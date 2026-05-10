using System;
using System.Windows.Forms;

namespace ClientCustomer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 先显示点餐模式选择窗体
            using (var orderTypeForm = new OrderTypeForm())
            {
                if (orderTypeForm.ShowDialog() == DialogResult.OK)
                {
                    // 选择成功后打开主窗体
                    Application.Run(new Form1());
                }
            }
        }
    }
}