using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSolution
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());

            bool firstInstance;
            using (Mutex mutex = new Mutex(false, "Local\\" + "eSolution for EG2", out firstInstance))
            {
                if (firstInstance == true)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    DevExpress.Skins.SkinManager.EnableFormSkins();
                    //DevExpress.UserSkins.BonusSkins.Register();
                    //UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
                    //DevExpress.Skins.SkinManager.DisableMdiFormSkins();
                    frmLogin frm = new frmLogin();
                    while (frm.ShowDialog() != DialogResult.Yes)
                    {

                    }
                    if (frm.LoginFlag == true)
                    {
                        //Application.Run(new puReceivingScreen());
                        Application.Run(new frmMain());
                    }
                }
                else
                {
                    MessageBox.Show("Application is already running", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
