using ClientCustomer.Models;

namespace ClientCustomer;

public partial class LoginForm : Form
{
    public UserDto? LoggedInUser { get; private set; }
    public bool IsGuestMode { get; private set; }

    public LoginForm()
    {
        InitializeComponent();
        BindEvents();
    }

    private void BindEvents()
    {
        btnLogin.Click += BtnLogin_Click;
        btnRegister.Click += BtnRegister_Click;
        btnGuest.Click += BtnGuest_Click;
    }

    private async void BtnLogin_Click(object? sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;

        if (string.IsNullOrEmpty(username))
        {
            MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnLogin.Enabled = false;
        btnLogin.Text = "登录中...";

        try
        {
            var result = await ApiHelper.LoginAsync(username, password);

            if (result.Success && result.User != null)
            {
                LoggedInUser = result.User;
                IsGuestMode = false;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(result.Message, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("登录失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnLogin.Enabled = true;
            btnLogin.Text = "登录";
        }
    }

    private void BtnRegister_Click(object? sender, EventArgs e)
    {
        using var registerForm = new RegisterForm();
        if (registerForm.ShowDialog() == DialogResult.OK)
        {
            txtUsername.Text = registerForm.RegisteredUsername;
            txtPassword.Focus();
        }
    }

    private void BtnGuest_Click(object? sender, EventArgs e)
    {
        IsGuestMode = true;
        LoggedInUser = null;
        DialogResult = DialogResult.OK;
        Close();
    }
}
