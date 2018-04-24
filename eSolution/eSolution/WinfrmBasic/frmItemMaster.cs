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
using DevExpress.XtraGrid;
using eSolution.Database;
using System.Transactions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;

namespace eSolution
{
    public partial class frmItemMaster : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();
        string strModifiedFlag = "E";

        public void ResetDetial()
        {
            lueItemID.Text = "0";
            lueItemCode.Text = "";
            lueItemDescription.Text = "";
            lueUseYN.Text = "";
        }
        public void Initialized()
        {
            // Search Group
            Functions.QueryCmbItemType(db, ref lueSearchItemType, true);
            Functions.QueryCmbSetYesNoAll(ref lueSearchUseYN);

            // Detail 
            Functions.QueryCmbItemType(db, ref lueItemType, false);
            Functions.QueryCmbSetYesNo(ref lueUseYN);

            lueSearchItem.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchItem.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchItemType.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchItemType.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;
            
            lueSearchUseYN.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchUseYN.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueItemCode.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueItemCode.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueItemDescription.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueItemDescription.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueItemType.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueItemType.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueUseYN.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueUseYN.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            gvList.PopulateColumns();
        }
        public void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            string strSearchItem;
            string strSearhItemType;
            string strSearchUseYN;

            ResetDetial();

