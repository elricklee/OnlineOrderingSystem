namespace ClientCustomer;

partial class ChangePasswordForm
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
        panelMain = new Sunny.UI.UIPanel();
        lblTitle = new Sunny.UI.UILabel();
        lblUsername = new Sunny.UI.UILabel();
        txtUsername = new Sunny.UI.UITextBox();
        lblOldPassword = new Sunny.UI.UILabel();
        txtOldPassword = new Sunny.UI.UITextBox();
        lblNewPassword = new Sunny.UI.UILabel();
        txtNewPassword = new Sunny.UI.UITextBox();
        lblConfirmPassword = new Sunny.UI.UILabel();
        txtConfirmPassword = new Sunny.UI.UITextBox();
        btnSubmit = new Sunny.UI.UIButton();
        btnCancel = new Sunny.UI.UIButton();
        panelMain.SuspendLayout();
        SuspendLayout();
        // 
        // panelMain
        // 
        panelMain.Controls.Add(lblTitle);
        panelMain.Controls.Add(lblUsername);
        panelMain.Controls.Add(txtUsername);
        panelMain.Controls.Add(lblOldPassword);
        panelMain.Controls.Add(txtOldPassword);
        panelMain.Controls.Add(lblNewPassword);
        panelMain.Controls.Add(txtNewPassword);
        panelMain.Controls.Add(lblConfirmPassword);
        panelMain.Controls.Add(txtConfirmPassword);
        panelMain.Controls.Add(btnSubmit);
        panelMain.Controls.Add(btnCancel);
        panelMain.Dock = DockStyle.Fill;
        panelMain.FillColor = Color.White;
        panelMain.Font = new Font("微软雅黑", 10F);
        panelMain.Location = new Point(0, 0);
        panelMain.MinimumSize = new Size(1, 1);
        panelMain.Name = "panelMain";
        panelMain.Size = new Size(470, 360);
        panelMain.TabIndex = 0;
        panelMain.Text = null;
        panelMain.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("微软雅黑", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(255, 109, 0);
        lblTitle.Location = new Point(95, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(280, 46);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "修改密码";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblUsername
        // 
        lblUsername.Font = new Font("微软雅黑", 10.5F);
        lblUsername.Location = new Point(42, 90);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(94, 30);
        lblUsername.TabIndex = 1;
        lblUsername.Text = "用户名：";
        // 
        // txtUsername
        // 
        txtUsername.Font = new Font("微软雅黑", 10.5F);
        txtUsername.Location = new Point(140, 86);
        txtUsername.MinimumSize = new Size(1, 16);
        txtUsername.Name = "txtUsername";
        txtUsername.Padding = new Padding(5);
        txtUsername.ShowText = false;
        txtUsername.Size = new Size(276, 36);
        txtUsername.TabIndex = 2;
        txtUsername.TextAlignment = ContentAlignment.MiddleLeft;
        txtUsername.Watermark = "请输入用户名";
        // 
        // lblOldPassword
        // 
        lblOldPassword.Font = new Font("微软雅黑", 10.5F);
        lblOldPassword.Location = new Point(42, 138);
        lblOldPassword.Name = "lblOldPassword";
        lblOldPassword.Size = new Size(94, 30);
        lblOldPassword.TabIndex = 3;
        lblOldPassword.Text = "原密码：";
        // 
        // txtOldPassword
        // 
        txtOldPassword.Font = new Font("微软雅黑", 10.5F);
        txtOldPassword.Location = new Point(140, 134);
        txtOldPassword.MinimumSize = new Size(1, 16);
        txtOldPassword.Name = "txtOldPassword";
        txtOldPassword.Padding = new Padding(5);
        txtOldPassword.PasswordChar = '●';
        txtOldPassword.ShowText = false;
        txtOldPassword.Size = new Size(276, 36);
        txtOldPassword.TabIndex = 4;
        txtOldPassword.TextAlignment = ContentAlignment.MiddleLeft;
        txtOldPassword.Watermark = "请输入原密码";
        // 
        // lblNewPassword
        // 
        lblNewPassword.Font = new Font("微软雅黑", 10.5F);
        lblNewPassword.Location = new Point(42, 186);
        lblNewPassword.Name = "lblNewPassword";
        lblNewPassword.Size = new Size(94, 30);
        lblNewPassword.TabIndex = 5;
        lblNewPassword.Text = "新密码：";
        // 
        // txtNewPassword
        // 
        txtNewPassword.Font = new Font("微软雅黑", 10.5F);
        txtNewPassword.Location = new Point(140, 182);
        txtNewPassword.MinimumSize = new Size(1, 16);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.Padding = new Padding(5);
        txtNewPassword.PasswordChar = '●';
        txtNewPassword.ShowText = false;
        txtNewPassword.Size = new Size(276, 36);
        txtNewPassword.TabIndex = 6;
        txtNewPassword.TextAlignment = ContentAlignment.MiddleLeft;
        txtNewPassword.Watermark = "至少 6 位";
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.Font = new Font("微软雅黑", 10.5F);
        lblConfirmPassword.Location = new Point(42, 234);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(94, 30);
        lblConfirmPassword.TabIndex = 7;
        lblConfirmPassword.Text = "确认密码：";
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.Font = new Font("微软雅黑", 10.5F);
        txtConfirmPassword.Location = new Point(140, 230);
        txtConfirmPassword.MinimumSize = new Size(1, 16);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.Padding = new Padding(5);
        txtConfirmPassword.PasswordChar = '●';
        txtConfirmPassword.ShowText = false;
        txtConfirmPassword.Size = new Size(276, 36);
        txtConfirmPassword.TabIndex = 8;
        txtConfirmPassword.TextAlignment = ContentAlignment.MiddleLeft;
        txtConfirmPassword.Watermark = "请再次输入新密码";
        // 
        // btnSubmit
        // 
        btnSubmit.FillColor = Color.FromArgb(255, 109, 0);
        btnSubmit.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold);
        btnSubmit.Location = new Point(140, 294);
        btnSubmit.MinimumSize = new Size(1, 1);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Radius = 8;
        btnSubmit.RectColor = Color.FromArgb(255, 109, 0);
        btnSubmit.Size = new Size(128, 40);
        btnSubmit.TabIndex = 9;
        btnSubmit.Text = "确认修改";
        btnSubmit.TipsFont = new Font("宋体", 9F);
        // 
        // btnCancel
        // 
        btnCancel.FillColor = Color.FromArgb(117, 117, 117);
        btnCancel.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold);
        btnCancel.Location = new Point(288, 294);
        btnCancel.MinimumSize = new Size(1, 1);
        btnCancel.Name = "btnCancel";
        btnCancel.Radius = 8;
        btnCancel.RectColor = Color.FromArgb(117, 117, 117);
        btnCancel.Size = new Size(128, 40);
        btnCancel.TabIndex = 10;
        btnCancel.Text = "取消";
        btnCancel.TipsFont = new Font("宋体", 9F);
        // 
        // ChangePasswordForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(470, 360);
        Controls.Add(panelMain);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ChangePasswordForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "修改密码";
        panelMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Sunny.UI.UIPanel panelMain;
    private Sunny.UI.UILabel lblTitle;
    private Sunny.UI.UILabel lblUsername;
    private Sunny.UI.UITextBox txtUsername;
    private Sunny.UI.UILabel lblOldPassword;
    private Sunny.UI.UITextBox txtOldPassword;
    private Sunny.UI.UILabel lblNewPassword;
    private Sunny.UI.UITextBox txtNewPassword;
    private Sunny.UI.UILabel lblConfirmPassword;
    private Sunny.UI.UITextBox txtConfirmPassword;
    private Sunny.UI.UIButton btnSubmit;
    private Sunny.UI.UIButton btnCancel;
}
