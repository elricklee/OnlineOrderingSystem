namespace ClientCustomer;

partial class RegisterForm
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
        lblConfirmPassword = new Sunny.UI.UILabel();
        txtConfirmPassword = new Sunny.UI.UITextBox();
        lblRealName = new Sunny.UI.UILabel();
        txtRealName = new Sunny.UI.UITextBox();
        lblPhone = new Sunny.UI.UILabel();
        txtPhone = new Sunny.UI.UITextBox();
        lblAddress = new Sunny.UI.UILabel();
        txtAddress = new Sunny.UI.UITextBox();
        btnRegister = new Sunny.UI.UIButton();
        btnCancel = new Sunny.UI.UIButton();
        panelMain = new Sunny.UI.UIPanel();
        panelMain.SuspendLayout();
        SuspendLayout();
        //
        // lblTitle
        //
        lblTitle.Font = new Font("微软雅黑", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(255, 109, 0);
        lblTitle.Location = new Point(150, 15);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(200, 35);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "注册新账号";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        //
        // lblUsername
        //
        lblUsername.Font = new Font("微软雅黑", 10F);
        lblUsername.ForeColor = Color.FromArgb(51, 51, 51);
        lblUsername.Location = new Point(30, 60);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(80, 28);
        lblUsername.TabIndex = 1;
        lblUsername.Text = "用户名：";
        //
        // txtUsername
        //
        txtUsername.Font = new Font("微软雅黑", 10F);
        txtUsername.Location = new Point(110, 56);
        txtUsername.Margin = new Padding(4, 5, 4, 5);
        txtUsername.MinimumSize = new Size(1, 16);
        txtUsername.Name = "txtUsername";
        txtUsername.Padding = new Padding(5);
        txtUsername.ShowText = false;
        txtUsername.Size = new Size(200, 32);
        txtUsername.TabIndex = 2;
        txtUsername.TextAlignment = ContentAlignment.MiddleLeft;
        txtUsername.Watermark = "必填";
        //
        // lblPassword
        //
        lblPassword.Font = new Font("微软雅黑", 10F);
        lblPassword.ForeColor = Color.FromArgb(51, 51, 51);
        lblPassword.Location = new Point(30, 98);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(80, 28);
        lblPassword.TabIndex = 3;
        lblPassword.Text = "密码：";
        //
        // txtPassword
        //
        txtPassword.Font = new Font("微软雅黑", 10F);
        txtPassword.Location = new Point(110, 94);
        txtPassword.Margin = new Padding(4, 5, 4, 5);
        txtPassword.MinimumSize = new Size(1, 16);
        txtPassword.Name = "txtPassword";
        txtPassword.Padding = new Padding(5);
        txtPassword.PasswordChar = '●';
        txtPassword.ShowText = false;
        txtPassword.Size = new Size(200, 32);
        txtPassword.TabIndex = 4;
        txtPassword.TextAlignment = ContentAlignment.MiddleLeft;
        txtPassword.Watermark = "必填";
        //
        // lblConfirmPassword
        //
        lblConfirmPassword.Font = new Font("微软雅黑", 10F);
        lblConfirmPassword.ForeColor = Color.FromArgb(51, 51, 51);
        lblConfirmPassword.Location = new Point(30, 136);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(80, 28);
        lblConfirmPassword.TabIndex = 5;
        lblConfirmPassword.Text = "确认密码：";
        //
        // txtConfirmPassword
        //
        txtConfirmPassword.Font = new Font("微软雅黑", 10F);
        txtConfirmPassword.Location = new Point(110, 132);
        txtConfirmPassword.Margin = new Padding(4, 5, 4, 5);
        txtConfirmPassword.MinimumSize = new Size(1, 16);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.Padding = new Padding(5);
        txtConfirmPassword.PasswordChar = '●';
        txtConfirmPassword.ShowText = false;
        txtConfirmPassword.Size = new Size(200, 32);
        txtConfirmPassword.TabIndex = 6;
        txtConfirmPassword.TextAlignment = ContentAlignment.MiddleLeft;
        txtConfirmPassword.Watermark = "必填";
        //
        // lblRealName
        //
        lblRealName.Font = new Font("微软雅黑", 10F);
        lblRealName.ForeColor = Color.FromArgb(51, 51, 51);
        lblRealName.Location = new Point(30, 174);
        lblRealName.Name = "lblRealName";
        lblRealName.Size = new Size(80, 28);
        lblRealName.TabIndex = 7;
        lblRealName.Text = "真实姓名：";
        //
        // txtRealName
        //
        txtRealName.Font = new Font("微软雅黑", 10F);
        txtRealName.Location = new Point(110, 170);
        txtRealName.Margin = new Padding(4, 5, 4, 5);
        txtRealName.MinimumSize = new Size(1, 16);
        txtRealName.Name = "txtRealName";
        txtRealName.Padding = new Padding(5);
        txtRealName.ShowText = false;
        txtRealName.Size = new Size(200, 32);
        txtRealName.TabIndex = 8;
        txtRealName.TextAlignment = ContentAlignment.MiddleLeft;
        txtRealName.Watermark = "选填";
        //
        // lblPhone
        //
        lblPhone.Font = new Font("微软雅黑", 10F);
        lblPhone.ForeColor = Color.FromArgb(51, 51, 51);
        lblPhone.Location = new Point(30, 212);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(80, 28);
        lblPhone.TabIndex = 9;
        lblPhone.Text = "手机号：";
        //
        // txtPhone
        //
        txtPhone.Font = new Font("微软雅黑", 10F);
        txtPhone.Location = new Point(110, 208);
        txtPhone.Margin = new Padding(4, 5, 4, 5);
        txtPhone.MinimumSize = new Size(1, 16);
        txtPhone.Name = "txtPhone";
        txtPhone.Padding = new Padding(5);
        txtPhone.ShowText = false;
        txtPhone.Size = new Size(200, 32);
        txtPhone.TabIndex = 10;
        txtPhone.TextAlignment = ContentAlignment.MiddleLeft;
        txtPhone.Watermark = "选填";
        //
        // lblAddress
        //
        lblAddress.Font = new Font("微软雅黑", 10F);
        lblAddress.ForeColor = Color.FromArgb(51, 51, 51);
        lblAddress.Location = new Point(30, 250);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(80, 28);
        lblAddress.TabIndex = 11;
        lblAddress.Text = "常用地址：";
        //
        // txtAddress
        //
        txtAddress.Font = new Font("微软雅黑", 10F);
        txtAddress.Location = new Point(110, 246);
        txtAddress.Margin = new Padding(4, 5, 4, 5);
        txtAddress.MinimumSize = new Size(1, 16);
        txtAddress.Name = "txtAddress";
        txtAddress.Padding = new Padding(5);
        txtAddress.ShowText = false;
        txtAddress.Size = new Size(200, 32);
        txtAddress.TabIndex = 12;
        txtAddress.TextAlignment = ContentAlignment.MiddleLeft;
        txtAddress.Watermark = "选填";
        //
        // btnRegister
        //
        btnRegister.Cursor = Cursors.Hand;
        btnRegister.FillColor = Color.FromArgb(255, 109, 0);
        btnRegister.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        btnRegister.ForeColor = Color.White;
        btnRegister.Location = new Point(30, 300);
        btnRegister.MinimumSize = new Size(1, 1);
        btnRegister.Name = "btnRegister";
        btnRegister.Radius = 8;
        btnRegister.RectColor = Color.FromArgb(255, 109, 0);
        btnRegister.Size = new Size(135, 40);
        btnRegister.TabIndex = 13;
        btnRegister.Text = "注册";
        //
        // btnCancel
        //
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.FillColor = Color.FromArgb(117, 117, 117);
        btnCancel.Font = new Font("微软雅黑", 11F);
        btnCancel.ForeColor = Color.White;
        btnCancel.Location = new Point(175, 300);
        btnCancel.MinimumSize = new Size(1, 1);
        btnCancel.Name = "btnCancel";
        btnCancel.Radius = 8;
        btnCancel.RectColor = Color.FromArgb(117, 117, 117);
        btnCancel.Size = new Size(135, 40);
        btnCancel.TabIndex = 14;
        btnCancel.Text = "取消";
        //
        // panelMain
        //
        panelMain.Controls.Add(lblTitle);
        panelMain.Controls.Add(lblUsername);
        panelMain.Controls.Add(txtUsername);
        panelMain.Controls.Add(lblPassword);
        panelMain.Controls.Add(txtPassword);
        panelMain.Controls.Add(lblConfirmPassword);
        panelMain.Controls.Add(txtConfirmPassword);
        panelMain.Controls.Add(lblRealName);
        panelMain.Controls.Add(txtRealName);
        panelMain.Controls.Add(lblPhone);
        panelMain.Controls.Add(txtPhone);
        panelMain.Controls.Add(lblAddress);
        panelMain.Controls.Add(txtAddress);
        panelMain.Controls.Add(btnRegister);
        panelMain.Controls.Add(btnCancel);
        panelMain.Dock = DockStyle.Fill;
        panelMain.FillColor = Color.White;
        panelMain.Location = new Point(0, 0);
        panelMain.Name = "panelMain";
        panelMain.Size = new Size(350, 360);
        panelMain.TabIndex = 0;
        //
        // RegisterForm
        //
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        ClientSize = new Size(350, 360);
        Controls.Add(panelMain);
        Font = new Font("微软雅黑", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "RegisterForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "注册账号";
        panelMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Sunny.UI.UILabel lblTitle;
    private Sunny.UI.UILabel lblUsername;
    private Sunny.UI.UITextBox txtUsername;
    private Sunny.UI.UILabel lblPassword;
    private Sunny.UI.UITextBox txtPassword;
    private Sunny.UI.UILabel lblConfirmPassword;
    private Sunny.UI.UITextBox txtConfirmPassword;
    private Sunny.UI.UILabel lblRealName;
    private Sunny.UI.UITextBox txtRealName;
    private Sunny.UI.UILabel lblPhone;
    private Sunny.UI.UITextBox txtPhone;
    private Sunny.UI.UILabel lblAddress;
    private Sunny.UI.UITextBox txtAddress;
    private Sunny.UI.UIButton btnRegister;
    private Sunny.UI.UIButton btnCancel;
    private Sunny.UI.UIPanel panelMain;
}
