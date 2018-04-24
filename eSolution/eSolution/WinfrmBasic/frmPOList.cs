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
using DevExpress.XtraGrid.Views.Base;
using eSolution.Database;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;

namespace eSolution
{
    public partial class frmPOList : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();

        public frmPOList()
        {
            InitializeComponent();
        }
        public void Initialized()
        {

            Functions.QueryCmbCustomerList(db, ref lueSearchCustomer, true);
            string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
            Functions.QueryCmbUserCodeData(db, ref lueSearchPOType, lueSearchPOType.Tag.ToString(), "", true);
            string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
            Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOType, "", true);
            Functions.QueryCmbOpenClosedAll(ref lueSearchStatus);

            dtSearchDateFrom.EditValue = Convert.ToDateTime(db.fn_ServerDateTime()).AddDays(-90) ;
            dtSearchDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtSearchDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";

            dtSearchDateTo.EditValue = (DateTime?)db.fn_ServerDateTime();
            dtSearchDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtSearchDateTo.Properties.Mask.EditMask = "MM/dd/yyyy";

            dtSearchDateFrom.Properties.AppearanceFocused.BackColor = Color.Yellow;
            dtSearchDateFrom.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            dtSearchDateTo.Properties.AppearanceFocused.BackColor = Color.Yellow;
            dtSearchDateTo.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchCustomer.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchCustomer.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchPOType.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchPOType.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchPO.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchPO.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSearchItem.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSearchItem.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchStatus.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchStatus.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;
        }
        public void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime dtFromDate, dtToDate;
            string strFromDate, strToDate;
            string strSearchCustomer;
            string strSearchPONumber;
            string strSearchItem;
            string strSearchStatus;

            gcHeader.DataSource = null;
            try
            {

                dtFromDate = Convert.ToDateTime(dtSearchDateFrom.EditValue);
                dtToDate = Convert.ToDateTime(dtSearchDateTo.EditValue).AddDays(1);
                strFromDate = Functions.FunctionDateToString(dtFromDate, 0);
                strToDate = Functions.FunctionDateToString(dtToDate, 0);
                dtFromDate = Convert.ToDateTime(strFromDate);
                dtToDate = Convert.ToDateTime(strToDate);

                strSearchCustomer = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                if (string.IsNullOrEmpty(strSearchCustomer))
                    strSearchCustomer = "%";
                strSearchPONumber = lueSearchPO.Properties.GetKeyValueByDisplayText(lueSearchPO.Text).ToString();
                if (string.IsNullOrEmpty(strSearchPONumber))
                    strSearchPONumber = "%";
                strSearchItem = txtSearchItem.Text.ToString();
                if (string.IsNullOrEmpty(strSearchItem))
                    strSearchItem = "%";
                strSearchStatus = lueSearchStatus.Properties.GetKeyValueByDisplayText(lueSearchStatus.Text).ToString();
                if (string.IsNullOrEmpty(strSearchStatus))
                    strSearchStatus = "%";

                string strSearchPOtype = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                if (string.IsNullOrEmpty(strSearchPOtype))
                    strSearchPOtype = "%";

                var qry = db.stp_POHeader_Select(dtFromDate, dtToDate, strSearchCustomer, strSearchPOtype, strSearchPONumber, strSearchStatus);

                if (qry != null)
                {
                    gcHeader.DataSource = qry.ToList();
                    if (gvHeader.RowCount > 0)
                    {

                        gvHeader.FocusedRowHandle = -1;
                        string[] arr = { "CustomerID", "POHeaderID" };
                        Functions.SetInvisible(ref gvHeader, arr);

                        gvHeader.BestFitColumns();
                        gvHeader.OptionsBehavior.ReadOnly = true;
                        gvHeader.FocusedRowHandle = 0;

                    }
                }
                else
                {
                    gcHeader.DataSource = null;
                    MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't Search Item List!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public void SearchData(string strCustomer, string strPONumber)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var qry = db.stp_PODetail_Select(strCustomer, "%", strPONumber, "%", "%");
             

                if (qry != null)
                {
                    gcDetail.DataSource = qry.ToList();
                    if (gvDetail.RowCount > 0)
                    {
                        gvDetail.BestFitColumns();
                        gvDetail.OptionsBehavior.ReadOnly = true;
                        gvDetail.FocusedRowHandle = 0;

                        // Set Display format
                        //CustomerCode CustomerName    PONumber OrderDate   POLineNumber ItemCode    ItemNumber ReceiveQty  DueDate ShipRefurbishedQty  ShipFrontOnly ShipFunctionFailQty
                        //ShipDIPQty ShipSampleQty   ShipNTFQty ShipOutOfWarranty   ShipCustomerAbuse ShipTotalQty    InventoryQty Status  POHeaderID PODetailID  CustomerID ItemID

                        // Set Display format
                        gvDetail.Columns["ReceiveQty"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ReceiveQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.Columns["ShipRefurbishedQty"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ShipRefurbishedQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.Columns["ShipRefurbishedFPCBQty"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ShipRefurbishedFPCBQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.Columns["ShipFrontOnly"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ShipFrontOnly"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;


                        gvDetail.Columns["ShipFunctionFailQty"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ShipFunctionFailQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.Columns["ShipDIPQty"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ShipDIPQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.Columns["ShipSampleQty"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ShipSampleQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.Columns["ShipNTFQty"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ShipNTFQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.Columns["ShipOutOfWarranty"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ShipOutOfWarranty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.Columns["ShipCustomerAbuse"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ShipCustomerAbuse"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;


                        gvDetail.Columns["ShipTotalQty"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["ShipTotalQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.Columns["InventoryQty"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["InventoryQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.Columns["POLineNumber"].Caption = "Line#";
                        gvDetail.Columns["ReceiveQty"].Caption = "Receive";
                        gvDetail.Columns["ShipRefurbishedQty"].Caption = "Refurbished";
                        gvDetail.Columns["ShipRefurbishedFPCBQty"].Caption = "Refurbished-FPCB";
                        gvDetail.Columns["ShipFrontOnly"].Caption = "Front Only";
                        gvDetail.Columns["ShipFunctionFailQty"].Caption = "Function Fail";
                        gvDetail.Columns["ShipDIPQty"].Caption = "DIP";
                        gvDetail.Columns["ShipSampleQty"].Caption = "Sample";
                        gvDetail.Columns["ShipNTFQty"].Caption = "NTF";
                        gvDetail.Columns["ShipOutOfWarranty"].Caption = "OOW";
                        gvDetail.Columns["ShipCustomerAbuse"].Caption = "Customer Abuse";
                        gvDetail.Columns["ShipTotalQty"].Caption = "Total";
                        gvDetail.Columns["InventoryQty"].Caption = "Inventory";

                        gvDetail.Columns["PONumber"].BestFit();
                        gvDetail.Columns["ItemNumber"].BestFit();
                        gvDetail.Columns["POLineNumber"].BestFit();

                        string[] arr = { "CustomerCode", "ItemCode", "DueDate", "POHeaderID", "PODetailID", "CustomerID", "ItemID" };
                        Functions.SetInvisible(ref gvDetail, arr);
                    }
                }
                else
                {
                    gcDetail.DataSource = null;
                    MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't Search Purchase Order Detail!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public Boolean DeleteData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (gvHeader.RowCount <= 0) return false;
                Int16 intPOHeaderID = Convert.ToInt16(gvHeader.GetRowCellValue(gvHeader.FocusedRowHandle, "POHeaderID").ToString());
                if (intPOHeaderID <= 0)
                {
                    //XtraMessageBox.Show("Please, input P/O Number first.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtPONumber.Focus();
                    return false;
                }
                DialogResult result = XtraMessageBox.Show("Do you want to delete P/O Data?", "Question!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    return false;
                }
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                {
                    using (eSolutionDataContext db = new eSolutionDataContext())
                    {
                        DateTime dtServerDate = Convert.ToDateTime(db.fn_ServerDateTime().ToString());

                        var qryPODetail = from pod in db.PODetails
                                          where pod.POHeaderID == intPOHeaderID
                                          select pod;

                        foreach (var dtl in qryPODetail)
                        {
                            db.PODetails.DeleteOnSubmit(dtl);
                        }

                        var qryPOHeader = from poh in db.POHeaders
                                          where poh.POHeaderID == intPOHeaderID
                                          select poh;
                        foreach (var dtl in qryPOHeader)
                        {
                            db.POHeaders.DeleteOnSubmit(dtl);
                        }

                        db.SubmitChanges();
                    }
                    scope.Complete();
                }
                MessageBox.Show("Delete Completed!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchData();
        }

        private void frmPOList_Load(object sender, EventArgs e)
        {
            Initialized();
        }



        private void gvHeader_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle < 0)
                {
                    return;
                }
                else
                {
                    // set customer shipping item number
                    string strCustomer, strPONumber;
                    strCustomer = gvHeader.GetRowCellValue(e.FocusedRowHandle, "CustomerCode").ToString();
                    strPONumber = gvHeader.GetRowCellValue(e.FocusedRowHandle, "PONumber").ToString();

                    SearchData(strCustomer, strPONumber);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get P/O Detail." + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                eSolution.WinfrmBasic.frmPopupPOEdit frm = new eSolution.WinfrmBasic.frmPopupPOEdit();
                frm.intPOHeaderID = 0;
                frm.strEntryStatus = "A";

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                        string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                        Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOType, "", true);
                    }
                    catch
                    {
                    }
                    barBtnSearch.PerformClick();
                }
                frm.Dispose();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvHeader.RowCount == 0)
                {
                    return;
                }

                //DataViewBase view = gcHeader.View;
                
                eSolution.WinfrmBasic.frmPopupPOEdit frm = new eSolution.WinfrmBasic.frmPopupPOEdit();
                frm.intPOHeaderID = Convert.ToInt16(gvHeader.GetRowCellValue(gvHeader.FocusedRowHandle, "POHeaderID").ToString());
                frm.strEntryStatus = "E";

                if (frm.ShowDialog(this) == DialogResult.OK)
               {
                    try
                    {
                        string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                        string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                        Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOType, "", true);
                    }
                    catch
                    {
                    }

                    barBtnSearch.PerformClick();
                }
                frm.Dispose();
                
            }
            catch { }
        }

        private void barBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //SearchData();
            try
            {
                string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOType, "", true);
            }
            catch
            {
            }

            DeleteData();
        }

        private void gvHeader_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                gvHeader.FocusedRowHandle -= 1;
            }
            else if (e.Delta < 0)
            {
                gvHeader.FocusedRowHandle += 1;
            }
        }
        private void gvHeader_RowCountChanged(object sender, EventArgs e)
        {
            Functions.gvRowCountChanged(sender, e);
        }
        private void gvHeader_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            Functions.AddingRowNumber(sender, e);
        }

        private void gvDetail_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                gvHeader.FocusedRowHandle -= 1;
            }
            else if (e.Delta < 0)
            {
                gvHeader.FocusedRowHandle += 1;
            }

        }

        private void gvDetail_RowCountChanged(object sender, EventArgs e)
        {
            Functions.gvRowCountChanged(sender, e);

        }

        private void gvDetail_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            Functions.AddingRowNumber(sender, e);

        }

        private void gcSearch_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lueSearchPOType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOType, "", true);
            }
            catch
            {
            }
        }

        private void lueSearchCustomer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                Functions.QueryCmbUserCodeData(db, ref lueSearchPOType, lueSearchPOType.Tag.ToString(), "", true);
                string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOType, "", true);
            }
            catch
            { }
        }

        private void frmPOList_Activated(object sender, EventArgs e)
        {
            //Functions.QueryCmbCustomerList(db, ref lueSearchCustomer, true);
            string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
            Functions.QueryCmbUserCodeData(db, ref lueSearchPOType, lueSearchPOType.Tag.ToString(), "", true);
            string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
            Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOType, "", true);
            Functions.QueryCmbOpenClosedAll(ref lueSearchStatus);

        }
    }
}