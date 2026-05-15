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

            bool restartOrderType = true;
            while (restartOrderType)
            {
                restartOrderType = false;
                
                using (var orderTypeForm = new OrderTypeForm())
                {
                    if (orderTypeForm.ShowDialog() == DialogResult.OK)
                    {
                        var mainForm = new Form1(
                            orderTypeForm.OrderType,
                            orderTypeForm.TableNumber,
                            orderTypeForm.DeliveryAddress
                        );
                        
                        if (mainForm.ShowDialog() == DialogResult.Retry)
                        {
                            restartOrderType = true;
                        }
                    }
                }
            }
        }
    }
}
