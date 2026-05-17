using ClientCustomer.Models;

namespace ClientCustomer;

public partial class ChangePasswordForm : Form
{
    public ChangePasswordForm()
    {
        InitializeComponent();
        BindEvents();
        PrefillCurrentUser();
    }

    private void BindEvents()
    {
        btnSubmit.Click += BtnSubmit_Click;
        btnCancel.Click += (_, _) => Close();
    }

    private void PrefillCurrentUser()
    {
        if (Program.CurrentUser == null)
        {
            return;
        }

        txtUsername.Text = Program.CurrentUser.Username;
        txtUsername.ReadOnly = true;
    }

    private async void BtnSubmit_Click(object? sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var oldPassword = txtOldPassword.Text;
        var newPassword = txtNewPassword.Text;
        var confirmPassword = txtConfirmPassword.Text;

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(oldPassword) ||
            string.IsNullOrWhiteSpace(newPassword) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            MessageBox.Show("请完整填写用户名、原密码和新密码。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        btnSubmit.Text = "提交中...";

        try
        {
            var result = await ApiHelper.ChangePasswordAsync(new ChangePasswordRequest
            {
                Username = username,
                OldPassword = oldPassword,
                NewPassword = newPassword
            });

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("密码修改成功，请使用新密码重新登录。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("修改密码失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSubmit.Enabled = true;
            btnSubmit.Text = "确认修改";
        }
    }
}
