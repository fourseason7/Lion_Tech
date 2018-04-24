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
using DevExpress.XtraGrid.Views;
using System.Transactions;
using DevExpress.XtraEditors.Repository;
using eSolution.Database;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;

namespace eSolution.WinfrmBasic
{
    public partial class frmPacking : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();
        DataTable dTableCustomerItemList;
        Int16 pOdetailID;

        public struct _QRCode
        {
            public string QRCode;
            public string PONumber;
            public int LineNumber;
            public string SupplierID;
            public string ItemCode;
            public int ItemQuantity;
            public string FactoryCode;
            public string ProductionDate;  //YYMMDD
            public string ShipDate; //YYMMDD
            public int SerialNumber;
            public string MaterialSource; // Reclaim Supply
            public int OrderQty;
            public int ShippedQty;
            public int RemainQty;
            public int ID; // po detail id
            public string CVEReserved1;
            public string CVEReserved2;
            public string SupplierSection;
        }
        public struct _ShipBoxLable
        {
            public string ShipBoxNo;
            public string Quantity;
            public string Model;
            public string ItemCode;
            public string Status;
            public string ShipDate;
            public string Date;
            public string Shipper;
            public string PONumber;
        }
        public frmPacking()
        {
            InitializeComponent();
        }
        public void Initialized()
        {
            //Functions.QueryCmbSetYesNoAll(ref lueSearchUseYN);
            //Functions.QueryCmbSetYesNo(ref lueUseYN);
            Functions.QueryCmbCustomerList(db, ref lueSearchCustomer);
            string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();

            Functions.QueryCmbUserCodeData(db, ref lueSearchPOType, lueSearchPOType.Tag.ToString(), "", true);
            string pOtype = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();

            Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOtype, "N", true);

            Functions.QueryCmbShippingStatus(db, ref lueShippingStatus, pOtype);


            dtSearchDateFrom.EditValue = Convert.ToDateTime(db.fn_ServerDateTime()).AddDays(-7);
            dtSearchDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtSearchDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            dtSearchDateTo.EditValue = (DateTime?)db.fn_ServerDateTime();

            lueSearchCustomer.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchCustomer.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchPOType.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchPOType.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchPO.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchPO.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSearchItem.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSearchItem.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueShippingStatus.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueShippingStatus.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;


            lueItemNumber.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueItemNumber.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtShippingQty.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtShippingQty.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            dtShippingDate.EditValue = (DateTime?)db.fn_ServerDateTime();
            dtShippingDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtShippingDate.Properties.Mask.EditMask = "MM/dd/yyyy";

            txtRemark.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtRemark.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;


            dtShippingDate.Properties.AppearanceFocused.BackColor = Color.Yellow;
            dtShippingDate.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;


            dtShippingDate.EditValue = db.fn_ServerDateTime().ToString();

            gvList.OptionsSelection.EnableAppearanceFocusedCell = true;
            gvList.OptionsSelection.EnableAppearanceFocusedRow = true;
            gvList.Appearance.FocusedRow.BackColor = Color.Yellow; // Color.FromArgb(255, 255, 192);
            gvList.Appearance.SelectedRow.BackColor = Color.Yellow; // Color.FromArgb(255, 255, 192)
            gvList.Appearance.SelectedRow.Options.UseBackColor = true;

