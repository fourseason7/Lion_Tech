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

namespace eSolution.WinfrmBasic
{
    public partial class frmPOPackingHistory : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();

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

        public frmPOPackingHistory()
        {
            InitializeComponent();
        }
        public void Initialized()
        {

            Functions.QueryCmbCustomerList(db, ref lueSearchCustomer);
            string customerCode = lueSearchCustomer.Properties.GetKeyValueByDisplayText(lueSearchCustomer.Text).ToString();
            Functions.QueryCmbUserCodeData(db, ref lueSearchPOType, lueSearchPOType.Tag.ToString(), "", true);
            string pOType = lueSearchPOType.Properties.GetKeyValueByDisplayText(lueSearchPOType.Text).ToString();
            Functions.QueryCmbAvailablePOList(db, ref lueSearchPO, customerCode, pOType, "", true);

            dtSearchDateFrom.EditValue = Convert.ToDateTime(db.fn_ServerDateTime()).AddDays(-7);
            dtSearchDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtSearchDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            dtSearchDateTo.EditValue = (DateTime?)db.fn_ServerDateTime();

            dtSearchDateFrom.Properties.AppearanceFocused.BackColor = Color.Yellow;
            dtSearchDateFrom.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            dtSearchDateTo.Properties.AppearanceFocused.BackColor = Color.Yellow;
            dtSearchDateTo.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchCustomer.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchCustomer.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            lueSearchPO.Properties.AppearanceFocused.BackColor = Color.Yellow;
            lueSearchPO.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSearchItem.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSearchItem.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSearchBoxNo.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSearchBoxNo.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            barEditLabelShift.EditValue = 20;
        }
        public void SearchData()
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime dtFromDate, dtToDate;
            string strFromDate, strToDate;
            string strSearchCustomer;
            string strSearchPONumber;
            string strSearchItem;
            string strSearchShipBoxNo;

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
                strSearchPONumber = lueSearchPO.Properties.GetKeyValueByDisplayText(lueSearchPO.Text).ToString();
                if (string.IsNullOrEmpty(strSearchPONumber))
                    strSearchPONumber = "%";
                strSearchItem = txtSearchItem.Text.ToString();
                if (string.IsNullOrEmpty(strSearchItem))
                    strSearchItem = "%";
                strSearchShipBoxNo = txtSearchBoxNo.Text.Trim();
                if (string.IsNullOrEmpty(strSearchShipBoxNo))
                    strSearchShipBoxNo = "%";

                var qry = db.stp_POShipment_Select(dtFromDate, dtToDate, strSearchCustomer, strSearchPOtype, strSearchPONumber, strSearchItem, strSearchShipBoxNo);

