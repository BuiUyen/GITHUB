using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chỉnh_sửa_đồng_bộ_giá
{
    public partial class Form1 : Form
    {
        DataTableCollection tableCollection;
        public class LinhKien
        {
            public string TenSanPham { get; set; }
            public string HinhThucQuanLySanPham { get; set; }
            public string LoaiSanPham { get; set; }
            public string MoTaSanPham { get; set; }
            public string NhanHieu { get; set; }
            public string Tags { get; set; }
            public string ThuocTinh1 { get; set; }
            public string GiaTriThuocTinh1 { get; set; }
            //
            public string ThuocTinh2 { get; set; }
            public string GiaTriThuocTinh2 { get; set; }
            //
            public string ThuocTinh3 { get; set; }
            public string GiaTriThuocTinh3 { get; set; }
            //
            public string TenPhienBanSanPham { get; set; }
            public string MaSKU { get; set; }
            public string Barcode { get; set; }
            public string KhoiLuong { get; set; }
            public string DonViKhoiLuong { get; set; }
            public string AnhDaiDien { get; set; }
            public string DonVi { get; set; }
            public string ApDungThue { get; set; }
            public string GiaVonKhoiTao { get; set; }
            public string TonKhoBanDau { get; set; }
            public string TonKhoToiThieu { get; set; }
            public string TonKhoToiDa { get; set; }
            public string DiemLuuKho { get; set; }
            public string GiaBanBuon { get; set; }
            public string GiaNhap { get; set; }
            public string GiaBanLe { get; set; }
            public List<LinhKien> mListThuocTinh { get; set; } = new List<LinhKien>();
            public string SKU_SanPhamChinh { get; set; }
        }

        public class GiaInput
        {
            public string TenSanPham { get; set; }
            public string SKU { get; set; }
            public string GiaBanLe { get; set; }
            public string Sapo { get; set; }
            public string ShopeeChoTroi { get; set; }
            public string ShopeeLinhKien { get; set; }
            public string ShopeeAna { get; set; }
            public string ShopeeCoDienTu { get; set; }
        }
        
        public List<LinhKien> mList_Goc = new List<LinhKien>();
        public List<LinhKien> mList_PhienBanSanPham = new List<LinhKien>();
        public List<LinhKien> mList_KetQua = new List<LinhKien>();
        public List<GiaInput> mListGiaInput = new List<GiaInput>();

        public Form1()
        {
            InitializeComponent();
        }

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
                dataGridViewData_Goc.DataSource = dt;
                mList_Goc = (from DataRow dr in dt.Rows
                             select new LinhKien()
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
                                 MaSKU = dr["Mã SKU*"].ToString(),
                                 Barcode = dr["Barcode"].ToString(),
                                 KhoiLuong = dr["Khối lượng"].ToString(),
                                 DonViKhoiLuong = dr["Đơn vị khối lượng"].ToString(),
                                 AnhDaiDien = dr["Ảnh đại diện"].ToString(),
                                 DonVi = dr["Đơn vị"].ToString(),
                                 ApDungThue = dr["Áp dụng thuế"].ToString(),
                                 GiaVonKhoiTao = dr["LC_CN1_Giá vốn khởi tạo*"].ToString(),
                                 TonKhoBanDau = dr["LC_CN1_Tồn kho ban đầu*"].ToString(),
                                 TonKhoToiThieu = dr["LC_CN1_Tồn tối thiểu"].ToString(),
                                 TonKhoToiDa = dr["LC_CN1_Tồn tối đa"].ToString(),
                                 DiemLuuKho = dr["LC_CN1_Điểm lưu kho"].ToString(),
                                 GiaBanBuon = dr["PL_Giá bán buôn"].ToString(),
                                 GiaNhap = dr["PL_Giá nhập"].ToString(),
                                 GiaBanLe = dr["PL_Giá bán lẻ"].ToString()
                             }).ToList();

                mList_PhienBanSanPham = XuLyFileNguon(mList_Goc);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
                MessageBox.Show(Ex.ToString());
            }
        }
        
        private void BrowseFolderButton_Click()
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;            
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbxFolder.Text = folderDlg.SelectedPath;
                //Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        public List<LinhKien> mList_PhienBan_Sapo = new List<LinhKien>();
        public List<LinhKien> mList_Sapo = new List<LinhKien>();

        public List<LinhKien> mList_PhienBan_ChoTroi = new List<LinhKien>();
        public List<LinhKien> mList_ChoTroi = new List<LinhKien>();

        public List<LinhKien> mList_PhienBan_LinhKien = new List<LinhKien>();
        public List<LinhKien> mList_LinhKien = new List<LinhKien>();

        public List<LinhKien> mList_PhienBan_Ana = new List<LinhKien>();
        public List<LinhKien> mList_Ana = new List<LinhKien>();

        public List<LinhKien> mList_PhienBan_CoDienTu = new List<LinhKien>();
        public List<LinhKien> mList_CoDienTu = new List<LinhKien>();

        private void btnFolder_Click(object sender, EventArgs e)
        {
            BrowseFolderButton_Click();
            mList_PhienBan_Sapo = DocFileNguon(tbxFolder.Text + @"\" + "SAPO.xlsx");
            mList_Sapo = XuLyFileNguon(mList_PhienBan_Sapo);
            lbSoSanPham1.Text = mList_Sapo.Count().ToString();
            lbPhienBanSanPham1.Text = mList_PhienBan_Sapo.Count().ToString();


            mList_PhienBan_ChoTroi = DocFileNguon(tbxFolder.Text + @"\" + "Shopee ChoTroi.xlsx");
            mList_ChoTroi = XuLyFileNguon(mList_PhienBan_ChoTroi);
            lbSoSanPham2.Text = mList_ChoTroi.Count().ToString();
            lbPhienBanSanPham2.Text = mList_PhienBan_ChoTroi.Count().ToString();


            mList_PhienBan_LinhKien = DocFileNguon(tbxFolder.Text + @"\" + "Shopee LinhKien.xlsx");
            mList_LinhKien = XuLyFileNguon(mList_PhienBan_LinhKien);
            lbSoSanPham3.Text = mList_LinhKien.Count().ToString();
            lbPhienBanSanPham3.Text = mList_PhienBan_LinhKien.Count().ToString();


            mList_PhienBan_Ana = DocFileNguon(tbxFolder.Text + @"\" + "Shopee Ana.xlsx");
            mList_Ana = XuLyFileNguon(mList_PhienBan_Ana);
            lbSoSanPham4.Text = mList_Ana.Count().ToString();
            lbPhienBanSanPham4.Text = mList_PhienBan_Ana.Count().ToString();


            mList_PhienBan_CoDienTu = DocFileNguon(tbxFolder.Text + @"\" + "Shopee CoDienTu.xlsx");
            mList_CoDienTu = XuLyFileNguon(mList_PhienBan_CoDienTu);
            lbSoSanPham5.Text = mList_CoDienTu.Count().ToString();
            lbPhienBanSanPham5.Text = mList_PhienBan_CoDienTu.Count().ToString();

        }

        private void dataGridViewInput_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.V) && (e.Modifiers == Keys.Control))
            {
                PasteToExcel(true);
                e.Handled = true;
            }
        }

        private void CopyToExcel(bool hdr)
        {
            if (dataGridViewInput.SelectedRows.Count > 0)
            {
                string scopy = "<table>{0}<tbody>";
                string sheaders = "";
                foreach (DataGridViewRow row in dataGridViewInput.SelectedRows)
                {
                    if (hdr && string.IsNullOrEmpty(sheaders))
                    {
                        sheaders = "<theader><tr>";
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sheaders += "<th>" + cell.OwningColumn.HeaderText +
                                "</th>";
                        }
                        sheaders += "</tr></theader>";
                    }
                    scopy += "<tr>";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.ValueType == typeof(DateTime))
                            {
                                scopy +=
                                    "<td style=mso-number-format:\"dd/MM/yyyy HH:mm\">"
                                    + cell.Value.ToString() + "</td>";
                            }
                            else if (cell.ValueType == typeof(bool))
                            {
                                scopy += "<td style=mso-number-format:\"\\@\">" +
                                   (Convert.ToBoolean(cell.Value) ? "Yes" : "No") +
                                   "</td>";
                            }
                            else if (cell.ValueType == typeof(int))
                            {
                                scopy += "<td style=mso-number-format:\"0\">" +
                                    cell.Value.ToString() + "</td>";
                            }
                            else if (cell.ValueType == typeof(double))
                            {
                                scopy += "<td style=mso-number-format:\"0.00\">" +
                                    cell.Value.ToString() + "</td>";
                            }
                            else
                            {
                                scopy += "<td style=mso-number-format:\"\\@\">" +
                                    cell.Value.ToString() + "</td>";
                            }
                        }
                        else
                        {
                            scopy += "<td style=mso-number-format:\"\\@\"/>";
                        }
                    }
                    scopy += "</tr>";
                }
                scopy += "</tbody></table>";
                Clipboard.SetData(DataFormats.Text, string.Format(scopy, sheaders));
            }
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

                if (lines[0].Split('\t').Count() > 2)
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
                            GiaInput _giainput = new GiaInput();
                            _giainput.SKU = fields[0];
                            _giainput.GiaBanLe = fields[1];
                            mListGiaInput.Add(_giainput);
                        }
                        else
                        {
                            GiaInput _giainput = new GiaInput();
                            _giainput.SKU = "lỗi";
                            _giainput.GiaBanLe = "chưa có giá";
                            mListGiaInput.Add(_giainput);
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
            catch (Exception Ex)
            {
                MessageBox.Show("-> Lỗi dữ liệu nguồn!!!", "Thông Báo");
                MessageBox.Show(Ex.ToString());
            }
        }

        private void xóaTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewInput.Rows.Clear();
            mListGiaInput = new List<GiaInput>();
        }

        private void dánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteToExcel(true);
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            mList_KetQua = new List<LinhKien>();

            foreach (GiaInput _giaInput in mListGiaInput)
            {
                LinhKien _linhkien = new LinhKien();
                if (mList_Goc.FirstOrDefault(v => v.MaSKU == _giaInput.SKU.Trim()) != null)
                {
                    //string SKU = mList_Goc.FirstOrDefault(v => v.MaSKU == _giaInput.SKU.Trim()).SKU_SanPhamChinh;
                    //_linhkien = mList_PhienBanSanPham.FirstOrDefault(v => v.MaSKU == SKU);
                    //foreach (LinhKien lk in _linhkien.mListThuocTinh)
                    //{
                    //    if (lk.MaSKU == _giaInput.SKU)
                    //    {
                    //        lk.GiaBanLe = _giaInput.GiaBanLe;
                    //    }
                    //    mList_KetQua.Add(lk);
                    //}

                    _linhkien = mList_Goc.FirstOrDefault(v => v.MaSKU == _giaInput.SKU.Trim());
                    mList_KetQua.Add(_linhkien);
                }
                else
                {
                    _linhkien.MaSKU = "không tìm thấy SKU";
                    _linhkien.GiaNhap = "chưa có giá nhập";
                    mList_KetQua.Add(_linhkien);
                    //MessageBox.Show("Lỗi SKU sản phẩm không tìm thấy: " + _giaInput.SKU.Trim(), "Thông Báo");
                }
            }

            //foreach (LinhKien _lk in mList_Goc)
            //{
            //    //LinhKien _linhkien = new LinhKien();
            //    if (mListGiaInput.FirstOrDefault(v => v.SKU.Trim() == _lk.MaSKU) == null)
            //    {
            //        mList_KetQua.Add(_lk);
            //    }
            //    else
            //    {
            //        _lk.MoTaSanPham = mListGiaInput.FirstOrDefault(v => v.SKU.Trim() == _lk.MaSKU).GiaBanLe;
            //        mList_KetQua.Add(_lk);
            //    }
            //}

            dataGridViewKetQua.Rows.Clear();
            foreach (LinhKien sp in mList_KetQua)
            {
                int n = dataGridViewKetQua.Rows.Add();
                dataGridViewKetQua.Rows[n].Cells[0].Value = sp.TenSanPham;
                dataGridViewKetQua.Rows[n].Cells[1].Value = sp.HinhThucQuanLySanPham;
                dataGridViewKetQua.Rows[n].Cells[2].Value = sp.LoaiSanPham;
                dataGridViewKetQua.Rows[n].Cells[3].Value = sp.MoTaSanPham;
                dataGridViewKetQua.Rows[n].Cells[4].Value = sp.NhanHieu;
                dataGridViewKetQua.Rows[n].Cells[5].Value = sp.Tags;
                dataGridViewKetQua.Rows[n].Cells[6].Value = sp.ThuocTinh1;
                dataGridViewKetQua.Rows[n].Cells[7].Value = sp.GiaTriThuocTinh1;
                dataGridViewKetQua.Rows[n].Cells[8].Value = sp.ThuocTinh2;
                dataGridViewKetQua.Rows[n].Cells[9].Value = sp.GiaTriThuocTinh2;
                dataGridViewKetQua.Rows[n].Cells[10].Value = sp.ThuocTinh3;
                dataGridViewKetQua.Rows[n].Cells[11].Value = sp.GiaTriThuocTinh3;
                dataGridViewKetQua.Rows[n].Cells[12].Value = sp.TenPhienBanSanPham;
                dataGridViewKetQua.Rows[n].Cells[13].Value = sp.MaSKU;
                dataGridViewKetQua.Rows[n].Cells[14].Value = sp.Barcode;
                dataGridViewKetQua.Rows[n].Cells[15].Value = sp.KhoiLuong;
                dataGridViewKetQua.Rows[n].Cells[16].Value = sp.DonViKhoiLuong;
                dataGridViewKetQua.Rows[n].Cells[17].Value = sp.AnhDaiDien;
                dataGridViewKetQua.Rows[n].Cells[18].Value = sp.DonVi;
                dataGridViewKetQua.Rows[n].Cells[19].Value = sp.ApDungThue;
                dataGridViewKetQua.Rows[n].Cells[20].Value = sp.GiaVonKhoiTao;
                dataGridViewKetQua.Rows[n].Cells[21].Value = sp.TonKhoBanDau;
                dataGridViewKetQua.Rows[n].Cells[22].Value = sp.TonKhoToiThieu;
                dataGridViewKetQua.Rows[n].Cells[23].Value = sp.TonKhoToiDa;
                dataGridViewKetQua.Rows[n].Cells[24].Value = sp.DiemLuuKho;
                dataGridViewKetQua.Rows[n].Cells[25].Value = sp.GiaBanBuon;
                dataGridViewKetQua.Rows[n].Cells[26].Value = sp.GiaNhap;
                dataGridViewKetQua.Rows[n].Cells[27].Value = sp.GiaBanLe;
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
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
                    if (dataGridViewKetQua.Rows[i].Cells[j].Value == null)
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridViewKetQua.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Kết quả điều chỉnh giá sản phẩm";
            saveFileDialog.DefaultExt = ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private List<LinhKien> XuLyFileNguon(List<LinhKien> mList)
        {
            List<LinhKien> _mList_PhienBanSanPham = new List<LinhKien>();

            for (int x = 0; x < mList.Count; x++)
            {
                LinhKien lk = mList[x];
                if (lk.TenSanPham == "")
                {
                    int t = _mList_PhienBanSanPham.Count();
                    _mList_PhienBanSanPham[t - 1].mListThuocTinh.Add(lk);

                    mList[x].SKU_SanPhamChinh = _mList_PhienBanSanPham[t - 1].MaSKU;
                }
                else
                {
                    lk.mListThuocTinh.Add(lk);
                    _mList_PhienBanSanPham.Add(lk);
                    mList[x].SKU_SanPhamChinh = mList[x].MaSKU;
                }
            }
            return _mList_PhienBanSanPham;
        }

        private List<LinhKien> DocFileNguon(string FileName)
        {


            List<LinhKien> mList = new List<LinhKien>();

            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                try
                {
                    using (var steam = File.Open(FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;

                            System.Data.DataTable dt = tableCollection[tableCollection[0].TableName];
                            mList = (from DataRow dr in dt.Rows
                                     select new LinhKien()
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
                                         MaSKU = dr["Mã SKU*"].ToString(),
                                         Barcode = dr["Barcode"].ToString(),
                                         KhoiLuong = dr["Khối lượng"].ToString(),
                                         DonViKhoiLuong = dr["Đơn vị khối lượng"].ToString(),
                                         AnhDaiDien = dr["Ảnh đại diện"].ToString(),
                                         DonVi = dr["Đơn vị"].ToString(),
                                         ApDungThue = dr["Áp dụng thuế"].ToString(),
                                         GiaVonKhoiTao = dr["LC_CN1_Giá vốn khởi tạo*"].ToString(),
                                         TonKhoBanDau = dr["LC_CN1_Tồn kho ban đầu*"].ToString(),
                                         TonKhoToiThieu = dr["LC_CN1_Tồn tối thiểu"].ToString(),
                                         TonKhoToiDa = dr["LC_CN1_Tồn tối đa"].ToString(),
                                         DiemLuuKho = dr["LC_CN1_Điểm lưu kho"].ToString(),
                                         GiaBanLe = dr["PL_Giá bán lẻ"].ToString()
                                     }).ToList();


                        }

                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
                    MessageBox.Show(Ex.ToString());
                }
            }
            return mList;
        }

        private void btnXuLyChung_Click(object sender, EventArgs e)
        {
            dataGridViewXuLyChung.Rows.Clear();

            foreach (GiaInput _giaInput in mListGiaInput)
            {
                _giaInput.TenSanPham = mList_PhienBan_Sapo.FirstOrDefault(v => v.MaSKU == _giaInput.SKU.Trim()).TenSanPham;
                _giaInput.Sapo = _giaInput.GiaBanLe;

                if (mList_PhienBan_ChoTroi.FirstOrDefault(v => v.MaSKU == _giaInput.SKU.Trim()) != null)
                {
                    _giaInput.ShopeeChoTroi = _giaInput.GiaBanLe;

                }
                else
                {
                    _giaInput.ShopeeChoTroi = "K";
                }

                if (mList_PhienBan_LinhKien.FirstOrDefault(v => v.MaSKU == _giaInput.SKU.Trim()) != null)
                {
                    _giaInput.ShopeeLinhKien = _giaInput.GiaBanLe;

                }
                else
                {
                    _giaInput.ShopeeLinhKien = "K";
                }

                if (mList_PhienBan_Ana.FirstOrDefault(v => v.MaSKU == _giaInput.SKU.Trim()) != null)
                {
                    _giaInput.ShopeeAna = _giaInput.GiaBanLe;

                }
                else
                {
                    _giaInput.ShopeeAna = "K";
                }

                if (mList_PhienBan_CoDienTu.FirstOrDefault(v => v.MaSKU == _giaInput.SKU.Trim()) != null)
                {
                    _giaInput.ShopeeCoDienTu = _giaInput.GiaBanLe;
                }
                else
                {
                    _giaInput.ShopeeCoDienTu = "K";
                }

                int n = dataGridViewXuLyChung.Rows.Add();
                dataGridViewXuLyChung.Rows[n].Cells[0].Value = _giaInput.TenSanPham;
                dataGridViewXuLyChung.Rows[n].Cells[1].Value = _giaInput.SKU;
                dataGridViewXuLyChung.Rows[n].Cells[2].Value = _giaInput.Sapo;
                dataGridViewXuLyChung.Rows[n].Cells[3].Value = _giaInput.ShopeeChoTroi;
                dataGridViewXuLyChung.Rows[n].Cells[4].Value = _giaInput.ShopeeLinhKien;
                dataGridViewXuLyChung.Rows[n].Cells[5].Value = _giaInput.ShopeeAna;
                dataGridViewXuLyChung.Rows[n].Cells[6].Value = _giaInput.ShopeeCoDienTu;
            }
        }

        private void btnWebtoShopee_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }
    }
}
