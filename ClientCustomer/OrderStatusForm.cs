using ClientCustomer.Models;
using Sunny.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ClientCustomer
{
    public partial class OrderStatusForm : UIForm
    {
        private static readonly Color PrimaryColor = Color.FromArgb(255, 109, 0);
        private static readonly Color TextSecondaryColor = Color.FromArgb(117, 117, 117);
        private static readonly Color SuccessColor = Color.FromArgb(76, 175, 80);
        private static readonly Color DangerColor = Color.FromArgb(244, 67, 54);
        private static readonly Color InfoColor = Color.FromArgb(33, 150, 243);

        public OrderStatusForm()
        {
            InitializeComponent();
        }

        private async void BtnQuery_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderId.Text))
            {
                UIMessageTip.ShowWarning("请输入订单编号");
                txtOrderId.Focus();
                return;
            }

            if (!int.TryParse(txtOrderId.Text.Trim(), out int orderId))
            {
                UIMessageTip.ShowWarning("请输入有效的订单编号");
                txtOrderId.Focus();
                return;
            }

            btnQuery.Enabled = false;
            btnQuery.Text = "查询中...";

            try
            {
                var order = await ApiHelper.GetOrderAsync(orderId);
                DisplayOrderInfo(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearOrderInfo();
            }
            finally
            {
                btnQuery.Enabled = true;
                btnQuery.Text = "查询";
            }
        }

        private void DisplayOrderInfo(OrderDto order)
        {
            lblOrderId.Text = $"订单编号：{order.Id}";
            lblOrderType.Text = $"订单类型：{GetOrderTypeText(order.OrderType)}";
            lblTableNumber.Text = $"桌号：{order.TableNumber ?? "-"}";
            lblAddress.Text = $"配送地址：{order.Address ?? "-"}";
            lblNote.Text = $"备注：{order.Note ?? "-"}";
            lblDeliveryFee.Text = $"配送费：¥{order.DeliveryFee:F2}";
            lblCreatedAt.Text = $"创建时间：{order.CreatedAt:yyyy-MM-dd HH:mm:ss}";

            lblStatus.Text = $"状态：{GetStatusText(order.Status)}";
            lblStatus.ForeColor = GetStatusColor(order.Status);

            lblTotalAmount.Text = $"总金额：¥{order.TotalAmount:F2}";

            dgvOrderItems.DataSource = null;
            dgvOrderItems.DataSource = order.OrderItems.Select(oi => new
            {
                菜品名称 = oi.DishName,
                单价 = $"¥{oi.Price:F2}",
                数量 = oi.Quantity,
                小计 = $"¥{oi.Price * oi.Quantity:F2}"
            }).ToList();

            if (dgvOrderItems.Columns["菜品名称"] != null)
                dgvOrderItems.Columns["菜品名称"]!.FillWeight = 40;
            if (dgvOrderItems.Columns["单价"] != null)
                dgvOrderItems.Columns["单价"]!.FillWeight = 20;
            if (dgvOrderItems.Columns["数量"] != null)
                dgvOrderItems.Columns["数量"]!.FillWeight = 20;
            if (dgvOrderItems.Columns["小计"] != null)
                dgvOrderItems.Columns["小计"]!.FillWeight = 20;
        }

        private void ClearOrderInfo()
        {
            lblOrderId.Text = "订单编号：-";
            lblOrderType.Text = "订单类型：-";
            lblTableNumber.Text = "桌号：-";
            lblAddress.Text = "配送地址：-";
            lblNote.Text = "备注：-";
            lblStatus.Text = "状态：-";
            lblStatus.ForeColor = TextSecondaryColor;
            lblTotalAmount.Text = "总金额：-";
            lblDeliveryFee.Text = "配送费：-";
            lblCreatedAt.Text = "创建时间：-";
            dgvOrderItems.DataSource = null;
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

        private Color GetStatusColor(string status)
        {
            return status switch
            {
                "Pending" => InfoColor,
                "Confirmed" => InfoColor,
                "Preparing" => PrimaryColor,
                "Ready" => SuccessColor,
                "Delivering" => PrimaryColor,
                "Completed" => SuccessColor,
                "Cancelled" => DangerColor,
                _ => TextSecondaryColor
            };
        }

        private static string GetOrderTypeText(string orderType)
        {
            return orderType switch
            {
                "DineIn" => "堂食",
                "Delivery" => "外卖",
                _ => orderType
            };
        }

        private void lblHint_Click(object sender, EventArgs e)
        {

        }
    }
}
