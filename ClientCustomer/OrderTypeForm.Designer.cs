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
        txtTableNumber = new TextBox();
        lblTableNumberLabel = new Label();
        lblDineInDesc = new Label();
        lblDineInTitle = new Label();
        picDineIn = new PictureBox();
        panelDelivery = new Panel();
        lblDeliveryDesc = new Label();
        lblDeliveryTitle = new Label();
        picDelivery = new PictureBox();
        lblAddress = new Label();
        txtAddress = new TextBox();
        cmbProvince = new ComboBox();
        cmbCity = new ComboBox();
        cmbDistrict = new ComboBox();
        lblProvince = new Label();
        btnConfirm = new Sunny.UI.UIButton();
        panelDineIn.SuspendLayout();
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
        panelDineIn.Controls.Add(txtTableNumber);
        panelDineIn.Controls.Add(lblTableNumberLabel);
        panelDineIn.Controls.Add(lblDineInDesc);
        panelDineIn.Controls.Add(lblDineInTitle);
        panelDineIn.Controls.Add(picDineIn);
        panelDineIn.Cursor = Cursors.Hand;
        panelDineIn.Location = new Point(99, 107);
        panelDineIn.Name = "panelDineIn";
        panelDineIn.Size = new Size(273, 339);
        panelDineIn.TabIndex = 1;
        // 
        // txtTableNumber
        // 
        txtTableNumber.Font = new Font("微软雅黑", 10F);
        txtTableNumber.Location = new Point(109, 249);
        txtTableNumber.MaxLength = 100;
        txtTableNumber.Name = "txtTableNumber";
        txtTableNumber.Size = new Size(120, 34);
        txtTableNumber.TabIndex = 4;
        // 
        // lblTableNumberLabel
        // 
        lblTableNumberLabel.AutoSize = true;
        lblTableNumberLabel.Font = new Font("微软雅黑", 10F);
        lblTableNumberLabel.Location = new Point(21, 256);
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
        lblDineInDesc.Location = new Point(68, 196);
        lblDineInDesc.Name = "lblDineInDesc";
        lblDineInDesc.Size = new Size(112, 27);
        lblDineInDesc.TabIndex = 2;
        lblDineInDesc.Text = "在餐厅就餐";
        lblDineInDesc.TextAlign = ContentAlignment.MiddleCenter;
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
        picDineIn.Location = new Point(73, 30);
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
        panelDelivery.Controls.Add(cmbDistrict);
        panelDelivery.Controls.Add(cmbCity);
        panelDelivery.Controls.Add(cmbProvince);
        panelDelivery.Controls.Add(lblProvince);
        panelDelivery.Controls.Add(lblDeliveryDesc);
        panelDelivery.Controls.Add(lblDeliveryTitle);
        panelDelivery.Controls.Add(picDelivery);
        panelDelivery.Cursor = Cursors.Hand;
        panelDelivery.Location = new Point(442, 107);
        panelDelivery.Name = "panelDelivery";
        panelDelivery.Size = new Size(279, 339);
        panelDelivery.TabIndex = 2;
        // 
        // lblDeliveryDesc
        // 
        lblDeliveryDesc.AutoSize = true;
        lblDeliveryDesc.Font = new Font("微软雅黑", 10F);
        lblDeliveryDesc.ForeColor = Color.Gray;
        lblDeliveryDesc.Location = new Point(83, 196);
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
        // 
        // picDelivery
        // 
        picDelivery.Image = Properties.Resources.外卖;
        picDelivery.Location = new Point(83, 30);
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
        lblAddress.Text = "配送地址：";
        // 
        // txtAddress
        // 
        txtAddress.Enabled = false;
        txtAddress.Font = new Font("微软雅黑", 10F);
        txtAddress.Location = new Point(286, 473);
        txtAddress.MaxLength = 200;
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(400, 34);
        txtAddress.TabIndex = 4;
        // 
        // lblProvince
        // 
        lblProvince.AutoSize = true;
        lblProvince.Enabled = false;
        lblProvince.Font = new Font("微软雅黑", 10F);
        lblProvince.Location = new Point(21, 240);
        lblProvince.Name = "lblProvince";
        lblProvince.Size = Size.Empty;
        lblProvince.TabIndex = 5;
        // 
        // cmbProvince
        // 
        cmbProvince.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProvince.Enabled = false;
        cmbProvince.Font = new Font("微软雅黑", 9F);
        cmbProvince.Location = new Point(21, 268);
        cmbProvince.Name = "cmbProvince";
        cmbProvince.Size = new Size(80, 30);
        cmbProvince.TabIndex = 6;
        // 
        // cmbCity
        // 
        cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCity.Enabled = false;
        cmbCity.Font = new Font("微软雅黑", 9F);
        cmbCity.Location = new Point(109, 268);
        cmbCity.Name = "cmbCity";
        cmbCity.Size = new Size(80, 30);
        cmbCity.TabIndex = 7;
        // 
        // cmbDistrict
        // 
        cmbDistrict.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDistrict.Enabled = false;
        cmbDistrict.Font = new Font("微软雅黑", 9F);
        cmbDistrict.Location = new Point(197, 268);
        cmbDistrict.Name = "cmbDistrict";
        cmbDistrict.Size = new Size(80, 30);
        cmbDistrict.TabIndex = 8;
        // 
        // btnConfirm
        // 
        btnConfirm.Cursor = Cursors.Hand;
        btnConfirm.FillColor = Color.FromArgb(255, 109, 0);
        btnConfirm.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
        btnConfirm.Location = new Point(320, 537);
        btnConfirm.MinimumSize = new Size(1, 1);
        btnConfirm.Name = "btnConfirm";
        btnConfirm.Radius = 6;
        btnConfirm.RectColor = Color.FromArgb(255, 109, 0);
        btnConfirm.Size = new Size(160, 45);
        btnConfirm.TabIndex = 5;
        btnConfirm.Text = "开始点餐";
        // 
        // OrderTypeForm
        // 
        AutoScaleDimensions = new SizeF(11F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ButtonFace;
        ClientSize = new Size(820, 607);
        Controls.Add(btnConfirm);
        Controls.Add(txtAddress);
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
    private System.Windows.Forms.TextBox txtTableNumber;
    private System.Windows.Forms.Label lblTableNumberLabel;
    private System.Windows.Forms.Panel panelDelivery;
    private System.Windows.Forms.PictureBox picDelivery;
    private System.Windows.Forms.Label lblDeliveryTitle;
    private System.Windows.Forms.Label lblDeliveryDesc;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.ComboBox cmbProvince;
    private System.Windows.Forms.ComboBox cmbCity;
    private System.Windows.Forms.ComboBox cmbDistrict;
    private System.Windows.Forms.Label lblProvince;
    private Sunny.UI.UIButton btnConfirm;
}
