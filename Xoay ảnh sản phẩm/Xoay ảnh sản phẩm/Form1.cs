using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader.Exceptions;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;



namespace Xoay_ảnh_sản_phẩm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class SanPham
        {
            public string STT { get; set; }
            public string Tensanpham { get; set; }
            public string SKU { get; set; }
            public string Anhdaidien { get; set; }
        }

        DataTableCollection tableCollection;

        public List<SanPham> mList_Goc = new List<SanPham>();
        public string LinkFoder;

        public Boolean saveRotateImg(string path)
        {
            pictureBox1.ImageLocation = path; //path to image
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            string new_path1 = path.Replace(".jpg", "_xa(1).jpg");
            string new_path2 = path.Replace(".jpg", "_xa(2).jpg");

            using (Image image = Image.FromFile(path))
            {
                //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the image to the new_path
                image.Save(new_path1, System.Drawing.Imaging.ImageFormat.Jpeg);

                pictureBox2.ImageLocation = new_path1; //path to image
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            //System.IO.File.Delete(path);

            using (Image image = Image.FromFile(path))
            {
                //rotate the picture by 180 degrees and re-save the picture as a Jpeg
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Save the image to the new_path
                image.Save(new_path2, System.Drawing.Imaging.ImageFormat.Jpeg);

                pictureBox3.ImageLocation = new_path2; //path to image
                pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            return true;
        }


        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txbFile.Text = openFileDialog.FileName;
                    saveRotateImg(openFileDialog.FileName);
                }
            }
        }

        private void bnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbxLinkExcel.Text = openFileDialog.FileName;
                    using (var steam = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                            });

                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (System.Data.DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxFoder.Text = @"C:\Users\huuuy\Downloads\AnhSP";
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                System.Data.DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
                
                mList_Goc = (from DataRow dr in dt.Rows
                             select new SanPham()
                             {
                                 STT = dr["STT"].ToString(),
                                 Tensanpham = dr["Tên sản phẩm"].ToString(),
                                 SKU = dr["SKU"].ToString(),
                                 Anhdaidien = dr["Ảnh đại diện"].ToString()
                             }).ToList();
            }
            catch
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            LinkFoder = tbxFoder.Text;
            string mSKU = tbxSKU.Text;
            WebClient webClient = new WebClient();

            SanPham mSanPham = mList_Goc.FirstOrDefault(v => v.SKU == mSKU);
            try
            {
                if (mSanPham == null)
                {
                    MessageBox.Show("Không thấy sản phẩm!!!", "Thông Báo");
                }
                else
                {
                    string localFile = LinkFoder + @"\" + mSanPham.SKU + ".jpg";
                    string remoteFile = mSanPham.Anhdaidien;
                    webClient.DownloadFile(remoteFile, localFile);
                    saveRotateImg(localFile);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông Báo");
            }
        }

        private void tbxSKU_TextChanged(object sender, EventArgs e)
        {
            btnRun_Click(sender,e);

        }

        private void tbxFoder_DoubleClick_1(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    LinkFoder = fbd.SelectedPath;
                    tbxFoder.Text = LinkFoder;
                }
            }
        }
    }
}