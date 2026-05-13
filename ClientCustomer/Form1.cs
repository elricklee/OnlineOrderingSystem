using ClientCustomer.Models;
using Sunny.UI;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace ClientCustomer
{
    public partial class Form1 : UIForm
    {
        private readonly string _orderType;
        private readonly string? _tableNumber;
        private readonly string? _deliveryAddress;

        private List<DishDto> _allDishes = new();
        private List<CartItem> _cart = new();
        private string _selectedCategory = "全部";

        private static readonly Color PrimaryColor = Color.FromArgb(255, 109, 0);
        private static readonly Color TextColor = Color.FromArgb(51, 51, 51);
        private static readonly Color TextSecondaryColor = Color.FromArgb(117, 117, 117);
        private static readonly Color CardBgColor = Color.White;
        private static readonly Color SuccessColor = Color.FromArgb(76, 175, 80);
        private static readonly Color DangerColor = Color.FromArgb(244, 67, 54);
        private static readonly Color PrimaryDarkColor = Color.FromArgb(230, 81, 0);

        public Form1(string orderType, string? tableNumber, string? deliveryAddress)
        {
            InitializeComponent();

            _orderType = orderType;
            _tableNumber = tableNumber;
            _deliveryAddress = deliveryAddress;

            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;

            UpdateOrderInfoDisplay();
            _ = LoadDishesAsync();
        }

        private void UpdateOrderInfoDisplay()
        {
            if (_orderType == "DineIn")
            {
                lblOrderInfo.Text = $"[堂食 · 桌号：{_tableNumber}]";
            }
            else
            {
                lblOrderInfo.Text = $"[外卖 · 配送费：¥5]";
            }
        }

        private async Task LoadDishesAsync()
        {
            try
            {
                lblNoDish.Visible = true;
                lblNoDish.Text = "正在加载菜品...";

                _allDishes = await ApiHelper.GetDishesAsync();

                lblNoDish.Visible = false;
                DisplayDishes(_allDishes);
            }
            catch (Exception ex)
            {
                lblNoDish.Visible = true;
                lblNoDish.Text = $"加载菜品失败：{ex.Message}";
            }
        }

        private void DisplayDishes(List<DishDto> dishes)
        {
            dishFlowPanel.Controls.Clear();

            var availableDishes = dishes.Where(d => d.IsAvailable).ToList();

            if (availableDishes.Count == 0)
            {
                lblNoDish.Visible = true;
                lblNoDish.Text = "暂无菜品";
                return;
            }

            lblNoDish.Visible = false;

            foreach (var dish in availableDishes)
            {
                var card = CreateDishCard(dish);
                dishFlowPanel.Controls.Add(card);
            }
        }

        private Panel CreateDishCard(DishDto dish)
        {
            var card = new Panel
            {
                Width = 200,
                Height = 290,
                BackColor = CardBgColor,
                Margin = new Padding(6, 6, 6, 6),
                Padding = new Padding(8),
                Cursor = Cursors.Default
            };
            card.Paint += (s, e) =>
            {
                e.Graphics.Clear(CardBgColor);
                using var pen = new Pen(Color.FromArgb(224, 224, 224), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                using var shadowPen = new Pen(Color.FromArgb(240, 240, 240), 1);
                e.Graphics.DrawRectangle(shadowPen, 1, 1, card.Width - 3, card.Height - 3);
            };

            var picBox = new PictureBox
            {
                Size = new Size(182, 110),
                Location = new Point(9, 9),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(245, 245, 245),
                BorderStyle = BorderStyle.None
            };
            LoadDishImage(picBox, dish);

            var lblName = new UILabel
            {
                Text = dish.Name,
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                ForeColor = TextColor,
                Location = new Point(10, 125),
                Size = new Size(180, 25),
                TagString = null
            };

            var lblPrice = new UILabel
            {
                Text = $"¥{dish.Price:F0}",
                Font = new Font("微软雅黑", 14F, FontStyle.Bold),
                ForeColor = PrimaryColor,
                Location = new Point(10, 152),
                Size = new Size(100, 28),
                TagString = null
            };

            var lblSpicy = new UILabel
            {
                Text = GetSpicyDisplay(dish.SpicyLevel),
                Font = new Font("微软雅黑", 9F),
                ForeColor = dish.SpicyLevel > 0 ? DangerColor : SuccessColor,
                Location = new Point(115, 157),
                Size = new Size(75, 22),
                TagString = null
            };

            var lblDesc = new UILabel
            {
                Text = TruncateText(dish.Description ?? "", 18),
                Font = new Font("微软雅黑", 9F),
                ForeColor = TextSecondaryColor,
                Location = new Point(10, 183),
                Size = new Size(180, 30),
                TagString = null
            };

            var btnAdd = new UIButton
            {
                Text = "加入购物车",
                Size = new Size(182, 38),
                Location = new Point(9, 225),
                Font = new Font("微软雅黑", 10F),
                FillColor = PrimaryColor,
                ForeColor = Color.White,
                RectColor = PrimaryColor,
                Radius = 6,
                Cursor = Cursors.Hand,
                TagString = null
            };
            btnAdd.Click += (s, e) => AddToCart(dish);

            var lblCategory = new UILabel
            {
                Text = dish.Category,
                Font = new Font("微软雅黑", 8F),
                ForeColor = Color.FromArgb(158, 158, 158),
                Location = new Point(10, 268),
                Size = new Size(80, 18),
                TagString = null
            };

            card.Controls.AddRange(new Control[] { picBox, lblName, lblPrice, lblSpicy, lblDesc, btnAdd, lblCategory });
            return card;
        }

        private async void LoadDishImage(PictureBox picBox, DishDto dish)
        {
            if (!string.IsNullOrEmpty(dish.ImagePath))
            {
                try
                {
                    var imageUrl = dish.ImagePath.StartsWith("http")
                        ? dish.ImagePath
                        : $"http://localhost:5000{dish.ImagePath}";

                    using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
                    var imageBytes = await client.GetByteArrayAsync(imageUrl);

                    this.Invoke((MethodInvoker)delegate
                    {
                        try
                        {
                            using var ms = new MemoryStream(imageBytes);
                            picBox.Image = Image.FromStream(ms);
                        }
                        catch { }
                    });
                }
                catch { }
            }

            if (picBox.Image == null)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    DrawPlaceholderImage(picBox, dish.Name);
                });
            }
        }

        private void DrawPlaceholderImage(PictureBox picBox, string dishName)
        {
            var bmp = new Bitmap(picBox.Width, picBox.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                var brush = new SolidBrush(Color.FromArgb(255, 224, 178));
                g.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);

                var initial = dishName.Length > 0 ? dishName[0].ToString() : "?";
                var font = new Font("微软雅黑", 32F, FontStyle.Bold);
                var textColor = new SolidBrush(PrimaryDarkColor);
                var textSize = g.MeasureString(initial, font);
                g.DrawString(initial, font, textColor,
                    (bmp.Width - textSize.Width) / 2,
                    (bmp.Height - textSize.Height) / 2);
            }
            picBox.Image = bmp;
        }

        private void AddToCart(DishDto dish)
        {
            var existingItem = _cart.FirstOrDefault(c => c.DishId == dish.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    DishId = dish.Id,
                    DishName = dish.Name,
                    Price = dish.Price,
                    Quantity = 1
                });
            }

            UpdateCartBar();

            UIMessageTip.ShowOk($"已添加「{dish.Name}」到购物车", 1000);
        }

        private void UpdateCartBar()
        {
            if (_cart.Count == 0)
            {
                lblCartSummary.Text = "购物车：空";
                return;
            }

            var totalItems = _cart.Sum(c => c.Quantity);
            var totalAmount = _cart.Sum(c => c.Subtotal);
            var deliveryFee = _orderType == "Delivery" ? 5.00m : 0.00m;
            var finalTotal = totalAmount + deliveryFee;

            var summaryParts = _cart.Select(c => $"{c.DishName}x{c.Quantity}");
            var summaryText = string.Join("  ", summaryParts);

            if (_orderType == "Delivery")
            {
                lblCartSummary.Text = $"购物车({totalItems}件)：{summaryText}  商品合计：¥{totalAmount:F0}  配送费：¥{deliveryFee:F0}  总计：¥{finalTotal:F0}";
            }
            else
            {
                lblCartSummary.Text = $"购物车({totalItems}件)：{summaryText}  合计：¥{totalAmount:F0}";
            }
        }

        private void CategoryButton_Click(object? sender, EventArgs e)
        {
            if (sender is not UIButton btn) return;

            _selectedCategory = btn.Text;

            foreach (Control ctrl in categoryFlow.Controls)
            {
                if (ctrl is UIButton catBtn)
                {
                    catBtn.FillColor = catBtn.Text == _selectedCategory ? PrimaryColor : Color.White;
                    catBtn.ForeColor = catBtn.Text == _selectedCategory ? Color.White : TextColor;
                }
            }

            FilterDishes();
        }

        private void FilterDishes()
        {
            var filtered = _selectedCategory == "全部"
                ? _allDishes
                : _allDishes.Where(d => d.Category == _selectedCategory).ToList();

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var keyword = txtSearch.Text.Trim();
                filtered = filtered.Where(d => d.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            DisplayDishes(filtered);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            FilterDishes();
        }

        private void BtnCheckOrder_Click(object? sender, EventArgs e)
        {
            var orderStatusForm = new OrderStatusForm();
            orderStatusForm.ShowDialog(this);
        }

        private void BtnViewCart_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                UIMessageTip.ShowWarning("购物车为空");
                return;
            }

            var cartForm = new CartForm(_cart, _orderType, _tableNumber, _deliveryAddress);
            cartForm.ShowDialog(this);
            UpdateCartBar();
        }

        private void BtnCheckout_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                UIMessageTip.ShowWarning("购物车为空，请先选择菜品");
                return;
            }

            var cartForm = new CartForm(_cart, _orderType, _tableNumber, _deliveryAddress);
            cartForm.ShowDialog(this);
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

                if (result.Recommendations.Count > 0)
                {
                    var recTexts = result.Recommendations.Select(r => $"「{r.DishName}」- {r.Reason}");
                    lblAIText.Text = string.Join(" | ", recTexts);
                    lblAIText.ForeColor = SuccessColor;
                }
                else
                {
                    lblAIText.Text = "暂无推荐结果，请尝试选择更多菜品后再获取推荐";
                    lblAIText.ForeColor = TextSecondaryColor;
                }
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
                1 => "微辣🌶",
                2 => "中辣🌶🌶",
                3 => "特辣🌶🌶🌶",
                _ => "未知"
            };
        }

        private static string TruncateText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Length <= maxLength ? text : text.Substring(0, maxLength) + "...";
        }
    }
}
