using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Columns;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using eSolution.Database;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace eSolution
{
    class Functions
    {
        public static string GetOfficeVersion()
        {
            string sVersion = string.Empty;
            Microsoft.Office.Interop.Excel.Application appVersion = new Microsoft.Office.Interop.Excel.Application();
            appVersion.Visible = false;
            switch (appVersion.Version.ToString())
            {
                case "7.0":
                    sVersion = "95";
                    break;
                case "8.0":
                    sVersion = "97";
                    break;
                case "9.0":
                    sVersion = "2000";
                    break;
                case "10.0":
                    sVersion = "2002";
                    break;
                case "11.0":
                    sVersion = "2003";
                    break;
                case "12.0":
                    sVersion = "2007";
                    break;
                case "14.0":
                    sVersion = "2010";
                    break;
                case "15.0":
                    sVersion = "2013";
                    break;
                case "16.0":
                    sVersion = "2016";
                    break;
                default:
                    sVersion = "Too Old!";
                    break;
            }
            return sVersion;
            //Console.WriteLine("MS office version: " + sVersion);
            //return null;
        }

        public static void ExportToExcel(SaveFileDialog saveDialog, GridView gridView, string tabName)
        {
            DialogResult dialgResult = default(DialogResult);
            var _with1 = saveDialog;

            _with1.Filter = "Microsoft Excel|*.xls";
            _with1.Title = "Save as Excel";
            _with1.FileName = string.Format("{0}_{1}", tabName, DateTime.Today.ToString("yyyyMMdd"));
            _with1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (_with1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    gridView.ExportToXls(_with1.FileName);
                    dialgResult = XtraMessageBox.Show("Do you want to open this file?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dialgResult == DialogResult.Yes)
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
        public static string GetMessageFromException(ref Exception ex)
        {
            if (ex.InnerException == null)
            {
                return ex.Message;
            }
            else {
                return ex.InnerException.Message;
            }
        }
        public static void InitializeControlsClear(ref System.Windows.Forms.Control.ControlCollection ControlName)
        {
            try
            {
		        foreach (System.Windows.Forms.Control ctrl in ControlName) 
                {
			        if (ctrl is LookUpEdit) 
                    {
				        ((LookUpEdit)ctrl).ItemIndex = 0;
			        } 
                    else if (ctrl is TextEdit) 
                    {
				        ((TextEdit)ctrl).Text = string.Empty;
			        } 
                    else if (ctrl is DateEdit) 
                    {
				        ((DateEdit)ctrl).EditValue = DateTime.Today;
                    }
			    }
            }
            catch
            {
            }
        }
        public static void InitializeFocusControls(ref System.Windows.Forms.Control.ControlCollection ControlName)
        { 
            try
            {
                foreach (System.Windows.Forms.Control ctrl in ControlName)
                {
                    if (ctrl is DevExpress.XtraEditors.ImageComboBoxEdit)
                    {
                        ((ImageComboBoxEdit)ctrl).Properties.AppearanceFocused.BackColor = Color.Yellow;
                        ((ImageComboBoxEdit)ctrl).Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (ctrl is DateEdit)
                    {
                        ((DateEdit)ctrl).Properties.AppearanceFocused.BackColor = Color.Yellow;
                    }
                    else if (ctrl is LookUpEdit)
                    {
                        ((LookUpEdit)ctrl).Properties.AppearanceFocused.BackColor = Color.Yellow;
                        ((LookUpEdit)ctrl).Properties.NullText = string.Empty;
                    }
                    else if (ctrl is TextEdit)
                    {
                        ((TextEdit)ctrl).Text = string.Empty;
                        ((TextEdit)ctrl).Properties.AppearanceFocused.BackColor = Color.Yellow;
                        ((TextEdit)ctrl).Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;
                        ((TextEdit)ctrl).Properties.Mask.SaveLiteral = false;
                        ((TextEdit)ctrl).Properties.Mask.UseMaskAsDisplayFormat = true;
                    }
                    else if (ctrl is RadioGroup)
                    {
                        ((RadioGroup)ctrl).BackColor = Color.Transparent;
                        //((RadioGroup) ctrl).BorderStyle = Controls.BorderStyles.NoBorder;
                    }
                }
            }
            catch
            {
            }
        }

        public static DateTime GetSystemDateTime(ref eSolutionDataContext db)
        {
            return Convert.ToDateTime(db.stp_GetServerDatetime().SingleOrDefault().Now);
        }
        public static string FunctionDateToString(DateTime dtDate, Int16 formatType)
        {
            //string strReturn = dtDate.ToString("yyyyMMdd");
            string strReturn;
            switch (formatType)
            {
                case 1: //yyyyMMdd
                    strReturn = dtDate.ToString("yyyyMMdd");
                    break;
                case 2: //yyyy/MM/dd
                    strReturn = dtDate.ToString("yyyy/MM/dd");
                    break;
                case 3: //MM/dd/yyyy
                    strReturn = dtDate.ToString("dd/MM/yyyy");
                    break;
                default:
                    strReturn = dtDate.ToString("MM/dd/yyyy");
                    break;
            }
            return strReturn;
        }
        public static void DefineGridView(ref GridView GridViewName)
        {
            {
                //Make gridview readonly
                using (GridView gv = GridViewName)
                {
                    gv.OptionsBehavior.Editable = false;
                    gv.OptionsBehavior.ReadOnly = true;
                    gv.OptionsView.ColumnAutoWidth = true;
                    gv.OptionsView.EnableAppearanceEvenRow = true;
                    gv.IndicatorWidth = 45;
                    gv.OptionsSelection.MultiSelect = true;
                    gv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                    gv.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
                    //.OptionsView.ShowGroupPanel = False

                    //int intFontSize = GetSetting("TMS", "Font", "Size", "8");
                    int intFontSize = 10;
                    gv.Appearance.HeaderPanel.Font = new Font("Tahoma", intFontSize);
                    gv.Appearance.Row.Font = new Font("Tahoma", intFontSize);
                }
            }
        }
        public static void DefineGridViewAllowEdit(ref DevExpress.XtraGrid.Views.Grid.GridView gridViewName)
        {
            {
                //Prevent set column width automatically as same size 
                gridViewName.OptionsView.ColumnAutoWidth = true;
                //Give color for each even row 
                gridViewName.OptionsView.EnableAppearanceEvenRow = true;

                gridViewName.IndicatorWidth = 45;

                //int intFontSize = GetSetting("TMS", "Font", "Size", "8");
                int intFontSize = 10;
                gridViewName.Appearance.HeaderPanel.Font = new Font("Tahoma", intFontSize);
                gridViewName.Appearance.Row.Font = new Font("Tahoma", intFontSize);
                //Set each column size based on data of each column
            }
        }
        public static void SetGridModifyAllow(ref GridView GridViewName, string[] AllowEditColumnNames)
        {
            {
                for (int i = 0; i <= GridViewName.Columns.Count - 1; i++)
                {
                    GridViewName.Columns[i].OptionsColumn.AllowEdit = true;
                    GridViewName.Columns[i].OptionsColumn.ReadOnly = true;
                }
                if (GridViewName.Columns.Count > 0)
                {
                    for (int i = 0; i <= AllowEditColumnNames.Length - 1; i++)
                    {
                        try
                        {
                            GridViewName.Columns[AllowEditColumnNames[i]].OptionsColumn.AllowEdit = true;
                            GridViewName.Columns[AllowEditColumnNames[i]].OptionsColumn.ReadOnly = false;
                            GridViewName.Columns[AllowEditColumnNames[i]].AppearanceCell.BackColor = Color.FromArgb(0xed, 0xf6, 0xff);

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    //int intFontSize = GetSetting("TMS", "Font", "Size", "8");
                    int intFontSize = 10;
                    GridViewName.Appearance.HeaderPanel.Font = new Font("Tahoma", intFontSize);
                    GridViewName.Appearance.Row.Font = new Font("Tahoma", intFontSize);
                    GridViewName.BestFitColumns();
                }

            }
        }
        public static void SetGridModifyAllowUpdate(ref GridView GridViewName, string[] AllowEditColumnNames)
        {
            {
                for (int i = 0; i <= GridViewName.Columns.Count - 1; i++)
                {
                    GridViewName.Columns[i].OptionsColumn.AllowEdit = false;
                    GridViewName.Columns[i].OptionsColumn.ReadOnly = true;
                }
                if (GridViewName.Columns.Count > 0)
                {
                    for (int i = 0; i <= AllowEditColumnNames.Length - 1; i++)
                    {
                        try
                        {
                            GridViewName.Columns[AllowEditColumnNames[i]].OptionsColumn.AllowEdit = true;
                            GridViewName.Columns[AllowEditColumnNames[i]].OptionsColumn.ReadOnly = false;
                            GridViewName.Columns[AllowEditColumnNames[i]].AppearanceCell.BackColor = Color.FromArgb(0xed, 0xf6, 0xff);

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    //int intFontSize = GetSetting("TMS", "Font", "Size", "8");
                    int intFontSize = 10;
                    GridViewName.Appearance.HeaderPanel.Font = new Font("Tahoma", intFontSize);
                    GridViewName.Appearance.Row.Font = new Font("Tahoma", intFontSize);
                    //.BestFitColumns()
                    GridViewName.OptionsSelection.MultiSelect = true;
                    GridViewName.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                    GridViewName.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
                }

            }
        }
        public static void SetGridModifyDenyAll(ref GridView GridViewName)
        {
            try
            {
                {
                    for (int i = 0; i <= GridViewName.Columns.Count - 1; i++)
                    {
                        GridViewName.Columns[i].OptionsColumn.AllowEdit = false;
                        GridViewName.Columns[i].OptionsColumn.ReadOnly = true;
                    }
                }
            }
            //catch (ApplicationException ex)
            catch
            {
                //GatheringErrorInfo(Me, ex)
            }
            finally
            {
            }
        }

        public static void gvRowCountChanged(System.Object sender, EventArgs e)
        {
            GridView gridView = ((GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
        }
        public static void AddingRowNumber(System.Object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;
            if ((e.Info.IsRowIndicator & e.RowHandle > -1))
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                e.Info.DisplayText = (e.RowHandle + 1).ToString("#,##0");
            }
        }
        public static void SetReadOnly(ref GridView GridViewName)
        {
            using (GridView gv = GridViewName)
            {
                gv.OptionsSelection.MultiSelect = true;
                gv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                gv.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
                gv.OptionsBehavior.Editable = false;
                gv.OptionsBehavior.ReadOnly = true;
            }
        }
        public static void SetInvisible(ref GridView GridViewName, string[] InvisiableColumnNames)
        {
            if (GridViewName.RowCount > 0)
            {
                for(int i = 0; i< InvisiableColumnNames.Length;i++)
                {
                    try
                    {
                        GridViewName.Columns[InvisiableColumnNames[i]].Visible = false;
                    }
                    catch
                    {
                    }
                }
            }
        }
        public static void SetCurrencyColumn(ref GridView GridViewName, string[] CurrencyColumnNames)
        {
            using (GridView gv = GridViewName)
            {
                if (gv.RowCount > 0)
                {
                    for(int i = 0; i< CurrencyColumnNames.Length;i++)
                    {
                        try
                        {
                            gv.Columns[CurrencyColumnNames[i]].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            gv.Columns[CurrencyColumnNames[i]].DisplayFormat.FormatString = "c2";
                            gv.Columns[CurrencyColumnNames[i]].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gv.Columns[CurrencyColumnNames[i]].SummaryItem.DisplayFormat = "{0:c2}";
                        }
                        catch
                        {
                        }
                    }
                }
                gv.BestFitColumns();
            }
        }
        public static void QueryCmbOpenClosedAll(ref LookUpEdit cmbName)
        {
            DataTable dt = DatabaseHelper.GetCodeValueOpenClosedNoAll();
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbOpenClosed(ref LookUpEdit cmbName)
        {
            DataTable dt = DatabaseHelper.GetCodeValueSetOpenClosedByBoolean();
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbSetYesNoAll(ref LookUpEdit cmbName)
        {
            DataTable dt = DatabaseHelper.GetCodeValueSetYesNoAll();
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbSetYesNo(ref LookUpEdit cmbName)
        {
            DataTable dt = DatabaseHelper.GetCodeValueSetYesNo();
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbSetYesNoBoolean(ref LookUpEdit cmbName)
        {
            DataTable dt = DatabaseHelper.GetCodeValueSetYesNoByBoolean();
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbShippingType(ref LookUpEdit cmbName)
        {
            DataTable dt = DatabaseHelper.GetCodeShippingType();
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbCustomerItemList(eSolutionDataContext db, ref LookUpEdit cmbName, string CustomerCode, string RSType = "S")
        {
            DataTable dt = DatabaseHelper.GetCustomerItemList(db, CustomerCode, RSType);

            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbItemType(eSolutionDataContext db, ref LookUpEdit cmbName, Boolean argALL = false)
        {
            DataTable dt = DatabaseHelper.GetUserCodeData(db, cmbName.Tag.ToString(), "", argALL);

            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }

        public static void QueryCmbItemCode(eSolutionDataContext db, ref LookUpEdit cmbName, Boolean argAll = false)
        {
            DataTable dt = DatabaseHelper.GetItemCode(db, cmbName.Tag.ToString());

            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbShippingStatus(eSolutionDataContext db, ref LookUpEdit cmbName, string codeGroup = "", Boolean argAll = false)
        {
            DataTable dt = DatabaseHelper.GetUserCodeData(db, cmbName.Tag.ToString(), codeGroup);

            cmbName.Properties.DataSource = null;
            try
            {
                cmbName.Properties.ValueMember = string.Empty;
                cmbName.Properties.DisplayMember = string.Empty;
            }
            catch
            {
            }
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }

        public static void QueryCmbCustomerList(eSolutionDataContext db, ref LookUpEdit cmbName, Boolean argAll = false)
        {
            DataTable dt = DatabaseHelper.GetCustomerList(db, argAll);

            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCheckCmbCustomerList(eSolutionDataContext db, ref CheckedComboBoxEdit cmbName, Boolean argAll = false)
        {
            DataTable dt = DatabaseHelper.GetCustomerListByID(db, argAll);

            cmbName.Properties.Items.Clear();
            cmbName.Properties.DataSource = null;

            if (dt.Rows.Count > 0)
            {
                cmbName.Properties.DataSource = dt;
                cmbName.Properties.ValueMember = "ValueMember";
                cmbName.Properties.DisplayMember = "DisplayMember";
                cmbName.Properties.Items.Add("Value", CheckState.Unchecked, true);
                cmbName.CheckAll();
                cmbName.SetEditValue(0);
                cmbName.CheckAll();
            }
            else
            {
                cmbName.SetEditValue(null);
            }
            cmbName.Properties.PopupControl = null;
            cmbName.Properties.SeparatorChar = ';';
            cmbName.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;

        }
        public static void QueryCheckCmbPOTypeList(eSolutionDataContext db, ref CheckedComboBoxEdit cmbName, Boolean argAll = false)
        {
            DataTable dt = DatabaseHelper.GetUserCodeData(db, "POTYPE", "COMMON", false);

            cmbName.Properties.Items.Clear();
            cmbName.Properties.DataSource = null;

            if (dt.Rows.Count > 0)
            {
                cmbName.Properties.DataSource = dt;
                cmbName.Properties.ValueMember = "ValueMember";
                cmbName.Properties.DisplayMember = "DisplayMember";
                cmbName.Properties.Items.Add("Value", CheckState.Unchecked, true);
                cmbName.CheckAll();
                cmbName.SetEditValue(0);
                cmbName.CheckAll();
            }
            else
            {
                cmbName.SetEditValue(null);
            }
            cmbName.Properties.PopupControl = null;
            cmbName.Properties.SeparatorChar = ';';
            cmbName.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;

        }
        public static void QueryCmbAvailablePOList(eSolutionDataContext db, ref LookUpEdit cmbName)
        {
            DataTable dt = DatabaseHelper.GetCodeAvailablePOList(db);
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbAvailablePOList(eSolutionDataContext db, ref LookUpEdit cmbName, string customerCode, string pOType, string pOStatus, Boolean allFlag)
        {
            DataTable dt = DatabaseHelper.GetCodeAvailablePOList(db, customerCode, pOType, pOStatus, allFlag );
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbUserCodeData(eSolutionDataContext db, ref LookUpEdit cmbName, string tableName)
        {
            DataTable dt = DatabaseHelper.GetUserCodeData(db, tableName);
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbUserCodeData(eSolutionDataContext db, ref LookUpEdit cmbName, string tableName, string codeGroup = "", Boolean allFlag = false)
        {
            DataTable dt = DatabaseHelper.GetUserCodeData(db, tableName, codeGroup, allFlag);
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }
        public static void QueryCmbState(eSolutionDataContext db, ref LookUpEdit cmbName, Boolean allFlag = false)
        {
            DataTable dt = DatabaseHelper.GetStateCode(db, allFlag);
            cmbName.Properties.DataSource = null;
            cmbName.Properties.ValueMember = string.Empty;
            cmbName.Properties.DisplayMember = string.Empty;
            cmbName.Properties.Columns.Clear();

            cmbName.Properties.DataSource = dt;
            cmbName.Properties.ValueMember = "ValueMember";
            cmbName.Properties.DisplayMember = "DisplayMember";
            cmbName.Properties.ForceInitialize();
            cmbName.Properties.PopulateColumns();
            cmbName.Properties.Columns["ValueMember"].Visible = false;
            cmbName.EditValue = cmbName.Properties.GetDataSourceValue(cmbName.Properties.ValueMember, 0);
        }

        public static void SetGridNullCheckColumnEditAllow(GridView gridViewName, string[] pArray)
        {
            var cursorCurrent = Cursor.Current;
            var rowHandle = gridViewName.FocusedRowHandle + 1;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                for (int i = 1; i < gridViewName.RowCount + 1; i++)
                {
                    for (int j = 0; j < pArray.Length; j++)
                    {
                        gridViewName.Columns[pArray[j]].OptionsColumn.AllowEdit = true;
                        gridViewName.Columns[pArray[j]].OptionsColumn.ReadOnly = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = cursorCurrent;
            }
        }

        public static List<object> checkedCMBEGetData(CheckedComboBoxEdit checkedCMBE)
        {
            try
            {
                return checkedCMBE.Properties.Items.GetCheckedValues();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetcheckedComboBoxValue(CheckedComboBoxEdit checkedCMBE)
        {
            string s = string.Empty;


            for (int i = 0; i < checkedCMBEGetData(checkedCMBE).Count; i++)
            {
                if (i == 0)
                {
                    s = s + checkedCMBEGetData(checkedCMBE)[i].ToString();
                }
                else
                {
                    s = s + "," + checkedCMBEGetData(checkedCMBE)[i].ToString();
                }
            }
            return s;
        }
        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;


                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }


                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
    }
}
