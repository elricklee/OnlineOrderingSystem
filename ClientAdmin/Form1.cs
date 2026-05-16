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
            Size = new Size(1350, 850);
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

            chkIsAvailable.Checked = true;

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
        private async Task LoadDishesAsync()
        {
            try
            {
                var dishes = await ApiHelper.GetListAsync<DishDto>("api/Dishes");

                dgvDishes.DataSource = null;
                dgvDishes.DataSource = dishes;

                SetDishGridHeaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载菜品失败：" + ex.Message);
            }
        }
        private void SetDishGridHeaders()
        {
            if (dgvDishes.Columns["Id"] != null)
                dgvDishes.Columns["Id"].HeaderText = "编号";

            if (dgvDishes.Columns["Name"] != null)
                dgvDishes.Columns["Name"].HeaderText = "菜品名称";

            if (dgvDishes.Columns["Category"] != null)
                dgvDishes.Columns["Category"].HeaderText = "分类";

            if (dgvDishes.Columns["Price"] != null)
            {
                dgvDishes.Columns["Price"].HeaderText = "价格";
                dgvDishes.Columns["Price"].DefaultCellStyle.Format = "0.00";
            }

            if (dgvDishes.Columns["ImagePath"] != null)
                dgvDishes.Columns["ImagePath"].HeaderText = "图片路径";

            if (dgvDishes.Columns["SpicyLevel"] != null)
                dgvDishes.Columns["SpicyLevel"].HeaderText = "辣度";

            if (dgvDishes.Columns["IsAvailable"] != null)
                dgvDishes.Columns["IsAvailable"].HeaderText = "是否可售";

            if (dgvDishes.Columns["Description"] != null)
                dgvDishes.Columns["Description"].HeaderText = "描述";
        }
        private async void btnLoadDishes_Click(object sender, EventArgs e)
        {
            await LoadDishesAsync();
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
                    Category = txtCategory.Text.Trim(),
                    Price = price,
                    ImagePath = txtImagePath.Text.Trim(),
                    SpicyLevel = GetSelectedSpicyLevel(),
                    IsAvailable = chkIsAvailable.Checked,
                    Description = txtDescription.Text.Trim()
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
                    Category = txtCategory.Text.Trim(),
                    Price = price,
                    ImagePath = txtImagePath.Text.Trim(),
                    SpicyLevel = GetSelectedSpicyLevel(),
                    IsAvailable = chkIsAvailable.Checked,
                    Description = txtDescription.Text.Trim()
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

            var result = MessageBox.Show(
                "确定要删除这个菜品吗？",
                "确认删除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await ApiHelper.DeleteAsync($"api/Dishes/{selectedDishId.Value}");

                MessageBox.Show("删除菜品成功");

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
            txtCategory.Text = dish.Category;
            txtPrice.Text = dish.Price.ToString("0.00");

            txtImagePath.Text = dish.ImagePath ?? "";
            txtDescription.Text = dish.Description ?? "";

            SetSelectedSpicyLevel(dish.SpicyLevel);
            chkIsAvailable.Checked = dish.IsAvailable;

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

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
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
            txtCategory.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtImagePath.Text = string.Empty;
            txtDescription.Text = string.Empty;

            SetSelectedSpicyLevel(0);
            chkIsAvailable.Checked = true;

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

            cmbOrderStatus.Items.Clear();
            cmbOrderStatus.Items.Add("待处理");
            cmbOrderStatus.Items.Add("已确认");
            cmbOrderStatus.Items.Add("制作中");
            cmbOrderStatus.Items.Add("已出餐");
            cmbOrderStatus.Items.Add("配送中");
            cmbOrderStatus.Items.Add("已完成");
            cmbOrderStatus.Items.Add("已取消");

            if (cmbOrderStatus.Items.Count > 0)
            {
                cmbOrderStatus.SelectedIndex = 0;
            }

            ClearOrderDetail();

            dgvOrders.CellFormatting += DgvOrders_CellFormatting;
        }

        private void DgvOrders_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgvOrders.Columns[e.ColumnIndex];
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
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvOrders.Columns["Id"] != null)
            {
                dgvOrders.Columns["Id"].HeaderText = "订单号";
                dgvOrders.Columns["Id"].FillWeight = 50;
                dgvOrders.Columns["Id"].DisplayIndex = 0;
            }

            if (dgvOrders.Columns["OrderType"] != null)
            {
                dgvOrders.Columns["OrderType"].HeaderText = "类型";
                dgvOrders.Columns["OrderType"].FillWeight = 50;
                dgvOrders.Columns["OrderType"].DisplayIndex = 1;
            }

            if (dgvOrders.Columns["TableNumber"] != null)
            {
                dgvOrders.Columns["TableNumber"].HeaderText = "桌号";
                dgvOrders.Columns["TableNumber"].FillWeight = 50;
                dgvOrders.Columns["TableNumber"].DisplayIndex = 2;
            }

            if (dgvOrders.Columns["CustomerName"] != null)
            {
                dgvOrders.Columns["CustomerName"].HeaderText = "顾客";
                dgvOrders.Columns["CustomerName"].FillWeight = 60;
                dgvOrders.Columns["CustomerName"].DisplayIndex = 3;
            }

            if (dgvOrders.Columns["Phone"] != null)
            {
                dgvOrders.Columns["Phone"].HeaderText = "电话";
                dgvOrders.Columns["Phone"].FillWeight = 80;
                dgvOrders.Columns["Phone"].DisplayIndex = 4;
            }

            if (dgvOrders.Columns["Address"] != null)
            {
                dgvOrders.Columns["Address"].HeaderText = "配送地址";
                dgvOrders.Columns["Address"].FillWeight = 120;
                dgvOrders.Columns["Address"].DisplayIndex = 5;
            }

            if (dgvOrders.Columns["TotalAmount"] != null)
            {
                dgvOrders.Columns["TotalAmount"].HeaderText = "总金额";
                dgvOrders.Columns["TotalAmount"].FillWeight = 70;
                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
                dgvOrders.Columns["TotalAmount"].DisplayIndex = 6;
            }

            if (dgvOrders.Columns["Status"] != null)
            {
                dgvOrders.Columns["Status"].HeaderText = "状态";
                dgvOrders.Columns["Status"].FillWeight = 60;
                dgvOrders.Columns["Status"].DisplayIndex = 7;
            }

            if (dgvOrders.Columns["CreatedAt"] != null)
            {
                dgvOrders.Columns["CreatedAt"].HeaderText = "下单时间";
                dgvOrders.Columns["CreatedAt"].FillWeight = 80;
                dgvOrders.Columns["CreatedAt"].DefaultCellStyle.Format = "MM-dd HH:mm";
                dgvOrders.Columns["CreatedAt"].DisplayIndex = 8;
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
        }

        private void SetOrderItemGridHeaders()
        {
            dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvOrderItems.Columns["Id"] != null)
            {
                dgvOrderItems.Columns["Id"].HeaderText = "明细编号";
                dgvOrderItems.Columns["Id"].FillWeight = 60;
            }

            if (dgvOrderItems.Columns["OrderId"] != null)
            {
                dgvOrderItems.Columns["OrderId"].HeaderText = "订单编号";
                dgvOrderItems.Columns["OrderId"].FillWeight = 60;
            }

            if (dgvOrderItems.Columns["DishId"] != null)
            {
                dgvOrderItems.Columns["DishId"].HeaderText = "菜品编号";
                dgvOrderItems.Columns["DishId"].FillWeight = 60;
            }

            if (dgvOrderItems.Columns["DishName"] != null)
            {
                dgvOrderItems.Columns["DishName"].HeaderText = "菜品名称";
                dgvOrderItems.Columns["DishName"].FillWeight = 100;
            }

            if (dgvOrderItems.Columns["Price"] != null)
            {
                dgvOrderItems.Columns["Price"].HeaderText = "单价";
                dgvOrderItems.Columns["Price"].FillWeight = 70;
                dgvOrderItems.Columns["Price"].DefaultCellStyle.Format = "C2";
            }

            if (dgvOrderItems.Columns["Quantity"] != null)
            {
                dgvOrderItems.Columns["Quantity"].HeaderText = "数量";
                dgvOrderItems.Columns["Quantity"].FillWeight = 50;
            }

            if (dgvOrderItems.Columns["Subtotal"] != null)
            {
                dgvOrderItems.Columns["Subtotal"].HeaderText = "小计";
                dgvOrderItems.Columns["Subtotal"].FillWeight = 70;
                dgvOrderItems.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            }
        }

        private async void btnLoadOrders_Click(object sender, EventArgs e)
        {
            await LoadOrdersAsync();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
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

            var chineseStatus = StatusMapReverse.GetValueOrDefault(order.Status, order.Status);
            if (cmbOrderStatus.Items.Contains(chineseStatus))
            {
                cmbOrderStatus.SelectedItem = chineseStatus;
            }
            else
            {
                cmbOrderStatus.Text = chineseStatus;
            }

            ShowOrderDetail(order);
            BindOrderItems(order);
        }

        private void ShowOrderDetail(OrderDto order)
        {
            lblOrderId.Text = $"订单编号：{order.Id}";
            lblOrderType.Text = $"订单类型：{GetDisplayText(order.OrderType)}";
            lblCustomerName.Text = $"顾客姓名：{order.CustomerName}";
            lblPhone.Text = $"电话：{order.Phone}";
            lblTableNumber.Text = $"桌号：{GetDisplayText(order.TableNumber)}";
            lblAddress.Text = $"配送地址：{GetDisplayText(order.Address)}";
            lblNote.Text = $"备注：{GetDisplayText(order.Note)}";
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

        private async void btnUpdateOrderStatus_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == null)
            {
                MessageBox.Show("请先选择一个订单");
                return;
            }

            var newStatusChinese = cmbOrderStatus.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(newStatusChinese))
            {
                newStatusChinese = cmbOrderStatus.Text;
            }

            if (string.IsNullOrWhiteSpace(newStatusChinese))
            {
                MessageBox.Show("请选择订单状态");
                return;
            }

            var newStatus = StatusMap.GetValueOrDefault(newStatusChinese, newStatusChinese);

            try
            {
                var dto = new
                {
                    Status = newStatus
                };

                await ApiHelper.PutAsync($"api/Orders/{selectedOrderId.Value}/status", dto);

                MessageBox.Show("订单状态修改成功");

                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改订单状态失败：" + ex.Message);
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
            lblNote.Text = "备注：";
            lblDeliveryFee.Text = "配送费：";
            lblTotalAmount.Text = "总金额：";
            lblStatus.Text = "状态：";
            lblCreatedAt.Text = "创建时间：";
        }

        private string GetDisplayText(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "无";
            }

            return value;
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

            ResetStatisticsDisplay();
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
            if (currentTopDishes.Count == 0)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(panelTopDishesChart.BackColor);

            var bounds = panelTopDishesChart.ClientRectangle;
            var chartArea = new Rectangle(45, 20, Math.Max(120, bounds.Width - 65), Math.Max(100, bounds.Height - 65));
            var maxQuantity = Math.Max(1, currentTopDishes.Max(item => item.TotalQuantity));
            var gap = 12;
            var barCount = currentTopDishes.Count;
            var availableWidth = chartArea.Width - gap * (barCount + 1);
            var barWidth = Math.Max(24, availableWidth / Math.Max(1, barCount));

            using var axisPen = new Pen(Color.FromArgb(90, 90, 90), 1.5f);
            using var textBrush = new SolidBrush(Color.FromArgb(60, 60, 60));
            using var valueFont = new Font("宋体", 9F, FontStyle.Regular);
            using var labelFont = new Font("宋体", 9F, FontStyle.Regular);

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
                    Color.FromArgb(80, 160, 255),
                    Color.FromArgb(42, 99, 196),
                    LinearGradientMode.Vertical
                );

                e.Graphics.FillRectangle(barBrush, barRect);
                e.Graphics.DrawRectangle(Pens.WhiteSmoke, barRect);

                var quantityText = dish.TotalQuantity.ToString();
                var quantitySize = e.Graphics.MeasureString(quantityText, valueFont);
                e.Graphics.DrawString(
                    quantityText,
                    valueFont,
                    textBrush,
                    x + (barWidth - quantitySize.Width) / 2,
                    Math.Max(chartArea.Top, y - quantitySize.Height - 4)
                );

                var dishName = dish.DishName.Length > 6 ? $"{dish.DishName[..6]}…" : dish.DishName;
                var labelRect = new RectangleF(x - 8, chartArea.Bottom + 6, barWidth + 16, 28);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Near
                };
                e.Graphics.DrawString(dishName, labelFont, textBrush, labelRect, format);
            }
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
            cmbDishCategory.TextChanged += (_, _) =>
            {
                if (txtCategory.Text != cmbDishCategory.Text)
                {
                    txtCategory.Text = cmbDishCategory.Text;
                }
            };

            btnLoadDeliveryZones.Click += async (_, _) => await LoadDeliveryZonesAsync();
            btnAddDeliveryZone.Click += async (_, _) => await AddDeliveryZoneAsync();
            btnUpdateDeliveryZone.Click += async (_, _) => await UpdateDeliveryZoneAsync();
            btnDeleteDeliveryZone.Click += async (_, _) => await DeleteDeliveryZoneAsync();
            dgvDeliveryZones.CellClick += DeliveryZonesGrid_CellClick;

            btnLoadDiningTables.Click += async (_, _) => await LoadDiningTablesAsync();
            btnAddDiningTable.Click += async (_, _) => await AddDiningTableAsync();
            btnUpdateDiningTable.Click += async (_, _) => await UpdateDiningTableAsync();
            btnDeleteDiningTable.Click += async (_, _) => await DeleteDiningTableAsync();
            dgvDiningTables.CellClick += DiningTablesGrid_CellClick;

            btnLoadUsers.Click += async (_, _) => await LoadUsersAsync();
            btnAddUser.Click += async (_, _) => await AddUserAsync();
            btnUpdateUser.Click += async (_, _) => await UpdateUserAsync();
            btnDeleteUser.Click += async (_, _) => await DeleteUserAsync();
            btnResetPassword.Click += async (_, _) => await ResetUserPasswordAsync();
            dgvUsers.CellClick += UsersGrid_CellClick;
        }

        private async void AdminForm_Load(object? sender, EventArgs e)
        {
            await RefreshDishCategoriesAsync();
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
            btnUpdateOrderStatus.Text = "更新状态";
            btnLoadStatistics.Text = "加载统计";
            btnResetStatistics.Text = "重置";
            btnLoadAiSuggestion.Text = "获取建议";
            btnChooseImage.Text = "选择图片";

            cmbSpicyLevel.Items.Clear();
            cmbSpicyLevel.Items.Add("0 - 不辣");
            cmbSpicyLevel.Items.Add("1 - 微辣");
            cmbSpicyLevel.Items.Add("2 - 中辣");
            cmbSpicyLevel.Items.Add("3 - 特辣");
            cmbSpicyLevel.SelectedIndex = 0;

            cmbOrderStatus.Items.Clear();
            cmbOrderStatus.Items.AddRange(new object[]
            {
                "待处理", "已确认", "制作中", "已出餐", "配送中", "已完成", "已取消"
            });
            if (cmbOrderStatus.Items.Count > 0)
            {
                cmbOrderStatus.SelectedIndex = 0;
            }
        }

        private async Task RefreshDishCategoriesAsync()
        {
            try
            {
                var dishes = await ApiHelper.GetListAsync<DishDto>("api/dishes");
                var categories = _defaultCategories
                    .Concat(dishes.Select(dish => dish.Category))
                    .Where(category => !string.IsNullOrWhiteSpace(category))
                    .Distinct()
                    .OrderBy(category => category)
                    .ToList();

                var current = cmbDishCategory.Text;
                cmbDishCategory.Items.Clear();
                foreach (var category in categories)
                {
                    cmbDishCategory.Items.Add(category);
                }

                if (!string.IsNullOrWhiteSpace(current))
                {
                    cmbDishCategory.Text = current;
                }
            }
            catch
            {
            }
        }

        private async Task LoadDeliveryZonesAsync()
        {
            var zones = await ApiHelper.GetListAsync<DeliveryZoneDto>("api/deliveryzones");
            dgvDeliveryZones.DataSource = null;
            dgvDeliveryZones.DataSource = zones;
            SetDeliveryZoneGridHeaders();
        }

        private void SetDeliveryZoneGridHeaders()
        {
            var provinceColumn = dgvDeliveryZones.Columns["Province"];
            var cityColumn = dgvDeliveryZones.Columns["City"];
            var districtColumn = dgvDeliveryZones.Columns["District"];
            var deliveryFeeColumn = dgvDeliveryZones.Columns["DeliveryFee"];
            var isActiveColumn = dgvDeliveryZones.Columns["IsActive"];
            var sortOrderColumn = dgvDeliveryZones.Columns["SortOrder"];
            var displayNameColumn = dgvDeliveryZones.Columns["DisplayName"];
            var idColumn = dgvDeliveryZones.Columns["Id"];

            if (provinceColumn != null) provinceColumn.HeaderText = "省份";
            if (cityColumn != null) cityColumn.HeaderText = "城市";
            if (districtColumn != null) districtColumn.HeaderText = "区县";
            if (deliveryFeeColumn != null) deliveryFeeColumn.HeaderText = "配送费";
            if (isActiveColumn != null) isActiveColumn.HeaderText = "可配送";
            if (sortOrderColumn != null) sortOrderColumn.HeaderText = "排序";
            if (displayNameColumn != null) displayNameColumn.HeaderText = "显示名称";
            if (idColumn != null) idColumn.HeaderText = "编号";
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

            if (MessageBox.Show("确定删除这个配送区域吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await ApiHelper.DeleteAsync($"api/deliveryzones/{_selectedZoneId.Value}");
                ClearDeliveryZoneEditor();
                await LoadDeliveryZonesAsync();
                MessageBox.Show("配送区域已删除。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除配送区域失败：" + ex.Message);
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
            var idColumn = dgvDiningTables.Columns["Id"];
            var tableNumberColumn = dgvDiningTables.Columns["TableNumber"];
            var seatCountColumn = dgvDiningTables.Columns["SeatCount"];
            var occupiedColumn = dgvDiningTables.Columns["IsOccupied"];
            var enabledColumn = dgvDiningTables.Columns["IsEnabled"];

            if (idColumn != null) idColumn.HeaderText = "编号";
            if (tableNumberColumn != null) tableNumberColumn.HeaderText = "桌号";
            if (seatCountColumn != null) seatCountColumn.HeaderText = "座位数";
            if (occupiedColumn != null) occupiedColumn.HeaderText = "占用中";
            if (enabledColumn != null) enabledColumn.HeaderText = "启用";
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

            if (MessageBox.Show("确定删除这张餐桌吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await ApiHelper.DeleteAsync($"api/diningtables/{_selectedDiningTableId.Value}");
                ClearDiningTableEditor();
                await LoadDiningTablesAsync();
                MessageBox.Show("餐桌已删除。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除餐桌失败：" + ex.Message);
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
                TableNumber = txtDiningTableNumber.Text.Trim(),
                SeatCount = seatCount,
                IsOccupied = chkDiningTableOccupied.Checked,
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
        }

        private void ClearDiningTableEditor()
        {
            _selectedDiningTableId = null;
            txtDiningTableNumber.Text = string.Empty;
            txtDiningTableSeats.Text = string.Empty;
            chkDiningTableOccupied.Checked = false;
            chkDiningTableEnabled.Checked = true;
        }

        private void RefreshOrderAddressDisplay()
        {
            if (dgvOrders.CurrentRow?.DataBoundItem is not OrderDto order)
            {
                return;
            }

            var fullAddress = string.Join(
                " ",
                new[] { order.DeliveryRegion, order.Address }.Where(value => !string.IsNullOrWhiteSpace(value)));

            if (!string.IsNullOrWhiteSpace(fullAddress))
            {
                lblAddress.Text = $"配送地址：{fullAddress}";
            }
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
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = users;
            SetUserGridHeaders();
        }

        private void SetUserGridHeaders()
        {
            var idColumn = dgvUsers.Columns["Id"];
            var usernameColumn = dgvUsers.Columns["Username"];
            var roleColumn = dgvUsers.Columns["Role"];
            var realNameColumn = dgvUsers.Columns["RealName"];
            var phoneColumn = dgvUsers.Columns["Phone"];
            var addressColumn = dgvUsers.Columns["Address"];
            var createdAtColumn = dgvUsers.Columns["CreatedAt"];
            var isActiveColumn = dgvUsers.Columns["IsActive"];

            if (idColumn != null) idColumn.HeaderText = "编号";
            if (usernameColumn != null) usernameColumn.HeaderText = "用户名";
            if (roleColumn != null) roleColumn.HeaderText = "角色";
            if (realNameColumn != null) realNameColumn.HeaderText = "姓名";
            if (phoneColumn != null) phoneColumn.HeaderText = "电话";
            if (addressColumn != null) addressColumn.HeaderText = "地址";
            if (createdAtColumn != null)
            {
                createdAtColumn.HeaderText = "创建时间";
                createdAtColumn.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }
            if (isActiveColumn != null) isActiveColumn.HeaderText = "启用";
        }

        private async Task AddUserAsync()
        {
            MessageBox.Show("新增用户功能暂未实现，请通过注册页面添加用户。");
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
                    RealName = txtRealName.Text.Trim(),
                    Phone = txtUserPhone.Text.Trim(),
                    Address = txtUserAddress.Text.Trim(),
                    IsActive = chkIsActive.Checked
                };

                await ApiHelper.UpdateUserAsync(selectedUserId.Value, request);
                ClearUserEditor();
                await LoadUsersAsync();
                MessageBox.Show("用户信息已更新。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新用户失败：" + ex.Message);
            }
        }

        private async Task DeleteUserAsync()
        {
            if (selectedUserId == null)
            {
                MessageBox.Show("请先选择一个用户。");
                return;
            }

            if (MessageBox.Show("确定删除这个用户吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await ApiHelper.DeleteUserAsync(selectedUserId.Value);
                ClearUserEditor();
                await LoadUsersAsync();
                MessageBox.Show("用户已删除。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除用户失败：" + ex.Message);
            }
        }

        private async Task ResetUserPasswordAsync()
        {
            if (selectedUserId == null)
            {
                MessageBox.Show("请先选择一个用户。");
                return;
            }

            // 使用自定义对话框输入新密码
            using var inputForm = new Form
            {
                Text = "重置密码",
                Size = new Size(350, 150),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblPrompt = new Label
            {
                Text = "请输入新密码：",
                Location = new Point(20, 20),
                Size = new Size(280, 20)
            };

            var txtPassword = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(280, 25),
                PasswordChar = '*',
                UseSystemPasswordChar = true
            };

            var btnOK = new Button
            {
                Text = "确定",
                DialogResult = DialogResult.OK,
                Location = new Point(140, 85),
                Size = new Size(80, 30)
            };

            var btnCancel = new Button
            {
                Text = "取消",
                DialogResult = DialogResult.Cancel,
                Location = new Point(230, 85),
                Size = new Size(80, 30)
            };

            inputForm.Controls.Add(lblPrompt);
            inputForm.Controls.Add(txtPassword);
            inputForm.Controls.Add(btnOK);
            inputForm.Controls.Add(btnCancel);
            inputForm.AcceptButton = btnOK;
            inputForm.CancelButton = btnCancel;

            if (inputForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var newPassword = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("密码不能为空。");
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("密码长度至少为 6 位。");
                return;
            }

            try
            {
                await ApiHelper.ResetPasswordAsync(selectedUserId.Value, newPassword);
                MessageBox.Show("密码已重置。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("重置密码失败：" + ex.Message);
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

