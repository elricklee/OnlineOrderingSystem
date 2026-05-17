namespace ClientCustomer;

partial class ForgotPasswordForm
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
        lblRealName = new Sunny.UI.UILabel();
        txtRealName = new Sunny.UI.UITextBox();
        lblNewPassword = new Sunny.UI.UILabel();
        txtNewPassword = new Sunny.UI.UITextBox();
        lblConfirmPassword = new Sunny.UI.UILabel();
        txtConfirmPassword = new Sunny.UI.UITextBox();
        lblHint = new Sunny.UI.UILabel();
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
        panelMain.Controls.Add(lblRealName);
        panelMain.Controls.Add(txtRealName);
        panelMain.Controls.Add(lblNewPassword);
        panelMain.Controls.Add(txtNewPassword);
        panelMain.Controls.Add(lblConfirmPassword);
        panelMain.Controls.Add(txtConfirmPassword);
        panelMain.Controls.Add(lblHint);
        panelMain.Controls.Add(btnSubmit);
        panelMain.Controls.Add(btnCancel);
        panelMain.Dock = DockStyle.Fill;
        panelMain.FillColor = Color.White;
        panelMain.Font = new Font("微软雅黑", 10F);
        panelMain.Location = new Point(0, 0);
        panelMain.MinimumSize = new Size(1, 1);
        panelMain.Name = "panelMain";
        panelMain.Size = new Size(500, 392);
        panelMain.TabIndex = 0;
        panelMain.Text = null;
        panelMain.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("微软雅黑", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(51, 122, 183);
        lblTitle.Location = new Point(108, 18);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(284, 44);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "忘记密码";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblUsername
        // 
        lblUsername.Font = new Font("微软雅黑", 10.5F);
        lblUsername.Location = new Point(48, 92);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(94, 30);
        lblUsername.TabIndex = 1;
        lblUsername.Text = "用户名：";
        // 
        // txtUsername
        // 
        txtUsername.Font = new Font("微软雅黑", 10.5F);
        txtUsername.Location = new Point(150, 88);
        txtUsername.MinimumSize = new Size(1, 16);
        txtUsername.Name = "txtUsername";
        txtUsername.Padding = new Padding(5);
        txtUsername.ShowText = false;
        txtUsername.Size = new Size(300, 36);
        txtUsername.TabIndex = 2;
        txtUsername.TextAlignment = ContentAlignment.MiddleLeft;
        txtUsername.Watermark = "请输入要找回的用户名";
        // 
        // lblRealName
        // 
        lblRealName.Font = new Font("微软雅黑", 10.5F);
        lblRealName.Location = new Point(48, 140);
        lblRealName.Name = "lblRealName";
        lblRealName.Size = new Size(94, 30);
        lblRealName.TabIndex = 3;
        lblRealName.Text = "真实姓名：";
        // 
        // txtRealName
        // 
        txtRealName.Font = new Font("微软雅黑", 10.5F);
        txtRealName.Location = new Point(150, 136);
        txtRealName.MinimumSize = new Size(1, 16);
        txtRealName.Name = "txtRealName";
        txtRealName.Padding = new Padding(5);
        txtRealName.ShowText = false;
        txtRealName.Size = new Size(300, 36);
        txtRealName.TabIndex = 4;
        txtRealName.TextAlignment = ContentAlignment.MiddleLeft;
        txtRealName.Watermark = "用于身份校验";
        // 
        // lblNewPassword
        // 
        lblNewPassword.Font = new Font("微软雅黑", 10.5F);
        lblNewPassword.Location = new Point(48, 188);
        lblNewPassword.Name = "lblNewPassword";
        lblNewPassword.Size = new Size(94, 30);
        lblNewPassword.TabIndex = 5;
        lblNewPassword.Text = "新密码：";
        // 
        // txtNewPassword
        // 
        txtNewPassword.Font = new Font("微软雅黑", 10.5F);
        txtNewPassword.Location = new Point(150, 184);
        txtNewPassword.MinimumSize = new Size(1, 16);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.Padding = new Padding(5);
        txtNewPassword.PasswordChar = '●';
        txtNewPassword.ShowText = false;
        txtNewPassword.Size = new Size(300, 36);
        txtNewPassword.TabIndex = 6;
        txtNewPassword.TextAlignment = ContentAlignment.MiddleLeft;
        txtNewPassword.Watermark = "至少 6 位";
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.Font = new Font("微软雅黑", 10.5F);
        lblConfirmPassword.Location = new Point(48, 236);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(94, 30);
        lblConfirmPassword.TabIndex = 7;
        lblConfirmPassword.Text = "确认密码：";
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.Font = new Font("微软雅黑", 10.5F);
        txtConfirmPassword.Location = new Point(150, 232);
        txtConfirmPassword.MinimumSize = new Size(1, 16);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.Padding = new Padding(5);
        txtConfirmPassword.PasswordChar = '●';
        txtConfirmPassword.ShowText = false;
        txtConfirmPassword.Size = new Size(300, 36);
        txtConfirmPassword.TabIndex = 8;
        txtConfirmPassword.TextAlignment = ContentAlignment.MiddleLeft;
        txtConfirmPassword.Watermark = "请再次输入新密码";
        // 
        // lblHint
        // 
        lblHint.Font = new Font("微软雅黑", 9F);
        lblHint.ForeColor = Color.FromArgb(117, 117, 117);
        lblHint.Location = new Point(48, 284);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(402, 42);
        lblHint.TabIndex = 9;
        lblHint.Text = "为了简化流程，这里使用“用户名 + 真实姓名”进行身份校验。";
        // 
        // btnSubmit
        // 
        btnSubmit.FillColor = Color.FromArgb(51, 122, 183);
        btnSubmit.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold);
        btnSubmit.Location = new Point(178, 334);
        btnSubmit.MinimumSize = new Size(1, 1);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Radius = 8;
        btnSubmit.RectColor = Color.FromArgb(51, 122, 183);
        btnSubmit.Size = new Size(120, 40);
        btnSubmit.TabIndex = 10;
        btnSubmit.Text = "重设密码";
        btnSubmit.TipsFont = new Font("宋体", 9F);
        // 
        // btnCancel
        // 
        btnCancel.FillColor = Color.FromArgb(117, 117, 117);
        btnCancel.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold);
        btnCancel.Location = new Point(330, 334);
        btnCancel.MinimumSize = new Size(1, 1);
        btnCancel.Name = "btnCancel";
        btnCancel.Radius = 8;
        btnCancel.RectColor = Color.FromArgb(117, 117, 117);
        btnCancel.Size = new Size(120, 40);
        btnCancel.TabIndex = 11;
        btnCancel.Text = "取消";
        btnCancel.TipsFont = new Font("宋体", 9F);
        // 
        // ForgotPasswordForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(500, 392);
        Controls.Add(panelMain);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ForgotPasswordForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "忘记密码";
        panelMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Sunny.UI.UIPanel panelMain;
    private Sunny.UI.UILabel lblTitle;
    private Sunny.UI.UILabel lblUsername;
    private Sunny.UI.UITextBox txtUsername;
    private Sunny.UI.UILabel lblRealName;
    private Sunny.UI.UITextBox txtRealName;
    private Sunny.UI.UILabel lblNewPassword;
    private Sunny.UI.UITextBox txtNewPassword;
    private Sunny.UI.UILabel lblConfirmPassword;
    private Sunny.UI.UITextBox txtConfirmPassword;
    private Sunny.UI.UILabel lblHint;
    private Sunny.UI.UIButton btnSubmit;
    private Sunny.UI.UIButton btnCancel;
}
