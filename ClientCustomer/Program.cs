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

            var restartLogin = true;
            while (restartLogin)
            {
                restartLogin = false;

                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    CurrentUser = loginForm.LoggedInUser;
                    IsGuestMode = loginForm.IsGuestMode;
                }

                if (IsGuestMode)
                {
                    using var guestForm = new Form1(new OrderSession { OrderType = "Browse" });
                    var guestResult = guestForm.ShowDialog();
                    if (guestResult == DialogResult.Abort)
                    {
                        restartLogin = true;
                    }
                    continue;
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
                            var mainResult = mainForm.ShowDialog();

                            if (mainResult == DialogResult.Retry)
                            {
                                restartOrderType = true;
                            }
                            else if (mainResult == DialogResult.Abort)
                            {
                                restartLogin = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
