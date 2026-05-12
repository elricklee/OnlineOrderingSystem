namespace ClientCustomer
{
    partial class CartForm
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
            ClientSize = new Size(800, 620);
            Name = "CartForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "购物车";
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ResumeLayout(false);
        }
    }
}
