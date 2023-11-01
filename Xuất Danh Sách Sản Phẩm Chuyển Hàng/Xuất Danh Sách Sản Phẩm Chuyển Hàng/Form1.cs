using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xuất_Danh_Sách_Sản_Phẩm_Chuyển_Hàng
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
            public string TenSanPham { get; set; }
            public string HinhThucQuanLySanPham { get; set; }
            public string LoaiSanPham { get; set; }
            public string MoTaSanPham { get; set; }
            public string NhanHieu { get; set; }
            public string Tags { get; set; }
            public string ThuocTinh1 { get; set; }
            public string GiaTriThuocTinh1 { get; set; }
            public string ThuocTinh2 { get; set; }
            public string GiaTriThuocTinh2 { get; set; }
            public string ThuocTinh3 { get; set; }
            public string GiaTriThuocTinh3 { get; set; }
            public string TenPhienBanSanPham { get; set; }
            public string SKU { get; set; }
            public string Barcode { get; set; }
            public string KhoiLuong { get; set; }
            public string DonViKhoiLuong { get; set; }
            public string AnhDaiDien { get; set; }
            public string DonVi { get; set; }
            public string ApDungThue { get; set; }
            public string TonKhoBanDau { get; set; }
            public string GiaVonKhoiTao { get; set; }
            public string TonKhoToiThieu { get; set; }
            public string TonKhoToiDa { get; set; }
            public string DiemLuuKho { get; set; }
            public string GiaBanLe { get; set; }
            public string GiaNhap { get; set; }
            public string GiaShopTong { get; set; }
            public string GiaTMDT { get; set; }
            public string GiaTrungQuoc { get; set; }
            public string SoLuongChuyen { get; set; }
            public string STT { get; set; }

        }

        List<SanPham> mList_Goc = new List<SanPham>();
        List<SanPham> mListInput = new List<SanPham>();


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
                             select new SanPham()
                             {
                                 TenSanPham = dr["Tên sản phẩm*"].ToString(),
                                 HinhThucQuanLySanPham = dr["Hình thức quản lý sản phẩm"].ToString(),
                                 LoaiSanPham = dr["Loại sản phẩm"].ToString(),
                                 MoTaSanPham = dr["Mô tả sản phẩm"].ToString(),
                                 NhanHieu = dr["Nhãn hiệu"].ToString(),
                                 Tags = dr["Tags"].ToString(),
                                 ThuocTinh1 = dr["Thuộc tính 1"].ToString(),
                                 GiaTriThuocTinh1 = dr["Giá trị thuộc tính 1"].ToString(),
                                 ThuocTinh2 = dr["Thuộc tính 2"].ToString(),
                                 GiaTriThuocTinh2 = dr["Giá trị thuộc tính 2"].ToString(),
                                 ThuocTinh3 = dr["Thuộc tính 3"].ToString(),
                                 GiaTriThuocTinh3 = dr["Giá trị thuộc tính 3"].ToString(),
                                 TenPhienBanSanPham = dr["Tên phiên bản sản phẩm"].ToString(),
                                 SKU = dr["Mã SKU*"].ToString(),
                                 Barcode = dr["Barcode"].ToString(),
                                 KhoiLuong = dr["Khối lượng"].ToString(),
                                 DonViKhoiLuong = dr["Đơn vị khối lượng"].ToString(),
                                 AnhDaiDien = dr["Ảnh đại diện"].ToString(),
                                 DonVi = dr["Đơn vị"].ToString(),
                                 ApDungThue = dr["Áp dụng thuế"].ToString(),
                                 TonKhoBanDau = dr["LC_CN2_Tồn kho ban đầu*"].ToString(),
                                 GiaVonKhoiTao = dr["LC_CN2_Giá vốn khởi tạo*"].ToString(),
                                 TonKhoToiThieu = dr["LC_CN2_Tồn tối thiểu"].ToString(),
                                 TonKhoToiDa = dr["LC_CN2_Tồn tối đa"].ToString(),
                                 DiemLuuKho = dr["LC_CN2_Điểm lưu kho"].ToString(),
                                 GiaBanLe = dr["PL_Giá bán lẻ"].ToString(),
                                 GiaNhap = dr["PL_Giá nhập"].ToString(),
                                 GiaShopTong = dr["PL_Giá Shop Tổng"].ToString(),
                                 GiaTMDT = dr["PL_Giá sàn TMĐT"].ToString(),
                                 GiaTrungQuoc = dr["PL_TRUNG QUỐC"].ToString(),
                             }).ToList();
            }
            catch (Exception ex) { }
        }

        private void PasteToExcel(bool hdr)
        {
            dataGridViewInput.Rows.Clear();

            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Replace("\n", "").Split('\r');
                dataGridViewInput.Rows.Add(lines.Length - 1);
                string[] fields;
                int row = 0;
                int col = 0;

                if (lines[0].Split('\t').Count() > 3)
                {
                    MessageBox.Show("Dữ liệu không phù hợp!!!", "Thông Báo");
                }
                else
                {
                    foreach (string item in lines)
                    {
                        fields = item.Split('\t');
                        if (fields[0] != "")
                        {
                            SanPham sp = new SanPham();
                            sp.SKU = fields[0];
                            sp.SoLuongChuyen = fields[1];
                            mListInput.Add(sp);
                        }

                        foreach (string f in fields)
                        {
                            Console.WriteLine(f);
                            dataGridViewInput[col, row].Value = f;
                            col++;
                        }
                        row++;
                        col = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteToExcel(true);
        }

        private void btnRUN_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach(SanPham sp in mListInput) 
            {
                SanPham _sanpham = mList_Goc.FirstOrDefault(x => x.SKU == sp.SKU);
                if (_sanpham != null)
                {
                    sp.STT = i.ToString();
                    sp.DiemLuuKho = _sanpham.DiemLuuKho;
                    sp.TenPhienBanSanPham = _sanpham.TenPhienBanSanPham;
                }
                else
                {
                    sp.STT = i.ToString();
                    sp.DiemLuuKho = "null";
                    sp.TenPhienBanSanPham = "null";
                }
                i++;                
            }
            Show_Ket_Qua();
        }
        private void Show_Ket_Qua()
        {
            dataGridViewOutput.Rows.Clear();
            foreach (SanPham sp in mListInput)
            {
                int n = dataGridViewOutput.Rows.Add();
                dataGridViewOutput.Rows[n].Cells[0].Value = sp.STT;
                dataGridViewOutput.Rows[n].Cells[1].Value = sp.TenPhienBanSanPham;
                dataGridViewOutput.Rows[n].Cells[2].Value = sp.SKU;
                dataGridViewOutput.Rows[n].Cells[3].Value = sp.SoLuongChuyen;
            }
        }

        private void xóaTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewInput.Rows.Clear();
            mListInput = new List<SanPham>();
        }
    }
}
