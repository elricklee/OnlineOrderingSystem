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
        grpDetail = new Sunny.UI.UIGroupBox();
        lblOrderId = new Sunny.UI.UILabel();
        lblOrderType = new Sunny.UI.UILabel();
        lblStatus = new Sunny.UI.UILabel();
        lblTotalAmount = new Sunny.UI.UILabel();
        lblCreatedAt = new Sunny.UI.UILabel();
        lblAddress = new Sunny.UI.UILabel();
        dgvOrderItems = new Sunny.UI.UIDataGridView();
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
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrders.BackgroundColor = Color.White;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvOrders.Font = new Font("微软雅黑", 10F);
        dgvOrders.Location = new Point(12, 12);
        dgvOrders.MultiSelect = false;
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size = new Size(400, 420);
        dgvOrders.TabIndex = 0;
        //
        // grpDetail
        //
        grpDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grpDetail.Controls.Add(lblOrderId);
        grpDetail.Controls.Add(lblOrderType);
        grpDetail.Controls.Add(lblStatus);
        grpDetail.Controls.Add(lblTotalAmount);
        grpDetail.Controls.Add(lblCreatedAt);
        grpDetail.Controls.Add(lblAddress);
        grpDetail.Controls.Add(dgvOrderItems);
        grpDetail.Font = new Font("微软雅黑", 10F);
        grpDetail.Location = new Point(420, 12);
        grpDetail.Name = "grpDetail";
        grpDetail.Padding = new Padding(0, 28, 0, 0);
        grpDetail.Size = new Size(460, 420);
        grpDetail.TabIndex = 1;
        grpDetail.Text = "订单详情";
        //
        // lblOrderId
        //
        lblOrderId.Font = new Font("微软雅黑", 10F);
        lblOrderId.ForeColor = Color.FromArgb(51, 51, 51);
        lblOrderId.Location = new Point(15, 35);
        lblOrderId.Name = "lblOrderId";
        lblOrderId.Size = new Size(200, 26);
        lblOrderId.TabIndex = 0;
        lblOrderId.Text = "订单编号：";
        //
        // lblOrderType
        //
        lblOrderType.Font = new Font("微软雅黑", 10F);
        lblOrderType.ForeColor = Color.FromArgb(51, 51, 51);
        lblOrderType.Location = new Point(230, 35);
        lblOrderType.Name = "lblOrderType";
        lblOrderType.Size = new Size(200, 26);
        lblOrderType.TabIndex = 1;
        lblOrderType.Text = "订单类型：";
        //
        // lblStatus
        //
        lblStatus.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        lblStatus.ForeColor = Color.FromArgb(255, 109, 0);
        lblStatus.Location = new Point(15, 65);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(200, 26);
        lblStatus.TabIndex = 2;
        lblStatus.Text = "状态：";
        //
        // lblTotalAmount
        //
        lblTotalAmount.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        lblTotalAmount.ForeColor = Color.FromArgb(244, 67, 54);
        lblTotalAmount.Location = new Point(230, 65);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(200, 26);
        lblTotalAmount.TabIndex = 3;
        lblTotalAmount.Text = "总金额：";
        //
        // lblCreatedAt
        //
        lblCreatedAt.Font = new Font("微软雅黑", 10F);
        lblCreatedAt.ForeColor = Color.FromArgb(51, 51, 51);
        lblCreatedAt.Location = new Point(15, 95);
        lblCreatedAt.Name = "lblCreatedAt";
        lblCreatedAt.Size = new Size(415, 26);
        lblCreatedAt.TabIndex = 4;
        lblCreatedAt.Text = "下单时间：";
        //
        // lblAddress
        //
        lblAddress.Font = new Font("微软雅黑", 10F);
        lblAddress.ForeColor = Color.FromArgb(51, 51, 51);
        lblAddress.Location = new Point(15, 125);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(415, 26);
        lblAddress.TabIndex = 5;
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
        dgvOrderItems.Location = new Point(15, 160);
        dgvOrderItems.MultiSelect = false;
        dgvOrderItems.Name = "dgvOrderItems";
        dgvOrderItems.ReadOnly = true;
        dgvOrderItems.RowHeadersVisible = false;
        dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrderItems.Size = new Size(430, 245);
        dgvOrderItems.TabIndex = 6;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnClose.Cursor = Cursors.Hand;
        btnClose.FillColor = Color.FromArgb(117, 117, 117);
        btnClose.Font = new Font("微软雅黑", 10F);
        btnClose.ForeColor = Color.White;
        btnClose.Location = new Point(780, 440);
        btnClose.MinimumSize = new Size(1, 1);
        btnClose.Name = "btnClose";
        btnClose.Radius = 8;
        btnClose.RectColor = Color.FromArgb(117, 117, 117);
        btnClose.Size = new Size(100, 36);
        btnClose.TabIndex = 2;
        btnClose.Text = "关闭";
        //
        // OrderHistoryForm
        //
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        ClientSize = new Size(900, 490);
        Controls.Add(btnClose);
        Controls.Add(grpDetail);
        Controls.Add(dgvOrders);
        Font = new Font("微软雅黑", 10F);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "OrderHistoryForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "我的订单";
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        grpDetail.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
        ResumeLayout(false);
    }

    private Sunny.UI.UIDataGridView dgvOrders;
    private Sunny.UI.UIGroupBox grpDetail;
    private Sunny.UI.UILabel lblOrderId;
    private Sunny.UI.UILabel lblOrderType;
    private Sunny.UI.UILabel lblStatus;
    private Sunny.UI.UILabel lblTotalAmount;
    private Sunny.UI.UILabel lblCreatedAt;
    private Sunny.UI.UILabel lblAddress;
    private Sunny.UI.UIDataGridView dgvOrderItems;
    private Sunny.UI.UIButton btnClose;
}
