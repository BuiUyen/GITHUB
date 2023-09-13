using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using ExcelDataReader;

namespace Sao_chép_sản_phẩm_shopee_sang_tiktok
{
    public partial class Form1 : Form
    {
        DataTableCollection tableCollection;

        public Form1()
        {
            InitializeComponent();
        }

        public class SanPham
        {
            public string ID { get; set; }  //Mã sản phẩm shopee
            public string SKUSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string MoTaSanPham { get; set; }
            public List<PhanLoai> ListPhanLoai { get; set; }
            public List<string> ListAnh { get; set; }

            //ảnh sản phẩm
            public string AnhBia { get; set; }
            public string Anh1 { get; set; }
            public string Anh2 { get; set; }
            public string Anh3 { get; set; }
            public string Anh4 { get; set; }
            public string Anh5 { get; set; }
            public string Anh6 { get; set; }
            public string Anh7 { get; set; }
            public string Anh8 { get; set; }

            public string TenPhanLoai1 { get; set; }
            public string AnhPhanLoai1 { get; set; }
            public string TenPhanLoai2 { get; set; }
            public string AnhPhanLoai2 { get; set; }
            public string TenPhanLoai3 { get; set; }
            public string AnhPhanLoai3 { get; set; }
            public string TenPhanLoai4 { get; set; }
            public string AnhPhanLoai4 { get; set; }
            public string TenPhanLoai5 { get; set; }
            public string AnhPhanLoai5 { get; set; }
            public string TenPhanLoai6 { get; set; }
            public string AnhPhanLoai6 { get; set; }
            public string TenPhanLoai7 { get; set; }
            public string AnhPhanLoai7 { get; set; }

        }


        public class PhanLoai
        {
            public string ID { get; set; }  //Mã sản phẩm shopee
            public string SKUSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string MoTaSanPham { get; set; }
            public string IDPhanLoai { get; set; } //Mã phân loại sản phẩm shopee
            public string SKUPhanLoai { get; set; }
            public string TenPhanLoai { get; set; }
            public string GiaBan { get; set; }
            public string LinkAnh { get; set; }
            public List<string> ListAnh { get; set; }

        }

        public List<SanPham> mListGoc = new List<SanPham>();

        public List<PhanLoai> mListPhanLoai = new List<PhanLoai>();

        public List<SanPham> mListAnh = new List<SanPham>();

        public List<PhanLoai> mListKetQua = new List<PhanLoai>();

        private void btnOpenFileExcel1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbxFile1.Text = openFileDialog.FileName;
                    using (var steam = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                            });

