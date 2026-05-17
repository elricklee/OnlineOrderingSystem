using ClientCustomer.Models;

namespace ClientCustomer;

public partial class OrderHistoryForm : Form
{
    private readonly int _userId;
    private readonly System.Windows.Forms.Timer _statusRefreshTimer = new() { Interval = 15000 };
    private readonly Dictionary<int, string> _knownOrderStatuses = new();
    private List<OrderDto> _orders = new();
    private bool _isLoadingOrders;

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
        dgvOrders.CellFormatting += DgvOrders_CellFormatting;
        dgvOrders.CellToolTipTextNeeded += Grid_CellToolTipTextNeeded;
        dgvOrderItems.CellToolTipTextNeeded += Grid_CellToolTipTextNeeded;
        btnRefresh.Click += BtnRefresh_Click;
        btnClose.Click += BtnClose_Click;
        _statusRefreshTimer.Tick += StatusRefreshTimer_Tick;
        FormClosed += (_, _) => _statusRefreshTimer.Stop();
    }

    private async void OrderHistoryForm_Load(object? sender, EventArgs e)
    {
        await LoadOrdersAsync();
        _statusRefreshTimer.Start();
    }

    private async Task LoadOrdersAsync(bool notifyChanges = false)
    {
        if (_isLoadingOrders)
        {
            return;
        }

        _isLoadingOrders = true;

        try
        {
            var selectedOrderId = dgvOrders.CurrentRow?.DataBoundItem is OrderDto selectedOrder
                ? selectedOrder.Id
                : (int?)null;

            var newOrders = await ApiHelper.GetOrdersByUserIdAsync(_userId);
            NotifyStatusChanges(newOrders, notifyChanges);
            _orders = newOrders;

            dgvOrders.DataSource = _orders;
            SetGridHeaders();

            RestoreSelection(selectedOrderId);
            if (dgvOrders.CurrentRow?.DataBoundItem is OrderDto currentOrder)
            {
                ShowOrderDetail(currentOrder);
            }
            else
            {
                ClearDetail();
            }

            RememberStatuses();
        }
        catch (Exception ex)
        {
            MessageBox.Show("加载订单失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _isLoadingOrders = false;
        }
    }

    private void SetGridHeaders()
    {
        ApplyGridDensity(dgvOrders);
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        if (dgvOrders.Columns["OrderNo"] != null)
        {
            dgvOrders.Columns["OrderNo"].HeaderText = "订单编号";
            dgvOrders.Columns["OrderNo"].FillWeight = 130;
            dgvOrders.Columns["OrderNo"].MinimumWidth = 150;
        }

        if (dgvOrders.Columns["Id"] != null)
        {
            dgvOrders.Columns["Id"].Visible = false;
        }

        if (dgvOrders.Columns["OrderType"] != null)
        {
            dgvOrders.Columns["OrderType"].HeaderText = "类型";
            dgvOrders.Columns["OrderType"].FillWeight = 70;
            dgvOrders.Columns["OrderType"].MinimumWidth = 80;
        }

        if (dgvOrders.Columns["TableSessionNo"] != null)
        {
            dgvOrders.Columns["TableSessionNo"].HeaderText = "桌次";
            dgvOrders.Columns["TableSessionNo"].FillWeight = 120;
            dgvOrders.Columns["TableSessionNo"].MinimumWidth = 135;
        }

        if (dgvOrders.Columns["TotalAmount"] != null)
        {
            dgvOrders.Columns["TotalAmount"].HeaderText = "总金额";
            dgvOrders.Columns["TotalAmount"].FillWeight = 85;
            dgvOrders.Columns["TotalAmount"].MinimumWidth = 95;
            dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "¥0.00";
        }

        if (dgvOrders.Columns["Status"] != null)
        {
            dgvOrders.Columns["Status"].HeaderText = "状态";
            dgvOrders.Columns["Status"].FillWeight = 80;
            dgvOrders.Columns["Status"].MinimumWidth = 90;
        }

        if (dgvOrders.Columns["CreatedAt"] != null)
        {
            dgvOrders.Columns["CreatedAt"].HeaderText = "下单时间";
            dgvOrders.Columns["CreatedAt"].FillWeight = 105;
            dgvOrders.Columns["CreatedAt"].MinimumWidth = 125;
            dgvOrders.Columns["CreatedAt"].DefaultCellStyle.Format = "MM-dd HH:mm";
        }

        foreach (var col in new[] { "UserId", "CustomerName", "Phone", "Address", "TableNumber", "DiningTableId", "TableSessionId", "Note", "DeliveryFee", "DeliveryZoneId", "DeliveryRegion", "EstimatedMinutes", "OrderItems" })
        {
            if (dgvOrders.Columns[col] != null)
                dgvOrders.Columns[col].Visible = false;
        }
    }

    private void DgvOrders_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
        {
            return;
        }

        var columnName = dgvOrders.Columns[e.ColumnIndex].Name;
        if (columnName == "OrderType" && e.Value is string orderType)
        {
            e.Value = GetOrderTypeText(orderType);
            e.FormattingApplied = true;
        }

        if (columnName == "Status" && e.Value is string status)
        {
            e.Value = GetStatusText(status);
            e.FormattingApplied = true;
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
        lblOrderId.Text = $"订单编号：{(string.IsNullOrWhiteSpace(order.OrderNo) ? order.Id.ToString() : order.OrderNo)}";
        lblOrderType.Text = $"订单类型：{GetOrderTypeText(order.OrderType)}";
        lblStatus.Text = $"状态：{GetStatusText(order.Status)}";
        lblTotalAmount.Text = $"总金额：¥{order.TotalAmount:F2}";
        lblCreatedAt.Text = $"下单时间：{order.CreatedAt:yyyy-MM-dd HH:mm:ss}";
        var fullAddress = string.Join(" ", new[] { order.DeliveryRegion, order.Address }.Where(x => !string.IsNullOrWhiteSpace(x)));
        lblAddress.Text = order.OrderType == "Delivery"
            ? $"配送地址：{(string.IsNullOrWhiteSpace(fullAddress) ? "无" : fullAddress)}"
            : $"桌号 / 桌次：{order.TableNumber ?? "无"} / {order.TableSessionNo ?? "无"}";

        // 计算并显示预计完成时间
        var activeStatuses = new[] { "Pending", "Confirmed", "Preparing" };
        if (activeStatuses.Contains(order.Status) && order.EstimatedMinutes > 0)
        {
            var estimatedTime = order.CreatedAt.AddMinutes(order.EstimatedMinutes);
            lblEstimatedTime.Text = $"预计完成时间：{estimatedTime:yyyy-MM-dd HH:mm:ss}";
        }
        else
        {
            lblEstimatedTime.Text = "预计完成时间：--";
        }

        dgvOrderItems.DataSource = order.OrderItems;
        SetOrderItemGridHeaders();
    }

    private void SetOrderItemGridHeaders()
    {
        ApplyGridDensity(dgvOrderItems);
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

    private static void ApplyGridDensity(DataGridView dgv)
    {
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        dgv.ColumnHeadersHeight = 42;
        dgv.RowTemplate.Height = 40;
        dgv.RowTemplate.MinimumHeight = 40;
        dgv.DefaultCellStyle.Padding = new Padding(4, 6, 4, 6);
        dgv.DefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
        dgv.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        dgv.RowHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
    }

    private static void Grid_CellToolTipTextNeeded(object? sender, DataGridViewCellToolTipTextNeededEventArgs e)
    {
        if (sender is not DataGridView dgv || e.RowIndex < 0 || e.ColumnIndex < 0)
        {
            return;
        }

        var value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        e.ToolTipText = value?.ToString() ?? string.Empty;
    }

    private void ClearDetail()
    {
        lblOrderId.Text = "订单编号：";
        lblOrderType.Text = "订单类型：";
        lblStatus.Text = "状态：";
        lblTotalAmount.Text = "总金额：";
        lblCreatedAt.Text = "下单时间：";
        lblEstimatedTime.Text = "预计完成时间：";
        lblAddress.Text = "配送地址：";
        dgvOrderItems.DataSource = null;
    }

    private static string GetStatusText(string status)
    {
        return status switch
        {
            "Pending" => "待处理",
            "Confirmed" => "已接单",
            "Preparing" => "制作中",
            "Ready" => "已出餐",
            "Delivering" => "配送中",
            "Completed" => "已完成",
            "Cancelled" => "已取消",
            _ => "未知状态"
        };
    }

    private static string GetOrderTypeText(string orderType)
    {
        return orderType switch
        {
            "DineIn" => "堂食",
            "Delivery" => "外卖",
            _ => "未知类型"
        };
    }

    private async void BtnRefresh_Click(object? sender, EventArgs e)
    {
        btnRefresh.Enabled = false;
        btnRefresh.Text = "刷新中";

        try
        {
            await LoadOrdersAsync(true);
            lblNotice.Text = "订单列表已刷新";
            lblNotice.ForeColor = Color.FromArgb(46, 125, 50);
        }
        finally
        {
            btnRefresh.Enabled = true;
            btnRefresh.Text = "刷新";
        }
    }

    private async void StatusRefreshTimer_Tick(object? sender, EventArgs e)
    {
        await LoadOrdersAsync(true);
    }

    private void NotifyStatusChanges(List<OrderDto> newOrders, bool notifyChanges)
    {
        if (!notifyChanges || _knownOrderStatuses.Count == 0)
        {
            return;
        }

        var changedOrders = newOrders
            .Where(order => _knownOrderStatuses.TryGetValue(order.Id, out var oldStatus) && oldStatus != order.Status)
            .ToList();

        if (changedOrders.Count == 0)
        {
            return;
        }

        var latest = changedOrders.OrderByDescending(order => order.CreatedAt).First();
        lblNotice.Text = $"订单 {latest.Id} 状态已更新为：{GetStatusText(latest.Status)}";
        lblNotice.ForeColor = Color.FromArgb(255, 109, 0);
    }

    private void RememberStatuses()
    {
        _knownOrderStatuses.Clear();
        foreach (var order in _orders)
        {
            _knownOrderStatuses[order.Id] = order.Status;
        }
    }

    private void RestoreSelection(int? selectedOrderId)
    {
        if (_orders.Count == 0)
        {
            return;
        }

        var rowIndex = 0;
        if (selectedOrderId != null)
        {
            var index = _orders.FindIndex(order => order.Id == selectedOrderId.Value);
            if (index >= 0)
            {
                rowIndex = index;
            }
        }

        dgvOrders.ClearSelection();
        dgvOrders.Rows[rowIndex].Selected = true;
        var firstVisibleCell = dgvOrders.Rows[rowIndex].Cells
            .Cast<DataGridViewCell>()
            .FirstOrDefault(cell => cell.Visible);
        if (firstVisibleCell != null)
        {
            dgvOrders.CurrentCell = firstVisibleCell;
        }
    }

    private void BtnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
