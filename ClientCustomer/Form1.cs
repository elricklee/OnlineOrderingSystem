using ClientCustomer.Models;
using Sunny.UI;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace ClientCustomer
{
    public partial class Form1 : UIForm
    {
        private readonly OrderSession _session;
        private readonly List<DishDto> _allDishes = new();
        private readonly List<CartItem> _cart = new();

        private const string AllCategoryText = "菜品总览";
        private string _selectedCategory = AllCategoryText;
        private bool _eventsBound;

        private static readonly Color PrimaryColor = Color.FromArgb(255, 109, 0);
        private static readonly Color PrimaryDarkColor = Color.FromArgb(230, 81, 0);
        private static readonly Color SurfaceColor = Color.White;
        private static readonly Color TextColor = Color.FromArgb(51, 51, 51);
        private static readonly Color TextSecondaryColor = Color.FromArgb(117, 117, 117);
        private static readonly Color SuccessColor = Color.FromArgb(76, 175, 80);
        private static readonly Color DangerColor = Color.FromArgb(244, 67, 54);

        public Form1(OrderSession session)
        {
            InitializeComponent();
            _session = session ?? new OrderSession();
            Load += Form1_Load;
        }

        public Form1(string orderType, string? tableNumber, string? deliveryAddress)
            : this(new OrderSession
            {
                OrderType = orderType,
                TableNumber = tableNumber,
                DeliveryAddressDetail = deliveryAddress
            })
        {
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            BindEventsOnce();
            ApplyVisualTweaks();
            UpdateOrderInfoDisplay();
            UpdateCartBar();
            _ = LoadDishesAsync();
        }

        private void BindEventsOnce()
        {
            if (_eventsBound)
            {
                return;
            }

            _eventsBound = true;
            txtSearch.KeyDown += TxtSearch_KeyDown;
        }

        private void ApplyVisualTweaks()
        {
            Text = "珞珈线上点餐系统";
            lblTitle.Text = "珞珈线上点餐系统";

            if (Program.CurrentUser != null)
            {
                lblTitle.Text = $"珞珈线上点餐系统 - 欢迎，{Program.CurrentUser.RealName ?? Program.CurrentUser.Username}";
                btnCheckOrder.Text = "我的订单";
            }
            else if (Program.IsGuestMode)
            {
                lblTitle.Text = "珞珈线上点餐系统 - 游客浏览";
                btnCheckOrder.Text = "游客说明";
                btnBack.Text = "返回登录";
            }
            else
            {
                btnCheckOrder.Text = "查订单";
            }

            btnSearch.Text = "搜索";
            btnRefresh.Text = "刷新";
            btnBack.Text = "重选模式";
            btnViewCart.Text = "购物车";
            btnCheckout.Text = "去结算";
            btnGetRecommend.Text = "获取推荐";
            btnLogout.Text = Program.IsGuestMode ? "退出游客" : Program.CurrentUser == null ? "退出" : "退出登录";
            lblAITitle.Text = "AI 推荐";
            lblAIText.Text = "先挑几道菜，AI 会帮你推荐更搭配的组合。";
            lblAIText.ForeColor = TextSecondaryColor;

            txtSearch.Watermark = "输入菜名搜索";

            StyleActionButton(btnSearch, Color.White, PrimaryDarkColor);
            StyleActionButton(btnRefresh, Color.White, PrimaryDarkColor);
            StyleActionButton(btnBack, Color.White, PrimaryDarkColor);
            StyleActionButton(btnCheckOrder, Color.White, PrimaryDarkColor);
            StyleActionButton(btnLogout, Color.White, PrimaryDarkColor);
            StyleActionButton(btnViewCart, PrimaryColor, Color.White);
            StyleActionButton(btnCheckout, Color.FromArgb(44, 62, 80), Color.White);
            StyleActionButton(btnGetRecommend, Color.FromArgb(46, 125, 50), Color.White);

            if (Program.IsGuestMode)
            {
                btnViewCart.Enabled = false;
                btnCheckout.Enabled = false;
                btnCheckOrder.Enabled = true;
                lblAIText.Text = "游客模式下可以浏览菜品和查看推荐，登录后才能加入购物车并下单。";
            }
        }

        private static void StyleActionButton(UIButton button, Color fillColor, Color foreColor)
        {
            button.FillColor = fillColor;
            button.RectColor = fillColor;
            button.ForeColor = foreColor;
            button.Radius = Math.Max(button.Radius, 8);
            button.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        }

        private void UpdateOrderInfoDisplay()
        {
            if (_session.OrderType == "DineIn")
            {
                lblOrderInfo.Text = $"[堂食 · 桌号：{_session.TableNumber ?? "未选择"}]";
                return;
            }

            if (_session.OrderType == "Browse")
            {
                lblOrderInfo.Text = "[游客浏览模式 · 仅可查看菜品]";
                return;
            }

            var region = string.IsNullOrWhiteSpace(_session.DeliveryRegion)
                ? "未选择配送区域"
                : _session.DeliveryRegion;

            var feeText = _session.DeliveryZoneId == null
                ? "配送费待定"
                : $"配送费：¥{_session.DeliveryFee:0.##}";

            lblOrderInfo.Text = $"[外卖 · {region} · {feeText}]";
        }

        private async Task LoadDishesAsync()
        {
            try
            {
                lblNoDish.Visible = true;
                lblNoDish.Text = "正在加载菜品...";

                var dishes = await ApiHelper.GetDishesAsync();
                _allDishes.Clear();
                _allDishes.AddRange(dishes);

                BuildCategoryButtons(_allDishes.Select(d => d.Category));
                FilterDishes();
            }
            catch (Exception ex)
            {
                lblNoDish.Visible = true;
                lblNoDish.Text = $"加载菜品失败：{ex.Message}";
            }
        }

        private void BuildCategoryButtons(IEnumerable<string> categories)
        {
            var categoryList = categories
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            categoryFlow.Controls.Clear();
            categoryFlow.WrapContents = false;

            CreateCategoryButton(AllCategoryText, true);
            foreach (var category in categoryList)
            {
                CreateCategoryButton(category, false);
            }
        }

        private void CreateCategoryButton(string text, bool selected)
        {
            var button = new UIButton
            {
                Text = text,
                Width = Math.Max(90, text.Length * 20 + 28),
                Height = 34,
                Font = new Font("微软雅黑", 9.5F, FontStyle.Bold),
                Radius = 16,
                Cursor = Cursors.Hand,
                FillColor = selected ? PrimaryColor : Color.White,
                RectColor = selected ? PrimaryColor : Color.FromArgb(220, 220, 220),
                ForeColor = selected ? Color.White : TextColor,
                TagString = null
            };
            button.Click += CategoryButton_Click;
            categoryFlow.Controls.Add(button);
        }

        private void DisplayDishes(List<DishDto> dishes)
        {
            dishFlowPanel.Controls.Clear();
            var availableDishes = dishes.Where(d => d.IsAvailable).ToList();

            if (availableDishes.Count == 0)
            {
                lblNoDish.Visible = true;
                lblNoDish.Text = "暂无符合条件的菜品";
                return;
            }

            lblNoDish.Visible = false;

            foreach (var dish in availableDishes)
            {
                dishFlowPanel.Controls.Add(CreateDishCard(dish));
            }
        }

        private Panel CreateDishCard(DishDto dish)
        {
            var card = new Panel
            {
                Width = 244,
                Height = 330,
                BackColor = SurfaceColor,
                Margin = new Padding(10)
            };

            card.Paint += (_, e) =>
            {
                e.Graphics.Clear(SurfaceColor);
                using var borderPen = new Pen(Color.FromArgb(230, 230, 230), 1);
                e.Graphics.DrawRectangle(borderPen, 0, 0, card.Width - 1, card.Height - 1);
            };

            var pictureBox = new PictureBox
            {
                Size = new Size(220, 112),
                Location = new Point(12, 12),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(248, 248, 248)
            };
            LoadDishImage(pictureBox, dish);

            var lblName = new UILabel
            {
                Text = dish.Name,
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                ForeColor = TextColor,
                Location = new Point(12, 132),
                Size = new Size(220, 28),
                AutoEllipsis = true,
                TagString = null
            };

            var lblPrice = new UILabel
            {
                Text = $"¥{dish.Price:0.##}",
                Font = new Font("微软雅黑", 15F, FontStyle.Bold),
                ForeColor = PrimaryColor,
                Location = new Point(12, 162),
                Size = new Size(112, 30),
                TagString = null
            };

            var lblSpicy = new UILabel
            {
                Text = GetSpicyDisplay(dish.SpicyLevel),
                Font = new Font("微软雅黑", 9F),
                ForeColor = dish.SpicyLevel > 0 ? DangerColor : SuccessColor,
                Location = new Point(128, 166),
                Size = new Size(104, 24),
                TextAlign = ContentAlignment.MiddleRight,
                TagString = null
            };

            var description = string.IsNullOrWhiteSpace(dish.Description) || dish.Description.Trim() == "空"
                ? string.Empty
                : $"  {dish.Description.Trim()}";

            var lblDesc = new UILabel
            {
                Text = $"分类：{dish.Category}{description}",
                Font = new Font("微软雅黑", 8.5F),
                ForeColor = PrimaryDarkColor,
                Location = new Point(12, 198),
                Size = new Size(220, 24),
                AutoEllipsis = true,
                TagString = null
            };

            var lblQuantity = new UILabel
            {
                Text = "数量：",
                Font = new Font("微软雅黑", 9F),
                ForeColor = TextSecondaryColor,
                Location = new Point(12, 236),
                Size = new Size(72, 26),
                TagString = null
            };

            var quantityInput = new NumericUpDown
            {
                Font = new Font("微软雅黑", 10F),
                Location = new Point(86, 232),
                Minimum = 1,
                Maximum = 99,
                Value = 1,
                Size = new Size(72, 30),
                TextAlign = HorizontalAlignment.Center
            };

            var btnAdd = new UIButton
            {
                Text = "加入购物车",
                Size = new Size(220, 38),
                Location = new Point(12, 276),
                Font = new Font("微软雅黑", 10F, FontStyle.Bold),
                FillColor = PrimaryColor,
                RectColor = PrimaryColor,
                ForeColor = Color.White,
                Radius = 8,
                Cursor = Cursors.Hand,
                TagString = null
            };
            btnAdd.Click += (_, _) => AddToCart(dish, (int)quantityInput.Value);

            if (Program.IsGuestMode)
            {
                btnAdd.Enabled = false;
                btnAdd.Text = "登录后可下单";
                btnAdd.FillColor = Color.FromArgb(189, 189, 189);
                btnAdd.RectColor = Color.FromArgb(189, 189, 189);
            }

            card.Controls.AddRange(
                new Control[]
                {
                    pictureBox, lblName, lblPrice, lblSpicy, lblDesc,
                    lblQuantity, quantityInput, btnAdd
                });

            return card;
        }

        private async void LoadDishImage(PictureBox pictureBox, DishDto dish)
        {
            if (!string.IsNullOrWhiteSpace(dish.ImagePath))
            {
                try
                {
                    var imageUrl = dish.ImagePath.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                        ? dish.ImagePath
                        : $"http://127.0.0.1:5000{dish.ImagePath}";

                    using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
                    var imageBytes = await client.GetByteArrayAsync(imageUrl);

                    if (IsDisposed || !IsHandleCreated)
                    {
                        return;
                    }

                    BeginInvoke((MethodInvoker)delegate
                    {
                        using var ms = new MemoryStream(imageBytes);
                        pictureBox.Image = Image.FromStream(ms);
                    });
                }
                catch
                {
                }
            }

            if (pictureBox.Image == null && !IsDisposed && IsHandleCreated)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    if (pictureBox.Image == null)
                    {
                        DrawPlaceholderImage(pictureBox, dish.Name);
                    }
                });
            }
        }

        private void DrawPlaceholderImage(PictureBox pictureBox, string dishName)
        {
            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using var graphics = Graphics.FromImage(bitmap);
            using var backgroundBrush = new SolidBrush(Color.FromArgb(255, 235, 210));
            using var textBrush = new SolidBrush(PrimaryDarkColor);
            using var font = new Font("微软雅黑", 30F, FontStyle.Bold);

            graphics.FillRectangle(backgroundBrush, 0, 0, bitmap.Width, bitmap.Height);
            var initial = string.IsNullOrWhiteSpace(dishName) ? "?" : dishName[0].ToString();
            var size = graphics.MeasureString(initial, font);
            graphics.DrawString(
                initial,
                font,
                textBrush,
                (bitmap.Width - size.Width) / 2,
                (bitmap.Height - size.Height) / 2);

            pictureBox.Image = bitmap;
        }

        private void AddToCart(DishDto dish, int quantity)
        {
            if (Program.IsGuestMode)
            {
                UIMessageTip.ShowWarning("游客模式仅支持浏览菜品，请先登录后再下单。");
                return;
            }

            var existingItem = _cart.FirstOrDefault(c => c.DishId == dish.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    DishId = dish.Id,
                    DishName = dish.Name,
                    Price = dish.Price,
                    Quantity = quantity
                });
            }

            UpdateCartBar();
            UIMessageTip.ShowOk($"已加入 {quantity} 份「{dish.Name}」", 1000);
        }

        private void UpdateCartBar()
        {
            if (Program.IsGuestMode)
            {
                lblCartSummary.Text = "游客模式：当前仅可浏览菜品，登录后可加入购物车并下单";
                return;
            }

            if (_cart.Count == 0)
            {
                lblCartSummary.Text = "购物车：空";
                return;
            }

            var totalItems = _cart.Sum(c => c.Quantity);
            var subtotal = _cart.Sum(c => c.Subtotal);
            var isDelivery = _session.OrderType == "Delivery";
            var finalTotal = subtotal + _session.DeliveryFee;
            var summaryText = string.Join("  ", _cart.Select(c => $"{c.DishName}x{c.Quantity}"));

            if (isDelivery)
            {
                var feeText = _session.DeliveryZoneId == null
                    ? "待选择区域"
                    : $"¥{_session.DeliveryFee:0.##}";
                lblCartSummary.Text =
                    $"购物车({totalItems}件)：{summaryText}  商品合计：¥{subtotal:0.##}  配送费：{feeText}" +
                    (_session.DeliveryZoneId == null ? string.Empty : $"  总计：¥{finalTotal:0.##}");
            }
            else
            {
                lblCartSummary.Text = $"购物车({totalItems}件)：{summaryText}  合计：¥{subtotal:0.##}";
            }
        }

        private void CategoryButton_Click(object? sender, EventArgs e)
        {
            if (sender is not UIButton button)
            {
                return;
            }

            _selectedCategory = button.Text;
            foreach (Control control in categoryFlow.Controls)
            {
                if (control is UIButton categoryButton)
                {
                    var selected = categoryButton.Text == _selectedCategory;
                    categoryButton.FillColor = selected ? PrimaryColor : Color.White;
                    categoryButton.RectColor = selected ? PrimaryColor : Color.FromArgb(220, 220, 220);
                    categoryButton.ForeColor = selected ? Color.White : TextColor;
                }
            }

            FilterDishes();
        }

        private void FilterDishes()
        {
            IEnumerable<DishDto> filtered = _allDishes;

            if (_selectedCategory != AllCategoryText)
            {
                filtered = filtered.Where(d => d.Category == _selectedCategory);
            }

            var keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filtered = filtered.Where(d =>
                    d.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    (d.Description?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false));
            }

            DisplayDishes(filtered.ToList());
        }

        private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                FilterDishes();
            }
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            FilterDishes();
        }

        private async void BtnRefresh_Click(object? sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "刷新中...";

            try
            {
                await LoadDishesAsync();
                UIMessageTip.ShowOk("菜品列表已刷新");
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError($"刷新失败：{ex.Message}");
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnRefresh.Text = "刷新";
            }
        }

        private void BtnBack_Click(object? sender, EventArgs e)
        {
            DialogResult = Program.IsGuestMode ? DialogResult.Abort : DialogResult.Retry;
            Close();
        }

        private void BtnCheckOrder_Click(object? sender, EventArgs e)
        {
            if (Program.CurrentUser != null)
            {
                using var orderHistoryForm = new OrderHistoryForm(Program.CurrentUser.Id);
                orderHistoryForm.ShowDialog(this);
            }
            else if (Program.IsGuestMode)
            {
                MessageBox.Show("游客模式仅支持浏览菜品，不支持购物车、下单和个人订单查询。", "游客说明", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using var orderStatusForm = new OrderStatusForm();
                orderStatusForm.ShowDialog(this);
            }
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Program.CurrentUser = null;
            Program.IsGuestMode = false;
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void BtnViewCart_Click(object? sender, EventArgs e)
        {
            OpenCartDialog();
        }

        private void BtnCheckout_Click(object? sender, EventArgs e)
        {
            OpenCartDialog();
        }

        private void OpenCartDialog()
        {
            if (Program.IsGuestMode)
            {
                UIMessageTip.ShowWarning("游客模式不能加入购物车或结算，请先登录。");
                return;
            }

            if (_cart.Count == 0)
            {
                UIMessageTip.ShowWarning("购物车为空，请先选择菜品");
                return;
            }

            using var cartForm = new CartForm(_cart, _session);
            cartForm.ShowDialog(this);
            UpdateOrderInfoDisplay();
            UpdateCartBar();
        }

        private async void BtnGetRecommend_Click(object? sender, EventArgs e)
        {
            btnGetRecommend.Enabled = false;
            btnGetRecommend.Text = "获取中...";

            try
            {
                var request = new RecommendationRequestDto
                {
                    CurrentItems = _cart.Select(c => new CurrentItemDto
                    {
                        DishId = c.DishId,
                        DishName = c.DishName
                    }).ToList(),
                    Preferences = ""
                };

                var result = await ApiHelper.GetRecommendationAsync(request);

                if (result.Recommendations.Count == 0)
                {
                    lblAIText.Text = "当前没有推荐结果，试试先加几道菜。";
                    lblAIText.ForeColor = TextSecondaryColor;
                    return;
                }

                lblAIText.Text = string.Join(
                    " | ",
                    result.Recommendations.Select(item => $"「{item.DishName}」{item.Reason}"));
                lblAIText.ForeColor = SuccessColor;
            }
            catch (Exception ex)
            {
                lblAIText.Text = $"推荐获取失败：{ex.Message}";
                lblAIText.ForeColor = DangerColor;
            }
            finally
            {
                btnGetRecommend.Enabled = true;
                btnGetRecommend.Text = "获取推荐";
            }
        }

        private static string GetSpicyDisplay(int level)
        {
            return level switch
            {
                0 => "不辣",
                1 => "微辣 🌶",
                2 => "中辣 🌶🌶",
                3 => "特辣 🌶🌶🌶",
                _ => "未知"
            };
        }

        private static string TruncateText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return text.Length <= maxLength ? text : text[..maxLength] + "...";
        }

        private void lblOrderInfo_Click(object sender, EventArgs e)
        {
        }

        private void dishFlowPanel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
