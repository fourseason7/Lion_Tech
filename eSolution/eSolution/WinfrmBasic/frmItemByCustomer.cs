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
    public partial class frmItemByCustomer : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();
        DataTable dataTable;
        string AddEditStatus = "N"; // N: No, A: Add, E: Edit
        Int16 itemDetailID;

        public frmItemByCustomer()
        {
            InitializeComponent();
        }
        private DataTable MakeNamesTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable namesTable = new DataTable("Names");

            // Add three column objects to the table.
            DataColumn CustomerCode = new DataColumn("CustomerCode");
            CustomerCode.DataType = System.Type.GetType("System.String");
            CustomerCode.Caption = "Customer Name";
            namesTable.Columns.Add(CustomerCode);

            DataColumn CustomerName = new DataColumn("CustomerName");
            CustomerName.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(CustomerName);

            DataColumn ItemID = new DataColumn("ItemID");
            ItemID.DataType = System.Type.GetType("System.Int16");
            ItemID.Caption = "Internal Item";
            namesTable.Columns.Add(ItemID);

            DataColumn ItemNumberID = new DataColumn("ItemNumberID");
            ItemNumberID.DataType = System.Type.GetType("System.Int16");
            ItemNumberID.Caption = "External Item";
            namesTable.Columns.Add(ItemNumberID);

            DataColumn InternalItem = new DataColumn("InternalItem");
            InternalItem.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(InternalItem);

            DataColumn ExternalItem = new DataColumn("ExternalItem");
            ExternalItem.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(ExternalItem);

            DataColumn ItemType = new DataColumn("ItemType");
            ItemType.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(ItemType);

            DataColumn ItemTypeName = new DataColumn("ItemTypeName");
            ItemTypeName.DataType = System.Type.GetType("System.String");
            ItemTypeName.Caption = "Item Type";
            namesTable.Columns.Add(ItemTypeName);

            DataColumn UseYN = new DataColumn("UseYN");
            UseYN.DataType = System.Type.GetType("System.Boolean");
            namesTable.Columns.Add(UseYN);

            DataColumn ItemDetailID = new DataColumn("ItemDetailID");
            ItemDetailID.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ItemDetailID);

            // Return the new DataTable.
            return namesTable;
        }
        private void CreateNewDataRow()
        {

            dataTable = MakeNamesTable();
            gcList.DataSource = dataTable;
            gvList.PopulateColumns();

        }
        public void Initialized()
        {
            //CreateNewDataRow();
            AddEditStatus = "N";

            Functions.QueryCmbCustomerList(db, ref lueSearchCustomer);
            string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();

            Functions.QueryCmbSetYesNoAll(ref lueSearchUseYN);

            lueSearchCustomer.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchCustomer.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSearchItemInternal.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSearchItemInternal.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSearchItemExternal.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSearchItemExternal.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchUseYN.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchUseYN.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            gvList.PopulateColumns();
        }
        
        public void InitialEditItem()
        {
            Functions.QueryCmbCustomerList(db, ref lueCustomer);
            Functions.QueryCmbItemCode(db, ref lueItemInternal);
            Functions.QueryCmbItemCode(db, ref lueItemExternal);
            Functions.QueryCmbItemType(db, ref lueItemType, false);
            Functions.QueryCmbSetYesNo(ref lueUseYN);

            lueCustomer.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueCustomer.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueItemInternal.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueItemInternal.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueItemExternal.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueItemExternal.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueItemType.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueItemType.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueUseYN.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueUseYN.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

        }

        public void MakeEnableDisableGroupControl(Boolean blnEnable = true)
        {
            if (blnEnable == true)
            {
                lueCustomer.Enabled = true;
                lueItemExternal.Enabled = true;
                lueItemInternal.Enabled = true;
                lueItemType.Enabled = true;
                lueUseYN.Enabled = true;
            }
            else
            {
                lueCustomer.Enabled = false;
                lueItemExternal.Enabled = false;
                lueItemInternal.Enabled = false;
                lueItemType.Enabled = false;
                lueUseYN.Enabled = false;
            }
        }

        private void AddDropDown()
        {
            repositoryItemLueCustomerCode.DataSource = DatabaseHelper.GetCustomerList(db);
            repositoryItemLueCustomerCode.ValueMember = "ValueMember";
            repositoryItemLueCustomerCode.DisplayMember = "DisplayMember";
            gvList.Columns["CustomerCode"].ColumnEdit = repositoryItemLueCustomerCode;
            repositoryItemLueCustomerCode.PopulateColumns();

            repositoryItemLueItemCode.DataSource = DatabaseHelper.GetItemCode(db, "I");
            repositoryItemLueItemCode.ValueMember = "ValueMember";
            repositoryItemLueItemCode.DisplayMember = "DisplayMember";
            //repositoryItemLueItemCode.PopulateColumns();
            gvList.Columns["ItemID"].ColumnEdit = repositoryItemLueItemCode;

            repositoryItemLueItemNumber.DataSource = DatabaseHelper.GetItemCode(db, "E");
            repositoryItemLueItemNumber.ValueMember = "ValueMember";
            repositoryItemLueItemNumber.DisplayMember = "DisplayMember";
            //repositoryItemLueItemNumber.PopulateColumns();
            gvList.Columns["ItemNumberID"].ColumnEdit = repositoryItemLueItemNumber;

            gvList.OptionsView.ColumnAutoWidth = true;

            //repositoryItemLueCustomerCode.NullText = "";
            //repositoryItemLueItemCode.NullText = "";
            //repositoryItemLueItemNumber.NullText = "";
        }
        public Boolean ValidateData()
        {
            try
            {
                string strCustomerCode = lueCustomer.EditValue.ToString();
                if (string.IsNullOrEmpty(strCustomerCode))
                {
                    XtraMessageBox.Show("Please, check the Customer Data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueCustomer.Focus();
                    return false;
                }
                string strItemInternal = lueItemInternal.EditValue.ToString();
                if (string.IsNullOrEmpty(strItemInternal))
                {
                    XtraMessageBox.Show("Please, check the Internal Item Code Data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueItemInternal.Focus();
                    return false;
                }
                string strItemExternal = lueItemExternal.EditValue.ToString();
                if (string.IsNullOrEmpty(strItemExternal))
                {
                    XtraMessageBox.Show("Please, check the External Item Code Data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueItemExternal.Focus();
                    return false;
                }
                string strItemType = lueItemType.EditValue.ToString();
                if (string.IsNullOrEmpty(strItemType))
                {
                    XtraMessageBox.Show("Please, check the Item Type!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueItemType.Focus();
                    return false;
                }
                string strUseYN = lueUseYN.EditValue.ToString();
                if (string.IsNullOrEmpty(strUseYN))
                {
                    XtraMessageBox.Show("Please, check the External Item Code Data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueUseYN.Focus();
                    return false;
                }

                if (AddEditStatus == "A")
                {
                    var qryCount = (from ibs in db.ItemByCustomers
                               from cst in db.Customers
                               where ibs.CustomerID == cst.CustomerID
                               && cst.CustomerCode == strCustomerCode
                               && ibs.ItemID == Convert.ToInt16(strItemInternal)
                               && ibs.ItemNumberID == Convert.ToInt16(strItemExternal)
                               select ibs).Count();
                    if (qryCount > 0)
                    {
                        XtraMessageBox.Show("Already Exists to Item by Customer!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lueCustomer.Focus();
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                string errMsg;
                if (ex.InnerException == null)
                {
                    errMsg = ex.Message.ToString();
                }
                else
                {
                    errMsg = ex.InnerException.ToString();
                }
                XtraMessageBox.Show("Please, check the data vlaidate!" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public Boolean SaveData()
        {
            Int16 intCustomerID, intItemID, intItemNumberID;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                {
                    using (eSolutionDataContext db = new eSolutionDataContext())
                    {
                        DateTime dtServerDate = Convert.ToDateTime(db.fn_ServerDateTime().ToString());
                        string strCustomerCode = lueCustomer.EditValue.ToString();
                        if (string.IsNullOrEmpty(strCustomerCode))
                        {
                            XtraMessageBox.Show("Please, check the Customer Data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lueCustomer.Focus();
                            return false;
                        }
                        string strItemInternal = lueItemInternal.EditValue.ToString();
                        if (string.IsNullOrEmpty(strItemInternal))
                        {
                            XtraMessageBox.Show("Please, check the Internal Item Code Data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lueItemInternal.Focus();
                            return false;
                        }
                        string strItemExternal = lueItemExternal.EditValue.ToString();
                        if (string.IsNullOrEmpty(strItemExternal))
                        {
                            XtraMessageBox.Show("Please, check the External Item Code Data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lueItemExternal.Focus();
                            return false;
                        }
                        string strItemType = lueItemType.EditValue.ToString();
                        if (string.IsNullOrEmpty(strItemType))
                        {
                            XtraMessageBox.Show("Please, check the Item Type!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lueItemType.Focus();
                            return false;
                        }
                        string strUseYN = lueUseYN.EditValue.ToString();
                        if (string.IsNullOrEmpty(strUseYN))
                        {
                            XtraMessageBox.Show("Please, check the External Item Code Data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lueUseYN.Focus();
                            return false;
                        }
                        Int16 intItemDetailID = Convert.ToInt16(txtItemDetailID.Text.Trim());

                        if (AddEditStatus == "A")
                        {
                            ItemByCustomer ibc = new ItemByCustomer();

                            var qryCustomer = (from a in db.Customers where a.CustomerCode == strCustomerCode select a).FirstOrDefault();

                            ibc.CustomerID = qryCustomer.CustomerID;
                            ibc.ItemID = Convert.ToInt16(strItemInternal);
                            ibc.ItemCode = (from a in db.ItemMasters where a.ItemID == Convert.ToInt16(strItemInternal) select a.ItemCode).FirstOrDefault();
                            ibc.ItemNumberID = Convert.ToInt16(strItemExternal);
                            ibc.ItemNumber = (from a in db.ItemMasters where a.ItemID == Convert.ToInt16(strItemExternal) select a.ItemCode).FirstOrDefault();
                            ibc.ItemType = strItemType;
                            Boolean blnUseYN;
                            if (strUseYN == "Y")
                            {
                                blnUseYN = true;
                            }
                            else
                            {
                                blnUseYN = false;
                            }
                            ibc.UseYN = blnUseYN;
                            ibc.CreateCompName = Environment.MachineName;
                            ibc.CreateDate = dtServerDate;

                            intCustomerID = Convert.ToInt16(qryCustomer.CustomerID);
                            intItemID= Convert.ToInt16(strItemInternal);
                            intItemNumberID= Convert.ToInt16(strItemExternal);

                            db.ItemByCustomers.InsertOnSubmit(ibc);
                            db.SubmitChanges();

                            var qry = (from obj in db.ItemByCustomers
                                       where obj.CustomerID == intCustomerID
                                       && obj.ItemID == intItemID
                                       && obj.ItemNumberID== intItemNumberID
                                       select obj.ItemDetailID).FirstOrDefault();

                            itemDetailID = Convert.ToInt16(qry);
                        }
                        else
                        {
                            var qryItemByCustomer = (from obj in db.ItemByCustomers
                                                     where obj.ItemDetailID == intItemDetailID
                                                     select obj).FirstOrDefault();
                            if (qryItemByCustomer != null)
                            {
                                var qryCustomer = (from a in db.Customers where a.CustomerCode == strCustomerCode select a).FirstOrDefault();
                                qryItemByCustomer.CustomerID = qryCustomer.CustomerID;
                                qryItemByCustomer.ItemID = Convert.ToInt16(strItemInternal);
                                qryItemByCustomer.ItemCode = (from a in db.ItemMasters where a.ItemID == Convert.ToInt16(strItemInternal) select a.ItemCode).FirstOrDefault();
                                qryItemByCustomer.ItemNumberID = Convert.ToInt16(strItemExternal);
                                qryItemByCustomer.ItemNumber = (from a in db.ItemMasters where a.ItemID == Convert.ToInt16(strItemInternal) select a.ItemCode).FirstOrDefault();
                                qryItemByCustomer.ItemType = strItemType;
                                Boolean blnUseYN;
                                if (strUseYN == "Y")
                                {
                                    blnUseYN = true;
                                }
                                else
                                {
                                    blnUseYN = false;
                                }
                                qryItemByCustomer.UseYN = blnUseYN;
                                qryItemByCustomer.ModifiedCompName = Environment.MachineName;
                                qryItemByCustomer.ModifiedDate= dtServerDate;

                                itemDetailID = intItemDetailID;
                            }
                            db.SubmitChanges();
                        }
                    }
                    scope.Complete();
                }
                MessageBox.Show("Completed Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //int rowHandle = GetRowHandleByColumnValue(gvList, "ItemDetailID", itemDetailID);
                //if (rowHandle != GridControl.InvalidRowHandle)
                //{
                //    gvList.FocusedColumn = gvList.Columns.ColumnByFieldName("ItemDetailID");
                //    gvList.FocusedRowHandle = rowHandle;
                //    //gvList.ShowEditor();
                //}
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
        public void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            string strSearchCustomer;
            string strInternalItem;
            string strExternalItem;
            string strSearchUseYN;

            try
            {
                strSearchCustomer = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                if (string.IsNullOrEmpty(strSearchCustomer))
                    strSearchCustomer = "%";

                strInternalItem = txtSearchItemInternal.Text.Trim();
                if (string.IsNullOrEmpty(strInternalItem)) strInternalItem = "%";

                strExternalItem= txtSearchItemExternal.Text.Trim();
                if (string.IsNullOrEmpty(strExternalItem)) strExternalItem = "%";

                strSearchUseYN = lueSearchUseYN.Properties.GetKeyValueByDisplayText(lueSearchUseYN.Text).ToString();
                if (string.IsNullOrEmpty(strSearchUseYN)) strSearchUseYN = "%";


                var qry = db.stp_ItemByCustomer_Select(strSearchCustomer, strInternalItem, strExternalItem, strSearchUseYN);
                if (qry != null)
                {
                    gcList.DataSource = qry.ToList();
                    if (gvList.RowCount > 0)
                    {
                        AddDropDown();
                        gvList.FocusedRowHandle = -1;
                        string[] arr = { "CustomerCode", "ItemID", "ItemNumberID", "ItemType", "ItemDetailID"  };
                        Functions.SetInvisible(ref gvList, arr);

                        gvList.BestFitColumns();
                        gvList.OptionsBehavior.Editable = false;
                        gvList.FocusedRowHandle = 0;
                    }
                }
                else
                {
                    MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string errMsg;
                if (ex.InnerException == null)
                {
                    errMsg = ex.Message.ToString();
                }
                else
                {
                    errMsg = ex.InnerException.ToString();
                }
                XtraMessageBox.Show("Couldn't Search Item By List!" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private int GetRowHandleByColumnValue(GridView view, string ColumnFieldName, object value)
        {
            int result = GridControl.InvalidRowHandle;
            for (int i = 0; i < view.RowCount; i++)
                if (view.GetDataRow(i)[ColumnFieldName].Equals(value))
                    return i;
            return result;
        }
        private void frmItemByCustomer_Load(object sender, EventArgs e)
        {
            Initialized();
            InitialEditItem();
        }

        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchData();
            
        }

        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                InitialEditItem();
                MakeEnableDisableGroupControl(true);

                AddEditStatus = "A";

                lueCustomer.Focus();
            }
            catch (Exception ex)
            {
                string errMsg;
                if (ex.InnerException == null)
                {
                    errMsg = ex.Message.ToString();
                }
                else
                {
                    errMsg = ex.InnerException.ToString();
                }
                XtraMessageBox.Show("Add New Row Failed!" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gvList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gvList_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            Functions.AddingRowNumber(sender, e);
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string strUseYN;
            Boolean blnUseYN;
            try
            {
                MakeEnableDisableGroupControl(false);

                if (gvList.RowCount > 0)
                {
                    lueCustomer.EditValue = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("CustomerCode").ToString();
                    lueItemInternal.EditValue = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("ItemID").ToString();
                    lueItemExternal.EditValue = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("ItemNumberID").ToString();
                    lueItemType.EditValue = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("ItemType").ToString();
                    blnUseYN = Convert.ToBoolean((sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("UseYN").ToString());
                    if (blnUseYN == true)
                    {
                        strUseYN = "Y";
                    }
                    else
                    {
                        strUseYN = "N";
                    }
                    lueUseYN.EditValue = strUseYN;
                    txtItemDetailID.Text = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRowCellValue("ItemDetailID").ToString();
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

        private void gvList_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridView = ((GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
        }

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MakeEnableDisableGroupControl(true);
            AddEditStatus = "E";
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (AddEditStatus == "N") return;

            if (ValidateData() == true)
            {
                int rowHandle = gvList.FocusedRowHandle;
                //save data.
                if (SaveData() == true)
                {
                    barBtnSearch.PerformClick();

                    gvList.FocusedRowHandle = rowHandle;
                }
                else
                {
                    MakeEnableDisableGroupControl(true);
                }
            }
        }

        private void gvList_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
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
    }
}