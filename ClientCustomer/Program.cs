using System;
using System.Windows.Forms;
using ClientCustomer.Models;

namespace ClientCustomer
{
    internal static class Program
    {
        public static UserDto? CurrentUser { get; set; }
        public static bool IsGuestMode { get; set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                CurrentUser = loginForm.LoggedInUser;
                IsGuestMode = loginForm.IsGuestMode;
            }

            bool restartOrderType = true;
            while (restartOrderType)
            {
                restartOrderType = false;

                using (var orderTypeForm = new OrderTypeForm())
                {
                    if (orderTypeForm.ShowDialog() == DialogResult.OK)
                    {
                        var mainForm = new Form1(orderTypeForm.Session);

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
