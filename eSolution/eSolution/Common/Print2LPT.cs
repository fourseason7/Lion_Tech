using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSolution
{
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
    public static class Print2LPT
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        public static bool PrintSample2LPT()
        {
            string nl = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
            bool IsConnected = false;

            string sampleText = "Hello World!" + nl +
            "Enjoy Printing...";
            try
            {
                Byte[] buffer = new byte[sampleText.Length];
                buffer = System.Text.Encoding.ASCII.GetBytes(sampleText);

                SafeFileHandle fh = CreateFile("LPT1:", FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                if (!fh.IsInvalid)
                {
                    IsConnected = true;
                    FileStream lpt1 = new FileStream(fh, FileAccess.ReadWrite);
                    lpt1.Write(buffer, 0, buffer.Length);
                    lpt1.Close();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return IsConnected;
        }
        public static bool Print(string printText, string lptPort)
        {
            bool IsConnected = false;

            //string sampleText = "Hello World!" + nl +
            //"Enjoy Printing...";
            try
            {
                Byte[] buffer = new byte[printText.Length];
                buffer = System.Text.Encoding.ASCII.GetBytes(printText);

                SafeFileHandle fh = CreateFile(lptPort, FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                if (!fh.IsInvalid)
                {
                    IsConnected = true;
                    FileStream lpt = new FileStream(fh, FileAccess.ReadWrite);
                    lpt.Write(buffer, 0, buffer.Length);
                    lpt.Close();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return IsConnected;
        }
        public static Boolean PrintShipBoxLabel(string lptPort, _ShipBoxLable ShipBoxID)
        {
            try
            {
                string zpl = "";
                string nl = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
                zpl = zpl + Environment.NewLine + "^XA";
                zpl = zpl + Environment.NewLine + "^MMT";
                zpl = zpl + Environment.NewLine + "^LS0";
                zpl = zpl + Environment.NewLine + "^FO0080,0080^GB0730,1100,4^FS"; // outline
                zpl = zpl + Environment.NewLine + "^FO0080,0850^GB0730,0000,4^FS"; // separate line
                zpl = zpl + Environment.NewLine + "^FT0160,1100^A0B,58,58^FDBox ID^FS";
                zpl = zpl + Environment.NewLine + "^FT0160,0800^A0B,58,58^FD" + ShipBoxID.ShipBoxNo + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0230,0800^BY3,3,50^BCB,,N,N^FD" + ShipBoxID.ShipBoxNo + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0300,1100^A0B,58,58^FDQuantity^FS";
                zpl = zpl + Environment.NewLine + "^FT0300,0800^A0B,58,58^FD" + ShipBoxID.Quantity + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0370,1100^A0B,58,58^FDModel^FS";
                zpl = zpl + Environment.NewLine + "^FT0370,0800^A0B,58,58^FD" + ShipBoxID.Model + "^FS";
                zpl = zpl + Environment.NewLine + "^FT0440,1100^A0B,58,58^FDItem#^FS";
                zpl = zpl + Environment.NewLine + "^FT0440,0800^A0B,58,58^FD" + ShipBoxID.ItemCode + "^FS";
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
    }
}
