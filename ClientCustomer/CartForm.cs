using ClientCustomer.Models;
using Sunny.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ClientCustomer
{
    public partial class CartForm : UIForm
    {
        private readonly List<CartItem> _cart;
        private readonly string _orderType;
        private readonly string? _tableNumber;
        private readonly string? _deliveryAddress;

        private readonly Color PrimaryColor = Color.FromArgb(255, 109, 0);
        private readonly Color PrimaryLightColor = Color.FromArgb(255, 243, 224);
        private readonly Color TextColor = Color.FromArgb(51, 51, 51);
        private readonly Color TextSecondaryColor = Color.FromArgb(117, 117, 117);
        private readonly Color SuccessColor = Color.FromArgb(76, 175, 80);
        private readonly Color DangerColor = Color.FromArgb(244, 67, 54);

        private UIDataGridView dgvCart = null!;
        private UITextBox txtNote = null!;
        private UILabel lblSubtotal = null!;
        private UILabel lblDeliveryFee = null!;
        private UILabel lblTotal = null!;
        private UIButton btnClearCart = null!;
        private UIButton btnSubmitOrder = null!;

        public CartForm(List<CartItem> cart, string orderType, string? tableNumber, string? deliveryAddress)
        {
            InitializeComponent();

            _cart = cart;
            _orderType = orderType;
            _tableNumber = tableNumber;
            _deliveryAddress = deliveryAddress;

            InitializeCustomControls();
            LoadCart();
        }

        private void InitializeCustomControls()
        {
            this.BackColor = Color.White;
            this.Padding = new Padding(0, 36, 0, 0);
            this.ShowTitle = true;
            this.TitleColor = PrimaryColor;

            var mainLayout = new UITableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = Color.White,
                TagString = null
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            CreateCartGrid();

            mainLayout.Controls.Add(dgvCart, 0, 0);
            mainLayout.Controls.Add(BuildNotePanel(), 0, 1);
            mainLayout.Controls.Add(BuildTotalPanel(), 0, 2);
            mainLayout.Controls.Add(BuildButtonPanel(), 0, 3);

            this.Controls.Add(mainLayout);
        }

        private void CreateCartGrid()
        {
            dgvCart = new UIDataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                GridColor = Color.FromArgb(224, 224, 224),
                Font = new Font("微软雅黑", 10F),
                Margin = new Padding(10)
            };

            dgvCart.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
            dgvCart.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.RowHeadersVisible = false;
            dgvCart.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 248, 240);
        }

        private UIPanel BuildNotePanel()
        {
            var panel = new UIPanel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(250, 250, 250),
                Margin = new Padding(0),
                TagString = null
            };

            var lblNote = new UILabel
            {
                Text = "订单备注：",
                Font = new Font("微软雅黑", 10F),
                ForeColor = TextColor,
                Location = new Point(15, 25),
                Size = new Size(100, 30),
                TagString = null
            };

            txtNote = new UITextBox
            {
                Location = new Point(120, 22),
                Size = new Size(650, 36),
                Font = new Font("微软雅黑", 10F),
                FillColor = Color.White,
                TagString = null,
                Watermark = "请输入备注信息（选填）"
            };

            panel.Controls.AddRange(new Control[] { lblNote, txtNote });
            return panel;
        }

        private UIPanel BuildTotalPanel()
        {
            var panel = new UIPanel
            {
                Dock = DockStyle.Fill,
                FillColor = PrimaryLightColor,
                Margin = new Padding(0),
                TagString = null
            };

            var lblSubtotalLabel = new UILabel
            {
                Text = "商品合计：",
                Font = new Font("微软雅黑", 11F),
                ForeColor = TextColor,
                Location = new Point(420, 10),
                Size = new Size(110, 28),
                TagString = null
            };

            lblSubtotal = new UILabel
            {
                Text = "¥0",
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                ForeColor = PrimaryColor,
                Location = new Point(530, 10),
                Size = new Size(120, 28),
                TagString = null
            };

            var lblDeliveryFeeLabel = new UILabel
            {
                Text = "配送费：",
                Font = new Font("微软雅黑", 11F),
                ForeColor = TextColor,
                Location = new Point(420, 42),
                Size = new Size(110, 28),
                Visible = _orderType == "Delivery",
                TagString = null
            };

            lblDeliveryFee = new UILabel
            {
                Text = "¥5",
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                ForeColor = PrimaryColor,
                Location = new Point(530, 42),
                Size = new Size(120, 28),
                Visible = _orderType == "Delivery",
                TagString = null
            };

            var lblTotalLabel = new UILabel
            {
                Text = "应付总额：",
                Font = new Font("微软雅黑", 13F, FontStyle.Bold),
                ForeColor = TextColor,
                Location = new Point(420, 74),
                Size = new Size(130, 32),
                TagString = null
            };

            lblTotal = new UILabel
            {
                Text = "¥0",
                Font = new Font("微软雅黑", 13F, FontStyle.Bold),
                ForeColor = DangerColor,
                Location = new Point(550, 74),
                Size = new Size(150, 32),
                TagString = null
            };

            var orderInfoLabel = new UILabel
            {
                Font = new Font("微软雅黑", 10F),
                ForeColor = TextSecondaryColor,
                Location = new Point(15, 10),
                Size = new Size(380, 100),
                TagString = null
            };

            if (_orderType == "DineIn")
            {
                orderInfoLabel.Text = $"堂食订单\n桌号：{_tableNumber}\n\n请在备注中填写特殊要求";
            }
            else
            {
                orderInfoLabel.Text = $"外卖订单\n配送地址：{_deliveryAddress}\n配送费：¥5.00";
            }

            panel.Controls.AddRange(new Control[] { orderInfoLabel, lblSubtotalLabel, lblSubtotal, lblDeliveryFeeLabel, lblDeliveryFee, lblTotalLabel, lblTotal });
            return panel;
        }

        private UIPanel BuildButtonPanel()
        {
            var panel = new UIPanel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.White,
                Margin = new Padding(0),
                TagString = null
            };

            btnClearCart = new UIButton
            {
                Text = "清空购物车",
                Location = new Point(200, 12),
                Size = new Size(140, 42),
                Font = new Font("微软雅黑", 10F),
                FillColor = Color.White,
                ForeColor = DangerColor,
                RectColor = DangerColor,
                Radius = 6,
                Cursor = Cursors.Hand,
                TagString = null
            };
            btnClearCart.Click += BtnClearCart_Click;

            btnSubmitOrder = new UIButton
            {
                Text = "提交订单",
                Location = new Point(480, 12),
                Size = new Size(160, 42),
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                FillColor = PrimaryColor,
                ForeColor = Color.White,
                RectColor = PrimaryColor,
                Radius = 6,
                Cursor = Cursors.Hand,
                TagString = null
            };
            btnSubmitOrder.Click += BtnSubmitOrder_Click;

            panel.Controls.AddRange(new Control[] { btnClearCart, btnSubmitOrder });
            return panel;
        }

        private void LoadCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart.Select(c => new
            {
                菜品名称 = c.DishName,
                单价 = $"¥{c.Price:F2}",
                数量 = c.Quantity,
                小计 = $"¥{c.Subtotal:F2}"
            }).ToList();

            if (dgvCart.Columns["菜品名称"] != null)
                dgvCart.Columns["菜品名称"]!.FillWeight = 40;
            if (dgvCart.Columns["单价"] != null)
                dgvCart.Columns["单价"]!.FillWeight = 20;
            if (dgvCart.Columns["数量"] != null)
                dgvCart.Columns["数量"]!.FillWeight = 20;
            if (dgvCart.Columns["小计"] != null)
                dgvCart.Columns["小计"]!.FillWeight = 20;

            UpdateTotals();
        }

        private void UpdateTotals()
        {
            var subtotal = _cart.Sum(c => c.Subtotal);
            var deliveryFee = _orderType == "Delivery" ? 5.00m : 0.00m;
            var total = subtotal + deliveryFee;

            lblSubtotal.Text = $"¥{subtotal:F2}";
            lblDeliveryFee.Text = $"¥{deliveryFee:F2}";
            lblTotal.Text = $"¥{total:F2}";
        }

        private void BtnClearCart_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0) return;

            var result = MessageBox.Show("确定要清空购物车吗？", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _cart.Clear();
                LoadCart();
            }
        }

        private async void BtnSubmitOrder_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                UIMessageTip.ShowWarning("购物车为空");
                return;
            }

            btnSubmitOrder.Enabled = false;
            btnSubmitOrder.Text = "提交中...";

            try
            {
                var orderCreate = new OrderCreateDto
                {
                    CustomerName = _orderType == "DineIn" ? $"桌号{_tableNumber}" : "外卖顾客",
                    Phone = "",
                    OrderType = _orderType,
                    TableNumber = _tableNumber,
                    Address = _deliveryAddress,
                    Note = txtNote.Text.Trim(),
                    DeliveryFee = _orderType == "Delivery" ? 5.00m : 0.00m,
                    OrderItems = _cart.Select(c => new OrderItemDto
                    {
                        DishId = c.DishId,
                        Quantity = c.Quantity
                    }).ToList()
                };

                var orderResult = await ApiHelper.CreateOrderAsync(orderCreate);

                _cart.Clear();

                MessageBox.Show(
                    $"订单提交成功！\n\n订单编号：{orderResult.Id}\n订单状态：{GetStatusText(orderResult.Status)}\n总金额：¥{orderResult.TotalAmount:F2}",
                    "下单成功",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"订单提交失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSubmitOrder.Enabled = true;
                btnSubmitOrder.Text = "提交订单";
            }
        }

        private static string GetStatusText(string status)
        {
            return status switch
            {
                "Pending" => "待处理",
                "Confirmed" => "已确认",
                "Preparing" => "制作中",
                "Ready" => "已出餐",
                "Delivering" => "配送中",
                "Completed" => "已完成",
                "Cancelled" => "已取消",
                _ => status
            };
        }
    }
}
