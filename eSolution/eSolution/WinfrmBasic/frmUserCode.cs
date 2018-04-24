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

namespace eSolution.WinfrmBasic
{
    public partial class frmUserCode : DevExpress.XtraEditors.XtraForm
    {
        eSolutionDataContext db = new eSolutionDataContext();

        public frmUserCode()
        {
            InitializeComponent();
        }

        private void SearchUserCode()
        {
            try
            {
                string strTableName = txtTableName.Text;

            }
            catch
            { 
            }
            
        }
        private void SearchUserCodeData()
        {
            try
            {
                string strTableName = gvUserCode.GetRowCellValue(gvUserCode.FocusedRowHandle, "TableName").ToString();

            }
            catch 
            {
            }

        }
        private void frmUserCode_Load(object sender, EventArgs e)
        {

        }

        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchUserCode();
        }

        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvUserCode.AddNewRow();

            int rowHandle = gvUserCode.GetRowHandle(gvUserCode.DataRowCount);
            if (gvUserCode.IsNewItemRow(rowHandle))
            {
                gvUserCode.SetRowCellValue(rowHandle, gvUserCode.Columns[0], "");
                gvUserCode.SetRowCellValue(rowHandle, gvUserCode.Columns[1], "");
                gvUserCode.SetRowCellValue(rowHandle, gvUserCode.Columns[2], "");
            }
        }

    }
}