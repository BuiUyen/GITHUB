using ExcelDataReader;
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

namespace Dang_San_Phan_Sapo_Len_Shopee
{
    public partial class Form1 : Form
    {
        public class LinhKien
        {
            public string DuongDan { get; set; }
            public string TenSanPham { get; set; }
            public string NoiDung { get; set; }
            public string HienThi { get; set; }
            public string SKU { get; set; }
            public string Gia { get; set; }
            public string MaVach { get; set; }
            public string AnhDaiDien { get; set; }
            public string LinkAnhSaPo { get; set; }
            public List<string> ListAnh { get; set; } = new List<string>();
            public string CanNang { get; set; }
        }

        public List<LinhKien> mList_Goc = new List<LinhKien>();
        public List<LinhKien> mList_KetQua = new List<LinhKien>();

        DataTableCollection tableCollection;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbxLinkExcel.Text = openFileDialog.FileName;
                    using (var steam = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
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
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                System.Data.DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
                dataGridViewData.DataSource = dt;
                mList_Goc = (from DataRow dr in dt.Rows
                             select new LinhKien()
                             {
                                 DuongDan = dr["Đường dẫn / Alias"].ToString(),
                                 TenSanPham = dr["Tên sản phẩm"].ToString(),
                                 NoiDung = dr["Nội dung"].ToString(),
                                 HienThi = dr["Hiển thị"].ToString(),
                                 SKU = dr["Mã (SKU)"].ToString(),
                                 Gia = dr["Giá"].ToString(),
                                 MaVach = dr["Mã vạch(Barcode)"].ToString(),
                                 AnhDaiDien = dr["Ảnh đại diện"].ToString(),
                                 CanNang = dr["Cân nặng"].ToString()
                             }).ToList();                
            }
            catch
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
            }
        }

        private void btnXuLi_Click(object sender, EventArgs e)
        {
            foreach(LinhKien _linhkien in mList_Goc)
            {
                if (mList_KetQua.FirstOrDefault(v => v.DuongDan == _linhkien.DuongDan) == null)
                {
                    LinhKien mLinhKien = new LinhKien();
                    mLinhKien = _linhkien;
                    mLinhKien.ListAnh.Add(_linhkien.AnhDaiDien);
                    mLinhKien.LinkAnhSaPo = _linhkien.AnhDaiDien;
                    mList_KetQua.Add(mLinhKien);

                }
                else
                {                    
                    int x = mList_KetQua.FindIndex(v => v.DuongDan == _linhkien.DuongDan);
                    mList_KetQua[x].ListAnh.Add(_linhkien.AnhDaiDien);
                    mList_KetQua[x].LinkAnhSaPo = mList_KetQua[x].LinkAnhSaPo + "," + _linhkien.AnhDaiDien;
                }
            }
            ShowDataGirdViewEnd();
        }

        private void ShowDataGirdViewEnd()
        {
            dataGridViewKetQua.Rows.Clear();
            foreach (LinhKien mLinhKien in mList_KetQua)
            {
                int n = dataGridViewKetQua.Rows.Add();
                dataGridViewKetQua.Rows[n].Cells[0].Value = mLinhKien.DuongDan;
                dataGridViewKetQua.Rows[n].Cells[1].Value = mLinhKien.TenSanPham;
                dataGridViewKetQua.Rows[n].Cells[2].Value = mLinhKien.NoiDung;
                dataGridViewKetQua.Rows[n].Cells[3].Value = mLinhKien.HienThi;
                dataGridViewKetQua.Rows[n].Cells[4].Value = mLinhKien.SKU;
                dataGridViewKetQua.Rows[n].Cells[5].Value = mLinhKien.Gia;
                dataGridViewKetQua.Rows[n].Cells[6].Value = mLinhKien.MaVach;
                dataGridViewKetQua.Rows[n].Cells[7].Value = mLinhKien.LinkAnhSaPo;
                dataGridViewKetQua.Rows[n].Cells[8].Value = mLinhKien.CanNang;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Trang_tính1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Uyên";

            for (int i = 1; i < dataGridViewKetQua.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewKetQua.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewKetQua.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewKetQua.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridViewKetQua.Rows[i].Cells[j].Value.ToString();
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Ket Qua";
            saveFileDialog.DefaultExt = ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }
    }
}
