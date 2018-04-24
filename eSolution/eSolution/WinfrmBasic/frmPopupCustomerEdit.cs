using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using eSolution.Database;


namespace eSolution.WinfrmBasic
{
    public partial class frmPopupCustomerEdit : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();

        public int intCustomerID;
        public string strEntryStatus; // A : Create New PO, E : Edit PO
        public frmPopupCustomerEdit()
        {
            InitializeComponent();
        }

        private void Initialized()
        {
            Functions.QueryCmbState(db, ref lueState, false);
            Functions.QueryCmbSetYesNo(ref lueUseYN);

            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
            txtContactName.Text = "";
            txtContactTitle.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            lueState.EditValue = "TX";
            txtPostalCode.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            luePaymentTerm.EditValue = "";
            lueUseYN.EditValue = "Y";

            txtCustomerCode.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtCustomerCode.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtCustomerName.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtCustomerName.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtContactName.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtContactName.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtCustomerCode.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtCustomerCode.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtContactTitle.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtContactTitle.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtAddress1.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtAddress1.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtAddress2.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtAddress2.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtCity.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtCity.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueState.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueState.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtPostalCode.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtPostalCode.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtPhone.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtPhone.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtFax.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtFax.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            luePaymentTerm.Properties.AppearanceFocused.BackColor = Color.Yellow;
            luePaymentTerm.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueUseYN.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueUseYN.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtCustomerCode.Focus();
        }
        private void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var qry = (from obj in db.Customers
                           where obj.CustomerID == intCustomerID
                           select obj).FirstOrDefault();
                if (qry != null)
                {
                    txtCustomerID.Text = qry.CustomerID.ToString();
                    txtCustomerCode.Text = qry.CustomerCode;
                    txtCustomerName.Text = qry.CustomerName;
                    txtContactName.Text = qry.ContactName;
                    txtContactTitle.Text = qry.ContactTitle;
                    txtAddress1.Text = qry.Address1;
                    txtAddress2.Text = qry.Address2;
                    txtCity.Text = qry.City;
                    lueState.EditValue = qry.State;
                    txtPostalCode.Text = qry.PostalCode;
                    txtPhone.Text = qry.Phone;
                    txtFax.Text = qry.Fax;
                    luePaymentTerm.EditValue = qry.PaymentTerm;
                    if (qry.UseYN.ToString() == "0" )
                        lueUseYN.EditValue = "N";
                    else
                        lueUseYN.EditValue = "Y";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not find P/O Data!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public Boolean SaveData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                intCustomerID = Convert.ToInt16(txtCustomerID.Text);
                string strCustomerCode = (txtCustomerCode.Text).ToUpper().Trim();
                string strCustomerName = (txtCustomerName.Text).Trim();
                string strContactName = (txtContactName.Text).Trim();
                string strContactTitle = (txtContactTitle.Text).Trim();
                string strAddress1 = (txtAddress1.Text).Trim();
                string strAddress2 = (txtAddress2.Text).Trim();
                string strCity = (txtCity.Text).Trim();
                string strState = lueState.EditValue.ToString();
                string strPostalCode = (txtPostalCode.Text).Trim();
                string strPhone = (txtPhone.Text).Trim();
                string strFax = (txtFax.Text).Trim();
                string strPaymentTerm = (luePaymentTerm.EditValue).ToString();
                string strUseYN = (lueUseYN.EditValue.ToString());
                bool blnUseYN;

                if (string.IsNullOrEmpty(strCustomerCode))
                {
                    XtraMessageBox.Show("Please, input Customer Code first.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerCode.Focus();
                    return false;
                }

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                {
                    using (eSolutionDataContext db = new eSolutionDataContext())
                    {
                        DateTime dtServerDate = Convert.ToDateTime(db.fn_ServerDateTime().ToString());

                        var qryCustomer = (from cst in db.Customers
                                           where cst.CustomerCode == strCustomerCode
                                           select cst).FirstOrDefault();


                        if (qryCustomer == null)
                        {
                            // new add row
                            var qryCount = (from cst in db.Customers
                                            where cst.CustomerCode == strCustomerCode
                                            select cst).Count();
                            if (qryCount > 0)
                            {
                                MessageBox.Show("Already regist Customer Code" + Environment.NewLine + "Please, check Customer List!",
                                    "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCustomerCode.Focus();
                                return false;
                            }

                            Customer customer = new Customer();
                            customer.CustomerCode = strCustomerCode;
                            customer.CustomerName = strCustomerName;
                            customer.ContactName = strContactName;
                            customer.ContactTitle = strContactTitle;
                            customer.Address1 = strAddress1;
                            customer.Address2 = strAddress2;
                            customer.City = strCity;
                            customer.State = strState;
                            customer.PostalCode = strPostalCode;
                            customer.Phone = strPhone;
                            customer.Fax = strFax;
                            customer.PaymentTerm = strPaymentTerm;
                            if (strUseYN == "Y")
                            {
                                blnUseYN = true;
                            }
                            else
                           {
                                blnUseYN = false;
                            }
                            customer.UseYN = blnUseYN;
                            customer.CreateDate = dtServerDate;
                            customer.CreateCompName = Environment.MachineName;

                        }
                        else
                        {
                            intCustomerID = (from obj in db.Customers where obj.CustomerCode == strCustomerCode select obj.CustomerID).FirstOrDefault();
                            qryCustomer.CustomerCode = strCustomerCode;
                            qryCustomer.CustomerName = strCustomerName;
                            qryCustomer.ContactName = strContactName;
                            qryCustomer.ContactTitle = strContactTitle;
                            qryCustomer.Address1 = strAddress1;
                            qryCustomer.Address2 = strAddress2;
                            qryCustomer.City = strCity;
                            qryCustomer.State = strState;
                            qryCustomer.PostalCode = strPostalCode;
                            qryCustomer.Phone = strPhone;
                            qryCustomer.Fax = strFax;
                            qryCustomer.PaymentTerm = strPaymentTerm;
                        }
                        db.SubmitChanges();

                        if (strEntryStatus == "A")
                        {
                            txtCustomerID.Text = intCustomerID.ToString();
                            strEntryStatus = "E";
                        }
                    }
                    scope.Complete();
                }
                MessageBox.Show("Completed Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Error!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SearchData();
                Cursor.Current = Cursors.Default;
            }
            return false;
        }

        private void frmPopupCustomerEdit_Load(object sender, EventArgs e)
        {
            Initialized();

            if (strEntryStatus == "A") // Create New PO
            {
                barBtnNew.PerformClick();
            }
            else // Retreive PO Data
            {
                SearchData();
            }
            txtCustomerCode.Focus();
        }

        private void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Initialized();
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}