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
        lblTitle = new System.Windows.Forms.Label();
        panelDineIn = new System.Windows.Forms.Panel();
        picDineIn = new System.Windows.Forms.PictureBox();
        lblDineInTitle = new System.Windows.Forms.Label();
        lblDineInDesc = new System.Windows.Forms.Label();
        txtTableNumber = new System.Windows.Forms.TextBox();
        lblTableNumberLabel = new System.Windows.Forms.Label();
        panelDelivery = new System.Windows.Forms.Panel();
        picDelivery = new System.Windows.Forms.PictureBox();
        lblDeliveryTitle = new System.Windows.Forms.Label();
        lblDeliveryDesc = new System.Windows.Forms.Label();
        lblAddress = new System.Windows.Forms.Label();
        txtAddress = new System.Windows.Forms.TextBox();
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
        lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
        lblTitle.Location = new System.Drawing.Point(277, 24);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(272, 47);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "请选择点餐模式";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // panelDineIn
        //
        panelDineIn.BackColor = System.Drawing.Color.White;
        panelDineIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        panelDineIn.Controls.Add(txtTableNumber);
        panelDineIn.Controls.Add(lblTableNumberLabel);
        panelDineIn.Controls.Add(lblDineInDesc);
        panelDineIn.Controls.Add(lblDineInTitle);
        panelDineIn.Controls.Add(picDineIn);
        panelDineIn.Cursor = System.Windows.Forms.Cursors.Hand;
        panelDineIn.Location = new System.Drawing.Point(99, 107);
        panelDineIn.Name = "panelDineIn";
        panelDineIn.Size = new System.Drawing.Size(273, 339);
        panelDineIn.TabIndex = 1;
        //
        // picDineIn
        //
        picDineIn.BackColor = System.Drawing.Color.White;
        picDineIn.Image = Properties.Resources.堂食;
        picDineIn.Location = new System.Drawing.Point(73, 30);
        picDineIn.Name = "picDineIn";
        picDineIn.Size = new System.Drawing.Size(110, 110);
        picDineIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        picDineIn.TabIndex = 0;
        picDineIn.TabStop = false;
        //
        // lblDineInTitle
        //
        lblDineInTitle.AutoSize = true;
        lblDineInTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
        lblDineInTitle.ForeColor = Color.FromArgb(255, 87, 34);
        lblDineInTitle.Location = new System.Drawing.Point(68, 159);
        lblDineInTitle.Name = "lblDineInTitle";
        lblDineInTitle.Size = new System.Drawing.Size(129, 37);
        lblDineInTitle.TabIndex = 1;
        lblDineInTitle.Text = "堂食点餐";
        lblDineInTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // lblDineInDesc
        //
        lblDineInDesc.AutoSize = true;
        lblDineInDesc.Font = new System.Drawing.Font("微软雅黑", 10F);
        lblDineInDesc.ForeColor = System.Drawing.Color.Gray;
        lblDineInDesc.Location = new System.Drawing.Point(68, 196);
        lblDineInDesc.Name = "lblDineInDesc";
        lblDineInDesc.Size = new System.Drawing.Size(112, 27);
        lblDineInDesc.TabIndex = 2;
        lblDineInDesc.Text = "在餐厅就餐";
        lblDineInDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // txtTableNumber
        //
        txtTableNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
        txtTableNumber.Location = new System.Drawing.Point(109, 249);
        txtTableNumber.MaxLength = 100;
        txtTableNumber.Name = "txtTableNumber";
        txtTableNumber.Size = new System.Drawing.Size(120, 34);
        txtTableNumber.TabIndex = 4;
        //
        // lblTableNumberLabel
        //
        lblTableNumberLabel.AutoSize = true;
        lblTableNumberLabel.Font = new System.Drawing.Font("微软雅黑", 10F);
        lblTableNumberLabel.Location = new System.Drawing.Point(21, 256);
        lblTableNumberLabel.Name = "lblTableNumberLabel";
        lblTableNumberLabel.Size = new System.Drawing.Size(72, 27);
        lblTableNumberLabel.TabIndex = 3;
        lblTableNumberLabel.Text = "桌号：";
        //
        // panelDelivery
        //
        panelDelivery.BackColor = System.Drawing.Color.White;
        panelDelivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        panelDelivery.Controls.Add(lblDeliveryDesc);
        panelDelivery.Controls.Add(lblDeliveryTitle);
        panelDelivery.Controls.Add(picDelivery);
        panelDelivery.Cursor = System.Windows.Forms.Cursors.Hand;
        panelDelivery.Location = new System.Drawing.Point(442, 107);
        panelDelivery.Name = "panelDelivery";
        panelDelivery.Size = new System.Drawing.Size(279, 339);
        panelDelivery.TabIndex = 2;
        //
        // picDelivery
        //
        picDelivery.Image = Properties.Resources.外卖;
        picDelivery.Location = new System.Drawing.Point(83, 30);
        picDelivery.Name = "picDelivery";
        picDelivery.Size = new System.Drawing.Size(110, 110);
        picDelivery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        picDelivery.TabIndex = 0;
        picDelivery.TabStop = false;
        //
        // lblDeliveryTitle
        //
        lblDeliveryTitle.AutoSize = true;
        lblDeliveryTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
        lblDeliveryTitle.ForeColor = Color.FromArgb(33, 150, 243);
        lblDeliveryTitle.Location = new System.Drawing.Point(74, 159);
        lblDeliveryTitle.Name = "lblDeliveryTitle";
        lblDeliveryTitle.Size = new System.Drawing.Size(129, 37);
        lblDeliveryTitle.TabIndex = 1;
        lblDeliveryTitle.Text = "外卖点餐";
        lblDeliveryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // lblDeliveryDesc
        //
        lblDeliveryDesc.AutoSize = true;
        lblDeliveryDesc.Font = new System.Drawing.Font("微软雅黑", 10F);
        lblDeliveryDesc.ForeColor = System.Drawing.Color.Gray;
        lblDeliveryDesc.Location = new System.Drawing.Point(74, 196);
        lblDeliveryDesc.Name = "lblDeliveryDesc";
        lblDeliveryDesc.Size = new System.Drawing.Size(112, 27);
        lblDeliveryDesc.TabIndex = 3;
        lblDeliveryDesc.Text = "配送到家";
        lblDeliveryDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // lblAddress
        //
        lblAddress.AutoSize = true;
        lblAddress.Enabled = false;
        lblAddress.Font = new System.Drawing.Font("微软雅黑", 10F);
        lblAddress.Location = new System.Drawing.Point(168, 480);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new System.Drawing.Size(112, 27);
        lblAddress.TabIndex = 3;
        lblAddress.Text = "配送地址：";
        //
        // txtAddress
        //
        txtAddress.Enabled = false;
        txtAddress.Font = new System.Drawing.Font("微软雅黑", 10F);
        txtAddress.Location = new System.Drawing.Point(286, 473);
        txtAddress.MaxLength = 200;
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new System.Drawing.Size(400, 34);
        txtAddress.TabIndex = 4;
        //
        // btnConfirm
        //
        btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
        btnConfirm.FillColor = Color.FromArgb(255, 109, 0);
        btnConfirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
        btnConfirm.ForeColor = System.Drawing.Color.White;
        btnConfirm.Location = new System.Drawing.Point(320, 537);
        btnConfirm.MinimumSize = new System.Drawing.Size(1, 1);
        btnConfirm.Name = "btnConfirm";
        btnConfirm.Radius = 6;
        btnConfirm.RectColor = Color.FromArgb(255, 109, 0);
        btnConfirm.Size = new System.Drawing.Size(160, 45);
        btnConfirm.TabIndex = 5;
        btnConfirm.TagString = null;
        btnConfirm.Text = "开始点餐";
        btnConfirm.TipsFont = new System.Drawing.Font("宋体", 9F);
        //
        // OrderTypeForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.ButtonFace;
        ClientSize = new System.Drawing.Size(820, 607);
        Controls.Add(btnConfirm);
        Controls.Add(txtAddress);
        Controls.Add(lblAddress);
        Controls.Add(panelDelivery);
        Controls.Add(panelDineIn);
        Controls.Add(lblTitle);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "OrderTypeForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
    private Sunny.UI.UIButton btnConfirm;
}
