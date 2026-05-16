using ClientCustomer.Models;

namespace ClientCustomer;

public partial class RegisterForm : Form
{
    public string RegisteredUsername { get; private set; } = string.Empty;

    public RegisterForm()
    {
        InitializeComponent();
        BindEvents();
    }

    private void BindEvents()
    {
        btnRegister.Click += BtnRegister_Click;
        btnCancel.Click += BtnCancel_Click;
    }

    private async void BtnRegister_Click(object? sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;
        var confirmPassword = txtConfirmPassword.Text;
        var realName = txtRealName.Text.Trim();
        var phone = txtPhone.Text.Trim();
        var address = txtAddress.Text.Trim();

        if (string.IsNullOrEmpty(username))
        {
            MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        if (username.Length < 3 || username.Length > 20)
        {
            MessageBox.Show("用户名长度应为3-20个字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return;
        }

        if (password.Length < 6)
        {
            MessageBox.Show("密码长度至少6个字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return;
        }

        if (password != confirmPassword)
        {
            MessageBox.Show("两次输入的密码不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmPassword.Focus();
            return;
        }

        btnRegister.Enabled = false;
        btnRegister.Text = "注册中...";

        try
        {
            var request = new RegisterRequest
            {
                Username = username,
                Password = password,
                RealName = string.IsNullOrEmpty(realName) ? null : realName,
                Phone = string.IsNullOrEmpty(phone) ? null : phone,
                Address = string.IsNullOrEmpty(address) ? null : address
            };

            var result = await ApiHelper.RegisterAsync(request);

            if (result.Success)
            {
                MessageBox.Show("注册成功！请登录", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RegisteredUsername = username;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(result.Message, "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("注册失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnRegister.Enabled = true;
            btnRegister.Text = "注册";
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