                if (qry != null)
                {
                    gcList.DataSource = qry.ToList();
                    if (gvList.RowCount > 0)
                    {
                        gvList.BestFitColumns();
                        gvList.OptionsBehavior.ReadOnly = true;
                        gvList.FocusedRowHandle = 0;

                        gvList.Columns["CustomerCode"].Caption = "Customer";
                        gvList.Columns["POLineNumber"].Caption = "Line";
                        gvList.Columns["ShippingStatusName"].Caption = "Shipping Status";

                        string[] arr = { "ShippingStatus"};
                        Functions.SetInvisible(ref gvList, arr);

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
                MessageBox.Show("Couldn't Search P/O Packing History!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private Boolean DeleteShipBox()
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string strShipBoxNo = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ShipBoxNo").ToString();
                if (string.IsNullOrEmpty(strShipBoxNo))
                {
                    XtraMessageBox.Show("Please, Could not get Ship Box#.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                DialogResult result = XtraMessageBox.Show("Do you want to delete Box Data?", "Question!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    return false;
                }
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                {
                    using (eSolutionDataContext db = new eSolutionDataContext())
                    {
                        DateTime dtServerDate = Convert.ToDateTime(db.fn_ServerDateTime().ToString());
                        string strShippingStatus = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ShippingStatus").ToString();;
                        string strShippingType = strShippingStatus.Substring(0, 1);
                        Int16 intShippedQty = Convert.ToInt16(gvList.GetRowCellValue(gvList.FocusedRowHandle, "ShippedQty").ToString());


                        var qryShipment = (from obj in db.POShipments
                                           where obj.ShipBoxNo == strShipBoxNo
                                           select obj).FirstOrDefault();

                        if (qryShipment == null)
                        {
                            MessageBox.Show("Could not find Ship Box Data." + Environment.NewLine + "Please, check the history", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (qryShipment.POPalletID > 0)
                        {
                            MessageBox.Show("Already Palletized." + Environment.NewLine + "Please, un-palletized first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        var qryPODetail = (from pod in db.PODetails
                                          where pod.PODetailID == qryShipment.PODetailID
                                          select pod).FirstOrDefault();

                        if (qryPODetail == null)
                        {
                            return false;
                        }

                        //switch (strShippingType)
                        //{
                        //    case "G":
                        //        qryPODetail.ShipGoodQty = qryPODetail.ShipGoodQty - c;
                        //        break;
                        //    case "F":
                        //        qryPODetail.ShipFunctionFailQty = qryPODetail.ShipFunctionFailQty - intShippedQty;
                        //        break;
                        //    case "D":
                        //        qryPODetail.ShipDIPQty = qryPODetail.ShipDIPQty - intShippedQty;
                        //        break;
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
                                qryPODetail.ShipRefurbishedQty = qryPODetail.ShipRefurbishedQty - intShippedQty;
                                break;
                            case "GFCL":
                                qryPODetail.ShipRefurbishedFPCBQty = qryPODetail.ShipRefurbishedFPCBQty - intShippedQty;
                                break;
                            case "GFRO":
                                qryPODetail.ShipFrontOnly = qryPODetail.ShipFrontOnly - intShippedQty;
                                break;
                            case "DDEF":
                            case "DIP":
                                qryPODetail.ShipDIPQty = qryPODetail.ShipDIPQty - intShippedQty;
                                break;
                            case "FRFF":
                                qryPODetail.ShipFunctionFailQty = qryPODetail.ShipFunctionFailQty - intShippedQty;
                                break;
                            case "GSMP":
                                qryPODetail.ShipSampleQty = qryPODetail.ShipSampleQty - intShippedQty;
                                break;
                            case "GNTF":
                                qryPODetail.ShipNTFQty = qryPODetail.ShipNTFQty - intShippedQty;
                                break;
                            case "ROOW":
                                qryPODetail.ShipOutOfWarranty = qryPODetail.ShipOutOfWarranty - intShippedQty;
                                break;
                            case "RCTA":
                                qryPODetail.ShipCustomerAbuse = qryPODetail.ShipCustomerAbuse - intShippedQty;
                                break;
                            case "NMP":
                                qryPODetail.ShipNMPQty = qryPODetail.ShipNMPQty - intShippedQty;
                                break;
                        }

                        if (qryPODetail.Status == true)
                        {
                            qryPODetail.Status = false;
                        }
                        qryPODetail.ModifiedDate = dtServerDate;
                        qryPODetail.ModifiedHostName = Environment.MachineName;

                        var qryPOHeader = (from poh in db.POHeaders
                                           where poh.POHeaderID == qryPODetail.POHeaderID
                                           select poh).FirstOrDefault();

                        if (qryPOHeader == null)
                        {
                            return false;
                        }
                        qryPOHeader.Status = false;
                        qryPOHeader.ModifiedDate = dtServerDate;
                        qryPOHeader.ModifiedCompName = Environment.MachineName;

                        db.POShipments.DeleteOnSubmit(qryShipment);
                        try
                        {
                            db.SubmitChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Could not delete to Ship Box#!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                    scope.Complete();
                }
                MessageBox.Show("Delete Completed!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete to Ship Box#!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                //zpl = zpl + Environment.NewLine + "^LS" + convert.int16(barEditLabelShift.EditValue.ToString()) + " ";
                //zpl = zpl + Environment.NewLine + String.Format("^LH{0},{1}", Convert.ToInt16(barEditLabelX.EditValue.ToString()).ToString(), Convert.ToInt16(barEditLabelY.EditValue.ToString()).ToString());
                zpl = zpl + Environment.NewLine + string.Format("^LS{0}", Convert.ToInt16(barEditLabelShift.EditValue.ToString()).ToString());
                zpl = zpl + Environment.NewLine + "^FO0080,0080^GB0730,1100,4^FS"; // outline
                zpl = zpl + Environment.NewLine + "^FO0080,0850^GB0730,0000,4^FS"; // separate line
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
        private void frmPOPackingHistory_Load(object sender, EventArgs e)
        {
            Initialized();
        }

        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchData();
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
            GridView gridView = ((GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
        }

        private void barbtnReprintShipBox_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvList.RowCount < 0)
                return;

            try
            {
                int intRowHandle = gvList.FocusedRowHandle;
                _ShipBoxLable sb = new _ShipBoxLable();
                sb.ShipBoxNo = gvList.GetRowCellValue(intRowHandle, "ShipBoxNo").ToString();
                sb.Quantity = gvList.GetRowCellValue(intRowHandle, "ShippedQty").ToString();
                //sb.Model = gvList.GetRowCellValue(intRowHandle, "ItemCode").ToString();
                sb.ItemCode = gvList.GetRowCellValue(intRowHandle, "ActItemNumber").ToString();
                sb.Status = gvList.GetRowCellValue(intRowHandle, "ShippingStatusName").ToString();
                sb.Date = Convert.ToDateTime(gvList.GetRowCellValue(intRowHandle, "ShippedDate").ToString()).ToString("MM/dd/yyyy");
                if (sb.Date == "04/01/2017")
                    sb.Date = "03/31/2017";

                sb.Shipper = "EG2 Mobile Technology";
                sb.PONumber = gvList.GetRowCellValue(intRowHandle, "PONumber").ToString();

                Boolean blnReturn = PrintShipBoxLabel(Properties.Settings.Default.PrintShipBox, sb);

            }
            catch
            {
            }
            


        }

        private void barBtnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvList.RowCount < 0)
                    return;

                Functions.ExportToExcel(saveFileDialog1, gvList, this.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Could not export to excel file." + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void barBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvList.RowCount == 0) return;

            if (DeleteShipBox() == true)
            {
                SearchData();
            }

        }

        private void barBtnQRCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string strShipStatusType = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ShippingStatus").ToString().Substring(0, 1);
                if (strShipStatusType != "G")
                {
                    return;
                }
                DialogResult result = XtraMessageBox.Show("Do you want reprint to QR Code?", "Question!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    return;
                }

                string strShipBoxNo = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ShipBoxNo").ToString();
                var qryShipment = (from obj in db.POShipments
                                   where obj.ShipBoxNo == strShipBoxNo
                                   && obj.ShippingStatus.StartsWith("G")
                                   select obj).FirstOrDefault();
                if (qryShipment == null)
                {
                    return;
                }
                _QRCode qRCode = new _QRCode();
                qRCode.PONumber = qryShipment.PONumber;
                qRCode.LineNumber = Convert.ToInt16(qryShipment.POLineNumber.ToString());
                qRCode.ItemCode = qryShipment.ItemNumber;
                qRCode.ItemQuantity = Convert.ToInt16(qryShipment.ShippedQty.ToString());
                qRCode.ProductionDate = Convert.ToDateTime(qryShipment.ShippedDate.ToString()).ToString("yyMMdd");
                qRCode.ShipDate = Convert.ToDateTime(qryShipment.ShippedDate.ToString()).ToString("yyMMdd");
                qRCode.SerialNumber = Convert.ToInt16(qryShipment.StartNo.ToString());
                qRCode.SupplierID = "EG2";
                qRCode.MaterialSource = "R";

    //            QRCode = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}"
    //, qRCode.PONumber
    //, qRCode.SupplierID
    //, qRCode.ItemCode
    //, qRCode.ItemQuantity.ToString()
    //, qRCode.FactoryCode
    //, qRCode.ProductionDate
    //, qRCode.ShipDate
    //, qRCode.SerialNumber.ToString()
    //, qRCode.MaterialSource
    //, qRCode.CVEReserved1
    //, qRCode.CVEReserved2
    //, qRCode.SupplierSection);

                Boolean blnReturn = PrintQRCodeLabel(Properties.Settings.Default.PrintQRCode, qRCode);
            }
            catch
            { }
        }
    }
}