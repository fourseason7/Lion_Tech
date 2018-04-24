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
using eSolution.Report;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraReports.UI;

namespace eSolution.WinfrmBasic
{
    public partial class frmPackingSummaryForCVE : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();
        public frmPackingSummaryForCVE()
        {
            InitializeComponent();
        }
        public void Initialized()
        {

            Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, "CVE", "", "", true);

            barEditCopies.EditValue = 1;

            dtSearchDateFrom.EditValue = Convert.ToDateTime(db.fn_ServerDateTime()).AddDays(-7);
            dtSearchDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtSearchDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            dtSearchDateTo.EditValue = (DateTime?)db.fn_ServerDateTime();

            dtSearchDateFrom.Properties.AppearanceFocused.BackColor = Color.Yellow;
            dtSearchDateFrom.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            dtSearchDateTo.Properties.AppearanceFocused.BackColor = Color.Yellow;
            dtSearchDateTo.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchPO.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchPO.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;
        }
        public void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime dtFromDate, dtToDate;
            string strFromDate, strToDate;
            string strSearchPONumber;

            try
            {

                dtFromDate = Convert.ToDateTime(dtSearchDateFrom.EditValue);
                dtToDate = Convert.ToDateTime(dtSearchDateTo.EditValue).AddDays(1);
                strFromDate = Functions.FunctionDateToString(dtFromDate, 0);
                strToDate = Functions.FunctionDateToString(dtToDate, 0);
                dtFromDate = Convert.ToDateTime(strFromDate);
                dtToDate = Convert.ToDateTime(strToDate);

                strSearchPONumber = lueSearchPO.Properties.GetKeyValueByDisplayText(lueSearchPO.Text).ToString();
                if (string.IsNullOrEmpty(strSearchPONumber))
                    strSearchPONumber = "%";

                var qry = db.stp_PackingSummaryForCVE_Select(dtFromDate, dtToDate, strSearchPONumber);

                if (qry != null)
                {
                    gcList.DataSource = qry.ToList();
                    if (gvList.RowCount > 0)
                    {
                        gvList.BestFitColumns();
                        gvList.OptionsBehavior.ReadOnly = true;
                        gvList.FocusedRowHandle = 0;

                        //gvList.Columns["CustomerCode"].Caption = "Customer";
                        //gvList.Columns["POLineNumber"].Caption = "Line";
                        //gvList.Columns["ShippingStatusName"].Caption = "Shipping Status";

                        //gvList.Columns["ShippingStatus"].Visible = false;
                        //gvList.Columns["ItemCode"].Visible = false;
                        //string[] arr = { "CustomerID", "POHeaderID" };
                        //Functions.SetInvisible(ref gvList, arr);

                        gvList.BestFitColumns();
                    }
                }
                else
                {
                    gcList.DataSource = null;
                    MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't Search Pallet History!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            Int16 intCopies = Convert.ToInt16(barEditCopies.EditValue.ToString());
            //e.PrintDocument.PrinterSettings.Copies = 2;
            e.PrintDocument.PrinterSettings.Copies = intCopies;
        }
        private void frmPackingSummaryForCVE_Load(object sender, EventArgs e)
        {
            Initialized();
        }

        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchData();
        }

        private void barBtnExcelExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvList.RowCount <= 0)
                    return;

                Functions.ExportToExcel(saveFileDialog1, gvList, this.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Could not export to excel file." + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barBtnPrintPacking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvList.RowCount == 0) return;

                int rowHandle = gvList.FocusedRowHandle;
                decimal palletNo = Convert.ToDecimal(gvList.GetRowCellValue(rowHandle, "PalletNo"));
                prtPackingList rpt = new prtPackingList();
                rpt.Parameters["palletNo"].Value = palletNo;
                rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                rpt.Print();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Could not print packing list." + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barBtnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvList.RowCount == 0) return;

                int rowHandle = gvList.FocusedRowHandle;
                decimal palletNo = Convert.ToDecimal(gvList.GetRowCellValue(rowHandle, "PalletNo"));
                prtPackingList rpt = new prtPackingList();
                rpt.Parameters["palletNo"].Value = palletNo;
                rpt.ShowPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Could not preview packing list." + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}