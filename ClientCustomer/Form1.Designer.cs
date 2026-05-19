namespace ClientCustomer;

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
        mainLayout = new Sunny.UI.UITableLayoutPanel();
        headerPanel = new Sunny.UI.UIPanel();
        lblTitle = new Sunny.UI.UILabel();
        lblOrderInfo = new Sunny.UI.UILabel();
        txtSearch = new Sunny.UI.UITextBox();
        btnSearch = new Sunny.UI.UIButton();
        btnRefresh = new Sunny.UI.UIButton();
        btnBack = new Sunny.UI.UIButton();
        btnCheckOrder = new Sunny.UI.UIButton();
        btnLogout = new Sunny.UI.UIButton();
        dishAreaPanel = new Panel();
        dishFlowPanel = new FlowLayoutPanel();
        categoryPanel = new Sunny.UI.UIPanel();
        lblCategoryTitle = new Sunny.UI.UILabel();
        categoryFlow = new FlowLayoutPanel();
        btnCategoryAll = new Sunny.UI.UIButton();
        btnCategoryHot = new Sunny.UI.UIButton();
        btnCategoryCold = new Sunny.UI.UIButton();
        btnCategoryStaple = new Sunny.UI.UIButton();
        btnCategoryDrink = new Sunny.UI.UIButton();
        btnCategorySoup = new Sunny.UI.UIButton();
        lblNoDish = new Sunny.UI.UILabel();
        cartBarPanel = new Sunny.UI.UIPanel();
        lblCartSummary = new Sunny.UI.UILabel();
        btnViewCart = new Sunny.UI.UIButton();
        btnCheckout = new Sunny.UI.UIButton();
        aiPanel = new Sunny.UI.UIPanel();
        lblAITitle = new Sunny.UI.UILabel();
        lblAIText = new Sunny.UI.UILabel();
        btnGetRecommend = new Sunny.UI.UIButton();
        mainLayout.SuspendLayout();
        headerPanel.SuspendLayout();
        dishAreaPanel.SuspendLayout();
        categoryPanel.SuspendLayout();
        categoryFlow.SuspendLayout();
        cartBarPanel.SuspendLayout();
        aiPanel.SuspendLayout();
        SuspendLayout();
        // 
        // mainLayout
        // 
        mainLayout.BackColor = Color.FromArgb(250, 250, 250);
        mainLayout.ColumnCount = 1;
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainLayout.Controls.Add(headerPanel, 0, 0);
        mainLayout.Controls.Add(dishAreaPanel, 0, 1);
        mainLayout.Controls.Add(cartBarPanel, 0, 2);
        mainLayout.Controls.Add(aiPanel, 0, 3);
        mainLayout.Dock = DockStyle.Fill;
        mainLayout.Location = new Point(0, 36);
        mainLayout.Name = "mainLayout";
        mainLayout.RowCount = 4;
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 86F));
        mainLayout.Size = new Size(1378, 827);
        mainLayout.TabIndex = 0;
        mainLayout.TagString = null;
        // 
        // headerPanel
        // 
        headerPanel.Controls.Add(lblTitle);
        headerPanel.Controls.Add(lblOrderInfo);
        headerPanel.Controls.Add(txtSearch);
        headerPanel.Controls.Add(btnSearch);
        headerPanel.Controls.Add(btnRefresh);
        headerPanel.Controls.Add(btnBack);
        headerPanel.Controls.Add(btnCheckOrder);
        headerPanel.Controls.Add(btnLogout);
        headerPanel.Dock = DockStyle.Fill;
        headerPanel.FillColor = Color.FromArgb(255, 109, 0);
        headerPanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        headerPanel.Location = new Point(0, 0);
        headerPanel.Margin = new Padding(0);
        headerPanel.MinimumSize = new Size(1, 1);
        headerPanel.Name = "headerPanel";
        headerPanel.Size = new Size(1378, 60);
        headerPanel.TabIndex = 0;
        headerPanel.Text = null;
        headerPanel.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.FromArgb(255, 109, 0);
        lblTitle.Font = new Font("微软雅黑", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.Black;
        lblTitle.Location = new Point(20, 8);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(276, 40);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "珞珈线上点餐系统";
        // 
        // lblOrderInfo
        // 
        lblOrderInfo.BackColor = Color.FromArgb(255, 109, 0);
        lblOrderInfo.Font = new Font("微软雅黑", 11F);
        lblOrderInfo.ForeColor = Color.White;
        lblOrderInfo.Location = new Point(318, 18);
        lblOrderInfo.Name = "lblOrderInfo";
        lblOrderInfo.Size = new Size(262, 30);
        lblOrderInfo.TabIndex = 1;
        lblOrderInfo.Text = "指尖点好菜，珞珈好味来";
        lblOrderInfo.Click += lblOrderInfo_Click;
        // 
        // txtSearch
        // 
        txtSearch.Font = new Font("微软雅黑", 10F);
        txtSearch.Location = new Point(640, 12);
        txtSearch.Margin = new Padding(4, 5, 4, 5);
        txtSearch.MinimumSize = new Size(1, 16);
        txtSearch.Name = "txtSearch";
        txtSearch.Padding = new Padding(5);
        txtSearch.ShowText = false;
        txtSearch.Size = new Size(230, 36);
        txtSearch.TabIndex = 2;
        txtSearch.TextAlignment = ContentAlignment.MiddleLeft;
        txtSearch.Watermark = "搜索菜品...";
        // 
        // btnSearch
        // 
        btnSearch.Cursor = Cursors.Hand;
        btnSearch.FillColor = Color.White;
        btnSearch.Font = new Font("微软雅黑", 10F);
        btnSearch.ForeColor = Color.FromArgb(255, 109, 0);
        btnSearch.Location = new Point(877, 12);
        btnSearch.MinimumSize = new Size(1, 1);
        btnSearch.Name = "btnSearch";
        btnSearch.Radius = 6;
        btnSearch.RectColor = Color.White;
        btnSearch.Size = new Size(80, 36);
        btnSearch.TabIndex = 3;
        btnSearch.Text = "搜索";
        btnSearch.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnSearch.Click += BtnSearch_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.Cursor = Cursors.Hand;
        btnRefresh.FillColor = Color.White;
        btnRefresh.Font = new Font("微软雅黑", 10F);
        btnRefresh.ForeColor = Color.FromArgb(255, 109, 0);
        btnRefresh.Location = new Point(974, 12);
        btnRefresh.MinimumSize = new Size(1, 1);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Radius = 6;
        btnRefresh.RectColor = Color.White;
        btnRefresh.Size = new Size(80, 36);
        btnRefresh.TabIndex = 5;
        btnRefresh.Text = "刷新";
        btnRefresh.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnRefresh.Click += BtnRefresh_Click;
        // 
        // btnBack
        // 
        btnBack.Cursor = Cursors.Hand;
        btnBack.FillColor = Color.White;
        btnBack.Font = new Font("微软雅黑", 10F);
        btnBack.ForeColor = Color.FromArgb(255, 109, 0);
        btnBack.Location = new Point(1073, 12);
        btnBack.MinimumSize = new Size(1, 1);
        btnBack.Name = "btnBack";
        btnBack.Radius = 6;
        btnBack.RectColor = Color.White;
        btnBack.Size = new Size(80, 36);
        btnBack.TabIndex = 6;
        btnBack.Text = "返回";
        btnBack.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnBack.Click += BtnBack_Click;
        // 
        // btnCheckOrder
        // 
        btnCheckOrder.Cursor = Cursors.Hand;
        btnCheckOrder.FillColor = Color.FromArgb(255, 255, 255);
        btnCheckOrder.Font = new Font("微软雅黑", 10F);
        btnCheckOrder.ForeColor = Color.FromArgb(255, 109, 0);
        btnCheckOrder.Location = new Point(1160, 12);
        btnCheckOrder.MinimumSize = new Size(1, 1);
        btnCheckOrder.Name = "btnCheckOrder";
        btnCheckOrder.Radius = 6;
        btnCheckOrder.RectColor = Color.White;
        btnCheckOrder.Size = new Size(90, 36);
        btnCheckOrder.TabIndex = 4;
        btnCheckOrder.Text = "我的订单";
        btnCheckOrder.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnCheckOrder.Click += BtnCheckOrder_Click;
        // 
        // btnLogout
        //
        btnLogout.Cursor = Cursors.Hand;
        btnLogout.FillColor = Color.White;
        btnLogout.Font = new Font("微软雅黑", 10F);
        btnLogout.ForeColor = Color.FromArgb(255, 109, 0);
        btnLogout.Location = new Point(1268, 12);
        btnLogout.MinimumSize = new Size(1, 1);
        btnLogout.Name = "btnLogout";
        btnLogout.Radius = 6;
        btnLogout.RectColor = Color.White;
        btnLogout.Size = new Size(90, 36);
        btnLogout.TabIndex = 7;
        btnLogout.Text = "退出登录";
        btnLogout.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnLogout.Click += BtnLogout_Click;
        // 
        // dishAreaPanel
        // 
        dishAreaPanel.BackColor = Color.FromArgb(250, 250, 250);
        dishAreaPanel.Controls.Add(dishFlowPanel);
        dishAreaPanel.Controls.Add(categoryPanel);
        dishAreaPanel.Controls.Add(lblNoDish);
        dishAreaPanel.Dock = DockStyle.Fill;
        dishAreaPanel.Location = new Point(3, 63);
        dishAreaPanel.Name = "dishAreaPanel";
        dishAreaPanel.Size = new Size(1372, 610);
        dishAreaPanel.TabIndex = 1;
        // 
        // dishFlowPanel
        // 
        dishFlowPanel.AutoScroll = true;
        dishFlowPanel.BackColor = Color.FromArgb(250, 250, 250);
        dishFlowPanel.Dock = DockStyle.Fill;
        dishFlowPanel.Location = new Point(185, 0);
        dishFlowPanel.Name = "dishFlowPanel";
        dishFlowPanel.Padding = new Padding(15, 10, 10, 10);
        dishFlowPanel.Size = new Size(1187, 610);
        dishFlowPanel.TabIndex = 2;
        dishFlowPanel.Paint += dishFlowPanel_Paint;
        // 
        // categoryPanel
        // 
        categoryPanel.Controls.Add(lblCategoryTitle);
        categoryPanel.Controls.Add(categoryFlow);
        categoryPanel.Dock = DockStyle.Left;
        categoryPanel.FillColor = Color.White;
        categoryPanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        categoryPanel.Location = new Point(0, 0);
        categoryPanel.Margin = new Padding(0);
        categoryPanel.MaximumSize = new Size(220, 2000);
        categoryPanel.MinimumSize = new Size(160, 200);
        categoryPanel.Name = "categoryPanel";
        categoryPanel.Size = new Size(185, 610);
        categoryPanel.TabIndex = 0;
        categoryPanel.Text = null;
        categoryPanel.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // lblCategoryTitle
        // 
        lblCategoryTitle.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
        lblCategoryTitle.ForeColor = Color.FromArgb(51, 51, 51);
        lblCategoryTitle.Location = new Point(15, 12);
        lblCategoryTitle.Name = "lblCategoryTitle";
        lblCategoryTitle.Size = new Size(150, 35);
        lblCategoryTitle.TabIndex = 0;
        lblCategoryTitle.Text = "菜品分类";
        // 
        // categoryFlow
        // 
        categoryFlow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        categoryFlow.AutoScroll = true;
        categoryFlow.BackColor = Color.White;
        categoryFlow.Controls.Add(btnCategoryAll);
        categoryFlow.Controls.Add(btnCategoryHot);
        categoryFlow.Controls.Add(btnCategoryCold);
        categoryFlow.Controls.Add(btnCategoryStaple);
        categoryFlow.Controls.Add(btnCategoryDrink);
        categoryFlow.Controls.Add(btnCategorySoup);
        categoryFlow.FlowDirection = FlowDirection.TopDown;
        categoryFlow.Location = new Point(0, 55);
        categoryFlow.Name = "categoryFlow";
        categoryFlow.Padding = new Padding(5);
        categoryFlow.Size = new Size(185, 555);
        categoryFlow.TabIndex = 1;
        categoryFlow.WrapContents = false;
        // 
        // btnCategoryAll
        // 
        btnCategoryAll.Cursor = Cursors.Hand;
        btnCategoryAll.FillColor = Color.FromArgb(255, 109, 0);
        btnCategoryAll.Font = new Font("微软雅黑", 11F);
        btnCategoryAll.Location = new Point(7, 8);
        btnCategoryAll.Margin = new Padding(2, 3, 2, 3);
        btnCategoryAll.MinimumSize = new Size(1, 1);
        btnCategoryAll.Name = "btnCategoryAll";
        btnCategoryAll.Radius = 6;
        btnCategoryAll.RectColor = Color.FromArgb(255, 109, 0);
        btnCategoryAll.Size = new Size(155, 40);
        btnCategoryAll.TabIndex = 2;
        btnCategoryAll.Text = "菜品总览";
        btnCategoryAll.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnCategoryAll.Click += CategoryButton_Click;
        // 
        // btnCategoryHot
        // 
        btnCategoryHot.Cursor = Cursors.Hand;
        btnCategoryHot.FillColor = Color.White;
        btnCategoryHot.Font = new Font("微软雅黑", 11F);
        btnCategoryHot.ForeColor = Color.FromArgb(51, 51, 51);
        btnCategoryHot.Location = new Point(7, 54);
        btnCategoryHot.Margin = new Padding(2, 3, 2, 3);
        btnCategoryHot.MinimumSize = new Size(1, 1);
        btnCategoryHot.Name = "btnCategoryHot";
        btnCategoryHot.Radius = 6;
        btnCategoryHot.RectColor = Color.FromArgb(255, 109, 0);
        btnCategoryHot.Size = new Size(155, 40);
        btnCategoryHot.TabIndex = 3;
        btnCategoryHot.Text = "热菜";
        btnCategoryHot.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnCategoryHot.Click += CategoryButton_Click;
        // 
        // btnCategoryCold
        // 
        btnCategoryCold.Cursor = Cursors.Hand;
        btnCategoryCold.FillColor = Color.White;
        btnCategoryCold.Font = new Font("微软雅黑", 11F);
        btnCategoryCold.ForeColor = Color.FromArgb(51, 51, 51);
        btnCategoryCold.Location = new Point(7, 100);
        btnCategoryCold.Margin = new Padding(2, 3, 2, 3);
        btnCategoryCold.MinimumSize = new Size(1, 1);
        btnCategoryCold.Name = "btnCategoryCold";
        btnCategoryCold.Radius = 6;
        btnCategoryCold.RectColor = Color.FromArgb(255, 109, 0);
        btnCategoryCold.Size = new Size(155, 40);
        btnCategoryCold.TabIndex = 4;
        btnCategoryCold.Text = "凉菜";
        btnCategoryCold.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnCategoryCold.Click += CategoryButton_Click;
        // 
        // btnCategoryStaple
        // 
        btnCategoryStaple.Cursor = Cursors.Hand;
        btnCategoryStaple.FillColor = Color.White;
        btnCategoryStaple.Font = new Font("微软雅黑", 11F);
        btnCategoryStaple.ForeColor = Color.FromArgb(51, 51, 51);
        btnCategoryStaple.Location = new Point(7, 146);
        btnCategoryStaple.Margin = new Padding(2, 3, 2, 3);
        btnCategoryStaple.MinimumSize = new Size(1, 1);
        btnCategoryStaple.Name = "btnCategoryStaple";
        btnCategoryStaple.Radius = 6;
        btnCategoryStaple.RectColor = Color.FromArgb(255, 109, 0);
        btnCategoryStaple.Size = new Size(155, 40);
        btnCategoryStaple.TabIndex = 5;
        btnCategoryStaple.Text = "主食";
        btnCategoryStaple.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnCategoryStaple.Click += CategoryButton_Click;
        // 
        // btnCategoryDrink
        // 
        btnCategoryDrink.Cursor = Cursors.Hand;
        btnCategoryDrink.FillColor = Color.White;
        btnCategoryDrink.Font = new Font("微软雅黑", 11F);
        btnCategoryDrink.ForeColor = Color.FromArgb(51, 51, 51);
        btnCategoryDrink.Location = new Point(7, 192);
        btnCategoryDrink.Margin = new Padding(2, 3, 2, 3);
        btnCategoryDrink.MinimumSize = new Size(1, 1);
        btnCategoryDrink.Name = "btnCategoryDrink";
        btnCategoryDrink.Radius = 6;
        btnCategoryDrink.RectColor = Color.FromArgb(255, 109, 0);
        btnCategoryDrink.Size = new Size(155, 40);
        btnCategoryDrink.TabIndex = 6;
        btnCategoryDrink.Text = "饮品";
        btnCategoryDrink.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnCategoryDrink.Click += CategoryButton_Click;
        // 
        // btnCategorySoup
        // 
        btnCategorySoup.Cursor = Cursors.Hand;
        btnCategorySoup.FillColor = Color.White;
        btnCategorySoup.Font = new Font("微软雅黑", 11F);
        btnCategorySoup.ForeColor = Color.FromArgb(51, 51, 51);
        btnCategorySoup.Location = new Point(7, 238);
        btnCategorySoup.Margin = new Padding(2, 3, 2, 3);
        btnCategorySoup.MinimumSize = new Size(1, 1);
        btnCategorySoup.Name = "btnCategorySoup";
        btnCategorySoup.Radius = 6;
        btnCategorySoup.RectColor = Color.FromArgb(255, 109, 0);
        btnCategorySoup.Size = new Size(155, 40);
        btnCategorySoup.TabIndex = 7;
        btnCategorySoup.Text = "汤类";
        btnCategorySoup.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnCategorySoup.Click += CategoryButton_Click;
        // 
        // lblNoDish
        // 
        lblNoDish.Font = new Font("微软雅黑", 14F);
        lblNoDish.ForeColor = Color.FromArgb(117, 117, 117);
        lblNoDish.Location = new Point(300, 200);
        lblNoDish.Name = "lblNoDish";
        lblNoDish.Size = new Size(400, 40);
        lblNoDish.TabIndex = 2;
        lblNoDish.Text = "暂无菜品数据，请稍后刷新...";
        lblNoDish.Visible = false;
        // 
        // cartBarPanel
        // 
        cartBarPanel.Controls.Add(lblCartSummary);
        cartBarPanel.Controls.Add(btnViewCart);
        cartBarPanel.Controls.Add(btnCheckout);
        cartBarPanel.Dock = DockStyle.Fill;
        cartBarPanel.FillColor = Color.FromArgb(255, 243, 224);
        cartBarPanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        cartBarPanel.Location = new Point(0, 676);
        cartBarPanel.Margin = new Padding(0);
        cartBarPanel.MinimumSize = new Size(1, 1);
        cartBarPanel.Name = "cartBarPanel";
        cartBarPanel.Size = new Size(1378, 65);
        cartBarPanel.TabIndex = 2;
        cartBarPanel.Text = null;
        cartBarPanel.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // lblCartSummary
        // 
        lblCartSummary.Font = new Font("微软雅黑", 11F);
        lblCartSummary.ForeColor = Color.FromArgb(51, 51, 51);
        lblCartSummary.Location = new Point(20, 18);
        lblCartSummary.Name = "lblCartSummary";
        lblCartSummary.Size = new Size(700, 30);
        lblCartSummary.TabIndex = 0;
        lblCartSummary.Text = "购物车：空";
        // 
        // btnViewCart
        // 
        btnViewCart.Cursor = Cursors.Hand;
        btnViewCart.FillColor = Color.White;
        btnViewCart.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnViewCart.ForeColor = Color.FromArgb(255, 109, 0);
        btnViewCart.Location = new Point(850, 12);
        btnViewCart.MinimumSize = new Size(1, 1);
        btnViewCart.Name = "btnViewCart";
        btnViewCart.Radius = 6;
        btnViewCart.RectColor = Color.FromArgb(255, 109, 0);
        btnViewCart.Size = new Size(130, 40);
        btnViewCart.TabIndex = 1;
        btnViewCart.Text = "查看购物车";
        btnViewCart.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnViewCart.Click += BtnViewCart_Click;
        // 
        // btnCheckout
        // 
        btnCheckout.Cursor = Cursors.Hand;
        btnCheckout.FillColor = Color.FromArgb(255, 109, 0);
        btnCheckout.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        btnCheckout.Location = new Point(1000, 12);
        btnCheckout.MinimumSize = new Size(1, 1);
        btnCheckout.Name = "btnCheckout";
        btnCheckout.Radius = 6;
        btnCheckout.RectColor = Color.FromArgb(255, 109, 0);
        btnCheckout.Size = new Size(130, 40);
        btnCheckout.TabIndex = 2;
        btnCheckout.Text = "去结算";
        btnCheckout.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnCheckout.Click += BtnCheckout_Click;
        // 
        // aiPanel
        // 
        aiPanel.Controls.Add(lblAITitle);
        aiPanel.Controls.Add(lblAIText);
        aiPanel.Controls.Add(btnGetRecommend);
        aiPanel.Dock = DockStyle.Fill;
        aiPanel.FillColor = Color.FromArgb(232, 245, 233);
        aiPanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        aiPanel.Location = new Point(0, 741);
        aiPanel.Margin = new Padding(0);
        aiPanel.MinimumSize = new Size(1, 120);
        aiPanel.Name = "aiPanel";
        aiPanel.Size = new Size(1378, 120);
        aiPanel.TabIndex = 3;
        aiPanel.Text = null;
        aiPanel.TextAlignment = ContentAlignment.MiddleCenter;
        aiPanel.Click += aiPanel_Click;
        // 
        // lblAITitle
        // 
        lblAITitle.FlatStyle = FlatStyle.System;
        lblAITitle.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        lblAITitle.ForeColor = Color.FromArgb(76, 175, 80);
        lblAITitle.Location = new Point(18, 14);
        lblAITitle.Name = "lblAITitle";
        lblAITitle.Size = new Size(90, 28);
        lblAITitle.TabIndex = 0;
        lblAITitle.Text = "AI推荐：";
        // 
        // lblAIText
        // 
        lblAIText.Font = new Font("微软雅黑", 10F);
        lblAIText.ForeColor = Color.FromArgb(117, 117, 117);
        lblAIText.Location = new Point(126, 0);
        lblAIText.Name = "lblAIText";
        lblAIText.Size = new Size(1094, 61);
        lblAIText.TabIndex = 1;
        lblAIText.Text = "选择菜品后，点击获取AI推荐";
        // 
        // btnGetRecommend
        // 
        btnGetRecommend.Cursor = Cursors.Hand;
        btnGetRecommend.FillColor = Color.FromArgb(76, 175, 80);
        btnGetRecommend.Font = new Font("微软雅黑", 10F);
        btnGetRecommend.Location = new Point(1250, 24);
        btnGetRecommend.MinimumSize = new Size(1, 1);
        btnGetRecommend.Name = "btnGetRecommend";
        btnGetRecommend.Radius = 6;
        btnGetRecommend.RectColor = Color.FromArgb(76, 175, 80);
        btnGetRecommend.Size = new Size(110, 36);
        btnGetRecommend.TabIndex = 2;
        btnGetRecommend.Text = "获取推荐";
        btnGetRecommend.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnGetRecommend.Click += BtnGetRecommend_Click;
        // 
        // Form1
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(250, 250, 250);
        ClientSize = new Size(1378, 863);
        Controls.Add(mainLayout);
        Font = new Font("Microsoft YaHei UI", 10F);
        MinimumSize = new Size(1089, 724);
        Name = "Form1";
        Padding = new Padding(0, 36, 0, 0);
        Text = "珞珈线上点餐系统-顾客端";
        ZoomScaleRect = new Rectangle(22, 22, 1378, 863);
        mainLayout.ResumeLayout(false);
        headerPanel.ResumeLayout(false);
        dishAreaPanel.ResumeLayout(false);
        categoryPanel.ResumeLayout(false);
        categoryFlow.ResumeLayout(false);
        cartBarPanel.ResumeLayout(false);
        aiPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Sunny.UI.UITableLayoutPanel mainLayout;
    private Sunny.UI.UIPanel headerPanel;
    private Sunny.UI.UILabel lblTitle;
    private Sunny.UI.UILabel lblOrderInfo;
    private Sunny.UI.UITextBox txtSearch;
    private Sunny.UI.UIButton btnSearch;
    private Sunny.UI.UIButton btnRefresh;
    private Sunny.UI.UIButton btnBack;
    private Sunny.UI.UIButton btnCheckOrder;
    private Sunny.UI.UIButton btnLogout;
    private Sunny.UI.UIPanel categoryPanel;
    private Sunny.UI.UILabel lblCategoryTitle;
    private FlowLayoutPanel categoryFlow;
    private System.Windows.Forms.Panel dishAreaPanel;
    private FlowLayoutPanel dishFlowPanel;
    private Sunny.UI.UILabel lblNoDish;
    private Sunny.UI.UIPanel cartBarPanel;
    private Sunny.UI.UILabel lblCartSummary;
    private Sunny.UI.UIButton btnViewCart;
    private Sunny.UI.UIButton btnCheckout;
    private Sunny.UI.UIPanel aiPanel;
    private Sunny.UI.UILabel lblAITitle;
    private Sunny.UI.UILabel lblAIText;
    private Sunny.UI.UIButton btnGetRecommend;
    private Sunny.UI.UIButton btnCategoryAll;
    private Sunny.UI.UIButton btnCategoryHot;
    private Sunny.UI.UIButton btnCategoryCold;
    private Sunny.UI.UIButton btnCategoryStaple;
    private Sunny.UI.UIButton btnCategoryDrink;
    private Sunny.UI.UIButton btnCategorySoup;
}
