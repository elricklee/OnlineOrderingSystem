namespace ClientAdmin;

partial class Form1
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
        DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
        tabMain = new Sunny.UI.UITabControl();
        tabDishes = new TabPage();
        layoutDishPage = new Sunny.UI.UITableLayoutPanel();
        grpDishEdit = new Sunny.UI.UIGroupBox();
        layoutDishEdit = new Sunny.UI.UITableLayoutPanel();
        uiLabel3 = new Sunny.UI.UILabel();
        btnDeleteDish = new Sunny.UI.UIButton();
        txtDishName = new Sunny.UI.UITextBox();
        uiLabel1 = new Sunny.UI.UILabel();
        btnAddDish = new Sunny.UI.UIButton();
        txtCategory = new Sunny.UI.UITextBox();
        uiLabel2 = new Sunny.UI.UILabel();
        txtPrice = new Sunny.UI.UITextBox();
        btnUpdateDish = new Sunny.UI.UIButton();
        btnLoadDishes = new Sunny.UI.UIButton();
        dgvDishes = new Sunny.UI.UIDataGridView();
        tabOrders = new TabPage();
        layoutOrderPage = new Sunny.UI.UITableLayoutPanel();
        panelOrderTop = new Sunny.UI.UIFlowLayoutPanel();
        btnLoadOrders = new Sunny.UI.UIButton();
        changeOrder = new Sunny.UI.UILabel();
        cmbOrderStatus = new Sunny.UI.UIComboBox();
        btnUpdateOrderStatus = new Sunny.UI.UIButton();
        layoutOrderMain = new Sunny.UI.UITableLayoutPanel();
        dgvOrders = new Sunny.UI.UIDataGridView();
        grpOrderDetail = new Sunny.UI.UIGroupBox();
        lblCreatedAt = new Sunny.UI.UILabel();
        lblStatus = new Sunny.UI.UILabel();
        lblTotalAmount = new Sunny.UI.UILabel();
        lblDeliveryFee = new Sunny.UI.UILabel();
        lblNote = new Sunny.UI.UILabel();
        lblAddress = new Sunny.UI.UILabel();
        lblTableNumber = new Sunny.UI.UILabel();
        lblPhone = new Sunny.UI.UILabel();
        lblCustomerName = new Sunny.UI.UILabel();
        lblOrderType = new Sunny.UI.UILabel();
        lblOrderId = new Sunny.UI.UILabel();
        grpOrderItems = new Sunny.UI.UIGroupBox();
        dgvOrderItems = new Sunny.UI.UIDataGridView();
        tabStatistics = new TabPage();
        tabAi = new TabPage();
        tabMain.SuspendLayout();
        tabDishes.SuspendLayout();
        layoutDishPage.SuspendLayout();
        grpDishEdit.SuspendLayout();
        layoutDishEdit.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDishes).BeginInit();
        tabOrders.SuspendLayout();
        layoutOrderPage.SuspendLayout();
        panelOrderTop.SuspendLayout();
        layoutOrderMain.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        grpOrderDetail.SuspendLayout();
        grpOrderItems.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
        SuspendLayout();
        // 
        // tabMain
        // 
        tabMain.Controls.Add(tabDishes);
        tabMain.Controls.Add(tabOrders);
        tabMain.Controls.Add(tabStatistics);
        tabMain.Controls.Add(tabAi);
        tabMain.Dock = DockStyle.Fill;
        tabMain.DrawMode = TabDrawMode.OwnerDrawFixed;
        tabMain.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        tabMain.ItemSize = new Size(150, 40);
        tabMain.Location = new Point(0, 35);
        tabMain.MainPage = "";
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 0;
        tabMain.Size = new Size(1228, 689);
        tabMain.SizeMode = TabSizeMode.Fixed;
        tabMain.TabIndex = 0;
        tabMain.TabUnSelectedForeColor = Color.FromArgb(240, 240, 240);
        tabMain.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // tabDishes
        // 
        tabDishes.Controls.Add(layoutDishPage);
        tabDishes.Location = new Point(0, 40);
        tabDishes.Name = "tabDishes";
        tabDishes.Size = new Size(1228, 649);
        tabDishes.TabIndex = 0;
        tabDishes.Text = "菜品管理";
        tabDishes.UseVisualStyleBackColor = true;
        // 
        // layoutDishPage
        // 
        layoutDishPage.ColumnCount = 1;
        layoutDishPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutDishPage.Controls.Add(grpDishEdit, 0, 2);
        layoutDishPage.Controls.Add(btnLoadDishes, 0, 0);
        layoutDishPage.Controls.Add(dgvDishes, 0, 1);
        layoutDishPage.Dock = DockStyle.Fill;
        layoutDishPage.Location = new Point(0, 0);
        layoutDishPage.Name = "layoutDishPage";
        layoutDishPage.RowCount = 3;
        layoutDishPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutDishPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutDishPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 210F));
        layoutDishPage.Size = new Size(1228, 649);
        layoutDishPage.TabIndex = 8;
        layoutDishPage.TagString = null;
        // 
        // grpDishEdit
        // 
        grpDishEdit.Controls.Add(layoutDishEdit);
        grpDishEdit.Dock = DockStyle.Fill;
        grpDishEdit.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpDishEdit.Location = new Point(10, 449);
        grpDishEdit.Margin = new Padding(10);
        grpDishEdit.MinimumSize = new Size(1, 1);
        grpDishEdit.Name = "grpDishEdit";
        grpDishEdit.Padding = new Padding(0, 32, 0, 0);
        grpDishEdit.Size = new Size(1208, 190);
        grpDishEdit.TabIndex = 9;
        grpDishEdit.Text = "菜品编辑";
        grpDishEdit.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // layoutDishEdit
        // 
        layoutDishEdit.Anchor = AnchorStyles.None;
        layoutDishEdit.ColumnCount = 6;
        layoutDishEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 163F));
        layoutDishEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.57895F));
        layoutDishEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 139F));
        layoutDishEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.5789471F));
        layoutDishEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 149F));
        layoutDishEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.8421059F));
        layoutDishEdit.Controls.Add(uiLabel3, 4, 0);
        layoutDishEdit.Controls.Add(btnDeleteDish, 5, 1);
        layoutDishEdit.Controls.Add(txtDishName, 1, 0);
        layoutDishEdit.Controls.Add(uiLabel1, 0, 0);
        layoutDishEdit.Controls.Add(btnAddDish, 1, 1);
        layoutDishEdit.Controls.Add(txtCategory, 3, 0);
        layoutDishEdit.Controls.Add(uiLabel2, 2, 0);
        layoutDishEdit.Controls.Add(txtPrice, 5, 0);
        layoutDishEdit.Controls.Add(btnUpdateDish, 3, 1);
        layoutDishEdit.Location = new Point(60, 32);
        layoutDishEdit.Name = "layoutDishEdit";
        layoutDishEdit.RowCount = 2;
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutDishEdit.Size = new Size(1105, 155);
        layoutDishEdit.TabIndex = 0;
        layoutDishEdit.TagString = null;
        // 
        // uiLabel3
        // 
        uiLabel3.Anchor = AnchorStyles.None;
        uiLabel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
        uiLabel3.Location = new Point(747, 21);
        uiLabel3.Name = "uiLabel3";
        uiLabel3.Size = new Size(83, 34);
        uiLabel3.TabIndex = 9;
        uiLabel3.Text = "价格：";
        // 
        // btnDeleteDish
        // 
        btnDeleteDish.Anchor = AnchorStyles.None;
        btnDeleteDish.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnDeleteDish.Location = new Point(909, 85);
        btnDeleteDish.MinimumSize = new Size(1, 1);
        btnDeleteDish.Name = "btnDeleteDish";
        btnDeleteDish.Radius = 2;
        btnDeleteDish.Size = new Size(150, 60);
        btnDeleteDish.TabIndex = 3;
        btnDeleteDish.Text = "删除按钮";
        btnDeleteDish.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnDeleteDish.Click += btnDeleteDish_Click;
        // 
        // txtDishName
        // 
        txtDishName.Anchor = AnchorStyles.None;
        txtDishName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtDishName.Location = new Point(196, 16);
        txtDishName.Margin = new Padding(4, 5, 4, 5);
        txtDishName.MinimumSize = new Size(1, 16);
        txtDishName.Name = "txtDishName";
        txtDishName.Padding = new Padding(5);
        txtDishName.ShowText = false;
        txtDishName.Size = new Size(140, 44);
        txtDishName.TabIndex = 7;
        txtDishName.TextAlignment = ContentAlignment.MiddleLeft;
        txtDishName.Watermark = "";
        // 
        // uiLabel1
        // 
        uiLabel1.Anchor = AnchorStyles.None;
        uiLabel1.Font = new Font("宋体", 12F);
        uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
        uiLabel1.Location = new Point(15, 21);
        uiLabel1.Name = "uiLabel1";
        uiLabel1.Size = new Size(132, 34);
        uiLabel1.TabIndex = 8;
        uiLabel1.Text = "菜品名称：";
        // 
        // btnAddDish
        // 
        btnAddDish.Anchor = AnchorStyles.None;
        btnAddDish.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnAddDish.Location = new Point(191, 85);
        btnAddDish.MinimumSize = new Size(1, 1);
        btnAddDish.Name = "btnAddDish";
        btnAddDish.Radius = 2;
        btnAddDish.Size = new Size(150, 60);
        btnAddDish.TabIndex = 1;
        btnAddDish.Text = "添加按钮";
        btnAddDish.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnAddDish.Click += btnAddDish_Click;
        // 
        // txtCategory
        // 
        txtCategory.Anchor = AnchorStyles.None;
        txtCategory.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtCategory.Location = new Point(540, 16);
        txtCategory.Margin = new Padding(4, 5, 4, 5);
        txtCategory.MinimumSize = new Size(1, 16);
        txtCategory.Name = "txtCategory";
        txtCategory.Padding = new Padding(5);
        txtCategory.ShowText = false;
        txtCategory.Size = new Size(142, 44);
        txtCategory.TabIndex = 6;
        txtCategory.TextAlignment = ContentAlignment.MiddleLeft;
        txtCategory.Watermark = "";
        // 
        // uiLabel2
        // 
        uiLabel2.Anchor = AnchorStyles.None;
        uiLabel2.Enabled = false;
        uiLabel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
        uiLabel2.Location = new Point(391, 21);
        uiLabel2.Name = "uiLabel2";
        uiLabel2.Size = new Size(94, 34);
        uiLabel2.TabIndex = 9;
        uiLabel2.Text = "分类：";
        // 
        // txtPrice
        // 
        txtPrice.Anchor = AnchorStyles.None;
        txtPrice.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtPrice.Location = new Point(909, 16);
        txtPrice.Margin = new Padding(4, 5, 4, 5);
        txtPrice.MinimumSize = new Size(1, 16);
        txtPrice.Name = "txtPrice";
        txtPrice.Padding = new Padding(5);
        txtPrice.ShowText = false;
        txtPrice.Size = new Size(149, 44);
        txtPrice.TabIndex = 7;
        txtPrice.TextAlignment = ContentAlignment.MiddleLeft;
        txtPrice.Watermark = "";
        // 
        // btnUpdateDish
        // 
        btnUpdateDish.Anchor = AnchorStyles.None;
        btnUpdateDish.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnUpdateDish.Location = new Point(536, 85);
        btnUpdateDish.MinimumSize = new Size(1, 1);
        btnUpdateDish.Name = "btnUpdateDish";
        btnUpdateDish.Radius = 2;
        btnUpdateDish.Size = new Size(150, 60);
        btnUpdateDish.TabIndex = 2;
        btnUpdateDish.Text = "修改按钮";
        btnUpdateDish.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnUpdateDish.Click += btnUpdateDish_Click;
        // 
        // btnLoadDishes
        // 
        btnLoadDishes.Anchor = AnchorStyles.None;
        btnLoadDishes.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnLoadDishes.Location = new Point(559, 12);
        btnLoadDishes.MinimumSize = new Size(1, 1);
        btnLoadDishes.Name = "btnLoadDishes";
        btnLoadDishes.Size = new Size(110, 35);
        btnLoadDishes.TabIndex = 0;
        btnLoadDishes.Text = "刷新按钮";
        btnLoadDishes.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnLoadDishes.Click += btnLoadDishes_Click;
        // 
        // dgvDishes
        // 
        dgvDishes.AllowUserToAddRows = false;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
        dgvDishes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        dgvDishes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDishes.BackgroundColor = Color.White;
        dgvDishes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
        dgvDishes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        dgvDishes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = SystemColors.Window;
        dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
        dgvDishes.DefaultCellStyle = dataGridViewCellStyle3;
        dgvDishes.Dock = DockStyle.Fill;
        dgvDishes.EnableHeadersVisualStyles = false;
        dgvDishes.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvDishes.GridColor = Color.FromArgb(80, 160, 255);
        dgvDishes.Location = new Point(12, 65);
        dgvDishes.Margin = new Padding(12, 5, 12, 5);
        dgvDishes.Name = "dgvDishes";
        dgvDishes.ReadOnly = true;
        dgvDishes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
        dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle4.SelectionForeColor = Color.White;
        dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
        dgvDishes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
        dgvDishes.RowHeadersWidth = 62;
        dataGridViewCellStyle5.BackColor = Color.White;
        dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvDishes.RowsDefaultCellStyle = dataGridViewCellStyle5;
        dgvDishes.SelectedIndex = -1;
        dgvDishes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDishes.Size = new Size(1204, 369);
        dgvDishes.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvDishes.TabIndex = 4;
        dgvDishes.CellClick += dgvDishes_CellClick;
        // 
        // tabOrders
        // 
        tabOrders.Controls.Add(layoutOrderPage);
        tabOrders.Location = new Point(0, 40);
        tabOrders.Name = "tabOrders";
        tabOrders.Size = new Size(1228, 649);
        tabOrders.TabIndex = 1;
        tabOrders.Text = "订单管理";
        tabOrders.UseVisualStyleBackColor = true;
        // 
        // layoutOrderPage
        // 
        layoutOrderPage.ColumnCount = 1;
        layoutOrderPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutOrderPage.Controls.Add(panelOrderTop, 0, 0);
        layoutOrderPage.Controls.Add(layoutOrderMain, 0, 1);
        layoutOrderPage.Controls.Add(grpOrderItems, 0, 2);
        layoutOrderPage.Dock = DockStyle.Fill;
        layoutOrderPage.Location = new Point(0, 0);
        layoutOrderPage.Name = "layoutOrderPage";
        layoutOrderPage.RowCount = 3;
        layoutOrderPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
        layoutOrderPage.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
        layoutOrderPage.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
        layoutOrderPage.Size = new Size(1228, 649);
        layoutOrderPage.TabIndex = 0;
        layoutOrderPage.TagString = null;
        // 
        // panelOrderTop
        // 
        panelOrderTop.Controls.Add(btnLoadOrders);
        panelOrderTop.Controls.Add(changeOrder);
        panelOrderTop.Controls.Add(cmbOrderStatus);
        panelOrderTop.Controls.Add(btnUpdateOrderStatus);
        panelOrderTop.Dock = DockStyle.Fill;
        panelOrderTop.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        panelOrderTop.Location = new Point(4, 5);
        panelOrderTop.Margin = new Padding(4, 5, 4, 5);
        panelOrderTop.MinimumSize = new Size(1, 1);
        panelOrderTop.Name = "panelOrderTop";
        panelOrderTop.Padding = new Padding(2);
        panelOrderTop.ShowText = false;
        panelOrderTop.Size = new Size(1220, 60);
        panelOrderTop.TabIndex = 0;
        panelOrderTop.Text = "uiFlowLayoutPanel1";
        panelOrderTop.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // btnLoadOrders
        // 
        btnLoadOrders.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnLoadOrders.Location = new Point(38, 9);
        btnLoadOrders.MinimumSize = new Size(1, 1);
        btnLoadOrders.Name = "btnLoadOrders";
        btnLoadOrders.Size = new Size(137, 38);
        btnLoadOrders.TabIndex = 7;
        btnLoadOrders.Text = "刷新订单";
        btnLoadOrders.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnLoadOrders.Click += btnLoadOrders_Click;
        // 
        // changeOrder
        // 
        changeOrder.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        changeOrder.ForeColor = Color.FromArgb(48, 48, 48);
        changeOrder.Location = new Point(298, 9);
        changeOrder.Name = "changeOrder";
        changeOrder.Size = new Size(150, 38);
        changeOrder.TabIndex = 8;
        changeOrder.Text = "修改为：";
        changeOrder.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // cmbOrderStatus
        // 
        cmbOrderStatus.DataSource = null;
        cmbOrderStatus.FillColor = Color.White;
        cmbOrderStatus.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        cmbOrderStatus.ItemHoverColor = Color.FromArgb(155, 200, 255);
        cmbOrderStatus.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
        cmbOrderStatus.Location = new Point(543, 9);
        cmbOrderStatus.Margin = new Padding(4, 5, 4, 5);
        cmbOrderStatus.MinimumSize = new Size(63, 0);
        cmbOrderStatus.Name = "cmbOrderStatus";
        cmbOrderStatus.Padding = new Padding(0, 0, 30, 2);
        cmbOrderStatus.Size = new Size(225, 38);
        cmbOrderStatus.SymbolSize = 24;
        cmbOrderStatus.TabIndex = 9;
        cmbOrderStatus.TextAlignment = ContentAlignment.MiddleLeft;
        cmbOrderStatus.Watermark = "";
        // 
        // btnUpdateOrderStatus
        // 
        btnUpdateOrderStatus.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnUpdateOrderStatus.Location = new Point(893, 9);
        btnUpdateOrderStatus.MinimumSize = new Size(1, 1);
        btnUpdateOrderStatus.Name = "btnUpdateOrderStatus";
        btnUpdateOrderStatus.Size = new Size(150, 38);
        btnUpdateOrderStatus.TabIndex = 6;
        btnUpdateOrderStatus.Text = "修改状态";
        btnUpdateOrderStatus.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnUpdateOrderStatus.Click += btnUpdateOrderStatus_Click;
        // 
        // layoutOrderMain
        // 
        layoutOrderMain.ColumnCount = 2;
        layoutOrderMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.17512F));
        layoutOrderMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.82488F));
        layoutOrderMain.Controls.Add(dgvOrders, 0, 0);
        layoutOrderMain.Controls.Add(grpOrderDetail, 1, 0);
        layoutOrderMain.Dock = DockStyle.Fill;
        layoutOrderMain.Location = new Point(3, 73);
        layoutOrderMain.Name = "layoutOrderMain";
        layoutOrderMain.RowCount = 1;
        layoutOrderMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutOrderMain.Size = new Size(1222, 370);
        layoutOrderMain.TabIndex = 1;
        layoutOrderMain.TagString = null;
        // 
        // dgvOrders
        // 
        dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
        dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
        dgvOrders.BackgroundColor = Color.White;
        dgvOrders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle7.ForeColor = Color.White;
        dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
        dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle8.BackColor = SystemColors.Window;
        dataGridViewCellStyle8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle8.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
        dgvOrders.DefaultCellStyle = dataGridViewCellStyle8;
        dgvOrders.Dock = DockStyle.Fill;
        dgvOrders.EnableHeadersVisualStyles = false;
        dgvOrders.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvOrders.GridColor = Color.FromArgb(80, 160, 255);
        dgvOrders.Location = new Point(3, 3);
        dgvOrders.Name = "dgvOrders";
        dgvOrders.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
        dataGridViewCellStyle9.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle9.SelectionForeColor = Color.White;
        dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
        dgvOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
        dgvOrders.RowHeadersWidth = 62;
        dataGridViewCellStyle10.BackColor = Color.White;
        dataGridViewCellStyle10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvOrders.RowsDefaultCellStyle = dataGridViewCellStyle10;
        dgvOrders.SelectedIndex = -1;
        dgvOrders.Size = new Size(766, 364);
        dgvOrders.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvOrders.TabIndex = 0;
        dgvOrders.CellClick += dgvOrders_CellClick;
        // 
        // grpOrderDetail
        // 
        grpOrderDetail.Controls.Add(lblCreatedAt);
        grpOrderDetail.Controls.Add(lblStatus);
        grpOrderDetail.Controls.Add(lblTotalAmount);
        grpOrderDetail.Controls.Add(lblDeliveryFee);
        grpOrderDetail.Controls.Add(lblNote);
        grpOrderDetail.Controls.Add(lblAddress);
        grpOrderDetail.Controls.Add(lblTableNumber);
        grpOrderDetail.Controls.Add(lblPhone);
        grpOrderDetail.Controls.Add(lblCustomerName);
        grpOrderDetail.Controls.Add(lblOrderType);
        grpOrderDetail.Controls.Add(lblOrderId);
        grpOrderDetail.Dock = DockStyle.Fill;
        grpOrderDetail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpOrderDetail.Location = new Point(776, 5);
        grpOrderDetail.Margin = new Padding(4, 5, 4, 5);
        grpOrderDetail.MinimumSize = new Size(1, 1);
        grpOrderDetail.Name = "grpOrderDetail";
        grpOrderDetail.Padding = new Padding(0, 32, 0, 0);
        grpOrderDetail.Size = new Size(442, 360);
        grpOrderDetail.TabIndex = 1;
        grpOrderDetail.Text = "订单详情";
        grpOrderDetail.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // lblCreatedAt
        // 
        lblCreatedAt.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblCreatedAt.ForeColor = Color.FromArgb(48, 48, 48);
        lblCreatedAt.Location = new Point(242, 210);
        lblCreatedAt.Name = "lblCreatedAt";
        lblCreatedAt.Size = new Size(189, 106);
        lblCreatedAt.TabIndex = 10;
        lblCreatedAt.Text = "创建时间：";
        // 
        // lblStatus
        // 
        lblStatus.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblStatus.ForeColor = Color.FromArgb(48, 48, 48);
        lblStatus.Location = new Point(242, 142);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(189, 34);
        lblStatus.TabIndex = 9;
        lblStatus.Text = "状态：";
        // 
        // lblTotalAmount
        // 
        lblTotalAmount.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblTotalAmount.ForeColor = Color.FromArgb(48, 48, 48);
        lblTotalAmount.Location = new Point(242, 38);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(189, 34);
        lblTotalAmount.TabIndex = 8;
        lblTotalAmount.Text = "总金额：";
        // 
        // lblDeliveryFee
        // 
        lblDeliveryFee.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblDeliveryFee.ForeColor = Color.FromArgb(48, 48, 48);
        lblDeliveryFee.Location = new Point(3, 282);
        lblDeliveryFee.Name = "lblDeliveryFee";
        lblDeliveryFee.Size = new Size(233, 34);
        lblDeliveryFee.TabIndex = 7;
        lblDeliveryFee.Text = "配送费：";
        // 
        // lblNote
        // 
        lblNote.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblNote.ForeColor = Color.FromArgb(48, 48, 48);
        lblNote.Location = new Point(3, 244);
        lblNote.Name = "lblNote";
        lblNote.Size = new Size(233, 34);
        lblNote.TabIndex = 6;
        lblNote.Text = "备注：";
        // 
        // lblAddress
        // 
        lblAddress.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblAddress.ForeColor = Color.FromArgb(48, 48, 48);
        lblAddress.Location = new Point(3, 210);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(233, 34);
        lblAddress.TabIndex = 5;
        lblAddress.Text = "配送地址：";
        // 
        // lblTableNumber
        // 
        lblTableNumber.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblTableNumber.ForeColor = Color.FromArgb(48, 48, 48);
        lblTableNumber.Location = new Point(3, 176);
        lblTableNumber.Name = "lblTableNumber";
        lblTableNumber.Size = new Size(233, 34);
        lblTableNumber.TabIndex = 4;
        lblTableNumber.Text = "桌号：";
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblPhone.ForeColor = Color.FromArgb(48, 48, 48);
        lblPhone.Location = new Point(3, 142);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(233, 34);
        lblPhone.TabIndex = 3;
        lblPhone.Text = "电话：";
        // 
        // lblCustomerName
        // 
        lblCustomerName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblCustomerName.ForeColor = Color.FromArgb(48, 48, 48);
        lblCustomerName.Location = new Point(3, 108);
        lblCustomerName.Name = "lblCustomerName";
        lblCustomerName.Size = new Size(233, 34);
        lblCustomerName.TabIndex = 2;
        lblCustomerName.Text = "顾客姓名：";
        // 
        // lblOrderType
        // 
        lblOrderType.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblOrderType.ForeColor = Color.FromArgb(48, 48, 48);
        lblOrderType.Location = new Point(3, 72);
        lblOrderType.Name = "lblOrderType";
        lblOrderType.Size = new Size(233, 34);
        lblOrderType.TabIndex = 1;
        lblOrderType.Text = "订单类型：";
        // 
        // lblOrderId
        // 
        lblOrderId.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblOrderId.ForeColor = Color.FromArgb(48, 48, 48);
        lblOrderId.Location = new Point(3, 38);
        lblOrderId.Name = "lblOrderId";
        lblOrderId.Size = new Size(233, 34);
        lblOrderId.TabIndex = 0;
        lblOrderId.Text = "订单编号：";
        // 
        // grpOrderItems
        // 
        grpOrderItems.Controls.Add(dgvOrderItems);
        grpOrderItems.Dock = DockStyle.Fill;
        grpOrderItems.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpOrderItems.Location = new Point(4, 451);
        grpOrderItems.Margin = new Padding(4, 5, 4, 5);
        grpOrderItems.MinimumSize = new Size(1, 1);
        grpOrderItems.Name = "grpOrderItems";
        grpOrderItems.Padding = new Padding(0, 32, 0, 0);
        grpOrderItems.Size = new Size(1220, 193);
        grpOrderItems.TabIndex = 2;
        grpOrderItems.Text = "订单明细";
        grpOrderItems.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // dgvOrderItems
        // 
        dataGridViewCellStyle11.BackColor = Color.FromArgb(235, 243, 255);
        dgvOrderItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
        dgvOrderItems.BackgroundColor = Color.White;
        dgvOrderItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle12.BackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle12.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle12.ForeColor = Color.White;
        dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
        dgvOrderItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
        dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle13.BackColor = SystemColors.Window;
        dataGridViewCellStyle13.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle13.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
        dgvOrderItems.DefaultCellStyle = dataGridViewCellStyle13;
        dgvOrderItems.Dock = DockStyle.Fill;
        dgvOrderItems.EnableHeadersVisualStyles = false;
        dgvOrderItems.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvOrderItems.GridColor = Color.FromArgb(80, 160, 255);
        dgvOrderItems.Location = new Point(0, 32);
        dgvOrderItems.Name = "dgvOrderItems";
        dgvOrderItems.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle14.BackColor = Color.FromArgb(235, 243, 255);
        dataGridViewCellStyle14.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle14.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle14.SelectionForeColor = Color.White;
        dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
        dgvOrderItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
        dgvOrderItems.RowHeadersWidth = 62;
        dataGridViewCellStyle15.BackColor = Color.White;
        dataGridViewCellStyle15.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvOrderItems.RowsDefaultCellStyle = dataGridViewCellStyle15;
        dgvOrderItems.SelectedIndex = -1;
        dgvOrderItems.Size = new Size(1220, 161);
        dgvOrderItems.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvOrderItems.TabIndex = 0;
        // 
        // tabStatistics
        // 
        tabStatistics.Location = new Point(0, 40);
        tabStatistics.Name = "tabStatistics";
        tabStatistics.Size = new Size(200, 60);
        tabStatistics.TabIndex = 2;
        tabStatistics.Text = "统计分析";
        tabStatistics.UseVisualStyleBackColor = true;
        // 
        // tabAi
        // 
        tabAi.Location = new Point(0, 40);
        tabAi.Name = "tabAi";
        tabAi.Size = new Size(200, 60);
        tabAi.TabIndex = 3;
        tabAi.Text = "AI建议";
        tabAi.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(1228, 724);
        Controls.Add(tabMain);
        Font = new Font("Microsoft YaHei UI", 10F);
        MinimumSize = new Size(1089, 724);
        Name = "Form1";
        Text = "珞珈线上点餐系统-管理员端";
        ZoomScaleRect = new Rectangle(22, 22, 1228, 724);
        tabMain.ResumeLayout(false);
        tabDishes.ResumeLayout(false);
        layoutDishPage.ResumeLayout(false);
        grpDishEdit.ResumeLayout(false);
        layoutDishEdit.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvDishes).EndInit();
        tabOrders.ResumeLayout(false);
        layoutOrderPage.ResumeLayout(false);
        panelOrderTop.ResumeLayout(false);
        layoutOrderMain.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        grpOrderDetail.ResumeLayout(false);
        grpOrderItems.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
        ResumeLayout(false);
    }
    private Sunny.UI.UITabControl tabMain;
    private TabPage tabDishes;
    private TabPage tabOrders;
    private Sunny.UI.UIButton btnDeleteDish;
    private Sunny.UI.UIButton btnUpdateDish;
    private Sunny.UI.UIButton btnAddDish;
    private Sunny.UI.UIButton btnLoadDishes;
    private TabPage tabStatistics;
    private TabPage tabAi;
    private Sunny.UI.UITextBox txtPrice;
    private Sunny.UI.UITextBox txtCategory;
    private Sunny.UI.UIDataGridView dgvDishes;
    private Sunny.UI.UITableLayoutPanel layoutDishPage;
    private Sunny.UI.UIGroupBox grpDishEdit;
    private Sunny.UI.UITableLayoutPanel layoutDishEdit;
    private Sunny.UI.UITextBox txtDishName;
    private Sunny.UI.UILabel uiLabel1;
    private Sunny.UI.UILabel uiLabel3;
    private Sunny.UI.UILabel uiLabel2;
    private Sunny.UI.UITableLayoutPanel layoutOrderPage;
    private Sunny.UI.UIFlowLayoutPanel panelOrderTop;
    private Sunny.UI.UIButton btnUpdateOrderStatus;
    private Sunny.UI.UIComboBox cmbOrderStatus;
    private Sunny.UI.UILabel changeOrder;
    private Sunny.UI.UIButton btnLoadOrders;
    private Sunny.UI.UITableLayoutPanel layoutOrderMain;
    private Sunny.UI.UIDataGridView dgvOrders;
    private Sunny.UI.UIGroupBox grpOrderDetail;
    private Sunny.UI.UILabel uiLabel15;
    private Sunny.UI.UILabel lblCreatedAt;
    private Sunny.UI.UILabel lblStatus;
    private Sunny.UI.UILabel lblTotalAmount;
    private Sunny.UI.UILabel lblDeliveryFee;
    private Sunny.UI.UILabel lblNote;
    private Sunny.UI.UILabel lblAddress;
    private Sunny.UI.UILabel lblTableNumber;
    private Sunny.UI.UILabel lblPhone;
    private Sunny.UI.UILabel lblCustomerName;
    private Sunny.UI.UILabel lblOrderType;
    private Sunny.UI.UILabel lblOrderId;
    private Sunny.UI.UIGroupBox grpOrderItems;
    private Sunny.UI.UIDataGridView dgvOrderItems;
}
