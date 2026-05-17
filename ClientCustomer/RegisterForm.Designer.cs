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
        lblSubTitle = new Sunny.UI.UILabel();
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
        lblRegion = new Sunny.UI.UILabel();
        cmbProvince = new ComboBox();
        cmbCity = new ComboBox();
        cmbDistrict = new ComboBox();
        lblAddress = new Sunny.UI.UILabel();
        txtAddress = new Sunny.UI.UITextBox();
        lblHint = new Sunny.UI.UILabel();
        btnRegister = new Sunny.UI.UIButton();
        btnCancel = new Sunny.UI.UIButton();
        panelMain = new Sunny.UI.UIPanel();
        panelMain.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("微软雅黑", 20F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(230, 81, 0);
        lblTitle.Location = new Point(40, 25);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(420, 45);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "注册新账号";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSubTitle
        // 
        lblSubTitle.Font = new Font("微软雅黑", 9.5F);
        lblSubTitle.ForeColor = Color.FromArgb(117, 117, 117);
        lblSubTitle.Location = new Point(40, 70);
        lblSubTitle.Name = "lblSubTitle";
        lblSubTitle.Size = new Size(420, 28);
        lblSubTitle.TabIndex = 1;
        lblSubTitle.Text = "请填写真实联系方式，便于订单提醒和配送核对";
        lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblUsername
        // 
        lblUsername.Font = new Font("微软雅黑", 10.5F);
        lblUsername.ForeColor = Color.FromArgb(51, 51, 51);
        lblUsername.Location = new Point(55, 118);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(110, 30);
        lblUsername.TabIndex = 2;
        lblUsername.Text = "用户名 *：";
        lblUsername.TextAlign = ContentAlignment.MiddleRight;
        // 
        // txtUsername
        // 
        txtUsername.Font = new Font("微软雅黑", 10.5F);
        txtUsername.Location = new Point(178, 114);
        txtUsername.Margin = new Padding(4, 5, 4, 5);
        txtUsername.MinimumSize = new Size(1, 16);
        txtUsername.Name = "txtUsername";
        txtUsername.Padding = new Padding(8, 5, 8, 5);
        txtUsername.ShowText = false;
        txtUsername.Size = new Size(260, 34);
        txtUsername.TabIndex = 3;
        txtUsername.TextAlignment = ContentAlignment.MiddleLeft;
        txtUsername.Watermark = "3-20个字符";
        // 
        // lblPassword
        // 
        lblPassword.Font = new Font("微软雅黑", 10.5F);
        lblPassword.ForeColor = Color.FromArgb(51, 51, 51);
        lblPassword.Location = new Point(55, 162);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(110, 30);
        lblPassword.TabIndex = 4;
        lblPassword.Text = "密码 *：";
        lblPassword.TextAlign = ContentAlignment.MiddleRight;
        // 
        // txtPassword
        // 
        txtPassword.Font = new Font("微软雅黑", 10.5F);
        txtPassword.Location = new Point(178, 158);
        txtPassword.Margin = new Padding(4, 5, 4, 5);
        txtPassword.MinimumSize = new Size(1, 16);
        txtPassword.Name = "txtPassword";
        txtPassword.Padding = new Padding(8, 5, 8, 5);
        txtPassword.PasswordChar = '●';
        txtPassword.ShowText = false;
        txtPassword.Size = new Size(260, 34);
        txtPassword.TabIndex = 5;
        txtPassword.TextAlignment = ContentAlignment.MiddleLeft;
        txtPassword.Watermark = "至少6个字符";
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.Font = new Font("微软雅黑", 10.5F);
        lblConfirmPassword.ForeColor = Color.FromArgb(51, 51, 51);
        lblConfirmPassword.Location = new Point(55, 206);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(110, 30);
        lblConfirmPassword.TabIndex = 6;
        lblConfirmPassword.Text = "确认密码 *：";
        lblConfirmPassword.TextAlign = ContentAlignment.MiddleRight;
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.Font = new Font("微软雅黑", 10.5F);
        txtConfirmPassword.Location = new Point(178, 202);
        txtConfirmPassword.Margin = new Padding(4, 5, 4, 5);
        txtConfirmPassword.MinimumSize = new Size(1, 16);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.Padding = new Padding(8, 5, 8, 5);
        txtConfirmPassword.PasswordChar = '●';
        txtConfirmPassword.ShowText = false;
        txtConfirmPassword.Size = new Size(260, 34);
        txtConfirmPassword.TabIndex = 7;
        txtConfirmPassword.TextAlignment = ContentAlignment.MiddleLeft;
        txtConfirmPassword.Watermark = "再次输入密码";
        // 
        // lblRealName
        // 
        lblRealName.Font = new Font("微软雅黑", 10.5F);
        lblRealName.ForeColor = Color.FromArgb(51, 51, 51);
        lblRealName.Location = new Point(55, 250);
        lblRealName.Name = "lblRealName";
        lblRealName.Size = new Size(110, 30);
        lblRealName.TabIndex = 8;
        lblRealName.Text = "真实姓名 *：";
        lblRealName.TextAlign = ContentAlignment.MiddleRight;
        // 
        // txtRealName
        // 
        txtRealName.Font = new Font("微软雅黑", 10.5F);
        txtRealName.Location = new Point(178, 246);
        txtRealName.Margin = new Padding(4, 5, 4, 5);
        txtRealName.MinimumSize = new Size(1, 16);
        txtRealName.Name = "txtRealName";
        txtRealName.Padding = new Padding(8, 5, 8, 5);
        txtRealName.ShowText = false;
        txtRealName.Size = new Size(260, 34);
        txtRealName.TabIndex = 9;
        txtRealName.TextAlignment = ContentAlignment.MiddleLeft;
        txtRealName.Watermark = "用于管理员核对订单";
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("微软雅黑", 10.5F);
        lblPhone.ForeColor = Color.FromArgb(51, 51, 51);
        lblPhone.Location = new Point(55, 294);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(110, 30);
        lblPhone.TabIndex = 10;
        lblPhone.Text = "手机号 *：";
        lblPhone.TextAlign = ContentAlignment.MiddleRight;
        // 
        // txtPhone
        // 
        txtPhone.Font = new Font("微软雅黑", 10.5F);
        txtPhone.Location = new Point(178, 290);
        txtPhone.Margin = new Padding(4, 5, 4, 5);
        txtPhone.MinimumSize = new Size(1, 16);
        txtPhone.Name = "txtPhone";
        txtPhone.Padding = new Padding(8, 5, 8, 5);
        txtPhone.ShowText = false;
        txtPhone.Size = new Size(260, 34);
        txtPhone.TabIndex = 11;
        txtPhone.TextAlignment = ContentAlignment.MiddleLeft;
        txtPhone.Watermark = "请输入11位大陆手机号";
        // 
        // lblRegion
        // 
        lblRegion.Font = new Font("微软雅黑", 10.5F);
        lblRegion.ForeColor = Color.FromArgb(51, 51, 51);
        lblRegion.Location = new Point(55, 338);
        lblRegion.Name = "lblRegion";
        lblRegion.Size = new Size(110, 30);
        lblRegion.TabIndex = 12;
        lblRegion.Text = "常用区域 *：";
        lblRegion.TextAlign = ContentAlignment.MiddleRight;
        // 
        // cmbProvince
        // 
        cmbProvince.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProvince.Font = new Font("微软雅黑", 10F);
        cmbProvince.FormattingEnabled = true;
        cmbProvince.Location = new Point(178, 335);
        cmbProvince.Name = "cmbProvince";
        cmbProvince.Size = new Size(100, 35);
        cmbProvince.TabIndex = 13;
        // 
        // cmbCity
        // 
        cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCity.Font = new Font("微软雅黑", 10F);
        cmbCity.FormattingEnabled = true;
        cmbCity.Location = new Point(285, 335);
        cmbCity.Name = "cmbCity";
        cmbCity.Size = new Size(100, 35);
        cmbCity.TabIndex = 14;
        // 
        // cmbDistrict
        // 
        cmbDistrict.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDistrict.Font = new Font("微软雅黑", 10F);
        cmbDistrict.FormattingEnabled = true;
        cmbDistrict.Location = new Point(392, 335);
        cmbDistrict.Name = "cmbDistrict";
        cmbDistrict.Size = new Size(100, 35);
        cmbDistrict.TabIndex = 15;
        // 
        // lblAddress
        // 
        lblAddress.Font = new Font("微软雅黑", 10.5F);
        lblAddress.ForeColor = Color.FromArgb(51, 51, 51);
        lblAddress.Location = new Point(55, 386);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(110, 30);
        lblAddress.TabIndex = 16;
        lblAddress.Text = "详细地址 *：";
        lblAddress.TextAlign = ContentAlignment.MiddleRight;
        // 
        // txtAddress
        // 
        txtAddress.Font = new Font("微软雅黑", 10.5F);
        txtAddress.Location = new Point(178, 382);
        txtAddress.Margin = new Padding(4, 5, 4, 5);
        txtAddress.MinimumSize = new Size(1, 16);
        txtAddress.Name = "txtAddress";
        txtAddress.Padding = new Padding(8, 5, 8, 5);
        txtAddress.ShowText = false;
        txtAddress.Size = new Size(260, 34);
        txtAddress.TabIndex = 17;
        txtAddress.TextAlignment = ContentAlignment.MiddleLeft;
        txtAddress.Watermark = "楼栋、门牌号或宿舍号";
        // 
        // lblHint
        // 
        lblHint.Font = new Font("微软雅黑", 9F);
        lblHint.ForeColor = Color.FromArgb(117, 117, 117);
        lblHint.Location = new Point(138, 422);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(330, 24);
        lblHint.TabIndex = 18;
        lblHint.Text = "保存后外卖点餐会自动带出该地址";
        // 
        // btnRegister
        // 
        btnRegister.Cursor = Cursors.Hand;
        btnRegister.FillColor = Color.FromArgb(255, 109, 0);
        btnRegister.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
        btnRegister.ForeColor = Color.White;
        btnRegister.Location = new Point(105, 470);
        btnRegister.MinimumSize = new Size(1, 1);
        btnRegister.Name = "btnRegister";
        btnRegister.Radius = 10;
        btnRegister.RectColor = Color.FromArgb(255, 109, 0);
        btnRegister.Size = new Size(135, 42);
        btnRegister.TabIndex = 19;
        btnRegister.Text = "注册";
        // 
        // btnCancel
        // 
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.FillColor = Color.FromArgb(117, 117, 117);
        btnCancel.Font = new Font("微软雅黑", 11F);
        btnCancel.ForeColor = Color.White;
        btnCancel.Location = new Point(260, 470);
        btnCancel.MinimumSize = new Size(1, 1);
        btnCancel.Name = "btnCancel";
        btnCancel.Radius = 10;
        btnCancel.RectColor = Color.FromArgb(117, 117, 117);
        btnCancel.Size = new Size(135, 42);
        btnCancel.TabIndex = 20;
        btnCancel.Text = "取消";
        // 
        // panelMain
        // 
        panelMain.Controls.Add(lblTitle);
        panelMain.Controls.Add(lblSubTitle);
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
        panelMain.Controls.Add(lblRegion);
        panelMain.Controls.Add(cmbProvince);
        panelMain.Controls.Add(cmbCity);
        panelMain.Controls.Add(cmbDistrict);
        panelMain.Controls.Add(lblAddress);
        panelMain.Controls.Add(txtAddress);
        panelMain.Controls.Add(lblHint);
        panelMain.Controls.Add(btnRegister);
        panelMain.Controls.Add(btnCancel);
        panelMain.Dock = DockStyle.Fill;
        panelMain.FillColor = Color.FromArgb(255, 252, 248);
        panelMain.Location = new Point(0, 0);
        panelMain.Name = "panelMain";
        panelMain.RectColor = Color.FromArgb(255, 224, 178);
        panelMain.Size = new Size(500, 540);
        panelMain.TabIndex = 0;
        panelMain.Text = null;
        panelMain.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // RegisterForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(255, 252, 248);
        ClientSize = new Size(500, 540);
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
    private Sunny.UI.UILabel lblSubTitle;
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
    private Sunny.UI.UILabel lblRegion;
    private ComboBox cmbProvince;
    private ComboBox cmbCity;
    private ComboBox cmbDistrict;
    private Sunny.UI.UILabel lblAddress;
    private Sunny.UI.UITextBox txtAddress;
    private Sunny.UI.UILabel lblHint;
    private Sunny.UI.UIButton btnRegister;
    private Sunny.UI.UIButton btnCancel;
    private Sunny.UI.UIPanel panelMain;
}
