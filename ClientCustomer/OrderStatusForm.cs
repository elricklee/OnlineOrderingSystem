using ClientCustomer.Models;
using Sunny.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ClientCustomer
{
    public partial class OrderStatusForm : UIForm
    {
        private readonly Color PrimaryColor = Color.FromArgb(255, 109, 0);
        private readonly Color TextColor = Color.FromArgb(51, 51, 51);
        private readonly Color TextSecondaryColor = Color.FromArgb(117, 117, 117);
        private readonly Color SuccessColor = Color.FromArgb(76, 175, 80);
        private readonly Color DangerColor = Color.FromArgb(244, 67, 54);
        private readonly Color InfoColor = Color.FromArgb(33, 150, 243);

        private UITextBox txtOrderId = null!;
        private UIButton btnQuery = null!;
        private UIGroupBox grpOrderInfo = null!;
        private UILabel lblOrderId = null!;
        private UILabel lblOrderType = null!;
        private UILabel lblTableNumber = null!;
        private UILabel lblAddress = null!;
        private UILabel lblStatus = null!;
        private UILabel lblTotalAmount = null!;
        private UILabel lblDeliveryFee = null!;
        private UILabel lblNote = null!;
        private UILabel lblCreatedAt = null!;
        private UIDataGridView dgvOrderItems = null!;

        public OrderStatusForm()
        {
            InitializeComponent();
            InitializeCustomControls();
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
                RowCount = 3,
                BackColor = Color.White,
                TagString = null
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 230F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            BuildOrderInfoPanel();

            mainLayout.Controls.Add(BuildQueryPanel(), 0, 0);
            mainLayout.Controls.Add(grpOrderInfo, 0, 1);
            mainLayout.Controls.Add(BuildOrderItemsPanel(), 0, 2);

            this.Controls.Add(mainLayout);
        }

        private UIPanel BuildQueryPanel()
        {
            var panel = new UIPanel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(250, 250, 250),
                Margin = new Padding(0),
                TagString = null
            };

            var lblHint = new UILabel
            {
                Text = "订单编号：",
                Font = new Font("微软雅黑", 11F),
                ForeColor = TextColor,
                Location = new Point(80, 18),
                Size = new Size(110, 30),
                TagString = null
            };

            txtOrderId = new UITextBox
            {
                Location = new Point(195, 14),
                Size = new Size(200, 36),
                Font = new Font("微软雅黑", 11F),
                FillColor = Color.White,
                TagString = null,
                Watermark = "请输入订单编号"
            };

            btnQuery = new UIButton
            {
                Text = "查询",
                Location = new Point(410, 14),
                Size = new Size(110, 36),
                Font = new Font("微软雅黑", 10F, FontStyle.Bold),
                FillColor = PrimaryColor,
                ForeColor = Color.White,
                RectColor = PrimaryColor,
                Radius = 6,
                Cursor = Cursors.Hand,
                TagString = null
            };
            btnQuery.Click += BtnQuery_Click;

            panel.Controls.AddRange(new Control[] { lblHint, txtOrderId, btnQuery });
            return panel;
        }

        private void BuildOrderInfoPanel()
        {
            grpOrderInfo = new UIGroupBox
            {
                Dock = DockStyle.Fill,
                Text = "订单信息",
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                FillColor = Color.White,
                Margin = new Padding(10, 5, 10, 5),
                TagString = null
            };

            lblOrderId = CreateInfoLabel("订单编号：-", 20, 35);
            lblOrderType = CreateInfoLabel("订单类型：-", 20, 65);
            lblTableNumber = CreateInfoLabel("桌号：-", 20, 95);
            lblAddress = CreateInfoLabel("配送地址：-", 20, 125);
            lblNote = CreateInfoLabel("备注：-", 20, 155);

            lblStatus = new UILabel
            {
                Text = "状态：-",
                Font = new Font("微软雅黑", 12F, FontStyle.Bold),
                ForeColor = TextSecondaryColor,
                Location = new Point(350, 35),
                Size = new Size(300, 30),
                TagString = null
            };

            lblTotalAmount = new UILabel
            {
                Text = "总金额：-",
                Font = new Font("微软雅黑", 12F, FontStyle.Bold),
                ForeColor = PrimaryColor,
                Location = new Point(350, 65),
                Size = new Size(300, 30),
                TagString = null
            };

            lblDeliveryFee = CreateInfoLabel("配送费：-", 350, 95);
            lblCreatedAt = CreateInfoLabel("创建时间：-", 350, 125);

            grpOrderInfo.Controls.AddRange(new Control[]
            {
                lblOrderId, lblOrderType, lblTableNumber, lblAddress,
                lblNote, lblStatus, lblTotalAmount, lblDeliveryFee, lblCreatedAt
            });
        }

        private UIPanel BuildOrderItemsPanel()
        {
            var panel = new UIPanel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.White,
                Margin = new Padding(10, 0, 10, 10),
                TagString = null
            };

            var grpItems = new UIGroupBox
            {
                Dock = DockStyle.Fill,
                Text = "订单明细",
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                FillColor = Color.White,
                TagString = null
            };

            dgvOrderItems = new UIDataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                GridColor = Color.FromArgb(224, 224, 224),
                Font = new Font("微软雅黑", 10F)
            };

            dgvOrderItems.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgvOrderItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrderItems.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
            dgvOrderItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderItems.EnableHeadersVisualStyles = false;
            dgvOrderItems.RowHeadersVisible = false;
            dgvOrderItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 248, 240);

            grpItems.Controls.Add(dgvOrderItems);
            panel.Controls.Add(grpItems);
            return panel;
        }

        private UILabel CreateInfoLabel(string text, int x, int y)
        {
            return new UILabel
            {
                Text = text,
                Font = new Font("微软雅黑", 10F),
                ForeColor = TextColor,
                Location = new Point(x, y),
                Size = new Size(300, 25),
                TagString = null
            };
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
    }
}
