using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.XtraEditors.Controls;
using System.Data.SqlClient;

namespace eSolution
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        #region Attribute
        #endregion

        #region Properties
        public bool LoginFlag = false;
        public bool IsInitalPassword = false;
        string nl = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();

        #endregion

        #region local

        public static string PublishVersion
        {
            get
            {
                Version version = Assembly.GetEntryAssembly().GetName().Version;
                return string.Format("Version  -  {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            }
        }
        private void ChangeConnectionString()
        {
            //// Get the application configuration file.
            //System.Configuration.Configuration config =
            //        ConfigurationManager.OpenExeConfiguration(
            //        ConfigurationUserLevel.None);

            //// Get the current connection strings count.
            //int connStrCnt =
            //    ConfigurationManager.ConnectionStrings.Count;

            //// Create the connection string name. 
            ////string csName =
            ////    "ConnStr" + connStrCnt.ToString();
            //string csName = "eMESConnectionString";

            //// Create a connection string element and
            //// save it to the configuration file.

            //// Create a connection string element.
            //ConnectionStringSettings csSettings =
            //        new ConnectionStringSettings(csName, "Data Source = " + cmbDB.EditValue.ToString() + "; Initial Catalog = eMES; Persist Security Info = True; User ID = emes_usr; Password = emes123", "System.Data.SqlClient");

            //// Get the connection strings section.
            //ConnectionStringsSection csSection =
            //    config.ConnectionStrings;

            //// Add the new element.
            //csSection.ConnectionStrings.Add(csSettings);

            //// Save the configuration file.
            //config.Save(ConfigurationSaveMode.Modified);

            ////string connectionString = System.Configuration.ConfigurationSettings.AppSettings["eMESConnectionString"];
            ////string connectionString = ConfigurationManager.ConnectionStrings[csName].ConnectionString;
            ////MessageBox.Show(connectionString);
        }

        private bool CheckInput()
        {
            var cursorCurrent = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string strUserID = txtUserName.Text.Trim();
                string strPassword = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(strUserID))
                {
                    //XtraMessageBox.Show("User Name is Empty!", ConstStrings.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    XtraMessageBox.Show("User Name is Empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(strPassword))
                {
                    //XtraMessageBox.Show("Password is Empty!", ConstStrings.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    XtraMessageBox.Show("Pasword is Empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //Functions.CreateErrorLog(GetType().Name, MethodBase.GetCurrentMethod().Name, ex);
                //MessageBox.Show(ConstStrings.TryAgain, ConstStrings.Failed, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Try Again!", "Login Failed" + nl + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                Cursor.Current = cursorCurrent;
            }

        }

        #endregion
        #region Event
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var cursorCurrent = Cursor.Current;
            if (CheckInput() == false) return;

            ChangeConnectionString();


            LoginFlag = true;
            this.DialogResult = DialogResult.Yes;
            // if (CheckVersion() == false) return;
            //if (PasswordValidation() == true)
            //{
            //    //Create Log.SystemInOut

            //    try
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            //        {
            //            using (DBConnDataContext db = new DBConnDataContext())
            //            {
            //                DatabaseHelper.SystemInOutInsert(db, "I");
            //                db.SubmitChanges();
            //            }
            //            scope.Complete();
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        Functions.CreateErrorLog(GetType().Name, MethodBase.GetCurrentMethod().Name, ex);
            //        //MessageBox.Show(ConstStrings.TryAgain, ConstStrings.Failed, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    finally
            //    {
            //        Cursor.Current = cursorCurrent;
            //        //                    bool NetConnection = NetMembershipHelper.CheckConnectionString("MyConnectionString");
            //    }
            //}

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    txtPassword.Focus();
                    return;
                }
                btnLogin.PerformClick();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            var cursorCurrent = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (LoginFlag == false)
                {
                    DialogResult dr = XtraMessageBox.Show("Are you sure to close this application?", ConstStrings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //DialogResult dr = XtraMessageBox.Show("Are you sure to close this application?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        DialogResult = DialogResult.Yes;
                    }
                    else if (dr == System.Windows.Forms.DialogResult.No)
                    {
                        e.Cancel = true;
                    }

                }
            }
            catch (Exception ex)
            {
                //Functions.CreateErrorLog(GetType().Name, MethodBase.GetCurrentMethod().Name, ex);
                MessageBox.Show(ConstStrings.TryAgain + nl + ex.Message.ToString(), ConstStrings.Failed, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor.Current = cursorCurrent;
            }
        }

        #endregion

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //ComboBoxEdit combo = new ComboBoxEdit();
            ComboBoxItemCollection coll = cmbDB.Properties.Items;

            coll.BeginUpdate();

            try
            {
                coll.Add("localhost");
                //coll.Add("127.0.0.1");
            }
            finally
            {
                coll.EndUpdate();
            }
            cmbDB.Reset();
            cmbDB.SelectedIndex = 0;
            Controls.Add(cmbDB);

        }
    }
}