            barEditLabelShift.EditValue = 20;
            barEditLabelX.EditValue = 0;
            barEditLabelY.EditValue = 0;
        }
        public DataTable GetCustomerItemList(string CustomerCode, string RSType)
        {
            DataTable dt = new DataTable();
            DataColumn colValue = new DataColumn();
            DataColumn colText = new DataColumn();
            DataRow newRow;

            //select *
            //  from ItemByCustomer a
            //     , Customer b
            // where b.CustomerID = a.CustomerID
            //   and b.CustomerCode = 'CVE'
            //   and a.ItemType like '%S%'

            try
            {
                colText.ColumnName = HelperClass.DisplayName;
                colValue.ColumnName = HelperClass.CodeName;
                colText.DataType = typeof(System.String);
                colValue.DataType = typeof(System.String);

                dt.Columns.Add(colText);
                dt.Columns.Add(colValue);

                var sqlQuery = from itm in db.ItemByCustomers
                               from cst in db.Customers
                               from mst in db.ItemMasters
                               where itm.CustomerID == cst.CustomerID
                               && mst.ItemID == itm.ItemNumberID
                               && mst.UseYN == true
                               && cst.CustomerCode == CustomerCode
                               && itm.ItemType.Contains(RSType)
                               select new
                               {
                                   ItemNumber = mst.ItemCode
                               };
                foreach (var row in sqlQuery)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = row.ItemNumber;
                    newRow[HelperClass.CodeName] = row.ItemNumber;
                    dt.Rows.Add(newRow);
                }
            }
            catch
            {
                dt = null;
            }
            finally
            {
            }
            return dt;
        }
        public void QueryCmbCustomerItemList(DataTable dt, ref LookUpEdit cmbName)
        {
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
        public void ResetShipGroup()
        {
            txtPODetailID.EditValue = "";
            txtPONo.EditValue = "";
            txtPOLine.EditValue = "";
            txtItemCode.EditValue = "";
            lueItemNumber.EditValue = "";
            txtRemaingQty.Text = "";
            lueShippingStatus.ItemIndex = 0;
            txtShippingQty.EditValue = "";
            dtShippingDate.EditValue = db.fn_ServerDateTime().ToString();
            txtRemark.Text = "";
        }
        public void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime dtFromDate, dtToDate;
            string strFromDate, strToDate;

            string strSearchCustomer;
            string strSearchPOType;
            string strSearchPONumber;
            string strSearchItem;

            gcList.DataSource = null;
            gvList.Columns.Clear();

            try
            {
                dtFromDate = Convert.ToDateTime(dtSearchDateFrom.EditValue);
                dtToDate = Convert.ToDateTime(dtSearchDateTo.EditValue).AddDays(1);
                strFromDate = Functions.FunctionDateToString(dtFromDate, 0);
                strToDate = Functions.FunctionDateToString(dtToDate, 0);

                strSearchCustomer = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                if (string.IsNullOrEmpty(strSearchCustomer)) strSearchCustomer = "%";

                strSearchPOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                if (string.IsNullOrEmpty(strSearchPOType)) strSearchPOType = "%";

                strSearchPONumber = lueSearchPO.Properties.GetKeyValueByDisplayText(lueSearchPO.Text).ToString();
                if (string.IsNullOrEmpty(strSearchPONumber)) strSearchPONumber = "%";

                strSearchItem = txtSearchItem.Text.ToString();
                if (string.IsNullOrEmpty(strSearchItem)) strSearchItem = "%";

                var qry = db.stp_PODetail_Packing_Select(dtFromDate, dtToDate, strSearchCustomer, strSearchPOType, strSearchPONumber, strSearchItem, "%");
                if (qry != null)
                {
                    gcList.DataSource = qry.ToList();
                    if (gvList.RowCount > 0)
                    {
                        gvList.Columns["CustomerName"].Visible = false;
                        gvList.Columns["Status"].Visible = false;
                        gvList.Columns["POHeaderID"].Visible = false;
                        gvList.Columns["PODetailID"].Visible = false;
                        gvList.Columns["CustomerID"].Visible = false;
                        gvList.Columns["ItemID"].Visible = false;
                        gvList.Columns["HeaderStatus"].Visible = false;

                        // Set Display format
                        gvList.Columns["POLineNumber"].Caption = "Line";
                        gvList.Columns["ReceiveQty"].Caption = "RCV QTY";
                        gvList.Columns["ShipRefurbishedQty"].Caption = "Refurbished";
                        gvList.Columns["ShipRefurbishedFPCBQty"].Caption = "Refurbished-FPCB";
                        gvList.Columns["ShipFrontOnly"].Caption = "Front Only";
                        gvList.Columns["ShipFunctionFailQty"].Caption = "Function Fail";
                        gvList.Columns["ShipDIPQty"].Caption = "DIP";
                        gvList.Columns["ShipNMPQty"].Caption = "NMP";
                        gvList.Columns["ShipSampleQty"].Caption = "Sample";
                        gvList.Columns["ShipNTFQty"].Caption = "NTF";
                        gvList.Columns["ShipOutOfWarranty"].Caption = "OOW";
                        gvList.Columns["ShipCustomerAbuse"].Caption = "Customer Abuse";
                        gvList.Columns["ShipTotalQty"].Caption = "Total";
                        gvList.Columns["InventoryQty"].Caption = "Remain";

                        gvList.Columns["ReceiveQty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ReceiveQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipRefurbishedQty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipRefurbishedQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipRefurbishedFPCBQty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipRefurbishedFPCBQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipFrontOnly"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipFrontOnly"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipFunctionFailQty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipFunctionFailQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipDIPQty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipDIPQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipNMPQty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipNMPQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipSampleQty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipSampleQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipNTFQty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipNTFQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipOutOfWarranty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipOutOfWarranty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipCustomerAbuse"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipCustomerAbuse"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["ShipTotalQty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["ShipTotalQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gvList.Columns["InventoryQty"].DisplayFormat.FormatString = "#,##0";
                        gvList.Columns["InventoryQty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        switch (strSearchPOType)
                        {
                            case "%":
                                string[] arr1 = { "CustomerCode", "POHeaderID", "HeaderStatus", "PODetailID", "CustomerID", "ItemID" };
                                Functions.SetInvisible(ref gvList, arr1);
                                break;
                            case "RMA":
                                //string[] arr2 = { "ShipFrontOnly", "ShipFunctionFailQty", "ShipDIPQty", "ShipNMPQty", "ShipSampleQty", "CustomerCode", "POHeaderID", "HeaderStatus", "PODetailID", "CustomerID", "ItemID" };
                                string[] arr2 = { "CustomerCode", "POHeaderID", "HeaderStatus", "PODetailID", "CustomerID", "ItemID" };
                                Functions.SetInvisible(ref gvList, arr2);
                                break;
                            case "REGULAR":
                                //string[] arr3 = { "ShipRefurbishedQty", "ShipNTFQty", "ShipOutOfWarranty", "ShipCustomerAbuse", "CustomerCode", "POHeaderID", "HeaderStatus", "PODetailID", "CustomerID", "ItemID" };
                                string[] arr3 = { "CustomerCode", "POHeaderID", "HeaderStatus", "PODetailID", "CustomerID", "ItemID" };
                                Functions.SetInvisible(ref gvList, arr3);
                                break;
                        }
                        gvList.Columns["POType"].BestFit();
                        gvList.Columns["PONumber"].BestFit();
                        gvList.Columns["OrderDate"].BestFit();
                        gvList.Columns["ItemNumber"].BestFit();
                        gvList.Columns["POLineNumber"].BestFit();
                        gvList.Columns["ReceiveQty"].BestFit();
                        gvList.Columns["ShipRefurbishedQty"].BestFit();
                        gvList.Columns["ShipRefurbishedFPCBQty"].BestFit();
                        gvList.Columns["ShipFrontOnly"].BestFit();


                        //gvList.BestFitColumns();
                        gvList.OptionsBehavior.ReadOnly = true;

                        //gvList.FocusedRowHandle = 0;
                        dTableCustomerItemList = GetCustomerItemList(txtCustomerCode.Text, "S");
                        QueryCmbCustomerItemList(dTableCustomerItemList, ref lueItemNumber);

                        //// get previous detaild id
                        //for (int i = 0; i <= (gvList.RowCount - 1); i++)
                        //{
                        //    int tmp = Convert.ToInt16(gvList.GetRowCellValue(i, "PODetailID"));
                        //    if (tmp == pOdetailID)
                        //    {
                        //        //gvList.SelectRow(i);
                        //        gvList.FocusedRowHandle = i;
                        //    }
                        //}
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
                MessageBox.Show("Couldn't Search P/O Detail List!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private Boolean Validation()
        {
            string strCustomerCode, strPONumber, strItemCode, strItemShipping, strShippingStatus, strShippingStatusName;
            string strShippingType, strItem;
            int intPOLineNumber, intPODetailID, intOrderQty, intShipQty, intRemainQty;
            try
            {
                strCustomerCode = txtCustomerCode.EditValue.ToString();
                strPONumber = txtPONo.EditValue.ToString();
                intPOLineNumber = Convert.ToInt16(txtPOLine.EditValue.ToString());
                strItemCode = txtItemCode.EditValue.ToString();
                strItemShipping = lueItemNumber.EditValue.ToString().Trim();
                strItem = txtItem.Text;
                strShippingStatus = lueShippingStatus.Properties.GetKeyValueByDisplayText(lueShippingStatus.Text).ToString();
                strShippingStatusName = lueShippingStatus.Text;
                if (string.IsNullOrEmpty(strShippingStatus))
                {
                    MessageBox.Show("Please, Select to Shipping Type!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueShippingStatus.Focus();
                    return false;
                }

                //if (strItem.Substring(0, strItem.IndexOf("_")) != strItemShipping.Substring(strItemShipping.IndexOf("_")))
                //{
                //    MessageBox.Show("Item Number is not correct!" + Environment.NewLine + "Please, check the Item Number!");
                //    lueItemNumber.Focus();
                //    return false;
                //}
                try
                {
                    char sp = '-';
                    string[] spStrItem = strItem.Split(sp);
                    string[] spStrItemNumber = strItemShipping.Split(sp);
                    if (spStrItem[0] + spStrItem[1] != spStrItemNumber[0] + spStrItemNumber[1])
                    {
                        MessageBox.Show("Item Number is not correct!" + Environment.NewLine + "Please, check the Item Number!");
                        lueItemNumber.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Item Number is not correct!" + Environment.NewLine + "Please, check the Item Number!");
                    lueItemNumber.Focus();
                    return false;
                }

                intPODetailID = Convert.ToInt16(txtPODetailID.EditValue.ToString());
                pOdetailID = Convert.ToInt16(intPODetailID);

                try { intShipQty = Convert.ToInt16(txtShippingQty.EditValue.ToString()); } catch { intShipQty = 0; }
                if (intShipQty == 0)
                {
                    MessageBox.Show("Please, check the ShippedQty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtShippingQty.Focus();
                    return false;
                }
                intRemainQty = Convert.ToInt16(txtRemaingQty.EditValue.ToString());
                if (intRemainQty == 0)
                {
                    MessageBox.Show("Please, check the Remain Qty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtShippingQty.Focus();
                    return false;

                }
                intOrderQty = Convert.ToInt16(txtOrderQty.EditValue.ToString());
                if (intShipQty > intRemainQty)
                {
                    MessageBox.Show("Shipping QTY greather than Remain QTY!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtShippingQty.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(dtShippingDate.EditValue.ToString()))
                {
                    MessageBox.Show("Please, select to correct shipping date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtShippingDate.Focus();
                    return false;
                }
                strShippingType = strShippingStatus.Substring(0, 1);
                if (strShippingType == "G")
                {
                    if (!strItemShipping.EndsWith("_R"))
                    {
                        MessageBox.Show("Please, select to correct Item Number." + Environment.NewLine + "Finished Good Units need to '_R' item only!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lueItemNumber.Focus();
                        return false;
                    }
                }
                //sHipBox.Status = strShippingStatus;

                return true;
            }
            catch
            {
                return false;
            }
        }

        private Boolean SaveData()
        {
            string strCustomerCode, strPONumber, strItemCode, strItemShipping, strShipBoxNo, strShippingType, strShippingStatus, strRemark, strShippingStatusName;
            DateTime dtShippDate, dtServerDate;
            int intPOLineNumber, intPODetailID, intOrderQty, intShipQty, intRemainQty, intStartNo;
            try
            {
                strCustomerCode = txtCustomerCode.EditValue.ToString();
                strPONumber = txtPONo.EditValue.ToString();
                intPOLineNumber = Convert.ToInt16(txtPOLine.EditValue.ToString());
                strItemCode = txtItemCode.EditValue.ToString();
                strItemShipping = lueItemNumber.EditValue.ToString().Trim();
                //if (!strItemShipping.EndsWith("_R"))
                //{
                //    strItemShipping = strItemShipping + "_R";
                //}
                strShippingStatus = lueShippingStatus.Properties.GetKeyValueByDisplayText(lueShippingStatus.Text).ToString();
                strShippingStatusName = lueShippingStatus.Text;
                if (string.IsNullOrEmpty(strShippingStatus))
                {
                    MessageBox.Show("Please, Select to Shipping Type!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueShippingStatus.Focus();
                    return false;
                }
                intPODetailID = Convert.ToInt16(txtPODetailID.EditValue.ToString());
                pOdetailID = Convert.ToInt16(intPODetailID);

                try { intShipQty = Convert.ToInt16(txtShippingQty.EditValue.ToString()); } catch { intShipQty = 0; }
                if (intShipQty == 0)
                {
                    MessageBox.Show("Please, check the ShippedQty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtShippingQty.Focus();
                    return false;
                }
                intRemainQty = Convert.ToInt16(txtRemaingQty.EditValue.ToString());
                if ( intRemainQty == 0)
                {
                    MessageBox.Show("Please, check the Remain Qty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtShippingQty.Focus();
                    return false;

                }
                intOrderQty = Convert.ToInt16(txtOrderQty.EditValue.ToString());

                if (intShipQty > intRemainQty)
                {
                    MessageBox.Show("Shipping QTY greather than Remain QTY!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtShippingQty.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(dtShippingDate.EditValue.ToString()))
                {
                    MessageBox.Show("Please, select to correct shipping date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtShippingDate.Focus();
                    return false;
                }
                dtShippDate = Convert.ToDateTime(dtShippingDate.DateTime.ToString());
                strRemark = Convert.ToString(txtRemark.Text);

                //var qry = (from obj in db.POShipments
                //           where obj.PODetailID == intPODetailID
                //           && obj.ShippingStatus.StartsWith("G")
                //           orderby obj.ShipmentID descending
                //           select obj).Take(1).FirstOrDefault();
                strShippingType = strShippingStatus.Substring(0, 1);
                if (strShippingType == "G")
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                    {

                        using (eSolutionDataContext db = new eSolutionDataContext())
                        {
                            var qryStartno = (from obj in db.PODetails
                                              where obj.PODetailID == intPODetailID
                                              select obj).FirstOrDefault();
                            if (qryStartno == null)
                            {
                                intStartNo = 1;
                            }
                            else
                            {
                                intStartNo = qryStartno.ShipRefurbishedQty
                                    + qryStartno.ShipFrontOnly
                                    + qryStartno.ShipSampleQty
                                    + qryStartno.ShipNTFQty;
                                intStartNo = intStartNo + 1;
                                //intStartNo = Convert.ToInt16(qry.ShippedQty) + Convert.ToInt16(qry.StartNo) + 1;
                            }
                        }

                    }
                }
                else
                {
                    intStartNo = 0;
                }



                //intStartNo = (from obj in db.PODetails
                //              where obj.PODetailID == intPODetailID
                //              select obj.ShipGoodQty).FirstOrDefault() + 1;

                //intStartNo = intOrderQty - intRemainQty + 1;

                // 
                _QRCode qRCode = new _QRCode();
                qRCode.PONumber = strPONumber;
                qRCode.LineNumber = intPOLineNumber;
                qRCode.ItemCode = strItemShipping;
                qRCode.ItemQuantity = intShipQty;
                qRCode.ProductionDate = dtShippDate.ToString("yyMMdd");
                qRCode.ShipDate = dtShippDate.ToString("yyMMdd");
                qRCode.SerialNumber = intStartNo;
                qRCode.SupplierID = "EG2";
                qRCode.MaterialSource = "R";
                _ShipBoxLable sHipBox = new _ShipBoxLable();
                sHipBox.PONumber = strPONumber;
                sHipBox.Model = strItemCode;
                sHipBox.ItemCode = strItemShipping;
                sHipBox.Quantity = intShipQty.ToString();

                //strShippingType = strShippingStatus.Substring(0, 1);
                //if (strShippingType == "G")
                //{
                //    sHipBox.Status = "Good";
                //}
                //else if (strShippingType == "F")
                //{
                //    sHipBox.Status = "Function Fail";
                //}
                //else
                //{
                //    sHipBox.Status = "DIP";
                //}
                //sHipBox.Status = strShippingStatus;
                sHipBox.Status = strShippingStatusName;
                //sHipBox.Date = dtShippDate.ToString("MM/dd/yyyy");
                if (dtShippDate.ToString("MM/dd/yyyy") == "04/01/2017")
                    sHipBox.Date = "03/31/2017";
                else
                    sHipBox.Date = dtShippDate.ToString("MM/dd/yyyy");


                sHipBox.Shipper = "EG2 Mobile Technology";

                Cursor.Current = Cursors.WaitCursor;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                {
                    using (eSolutionDataContext db = new eSolutionDataContext())
                    {
                        strShipBoxNo = db.fn_GetShipBoxNo(strCustomerCode);
                        dtServerDate = Convert.ToDateTime(db.fn_ServerDateTime().ToString());

                        sHipBox.ShipBoxNo = strShipBoxNo;

                        POShipment pOShipment = new POShipment();
                        pOShipment.PODetailID = intPODetailID;
                        pOShipment.PONumber = strPONumber;
                        pOShipment.POLineNumber = intPOLineNumber;
                        pOShipment.ItemCode = strItemCode;
                        pOShipment.ItemNumber = strItemShipping;
                        pOShipment.ShippingStatus = strShippingStatus;
                        pOShipment.ShippedQty = intShipQty;
                        pOShipment.ShippedDate = dtShippDate;
                        pOShipment.ShipBoxNo = strShipBoxNo;
                        pOShipment.Remark = strRemark;
                        pOShipment.CreateDate = dtServerDate;
                        pOShipment.CreateCompName = Environment.MachineName;
                        pOShipment.ModifiedDate = dtServerDate;
                        pOShipment.ModifiedCompName= Environment.MachineName;


                        var qryDetail = (from dtl in db.PODetails
                                         where dtl.PODetailID == intPODetailID
                                         select dtl).FirstOrDefault();
                        // 

                        //qRCode.SerialNumber = qryDetail.ShipGoodQty + 1;
                        pOShipment.StartNo = qRCode.SerialNumber;

                        db.POShipments.InsertOnSubmit(pOShipment);

                        //if (strShippingType == "G")
                        //{
                        //    qryDetail.ShipGoodQty = qryDetail.ShipGoodQty + intShipQty;
                        //}
                        //else if (strShippingType == "F")
                        //{
                        //    qryDetail.ShipFunctionFailQty = qryDetail.ShipFunctionFailQty + intShipQty;
                        //}
                        //else
                        //{
                        //    qryDetail.ShipDIPQty = qryDetail.ShipDIPQty + intShipQty;
                        //}
                        //CodeName CodeSeq CodeDescription
                        //GREF    1   Refurbished
                        //GFRO    2   Front Only
                        //DDEF    3   Defective
                        //FRFF    4   Receiving Function Fail
                        //GSMP    5   Sample
                        //GNTF    6   NTF
                        //ROOW    7   Out Of Warrnty
                        //RCTA    8   Customer Abuse
                        switch (strShippingStatus)
                        {
                            case "GREF":
                                qryDetail.ShipRefurbishedQty = qryDetail.ShipRefurbishedQty + intShipQty;
                                break;
                            case "GFCL":
                                qryDetail.ShipRefurbishedFPCBQty = qryDetail.ShipRefurbishedFPCBQty + intShipQty;
                                break;
                            case "GFRO":
                                qryDetail.ShipFrontOnly = qryDetail.ShipFrontOnly + intShipQty;
                                break;
                            case "DDEF":
                            case "DIP":
                                qryDetail.ShipDIPQty = qryDetail.ShipDIPQty + intShipQty;
                                break;
                            case "FRFF":
                                qryDetail.ShipFunctionFailQty = qryDetail.ShipFunctionFailQty + intShipQty;
                                break;
                            case "GSMP":
                                qryDetail.ShipSampleQty = qryDetail.ShipSampleQty + intShipQty;
                                break;
                            case "GNTF":
                                qryDetail.ShipNTFQty = qryDetail.ShipNTFQty + intShipQty;
                                break;
                            case "ROOW":
                                qryDetail.ShipOutOfWarranty = qryDetail.ShipOutOfWarranty + intShipQty;
                                break;
                            case "RCTA":
                                qryDetail.ShipCustomerAbuse = qryDetail.ShipCustomerAbuse + intShipQty;
                                break;
                            case "NMP":
                                qryDetail.ShipNMPQty = qryDetail.ShipNMPQty + intShipQty;
                                break;
                        }

                        if (qryDetail.RemainQty - intShipQty == 0)
                        {
                            qryDetail.Status = true;
                        }
                        qryDetail.CreatedDate = dtServerDate;
                        qryDetail.CreatedHostName = Environment.MachineName;

                        qryDetail.ModifiedDate = dtServerDate;
                        qryDetail.ModifiedHostName = Environment.MachineName;

                        db.SubmitChanges();

                        var qryCloseStatus = (from obj in db.PODetails
                                              where obj.PONumber == strPONumber
                                              && obj.Status == false
                                              select obj).Count();

                        if (qryCloseStatus == 0)
                        {
                            var qryHdr = (from hdr in db.POHeaders
                                          where hdr.PONumber == strPONumber
                                          select hdr).FirstOrDefault();
                            qryHdr.Status = true;
                            qryHdr.ModifiedDate = dtServerDate;
                            qryHdr.ModifiedCompName = Environment.MachineName;
                        }
                        db.SubmitChanges();
                    }
                    scope.Complete();

                    if (strShippingType == "G")
                    {
                        Boolean blnReturn = PrintQRCodeLabel(Properties.Settings.Default.PrintQRCode, qRCode);
                    }
                    if (chkShipBoxLabel.Checked == true)
                    {
                        Boolean blnReturn = PrintShipBoxLabel(Properties.Settings.Default.PrintShipBox, sHipBox);
                    }

                }

                MessageBox.Show("Save completed for shipping Qty.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not save to Packing!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //db.Dispose();
            }
        }
        public Boolean PrintShipBoxLabel(string lptPort, _ShipBoxLable ShipBoxID)
        {
            try
            {
                string zpl = "";
                string nl = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
                zpl = zpl + Environment.NewLine + "^XA";
                zpl = zpl + Environment.NewLine + "^MMT";
                //zpl = zpl + Environment.NewLine + "^LS130";
                zpl = zpl + Environment.NewLine + String.Format("^LH{0},{1}", Convert.ToInt16(barEditLabelX.EditValue.ToString()).ToString(), Convert.ToInt16(barEditLabelY.EditValue.ToString()).ToString());
                zpl = zpl + Environment.NewLine + string.Format("^LS{0}", Convert.ToInt16(barEditLabelShift.EditValue.ToString()).ToString());
                zpl = zpl + Environment.NewLine + "^FO0080,0080^GB0730,1100,4^FS"; // outline
                zpl = zpl + Environment.NewLine + "^FO0080,0850^GB0730,0000,4^FS"; // separate line
                zpl = zpl + Environment.NewLine + "^FT0160,1100^A0B,58,58^FDBox ID^FS";
                zpl = zpl + Environment.NewLine + "^FT0160,0800^A0B,58,58^FD" + ShipBoxID.ShipBoxNo + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0230,0800^BY3,3,50^BCB,,N,N^FD" + ShipBoxID.ShipBoxNo + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0300,1100^A0B,58,58^FDQuantity^FS";
                zpl = zpl + Environment.NewLine + "^FT0300,0800^A0B,58,58^FD" + ShipBoxID.Quantity + "^FS";

                //zpl = zpl + Environment.NewLine + "^FT0370,1100^A0B,58,58^FDModel^FS";
                //zpl = zpl + Environment.NewLine + "^FT0370,0800^A0B,58,58^FD" + ShipBoxID.Model + "^FS";
                //zpl = zpl + Environment.NewLine + "^FT0440,1100^A0B,58,58^FDItem#^FS";
                //zpl = zpl + Environment.NewLine + "^FT0440,0800^A0B,58,58^FD" + ShipBoxID.ItemCode + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0370,1100^A0B,58,58^FDItem#^FS";
                zpl = zpl + Environment.NewLine + "^FT0370,0800^A0B,58,58^FD" + ShipBoxID.ItemCode + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0440,0800^BY3,3,50^BCB,,N,N^FD" + ShipBoxID.ItemCode + "^FS";

                //zpl = zpl + Environment.NewLine + "^FT0370,1100^A0B,58,58^FDModel^FS";
                //zpl = zpl + Environment.NewLine + "^FT0370,0800^A0B,58,58^FD" + ShipBoxID.Model + "^FS";
                //zpl = zpl + Environment.NewLine + "^FT0440,1100^A0B,58,58^FDItem#^FS";
                //zpl = zpl + Environment.NewLine + "^FT0440,0800^A0B,58,58^FD" + ShipBoxID.ItemCode + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0510,1100^A0B,58,58^FDStatus^FS";
                zpl = zpl + Environment.NewLine + "^FT0510,0800^A0B,58,58^FD" + ShipBoxID.Status + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0580,1100^A0B,58,58^FDDate^FS";
                zpl = zpl + Environment.NewLine + "^FT0580,0800^A0B,58,58^FD" + ShipBoxID.Date + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0650,1100^A0B,58,58^FDShipper^FS";
                zpl = zpl + Environment.NewLine + "^FT0650,0800^A0B,58,58^FDEG2 Mobile Technology^FS";
                zpl = zpl + Environment.NewLine + "^FT0720,1100^A0B,58,58^FDPO#^FS";
                zpl = zpl + Environment.NewLine + "^FT0720,0800^A0B,58,58^FD" + ShipBoxID.PONumber + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0790,0800^BY3,3,50^BCB,,N,N^FD" + ShipBoxID.PONumber + "^FS";
                zpl = zpl + Environment.NewLine + "^PQ1,0,1,Y^XZ";


                Print2LPT.Print(zpl, lptPort);
            }
            catch (SystemException ex)
            {
                MessageBox.Show("QR Code printing is not working!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public Boolean PrintQRCodeLabel(string lptPort, _QRCode qRCode)
        {
            try
            {
                string zpl = "";
                string nl = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
                string QRCode;

                for (int i = 1; i <= Convert.ToInt16(qRCode.ItemQuantity); i++)
                {
                    QRCode = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}"
                        , qRCode.PONumber
                        , qRCode.SupplierID
                        , qRCode.ItemCode
                        , qRCode.ItemQuantity.ToString()
                        , qRCode.FactoryCode
                        , qRCode.ProductionDate
                        , qRCode.ShipDate
                        , qRCode.SerialNumber.ToString()
                        , qRCode.MaterialSource
                        , qRCode.CVEReserved1
                        , qRCode.CVEReserved2
                        , qRCode.SupplierSection);

                    if (qRCode.SerialNumber == 0)
                    {
                        qRCode.SerialNumber = 1;
                    }

                    zpl = zpl + "^XA";
                    zpl = zpl + Environment.NewLine + "^MMT";
                    zpl = zpl + Environment.NewLine + "^PW203";
                    zpl = zpl + Environment.NewLine + "^LL0102";
                    zpl = zpl + Environment.NewLine + "^LH10,5";
                    zpl = zpl + Environment.NewLine + "^LS10";
                    zpl = zpl + Environment.NewLine + "^FT20,100^BQ,2,2^FDMA," + QRCode + "^FS";
                    zpl = zpl + Environment.NewLine + "^FO90,20^A0N,12,12^FD" + qRCode.ItemCode + "^FS";
                    zpl = zpl + Environment.NewLine + "^FO90,40^A0N,12,12^FD" + qRCode.PONumber + "^FS";
                    zpl = zpl + Environment.NewLine + "^FO90,60^A0N,12,12^FD" + qRCode.ShipDate + "^FS";
                    zpl = zpl + Environment.NewLine + "^FO90,80^A0N,12,12^FD" + qRCode.SerialNumber + "^FS";
                    zpl = zpl + Environment.NewLine + "^XZ";
                    zpl = zpl + Environment.NewLine;

                    qRCode.SerialNumber = qRCode.SerialNumber + 1;

                }
                Print2LPT.Print(zpl, lptPort);
            }
            catch (SystemException ex)
            {
                MessageBox.Show("QR Code printing is not working!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
 
        private void frmPacking_Load(object sender, EventArgs e)
        {
            Initialized();
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetShipGroup();
            SearchData();

            // get previous detaild id
            Boolean blnFind = false;
            gvList.FocusedRowHandle = -1;
            for (int i = 0; i <= (gvList.RowCount - 1); i++)
            {
                int tmp = Convert.ToInt16(gvList.GetRowCellValue(i, "PODetailID"));
                if (tmp == pOdetailID)
                {
                    //gvList.SelectRow(i);
                    gvList.FocusedRowHandle = i;
                    blnFind = true;
                }
            }

            if (blnFind == false && gvList.RowCount > 0)
            {
                gvList.FocusedRowHandle = 0;
            }
        }
        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
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

                    txtPONo.Text = gvList.GetRowCellValue(e.FocusedRowHandle, "PONumber").ToString();
                    txtPOLine.Text = gvList.GetRowCellValue(e.FocusedRowHandle, "POLineNumber").ToString();
                    txtItemCode.Text = gvList.GetRowCellValue(e.FocusedRowHandle, "ItemCode").ToString();
                    //lue.Text = gvList.GetRowCellValue(e.FocusedRowHandle, "ItemNumber").ToString();
                    txtOrderQty.Text = gvList.GetRowCellValue(e.FocusedRowHandle, "ReceiveQty").ToString();
                    txtRemaingQty.Text = gvList.GetRowCellValue(e.FocusedRowHandle, "InventoryQty").ToString();
                    txtCustomerCode.Text = gvList.GetRowCellValue(e.FocusedRowHandle, "CustomerCode").ToString();
                    txtPODetailID.Text = gvList.GetRowCellValue(e.FocusedRowHandle, "PODetailID").ToString();

                    lueItemNumber.EditValue = gvList.GetRowCellValue(e.FocusedRowHandle, "ItemNumber").ToString();
                    txtItem.Text = lueItemNumber.EditValue.ToString();

                    string strPOType = gvList.GetRowCellValue(e.FocusedRowHandle, "POType").ToString();
                    Functions.QueryCmbShippingStatus(db, ref lueShippingStatus, strPOType);
                    if (strPOType == "FCL")
                    {
                        lueShippingStatus.Text = "Refurbished-FPCB";
                    }
                    else
                    {
                        lueShippingStatus.ItemIndex = 0;
                    }
                    txtShippingQty.Text = "";
                    txtShippingQty.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get P/O Detail." + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { }
        }


        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Validation() == false) return;

                string strPODetailId = txtPODetailID.EditValue.ToString();
                if (!string.IsNullOrEmpty(strPODetailId))
                {
                    if (SaveData() == true)
                    {
                        ResetShipGroup();
                        SearchData();
                    }
                }
            }
            catch (Exception ex)
            {
                string err;
                if (ex.InnerException == null)
                {
                    err = ex.InnerException.Message.ToString();
                }
                else
                {
                    err = ex.Message.ToString();
                }
                XtraMessageBox.Show(err, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueShippingType_EditValueChanged(object sender, EventArgs e)
        {
            string strShippingType = (sender as DevExpress.XtraEditors.LookUpEdit).EditValue.ToString();
            if (strShippingType == "G")
            {
                chkShipBoxLabel.Checked = true;
            }
            else
            {
                chkShipBoxLabel.Checked = false;
            }
        }

        private void gvList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            Functions.AddingRowNumber(sender, e);
        }

        private void lueItemNumber_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                LookUpEdit edit = (sender as LookUpEdit);
                DataRow r = dTableCustomerItemList.Rows.Add(new object[] { });
                r[edit.Properties.DisplayMember] = e.DisplayValue.ToString().ToUpper();
                r[edit.Properties.ValueMember] = e.DisplayValue.ToString().ToUpper();
                edit.EditValue = r[edit.Properties.ValueMember];
                e.Handled = true;
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


        private void lueSearchPOType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOType, "", true);

                btnSearch.PerformClick();
            }
            catch
            {
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

        private void lueSearchCustomer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
                Functions.QueryCmbUserCodeData(db, ref lueSearchPOType, lueSearchPOType.Tag.ToString(), "", true);
                string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
                Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOType, "", true);
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
                XtraMessageBox.Show("Search Customer Failed!" + Environment.NewLine + errMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcList_Click(object sender, EventArgs e)
        {

        }

        private void frmPacking_Activated(object sender, EventArgs e)
        {
            ////Initialized();
            ////Functions.QueryCmbSetYesNoAll(ref lueSearchUseYN);
            ////Functions.QueryCmbSetYesNo(ref lueUseYN);
            ////Functions.QueryCmbCustomerList(db, ref lueSearchCustomer);

            string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();

            Functions.QueryCmbUserCodeData(db, ref lueSearchPOType, lueSearchPOType.Tag.ToString(), "", true);
            string pOtype = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
            Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOtype, "N", true);

        }

        private void labelControl12_Click(object sender, EventArgs e)
        {

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
    }
}