            try
            {
                strSearchItem = lueSearchItem.EditValue.ToString();
                if (string.IsNullOrEmpty(strSearchItem)) strSearchItem = "%";

                strSearhItemType = lueSearchItemType.Properties.GetKeyValueByDisplayText(lueSearchItemType.Text).ToString();
                if (string.IsNullOrEmpty(strSearhItemType)) strSearhItemType = "%";

                strSearchUseYN = lueSearchUseYN.Properties.GetKeyValueByDisplayText(lueSearchUseYN.Text).ToString();
                if (string.IsNullOrEmpty(strSearchUseYN)) strSearchUseYN = "%";

                //if (strSearchUseYN == "%")
                //{
                //    strSearchUseYN = "";
                //}

                var qry = db.stp_ItemMaster_Select(strSearchItem, strSearhItemType, strSearchUseYN).ToList();
                //var qry = from obj in db.ItemMasters
                //          where (obj.ItemCode.Contains(strSearchItem) || obj.ItemDescription.Contains(strSearchItem))
                //          && obj.ItemType.Contains(strSearhItemType)
                //          && (obj.UseYN == true ? "Y" : "N").Contains(strSearchUseYN)
                //          select new
                //          {
                //              ItemID = obj.ItemID
                //              ,
                //              ItemCode = obj.ItemCode
                //              ,
                //              ItemDescription = obj.ItemDescription
                //              ,
                //              ItemType = obj.ItemType
                //              ,
                //              UseYN = obj.UseYN
                //          };
                if (qry.Count() > 0)
                {
                    gcList.DataSource = qry;
                    //gcList.View.FocusedRowHandle = 0;
                    string[] arr = {"ItemID", "ItemType"};
                    Functions.SetInvisible(ref gvList, arr);
                    gvList.BestFitColumns();

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
                MessageBox.Show("Couldn't Search Item List!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public Boolean ValidateData()
        {
            try
            {
                string strItemID = lueItemID.EditValue.ToString();

                Int16 intItemID = Convert.ToInt16(strItemID);
                string strItemCode = lueItemCode.EditValue.ToString();

                strItemCode.Replace(" ", "");
                strItemCode = strItemCode.ToUpper();
                if (string.IsNullOrEmpty(strItemCode))
                {
                    XtraMessageBox.Show("Please, check the Item Code.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueItemCode.Focus();
                    return false;
                }
                string strItemDescription = lueItemDescription.EditValue.ToString();
                if (string.IsNullOrEmpty(strItemDescription))
                {
                    XtraMessageBox.Show("Please, check the Item Description.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueItemDescription.Focus();
                    return false;
                }
                string strItemType = lueItemType.EditValue.ToString();
                if (string.IsNullOrEmpty(strItemType))
                {
                    XtraMessageBox.Show("Please, check the Item Type.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueItemType.Focus();
                    return false;
                }
                string strUseYN = lueUseYN.EditValue.ToString();
                //Boolean blnUseYN;
                //if (strUseYN == "Y")
                //{
                //    blnUseYN = true;
                //}
                //else
                //{
                //    blnUseYN = false;
                //}
                if (string.IsNullOrEmpty(strUseYN))
                {
                    XtraMessageBox.Show("Please, check the Item Code.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueUseYN.Focus();
                    return false;
                }
                return true;

            }
            catch
            {
                XtraMessageBox.Show("Unexpected issue when validate!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }
        public Boolean SaveData()
        {
            if (Validate() == false)
            {
                return false;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                {
                    using (eSolutionDataContext db = new eSolutionDataContext())
                    {
                        string strItemID = lueItemID.EditValue.ToString();
                        Int16 intItemID = Convert.ToInt16(strItemID);
                        string strItemCode = lueItemCode.EditValue.ToString();
                        strItemCode.Replace(" ", "");
                        strItemCode = strItemCode.ToUpper();
                        string strItemDescription = lueItemDescription.EditValue.ToString();
                        string strItemType = lueItemType.EditValue.ToString();
                        string strUseYN = lueUseYN.EditValue.ToString();
                        Boolean blnUseYN;
                        if (strUseYN == "Y")
                        {
                            blnUseYN = true;
                        }
                        else 
                        {
                            blnUseYN = false;
                        }

                        if (strModifiedFlag == "A")
                        { 
                            // new add row
                            var qryCount = (from obj in db.ItemMasters
                                            where obj.ItemCode.Replace(" ", "").ToUpper() == strItemCode 
                                            && obj.ItemType == strItemType
                                            select obj).Count();
                            if (qryCount > 0)
                            {
                                MessageBox.Show("Already regist Item Code in Database." + Environment.NewLine + "Please, check the Item List!",
                                    "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                            ItemMaster itemMaster = new ItemMaster();
                            itemMaster.ItemCode = strItemCode;
                            itemMaster.ItemDescription = strItemDescription;
                            itemMaster.UseYN = blnUseYN;
                            itemMaster.ItemType = strItemType;

                            db.ItemMasters.InsertOnSubmit(itemMaster);
                        }
                        else
                        { 
                            // modified data
                            var qry = (from obj in db.ItemMasters
                                       where obj.ItemID == intItemID
                                       select obj).FirstOrDefault();
                            if (qry == null)
                            {
                                MessageBox.Show("Not exists Model Code." + Environment.NewLine + "Please, check the Item List!",
                                    "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                            qry.ItemCode = strItemCode;
                            qry.ItemDescription = strItemDescription;
                            qry.ItemType = strItemType;
                            qry.UseYN = blnUseYN;
                        }
                        db.SubmitChanges();
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
                Cursor.Current = Cursors.Default;
            }
            return true;
        }
        public frmItemMaster()
        {
            InitializeComponent();
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            Initialized();
        }

      
        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SearchData();
            //Cursor.Current = Cursors.WaitCursor;
            //string strSearchItem;
            //string strUseYN;

            //ResetDetial();

            //try
            //{
            //    strSearchItem = lueSearchItem.EditValue.ToString();
            //    strUseYN = lueSearchUseYN.Properties.GetKeyValueByDisplayText(lueSearchUseYN.Text).ToString();
            //    if (strUseYN == "%")
            //    {
            //        strUseYN = "";
            //    }

            //    var qry = from obj in db.ItemMasters
            //              where (obj.ItemCode.Contains(strSearchItem) || obj.ItemDescription.Contains(strSearchItem))
            //              && (obj.UseYN == true?"Y":"N").Contains(strUseYN)
            //              select new
            //              {
            //                  ItemID = obj.ItemID
            //                  , ItemCode = obj.ItemCode
            //                  , ItemDescription = obj.ItemDescription
            //                  , ItemType = obj.ItemType
            //                  , UseYN = obj.UseYN
            //              };
            //    if (qry.Count() > 0)
            //    {
            //        gcList.DataSource = qry;
            //    }
            //    else
            //    {
            //        gcList.DataSource = null;
            //        MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Couldn't Search Item List!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //finally
            //{
            //    Cursor.Current = Cursors.Default;
            //}

        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string strItemID;
            string strItemCode;
            string strItemDescription;
            string strItemType;
            string strUseYN;
            Boolean blnUseYN;
            try
            {
                if (gvList.RowCount > 0)
                {
                    strItemID = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("ItemID").ToString();
                    strItemCode = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("ItemCode").ToString();
                    strItemDescription = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("ItemDescription").ToString();
                    strItemType = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("ItemType").ToString();
                    blnUseYN = Convert.ToBoolean((sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("UseYN").ToString());
                    if (blnUseYN == true)
                    {
                        strUseYN = "Y";
                    }
                    else
                    {
                        strUseYN = "N";
                    }

                    lueItemID.Text = strItemID;
                    lueItemCode.Text = strItemCode;
                    lueItemDescription.Text = strItemDescription;
                    //lueItemType.Text = strItemType;
                    //lueUseYN.Text = strUseYN;
                    lueItemType.EditValue = strItemType;
                    lueUseYN.EditValue = strUseYN;

                    strModifiedFlag = "E";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceiption Error!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            strModifiedFlag = "A";
            ResetDetial();
            lueItemCode.Focus();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean blnResult = false;
            blnResult = ValidateData();
            if (blnResult == false) return;

            blnResult = SaveData();
            if (blnResult == true )
            {
                // Refresh list
                btnSearch.PerformClick();
            }
        }

        private void gvList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            Functions.AddingRowNumber(sender, e);
        }

        private void gvList_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                gvList.FocusedRowHandle -= 1;
            }
            else if (e.Delta < 0)
            {
                gvList.FocusedRowHandle += 1;
            }
        }

 
        private void gvList_RowCountChanged(object sender, EventArgs e)
        {
            //GridView gridView = ((GridView)sender);
            //if (!gridView.GridControl.IsHandleCreated) return;
            //Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            //SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            //gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;

            Functions.gvRowCountChanged(sender, e);
        }

        private void gvList_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
        }
    }
}