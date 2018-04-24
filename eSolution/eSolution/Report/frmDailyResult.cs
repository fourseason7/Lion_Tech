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
using DevExpress.XtraGrid;

namespace eSolution.WinfrmBasic
{
    public partial class frmDailyResult : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();
        public event EventHandler leNameEditvalueChanged;

        public frmDailyResult()
        {
            InitializeComponent();
        }
        public void Initialized()
        {
            //Search Group
            Functions.QueryCheckCmbCustomerList(db, ref lueSearchCustomer, false);
            Functions.QueryCheckCmbPOTypeList(db, ref lueSearchPOType, false);
            //string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();

            dtSearchDateFrom.EditValue = (DateTime?)db.fn_ServerDateTime();
            //dtSearchDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //dtSearchDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            dtSearchDateTo.EditValue = (DateTime?)db.fn_ServerDateTime();



            //lueSearchCustomer.Properties.AppearanceFocused.BackColor = Color.Yellow;
            //lueSearchCustomer.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;


            gvList.PopulateColumns();
        }

        private void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime dtFromDate, dtToDate;
            string strFromDate, strToDate;
            string strCompany = string.Empty;
            string strPOType = string.Empty;
            int intStatus = 0;

            try
            {
                dtFromDate = Convert.ToDateTime(dtSearchDateFrom.EditValue);
                dtToDate = Convert.ToDateTime(dtSearchDateTo.EditValue).AddDays(1);
                strFromDate = Functions.FunctionDateToString(dtFromDate, 0);
                strToDate = Functions.FunctionDateToString(dtToDate, 0);
                dtFromDate = Convert.ToDateTime(strFromDate);
                dtToDate = Convert.ToDateTime(strToDate);
                strCompany = Functions.GetcheckedComboBoxValue(lueSearchCustomer);
                strPOType = Functions.GetcheckedComboBoxValue(lueSearchPOType);

                if (chkPalletDate.Checked)
                {
                    intStatus = 1; // Available Pallet QTY
                }
                else
                {
                    intStatus = 0; // Period by Pallet Date
                }

                gvList.Columns.Clear();
                gcList.DataSource = null;

                if (rdbSummary.Checked)
                {
                    var qry = db.stp_DailyResult_By_Summary(dtFromDate, dtToDate, strCompany, strPOType, intStatus).ToList();
                    if (qry.Count() > 0)
                    {


                        gcList.DataSource = qry;
                        gvList.BestFitColumns();
                        gvList.OptionsBehavior.ReadOnly = true;
                        gvList.FocusedRowHandle = gvList.GetVisibleRowHandle(0);

                        gvList.Columns["QTY"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["QTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvList.OptionsView.ShowFooter = true;
                        gvList.Columns["QTY"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gvList.Columns["QTY"].SummaryItem.FieldName = "QTY";
                        gvList.Columns["QTY"].SummaryItem.DisplayFormat = "Total QTY: {0:n0}";

                    }
                    else
                    {
                        gcList.DataSource = null;
                        MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var qry = db.stp_DailyResult_By_Daily(dtFromDate, dtToDate, strCompany, strPOType).ToList();
                    if (qry.Count() > 0)
                    {
                        gcList.DataSource = qry;
                        gvList.BestFitColumns();
                        gvList.OptionsBehavior.ReadOnly = true;
                        gvList.FocusedRowHandle = gvList.GetVisibleRowHandle(0);

                        gvList.Columns["QTY"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["QTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        gvList.OptionsView.ShowFooter = true;
                        gvList.Columns["QTY"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gvList.Columns["QTY"].SummaryItem.FieldName = "QTY";
                        gvList.Columns["QTY"].SummaryItem.DisplayFormat = "Total QTY: {0:n0}";
                    }
                    else
                    {
                        gcList.DataSource = null;
                        MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
        private void frmDailyResult_Load(object sender, EventArgs e)
        {
            Initialized();
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchData();
        }

        private void barBtnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvList.RowCount <= 0)
                    return;

                string fileName = string.Empty;
                DateTime dtFromDate, dtToDate;

                string strFromDate = string.Empty;
                string strToDate = string.Empty;

                fileName = this.Text;

                dtFromDate = Convert.ToDateTime(dtSearchDateFrom.EditValue);
                dtToDate = Convert.ToDateTime(dtSearchDateTo.EditValue).AddDays(1);
                strFromDate = Functions.FunctionDateToString(dtFromDate, 1);
                strToDate = Functions.FunctionDateToString(dtToDate, 1);

                if (rdbSummary.Checked)
                {
                    fileName = fileName + "_Summary_" + strFromDate + "_" + strToDate;
                }
                else if (rdbDaily.Checked)
                {
                    fileName = fileName + "_Daily_" + strFromDate + "_" + strToDate;
                }
                //else
                //{ }


                Functions.ExportToExcel(saveFileDialog1, gvList, fileName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Could not export to excel file." + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvList_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                if (e.Column.FieldName == "Customer" || e.Column.FieldName == "POType" || e.Column.FieldName == "Model")
                {
                    string val1 = view.GetRowCellValue(e.RowHandle1, e.Column).ToString();
                    string val2 = view.GetRowCellValue(e.RowHandle2, e.Column).ToString();

                    e.Merge = (val1 == val2);
                    e.Handled = true;
                    return;
                }
            }
            catch(Exception ex)
            {
            
            }

        }

        private void chkPalletDate_Click(object sender, EventArgs e)
        {
            if (chkPalletDate.Checked)
            {
                dtSearchDateFrom.Enabled = true;
                dtSearchDateTo.Enabled = true;
            }
            else
            {
                dtSearchDateFrom.Enabled = false;
                dtSearchDateTo.Enabled = false;
            }
        }

        private void chkPalletDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.leNameEditvalueChanged != null)
                this.leNameEditvalueChanged(this, e);
        }

        private void lueSearchPOType_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                string[] checkedValues = e.Value.ToString().Split((sender as CheckedComboBoxEdit).Properties.SeparatorChar);
                if (checkedValues.Length == (sender as CheckedComboBoxEdit).Properties.Items.Count)
                {
                    e.DisplayText = "All";
                }
            }

        }
    }
}