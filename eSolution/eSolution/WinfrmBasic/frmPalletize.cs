using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using eSolution.Database;
using System.Transactions;
using eSolution.Report;
using DevExpress.XtraReports.UI;

namespace eSolution.WinfrmBasic
{
    public partial class frmPalletize : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();
        public DataTable dataTablePendingList;
        public DataTable dataTablePackingList;

        public frmPalletize()
        {
            InitializeComponent();
        }
        private void CreateNewDataRow()
        {

            dataTablePendingList = MakeNamesTable();
            gcPendingList.DataSource = dataTablePendingList;
            gvPendingList.PopulateColumns();

            dataTablePackingList = MakeNamesTable();
            gcPalletize.DataSource = dataTablePackingList;
            gvPalletize.PopulateColumns();


            gvPendingList.Columns["ItemCode"].Visible = false;
            gvPendingList.Columns["CustomerCode"].Visible = false;
            gvPendingList.Columns["ShipmentID"].Visible = false;

            // Set Display format
            gvPendingList.Columns["ActItemNumber"].Caption = "Item Number";
            gvPendingList.Columns["ShippingStatusName"].Caption = "Status";
            gvPendingList.Columns["ShippedDate"].Caption = "Packing Date";
            gvPendingList.Columns["ShippedQty"].Caption = "Qty";
            gvPendingList.Columns["POType"].Caption = "P/O Type";

            gvPendingList.Columns["ShippedQty"].DisplayFormat.FormatString = "#,##0";
            gvPendingList.Columns["ShippedQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gvPendingList.Columns["ShippedDate"].DisplayFormat.FormatString = "MM/dd/yyyy";
            gvPendingList.Columns["ShippedDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            gvPalletize.Columns["ItemCode"].Visible = false;
            gvPalletize.Columns["CustomerCode"].Visible = false;
            gvPalletize.Columns["ShipmentID"].Visible = false;

            // Set Display format
            gvPalletize.Columns["ActItemNumber"].Caption = "Item Number";
            gvPalletize.Columns["ShippingStatusName"].Caption = "Status";
            gvPalletize.Columns["ShippedDate"].Caption = "Packing Date";
            gvPalletize.Columns["ShippedQty"].Caption = "Qty";
            gvPalletize.Columns["POType"].Caption = "P/O Type";

            gvPalletize.Columns["ShippedQty"].DisplayFormat.FormatString = "#,##0";
            gvPalletize.Columns["ShippedQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gvPalletize.Columns["ShippedDate"].DisplayFormat.FormatString = "MM/dd/yyyy";
            gvPalletize.Columns["ShippedDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;


        }
        private DataTable MakeNamesTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable namesTable = new DataTable("Names");

            // Add three column objects to the table.
            DataColumn PONumber = new DataColumn("PONumber");
            PONumber.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(PONumber);

            DataColumn ShipBoxNo = new DataColumn("ShipBoxNo");
            ShipBoxNo.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(ShipBoxNo);

            DataColumn ItemCode = new DataColumn("ItemCode");
            ItemCode.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(ItemCode);

            DataColumn ActItemNumber = new DataColumn("ActItemNumber");
            ActItemNumber.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(ActItemNumber);

            DataColumn ShippingStatusName = new DataColumn("ShippingStatusName");
            ShippingStatusName.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(ShippingStatusName);

            DataColumn ShippedQty = new DataColumn("ShippedQty");
            ShippedQty.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ShippedQty);

            DataColumn CustomerCode = new DataColumn("CustomerCode");
            CustomerCode.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(CustomerCode);

            DataColumn POType = new DataColumn("POType");
            //ItemNumber.ColumnName = "Item Number";
            POType.DataType = System.Type.GetType("System.String");
            namesTable.Columns.Add(POType);

            DataColumn ShippedDate = new DataColumn("ShippedDate");
            ShippedDate.DataType = System.Type.GetType("System.DateTime");
            namesTable.Columns.Add(ShippedDate);

            DataColumn ShipmentID = new DataColumn("ShipmentID");
            ShipmentID.DataType = System.Type.GetType("System.Int16");
            namesTable.Columns.Add(ShipmentID);

            // Return the new DataTable.
            return namesTable;
        }
        public void Initialized()
        {

            Functions.QueryCmbCustomerList(db, ref lueSearchCustomer);
            string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
            Functions.QueryCmbUserCodeData(db, ref lueSearchPOType, lueSearchPOType.Tag.ToString(), "", true);
            string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();

            barEditCopies.EditValue = 1;

            txtPalletID.Text = "";

            lueSearchCustomer.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchCustomer.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchPOType.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchPOType.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSearchBoxNo.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSearchBoxNo.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtPalletID.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtPalletID.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            CreateNewDataRow();

        }
        public void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            string strSearchCustomer;
            string strSearchPOType;
            string strSearchShipBoxNo;
            string strSearchPONumber;

            try
            {
                strSearchCustomer = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                strSearchPOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                if (string.IsNullOrEmpty(strSearchPOType)) strSearchPOType = "%";
                strSearchShipBoxNo = txtSearchBoxNo.Text.Trim();
                if (string.IsNullOrEmpty(strSearchShipBoxNo)) strSearchShipBoxNo = "%";
                strSearchPONumber = txtSearchPONumber.Text.Trim();
                if (string.IsNullOrEmpty(strSearchPONumber)) strSearchPONumber = "%";

                var qry = db.stp_POShipment_PendingPalletize_Select(strSearchCustomer, strSearchPOType, strSearchPONumber, strSearchShipBoxNo);
                if (qry != null)
                {
                    dataTablePendingList = Functions.LINQToDataTable(qry);
                    //gcPendingList.DataSource = qry.ToList();
                    gcPendingList.DataSource = dataTablePendingList;
                    if (gvPendingList.RowCount > 0)
                    {
                        gvPendingList.Columns["ItemCode"].Visible = false;
                        gvPendingList.Columns["CustomerCode"].Visible = false;
                        gvPendingList.Columns["ShipmentID"].Visible = false;

                        // Set Display format
                        gvPendingList.Columns["ActItemNumber"].Caption = "Item Number";
                        gvPendingList.Columns["ShippingStatusName"].Caption = "Status";
                        gvPendingList.Columns["ShippedDate"].Caption = "Packing Date";
                        gvPendingList.Columns["ShippedQty"].Caption = "Qty";
                        gvPendingList.Columns["POType"].Caption = "P/O Type";

                        gvPendingList.Columns["ShippedQty"].DisplayFormat.FormatString = "#,##0";
                        gvPendingList.Columns["ShippedQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvPendingList.Columns["ShippedDate"].DisplayFormat.FormatString = "MM/dd/yyyy";
                        gvPendingList.Columns["ShippedDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        //gvList.BestFitColumns();
                        gvPendingList.OptionsBehavior.ReadOnly = true;

                        gvPalletize.BestFitColumns();
                    }

                }
                else
                {
                    gcPendingList.DataSource = null;
                    MessageBox.Show("No Results", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't Search Pending Palletize!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void txtSearchBoxNo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmPalletize_Load(object sender, EventArgs e)
        {
            Initialized();
        }

        private void btnSearchPendingBox_Click(object sender, EventArgs e)
        {
            //Initialized();
            SearchData();
            txtSearchBoxNo.Focus();
        }


        private void picRight_Click(object sender, EventArgs e)
        {
            //string shipBoxNo, itemCode, actItemNumber, shippingStatusName, customerCode, pOType;
            //Int16 shippedQty, shipmentID;
            //DateTime dtShippedDate;

            Cursor.Current = Cursors.WaitCursor;

            DataRow packingRow;
            try
            {
                for (int i = 0; i < gvPendingList.RowCount; i++)
                {
                    bool isSelected = gvPendingList.IsRowSelected(i);
                    if (isSelected)
                    {
                        string shipBoxNo = Convert.ToString(gvPendingList.GetRowCellValue(i, "ShipBoxNo"));
                        string itemCode = Convert.ToString(gvPendingList.GetRowCellValue(i, "ShippingStatusName"));
                        string actItemNumber = Convert.ToString(gvPendingList.GetRowCellValue(i, "ActItemNumber"));
                        string shippingStatusName = Convert.ToString(gvPendingList.GetRowCellValue(i, "ShippingStatusName"));
                        Int16 shippedQty = Convert.ToInt16(gvPendingList.GetRowCellValue(i, "ShippedQty").ToString());
                        string customerCode = Convert.ToString(gvPendingList.GetRowCellValue(i, "CustomerCode"));
                        string pOType = Convert.ToString(gvPendingList.GetRowCellValue(i, "POType"));
                        DateTime shippedDate = Convert.ToDateTime(gvPendingList.GetRowCellValue(i, "ShippedDate").ToString());
                        Int16 shipmentID = Convert.ToInt16(gvPendingList.GetRowCellValue(i, "ShipmentID").ToString());

                        packingRow = dataTablePackingList.NewRow();
                        packingRow["ShipBoxNo"] = shipBoxNo;
                        packingRow["ItemCode"] = itemCode;
                        packingRow["ActItemNumber"] = actItemNumber;
                        packingRow["ShippingStatusName"] = shippingStatusName;
                        packingRow["ShippedQty"] = shippedQty;
                        packingRow["CustomerCode"] = customerCode;
                        packingRow["POType"] = pOType;
                        packingRow["ShippedDate"] = shippedDate;
                        packingRow["ShipmentID"] = shipmentID;

                        dataTablePackingList.Rows.Add(packingRow);
                    }
                }

                for (int i = gvPendingList.RowCount; i >= 0; i--)
                {
                    bool isSelected = gvPendingList.IsRowSelected(i);
                    if (isSelected)
                    {
                        gvPendingList.DeleteRow(i);
                    }
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
                XtraMessageBox.Show("Failed to packing!" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void picLeft_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataRow PendingRow;
            try
            {
                for (int i = 0; i < gvPalletize.RowCount; i++)
                {
                    bool isSelected = gvPalletize.IsRowSelected(i);
                    if (isSelected)
                    {
                        string shipBoxNo = Convert.ToString(gvPalletize.GetRowCellValue(i, "ShipBoxNo"));
                        string itemCode = Convert.ToString(gvPalletize.GetRowCellValue(i, "ShippingStatusName"));
                        string actItemNumber = Convert.ToString(gvPalletize.GetRowCellValue(i, "ActItemNumber"));
                        string shippingStatusName = Convert.ToString(gvPalletize.GetRowCellValue(i, "ShippingStatusName"));
                        Int16 shippedQty = Convert.ToInt16(gvPalletize.GetRowCellValue(i, "ShippedQty").ToString());
                        string customerCode = Convert.ToString(gvPalletize.GetRowCellValue(i, "CustomerCode"));
                        string pOType = Convert.ToString(gvPalletize.GetRowCellValue(i, "POType"));
                        DateTime shippedDate = Convert.ToDateTime(gvPalletize.GetRowCellValue(i, "ShippedDate").ToString());
                        Int16 shipmentID = Convert.ToInt16(gvPalletize.GetRowCellValue(i, "ShipmentID").ToString());

                        PendingRow = dataTablePendingList.NewRow();
                        PendingRow["ShipBoxNo"] = shipBoxNo;
                        PendingRow["ItemCode"] = itemCode;
                        PendingRow["ActItemNumber"] = actItemNumber;
                        PendingRow["ShippingStatusName"] = shippingStatusName;
                        PendingRow["ShippedQty"] = shippedQty;
                        PendingRow["CustomerCode"] = customerCode;
                        PendingRow["POType"] = pOType;
                        PendingRow["ShippedDate"] = shippedDate;
                        PendingRow["ShipmentID"] = shipmentID;

                        dataTablePendingList.Rows.Add(PendingRow);
                    }
                }

                for (int i = gvPalletize.RowCount; i >= 0; i--)
                {
                    bool isSelected = gvPalletize.IsRowSelected(i);
                    if (isSelected)
                    {
                        gvPalletize.DeleteRow(i);
                    }
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
                XtraMessageBox.Show("Failed to packing!" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void btnCreatePallet_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strPalletNo;
            int poPalletID;
            try
            {
                if (gvPalletize.RowCount == 0) return;

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                {
                    using (eSolutionDataContext db = new eSolutionDataContext())
                    {
                        DateTime dtServerDate = Convert.ToDateTime(db.fn_ServerDateTime().ToString());

                        strPalletNo = dtServerDate.ToString("yyMMddHHmmss");
                        //palletNo = Convert.ToInt32(dtServerDate.ToString("yyMMddHHmmss"));

                        var qryPalletCnt = (from obj in db.POPalletInfos
                                            where obj.PalletNo == Convert.ToDecimal(strPalletNo)
                                            select obj).Count();

                        if (qryPalletCnt > 0)
                        {
                            XtraMessageBox.Show(string.Format("Already using the pallet no [{0}]", strPalletNo.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        POPalletInfo pOPalletInfo = new POPalletInfo();
                        pOPalletInfo.PalletNo = Convert.ToDecimal(strPalletNo);
                        pOPalletInfo.PalletDate = dtServerDate;
                        pOPalletInfo.CreatedDate = dtServerDate;
                        pOPalletInfo.CreatedHostName = Environment.MachineName;
                        db.POPalletInfos.InsertOnSubmit(pOPalletInfo);

                        db.SubmitChanges();

                        poPalletID = (from obj in db.POPalletInfos
                                      where obj.PalletNo == Convert.ToDecimal(strPalletNo)
                                    select obj.POPalletID).FirstOrDefault();

                        txtPalletID.Text = strPalletNo;

                        for (int i = 0; i < gvPalletize.RowCount; i++)
                        {
                            Int16 shipmentID = Convert.ToInt16(gvPalletize.GetRowCellValue(i, "ShipmentID").ToString());

                            var qryShipment = (from obj in db.POShipments
                                               where obj.ShipmentID == shipmentID
                                               select obj).FirstOrDefault();

                            qryShipment.POPalletID = poPalletID;
                            qryShipment.ModifiedCompName = Environment.MachineName;
                            qryShipment.ModifiedDate = dtServerDate;
                        }

                        txtPalletID_Info.EditValue = strPalletNo;
                        db.SubmitChanges();
                    }
                    scope.Complete();
                }

                if (chkPackingList.Checked == true)
                {
                    // print packing list
                    try
                    {
                        if (!string.IsNullOrEmpty(strPalletNo))
                        {
                            decimal palletNo = Convert.ToDecimal(strPalletNo);
                            string customerCode = Convert.ToString(gvPalletize.GetRowCellValue(1, "CustomerCode"));

                            string location = "";
                            if (customerCode == "CVE")
                            {
                                if (chkAllen.Checked)
                                {
                                    location = "ALLEN";
                                }
                                else if (chkPlano.Checked)
                                {
                                    location = "PLANO";
                                }
                                else
                                {
                                    XtraMessageBox.Show("Please, check to Ship Location.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                location = "";
                            }
                            prtPackingList rpt = new prtPackingList();
                            rpt.Parameters["palletNo"].Value = palletNo;
                            rpt.Parameters["location"].Value = location;
                            rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                            rpt.Print();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Could not print packing list." + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                XtraMessageBox.Show("Completed Palletizing." , "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnResetPallet.PerformClick();
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
                XtraMessageBox.Show("Failed to packing!" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void btnResetPallet_Click(object sender, EventArgs e)
        {
            // button setting
            btnCreatePallet.Enabled = true;
            btnUpdatePallet.Enabled = false;
            btnCancelPalletize.Enabled = false;

            txtPalletID.Text = "";
            gcPalletize.DataSource = null;
            CreateNewDataRow();

            btnSearchPendingBox.PerformClick();
        }

        private void btnCancelPalletize_Click(object sender, EventArgs e)
        {
            try
            {
                string strPalletNo = txtPalletID.Text.Trim();
                DialogResult result = XtraMessageBox.Show(string.Format("Would you like to Cancel to Pallet [{0}] ? ", strPalletNo), "Question!",  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.No) return;

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                {
                    using (eSolutionDataContext db = new eSolutionDataContext())
                    {
                        DateTime dtServerDate = Convert.ToDateTime(db.fn_ServerDateTime().ToString());

                        if (string.IsNullOrEmpty(strPalletNo)) return;

                        var qryShips = from shp in db.POShipments
                                      from plt in db.POPalletInfos
                                      where shp.POPalletID == plt.POPalletID
                                      && plt.PalletNo == Convert.ToDecimal(strPalletNo)
                                      select shp;


                        foreach (POShipment shp in qryShips)
                        {
                            shp.POPalletID = null;
                            shp.ModifiedCompName = Environment.MachineName;
                            shp.ModifiedDate = dtServerDate;
                        }
                        var qryPlt = (from plt in db.POPalletInfos
                                      where plt.PalletNo == Convert.ToDecimal(strPalletNo)
                                      select plt).FirstOrDefault();
                        db.POPalletInfos.DeleteOnSubmit(qryPlt);

                        db.SubmitChanges();
                    }
                    scope.Complete();
                }
                XtraMessageBox.Show("Cancelled palletizied!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnResetPallet.PerformClick();

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
                XtraMessageBox.Show("failed to retrieveing for Pallet" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void txtPalletID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPalletID_KeyDown(object sender, KeyEventArgs e)
        {
            string strPalletID = txtPalletID.Text.Trim();
            if (string.IsNullOrEmpty(strPalletID))
            {
                txtPalletID.Focus();
                return;
            }

            if (e.Handled)
            {
                txtPalletID.Focus();
                return;
            }

            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                    {
                        using (eSolutionDataContext db = new eSolutionDataContext())
                        {
                            string strPalletNo = txtPalletID.Text.Trim();
                            if (string.IsNullOrEmpty(strPalletNo)) return;

                            var qry = db.stp_POPalletInfo_Select("%", "%", strPalletNo);

                            if (qry != null)
                            {
                                dataTablePackingList = Functions.LINQToDataTable(qry);
                                gcPalletize.DataSource = dataTablePackingList;

                                // Button Setting
                                btnCreatePallet.Enabled = false;
                                btnUpdatePallet.Enabled = true;
                                btnCancelPalletize.Enabled = true;

                                btnPrint.Enabled = true;

                            }
                            else
                            {
                                gcPalletize.DataSource = null;
                                XtraMessageBox.Show(string.Format("Could not found the Pallet No[{0}]!", strPalletNo), "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                // button setting
                                btnCreatePallet.Enabled = true;
                                btnUpdatePallet.Enabled = false;
                                btnCancelPalletize.Enabled = false;

                                btnPrint.Enabled = false;

                                txtPalletID.Focus();
                                return;
                            }
                        }
                        scope.Complete();
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
                    XtraMessageBox.Show(string.Format("Could not found the Pallet No[{0}]!", strPalletID) + Environment.NewLine + errMsg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void chkAllen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllen.Checked)
            {
                chkPlano.Checked = false;
            }
        }


        private void chkPlano_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlano.Checked)
            {
                chkAllen.Checked = false;
            }

        }

        private void chkPackingList_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void picRight_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barStaticItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strPalletNo;
            // print packing list
            try
            {
                strPalletNo = txtPalletID.EditValue.ToString();

                if (!string.IsNullOrEmpty(strPalletNo))
                {
                    decimal palletNo = Convert.ToDecimal(strPalletNo);
                    string customerCode = Convert.ToString(gvPalletize.GetRowCellValue(1, "CustomerCode"));

                    string location = "";
                    if (customerCode == "CVE")
                    {
                        if (chkAllen.Checked)
                        {
                            location = "ALLEN";
                        }
                        else if (chkPlano.Checked)
                        {
                            location = "PLANO";
                        }
                        else
                        {
                            XtraMessageBox.Show("Please, check to Ship Location.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        location = "";
                    }
                    prtPackingList rpt = new prtPackingList();
                    rpt.Parameters["palletNo"].Value = palletNo;
                    rpt.Parameters["location"].Value = location;
                    rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                    rpt.Print();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Could not print packing list." + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}