namespace ClientCustomer;

partial class OrderTypeForm
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
        lblTitle = new Label();
        panelDineIn = new Panel();
        cmbDiningTable = new ComboBox();
        lblDinerCount = new Label();
        nudDinerCount = new NumericUpDown();
        lblDiningTableHint = new Label();
        btnRefreshTables = new Button();
        lblTableNumberLabel = new Label();
        lblDineInDesc = new Label();
        lblDineInTitle = new Label();
        picDineIn = new PictureBox();
        panelDelivery = new Panel();
        lblDeliveryDesc = new Label();
        lblDeliveryTitle = new Label();
        picDelivery = new PictureBox();
        lblAddress = new Label();
        cmbProvince = new ComboBox();
        cmbCity = new ComboBox();
        cmbDistrict = new ComboBox();
        lblAddressDetail = new Label();
        txtAddress = new TextBox();
        lblCustomerPhone = new Label();
        txtCustomerPhone = new TextBox();
        btnConfirm = new Sunny.UI.UIButton();
        panelDineIn.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudDinerCount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picDineIn).BeginInit();
        panelDelivery.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picDelivery).BeginInit();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("微软雅黑", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
        lblTitle.Location = new Point(277, 24);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(272, 47);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "请选择点餐模式";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // panelDineIn
        // 
        panelDineIn.BackColor = Color.White;
        panelDineIn.BorderStyle = BorderStyle.FixedSingle;
        panelDineIn.Controls.Add(cmbDiningTable);
        panelDineIn.Controls.Add(lblDinerCount);
        panelDineIn.Controls.Add(nudDinerCount);
        panelDineIn.Controls.Add(lblDiningTableHint);
        panelDineIn.Controls.Add(btnRefreshTables);
        panelDineIn.Controls.Add(lblTableNumberLabel);
        panelDineIn.Controls.Add(lblDineInDesc);
        panelDineIn.Controls.Add(lblDineInTitle);
        panelDineIn.Controls.Add(picDineIn);
        panelDineIn.Cursor = Cursors.Hand;
        panelDineIn.Location = new Point(99, 107);
        panelDineIn.Name = "panelDineIn";
        panelDineIn.Size = new Size(273, 365);
        panelDineIn.TabIndex = 1;
        // 
        // cmbDiningTable
        // 
        cmbDiningTable.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDiningTable.Font = new Font("微软雅黑", 10F);
        cmbDiningTable.FormattingEnabled = true;
        cmbDiningTable.Location = new Point(99, 232);
        cmbDiningTable.Name = "cmbDiningTable";
        cmbDiningTable.Size = new Size(169, 35);
        cmbDiningTable.TabIndex = 5;
        // 
        // lblDinerCount
        // 
        lblDinerCount.AutoSize = true;
        lblDinerCount.Font = new Font("微软雅黑", 10F);
        lblDinerCount.Location = new Point(20, 271);
        lblDinerCount.Name = "lblDinerCount";
        lblDinerCount.Size = new Size(72, 27);
        lblDinerCount.TabIndex = 8;
        lblDinerCount.Text = "人数：";
        // 
        // nudDinerCount
        // 
        nudDinerCount.Font = new Font("微软雅黑", 10F);
        nudDinerCount.Location = new Point(96, 271);
        nudDinerCount.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
        nudDinerCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudDinerCount.Name = "nudDinerCount";
        nudDinerCount.Size = new Size(73, 34);
        nudDinerCount.TabIndex = 9;
        nudDinerCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblDiningTableHint
        // 
        lblDiningTableHint.Font = new Font("微软雅黑", 9F);
        lblDiningTableHint.ForeColor = Color.Gray;
        lblDiningTableHint.Location = new Point(21, 199);
        lblDiningTableHint.Name = "lblDiningTableHint";
        lblDiningTableHint.Size = new Size(231, 28);
        lblDiningTableHint.TabIndex = 6;
        lblDiningTableHint.Text = "请选择可用餐桌";
        // 
        // btnRefreshTables
        // 
        btnRefreshTables.Cursor = Cursors.Hand;
        btnRefreshTables.Font = new Font("微软雅黑", 9F);
        btnRefreshTables.Location = new Point(37, 311);
        btnRefreshTables.Name = "btnRefreshTables";
        btnRefreshTables.Size = new Size(192, 30);
        btnRefreshTables.TabIndex = 7;
        btnRefreshTables.Text = "🔄 刷新餐桌列表";
        // 
        // lblTableNumberLabel
        // 
        lblTableNumberLabel.AutoSize = true;
        lblTableNumberLabel.Font = new Font("微软雅黑", 10F);
        lblTableNumberLabel.Location = new Point(21, 240);
        lblTableNumberLabel.Name = "lblTableNumberLabel";
        lblTableNumberLabel.Size = new Size(72, 27);
        lblTableNumberLabel.TabIndex = 3;
        lblTableNumberLabel.Text = "桌号：";
        // 
        // lblDineInDesc
        // 
        lblDineInDesc.AutoSize = true;
        lblDineInDesc.Font = new Font("微软雅黑", 10F);
        lblDineInDesc.ForeColor = Color.Gray;
        lblDineInDesc.Location = new Point(76, 132);
        lblDineInDesc.Name = "lblDineInDesc";
        lblDineInDesc.Size = new Size(112, 27);
        lblDineInDesc.TabIndex = 2;
        lblDineInDesc.Text = "在餐厅就餐";
        lblDineInDesc.TextAlign = ContentAlignment.MiddleCenter;
        lblDineInDesc.Click += lblDineInDesc_Click;
        // 
        // lblDineInTitle
        // 
        lblDineInTitle.AutoSize = true;
        lblDineInTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        lblDineInTitle.ForeColor = Color.FromArgb(255, 87, 34);
        lblDineInTitle.Location = new Point(68, 159);
        lblDineInTitle.Name = "lblDineInTitle";
        lblDineInTitle.Size = new Size(129, 37);
        lblDineInTitle.TabIndex = 1;
        lblDineInTitle.Text = "堂食点餐";
        lblDineInTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // picDineIn
        // 
        picDineIn.BackColor = Color.White;
        picDineIn.Image = Properties.Resources.堂食;
        picDineIn.Location = new Point(76, 19);
        picDineIn.Name = "picDineIn";
        picDineIn.Size = new Size(110, 110);
        picDineIn.SizeMode = PictureBoxSizeMode.Zoom;
        picDineIn.TabIndex = 0;
        picDineIn.TabStop = false;
        // 
        // panelDelivery
        // 
        panelDelivery.BackColor = Color.White;
        panelDelivery.BorderStyle = BorderStyle.FixedSingle;
        panelDelivery.Controls.Add(lblDeliveryDesc);
        panelDelivery.Controls.Add(lblDeliveryTitle);
        panelDelivery.Controls.Add(picDelivery);
        panelDelivery.Cursor = Cursors.Hand;
        panelDelivery.Location = new Point(442, 107);
        panelDelivery.Name = "panelDelivery";
        panelDelivery.Size = new Size(279, 365);
        panelDelivery.TabIndex = 2;
        // 
        // lblDeliveryDesc
        // 
        lblDeliveryDesc.AutoSize = true;
        lblDeliveryDesc.Font = new Font("微软雅黑", 10F);
        lblDeliveryDesc.ForeColor = Color.Gray;
        lblDeliveryDesc.Location = new Point(92, 132);
        lblDeliveryDesc.Name = "lblDeliveryDesc";
        lblDeliveryDesc.Size = new Size(92, 27);
        lblDeliveryDesc.TabIndex = 3;
        lblDeliveryDesc.Text = "配送到家";
        lblDeliveryDesc.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblDeliveryTitle
        // 
        lblDeliveryTitle.AutoSize = true;
        lblDeliveryTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        lblDeliveryTitle.ForeColor = Color.FromArgb(33, 150, 243);
        lblDeliveryTitle.Location = new Point(74, 159);
        lblDeliveryTitle.Name = "lblDeliveryTitle";
        lblDeliveryTitle.Size = new Size(129, 37);
        lblDeliveryTitle.TabIndex = 1;
        lblDeliveryTitle.Text = "外卖点餐";
        lblDeliveryTitle.TextAlign = ContentAlignment.MiddleCenter;
        lblDeliveryTitle.Click += lblDeliveryTitle_Click;
        // 
        // picDelivery
        // 
        picDelivery.Image = Properties.Resources.外卖;
        picDelivery.Location = new Point(83, 19);
        picDelivery.Name = "picDelivery";
        picDelivery.Size = new Size(110, 110);
        picDelivery.SizeMode = PictureBoxSizeMode.Zoom;
        picDelivery.TabIndex = 0;
        picDelivery.TabStop = false;
        // 
        // lblAddress
        // 
        lblAddress.AutoSize = true;
        lblAddress.Enabled = false;
        lblAddress.Font = new Font("微软雅黑", 10F);
        lblAddress.Location = new Point(168, 480);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(112, 27);
        lblAddress.TabIndex = 3;
        lblAddress.Text = "配送区域 *：";
        // 
        // cmbProvince
        // 
        cmbProvince.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProvince.Enabled = false;
        cmbProvince.Font = new Font("微软雅黑", 10F);
        cmbProvince.FormattingEnabled = true;
        cmbProvince.Location = new Point(286, 473);
        cmbProvince.Name = "cmbProvince";
        cmbProvince.Size = new Size(120, 35);
        cmbProvince.TabIndex = 7;
        // 
        // cmbCity
        // 
        cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCity.Enabled = false;
        cmbCity.Font = new Font("微软雅黑", 10F);
        cmbCity.FormattingEnabled = true;
        cmbCity.Location = new Point(416, 473);
        cmbCity.Name = "cmbCity";
        cmbCity.Size = new Size(120, 35);
        cmbCity.TabIndex = 8;
        // 
        // cmbDistrict
        // 
        cmbDistrict.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDistrict.Enabled = false;
        cmbDistrict.Font = new Font("微软雅黑", 10F);
        cmbDistrict.FormattingEnabled = true;
        cmbDistrict.Location = new Point(546, 473);
        cmbDistrict.Name = "cmbDistrict";
        cmbDistrict.Size = new Size(140, 35);
        cmbDistrict.TabIndex = 9;
        // 
        // lblAddressDetail
        // 
        lblAddressDetail.AutoSize = true;
        lblAddressDetail.Enabled = false;
        lblAddressDetail.Font = new Font("微软雅黑", 10F);
        lblAddressDetail.Location = new Point(168, 523);
        lblAddressDetail.Name = "lblAddressDetail";
        lblAddressDetail.Size = new Size(112, 27);
        lblAddressDetail.TabIndex = 10;
        lblAddressDetail.Text = "详细地址 *：";
        // 
        // txtAddress
        // 
        txtAddress.Enabled = false;
        txtAddress.Font = new Font("微软雅黑", 10F);
        txtAddress.Location = new Point(286, 516);
        txtAddress.MaxLength = 200;
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(400, 34);
        txtAddress.TabIndex = 11;
        // 
        // lblCustomerPhone
        // 
        lblCustomerPhone.AutoSize = true;
        lblCustomerPhone.Enabled = false;
        lblCustomerPhone.Font = new Font("微软雅黑", 10F);
        lblCustomerPhone.Location = new Point(196, 566);
        lblCustomerPhone.Name = "lblCustomerPhone";
        lblCustomerPhone.Size = new Size(92, 27);
        lblCustomerPhone.TabIndex = 12;
        lblCustomerPhone.Text = "手机号 *：";
        // 
        // txtCustomerPhone
        // 
        txtCustomerPhone.Enabled = false;
        txtCustomerPhone.Font = new Font("微软雅黑", 10F);
        txtCustomerPhone.Location = new Point(286, 559);
        txtCustomerPhone.MaxLength = 20;
        txtCustomerPhone.Name = "txtCustomerPhone";
        txtCustomerPhone.Size = new Size(200, 34);
        txtCustomerPhone.TabIndex = 13;
        // 
        // btnConfirm
        // 
        btnConfirm.Cursor = Cursors.Hand;
        btnConfirm.FillColor = Color.FromArgb(255, 109, 0);
        btnConfirm.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
        btnConfirm.Location = new Point(320, 618);
        btnConfirm.MinimumSize = new Size(1, 1);
        btnConfirm.Name = "btnConfirm";
        btnConfirm.Radius = 6;
        btnConfirm.RectColor = Color.FromArgb(255, 109, 0);
        btnConfirm.Size = new Size(180, 48);
        btnConfirm.TabIndex = 14;
        btnConfirm.Text = "进入点餐";
        btnConfirm.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // OrderTypeForm
        // 
        AutoScaleDimensions = new SizeF(11F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ButtonFace;
        ClientSize = new Size(820, 700);
        Controls.Add(btnConfirm);
        Controls.Add(txtCustomerPhone);
        Controls.Add(lblCustomerPhone);
        Controls.Add(txtAddress);
        Controls.Add(lblAddressDetail);
        Controls.Add(cmbDistrict);
        Controls.Add(cmbCity);
        Controls.Add(cmbProvince);
        Controls.Add(lblAddress);
        Controls.Add(panelDelivery);
        Controls.Add(panelDineIn);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "OrderTypeForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "选择点餐模式";
        panelDineIn.ResumeLayout(false);
        panelDineIn.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudDinerCount).EndInit();
        ((System.ComponentModel.ISupportInitialize)picDineIn).EndInit();
        panelDelivery.ResumeLayout(false);
        panelDelivery.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picDelivery).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel panelDineIn;
    private System.Windows.Forms.PictureBox picDineIn;
    private System.Windows.Forms.Label lblDineInTitle;
    private System.Windows.Forms.Label lblDineInDesc;
    private System.Windows.Forms.ComboBox cmbDiningTable;
    private System.Windows.Forms.Label lblDiningTableHint;
    private System.Windows.Forms.Button btnRefreshTables;
    private System.Windows.Forms.Label lblDinerCount;
    private System.Windows.Forms.NumericUpDown nudDinerCount;
    private System.Windows.Forms.Label lblTableNumberLabel;
    private System.Windows.Forms.Panel panelDelivery;
    private System.Windows.Forms.PictureBox picDelivery;
    private System.Windows.Forms.Label lblDeliveryTitle;
    private System.Windows.Forms.Label lblDeliveryDesc;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.ComboBox cmbProvince;
    private System.Windows.Forms.ComboBox cmbCity;
    private System.Windows.Forms.ComboBox cmbDistrict;
    private System.Windows.Forms.Label lblAddressDetail;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Label lblCustomerPhone;
    private System.Windows.Forms.TextBox txtCustomerPhone;
    private Sunny.UI.UIButton btnConfirm;
}
