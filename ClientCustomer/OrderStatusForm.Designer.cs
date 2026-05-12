namespace ClientCustomer
{
    partial class OrderStatusForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(700, 550);
            Name = "OrderStatusForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "订单状态查询";
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ResumeLayout(false);
        }
    }
}