                            tableCollection = result.Tables;
                            cbxSheet1.Items.Clear();
                            foreach (System.Data.DataTable table in tableCollection)
                                cbxSheet1.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void cbxSheet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = tableCollection[cbxSheet1.SelectedItem.ToString()];
                //dataGridViewData.DataSource = dt;
                mListGoc = (from DataRow dr in dt.Rows
                            select new SanPham()
                            {
                                ID = dr["Mã Sản phẩm"].ToString(),
                                SKUSanPham = dr["SKU Sản phẩm"].ToString(),
                                TenSanPham = dr["Tên Sản phẩm"].ToString(),
                                MoTaSanPham = dr["Mô tả Sản phẩm"].ToString()
                            }).ToList();
                HienThiFile1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnOpenFileExcel2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbxFile2.Text = openFileDialog.FileName;
                    using (var steam = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                            });

                            tableCollection = result.Tables;
                            cbxSheet2.Items.Clear();
                            foreach (System.Data.DataTable table in tableCollection)
                                cbxSheet2.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void cbxSheet2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = tableCollection[cbxSheet1.SelectedItem.ToString()];
                //dataGridViewData.DataSource = dt;
                mListPhanLoai = (from DataRow dr in dt.Rows
                                 select new PhanLoai()
                                 {
                                     ID = dr["Mã Sản phẩm"].ToString(),
                                     TenSanPham = dr["Tên Sản phẩm"].ToString(),
                                     IDPhanLoai = dr["Mã Phân loại"].ToString(),
                                     TenPhanLoai = dr["Tên phân loại"].ToString(),

                                     SKUPhanLoai = dr["SKU"].ToString(),
                                     GiaBan = dr["Giá"].ToString()
                                 }).ToList();

                HienThiFile2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnOpenFileExcel3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbxFile3.Text = openFileDialog.FileName;
                    using (var steam = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                            });

                            tableCollection = result.Tables;
                            cbxSheet3.Items.Clear();
                            foreach (System.Data.DataTable table in tableCollection)
                                cbxSheet3.Items.Add(table.TableName);
                        }
                    }
                }
            }

        }
        private void cbxSheet3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = tableCollection[cbxSheet1.SelectedItem.ToString()];
                //dataGridViewData.DataSource = dt;
                mListAnh = (from DataRow dr in dt.Rows
                            select new SanPham()
                            {
                                ID = dr["Mã Sản phẩm"].ToString(),
                                SKUSanPham = dr["SKU Sản phẩm"].ToString(),
                                TenSanPham = dr["Tên Sản phẩm"].ToString(),

                                AnhBia = dr["Ảnh bìa"].ToString(),
                                Anh1 = dr["Hình ảnh sản phẩm 1"].ToString(),
                                Anh2 = dr["Hình ảnh sản phẩm 2"].ToString(),
                                Anh3 = dr["Hình ảnh sản phẩm 3"].ToString(),
                                Anh4 = dr["Hình ảnh sản phẩm 4"].ToString(),
                                Anh5 = dr["Hình ảnh sản phẩm 5"].ToString(),
                                Anh6 = dr["Hình ảnh sản phẩm 6"].ToString(),
                                Anh7 = dr["Hình ảnh sản phẩm 7"].ToString(),
                                Anh8 = dr["Hình ảnh sản phẩm 8"].ToString(),

                                TenPhanLoai1 = dr["Tên phân loại 1"].ToString(),
                                AnhPhanLoai1 = dr["Hình ảnh phân loại 1"].ToString(),

                                TenPhanLoai2 = dr["Tên phân loại 2"].ToString(),
                                AnhPhanLoai2 = dr["Hình ảnh phân loại 2"].ToString(),

                                TenPhanLoai3 = dr["Tên phân loại 3"].ToString(),
                                AnhPhanLoai3 = dr["Hình ảnh phân loại 3"].ToString(),

                                TenPhanLoai4 = dr["Tên phân loại 4"].ToString(),
                                AnhPhanLoai4 = dr["Hình ảnh phân loại 4"].ToString(),

                                TenPhanLoai5 = dr["Tên phân loại 5"].ToString(),
                                AnhPhanLoai5 = dr["Hình ảnh phân loại 5"].ToString(),

                                TenPhanLoai6 = dr["Tên phân loại 6"].ToString(),
                                AnhPhanLoai6 = dr["Hình ảnh phân loại 6"].ToString(),

                                TenPhanLoai7 = dr["Tên phân loại 7"].ToString(),
                                AnhPhanLoai7 = dr["Hình ảnh phân loại 7"].ToString()

                            }).ToList();

                HienThiFile3();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
                MessageBox.Show(ex.ToString());
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void HienThiFile1()
        {
            dataGridViewData.Rows.Clear();
            foreach (SanPham sanpham in mListGoc)
            {
                int n = dataGridViewData.Rows.Add();
                dataGridViewData.Rows[n].Cells[0].Value = sanpham.ID;
                dataGridViewData.Rows[n].Cells[1].Value = sanpham.SKUSanPham;
                dataGridViewData.Rows[n].Cells[2].Value = sanpham.TenSanPham;
                dataGridViewData.Rows[n].Cells[3].Value = sanpham.MoTaSanPham;
            }
        }

        private void HienThiFile2()
        {
            mListKetQua = new List<PhanLoai>();

            foreach (PhanLoai _phanloai in mListPhanLoai)
            {
                _phanloai.MoTaSanPham = mListGoc.FirstOrDefault(x => x.ID == _phanloai.ID).MoTaSanPham;
                _phanloai.SKUSanPham = mListGoc.FirstOrDefault(x => x.ID == _phanloai.ID).SKUSanPham;
                mListKetQua.Add(_phanloai);
            }    

            dataGridViewData.Rows.Clear();
            foreach (PhanLoai phanloai in mListKetQua)
            {
                int n = dataGridViewData.Rows.Add();
                dataGridViewData.Rows[n].Cells[0].Value = phanloai.ID;
                dataGridViewData.Rows[n].Cells[1].Value = phanloai.SKUSanPham;
                dataGridViewData.Rows[n].Cells[2].Value = phanloai.TenSanPham;
                dataGridViewData.Rows[n].Cells[3].Value = phanloai.MoTaSanPham;
                dataGridViewData.Rows[n].Cells[4].Value = phanloai.TenPhanLoai;

                dataGridViewData.Rows[n].Cells[6].Value = phanloai.GiaBan;
                dataGridViewData.Rows[n].Cells[7].Value = phanloai.SKUPhanLoai;
            }
        }

        private void HienThiFile3()
        {
            foreach (PhanLoai _phanloai in mListKetQua)
            {
                _phanloai.ListAnh = new List<string>();
                int stt = mListAnh.FindIndex(x => x.ID == _phanloai.ID);
                _phanloai.ListAnh.Add(mListAnh[stt].AnhBia);
                _phanloai.ListAnh.Add(mListAnh[stt].Anh1);
                _phanloai.ListAnh.Add(mListAnh[stt].Anh2);
                _phanloai.ListAnh.Add(mListAnh[stt].Anh3);
                _phanloai.ListAnh.Add(mListAnh[stt].Anh4);
                _phanloai.ListAnh.Add(mListAnh[stt].Anh5);
                _phanloai.ListAnh.Add(mListAnh[stt].Anh6);
                _phanloai.ListAnh.Add(mListAnh[stt].Anh7);
                _phanloai.ListAnh.Add(mListAnh[stt].Anh8);

                if(_phanloai.TenPhanLoai == mListAnh[stt].TenPhanLoai1)
                {
                    _phanloai.LinkAnh = mListAnh[stt].AnhPhanLoai1;
                }

                if (_phanloai.TenPhanLoai == mListAnh[stt].TenPhanLoai2)
                {
                    _phanloai.LinkAnh = mListAnh[stt].AnhPhanLoai2;
                }

                if (_phanloai.TenPhanLoai == mListAnh[stt].TenPhanLoai3)
                {
                    _phanloai.LinkAnh = mListAnh[stt].AnhPhanLoai3;
                }

                if (_phanloai.TenPhanLoai == mListAnh[stt].TenPhanLoai4)
                {
                    _phanloai.LinkAnh = mListAnh[stt].AnhPhanLoai4;
                }

                if (_phanloai.TenPhanLoai == mListAnh[stt].TenPhanLoai5)
                {
                    _phanloai.LinkAnh = mListAnh[stt].AnhPhanLoai5;
                }

                if (_phanloai.TenPhanLoai == mListAnh[stt].TenPhanLoai6)
                {
                    _phanloai.LinkAnh = mListAnh[stt].AnhPhanLoai6;
                }

                if (_phanloai.TenPhanLoai == mListAnh[stt].TenPhanLoai7)
                {
                    _phanloai.LinkAnh = mListAnh[stt].AnhPhanLoai7;
                }

            }


            dataGridViewData.Rows.Clear();
            foreach (PhanLoai phanloai in mListKetQua)
            {
                int n = dataGridViewData.Rows.Add();
                dataGridViewData.Rows[n].Cells[0].Value = phanloai.ID;
                dataGridViewData.Rows[n].Cells[1].Value = phanloai.SKUSanPham;
                dataGridViewData.Rows[n].Cells[2].Value = phanloai.TenSanPham;
                dataGridViewData.Rows[n].Cells[3].Value = phanloai.MoTaSanPham;
                dataGridViewData.Rows[n].Cells[4].Value = phanloai.TenPhanLoai;

                dataGridViewData.Rows[n].Cells[5].Value = phanloai.LinkAnh;

                dataGridViewData.Rows[n].Cells[6].Value = phanloai.GiaBan;
                dataGridViewData.Rows[n].Cells[7].Value = phanloai.SKUPhanLoai;

                for(int i = 0; i < phanloai.ListAnh.Count; i++)
                {
                    dataGridViewData.Rows[n].Cells[8+i].Value = phanloai.ListAnh[i];
                }
            }

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Trang_tính1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            worksheet.Name = "Uyên";

            for (int i = 1; i < dataGridViewData.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewData.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewData.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewData.Columns.Count; j++)
                {
                    try
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridViewData.Rows[i].Cells[j].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }

                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Danh sach san pham Kool up tiktok";
            saveFileDialog.DefaultExt = ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }
    }
}