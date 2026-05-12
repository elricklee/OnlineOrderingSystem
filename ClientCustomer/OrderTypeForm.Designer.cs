namespace ClientCustomer
{
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
            lblDeliveryTitle = new Label();
            picDelivery = new PictureBox();
            lblDeliveryDesc = new Label();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnConfirm = new Sunny.UI.UIButton();
            panelDineIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDineIn).BeginInit();
            panelDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDelivery).BeginInit();
            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("微软雅黑", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblTitle.Location = new Point(277, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(272, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "请选择点餐模式";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

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

            txtTableNumber.Font = new Font("微软雅黑", 10F);
            txtTableNumber.Location = new Point(109, 249);
            txtTableNumber.MaxLength = 100;
            txtTableNumber.Name = "txtTableNumber";
            txtTableNumber.Size = new Size(120, 34);
            txtTableNumber.TabIndex = 4;

            lblTableNumberLabel.AutoSize = true;
            lblTableNumberLabel.Font = new Font("微软雅黑", 10F);
            lblTableNumberLabel.Location = new Point(21, 256);
            lblTableNumberLabel.Name = "lblTableNumberLabel";
            lblTableNumberLabel.Size = new Size(72, 27);
            lblTableNumberLabel.TabIndex = 3;
            lblTableNumberLabel.Text = "桌号：";

            lblDineInDesc.AutoSize = true;
            lblDineInDesc.Font = new Font("微软雅黑", 10F);
            lblDineInDesc.ForeColor = Color.Gray;
            lblDineInDesc.Location = new Point(68, 196);
            lblDineInDesc.Name = "lblDineInDesc";
            lblDineInDesc.Size = new Size(112, 27);
            lblDineInDesc.TabIndex = 2;
            lblDineInDesc.Text = "在餐厅就餐";
            lblDineInDesc.TextAlign = ContentAlignment.MiddleCenter;

            lblDineInTitle.AutoSize = true;
            lblDineInTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
            lblDineInTitle.ForeColor = Color.FromArgb(255, 87, 34);
            lblDineInTitle.Location = new Point(68, 159);
            lblDineInTitle.Name = "lblDineInTitle";
            lblDineInTitle.Size = new Size(129, 37);
            lblDineInTitle.TabIndex = 1;
            lblDineInTitle.Text = "堂食点餐";
            lblDineInTitle.TextAlign = ContentAlignment.MiddleCenter;

            picDineIn.BackColor = Color.White;
            picDineIn.Image = Properties.Resources.堂食;
            picDineIn.Location = new Point(73, 30);
            picDineIn.Name = "picDineIn";
            picDineIn.Size = new Size(110, 110);
            picDineIn.SizeMode = PictureBoxSizeMode.Zoom;
            picDineIn.TabIndex = 0;
            picDineIn.TabStop = false;

            panelDelivery.BackColor = Color.White;
            panelDelivery.BorderStyle = BorderStyle.FixedSingle;
            panelDelivery.Controls.Add(lblDeliveryDesc);
            panelDelivery.Controls.Add(lblDeliveryTitle);
            panelDelivery.Controls.Add(picDelivery);
            panelDelivery.Cursor = Cursors.Hand;
            panelDelivery.Location = new Point(442, 107);
            panelDelivery.Name = "panelDelivery";
            panelDelivery.Size = new Size(279, 339);
            panelDelivery.TabIndex = 2;

            lblDeliveryDesc = new Label();
            lblDeliveryDesc.AutoSize = true;
            lblDeliveryDesc.Font = new Font("微软雅黑", 10F);
            lblDeliveryDesc.ForeColor = Color.Gray;
            lblDeliveryDesc.Location = new Point(74, 196);
            lblDeliveryDesc.Name = "lblDeliveryDesc";
            lblDeliveryDesc.Size = new Size(112, 27);
            lblDeliveryDesc.TabIndex = 3;
            lblDeliveryDesc.Text = "配送到家";
            lblDeliveryDesc.TextAlign = ContentAlignment.MiddleCenter;

            lblDeliveryTitle.AutoSize = true;
            lblDeliveryTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
            lblDeliveryTitle.ForeColor = Color.FromArgb(33, 150, 243);
            lblDeliveryTitle.Location = new Point(74, 159);
            lblDeliveryTitle.Name = "lblDeliveryTitle";
            lblDeliveryTitle.Size = new Size(129, 37);
            lblDeliveryTitle.TabIndex = 1;
            lblDeliveryTitle.Text = "外卖点餐";
            lblDeliveryTitle.TextAlign = ContentAlignment.MiddleCenter;

            picDelivery.Image = Properties.Resources.外卖;
            picDelivery.Location = new Point(83, 30);
            picDelivery.Name = "picDelivery";
            picDelivery.Size = new Size(110, 110);
            picDelivery.SizeMode = PictureBoxSizeMode.Zoom;
            picDelivery.TabIndex = 0;
            picDelivery.TabStop = false;

            lblAddress.AutoSize = true;
            lblAddress.Enabled = false;
            lblAddress.Font = new Font("微软雅黑", 10F);
            lblAddress.Location = new Point(168, 480);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(112, 27);
            lblAddress.TabIndex = 3;
            lblAddress.Text = "配送地址：";

            txtAddress.Enabled = false;
            txtAddress.Font = new Font("微软雅黑", 10F);
            txtAddress.Location = new Point(286, 473);
            txtAddress.MaxLength = 200;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(400, 34);
            txtAddress.TabIndex = 4;

            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
            btnConfirm.Location = new Point(320, 537);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(160, 45);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "开始点餐";
            btnConfirm.FillColor = Color.FromArgb(255, 109, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.RectColor = Color.FromArgb(255, 109, 0);
            btnConfirm.Radius = 6;

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

        private Label lblTitle;
        private Panel panelDineIn;
        private Label lblDineInTitle;
        private PictureBox picDineIn;
        private Label lblDineInDesc;
        private TextBox txtTableNumber;
        private Label lblTableNumberLabel;
        private Panel panelDelivery;
        private Label lblDeliveryTitle;
        private PictureBox picDelivery;
        private Label lblDeliveryDesc;
        private Label lblAddress;
        private TextBox txtAddress;
        private Sunny.UI.UIButton btnConfirm;
    }
}
