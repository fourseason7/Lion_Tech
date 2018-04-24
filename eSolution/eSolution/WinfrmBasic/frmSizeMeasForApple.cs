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

namespace eSolution.WinfrmBasic
{
    public partial class frmSizeMeasForApple : DevExpress.XtraEditors.XtraForm
    {
        public frmSizeMeasForApple()
        {
            InitializeComponent();
        }

        public struct _QRCode
        {

            //Upper Left Flatness   Spot 1 - Vertical thickness of upper left corner        000.00
            //Lower Right Flatness  Spot 3 - Vertical thickness of lower right corner       000.00
            //Length                Spot 5                                                  000.00
            //Width                 Spot 6                                                  000.00
            //Critical Point        Spot 11 for LCD, Spot 7 for BC                          000.00
            //Grade                 Grade A within tolerance(0.1 mm), Grade B for bigger, Grade C for smaller CHAR(1)
            public string Spot1; //
            public string Spot3;
            public string Spot5;
            public string Spot6;
            public string Spot11;
            public string Grade;
        }
        private void Initialized()
        {
            txtSpot1.EditValue = 0.0;
            txtSpot3.EditValue = 0.0;
            txtSpot5.EditValue = 0.0;
            txtSpot6.EditValue = 0.0;
            txtSpot11.EditValue = 0.0;

            txtSpotDisp1.EditValue = "";
            txtSpotDisp3.EditValue = "";
            txtSpotDisp5.EditValue = "";
            txtSpotDisp6.EditValue = "";
            txtSpotDisp11.EditValue = "";

            txtGrade.SelectedIndex = 0;


            txtSpot1.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSpot1.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSpot3.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSpot3.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSpot5.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSpot5.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSpot6.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSpot6.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSpot11.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSpot11.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSpotDisp1.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSpotDisp1.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSpotDisp3.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSpotDisp3.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSpotDisp5.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSpotDisp5.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSpotDisp6.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSpotDisp6.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSpotDisp11.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtSpotDisp11.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtGrade.Properties.AppearanceFocused.BackColor = Color.Yellow;
            txtGrade.Properties.AppearanceReadOnly.BackColor = Color.LightGoldenrodYellow;

            txtSpot6.Select();
        }

        private Boolean IsValidate()
        {
            if (string.IsNullOrEmpty(txtSpotDisp1.EditValue.ToString()) == true)
            {
                MessageBox.Show("Please, check the Spot1's Value.");
                txtSpot1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSpotDisp6.EditValue.ToString()) == true)
            {
                MessageBox.Show("Please, check the Spot6's Value.");
                txtSpot6.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSpotDisp5.EditValue.ToString()) == true)
            {
                MessageBox.Show("Please, check the Spot5's Value.");
                txtSpot5.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSpotDisp3.EditValue.ToString()) == true)
            {
                MessageBox.Show("Please, check the Spot3's Value.");
                txtSpot3.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSpotDisp11.EditValue.ToString()) == true)
            {
                MessageBox.Show("Please, check the Spot11's Value.");
                txtSpot11.Focus();
                return false;
            }
            string strGrade = "";
            strGrade = txtGrade.EditValue.ToString();

            if (string.IsNullOrEmpty(strGrade) == true)
            {
                MessageBox.Show("Please, check the Grade Value.");
                txtGrade.Focus();
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

                QRCode = string.Format("{0}|{1}|{2}|{3}|{4}|{5}"
                    , qRCode.Spot1
                    , qRCode.Spot3
                    , qRCode.Spot5
                    , qRCode.Spot6
                    , qRCode.Spot11
                    , qRCode.Grade);

                zpl = zpl + "^XA";
                //zpl = zpl + Environment.NewLine + "^MMT";
                //zpl = zpl + Environment.NewLine + "^PW203";
                //zpl = zpl + Environment.NewLine + "^LL0102";
                //zpl = zpl + Environment.NewLine + "^LH10,5";
                //zpl = zpl + Environment.NewLine + "^LS10";
                zpl = zpl + Environment.NewLine + "^FO350,020^BQN,2,2^FDQA," + QRCode + "^FS";
                zpl = zpl + Environment.NewLine + "^FO440,030^A0N,75,75^FD" + qRCode.Grade + "^FS";
                zpl = zpl + Environment.NewLine + "^XZ";
                zpl = zpl + Environment.NewLine;
                Print2LPT.Print(zpl, lptPort);
            }
            catch (SystemException ex)
            {
                MessageBox.Show("QR Code printing is not working!" + Environment.NewLine + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void frmSizeMeasForApple_Load(object sender, EventArgs e)
        {
            Initialized();
            


        }

        private void txtSpot6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtSpot1.Focus();
            }
        }

        private void txtSpot1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtSpot5.Focus();
            }
        }

        private void txtSpot5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtSpot3.Focus();
            }
        }

        private void txtSpot3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtSpot11.Focus();
            }
        }

        private void txtSpot11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                
            }
        }

        private void txtSpot6_EditValueChanged(object sender, EventArgs e)
        {
            txtSpotDisp6.Text = txtSpot6.EditValue.ToString();
        }

        private void txtSpot1_EditValueChanged(object sender, EventArgs e)
        {
            txtSpotDisp1.Text = txtSpot1.EditValue.ToString();
        }

        private void txtSpot5_EditValueChanged(object sender, EventArgs e)
        {
            txtSpotDisp5.Text = txtSpot5.EditValue.ToString();
        }

        private void txtSpot3_EditValueChanged(object sender, EventArgs e)
        {
            txtSpotDisp3.Text = txtSpot3.EditValue.ToString();
        }

        private void txtSpot11_EditValueChanged(object sender, EventArgs e)
        {
            txtSpotDisp11.Text = txtSpot11.EditValue.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Boolean blnRtnValue = false;

            blnRtnValue = IsValidate();

            if (blnRtnValue == false)
                return;

                //// print QR Code
            _QRCode qRCode = new _QRCode();

            qRCode.Spot1 = string.Format("{0:0.00}", Convert.ToDecimal(txtSpotDisp1.EditValue.ToString()));
            qRCode.Spot3 = string.Format("{0:0.00}", Convert.ToDecimal(txtSpotDisp3.EditValue.ToString()));
            qRCode.Spot5 = string.Format("{0:0.00}", Convert.ToDecimal(txtSpotDisp5.EditValue.ToString()));
            qRCode.Spot6 = string.Format("{0:0.00}", Convert.ToDecimal(txtSpotDisp6.EditValue.ToString()));
            qRCode.Spot11 = string.Format("{0:0.00}", Convert.ToDecimal(txtSpotDisp11.EditValue.ToString()));


            //qRCode.Spot1 = string.Format("{0:0.00}", Int32(txtSpotDisp1.EditValue.ToString()));
            //qRCode.Spot3 = string.Format("{0:0.00}", txtSpotDisp3.EditValue.ToString());
            //qRCode.Spot5 = string.Format("{0:0.00}", txtSpotDisp5.EditValue.ToString());
            //qRCode.Spot6 = string.Format("{0:0.00}", txtSpotDisp6.EditValue.ToString());
            //qRCode.Spot11 = string.Format("{0:0.00}", txtSpotDisp11.EditValue.ToString());
            qRCode.Grade = txtGrade.EditValue.ToString();

            blnRtnValue = PrintQRCodeLabel(Properties.Settings.Default.PrintQRCode_Meas, qRCode);

            if (blnRtnValue == true)
            {
                btnReset.PerformClick();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Initialized();
        }
    }
}