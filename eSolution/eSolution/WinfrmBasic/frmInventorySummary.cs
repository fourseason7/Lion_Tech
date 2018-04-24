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
using DevExpress.XtraGrid.Views.Base;
using eSolution.Database;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace eSolution.WinfrmBasic
{
    public partial class frmInventorySummary : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();
        public frmInventorySummary()
        {
            InitializeComponent();
        }
        public void Initialized()
        {
            //gcTotal.DataSource = null;
            //GridView view = new GridView(gcTotal);
            ////view.OptionsView.ShowGroupPanel = false;
            ////view.OptionsView.ShowColumnHeaders = false;
            //gcTotal.MainView = view;

            Functions.QueryCmbCustomerList(db, ref lueSearchCustomer, true);
            string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
            Functions.QueryCmbUserCodeData(db, ref lueSearchPOType, lueSearchPOType.Tag.ToString(), "", true);
            string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();

            //dtSearchDateFrom.EditValue = Convert.ToDateTime(db.fn_ServerDateTime()).AddDays(-90);
            dtSearchDateFrom.EditValue = Convert.ToDateTime("01/01/2010");
            dtSearchDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtSearchDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";

            //dtSearchDateTo.EditValue = (DateTime?)db.fn_ServerDateTime();
            dtSearchDateTo.EditValue = Convert.ToDateTime(db.fn_ServerDateTime());
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

            barEditYieldRate.EditValue = 85;
        }

        public void exportToExcel( )
        {
            using (var saveDialog = new SaveFileDialog())
            {
                DialogResult dialogResult = default(DialogResult);
                var _with1 = saveDialog;

                _with1.Filter = "Microsoft Excel|*.xls";
                _with1.Title = "Save as Excel";
                _with1.FileName = string.Format("{0}_{1}", this.Text, DateTime.Today.ToString("yyyyMMdd"));
                _with1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (_with1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var printingSystem = new PrintingSystemBase();
                        var compositeLink = new CompositeLinkBase();
                        compositeLink.PrintingSystemBase = printingSystem;

                        var link1 = new PrintableComponentLinkBase();
                        link1.Component = gcTotal;
                        //link1.PaperName = gcTotal.Tag.ToString();
                        var link2 = new PrintableComponentLinkBase();
                        link2.Component = gcDetail;
                        //link2.PaperName = gcDetail.Tag.ToString();
                        var link3 = new PrintableComponentLinkBase();
                        link3.Component = gcCandidate;
                        //link3.PaperName = gcCandidate.Tag.ToString();

                        compositeLink.Links.Add(link1);
                        compositeLink.Links.Add(link2);
                        compositeLink.Links.Add(link3);


                        var options = new XlsxExportOptions();
                        options.ExportMode = XlsxExportMode.SingleFilePageByPage;

                        compositeLink.CreatePageForEachLink();
                        compositeLink.ExportToXlsx(_with1.FileName, options);

                        string strexcelversion = Functions.GetOfficeVersion();
                        if (int.Parse(strexcelversion) >= 2007)
                        {
                            Microsoft.Office.Interop.Excel.Application exc = new Microsoft.Office.Interop.Excel.Application();
                            Microsoft.Office.Interop.Excel.Workbook workbook = exc.Workbooks.Open(_with1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                            Microsoft.Office.Interop.Excel.Sheets sheets = workbook.Worksheets;

                            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)(sheets[1]);
                            Microsoft.Office.Interop.Excel.Worksheet sheet2 = (Microsoft.Office.Interop.Excel.Worksheet)(sheets[2]);
                            Microsoft.Office.Interop.Excel.Worksheet sheet3 = (Microsoft.Office.Interop.Excel.Worksheet)(sheets[3]);

                            sheet1.Name = gcTotal.Tag.ToString();
                            sheet2.Name = gcDetail.Tag.ToString();
                            sheet3.Name = gcCandidate.Tag.ToString();

                            workbook.Close(true, Type.Missing, Type.Missing);
                            exc.Quit();
                        }

                        //System.Diagnostics.Process.Start(_with1.FileName);

                        DialogResult = XtraMessageBox.Show("Do you want to open this file?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (DialogResult == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(_with1.FileName);
                        }
                        else
                        {
                            XtraMessageBox.Show("Export Succeeded!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Could not export to excel file." + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
        public void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime dtFromDate, dtToDate;
            string strFromDate, strToDate;
            string strSearchCustomer;
            decimal decYieldRate;
            
            gcTotal.DataSource = null;
            gcCandidate.DataSource = null;
            gcDetail.DataSource = null;
            gvTotal.PopulateColumns();
            gvCandidate.PopulateColumns();
            gvDetail.PopulateColumns();
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
                string strSearchPOtype = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                if (string.IsNullOrEmpty(strSearchPOtype))
                    strSearchPOtype = "%";


                try
                {
                    decYieldRate = Convert.ToDecimal(barEditYieldRate.EditValue.ToString()) / 100;
                }
                catch
                {
                    decYieldRate = 0;
                }
                    


                var qryTotal = db.stp_InventorySummary_Total(dtFromDate, dtToDate, strSearchCustomer, strSearchPOtype);
                //var qry = db.stp_POHeader_Select(dtFromDate, dtToDate, strSearchCustomer, strSearchPOtype, strSearchPONumber, strSearchStatus);

                if (qryTotal != null)
                {
                    gcTotal.DataSource = qryTotal.ToList();
                    if (gvTotal.RowCount > 0)
                    {

                        gvTotal.FocusedRowHandle = -1;
                        //string[] arr = { "CustomerID", "POHeaderID" };
                        //Functions.SetInvisible(ref gvTotal, arr);

                        // Set Display format
                        gvTotal.Columns["Regular"].DisplayFormat.FormatString = "#,##0";
                        gvTotal.Columns["Regular"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvTotal.Columns["FCL"].DisplayFormat.FormatString = "#,##0";
                        gvTotal.Columns["FCL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvTotal.Columns["RMA"].DisplayFormat.FormatString = "#,##0";
                        gvTotal.Columns["RMA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvTotal.Columns["Total"].DisplayFormat.FormatString = "#,##0";
                        gvTotal.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvTotal.OptionsView.ShowFooter = true;
                        //gvTotal.Columns["Regular"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        //gvTotal.Columns["Regular"].SummaryItem.FieldName = "Regular";
                        //gvTotal.Columns["Regular"].SummaryItem.DisplayFormat = "SUM={0;#,##}";
                        gvTotal.Columns["Regular"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Regular", "{0:#,##0}");
                        gvTotal.Columns["FCL"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "FCL", "{0:#,##0}");
                        gvTotal.Columns["RMA"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "RMA", "{0:#,##0}");
                        gvTotal.Columns["Total"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:#,##0}");

                        gvTotal.BestFitColumns();
                        gvTotal.OptionsBehavior.ReadOnly = true;
                        gvTotal.FocusedRowHandle = 0;

                    }
                }
                else
                {
                    gcTotal.DataSource = null;
                    //MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

               var qryCandidate = db.stp_InventorySummary_Canidate(dtFromDate, dtToDate, strSearchCustomer, strSearchPOtype, decYieldRate );
                if (qryCandidate != null)
                {
                    gcCandidate.DataSource = qryCandidate.ToList();
                    if (gvCandidate.RowCount > 0)
                    {

                        gvCandidate.FocusedRowHandle = -1;
                        //string[] arr = { "CustomerCode" };
                        //Functions.SetInvisible(ref gvTotal, arr);

                        gvCandidate.Columns["Regular"].DisplayFormat.FormatString = "#,##0";
                        gvCandidate.Columns["Regular"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvCandidate.Columns["FCL"].DisplayFormat.FormatString = "#,##0";
                        gvCandidate.Columns["FCL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvCandidate.Columns["RMA"].DisplayFormat.FormatString = "#,##0";
                        gvCandidate.Columns["RMA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvCandidate.Columns["Total"].DisplayFormat.FormatString = "#,##0";
                        gvCandidate.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvCandidate.OptionsView.ShowFooter = true;
                        gvCandidate.Columns["Regular"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Regular", "{0:#,##0}");
                        gvCandidate.Columns["FCL"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "FCL", "{0:#,##0}");
                        gvCandidate.Columns["RMA"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "RMA", "{0:#,##0}");
                        gvCandidate.Columns["Total"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:#,##0}");


                        gvCandidate.BestFitColumns();
                        gvCandidate.OptionsBehavior.ReadOnly = true;
                        gvCandidate.FocusedRowHandle = 0;

                    }
                }
                else
                {
                    gcCandidate.DataSource = null;
                    //MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                var qryDetail = db.stp_InventorySummary_Detail(dtFromDate, dtToDate, strSearchCustomer, strSearchPOtype);
                //var qry = db.stp_POHeader_Select(dtFromDate, dtToDate, strSearchCustomer, strSearchPOtype, strSearchPONumber, strSearchStatus);

                if (qryDetail != null)
                {
                    gcDetail.DataSource = qryDetail.ToList();
                    if (gvDetail.RowCount > 0)
                    {

                        gvDetail.FocusedRowHandle = -1;
                        string[] arr = { "CustomerCode"};
                        Functions.SetInvisible(ref gvTotal, arr);


                        gvDetail.Columns["Regular"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["Regular"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvDetail.Columns["FCL"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["FCL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvDetail.Columns["RMA"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["RMA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvDetail.Columns["Total"].DisplayFormat.FormatString = "#,##0";
                        gvDetail.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvDetail.OptionsView.ShowFooter = true;
                        gvDetail.Columns["Regular"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Regular", "{0:#,##0}");
                        gvDetail.Columns["FCL"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "FCL", "{0:#,##0}");
                        gvDetail.Columns["RMA"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "RMA", "{0:#,##0}");
                        gvDetail.Columns["Total"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:#,##0}");

                        gvDetail.BestFitColumns();
                        gvDetail.OptionsBehavior.ReadOnly = true;
                        gvDetail.FocusedRowHandle = 0;

                    }
                }
                else
                {
                    gcDetail.DataSource = null;
                    //MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Initialized();
            SearchData();
        }

        private void frmInventorySummary_Load(object sender, EventArgs e)
        {
            Initialized();
        }

        private void gvTotal_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            e.Handled = true;
        }

        private void gvCandidate_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            e.Handled = true;
        }

        private void gvDetail_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            e.Handled = true;
        }

        private void gvTotal_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            Functions.AddingRowNumber(sender, e);
        }

        private void gvCandidate_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            Functions.AddingRowNumber(sender, e);
        }

        private void gvDetail_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            Functions.AddingRowNumber(sender, e);
        }

        private void gvTotal_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                gvTotal.FocusedRowHandle -= 1;
            }
            else if (e.Delta < 0)
            {
                gvTotal.FocusedRowHandle += 1;
            }
        }

        private void gvCandidate_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                gvCandidate.FocusedRowHandle -= 1;
            }
            else if (e.Delta < 0)
            {
                gvCandidate.FocusedRowHandle += 1;
            }
        }

        private void gvDetail_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                gvDetail.FocusedRowHandle -= 1;
            }
            else if (e.Delta < 0)
            {
                gvDetail.FocusedRowHandle += 1;
            }
        }

        private void gvDetail_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridView = ((GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
        }

        private void gvCandidate_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridView = ((GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
        }

        private void gvTotal_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridView = ((GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
        }

        private void barBtnExcelExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvTotal.RowCount <= 0)
                    return;

                string fileName = this.Name;



                exportToExcel();

                //Functions.ExportToExcel(saveFileDialog1, gvList, fileName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Could not export to excel file." + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}