using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientCustomer
{
    public partial class OrderTypeForm : Form
    {
        // 公开属性，用于传递选择结果
        public string OrderType { get; private set; } = "DineIn";
        public string? TableNumber { get; private set; }
        public string? DeliveryAddress { get; private set; }

        public OrderTypeForm()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            // 点击堂食面板
            panelDineIn.Click += (s, e) => SelectDineIn();

            // 点击堂食面板内的所有控件也触发选择
            foreach (Control control in panelDineIn.Controls)
            {
                control.Click += (s, e) => SelectDineIn();
            }

            // 点击外卖面板
            panelDelivery.Click += (s, e) => SelectDelivery();

            // 点击外卖面板内的所有控件也触发选择
            foreach (Control control in panelDelivery.Controls)
            {
                control.Click += (s, e) => SelectDelivery();
            }

            // 点击确认按钮
            btnConfirm.Click += BtnConfirm_Click;
        }

        private void SelectDineIn()
        {
            OrderType = "DineIn";

            // 更新面板样式
            panelDineIn.BackColor = Color.FromArgb(255, 243, 224); // 浅橙色
            panelDelivery.BackColor = Color.White;

            panelDineIn.BorderStyle = BorderStyle.FixedSingle;
            panelDelivery.BorderStyle = BorderStyle.None;

            // 启用桌号输入
            txtTableNumber.Enabled = true;
            txtTableNumber.Focus();

            // 禁用地址输入
            txtAddress.Enabled = false;
            lblAddress.Enabled = false;
            txtAddress.Clear();
        }

        private void SelectDelivery()
        {
            OrderType = "Delivery";

            // 更新面板样式
            panelDelivery.BackColor = Color.FromArgb(227, 242, 253); // 浅蓝色
            panelDineIn.BackColor = Color.White;

            panelDelivery.BorderStyle = BorderStyle.FixedSingle;
            panelDineIn.BorderStyle = BorderStyle.None;

            // 启用地址输入
            txtAddress.Enabled = true;
            lblAddress.Enabled = true;
            txtAddress.Focus();

            // 禁用桌号输入
            txtTableNumber.Enabled = false;
            txtTableNumber.Clear();
        }

        private void BtnConfirm_Click(object? sender, EventArgs e)
        {
            // 验证输入
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
            else // Delivery
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

            // 设置对话框结果并关闭
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
