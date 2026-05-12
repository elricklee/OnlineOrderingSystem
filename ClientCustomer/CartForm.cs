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

        private static readonly Color PrimaryColor = Color.FromArgb(255, 109, 0);

        public CartForm(List<CartItem> cart, string orderType, string? tableNumber, string? deliveryAddress)
        {
            InitializeComponent();

            _cart = cart;
            _orderType = orderType;
            _tableNumber = tableNumber;
            _deliveryAddress = deliveryAddress;

            LoadCart();
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

            lblDeliveryFee.Visible = _orderType == "Delivery";
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
