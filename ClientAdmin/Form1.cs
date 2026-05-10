using ClientAdmin.Helpers;
using ClientAdmin.Models;
using Sunny.UI;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientAdmin
{
    public partial class Form1 : UIForm
    {
        private int? selectedDishId = null;
        private int? selectedOrderId = null;

        public Form1()
        {
            InitializeComponent();

            Text = "珞珈线上点餐系统-管理员端";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1350, 850);
            MinimumSize = new Size(1000, 650);

            InitDishGrid();
            InitOrderManagement();
        }

        private void InitDishGrid()
        {
            dgvDishes.ReadOnly = true;
            dgvDishes.AllowUserToAddRows = false;
            dgvDishes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDishes.MultiSelect = false;
            dgvDishes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async Task LoadDishesAsync()
        {
            try
            {
                var dishes = await ApiHelper.GetListAsync<DishDto>("api/Dishes");

                dgvDishes.DataSource = null;
                dgvDishes.DataSource = dishes;

                if (dgvDishes.Columns["Id"] != null)
                    dgvDishes.Columns["Id"].HeaderText = "编号";

                if (dgvDishes.Columns["Name"] != null)
                    dgvDishes.Columns["Name"].HeaderText = "菜品名称";

                if (dgvDishes.Columns["Category"] != null)
                    dgvDishes.Columns["Category"].HeaderText = "分类";

                if (dgvDishes.Columns["Price"] != null)
                    dgvDishes.Columns["Price"].HeaderText = "价格";
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载菜品失败：" + ex.Message);
            }
        }

        private async void btnLoadDishes_Click(object sender, EventArgs e)
        {
            await LoadDishesAsync();
        }

        private async void btnAddDish_Click(object sender, EventArgs e)
        {
            if (!ValidateDishInput(out decimal price))
            {
                return;
            }

            try
            {
                var dish = new DishDto
                {
                    Name = txtDishName.Text.Trim(),
                    Category = txtCategory.Text.Trim(),
                    Price = price
                };

                await ApiHelper.PostAsync("api/Dishes", dish);

                MessageBox.Show("添加菜品成功");

                ClearDishInputs();
                await LoadDishesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加菜品失败：" + ex.Message);
            }
        }

        private async void btnUpdateDish_Click(object sender, EventArgs e)
        {
            if (selectedDishId == null)
            {
                MessageBox.Show("请先在表格中选择一个菜品");
                return;
            }

            if (!ValidateDishInput(out decimal price))
            {
                return;
            }

            try
            {
                var dish = new DishDto
                {
                    Id = selectedDishId.Value,
                    Name = txtDishName.Text.Trim(),
                    Category = txtCategory.Text.Trim(),
                    Price = price
                };

                await ApiHelper.PutAsync($"api/Dishes/{selectedDishId.Value}", dish);

                MessageBox.Show("修改菜品成功");

                ClearDishInputs();
                await LoadDishesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改菜品失败：" + ex.Message);
            }
        }

        private async void btnDeleteDish_Click(object sender, EventArgs e)
        {
            if (selectedDishId == null)
            {
                MessageBox.Show("请先在表格中选择一个菜品");
                return;
            }

            var result = MessageBox.Show(
                "确定要删除这个菜品吗？",
                "确认删除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await ApiHelper.DeleteAsync($"api/Dishes/{selectedDishId.Value}");

                MessageBox.Show("删除菜品成功");

                ClearDishInputs();
                await LoadDishesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除菜品失败：" + ex.Message);
            }
        }

        private void dgvDishes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var dish = dgvDishes.Rows[e.RowIndex].DataBoundItem as DishDto;

            if (dish == null)
            {
                return;
            }

            selectedDishId = dish.Id;
            txtDishName.Text = dish.Name;
            txtCategory.Text = dish.Category;
            txtPrice.Text = dish.Price.ToString();
        }

        private bool ValidateDishInput(out decimal price)
        {
            price = 0;

            if (string.IsNullOrWhiteSpace(txtDishName.Text))
            {
                MessageBox.Show("请输入菜品名称");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("请输入菜品分类");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("价格必须是数字");
                return false;
            }

            if (price <= 0)
            {
                MessageBox.Show("价格必须大于 0");
                return false;
            }

            return true;
        }

        private void ClearDishInputs()
        {
            selectedDishId = null;
            txtDishName.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }


        //第二页 订单管理

        private void InitOrderManagement()
        {
            dgvOrders.ReadOnly = true;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvOrderItems.ReadOnly = true;
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItems.MultiSelect = false;
            dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbOrderStatus.Items.Clear();
            cmbOrderStatus.Items.Add("Pending");
            cmbOrderStatus.Items.Add("Confirmed");
            cmbOrderStatus.Items.Add("Preparing");
            cmbOrderStatus.Items.Add("Ready");
            cmbOrderStatus.Items.Add("Delivering");
            cmbOrderStatus.Items.Add("Completed");
            cmbOrderStatus.Items.Add("Cancelled");

            if (cmbOrderStatus.Items.Count > 0)
            {
                cmbOrderStatus.SelectedIndex = 0;
            }

            ClearOrderDetail();
        }

        private async Task LoadOrdersAsync()
        {
            try
            {
                var orders = await ApiHelper.GetListAsync<OrderDto>("api/Orders");

                dgvOrders.DataSource = null;
                dgvOrders.DataSource = orders;

                SetOrderGridHeaders();

                dgvOrderItems.DataSource = null;
                selectedOrderId = null;
                ClearOrderDetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载订单失败：" + ex.Message);
            }
        }

        private void SetOrderGridHeaders()
        {
            if (dgvOrders.Columns["Id"] != null)
                dgvOrders.Columns["Id"].HeaderText = "订单编号";

            if (dgvOrders.Columns["CustomerName"] != null)
                dgvOrders.Columns["CustomerName"].HeaderText = "顾客姓名";

            if (dgvOrders.Columns["Phone"] != null)
                dgvOrders.Columns["Phone"].HeaderText = "电话";

            if (dgvOrders.Columns["Address"] != null)
                dgvOrders.Columns["Address"].HeaderText = "配送地址";

            if (dgvOrders.Columns["TotalAmount"] != null)
                dgvOrders.Columns["TotalAmount"].HeaderText = "总金额";

            if (dgvOrders.Columns["Status"] != null)
                dgvOrders.Columns["Status"].HeaderText = "订单状态";

            if (dgvOrders.Columns["CreatedAt"] != null)
            {
                dgvOrders.Columns["CreatedAt"].HeaderText = "创建时间";
                dgvOrders.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            }

            if (dgvOrders.Columns["OrderItems"] != null)
                dgvOrders.Columns["OrderItems"].Visible = false;

            // 这些是文档里的预留字段。当前后端没返回时可以先隐藏。
            if (dgvOrders.Columns["OrderType"] != null)
                dgvOrders.Columns["OrderType"].HeaderText = "订单类型";

            if (dgvOrders.Columns["TableNumber"] != null)
                dgvOrders.Columns["TableNumber"].HeaderText = "桌号";

            if (dgvOrders.Columns["Note"] != null)
                dgvOrders.Columns["Note"].Visible = false;

            if (dgvOrders.Columns["DeliveryFee"] != null)
                dgvOrders.Columns["DeliveryFee"].HeaderText = "配送费";
        }

        private void SetOrderItemGridHeaders()
        {
            if (dgvOrderItems.Columns["Id"] != null)
                dgvOrderItems.Columns["Id"].HeaderText = "明细编号";

            if (dgvOrderItems.Columns["OrderId"] != null)
                dgvOrderItems.Columns["OrderId"].HeaderText = "订单编号";

            if (dgvOrderItems.Columns["DishId"] != null)
                dgvOrderItems.Columns["DishId"].HeaderText = "菜品编号";

            if (dgvOrderItems.Columns["DishName"] != null)
                dgvOrderItems.Columns["DishName"].HeaderText = "菜品名称";

            if (dgvOrderItems.Columns["Price"] != null)
                dgvOrderItems.Columns["Price"].HeaderText = "单价";

            if (dgvOrderItems.Columns["Quantity"] != null)
                dgvOrderItems.Columns["Quantity"].HeaderText = "数量";

            if (dgvOrderItems.Columns["Subtotal"] != null)
                dgvOrderItems.Columns["Subtotal"].HeaderText = "小计";
        }

        private async void btnLoadOrders_Click(object sender, EventArgs e)
        {
            await LoadOrdersAsync();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var order = dgvOrders.Rows[e.RowIndex].DataBoundItem as OrderDto;

            if (order == null)
            {
                return;
            }

            selectedOrderId = order.Id;

            if (cmbOrderStatus.Items.Contains(order.Status))
            {
                cmbOrderStatus.SelectedItem = order.Status;
            }
            else
            {
                cmbOrderStatus.Text = order.Status;
            }

            ShowOrderDetail(order);
            BindOrderItems(order);
        }

        private void ShowOrderDetail(OrderDto order)
        {
            lblOrderId.Text = $"订单编号：{order.Id}";
            lblOrderType.Text = $"订单类型：{GetDisplayText(order.OrderType)}";
            lblCustomerName.Text = $"顾客姓名：{order.CustomerName}";
            lblPhone.Text = $"电话：{order.Phone}";
            lblTableNumber.Text = $"桌号：{GetDisplayText(order.TableNumber)}";
            lblAddress.Text = $"配送地址：{GetDisplayText(order.Address)}";
            lblNote.Text = $"备注：{GetDisplayText(order.Note)}";
            lblDeliveryFee.Text = $"配送费：{order.DeliveryFee:0.00} 元";
            lblTotalAmount.Text = $"总金额：{order.TotalAmount:0.00} 元";
            lblStatus.Text = $"状态：{order.Status}";
            lblCreatedAt.Text = $"创建时间：{order.CreatedAt:yyyy-MM-dd HH:mm:ss}";
        }

        private void BindOrderItems(OrderDto order)
        {
            dgvOrderItems.DataSource = null;
            dgvOrderItems.DataSource = order.OrderItems;

            SetOrderItemGridHeaders();
        }

        private async void btnUpdateOrderStatus_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == null)
            {
                MessageBox.Show("请先选择一个订单");
                return;
            }

            var newStatus = cmbOrderStatus.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(newStatus))
            {
                newStatus = cmbOrderStatus.Text;
            }

            if (string.IsNullOrWhiteSpace(newStatus))
            {
                MessageBox.Show("请选择订单状态");
                return;
            }

            try
            {
                await ApiHelper.PutAsync($"api/Orders/{selectedOrderId.Value}/status", newStatus);

                MessageBox.Show("订单状态修改成功");

                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改订单状态失败：" + ex.Message);
            }
        }

        private void ClearOrderDetail()
        {
            lblOrderId.Text = "订单编号：";
            lblOrderType.Text = "订单类型：";
            lblCustomerName.Text = "顾客姓名：";
            lblPhone.Text = "电话：";
            lblTableNumber.Text = "桌号：";
            lblAddress.Text = "配送地址：";
            lblNote.Text = "备注：";
            lblDeliveryFee.Text = "配送费：";
            lblTotalAmount.Text = "总金额：";
            lblStatus.Text = "状态：";
            lblCreatedAt.Text = "创建时间：";
        }

        private string GetDisplayText(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "无";
            }

            return value;
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}