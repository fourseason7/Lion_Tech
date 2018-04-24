using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;

namespace eSolution
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        void OpenForm(string strName, string strCaption)
        {
            var cursorCurrent = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Prevent open same form
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == strName)
                    {
                        f.SelectNextControl(f.Controls.Find(strName, true).FirstOrDefault() as TextBox, true, true, true, true);
                        f.Activate();
                        return;
                    }
                }

                Form frm = (Form)Activator.CreateInstance(null, strName).Unwrap();
                //frm.MdiParent = this;
                //frm.Name = strName;
                //frm.Text = strCaption;
                if (strName == "eSolution.WinfrmBasic.frmSizeMeasForApple")
                {
                    //frm.MdiParent = this;
                    frm.Name = strName;
                    frm.Text = strCaption;
                    frm.ShowDialog();
                }
                else
                {
                    frm.MdiParent = this;
                    frm.Name = strName;
                    frm.Text = strCaption;
                    frm.Show();
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't find open " + strCaption + "!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Functions.CreateErrorLog(GetType().Name, MethodBase.GetCurrentMethod().Name, ex);
                //MessageBox.Show(ConstStrings.TryAgain, ConstStrings.Failed, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor.Current = cursorCurrent;
            }
            foreach (XtraMdiTabPage pg in xtraTabbedMdiManager1.Pages)
            {
                if (pg.MdiChild.Name == strName)
                {
                    xtraTabbedMdiManager1.SelectedPage = pg;
                    return;
                }
            }
        }
        public void CloseForm(string frmName)
        {
            foreach (Form f in Application.OpenForms)
            {
                f.Close();
                break;
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = String.Format("{0} [Ver.{1}]", this.Text, version);
        }

        private void navBarMainMenu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var cursorCurrent = Cursor.Current;
            string strFormName = "";
            string strCaption = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (e.Link.Item.Tag != null)
                {
                    strFormName = e.Link.Item.Tag.ToString();
                    strCaption = e.Link.Item.Caption.ToString();
                    OpenForm(strFormName, strCaption);
                }
            }
            catch (Exception ex)
            {
                //Functions.CreateErrorLog(GetType().Name, MethodBase.GetCurrentMethod().Name, ex);
                MessageBox.Show("Couldn't find open " + strCaption + "!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = cursorCurrent;
            }
        }

        private void barSubMenuExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void navBarMainMenu_Click(object sender, EventArgs e)
        {

        }
    }
}