using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Bật_Tắt_Máy_Bơm_Nước
{
    public partial class Form1 : Form
    {
        int TrangThaiMayBom = 0;
        public Form1()
        {            
            InitializeComponent();            
            Trangthaimaybom();
        }

        private void btnBatMayBom_Click(object sender, EventArgs e)
        {
            string url = @"https://sgp1.blynk.cloud/external/api/update?token=KArvFa87fr7DCTL-J90YEPSqkkD2l5zG&D0=1";
            BatTat(url, "Đã bật máy bơm!!!");
            btnTatMayBom.Show();
        }

        private void btnTatMayBom_Click(object sender, EventArgs e)
        {
            string url = @"https://sgp1.blynk.cloud/external/api/update?token=KArvFa87fr7DCTL-J90YEPSqkkD2l5zG&D0=0";
            BatTat(url, "Đã tắt máy bơm!!!");
            btnTatMayBom.Hide();
        }

        private void BatTat( string url, string trangthai)
        {
            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Trangthaimaybom();
        }

        private void Trangthaimaybom()
        {
            string url = @"https://sgp1.blynk.cloud/external/api/get?token=KArvFa87fr7DCTL-J90YEPSqkkD2l5zG&D0";
            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string urlText = reader.ReadToEnd();
            if (urlText == "1")
            {
                lbThongBao.Text = "Máy bơm đang bật!!!";
                btnTatMayBom.Show();
                btnBatMayBom.Hide();
            }
            else
            {
                lbThongBao.Text = "Máy bơm đang tắt!!!";
                btnTatMayBom.Hide();
                btnBatMayBom.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Trangthaimaybom();
        }
    }
}
