using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using eSolution.Database;

namespace eSolution
{
    class DatabaseHelper
    {
        public static DataTable GetCodeValueSetOpenClosedByBoolean()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ValueMember", typeof(Boolean));
            dt.Columns.Add("DisplayMember", typeof(string));

            dt.Rows.Add(false, "OPEN");
            dt.Rows.Add(true, "CLOSED");
            return dt;
        }
        public static DataTable GetCodeValueOpenClosedNoAll()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ValueMember", typeof(string));
            dt.Columns.Add("DisplayMember", typeof(string));

            dt.Rows.Add("%", "ALL");
            dt.Rows.Add("N", "OPEN");
            dt.Rows.Add("Y", "CLOSED");
            return dt;
        }
        public static DataTable GetCodeValueSetYesNoByBoolean()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ValueMember", typeof(Boolean));
            dt.Columns.Add("DisplayMember", typeof(string));

            dt.Rows.Add(true, "YES");
            dt.Rows.Add(false, "NO");
            return dt;
        }
        public static DataTable GetCodeValueSetYesNo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ValueMember", typeof(string));
            dt.Columns.Add("DisplayMember", typeof(string));

            dt.Rows.Add("", "");
            dt.Rows.Add("Y", "YES");
            dt.Rows.Add("N", "NO");
            return dt;
        }
        public static DataTable GetCodeValueSetYesNoAll()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ValueMember", typeof(string));
            dt.Columns.Add("DisplayMember", typeof(string));

            dt.Rows.Add("%", "ALL");
            dt.Rows.Add("Y", "YES");
            dt.Rows.Add("N", "NO");
            return dt;
        }

        public static DataTable GetStateCode(eSolutionDataContext db, Boolean argAll = false)
        {
            DataTable dt = new DataTable();
            DataColumn colValue = new DataColumn();
            DataColumn colText = new DataColumn();
            DataRow newRow;
            try
            {
                colText.ColumnName = HelperClass.DisplayName;
                colValue.ColumnName = HelperClass.CodeName;
                colText.DataType = typeof(System.String);
                colValue.DataType = typeof(System.String);

                dt.Columns.Add(colText);
                dt.Columns.Add(colValue);

                //var sqlQuery = eMESdb.stp_CustomerList();
                //var sqlQuery = db.stp_UserCodeData_Select(argTableName, argCodeGroup).ToList();
                var sqlQuery = from obj in db.States
                               select new
                               {
                                   DisplayName = obj.Code
                                   ,
                                   CodeName = obj.Code
                               };
                //var sqlQuery = from obj in db.UserCodeDatas
                //               where obj.TableName == argTableName
                //                && obj.CodeGroup.Contains(argCodeGroup)
                //               orderby obj.CodeSeq
                //               select new 
                //               {
                //                   DisplayName = obj.CodeDescription
                //                   , CodeName = obj.CodeName
                //               };
                if (argAll == true)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = "ALL";
                    newRow[HelperClass.CodeName] = "";
                    dt.Rows.Add(newRow);
                }
                foreach (var row in sqlQuery)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = row.DisplayName;
                    newRow[HelperClass.CodeName] = row.CodeName;
                    dt.Rows.Add(newRow);
                }
            }
            catch
            { }

            return dt;
        }
        public static DataTable GetUserCodeData(eSolutionDataContext db, string argTableName, string argCodeGroup = "", Boolean argAll = false)
        {
            DataTable dt = new DataTable();
            DataColumn colValue = new DataColumn();
            DataColumn colText = new DataColumn();
            DataRow newRow;
            try
            {
                colText.ColumnName = HelperClass.DisplayName;
                colValue.ColumnName = HelperClass.CodeName;
                colText.DataType = typeof(System.String);
                colValue.DataType = typeof(System.String);

                dt.Columns.Add(colText);
                dt.Columns.Add(colValue);

                //var sqlQuery = eMESdb.stp_CustomerList();
                var sqlQuery = db.stp_UserCodeData_Select(argTableName, argCodeGroup).ToList();
                //var sqlQuery = from obj in db.UserCodeDatas
                //               where obj.TableName == argTableName
                //                && obj.CodeGroup.Contains(argCodeGroup)
                //               orderby obj.CodeSeq
                //               select new 
                //               {
                //                   DisplayName = obj.CodeDescription
                //                   , CodeName = obj.CodeName
                //               };
                if (argAll == true)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = "ALL";
                    newRow[HelperClass.CodeName] = "";
                    dt.Rows.Add(newRow);
                }
                //else
                //{
                //    newRow = dt.NewRow();
                //    newRow[HelperClass.DisplayName] = "";
                //    newRow[HelperClass.CodeName] = "";
                //    dt.Rows.Add(newRow);
                //}
                foreach (var row in sqlQuery)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = row.DisplayName;
                    newRow[HelperClass.CodeName] = row.CodeName;
                    dt.Rows.Add(newRow);
                }
            }
            catch
            { }

            return dt;
        }
        
        public static DataTable GetCodeShippingType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ValueMember", typeof(string));
            dt.Columns.Add("DisplayMember", typeof(string));

            dt.Rows.Add("", "");
            dt.Rows.Add("G", "Good");
            dt.Rows.Add("F", "Function Fail");
            dt.Rows.Add("D", "DIP");
            return dt;
        }

        public static DataTable GetItemCode(eSolutionDataContext db, string itemType = "I")
        {
            //EMSdb = new eSolutionDataContext();

            DataTable dt = new DataTable();
            DataColumn colValue = new DataColumn();
            DataColumn colText = new DataColumn();
            DataRow newRow;

            try
            {
                colText.ColumnName = HelperClass.DisplayName;
                colValue.ColumnName = HelperClass.CodeName;
                colText.DataType = typeof(System.String);
                colValue.DataType = typeof(System.String);

                dt.Columns.Add(colText);
                dt.Columns.Add(colValue);

                //var sqlQuery = eMESdb.stp_CustomerList();
                var sqlQuery = from obj in db.ItemMasters
                               where obj.ItemType == itemType
                               group obj by new
                               {
                                   obj.ItemID
                                   ,
                                   obj.ItemCode
                               }
                                   into grouping
                               select new { grouping.Key, grouping };

                newRow = dt.NewRow();
                newRow[HelperClass.DisplayName] = "";
                newRow[HelperClass.CodeName] = "";
                dt.Rows.Add(newRow);

                foreach (var row in sqlQuery)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = row.Key.ItemCode;
                    newRow[HelperClass.CodeName] = row.Key.ItemID;
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
        public static DataTable GetCustomerListByID(eSolutionDataContext db, Boolean argAll = false)
        {
            //EMSdb = new eSolutionDataContext();

            DataTable dt = new DataTable();
            DataColumn colValue = new DataColumn();
            DataColumn colText = new DataColumn();
            DataRow newRow;

            try
            {
                colText.ColumnName = HelperClass.DisplayName;
                colValue.ColumnName = HelperClass.CodeName;
                colText.DataType = typeof(System.String);
                colValue.DataType = typeof(System.String);

                dt.Columns.Add(colText);
                dt.Columns.Add(colValue);


                var sqlQuery = db.stp_CustomerListByID().ToList();


                if (argAll == true)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = "ALL";
                    newRow[HelperClass.CodeName] = "";
                    dt.Rows.Add(newRow);
                }
                foreach (var row in sqlQuery)
                {
                    newRow = dt.NewRow();
                    //newRow[HelperClass.DisplayName] = row.Key.CustomerName;
                    //newRow[HelperClass.CodeName] = row.Key.CustomerCode;
                    newRow[HelperClass.DisplayName] = row.DisplayName;
                    newRow[HelperClass.CodeName] = row.CodeName;
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

        public static DataTable GetCustomerList(eSolutionDataContext db, Boolean argAll = false)
        {
            //EMSdb = new eSolutionDataContext();

            DataTable dt = new DataTable();
            DataColumn colValue = new DataColumn();
            DataColumn colText = new DataColumn();
            DataRow newRow;

            try
            {
                colText.ColumnName = HelperClass.DisplayName;
                colValue.ColumnName = HelperClass.CodeName;
                colText.DataType = typeof(System.String);
                colValue.DataType = typeof(System.String);

                dt.Columns.Add(colText);
                dt.Columns.Add(colValue);

                var sqlQuery = db.stp_CustomerList().ToList();
                //var sqlQuery = from obj in db.Customers
                //               group obj by new
                //               {
                //                   obj.CustomerCode
                //                   ,
                //                   obj.CustomerName
                //               }
                //                   into grouping
                //                   select new { grouping.Key, grouping };
                if (argAll == true)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = "ALL";
                    newRow[HelperClass.CodeName] = "";
                    dt.Rows.Add(newRow);
                }
                foreach (var row in sqlQuery)
                {
                    newRow = dt.NewRow();
                    //newRow[HelperClass.DisplayName] = row.Key.CustomerName;
                    //newRow[HelperClass.CodeName] = row.Key.CustomerCode;
                    newRow[HelperClass.DisplayName] = row.DisplayName;
                    newRow[HelperClass.CodeName] = row.CodeName;
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
        public static DataTable GetCustomerItemList(eSolutionDataContext db, string CustomerCode, string RSType = "")
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
                               where itm.CustomerID == cst.CustomerID
                               && cst.CustomerCode == CustomerCode
                               && itm.ItemType.Contains(RSType)
                               orderby itm.ItemNumber
                               select new
                               {
                                   ItemNumber = itm.ItemNumber,
                               }
                               ;
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
        public static DataTable GetCodeAvailablePOList(eSolutionDataContext db)
        {
            DataTable dt = new DataTable();
            DataColumn colValue = new DataColumn();
            DataColumn colText = new DataColumn();
            DataRow newRow;

            try
            {
                colText.ColumnName = HelperClass.DisplayName;
                colValue.ColumnName = HelperClass.CodeName;
                colText.DataType = typeof(System.String);
                colValue.DataType = typeof(System.String);

                dt.Columns.Add(colText);
                dt.Columns.Add(colValue);

                //var sqlQuery = eMESdb.stp_CustomerList();
                var sqlQuery = from obj in db.POHeaders
                               where obj.Status == false
                               orderby obj.PONumber
                               select new
                               {
                                   POID = obj.POHeaderID,
                                   PONO = obj.PONumber
                               };
                foreach (var row in sqlQuery)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = row.PONO;
                    newRow[HelperClass.CodeName] = row.PONO;
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
        public static DataTable GetCodeAvailablePOList(eSolutionDataContext db, string customerCode, string pOType, string pOStatus, Boolean allFlag)
        {
            //EMSdb = new eSolutionDataContext();

            DataTable dt = new DataTable();
            DataColumn colValue = new DataColumn();
            DataColumn colText = new DataColumn();
            DataRow newRow;

            try
            {
                colText.ColumnName = HelperClass.DisplayName;
                colValue.ColumnName = HelperClass.CodeName;
                colText.DataType = typeof(System.String);
                colValue.DataType = typeof(System.String);

                dt.Columns.Add(colText);
                dt.Columns.Add(colValue);

                if (string.IsNullOrEmpty(customerCode)) customerCode = "%";
                if (string.IsNullOrEmpty(pOType)) pOType = "%";
                if (string.IsNullOrEmpty(pOStatus)) pOStatus = "%";

                var sqlQuery = db.stp_GetPOListByCustomer(customerCode, pOType, pOStatus).ToList();
                //var sqlQuery = from obj in db.POHeaders
                //               from cst in db.Customers
                //               where obj.CustomerID == cst.CustomerID
                //               && obj.POType == pOType
                //               && (obj.Status.ToString()).ToUpper().Contains(pOStatus)
                //               && cst.CustomerCode == customerCode
                //               orderby obj.PONumber
                //               select new
                //               {
                //                   POID = obj.POHeaderID,
                //                   PONO = obj.PONumber
                //               };
                if (allFlag == true)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = "ALL";
                    newRow[HelperClass.CodeName] = "";
                    dt.Rows.Add(newRow);
                }
                foreach (var row in sqlQuery)
                {
                    newRow = dt.NewRow();
                    newRow[HelperClass.DisplayName] = row.PONumber;
                    newRow[HelperClass.CodeName] = row.PONumber;
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

    }
}
