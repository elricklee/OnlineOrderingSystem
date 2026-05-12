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
        lblNote = new Sunny.UI.UILabel();
        txtNote = new Sunny.UI.UITextBox();
        totalPanel = new Sunny.UI.UIPanel();
        lblSubtitleLabel = new Sunny.UI.UILabel();
        lblSubtotal = new Sunny.UI.UILabel();
        lblDeliveryFeeLabel = new Sunny.UI.UILabel();
        lblDeliveryFee = new Sunny.UI.UILabel();
        lblTotalLabel = new Sunny.UI.UILabel();
        lblTotal = new Sunny.UI.UILabel();
        buttonPanel = new Sunny.UI.UIPanel();
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
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
        mainLayout.Size = new Size(800, 584);
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
        dgvCart.Size = new Size(780, 299);
        dgvCart.StripeOddColor = Color.FromArgb(255, 248, 240);
        dgvCart.TabIndex = 0;
        // 
        // notePanel
        // 
        notePanel.Controls.Add(lblNote);
        notePanel.Controls.Add(txtNote);
        notePanel.Dock = DockStyle.Fill;
        notePanel.FillColor = Color.FromArgb(250, 250, 250);
        notePanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        notePanel.Location = new Point(0, 319);
        notePanel.Margin = new Padding(0);
        notePanel.MinimumSize = new Size(1, 1);
        notePanel.Name = "notePanel";
        notePanel.Size = new Size(800, 80);
        notePanel.TabIndex = 1;
        notePanel.Text = null;
        notePanel.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // lblNote
        // 
        lblNote.FlatStyle = FlatStyle.System;
        lblNote.Font = new Font("微软雅黑", 10F);
        lblNote.ForeColor = Color.FromArgb(51, 51, 51);
        lblNote.Location = new Point(15, 25);
        lblNote.Name = "lblNote";
        lblNote.Size = new Size(100, 30);
        lblNote.TabIndex = 0;
        lblNote.Text = "订单备注：";
        // 
        // txtNote
        // 
        txtNote.Font = new Font("微软雅黑", 10F);
        txtNote.Location = new Point(120, 22);
        txtNote.Margin = new Padding(4, 5, 4, 5);
        txtNote.MinimumSize = new Size(1, 16);
        txtNote.Name = "txtNote";
        txtNote.Padding = new Padding(5);
        txtNote.ShowText = false;
        txtNote.Size = new Size(650, 36);
        txtNote.TabIndex = 1;
        txtNote.TextAlignment = ContentAlignment.MiddleLeft;
        txtNote.Watermark = "请输入备注信息（选填）";
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
        totalPanel.Location = new Point(0, 399);
        totalPanel.Margin = new Padding(0);
        totalPanel.MinimumSize = new Size(1, 1);
        totalPanel.Name = "totalPanel";
        totalPanel.Size = new Size(800, 120);
        totalPanel.TabIndex = 2;
        totalPanel.Text = null;
        totalPanel.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // lblSubtitleLabel
        // 
        lblSubtitleLabel.FlatStyle = FlatStyle.System;
        lblSubtitleLabel.Font = new Font("微软雅黑", 11F);
        lblSubtitleLabel.ForeColor = Color.FromArgb(51, 51, 51);
        lblSubtitleLabel.Location = new Point(420, 10);
        lblSubtitleLabel.Name = "lblSubtitleLabel";
        lblSubtitleLabel.Size = new Size(110, 28);
        lblSubtitleLabel.TabIndex = 0;
        lblSubtitleLabel.Text = "商品合计：";
        // 
        // lblSubtotal
        // 
        lblSubtotal.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        lblSubtotal.ForeColor = Color.FromArgb(255, 109, 0);
        lblSubtotal.Location = new Point(530, 10);
        lblSubtotal.Name = "lblSubtotal";
        lblSubtotal.Size = new Size(120, 28);
        lblSubtotal.TabIndex = 1;
        lblSubtotal.Text = "¥0";
        // 
        // lblDeliveryFeeLabel
        // 
        lblDeliveryFeeLabel.Font = new Font("微软雅黑", 11F);
        lblDeliveryFeeLabel.ForeColor = Color.FromArgb(51, 51, 51);
        lblDeliveryFeeLabel.Location = new Point(420, 42);
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
        lblDeliveryFee.Location = new Point(530, 42);
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
        lblTotalLabel.Location = new Point(420, 74);
        lblTotalLabel.Name = "lblTotalLabel";
        lblTotalLabel.Size = new Size(130, 32);
        lblTotalLabel.TabIndex = 4;
        lblTotalLabel.Text = "应付总额：";
        // 
        // lblTotal
        // 
        lblTotal.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(244, 67, 54);
        lblTotal.Location = new Point(550, 74);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(150, 32);
        lblTotal.TabIndex = 5;
        lblTotal.Text = "¥0";
        // 
        // buttonPanel
        // 
        buttonPanel.Controls.Add(btnClearCart);
        buttonPanel.Controls.Add(btnSubmitOrder);
        buttonPanel.Dock = DockStyle.Fill;
        buttonPanel.FillColor = Color.White;
        buttonPanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        buttonPanel.Location = new Point(0, 519);
        buttonPanel.Margin = new Padding(0);
        buttonPanel.MinimumSize = new Size(1, 1);
        buttonPanel.Name = "buttonPanel";
        buttonPanel.Size = new Size(800, 65);
        buttonPanel.TabIndex = 3;
        buttonPanel.Text = null;
        buttonPanel.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // btnClearCart
        // 
        btnClearCart.Cursor = Cursors.Hand;
        btnClearCart.FillColor = Color.White;
        btnClearCart.Font = new Font("微软雅黑", 10F);
        btnClearCart.ForeColor = Color.FromArgb(244, 67, 54);
        btnClearCart.Location = new Point(200, 12);
        btnClearCart.MinimumSize = new Size(1, 1);
        btnClearCart.Name = "btnClearCart";
        btnClearCart.Radius = 6;
        btnClearCart.RectColor = Color.FromArgb(244, 67, 54);
        btnClearCart.Size = new Size(140, 42);
        btnClearCart.TabIndex = 0;
        btnClearCart.Text = "清空购物车";
        btnClearCart.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnClearCart.Click += BtnClearCart_Click;
        // 
        // btnSubmitOrder
        // 
        btnSubmitOrder.Cursor = Cursors.Hand;
        btnSubmitOrder.FillColor = Color.FromArgb(255, 109, 0);
        btnSubmitOrder.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        btnSubmitOrder.Location = new Point(480, 12);
        btnSubmitOrder.MinimumSize = new Size(1, 1);
        btnSubmitOrder.Name = "btnSubmitOrder";
        btnSubmitOrder.Radius = 6;
        btnSubmitOrder.RectColor = Color.FromArgb(255, 109, 0);
        btnSubmitOrder.Size = new Size(160, 42);
        btnSubmitOrder.TabIndex = 1;
        btnSubmitOrder.Text = "提交订单";
        btnSubmitOrder.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnSubmitOrder.Click += BtnSubmitOrder_Click;
        // 
        // CartForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        ClientSize = new Size(800, 620);
        Controls.Add(mainLayout);
        Font = new Font("Microsoft YaHei UI", 10F);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CartForm";
        Padding = new Padding(0, 36, 0, 0);
        StartPosition = FormStartPosition.CenterParent;
        Text = "购物车";
        ZoomScaleRect = new Rectangle(22, 22, 800, 620);
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
    private Sunny.UI.UILabel lblNote;
    private Sunny.UI.UITextBox txtNote;
    private Sunny.UI.UIPanel totalPanel;
    private Sunny.UI.UILabel lblSubtitleLabel;
    private Sunny.UI.UILabel lblSubtotal;
    private Sunny.UI.UILabel lblDeliveryFeeLabel;
    private Sunny.UI.UILabel lblDeliveryFee;
    private Sunny.UI.UILabel lblTotalLabel;
    private Sunny.UI.UILabel lblTotal;
    private Sunny.UI.UIPanel buttonPanel;
    private Sunny.UI.UIButton btnClearCart;
    private Sunny.UI.UIButton btnSubmitOrder;
}
