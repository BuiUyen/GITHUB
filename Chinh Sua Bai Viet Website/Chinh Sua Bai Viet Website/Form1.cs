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
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Chinh_Sua_Bai_Viet_Website
{
    public partial class Form1 : Form
    {
        DataTableCollection tableCollection;

        public class LinhKien
        {            
            public string Alias { get; set; }
            public string TenSanPham { get; set; }
            public string NoiDung { get; set; }
            public string NhaCungCap { get; set; }
            public string Loai { get; set; }
            public string Tag { get; set; }
            public string HienThi { get; set; }
            public string ThuocTinh { get; set; }
            public string GiaTriThuocTinh { get; set; }
            //
            public string ThuocTinh2 { get; set; }
            public string GiaTriThuocTinh2 { get; set; }
            //
            public string ThuocTinh3 { get; set; }
            public string GiaTriThuocTinh3 { get; set; }
            //
            public string SKU { get; set; }
            public string QuanLyKho { get; set; }
            public string SoLuong { get; set; }
            public string ChoPhepBan { get; set; }

            public string Variant { get; set; }
            public string Gia { get; set; }
            public string GiaSoSanh { get; set; }
            public string YeuCauVanChuyen { get; set; }
            public string VAT { get; set; }
            public string MaVach { get; set; }
            public string AnhDaiDien { get; set; }
            public string ChuThich { get; set; }
            public string TheTieuDe { get; set; }
            public string TheMoTa { get; set; }
            public string CanNang { get; set; }
            public string DonViCan { get; set; }
            public string AnhPhienBan { get; set; }
            public string MoTaNgan { get; set; }
            public string ID { get; set; }
            public string IDTuyChon { get; set; }    
            
            //thông số thêm
            public List<string> mListAnh { get; set; } = new List<string>();
            public string TenPhienBan { get; set; }
            public List<LinhKien> mListLinhKien { get; set; } = new List<LinhKien>();
            public string MaNganhSenDo { get; set; }
            public string ThongSo { get; set; }
            public string CongDung { get; set; }
            public List<LinhKien> mListPhanLoai { get; set; } = new List<LinhKien>();
        }

        public class Tags
        {
            public int ID { get; set; }
            public string Tag { get; set; }

        }

        public class NganhHang
        {
            public string TuKhoa { get; set; }
            public string MaNganh { get; set; }

        }
        public class SanPhamSendo
        {
            public string ID { get; set; }
            public string TenSanPham { get; set; }
            public string SKU { get; set; }
            public string TinhTrang { get; set; }
        }

        public List<LinhKien> mList_Goc = new List<LinhKien>();
        public List<LinhKien> mList = new List<LinhKien>();// list đã xử lý phân loại
        public List<Tags> mListTags = new List<Tags>();
        public List<Tags> mListTagsKetQua = new List<Tags>();
        public List<LinhKien> mListXepAnh = new List<LinhKien>();

        public List<NganhHang> mListNganh = new List<NganhHang>();

        public Form1()
        {            
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {            
            btnExcel.Hide();
            try
            {
                using (StreamReader sr = File.OpenText(@"Tags.txt"))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Tags tag = new Tags();
                        tag.ID = mListTags.Count;
                        tag.Tag = s;
                        mListTags.Add(tag);                        
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            ShowDataGirdViewTagsGoiY(mListTags);
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
            Nganhhang();

            //try
            {
                System.Data.DataTable dt = tableCollection[cbxSheet.SelectedItem.ToString()];
                dataGridViewData.DataSource = dt;
                mList_Goc = (from DataRow dr in dt.Rows
                             select new LinhKien()
                             {
                                 Alias = dr["Đường dẫn / Alias"].ToString(),
                                 TenSanPham = dr["Tên sản phẩm"].ToString(),
                                 NoiDung = dr["Nội dung"].ToString(),
                                 NhaCungCap = dr["Nhà cung cấp"].ToString(),
                                 Loai = dr["Loại"].ToString(),
                                 Tag = dr["Tags"].ToString(),
                                 HienThi = dr["Hiển thị"].ToString(),
                                 ThuocTinh  = dr["Thuộc tính 1(Option1 Name)"].ToString(),
                                 GiaTriThuocTinh = dr["Giá trị thuộc tính 1(Option1 Value)"].ToString(),
                                 ThuocTinh2 = dr["Thuộc tính 2(Option2 Name)"].ToString(),
                                 GiaTriThuocTinh2 = dr["Giá trị thuộc tính 2(Option2 Value)"].ToString(),
                                 ThuocTinh3 = dr["Thuộc tính 3(Option3 Name)"].ToString(),
                                 GiaTriThuocTinh3 = dr["Giá trị thuộc tính 1(Option3 Value)"].ToString(),
                                 SKU = dr["Mã (SKU)"].ToString(),
                                 QuanLyKho = dr["Quản lý kho"].ToString(),
                                 SoLuong = dr["Số lượng"].ToString(),
                                 ChoPhepBan = dr["Cho phép tiếp tục mua khi hết hàng(continue/deny)"].ToString(),
                                 Variant = dr["Variant Fulfillment Service"].ToString(),
                                 Gia = dr["Giá"].ToString(),
                                 GiaSoSanh = dr["Giá so sánh"].ToString(),
                                 YeuCauVanChuyen = dr["Yêu cầu vận chuyển"].ToString(),
                                 VAT = dr["VAT"].ToString(),
                                 MaVach = dr["Mã vạch(Barcode)"].ToString(),
                                 AnhDaiDien = dr["Ảnh đại diện"].ToString(),
                                 ChuThich = dr["Chú thích ảnh"].ToString(),
                                 TheTieuDe = dr["Thẻ tiêu đề(SEO Title)"].ToString(),
                                 TheMoTa = dr["Thẻ mô tả(SEO Description)"].ToString(),
                                 CanNang = dr["Cân nặng"].ToString(),
                                 DonViCan = dr["Đơn vị cân nặng"].ToString(),
                                 AnhPhienBan = dr["Ảnh phiên bản"].ToString(),
                                 MoTaNgan = dr["Mô tả ngắn"].ToString(),
                                 ID = dr["Id sản phẩm"].ToString(),
                                 IDTuyChon = dr["Id tùy chọn"].ToString()
                             }).ToList();


                for (int x = 0; x < mList_Goc.Count; x++)
                {
                    if (mList.FirstOrDefault(v => v.ID == mList_Goc[x].ID) == null)
                    {
                        LinhKien _linhkien = new LinhKien();
                        _linhkien = mList_Goc[x];
                        _linhkien.mListLinhKien.Add(mList_Goc[x]);
                        _linhkien.mListPhanLoai.Add(mList_Goc[x]);

                        if (mList_Goc[x].AnhDaiDien != "")
                        {
                            _linhkien.mListAnh.Add(mList_Goc[x].AnhDaiDien);
                        }
                        mList.Add(_linhkien);
                    }
                    else
                    {
                        int stt = mList.FindIndex(v => v.ID == mList_Goc[x].ID);
                        mList_Goc[x].ThuocTinh = mList[stt].ThuocTinh;

                        mList[stt].mListLinhKien.Add(mList_Goc[x]);                        

                        //thêm link ảnh vào list mListLinhKien
                        if (mList_Goc[x].AnhDaiDien != "")
                        {
                            mList[stt].mListAnh.Add(mList_Goc[x].AnhDaiDien);
                        }

                        //thêm phân loại vào list mListPhanLoai
                        if (mList_Goc[x].IDTuyChon != "")
                        {
                            mList[stt].mListPhanLoai.Add(mList_Goc[x]);
                        }
                    }

                    //tạo tên phiên bản
                    if (mList_Goc[x].TenSanPham == "")
                    {
                        LinhKien lk = mList_Goc.FirstOrDefault(v => v.ID == mList_Goc[x].ID);
                        mList_Goc[x].TenPhienBan = lk.TenSanPham + " - " + mList_Goc[x].GiaTriThuocTinh;
                    }
                    else
                    {
                        mList_Goc[x].TenPhienBan = mList_Goc[x].TenSanPham;
                    }    
                }
            }
            //catch(Exception Ex)
            //{
            //    MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
            //    MessageBox.Show(Ex.ToString());
            //}
        }

        private void tbxTimTags_TextChanged(object sender, EventArgs e)
        {
            string tx = tbxTimTags.Text;            
            dataGridViewTagsGoiY.Rows.Clear();
            mListTagsKetQua.Clear();

            foreach (Tags tag in mListTags)
            {
                int vi_tri = tag.Tag.ToUpper().IndexOf(tx.ToUpper());
                if (vi_tri >= 0)
                {                    
                    mListTagsKetQua.Add(tag);                    
                }
            }
            ShowDataGirdViewTagsGoiY(mListTagsKetQua);

            //Lựa chọn sản phẩm đầu tiên trong danh sách
            if (mListTagsKetQua.Count > 0)
            {
                dataGridViewTagsGoiY.Rows[0].Selected = true;
                TagLuaChon = mListTagsKetQua[0];
                lbTags.Text = TagLuaChon.Tag;
            }
            else
            {
                TagLuaChon = new Tags();
                lbTags.Text = "...";
            }    
        }

        private void dataGridViewTagsGoiY_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            try
            {
                dataGridViewTagsGoiY.CurrentRow.Selected = true;
                int ID = Convert.ToInt32(dataGridViewTagsGoiY.Rows[e.RowIndex].Cells["IDTags"].FormattedValue.ToString());
                TagLuaChon = mListTagsKetQua.First(x => x.ID == ID);
                lbTags.Text = TagLuaChon.Tag;
            }
            catch
            { }
        }

        Tags TagLuaChon = new Tags();//Tag được lựa chọn trên bảng tìm kiếm

        

        private void ShowDataGirdViewTagsGoiY(List<Tags> ListInput)
        {
            dataGridViewTagsGoiY.Rows.Clear();
            foreach (Tags tag in ListInput)
            {
                int n = dataGridViewTagsGoiY.Rows.Add();
                dataGridViewTagsGoiY.Rows[n].Cells[0].Value = tag.ID.ToString();
                dataGridViewTagsGoiY.Rows[n].Cells[1].Value = tag.Tag.ToString();                
            }
        }

        private void tbxGiaBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                
            }
        }

        private void tbxGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)  && e.KeyChar != '.')
                e.Handled = true;
        }

        private void tbxGiaSoSanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                
            }
        }

        private void tbxGiaSoSanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)  && e.KeyChar != '.')
                e.Handled = true;
        }

        private void tbxCanNang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                
            }
        }

        private void tbxCanNang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }


        int STTLinhKien;
        int STTAnhDaiDien;
        private void btnTiep_Click(object sender, EventArgs e)
        {
            try

            {
                for (int i = 0; i < mList.Count; i++)
                {
                    if (mList[i].Tag == "")
                    {
                        lbIDSanPham.Text = mList[i].ID;
                        lbIDTuyChon.Text = mList[i].IDTuyChon;
                        tbxTenSanPham.Text = mList[i].TenSanPham;
                        lbSKU.Text = mList[i].SKU;
                        tbxGiaBan.Text = mList[i].Gia;
                        tbxGiaSoSanh.Text = mList[i].GiaSoSanh;
                        tbxCanNang.Text = mList[i].CanNang;
                        STTLinhKien = i;
                        STTAnhDaiDien = 1;
                        if (mList[i].mListAnh.Count > 0)
                        {
                            var request = WebRequest.Create(mList[i].mListAnh[0]);
                            using (var response = request.GetResponse())
                            using (var stream = response.GetResponseStream())
                            {
                                pictureBox1.Image = Bitmap.FromStream(stream);
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                        else
                        {
                            Bitmap image = new Bitmap("chua co anh.jpg");
                            {
                                pictureBox1.Image = image;
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                        lbSTTAnhDaiDien.Text = STTAnhDaiDien.ToString();
                        lbSoLuongAnh.Text = mList[i].mListAnh.Count.ToString();
                        break;
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(STTAnhDaiDien > 1)
            {
                STTAnhDaiDien = STTAnhDaiDien - 1;
                var request = WebRequest.Create(mList[STTLinhKien].mListAnh[STTAnhDaiDien-1]);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                lbSTTAnhDaiDien.Text = STTAnhDaiDien.ToString();
            }
        } // nút back ảnh

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (STTAnhDaiDien < mList[STTLinhKien].mListAnh.Count)
            {
                STTAnhDaiDien = STTAnhDaiDien + 1;
                var request = WebRequest.Create(mList[STTLinhKien].mListAnh[STTAnhDaiDien-1]);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                lbSTTAnhDaiDien.Text = STTAnhDaiDien.ToString();
            }
        }// nút next ảnh

        public List<LinhKien> mListKetQua = new List<LinhKien>();

        private void btnOK_Click(object sender, EventArgs e)
        {
            mList[STTLinhKien].TenSanPham = tbxTenSanPham.Text;
            mList[STTLinhKien].Gia = tbxGiaBan.Text;
            mList[STTLinhKien].GiaSoSanh = tbxGiaSoSanh.Text;
            mList[STTLinhKien].CanNang = tbxCanNang.Text;
            mList[STTLinhKien].Tag = TagLuaChon.Tag;
            mList[STTLinhKien].ChuThich = "Đã sửa";

            if(mListKetQua.FirstOrDefault(x=>x.ID == mList[STTLinhKien].ID) == null)
            {
                mListKetQua.Add(mList[STTLinhKien]);
                MessageBox.Show("Đã thêm sản phẩm: " + mList[STTLinhKien].TenSanPham);
            }
            else
            {
                mListKetQua[mListKetQua.FindIndex(x => x.ID == mList[STTLinhKien].ID)] = mList[STTLinhKien];
                MessageBox.Show("Đã sửa sản phẩm: " + mList[STTLinhKien].TenSanPham);
            } 
            ShowDataGirdViewKetQua();            
        }

        private void ShowDataGirdViewKetQua()
        {
            dataGridViewXuat.Rows.Clear();
            foreach (LinhKien sp in mListKetQua)
            {
                int n = dataGridViewXuat.Rows.Add();
                dataGridViewXuat.Rows[n].Cells[0].Value = sp.ID;
                dataGridViewXuat.Rows[n].Cells[1].Value = sp.IDTuyChon;
                dataGridViewXuat.Rows[n].Cells[2].Value = sp.TenSanPham;
                dataGridViewXuat.Rows[n].Cells[3].Value = sp.SKU;
                dataGridViewXuat.Rows[n].Cells[4].Value = sp.Gia;
                dataGridViewXuat.Rows[n].Cells[5].Value = sp.GiaSoSanh;
                dataGridViewXuat.Rows[n].Cells[6].Value = sp.CanNang;
                dataGridViewXuat.Rows[n].Cells[7].Value = sp.ID;
                dataGridViewXuat.Rows[n].Cells[8].Value = sp.IDTuyChon;
                dataGridViewXuat.Rows[n].Cells[9].Value = sp.Tag;
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < mList_Goc.Count; x++)
            {
                if (mList_Goc[x].IDTuyChon != "")
                {
                    LinhKien linhkien = mList.FirstOrDefault(v => v.ID == mList_Goc[x].ID);
                    mList_Goc[x].TenSanPham = linhkien.TenSanPham;
                    mList_Goc[x].Gia = linhkien.Gia;
                    mList_Goc[x].GiaSoSanh = linhkien.GiaSoSanh;
                    mList_Goc[x].Tag = linhkien.Tag;
                    mList_Goc[x].ChuThich = linhkien.ChuThich;
                }
            }
            
            dataGridViewXuat.Rows.Clear();
            foreach (LinhKien sp in mList_Goc)
            {
                int n = dataGridViewXuat.Rows.Add();
                dataGridViewXuat.Rows[n].Cells[0].Value = sp.Alias;
                dataGridViewXuat.Rows[n].Cells[1].Value = sp.TenSanPham;
                dataGridViewXuat.Rows[n].Cells[2].Value = sp.SKU;
                dataGridViewXuat.Rows[n].Cells[3].Value = sp.Gia;
                dataGridViewXuat.Rows[n].Cells[4].Value = sp.GiaSoSanh;
                dataGridViewXuat.Rows[n].Cells[5].Value = sp.AnhDaiDien;
                dataGridViewXuat.Rows[n].Cells[6].Value = sp.CanNang;
                dataGridViewXuat.Rows[n].Cells[7].Value = sp.ID;
                dataGridViewXuat.Rows[n].Cells[8].Value = sp.IDTuyChon;
                dataGridViewXuat.Rows[n].Cells[9].Value = sp.Tag;
            }
            btnExcel.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Trang_tính1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            worksheet.Name = "Uyên";

            for (int i = 1; i < dataGridViewXuat.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewXuat.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewXuat.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewXuat.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridViewXuat.Rows[i].Cells[j].Value.ToString();
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Ket Qua Danh Muc San Pham";
            saveFileDialog.DefaultExt = ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void btnXepAnh_Click(object sender, EventArgs e)
        {
            mListXepAnh = new List<LinhKien>();
            mListKetQua = new List<LinhKien>();
            
            for (int x = 0; x < mList_Goc.Count; x++)
            {
                if(mList_Goc[x].SKU != "")
                {
                    LinhKien _linhkien = new LinhKien();                        
                    if (mListXepAnh.FirstOrDefault(v => v.ID == mList_Goc[x].ID) == null)
                    {
                        _linhkien = mList_Goc[x];
                    }
                    else
                    {
                        int stt = mListXepAnh.FindIndex(v => v.ID == mList_Goc[x].ID);
                        _linhkien = mList_Goc[x];
                        _linhkien.AnhDaiDien = mListXepAnh[stt].AnhDaiDien;
                        _linhkien.NoiDung = mListXepAnh[stt].NoiDung;
                    }
                    mListXepAnh.Add(_linhkien);
                }
            }
            
            foreach (string line in tbxInputSKU.Lines)
            {
                string text = line.Trim();
                if(text == "")
                {
                    LinhKien _linhkien = new LinhKien();
                    _linhkien.AnhDaiDien = "chưa có ảnh";
                    _linhkien.SKU = "Lỗi SKU";
                    mListKetQua.Add(_linhkien);
                }
                else
                {
                    LinhKien _linhkien = new LinhKien();
                    int stt = mListXepAnh.FindIndex(v => v.SKU == text);
                    if (stt < 0)
                    {
                        _linhkien.SKU = "Lỗi SKU";
                    }
                    else
                    {
                        _linhkien = mListXepAnh[stt];
                    }
                    mListKetQua.Add(_linhkien);


                    //LinhKien _linhkien = new LinhKien();
                    //int stt = mList_Goc.FindIndex(v => v.TenSanPham == text);
                    //if (stt < 0)
                    //{
                    //    _linhkien.SKU = "Lỗi SKU";
                    //}
                    //else
                    //{
                    //    _linhkien = mListXepAnh[stt];
                    //}
                    //mListKetQua.Add(_linhkien);
                }                
            }

            dataGridViewKetQua.Rows.Clear();
            foreach (LinhKien sp in mListKetQua)
            {
                int n = dataGridViewKetQua.Rows.Add();
                dataGridViewKetQua.Rows[n].Cells[0].Value = sp.ID;
                try
                {
                    if(sp.Tag == null)
                    {

                    }
                    else
                    {
                        NganhHang nganh = mListNganh.FirstOrDefault(v => sp.Tag.Contains(v.TuKhoa));
                        if (nganh == null)
                        {
                            sp.MaNganhSenDo = "chưa có";

                        }
                        else
                            sp.MaNganhSenDo = nganh.MaNganh;
                    }                    
                }
                catch (Exception ex)
                {
                    
                }

                dataGridViewKetQua.Rows[n].Cells[1].Value = sp.MaNganhSenDo;
                dataGridViewKetQua.Rows[n].Cells[2].Value = sp.TenPhienBan;
                dataGridViewKetQua.Rows[n].Cells[3].Value = sp.SKU;
                string tatcaanh = "";
                foreach (string anh in sp.mListAnh)
                {
                    if (tatcaanh.Length == 0)
                    {
                        tatcaanh = anh;
                    }
                    else
                    {
                        tatcaanh = tatcaanh + ";" + anh;
                    }
                }
                dataGridViewKetQua.Rows[n].Cells[4].Value = tatcaanh;
                dataGridViewKetQua.Rows[n].Cells[5].Value = sp.NoiDung;
                dataGridViewKetQua.Rows[n].Cells[6].Value = sp.Gia;
                dataGridViewKetQua.Rows[n].Cells[7].Value = sp.CanNang;
                dataGridViewKetQua.Rows[n].Cells[8].Value = sp.AnhDaiDien;
                dataGridViewKetQua.Rows[n].Cells[11].Value = sp.TenSanPham;
                dataGridViewKetQua.Rows[n].Cells[12].Value = sp.GiaTriThuocTinh;


            }
        }

        private void btnThongSoCongDung_Click(object sender, EventArgs e)
        {
            foreach (LinhKien sp in mListKetQua)
            {
                HtmlToText _HtmlToText = new HtmlToText();
                if(!(sp.NoiDung == null))
                {
                    string noidung = _HtmlToText.HTMLToText(sp.NoiDung);
                    var listNoiDung = noidung.Split(new[] { "\n\n" }, StringSplitOptions.None).ToList();
                    if (listNoiDung.Count > 5)
                    {
                        sp.ThongSo = listNoiDung[2].Trim('\n').Replace("\n", "\n\n");  
                        sp.CongDung = listNoiDung[4].Trim('\n').Replace("\n", "\n\n");
                        sp.MoTaNgan = tbxBaiVietTren.Text + sp.ThongSo + tbxBaiVietGiua.Text + sp.CongDung + tbxBaiVietDuoi.Text;
                    }
                }                
            }

            dataGridViewKetQua.Rows.Clear();
            foreach (LinhKien sp in mListKetQua)
            {
                int n = dataGridViewKetQua.Rows.Add();                
                dataGridViewKetQua.Rows[n].Cells[1].Value = sp.MaNganhSenDo;
                dataGridViewKetQua.Rows[n].Cells[2].Value = sp.TenPhienBan;
                dataGridViewKetQua.Rows[n].Cells[3].Value = sp.SKU;
                string tatcaanh = "";
                foreach (string anh in sp.mListAnh)
                {
                    if (tatcaanh.Length == 0)
                    {
                        tatcaanh = anh;
                    }
                    else
                    {
                        tatcaanh = tatcaanh + ";" + anh;
                    }
                }
                dataGridViewKetQua.Rows[n].Cells[4].Value = tatcaanh;
                dataGridViewKetQua.Rows[n].Cells[5].Value = sp.MoTaNgan;
                dataGridViewKetQua.Rows[n].Cells[6].Value = sp.Gia;
                dataGridViewKetQua.Rows[n].Cells[7].Value = sp.CanNang;
                dataGridViewKetQua.Rows[n].Cells[8].Value = sp.AnhDaiDien;
                dataGridViewKetQua.Rows[n].Cells[9].Value = sp.ThongSo;
                dataGridViewKetQua.Rows[n].Cells[10].Value = sp.CongDung;
            }
        }

        private void btnXulinoidung_Click(object sender, EventArgs e)
        {
            mListXepAnh = new List<LinhKien>();
            mListKetQua = new List<LinhKien>();
            //for (int x = 0; x < mList_Goc.Count; x++)
            //{
            //    LinhKien _linhkien = new LinhKien();

            //    if (mListXepAnh.FirstOrDefault(v => v.ID == mList_Goc[x].ID) == null)
            //    {
            //        _linhkien = mList_Goc[x];
            //        _linhkien.mListLinhKien.Add(mList_Goc[x]);
            //        mListXepAnh.Add(_linhkien);
            //    }
            //    else
            //    {
            //        int stt = mListXepAnh.FindIndex(v => v.ID == mList_Goc[x].ID);                    
            //        mListXepAnh[stt].mListLinhKien.Add(mList_Goc[x]);
            //    }
            //}

            foreach (string line in tbxInputSKU.Lines)
            {
                string text = line.Trim();
                if (text == "")
                {
                    LinhKien _linhkien = new LinhKien();
                    _linhkien.AnhDaiDien = "chưa có ảnh";
                    _linhkien.SKU = "Lỗi SKU";
                    mListKetQua.Add(_linhkien);
                }
                else
                {
                    LinhKien _linhkien = new LinhKien();
                    int stt = mList.FindIndex(v => v.SKU == text);
                    if (stt < 0)
                    {
                        _linhkien.SKU = "Lỗi SKU không tồn tại";
                        mListKetQua.Add(_linhkien);
                    }
                    else
                    {
                        _linhkien = mList[stt];
                        if(_linhkien.mListPhanLoai.Count > 1)
                        {
                            foreach(LinhKien lk in _linhkien.mListPhanLoai)
                            {
                                mListKetQua.Add(lk);
                            }
                        }
                        else
                        {
                            mListKetQua.Add(_linhkien);
                        }
                    }
                }
            }

            dataGridViewAnhWeb.Rows.Clear();
            foreach (LinhKien sp in mListKetQua)
            {
                int n = dataGridViewAnhWeb.Rows.Add();
                dataGridViewAnhWeb.Rows[n].Cells[0].Value = sp.Alias;
                dataGridViewAnhWeb.Rows[n].Cells[1].Value = sp.TenSanPham;
                dataGridViewAnhWeb.Rows[n].Cells[2].Value = sp.NoiDung;
                dataGridViewAnhWeb.Rows[n].Cells[3].Value = sp.NhaCungCap;
                dataGridViewAnhWeb.Rows[n].Cells[4].Value = sp.Loai;
                dataGridViewAnhWeb.Rows[n].Cells[5].Value = sp.Tag;
                dataGridViewAnhWeb.Rows[n].Cells[6].Value = sp.HienThi;
                dataGridViewAnhWeb.Rows[n].Cells[7].Value = sp.ThuocTinh;
                dataGridViewAnhWeb.Rows[n].Cells[8].Value = sp.GiaTriThuocTinh;
                dataGridViewAnhWeb.Rows[n].Cells[9].Value = sp.ThuocTinh2;
                dataGridViewAnhWeb.Rows[n].Cells[10].Value = sp.GiaTriThuocTinh2;
                dataGridViewAnhWeb.Rows[n].Cells[11].Value = sp.ThuocTinh3;
                dataGridViewAnhWeb.Rows[n].Cells[12].Value = sp.GiaTriThuocTinh3;
                dataGridViewAnhWeb.Rows[n].Cells[13].Value = sp.SKU;
                dataGridViewAnhWeb.Rows[n].Cells[14].Value = sp.QuanLyKho;
                dataGridViewAnhWeb.Rows[n].Cells[15].Value = sp.SoLuong;
                dataGridViewAnhWeb.Rows[n].Cells[16].Value = sp.ChoPhepBan;
                dataGridViewAnhWeb.Rows[n].Cells[17].Value = sp.Variant;
                dataGridViewAnhWeb.Rows[n].Cells[18].Value = sp.Gia;
                dataGridViewAnhWeb.Rows[n].Cells[19].Value = sp.GiaSoSanh;
                dataGridViewAnhWeb.Rows[n].Cells[20].Value = sp.YeuCauVanChuyen;
                dataGridViewAnhWeb.Rows[n].Cells[21].Value = sp.VAT;
                dataGridViewAnhWeb.Rows[n].Cells[22].Value = sp.MaVach;
                dataGridViewAnhWeb.Rows[n].Cells[23].Value = sp.AnhDaiDien;
                dataGridViewAnhWeb.Rows[n].Cells[24].Value = sp.ChuThich;
                dataGridViewAnhWeb.Rows[n].Cells[25].Value = sp.TheTieuDe;
                dataGridViewAnhWeb.Rows[n].Cells[26].Value = sp.TheMoTa;
                dataGridViewAnhWeb.Rows[n].Cells[27].Value = sp.CanNang;
                dataGridViewAnhWeb.Rows[n].Cells[28].Value = sp.DonViCan;
                dataGridViewAnhWeb.Rows[n].Cells[29].Value = sp.AnhPhienBan;
                dataGridViewAnhWeb.Rows[n].Cells[30].Value = sp.MoTaNgan;
                dataGridViewAnhWeb.Rows[n].Cells[31].Value = sp.ID;
                dataGridViewAnhWeb.Rows[n].Cells[32].Value = sp.IDTuyChon;
            }
        }        

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Trang_tính1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            worksheet.Name = "Uyên";

            for (int i = 1; i < dataGridViewAnhWeb.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewAnhWeb.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewAnhWeb.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewAnhWeb.Columns.Count; j++)
                {
                    if(dataGridViewAnhWeb.Rows[i].Cells[j].Value == null)
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridViewAnhWeb.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Ket Qua Danh Muc San Pham";
            saveFileDialog.DefaultExt = ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void btnXuat2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Trang_tính1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            worksheet.Name = "Uyên";

            for (int i = 1; i < dataGridViewKetQua.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewKetQua.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewKetQua.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewKetQua.Columns.Count; j++)
                {
                    if(dataGridViewKetQua.Rows[i].Cells[j].Value == null)
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                    else
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

        private void Nganhhang()
        {
            DataTableCollection tableMaNganhCollection;
            List<string> listSheet = new List<string>();
            mListNganh.Clear();

            using (var steam = File.Open(@"Ma nganh.xlsx", FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                    });
                    tableMaNganhCollection = result.Tables;
                    foreach (System.Data.DataTable table in result.Tables)
                        listSheet.Add(table.TableName);
                }
            }

            try
            {
                System.Data.DataTable dt = tableMaNganhCollection[listSheet[0]];
                dataGridViewNganhHang.DataSource = dt;
                mListNganh = (from DataRow dr in dt.Rows
                             select new NganhHang()
                             {
                                 TuKhoa = dr["Từ khóa"].ToString(),
                                 MaNganh = dr["Mã ngành"].ToString()                             
                             }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxSKU_TextChanged(object sender, EventArgs e)
        {
            string SKU = tbxSKU.Text;
            WebClient webClient = new WebClient();
            int i=1;
            try
            {
                LinhKien lk = mList_Goc.FirstOrDefault(v => v.SKU == SKU);
                if(lk != null)
                {
                    LinhKien _linhkien = mList.FirstOrDefault(v => v.ID == lk.ID);
                    if(_linhkien != null)
                    {
                        //using (var fbd = new FolderBrowserDialog())
                        //{
                        //    DialogResult result = fbd.ShowDialog();
                        //    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        //    {
                        //        foreach (string linkanh in _linhkien.mListAnh)
                        //        {
                        //            string localFile = fbd.SelectedPath + @"\" + _linhkien.SKU + "_" + i + ".jpg";
                        //            string remoteFile = linkanh;
                        //            webClient.DownloadFile(remoteFile, localFile);
                        //            i++;
                        //        }
                        //    }
                        //}

                        string Path = @"ANHWEB";
                        foreach (string linkanh in _linhkien.mListAnh)
                        {
                            string localFile = Path + @"\" + _linhkien.SKU + "_" + i + ".jpg";
                            string remoteFile = linkanh;
                            webClient.DownloadFile(remoteFile, localFile);
                            i++;
                        }
                        MessageBox.Show("Đã tải " + _linhkien.mListAnh.Count + " ảnh sản phẩm: " + _linhkien.TenSanPham + ".");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLayAnhShopee_Click(object sender, EventArgs e)
        {
            List<LinhKien> mList_KetQua = new List<LinhKien>();

            foreach (string line in tbxInputSKU.Lines)
            {
                string text = line.Trim();
                if (text == "")
                {
                    LinhKien _linhkien = new LinhKien();
                    _linhkien.AnhDaiDien = "chưa có ảnh";
                    _linhkien.SKU = "Lỗi cách dòng";
                    mListKetQua.Add(_linhkien);
                }
                else
                {
                    LinhKien _linhkien = new LinhKien();
                    LinhKien lk = mList_Goc.FirstOrDefault(v => v.SKU == text);

                    if (lk != null)
                    {
                        _linhkien = mList.FirstOrDefault(v => v.ID == lk.ID);
                        if (_linhkien != null)
                        {
                            //_linhkien.SKU = text;
                            mList_KetQua.Add(_linhkien);                            
                        }
                    }
                    else
                    {
                        _linhkien.Alias = text;
                        _linhkien.AnhDaiDien = "chưa có ảnh";
                        _linhkien.SKU = "Lỗi SKU";
                        mList_KetQua.Add(_linhkien);
                    }
                }
            }

            dataGridViewAnhShopee.Rows.Clear();
            foreach (LinhKien sp in mList_KetQua)
            {
                int n = dataGridViewAnhShopee.Rows.Add();
                dataGridViewAnhShopee.Rows[n].Cells[0].Value = sp.Alias;
                dataGridViewAnhShopee.Rows[n].Cells[1].Value = sp.TenSanPham;
                dataGridViewAnhShopee.Rows[n].Cells[2].Value = sp.SKU;

                int i = 0;
                foreach (string anh in sp.mListAnh)
                {
                    dataGridViewAnhShopee.Rows[n].Cells[i + 3].Value = sp.mListAnh[i];
                    i++;
                    if (i > 7)
                    {
                        break;
                    }
                }
            }
        }

        private void btnDangLazada_Click(object sender, EventArgs e)
        {
            mListKetQua = new List<LinhKien>();
            string ID = "";

            foreach (string line in tbxInputSKU.Lines)
            {
                string text = line.Trim();
                if (text == "")
                {
                    LinhKien _linhkien = new LinhKien();
                    _linhkien.AnhDaiDien = "chưa có ảnh";
                    _linhkien.SKU = "Lỗi SKU";
                    mListKetQua.Add(_linhkien);
                }
                else
                {
                    LinhKien _linhkien = new LinhKien();
                    int stt = mList_Goc.FindIndex(v => v.SKU == text);
                    if (stt < 0)
                    {
                        _linhkien.SKU = "Lỗi SKU không tồn tại";
                        mListKetQua.Add(_linhkien);
                    }
                    else
                    {
                        ID = mList_Goc[stt].ID;

                        if (mListKetQua.FirstOrDefault(v => v.ID == ID) == null)  //kiểm tra xem đã có phân loại đó hay chưa
                        {
                            _linhkien = mList.FirstOrDefault(v => v.ID == ID);
                            if (_linhkien.mListAnh.Count == 0)
                            {
                                _linhkien.SKU = "Sản phẩm chưa có ảnh";
                                mListKetQua.Add(_linhkien);
                            }
                            else
                            {
                                foreach (LinhKien phanloai in _linhkien.mListPhanLoai)
                                {
                                    HtmlToText _HtmlToText = new HtmlToText();

                                    if (!(phanloai.NoiDung == null))
                                    {
                                        string noidung = _HtmlToText.HTMLToText(phanloai.NoiDung);
                                        var listNoiDung = noidung.Split(new[] { "\n\n" }, StringSplitOptions.None).ToList();
                                        if (listNoiDung.Count > 5)
                                        {
                                            phanloai.ThongSo = listNoiDung[2].Trim('\n').Replace("\n", "\n\n");
                                            phanloai.CongDung = listNoiDung[4].Trim('\n').Replace("\n", "\n\n");
                                            phanloai.MoTaNgan = NoiDungSanPhamLazada(phanloai.ThongSo, phanloai.CongDung, phanloai);
                                        }
                                    }
                                    mListKetQua.Add(phanloai);
                                }
                            }
                        }
                    }
                }
            }

            ShowdataGridViewDangSPLazada(mListKetQua);
        }

        string NoiDungSanPhamLazada (string thongso, string congdung, LinhKien mLinhKien)
        {
            StringBuilder DB = new StringBuilder();
            DB.Append("<p style=\"margin:0;padding:8.0px 0;white-space:pre-wrap\"><span style=\"font-family:none\"></span></p><h1 style=\"margin:0;padding:8.0px 0;white-space:pre-wrap;text-align:center;display:inline-block;width:100.0% \"><div style=\"font-weight:bold;margin:0;padding:8.0px 0;white-space:pre-wrap\"><strong style=\"font-weight:bold\">");
            DB.Append(mLinhKien.TenSanPham);
            DB.Append("</strong></div></h1><h2><strong style=\"font-weight:bold\"></strong><strong style=\"font-weight:bold\">Thông Số Kỹ Thuật:</strong></h2><p style=\"margin:0;padding:8.0px 0;white-space:pre-wrap\"><span>");

            thongso = thongso.Replace("\n\n", "</span></p><p style=\"margin:0;padding:8.0px 0;white-space:pre-wrap\"><span>");
            DB.Append(thongso);

            DB.Append("</span></p><div style=\"width:100.0%;margin:0;padding:8.0px 0;white-space:pre-wrap\"><div style=\"width:100.0%;display:block;margin:0;padding:8.0px 0;white-space:pre-wrap\"><div style=\"width:100.0%;display:block;margin:0;padding:8.0px 0;white-space:pre-wrap\"><div style=\"width:100.0%;display:block;margin:0;padding:8.0px 0;white-space:pre-wrap\"><div style=\"width:100.0%;display:block;margin:0;padding:8.0px 0;white-space:pre-wrap\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%; display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block\"><img class=\"\" src=\"");
            DB.Append(mLinhKien.mListAnh[0]);

            DB.Append("\" style=\"width:100.0%;display:block\"/></div></div></div></div></div></div></div></div></div></div></div></div></div></div></div><p style=\"margin:0;padding:8.0px 0;white-space:pre-wrap\"><span></span></p><h2><strong style=\"font-weight:bold\">Công Dụng:</strong></h2><p style=\"margin:0;padding:8.0px 0;white-space:pre- wrap\"><span>");

            congdung = congdung.Replace("\n\n", "</span></p><p style=\"margin:0;padding:8.0px 0;white-space:pre-wrap\"><span>");
            DB.Append(congdung);
             
            DB.Append("</span></p><p style=\"margin:0;padding:8.0px 0;white-space:pre-wrap\"><span></span></p><div style=\"width:100.0%;margin:0;padding:8.0px 0;white-space:pre-wrap\"><div style=\"width:100.0%;display:block;margin:0;padding:8.0px 0;white-space:pre-wrap\"><div style=\"width:100.0%;display:block;margin:0;padding:8.0px 0;white-space:pre-wrap\"><div style=\"width:100.0 %;display:block;margin:0;padding:8.0px 0;white-space:pre-wrap\"><div style=\"width:100.0%;display:block;margin:0;padding:8.0px 0;white-space:pre-wrap\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block;margin:0\"><div style=\"width:100.0%;display:block\"><img class=\"\" src=\"");

            for(int i = 1; i < mLinhKien.mListAnh.Count; i++)
            {
                DB.Append(mLinhKien.mListAnh[i]);
                if(i == mLinhKien.mListAnh.Count - 1)
                { 
                    break;
                }
                DB.Append("\" style=\"width:100%;display:block\"/></div></div></div></div></div></div></div><div style=\"width:100%;margin:0\"><div style=\"width:100%;display:block;margin:0\"><div style=\"width:100%;display:block;margin:0\"><div style=\"width:100%;display:block;margin:0\"><div style=\"width:100%;display:block;margin:0\"><div style=\"width:100%;display:block;margin:0\"><div style=\"width:100%;display:block\"><img class=\"\" src=\"");
            }
            DB.Append("\"style=\"width:100%;display:block\"/></div></div></div></div></div></div><div style=\"width:100.0%;margin:0;padding:8.0px 0;white-space:pre-wrap\"><span></span></div>");
            
            return DB.ToString();
        }

        void ShowdataGridViewDangSPLazada(List<LinhKien> mListKetQua)
        {
            dataGridViewDangSPLazada.Rows.Clear();
            foreach (LinhKien sp in mListKetQua)
            {
                int n = dataGridViewDangSPLazada.Rows.Add();
                dataGridViewDangSPLazada.Rows[n].Cells[0].Value = sp.ID;
                dataGridViewDangSPLazada.Rows[n].Cells[2].Value = "ngành hàng";
                dataGridViewDangSPLazada.Rows[n].Cells[3].Value = sp.TenSanPham;
                int i = 0;
                foreach (string anh in sp.mListAnh)
                {
                    dataGridViewDangSPLazada.Rows[n].Cells[i + 4].Value = sp.mListAnh[i];
                    i++;
                    if (i > 7)
                    {
                        break;
                    }
                }
                dataGridViewDangSPLazada.Rows[n].Cells[12].Value = "No Brand";
                dataGridViewDangSPLazada.Rows[n].Cells[13].Value = sp.MoTaNgan;
                dataGridViewDangSPLazada.Rows[n].Cells[14].Value = "Không";
                dataGridViewDangSPLazada.Rows[n].Cells[15].Value = sp.ThuocTinh;
                dataGridViewDangSPLazada.Rows[n].Cells[16].Value = sp.GiaTriThuocTinh;
                dataGridViewDangSPLazada.Rows[n].Cells[17].Value = sp.AnhPhienBan;
                dataGridViewDangSPLazada.Rows[n].Cells[20].Value = sp.Gia;
                dataGridViewDangSPLazada.Rows[n].Cells[21].Value = sp.SKU;
                dataGridViewDangSPLazada.Rows[n].Cells[22].Value = sp.SoLuong;
                if(sp.CanNang != null)
                {
                    try
                    {
                        dataGridViewDangSPLazada.Rows[n].Cells[23].Value = (Int32.Parse(sp.CanNang) / 1000).ToString();
                    }
                    catch
                    {
                        dataGridViewDangSPLazada.Rows[n].Cells[23].Value = sp.CanNang;
                    }
                }                    
                dataGridViewDangSPLazada.Rows[n].Cells[24].Value = "rộng";
                dataGridViewDangSPLazada.Rows[n].Cells[25].Value = "dài";
                dataGridViewDangSPLazada.Rows[n].Cells[26].Value = "cao";
            }
        }

        private void btnXuatFileLazada_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Trang_tính1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            worksheet.Name = "Uyên";

            for (int i = 1; i < dataGridViewDangSPLazada.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewDangSPLazada.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewDangSPLazada.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewDangSPLazada.Columns.Count; j++)
                {
                    if (dataGridViewDangSPLazada.Rows[i].Cells[j].Value == null)
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                    else
                        worksheet.Cells[i + 2, j + 1] = dataGridViewDangSPLazada.Rows[i].Cells[j].Value.ToString();
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Ket Qua File Up Lazada";
            saveFileDialog.DefaultExt = ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void btnTaobaivietLazada_Click(object sender, EventArgs e)
        {
            mListKetQua = new List<LinhKien>();

            foreach (string line in tbxInputSKU.Lines)
            {
                string text = line.Trim();
                if (text == "")
                {
                    LinhKien _linhkien = new LinhKien();
                    _linhkien.AnhDaiDien = "chưa có ảnh";
                    _linhkien.SKU = "Lỗi SKU";
                    mListKetQua.Add(_linhkien);
                }
                else
                {
                    LinhKien _linhkien = new LinhKien();
                    int stt = mList_Goc.FindIndex(v => v.SKU == text);
                    if ( stt < 0)
                    {
                        _linhkien.SKU = "Lỗi SKU không tồn tại";
                        mListKetQua.Add(_linhkien);
                    }
                    else
                    {
                        _linhkien = mList.FirstOrDefault(v => v.ID == mList_Goc[stt].ID);
                        HtmlToText _HtmlToText = new HtmlToText();
                        if (_linhkien.mListAnh.Count == 0)
                        {
                            _linhkien.SKU = "Sản phẩm chưa có ảnh";
                            mListKetQua.Add(_linhkien);
                        }
                        else
                        {
                            if (!(_linhkien.NoiDung == null))
                            {
                                string noidung = _HtmlToText.HTMLToText(_linhkien.NoiDung);
                                var listNoiDung = noidung.Split(new[] { "\n\n" }, StringSplitOptions.None).ToList();
                                if (listNoiDung.Count > 5)
                                {
                                    _linhkien.ThongSo = listNoiDung[2].Trim('\n').Replace("\n", "\n\n");
                                    _linhkien.CongDung = listNoiDung[4].Trim('\n').Replace("\n", "\n\n");
                                    _linhkien.MoTaNgan = NoiDungSanPhamLazada(_linhkien.ThongSo, _linhkien.CongDung, _linhkien);
                                }
                            }
                            mListKetQua.Add(_linhkien);
                        }                        
                    }
                }
            }
            ShowdataGridViewDangSPLazada(mListKetQua);
        }

        SanPhamSendo sanphamDangChay = new SanPhamSendo();
        public List<SanPhamSendo> mListInput = new List<SanPhamSendo>();
        int stt = 0;
        private void btnRunSendo_Click(object sender, EventArgs e)
        {
            dataGridViewSendo.Rows.Clear();
            Khoi_Tao_Chrome();
            
            foreach (SanPhamSendo sp in mListInput)
            {
                sanphamDangChay = sp;
                stt = mListInput.FindIndex(n => n.ID == sp.ID);
                try
                {
                    Chay_Chuong_Trinh(sp);
                }
                catch
                {
                    mListInput[stt].TinhTrang = "lỗi";
                }
            }
            Show_Ket_Qua();
        }

        ChromeDriver driver;
        private void Khoi_Tao_Chrome()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000"); //an chorme

            driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl("https://ban.sendo.vn/");
            driver.FindElement(By.Id("field-username")).SendKeys(tbxTaiKhoanSendo.Text);
            driver.FindElement(By.Id("field-password")).SendKeys(tbxMatKhauSendo.Text);
            driver.FindElement(By.Name("password")).SendKeys(OpenQA.Selenium.Keys.Return);//Đăng nhập tài khoản
            System.Threading.Thread.Sleep(10000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());            
        }

        private void Chay_Chuong_Trinh(SanPhamSendo _sanpham)
        {
            if (checkBoxBaiViet.Checked == true)
            {
                driver.Navigate().GoToUrl(@"file:///D:/FileNoiDung.html.htm");
                Thread.Sleep(3000);
                Actions action1 = new Actions(driver);
                action1.KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("a").KeyUp(OpenQA.Selenium.Keys.Control).Perform();
                action1.KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("c").KeyUp(OpenQA.Selenium.Keys.Control).Perform(); Thread.Sleep(1000);
            }

            driver.Navigate().GoToUrl("https://ban.sendo.vn/san-pham/" + _sanpham.ID);
            Thread.Sleep(5000);

            if (checkBoxBaiViet.Checked == true)
            {
                driver.FindElements(By.ClassName("iconWrap_JcTv"))[0].Click();
                Actions action2 = new Actions(driver);
                action2.KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("a").KeyUp(OpenQA.Selenium.Keys.Control).Perform();
                action2.KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("v").KeyUp(OpenQA.Selenium.Keys.Control).Perform(); Thread.Sleep(1000);
                driver.FindElements(By.ClassName("iconWrap_JcTv"))[0].Click();
            }
            //Chỉnh sửa Tên sản phẩm
            if (checkBoxTenSanPham.Checked == true)
            {
                driver.FindElement(By.Id("field-name")).Clear();
                driver.FindElement(By.Id("field-name")).SendKeys(_sanpham.TenSanPham);
                Thread.Sleep(3000);
            }
            //Chỉnh sửa SKU sản phẩm
            if (checkBoxSKU.Checked == true)
            {
                driver.FindElement(By.Id("field-store_sku")).Clear();
                driver.FindElement(By.Id("field-store_sku")).SendKeys(_sanpham.SKU);
                Thread.Sleep(3000);
            }

            //Chỉnh sửa Ảnh đại diện sản phẩm
            if (checkBoxSKU.Checked == true)
            {
                driver.FindElements(By.ClassName("editIcon_2i-f"))[0].Click();
                Thread.Sleep(1000);
                var upfileAnh = driver.FindElements(By.ClassName("d7e-cd3660"));
                upfileAnh[1].Click();
                Thread.Sleep(3000);
                System.Windows.Forms.SendKeys.SendWait(_sanpham.TenSanPham);
                System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(8000);
            }

            var element = driver.FindElements(By.ClassName("d7e-aa34b6"));
            element[element.Count() - 1].Click();
            Thread.Sleep(1000);
            try
            {
                var undefined = driver.FindElement(By.ClassName("msg_1QvY"));
                if (undefined != null)
                {
                    mListInput[stt].TinhTrang = undefined.Text;
                    switch (mListInput[stt].TinhTrang)
                    {
                        case "Mô tả sản phẩm, tối thiểu 100 ký tự":
                            break;

                        case "Mã sản phẩm đã tồn tại":
                            break;

                        case "Gửi duyệt thành công":
                            break;

                        default:
                            break;
                    }
                }
            }
            catch
            {
                mListInput[stt].TinhTrang = "Thành công!";
            }

            Thread.Sleep(6000);
        }

        private void Show_Ket_Qua()
        {
            foreach (SanPhamSendo sp in mListInput)
            {
                int n = dataGridViewSendo.Rows.Add();
                dataGridViewSendo.Rows[n].Cells[0].Value = sp.ID;
                dataGridViewSendo.Rows[n].Cells[1].Value = sp.TenSanPham;
                dataGridViewSendo.Rows[n].Cells[2].Value = sp.SKU;
                dataGridViewSendo.Rows[n].Cells[3].Value = sp.TinhTrang;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
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
                            SanPhamSendo sp = new SanPhamSendo();
                            sp.ID = fields[0];
                            sp.TenSanPham = fields[1];
                            sp.SKU = fields[2];
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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataGridViewInput.Rows.Clear();
            mListInput = new List<SanPhamSendo>();
        }


    }
}