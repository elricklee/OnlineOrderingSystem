using ClientCustomer.Models;
using System.Text.RegularExpressions;

namespace ClientCustomer;

public partial class RegisterForm : Form
{
    private static readonly Regex PhoneRegex = new("^1[3-9]\\d{9}$", RegexOptions.Compiled);
    private readonly List<DeliveryZoneDto> _deliveryZones = new();

    public string RegisteredUsername { get; private set; } = string.Empty;

    public RegisterForm()
    {
        InitializeComponent();
        BindEvents();
    }

    private void BindEvents()
    {
        Load += RegisterForm_Load;
        btnRegister.Click += BtnRegister_Click;
        btnCancel.Click += BtnCancel_Click;
        cmbProvince.SelectedIndexChanged += ProvinceChanged;
        cmbCity.SelectedIndexChanged += CityChanged;
        cmbDistrict.SelectedIndexChanged += DistrictChanged;
    }

    private async void RegisterForm_Load(object? sender, EventArgs e)
    {
        await LoadDeliveryZonesAsync();
    }

    private async Task LoadDeliveryZonesAsync()
    {
        try
        {
            lblHint.Text = "正在加载配送区域...";
            lblHint.ForeColor = Color.FromArgb(117, 117, 117);

            var zones = await ApiHelper.GetDeliveryZonesAsync();
            _deliveryZones.Clear();
            _deliveryZones.AddRange(zones.OrderBy(zone => zone.SortOrder).ThenBy(zone => zone.DisplayName));

            BindProvinces();
            lblHint.Text = "保存后外卖点餐会自动带出该地址";
        }
        catch (Exception ex)
        {
            lblHint.ForeColor = Color.FromArgb(211, 47, 47);
            lblHint.Text = "配送区域加载失败：" + ex.Message;
        }
    }

    private void BindProvinces()
    {
        BindComboBox(
            cmbProvince,
            _deliveryZones.Select(zone => zone.Province).Distinct().OrderBy(item => item).ToList());
    }

    private void ProvinceChanged(object? sender, EventArgs e)
    {
        var cities = _deliveryZones
            .Where(zone => zone.Province == cmbProvince.Text)
            .Select(zone => zone.City)
            .Distinct()
            .OrderBy(item => item)
            .ToList();

        BindComboBox(cmbCity, cities);
        UpdateDistrictOptions();
    }

    private void CityChanged(object? sender, EventArgs e)
    {
        UpdateDistrictOptions();
    }

    private void UpdateDistrictOptions()
    {
        var districts = _deliveryZones
            .Where(zone => zone.Province == cmbProvince.Text && zone.City == cmbCity.Text)
            .Select(zone => zone.District)
            .Distinct()
            .OrderBy(item => item)
            .ToList();

        BindComboBox(cmbDistrict, districts);
    }

    private void DistrictChanged(object? sender, EventArgs e)
    {
    }

    private static void BindComboBox(ComboBox comboBox, List<string> items)
    {
        comboBox.Items.Clear();
        foreach (var item in items)
        {
            comboBox.Items.Add(item);
        }

        if (comboBox.Items.Count > 0)
        {
            comboBox.SelectedIndex = 0;
        }
    }

    private async void BtnRegister_Click(object? sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;
        var confirmPassword = txtConfirmPassword.Text;
        var realName = txtRealName.Text.Trim();
        var phone = txtPhone.Text.Trim();
        var detailAddress = txtAddress.Text.Trim();
        var fullAddress = BuildFullAddress(detailAddress);

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

        if (string.IsNullOrEmpty(realName))
        {
            MessageBox.Show("请输入真实姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtRealName.Focus();
            return;
        }

        if (string.IsNullOrEmpty(phone))
        {
            MessageBox.Show("请输入手机号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPhone.Focus();
            return;
        }

        if (!PhoneRegex.IsMatch(phone))
        {
            MessageBox.Show("手机号格式不正确，请输入11位大陆手机号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPhone.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(fullAddress))
        {
            MessageBox.Show("请选择常用配送区域并填写详细地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtAddress.Focus();
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
                RealName = realName,
                Phone = phone,
                Address = fullAddress
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

    private string? BuildFullAddress(string detailAddress)
    {
        if (string.IsNullOrWhiteSpace(cmbProvince.Text) ||
            string.IsNullOrWhiteSpace(cmbCity.Text) ||
            string.IsNullOrWhiteSpace(cmbDistrict.Text) ||
            string.IsNullOrWhiteSpace(detailAddress))
        {
            return null;
        }

        return string.Join(
            " ",
            new[] { cmbProvince.Text, cmbCity.Text, cmbDistrict.Text, detailAddress.Trim() });
    }
}
