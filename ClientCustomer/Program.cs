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

            using (var orderTypeForm = new OrderTypeForm())
            {
                if (orderTypeForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1(
                        orderTypeForm.OrderType,
                        orderTypeForm.TableNumber,
                        orderTypeForm.DeliveryAddress
                    ));
                }
            }
        }
    }
}
