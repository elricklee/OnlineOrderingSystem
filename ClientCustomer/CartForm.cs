using ClientCustomer.Models;
using Sunny.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ClientCustomer
{
    public partial class CartForm : UIForm
    {
        private readonly List<CartItem> _cart;
        private readonly OrderSession _session;
        private readonly List<DeliveryZoneDto> _deliveryZones = new();
        private bool _eventsBound;

        public CartForm()
            : this(new List<CartItem>(), new OrderSession { OrderType = "Delivery" })
        {
        }

        public CartForm(List<CartItem> cart, OrderSession session)
        {
            InitializeComponent();

            _cart = cart;
            _session = session;

            ConfigureFixedControls();
            Load += CartForm_Load;
            LoadCart();
        }

        public CartForm(List<CartItem> cart, string orderType, string? tableNumber, string? deliveryAddress)
            : this(cart, new OrderSession
            {
                OrderType = orderType,
                TableNumber = tableNumber,
                DeliveryAddressDetail = deliveryAddress
            })
        {
        }

        private void ConfigureFixedControls()
        {
            Text = "确认订单";

            if (_session.OrderType == "Delivery")
            {
                lblCurrentTable.Visible = false;
                lblDeliveryRegion.Visible = true;
                cmbDeliveryProvince.Visible = true;
                cmbDeliveryCity.Visible = true;
                cmbDeliveryDistrict.Visible = true;
                lblAddressDetailEditor.Visible = true;
                txtAddressDetail.Visible = true;
                lblCustomerPhoneEditor.Visible = true;
                txtCustomerPhone.Visible = true;
            }
            else
            {
                mainLayout.RowStyles[1].Height = 80F;
                lblCurrentTable.Visible = true;
                lblDeliveryRegion.Visible = false;
                cmbDeliveryProvince.Visible = false;
                cmbDeliveryCity.Visible = false;
                cmbDeliveryDistrict.Visible = false;
                lblAddressDetailEditor.Visible = false;
                txtAddressDetail.Visible = false;
                lblCustomerPhoneEditor.Visible = false;
                txtCustomerPhone.Visible = false;
            }

            BindEventsOnce();
        }

        private void BindEventsOnce()
        {
            if (_eventsBound)
            {
                return;
            }

            _eventsBound = true;
            btnDecreaseQuantity.Click += (_, _) => ChangeSelectedQuantity(-1);
            btnIncreaseQuantity.Click += (_, _) => ChangeSelectedQuantity(1);
            btnRemoveCartItem.Click += (_, _) => RemoveSelectedItem();
            cmbDeliveryProvince.SelectedIndexChanged += ProvinceChanged;
            cmbDeliveryCity.SelectedIndexChanged += CityChanged;
            cmbDeliveryDistrict.SelectedIndexChanged += DistrictChanged;
        }

        private async void CartForm_Load(object? sender, EventArgs e)
        {
            lblCurrentTable.Text = $"当前桌号：{_session.TableNumber ?? "未选择"}";
            txtAddressDetail.Text = _session.DeliveryAddressDetail ?? string.Empty;
            txtCustomerPhone.Text = _session.Phone ?? string.Empty;

            if (_session.OrderType == "Delivery")
            {
                await LoadDeliveryZonesAsync();
            }
        }

        private async Task LoadDeliveryZonesAsync()
        {
            try
            {
                var zones = await ApiHelper.GetDeliveryZonesAsync();
                _deliveryZones.Clear();
                _deliveryZones.AddRange(zones.OrderBy(zone => zone.SortOrder).ThenBy(zone => zone.DisplayName));
                BindProvinces();
                UpdateTotals();
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError($"加载配送区域失败：{ex.Message}");
            }
        }

        private void BindProvinces()
        {
            BindComboItems(cmbDeliveryProvince, _deliveryZones.Select(zone => zone.Province).Distinct().OrderBy(item => item).ToList());
        }

        private void ProvinceChanged(object? sender, EventArgs e)
        {
            var cities = _deliveryZones
                .Where(zone => zone.Province == cmbDeliveryProvince.Text)
                .Select(zone => zone.City)
                .Distinct()
                .OrderBy(item => item)
                .ToList();

            BindComboItems(cmbDeliveryCity, cities);
            UpdateDistricts();
        }

        private void CityChanged(object? sender, EventArgs e)
        {
            UpdateDistricts();
        }

        private void UpdateDistricts()
        {
            var districts = _deliveryZones
                .Where(zone => zone.Province == cmbDeliveryProvince.Text && zone.City == cmbDeliveryCity.Text)
                .Select(zone => zone.District)
                .Distinct()
                .OrderBy(item => item)
                .ToList();

            BindComboItems(cmbDeliveryDistrict, districts);
            UpdateSelectedDeliveryZone();
        }

        private void DistrictChanged(object? sender, EventArgs e)
        {
            UpdateSelectedDeliveryZone();
        }

        private static void BindComboItems(UIComboBox comboBox, List<string> items)
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

        private void UpdateSelectedDeliveryZone()
        {
            var selectedZone = _deliveryZones.FirstOrDefault(zone =>
                zone.Province == cmbDeliveryProvince.Text &&
                zone.City == cmbDeliveryCity.Text &&
                zone.District == cmbDeliveryDistrict.Text);

            if (selectedZone == null)
            {
                _session.DeliveryZoneId = null;
                _session.DeliveryRegion = null;
                _session.DeliveryFee = 0m;
            }
            else
            {
                _session.DeliveryZoneId = selectedZone.Id;
                _session.DeliveryRegion = selectedZone.DisplayName;
                _session.DeliveryFee = selectedZone.DeliveryFee;
            }

            UpdateTotals();
        }

        private void LoadCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart
                .Select(item => new CartGridRow
                {
                    DishName = item.DishName,
                    UnitPrice = $"¥{item.Price:F2}",
                    Quantity = item.Quantity,
                    Subtotal = $"¥{item.Subtotal:F2}"
                })
                .ToList();

            SetCartGridHeaders();
            UpdateTotals();
        }

        private void SetCartGridHeaders()
        {
            var dishNameColumn = dgvCart.Columns["DishName"];
            if (dishNameColumn != null)
            {
                dishNameColumn.HeaderText = "菜品名称";
                dishNameColumn.FillWeight = 40;
            }

            var unitPriceColumn = dgvCart.Columns["UnitPrice"];
            if (unitPriceColumn != null)
            {
                unitPriceColumn.HeaderText = "单价";
                unitPriceColumn.FillWeight = 18;
            }

            var quantityColumn = dgvCart.Columns["Quantity"];
            if (quantityColumn != null)
            {
                quantityColumn.HeaderText = "数量";
                quantityColumn.FillWeight = 18;
            }

            var subtotalColumn = dgvCart.Columns["Subtotal"];
            if (subtotalColumn != null)
            {
                subtotalColumn.HeaderText = "小计";
                subtotalColumn.FillWeight = 24;
            }
        }

        private void UpdateTotals()
        {
            var subtotal = _cart.Sum(cartItem => cartItem.Subtotal);
            var deliveryFee = _session.OrderType == "Delivery" ? _session.DeliveryFee : 0m;
            var total = subtotal + deliveryFee;

            lblSubtotal.Text = $"¥{subtotal:F2}";
            lblDeliveryFee.Text = _session.OrderType == "Delivery"
                ? (_session.DeliveryZoneId == null ? "待选择" : $"¥{deliveryFee:F2}")
                : "¥0.00";
            lblDeliveryFee.Visible = _session.OrderType == "Delivery";
            lblDeliveryFeeLabel.Visible = _session.OrderType == "Delivery";
            lblTotal.Text = $"¥{total:F2}";
        }

        private void ChangeSelectedQuantity(int delta)
        {
            if (dgvCart.CurrentRow == null || dgvCart.CurrentRow.Index < 0 || dgvCart.CurrentRow.Index >= _cart.Count)
            {
                UIMessageTip.ShowWarning("请先选中一个菜品");
                return;
            }

            var item = _cart[dgvCart.CurrentRow.Index];
            item.Quantity += delta;

            if (item.Quantity <= 0)
            {
                _cart.RemoveAt(dgvCart.CurrentRow.Index);
            }

            LoadCart();
        }

        private void RemoveSelectedItem()
        {
            if (dgvCart.CurrentRow == null || dgvCart.CurrentRow.Index < 0 || dgvCart.CurrentRow.Index >= _cart.Count)
            {
                UIMessageTip.ShowWarning("请先选中一个菜品");
                return;
            }

            _cart.RemoveAt(dgvCart.CurrentRow.Index);
            LoadCart();
        }

        private void BtnClearCart_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                return;
            }

            var result = MessageBox.Show(
                "确定要清空购物车吗？",
                "确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _cart.Clear();
                LoadCart();
            }
        }

        private async void BtnSubmitOrder_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                UIMessageTip.ShowWarning("购物车为空");
                return;
            }

            if (!TryCollectSessionData(out var errorMessage))
            {
                UIMessageTip.ShowWarning(errorMessage);
                return;
            }

            btnSubmitOrder.Enabled = false;
            btnSubmitOrder.Text = "提交中...";

            try
            {
                var orderCreate = new OrderCreateDto
                {
                    UserId = Program.CurrentUser?.Id,
                    CustomerName = _session.OrderType == "DineIn" ? $"桌号{_session.TableNumber}" : "外卖顾客",
                    Phone = _session.Phone ?? string.Empty,
                    OrderType = _session.OrderType,
                    TableNumber = _session.TableNumber,
                    DiningTableId = _session.DiningTableId,
                    DinerCount = _session.DinerCount,
                    Address = _session.DeliveryAddressDetail,
                    DeliveryZoneId = _session.DeliveryZoneId,
                    DeliveryRegion = _session.DeliveryRegion,
                    Note = txtNote.Text.Trim(),
                    DeliveryFee = _session.OrderType == "Delivery" ? _session.DeliveryFee : 0m,
                    OrderItems = _cart.Select(item => new OrderItemDto
                    {
                        DishId = item.DishId,
                        Quantity = item.Quantity
                    }).ToList()
                };

                var orderResult = await ApiHelper.CreateOrderAsync(orderCreate);
                _cart.Clear();

                MessageBox.Show(
                    $"订单提交成功！\n\n订单编号：{orderResult.Id}\n订单状态：{GetStatusText(orderResult.Status)}\n总金额：¥{orderResult.TotalAmount:F2}",
                    "下单成功",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"订单提交失败：{ex.Message}",
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSubmitOrder.Enabled = true;
                btnSubmitOrder.Text = "提交订单";
            }
        }

        private bool TryCollectSessionData(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (_session.OrderType == "DineIn")
            {
                if (_session.DiningTableId == null)
                {
                    errorMessage = "当前堂食订单没有可用餐桌，请返回重新选择。";
                    return false;
                }

                return true;
            }

            _session.Phone = NormalizeText(txtCustomerPhone.Text);
            _session.DeliveryAddressDetail = NormalizeText(txtAddressDetail.Text);
            UpdateSelectedDeliveryZone();

            if (_session.DeliveryZoneId == null)
            {
                errorMessage = "请先选择配送区域。";
                return false;
            }

            if (string.IsNullOrWhiteSpace(_session.DeliveryAddressDetail))
            {
                errorMessage = "请填写详细配送地址后再提交订单。";
                return false;
            }

            return true;
        }

        private static string? NormalizeText(string? value)
        {
            var text = value?.Trim();
            return string.IsNullOrWhiteSpace(text) ? null : text;
        }

        private static string GetStatusText(string status)
        {
            return status switch
            {
                "Pending" => "待处理",
                "Confirmed" => "已确认",
                "Preparing" => "制作中",
                "Ready" => "已出餐",
                "Delivering" => "配送中",
                "Completed" => "已完成",
                "Cancelled" => "已取消",
                _ => status
            };
        }

        private sealed class CartGridRow
        {
            public string DishName { get; set; } = string.Empty;
            public string UnitPrice { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public string Subtotal { get; set; } = string.Empty;
        }
    }
}
