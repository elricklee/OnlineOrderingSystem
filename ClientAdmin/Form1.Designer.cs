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
        layoutDishEdit.Dock = DockStyle.Fill;
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
        layoutDishEdit.Location = new Point(0, 0);
        layoutDishEdit.Name = "layoutDishEdit";
        layoutDishEdit.RowCount = 5;
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 61F));
        layoutDishEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        layoutDishEdit.Size = new Size(1105, 299);
        layoutDishEdit.TabIndex = 0;
        layoutDishEdit.TagString = null;
        // 
        // uiLabel3
        // 
        uiLabel3.Anchor = AnchorStyles.None;
        uiLabel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
        uiLabel3.Location = new Point(747, 9);
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
        txtCategory.Location = new Point(523, 5);
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
        txtPrice.Location = new Point(925, 5);
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
        // lblImagePath
        // 
        lblImagePath.Anchor = AnchorStyles.None;
        lblImagePath.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblImagePath.ForeColor = Color.FromArgb(48, 48, 48);
        lblImagePath.Location = new Point(6, 80);
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
        txtImagePath.Location = new Point(167, 75);
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
        btnChooseImage.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnChooseImage.Location = new Point(714, 71);
        btnChooseImage.MinimumSize = new Size(1, 1);
        btnChooseImage.Name = "btnChooseImage";
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
        chkIsAvailable.Location = new Point(897, 75);
        chkIsAvailable.MinimumSize = new Size(1, 1);
        chkIsAvailable.Name = "chkIsAvailable";
        chkIsAvailable.Size = new Size(205, 44);
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
        btnAddDish.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnAddDish.Location = new Point(6, 248);
        btnAddDish.MinimumSize = new Size(1, 1);
        btnAddDish.Name = "btnAddDish";
        btnAddDish.Radius = 2;
        btnAddDish.Size = new Size(150, 48);
        btnAddDish.TabIndex = 1;
        btnAddDish.Text = "添加按钮";
        btnAddDish.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnAddDish.Click += btnAddDish_Click;
        // 
        // btnUpdateDish
        // 
        btnUpdateDish.Anchor = AnchorStyles.None;
        btnUpdateDish.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnUpdateDish.Location = new Point(177, 248);
        btnUpdateDish.MinimumSize = new Size(1, 1);
        btnUpdateDish.Name = "btnUpdateDish";
        btnUpdateDish.Radius = 2;
        btnUpdateDish.Size = new Size(150, 48);
        btnUpdateDish.TabIndex = 2;
        btnUpdateDish.Text = "修改按钮";
        btnUpdateDish.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnUpdateDish.Click += btnUpdateDish_Click;
        // 
        // btnDeleteDish
        // 
        btnDeleteDish.Anchor = AnchorStyles.None;
        btnDeleteDish.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnDeleteDish.Location = new Point(351, 248);
        btnDeleteDish.MinimumSize = new Size(1, 1);
        btnDeleteDish.Name = "btnDeleteDish";
        btnDeleteDish.Radius = 2;
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
        lblSpicyCondition.Location = new Point(15, 146);
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
        cmbSpicyLevel.Location = new Point(167, 148);
        cmbSpicyLevel.Margin = new Padding(4, 5, 4, 5);
        cmbSpicyLevel.MinimumSize = new Size(63, 0);
        cmbSpicyLevel.Name = "cmbSpicyLevel";
        cmbSpicyLevel.Padding = new Padding(0, 0, 30, 2);
        cmbSpicyLevel.Size = new Size(171, 31);
        cmbSpicyLevel.SymbolSize = 24;
        cmbSpicyLevel.TabIndex = 15;
        cmbSpicyLevel.Text = "空";
        cmbSpicyLevel.TextAlignment = ContentAlignment.MiddleLeft;
        cmbSpicyLevel.Watermark = "";
        // 
        // btnLoadDishes
        // 
        btnLoadDishes.Anchor = AnchorStyles.None;
        btnLoadDishes.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnLoadDishes.Location = new Point(557, 12);
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
        tabOrders.Size = new Size(200, 60);
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
        layoutOrderPage.Size = new Size(200, 60);
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
        panelOrderTop.Size = new Size(192, 60);
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
        layoutOrderMain.Size = new Size(194, 1);
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
        dgvOrders.Size = new Size(116, 1);
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
        grpOrderDetail.Location = new Point(126, 5);
        grpOrderDetail.Margin = new Padding(4, 5, 4, 5);
        grpOrderDetail.MinimumSize = new Size(1, 1);
        grpOrderDetail.Name = "grpOrderDetail";
        grpOrderDetail.Padding = new Padding(0, 32, 0, 0);
        grpOrderDetail.Size = new Size(64, 1);
        grpOrderDetail.TabIndex = 1;
        grpOrderDetail.Text = "订单详情";
        grpOrderDetail.TextAlignment = ContentAlignment.MiddleLeft;
        // 
        // lblCreatedAt
        // 
        lblCreatedAt.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblCreatedAt.ForeColor = Color.FromArgb(48, 48, 48);
        lblCreatedAt.Location = new Point(242, 108);
        lblCreatedAt.Name = "lblCreatedAt";
        lblCreatedAt.Size = new Size(189, 106);
        lblCreatedAt.TabIndex = 10;
        lblCreatedAt.Text = "创建时间：";
        // 
        // lblStatus
        // 
        lblStatus.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblStatus.ForeColor = Color.FromArgb(48, 48, 48);
        lblStatus.Location = new Point(242, 72);
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
        lblDeliveryFee.Location = new Point(3, 324);
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
        lblNote.Size = new Size(403, 80);
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
        grpOrderItems.Location = new Point(4, 69);
        grpOrderItems.Margin = new Padding(4, 5, 4, 5);
        grpOrderItems.MinimumSize = new Size(1, 1);
        grpOrderItems.Name = "grpOrderItems";
        grpOrderItems.Padding = new Padding(0, 32, 0, 0);
        grpOrderItems.Size = new Size(192, 1);
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
        dgvOrderItems.Size = new Size(192, 0);
        dgvOrderItems.StripeOddColor = Color.FromArgb(235, 243, 255);
        dgvOrderItems.TabIndex = 0;
        // 
        // tabStatistics
        // 
        tabStatistics.Controls.Add(layoutStatisticsPage);
        tabStatistics.Location = new Point(0, 40);
        tabStatistics.Name = "tabStatistics";
        tabStatistics.Size = new Size(200, 60);
        tabStatistics.TabIndex = 2;
        tabStatistics.Text = "统计分析";
        tabStatistics.UseVisualStyleBackColor = true;
        // 
        // layoutStatisticsPage
        // 
        layoutStatisticsPage.Dock = DockStyle.Fill;
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
        btnResetStatistics.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnResetStatistics.Location = new Point(957, 6);
        btnResetStatistics.MinimumSize = new Size(1, 1);
        btnResetStatistics.Name = "btnResetStatistics";
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
        btnLoadStatistics.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnLoadStatistics.Location = new Point(795, 6);
        btnLoadStatistics.MinimumSize = new Size(1, 1);
        btnLoadStatistics.Name = "btnLoadStatistics";
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
        btnLoadAiSuggestion.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnLoadAiSuggestion.Location = new Point(10, 6);
        btnLoadAiSuggestion.MinimumSize = new Size(1, 1);
        btnLoadAiSuggestion.Name = "btnLoadAiSuggestion";
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
}
