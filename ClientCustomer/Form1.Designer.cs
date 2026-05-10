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
        panelHeader = new ReaLTaiizor.Controls.MetroPanel();
        lblOrderType = new Label();
        panelCategory = new ReaLTaiizor.Controls.ExtendedPanel();
        rbSoup = new ReaLTaiizor.Controls.AirRadioButton();
        rbDrink = new ReaLTaiizor.Controls.AirRadioButton();
        rbStaple = new ReaLTaiizor.Controls.AirRadioButton();
        rbColdDish = new ReaLTaiizor.Controls.AirRadioButton();
        rbHotDish = new ReaLTaiizor.Controls.AirRadioButton();
        rbAll = new ReaLTaiizor.Controls.AirRadioButton();
        lblCategoryTitle = new Label();
        lblHeaderTitle = new Label();
        panelHeader.SuspendLayout();
        panelCategory.SuspendLayout();
        SuspendLayout();
        // 
        // panelHeader
        // 
        panelHeader.BackgroundColor = Color.FromArgb(255, 87, 34);
        panelHeader.BorderColor = Color.FromArgb(150, 150, 150);
        panelHeader.BorderThickness = 1;
        panelHeader.Controls.Add(lblHeaderTitle);
        panelHeader.Controls.Add(lblOrderType);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.IsDerivedStyle = true;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(1378, 60);
        panelHeader.Style = ReaLTaiizor.Enum.Metro.Style.Light;
        panelHeader.StyleManager = null;
        panelHeader.TabIndex = 0;
        panelHeader.ThemeAuthor = "Taiizor";
        panelHeader.ThemeName = "MetroLight";
        // 
        // lblOrderType
        // 
        lblOrderType.AutoSize = true;
        lblOrderType.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblOrderType.ForeColor = Color.White;
        lblOrderType.Location = new Point(1100, 18);
        lblOrderType.Name = "lblOrderType";
        lblOrderType.Size = new Size(183, 30);
        lblOrderType.TabIndex = 0;
        lblOrderType.Text = "[堂食·桌号：A01]";
        lblOrderType.TextAlign = ContentAlignment.MiddleRight;
        // 
        // panelCategory
        // 
        panelCategory.BackColor = Color.White;
        panelCategory.BorderStyle = BorderStyle.FixedSingle;
        panelCategory.Controls.Add(rbSoup);
        panelCategory.Controls.Add(rbDrink);
        panelCategory.Controls.Add(rbStaple);
        panelCategory.Controls.Add(rbColdDish);
        panelCategory.Controls.Add(rbHotDish);
        panelCategory.Controls.Add(rbAll);
        panelCategory.Controls.Add(lblCategoryTitle);
        panelCategory.Dock = DockStyle.Left;
        panelCategory.DrawMode = ReaLTaiizor.Controls.ExtendedPanel.Drawer.Default;
        panelCategory.Location = new Point(0, 60);
        panelCategory.MostInterval = 100;
        panelCategory.Name = "panelCategory";
        panelCategory.Opacity = 50;
        panelCategory.Size = new Size(200, 784);
        panelCategory.TabIndex = 1;
        panelCategory.TopMost = true;
        // 
        // rbSoup
        // 
        rbSoup.Checked = false;
        rbSoup.Customization = "PDw8/+3t7f/m5ub/p6en/2RkZP8=";
        rbSoup.Field = 16;
        rbSoup.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        rbSoup.Image = null;
        rbSoup.Location = new Point(20, 260);
        rbSoup.Name = "rbSoup";
        rbSoup.NoRounding = false;
        rbSoup.Size = new Size(160, 16);
        rbSoup.TabIndex = 6;
        rbSoup.Text = "汤类";
        rbSoup.Transparent = false;
        // 
        // rbDrink
        // 
        rbDrink.Checked = false;
        rbDrink.Customization = "PDw8/+3t7f/m5ub/p6en/2RkZP8=";
        rbDrink.Field = 16;
        rbDrink.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        rbDrink.Image = null;
        rbDrink.Location = new Point(20, 220);
        rbDrink.Name = "rbDrink";
        rbDrink.NoRounding = false;
        rbDrink.Size = new Size(160, 16);
        rbDrink.TabIndex = 5;
        rbDrink.Text = "饮品";
        rbDrink.Transparent = false;
        // 
        // rbStaple
        // 
        rbStaple.Checked = false;
        rbStaple.Customization = "PDw8/+3t7f/m5ub/p6en/2RkZP8=";
        rbStaple.Field = 16;
        rbStaple.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        rbStaple.Image = null;
        rbStaple.Location = new Point(20, 180);
        rbStaple.Name = "rbStaple";
        rbStaple.NoRounding = false;
        rbStaple.Size = new Size(160, 16);
        rbStaple.TabIndex = 4;
        rbStaple.Text = "主食";
        rbStaple.Transparent = false;
        // 
        // rbColdDish
        // 
        rbColdDish.Checked = false;
        rbColdDish.Customization = "PDw8/+3t7f/m5ub/p6en/2RkZP8=";
        rbColdDish.Field = 16;
        rbColdDish.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        rbColdDish.Image = null;
        rbColdDish.Location = new Point(20, 140);
        rbColdDish.Name = "rbColdDish";
        rbColdDish.NoRounding = false;
        rbColdDish.Size = new Size(160, 16);
        rbColdDish.TabIndex = 3;
        rbColdDish.Text = "凉菜";
        rbColdDish.Transparent = false;
        // 
        // rbHotDish
        // 
        rbHotDish.Checked = false;
        rbHotDish.Customization = "PDw8/+3t7f/m5ub/p6en/2RkZP8=";
        rbHotDish.Field = 16;
        rbHotDish.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        rbHotDish.Image = null;
        rbHotDish.Location = new Point(20, 100);
        rbHotDish.Name = "rbHotDish";
        rbHotDish.NoRounding = false;
        rbHotDish.Size = new Size(160, 16);
        rbHotDish.TabIndex = 2;
        rbHotDish.Text = "热菜";
        rbHotDish.Transparent = false;
        // 
        // rbAll
        // 
        rbAll.Checked = true;
        rbAll.Customization = "PDw8/+3t7f/m5ub/p6en/2RkZP8=";
        rbAll.Field = 16;
        rbAll.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        rbAll.Image = null;
        rbAll.Location = new Point(20, 60);
        rbAll.Name = "rbAll";
        rbAll.NoRounding = false;
        rbAll.Size = new Size(150, 16);
        rbAll.TabIndex = 1;
        rbAll.Text = "全部菜品";
        rbAll.Transparent = false;
        // 
        // lblCategoryTitle
        // 
        lblCategoryTitle.AutoSize = true;
        lblCategoryTitle.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
        lblCategoryTitle.ForeColor = Color.FromArgb(51, 51, 51);
        lblCategoryTitle.Location = new Point(10, 10);
        lblCategoryTitle.Name = "lblCategoryTitle";
        lblCategoryTitle.Size = new Size(110, 31);
        lblCategoryTitle.TabIndex = 0;
        lblCategoryTitle.Text = "菜品分类";
        // 
        // lblHeaderTitle
        // 
        lblHeaderTitle.AutoSize = true;
        lblHeaderTitle.Font = new Font("微软雅黑", 16F, FontStyle.Bold, GraphicsUnit.Point, 134);
        lblHeaderTitle.ForeColor = Color.White;
        lblHeaderTitle.Location = new Point(20, 12);
        lblHeaderTitle.Name = "lblHeaderTitle";
        lblHeaderTitle.Size = new Size(274, 42);
        lblHeaderTitle.TabIndex = 1;
        lblHeaderTitle.Text = "珞珈线上点餐系统";
        // 
        // Form1
        // 
        BackColor = Color.FromArgb(250, 250, 250);
        ClientSize = new Size(1378, 844);
        Controls.Add(panelCategory);
        Controls.Add(panelHeader);
        DoubleBuffered = true;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "线上点餐系统-顾客端";
        WindowState = FormWindowState.Maximized;
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        panelCategory.ResumeLayout(false);
        panelCategory.PerformLayout();
        ResumeLayout(false);

    }
    private ReaLTaiizor.Controls.MetroPanel panelHeader;
    private Label lblOrderType;
    private ReaLTaiizor.Controls.ExtendedPanel panelCategory;
    private ReaLTaiizor.Controls.AirRadioButton rbSoup;
    private ReaLTaiizor.Controls.AirRadioButton rbDrink;
    private ReaLTaiizor.Controls.AirRadioButton rbStaple;
    private ReaLTaiizor.Controls.AirRadioButton rbColdDish;
    private ReaLTaiizor.Controls.AirRadioButton rbHotDish;
    private ReaLTaiizor.Controls.AirRadioButton rbAll;
    private Label lblCategoryTitle;
    private Label lblHeaderTitle;
}
