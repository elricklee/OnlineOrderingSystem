namespace ClientCustomer;

partial class OrderStatusForm
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
        DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
        mainLayout = new Sunny.UI.UITableLayoutPanel();
        queryPanel = new Sunny.UI.UIPanel();
        lblHint = new Sunny.UI.UILabel();
        txtOrderId = new Sunny.UI.UITextBox();
        btnQuery = new Sunny.UI.UIButton();
        grpOrderInfo = new Sunny.UI.UIGroupBox();
        lblOrderId = new Sunny.UI.UILabel();
        lblOrderType = new Sunny.UI.UILabel();
        lblTableNumber = new Sunny.UI.UILabel();
        lblAddress = new Sunny.UI.UILabel();
        lblNote = new Sunny.UI.UILabel();
        lblStatus = new Sunny.UI.UILabel();
        lblTotalAmount = new Sunny.UI.UILabel();
        lblDeliveryFee = new Sunny.UI.UILabel();
        lblCreatedAt = new Sunny.UI.UILabel();
        itemsPanel = new Sunny.UI.UIPanel();
        grpItems = new Sunny.UI.UIGroupBox();
        dgvOrderItems = new Sunny.UI.UIDataGridView();
        mainLayout.SuspendLayout();
        queryPanel.SuspendLayout();
        grpOrderInfo.SuspendLayout();
        itemsPanel.SuspendLayout();
        grpItems.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
        SuspendLayout();
        // 
        // mainLayout
        // 
        mainLayout.BackColor = Color.White;
        mainLayout.ColumnCount = 1;
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainLayout.Controls.Add(queryPanel, 0, 0);
        mainLayout.Controls.Add(grpOrderInfo, 0, 1);
        mainLayout.Controls.Add(itemsPanel, 0, 2);
        mainLayout.Dock = DockStyle.Fill;
        mainLayout.Location = new Point(0, 36);
        mainLayout.Name = "mainLayout";
        mainLayout.RowCount = 3;
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 230F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainLayout.Size = new Size(700, 514);
        mainLayout.TabIndex = 0;
        mainLayout.TagString = null;
        // 
        // queryPanel
        // 
        queryPanel.Controls.Add(lblHint);
        queryPanel.Controls.Add(txtOrderId);
        queryPanel.Controls.Add(btnQuery);
        queryPanel.Dock = DockStyle.Fill;
        queryPanel.FillColor = Color.FromArgb(250, 250, 250);
        queryPanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        queryPanel.Location = new Point(0, 0);
        queryPanel.Margin = new Padding(0);
        queryPanel.MinimumSize = new Size(1, 1);
        queryPanel.Name = "queryPanel";
        queryPanel.Size = new Size(700, 65);
        queryPanel.TabIndex = 0;
        queryPanel.Text = null;
        queryPanel.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // lblHint
        // 
        lblHint.FlatStyle = FlatStyle.System;
        lblHint.Font = new Font("微软雅黑", 11F);
        lblHint.ForeColor = Color.FromArgb(51, 51, 51);
        lblHint.Location = new Point(71, 18);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(119, 30);
        lblHint.TabIndex = 0;
        lblHint.Text = "订单编号：";
        lblHint.Click += lblHint_Click;
        // 
        // txtOrderId
        // 
        txtOrderId.Font = new Font("微软雅黑", 11F);
        txtOrderId.Location = new Point(195, 14);
        txtOrderId.Margin = new Padding(4, 5, 4, 5);
        txtOrderId.MinimumSize = new Size(1, 16);
        txtOrderId.Name = "txtOrderId";
        txtOrderId.Padding = new Padding(5);
        txtOrderId.ShowText = false;
        txtOrderId.Size = new Size(200, 36);
        txtOrderId.TabIndex = 1;
        txtOrderId.TextAlignment = ContentAlignment.MiddleLeft;
        txtOrderId.Watermark = "请输入订单编号";
        // 
        // btnQuery
        // 
        btnQuery.Cursor = Cursors.Hand;
        btnQuery.FillColor = Color.FromArgb(255, 109, 0);
        btnQuery.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnQuery.Location = new Point(410, 14);
        btnQuery.MinimumSize = new Size(1, 1);
        btnQuery.Name = "btnQuery";
        btnQuery.Radius = 6;
        btnQuery.RectColor = Color.FromArgb(255, 109, 0);
        btnQuery.Size = new Size(110, 36);
        btnQuery.TabIndex = 2;
        btnQuery.Text = "查询";
        btnQuery.Click += BtnQuery_Click;
        // 
        // grpOrderInfo
        // 
        grpOrderInfo.Controls.Add(lblOrderId);
        grpOrderInfo.Controls.Add(lblOrderType);
        grpOrderInfo.Controls.Add(lblTableNumber);
        grpOrderInfo.Controls.Add(lblAddress);
        grpOrderInfo.Controls.Add(lblNote);
        grpOrderInfo.Controls.Add(lblStatus);
        grpOrderInfo.Controls.Add(lblTotalAmount);
        grpOrderInfo.Controls.Add(lblDeliveryFee);
        grpOrderInfo.Controls.Add(lblCreatedAt);
        grpOrderInfo.Dock = DockStyle.Fill;
        grpOrderInfo.FillColor = Color.White;
        grpOrderInfo.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        grpOrderInfo.Location = new Point(10, 70);
        grpOrderInfo.Margin = new Padding(10, 5, 10, 5);
        grpOrderInfo.MinimumSize = new Size(1, 1);
        grpOrderInfo.Name = "grpOrderInfo";
        grpOrderInfo.Padding = new Padding(0, 32, 0, 0);
        grpOrderInfo.Size = new Size(680, 220);
        grpOrderInfo.TabIndex = 1;
        grpOrderInfo.Text = "订单信息";
        grpOrderInfo.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // lblOrderId
        // 
        lblOrderId.Font = new Font("微软雅黑", 10F);
        lblOrderId.ForeColor = Color.FromArgb(51, 51, 51);
        lblOrderId.Location = new Point(20, 35);
        lblOrderId.Name = "lblOrderId";
        lblOrderId.Size = new Size(300, 25);
        lblOrderId.TabIndex = 0;
        lblOrderId.Text = "订单编号：-";
        // 
        // lblOrderType
        // 
        lblOrderType.Font = new Font("微软雅黑", 10F);
        lblOrderType.ForeColor = Color.FromArgb(51, 51, 51);
        lblOrderType.Location = new Point(20, 65);
        lblOrderType.Name = "lblOrderType";
        lblOrderType.Size = new Size(300, 25);
        lblOrderType.TabIndex = 1;
        lblOrderType.Text = "订单类型：-";
        // 
        // lblTableNumber
        // 
        lblTableNumber.Font = new Font("微软雅黑", 10F);
        lblTableNumber.ForeColor = Color.FromArgb(51, 51, 51);
        lblTableNumber.Location = new Point(20, 95);
        lblTableNumber.Name = "lblTableNumber";
        lblTableNumber.Size = new Size(300, 25);
        lblTableNumber.TabIndex = 2;
        lblTableNumber.Text = "桌号：-";
        // 
        // lblAddress
        // 
        lblAddress.Font = new Font("微软雅黑", 10F);
        lblAddress.ForeColor = Color.FromArgb(51, 51, 51);
        lblAddress.Location = new Point(20, 125);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(300, 25);
        lblAddress.TabIndex = 3;
        lblAddress.Text = "配送地址：-";
        // 
        // lblNote
        // 
        lblNote.Font = new Font("微软雅黑", 10F);
        lblNote.ForeColor = Color.FromArgb(51, 51, 51);
        lblNote.Location = new Point(20, 155);
        lblNote.Name = "lblNote";
        lblNote.Size = new Size(300, 25);
        lblNote.TabIndex = 4;
        lblNote.Text = "备注：-";
        // 
        // lblStatus
        // 
        lblStatus.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
        lblStatus.ForeColor = Color.FromArgb(117, 117, 117);
        lblStatus.Location = new Point(350, 35);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(300, 30);
        lblStatus.TabIndex = 5;
        lblStatus.Text = "状态：-";
        // 
        // lblTotalAmount
        // 
        lblTotalAmount.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
        lblTotalAmount.ForeColor = Color.FromArgb(255, 109, 0);
        lblTotalAmount.Location = new Point(350, 65);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(300, 30);
        lblTotalAmount.TabIndex = 6;
        lblTotalAmount.Text = "总金额：-";
        // 
        // lblDeliveryFee
        // 
        lblDeliveryFee.Font = new Font("微软雅黑", 10F);
        lblDeliveryFee.ForeColor = Color.FromArgb(51, 51, 51);
        lblDeliveryFee.Location = new Point(350, 95);
        lblDeliveryFee.Name = "lblDeliveryFee";
        lblDeliveryFee.Size = new Size(300, 25);
        lblDeliveryFee.TabIndex = 7;
        lblDeliveryFee.Text = "配送费：-";
        // 
        // lblCreatedAt
        // 
        lblCreatedAt.Font = new Font("微软雅黑", 10F);
        lblCreatedAt.ForeColor = Color.FromArgb(51, 51, 51);
        lblCreatedAt.Location = new Point(350, 125);
        lblCreatedAt.Name = "lblCreatedAt";
        lblCreatedAt.Size = new Size(300, 25);
        lblCreatedAt.TabIndex = 8;
        lblCreatedAt.Text = "创建时间：-";
        // 
        // itemsPanel
        // 
        itemsPanel.Controls.Add(grpItems);
        itemsPanel.Dock = DockStyle.Fill;
        itemsPanel.FillColor = Color.White;
        itemsPanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        itemsPanel.Location = new Point(10, 295);
        itemsPanel.Margin = new Padding(10, 0, 10, 10);
        itemsPanel.MinimumSize = new Size(1, 1);
        itemsPanel.Name = "itemsPanel";
        itemsPanel.Size = new Size(680, 209);
        itemsPanel.TabIndex = 2;
        itemsPanel.Text = null;
        itemsPanel.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // grpItems
        // 
        grpItems.Controls.Add(dgvOrderItems);
        grpItems.Dock = DockStyle.Fill;
        grpItems.FillColor = Color.White;
        grpItems.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        grpItems.Location = new Point(0, 0);
        grpItems.Margin = new Padding(4, 5, 4, 5);
        grpItems.MinimumSize = new Size(1, 1);
        grpItems.Name = "grpItems";
        grpItems.Padding = new Padding(0, 32, 0, 0);
        grpItems.Size = new Size(680, 209);
        grpItems.TabIndex = 0;
        grpItems.Text = "订单明细";
        grpItems.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // dgvOrderItems
        // 
        dgvOrderItems.AllowUserToAddRows = false;
        dataGridViewCellStyle5.BackColor = Color.FromArgb(255, 248, 240);
        dgvOrderItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
        dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrderItems.BackgroundColor = Color.White;
        dgvOrderItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle6.BackColor = Color.FromArgb(255, 109, 0);
        dataGridViewCellStyle6.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        dataGridViewCellStyle6.ForeColor = Color.White;
        dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
        dgvOrderItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
        dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvOrderItems.Dock = DockStyle.Fill;
        dgvOrderItems.EnableHeadersVisualStyles = false;
        dgvOrderItems.Font = new Font("微软雅黑", 10F);
        dgvOrderItems.GridColor = Color.FromArgb(224, 224, 224);
        dgvOrderItems.Location = new Point(0, 32);
        dgvOrderItems.Name = "dgvOrderItems";
        dgvOrderItems.ReadOnly = true;
        dgvOrderItems.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle7.BackColor = Color.FromArgb(235, 243, 255);
        dataGridViewCellStyle7.Font = new Font("微软雅黑", 10F);
        dataGridViewCellStyle7.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle7.SelectionForeColor = Color.White;
        dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
        dgvOrderItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
        dgvOrderItems.RowHeadersVisible = false;
        dgvOrderItems.RowHeadersWidth = 62;
        dataGridViewCellStyle8.BackColor = Color.White;
        dataGridViewCellStyle8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvOrderItems.RowsDefaultCellStyle = dataGridViewCellStyle8;
        dgvOrderItems.SelectedIndex = -1;
        dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrderItems.Size = new Size(680, 177);
        dgvOrderItems.StripeOddColor = Color.FromArgb(255, 248, 240);
        dgvOrderItems.TabIndex = 0;
        // 
        // OrderStatusForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        ClientSize = new Size(700, 550);
        Controls.Add(mainLayout);
        Font = new Font("Microsoft YaHei UI", 10F);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "OrderStatusForm";
        Padding = new Padding(0, 36, 0, 0);
        StartPosition = FormStartPosition.CenterParent;
        Text = "订单状态查询";
        ZoomScaleRect = new Rectangle(22, 22, 700, 550);
        mainLayout.ResumeLayout(false);
        queryPanel.ResumeLayout(false);
        grpOrderInfo.ResumeLayout(false);
        itemsPanel.ResumeLayout(false);
        grpItems.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
        ResumeLayout(false);
    }

    private Sunny.UI.UITableLayoutPanel mainLayout;
    private Sunny.UI.UIPanel queryPanel;
    private Sunny.UI.UILabel lblHint;
    private Sunny.UI.UITextBox txtOrderId;
    private Sunny.UI.UIButton btnQuery;
    private Sunny.UI.UIGroupBox grpOrderInfo;
    private Sunny.UI.UILabel lblOrderId;
    private Sunny.UI.UILabel lblOrderType;
    private Sunny.UI.UILabel lblTableNumber;
    private Sunny.UI.UILabel lblAddress;
    private Sunny.UI.UILabel lblNote;
    private Sunny.UI.UILabel lblStatus;
    private Sunny.UI.UILabel lblTotalAmount;
    private Sunny.UI.UILabel lblDeliveryFee;
    private Sunny.UI.UILabel lblCreatedAt;
    private Sunny.UI.UIPanel itemsPanel;
    private Sunny.UI.UIGroupBox grpItems;
    private Sunny.UI.UIDataGridView dgvOrderItems;
}
