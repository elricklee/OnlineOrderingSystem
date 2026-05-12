using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ClientCustomer
{
    public partial class OrderTypeForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OrderType { get; private set; } = "DineIn";
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? TableNumber { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? DeliveryAddress { get; private set; }

        public OrderTypeForm()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            panelDineIn.Click += (s, e) => SelectDineIn();

            foreach (Control control in panelDineIn.Controls)
            {
                control.Click += (s, e) => SelectDineIn();
            }

            panelDelivery.Click += (s, e) => SelectDelivery();

            foreach (Control control in panelDelivery.Controls)
            {
                control.Click += (s, e) => SelectDelivery();
            }

            btnConfirm.Click += BtnConfirm_Click;
        }

        private void SelectDineIn()
        {
            OrderType = "DineIn";

            panelDineIn.BackColor = Color.FromArgb(255, 243, 224);
            panelDelivery.BackColor = Color.White;

            panelDineIn.BorderStyle = BorderStyle.FixedSingle;
            panelDelivery.BorderStyle = BorderStyle.None;

            txtTableNumber.Enabled = true;
            txtTableNumber.Focus();

            txtAddress.Enabled = false;
            lblAddress.Enabled = false;
            txtAddress.Clear();
        }

        private void SelectDelivery()
        {
            OrderType = "Delivery";

            panelDelivery.BackColor = Color.FromArgb(227, 242, 253);
            panelDineIn.BackColor = Color.White;

            panelDelivery.BorderStyle = BorderStyle.FixedSingle;
            panelDineIn.BorderStyle = BorderStyle.None;

            txtAddress.Enabled = true;
            lblAddress.Enabled = true;
            txtAddress.Focus();

            txtTableNumber.Enabled = false;
            txtTableNumber.Clear();
        }

        private void BtnConfirm_Click(object? sender, EventArgs e)
        {
            if (OrderType == "DineIn")
            {
                if (string.IsNullOrWhiteSpace(txtTableNumber.Text))
                {
                    MessageBox.Show("请输入桌号！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTableNumber.Focus();
                    return;
                }
                TableNumber = txtTableNumber.Text.Trim();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("请输入配送地址！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }
                DeliveryAddress = txtAddress.Text.Trim();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
