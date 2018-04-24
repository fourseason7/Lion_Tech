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
    public partial class frmPopupPOEdit : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();

        public int intPOHeaderID;
        public string strEntryStatus; // A : Create New PO, E : Edit PO
        public DataTable dtPODetails;

        public frmPopupPOEdit()
        {
            InitializeComponent();
        }

        public void Initialized()
        {
            lueCustomer.EditValue = null;

            txtPONumber.Text = "";
            deOrderDate.EditValue = DateTime.Now;
            lueStatus.EditValue = "";
            txtRemark.Text = "";
            txtPOHeaderID.Text = "";

            deOrderDate.EditValue = Convert.ToDateTime(db.fn_ServerDateTime()).AddDays(-7);
            deOrderDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            deOrderDate.Properties.Mask.EditMask = "MM/dd/yyyy";

            Functions.QueryCmbCustomerList(db, ref lueCustomer);
            Functions.QueryCmbOpenClosed(ref lueStatus);
            Functions.QueryCmbUserCodeData(db,ref lueSearchPOType, lueSearchPOType.Tag.ToString());


            lueCustomer.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueCustomer.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchPOType.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchPOType.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            deOrderDate.Properties.AppearanceFocused.BackColor = Color.Yellow;
            deOrderDate.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueStatus.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueStatus.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtPONumber.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtPONumber.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtRemark.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtRemark.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            gcPODetail.DataSource = dtPODetails;
            //gcPODetail.DataSource = null;
        }
        private void CreateNewDataRow()
        {

            dtPODetails = MakeNamesTable();
            //DataRow row;
            //row = dtPODetails.NewRow();

            //row["PODetailID"] = 0;
            //dtPODetails.Rows.Add(row);
            gcPODetail.DataSource = dtPODetails;

            gvPODetail.PopulateColumns();

        }
        private DataTable MakeNamesTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable namesTable = new DataTable("Names");

            // Add three column objects to the table.

            DataColumn CustomerCode = new DataColumn("CustomerCode");
            CustomerCode.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(CustomerCode);

            DataColumn CustomerName = new DataColumn("CustomerName");
            CustomerName.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(CustomerName);

            DataColumn PONumber = new DataColumn("PONumber");
            PONumber.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(PONumber);

            DataColumn OrderDate = new DataColumn("OrderDate");
            OrderDate.DataType = System.Type.GetType("System.DateTime");
            namesTable.Columns.Add(OrderDate);

            DataColumn POLineNumber = new DataColumn("POLineNumber");
            POLineNumber.DataType = System.Type.GetType("System.Int16");
            POLineNumber.Caption = "Line#";
            namesTable.Columns.Add(POLineNumber);

            DataColumn ItemCode = new DataColumn("ItemCode");
            ItemCode.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(ItemCode);

            DataColumn ItemNumber = new DataColumn("ItemNumber");
            ItemNumber.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(ItemNumber);

            DataColumn ReceiveQty = new DataColumn("ReceiveQty");
            ReceiveQty.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ReceiveQty);

            DataColumn DueDate = new DataColumn("DueDate");
            DueDate.DataType = System.Type.GetType("System.DateTime");
            namesTable.Columns.Add(DueDate);

            DataColumn ShipRefurbishedQty = new DataColumn("ShipRefurbishedQty");
            ShipRefurbishedQty.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ShipRefurbishedQty);

            DataColumn ShipFrontOnly = new DataColumn("ShipFrontOnly");
            ShipFrontOnly.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ShipFrontOnly);

            DataColumn ShipFunctionFailQty = new DataColumn("ShipFunctionFailQty");
            ShipFunctionFailQty.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ShipFunctionFailQty);

            DataColumn ShipDIPQty = new DataColumn("ShipDIPQty");
            ShipDIPQty.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ShipDIPQty);

            DataColumn ShipSampleQty = new DataColumn("ShipSampleQty");
            ShipSampleQty.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ShipSampleQty);

            DataColumn ShipNTFQty = new DataColumn("ShipNTFQty");
            ShipNTFQty.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ShipNTFQty);

            DataColumn ShipOutOfWarranty = new DataColumn("ShipOutOfWarranty");
            ShipOutOfWarranty.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ShipOutOfWarranty);

            DataColumn ShipCustomerAbuse = new DataColumn("ShipCustomerAbuse");
            ShipFunctionFailQty.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ShipCustomerAbuse);

            DataColumn ShipTotalQty = new DataColumn("ShipTotalQty");
            ShipTotalQty.DataType = System.Type.GetType("System.Int16");
            ShipTotalQty.Caption = "Total";
            namesTable.Columns.Add(ShipTotalQty);

            DataColumn InventoryQty = new DataColumn("InventoryQty");
            InventoryQty.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(InventoryQty);

            DataColumn Status = new DataColumn("Status");
            Status.DataType = System.Type.GetType("System.Boolean");
            namesTable.Columns.Add(Status);

            DataColumn POHeaderID = new DataColumn("POHeaderID");
            POHeaderID.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(POHeaderID);

            DataColumn PODetailID = new DataColumn("PODetailID");
            PODetailID.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(PODetailID);

            DataColumn CustomerID = new DataColumn("CustomerID");
            CustomerID.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(CustomerID);

            DataColumn ItemID = new DataColumn("ItemID");
            ItemID.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ItemID);


            // Return the new DataTable.
            return namesTable;
        }

        public void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            AddDropDown();
            try
            {
                var qry = (from hdr in db.POHeaders
                           from cst in db.Customers
                           where cst.CustomerID == hdr.CustomerID
                           && hdr.POHeaderID == intPOHeaderID
                           select new
                           {
                               CustomerID = cst.CustomerID
                               ,
                               CustomerCode = cst.CustomerCode
                               ,
                               POType = hdr.POType
                               ,
                               PONumber = hdr.PONumber
                               ,
                               POHeaderID = hdr.POHeaderID
                               ,
                               OrderDate = hdr.OrderDate
                               ,
                               Status = hdr.Status
                               ,
                               Remark = hdr.Remark
                           }).FirstOrDefault();

                if (qry != null)
                {
                    lueCustomer.EditValue = qry.CustomerCode;
                    lueSearchPOType.EditValue = qry.POType;
                    txtPONumber.Text = qry.PONumber;
                    txtPOHeaderID.Text = qry.POHeaderID.ToString();
                    deOrderDate.EditValue = qry.OrderDate;
                    lueStatus.EditValue = qry.Status;
                    txtRemark.Text = qry.Remark;

                    var qryDetail = db.stp_PODetail_Select(qry.CustomerCode, "%", qry.PONumber, "%", "%");
                    try
                    {
                        dtPODetails = Functions.LINQToDataTable(qryDetail);
                        gcPODetail.DataSource = dtPODetails;

                        if (gvPODetail.RowCount > 0)
                        {
                            //    // Set Display format
                            //gvPODetail.Columns["ReceiveQty"].DisplayFormat.FormatString = "#,##0";
                            //gvPODetail.Columns["ReceiveQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            //gvPODetail.Columns["ShipGoodQty"].DisplayFormat.FormatString = "#,##0";
                            //gvPODetail.Columns["ShipGoodQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            //gvPODetail.Columns["ShipFunctionFailQty"].DisplayFormat.FormatString = "#,##0";
                            //gvPODetail.Columns["ShipFunctionFailQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            //gvPODetail.Columns["ShipDIPQty"].DisplayFormat.FormatString = "#,##0";
                            //gvPODetail.Columns["ShipDIPQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            //gvPODetail.Columns["ShipTotalQty"].DisplayFormat.FormatString = "#,##0";
                            //gvPODetail.Columns["ShipTotalQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            //gvPODetail.Columns["InventoryQty"].DisplayFormat.FormatString = "#,##0";
                            //gvPODetail.Columns["InventoryQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                            ////gvPODetail.BestFitColumns();
                            ////gvPODetail.OptionsBehavior.ReadOnly = true;
                            //gvPODetail.FocusedRowHandle = 0;

                            //gvPODetail.Columns["POLineNumber"].Caption = "Line#";
                            //gvPODetail.Columns["ShipFunctionFailQty"].Caption = "Function Fail";
                            //gvPODetail.Columns["ShipDIPQty"].Caption = "DIP";
                            //gvPODetail.Columns["ShipTotalQty"].Caption = "Total";
                            //gvPODetail.Columns["InventoryQty"].Caption = "Inventory";


                            string[] arr = { "CustomerCode", "CustomerName", "PONumber", "OrderDate", "DueDate", "ItemCode", "POHeaderID", "PODetailID", "CustomerID", "ItemID" };
                            Functions.SetInvisible(ref gvPODetail, arr);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
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
        public Boolean  SaveData()
        {
            try
            {
                if (gvPODetail.IsEditing)
                    gvPODetail.CloseEditor();

                if (gvPODetail.FocusedRowModified)
                    gvPODetail.UpdateCurrentRow();

                Cursor.Current = Cursors.WaitCursor;
                intPOHeaderID = Convert.ToInt16(txtPOHeaderID.Text);
                int intCustomerID;
                string strCustomerCode = lueCustomer.EditValue.ToString();
                string strPOType = lueSearchPOType.EditValue.ToString();
                string strPONumber = txtPONumber.Text.Trim();
                if (string.IsNullOrEmpty(strPONumber))
                {
                    XtraMessageBox.Show("Please, input P/O Number first.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPONumber.Focus();
                    return false;
                }
                DateTime dtOrderDate = Convert.ToDateTime(deOrderDate.EditValue.ToString());
                //string strOrderDate = deOrderDate.EditValue.ToString();
                //DateTime dtOrderDate;
                //if (DateTime.TryParseExact(strOrderDate, "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out dtOrderDate) == false)
                //{
                //    XtraMessageBox.Show("Order Date is not valid", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    deOrderDate.Focus();
                //    return false;
                //}
                Boolean blnStatus = Convert.ToBoolean(lueStatus.Properties.GetKeyValueByDisplayText(lueStatus.Text).ToString());
                string strRemark = txtRemark.Text;

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                {
                    using (eSolutionDataContext db = new eSolutionDataContext())
                    {
                        DateTime dtServerDate = Convert.ToDateTime(db.fn_ServerDateTime().ToString());

                        var qryPOHeader = (from poh in db.POHeaders
                                           from cst in db.Customers
                                           where cst.CustomerID == poh.CustomerID
                                           && cst.CustomerCode == strCustomerCode
                                           && poh.PONumber == strPONumber
                                           select poh).FirstOrDefault();

                        if (qryPOHeader == null)
                        {
                            // new add row
                            var qryCount = (from poh in db.POHeaders
                                            from cst in db.Customers
                                            where cst.CustomerID == poh.CustomerID
                                            && cst.CustomerCode == strCustomerCode
                                            && poh.PONumber == strPONumber
                                            select poh).Count();
                            if (qryCount > 0)
                            {
                                MessageBox.Show("Already regist PO Number." + Environment.NewLine + "Please, check the PO Number!",
                                    "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPONumber.Focus();
                                return false;
                            }
                            POHeader poheader = new POHeader();

                            intCustomerID = (from obj in db.Customers where obj.CustomerCode == strCustomerCode select obj.CustomerID).FirstOrDefault();
                            poheader.CustomerID= intCustomerID;
                            poheader.PONumber = strPONumber;
                            poheader.POType = strPOType;
                            poheader.OrderDate = dtOrderDate;
                            poheader.Status = blnStatus;
                            if (blnStatus == true)
                            {
                                poheader.ClosedDate = dtServerDate;
                            }
                            poheader.CreateDate = dtServerDate;
                            poheader.CreateCompName = Environment.MachineName;
                            poheader.ModifiedDate = dtServerDate;
                            poheader.ModifiedCompName = Environment.MachineName;
                            db.POHeaders.InsertOnSubmit(poheader);

                        }
                        else 
                        {
                            intCustomerID = (from obj in db.Customers where obj.CustomerCode == strCustomerCode select obj.CustomerID).FirstOrDefault();
                            qryPOHeader.CustomerID = intCustomerID;
                            qryPOHeader.POType = strPOType;
                            qryPOHeader.PONumber = strPONumber;
                            qryPOHeader.OrderDate = dtOrderDate;
                            qryPOHeader.Status = blnStatus;
                            qryPOHeader.Remark = strRemark;
                            qryPOHeader.ModifiedCompName = Environment.MachineName;
                            qryPOHeader.ModifiedDate = dtServerDate;
                        }
                        db.SubmitChanges();

                        intPOHeaderID = (from obj in db.POHeaders
                                         where obj.CustomerID == intCustomerID
                                         && obj.PONumber == strPONumber
                                         select obj.POHeaderID).FirstOrDefault();
                        // PO Detail delete
                        for (int i = 0; i < gvPODetail.DataRowCount; i++)
                        { 
                            int intPODetailID = Convert.ToInt16(gvPODetail.GetRowCellValue(i, "PODetailID").ToString());
                            int intPOLineNumber;
                                try
                                {
                                   intPOLineNumber = Convert.ToInt16(gvPODetail.GetRowCellValue(i, "POLineNumber").ToString());
                                }
                            catch{
                                intPOLineNumber = 1;
                            }

                           
                            string strItemNumber = gvPODetail.GetRowCellValue(i, "ItemNumber").ToString();
                            var qryItem = (from itm in db.ItemMasters
                                          from itd in db.ItemByCustomers
                                          where itd.ItemID == itm.ItemID
                                              && itd.CustomerID == intCustomerID
                                              && itd.ItemNumber == strItemNumber
                                              && itd.ItemType.Contains("R")
                                          select new
                                          {
                                              ItemID = itm.ItemID,
                                              ItemCode = itm.ItemCode
                                          }
                                         ).FirstOrDefault();
                            int intItemID = qryItem.ItemID;
                            string strItemCode = qryItem.ItemCode;
                            DateTime? dtDueDate;
                            try
                            {
                                dtDueDate = Convert.ToDateTime(gvPODetail.GetRowCellValue(i, "DueDate").ToString());
                            }
                            catch
                            {
                                dtDueDate = null;
                            }
                            
                            int intReceivingQty = Convert.ToInt16(gvPODetail.GetRowCellValue(i, "ReceiveQty").ToString());
                            //int intShipGoodQty = Convert.ToInt16(gvPODetail.GetRowCellValue(i, "ShipGoodQty").ToString());
                            //int intShipFunctionFailQty = Convert.ToInt16(gvPODetail.GetRowCellValue(i, "ShipFunctionFailQty").ToString());
                            //int intShipDIPQty = Convert.ToInt16(gvPODetail.GetRowCellValue(i, "ShipDIPQty").ToString());
                            string strStatus = gvPODetail.GetRowCellValue(i, "Status").ToString();
                            Boolean blnStatusDetail = Convert.ToBoolean(gvPODetail.GetRowCellValue(i, "Status").ToString());

                            var qryDetail = (from obj in db.PODetails
                                             where obj.PODetailID == intPODetailID
                                             select obj).FirstOrDefault();
                            if (qryDetail == null)
                            {
                                PODetail dtl = new PODetail();
                                dtl.POHeaderID = intPOHeaderID;
                                dtl.POLineNumber = intPOLineNumber;
                                dtl.PONumber = strPONumber;
                                dtl.ItemID = intItemID;
                                dtl.ItemCode = strItemCode;
                                dtl.ItemNumber = strItemNumber;
                                dtl.ReceiveQty = intReceivingQty;
                                dtl.DueDate = dtDueDate;
                                //dtl.ShipGoodQty = intShipGoodQty;
                                //dtl.ShipDIPQty = intShipDIPQty;
                                //dtl.ShipFunctionFailQty = intShipFunctionFailQty;
                                //dtl.ShipDIPQty = intShipDIPQty;
                                dtl.Status = blnStatusDetail;
                                dtl.CreatedDate = dtServerDate;
                                dtl.CreatedHostName = Environment.MachineName;

                                db.PODetails.InsertOnSubmit(dtl);
                            }
                            else
                            {
                                if (!(qryDetail.POHeaderID == intPOHeaderID
                                    && qryDetail.POLineNumber == intPOLineNumber
                                    && qryDetail.PONumber == strPONumber
                                    && qryDetail.ItemID == intItemID
                                    && qryDetail.ItemCode == strItemCode
                                    && qryDetail.ItemNumber == strItemNumber
                                    && qryDetail.ReceiveQty == intReceivingQty
                                    //&& qryDetail.ShipGoodQty == intShipGoodQty
                                    //&& qryDetail.ShipFunctionFailQty == intShipFunctionFailQty
                                    //&& qryDetail.ShipDIPQty == intShipDIPQty
                                    && qryDetail.DueDate == dtDueDate
                                    && qryDetail.Status == blnStatusDetail))
                                {
                                    qryDetail.POHeaderID = intPOHeaderID;
                                    qryDetail.PONumber = strPONumber;
                                    qryDetail.POLineNumber = intPOLineNumber;
                                    qryDetail.ItemID = intItemID;
                                    qryDetail.ItemCode = strItemCode;
                                    qryDetail.ItemNumber = strItemNumber;
                                    qryDetail.ReceiveQty = intReceivingQty;
                                    qryDetail.DueDate = dtDueDate;
                                    //qryDetail.ShipGoodQty = intShipGoodQty;
                                    //qryDetail.ShipDIPQty = intShipDIPQty;
                                    //qryDetail.ShipFunctionFailQty = intShipFunctionFailQty;
                                    //qryDetail.ShipDIPQty = intShipDIPQty;
                                    qryDetail.Status = blnStatus;
                                    qryDetail.CreatedDate = dtServerDate;
                                    qryDetail.CreatedHostName = Environment.MachineName;
                                }
                            }
                            db.SubmitChanges();

                            if (strEntryStatus == "A")
                            {
                                txtPOHeaderID.Text = intPOHeaderID.ToString();
                                strEntryStatus = "E";
                            }
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
            return false ;
        }
        public Boolean DeleteData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                intPOHeaderID = Convert.ToInt16(txtPOHeaderID.Text);
                if (intPOHeaderID <= 0)
                {
                    //XtraMessageBox.Show("Please, input P/O Number first.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtPONumber.Focus();
                    return false;
                }
                DialogResult result =  XtraMessageBox.Show("Do you want to delete P/O Data?", "Question!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
        public void AddNewPO()
        {
            try
            {
                //var qry = db.stp_PODetail_Select("", "", "", "");
                //dtPODetails = Functions.LINQToDataTable(qry);
                //gcPODetail.DataSource = dtPODetails;
                //SearchData();
                deOrderDate.EditValue = db.fn_ServerDateTime().ToString();
                txtPOHeaderID.Text = "0";
                CreateNewDataRow();
                AddDropDown();

                string[] arr = { "CustomerCode", "CustomerName", "PONumber", "OrderDate", "DueDate", "ItemCode", "POHeaderID", "PODetailID", "CustomerID", "ItemID" };
                Functions.SetInvisible(ref gvPODetail, arr);


                lueCustomer.Focus();
            }
            catch
            {

            }
        }
        private void AddDropDown()
        {
            repositoryItemLookUpEdit1.DataSource = DatabaseHelper.GetCustomerItemList(db, lueCustomer.EditValue.ToString(), "");
            //repositoryItemLookUpEdit1.PopulateViewColumns();
            repositoryItemLookUpEdit1.ValueMember = "ValueMember";
            repositoryItemLookUpEdit1.DisplayMember = "DisplayMember";
            //repositoryItemLookUpEdit1.Columns["ValueMember"].Visible = false;
            //repositoryItemSearchLookUpEditItemNumber.DataSource = DatabaseHelper.GetCustomerItemList(db, lueCustomer.EditValue.ToString(), "S");
            //repositoryItemSearchLookUpEditItemNumber.PopulateViewColumns();
            //repositoryItemSearchLookUpEditItemNumber.ValueMember = "ValueMember";
            //repositoryItemSearchLookUpEditItemNumber.ValueMember = "DisplayMemeber";

            //gvPODetail.Columns["ItemNumber"].ColumnEdit = repositoryItemSearchLookUpEditItemNumber;
            gvPODetail.Columns["ItemNumber"].ColumnEdit = repositoryItemLookUpEdit1;

            gvPODetail.OptionsView.ColumnAutoWidth = true;
            gvPODetail.Columns["ItemNumber"].BestFit();
            //gvPODetail.BestFitColumns();

            repositoryItemSearchLookUpEditItemNumber.NullText = "";
        }
        private void frmPopupPOEdit_Load(object sender, EventArgs e)
        {
            Initialized();
            if (strEntryStatus == "A") // Create New PO
            {
                barBtnAdd.PerformClick();
            }
            else // Retreive PO Data
            {
                SearchData();
            }
            txtPONumber.Focus();
        }
        private void txtPONumber_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.Handled = true;
            }
        }
        private void barBtnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDeleteLine_Click(object sender, EventArgs e)
        {
            int intPODetailID;
            int intRow = gvPODetail.FocusedRowHandle;
            int poLineNumber;

            if (intRow < 0) return;

            intPODetailID = Convert.ToInt16(gvPODetail.GetRowCellValue(intRow, "PODetailID").ToString());
            if (intPODetailID == 0)
            {
                gvPODetail.DeleteRow(intRow);
                return;
            }

            poLineNumber = Convert.ToInt16(gvPODetail.GetRowCellValue(intRow, "POLineNumber").ToString());


            DialogResult dialogResult = XtraMessageBox.Show(string.Format("Do you want to delete Line Number {0}", poLineNumber.ToString()), "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;


                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                {
                    using (eSolutionDataContext db = new eSolutionDataContext())
                    {
                        var qryDelete = from obj in db.PODetails
                                        where obj.PODetailID == intPODetailID
                                        select obj;
                        foreach (var dtl in qryDelete)
                        {
                            db.PODetails.DeleteOnSubmit(dtl);
                        }
                        try 
                        { db.SubmitChanges(); 
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
                            XtraMessageBox.Show("Delete Failed!" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    scope.Complete();
                }
                SearchData();
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
                XtraMessageBox.Show("Delete Failed!" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            try
            {
                string sCustomerCode = lueCustomer.Properties.GetKeyValueByDisplayText(lueCustomer.Text).ToString();
                if (string.IsNullOrEmpty(sCustomerCode))
                {
                    XtraMessageBox.Show("Please, Select Customer first.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueCustomer.Focus();
                    return;
                }
                string sPONumber = txtPONumber.Text.ToUpper().Trim();
                if (string.IsNullOrEmpty(sPONumber))
                {
                    XtraMessageBox.Show("Please, Input PONumber first.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPONumber.Focus();
                    return;
                }
                else
                {
                    if (strEntryStatus == "A")
                    {
                        var qryCount = (from obj in db.POHeaders
                                        where obj.PONumber == sPONumber
                                        select obj).Count();
                        if (qryCount > 0)
                        {
                            XtraMessageBox.Show("PO Number is duplicate!" + Environment.NewLine + "Please, check P/O List.", "Warnign!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPONumber.Focus();
                            return;
                        }
                    }
                }

                Boolean bStatus = Convert.ToBoolean(lueStatus.Properties.GetKeyValueByDisplayText(lueStatus.Text).ToString());
                if (bStatus == true)
                {
                    XtraMessageBox.Show("Could not add new line because this P/O is closed.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                gvPODetail.OptionsBehavior.Editable = true;
                //gvPODetail.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

                if (gvPODetail.RowCount == 0)
                {
                    CreateNewDataRow();
                }

                AddDropDown();


                gvPODetail.AddNewRow();
                //int rowHandle = gvPODetail.GetRowHandle(gvPODetail.DataRowCount);
                //if (gvPODetail.IsNewItemRow(rowHandle))
                //{
                //    gvPODetail.SetRowCellValue(rowHandle, gvPODetail.Columns["POLineNumber"], rowHandle);
                //}

                Int16 intPOHeaderID, intPOLineNumber;
                try
                {
                    intPOHeaderID = Convert.ToInt16(txtPOHeaderID.Text);
                }
                catch
                {
                    intPOHeaderID = 0;
                }


      
                if (intPOHeaderID == 0)
                {
                    intPOLineNumber = Convert.ToInt16(gvPODetail.RowCount);
                    intPOLineNumber -= 1;

                }
                else
                {
                    try
                    {
                        var max_qry = (from obj in db.PODetails where obj.POHeaderID == intPOHeaderID select obj.POLineNumber).Max();
                        intPOLineNumber = Convert.ToInt16(max_qry.Value);
                    }
                    catch
                    {
                        intPOLineNumber = 0;
                    }
                }

                intPOLineNumber += 1;

                gvPODetail.SetRowCellValue(gvPODetail.FocusedRowHandle, "PODetailID", 0);
                gvPODetail.SetRowCellValue(gvPODetail.FocusedRowHandle, "POLineNumber", intPOLineNumber);
                gvPODetail.SetRowCellValue(gvPODetail.FocusedRowHandle, "ReceiveQty", 0);
                gvPODetail.SetRowCellValue(gvPODetail.FocusedRowHandle, "ShipTotalQty", 0);
                gvPODetail.SetRowCellValue(gvPODetail.FocusedRowHandle, "InventoryQty", 0);
                gvPODetail.SetRowCellValue(gvPODetail.FocusedRowHandle, "Status", false);

                gvPODetail.SetRowCellValue(gvPODetail.FocusedRowHandle, "PONumber", sPONumber);

                //gvPODetail.Columns["POLineNumber"].Caption = "Line#";
                //gvPODetail.Columns["ShipTotalQty"].Caption = "Ship Total";
                //gvPODetail.Columns["InventoryQty"].Caption = "Inventory";


                string[] arr = { "CustomerCode", "CustomerName", "PONumber", "DueDate", "ShipRefurbishedQty", "ShipFrontOnly", "ShipFunctionFailQty", "ShipDIPQty", "ShipSampleQty", "ShipNTFQty", "ShipOutOfWarranty", "ShipCustomerAbuse", "OrderDate", "ItemCode", "POHeaderID", "PODetailID", "CustomerID", "ItemID" };
                Functions.SetInvisible(ref gvPODetail, arr);

                gvPODetail.Columns["ShipTotalQty"].OptionsColumn.AllowEdit = false;
                gvPODetail.Columns["InventoryQty"].OptionsColumn.AllowEdit = false;

                gvPODetail.UpdateCurrentRow();
                gvPODetail.RefreshData();

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
                XtraMessageBox.Show("Add line to Purchase Order Failed!" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Initialized();
            //SearchData();
            //int a = gvPODetail.RowCount;
            CreateNewDataRow();
            AddNewPO();
        }


        private void gvPODetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //try
            //{
            //    if (e.FocusedRowHandle < 0)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        // set customer shipping item number
            //        txtLineNumber.Text = gvPODetail.GetRowCellValue(gvPODetail.FocusedRowHandle, "POLineNumber").ToString();
            //        lueItemNumber.EditValue = gvPODetail.GetRowCellValue(gvPODetail.FocusedRowHandle, "ItemNumber").ToString();
            //        txtOrderQty.Text = gvPODetail.GetRowCellValue(gvPODetail.FocusedRowHandle, "ReceiveQty").ToString();
            //        deDueDate.EditValue = gvPODetail.GetRowCellValue(gvPODetail.FocusedRowHandle, "DueDate").ToString();
            //        txtPODetailID.Text = gvPODetail.GetRowCellValue(gvPODetail.FocusedRowHandle, "PODetailID").ToString();
            //        txtRowNumber.Text = (gvPODetail.FocusedRowHandle).ToString();

            //        lueItemNumber.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string errMsg;
            //    if (ex.InnerException == null)
            //    {
            //        errMsg = ex.Message.ToString();
            //    }
            //    else
            //    {
            //        errMsg = ex.InnerException.ToString();
            //    }
            //    MessageBox.Show("Could not get P/O Detail." + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void gvPODetail_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            Functions.AddingRowNumber(sender, e);
        }

        private void gvPODetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;

            Int16 iReceiveQty;
            //Int16 iShipGoodQty;
            //Int16 iShipFunctionFailQty;
            //Int16 iShipDIPQty;
            //Int16 iShipTotalQty;
            //Int16 iInventoryQty;
            switch (e.Column.FieldName)
            {
                case "ReceiveQty":
                    iReceiveQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ReceiveQty"));
                    //iShipGoodQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipGoodQty"));
                    //iShipFunctionFailQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipFunctionFailQty"));
                    //iShipDIPQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipDIPQty"));
                    //iShipTotalQty = Convert.ToInt16(iShipGoodQty + iShipFunctionFailQty + iShipDIPQty);
                    //gvPODetail.SetFocusedRowCellValue("ShipTotalQty", iReceiveQty);
                    //iInventoryQty = Convert.ToInt16(iReceiveQty - iShipTotalQty);
                    gvPODetail.SetFocusedRowCellValue("InventoryQty", iReceiveQty);
                    break;
                //case "ShipGoodQty":
                //    iReceiveQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ReceiveQty"));
                //    iShipGoodQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipGoodQty"));
                //    iShipFunctionFailQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipFunctionFailQty"));
                //    iShipDIPQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipDIPQty"));
                //    iShipTotalQty = Convert.ToInt16(iShipGoodQty + iShipFunctionFailQty + iShipDIPQty);
                //    gvPODetail.SetFocusedRowCellValue("ShipTotalQty", iShipTotalQty);
                //    iInventoryQty = Convert.ToInt16(iReceiveQty - iShipTotalQty);
                //    gvPODetail.SetFocusedRowCellValue("InventoryQty", iInventoryQty);
                //    break;
                //case "ShipFunctionFailQty":
                //    iReceiveQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ReceiveQty"));
                //    iShipGoodQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipGoodQty"));
                //    iShipFunctionFailQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipFunctionFailQty"));
                //    iShipDIPQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipDIPQty"));
                //    iShipTotalQty = Convert.ToInt16(iShipGoodQty + iShipFunctionFailQty + iShipDIPQty);
                //    gvPODetail.SetFocusedRowCellValue("ShipTotalQty", iShipTotalQty);
                //    iInventoryQty = Convert.ToInt16(iReceiveQty - iShipTotalQty);
                //    gvPODetail.SetFocusedRowCellValue("InventoryQty", iInventoryQty);
                //    break;
                //case "ShipDIPQty":
                //    iReceiveQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ReceiveQty"));
                //    iShipGoodQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipGoodQty"));
                //    iShipFunctionFailQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipFunctionFailQty"));
                //    iShipDIPQty = Convert.ToInt16(gvPODetail.GetFocusedRowCellValue("ShipDIPQty"));
                //    iShipTotalQty = Convert.ToInt16(iShipGoodQty + iShipFunctionFailQty + iShipDIPQty);
                //    gvPODetail.SetFocusedRowCellValue("ShipTotalQty", iShipTotalQty);
                //    iInventoryQty = Convert.ToInt16(iReceiveQty - iShipTotalQty);
                //    gvPODetail.SetFocusedRowCellValue("InventoryQty", iInventoryQty);
                //    break;
            }
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            //SearchData();
        }

        private void barBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DeleteData();
            }
            catch
            { 
            }
        }

        private void gvPODetail_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridView = ((GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}