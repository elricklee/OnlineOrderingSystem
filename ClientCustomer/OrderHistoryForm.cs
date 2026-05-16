using ClientCustomer.Models;

namespace ClientCustomer;

public partial class OrderHistoryForm : Form
{
    private readonly int _userId;
    private List<OrderDto> _orders = new();

    public OrderHistoryForm(int userId)
    {
        _userId = userId;
        InitializeComponent();
        BindEvents();
    }

    private void BindEvents()
    {
        Load += OrderHistoryForm_Load;
        dgvOrders.CellClick += DgvOrders_CellClick;
        btnClose.Click += BtnClose_Click;
    }

    private async void OrderHistoryForm_Load(object? sender, EventArgs e)
    {
        await LoadOrdersAsync();
    }

    private async Task LoadOrdersAsync()
    {
        try
        {
            _orders = await ApiHelper.GetOrdersByUserIdAsync(_userId);
            dgvOrders.DataSource = _orders;
            SetGridHeaders();
            ClearDetail();
        }
        catch (Exception ex)
        {
            MessageBox.Show("加载订单失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SetGridHeaders()
    {
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        if (dgvOrders.Columns["Id"] != null)
        {
            dgvOrders.Columns["Id"].HeaderText = "订单号";
            dgvOrders.Columns["Id"].FillWeight = 50;
        }

        if (dgvOrders.Columns["OrderType"] != null)
        {
            dgvOrders.Columns["OrderType"].HeaderText = "类型";
            dgvOrders.Columns["OrderType"].FillWeight = 50;
        }

        if (dgvOrders.Columns["TotalAmount"] != null)
        {
            dgvOrders.Columns["TotalAmount"].HeaderText = "总金额";
            dgvOrders.Columns["TotalAmount"].FillWeight = 60;
            dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
        }

        if (dgvOrders.Columns["Status"] != null)
        {
            dgvOrders.Columns["Status"].HeaderText = "状态";
            dgvOrders.Columns["Status"].FillWeight = 50;
        }

        if (dgvOrders.Columns["CreatedAt"] != null)
        {
            dgvOrders.Columns["CreatedAt"].HeaderText = "下单时间";
            dgvOrders.Columns["CreatedAt"].FillWeight = 80;
            dgvOrders.Columns["CreatedAt"].DefaultCellStyle.Format = "MM-dd HH:mm";
        }

        foreach (var col in new[] { "UserId", "CustomerName", "Phone", "Address", "TableNumber", "DiningTableId", "Note", "DeliveryFee", "DeliveryZoneId", "DeliveryRegion", "OrderItems" })
        {
            if (dgvOrders.Columns[col] != null)
                dgvOrders.Columns[col].Visible = false;
        }
    }

    private void DgvOrders_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var order = _orders.ElementAtOrDefault(e.RowIndex);
        if (order == null) return;

        ShowOrderDetail(order);
    }

    private void ShowOrderDetail(OrderDto order)
    {
        lblOrderId.Text = $"订单编号：{order.Id}";
        lblOrderType.Text = $"订单类型：{(order.OrderType == "DineIn" ? "堂食" : "外卖")}";
        lblStatus.Text = $"状态：{GetStatusText(order.Status)}";
        lblTotalAmount.Text = $"总金额：¥{order.TotalAmount:F2}";
        lblCreatedAt.Text = $"下单时间：{order.CreatedAt:yyyy-MM-dd HH:mm:ss}";
        lblAddress.Text = order.OrderType == "Delivery"
            ? $"配送地址：{order.Address ?? "无"}"
            : $"桌号：{order.TableNumber ?? "无"}";

        dgvOrderItems.DataSource = order.OrderItems;
        SetOrderItemGridHeaders();
    }

    private void SetOrderItemGridHeaders()
    {
        dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        if (dgvOrderItems.Columns["DishName"] != null)
        {
            dgvOrderItems.Columns["DishName"].HeaderText = "菜品名称";
            dgvOrderItems.Columns["DishName"].FillWeight = 100;
        }

        if (dgvOrderItems.Columns["Price"] != null)
        {
            dgvOrderItems.Columns["Price"].HeaderText = "单价";
            dgvOrderItems.Columns["Price"].FillWeight = 60;
            dgvOrderItems.Columns["Price"].DefaultCellStyle.Format = "C2";
        }

        if (dgvOrderItems.Columns["Quantity"] != null)
        {
            dgvOrderItems.Columns["Quantity"].HeaderText = "数量";
            dgvOrderItems.Columns["Quantity"].FillWeight = 40;
        }

        foreach (var col in new[] { "Id", "DishId" })
        {
            if (dgvOrderItems.Columns[col] != null)
                dgvOrderItems.Columns[col].Visible = false;
        }
    }

    private void ClearDetail()
    {
        lblOrderId.Text = "订单编号：";
        lblOrderType.Text = "订单类型：";
        lblStatus.Text = "状态：";
        lblTotalAmount.Text = "总金额：";
        lblCreatedAt.Text = "下单时间：";
        lblAddress.Text = "配送地址：";
        dgvOrderItems.DataSource = null;
    }

    private static string GetStatusText(string status)
    {
        return status switch
        {
            "Pending" => "待处理",
            "Preparing" => "制作中",
            "Ready" => "已出餐",
            "Delivering" => "配送中",
            "Completed" => "已完成",
            "Cancelled" => "已取消",
            _ => status
        };
    }

    private void BtnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
