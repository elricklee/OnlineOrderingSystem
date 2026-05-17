using ClientCustomer.Models;

namespace ClientCustomer;

public partial class ForgotPasswordForm : Form
{
    public ForgotPasswordForm()
    {
        InitializeComponent();
        btnSubmit.Click += BtnSubmit_Click;
        btnCancel.Click += (_, _) => Close();
    }

    private async void BtnSubmit_Click(object? sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var realName = txtRealName.Text.Trim();
        var newPassword = txtNewPassword.Text;
        var confirmPassword = txtConfirmPassword.Text;

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(realName) ||
            string.IsNullOrWhiteSpace(newPassword) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            MessageBox.Show("请完整填写用户名、真实姓名和新密码。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (newPassword.Length < 6)
        {
            MessageBox.Show("新密码长度至少 6 位。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (newPassword != confirmPassword)
        {
            MessageBox.Show("两次输入的新密码不一致。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnSubmit.Enabled = false;
        btnSubmit.Text = "校验中...";

        try
        {
            var result = await ApiHelper.ForgotPasswordAsync(new ForgotPasswordRequest
            {
                Username = username,
                RealName = realName,
                NewPassword = newPassword
            });

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "重设失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("密码已重设成功，请返回登录。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("忘记密码操作失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSubmit.Enabled = true;
            btnSubmit.Text = "重设密码";
        }
    }
}
