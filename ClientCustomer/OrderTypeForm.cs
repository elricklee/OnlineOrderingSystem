using ClientCustomer.Models;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClientCustomer
{
    public partial class OrderTypeForm : Form
    {
        private static readonly Regex PhoneRegex = new("^1[3-9]\\d{9}$", RegexOptions.Compiled);
        private List<DiningTableDto> _availableTables = new();
        private List<DeliveryZoneDto> _deliveryZones = new();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OrderSession Session { get; private set; } = new();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OrderType => Session.OrderType;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? TableNumber => Session.TableNumber;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? DeliveryAddress => Session.FullDeliveryAddress;

        public OrderTypeForm()
        {
            InitializeComponent();
            ConfigureFixedControls();
            SetupEventHandlers();
            Load += OrderTypeForm_Load;
        }

        private void ConfigureFixedControls()
        {
            Text = "选择点餐模式";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(820, 700);
            MinimumSize = new Size(820, 700);

            lblAddress.Text = "配送区域 *：";
            txtAddress.Location = new Point(286, 516);
            txtAddress.Size = new Size(400, 34);
            txtAddress.MaxLength = 240;

            btnConfirm.Location = new Point(320, 618);
            btnConfirm.Size = new Size(180, 48);
            btnConfirm.Text = "进入点餐";

            SetDeliveryControlsEnabled(false);
        }

        private async void OrderTypeForm_Load(object? sender, EventArgs e)
        {
            await LoadInitialOptionsAsync();
            SelectDineIn();
        }

        private void SetupEventHandlers()
        {
            panelDineIn.Click += (_, _) => SelectDineIn();
            foreach (Control control in panelDineIn.Controls)
            {
                control.Click += (_, _) => SelectDineIn();
            }

            panelDelivery.Click += (_, _) => SelectDelivery();
            foreach (Control control in panelDelivery.Controls)
            {
                control.Click += (_, _) => SelectDelivery();
            }

            btnConfirm.Click += BtnConfirm_Click;
            cmbProvince.SelectedIndexChanged += ProvinceChanged;
            cmbCity.SelectedIndexChanged += CityChanged;
            cmbDistrict.SelectedIndexChanged += DistrictChanged;
            cmbDiningTable.SelectedIndexChanged += DiningTableChanged;
            nudDinerCount.ValueChanged += NudDinerCount_ValueChanged;
            btnRefreshTables.Click += BtnRefreshTables_Click;
        }

        private async Task LoadInitialOptionsAsync()
        {
            btnConfirm.Enabled = false;
            btnConfirm.Text = "加载中...";

            try
            {
                var tablesTask = ApiHelper.GetAvailableTablesAsync();
                var zonesTask = ApiHelper.GetDeliveryZonesAsync();
                await Task.WhenAll(tablesTask, zonesTask);

                _availableTables = tablesTask.Result;
                _deliveryZones = zonesTask.Result
                    .OrderBy(zone => zone.SortOrder)
                    .ThenBy(zone => zone.DisplayName)
                    .ToList();

                BindDiningTables();
                BindProvinces();
                ApplyCurrentUserDeliveryDefaults();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "初始化点餐信息失败：" + ex.Message,
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                btnConfirm.Enabled = true;
                btnConfirm.Text = "进入点餐";
            }
        }

        private async void BtnRefreshTables_Click(object? sender, EventArgs e)
        {
            btnRefreshTables.Enabled = false;
            btnRefreshTables.Text = "刷新中...";

            try
            {
                _availableTables = await ApiHelper.GetAvailableTablesAsync();
                BindDiningTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("刷新餐桌列表失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRefreshTables.Enabled = true;
                btnRefreshTables.Text = "🔄 刷新";
            }
        }

        private void BindDiningTables()
        {
            cmbDiningTable.Items.Clear();
            foreach (var table in _availableTables.Where(table => table.IsEnabled))
            {
                var remaining = table.RemainingSeats;
                cmbDiningTable.Items.Add(new ComboOption<DiningTableDto>(
                    $"{table.TableNumber} · {table.SeatCount}座(余{remaining})",
                    table));
            }

            if (cmbDiningTable.Items.Count > 0)
            {
                cmbDiningTable.SelectedIndex = 0;
            }

            UpdateDiningTableHint();
        }

        private void DiningTableChanged(object? sender, EventArgs e)
        {
            UpdateDiningTableHint();
        }

        private void NudDinerCount_ValueChanged(object? sender, EventArgs e)
        {
            UpdateDiningTableHint();
        }

        private void UpdateDiningTableHint()
        {
            if (cmbDiningTable.SelectedItem is ComboOption<DiningTableDto> option)
            {
                var table = option.Value;
                var remaining = table.RemainingSeats;
                var dinerCount = (int)nudDinerCount.Value;

                if (dinerCount > remaining)
                {
                    lblDiningTableHint.ForeColor = Color.Red;
                    lblDiningTableHint.Text = $"⚠ 剩余 {remaining} 座，不够 {dinerCount} 人！";
                }
                else
                {
                    lblDiningTableHint.ForeColor = Color.FromArgb(46, 125, 50);
                    lblDiningTableHint.Text = $"✓ 剩余 {remaining} 座，可容纳 {dinerCount} 人";
                }
                return;
            }

            lblDiningTableHint.ForeColor = Color.Gray;
            lblDiningTableHint.Text = "当前没有空闲餐桌，请联系管理员";
        }

        private void BindProvinces()
        {
            BindComboBox(
                cmbProvince,
                _deliveryZones.Select(zone => zone.Province).Distinct().OrderBy(item => item).ToList());
        }

        private void ProvinceChanged(object? sender, EventArgs e)
        {
            var province = cmbProvince.SelectedItem?.ToString();
            var cities = _deliveryZones
                .Where(zone => zone.Province == province)
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
            UpdateSelectedDeliveryZone();
        }

        private void DistrictChanged(object? sender, EventArgs e)
        {
            UpdateSelectedDeliveryZone();
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

        private void ApplyCurrentUserDeliveryDefaults()
        {
            var currentUser = Program.CurrentUser;
            if (currentUser == null)
            {
                return;
            }

            txtCustomerPhone.Text = currentUser.Phone ?? string.Empty;

            var address = currentUser.Address?.Trim();
            if (string.IsNullOrWhiteSpace(address))
            {
                return;
            }

            var zone = FindZoneFromAddress(address);
            if (zone == null)
            {
                txtAddress.Text = string.Empty;
                return;
            }

            SelectComboText(cmbProvince, zone.Province);
            SelectComboText(cmbCity, zone.City);
            SelectComboText(cmbDistrict, zone.District);
            txtAddress.Text = ExtractAddressDetail(address, zone);
            UpdateSelectedDeliveryZone();
        }

        private DeliveryZoneDto? FindZoneFromAddress(string address)
        {
            return _deliveryZones
                .OrderByDescending(zone => $"{zone.Province} {zone.City} {zone.District}".Length)
                .FirstOrDefault(zone =>
                    address.StartsWith($"{zone.Province} {zone.City} {zone.District}", StringComparison.OrdinalIgnoreCase) ||
                    address.StartsWith(zone.DisplayName, StringComparison.OrdinalIgnoreCase) ||
                    address.StartsWith($"{zone.Province}{zone.City}{zone.District}", StringComparison.OrdinalIgnoreCase));
        }

        private static string ExtractAddressDetail(string address, DeliveryZoneDto zone)
        {
            var prefixes = new[]
            {
                $"{zone.Province} {zone.City} {zone.District}",
                zone.DisplayName,
                $"{zone.Province}{zone.City}{zone.District}"
            };

            foreach (var prefix in prefixes.Where(prefix => !string.IsNullOrWhiteSpace(prefix)))
            {
                if (address.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    return address[prefix.Length..].Trim();
                }
            }

            return address;
        }

        private static void SelectComboText(ComboBox comboBox, string text)
        {
            var index = comboBox.Items.IndexOf(text);
            if (index >= 0)
            {
                comboBox.SelectedIndex = index;
            }
        }

        private void UpdateSelectedDeliveryZone()
        {
            var selectedZone = _deliveryZones.FirstOrDefault(zone =>
                zone.Province == cmbProvince.Text &&
                zone.City == cmbCity.Text &&
                zone.District == cmbDistrict.Text);

            if (selectedZone == null)
            {
                Session.DeliveryZoneId = null;
                Session.DeliveryRegion = null;
                Session.DeliveryFee = 0m;
                return;
            }

            Session.DeliveryZoneId = selectedZone.Id;
            Session.DeliveryRegion = selectedZone.DisplayName;
            Session.DeliveryFee = selectedZone.DeliveryFee;
        }

        private void SelectDineIn()
        {
            Session.OrderType = "DineIn";

            panelDineIn.BackColor = Color.FromArgb(255, 243, 224);
            panelDelivery.BackColor = Color.White;
            panelDineIn.BorderStyle = BorderStyle.FixedSingle;
            panelDelivery.BorderStyle = BorderStyle.None;

            cmbDiningTable.Enabled = true;
            cmbDiningTable.Focus();
            SetDeliveryControlsEnabled(false);
        }

        private void SelectDelivery()
        {
            Session.OrderType = "Delivery";

            panelDelivery.BackColor = Color.FromArgb(227, 242, 253);
            panelDineIn.BackColor = Color.White;
            panelDelivery.BorderStyle = BorderStyle.FixedSingle;
            panelDineIn.BorderStyle = BorderStyle.None;

            cmbDiningTable.Enabled = false;
            SetDeliveryControlsEnabled(true);
            cmbProvince.Focus();
        }

        private void SetDeliveryControlsEnabled(bool enabled)
        {
            lblAddress.Enabled = enabled;
            //lblDeliveryRegionHint.Enabled = enabled;
            lblAddressDetail.Enabled = enabled;
            lblCustomerPhone.Enabled = enabled;
            cmbProvince.Enabled = enabled;
            cmbCity.Enabled = enabled;
            cmbDistrict.Enabled = enabled;
            txtAddress.Enabled = enabled;
            txtCustomerPhone.Enabled = enabled;
        }

        private void BtnConfirm_Click(object? sender, EventArgs e)
        {
            if (Session.OrderType == "DineIn")
            {
                if (cmbDiningTable.SelectedItem is not ComboOption<DiningTableDto> option)
                {
                    MessageBox.Show("请先选择可用餐桌。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dinerCount = (int)nudDinerCount.Value;
                if (dinerCount > option.Value.RemainingSeats)
                {
                    MessageBox.Show($"该餐桌剩余 {option.Value.RemainingSeats} 座，无法容纳 {dinerCount} 人。\n请减少人数或选择其他餐桌。", "座位不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Session = new OrderSession
                {
                    OrderType = "DineIn",
                    DiningTableId = option.Value.Id,
                    TableNumber = option.Value.TableNumber,
                    DinerCount = dinerCount,
                    DeliveryFee = 0m
                };
            }
            else
            {
                UpdateSelectedDeliveryZone();
                var phone = NormalizeText(txtCustomerPhone.Text);
                var address = NormalizeText(txtAddress.Text);

                if (Session.DeliveryZoneId == null)
                {
                    MessageBox.Show("请先选择配送区域。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("请填写详细配送地址。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(phone))
                {
                    MessageBox.Show("请填写手机号。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerPhone.Focus();
                    return;
                }

                if (!PhoneRegex.IsMatch(phone))
                {
                    MessageBox.Show("手机号格式不正确，请输入11位大陆手机号。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerPhone.Focus();
                    return;
                }

                Session = new OrderSession
                {
                    OrderType = "Delivery",
                    Phone = phone,
                    DeliveryZoneId = Session.DeliveryZoneId,
                    DeliveryRegion = Session.DeliveryRegion,
                    DeliveryFee = Session.DeliveryFee,
                    DeliveryAddressDetail = address
                };
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private static string? NormalizeText(string? value)
        {
            var text = value?.Trim();
            return string.IsNullOrWhiteSpace(text) ? null : text;
        }

        private void lblDineInDesc_Click(object sender, EventArgs e)
        {

        }

        private void lblDeliveryTitle_Click(object sender, EventArgs e)
        {

        }

        private sealed class ComboOption<T>
        {
            public ComboOption(string text, T value)
            {
                Text = text;
                Value = value;
            }

            public string Text { get; }

            public T Value { get; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
