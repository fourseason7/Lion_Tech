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
using eSolution.Database;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using System.Transactions;

namespace eSolution.WinfrmBasic
{
    public partial class frmCustomerMaster : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();

        public frmCustomerMaster()
        {
            InitializeComponent();
        }
        public void Initialized()
        {
            // Search Group
            Functions.QueryCmbCustomerList(db, ref lueSearchCustomer, true);
            string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
            Functions.QueryCmbSetYesNoAll(ref lueSearchUseYN);


            lueSearchCustomer.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchCustomer.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchUseYN.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchUseYN.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            gvList.PopulateColumns();
        }

        private void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            string strSearchCustomer;
            string strSearchUseYN;

            try
            {
                strSearchCustomer = lueSearchCustomer.EditValue.ToString();
                if (string.IsNullOrEmpty(strSearchCustomer)) strSearchCustomer = "%";


                strSearchUseYN = lueSearchUseYN.Properties.GetKeyValueByDisplayText(lueSearchUseYN.Text).ToString();
                if (string.IsNullOrEmpty(strSearchUseYN)) strSearchUseYN = "%";

                var qry = db.stp_Customer_Select(strSearchCustomer, strSearchUseYN).ToList();
                if (qry.Count() > 0)
                {
                    gcList.DataSource = qry;
                    string[] arr = { "CustomerID"};
                    Functions.SetInvisible(ref gvList, arr);
                    gvList.BestFitColumns();
                    gvList.OptionsBehavior.ReadOnly = true;
                    gvList.FocusedRowHandle = gvList.GetVisibleRowHandle(0);
                }
                else
                {
                    gcList.DataSource = null;
                    MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't Search Customer List!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void frmCustomerMaster_Load(object sender, EventArgs e)
        {
            Initialized();
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchData();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvList.RowCount == 0)
                {
                    return;
                }

                //DataViewBase view = gcHeader.View;

                eSolution.WinfrmBasic.frmPopupCustomerEdit frm = new eSolution.WinfrmBasic.frmPopupCustomerEdit();
                frm.intCustomerID = Convert.ToInt16(gvList.GetRowCellValue(gvList.FocusedRowHandle, "CustomerID").ToString());
                frm.strEntryStatus = "E";

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                    }
                    catch
                    {
                    }

                    btnSearch.PerformClick();
                }
                frm.Dispose();

            }
            catch { }
        }
    }
}