namespace ClientCustomer;

partial class CartForm
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        mainLayout = new Sunny.UI.UITableLayoutPanel();
        dgvCart = new Sunny.UI.UIDataGridView();
        notePanel = new Sunny.UI.UIPanel();
        lblCurrentTable = new Sunny.UI.UILabel();
        lblNote = new Sunny.UI.UILabel();
        txtNote = new Sunny.UI.UITextBox();
        lblDeliveryRegion = new Sunny.UI.UILabel();
        cmbDeliveryProvince = new Sunny.UI.UIComboBox();
        cmbDeliveryCity = new Sunny.UI.UIComboBox();
        cmbDeliveryDistrict = new Sunny.UI.UIComboBox();
        lblAddressDetailEditor = new Sunny.UI.UILabel();
        txtAddressDetail = new Sunny.UI.UITextBox();
        lblCustomerPhoneEditor = new Sunny.UI.UILabel();
        txtCustomerPhone = new Sunny.UI.UITextBox();
        totalPanel = new Sunny.UI.UIPanel();
        lblSubtitleLabel = new Sunny.UI.UILabel();
        lblSubtotal = new Sunny.UI.UILabel();
        lblDeliveryFeeLabel = new Sunny.UI.UILabel();
        lblDeliveryFee = new Sunny.UI.UILabel();
        lblTotalLabel = new Sunny.UI.UILabel();
        lblTotal = new Sunny.UI.UILabel();
        buttonPanel = new Sunny.UI.UIPanel();
        btnDecreaseQuantity = new Sunny.UI.UIButton();
        btnIncreaseQuantity = new Sunny.UI.UIButton();
        btnRemoveCartItem = new Sunny.UI.UIButton();
        btnClearCart = new Sunny.UI.UIButton();
        btnSubmitOrder = new Sunny.UI.UIButton();
        mainLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
        notePanel.SuspendLayout();
        totalPanel.SuspendLayout();
        buttonPanel.SuspendLayout();
        SuspendLayout();
        //
        // mainLayout
        //
        mainLayout.BackColor = Color.White;
        mainLayout.ColumnCount = 1;
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainLayout.Controls.Add(dgvCart, 0, 0);
        mainLayout.Controls.Add(notePanel, 0, 1);
        mainLayout.Controls.Add(totalPanel, 0, 2);
        mainLayout.Controls.Add(buttonPanel, 0, 3);
        mainLayout.Dock = DockStyle.Fill;
        mainLayout.Location = new Point(0, 36);
        mainLayout.Name = "mainLayout";
        mainLayout.RowCount = 4;
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
        mainLayout.Size = new Size(860, 650);
        mainLayout.TabIndex = 0;
        mainLayout.TagString = null;
        //
        // dgvCart
        //
        dgvCart.AllowUserToAddRows = false;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 248, 240);
        dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCart.BackgroundColor = Color.White;
        dgvCart.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 109, 0);
        dataGridViewCellStyle2.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
        dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCart.Dock = DockStyle.Fill;
        dgvCart.EnableHeadersVisualStyles = false;
        dgvCart.Font = new Font("微软雅黑", 10F);
        dgvCart.GridColor = Color.FromArgb(224, 224, 224);
        dgvCart.Location = new Point(10, 10);
        dgvCart.Margin = new Padding(10);
        dgvCart.MultiSelect = false;
        dgvCart.Name = "dgvCart";
        dgvCart.ReadOnly = true;
        dgvCart.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = Color.FromArgb(235, 243, 255);
        dataGridViewCellStyle3.Font = new Font("微软雅黑", 10F);
        dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle3.SelectionForeColor = Color.White;
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
        dgvCart.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
        dgvCart.RowHeadersVisible = false;
        dgvCart.RowHeadersWidth = 62;
        dataGridViewCellStyle4.BackColor = Color.White;
        dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvCart.RowsDefaultCellStyle = dataGridViewCellStyle4;
        dgvCart.SelectedIndex = -1;
        dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCart.Size = new Size(840, 299);
        dgvCart.StripeOddColor = Color.FromArgb(255, 248, 240);
        dgvCart.TabIndex = 0;
        //
        // notePanel
        //
        notePanel.Controls.Add(lblCurrentTable);
        notePanel.Controls.Add(lblNote);
        notePanel.Controls.Add(txtNote);
        notePanel.Controls.Add(lblDeliveryRegion);
        notePanel.Controls.Add(cmbDeliveryProvince);
        notePanel.Controls.Add(cmbDeliveryCity);
        notePanel.Controls.Add(cmbDeliveryDistrict);
        notePanel.Controls.Add(lblAddressDetailEditor);
        notePanel.Controls.Add(txtAddressDetail);
        notePanel.Controls.Add(lblCustomerPhoneEditor);
        notePanel.Controls.Add(txtCustomerPhone);
        notePanel.Dock = DockStyle.Fill;
        notePanel.FillColor = Color.FromArgb(250, 250, 250);
        notePanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        notePanel.Location = new Point(0, 319);
        notePanel.Margin = new Padding(0);
        notePanel.MinimumSize = new Size(1, 1);
        notePanel.Name = "notePanel";
        notePanel.Size = new Size(860, 160);
        notePanel.TabIndex = 1;
        notePanel.Text = null;
        notePanel.TextAlignment = ContentAlignment.MiddleCenter;
        //
        // lblCurrentTable
        //
        lblCurrentTable.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        lblCurrentTable.ForeColor = Color.FromArgb(51, 51, 51);
        lblCurrentTable.Location = new Point(15, 8);
        lblCurrentTable.Name = "lblCurrentTable";
        lblCurrentTable.Size = new Size(280, 28);
        lblCurrentTable.TabIndex = 0;
        lblCurrentTable.Text = "当前桌号：";
        //
        // lblNote
        //
        lblNote.FlatStyle = FlatStyle.System;
        lblNote.Font = new Font("微软雅黑", 10F);
        lblNote.ForeColor = Color.FromArgb(51, 51, 51);
        lblNote.Location = new Point(15, 42);
        lblNote.Name = "lblNote";
        lblNote.Size = new Size(80, 28);
        lblNote.TabIndex = 1;
        lblNote.Text = "备注：";
        //
        // txtNote
        //
        txtNote.Font = new Font("微软雅黑", 10F);
        txtNote.Location = new Point(100, 38);
        txtNote.Margin = new Padding(4, 5, 4, 5);
        txtNote.MinimumSize = new Size(1, 16);
        txtNote.Name = "txtNote";
        txtNote.Padding = new Padding(5);
        txtNote.ShowText = false;
        txtNote.Size = new Size(740, 32);
        txtNote.TabIndex = 2;
        txtNote.TextAlignment = ContentAlignment.MiddleLeft;
        txtNote.Watermark = "请输入备注信息（选填）";
        //
        // lblDeliveryRegion
        //
        lblDeliveryRegion.Font = new Font("微软雅黑", 10F);
        lblDeliveryRegion.ForeColor = Color.FromArgb(51, 51, 51);
        lblDeliveryRegion.Location = new Point(15, 78);
        lblDeliveryRegion.Name = "lblDeliveryRegion";
        lblDeliveryRegion.Size = new Size(90, 28);
        lblDeliveryRegion.TabIndex = 3;
        lblDeliveryRegion.Text = "配送区域 *：";
        //
        // cmbDeliveryProvince
        //
        cmbDeliveryProvince.DataSource = null;
        cmbDeliveryProvince.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
        cmbDeliveryProvince.FillColor = Color.White;
        cmbDeliveryProvince.Font = new Font("微软雅黑", 10F);
        cmbDeliveryProvince.ItemHoverColor = Color.FromArgb(235, 243, 255);
        cmbDeliveryProvince.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
        cmbDeliveryProvince.Location = new Point(100, 74);
        cmbDeliveryProvince.Margin = new Padding(4, 5, 4, 5);
        cmbDeliveryProvince.MinimumSize = new Size(63, 0);
        cmbDeliveryProvince.Name = "cmbDeliveryProvince";
        cmbDeliveryProvince.Padding = new Padding(0, 0, 30, 2);
        cmbDeliveryProvince.Size = new Size(120, 32);
        cmbDeliveryProvince.SymbolSize = 24;
        cmbDeliveryProvince.TabIndex = 4;
        cmbDeliveryProvince.TextAlignment = ContentAlignment.MiddleLeft;
        cmbDeliveryProvince.Watermark = "";
        //
        // cmbDeliveryCity
        //
        cmbDeliveryCity.DataSource = null;
        cmbDeliveryCity.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
        cmbDeliveryCity.FillColor = Color.White;
        cmbDeliveryCity.Font = new Font("微软雅黑", 10F);
        cmbDeliveryCity.ItemHoverColor = Color.FromArgb(235, 243, 255);
        cmbDeliveryCity.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
        cmbDeliveryCity.Location = new Point(228, 74);
        cmbDeliveryCity.Margin = new Padding(4, 5, 4, 5);
        cmbDeliveryCity.MinimumSize = new Size(63, 0);
        cmbDeliveryCity.Name = "cmbDeliveryCity";
        cmbDeliveryCity.Padding = new Padding(0, 0, 30, 2);
        cmbDeliveryCity.Size = new Size(120, 32);
        cmbDeliveryCity.SymbolSize = 24;
        cmbDeliveryCity.TabIndex = 5;
        cmbDeliveryCity.TextAlignment = ContentAlignment.MiddleLeft;
        cmbDeliveryCity.Watermark = "";
        //
        // cmbDeliveryDistrict
        //
        cmbDeliveryDistrict.DataSource = null;
        cmbDeliveryDistrict.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
        cmbDeliveryDistrict.FillColor = Color.White;
        cmbDeliveryDistrict.Font = new Font("微软雅黑", 10F);
        cmbDeliveryDistrict.ItemHoverColor = Color.FromArgb(235, 243, 255);
        cmbDeliveryDistrict.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
        cmbDeliveryDistrict.Location = new Point(356, 74);
        cmbDeliveryDistrict.Margin = new Padding(4, 5, 4, 5);
        cmbDeliveryDistrict.MinimumSize = new Size(63, 0);
        cmbDeliveryDistrict.Name = "cmbDeliveryDistrict";
        cmbDeliveryDistrict.Padding = new Padding(0, 0, 30, 2);
        cmbDeliveryDistrict.Size = new Size(150, 32);
        cmbDeliveryDistrict.SymbolSize = 24;
        cmbDeliveryDistrict.TabIndex = 6;
        cmbDeliveryDistrict.TextAlignment = ContentAlignment.MiddleLeft;
        cmbDeliveryDistrict.Watermark = "";
        //
        // lblAddressDetailEditor
        //
        lblAddressDetailEditor.Font = new Font("微软雅黑", 10F);
        lblAddressDetailEditor.ForeColor = Color.FromArgb(51, 51, 51);
        lblAddressDetailEditor.Location = new Point(15, 112);
        lblAddressDetailEditor.Name = "lblAddressDetailEditor";
        lblAddressDetailEditor.Size = new Size(90, 28);
        lblAddressDetailEditor.TabIndex = 7;
        lblAddressDetailEditor.Text = "详细地址 *：";
        //
        // txtAddressDetail
        //
        txtAddressDetail.Font = new Font("微软雅黑", 10F);
        txtAddressDetail.Location = new Point(110, 108);
        txtAddressDetail.Margin = new Padding(4, 5, 4, 5);
        txtAddressDetail.MinimumSize = new Size(1, 16);
        txtAddressDetail.Name = "txtAddressDetail";
        txtAddressDetail.Padding = new Padding(5);
        txtAddressDetail.ShowText = false;
        txtAddressDetail.Size = new Size(395, 32);
        txtAddressDetail.TabIndex = 8;
        txtAddressDetail.TextAlignment = ContentAlignment.MiddleLeft;
        txtAddressDetail.Watermark = "请填写门牌号、楼栋、房间号等详细地址";
        //
        // lblCustomerPhoneEditor
        //
        lblCustomerPhoneEditor.Font = new Font("微软雅黑", 10F);
        lblCustomerPhoneEditor.ForeColor = Color.FromArgb(51, 51, 51);
        lblCustomerPhoneEditor.Location = new Point(525, 112);
        lblCustomerPhoneEditor.Name = "lblCustomerPhoneEditor";
        lblCustomerPhoneEditor.Size = new Size(80, 28);
        lblCustomerPhoneEditor.TabIndex = 9;
        lblCustomerPhoneEditor.Text = "手机号 *：";
        //
        // txtCustomerPhone
        //
        txtCustomerPhone.Font = new Font("微软雅黑", 10F);
        txtCustomerPhone.Location = new Point(610, 108);
        txtCustomerPhone.Margin = new Padding(4, 5, 4, 5);
        txtCustomerPhone.MinimumSize = new Size(1, 16);
        txtCustomerPhone.Name = "txtCustomerPhone";
        txtCustomerPhone.Padding = new Padding(5);
        txtCustomerPhone.ShowText = false;
        txtCustomerPhone.Size = new Size(230, 32);
        txtCustomerPhone.TabIndex = 10;
        txtCustomerPhone.TextAlignment = ContentAlignment.MiddleLeft;
        txtCustomerPhone.Watermark = "必填，11位手机号";
        //
        // totalPanel
        //
        totalPanel.Controls.Add(lblSubtitleLabel);
        totalPanel.Controls.Add(lblSubtotal);
        totalPanel.Controls.Add(lblDeliveryFeeLabel);
        totalPanel.Controls.Add(lblDeliveryFee);
        totalPanel.Controls.Add(lblTotalLabel);
        totalPanel.Controls.Add(lblTotal);
        totalPanel.Dock = DockStyle.Fill;
        totalPanel.FillColor = Color.FromArgb(255, 243, 224);
        totalPanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        totalPanel.Location = new Point(0, 479);
        totalPanel.Margin = new Padding(0);
        totalPanel.MinimumSize = new Size(1, 1);
        totalPanel.Name = "totalPanel";
        totalPanel.Size = new Size(860, 110);
        totalPanel.TabIndex = 2;
        totalPanel.Text = null;
        totalPanel.TextAlignment = ContentAlignment.MiddleCenter;
        //
        // lblSubtitleLabel
        //
        lblSubtitleLabel.FlatStyle = FlatStyle.System;
        lblSubtitleLabel.Font = new Font("微软雅黑", 11F);
        lblSubtitleLabel.ForeColor = Color.FromArgb(51, 51, 51);
        lblSubtitleLabel.Location = new Point(450, 10);
        lblSubtitleLabel.Name = "lblSubtitleLabel";
        lblSubtitleLabel.Size = new Size(110, 28);
        lblSubtitleLabel.TabIndex = 0;
        lblSubtitleLabel.Text = "商品合计：";
        //
        // lblSubtotal
        //
        lblSubtotal.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        lblSubtotal.ForeColor = Color.FromArgb(255, 109, 0);
        lblSubtotal.Location = new Point(560, 10);
        lblSubtotal.Name = "lblSubtotal";
        lblSubtotal.Size = new Size(120, 28);
        lblSubtotal.TabIndex = 1;
        lblSubtotal.Text = "¥0";
        //
        // lblDeliveryFeeLabel
        //
        lblDeliveryFeeLabel.Font = new Font("微软雅黑", 11F);
        lblDeliveryFeeLabel.ForeColor = Color.FromArgb(51, 51, 51);
        lblDeliveryFeeLabel.Location = new Point(450, 42);
        lblDeliveryFeeLabel.Name = "lblDeliveryFeeLabel";
        lblDeliveryFeeLabel.Size = new Size(110, 28);
        lblDeliveryFeeLabel.TabIndex = 2;
        lblDeliveryFeeLabel.Text = "配送费：";
        lblDeliveryFeeLabel.Visible = false;
        //
        // lblDeliveryFee
        //
        lblDeliveryFee.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        lblDeliveryFee.ForeColor = Color.FromArgb(255, 109, 0);
        lblDeliveryFee.Location = new Point(560, 42);
        lblDeliveryFee.Name = "lblDeliveryFee";
        lblDeliveryFee.Size = new Size(120, 28);
        lblDeliveryFee.TabIndex = 3;
        lblDeliveryFee.Text = "¥5";
        lblDeliveryFee.Visible = false;
        //
        // lblTotalLabel
        //
        lblTotalLabel.FlatStyle = FlatStyle.System;
        lblTotalLabel.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
        lblTotalLabel.ForeColor = Color.FromArgb(51, 51, 51);
        lblTotalLabel.Location = new Point(450, 74);
        lblTotalLabel.Name = "lblTotalLabel";
        lblTotalLabel.Size = new Size(130, 32);
        lblTotalLabel.TabIndex = 4;
        lblTotalLabel.Text = "应付总额：";
        //
        // lblTotal
        //
        lblTotal.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(244, 67, 54);
        lblTotal.Location = new Point(580, 74);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(150, 32);
        lblTotal.TabIndex = 5;
        lblTotal.Text = "¥0";
        //
        // buttonPanel
        //
        buttonPanel.Controls.Add(btnDecreaseQuantity);
        buttonPanel.Controls.Add(btnIncreaseQuantity);
        buttonPanel.Controls.Add(btnRemoveCartItem);
        buttonPanel.Controls.Add(btnClearCart);
        buttonPanel.Controls.Add(btnSubmitOrder);
        buttonPanel.Dock = DockStyle.Fill;
        buttonPanel.FillColor = Color.White;
        buttonPanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        buttonPanel.Location = new Point(0, 589);
        buttonPanel.Margin = new Padding(0);
        buttonPanel.MinimumSize = new Size(1, 1);
        buttonPanel.Name = "buttonPanel";
        buttonPanel.Size = new Size(860, 55);
        buttonPanel.TabIndex = 3;
        buttonPanel.Text = null;
        buttonPanel.TextAlignment = ContentAlignment.MiddleCenter;
        //
        // btnDecreaseQuantity
        //
        btnDecreaseQuantity.Cursor = Cursors.Hand;
        btnDecreaseQuantity.FillColor = Color.FromArgb(117, 117, 117);
        btnDecreaseQuantity.Font = new Font("微软雅黑", 9.5F, FontStyle.Bold);
        btnDecreaseQuantity.Location = new Point(15, 8);
        btnDecreaseQuantity.MinimumSize = new Size(1, 1);
        btnDecreaseQuantity.Name = "btnDecreaseQuantity";
        btnDecreaseQuantity.Radius = 8;
        btnDecreaseQuantity.RectColor = Color.FromArgb(117, 117, 117);
        btnDecreaseQuantity.Size = new Size(100, 38);
        btnDecreaseQuantity.TabIndex = 2;
        btnDecreaseQuantity.Text = "数量 -";
        btnDecreaseQuantity.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        //
        // btnIncreaseQuantity
        //
        btnIncreaseQuantity.Cursor = Cursors.Hand;
        btnIncreaseQuantity.FillColor = Color.FromArgb(46, 125, 50);
        btnIncreaseQuantity.Font = new Font("微软雅黑", 9.5F, FontStyle.Bold);
        btnIncreaseQuantity.Location = new Point(123, 8);
        btnIncreaseQuantity.MinimumSize = new Size(1, 1);
        btnIncreaseQuantity.Name = "btnIncreaseQuantity";
        btnIncreaseQuantity.Radius = 8;
        btnIncreaseQuantity.RectColor = Color.FromArgb(46, 125, 50);
        btnIncreaseQuantity.Size = new Size(100, 38);
        btnIncreaseQuantity.TabIndex = 3;
        btnIncreaseQuantity.Text = "数量 +";
        btnIncreaseQuantity.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        //
        // btnRemoveCartItem
        //
        btnRemoveCartItem.Cursor = Cursors.Hand;
        btnRemoveCartItem.FillColor = Color.FromArgb(211, 47, 47);
        btnRemoveCartItem.Font = new Font("微软雅黑", 9.5F, FontStyle.Bold);
        btnRemoveCartItem.Location = new Point(231, 8);
        btnRemoveCartItem.MinimumSize = new Size(1, 1);
        btnRemoveCartItem.Name = "btnRemoveCartItem";
        btnRemoveCartItem.Radius = 8;
        btnRemoveCartItem.RectColor = Color.FromArgb(211, 47, 47);
        btnRemoveCartItem.Size = new Size(100, 38);
        btnRemoveCartItem.TabIndex = 4;
        btnRemoveCartItem.Text = "移除菜品";
        btnRemoveCartItem.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        //
        // btnClearCart
        //
        btnClearCart.Cursor = Cursors.Hand;
        btnClearCart.FillColor = Color.FromArgb(117, 117, 117);
        btnClearCart.Font = new Font("微软雅黑", 9.5F, FontStyle.Bold);
        btnClearCart.ForeColor = Color.White;
        btnClearCart.Location = new Point(580, 8);
        btnClearCart.MinimumSize = new Size(1, 1);
        btnClearCart.Name = "btnClearCart";
        btnClearCart.Radius = 8;
        btnClearCart.RectColor = Color.FromArgb(117, 117, 117);
        btnClearCart.Size = new Size(120, 38);
        btnClearCart.TabIndex = 0;
        btnClearCart.Text = "清空购物车";
        btnClearCart.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnClearCart.Click += BtnClearCart_Click;
        //
        // btnSubmitOrder
        //
        btnSubmitOrder.Cursor = Cursors.Hand;
        btnSubmitOrder.FillColor = Color.FromArgb(255, 109, 0);
        btnSubmitOrder.Font = new Font("微软雅黑", 9.5F, FontStyle.Bold);
        btnSubmitOrder.ForeColor = Color.White;
        btnSubmitOrder.Location = new Point(710, 8);
        btnSubmitOrder.MinimumSize = new Size(1, 1);
        btnSubmitOrder.Name = "btnSubmitOrder";
        btnSubmitOrder.Radius = 8;
        btnSubmitOrder.RectColor = Color.FromArgb(255, 109, 0);
        btnSubmitOrder.Size = new Size(135, 38);
        btnSubmitOrder.TabIndex = 1;
        btnSubmitOrder.Text = "提交订单";
        btnSubmitOrder.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnSubmitOrder.Click += BtnSubmitOrder_Click;
        //
        // CartForm
        //
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        ClientSize = new Size(860, 686);
        Controls.Add(mainLayout);
        Font = new Font("Microsoft YaHei UI", 10F);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CartForm";
        Padding = new Padding(0, 36, 0, 0);
        StartPosition = FormStartPosition.CenterParent;
        Text = "购物车";
        ZoomScaleRect = new Rectangle(22, 22, 860, 686);
        mainLayout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
        notePanel.ResumeLayout(false);
        totalPanel.ResumeLayout(false);
        buttonPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Sunny.UI.UITableLayoutPanel mainLayout;
    private Sunny.UI.UIDataGridView dgvCart;
    private Sunny.UI.UIPanel notePanel;
    private Sunny.UI.UILabel lblCurrentTable;
    private Sunny.UI.UILabel lblNote;
    private Sunny.UI.UITextBox txtNote;
    private Sunny.UI.UILabel lblDeliveryRegion;
    private Sunny.UI.UIComboBox cmbDeliveryProvince;
    private Sunny.UI.UIComboBox cmbDeliveryCity;
    private Sunny.UI.UIComboBox cmbDeliveryDistrict;
    private Sunny.UI.UILabel lblAddressDetailEditor;
    private Sunny.UI.UITextBox txtAddressDetail;
    private Sunny.UI.UILabel lblCustomerPhoneEditor;
    private Sunny.UI.UITextBox txtCustomerPhone;
    private Sunny.UI.UIPanel totalPanel;
    private Sunny.UI.UILabel lblSubtitleLabel;
    private Sunny.UI.UILabel lblSubtotal;
    private Sunny.UI.UILabel lblDeliveryFeeLabel;
    private Sunny.UI.UILabel lblDeliveryFee;
    private Sunny.UI.UILabel lblTotalLabel;
    private Sunny.UI.UILabel lblTotal;
    private Sunny.UI.UIPanel buttonPanel;
    private Sunny.UI.UIButton btnDecreaseQuantity;
    private Sunny.UI.UIButton btnIncreaseQuantity;
    private Sunny.UI.UIButton btnRemoveCartItem;
    private Sunny.UI.UIButton btnClearCart;
    private Sunny.UI.UIButton btnSubmitOrder;
}
