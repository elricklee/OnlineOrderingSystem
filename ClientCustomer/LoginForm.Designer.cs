namespace ClientCustomer;

partial class LoginForm
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
        lblTitle = new Sunny.UI.UILabel();
        lblUsername = new Sunny.UI.UILabel();
        txtUsername = new Sunny.UI.UITextBox();
        lblPassword = new Sunny.UI.UILabel();
        txtPassword = new Sunny.UI.UITextBox();
        btnLogin = new Sunny.UI.UIButton();
        btnRegister = new Sunny.UI.UIButton();
        btnGuest = new Sunny.UI.UIButton();
        panelMain = new Sunny.UI.UIPanel();
        panelMain.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("微软雅黑", 20F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(255, 109, 0);
        lblTitle.Location = new Point(100, 9);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(280, 63);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "珞珈线上点餐系统";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblUsername
        // 
        lblUsername.Font = new Font("微软雅黑", 11F);
        lblUsername.ForeColor = Color.FromArgb(51, 51, 51);
        lblUsername.Location = new Point(60, 100);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(80, 30);
        lblUsername.TabIndex = 1;
        lblUsername.Text = "用户名：";
        // 
        // txtUsername
        // 
        txtUsername.Font = new Font("微软雅黑", 11F);
        txtUsername.Location = new Point(140, 96);
        txtUsername.Margin = new Padding(4, 5, 4, 5);
        txtUsername.MinimumSize = new Size(1, 16);
        txtUsername.Name = "txtUsername";
        txtUsername.Padding = new Padding(5);
        txtUsername.ShowText = false;
        txtUsername.Size = new Size(240, 36);
        txtUsername.TabIndex = 2;
        txtUsername.TextAlignment = ContentAlignment.MiddleLeft;
        txtUsername.Watermark = "请输入用户名";
        // 
        // lblPassword
        // 
        lblPassword.Font = new Font("微软雅黑", 11F);
        lblPassword.ForeColor = Color.FromArgb(51, 51, 51);
        lblPassword.Location = new Point(60, 155);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(80, 30);
        lblPassword.TabIndex = 3;
        lblPassword.Text = "密码：";
        // 
        // txtPassword
        // 
        txtPassword.Font = new Font("微软雅黑", 11F);
        txtPassword.Location = new Point(140, 151);
        txtPassword.Margin = new Padding(4, 5, 4, 5);
        txtPassword.MinimumSize = new Size(1, 16);
        txtPassword.Name = "txtPassword";
        txtPassword.Padding = new Padding(5);
        txtPassword.PasswordChar = '●';
        txtPassword.ShowText = false;
        txtPassword.Size = new Size(240, 36);
        txtPassword.TabIndex = 4;
        txtPassword.TextAlignment = ContentAlignment.MiddleLeft;
        txtPassword.Watermark = "请输入密码";
        // 
        // btnLogin
        // 
        btnLogin.Cursor = Cursors.Hand;
        btnLogin.FillColor = Color.FromArgb(255, 109, 0);
        btnLogin.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        btnLogin.Location = new Point(60, 220);
        btnLogin.MinimumSize = new Size(1, 1);
        btnLogin.Name = "btnLogin";
        btnLogin.Radius = 8;
        btnLogin.RectColor = Color.FromArgb(255, 109, 0);
        btnLogin.Size = new Size(160, 42);
        btnLogin.TabIndex = 5;
        btnLogin.Text = "登录";
        btnLogin.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // btnRegister
        // 
        btnRegister.Cursor = Cursors.Hand;
        btnRegister.FillColor = Color.FromArgb(51, 122, 183);
        btnRegister.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        btnRegister.Location = new Point(230, 220);
        btnRegister.MinimumSize = new Size(1, 1);
        btnRegister.Name = "btnRegister";
        btnRegister.Radius = 8;
        btnRegister.RectColor = Color.FromArgb(51, 122, 183);
        btnRegister.Size = new Size(160, 42);
        btnRegister.TabIndex = 6;
        btnRegister.Text = "注册账号";
        btnRegister.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // btnGuest
        // 
        btnGuest.Cursor = Cursors.Hand;
        btnGuest.FillColor = Color.FromArgb(117, 117, 117);
        btnGuest.Font = new Font("微软雅黑", 10F);
        btnGuest.Location = new Point(120, 280);
        btnGuest.MinimumSize = new Size(1, 1);
        btnGuest.Name = "btnGuest";
        btnGuest.Radius = 8;
        btnGuest.RectColor = Color.FromArgb(117, 117, 117);
        btnGuest.Size = new Size(200, 36);
        btnGuest.TabIndex = 7;
        btnGuest.Text = "游客模式点餐";
        btnGuest.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        // 
        // panelMain
        // 
        panelMain.Controls.Add(lblTitle);
        panelMain.Controls.Add(lblUsername);
        panelMain.Controls.Add(txtUsername);
        panelMain.Controls.Add(lblPassword);
        panelMain.Controls.Add(txtPassword);
        panelMain.Controls.Add(btnLogin);
        panelMain.Controls.Add(btnRegister);
        panelMain.Controls.Add(btnGuest);
        panelMain.Dock = DockStyle.Fill;
        panelMain.FillColor = Color.White;
        panelMain.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        panelMain.Location = new Point(0, 0);
        panelMain.Margin = new Padding(4, 5, 4, 5);
        panelMain.MinimumSize = new Size(1, 1);
        panelMain.Name = "panelMain";
        panelMain.Size = new Size(480, 360);
        panelMain.TabIndex = 0;
        panelMain.Text = null;
        panelMain.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // LoginForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        ClientSize = new Size(480, 360);
        Controls.Add(panelMain);
        Font = new Font("微软雅黑", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "用户登录";
        panelMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Sunny.UI.UILabel lblTitle;
    private Sunny.UI.UILabel lblUsername;
    private Sunny.UI.UITextBox txtUsername;
    private Sunny.UI.UILabel lblPassword;
    private Sunny.UI.UITextBox txtPassword;
    private Sunny.UI.UIButton btnLogin;
    private Sunny.UI.UIButton btnRegister;
    private Sunny.UI.UIButton btnGuest;
    private Sunny.UI.UIPanel panelMain;
}
