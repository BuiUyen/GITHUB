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

namespace Danh_Sách_Sản_Phẩm_Up_Shopee
{
    public partial class Form1 : Form
    {
        DataTableCollection tableCollection;

        public Form1()
        {
            InitializeComponent();
        }
        public class LinhKien
        {
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string MaPhanLoai { get; set; }
            public string TenPhanLoai { get; set; }
            public string SKUSanPham { get; set; }
            public string SKU { get; set; }
            public string Gia { get; set; }
            public string SoLuong { get; set; }
            public List<PhanLoai> mListPhanLoai { get; set; } = new List<PhanLoai>();
        }

        public class PhanLoai
        {
            public string MaPhanLoai { get; set; }
            public string TenPhanLoai { get; set; }
            public string SKUSanPham { get; set; }
            public string SKU { get; set; }
        }



        public List<LinhKien> mList_Goc = new List<LinhKien>();
        public List<LinhKien> mList = new List<LinhKien>();

        public List<LinhKien> mList_KetQua = new List<LinhKien>();

        private void btnOpenFileExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbxFile.Text = openFileDialog.FileName;
                    using (var steam = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                            });

                            tableCollection = result.Tables;
                            cbxSheet.Items.Clear();
                            foreach (System.Data.DataTable table in tableCollection)
                                cbxSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void cbxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = tableCollection[cbxSheet.SelectedItem.ToString()];
                dataGridViewData.DataSource = dt;
                mList_Goc = (from DataRow dr in dt.Rows
                             select new LinhKien()
                             {
                                 MaSanPham = dr["Mã Sản phẩm"].ToString(),
                                 TenSanPham = dr["Tên Sản phẩm"].ToString(),
                                 MaPhanLoai = dr["Mã Phân loại"].ToString(),
                                 TenPhanLoai = dr["Tên phân loại"].ToString(),
                                 SKUSanPham = dr["SKU Sản phẩm"].ToString(),
                                 SKU = dr["SKU"].ToString(),
                                 Gia = dr["Giá"].ToString(),
                                 SoLuong = dr["Số lượng"].ToString()                                 
                             }).ToList();


                for (int x = 0; x < mList_Goc.Count; x++)
                {
                    PhanLoai _phanloai = new PhanLoai();
                    _phanloai.MaPhanLoai = mList_Goc[x].MaPhanLoai;
                    _phanloai.TenPhanLoai = mList_Goc[x].TenPhanLoai;
                    _phanloai.SKUSanPham = mList_Goc[x].SKUSanPham;
                    _phanloai.SKU = mList_Goc[x].SKU;

                    if (mList.FirstOrDefault(v => v.MaSanPham == mList_Goc[x].MaSanPham) == null)
                    {
                        LinhKien _linhkien = new LinhKien();
                        _linhkien = mList_Goc[x];                        
                        _phanloai.SKU = mList_Goc[x].SKU;
                        _linhkien.mListPhanLoai.Add(_phanloai);
                        mList.Add(_linhkien);
                    }
                    else
                    {
                        int stt = mList.FindIndex(v => v.MaSanPham == mList_Goc[x].MaSanPham);
                        mList[stt].mListPhanLoai.Add(_phanloai);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
                MessageBox.Show(Ex.ToString());
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string[] masp = tbxListMaSanPham.Text.Split('\n');
            for (int i = 0; i < masp.Length; i++)
            {
                int stt = mList.FindIndex(v => v.MaSanPham == masp[i].Substring(0, 10));
                mList_KetQua.Add(mList[stt]);
            }
            ShowDataGirdViewKetQua(mList_KetQua);
        }

        private void ShowDataGirdViewKetQua(List<LinhKien> ListInput)
        {
            dataGridViewKetQua.Rows.Clear();
            foreach (LinhKien tag in mList_KetQua)
            {
                int n = dataGridViewKetQua.Rows.Add();
                dataGridViewKetQua.Rows[n].Cells[0].Value = tag.MaSanPham.ToString();
                dataGridViewKetQua.Rows[n].Cells[1].Value = tag.TenSanPham.ToString();
                dataGridViewKetQua.Rows[n].Cells[2].Value = tag.MaPhanLoai.ToString();
                dataGridViewKetQua.Rows[n].Cells[3].Value = tag.TenPhanLoai.ToString();
                dataGridViewKetQua.Rows[n].Cells[4].Value = tag.SKUSanPham.ToString();
                dataGridViewKetQua.Rows[n].Cells[5].Value = tag.SKU.ToString();
                dataGridViewKetQua.Rows[n].Cells[6].Value = tag.Gia.ToString();
                dataGridViewKetQua.Rows[n].Cells[7].Value = tag.SoLuong.ToString();
            }
        }

    }
}
