namespace ClientCustomer
{
    partial class OrderTypeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            panelDineIn = new Panel();
            picDineIn = new PictureBox();
            lblDineInTitle = new Label();
            lblDineInDesc = new Label();
            lblTableNumberLabel = new Label();
            txtTableNumber = new TextBox();
            panelDelivery = new Panel();
            picDelivery = new PictureBox();
            lblDeliveryTitle = new Label();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnConfirm = new ReaLTaiizor.Controls.AirButton();
            panelDineIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDineIn).BeginInit();
            panelDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDelivery).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("微软雅黑", 18F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblTitle.Location = new Point(150, 30);
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
            panelDineIn.Location = new Point(50, 100);
            panelDineIn.Name = "panelDineIn";
            panelDineIn.Size = new Size(230, 180);
            panelDineIn.TabIndex = 1;
            // 
            // picDineIn
            // 
            picDineIn.BackColor = Color.Transparent;
            picDineIn.Location = new Point(90, 20);
            picDineIn.Name = "picDineIn";
            picDineIn.Size = new Size(50, 50);
            picDineIn.SizeMode = PictureBoxSizeMode.Zoom;
            picDineIn.TabIndex = 0;
            picDineIn.TabStop = false;
            // 
            // lblDineInTitle
            // 
            lblDineInTitle.AutoSize = true;
            lblDineInTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblDineInTitle.ForeColor = Color.FromArgb(255, 87, 34);
            lblDineInTitle.Location = new Point(52, 73);
            lblDineInTitle.Name = "lblDineInTitle";
            lblDineInTitle.Size = new Size(129, 37);
            lblDineInTitle.TabIndex = 1;
            lblDineInTitle.Text = "堂食点餐";
            lblDineInTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDineInDesc
            // 
            lblDineInDesc.AutoSize = true;
            lblDineInDesc.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblDineInDesc.ForeColor = Color.Gray;
            lblDineInDesc.Location = new Point(52, 110);
            lblDineInDesc.Name = "lblDineInDesc";
            lblDineInDesc.Size = new Size(112, 27);
            lblDineInDesc.TabIndex = 2;
            lblDineInDesc.Text = "在餐厅就餐";
            lblDineInDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTableNumberLabel
            // 
            lblTableNumberLabel.AutoSize = true;
            lblTableNumberLabel.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblTableNumberLabel.Location = new Point(20, 145);
            lblTableNumberLabel.Name = "lblTableNumberLabel";
            lblTableNumberLabel.Size = new Size(72, 27);
            lblTableNumberLabel.TabIndex = 3;
            lblTableNumberLabel.Text = "桌号：";
            // 
            // txtTableNumber
            // 
            txtTableNumber.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtTableNumber.Location = new Point(90, 140);
            txtTableNumber.MaxLength = 100;
            txtTableNumber.Name = "txtTableNumber";
            txtTableNumber.Size = new Size(120, 34);
            txtTableNumber.TabIndex = 4;
            // 
            // panelDelivery
            // 
            panelDelivery.BackColor = Color.White;
            panelDelivery.BorderStyle = BorderStyle.FixedSingle;
            panelDelivery.Controls.Add(lblDeliveryTitle);
            panelDelivery.Controls.Add(picDelivery);
            panelDelivery.Cursor = Cursors.Hand;
            panelDelivery.Location = new Point(320, 100);
            panelDelivery.Name = "panelDelivery";
            panelDelivery.Size = new Size(230, 180);
            panelDelivery.TabIndex = 2;
            // 
            // picDelivery
            // 
            picDelivery.Location = new Point(90, 20);
            picDelivery.Name = "picDelivery";
            picDelivery.Size = new Size(50, 50);
            picDelivery.SizeMode = PictureBoxSizeMode.Zoom;
            picDelivery.TabIndex = 0;
            picDelivery.TabStop = false;
            // 
            // lblDeliveryTitle
            // 
            lblDeliveryTitle.AutoSize = true;
            lblDeliveryTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblDeliveryTitle.ForeColor = Color.FromArgb(33, 150, 243);
            lblDeliveryTitle.Location = new Point(54, 73);
            lblDeliveryTitle.Name = "lblDeliveryTitle";
            lblDeliveryTitle.Size = new Size(129, 37);
            lblDeliveryTitle.TabIndex = 1;
            lblDeliveryTitle.Text = "外卖点餐";
            lblDeliveryTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Enabled = false;
            lblAddress.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblAddress.Location = new Point(50, 300);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(112, 27);
            lblAddress.TabIndex = 3;
            lblAddress.Text = "配送地址：";
            // 
            // txtAddress
            // 
            txtAddress.Enabled = false;
            txtAddress.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtAddress.Location = new Point(150, 300);
            txtAddress.MaxLength = 200;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(400, 34);
            txtAddress.TabIndex = 4;
            // 
            // btnConfirm
            // 
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            btnConfirm.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.Image = null;
            btnConfirm.Location = new Point(220, 340);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.NoRounding = false;
            btnConfirm.Size = new Size(160, 45);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "开始点餐";
            btnConfirm.Transparent = false;
            // 
            // OrderTypeForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(578, 394);
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

        #endregion

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
        private Label lblAddress;
        private TextBox txtAddress;
        private ReaLTaiizor.Controls.AirButton btnConfirm;
    }
}