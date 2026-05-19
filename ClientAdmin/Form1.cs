using ClientAdmin.Helpers;
using ClientAdmin.Models;
using Sunny.UI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace ClientAdmin
{
    public partial class Form1 : UIForm
    {
        private int? selectedDishId = null;
        private int? selectedOrderId = null;
        private int? selectedProductId = null;
        private int? selectedUserId = null;
        private System.Collections.Generic.List<TopDishStatDto> currentTopDishes = new();
        private readonly string[] _defaultCategories = { "热菜", "凉菜", "主食", "饮品", "汤类", "小吃" };
        private int? _selectedZoneId;
        private int? _selectedDiningTableId;
        private bool _managementTabsInitialized;
        private bool _showDeletedDishes;
        private System.Collections.Generic.List<DishCategoryDto> _dishCategories = new();

        private static readonly System.Collections.Generic.Dictionary<string, string> StatusMap = new()
        {
            { "待处理", "Pending" },
            { "已确认", "Confirmed" },
            { "制作中", "Preparing" },
            { "已出餐", "Ready" },
            { "配送中", "Delivering" },
            { "已完成", "Completed" },
            { "已取消", "Cancelled" }
        };

        private static readonly System.Collections.Generic.Dictionary<string, string> StatusMapReverse = StatusMap.ToDictionary(x => x.Value, x => x.Key);
        public Form1()
        {
            InitializeComponent();

            Text = "珞珈线上点餐系统-管理员端";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(1000, 650);

            InitDishGrid();
            InitOrderManagement();
            InitStatisticsPage();
            InitAiPage();
            InitializeManagementTabs();
        }

        private void InitDishGrid()
        {
            dgvDishes.ReadOnly = true;
            dgvDishes.AllowUserToAddRows = false;
            dgvDishes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDishes.MultiSelect = false;
            dgvDishes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            cmbSpicyLevel.Items.Clear();
            cmbSpicyLevel.Items.Add("0 - 不辣");
            cmbSpicyLevel.Items.Add("1 - 微辣");
            cmbSpicyLevel.Items.Add("2 - 中辣");
            cmbSpicyLevel.Items.Add("3 - 特辣");
            cmbSpicyLevel.SelectedIndex = 0;

            cmbSaleStatus.Items.Clear();
            cmbSaleStatus.Items.Add("可售");
            cmbSaleStatus.Items.Add("停售");
            cmbSaleStatus.Items.Add("缺货");
            cmbSaleStatus.SelectedIndex = 0;
            cmbDishCategory.DropDownStyle = UIDropDownStyle.DropDownList;

            txtImagePath.ReadOnly = true;

            // 图片预览设置
            picDishImage.SizeMode = PictureBoxSizeMode.Zoom;
            picDishImage.BorderStyle = BorderStyle.FixedSingle;
            picDishImage.Cursor = Cursors.Hand;
        }

        private int GetSelectedSpicyLevel()
        {
            if (cmbSpicyLevel.SelectedIndex < 0)
            {
                return 0;
            }

            return cmbSpicyLevel.SelectedIndex;
        }

        private string GetSelectedSaleStatus()
        {
            if (cmbSaleStatus.SelectedIndex < 0)
            {
                return "OnSale";
            }

            return cmbSaleStatus.SelectedIndex switch
            {
                0 => "OnSale",
                1 => "OffSale",
                2 => "OutOfStock",
                _ => "OnSale"
            };
        }

        private void SetSelectedSaleStatus(string? saleStatus)
        {
            cmbSaleStatus.SelectedIndex = saleStatus switch
            {
                "OnSale" or "可售" => 0,
                "OffSale" or "停售" => 1,
                "OutOfStock" or "缺货" => 2,
                _ => 0
            };
        }

        private string GetCurrentDishCategoryName()
        {
            if (cmbDishCategory.SelectedItem is DishCategoryOption option)
            {
                return option.Value.Name.Trim();
            }

            return cmbDishCategory.Text.Trim();
        }

        private void RebindDishCategoryOptions(int? selectedCategoryId = null, string? selectedCategoryName = null)
        {
            cmbDishCategory.Items.Clear();
            foreach (var category in _dishCategories
                         .Where(category => category.IsEnabled)
                         .OrderBy(category => category.SortOrder)
                         .ThenBy(category => category.Name))
            {
                cmbDishCategory.Items.Add(new DishCategoryOption(category));
            }

            SelectDishCategory(selectedCategoryId, selectedCategoryName);
        }

        private void SetSelectedSpicyLevel(int spicyLevel)
        {
            if (spicyLevel < 0)
            {
                spicyLevel = 0;
            }

            if (spicyLevel > 3)
            {
                spicyLevel = 3;
            }

            cmbSpicyLevel.SelectedIndex = spicyLevel;
        }

        //图片处理 找到 OnlineOrdering.API/wwwroot/images 文件夹，后面图片会复制到这里。
        private string GetApiImagesFolder()
        {
            var current = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (current != null)
            {
                var apiFolder = Path.Combine(current.FullName, "OnlineOrdering.API");

                if (Directory.Exists(apiFolder))
                {
                    var imagesFolder = Path.Combine(apiFolder, "wwwroot", "images");
                    Directory.CreateDirectory(imagesFolder);
                    return imagesFolder;
                }

                current = current.Parent;
            }

            throw new DirectoryNotFoundException("未找到 OnlineOrdering.API 项目目录，无法保存图片。");
        }

        //把 /images/xxx.jpg 转成本机实际路径，方便 PictureBox 预览。
        private string? GetLocalImageFilePath(string? imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                return null;
            }

            if (File.Exists(imagePath))
            {
                return imagePath;
            }

            if (imagePath.StartsWith("/images/", StringComparison.OrdinalIgnoreCase))
            {
                var fileName = Path.GetFileName(imagePath);
                return Path.Combine(GetApiImagesFolder(), fileName);
            }

            return null;
        }

        //把图片显示到 picDishImage，且不会锁死图片文件。
        private void ShowDishImage(string? imagePath)
        {
            if (picDishImage.Image != null)
            {
                var oldImage = picDishImage.Image;
                picDishImage.Image = null;
                oldImage.Dispose();
            }

            var localPath = GetLocalImageFilePath(imagePath);

            if (string.IsNullOrWhiteSpace(localPath) || !File.Exists(localPath))
            {
                return;
            }

            using var stream = new FileStream(localPath, FileMode.Open, FileAccess.Read);
            using var tempImage = Image.FromStream(stream);
            picDishImage.Image = new Bitmap(tempImage);
        }

        //加载表头
        private async Task LoadDishesAsync(bool recycleBin = false)
        {
            try
            {
                _showDeletedDishes = recycleBin;
                var endpoint = recycleBin ? "api/dishes/recycle-bin" : "api/dishes";
                var dishes = await ApiHelper.GetListAsync<DishDto>(endpoint);

                // 转换 SaleStatus 为中文显示
                foreach (var dish in dishes)
                {
                    dish.SaleStatus = dish.SaleStatus switch
                    {
                        "OnSale" => "可售",
                        "OffSale" => "停售",
                        "OutOfStock" => "缺货",
                        _ => dish.SaleStatus
                    };
                }

                dgvDishes.DataSource = null;
                dgvDishes.DataSource = dishes;

                SetDishGridHeaders();
                btnDeleteDish.Text = recycleBin ? "恢复菜品" : "删除菜品";
                btnAddDish.Enabled = !recycleBin;
                btnUpdateDish.Enabled = !recycleBin;
                grpDishEdit.Text = recycleBin ? "已删除菜品 / 回收站" : "菜品编辑";
                btnToggleDeletedDishes.Text = recycleBin ? "返回菜品列表" : "查看已删除";
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载菜品失败：" + ex.Message);
            }
        }
        private void SetDishGridHeaders()
        {
            PrepareAdminGrid(dgvDishes);

            if (dgvDishes.Columns["Id"] != null)
            {
                dgvDishes.Columns["Id"].HeaderText = "编号";
                dgvDishes.Columns["Id"].FillWeight = 50;
                dgvDishes.Columns["Id"].MinimumWidth = 60;
            }

            if (dgvDishes.Columns["Name"] != null)
            {
                dgvDishes.Columns["Name"].HeaderText = "菜品名称";
                dgvDishes.Columns["Name"].FillWeight = 130;
                dgvDishes.Columns["Name"].MinimumWidth = 140;
            }

            if (dgvDishes.Columns["Category"] != null)
            {
                dgvDishes.Columns["Category"].HeaderText = "分类";
                dgvDishes.Columns["Category"].FillWeight = 90;
                dgvDishes.Columns["Category"].MinimumWidth = 90;
            }

            if (dgvDishes.Columns["Price"] != null)
            {
                dgvDishes.Columns["Price"].HeaderText = "价格";
                dgvDishes.Columns["Price"].DefaultCellStyle.Format = "0.00";
                dgvDishes.Columns["Price"].FillWeight = 80;
                dgvDishes.Columns["Price"].MinimumWidth = 90;
            }

            if (dgvDishes.Columns["ImagePath"] != null)
            {
                dgvDishes.Columns["ImagePath"].HeaderText = "图片路径";
                dgvDishes.Columns["ImagePath"].FillWeight = 120;
                dgvDishes.Columns["ImagePath"].MinimumWidth = 140;
            }

            if (dgvDishes.Columns["SpicyLevel"] != null)
            {
                dgvDishes.Columns["SpicyLevel"].HeaderText = "辣度";
                dgvDishes.Columns["SpicyLevel"].FillWeight = 70;
                dgvDishes.Columns["SpicyLevel"].MinimumWidth = 80;
            }

            if (dgvDishes.Columns["IsAvailable"] != null)
            {
                dgvDishes.Columns["IsAvailable"].HeaderText = "是否可售";
                dgvDishes.Columns["IsAvailable"].FillWeight = 80;
                dgvDishes.Columns["IsAvailable"].MinimumWidth = 90;
            }

            if (dgvDishes.Columns["Description"] != null)
            {
                dgvDishes.Columns["Description"].HeaderText = "描述";
                dgvDishes.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDishes.Columns["Description"].FillWeight = 180;
                dgvDishes.Columns["Description"].MinimumWidth = 220;
            }

            if (dgvDishes.Columns["CategoryId"] != null)
                dgvDishes.Columns["CategoryId"].Visible = false;

            if (dgvDishes.Columns["SaleStatus"] != null)
            {
                dgvDishes.Columns["SaleStatus"].HeaderText = "销售状态";
                dgvDishes.Columns["SaleStatus"].FillWeight = 90;
                dgvDishes.Columns["SaleStatus"].MinimumWidth = 100;
            }

            if (dgvDishes.Columns["SortOrder"] != null)
            {
                dgvDishes.Columns["SortOrder"].HeaderText = "排序";
                dgvDishes.Columns["SortOrder"].FillWeight = 70;
                dgvDishes.Columns["SortOrder"].MinimumWidth = 80;
            }

            if (dgvDishes.Columns["DeletedAt"] != null)
            {
                dgvDishes.Columns["DeletedAt"].HeaderText = "删除时间";
                dgvDishes.Columns["DeletedAt"].MinimumWidth = 145;
                dgvDishes.Columns["DeletedAt"].Visible = _showDeletedDishes;
            }

            if (dgvDishes.Columns["DeleteReason"] != null)
            {
                dgvDishes.Columns["DeleteReason"].HeaderText = "删除原因";
                dgvDishes.Columns["DeleteReason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDishes.Columns["DeleteReason"].FillWeight = 160;
                dgvDishes.Columns["DeleteReason"].MinimumWidth = 220;
                dgvDishes.Columns["DeleteReason"].Visible = _showDeletedDishes;
            }
        }
        private async void btnLoadDishes_Click(object sender, EventArgs e)
        {
            await LoadDishesAsync(_showDeletedDishes);
        }

        private async void btnToggleDeletedDishes_Click(object sender, EventArgs e)
        {
            await LoadDishesAsync(!_showDeletedDishes);
        }

        private async void btnAddDish_Click(object sender, EventArgs e)
        {
            if (!ValidateDishInput(out decimal price))
            {
                return;
            }

            try
            {
                var dish = new DishDto
                {
                    Name = txtDishName.Text.Trim(),
                    CategoryId = GetSelectedDishCategoryId(),
                    Category = GetCurrentDishCategoryName(),
                    Price = price,
                    ImagePath = txtImagePath.Text.Trim(),
                    SpicyLevel = GetSelectedSpicyLevel(),
                    IsAvailable = GetSelectedSaleStatus() == "OnSale",
                    Description = txtDescription.Text.Trim(),
                    SaleStatus = GetSelectedSaleStatus(),
                    SortOrder = 0
                };

                await ApiHelper.PostAsync("api/Dishes", dish);

                MessageBox.Show("添加菜品成功");

                ClearDishInputs();
                await LoadDishesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加菜品失败：" + ex.Message);
            }
        }

        private async void btnUpdateDish_Click(object sender, EventArgs e)
        {
            if (selectedDishId == null)
            {
                MessageBox.Show("请先在表格中选择一个菜品");
                return;
            }

            if (!ValidateDishInput(out decimal price))
            {
                return;
            }

            try
            {
                var dish = new DishDto
                {
                    Id = selectedDishId.Value,
                    Name = txtDishName.Text.Trim(),
                    CategoryId = GetSelectedDishCategoryId(),
                    Category = GetCurrentDishCategoryName(),
                    Price = price,
                    ImagePath = txtImagePath.Text.Trim(),
                    SpicyLevel = GetSelectedSpicyLevel(),
                    IsAvailable = GetSelectedSaleStatus() == "OnSale",
                    Description = txtDescription.Text.Trim(),
                    SaleStatus = GetSelectedSaleStatus(),
                    SortOrder = 0
                };

                await ApiHelper.PutAsync($"api/Dishes/{selectedDishId.Value}", dish);

                MessageBox.Show("修改菜品成功");

                ClearDishInputs();
                await LoadDishesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改菜品失败：" + ex.Message);
            }
        }

        private async void btnDeleteDish_Click(object sender, EventArgs e)
        {
            if (selectedDishId == null)
            {
                MessageBox.Show("请先在表格中选择一个菜品");
                return;
            }

            if (_showDeletedDishes)
            {
                try
                {
                    await ApiHelper.PutAsync($"api/dishes/{selectedDishId.Value}/restore", new { });
                    MessageBox.Show("菜品已恢复，请根据需要重新上架。");
                    ClearDishInputs();
                    await LoadDishesAsync(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("恢复菜品失败：" + ex.Message);
                }

                return;
            }

            try
            {
                using var dialog = new Form();
                dialog.Text = "删除菜品原因";
                dialog.Size = new Size(420, 210);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                var label = new Label
                {
                    Text = "请输入删除原因：",
                    Location = new Point(20, 20),
                    Size = new Size(340, 24)
                };
                var textBox = new TextBox
                {
                    Location = new Point(20, 50),
                    Size = new Size(360, 28),
                    MaxLength = 200
                };
                var btnOk = new Button
                {
                    Text = "确定",
                    DialogResult = DialogResult.OK,
                    Location = new Point(210, 110),
                    Size = new Size(80, 32)
                };
                var btnCancel = new Button
                {
                    Text = "取消",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(300, 110),
                    Size = new Size(80, 32)
                };

                dialog.Controls.Add(label);
                dialog.Controls.Add(textBox);
                dialog.Controls.Add(btnOk);
                dialog.Controls.Add(btnCancel);
                dialog.AcceptButton = btnOk;
                dialog.CancelButton = btnCancel;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                await ApiHelper.DeleteAsync(
                    $"api/Dishes/{selectedDishId.Value}",
                    new DishDeleteDto { DeleteReason = textBox.Text.Trim() });

                MessageBox.Show("菜品已删除");

                ClearDishInputs();
                await LoadDishesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除菜品失败：" + ex.Message);
            }
        }

        private void dgvDishes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var dish = dgvDishes.Rows[e.RowIndex].DataBoundItem as DishDto;

            if (dish == null)
            {
                return;
            }

            selectedDishId = dish.Id;

            txtDishName.Text = dish.Name;
            txtPrice.Text = dish.Price.ToString("0.00");

            txtImagePath.Text = dish.ImagePath ?? "";
            txtDescription.Text = dish.Description ?? "";

            SetSelectedSpicyLevel(dish.SpicyLevel);
            SetSelectedSaleStatus(dish.SaleStatus);
            SelectDishCategory(dish.CategoryId, dish.Category);

            ShowDishImage(dish.ImagePath);
        }

        private bool ValidateDishInput(out decimal price)
        {
            price = 0;

            if (string.IsNullOrWhiteSpace(txtDishName.Text))
            {
                MessageBox.Show("请输入菜品名称");
                return false;
            }

            if (string.IsNullOrWhiteSpace(GetCurrentDishCategoryName()))
            {
                MessageBox.Show("请输入菜品分类");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("价格必须是数字");
                return false;
            }

            if (price <= 0)
            {
                MessageBox.Show("价格必须大于 0");
                return false;
            }

            return true;
        }

        private void ClearDishInputs()
        {
            selectedDishId = null;

            txtDishName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtImagePath.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cmbDishCategory.SelectedIndex = -1;
            cmbDishCategory.Text = string.Empty;

            SetSelectedSpicyLevel(0);
            SetSelectedSaleStatus("OnSale");

            if (picDishImage.Image != null)
            {
                var oldImage = picDishImage.Image;
                picDishImage.Image = null;
                oldImage.Dispose();
            }
        }


       //选择图片按钮
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();

            dialog.Title = "选择菜品图片";
            dialog.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                var sourceFile = dialog.FileName;
                var imagesFolder = GetApiImagesFolder();

                var extension = Path.GetExtension(sourceFile);
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourceFile);
                var safeFileName = $"{fileNameWithoutExtension}_{DateTime.Now:yyyyMMddHHmmss}{extension}";

                var targetFile = Path.Combine(imagesFolder, safeFileName);

                File.Copy(sourceFile, targetFile, true);

                txtImagePath.Text = $"/images/{safeFileName}";

                ShowDishImage(txtImagePath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择图片失败：" + ex.Message);
            }
        }

        //图片放大
        private void picDishImage_Click(object sender, EventArgs e)
        {
            if (picDishImage.Image == null)
            {
                MessageBox.Show("当前没有可预览的图片");
                return;
            }

            using var previewForm = new Form();

            previewForm.Text = "菜品图片预览";
            previewForm.StartPosition = FormStartPosition.CenterParent;
            previewForm.Size = new Size(800, 600);

            var bigPictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = picDishImage.Image
            };

            previewForm.Controls.Add(bigPictureBox);
            previewForm.ShowDialog();
        }


        //第二页 订单管理

        private void InitOrderManagement()
        {
            dgvOrders.ReadOnly = true;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvOrderItems.ReadOnly = true;
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItems.MultiSelect = false;
            dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ClearOrderDetail();

            dgvOrders.CellFormatting += DgvOrders_CellFormatting;

            InitOrderGridColumns();
        }

        private void InitOrderGridColumns()
        {
            dgvOrders.Columns.Clear();

            var columns = new (string Name, string HeaderText, int FillWeight, int MinWidth)[]
            {
                ("OrderNo", "业务单号", 120, 150),
                ("Id", "内部编号", 50, 70),
                ("OrderType", "类型", 50, 80),
                ("TableNumber", "桌号", 50, 80),
                ("TableSessionNo", "桌次", 115, 150),
                ("CustomerName", "顾客", 60, 90),
                ("Phone", "电话", 80, 120),
                ("Address", "配送地址", 180, 220),
                ("TotalAmount", "总金额", 70, 90),
                ("Status", "状态", 60, 90),
                ("CreatedAt", "下单时间", 80, 130)
            };

            for (int i = 0; i < columns.Length; i++)
            {
                var (name, headerText, fillWeight, minWidth) = columns[i];
                var col = new DataGridViewTextBoxColumn
                {
                    Name = name,
                    HeaderText = headerText,
                    FillWeight = fillWeight,
                    MinimumWidth = minWidth,
                    DisplayIndex = i
                };

                if (name == "TotalAmount")
                {
                    col.DefaultCellStyle.Format = "C2";
                }
                else if (name == "CreatedAt")
                {
                    col.DefaultCellStyle.Format = "MM-dd HH:mm";
                }
                else if (name == "Address")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                dgvOrders.Columns.Add(col);
            }

            PrepareAdminGrid(dgvOrders);
        }

        private void DgvOrders_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgvOrders.Columns[e.ColumnIndex];
            if (col?.Name == "OrderType" && e.Value is string orderType)
            {
                e.Value = GetDisplayText(orderType);
                e.FormattingApplied = true;
            }

            if (col?.Name == "Status" && e.Value is string status)
            {
                e.Value = StatusMapReverse.GetValueOrDefault(status, status);
                e.FormattingApplied = true;
            }
        }

        private async Task LoadOrdersAsync()
        {
            try
            {
                var orders = await ApiHelper.GetListAsync<OrderDto>("api/Orders");

                dgvOrders.Columns.Clear();
                dgvOrders.DataSource = null;
                dgvOrders.DataSource = orders;

                SetOrderGridHeaders();

                dgvOrderItems.DataSource = null;
                selectedOrderId = null;
                ClearOrderDetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载订单失败：" + ex.Message);
            }
        }

        private void SetOrderGridHeaders()
        {
            PrepareAdminGrid(dgvOrders);

            if (dgvOrders.Columns["OrderNo"] != null)
            {
                dgvOrders.Columns["OrderNo"].HeaderText = "业务单号";
                dgvOrders.Columns["OrderNo"].FillWeight = 120;
                dgvOrders.Columns["OrderNo"].MinimumWidth = 150;
                dgvOrders.Columns["OrderNo"].DisplayIndex = 0;
            }

            if (dgvOrders.Columns["Id"] != null)
            {
                dgvOrders.Columns["Id"].HeaderText = "内部编号";
                dgvOrders.Columns["Id"].FillWeight = 50;
                dgvOrders.Columns["Id"].MinimumWidth = 70;
                dgvOrders.Columns["Id"].DisplayIndex = 1;
            }

            if (dgvOrders.Columns["OrderType"] != null)
            {
                dgvOrders.Columns["OrderType"].HeaderText = "类型";
                dgvOrders.Columns["OrderType"].FillWeight = 50;
                dgvOrders.Columns["OrderType"].MinimumWidth = 80;
                dgvOrders.Columns["OrderType"].DisplayIndex = 2;
            }

            if (dgvOrders.Columns["TableNumber"] != null)
            {
                dgvOrders.Columns["TableNumber"].HeaderText = "桌号";
                dgvOrders.Columns["TableNumber"].FillWeight = 50;
                dgvOrders.Columns["TableNumber"].MinimumWidth = 80;
                dgvOrders.Columns["TableNumber"].DisplayIndex = 3;
            }

            if (dgvOrders.Columns["TableSessionNo"] != null)
            {
                dgvOrders.Columns["TableSessionNo"].HeaderText = "桌次";
                dgvOrders.Columns["TableSessionNo"].FillWeight = 115;
                dgvOrders.Columns["TableSessionNo"].MinimumWidth = 150;
                dgvOrders.Columns["TableSessionNo"].DisplayIndex = 4;
            }

            if (dgvOrders.Columns["CustomerName"] != null)
            {
                dgvOrders.Columns["CustomerName"].HeaderText = "顾客";
                dgvOrders.Columns["CustomerName"].FillWeight = 60;
                dgvOrders.Columns["CustomerName"].MinimumWidth = 90;
                dgvOrders.Columns["CustomerName"].DisplayIndex = 5;
            }

            if (dgvOrders.Columns["Phone"] != null)
            {
                dgvOrders.Columns["Phone"].HeaderText = "电话";
                dgvOrders.Columns["Phone"].FillWeight = 80;
                dgvOrders.Columns["Phone"].MinimumWidth = 120;
                dgvOrders.Columns["Phone"].DisplayIndex = 6;
            }

            if (dgvOrders.Columns["Address"] != null)
            {
                dgvOrders.Columns["Address"].HeaderText = "配送地址";
                dgvOrders.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvOrders.Columns["Address"].FillWeight = 180;
                dgvOrders.Columns["Address"].MinimumWidth = 220;
                dgvOrders.Columns["Address"].DisplayIndex = 7;
            }

            if (dgvOrders.Columns["TotalAmount"] != null)
            {
                dgvOrders.Columns["TotalAmount"].HeaderText = "总金额";
                dgvOrders.Columns["TotalAmount"].FillWeight = 70;
                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
                dgvOrders.Columns["TotalAmount"].MinimumWidth = 90;
                dgvOrders.Columns["TotalAmount"].DisplayIndex = 8;
            }

            if (dgvOrders.Columns["Status"] != null)
            {
                dgvOrders.Columns["Status"].HeaderText = "状态";
                dgvOrders.Columns["Status"].FillWeight = 60;
                dgvOrders.Columns["Status"].MinimumWidth = 90;
                dgvOrders.Columns["Status"].DisplayIndex = 9;
            }

            if (dgvOrders.Columns["CreatedAt"] != null)
            {
                dgvOrders.Columns["CreatedAt"].HeaderText = "下单时间";
                dgvOrders.Columns["CreatedAt"].FillWeight = 80;
                dgvOrders.Columns["CreatedAt"].DefaultCellStyle.Format = "MM-dd HH:mm";
                dgvOrders.Columns["CreatedAt"].MinimumWidth = 130;
                dgvOrders.Columns["CreatedAt"].DisplayIndex = 10;
            }

            if (dgvOrders.Columns["OrderItems"] != null)
                dgvOrders.Columns["OrderItems"].Visible = false;

            if (dgvOrders.Columns["Note"] != null)
                dgvOrders.Columns["Note"].Visible = false;

            if (dgvOrders.Columns["DeliveryFee"] != null)
                dgvOrders.Columns["DeliveryFee"].Visible = false;

            if (dgvOrders.Columns["DiningTableId"] != null)
                dgvOrders.Columns["DiningTableId"].Visible = false;

            if (dgvOrders.Columns["DeliveryZoneId"] != null)
                dgvOrders.Columns["DeliveryZoneId"].Visible = false;

            if (dgvOrders.Columns["DeliveryRegion"] != null)
                dgvOrders.Columns["DeliveryRegion"].Visible = false;

            if (dgvOrders.Columns["CancelReason"] != null)
                dgvOrders.Columns["CancelReason"].Visible = false;

            if (dgvOrders.Columns["EstimatedMinutes"] != null)
                dgvOrders.Columns["EstimatedMinutes"].Visible = false;

            if (dgvOrders.Columns["DeliveryPersonName"] != null)
                dgvOrders.Columns["DeliveryPersonName"].Visible = false;

            if (dgvOrders.Columns["DeliveryPersonPhone"] != null)
                dgvOrders.Columns["DeliveryPersonPhone"].Visible = false;

            if (dgvOrders.Columns["TableSessionId"] != null)
                dgvOrders.Columns["TableSessionId"].Visible = false;
        }

        private void SetOrderItemGridHeaders()
        {
            PrepareAdminGrid(dgvOrderItems);

            if (dgvOrderItems.Columns["Id"] != null)
            {
                dgvOrderItems.Columns["Id"].HeaderText = "明细编号";
                dgvOrderItems.Columns["Id"].FillWeight = 60;
                dgvOrderItems.Columns["Id"].MinimumWidth = 80;
            }

            if (dgvOrderItems.Columns["OrderId"] != null)
            {
                dgvOrderItems.Columns["OrderId"].HeaderText = "订单编号";
                dgvOrderItems.Columns["OrderId"].FillWeight = 60;
                dgvOrderItems.Columns["OrderId"].MinimumWidth = 80;
            }

            if (dgvOrderItems.Columns["DishId"] != null)
            {
                dgvOrderItems.Columns["DishId"].HeaderText = "菜品编号";
                dgvOrderItems.Columns["DishId"].FillWeight = 60;
                dgvOrderItems.Columns["DishId"].MinimumWidth = 80;
            }

            if (dgvOrderItems.Columns["DishName"] != null)
            {
                dgvOrderItems.Columns["DishName"].HeaderText = "菜品名称";
                dgvOrderItems.Columns["DishName"].FillWeight = 100;
                dgvOrderItems.Columns["DishName"].MinimumWidth = 120;
            }

            if (dgvOrderItems.Columns["Price"] != null)
            {
                dgvOrderItems.Columns["Price"].HeaderText = "单价";
                dgvOrderItems.Columns["Price"].FillWeight = 70;
                dgvOrderItems.Columns["Price"].DefaultCellStyle.Format = "C2";
                dgvOrderItems.Columns["Price"].MinimumWidth = 90;
            }

            if (dgvOrderItems.Columns["Quantity"] != null)
            {
                dgvOrderItems.Columns["Quantity"].HeaderText = "数量";
                dgvOrderItems.Columns["Quantity"].FillWeight = 50;
                dgvOrderItems.Columns["Quantity"].MinimumWidth = 80;
            }

            if (dgvOrderItems.Columns["DishCategorySnapshot"] != null)
                dgvOrderItems.Columns["DishCategorySnapshot"].Visible = false;

            if (dgvOrderItems.Columns["Subtotal"] != null)
            {
                dgvOrderItems.Columns["Subtotal"].HeaderText = "小计";
                dgvOrderItems.Columns["Subtotal"].FillWeight = 70;
                dgvOrderItems.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                dgvOrderItems.Columns["Subtotal"].MinimumWidth = 90;
            }
        }

        private async void btnLoadOrders_Click(object sender, EventArgs e)
        {
            await LoadOrdersAsync();
        }

        private OrderDto? _selectedOrder = null;

        private async void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var order = dgvOrders.Rows[e.RowIndex].DataBoundItem as OrderDto;

            if (order == null)
            {
                return;
            }

            selectedOrderId = order.Id;
            _selectedOrder = order;

            ShowOrderDetail(order);
            BindOrderItems(order);
            UpdateOrderActionButtons(order.Status, order.OrderType);
            await LoadOrderStatusHistoryAsync(order);
        }

        private void ShowOrderDetail(OrderDto order)
        {
            lblOrderId.Text = $"订单编号：{(string.IsNullOrWhiteSpace(order.OrderNo) ? order.Id.ToString() : order.OrderNo)}";
            lblOrderType.Text = $"订单类型：{GetDisplayText(order.OrderType)}";
            lblCustomerName.Text = $"顾客姓名：{order.CustomerName}";
            lblPhone.Text = $"电话：{GetDisplayText(order.Phone)}";
            lblTableNumber.Text = $"桌号 / 桌次：{GetDisplayText(order.TableNumber)} / {GetDisplayText(order.TableSessionNo)}";
            lblAddress.Text = "配送地址：";
            txtOrderAddress.Text = GetDisplayText(BuildFullDeliveryAddress(order));
            lblNote.Text = "备注 / 状态轨迹：";
            txtOrderNote.Text = GetDisplayText(order.Note);
            lblDeliveryFee.Text = $"配送费：{order.DeliveryFee:0.00} 元";
            lblTotalAmount.Text = $"总金额：{order.TotalAmount:0.00} 元";
            lblStatus.Text = $"状态：{StatusMapReverse.GetValueOrDefault(order.Status, order.Status)}";
            lblCreatedAt.Text = $"创建时间：{order.CreatedAt:yyyy-MM-dd HH:mm:ss}";
        }

        private void BindOrderItems(OrderDto order)
        {
            dgvOrderItems.DataSource = null;
            dgvOrderItems.DataSource = order.OrderItems;

            SetOrderItemGridHeaders();
        }

        private static string? BuildFullDeliveryAddress(OrderDto order)
        {
            var fullAddress = string.Join(
                " ",
                new[] { order.DeliveryRegion, order.Address }.Where(value => !string.IsNullOrWhiteSpace(value)));

            return string.IsNullOrWhiteSpace(fullAddress) ? null : fullAddress;
        }

        private async Task LoadOrderStatusHistoryAsync(OrderDto order)
        {
            try
            {
                var histories = await ApiHelper.GetOrderStatusHistoryAsync(order.Id);
                if (histories.Count == 0)
                {
                    return;
                }

                var historyLines = histories.Select(history =>
                    $"{history.CreatedAt:MM-dd HH:mm}  {StatusMapReverse.GetValueOrDefault(history.FromStatus, history.FromStatus)} -> {StatusMapReverse.GetValueOrDefault(history.ToStatus, history.ToStatus)}" +
                    (string.IsNullOrWhiteSpace(history.Remark) ? string.Empty : $"（{history.Remark}）"));

                var note = string.IsNullOrWhiteSpace(order.Note) ? "无" : order.Note;
                txtOrderNote.Text = $"{note}{Environment.NewLine}{Environment.NewLine}状态轨迹：{Environment.NewLine}{string.Join(Environment.NewLine, historyLines)}";
            }
            catch
            {
            }
        }

        // ========== 订单工作台模式 ==========

        private void UpdateOrderActionButtons(string status, string? orderType)
        {
            // 隐藏所有操作按钮
            HideAllOrderActionButtons();

            // 根据状态显示对应的按钮
            switch (status)
            {
                case "Pending":
                    btnConfirmOrder.Visible = true;
                    btnConfirmOrder.Enabled = true;
                    btnRejectOrder.Visible = true;
                    btnRejectOrder.Enabled = true;
                    lblOrderActionHint.Text = "待处理订单：请接单或拒单";
                    break;

                case "Confirmed":
                    btnStartPreparing.Visible = true;
                    btnStartPreparing.Enabled = true;
                    btnCancelOrder.Visible = true;
                    btnCancelOrder.Enabled = true;
                    lblOrderActionHint.Text = "已确认订单：请开始制作或取消订单";
                    break;

                case "Preparing":
                    btnReady.Visible = true;
                    btnReady.Enabled = true;
                    btnCancelOrder.Visible = true;
                    btnCancelOrder.Enabled = true;
                    lblOrderActionHint.Text = "制作中订单：请完成出餐或取消订单";
                    break;

                case "Ready":
                    if (orderType == "Delivery")
                    {
                        btnStartDelivery.Visible = true;
                        btnStartDelivery.Enabled = true;
                    }
                    btnCompleteOrder.Visible = true;
                    btnCompleteOrder.Enabled = true;
                    lblOrderActionHint.Text = orderType == "Delivery" ? "已出餐：请开始配送或直接完成" : "已出餐：请完成订单";
                    break;

                case "Delivering":
                    btnCompleteOrder.Visible = true;
                    btnCompleteOrder.Enabled = true;
                    btnCompleteOrder.Text = "确认送达";
                    lblOrderActionHint.Text = "配送中：请点击确认送达";
                    break;

                case "Completed":
                case "Cancelled":
                    lblOrderActionHint.Text = "订单已结束，无需操作";
                    break;

                default:
                    lblOrderActionHint.Text = "请选择订单";
                    break;
            }
        }

        private void HideAllOrderActionButtons()
        {
            btnConfirmOrder.Visible = false;
            btnRejectOrder.Visible = false;
            btnStartPreparing.Visible = false;
            btnReady.Visible = false;
            btnStartDelivery.Visible = false;
            btnCompleteOrder.Visible = false;
            btnCancelOrder.Visible = false;

            // 重置按钮文字
            btnCompleteOrder.Text = "完成订单";
        }

        private async Task UpdateOrderStatusAsync(string newStatus, string? reason = null)
        {
            if (selectedOrderId == null)
            {
                MessageBox.Show("请先选择一个订单");
                return;
            }

            try
            {
                var dto = new
                {
                    Status = newStatus,
                    CancelReason = reason
                };

                await ApiHelper.PutAsync($"api/Orders/{selectedOrderId.Value}/status", dto);

                MessageBox.Show("订单状态更新成功");

                await LoadOrdersAsync();

                // 更新按钮状态
                if (_selectedOrder != null)
                {
                    _selectedOrder.Status = newStatus;
                    UpdateOrderActionButtons(newStatus, _selectedOrder.OrderType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新订单状态失败：" + ex.Message);
            }
        }

        // 接单：Pending -> Confirmed
        private async void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("确认接单？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await UpdateOrderStatusAsync("Confirmed");
            }
        }

        // 拒单：Pending -> Cancelled，需要弹窗输入原因
        private async void btnRejectOrder_Click(object sender, EventArgs e)
        {
            using var dialog = new Form();
            dialog.Text = "拒单原因";
            dialog.Size = new Size(400, 200);
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.MaximizeBox = false;
            dialog.MinimizeBox = false;

            var label = new Label
            {
                Text = "请输入拒单原因：",
                Location = new Point(20, 20),
                Size = new Size(350, 25)
            };

            var textBox = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(350, 25),
                MaxLength = 200
            };

            var btnOk = new Button
            {
                Text = "确定",
                DialogResult = DialogResult.OK,
                Location = new Point(200, 100),
                Size = new Size(80, 30)
            };

            var btnCancel = new Button
            {
                Text = "取消",
                DialogResult = DialogResult.Cancel,
                Location = new Point(290, 100),
                Size = new Size(80, 30)
            };

            dialog.Controls.Add(label);
            dialog.Controls.Add(textBox);
            dialog.Controls.Add(btnOk);
            dialog.Controls.Add(btnCancel);
            dialog.AcceptButton = btnOk;
            dialog.CancelButton = btnCancel;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var reason = textBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(reason))
                {
                    MessageBox.Show("请输入拒单原因");
                    return;
                }
                await UpdateOrderStatusAsync("Cancelled", reason);
            }
        }

        // 开始制作：Confirmed -> Preparing
        private async void btnStartPreparing_Click(object sender, EventArgs e)
        {
            await UpdateOrderStatusAsync("Preparing");
        }

        // 出餐完成：Preparing -> Ready
        private async void btnReady_Click(object sender, EventArgs e)
        {
            await UpdateOrderStatusAsync("Ready");
        }

        // 开始配送：Ready -> Delivering，外卖专用
        private async void btnStartDelivery_Click(object sender, EventArgs e)
        {
            await UpdateOrderStatusAsync("Delivering");
        }

        // 完成订单：Ready/Delivering -> Completed
        private async void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            await UpdateOrderStatusAsync("Completed");
        }

        // 取消订单，需要弹窗输入原因
        private async void btnCancelOrder_Click(object sender, EventArgs e)
        {
            using var dialog = new Form();
            dialog.Text = "取消订单原因";
            dialog.Size = new Size(400, 200);
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.MaximizeBox = false;
            dialog.MinimizeBox = false;

            var label = new Label
            {
                Text = "请输入取消订单的原因：",
                Location = new Point(20, 20),
                Size = new Size(350, 25)
            };

            var textBox = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(350, 25),
                MaxLength = 200
            };

            var btnOk = new Button
            {
                Text = "确定",
                DialogResult = DialogResult.OK,
                Location = new Point(200, 100),
                Size = new Size(80, 30)
            };

            var btnCancel = new Button
            {
                Text = "取消",
                DialogResult = DialogResult.Cancel,
                Location = new Point(290, 100),
                Size = new Size(80, 30)
            };

            dialog.Controls.Add(label);
            dialog.Controls.Add(textBox);
            dialog.Controls.Add(btnOk);
            dialog.Controls.Add(btnCancel);
            dialog.AcceptButton = btnOk;
            dialog.CancelButton = btnCancel;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var reason = textBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(reason))
                {
                    MessageBox.Show("请输入取消原因");
                    return;
                }
                await UpdateOrderStatusAsync("Cancelled", reason);
            }
        }

        private void ClearOrderDetail()
        {
            lblOrderId.Text = "订单编号：";
            lblOrderType.Text = "订单类型：";
            lblCustomerName.Text = "顾客姓名：";
            lblPhone.Text = "电话：";
            lblTableNumber.Text = "桌号：";
            lblAddress.Text = "配送地址：";
            txtOrderAddress.Text = string.Empty;
            lblNote.Text = "备注：";
            txtOrderNote.Text = string.Empty;
            lblDeliveryFee.Text = "配送费：";
            lblTotalAmount.Text = "总金额：";
            lblStatus.Text = "状态：";
            lblCreatedAt.Text = "创建时间：";

            // 清空订单时隐藏操作按钮
            _selectedOrder = null;
            HideAllOrderActionButtons();
            lblOrderActionHint.Text = "请选择订单";
        }

        private string GetDisplayText(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "无";
            }

            return value switch
            {
                "DineIn" => "堂食",
                "Delivery" => "外卖",
                _ => value
            };
        }

        private void InitStatisticsPage()
        {
            dgvTopDishes.ReadOnly = true;
            dgvTopDishes.AllowUserToAddRows = false;
            dgvTopDishes.AllowUserToDeleteRows = false;
            dgvTopDishes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopDishes.MultiSelect = false;
            dgvTopDishes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRevenueStatistics.ReadOnly = true;
            dgvRevenueStatistics.AllowUserToAddRows = false;
            dgvRevenueStatistics.AllowUserToDeleteRows = false;
            dgvRevenueStatistics.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenueStatistics.MultiSelect = false;
            dgvRevenueStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtpStatisticsStart.Value = DateTime.Today.AddDays(-7);
            dtpStatisticsEnd.Value = DateTime.Today;
            txtTopCount.Text = "5";
            panelTopDishesChart.Paint += panelTopDishesChart_Paint;
            panelTopDishesChart.Resize += (_, _) => panelTopDishesChart.Invalidate();

            InitStatisticsGridColumns();
            ResetStatisticsDisplay();
        }

        private void InitStatisticsGridColumns()
        {
            // 初始化热销菜品排行表格
            dgvTopDishes.Columns.Clear();

            var topDishColumns = new (string Name, string HeaderText, int FillWeight, int MinWidth)[]
            {
                ("DishId", "菜品编号", 80, 100),
                ("DishName", "菜品名称", 120, 150),
                ("TotalQuantity", "销量", 80, 100),
                ("TotalRevenue", "销售额", 100, 120)
            };

            for (int i = 0; i < topDishColumns.Length; i++)
            {
                var (name, headerText, fillWeight, minWidth) = topDishColumns[i];
                var col = new DataGridViewTextBoxColumn
                {
                    Name = name,
                    HeaderText = headerText,
                    FillWeight = fillWeight,
                    MinimumWidth = minWidth,
                    DisplayIndex = i
                };

                if (name == "TotalRevenue")
                {
                    col.DefaultCellStyle.Format = "0.00";
                }

                dgvTopDishes.Columns.Add(col);
            }

            PrepareAdminGrid(dgvTopDishes);

            // 初始化营收统计表格
            dgvRevenueStatistics.Columns.Clear();

            var revenueColumns = new (string Name, string HeaderText, int FillWeight, int MinWidth)[]
            {
                ("Metric", "统计项", 120, 150),
                ("Value", "数值", 120, 150)
            };

            for (int i = 0; i < revenueColumns.Length; i++)
            {
                var (name, headerText, fillWeight, minWidth) = revenueColumns[i];
                var col = new DataGridViewTextBoxColumn
                {
                    Name = name,
                    HeaderText = headerText,
                    FillWeight = fillWeight,
                    MinimumWidth = minWidth,
                    DisplayIndex = i
                };

                dgvRevenueStatistics.Columns.Add(col);
            }

            PrepareAdminGrid(dgvRevenueStatistics);

            // 添加默认行
            var defaultStats = new[]
            {
                new { Metric = "总订单数", Value = "0" },
                new { Metric = "总销售额", Value = "0.00 元" },
                new { Metric = "平均客单价", Value = "0.00 元" }
            };

            foreach (var stat in defaultStats)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dgvRevenueStatistics, stat.Metric, stat.Value);
                dgvRevenueStatistics.Rows.Add(row);
            }
        }

        private void InitAiPage()
        {
            txtAiSuggestion.Text = "暂无经营建议，请点击“获取经营建议”。";
            txtAiError.Text = "暂无错误。";
        }

        private async Task LoadStatisticsAsync()
        {
            ValidateStatisticsRange();

            var requestedTopCount = GetRequestedTopCount();

            try
            {
                var query = BuildStatisticsQueryString(requestedTopCount);
                var topDishesTask = ApiHelper.GetListAsync<TopDishStatDto>($"api/statistics/top-dishes{query}");
                var revenueTask = ApiHelper.GetAsync<RevenueStatDto>($"api/statistics/revenue{query}");

                await Task.WhenAll(topDishesTask, revenueTask);

                var topDishes = await topDishesTask;
                var revenue = await revenueTask ?? new RevenueStatDto();

                BindTopDishes(topDishes);
                BindRevenueStatistics(revenue);
                UpdateStatisticsSummary(topDishes, revenue);
                UpdateStatisticsRemark(requestedTopCount, topDishes.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载统计数据失败：" + ex.Message);
            }
        }

        private string BuildStatisticsQueryString(int topCount)
        {
            var startDate = dtpStatisticsStart.Value.Date.ToString("yyyy-MM-dd");
            var endDate = dtpStatisticsEnd.Value.Date.ToString("yyyy-MM-dd");
            return $"?topCount={topCount}&startDate={startDate}&endDate={endDate}";
        }

        private void ValidateStatisticsRange()
        {
            if (dtpStatisticsStart.Value.Date > dtpStatisticsEnd.Value.Date)
            {
                throw new InvalidOperationException("开始日期不能晚于结束日期。");
            }
        }

        private int GetRequestedTopCount()
        {
            var topCount = txtTopCount.IntValue;

            if (topCount <= 0 && int.TryParse(txtTopCount.Text, out var parsedTopCount))
            {
                topCount = parsedTopCount;
            }

            if (topCount <= 0)
            {
                topCount = 5;
            }

            topCount = Math.Clamp(topCount, 1, 50);
            txtTopCount.Text = topCount.ToString();
            return topCount;
        }

        private void BindTopDishes(System.Collections.Generic.List<TopDishStatDto> topDishes)
        {
            currentTopDishes = topDishes;

            dgvTopDishes.Columns.Clear();
            dgvTopDishes.DataSource = null;
            dgvTopDishes.DataSource = topDishes;

            lblChartPlaceholder.Visible = topDishes.Count == 0;
            panelTopDishesChart.Invalidate();

            if (dgvTopDishes.Columns["DishId"] != null)
                dgvTopDishes.Columns["DishId"].HeaderText = "菜品编号";

            if (dgvTopDishes.Columns["DishName"] != null)
                dgvTopDishes.Columns["DishName"].HeaderText = "菜品名称";

            if (dgvTopDishes.Columns["TotalQuantity"] != null)
                dgvTopDishes.Columns["TotalQuantity"].HeaderText = "销量";

            if (dgvTopDishes.Columns["TotalRevenue"] != null)
            {
                dgvTopDishes.Columns["TotalRevenue"].HeaderText = "销售额";
                dgvTopDishes.Columns["TotalRevenue"].DefaultCellStyle.Format = "0.00";
            }
        }

        private void BindRevenueStatistics(RevenueStatDto revenue)
        {
            var rows = new[]
            {
                new StatisticsGridRow("总订单数", revenue.TotalOrderCount.ToString()),
                new StatisticsGridRow("总销售额", $"{revenue.TotalRevenue:0.00} 元"),
                new StatisticsGridRow("平均客单价", $"{revenue.AverageOrderAmount:0.00} 元")
            };

            dgvRevenueStatistics.Columns.Clear();
            dgvRevenueStatistics.DataSource = null;
            dgvRevenueStatistics.DataSource = rows.ToList();

            if (dgvRevenueStatistics.Columns["Metric"] != null)
                dgvRevenueStatistics.Columns["Metric"].HeaderText = "统计项";

            if (dgvRevenueStatistics.Columns["Value"] != null)
                dgvRevenueStatistics.Columns["Value"].HeaderText = "数值";
        }

        private void UpdateStatisticsSummary(System.Collections.Generic.List<TopDishStatDto> topDishes, RevenueStatDto revenue)
        {
            lblTotalOrders.Text = $"订单数：{revenue.TotalOrderCount}";
            lblTotalRevenue.Text = $"销售额：{revenue.TotalRevenue:0.00} 元";
            lblAverageOrderAmount.Text = $"平均客单价：{revenue.AverageOrderAmount:0.00} 元";
            lblTopDishCount.Text = $"热销菜品数：{topDishes.Count}";
        }

        private void UpdateStatisticsRemark(int requestedTopCount, int actualCount)
        {
            var remark = $"统计区间：{dtpStatisticsStart.Value:yyyy-MM-dd} 至 {dtpStatisticsEnd.Value:yyyy-MM-dd}。";
            remark += $"{Environment.NewLine}热销菜品展示数量：前 {requestedTopCount} 条，当前返回 {actualCount} 条。";
            remark += $"{Environment.NewLine}统计数据来源于订单和订单明细，已取消订单不计入营收。";
            txtStatisticsRemark.Text = remark;
        }

        private void ResetStatisticsDisplay()
        {
            currentTopDishes = new System.Collections.Generic.List<TopDishStatDto>();
            dgvTopDishes.DataSource = null;
            dgvRevenueStatistics.DataSource = null;
            lblChartPlaceholder.Visible = true;
            panelTopDishesChart.Invalidate();

            lblTotalOrders.Text = "订单数：暂无数据";
            lblTotalRevenue.Text = "销售额：暂无数据";
            lblAverageOrderAmount.Text = "平均客单价：暂无数据";
            lblTopDishCount.Text = "热销菜品数：暂无数据";
            txtStatisticsRemark.Text = "统计数据来源于订单和订单明细，已取消订单不计入营收。";
        }

        private async Task LoadAiSuggestionsAsync()
        {
            ValidateStatisticsRange();

            var requestedTopCount = GetRequestedTopCount();

            try
            {
                var query = BuildStatisticsQueryString(requestedTopCount);
                var response = await ApiHelper.GetAsync<AiOperationSuggestResponseDto>($"api/ai/suggest-operation{query}")
                    ?? new AiOperationSuggestResponseDto();

                if (response.Suggestions.Count == 0)
                {
                    txtAiSuggestion.Text = "暂无经营建议，请先准备统计数据后再试。";
                }
                else
                {
                    txtAiSuggestion.Text = string.Join(
                        $"{Environment.NewLine}{Environment.NewLine}",
                        response.Suggestions.Select((suggestion, index) => $"{index + 1}. {suggestion}")
                    );
                }

                txtAiError.Text = "暂无错误。";
            }
            catch (Exception ex)
            {
                txtAiSuggestion.Text = "暂无经营建议，请检查接口或统计数据后重试。";
                txtAiError.Text = ex.Message;
            }
        }

        private void ResetAiDisplay()
        {
            txtAiSuggestion.Text = "暂无经营建议，请点击“获取经营建议”。";
            txtAiError.Text = "暂无错误。";
        }

        private async void btnLoadStatistics_Click(object sender, EventArgs e)
        {
            await LoadStatisticsAsync();
        }

        private void btnResetStatistics_Click(object sender, EventArgs e)
        {
            dtpStatisticsStart.Value = DateTime.Today.AddDays(-7);
            dtpStatisticsEnd.Value = DateTime.Today;
            txtTopCount.Text = "5";

            ResetStatisticsDisplay();
            ResetAiDisplay();
        }

        private async void btnLoadAiSuggestion_Click(object sender, EventArgs e)
        {
            await LoadAiSuggestionsAsync();
        }

        private void panelTopDishesChart_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.FromArgb(250, 252, 255));

            if (currentTopDishes.Count == 0)
            {
                return;
            }

            var bounds = panelTopDishesChart.ClientRectangle;
            if (bounds.Width < 120 || bounds.Height < 100)
            {
                return;
            }

            var chartArea = new Rectangle(58, 24, Math.Max(120, bounds.Width - 82), Math.Max(100, bounds.Height - 76));
            var maxQuantity = Math.Max(1, currentTopDishes.Max(item => item.TotalQuantity));
            var barCount = currentTopDishes.Count;
            var gap = Math.Max(14, Math.Min(28, chartArea.Width / Math.Max(1, barCount * 4)));
            var availableWidth = Math.Max(1, chartArea.Width - gap * (barCount + 1));
            var barWidth = Math.Max(26, Math.Min(72, availableWidth / Math.Max(1, barCount)));

            using var axisPen = new Pen(Color.FromArgb(170, 190, 215), 1.2f);
            using var gridPen = new Pen(Color.FromArgb(225, 235, 248), 1f);
            using var textBrush = new SolidBrush(Color.FromArgb(70, 84, 103));
            using var valueBrush = new SolidBrush(Color.FromArgb(24, 95, 170));
            using var valueFont = new Font("微软雅黑", 9F, FontStyle.Bold);
            using var labelFont = new Font("微软雅黑", 9F, FontStyle.Regular);

            for (var i = 0; i <= 4; i++)
            {
                var y = chartArea.Bottom - (chartArea.Height * i / 4);
                e.Graphics.DrawLine(gridPen, chartArea.Left, y, chartArea.Right, y);
            }

            e.Graphics.DrawLine(axisPen, chartArea.Left, chartArea.Bottom, chartArea.Right, chartArea.Bottom);
            e.Graphics.DrawLine(axisPen, chartArea.Left, chartArea.Top, chartArea.Left, chartArea.Bottom);

            for (var i = 0; i < barCount; i++)
            {
                var dish = currentTopDishes[i];
                var ratio = dish.TotalQuantity / (float)maxQuantity;
                var barHeight = Math.Max(8, (int)((chartArea.Height - 30) * ratio));
                var x = chartArea.Left + gap + i * (barWidth + gap);
                var y = chartArea.Bottom - barHeight;
                var barRect = new Rectangle(x, y, barWidth, barHeight);

                using var barBrush = new LinearGradientBrush(
                    barRect,
                    Color.FromArgb(255, 154, 86),
                    Color.FromArgb(255, 109, 0),
                    LinearGradientMode.Vertical
                );

                using var barPath = RoundedRectangle(barRect, 8);
                e.Graphics.FillPath(barBrush, barPath);

                var quantityText = dish.TotalQuantity.ToString();
                var quantitySize = e.Graphics.MeasureString(quantityText, valueFont);
                e.Graphics.DrawString(
                    quantityText,
                    valueFont,
                    valueBrush,
                    x + (barWidth - quantitySize.Width) / 2,
                    Math.Max(chartArea.Top, y - quantitySize.Height - 4)
                );

                var dishName = dish.DishName.Length > 7 ? $"{dish.DishName[..7]}…" : dish.DishName;
                var labelRect = new RectangleF(x - 8, chartArea.Bottom + 6, barWidth + 16, 28);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Near
                };
                e.Graphics.DrawString(dishName, labelFont, textBrush, labelRect, format);
            }
        }

        private static GraphicsPath RoundedRectangle(Rectangle rectangle, int radius)
        {
            var path = new GraphicsPath();
            var diameter = radius * 2;
            var arc = new Rectangle(rectangle.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90);
            arc.X = rectangle.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rectangle.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rectangle.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void InitializeManagementTabs()
        {
            if (_managementTabsInitialized)
            {
                return;
            }

            _managementTabsInitialized = true;
            ApplyManagementTextAndTheme();
            BindManagementEvents();
            Load += AdminForm_Load;
            dgvOrders.SelectionChanged += (_, _) => RefreshOrderAddressDisplay();
        }

        private void BindManagementEvents()
        {
            btnLoadDeliveryZones.Click += async (_, _) => await LoadDeliveryZonesAsync();
            btnAddDeliveryZone.Click += async (_, _) => await AddDeliveryZoneAsync();
            btnUpdateDeliveryZone.Click += async (_, _) => await UpdateDeliveryZoneAsync();
            btnDeleteDeliveryZone.Click += async (_, _) => await DeleteDeliveryZoneAsync();
            btnRestoreDeliveryZone.Click += async (_, _) => await RestoreDeliveryZoneAsync();
            dgvDeliveryZones.CellClick += DeliveryZonesGrid_CellClick;

            InitDeliveryZoneGridColumns();

            btnLoadDiningTables.Click += async (_, _) => await LoadDiningTablesAsync();
            btnAddDiningTable.Click += async (_, _) => await AddDiningTableAsync();
            btnUpdateDiningTable.Click += async (_, _) => await UpdateDiningTableAsync();
            btnDeleteDiningTable.Click += async (_, _) => await DeleteDiningTableAsync();
            btnRestoreDiningTable.Click += async (_, _) => await RestoreDiningTableAsync();
            dgvDiningTables.CellClick += DiningTablesGrid_CellClick;
            dgvDiningTables.CellFormatting += DiningTablesGrid_CellFormatting;

            btnLoadUsers.Click += async (_, _) => await LoadUsersAsync();
            btnUpdateUser.Click += async (_, _) => await UpdateUserAsync();
            dgvUsers.CellClick += UsersGrid_CellClick;
            dgvUsers.CellFormatting += UsersGrid_CellFormatting;

            InitUserGridColumns();

            AttachGridTooltips(dgvDishes);
            AttachGridTooltips(dgvOrders);
            AttachGridTooltips(dgvOrderItems);
            AttachGridTooltips(dgvDeliveryZones);
            AttachGridTooltips(dgvDiningTables);
            AttachGridTooltips(dgvUsers);
            AttachGridTooltips(dgvTopDishes);
            AttachGridTooltips(dgvRevenueStatistics);
        }

        private async void AdminForm_Load(object? sender, EventArgs e)
        {
            await RefreshDishCategoriesAsync();
            await LoadDishesAsync(false);
            RefreshOrderAddressDisplay();
        }

        private void ApplyManagementTextAndTheme()
        {
            Text = "珞珈线上点餐系统 - 管理员端";
            tabDishes.Text = "菜品管理";
            tabOrders.Text = "订单管理";
            tabStatistics.Text = "统计分析";
            tabAi.Text = "AI 建议";
            grpDishEdit.Text = "菜品编辑";
            grpOrderDetail.Text = "订单详情";
            grpOrderItems.Text = "订单明细";
            btnLoadDishes.Text = "加载菜品";
            btnAddDish.Text = "新增菜品";
            btnUpdateDish.Text = "更新菜品";
            btnDeleteDish.Text = "删除菜品";
            btnLoadOrders.Text = "加载订单";
            btnLoadStatistics.Text = "加载统计";
            btnResetStatistics.Text = "重置";
            btnLoadAiSuggestion.Text = "获取建议";
            btnChooseImage.Text = "选择图片";
            grpUserEditor.Text = "账号查看与状态管理";
            btnUpdateUser.Text = "保存启用状态";
            txtRealName.ReadOnly = true;
            txtUserPhone.ReadOnly = true;
            txtUserAddress.ReadOnly = true;
            btnDeleteDeliveryZone.Text = "停用区域";
            btnDeleteDiningTable.Text = "停用餐桌";
            chkDiningTableOccupied.Enabled = false;

            cmbSpicyLevel.Items.Clear();
            cmbSpicyLevel.Items.Add("0 - 不辣");
            cmbSpicyLevel.Items.Add("1 - 微辣");
            cmbSpicyLevel.Items.Add("2 - 中辣");
            cmbSpicyLevel.Items.Add("3 - 特辣");
            cmbSpicyLevel.SelectedIndex = 0;
        }

        private async Task RefreshDishCategoriesAsync()
        {
            var currentCategoryId = GetSelectedDishCategoryId();
            var currentCategoryName = GetCurrentDishCategoryName();

            try
            {
                _dishCategories = await ApiHelper.GetDishCategoriesAsync();
            }
            catch
            {
                return;
            }

            RebindDishCategoryOptions(currentCategoryId, currentCategoryName);
        }

        private int? GetSelectedDishCategoryId()
        {
            if (cmbDishCategory.SelectedItem is not DishCategoryOption option)
            {
                return null;
            }

            return option.Value.Id > 0 ? option.Value.Id : null;
        }

        private void SelectDishCategory(int? categoryId, string? categoryName)
        {
            if (cmbDishCategory.Items.Count == 0)
            {
                cmbDishCategory.Text = categoryName ?? string.Empty;
                return;
            }

            for (var index = 0; index < cmbDishCategory.Items.Count; index++)
            {
                if (cmbDishCategory.Items[index] is DishCategoryOption option &&
                    ((categoryId.HasValue && option.Value.Id == categoryId.Value) ||
                     (!categoryId.HasValue && string.Equals(option.Value.Name, categoryName, StringComparison.Ordinal))))
                {
                    cmbDishCategory.SelectedIndex = index;
                    return;
                }
            }

            cmbDishCategory.Text = categoryName ?? string.Empty;
        }

        private void InitDeliveryZoneGridColumns()
        {
            dgvDeliveryZones.ReadOnly = true;
            dgvDeliveryZones.AllowUserToAddRows = false;
            dgvDeliveryZones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeliveryZones.MultiSelect = false;
            dgvDeliveryZones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var columns = new (string Name, string HeaderText, int FillWeight, int MinWidth)[]
            {
                ("Id", "编号", 45, 60),
                ("Province", "省份", 80, 100),
                ("City", "城市", 80, 100),
                ("District", "区县", 80, 100),
                ("DeliveryFee", "配送费", 70, 90),
                ("IsActive", "启用配送", 60, 80),
                ("SortOrder", "排序", 55, 70),
                ("DisplayName", "显示名称", 160, 220)
            };

            for (int i = 0; i < columns.Length; i++)
            {
                var (name, headerText, fillWeight, minWidth) = columns[i];
                var col = new DataGridViewTextBoxColumn
                {
                    Name = name,
                    HeaderText = headerText,
                    FillWeight = fillWeight,
                    MinimumWidth = minWidth,
                    DisplayIndex = i
                };

                if (name == "DeliveryFee")
                {
                    col.DefaultCellStyle.Format = "0.00";
                }
                else if (name == "DisplayName")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                dgvDeliveryZones.Columns.Add(col);
            }

            PrepareAdminGrid(dgvDeliveryZones);
        }

        private async Task LoadDeliveryZonesAsync()
        {
            var zones = await ApiHelper.GetListAsync<DeliveryZoneDto>("api/deliveryzones");

            dgvDeliveryZones.Columns.Clear();
            dgvDeliveryZones.DataSource = null;
            dgvDeliveryZones.DataSource = zones;
            SetDeliveryZoneGridHeaders();
        }

        private void SetDeliveryZoneGridHeaders()
        {
            PrepareAdminGrid(dgvDeliveryZones);

            var provinceColumn = dgvDeliveryZones.Columns["Province"];
            var cityColumn = dgvDeliveryZones.Columns["City"];
            var districtColumn = dgvDeliveryZones.Columns["District"];
            var deliveryFeeColumn = dgvDeliveryZones.Columns["DeliveryFee"];
            var isActiveColumn = dgvDeliveryZones.Columns["IsActive"];
            var sortOrderColumn = dgvDeliveryZones.Columns["SortOrder"];
            var displayNameColumn = dgvDeliveryZones.Columns["DisplayName"];
            var idColumn = dgvDeliveryZones.Columns["Id"];

            if (idColumn != null) { idColumn.HeaderText = "编号"; idColumn.FillWeight = 45; }
            if (provinceColumn != null) { provinceColumn.HeaderText = "省份"; provinceColumn.FillWeight = 80; }
            if (cityColumn != null) { cityColumn.HeaderText = "城市"; cityColumn.FillWeight = 80; }
            if (districtColumn != null) { districtColumn.HeaderText = "区县"; districtColumn.FillWeight = 80; }
            if (deliveryFeeColumn != null)
            {
                deliveryFeeColumn.HeaderText = "配送费";
                deliveryFeeColumn.FillWeight = 70;
                deliveryFeeColumn.DefaultCellStyle.Format = "0.00";
            }
            if (isActiveColumn != null) { isActiveColumn.HeaderText = "启用配送"; isActiveColumn.FillWeight = 60; }
            if (sortOrderColumn != null) { sortOrderColumn.HeaderText = "排序"; sortOrderColumn.FillWeight = 55; }
            if (displayNameColumn != null)
            {
                displayNameColumn.HeaderText = "显示名称";
                displayNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                displayNameColumn.FillWeight = 160;
                displayNameColumn.MinimumWidth = 220;
            }

            HideColumnIfExists(dgvDeliveryZones, "IsDeleted");
        }

        private async Task AddDeliveryZoneAsync()
        {
            try
            {
                await ApiHelper.PostAsync("api/deliveryzones", BuildDeliveryZoneDto());
                ClearDeliveryZoneEditor();
                await LoadDeliveryZonesAsync();
                MessageBox.Show("配送区域已新增。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增配送区域失败：" + ex.Message);
            }
        }

        private async Task UpdateDeliveryZoneAsync()
        {
            if (_selectedZoneId == null)
            {
                MessageBox.Show("请先选择一个配送区域。");
                return;
            }

            try
            {
                await ApiHelper.PutAsync($"api/deliveryzones/{_selectedZoneId.Value}", BuildDeliveryZoneDto());
                ClearDeliveryZoneEditor();
                await LoadDeliveryZonesAsync();
                MessageBox.Show("配送区域已更新。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新配送区域失败：" + ex.Message);
            }
        }

        private async Task DeleteDeliveryZoneAsync()
        {
            if (_selectedZoneId == null)
            {
                MessageBox.Show("请先选择一个配送区域。");
                return;
            }

            if (MessageBox.Show("确定停用这个配送区域吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await ApiHelper.PutAsync($"api/deliveryzones/{_selectedZoneId.Value}/disable", new { });
                ClearDeliveryZoneEditor();
                await LoadDeliveryZonesAsync();
                MessageBox.Show("配送区域已停用。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("停用配送区域失败：" + ex.Message);
            }
        }

        private async Task RestoreDeliveryZoneAsync()
        {
            if (_selectedZoneId == null)
            {
                MessageBox.Show("请先选择一个配送区域。");
                return;
            }

            if (MessageBox.Show("确定恢复这个配送区域吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await ApiHelper.PutAsync($"api/deliveryzones/{_selectedZoneId.Value}/restore", new { });
                ClearDeliveryZoneEditor();
                await LoadDeliveryZonesAsync();
                MessageBox.Show("配送区域已恢复。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("恢复配送区域失败：" + ex.Message);
            }
        }

        private DeliveryZoneCreateUpdateDto BuildDeliveryZoneDto()
        {
            if (string.IsNullOrWhiteSpace(txtZoneProvince.Text) ||
                string.IsNullOrWhiteSpace(txtZoneCity.Text) ||
                string.IsNullOrWhiteSpace(txtZoneDistrict.Text))
            {
                throw new InvalidOperationException("省份、城市、区县都必须填写。");
            }

            if (!decimal.TryParse(txtZoneFee.Text, out var fee))
            {
                throw new InvalidOperationException("配送费必须是数字。");
            }

            _ = int.TryParse(txtZoneSortOrder.Text, out var sortOrder);

            return new DeliveryZoneCreateUpdateDto
            {
                Province = txtZoneProvince.Text.Trim(),
                City = txtZoneCity.Text.Trim(),
                District = txtZoneDistrict.Text.Trim(),
                DeliveryFee = fee,
                SortOrder = sortOrder,
                IsActive = chkZoneIsActive.Checked
            };
        }

        private void DeliveryZonesGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDeliveryZones.Rows[e.RowIndex].DataBoundItem is not DeliveryZoneDto zone)
            {
                return;
            }

            _selectedZoneId = zone.Id;
            txtZoneProvince.Text = zone.Province;
            txtZoneCity.Text = zone.City;
            txtZoneDistrict.Text = zone.District;
            txtZoneFee.Text = zone.DeliveryFee.ToString("0.##");
            txtZoneSortOrder.Text = zone.SortOrder.ToString();
            chkZoneIsActive.Checked = zone.IsActive;
        }

        private void ClearDeliveryZoneEditor()
        {
            _selectedZoneId = null;
            txtZoneProvince.Text = string.Empty;
            txtZoneCity.Text = string.Empty;
            txtZoneDistrict.Text = string.Empty;
            txtZoneFee.Text = string.Empty;
            txtZoneSortOrder.Text = "0";
            chkZoneIsActive.Checked = true;
        }

        private async Task LoadDiningTablesAsync()
        {
            var tables = await ApiHelper.GetListAsync<DiningTableDto>("api/diningtables");
            dgvDiningTables.DataSource = null;
            dgvDiningTables.DataSource = tables;
            SetDiningTableGridHeaders();
        }

        private void SetDiningTableGridHeaders()
        {
            PrepareAdminGrid(dgvDiningTables);

            var idColumn = dgvDiningTables.Columns["Id"];
            var tableNumberColumn = dgvDiningTables.Columns["TableNumber"];
            var seatCountColumn = dgvDiningTables.Columns["SeatCount"];
            var remainingColumn = dgvDiningTables.Columns["RemainingSeats"];
            var occupiedColumn = dgvDiningTables.Columns["IsOccupied"];
            var enabledColumn = dgvDiningTables.Columns["IsEnabled"];
            var statusColumn = dgvDiningTables.Columns["Status"];
            var currentOccupiedColumn = dgvDiningTables.Columns["CurrentOccupiedSeats"];
            var currentSessionNoColumn = dgvDiningTables.Columns["CurrentSessionNo"];

            if (idColumn != null) { idColumn.HeaderText = "编号"; idColumn.FillWeight = 45; idColumn.MinimumWidth = 60; }
            if (tableNumberColumn != null) { tableNumberColumn.HeaderText = "桌号"; tableNumberColumn.FillWeight = 90; tableNumberColumn.MinimumWidth = 90; }
            if (seatCountColumn != null) { seatCountColumn.HeaderText = "总座位"; seatCountColumn.FillWeight = 80; seatCountColumn.MinimumWidth = 80; }
            if (remainingColumn != null) { remainingColumn.HeaderText = "剩余座位"; remainingColumn.FillWeight = 90; remainingColumn.MinimumWidth = 90; }
            if (occupiedColumn != null) { occupiedColumn.HeaderText = "占用中"; occupiedColumn.FillWeight = 80; occupiedColumn.MinimumWidth = 90; }
            if (enabledColumn != null) { enabledColumn.HeaderText = "启用"; enabledColumn.FillWeight = 70; enabledColumn.MinimumWidth = 80; }
            if (statusColumn != null) { statusColumn.HeaderText = "状态"; statusColumn.FillWeight = 90; statusColumn.MinimumWidth = 90; }
            if (currentOccupiedColumn != null) { currentOccupiedColumn.HeaderText = "当前人数"; currentOccupiedColumn.FillWeight = 80; currentOccupiedColumn.MinimumWidth = 90; }
            if (currentSessionNoColumn != null) { currentSessionNoColumn.HeaderText = "当前桌次"; currentSessionNoColumn.FillWeight = 140; currentSessionNoColumn.MinimumWidth = 170; }

            // 隐藏不需要显示的列
            HideColumnIfExists(dgvDiningTables, "CurrentSessionId");
            HideColumnIfExists(dgvDiningTables, "IsDeleted");
        }

        private static void HideColumnIfExists(DataGridView dgv, string columnName)
        {
            var col = dgv.Columns[columnName];
            if (col != null) col.Visible = false;
        }

        private void DiningTablesGrid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvDiningTables.Columns[e.ColumnIndex].Name == "Status" && e.Value is string status)
            {
                var cellStyle = dgvDiningTables.Rows[e.RowIndex].Cells[e.ColumnIndex].Style;
                e.Value = status switch
                {
                    "Available" => "可用",
                    "Occupied" => "占用中",
                    "Cleaning" => "清洁中",
                    "Disabled" => "已停用",
                    _ => status
                };
                cellStyle.ForeColor = status switch
                {
                    "Available" => Color.FromArgb(46, 125, 50),
                    "Occupied" => Color.FromArgb(230, 81, 0),
                    "Cleaning" => Color.FromArgb(2, 119, 189),
                    "Disabled" => Color.FromArgb(117, 117, 117),
                    _ => Color.FromArgb(48, 48, 48)
                };
                cellStyle.Font = new Font(dgvDiningTables.Font, FontStyle.Bold);
                e.FormattingApplied = true;
            }
        }

        private async Task AddDiningTableAsync()
        {
            try
            {
                await ApiHelper.PostAsync("api/diningtables", BuildDiningTableDto());
                ClearDiningTableEditor();
                await LoadDiningTablesAsync();
                MessageBox.Show("餐桌已新增。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增餐桌失败：" + ex.Message);
            }
        }

        private async Task UpdateDiningTableAsync()
        {
            if (_selectedDiningTableId == null)
            {
                MessageBox.Show("请先选择一张餐桌。");
                return;
            }

            try
            {
                await ApiHelper.PutAsync($"api/diningtables/{_selectedDiningTableId.Value}", BuildDiningTableDto());
                ClearDiningTableEditor();
                await LoadDiningTablesAsync();
                MessageBox.Show("餐桌已更新。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新餐桌失败：" + ex.Message);
            }
        }

        private async Task DeleteDiningTableAsync()
        {
            if (_selectedDiningTableId == null)
            {
                MessageBox.Show("请先选择一张餐桌。");
                return;
            }

            if (MessageBox.Show("确定停用这张餐桌吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await ApiHelper.PutAsync($"api/diningtables/{_selectedDiningTableId.Value}/disable", new { });
                ClearDiningTableEditor();
                await LoadDiningTablesAsync();
                MessageBox.Show("餐桌已停用。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("停用餐桌失败：" + ex.Message);
            }
        }

        private async Task RestoreDiningTableAsync()
        {
            if (_selectedDiningTableId == null)
            {
                MessageBox.Show("请先选择一张餐桌。");
                return;
            }

            if (MessageBox.Show("确定恢复这张餐桌吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await ApiHelper.PutAsync($"api/diningtables/{_selectedDiningTableId.Value}/restore", new { });
                ClearDiningTableEditor();
                await LoadDiningTablesAsync();
                MessageBox.Show("餐桌已恢复。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("恢复餐桌失败：" + ex.Message);
            }
        }

        private DiningTableCreateUpdateDto BuildDiningTableDto()
        {
            if (string.IsNullOrWhiteSpace(txtDiningTableNumber.Text))
            {
                throw new InvalidOperationException("桌号不能为空。");
            }

            if (!int.TryParse(txtDiningTableSeats.Text, out var seatCount) || seatCount <= 0)
            {
                throw new InvalidOperationException("座位数必须是大于 0 的整数。");
            }

            return new DiningTableCreateUpdateDto
            {
                TableNumber = txtDiningTableNumber.Text.Trim().ToUpperInvariant(),
                SeatCount = seatCount,
                IsEnabled = chkDiningTableEnabled.Checked
            };
        }

        private void DiningTablesGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDiningTables.Rows[e.RowIndex].DataBoundItem is not DiningTableDto table)
            {
                return;
            }

            _selectedDiningTableId = table.Id;
            txtDiningTableNumber.Text = table.TableNumber;
            txtDiningTableSeats.Text = table.SeatCount.ToString();
            chkDiningTableOccupied.Checked = table.IsOccupied;
            chkDiningTableEnabled.Checked = table.IsEnabled;
            chkDiningTableOccupied.Enabled = false;
        }

        private void ClearDiningTableEditor()
        {
            _selectedDiningTableId = null;
            txtDiningTableNumber.Text = string.Empty;
            txtDiningTableSeats.Text = string.Empty;
            chkDiningTableOccupied.Checked = false;
            chkDiningTableOccupied.Enabled = false;
            chkDiningTableEnabled.Checked = true;
        }

        private void RefreshOrderAddressDisplay()
        {
            if (dgvOrders.CurrentRow?.DataBoundItem is not OrderDto order)
            {
                return;
            }

            var fullAddress = BuildFullDeliveryAddress(order);
            txtOrderAddress.Text = string.IsNullOrWhiteSpace(fullAddress) ? string.Empty : fullAddress;
        }

        private sealed class StatisticsGridRow
        {
            public StatisticsGridRow(string metric, string value)
            {
                Metric = metric;
                Value = value;
            }

            public string Metric { get; }

            public string Value { get; }
        }

        // ==================== 用户管理 ====================

        private async Task LoadUsersAsync()
        {
            var users = await ApiHelper.GetListAsync<UserDto>("api/users");

            dgvUsers.Columns.Clear();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = users;
            SetUserGridHeaders();
        }

        private void InitUserGridColumns()
        {
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var columns = new (string Name, string HeaderText, int FillWeight, int MinWidth)[]
            {
                ("Id", "编号", 45, 60),
                ("Username", "用户名", 90, 110),
                ("Role", "角色", 80, 90),
                ("RealName", "姓名", 90, 100),
                ("Phone", "电话", 110, 120),
                ("Address", "地址", 180, 260),
                ("CreatedAt", "创建时间", 100, 135),
                ("IsActive", "启用", 60, 80)
            };

            for (int i = 0; i < columns.Length; i++)
            {
                var (name, headerText, fillWeight, minWidth) = columns[i];
                var col = new DataGridViewTextBoxColumn
                {
                    Name = name,
                    HeaderText = headerText,
                    FillWeight = fillWeight,
                    MinimumWidth = minWidth,
                    DisplayIndex = i
                };

                if (name == "Address")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else if (name == "CreatedAt")
                {
                    col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                }

                dgvUsers.Columns.Add(col);
            }

            PrepareAdminGrid(dgvUsers);
        }

        private void SetUserGridHeaders()
        {
            PrepareAdminGrid(dgvUsers);

            var idColumn = dgvUsers.Columns["Id"];
            var usernameColumn = dgvUsers.Columns["Username"];
            var roleColumn = dgvUsers.Columns["Role"];
            var realNameColumn = dgvUsers.Columns["RealName"];
            var phoneColumn = dgvUsers.Columns["Phone"];
            var addressColumn = dgvUsers.Columns["Address"];
            var createdAtColumn = dgvUsers.Columns["CreatedAt"];
            var isActiveColumn = dgvUsers.Columns["IsActive"];

            if (idColumn != null) { idColumn.HeaderText = "编号"; idColumn.FillWeight = 45; idColumn.MinimumWidth = 60; }
            if (usernameColumn != null) { usernameColumn.HeaderText = "用户名"; usernameColumn.FillWeight = 90; usernameColumn.MinimumWidth = 110; }
            if (roleColumn != null) { roleColumn.HeaderText = "角色"; roleColumn.FillWeight = 80; roleColumn.MinimumWidth = 90; }
            if (realNameColumn != null) { realNameColumn.HeaderText = "姓名"; realNameColumn.FillWeight = 90; realNameColumn.MinimumWidth = 100; }
            if (phoneColumn != null) { phoneColumn.HeaderText = "电话"; phoneColumn.FillWeight = 110; phoneColumn.MinimumWidth = 120; }
            if (addressColumn != null)
            {
                addressColumn.HeaderText = "地址";
                addressColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                addressColumn.FillWeight = 180;
                addressColumn.MinimumWidth = 260;
            }
            if (createdAtColumn != null)
            {
                createdAtColumn.HeaderText = "创建时间";
                createdAtColumn.MinimumWidth = 135;
                createdAtColumn.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }
            if (isActiveColumn != null) { isActiveColumn.HeaderText = "启用"; isActiveColumn.FillWeight = 60; }
        }

        private static void PrepareAdminGrid(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 52;
            dgv.RowTemplate.Height = 46;
            dgv.RowTemplate.MinimumHeight = 46;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Padding = new Padding(5, 10, 5, 10);
            dgv.DefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
            dgv.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 10, 8, 10);
            dgv.RowHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
        }

        private static void AttachGridTooltips(DataGridView dgv)
        {
            dgv.ShowCellToolTips = true;
            dgv.CellToolTipTextNeeded -= AdminGrid_CellToolTipTextNeeded;
            dgv.CellToolTipTextNeeded += AdminGrid_CellToolTipTextNeeded;
        }

        private static void AdminGrid_CellToolTipTextNeeded(object? sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (sender is not DataGridView dgv || e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            var value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            e.ToolTipText = value?.ToString() ?? string.Empty;
        }

        private void UsersGrid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvUsers.Columns[e.ColumnIndex].Name == "Role" && e.Value is string role)
            {
                e.Value = role switch
                {
                    "Admin" => "管理员",
                    "Customer" => "顾客",
                    "Kitchen" => "后厨",
                    "Rider" => "配送员",
                    "SuperAdmin" => "超级管理员",
                    _ => role
                };
                e.FormattingApplied = true;
            }
        }

        private sealed class DishCategoryOption
        {
            public DishCategoryOption(DishCategoryDto value)
            {
                Value = value;
            }

            public DishCategoryDto Value { get; }

            public override string ToString()
            {
                return Value.Name;
            }
        }

        private async Task UpdateUserAsync()
        {
            if (selectedUserId == null)
            {
                MessageBox.Show("请先选择一个用户。");
                return;
            }

            try
            {
                var request = new UpdateUserRequest
                {
                    IsActive = chkIsActive.Checked
                };

                await ApiHelper.UpdateUserAsync(selectedUserId.Value, request);
                ClearUserEditor();
                await LoadUsersAsync();
                MessageBox.Show("账号状态已更新。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新账号状态失败：" + ex.Message);
            }
        }

        private void UsersGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvUsers.Rows[e.RowIndex].DataBoundItem is not UserDto user)
            {
                return;
            }

            selectedUserId = user.Id;
            txtUsername.Text = user.Username;
            txtRealName.Text = user.RealName ?? string.Empty;
            txtUserPhone.Text = user.Phone ?? string.Empty;
            txtUserAddress.Text = user.Address ?? string.Empty;
            chkIsActive.Checked = user.IsActive;
        }

        private void ClearUserEditor()
        {
            selectedUserId = null;
            txtUsername.Text = string.Empty;
            txtRealName.Text = string.Empty;
            txtUserPhone.Text = string.Empty;
            txtUserAddress.Text = string.Empty;
            chkIsActive.Checked = true;
        }
    }
}

