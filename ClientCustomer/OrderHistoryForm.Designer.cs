namespace ClientCustomer;

partial class OrderHistoryForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dgvOrders = new Sunny.UI.UIDataGridView();
        lblNotice = new Sunny.UI.UILabel();
        grpDetail = new Sunny.UI.UIGroupBox();
        lblOrderId = new Sunny.UI.UILabel();
        lblOrderType = new Sunny.UI.UILabel();
        lblStatus = new Sunny.UI.UILabel();
        lblTotalAmount = new Sunny.UI.UILabel();
        lblCreatedAt = new Sunny.UI.UILabel();
        lblEstimatedTime = new Sunny.UI.UILabel();
        lblAddress = new Sunny.UI.UILabel();
        dgvOrderItems = new Sunny.UI.UIDataGridView();
        btnRefresh = new Sunny.UI.UIButton();
        btnClose = new Sunny.UI.UIButton();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        grpDetail.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
        SuspendLayout();
        //
        // dgvOrders
        //
        dgvOrders.AllowUserToAddRows = false;
        dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvOrders.BackgroundColor = Color.White;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvOrders.Font = new Font("微软雅黑", 9.5F);
        dgvOrders.Location = new Point(12, 50);
        dgvOrders.MultiSelect = false;
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.RowTemplate.Height = 32;
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size = new Size(560, 560);
        dgvOrders.TabIndex = 0;
        //
        // lblNotice
        //
        lblNotice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblNotice.BackColor = Color.FromArgb(232, 245, 233);
        lblNotice.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        lblNotice.ForeColor = Color.FromArgb(46, 125, 50);
        lblNotice.Location = new Point(12, 12);
        lblNotice.Name = "lblNotice";
        lblNotice.Size = new Size(1050, 30);
        lblNotice.TabIndex = 3;
        lblNotice.Text = "订单状态会自动刷新；如需立即查看，请点击右下角刷新";
        lblNotice.TextAlign = ContentAlignment.MiddleLeft;
        //
        // grpDetail
        //
        grpDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grpDetail.Controls.Add(lblOrderId);
        grpDetail.Controls.Add(lblOrderType);
        grpDetail.Controls.Add(lblStatus);
        grpDetail.Controls.Add(lblTotalAmount);
        grpDetail.Controls.Add(lblCreatedAt);
        grpDetail.Controls.Add(lblEstimatedTime);
        grpDetail.Controls.Add(lblAddress);
        grpDetail.Controls.Add(dgvOrderItems);
        grpDetail.Font = new Font("微软雅黑", 10F);
        grpDetail.Location = new Point(582, 50);
        grpDetail.Name = "grpDetail";
        grpDetail.Padding = new Padding(0, 28, 0, 0);
        grpDetail.Size = new Size(600, 560);
        grpDetail.TabIndex = 1;
        grpDetail.Text = "订单详情";
        //
        // lblOrderId
        //
        lblOrderId.Font = new Font("微软雅黑", 10F);
        lblOrderId.ForeColor = Color.FromArgb(51, 51, 51);
        lblOrderId.Location = new Point(15, 35);
        lblOrderId.Name = "lblOrderId";
        lblOrderId.Size = new Size(240, 26);
        lblOrderId.TabIndex = 0;
        lblOrderId.Text = "订单编号：";
        //
        // lblOrderType
        //
        lblOrderType.Font = new Font("微软雅黑", 10F);
        lblOrderType.ForeColor = Color.FromArgb(51, 51, 51);
        lblOrderType.Location = new Point(280, 35);
        lblOrderType.Name = "lblOrderType";
        lblOrderType.Size = new Size(240, 26);
        lblOrderType.TabIndex = 1;
        lblOrderType.Text = "订单类型：";
        //
        // lblStatus
        //
        lblStatus.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        lblStatus.ForeColor = Color.FromArgb(255, 109, 0);
        lblStatus.Location = new Point(15, 65);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(240, 26);
        lblStatus.TabIndex = 2;
        lblStatus.Text = "状态：";
        //
        // lblTotalAmount
        //
        lblTotalAmount.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        lblTotalAmount.ForeColor = Color.FromArgb(244, 67, 54);
        lblTotalAmount.Location = new Point(280, 65);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(240, 26);
        lblTotalAmount.TabIndex = 3;
        lblTotalAmount.Text = "总金额：";
        //
        // lblCreatedAt
        //
        lblCreatedAt.Font = new Font("微软雅黑", 10F);
        lblCreatedAt.ForeColor = Color.FromArgb(51, 51, 51);
        lblCreatedAt.Location = new Point(15, 95);
        lblCreatedAt.Name = "lblCreatedAt";
        lblCreatedAt.Size = new Size(560, 26);
        lblCreatedAt.TabIndex = 4;
        lblCreatedAt.Text = "下单时间：";
        //
        // lblEstimatedTime
        //
        lblEstimatedTime.Font = new Font("微软雅黑", 10F);
        lblEstimatedTime.ForeColor = Color.FromArgb(46, 125, 50);
        lblEstimatedTime.Location = new Point(15, 125);
        lblEstimatedTime.Name = "lblEstimatedTime";
        lblEstimatedTime.Size = new Size(560, 26);
        lblEstimatedTime.TabIndex = 5;
        lblEstimatedTime.Text = "预计完成时间：";
        //
        // lblAddress
        //
        lblAddress.Font = new Font("微软雅黑", 10F);
        lblAddress.ForeColor = Color.FromArgb(51, 51, 51);
        lblAddress.Location = new Point(15, 155);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(560, 26);
        lblAddress.TabIndex = 6;
        lblAddress.Text = "配送地址：";
        //
        // dgvOrderItems
        //
        dgvOrderItems.AllowUserToAddRows = false;
        dgvOrderItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrderItems.BackgroundColor = Color.White;
        dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvOrderItems.Font = new Font("微软雅黑", 10F);
        dgvOrderItems.Location = new Point(15, 190);
        dgvOrderItems.MultiSelect = false;
        dgvOrderItems.Name = "dgvOrderItems";
        dgvOrderItems.ReadOnly = true;
        dgvOrderItems.RowHeadersVisible = false;
        dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrderItems.Size = new Size(570, 355);
        dgvOrderItems.TabIndex = 6;
        //
        // btnRefresh
        //
        btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnRefresh.Cursor = Cursors.Hand;
        btnRefresh.FillColor = Color.FromArgb(255, 109, 0);
        btnRefresh.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnRefresh.ForeColor = Color.White;
        btnRefresh.Location = new Point(962, 622);
        btnRefresh.MinimumSize = new Size(1, 1);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Radius = 8;
        btnRefresh.RectColor = Color.FromArgb(255, 109, 0);
        btnRefresh.Size = new Size(100, 36);
        btnRefresh.TabIndex = 2;
        btnRefresh.Text = "刷新";
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnClose.Cursor = Cursors.Hand;
        btnClose.FillColor = Color.FromArgb(117, 117, 117);
        btnClose.Font = new Font("微软雅黑", 10F);
        btnClose.ForeColor = Color.White;
        btnClose.Location = new Point(1082, 622);
        btnClose.MinimumSize = new Size(1, 1);
        btnClose.Name = "btnClose";
        btnClose.Radius = 8;
        btnClose.RectColor = Color.FromArgb(117, 117, 117);
        btnClose.Size = new Size(100, 36);
        btnClose.TabIndex = 4;
        btnClose.Text = "关闭";
        //
        // OrderHistoryForm
        //
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        ClientSize = new Size(1200, 670);
        Controls.Add(btnClose);
        Controls.Add(btnRefresh);
        Controls.Add(lblNotice);
        Controls.Add(grpDetail);
        Controls.Add(dgvOrders);
        Font = new Font("微软雅黑", 10F);
        MaximizeBox = true;
        MinimizeBox = false;
        MinimumSize = new Size(1180, 670);
        Name = "OrderHistoryForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "我的订单";
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        grpDetail.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
        ResumeLayout(false);
    }

    private Sunny.UI.UIDataGridView dgvOrders;
    private Sunny.UI.UILabel lblNotice;
    private Sunny.UI.UIGroupBox grpDetail;
    private Sunny.UI.UILabel lblOrderId;
    private Sunny.UI.UILabel lblOrderType;
    private Sunny.UI.UILabel lblStatus;
    private Sunny.UI.UILabel lblTotalAmount;
    private Sunny.UI.UILabel lblCreatedAt;
    private Sunny.UI.UILabel lblEstimatedTime;
    private Sunny.UI.UILabel lblAddress;
    private Sunny.UI.UIDataGridView dgvOrderItems;
    private Sunny.UI.UIButton btnRefresh;
    private Sunny.UI.UIButton btnClose;
}
