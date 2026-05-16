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
        DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle33 = new DataGridViewCellStyle();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        tabMain = new Sunny.UI.UITabControl();
        tabDishes = new TabPage();
        layoutDishPage = new Sunny.UI.UITableLayoutPanel();
        grpDishEdit = new Sunny.UI.UIGroupBox();
        layoutDishEdit = new Sunny.UI.UITableLayoutPanel();
        uiLabel3 = new Sunny.UI.UILabel();
        txtDishName = new Sunny.UI.UITextBox();
        uiLabel1 = new Sunny.UI.UILabel();
        txtCategory = new Sunny.UI.UITextBox();
        uiLabel2 = new Sunny.UI.UILabel();
        txtPrice = new Sunny.UI.UITextBox();
        cmbDishCategory = new Sunny.UI.UIComboBox();
        lblImagePath = new Sunny.UI.UILabel();
        txtImagePath = new Sunny.UI.UITextBox();
        btnChooseImage = new Sunny.UI.UIButton();
        chkIsAvailable = new Sunny.UI.UICheckBox();
        lblDescription = new Sunny.UI.UILabel();
        txtDescription = new Sunny.UI.UITextBox();
        picDishImage = new PictureBox();
        btnAddDish = new Sunny.UI.UIButton();
        btnUpdateDish = new Sunny.UI.UIButton();
        btnDeleteDish = new Sunny.UI.UIButton();
        lblPicture = new Sunny.UI.UILabel();
        lblSpicyCondition = new Sunny.UI.UILabel();
        cmbSpicyLevel = new Sunny.UI.UIComboBox();
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
        panelOrderActions = new Sunny.UI.UIFlowLayoutPanel();
        lblOrderActionHint = new Sunny.UI.UILabel();
        btnConfirmOrder = new Sunny.UI.UIButton();
        btnRejectOrder = new Sunny.UI.UIButton();
        btnStartPreparing = new Sunny.UI.UIButton();
        btnReady = new Sunny.UI.UIButton();
        btnStartDelivery = new Sunny.UI.UIButton();
        btnCompleteOrder = new Sunny.UI.UIButton();
        btnCancelOrder = new Sunny.UI.UIButton();
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
        layoutStatisticsPage = new Sunny.UI.UITableLayoutPanel();
        layoutStatisticsTop = new Sunny.UI.UITableLayoutPanel();
        uiLabel4 = new Sunny.UI.UILabel();
        dtpStatisticsStart = new Sunny.UI.UIDatePicker();
        lblTopCountTitle = new Sunny.UI.UILabel();
        dtpStatisticsEnd = new Sunny.UI.UIDatePicker();
        btnResetStatistics = new Sunny.UI.UIButton();
        uiLabel5 = new Sunny.UI.UILabel();
        txtTopCount = new Sunny.UI.UITextBox();
        btnLoadStatistics = new Sunny.UI.UIButton();
        layoutStatisticsSummary = new Sunny.UI.UITableLayoutPanel();
        grpTotalOrders = new Sunny.UI.UIGroupBox();
        lblTotalOrders = new Sunny.UI.UILabel();
        grpTotalRevenue = new Sunny.UI.UIGroupBox();
        lblTotalRevenue = new Sunny.UI.UILabel();
        grpTopDishCount = new Sunny.UI.UIGroupBox();
        lblTopDishCount = new Sunny.UI.UILabel();
        grpAverageOrderAmount = new Sunny.UI.UIGroupBox();
        lblAverageOrderAmount = new Sunny.UI.UILabel();
        layoutStatisticsMain = new Sunny.UI.UITableLayoutPanel();
        grpTopDishes = new Sunny.UI.UIGroupBox();
        dgvTopDishes = new Sunny.UI.UIDataGridView();
        grpTopDishesChart = new Sunny.UI.UIGroupBox();
        panelTopDishesChart = new Sunny.UI.UIPanel();
        lblChartPlaceholder = new Sunny.UI.UILabel();
        grpRevenueStatistics = new Sunny.UI.UIGroupBox();
        dgvRevenueStatistics = new Sunny.UI.UIDataGridView();
        grpStatisticsRemark = new Sunny.UI.UIGroupBox();
        txtStatisticsRemark = new Sunny.UI.UITextBox();
        tabAi = new TabPage();
        layoutAiPage = new Sunny.UI.UITableLayoutPanel();
        layoutAiTop = new Sunny.UI.UITableLayoutPanel();
        btnLoadAiSuggestion = new Sunny.UI.UIButton();
        lblAiHint = new Sunny.UI.UILabel();
        grpAiSuggestion = new Sunny.UI.UIGroupBox();
        txtAiSuggestion = new Sunny.UI.UITextBox();
        grpAiError = new Sunny.UI.UIGroupBox();
        txtAiError = new Sunny.UI.UITextBox();
        tabDeliveryZones = new TabPage();
        layoutDeliveryZonesPage = new Sunny.UI.UITableLayoutPanel();
        panelDeliveryZoneTop = new Sunny.UI.UIFlowLayoutPanel();
        btnLoadDeliveryZones = new Sunny.UI.UIButton();
        dgvDeliveryZones = new Sunny.UI.UIDataGridView();
        grpDeliveryZoneEditor = new Sunny.UI.UIGroupBox();
        layoutDeliveryZoneEditor = new Sunny.UI.UITableLayoutPanel();
        lblZoneProvince = new Sunny.UI.UILabel();
        txtZoneProvince = new Sunny.UI.UITextBox();
        lblZoneCity = new Sunny.UI.UILabel();
        txtZoneCity = new Sunny.UI.UITextBox();
        lblZoneDistrict = new Sunny.UI.UILabel();
        txtZoneDistrict = new Sunny.UI.UITextBox();
        lblZoneFee = new Sunny.UI.UILabel();
        txtZoneFee = new Sunny.UI.UITextBox();
        lblZoneSortOrder = new Sunny.UI.UILabel();
        txtZoneSortOrder = new Sunny.UI.UITextBox();
        chkZoneIsActive = new Sunny.UI.UICheckBox();
        panelDeliveryZoneActions = new Sunny.UI.UIFlowLayoutPanel();
        btnAddDeliveryZone = new Sunny.UI.UIButton();
        btnUpdateDeliveryZone = new Sunny.UI.UIButton();
        btnDeleteDeliveryZone = new Sunny.UI.UIButton();
        tabDiningTables = new TabPage();
        layoutDiningTablesPage = new Sunny.UI.UITableLayoutPanel();
        panelDiningTableTop = new Sunny.UI.UIFlowLayoutPanel();
        btnLoadDiningTables = new Sunny.UI.UIButton();
        dgvDiningTables = new Sunny.UI.UIDataGridView();
        grpDiningTableEditor = new Sunny.UI.UIGroupBox();
        layoutDiningTableEditor = new Sunny.UI.UITableLayoutPanel();
        lblDiningTableNumber = new Sunny.UI.UILabel();
        txtDiningTableNumber = new Sunny.UI.UITextBox();
        lblDiningTableSeats = new Sunny.UI.UILabel();
        txtDiningTableSeats = new Sunny.UI.UITextBox();
        chkDiningTableOccupied = new Sunny.UI.UICheckBox();
        chkDiningTableEnabled = new Sunny.UI.UICheckBox();
        panelDiningTableActions = new Sunny.UI.UIFlowLayoutPanel();
        btnAddDiningTable = new Sunny.UI.UIButton();
        btnUpdateDiningTable = new Sunny.UI.UIButton();
        btnDeleteDiningTable = new Sunny.UI.UIButton();
        tabUsers = new TabPage();
        layoutUsersPage = new Sunny.UI.UITableLayoutPanel();
        panelUsersTop = new Sunny.UI.UIFlowLayoutPanel();
        btnLoadUsers = new Sunny.UI.UIButton();
        dgvUsers = new Sunny.UI.UIDataGridView();
        grpUserEditor = new Sunny.UI.UIGroupBox();
        layoutUserEditor = new Sunny.UI.UITableLayoutPanel();
        lblUsername = new Sunny.UI.UILabel();
        txtUsername = new Sunny.UI.UITextBox();
        lblRealName = new Sunny.UI.UILabel();
        txtRealName = new Sunny.UI.UITextBox();
        lblUserPhone = new Sunny.UI.UILabel();
        txtUserPhone = new Sunny.UI.UITextBox();
        lblUserAddress = new Sunny.UI.UILabel();
        txtUserAddress = new Sunny.UI.UITextBox();
        chkIsActive = new Sunny.UI.UICheckBox();
        panelUserActions = new Sunny.UI.UIFlowLayoutPanel();
        btnAddUser = new Sunny.UI.UIButton();
        btnUpdateUser = new Sunny.UI.UIButton();
        btnDeleteUser = new Sunny.UI.UIButton();
        btnResetPassword = new Sunny.UI.UIButton();
        tabMain.SuspendLayout();
        tabDishes.SuspendLayout();
        layoutDishPage.SuspendLayout();
        grpDishEdit.SuspendLayout();
        layoutDishEdit.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picDishImage).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvDishes).BeginInit();
        tabOrders.SuspendLayout();
        layoutOrderPage.SuspendLayout();
        panelOrderTop.SuspendLayout();
        layoutOrderMain.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        grpOrderDetail.SuspendLayout();
        grpOrderItems.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
        tabStatistics.SuspendLayout();
        layoutStatisticsPage.SuspendLayout();
        layoutStatisticsTop.SuspendLayout();
        layoutStatisticsSummary.SuspendLayout();
        grpTotalOrders.SuspendLayout();
        grpTotalRevenue.SuspendLayout();
        grpTopDishCount.SuspendLayout();
        grpAverageOrderAmount.SuspendLayout();
        layoutStatisticsMain.SuspendLayout();
        grpTopDishes.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTopDishes).BeginInit();
        grpTopDishesChart.SuspendLayout();
        panelTopDishesChart.SuspendLayout();
        grpRevenueStatistics.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRevenueStatistics).BeginInit();
        grpStatisticsRemark.SuspendLayout();
        tabAi.SuspendLayout();
        layoutAiPage.SuspendLayout();
        layoutAiTop.SuspendLayout();
        grpAiSuggestion.SuspendLayout();
        grpAiError.SuspendLayout();
        tabDeliveryZones.SuspendLayout();
        layoutDeliveryZonesPage.SuspendLayout();
        panelDeliveryZoneTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDeliveryZones).BeginInit();
        grpDeliveryZoneEditor.SuspendLayout();
        layoutDeliveryZoneEditor.SuspendLayout();
        panelDeliveryZoneActions.SuspendLayout();
        tabDiningTables.SuspendLayout();
        layoutDiningTablesPage.SuspendLayout();
        panelDiningTableTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDiningTables).BeginInit();
        grpDiningTableEditor.SuspendLayout();
        layoutDiningTableEditor.SuspendLayout();
        panelDiningTableActions.SuspendLayout();
        tabUsers.SuspendLayout();
        layoutUsersPage.SuspendLayout();
        panelUsersTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
        grpUserEditor.SuspendLayout();
        layoutUserEditor.SuspendLayout();
        panelUserActions.SuspendLayout();
        SuspendLayout();
        // 
        // tabMain
        // 
        tabMain.Controls.Add(tabDishes);
        tabMain.Controls.Add(tabOrders);
        tabMain.Controls.Add(tabStatistics);
        tabMain.Controls.Add(tabAi);
        tabMain.Controls.Add(tabDeliveryZones);
        tabMain.Controls.Add(tabDiningTables);
        tabMain.Controls.Add(tabUsers);
        tabMain.Dock = DockStyle.Fill;
        tabMain.DrawMode = TabDrawMode.OwnerDrawFixed;
        tabMain.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        tabMain.ItemSize = new Size(150, 40);
        tabMain.Location = new Point(2, 36);
        tabMain.MainPage = "";
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 0;
        tabMain.Size = new Size(1224, 686);
        tabMain.SizeMode = TabSizeMode.Fixed;
        tabMain.TabIndex = 0;
        tabMain.TabUnSelectedForeColor = Color.FromArgb(240, 240, 240);
        tabMain.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        tabMain.SelectedIndexChanged += tabMain_SelectedIndexChanged;
        // 
        // tabDishes
        // 
        tabDishes.Controls.Add(layoutDishPage);
        tabDishes.Location = new Point(0, 40);
        tabDishes.Name = "tabDishes";
        tabDishes.Size = new Size(1224, 646);
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
        layoutDishPage.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
        layoutDishPage.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
        layoutDishPage.Size = new Size(1224, 646);
        layoutDishPage.TabIndex = 8;
        layoutDishPage.TagString = null;
        // 
        // grpDishEdit
        // 
        grpDishEdit.Controls.Add(layoutDishEdit);
        grpDishEdit.Dock = DockStyle.Fill;
        grpDishEdit.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpDishEdit.Location = new Point(10, 304);
        grpDishEdit.Margin = new Padding(10);
        grpDishEdit.MinimumSize = new Size(1, 1);
        grpDishEdit.Name = "grpDishEdit";
        grpDishEdit.Padding = new Padding(0, 32, 0, 0);
        grpDishEdit.Size = new Size(1204, 332);
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
        layoutDishEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 163F));
        layoutDishEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.5789471F));
        layoutDishEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
        layoutDishEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.8421059F));
        layoutDishEdit.Controls.Add(uiLabel3, 4, 0);
        layoutDishEdit.Controls.Add(txtDishName, 1, 0);
        layoutDishEdit.Controls.Add(uiLabel1, 0, 0);
        layoutDishEdit.Controls.Add(txtCategory, 3, 0);
        layoutDishEdit.Controls.Add(uiLabel2, 2, 0);
        layoutDishEdit.Controls.Add(txtPrice, 5, 0);
        layoutDishEdit.Controls.Add(cmbDishCategory, 3, 0);
        layoutDishEdit.Controls.Add(lblImagePath, 0, 1);
        layoutDishEdit.Controls.Add(txtImagePath, 1, 1);
        layoutDishEdit.Controls.Add(btnChooseImage, 4, 1);
        layoutDishEdit.Controls.Add(chkIsAvailable, 5, 1);
        layoutDishEdit.Controls.Add(lblDescription, 0, 3);
        layoutDishEdit.Controls.Add(txtDescription, 1, 3);
        layoutDishEdit.Controls.Add(picDishImage, 4, 3);
        layoutDishEdit.Controls.Add(btnAddDish, 0, 4);
        layoutDishEdit.Controls.Add(btnUpdateDish, 1, 4);
        layoutDishEdit.Controls.Add(btnDeleteDish, 2, 4);
        layoutDishEdit.Controls.Add(lblPicture, 4, 2);
        layoutDishEdit.Controls.Add(lblSpicyCondition, 0, 2);
        layoutDishEdit.Controls.Add(cmbSpicyLevel, 1, 2);
        layoutDishEdit.Location = new Point(58, 30);
        layoutDishEdit.Name = "layoutDishEdit";
        layoutDishEdit.RowCount = 5;
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 61F));
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        layoutDishEdit.Size = new Size(1105, 299);
        layoutDishEdit.TabIndex = 0;
        layoutDishEdit.TagString = null;
        // 
        // uiLabel3
        // 
        uiLabel3.Anchor = AnchorStyles.None;
        uiLabel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
        uiLabel3.Location = new Point(958, 9);
        uiLabel3.Name = "uiLabel3";
        uiLabel3.Size = new Size(83, 34);
        uiLabel3.TabIndex = 9;
        uiLabel3.Text = "价格：";
        // 
        // txtDishName
        // 
        txtDishName.Anchor = AnchorStyles.None;
        txtDishName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtDishName.Location = new Point(182, 5);
        txtDishName.Margin = new Padding(4, 5, 4, 5);
        txtDishName.MinimumSize = new Size(1, 16);
        txtDishName.Name = "txtDishName";
        txtDishName.Padding = new Padding(5);
        txtDishName.ShowText = false;
        txtDishName.Size = new Size(140, 42);
        txtDishName.TabIndex = 7;
        txtDishName.TextAlignment = ContentAlignment.MiddleLeft;
        txtDishName.Watermark = "";
        // 
        // uiLabel1
        // 
        uiLabel1.Anchor = AnchorStyles.None;
        uiLabel1.Font = new Font("宋体", 12F);
        uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
        uiLabel1.Location = new Point(15, 9);
        uiLabel1.Name = "uiLabel1";
        uiLabel1.Size = new Size(132, 34);
        uiLabel1.TabIndex = 8;
        uiLabel1.Text = "菜品名称：";
        // 
        // txtCategory
        // 
        txtCategory.Anchor = AnchorStyles.None;
        txtCategory.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtCategory.Location = new Point(718, 5);
        txtCategory.Margin = new Padding(4, 5, 4, 5);
        txtCategory.MinimumSize = new Size(1, 16);
        txtCategory.Name = "txtCategory";
        txtCategory.Padding = new Padding(5);
        txtCategory.ShowText = false;
        txtCategory.Size = new Size(142, 42);
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
        uiLabel2.Location = new Point(376, 9);
        uiLabel2.Name = "uiLabel2";
        uiLabel2.Size = new Size(94, 34);
        uiLabel2.TabIndex = 9;
        uiLabel2.Text = "分类：";
        // 
        // txtPrice
        // 
        txtPrice.Anchor = AnchorStyles.None;
        txtPrice.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtPrice.Location = new Point(7, 76);
        txtPrice.Margin = new Padding(4, 5, 4, 5);
        txtPrice.MinimumSize = new Size(1, 16);
        txtPrice.Name = "txtPrice";
        txtPrice.Padding = new Padding(5);
        txtPrice.ShowText = false;
        txtPrice.Size = new Size(149, 42);
        txtPrice.TabIndex = 7;
        txtPrice.TextAlignment = ContentAlignment.MiddleLeft;
        txtPrice.Watermark = "";
        // 
        // cmbDishCategory
        // 
        cmbDishCategory.Anchor = AnchorStyles.None;
        cmbDishCategory.DataSource = null;
        cmbDishCategory.FillColor = Color.White;
        cmbDishCategory.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        cmbDishCategory.ItemHoverColor = Color.FromArgb(155, 200, 255);
        cmbDishCategory.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
        cmbDishCategory.Location = new Point(523, 5);
        cmbDishCategory.Margin = new Padding(4, 5, 4, 5);
        cmbDishCategory.MinimumSize = new Size(1, 16);
        cmbDishCategory.Name = "cmbDishCategory";
        cmbDishCategory.Padding = new Padding(0, 0, 30, 2);
        cmbDishCategory.Size = new Size(142, 42);
        cmbDishCategory.SymbolSize = 24;
        cmbDishCategory.TabIndex = 20;
        cmbDishCategory.TextAlignment = ContentAlignment.MiddleLeft;
        cmbDishCategory.Watermark = "";
        // 
        // lblImagePath
        // 
        lblImagePath.Anchor = AnchorStyles.None;
        lblImagePath.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblImagePath.ForeColor = Color.FromArgb(48, 48, 48);
        lblImagePath.Location = new Point(177, 80);
        lblImagePath.Name = "lblImagePath";
        lblImagePath.Size = new Size(150, 34);
        lblImagePath.TabIndex = 10;
        lblImagePath.Text = "图片路径：";
        lblImagePath.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // txtImagePath
        // 
        txtImagePath.Anchor = AnchorStyles.None;
        layoutDishEdit.SetColumnSpan(txtImagePath, 3);
        txtImagePath.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtImagePath.Location = new Point(361, 75);
        txtImagePath.Margin = new Padding(4, 5, 4, 5);
        txtImagePath.MinimumSize = new Size(1, 16);
        txtImagePath.Name = "txtImagePath";
        txtImagePath.Padding = new Padding(5);
        txtImagePath.ShowText = false;
        txtImagePath.Size = new Size(513, 44);
        txtImagePath.TabIndex = 11;
        txtImagePath.Text = "空";
        txtImagePath.TextAlignment = ContentAlignment.MiddleLeft;
        txtImagePath.Watermark = "";
        // 
        // btnChooseImage
        // 
        btnChooseImage.Anchor = AnchorStyles.None;
        btnChooseImage.FillColor = Color.FromArgb(51, 122, 183);
        btnChooseImage.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnChooseImage.Location = new Point(924, 71);
        btnChooseImage.MinimumSize = new Size(1, 1);
        btnChooseImage.Name = "btnChooseImage";
        btnChooseImage.Radius = 8;
        btnChooseImage.RectColor = Color.FromArgb(51, 122, 183);
        btnChooseImage.Size = new Size(150, 52);
        btnChooseImage.TabIndex = 12;
        btnChooseImage.Text = "选择图片";
        btnChooseImage.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnChooseImage.Click += btnChooseImage_Click;
        // 
        // chkIsAvailable
        // 
        chkIsAvailable.Anchor = AnchorStyles.None;
        chkIsAvailable.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        chkIsAvailable.ForeColor = Color.FromArgb(48, 48, 48);
        chkIsAvailable.Location = new Point(3, 146);
        chkIsAvailable.MinimumSize = new Size(1, 1);
        chkIsAvailable.Name = "chkIsAvailable";
        chkIsAvailable.Size = new Size(157, 35);
        chkIsAvailable.TabIndex = 13;
        chkIsAvailable.Text = "是否可售";
        // 
        // lblDescription
        // 
        lblDescription.Anchor = AnchorStyles.None;
        lblDescription.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblDescription.ForeColor = Color.FromArgb(48, 48, 48);
        lblDescription.Location = new Point(6, 197);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(150, 34);
        lblDescription.TabIndex = 16;
        lblDescription.Text = "描述：";
        lblDescription.TextAlign = ContentAlignment.MiddleCenter;
        lblDescription.Click += lblDescription_Click;
        // 
        // txtDescription
        // 
        txtDescription.Anchor = AnchorStyles.None;
        layoutDishEdit.SetColumnSpan(txtDescription, 3);
        txtDescription.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtDescription.Location = new Point(167, 189);
        txtDescription.Margin = new Padding(4, 5, 4, 5);
        txtDescription.MinimumSize = new Size(1, 16);
        txtDescription.Multiline = true;
        txtDescription.Name = "txtDescription";
        txtDescription.Padding = new Padding(5);
        txtDescription.ShowScrollBar = true;
        txtDescription.ShowText = false;
        txtDescription.Size = new Size(513, 51);
        txtDescription.TabIndex = 17;
        txtDescription.Text = "空";
        txtDescription.TextAlignment = ContentAlignment.MiddleLeft;
        txtDescription.Watermark = "";
        // 
        // picDishImage
        // 
        picDishImage.Anchor = AnchorStyles.None;
        picDishImage.BorderStyle = BorderStyle.FixedSingle;
        layoutDishEdit.SetColumnSpan(picDishImage, 2);
        picDishImage.Location = new Point(766, 190);
        picDishImage.Name = "picDishImage";
        layoutDishEdit.SetRowSpan(picDishImage, 2);
        picDishImage.Size = new Size(257, 103);
        picDishImage.SizeMode = PictureBoxSizeMode.Zoom;
        picDishImage.TabIndex = 18;
        picDishImage.TabStop = false;
        picDishImage.Click += picDishImage_Click;
        // 
        // btnAddDish
        // 
        btnAddDish.Anchor = AnchorStyles.None;
        btnAddDish.FillColor = Color.FromArgb(51, 122, 183);
        btnAddDish.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnAddDish.Location = new Point(6, 248);
        btnAddDish.MinimumSize = new Size(1, 1);
        btnAddDish.Name = "btnAddDish";
        btnAddDish.Radius = 8;
        btnAddDish.RectColor = Color.FromArgb(51, 122, 183);
        btnAddDish.Size = new Size(150, 48);
        btnAddDish.TabIndex = 1;
        btnAddDish.Text = "添加按钮";
        btnAddDish.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnAddDish.Click += btnAddDish_Click;
        // 
        // btnUpdateDish
        // 
        btnUpdateDish.Anchor = AnchorStyles.None;
        btnUpdateDish.FillColor = Color.FromArgb(51, 122, 183);
        btnUpdateDish.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnUpdateDish.Location = new Point(177, 248);
        btnUpdateDish.MinimumSize = new Size(1, 1);
        btnUpdateDish.Name = "btnUpdateDish";
        btnUpdateDish.Radius = 8;
        btnUpdateDish.RectColor = Color.FromArgb(51, 122, 183);
        btnUpdateDish.Size = new Size(150, 48);
        btnUpdateDish.TabIndex = 2;
        btnUpdateDish.Text = "修改按钮";
        btnUpdateDish.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnUpdateDish.Click += btnUpdateDish_Click;
        // 
        // btnDeleteDish
        // 
        btnDeleteDish.Anchor = AnchorStyles.None;
        btnDeleteDish.FillColor = Color.FromArgb(211, 47, 47);
        btnDeleteDish.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnDeleteDish.Location = new Point(351, 248);
        btnDeleteDish.MinimumSize = new Size(1, 1);
        btnDeleteDish.Name = "btnDeleteDish";
        btnDeleteDish.Radius = 8;
        btnDeleteDish.RectColor = Color.FromArgb(211, 47, 47);
        btnDeleteDish.Size = new Size(144, 48);
        btnDeleteDish.TabIndex = 3;
        btnDeleteDish.Text = "删除按钮";
        btnDeleteDish.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnDeleteDish.Click += btnDeleteDish_Click;
        // 
        // lblPicture
        // 
        lblPicture.Anchor = AnchorStyles.None;
        layoutDishEdit.SetColumnSpan(lblPicture, 2);
        lblPicture.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblPicture.ForeColor = Color.FromArgb(48, 48, 48);
        lblPicture.Location = new Point(819, 146);
        lblPicture.Name = "lblPicture";
        lblPicture.Size = new Size(150, 34);
        lblPicture.TabIndex = 19;
        lblPicture.Text = "图片预览：";
        lblPicture.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSpicyCondition
        // 
        lblSpicyCondition.Anchor = AnchorStyles.None;
        lblSpicyCondition.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblSpicyCondition.ForeColor = Color.FromArgb(48, 48, 48);
        lblSpicyCondition.Location = new Point(186, 146);
        lblSpicyCondition.Name = "lblSpicyCondition";
        lblSpicyCondition.Size = new Size(133, 34);
        lblSpicyCondition.TabIndex = 14;
        lblSpicyCondition.Text = "辣度：";
        lblSpicyCondition.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // cmbSpicyLevel
        // 
        cmbSpicyLevel.Anchor = AnchorStyles.None;
        cmbSpicyLevel.DataSource = null;
        cmbSpicyLevel.FillColor = Color.White;
        cmbSpicyLevel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        cmbSpicyLevel.ItemHoverColor = Color.FromArgb(155, 200, 255);
        cmbSpicyLevel.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
        cmbSpicyLevel.Location = new Point(346, 148);
        cmbSpicyLevel.Margin = new Padding(4, 5, 4, 5);
        cmbSpicyLevel.MinimumSize = new Size(63, 0);
        cmbSpicyLevel.Name = "cmbSpicyLevel";
        cmbSpicyLevel.Padding = new Padding(0, 0, 30, 2);
        cmbSpicyLevel.Size = new Size(155, 31);
        cmbSpicyLevel.SymbolSize = 24;
        cmbSpicyLevel.TabIndex = 15;
        cmbSpicyLevel.Text = "空";
        cmbSpicyLevel.TextAlignment = ContentAlignment.MiddleLeft;
        cmbSpicyLevel.Watermark = "";
        // 
        // btnLoadDishes
        // 
        btnLoadDishes.Anchor = AnchorStyles.None;
        btnLoadDishes.FillColor = Color.FromArgb(51, 122, 183);
        btnLoadDishes.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnLoadDishes.Location = new Point(557, 12);
        btnLoadDishes.MinimumSize = new Size(1, 1);
        btnLoadDishes.Name = "btnLoadDishes";
        btnLoadDishes.Radius = 8;
        btnLoadDishes.RectColor = Color.FromArgb(51, 122, 183);
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
        dgvDishes.Size = new Size(1200, 224);
        dgvDishes.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvDishes.TabIndex = 4;
        dgvDishes.CellClick += dgvDishes_CellClick;
        // 
        // tabOrders
        // 
        tabOrders.Controls.Add(layoutOrderPage);
        tabOrders.Location = new Point(0, 40);
        tabOrders.Name = "tabOrders";
        tabOrders.Size = new Size(1224, 646);
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
        layoutOrderPage.Size = new Size(1224, 646);
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
        panelOrderTop.Size = new Size(1216, 60);
        panelOrderTop.TabIndex = 0;
        panelOrderTop.Text = "uiFlowLayoutPanel1";
        panelOrderTop.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // btnLoadOrders
        // 
        btnLoadOrders.FillColor = Color.FromArgb(51, 122, 183);
        btnLoadOrders.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnLoadOrders.Location = new Point(38, 9);
        btnLoadOrders.MinimumSize = new Size(1, 1);
        btnLoadOrders.Name = "btnLoadOrders";
        btnLoadOrders.Radius = 8;
        btnLoadOrders.RectColor = Color.FromArgb(51, 122, 183);
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
        btnUpdateOrderStatus.FillColor = Color.FromArgb(51, 122, 183);
        btnUpdateOrderStatus.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnUpdateOrderStatus.Location = new Point(893, 9);
        btnUpdateOrderStatus.MinimumSize = new Size(1, 1);
        btnUpdateOrderStatus.Name = "btnUpdateOrderStatus";
        btnUpdateOrderStatus.Radius = 8;
        btnUpdateOrderStatus.RectColor = Color.FromArgb(51, 122, 183);
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
        layoutOrderMain.Size = new Size(1218, 368);
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
        dgvOrders.Size = new Size(763, 362);
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
        grpOrderDetail.Controls.Add(panelOrderActions);
        grpOrderDetail.Dock = DockStyle.Fill;
        grpOrderDetail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpOrderDetail.Location = new Point(773, 5);
        grpOrderDetail.Margin = new Padding(4, 5, 4, 5);
        grpOrderDetail.MinimumSize = new Size(1, 1);
        grpOrderDetail.Name = "grpOrderDetail";
        grpOrderDetail.Padding = new Padding(0, 32, 0, 0);
        grpOrderDetail.Size = new Size(441, 600);
        grpOrderDetail.TabIndex = 1;
        grpOrderDetail.Text = "订单详情";
        grpOrderDetail.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // lblCreatedAt
        // 
        lblCreatedAt.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblCreatedAt.ForeColor = Color.FromArgb(48, 48, 48);
        lblCreatedAt.Location = new Point(10, 342);
        lblCreatedAt.Name = "lblCreatedAt";
        lblCreatedAt.Size = new Size(420, 28);
        lblCreatedAt.TabIndex = 10;
        lblCreatedAt.Text = "创建时间：";
        // 
        // lblStatus
        // 
        lblStatus.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
        lblStatus.ForeColor = Color.FromArgb(48, 48, 48);
        lblStatus.Location = new Point(10, 310);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(420, 28);
        lblStatus.TabIndex = 9;
        lblStatus.Text = "状态：";
        // 
        // lblTotalAmount
        // 
        lblTotalAmount.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
        lblTotalAmount.ForeColor = Color.FromArgb(255, 109, 0);
        lblTotalAmount.Location = new Point(220, 278);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(210, 28);
        lblTotalAmount.TabIndex = 8;
        lblTotalAmount.Text = "总金额：";
        // 
        // lblDeliveryFee
        // 
        lblDeliveryFee.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblDeliveryFee.ForeColor = Color.FromArgb(48, 48, 48);
        lblDeliveryFee.Location = new Point(10, 278);
        lblDeliveryFee.Name = "lblDeliveryFee";
        lblDeliveryFee.Size = new Size(200, 28);
        lblDeliveryFee.TabIndex = 7;
        lblDeliveryFee.Text = "配送费：";
        // 
        // lblNote
        // 
        lblNote.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblNote.ForeColor = Color.FromArgb(48, 48, 48);
        lblNote.Location = new Point(10, 230);
        lblNote.Name = "lblNote";
        lblNote.Size = new Size(420, 44);
        lblNote.TabIndex = 6;
        lblNote.Text = "备注：";
        // 
        // lblAddress
        // 
        lblAddress.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblAddress.ForeColor = Color.FromArgb(48, 48, 48);
        lblAddress.Location = new Point(10, 198);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(420, 28);
        lblAddress.TabIndex = 5;
        lblAddress.Text = "配送地址：";
        // 
        // lblTableNumber
        // 
        lblTableNumber.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblTableNumber.ForeColor = Color.FromArgb(48, 48, 48);
        lblTableNumber.Location = new Point(10, 166);
        lblTableNumber.Name = "lblTableNumber";
        lblTableNumber.Size = new Size(420, 28);
        lblTableNumber.TabIndex = 4;
        lblTableNumber.Text = "桌号：";
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblPhone.ForeColor = Color.FromArgb(48, 48, 48);
        lblPhone.Location = new Point(10, 134);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(420, 28);
        lblPhone.TabIndex = 3;
        lblPhone.Text = "电话：";
        // 
        // lblCustomerName
        // 
        lblCustomerName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblCustomerName.ForeColor = Color.FromArgb(48, 48, 48);
        lblCustomerName.Location = new Point(10, 102);
        lblCustomerName.Name = "lblCustomerName";
        lblCustomerName.Size = new Size(420, 28);
        lblCustomerName.TabIndex = 2;
        lblCustomerName.Text = "顾客姓名：";
        // 
        // lblOrderType
        // 
        lblOrderType.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblOrderType.ForeColor = Color.FromArgb(48, 48, 48);
        lblOrderType.Location = new Point(10, 70);
        lblOrderType.Name = "lblOrderType";
        lblOrderType.Size = new Size(420, 28);
        lblOrderType.TabIndex = 1;
        lblOrderType.Text = "订单类型：";
        // 
        // lblOrderId
        // 
        lblOrderId.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblOrderId.ForeColor = Color.FromArgb(48, 48, 48);
        lblOrderId.Location = new Point(10, 38);
        lblOrderId.Name = "lblOrderId";
        lblOrderId.Size = new Size(420, 28);
        lblOrderId.TabIndex = 0;
        lblOrderId.Text = "订单编号：";
        // 
        // panelOrderActions
        // 
        panelOrderActions.Controls.Add(lblOrderActionHint);
        panelOrderActions.Controls.Add(btnConfirmOrder);
        panelOrderActions.Controls.Add(btnRejectOrder);
        panelOrderActions.Controls.Add(btnStartPreparing);
        panelOrderActions.Controls.Add(btnReady);
        panelOrderActions.Controls.Add(btnStartDelivery);
        panelOrderActions.Controls.Add(btnCompleteOrder);
        panelOrderActions.Controls.Add(btnCancelOrder);
        panelOrderActions.FlowDirection = FlowDirection.TopDown;
        panelOrderActions.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        panelOrderActions.Location = new Point(10, 380);
        panelOrderActions.Margin = new Padding(4, 5, 4, 5);
        panelOrderActions.MinimumSize = new Size(1, 1);
        panelOrderActions.Name = "panelOrderActions";
        panelOrderActions.Padding = new Padding(2);
        panelOrderActions.Size = new Size(420, 200);
        panelOrderActions.TabIndex = 11;
        panelOrderActions.Text = null;
        panelOrderActions.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // lblOrderActionHint
        // 
        lblOrderActionHint.Font = new Font("微软雅黑", 10F, FontStyle.Bold, GraphicsUnit.Point, 134);
        lblOrderActionHint.ForeColor = Color.FromArgb(51, 122, 183);
        lblOrderActionHint.Location = new Point(5, 5);
        lblOrderActionHint.Margin = new Padding(5);
        lblOrderActionHint.Name = "lblOrderActionHint";
        lblOrderActionHint.Size = new Size(400, 28);
        lblOrderActionHint.TabIndex = 0;
        lblOrderActionHint.Text = "请选择订单";
        lblOrderActionHint.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnConfirmOrder
        // 
        btnConfirmOrder.FillColor = Color.FromArgb(92, 184, 92);
        btnConfirmOrder.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnConfirmOrder.Location = new Point(5, 43);
        btnConfirmOrder.Margin = new Padding(5);
        btnConfirmOrder.MinimumSize = new Size(1, 1);
        btnConfirmOrder.Name = "btnConfirmOrder";
        btnConfirmOrder.Radius = 6;
        btnConfirmOrder.RectColor = Color.FromArgb(92, 184, 92);
        btnConfirmOrder.Size = new Size(90, 35);
        btnConfirmOrder.TabIndex = 1;
        btnConfirmOrder.Text = "接单";
        btnConfirmOrder.Visible = false;
        btnConfirmOrder.Click += btnConfirmOrder_Click;
        // 
        // btnRejectOrder
        // 
        btnRejectOrder.FillColor = Color.FromArgb(217, 83, 79);
        btnRejectOrder.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnRejectOrder.Location = new Point(105, 43);
        btnRejectOrder.Margin = new Padding(5);
        btnRejectOrder.MinimumSize = new Size(1, 1);
        btnRejectOrder.Name = "btnRejectOrder";
        btnRejectOrder.Radius = 6;
        btnRejectOrder.RectColor = Color.FromArgb(217, 83, 79);
        btnRejectOrder.Size = new Size(90, 35);
        btnRejectOrder.TabIndex = 2;
        btnRejectOrder.Text = "拒单";
        btnRejectOrder.Visible = false;
        btnRejectOrder.Click += btnRejectOrder_Click;
        // 
        // btnStartPreparing
        // 
        btnStartPreparing.FillColor = Color.FromArgb(240, 173, 78);
        btnStartPreparing.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnStartPreparing.Location = new Point(5, 88);
        btnStartPreparing.Margin = new Padding(5);
        btnStartPreparing.MinimumSize = new Size(1, 1);
        btnStartPreparing.Name = "btnStartPreparing";
        btnStartPreparing.Radius = 6;
        btnStartPreparing.RectColor = Color.FromArgb(240, 173, 78);
        btnStartPreparing.Size = new Size(90, 35);
        btnStartPreparing.TabIndex = 3;
        btnStartPreparing.Text = "开始制作";
        btnStartPreparing.Visible = false;
        btnStartPreparing.Click += btnStartPreparing_Click;
        // 
        // btnReady
        // 
        btnReady.FillColor = Color.FromArgb(91, 192, 222);
        btnReady.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnReady.Location = new Point(105, 88);
        btnReady.Margin = new Padding(5);
        btnReady.MinimumSize = new Size(1, 1);
        btnReady.Name = "btnReady";
        btnReady.Radius = 6;
        btnReady.RectColor = Color.FromArgb(91, 192, 222);
        btnReady.Size = new Size(90, 35);
        btnReady.TabIndex = 4;
        btnReady.Text = "出餐完成";
        btnReady.Visible = false;
        btnReady.Click += btnReady_Click;
        // 
        // btnStartDelivery
        // 
        btnStartDelivery.FillColor = Color.FromArgb(153, 102, 204);
        btnStartDelivery.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnStartDelivery.Location = new Point(205, 88);
        btnStartDelivery.Margin = new Padding(5);
        btnStartDelivery.MinimumSize = new Size(1, 1);
        btnStartDelivery.Name = "btnStartDelivery";
        btnStartDelivery.Radius = 6;
        btnStartDelivery.RectColor = Color.FromArgb(153, 102, 204);
        btnStartDelivery.Size = new Size(90, 35);
        btnStartDelivery.TabIndex = 5;
        btnStartDelivery.Text = "开始配送";
        btnStartDelivery.Visible = false;
        btnStartDelivery.Click += btnStartDelivery_Click;
        // 
        // btnCompleteOrder
        // 
        btnCompleteOrder.FillColor = Color.FromArgb(51, 122, 183);
        btnCompleteOrder.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnCompleteOrder.Location = new Point(5, 133);
        btnCompleteOrder.Margin = new Padding(5);
        btnCompleteOrder.MinimumSize = new Size(1, 1);
        btnCompleteOrder.Name = "btnCompleteOrder";
        btnCompleteOrder.Radius = 6;
        btnCompleteOrder.RectColor = Color.FromArgb(51, 122, 183);
        btnCompleteOrder.Size = new Size(90, 35);
        btnCompleteOrder.TabIndex = 6;
        btnCompleteOrder.Text = "完成订单";
        btnCompleteOrder.Visible = false;
        btnCompleteOrder.Click += btnCompleteOrder_Click;
        // 
        // btnCancelOrder
        // 
        btnCancelOrder.FillColor = Color.FromArgb(150, 150, 150);
        btnCancelOrder.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnCancelOrder.Location = new Point(105, 133);
        btnCancelOrder.Margin = new Padding(5);
        btnCancelOrder.MinimumSize = new Size(1, 1);
        btnCancelOrder.Name = "btnCancelOrder";
        btnCancelOrder.Radius = 6;
        btnCancelOrder.RectColor = Color.FromArgb(150, 150, 150);
        btnCancelOrder.Size = new Size(90, 35);
        btnCancelOrder.TabIndex = 7;
        btnCancelOrder.Text = "取消订单";
        btnCancelOrder.Visible = false;
        btnCancelOrder.Click += btnCancelOrder_Click;
        // 
        // grpOrderItems
        // 
        grpOrderItems.Controls.Add(dgvOrderItems);
        grpOrderItems.Dock = DockStyle.Fill;
        grpOrderItems.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpOrderItems.Location = new Point(4, 449);
        grpOrderItems.Margin = new Padding(4, 5, 4, 5);
        grpOrderItems.MinimumSize = new Size(1, 1);
        grpOrderItems.Name = "grpOrderItems";
        grpOrderItems.Padding = new Padding(0, 32, 0, 0);
        grpOrderItems.Size = new Size(1216, 192);
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
        dgvOrderItems.Size = new Size(1216, 160);
        dgvOrderItems.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvOrderItems.TabIndex = 0;
        // 
        // tabStatistics
        // 
        tabStatistics.Controls.Add(layoutStatisticsPage);
        tabStatistics.Location = new Point(0, 40);
        tabStatistics.Name = "tabStatistics";
        tabStatistics.Size = new Size(1224, 646);
        tabStatistics.TabIndex = 2;
        tabStatistics.Text = "统计分析";
        tabStatistics.UseVisualStyleBackColor = true;
        // 
        // layoutStatisticsPage
        // 
        layoutStatisticsPage.Anchor = AnchorStyles.None;
        layoutStatisticsPage.ColumnCount = 1;
        layoutStatisticsPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatisticsPage.Controls.Add(layoutStatisticsTop, 0, 0);
        layoutStatisticsPage.Controls.Add(layoutStatisticsSummary, 0, 1);
        layoutStatisticsPage.Controls.Add(layoutStatisticsMain, 0, 2);
        layoutStatisticsPage.Location = new Point(0, 0);
        layoutStatisticsPage.Name = "layoutStatisticsPage";
        layoutStatisticsPage.Padding = new Padding(10);
        layoutStatisticsPage.RowCount = 3;
        layoutStatisticsPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
        layoutStatisticsPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        layoutStatisticsPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatisticsPage.Size = new Size(1224, 646);
        layoutStatisticsPage.TabIndex = 0;
        layoutStatisticsPage.TagString = null;
        // 
        // layoutStatisticsTop
        // 
        layoutStatisticsTop.ColumnCount = 10;
        layoutStatisticsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        layoutStatisticsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        layoutStatisticsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 119F));
        layoutStatisticsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
        layoutStatisticsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
        layoutStatisticsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
        layoutStatisticsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 148F));
        layoutStatisticsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        layoutStatisticsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatisticsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F));
        layoutStatisticsTop.Controls.Add(uiLabel4, 0, 0);
        layoutStatisticsTop.Controls.Add(dtpStatisticsStart, 1, 0);
        layoutStatisticsTop.Controls.Add(lblTopCountTitle, 4, 0);
        layoutStatisticsTop.Controls.Add(dtpStatisticsEnd, 3, 0);
        layoutStatisticsTop.Controls.Add(btnResetStatistics, 7, 0);
        layoutStatisticsTop.Controls.Add(uiLabel5, 2, 0);
        layoutStatisticsTop.Controls.Add(txtTopCount, 5, 0);
        layoutStatisticsTop.Controls.Add(btnLoadStatistics, 6, 0);
        layoutStatisticsTop.Dock = DockStyle.Fill;
        layoutStatisticsTop.Location = new Point(13, 13);
        layoutStatisticsTop.Name = "layoutStatisticsTop";
        layoutStatisticsTop.RowCount = 1;
        layoutStatisticsTop.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        layoutStatisticsTop.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        layoutStatisticsTop.Size = new Size(1198, 64);
        layoutStatisticsTop.TabIndex = 0;
        layoutStatisticsTop.TagString = null;
        // 
        // uiLabel4
        // 
        uiLabel4.Anchor = AnchorStyles.Left;
        uiLabel4.Font = new Font("宋体", 10F);
        uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
        uiLabel4.Location = new Point(3, 15);
        uiLabel4.Name = "uiLabel4";
        uiLabel4.Size = new Size(124, 34);
        uiLabel4.TabIndex = 0;
        uiLabel4.Text = "开始日期：";
        uiLabel4.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // dtpStatisticsStart
        // 
        dtpStatisticsStart.Anchor = AnchorStyles.None;
        dtpStatisticsStart.DateCultureInfo = new System.Globalization.CultureInfo("");
        dtpStatisticsStart.FillColor = Color.White;
        dtpStatisticsStart.Font = new Font("宋体", 10F);
        dtpStatisticsStart.Location = new Point(134, 10);
        dtpStatisticsStart.Margin = new Padding(4, 5, 4, 5);
        dtpStatisticsStart.MaxLength = 10;
        dtpStatisticsStart.MinimumSize = new Size(63, 0);
        dtpStatisticsStart.Name = "dtpStatisticsStart";
        dtpStatisticsStart.Padding = new Padding(0, 0, 30, 2);
        dtpStatisticsStart.Size = new Size(141, 44);
        dtpStatisticsStart.SymbolDropDown = 61555;
        dtpStatisticsStart.SymbolNormal = 61555;
        dtpStatisticsStart.SymbolSize = 24;
        dtpStatisticsStart.TabIndex = 1;
        dtpStatisticsStart.Text = "2026-05-10";
        dtpStatisticsStart.TextAlignment = ContentAlignment.MiddleLeft;
        dtpStatisticsStart.Value = new DateTime(2026, 5, 10, 13, 5, 23, 768);
        dtpStatisticsStart.Watermark = "";
        // 
        // lblTopCountTitle
        // 
        lblTopCountTitle.Anchor = AnchorStyles.None;
        lblTopCountTitle.Font = new Font("宋体", 10F);
        lblTopCountTitle.ForeColor = Color.FromArgb(48, 48, 48);
        lblTopCountTitle.Location = new Point(542, 15);
        lblTopCountTitle.Name = "lblTopCountTitle";
        lblTopCountTitle.Size = new Size(119, 34);
        lblTopCountTitle.TabIndex = 3;
        lblTopCountTitle.Text = "显示前N名：";
        lblTopCountTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // dtpStatisticsEnd
        // 
        dtpStatisticsEnd.Anchor = AnchorStyles.None;
        dtpStatisticsEnd.DateCultureInfo = new System.Globalization.CultureInfo("");
        dtpStatisticsEnd.FillColor = Color.White;
        dtpStatisticsEnd.Font = new Font("宋体", 10F);
        dtpStatisticsEnd.Location = new Point(403, 10);
        dtpStatisticsEnd.Margin = new Padding(4, 5, 4, 5);
        dtpStatisticsEnd.MaxLength = 10;
        dtpStatisticsEnd.MinimumSize = new Size(63, 0);
        dtpStatisticsEnd.Name = "dtpStatisticsEnd";
        dtpStatisticsEnd.Padding = new Padding(0, 0, 30, 2);
        dtpStatisticsEnd.Size = new Size(132, 44);
        dtpStatisticsEnd.SymbolDropDown = 61555;
        dtpStatisticsEnd.SymbolNormal = 61555;
        dtpStatisticsEnd.SymbolSize = 24;
        dtpStatisticsEnd.TabIndex = 4;
        dtpStatisticsEnd.Text = "2026-05-10";
        dtpStatisticsEnd.TextAlignment = ContentAlignment.MiddleLeft;
        dtpStatisticsEnd.Value = new DateTime(2026, 5, 10, 13, 7, 15, 580);
        dtpStatisticsEnd.Watermark = "";
        // 
        // btnResetStatistics
        // 
        btnResetStatistics.Anchor = AnchorStyles.None;
        btnResetStatistics.FillColor = Color.FromArgb(51, 122, 183);
        btnResetStatistics.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnResetStatistics.Location = new Point(957, 6);
        btnResetStatistics.MinimumSize = new Size(1, 1);
        btnResetStatistics.Name = "btnResetStatistics";
        btnResetStatistics.Radius = 8;
        btnResetStatistics.RectColor = Color.FromArgb(51, 122, 183);
        btnResetStatistics.Size = new Size(115, 52);
        btnResetStatistics.TabIndex = 8;
        btnResetStatistics.Text = "重置";
        btnResetStatistics.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnResetStatistics.Click += btnResetStatistics_Click;
        // 
        // uiLabel5
        // 
        uiLabel5.Anchor = AnchorStyles.None;
        uiLabel5.Font = new Font("宋体", 10F);
        uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
        uiLabel5.Location = new Point(283, 15);
        uiLabel5.Name = "uiLabel5";
        uiLabel5.Size = new Size(113, 34);
        uiLabel5.TabIndex = 2;
        uiLabel5.Text = "结束日期：";
        uiLabel5.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // txtTopCount
        // 
        txtTopCount.Anchor = AnchorStyles.None;
        txtTopCount.DoubleValue = 5D;
        txtTopCount.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtTopCount.IntValue = 5;
        txtTopCount.Location = new Point(668, 10);
        txtTopCount.Margin = new Padding(4, 5, 4, 5);
        txtTopCount.MinimumSize = new Size(1, 16);
        txtTopCount.Name = "txtTopCount";
        txtTopCount.Padding = new Padding(5);
        txtTopCount.ShowText = false;
        txtTopCount.Size = new Size(120, 44);
        txtTopCount.TabIndex = 9;
        txtTopCount.Text = "5";
        txtTopCount.TextAlignment = ContentAlignment.MiddleLeft;
        txtTopCount.Watermark = "";
        // 
        // btnLoadStatistics
        // 
        btnLoadStatistics.Anchor = AnchorStyles.None;
        btnLoadStatistics.FillColor = Color.FromArgb(51, 122, 183);
        btnLoadStatistics.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnLoadStatistics.Location = new Point(795, 6);
        btnLoadStatistics.MinimumSize = new Size(1, 1);
        btnLoadStatistics.Name = "btnLoadStatistics";
        btnLoadStatistics.Radius = 8;
        btnLoadStatistics.RectColor = Color.FromArgb(51, 122, 183);
        btnLoadStatistics.Size = new Size(142, 52);
        btnLoadStatistics.TabIndex = 10;
        btnLoadStatistics.Text = "刷新统计";
        btnLoadStatistics.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnLoadStatistics.Click += btnLoadStatistics_Click;
        // 
        // layoutStatisticsSummary
        // 
        layoutStatisticsSummary.ColumnCount = 4;
        layoutStatisticsSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutStatisticsSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutStatisticsSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutStatisticsSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutStatisticsSummary.Controls.Add(grpTotalOrders, 0, 0);
        layoutStatisticsSummary.Controls.Add(grpTotalRevenue, 1, 0);
        layoutStatisticsSummary.Controls.Add(grpTopDishCount, 3, 0);
        layoutStatisticsSummary.Controls.Add(grpAverageOrderAmount, 2, 0);
        layoutStatisticsSummary.Dock = DockStyle.Fill;
        layoutStatisticsSummary.Location = new Point(13, 83);
        layoutStatisticsSummary.Name = "layoutStatisticsSummary";
        layoutStatisticsSummary.RowCount = 1;
        layoutStatisticsSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatisticsSummary.Size = new Size(1198, 114);
        layoutStatisticsSummary.TabIndex = 1;
        layoutStatisticsSummary.TagString = null;
        // 
        // grpTotalOrders
        // 
        grpTotalOrders.Controls.Add(lblTotalOrders);
        grpTotalOrders.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpTotalOrders.Location = new Point(4, 5);
        grpTotalOrders.Margin = new Padding(4, 5, 4, 5);
        grpTotalOrders.MinimumSize = new Size(1, 1);
        grpTotalOrders.Name = "grpTotalOrders";
        grpTotalOrders.Padding = new Padding(0, 32, 0, 0);
        grpTotalOrders.Size = new Size(291, 104);
        grpTotalOrders.TabIndex = 0;
        grpTotalOrders.Text = "订单数";
        grpTotalOrders.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // lblTotalOrders
        // 
        lblTotalOrders.Dock = DockStyle.Fill;
        lblTotalOrders.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblTotalOrders.ForeColor = Color.FromArgb(48, 48, 48);
        lblTotalOrders.Location = new Point(0, 32);
        lblTotalOrders.Name = "lblTotalOrders";
        lblTotalOrders.Size = new Size(291, 72);
        lblTotalOrders.TabIndex = 0;
        lblTotalOrders.Text = "订单数：暂无数据";
        // 
        // grpTotalRevenue
        // 
        grpTotalRevenue.Controls.Add(lblTotalRevenue);
        grpTotalRevenue.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpTotalRevenue.Location = new Point(303, 5);
        grpTotalRevenue.Margin = new Padding(4, 5, 4, 5);
        grpTotalRevenue.MinimumSize = new Size(1, 1);
        grpTotalRevenue.Name = "grpTotalRevenue";
        grpTotalRevenue.Padding = new Padding(0, 32, 0, 0);
        grpTotalRevenue.Size = new Size(291, 104);
        grpTotalRevenue.TabIndex = 1;
        grpTotalRevenue.Text = "销售额";
        grpTotalRevenue.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // lblTotalRevenue
        // 
        lblTotalRevenue.Dock = DockStyle.Fill;
        lblTotalRevenue.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblTotalRevenue.ForeColor = Color.FromArgb(48, 48, 48);
        lblTotalRevenue.Location = new Point(0, 32);
        lblTotalRevenue.Name = "lblTotalRevenue";
        lblTotalRevenue.Size = new Size(291, 72);
        lblTotalRevenue.TabIndex = 0;
        lblTotalRevenue.Text = "销售额：暂无数据";
        // 
        // grpTopDishCount
        // 
        grpTopDishCount.Controls.Add(lblTopDishCount);
        grpTopDishCount.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpTopDishCount.Location = new Point(901, 5);
        grpTopDishCount.Margin = new Padding(4, 5, 4, 5);
        grpTopDishCount.MinimumSize = new Size(1, 1);
        grpTopDishCount.Name = "grpTopDishCount";
        grpTopDishCount.Padding = new Padding(0, 32, 0, 0);
        grpTopDishCount.Size = new Size(293, 104);
        grpTopDishCount.TabIndex = 3;
        grpTopDishCount.Text = "热销菜品";
        grpTopDishCount.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // lblTopDishCount
        // 
        lblTopDishCount.Dock = DockStyle.Fill;
        lblTopDishCount.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblTopDishCount.ForeColor = Color.FromArgb(48, 48, 48);
        lblTopDishCount.Location = new Point(0, 32);
        lblTopDishCount.Name = "lblTopDishCount";
        lblTopDishCount.Size = new Size(293, 72);
        lblTopDishCount.TabIndex = 0;
        lblTopDishCount.Text = "热销菜品数：暂无数据";
        // 
        // grpAverageOrderAmount
        // 
        grpAverageOrderAmount.Controls.Add(lblAverageOrderAmount);
        grpAverageOrderAmount.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpAverageOrderAmount.Location = new Point(602, 5);
        grpAverageOrderAmount.Margin = new Padding(4, 5, 4, 5);
        grpAverageOrderAmount.MinimumSize = new Size(1, 1);
        grpAverageOrderAmount.Name = "grpAverageOrderAmount";
        grpAverageOrderAmount.Padding = new Padding(0, 32, 0, 0);
        grpAverageOrderAmount.Size = new Size(291, 104);
        grpAverageOrderAmount.TabIndex = 2;
        grpAverageOrderAmount.Text = "平均客单价";
        grpAverageOrderAmount.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // lblAverageOrderAmount
        // 
        lblAverageOrderAmount.Dock = DockStyle.Fill;
        lblAverageOrderAmount.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblAverageOrderAmount.ForeColor = Color.FromArgb(48, 48, 48);
        lblAverageOrderAmount.Location = new Point(0, 32);
        lblAverageOrderAmount.Name = "lblAverageOrderAmount";
        lblAverageOrderAmount.Size = new Size(291, 72);
        lblAverageOrderAmount.TabIndex = 0;
        lblAverageOrderAmount.Text = "平均客单价：暂无数据";
        // 
        // layoutStatisticsMain
        // 
        layoutStatisticsMain.ColumnCount = 2;
        layoutStatisticsMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        layoutStatisticsMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        layoutStatisticsMain.Controls.Add(grpTopDishes, 0, 0);
        layoutStatisticsMain.Controls.Add(grpTopDishesChart, 1, 0);
        layoutStatisticsMain.Controls.Add(grpRevenueStatistics, 0, 1);
        layoutStatisticsMain.Controls.Add(grpStatisticsRemark, 1, 1);
        layoutStatisticsMain.Dock = DockStyle.Fill;
        layoutStatisticsMain.Location = new Point(13, 203);
        layoutStatisticsMain.Name = "layoutStatisticsMain";
        layoutStatisticsMain.RowCount = 2;
        layoutStatisticsMain.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
        layoutStatisticsMain.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
        layoutStatisticsMain.Size = new Size(1198, 430);
        layoutStatisticsMain.TabIndex = 2;
        layoutStatisticsMain.TagString = null;
        // 
        // grpTopDishes
        // 
        grpTopDishes.Controls.Add(dgvTopDishes);
        grpTopDishes.Dock = DockStyle.Fill;
        grpTopDishes.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpTopDishes.Location = new Point(4, 5);
        grpTopDishes.Margin = new Padding(4, 5, 4, 5);
        grpTopDishes.MinimumSize = new Size(1, 1);
        grpTopDishes.Name = "grpTopDishes";
        grpTopDishes.Padding = new Padding(0, 32, 0, 0);
        grpTopDishes.Size = new Size(710, 269);
        grpTopDishes.TabIndex = 0;
        grpTopDishes.Text = "热销菜品排行";
        grpTopDishes.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // dgvTopDishes
        // 
        dgvTopDishes.AllowUserToAddRows = false;
        dgvTopDishes.AllowUserToDeleteRows = false;
        dataGridViewCellStyle16.BackColor = Color.FromArgb(235, 243, 255);
        dgvTopDishes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
        dgvTopDishes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvTopDishes.BackgroundColor = Color.White;
        dgvTopDishes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle17.BackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle17.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle17.ForeColor = Color.White;
        dataGridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
        dgvTopDishes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
        dgvTopDishes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle18.BackColor = SystemColors.Window;
        dataGridViewCellStyle18.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle18.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
        dgvTopDishes.DefaultCellStyle = dataGridViewCellStyle18;
        dgvTopDishes.Dock = DockStyle.Fill;
        dgvTopDishes.EnableHeadersVisualStyles = false;
        dgvTopDishes.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvTopDishes.GridColor = Color.FromArgb(80, 160, 255);
        dgvTopDishes.Location = new Point(0, 32);
        dgvTopDishes.Name = "dgvTopDishes";
        dgvTopDishes.ReadOnly = true;
        dgvTopDishes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle19.BackColor = Color.FromArgb(235, 243, 255);
        dataGridViewCellStyle19.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle19.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle19.SelectionBackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle19.SelectionForeColor = Color.White;
        dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
        dgvTopDishes.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
        dgvTopDishes.RowHeadersWidth = 62;
        dataGridViewCellStyle20.BackColor = Color.White;
        dataGridViewCellStyle20.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvTopDishes.RowsDefaultCellStyle = dataGridViewCellStyle20;
        dgvTopDishes.SelectedIndex = -1;
        dgvTopDishes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTopDishes.Size = new Size(710, 237);
        dgvTopDishes.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvTopDishes.TabIndex = 0;
        // 
        // grpTopDishesChart
        // 
        grpTopDishesChart.Controls.Add(panelTopDishesChart);
        grpTopDishesChart.Dock = DockStyle.Fill;
        grpTopDishesChart.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpTopDishesChart.Location = new Point(722, 5);
        grpTopDishesChart.Margin = new Padding(4, 5, 4, 5);
        grpTopDishesChart.MinimumSize = new Size(1, 1);
        grpTopDishesChart.Name = "grpTopDishesChart";
        grpTopDishesChart.Padding = new Padding(0, 32, 0, 0);
        grpTopDishesChart.Size = new Size(472, 269);
        grpTopDishesChart.TabIndex = 4;
        grpTopDishesChart.Text = "热销菜品柱状图";
        grpTopDishesChart.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // panelTopDishesChart
        // 
        panelTopDishesChart.Controls.Add(lblChartPlaceholder);
        panelTopDishesChart.Dock = DockStyle.Fill;
        panelTopDishesChart.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        panelTopDishesChart.Location = new Point(0, 32);
        panelTopDishesChart.Margin = new Padding(4, 5, 4, 5);
        panelTopDishesChart.MinimumSize = new Size(1, 1);
        panelTopDishesChart.Name = "panelTopDishesChart";
        panelTopDishesChart.Size = new Size(472, 237);
        panelTopDishesChart.TabIndex = 0;
        panelTopDishesChart.Text = null;
        panelTopDishesChart.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // lblChartPlaceholder
        // 
        lblChartPlaceholder.Dock = DockStyle.Fill;
        lblChartPlaceholder.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblChartPlaceholder.ForeColor = Color.FromArgb(48, 48, 48);
        lblChartPlaceholder.Location = new Point(0, 0);
        lblChartPlaceholder.Name = "lblChartPlaceholder";
        lblChartPlaceholder.Size = new Size(472, 237);
        lblChartPlaceholder.TabIndex = 0;
        lblChartPlaceholder.Text = "图表区域：后续显示热销菜品柱状图";
        lblChartPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // grpRevenueStatistics
        // 
        grpRevenueStatistics.Controls.Add(dgvRevenueStatistics);
        grpRevenueStatistics.Dock = DockStyle.Fill;
        grpRevenueStatistics.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpRevenueStatistics.Location = new Point(4, 284);
        grpRevenueStatistics.Margin = new Padding(4, 5, 4, 5);
        grpRevenueStatistics.MinimumSize = new Size(1, 1);
        grpRevenueStatistics.Name = "grpRevenueStatistics";
        grpRevenueStatistics.Padding = new Padding(0, 32, 0, 0);
        grpRevenueStatistics.Size = new Size(710, 141);
        grpRevenueStatistics.TabIndex = 5;
        grpRevenueStatistics.Text = "营收统计";
        grpRevenueStatistics.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // dgvRevenueStatistics
        // 
        dgvRevenueStatistics.AllowUserToAddRows = false;
        dataGridViewCellStyle21.BackColor = Color.FromArgb(235, 243, 255);
        dgvRevenueStatistics.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
        dgvRevenueStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvRevenueStatistics.BackgroundColor = Color.White;
        dgvRevenueStatistics.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle22.BackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle22.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle22.ForeColor = Color.White;
        dataGridViewCellStyle22.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle22.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle22.WrapMode = DataGridViewTriState.True;
        dgvRevenueStatistics.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
        dgvRevenueStatistics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle23.BackColor = SystemColors.Window;
        dataGridViewCellStyle23.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle23.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle23.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle23.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle23.WrapMode = DataGridViewTriState.False;
        dgvRevenueStatistics.DefaultCellStyle = dataGridViewCellStyle23;
        dgvRevenueStatistics.Dock = DockStyle.Fill;
        dgvRevenueStatistics.EnableHeadersVisualStyles = false;
        dgvRevenueStatistics.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvRevenueStatistics.GridColor = Color.FromArgb(80, 160, 255);
        dgvRevenueStatistics.Location = new Point(0, 32);
        dgvRevenueStatistics.Name = "dgvRevenueStatistics";
        dgvRevenueStatistics.ReadOnly = true;
        dgvRevenueStatistics.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle24.BackColor = Color.FromArgb(235, 243, 255);
        dataGridViewCellStyle24.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle24.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle24.SelectionBackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle24.SelectionForeColor = Color.White;
        dataGridViewCellStyle24.WrapMode = DataGridViewTriState.True;
        dgvRevenueStatistics.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
        dgvRevenueStatistics.RowHeadersWidth = 62;
        dataGridViewCellStyle25.BackColor = Color.White;
        dataGridViewCellStyle25.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvRevenueStatistics.RowsDefaultCellStyle = dataGridViewCellStyle25;
        dgvRevenueStatistics.SelectedIndex = -1;
        dgvRevenueStatistics.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRevenueStatistics.Size = new Size(710, 109);
        dgvRevenueStatistics.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvRevenueStatistics.TabIndex = 0;
        // 
        // grpStatisticsRemark
        // 
        grpStatisticsRemark.Controls.Add(txtStatisticsRemark);
        grpStatisticsRemark.Dock = DockStyle.Fill;
        grpStatisticsRemark.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpStatisticsRemark.Location = new Point(722, 284);
        grpStatisticsRemark.Margin = new Padding(4, 5, 4, 5);
        grpStatisticsRemark.MinimumSize = new Size(1, 1);
        grpStatisticsRemark.Name = "grpStatisticsRemark";
        grpStatisticsRemark.Padding = new Padding(0, 32, 0, 0);
        grpStatisticsRemark.Size = new Size(472, 141);
        grpStatisticsRemark.TabIndex = 6;
        grpStatisticsRemark.Text = "统计说明";
        grpStatisticsRemark.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // txtStatisticsRemark
        // 
        txtStatisticsRemark.Dock = DockStyle.Fill;
        txtStatisticsRemark.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtStatisticsRemark.Location = new Point(0, 32);
        txtStatisticsRemark.Margin = new Padding(4, 5, 4, 5);
        txtStatisticsRemark.MinimumSize = new Size(1, 16);
        txtStatisticsRemark.Multiline = true;
        txtStatisticsRemark.Name = "txtStatisticsRemark";
        txtStatisticsRemark.Padding = new Padding(5);
        txtStatisticsRemark.ReadOnly = true;
        txtStatisticsRemark.RightToLeft = RightToLeft.No;
        txtStatisticsRemark.ShowScrollBar = true;
        txtStatisticsRemark.ShowText = false;
        txtStatisticsRemark.Size = new Size(472, 109);
        txtStatisticsRemark.TabIndex = 0;
        txtStatisticsRemark.Text = "统计数据来源于订单和订单明细，已取消订单不计入营收。";
        txtStatisticsRemark.TextAlignment = ContentAlignment.TopLeft;
        txtStatisticsRemark.Watermark = "";
        // 
        // tabAi
        // 
        tabAi.Controls.Add(layoutAiPage);
        tabAi.Location = new Point(0, 40);
        tabAi.Name = "tabAi";
        tabAi.Size = new Size(1224, 646);
        tabAi.TabIndex = 3;
        tabAi.Text = "AI建议";
        tabAi.UseVisualStyleBackColor = true;
        // 
        // layoutAiPage
        // 
        layoutAiPage.ColumnCount = 1;
        layoutAiPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutAiPage.Controls.Add(layoutAiTop, 0, 0);
        layoutAiPage.Controls.Add(grpAiSuggestion, 0, 1);
        layoutAiPage.Controls.Add(grpAiError, 0, 2);
        layoutAiPage.Dock = DockStyle.Fill;
        layoutAiPage.Location = new Point(0, 0);
        layoutAiPage.Name = "layoutAiPage";
        layoutAiPage.Padding = new Padding(10);
        layoutAiPage.RowCount = 3;
        layoutAiPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
        layoutAiPage.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
        layoutAiPage.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        layoutAiPage.Size = new Size(1224, 646);
        layoutAiPage.TabIndex = 0;
        layoutAiPage.TagString = null;
        // 
        // layoutAiTop
        // 
        layoutAiTop.ColumnCount = 3;
        layoutAiTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
        layoutAiTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutAiTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
        layoutAiTop.Controls.Add(btnLoadAiSuggestion, 0, 0);
        layoutAiTop.Controls.Add(lblAiHint, 1, 0);
        layoutAiTop.Dock = DockStyle.Fill;
        layoutAiTop.Location = new Point(13, 13);
        layoutAiTop.Name = "layoutAiTop";
        layoutAiTop.RowCount = 1;
        layoutAiTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutAiTop.Size = new Size(1198, 64);
        layoutAiTop.TabIndex = 0;
        layoutAiTop.TagString = null;
        // 
        // btnLoadAiSuggestion
        // 
        btnLoadAiSuggestion.Anchor = AnchorStyles.None;
        btnLoadAiSuggestion.FillColor = Color.FromArgb(51, 122, 183);
        btnLoadAiSuggestion.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnLoadAiSuggestion.Location = new Point(10, 6);
        btnLoadAiSuggestion.MinimumSize = new Size(1, 1);
        btnLoadAiSuggestion.Name = "btnLoadAiSuggestion";
        btnLoadAiSuggestion.Radius = 8;
        btnLoadAiSuggestion.RectColor = Color.FromArgb(51, 122, 183);
        btnLoadAiSuggestion.Size = new Size(150, 52);
        btnLoadAiSuggestion.TabIndex = 0;
        btnLoadAiSuggestion.Text = "获取经营建议";
        btnLoadAiSuggestion.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnLoadAiSuggestion.Click += btnLoadAiSuggestion_Click;
        // 
        // lblAiHint
        // 
        lblAiHint.Dock = DockStyle.Fill;
        lblAiHint.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblAiHint.ForeColor = Color.FromArgb(48, 48, 48);
        lblAiHint.Location = new Point(173, 0);
        lblAiHint.Name = "lblAiHint";
        lblAiHint.Size = new Size(1012, 64);
        lblAiHint.TabIndex = 1;
        lblAiHint.Text = "根据热销菜品、低销量菜品和订单统计数据生成经营建议";
        lblAiHint.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // grpAiSuggestion
        // 
        grpAiSuggestion.Controls.Add(txtAiSuggestion);
        grpAiSuggestion.Dock = DockStyle.Fill;
        grpAiSuggestion.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpAiSuggestion.Location = new Point(14, 85);
        grpAiSuggestion.Margin = new Padding(4, 5, 4, 5);
        grpAiSuggestion.MinimumSize = new Size(1, 1);
        grpAiSuggestion.Name = "grpAiSuggestion";
        grpAiSuggestion.Padding = new Padding(0, 32, 0, 0);
        grpAiSuggestion.Size = new Size(1196, 407);
        grpAiSuggestion.TabIndex = 1;
        grpAiSuggestion.Text = "AI经营建议";
        grpAiSuggestion.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // txtAiSuggestion
        // 
        txtAiSuggestion.Dock = DockStyle.Fill;
        txtAiSuggestion.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtAiSuggestion.Location = new Point(0, 32);
        txtAiSuggestion.Margin = new Padding(4, 5, 4, 5);
        txtAiSuggestion.MinimumSize = new Size(1, 16);
        txtAiSuggestion.Multiline = true;
        txtAiSuggestion.Name = "txtAiSuggestion";
        txtAiSuggestion.Padding = new Padding(5);
        txtAiSuggestion.ReadOnly = true;
        txtAiSuggestion.ShowScrollBar = true;
        txtAiSuggestion.ShowText = false;
        txtAiSuggestion.Size = new Size(1196, 375);
        txtAiSuggestion.TabIndex = 0;
        txtAiSuggestion.Text = "暂无经营建议，请点击“获取经营建议”。";
        txtAiSuggestion.TextAlignment = ContentAlignment.MiddleLeft;
        txtAiSuggestion.Watermark = "";
        // 
        // grpAiError
        // 
        grpAiError.Controls.Add(txtAiError);
        grpAiError.Dock = DockStyle.Fill;
        grpAiError.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpAiError.Location = new Point(14, 502);
        grpAiError.Margin = new Padding(4, 5, 4, 5);
        grpAiError.MinimumSize = new Size(1, 1);
        grpAiError.Name = "grpAiError";
        grpAiError.Padding = new Padding(0, 32, 0, 0);
        grpAiError.Size = new Size(1196, 129);
        grpAiError.TabIndex = 2;
        grpAiError.Text = "错误提示";
        grpAiError.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // txtAiError
        // 
        txtAiError.Dock = DockStyle.Fill;
        txtAiError.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtAiError.Location = new Point(0, 32);
        txtAiError.Margin = new Padding(4, 5, 4, 5);
        txtAiError.MinimumSize = new Size(1, 16);
        txtAiError.Multiline = true;
        txtAiError.Name = "txtAiError";
        txtAiError.Padding = new Padding(5);
        txtAiError.ShowScrollBar = true;
        txtAiError.ShowText = false;
        txtAiError.Size = new Size(1196, 97);
        txtAiError.TabIndex = 0;
        txtAiError.Text = "暂无错误。";
        txtAiError.TextAlignment = ContentAlignment.MiddleLeft;
        txtAiError.Watermark = "";
        // 
        // tabDeliveryZones
        // 
        tabDeliveryZones.Controls.Add(layoutDeliveryZonesPage);
        tabDeliveryZones.Location = new Point(0, 40);
        tabDeliveryZones.Name = "tabDeliveryZones";
        tabDeliveryZones.Size = new Size(1224, 646);
        tabDeliveryZones.TabIndex = 4;
        tabDeliveryZones.Text = "配送区域";
        tabDeliveryZones.UseVisualStyleBackColor = true;
        // 
        // layoutDeliveryZonesPage
        // 
        layoutDeliveryZonesPage.ColumnCount = 1;
        layoutDeliveryZonesPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutDeliveryZonesPage.Controls.Add(panelDeliveryZoneTop, 0, 0);
        layoutDeliveryZonesPage.Controls.Add(dgvDeliveryZones, 0, 1);
        layoutDeliveryZonesPage.Controls.Add(grpDeliveryZoneEditor, 0, 2);
        layoutDeliveryZonesPage.Dock = DockStyle.Fill;
        layoutDeliveryZonesPage.Location = new Point(0, 0);
        layoutDeliveryZonesPage.Name = "layoutDeliveryZonesPage";
        layoutDeliveryZonesPage.Padding = new Padding(10);
        layoutDeliveryZonesPage.RowCount = 3;
        layoutDeliveryZonesPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutDeliveryZonesPage.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
        layoutDeliveryZonesPage.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
        layoutDeliveryZonesPage.Size = new Size(1224, 646);
        layoutDeliveryZonesPage.TabIndex = 0;
        layoutDeliveryZonesPage.TagString = null;
        // 
        // panelDeliveryZoneTop
        // 
        panelDeliveryZoneTop.Controls.Add(btnLoadDeliveryZones);
        panelDeliveryZoneTop.Dock = DockStyle.Fill;
        panelDeliveryZoneTop.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        panelDeliveryZoneTop.Location = new Point(14, 15);
        panelDeliveryZoneTop.Margin = new Padding(4, 5, 4, 5);
        panelDeliveryZoneTop.MinimumSize = new Size(1, 1);
        panelDeliveryZoneTop.Name = "panelDeliveryZoneTop";
        panelDeliveryZoneTop.Padding = new Padding(2);
        panelDeliveryZoneTop.ShowText = false;
        panelDeliveryZoneTop.Size = new Size(1196, 50);
        panelDeliveryZoneTop.TabIndex = 0;
        panelDeliveryZoneTop.Text = null;
        panelDeliveryZoneTop.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // btnLoadDeliveryZones
        // 
        btnLoadDeliveryZones.FillColor = Color.FromArgb(51, 122, 183);
        btnLoadDeliveryZones.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnLoadDeliveryZones.Location = new Point(10, 8);
        btnLoadDeliveryZones.MinimumSize = new Size(1, 1);
        btnLoadDeliveryZones.Name = "btnLoadDeliveryZones";
        btnLoadDeliveryZones.Radius = 8;
        btnLoadDeliveryZones.RectColor = Color.FromArgb(51, 122, 183);
        btnLoadDeliveryZones.Size = new Size(120, 38);
        btnLoadDeliveryZones.TabIndex = 0;
        btnLoadDeliveryZones.Text = "加载区域";
        btnLoadDeliveryZones.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // dgvDeliveryZones
        // 
        dgvDeliveryZones.AllowUserToAddRows = false;
        dgvDeliveryZones.AllowUserToDeleteRows = false;
        dataGridViewCellStyle26.BackColor = Color.FromArgb(235, 243, 255);
        dgvDeliveryZones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
        dgvDeliveryZones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvDeliveryZones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDeliveryZones.BackgroundColor = Color.White;
        dgvDeliveryZones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle27.BackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle27.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle27.ForeColor = Color.White;
        dataGridViewCellStyle27.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle27.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle27.WrapMode = DataGridViewTriState.True;
        dgvDeliveryZones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
        dgvDeliveryZones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDeliveryZones.EnableHeadersVisualStyles = false;
        dgvDeliveryZones.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvDeliveryZones.GridColor = Color.FromArgb(80, 160, 255);
        dgvDeliveryZones.Location = new Point(20, 80);
        dgvDeliveryZones.Margin = new Padding(10);
        dgvDeliveryZones.MultiSelect = false;
        dgvDeliveryZones.Name = "dgvDeliveryZones";
        dgvDeliveryZones.ReadOnly = true;
        dgvDeliveryZones.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle28.BackColor = Color.FromArgb(235, 243, 255);
        dataGridViewCellStyle28.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle28.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle28.SelectionBackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle28.SelectionForeColor = Color.White;
        dataGridViewCellStyle28.WrapMode = DataGridViewTriState.True;
        dgvDeliveryZones.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
        dgvDeliveryZones.RowHeadersWidth = 30;
        dataGridViewCellStyle29.BackColor = Color.White;
        dataGridViewCellStyle29.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvDeliveryZones.RowsDefaultCellStyle = dataGridViewCellStyle29;
        dgvDeliveryZones.SelectedIndex = -1;
        dgvDeliveryZones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDeliveryZones.Size = new Size(1184, 319);
        dgvDeliveryZones.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvDeliveryZones.TabIndex = 1;
        // 
        // grpDeliveryZoneEditor
        // 
        grpDeliveryZoneEditor.Controls.Add(layoutDeliveryZoneEditor);
        grpDeliveryZoneEditor.Controls.Add(panelDeliveryZoneActions);
        grpDeliveryZoneEditor.Dock = DockStyle.Fill;
        grpDeliveryZoneEditor.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpDeliveryZoneEditor.Location = new Point(20, 419);
        grpDeliveryZoneEditor.Margin = new Padding(10);
        grpDeliveryZoneEditor.MinimumSize = new Size(1, 1);
        grpDeliveryZoneEditor.Name = "grpDeliveryZoneEditor";
        grpDeliveryZoneEditor.Padding = new Padding(0, 32, 0, 0);
        grpDeliveryZoneEditor.Size = new Size(1184, 207);
        grpDeliveryZoneEditor.TabIndex = 2;
        grpDeliveryZoneEditor.Text = "配送区域编辑";
        grpDeliveryZoneEditor.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // layoutDeliveryZoneEditor
        // 
        layoutDeliveryZoneEditor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        layoutDeliveryZoneEditor.ColumnCount = 6;
        layoutDeliveryZoneEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        layoutDeliveryZoneEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        layoutDeliveryZoneEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        layoutDeliveryZoneEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        layoutDeliveryZoneEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
        layoutDeliveryZoneEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        layoutDeliveryZoneEditor.Controls.Add(lblZoneProvince, 0, 0);
        layoutDeliveryZoneEditor.Controls.Add(txtZoneProvince, 1, 0);
        layoutDeliveryZoneEditor.Controls.Add(lblZoneCity, 2, 0);
        layoutDeliveryZoneEditor.Controls.Add(txtZoneCity, 3, 0);
        layoutDeliveryZoneEditor.Controls.Add(lblZoneDistrict, 4, 0);
        layoutDeliveryZoneEditor.Controls.Add(txtZoneDistrict, 5, 0);
        layoutDeliveryZoneEditor.Controls.Add(lblZoneFee, 0, 1);
        layoutDeliveryZoneEditor.Controls.Add(txtZoneFee, 1, 1);
        layoutDeliveryZoneEditor.Controls.Add(lblZoneSortOrder, 2, 1);
        layoutDeliveryZoneEditor.Controls.Add(txtZoneSortOrder, 3, 1);
        layoutDeliveryZoneEditor.Controls.Add(chkZoneIsActive, 4, 1);
        layoutDeliveryZoneEditor.Location = new Point(20, 40);
        layoutDeliveryZoneEditor.Name = "layoutDeliveryZoneEditor";
        layoutDeliveryZoneEditor.RowCount = 2;
        layoutDeliveryZoneEditor.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        layoutDeliveryZoneEditor.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        layoutDeliveryZoneEditor.Size = new Size(1144, 90);
        layoutDeliveryZoneEditor.TabIndex = 0;
        layoutDeliveryZoneEditor.TagString = null;
        // 
        // lblZoneProvince
        // 
        lblZoneProvince.Anchor = AnchorStyles.None;
        lblZoneProvince.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblZoneProvince.ForeColor = Color.FromArgb(48, 48, 48);
        lblZoneProvince.Location = new Point(3, 5);
        lblZoneProvince.Name = "lblZoneProvince";
        lblZoneProvince.Size = new Size(74, 34);
        lblZoneProvince.TabIndex = 0;
        lblZoneProvince.Text = "省份：";
        // 
        // txtZoneProvince
        // 
        txtZoneProvince.Anchor = AnchorStyles.None;
        txtZoneProvince.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtZoneProvince.Location = new Point(154, 5);
        txtZoneProvince.Margin = new Padding(4, 5, 4, 5);
        txtZoneProvince.MinimumSize = new Size(1, 16);
        txtZoneProvince.Name = "txtZoneProvince";
        txtZoneProvince.Padding = new Padding(5);
        txtZoneProvince.ShowText = false;
        txtZoneProvince.Size = new Size(145, 35);
        txtZoneProvince.TabIndex = 1;
        txtZoneProvince.TextAlignment = ContentAlignment.MiddleLeft;
        txtZoneProvince.Watermark = "";
        // 
        // lblZoneCity
        // 
        lblZoneCity.Anchor = AnchorStyles.None;
        lblZoneCity.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblZoneCity.ForeColor = Color.FromArgb(48, 48, 48);
        lblZoneCity.Location = new Point(377, 5);
        lblZoneCity.Name = "lblZoneCity";
        lblZoneCity.Size = new Size(74, 34);
        lblZoneCity.TabIndex = 2;
        lblZoneCity.Text = "城市：";
        // 
        // txtZoneCity
        // 
        txtZoneCity.Anchor = AnchorStyles.None;
        txtZoneCity.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtZoneCity.Location = new Point(528, 5);
        txtZoneCity.Margin = new Padding(4, 5, 4, 5);
        txtZoneCity.MinimumSize = new Size(1, 16);
        txtZoneCity.Name = "txtZoneCity";
        txtZoneCity.Padding = new Padding(5);
        txtZoneCity.ShowText = false;
        txtZoneCity.Size = new Size(145, 35);
        txtZoneCity.TabIndex = 3;
        txtZoneCity.TextAlignment = ContentAlignment.MiddleLeft;
        txtZoneCity.Watermark = "";
        // 
        // lblZoneDistrict
        // 
        lblZoneDistrict.Anchor = AnchorStyles.None;
        lblZoneDistrict.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblZoneDistrict.ForeColor = Color.FromArgb(48, 48, 48);
        lblZoneDistrict.Location = new Point(751, 5);
        lblZoneDistrict.Name = "lblZoneDistrict";
        lblZoneDistrict.Size = new Size(94, 34);
        lblZoneDistrict.TabIndex = 4;
        lblZoneDistrict.Text = "区县：";
        // 
        // txtZoneDistrict
        // 
        txtZoneDistrict.Anchor = AnchorStyles.None;
        txtZoneDistrict.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtZoneDistrict.Location = new Point(923, 5);
        txtZoneDistrict.Margin = new Padding(4, 5, 4, 5);
        txtZoneDistrict.MinimumSize = new Size(1, 16);
        txtZoneDistrict.Name = "txtZoneDistrict";
        txtZoneDistrict.Padding = new Padding(5);
        txtZoneDistrict.ShowText = false;
        txtZoneDistrict.Size = new Size(145, 35);
        txtZoneDistrict.TabIndex = 5;
        txtZoneDistrict.TextAlignment = ContentAlignment.MiddleLeft;
        txtZoneDistrict.Watermark = "";
        // 
        // lblZoneFee
        // 
        lblZoneFee.Anchor = AnchorStyles.None;
        lblZoneFee.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblZoneFee.ForeColor = Color.FromArgb(48, 48, 48);
        lblZoneFee.Location = new Point(3, 50);
        lblZoneFee.Name = "lblZoneFee";
        lblZoneFee.Size = new Size(74, 34);
        lblZoneFee.TabIndex = 6;
        lblZoneFee.Text = "配送费：";
        // 
        // txtZoneFee
        // 
        txtZoneFee.Anchor = AnchorStyles.None;
        txtZoneFee.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtZoneFee.Location = new Point(154, 50);
        txtZoneFee.Margin = new Padding(4, 5, 4, 5);
        txtZoneFee.MinimumSize = new Size(1, 16);
        txtZoneFee.Name = "txtZoneFee";
        txtZoneFee.Padding = new Padding(5);
        txtZoneFee.ShowText = false;
        txtZoneFee.Size = new Size(145, 35);
        txtZoneFee.TabIndex = 7;
        txtZoneFee.TextAlignment = ContentAlignment.MiddleLeft;
        txtZoneFee.Watermark = "";
        // 
        // lblZoneSortOrder
        // 
        lblZoneSortOrder.Anchor = AnchorStyles.None;
        lblZoneSortOrder.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblZoneSortOrder.ForeColor = Color.FromArgb(48, 48, 48);
        lblZoneSortOrder.Location = new Point(377, 50);
        lblZoneSortOrder.Name = "lblZoneSortOrder";
        lblZoneSortOrder.Size = new Size(74, 34);
        lblZoneSortOrder.TabIndex = 8;
        lblZoneSortOrder.Text = "排序：";
        // 
        // txtZoneSortOrder
        // 
        txtZoneSortOrder.Anchor = AnchorStyles.None;
        txtZoneSortOrder.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtZoneSortOrder.Location = new Point(528, 50);
        txtZoneSortOrder.Margin = new Padding(4, 5, 4, 5);
        txtZoneSortOrder.MinimumSize = new Size(1, 16);
        txtZoneSortOrder.Name = "txtZoneSortOrder";
        txtZoneSortOrder.Padding = new Padding(5);
        txtZoneSortOrder.ShowText = false;
        txtZoneSortOrder.Size = new Size(145, 35);
        txtZoneSortOrder.TabIndex = 9;
        txtZoneSortOrder.TextAlignment = ContentAlignment.MiddleLeft;
        txtZoneSortOrder.Watermark = "";
        // 
        // chkZoneIsActive
        // 
        chkZoneIsActive.Anchor = AnchorStyles.None;
        chkZoneIsActive.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        chkZoneIsActive.ForeColor = Color.FromArgb(48, 48, 48);
        chkZoneIsActive.Location = new Point(751, 48);
        chkZoneIsActive.MinimumSize = new Size(1, 1);
        chkZoneIsActive.Name = "chkZoneIsActive";
        chkZoneIsActive.Size = new Size(94, 38);
        chkZoneIsActive.TabIndex = 10;
        chkZoneIsActive.Text = "可配送";
        // 
        // panelDeliveryZoneActions
        // 
        panelDeliveryZoneActions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        panelDeliveryZoneActions.Controls.Add(btnAddDeliveryZone);
        panelDeliveryZoneActions.Controls.Add(btnUpdateDeliveryZone);
        panelDeliveryZoneActions.Controls.Add(btnDeleteDeliveryZone);
        panelDeliveryZoneActions.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        panelDeliveryZoneActions.Location = new Point(20, 119);
        panelDeliveryZoneActions.Margin = new Padding(4, 5, 4, 5);
        panelDeliveryZoneActions.MinimumSize = new Size(1, 1);
        panelDeliveryZoneActions.Name = "panelDeliveryZoneActions";
        panelDeliveryZoneActions.Padding = new Padding(2);
        panelDeliveryZoneActions.ShowText = false;
        panelDeliveryZoneActions.Size = new Size(400, 50);
        panelDeliveryZoneActions.TabIndex = 1;
        panelDeliveryZoneActions.Text = null;
        panelDeliveryZoneActions.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // btnAddDeliveryZone
        // 
        btnAddDeliveryZone.FillColor = Color.FromArgb(51, 122, 183);
        btnAddDeliveryZone.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnAddDeliveryZone.Location = new Point(10, 6);
        btnAddDeliveryZone.MinimumSize = new Size(1, 1);
        btnAddDeliveryZone.Name = "btnAddDeliveryZone";
        btnAddDeliveryZone.Radius = 8;
        btnAddDeliveryZone.RectColor = Color.FromArgb(51, 122, 183);
        btnAddDeliveryZone.Size = new Size(120, 38);
        btnAddDeliveryZone.TabIndex = 0;
        btnAddDeliveryZone.Text = "新增区域";
        btnAddDeliveryZone.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // btnUpdateDeliveryZone
        // 
        btnUpdateDeliveryZone.FillColor = Color.FromArgb(51, 122, 183);
        btnUpdateDeliveryZone.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnUpdateDeliveryZone.Location = new Point(140, 6);
        btnUpdateDeliveryZone.MinimumSize = new Size(1, 1);
        btnUpdateDeliveryZone.Name = "btnUpdateDeliveryZone";
        btnUpdateDeliveryZone.Radius = 8;
        btnUpdateDeliveryZone.RectColor = Color.FromArgb(51, 122, 183);
        btnUpdateDeliveryZone.Size = new Size(120, 38);
        btnUpdateDeliveryZone.TabIndex = 1;
        btnUpdateDeliveryZone.Text = "更新区域";
        btnUpdateDeliveryZone.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // btnDeleteDeliveryZone
        // 
        btnDeleteDeliveryZone.FillColor = Color.FromArgb(211, 47, 47);
        btnDeleteDeliveryZone.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnDeleteDeliveryZone.Location = new Point(270, 6);
        btnDeleteDeliveryZone.MinimumSize = new Size(1, 1);
        btnDeleteDeliveryZone.Name = "btnDeleteDeliveryZone";
        btnDeleteDeliveryZone.Radius = 8;
        btnDeleteDeliveryZone.RectColor = Color.FromArgb(211, 47, 47);
        btnDeleteDeliveryZone.Size = new Size(120, 38);
        btnDeleteDeliveryZone.TabIndex = 2;
        btnDeleteDeliveryZone.Text = "删除区域";
        btnDeleteDeliveryZone.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // tabDiningTables
        // 
        tabDiningTables.Controls.Add(layoutDiningTablesPage);
        tabDiningTables.Location = new Point(0, 40);
        tabDiningTables.Name = "tabDiningTables";
        tabDiningTables.Size = new Size(1224, 646);
        tabDiningTables.TabIndex = 5;
        tabDiningTables.Text = "餐桌管理";
        tabDiningTables.UseVisualStyleBackColor = true;
        // 
        // layoutDiningTablesPage
        // 
        layoutDiningTablesPage.ColumnCount = 1;
        layoutDiningTablesPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutDiningTablesPage.Controls.Add(panelDiningTableTop, 0, 0);
        layoutDiningTablesPage.Controls.Add(dgvDiningTables, 0, 1);
        layoutDiningTablesPage.Controls.Add(grpDiningTableEditor, 0, 2);
        layoutDiningTablesPage.Dock = DockStyle.Fill;
        layoutDiningTablesPage.Location = new Point(0, 0);
        layoutDiningTablesPage.Name = "layoutDiningTablesPage";
        layoutDiningTablesPage.Padding = new Padding(10);
        layoutDiningTablesPage.RowCount = 3;
        layoutDiningTablesPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutDiningTablesPage.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
        layoutDiningTablesPage.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
        layoutDiningTablesPage.Size = new Size(1224, 646);
        layoutDiningTablesPage.TabIndex = 0;
        layoutDiningTablesPage.TagString = null;
        // 
        // panelDiningTableTop
        // 
        panelDiningTableTop.Controls.Add(btnLoadDiningTables);
        panelDiningTableTop.Dock = DockStyle.Fill;
        panelDiningTableTop.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        panelDiningTableTop.Location = new Point(14, 15);
        panelDiningTableTop.Margin = new Padding(4, 5, 4, 5);
        panelDiningTableTop.MinimumSize = new Size(1, 1);
        panelDiningTableTop.Name = "panelDiningTableTop";
        panelDiningTableTop.Padding = new Padding(2);
        panelDiningTableTop.ShowText = false;
        panelDiningTableTop.Size = new Size(1196, 50);
        panelDiningTableTop.TabIndex = 0;
        panelDiningTableTop.Text = null;
        panelDiningTableTop.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // btnLoadDiningTables
        // 
        btnLoadDiningTables.FillColor = Color.FromArgb(51, 122, 183);
        btnLoadDiningTables.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnLoadDiningTables.Location = new Point(10, 8);
        btnLoadDiningTables.MinimumSize = new Size(1, 1);
        btnLoadDiningTables.Name = "btnLoadDiningTables";
        btnLoadDiningTables.Radius = 8;
        btnLoadDiningTables.RectColor = Color.FromArgb(51, 122, 183);
        btnLoadDiningTables.Size = new Size(120, 38);
        btnLoadDiningTables.TabIndex = 0;
        btnLoadDiningTables.Text = "加载餐桌";
        btnLoadDiningTables.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // dgvDiningTables
        // 
        dgvDiningTables.AllowUserToAddRows = false;
        dgvDiningTables.AllowUserToDeleteRows = false;
        dataGridViewCellStyle30.BackColor = Color.FromArgb(235, 243, 255);
        dgvDiningTables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle30;
        dgvDiningTables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvDiningTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDiningTables.BackgroundColor = Color.White;
        dgvDiningTables.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle31.BackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle31.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle31.ForeColor = Color.White;
        dataGridViewCellStyle31.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle31.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle31.WrapMode = DataGridViewTriState.True;
        dgvDiningTables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
        dgvDiningTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDiningTables.EnableHeadersVisualStyles = false;
        dgvDiningTables.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvDiningTables.GridColor = Color.FromArgb(80, 160, 255);
        dgvDiningTables.Location = new Point(20, 80);
        dgvDiningTables.Margin = new Padding(10);
        dgvDiningTables.MultiSelect = false;
        dgvDiningTables.Name = "dgvDiningTables";
        dgvDiningTables.ReadOnly = true;
        dgvDiningTables.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle32.BackColor = Color.FromArgb(235, 243, 255);
        dataGridViewCellStyle32.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle32.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle32.SelectionBackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle32.SelectionForeColor = Color.White;
        dataGridViewCellStyle32.WrapMode = DataGridViewTriState.True;
        dgvDiningTables.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
        dgvDiningTables.RowHeadersWidth = 30;
        dataGridViewCellStyle33.BackColor = Color.White;
        dataGridViewCellStyle33.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvDiningTables.RowsDefaultCellStyle = dataGridViewCellStyle33;
        dgvDiningTables.SelectedIndex = -1;
        dgvDiningTables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDiningTables.Size = new Size(1184, 319);
        dgvDiningTables.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvDiningTables.TabIndex = 1;
        // 
        // grpDiningTableEditor
        // 
        grpDiningTableEditor.Controls.Add(layoutDiningTableEditor);
        grpDiningTableEditor.Controls.Add(panelDiningTableActions);
        grpDiningTableEditor.Dock = DockStyle.Fill;
        grpDiningTableEditor.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpDiningTableEditor.Location = new Point(20, 419);
        grpDiningTableEditor.Margin = new Padding(10);
        grpDiningTableEditor.MinimumSize = new Size(1, 1);
        grpDiningTableEditor.Name = "grpDiningTableEditor";
        grpDiningTableEditor.Padding = new Padding(0, 32, 0, 0);
        grpDiningTableEditor.Size = new Size(1184, 207);
        grpDiningTableEditor.TabIndex = 2;
        grpDiningTableEditor.Text = "餐桌编辑";
        grpDiningTableEditor.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // layoutDiningTableEditor
        // 
        layoutDiningTableEditor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        layoutDiningTableEditor.ColumnCount = 4;
        layoutDiningTableEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        layoutDiningTableEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutDiningTableEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
        layoutDiningTableEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutDiningTableEditor.Controls.Add(lblDiningTableNumber, 0, 0);
        layoutDiningTableEditor.Controls.Add(txtDiningTableNumber, 1, 0);
        layoutDiningTableEditor.Controls.Add(lblDiningTableSeats, 2, 0);
        layoutDiningTableEditor.Controls.Add(txtDiningTableSeats, 3, 0);
        layoutDiningTableEditor.Controls.Add(chkDiningTableOccupied, 0, 1);
        layoutDiningTableEditor.Controls.Add(chkDiningTableEnabled, 2, 1);
        layoutDiningTableEditor.Location = new Point(20, 40);
        layoutDiningTableEditor.Name = "layoutDiningTableEditor";
        layoutDiningTableEditor.RowCount = 2;
        layoutDiningTableEditor.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        layoutDiningTableEditor.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        layoutDiningTableEditor.Size = new Size(1144, 90);
        layoutDiningTableEditor.TabIndex = 0;
        layoutDiningTableEditor.TagString = null;
        // 
        // lblDiningTableNumber
        // 
        lblDiningTableNumber.Anchor = AnchorStyles.None;
        lblDiningTableNumber.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblDiningTableNumber.ForeColor = Color.FromArgb(48, 48, 48);
        lblDiningTableNumber.Location = new Point(3, 5);
        lblDiningTableNumber.Name = "lblDiningTableNumber";
        lblDiningTableNumber.Size = new Size(74, 34);
        lblDiningTableNumber.TabIndex = 0;
        lblDiningTableNumber.Text = "桌号：";
        // 
        // txtDiningTableNumber
        // 
        txtDiningTableNumber.Anchor = AnchorStyles.None;
        txtDiningTableNumber.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtDiningTableNumber.Location = new Point(248, 5);
        txtDiningTableNumber.Margin = new Padding(4, 5, 4, 5);
        txtDiningTableNumber.MinimumSize = new Size(1, 16);
        txtDiningTableNumber.Name = "txtDiningTableNumber";
        txtDiningTableNumber.Padding = new Padding(5);
        txtDiningTableNumber.ShowText = false;
        txtDiningTableNumber.Size = new Size(145, 35);
        txtDiningTableNumber.TabIndex = 1;
        txtDiningTableNumber.TextAlignment = ContentAlignment.MiddleLeft;
        txtDiningTableNumber.Watermark = "";
        // 
        // lblDiningTableSeats
        // 
        lblDiningTableSeats.Anchor = AnchorStyles.None;
        lblDiningTableSeats.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblDiningTableSeats.ForeColor = Color.FromArgb(48, 48, 48);
        lblDiningTableSeats.Location = new Point(565, 5);
        lblDiningTableSeats.Name = "lblDiningTableSeats";
        lblDiningTableSeats.Size = new Size(94, 34);
        lblDiningTableSeats.TabIndex = 2;
        lblDiningTableSeats.Text = "座位数：";
        // 
        // txtDiningTableSeats
        // 
        txtDiningTableSeats.Anchor = AnchorStyles.None;
        txtDiningTableSeats.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtDiningTableSeats.Location = new Point(830, 5);
        txtDiningTableSeats.Margin = new Padding(4, 5, 4, 5);
        txtDiningTableSeats.MinimumSize = new Size(1, 16);
        txtDiningTableSeats.Name = "txtDiningTableSeats";
        txtDiningTableSeats.Padding = new Padding(5);
        txtDiningTableSeats.ShowText = false;
        txtDiningTableSeats.Size = new Size(145, 35);
        txtDiningTableSeats.TabIndex = 3;
        txtDiningTableSeats.TextAlignment = ContentAlignment.MiddleLeft;
        txtDiningTableSeats.Watermark = "";
        // 
        // chkDiningTableOccupied
        // 
        chkDiningTableOccupied.Anchor = AnchorStyles.None;
        chkDiningTableOccupied.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        chkDiningTableOccupied.ForeColor = Color.FromArgb(48, 48, 48);
        chkDiningTableOccupied.Location = new Point(3, 48);
        chkDiningTableOccupied.MinimumSize = new Size(1, 1);
        chkDiningTableOccupied.Name = "chkDiningTableOccupied";
        chkDiningTableOccupied.Size = new Size(74, 38);
        chkDiningTableOccupied.TabIndex = 4;
        chkDiningTableOccupied.Text = "占用中";
        // 
        // chkDiningTableEnabled
        // 
        chkDiningTableEnabled.Anchor = AnchorStyles.None;
        chkDiningTableEnabled.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        chkDiningTableEnabled.ForeColor = Color.FromArgb(48, 48, 48);
        chkDiningTableEnabled.Location = new Point(565, 48);
        chkDiningTableEnabled.MinimumSize = new Size(1, 1);
        chkDiningTableEnabled.Name = "chkDiningTableEnabled";
        chkDiningTableEnabled.Size = new Size(94, 38);
        chkDiningTableEnabled.TabIndex = 5;
        chkDiningTableEnabled.Text = "启用";
        // 
        // panelDiningTableActions
        // 
        panelDiningTableActions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        panelDiningTableActions.Controls.Add(btnAddDiningTable);
        panelDiningTableActions.Controls.Add(btnUpdateDiningTable);
        panelDiningTableActions.Controls.Add(btnDeleteDiningTable);
        panelDiningTableActions.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        panelDiningTableActions.Location = new Point(20, 119);
        panelDiningTableActions.Margin = new Padding(4, 5, 4, 5);
        panelDiningTableActions.MinimumSize = new Size(1, 1);
        panelDiningTableActions.Name = "panelDiningTableActions";
        panelDiningTableActions.Padding = new Padding(2);
        panelDiningTableActions.ShowText = false;
        panelDiningTableActions.Size = new Size(400, 50);
        panelDiningTableActions.TabIndex = 1;
        panelDiningTableActions.Text = null;
        panelDiningTableActions.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // btnAddDiningTable
        // 
        btnAddDiningTable.FillColor = Color.FromArgb(51, 122, 183);
        btnAddDiningTable.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnAddDiningTable.Location = new Point(10, 6);
        btnAddDiningTable.MinimumSize = new Size(1, 1);
        btnAddDiningTable.Name = "btnAddDiningTable";
        btnAddDiningTable.Radius = 8;
        btnAddDiningTable.RectColor = Color.FromArgb(51, 122, 183);
        btnAddDiningTable.Size = new Size(120, 38);
        btnAddDiningTable.TabIndex = 0;
        btnAddDiningTable.Text = "新增餐桌";
        btnAddDiningTable.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // btnUpdateDiningTable
        // 
        btnUpdateDiningTable.FillColor = Color.FromArgb(51, 122, 183);
        btnUpdateDiningTable.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnUpdateDiningTable.Location = new Point(140, 6);
        btnUpdateDiningTable.MinimumSize = new Size(1, 1);
        btnUpdateDiningTable.Name = "btnUpdateDiningTable";
        btnUpdateDiningTable.Radius = 8;
        btnUpdateDiningTable.RectColor = Color.FromArgb(51, 122, 183);
        btnUpdateDiningTable.Size = new Size(120, 38);
        btnUpdateDiningTable.TabIndex = 1;
        btnUpdateDiningTable.Text = "更新餐桌";
        btnUpdateDiningTable.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // btnDeleteDiningTable
        // 
        btnDeleteDiningTable.FillColor = Color.FromArgb(211, 47, 47);
        btnDeleteDiningTable.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnDeleteDiningTable.Location = new Point(270, 6);
        btnDeleteDiningTable.MinimumSize = new Size(1, 1);
        btnDeleteDiningTable.Name = "btnDeleteDiningTable";
        btnDeleteDiningTable.Radius = 8;
        btnDeleteDiningTable.RectColor = Color.FromArgb(211, 47, 47);
        btnDeleteDiningTable.Size = new Size(120, 38);
        btnDeleteDiningTable.TabIndex = 2;
        btnDeleteDiningTable.Text = "删除餐桌";
        btnDeleteDiningTable.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // tabUsers
        // 
        tabUsers.Controls.Add(layoutUsersPage);
        tabUsers.Location = new Point(0, 40);
        tabUsers.Name = "tabUsers";
        tabUsers.Size = new Size(1224, 646);
        tabUsers.TabIndex = 6;
        tabUsers.Text = "账号管理";
        tabUsers.UseVisualStyleBackColor = true;
        // 
        // layoutUsersPage
        // 
        layoutUsersPage.ColumnCount = 1;
        layoutUsersPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutUsersPage.Controls.Add(panelUsersTop, 0, 0);
        layoutUsersPage.Controls.Add(dgvUsers, 0, 1);
        layoutUsersPage.Controls.Add(grpUserEditor, 0, 2);
        layoutUsersPage.Dock = DockStyle.Fill;
        layoutUsersPage.Location = new Point(0, 0);
        layoutUsersPage.Name = "layoutUsersPage";
        layoutUsersPage.Padding = new Padding(10);
        layoutUsersPage.RowCount = 3;
        layoutUsersPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutUsersPage.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
        layoutUsersPage.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
        layoutUsersPage.Size = new Size(1224, 646);
        layoutUsersPage.TabIndex = 0;
        layoutUsersPage.TagString = null;
        // 
        // panelUsersTop
        // 
        panelUsersTop.Controls.Add(btnLoadUsers);
        panelUsersTop.Dock = DockStyle.Fill;
        panelUsersTop.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        panelUsersTop.Location = new Point(14, 15);
        panelUsersTop.Margin = new Padding(4, 5, 4, 5);
        panelUsersTop.MinimumSize = new Size(1, 1);
        panelUsersTop.Name = "panelUsersTop";
        panelUsersTop.Padding = new Padding(2);
        panelUsersTop.ShowText = false;
        panelUsersTop.Size = new Size(1196, 50);
        panelUsersTop.TabIndex = 0;
        panelUsersTop.Text = null;
        panelUsersTop.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // btnLoadUsers
        // 
        btnLoadUsers.FillColor = Color.FromArgb(51, 122, 183);
        btnLoadUsers.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnLoadUsers.Location = new Point(10, 8);
        btnLoadUsers.MinimumSize = new Size(1, 1);
        btnLoadUsers.Name = "btnLoadUsers";
        btnLoadUsers.Radius = 8;
        btnLoadUsers.RectColor = Color.FromArgb(51, 122, 183);
        btnLoadUsers.Size = new Size(120, 38);
        btnLoadUsers.TabIndex = 0;
        btnLoadUsers.Text = "加载用户";
        btnLoadUsers.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // dgvUsers
        // 
        dgvUsers.AllowUserToAddRows = false;
        dgvUsers.AllowUserToDeleteRows = false;
        dataGridViewCellStyle30.BackColor = Color.FromArgb(235, 243, 255);
        dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle30;
        dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvUsers.BackgroundColor = Color.White;
        dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle31.BackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle31.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle31.ForeColor = Color.White;
        dataGridViewCellStyle31.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle31.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle31.WrapMode = DataGridViewTriState.True;
        dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvUsers.EnableHeadersVisualStyles = false;
        dgvUsers.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvUsers.GridColor = Color.FromArgb(80, 160, 255);
        dgvUsers.Location = new Point(20, 80);
        dgvUsers.Margin = new Padding(10);
        dgvUsers.MultiSelect = false;
        dgvUsers.Name = "dgvUsers";
        dgvUsers.ReadOnly = true;
        dgvUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle32.BackColor = Color.FromArgb(235, 243, 255);
        dataGridViewCellStyle32.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dataGridViewCellStyle32.ForeColor = Color.FromArgb(48, 48, 48);
        dataGridViewCellStyle32.SelectionBackColor = Color.FromArgb(80, 160, 255);
        dataGridViewCellStyle32.SelectionForeColor = Color.White;
        dataGridViewCellStyle32.WrapMode = DataGridViewTriState.True;
        dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
        dgvUsers.RowHeadersWidth = 30;
        dataGridViewCellStyle33.BackColor = Color.White;
        dataGridViewCellStyle33.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvUsers.RowsDefaultCellStyle = dataGridViewCellStyle33;
        dgvUsers.SelectedIndex = -1;
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvUsers.Size = new Size(1184, 319);
        dgvUsers.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvUsers.TabIndex = 1;
        // 
        // grpUserEditor
        // 
        grpUserEditor.Controls.Add(layoutUserEditor);
        grpUserEditor.Controls.Add(panelUserActions);
        grpUserEditor.Dock = DockStyle.Fill;
        grpUserEditor.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        grpUserEditor.Location = new Point(20, 419);
        grpUserEditor.Margin = new Padding(10);
        grpUserEditor.MinimumSize = new Size(1, 1);
        grpUserEditor.Name = "grpUserEditor";
        grpUserEditor.Padding = new Padding(0, 32, 0, 0);
        grpUserEditor.Size = new Size(1184, 207);
        grpUserEditor.TabIndex = 2;
        grpUserEditor.Text = "用户编辑";
        grpUserEditor.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // layoutUserEditor
        // 
        layoutUserEditor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        layoutUserEditor.ColumnCount = 6;
        layoutUserEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        layoutUserEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        layoutUserEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        layoutUserEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        layoutUserEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
        layoutUserEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        layoutUserEditor.Controls.Add(lblUsername, 0, 0);
        layoutUserEditor.Controls.Add(txtUsername, 1, 0);
        layoutUserEditor.Controls.Add(lblRealName, 2, 0);
        layoutUserEditor.Controls.Add(txtRealName, 3, 0);
        layoutUserEditor.Controls.Add(lblUserPhone, 4, 0);
        layoutUserEditor.Controls.Add(txtUserPhone, 5, 0);
        layoutUserEditor.Controls.Add(lblUserAddress, 0, 1);
        layoutUserEditor.Controls.Add(txtUserAddress, 1, 1);
        layoutUserEditor.Controls.Add(chkIsActive, 2, 1);
        layoutUserEditor.Location = new Point(20, 40);
        layoutUserEditor.Name = "layoutUserEditor";
        layoutUserEditor.RowCount = 2;
        layoutUserEditor.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        layoutUserEditor.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        layoutUserEditor.Size = new Size(1144, 90);
        layoutUserEditor.TabIndex = 0;
        layoutUserEditor.TagString = null;
        // 
        // lblUsername
        // 
        lblUsername.Anchor = AnchorStyles.None;
        lblUsername.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblUsername.ForeColor = Color.FromArgb(48, 48, 48);
        lblUsername.Location = new Point(3, 5);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(74, 34);
        lblUsername.TabIndex = 0;
        lblUsername.Text = "用户名：";
        // 
        // txtUsername
        // 
        txtUsername.Anchor = AnchorStyles.None;
        txtUsername.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtUsername.Location = new Point(154, 5);
        txtUsername.Margin = new Padding(4, 5, 4, 5);
        txtUsername.MinimumSize = new Size(1, 16);
        txtUsername.Name = "txtUsername";
        txtUsername.Padding = new Padding(5);
        txtUsername.ReadOnly = true;
        txtUsername.ShowText = false;
        txtUsername.Size = new Size(145, 35);
        txtUsername.TabIndex = 1;
        txtUsername.TextAlignment = ContentAlignment.MiddleLeft;
        txtUsername.Watermark = "";
        // 
        // lblRealName
        // 
        lblRealName.Anchor = AnchorStyles.None;
        lblRealName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblRealName.ForeColor = Color.FromArgb(48, 48, 48);
        lblRealName.Location = new Point(377, 5);
        lblRealName.Name = "lblRealName";
        lblRealName.Size = new Size(74, 34);
        lblRealName.TabIndex = 2;
        lblRealName.Text = "姓名：";
        // 
        // txtRealName
        // 
        txtRealName.Anchor = AnchorStyles.None;
        txtRealName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtRealName.Location = new Point(528, 5);
        txtRealName.Margin = new Padding(4, 5, 4, 5);
        txtRealName.MinimumSize = new Size(1, 16);
        txtRealName.Name = "txtRealName";
        txtRealName.Padding = new Padding(5);
        txtRealName.ShowText = false;
        txtRealName.Size = new Size(145, 35);
        txtRealName.TabIndex = 3;
        txtRealName.TextAlignment = ContentAlignment.MiddleLeft;
        txtRealName.Watermark = "";
        // 
        // lblUserPhone
        // 
        lblUserPhone.Anchor = AnchorStyles.None;
        lblUserPhone.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblUserPhone.ForeColor = Color.FromArgb(48, 48, 48);
        lblUserPhone.Location = new Point(751, 5);
        lblUserPhone.Name = "lblUserPhone";
        lblUserPhone.Size = new Size(94, 34);
        lblUserPhone.TabIndex = 4;
        lblUserPhone.Text = "电话：";
        // 
        // txtUserPhone
        // 
        txtUserPhone.Anchor = AnchorStyles.None;
        txtUserPhone.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtUserPhone.Location = new Point(923, 5);
        txtUserPhone.Margin = new Padding(4, 5, 4, 5);
        txtUserPhone.MinimumSize = new Size(1, 16);
        txtUserPhone.Name = "txtUserPhone";
        txtUserPhone.Padding = new Padding(5);
        txtUserPhone.ShowText = false;
        txtUserPhone.Size = new Size(145, 35);
        txtUserPhone.TabIndex = 5;
        txtUserPhone.TextAlignment = ContentAlignment.MiddleLeft;
        txtUserPhone.Watermark = "";
        // 
        // lblUserAddress
        // 
        lblUserAddress.Anchor = AnchorStyles.None;
        lblUserAddress.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblUserAddress.ForeColor = Color.FromArgb(48, 48, 48);
        lblUserAddress.Location = new Point(3, 50);
        lblUserAddress.Name = "lblUserAddress";
        lblUserAddress.Size = new Size(74, 34);
        lblUserAddress.TabIndex = 6;
        lblUserAddress.Text = "地址：";
        // 
        // txtUserAddress
        // 
        txtUserAddress.Anchor = AnchorStyles.None;
        txtUserAddress.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtUserAddress.Location = new Point(154, 50);
        txtUserAddress.Margin = new Padding(4, 5, 4, 5);
        txtUserAddress.MinimumSize = new Size(1, 16);
        txtUserAddress.Name = "txtUserAddress";
        txtUserAddress.Padding = new Padding(5);
        txtUserAddress.ShowText = false;
        txtUserAddress.Size = new Size(145, 35);
        txtUserAddress.TabIndex = 7;
        txtUserAddress.TextAlignment = ContentAlignment.MiddleLeft;
        txtUserAddress.Watermark = "";
        // 
        // chkIsActive
        // 
        chkIsActive.Anchor = AnchorStyles.None;
        chkIsActive.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        chkIsActive.ForeColor = Color.FromArgb(48, 48, 48);
        chkIsActive.Location = new Point(377, 48);
        chkIsActive.MinimumSize = new Size(1, 1);
        chkIsActive.Name = "chkIsActive";
        chkIsActive.Size = new Size(74, 38);
        chkIsActive.TabIndex = 8;
        chkIsActive.Text = "启用";
        // 
        // panelUserActions
        // 
        panelUserActions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        panelUserActions.Controls.Add(btnAddUser);
        panelUserActions.Controls.Add(btnUpdateUser);
        panelUserActions.Controls.Add(btnDeleteUser);
        panelUserActions.Controls.Add(btnResetPassword);
        panelUserActions.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        panelUserActions.Location = new Point(20, 119);
        panelUserActions.Margin = new Padding(4, 5, 4, 5);
        panelUserActions.MinimumSize = new Size(1, 1);
        panelUserActions.Name = "panelUserActions";
        panelUserActions.Padding = new Padding(2);
        panelUserActions.ShowText = false;
        panelUserActions.Size = new Size(520, 50);
        panelUserActions.TabIndex = 1;
        panelUserActions.Text = null;
        panelUserActions.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // btnAddUser
        // 
        btnAddUser.FillColor = Color.FromArgb(51, 122, 183);
        btnAddUser.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnAddUser.Location = new Point(10, 6);
        btnAddUser.MinimumSize = new Size(1, 1);
        btnAddUser.Name = "btnAddUser";
        btnAddUser.Radius = 8;
        btnAddUser.RectColor = Color.FromArgb(51, 122, 183);
        btnAddUser.Size = new Size(110, 38);
        btnAddUser.TabIndex = 0;
        btnAddUser.Text = "新增用户";
        btnAddUser.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // btnUpdateUser
        // 
        btnUpdateUser.FillColor = Color.FromArgb(51, 122, 183);
        btnUpdateUser.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnUpdateUser.Location = new Point(130, 6);
        btnUpdateUser.MinimumSize = new Size(1, 1);
        btnUpdateUser.Name = "btnUpdateUser";
        btnUpdateUser.Radius = 8;
        btnUpdateUser.RectColor = Color.FromArgb(51, 122, 183);
        btnUpdateUser.Size = new Size(110, 38);
        btnUpdateUser.TabIndex = 1;
        btnUpdateUser.Text = "更新用户";
        btnUpdateUser.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // btnDeleteUser
        // 
        btnDeleteUser.FillColor = Color.FromArgb(211, 47, 47);
        btnDeleteUser.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnDeleteUser.Location = new Point(250, 6);
        btnDeleteUser.MinimumSize = new Size(1, 1);
        btnDeleteUser.Name = "btnDeleteUser";
        btnDeleteUser.Radius = 8;
        btnDeleteUser.RectColor = Color.FromArgb(211, 47, 47);
        btnDeleteUser.Size = new Size(110, 38);
        btnDeleteUser.TabIndex = 2;
        btnDeleteUser.Text = "删除用户";
        btnDeleteUser.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // btnResetPassword
        // 
        btnResetPassword.FillColor = Color.FromArgb(92, 184, 92);
        btnResetPassword.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnResetPassword.Location = new Point(370, 6);
        btnResetPassword.MinimumSize = new Size(1, 1);
        btnResetPassword.Name = "btnResetPassword";
        btnResetPassword.Radius = 8;
        btnResetPassword.RectColor = Color.FromArgb(92, 184, 92);
        btnResetPassword.Size = new Size(110, 38);
        btnResetPassword.TabIndex = 3;
        btnResetPassword.Text = "重置密码";
        btnResetPassword.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // Form1
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(1228, 724);
        Controls.Add(tabMain);
        Font = new Font("Microsoft YaHei UI", 10F);
        IconImage = (Image)resources.GetObject("$this.IconImage");
        MinimumSize = new Size(1089, 724);
        Name = "Form1";
        Padding = new Padding(2, 36, 2, 2);
        Resizable = true;
        StartPosition = FormStartPosition.CenterParent;
        Text = "珞珈线上点餐系统-管理员端";
        ZoomScaleRect = new Rectangle(22, 22, 1228, 724);
        tabMain.ResumeLayout(false);
        tabDishes.ResumeLayout(false);
        layoutDishPage.ResumeLayout(false);
        grpDishEdit.ResumeLayout(false);
        layoutDishEdit.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picDishImage).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvDishes).EndInit();
        tabOrders.ResumeLayout(false);
        layoutOrderPage.ResumeLayout(false);
        panelOrderTop.ResumeLayout(false);
        layoutOrderMain.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        grpOrderDetail.ResumeLayout(false);
        grpOrderItems.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
        tabStatistics.ResumeLayout(false);
        layoutStatisticsPage.ResumeLayout(false);
        layoutStatisticsTop.ResumeLayout(false);
        layoutStatisticsSummary.ResumeLayout(false);
        grpTotalOrders.ResumeLayout(false);
        grpTotalRevenue.ResumeLayout(false);
        grpTopDishCount.ResumeLayout(false);
        grpAverageOrderAmount.ResumeLayout(false);
        layoutStatisticsMain.ResumeLayout(false);
        grpTopDishes.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvTopDishes).EndInit();
        grpTopDishesChart.ResumeLayout(false);
        panelTopDishesChart.ResumeLayout(false);
        grpRevenueStatistics.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvRevenueStatistics).EndInit();
        grpStatisticsRemark.ResumeLayout(false);
        tabAi.ResumeLayout(false);
        layoutAiPage.ResumeLayout(false);
        layoutAiTop.ResumeLayout(false);
        grpAiSuggestion.ResumeLayout(false);
        grpAiError.ResumeLayout(false);
        tabDeliveryZones.ResumeLayout(false);
        layoutDeliveryZonesPage.ResumeLayout(false);
        panelDeliveryZoneTop.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvDeliveryZones).EndInit();
        grpDeliveryZoneEditor.ResumeLayout(false);
        layoutDeliveryZoneEditor.ResumeLayout(false);
        panelDeliveryZoneActions.ResumeLayout(false);
        tabDiningTables.ResumeLayout(false);
        layoutDiningTablesPage.ResumeLayout(false);
        panelDiningTableTop.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvDiningTables).EndInit();
        grpDiningTableEditor.ResumeLayout(false);
        layoutDiningTableEditor.ResumeLayout(false);
        panelDiningTableActions.ResumeLayout(false);
        tabUsers.ResumeLayout(false);
        layoutUsersPage.ResumeLayout(false);
        panelUsersTop.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
        grpUserEditor.ResumeLayout(false);
        layoutUserEditor.ResumeLayout(false);
        panelUserActions.ResumeLayout(false);
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
    private Sunny.UI.UIFlowLayoutPanel panelOrderActions;
    private Sunny.UI.UILabel lblOrderActionHint;
    private Sunny.UI.UIButton btnConfirmOrder;
    private Sunny.UI.UIButton btnRejectOrder;
    private Sunny.UI.UIButton btnStartPreparing;
    private Sunny.UI.UIButton btnReady;
    private Sunny.UI.UIButton btnStartDelivery;
    private Sunny.UI.UIButton btnCompleteOrder;
    private Sunny.UI.UIButton btnCancelOrder;
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
    private Sunny.UI.UITableLayoutPanel layoutStatisticsPage;
    private Sunny.UI.UITableLayoutPanel layoutStatisticsTop;
    private Sunny.UI.UILabel uiLabel4;
    private Sunny.UI.UIDatePicker dtpStatisticsStart;
    private Sunny.UI.UILabel uiLabel5;
    private Sunny.UI.UILabel lblTopCountTitle;
    private Sunny.UI.UIDatePicker dtpStatisticsEnd;
    private Sunny.UI.UIDatePicker uiDatePicker2;
    private Sunny.UI.UITextBox txtTopCount;
    private Sunny.UI.UIButton btnLoadStatistics;
    private Sunny.UI.UIButton btnResetStatistics;
    private Sunny.UI.UITableLayoutPanel layoutStatisticsSummary;
    private Sunny.UI.UIGroupBox grpTotalOrders;
    private Sunny.UI.UILabel lblTotalOrders;
    private Sunny.UI.UIGroupBox grpTotalRevenue;
    private Sunny.UI.UILabel lblTotalRevenue;
    private Sunny.UI.UIGroupBox grpAverageOrderAmount;
    private Sunny.UI.UILabel lblAverageOrderAmount;
    private Sunny.UI.UIGroupBox grpTopDishCount;
    private Sunny.UI.UILabel lblTopDishCount;
    private Sunny.UI.UITableLayoutPanel layoutStatisticsMain;
    private Sunny.UI.UIGroupBox grpTopDishes;
    private Sunny.UI.UIDataGridView dgvTopDishes;
    private Sunny.UI.UIGroupBox grpTopDishesChart;
    private Sunny.UI.UIPanel panelTopDishesChart;
    private Sunny.UI.UILabel lblChartPlaceholder;
    private Sunny.UI.UIGroupBox grpRevenueStatistics;
    private Sunny.UI.UIGroupBox grpStatisticsRemark;
    private Sunny.UI.UIDataGridView dgvRevenueStatistics;
    private Sunny.UI.UITextBox txtStatisticsRemark;
    private Sunny.UI.UITableLayoutPanel layoutAiPage;
    private Sunny.UI.UITableLayoutPanel layoutAiTop;
    private Sunny.UI.UIButton btnLoadAiSuggestion;
    private Sunny.UI.UILabel lblAiHint;
    private Sunny.UI.UIGroupBox grpAiSuggestion;
    private Sunny.UI.UITextBox txtAiSuggestion;
    private Sunny.UI.UIGroupBox grpAiError;
    private Sunny.UI.UITextBox txtAiError;
    private Sunny.UI.UILabel lblImagePath;
    private Sunny.UI.UITextBox txtImagePath;
    private Sunny.UI.UIButton btnChooseImage;
    private Sunny.UI.UICheckBox chkIsAvailable;
    private Sunny.UI.UIComboBox cmbSpicyLevel;
    private Sunny.UI.UILabel lblSpicyCondition;
    private Sunny.UI.UILabel lblDescription;
    private Sunny.UI.UITextBox txtDescription;
    private PictureBox picDishImage;
    private Sunny.UI.UILabel lblPicture;

    // 配送区域管理页控件
    private TabPage tabDeliveryZones;
    private Sunny.UI.UITableLayoutPanel layoutDeliveryZonesPage;
    private Sunny.UI.UIFlowLayoutPanel panelDeliveryZoneTop;
    private Sunny.UI.UIButton btnLoadDeliveryZones;
    private Sunny.UI.UIGroupBox grpDeliveryZoneEditor;
    private Sunny.UI.UITableLayoutPanel layoutDeliveryZoneEditor;
    private Sunny.UI.UILabel lblZoneProvince;
    private Sunny.UI.UITextBox txtZoneProvince;
    private Sunny.UI.UILabel lblZoneCity;
    private Sunny.UI.UITextBox txtZoneCity;
    private Sunny.UI.UILabel lblZoneDistrict;
    private Sunny.UI.UITextBox txtZoneDistrict;
    private Sunny.UI.UILabel lblZoneFee;
    private Sunny.UI.UITextBox txtZoneFee;
    private Sunny.UI.UILabel lblZoneSortOrder;
    private Sunny.UI.UITextBox txtZoneSortOrder;
    private Sunny.UI.UICheckBox chkZoneIsActive;
    private Sunny.UI.UIFlowLayoutPanel panelDeliveryZoneActions;
    private Sunny.UI.UIButton btnAddDeliveryZone;
    private Sunny.UI.UIButton btnUpdateDeliveryZone;
    private Sunny.UI.UIButton btnDeleteDeliveryZone;
    private Sunny.UI.UIDataGridView dgvDeliveryZones;

    // 餐桌管理页控件
    private TabPage tabDiningTables;
    private Sunny.UI.UITableLayoutPanel layoutDiningTablesPage;
    private Sunny.UI.UIFlowLayoutPanel panelDiningTableTop;
    private Sunny.UI.UIButton btnLoadDiningTables;
    private Sunny.UI.UIGroupBox grpDiningTableEditor;
    private Sunny.UI.UITableLayoutPanel layoutDiningTableEditor;
    private Sunny.UI.UILabel lblDiningTableNumber;
    private Sunny.UI.UITextBox txtDiningTableNumber;
    private Sunny.UI.UILabel lblDiningTableSeats;
    private Sunny.UI.UITextBox txtDiningTableSeats;
    private Sunny.UI.UICheckBox chkDiningTableOccupied;
    private Sunny.UI.UICheckBox chkDiningTableEnabled;
    private Sunny.UI.UIFlowLayoutPanel panelDiningTableActions;
    private Sunny.UI.UIButton btnAddDiningTable;
    private Sunny.UI.UIButton btnUpdateDiningTable;
    private Sunny.UI.UIButton btnDeleteDiningTable;
    private Sunny.UI.UIDataGridView dgvDiningTables;

    // 菜品分类下拉框
    private Sunny.UI.UIComboBox cmbDishCategory;

    // 用户管理页控件
    private TabPage tabUsers;
    private Sunny.UI.UITableLayoutPanel layoutUsersPage;
    private Sunny.UI.UIFlowLayoutPanel panelUsersTop;
    private Sunny.UI.UIButton btnLoadUsers;
    private Sunny.UI.UIDataGridView dgvUsers;
    private Sunny.UI.UIGroupBox grpUserEditor;
    private Sunny.UI.UITableLayoutPanel layoutUserEditor;
    private Sunny.UI.UILabel lblUsername;
    private Sunny.UI.UITextBox txtUsername;
    private Sunny.UI.UILabel lblRealName;
    private Sunny.UI.UITextBox txtRealName;
    private Sunny.UI.UILabel lblUserPhone;
    private Sunny.UI.UITextBox txtUserPhone;
    private Sunny.UI.UILabel lblUserAddress;
    private Sunny.UI.UITextBox txtUserAddress;
    private Sunny.UI.UICheckBox chkIsActive;
    private Sunny.UI.UIFlowLayoutPanel panelUserActions;
    private Sunny.UI.UIButton btnAddUser;
    private Sunny.UI.UIButton btnUpdateUser;
    private Sunny.UI.UIButton btnDeleteUser;
    private Sunny.UI.UIButton btnResetPassword;
}
