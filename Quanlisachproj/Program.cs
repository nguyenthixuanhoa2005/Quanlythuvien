using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlisachcoban
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool exitApp = false;

            while(exitApp == false)
            {
                using (DangNhap DN = new DangNhap())
                {
                    if (DN.ShowDialog() == DialogResult.OK)
                    {
                        using (TrangChu MainPage = new TrangChu(DN.loginUser))
                        {
                            if (MainPage.ShowDialog() == DialogResult.Retry)
                            {
                                continue;
                            }
                            else
                            {
                                exitApp = true;
                            }
                        }
                    }
                    else
                    {
                        exitApp = true;
                    }
                }
            }
        }
    }


}
