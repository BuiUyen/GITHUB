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

namespace Phan_mem_ban_hang_linh_kien
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public class DonHang
        {
            public int IDDonHang { get; set; }
            public string NgayThangNam { get; set; }
            public string MaKhachHang { get; set; }
            public string TenKhachHang { get; set; }
            public string SDT { get; set; }

            public List<SanPham> ListSanPham = new List<SanPham>();

        }
        public class KhachHang
        {
            public int IDKhachHang { get; set; }
            public string TenKhachHang { get; set; }
            public string SDT { get; set; }
            public int TongThanhToan { get; set; }
        }

        public class SanPham
        {
            public int ID { get; set; }
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
            public int GiaNhap { get; set; }
            public int GiaBan { get; set; }
            public string DonViTinh { get; set; }
            public int TamTinh { get; set; }
            public string ViTri { get; set; }
        }
        
        private void btnQuanLiTaiKhoan_Click(object sender, EventArgs e)
        {
            using (FormMatKhauQuanLiTaiKhoan form = new FormMatKhauQuanLiTaiKhoan())
            {
                var result = form.ShowDialog();
            }            
        }

        List<SanPham> ListInput = new List<SanPham>();

        List<SanPham> ListKetQuaTimKiem = new List<SanPham>();

        List<SanPham> ListSanPhamHoaDon = new List<SanPham>();

        DataTableCollection tableCollection;

        private void FormMain_Load(object sender, EventArgs e)
        {
            using (var steam = File.Open(@"file\Data.xlsx", FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    tableCollection = result.Tables;
                }
            }

            try
            {
                foreach (System.Data.DataTable table in tableCollection)
                {
                    System.Data.DataTable dt = tableCollection[table.TableName];
                    List<SanPham> List = new List<SanPham>();
                    ListInput = (from DataRow dr in dt.Rows
                            select new SanPham()
                            {
                                ID = Convert.ToInt32(dr["ID"].ToString()),
                                TenSanPham = dr["Tên sản phẩm"].ToString(),
                                SoLuong = Convert.ToInt32(dr["Số lượng"].ToString()),
                                GiaNhap = Convert.ToInt32(dr["Giá nhập"]),
                                GiaBan = Convert.ToInt32(dr["Giá bán"].ToString()),
                                DonViTinh = dr["Đơn vị tính"].ToString(),
                                ViTri = dr["Vị trí"].ToString()
                            }).ToList();                    
                }
            }
            catch
            {
                MessageBox.Show("Lỗi Sheet Data", "Thông Báo");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tx = tbxTimKiem.Text;
            List<int> IDKetqua = new List<int>();
            dataGridViewTimKiem.Rows.Clear();
            ListKetQuaTimKiem.Clear();
            foreach (SanPham sp in ListInput)
            {
                int vi_tri = sp.TenSanPham.ToUpper().IndexOf(tx.ToUpper());
                if (vi_tri >= 0)
                {
                    IDKetqua.Add(vi_tri);
                    ListKetQuaTimKiem.Add(sp);
                    int n = dataGridViewTimKiem.Rows.Add();
                    dataGridViewTimKiem.Rows[n].Cells[0].Value = sp.ID.ToString();
                    dataGridViewTimKiem.Rows[n].Cells[1].Value = sp.TenSanPham.ToString();
                    dataGridViewTimKiem.Rows[n].Cells[2].Value = sp.SoLuong.ToString();
                    dataGridViewTimKiem.Rows[n].Cells[3].Value = sp.GiaNhap.ToString();
                    dataGridViewTimKiem.Rows[n].Cells[4].Value = sp.GiaBan.ToString();
                    dataGridViewTimKiem.Rows[n].Cells[5].Value = sp.DonViTinh.ToString();
                }
            }

            //Lựa chọn sản phẩm đầu tiên trong danh sách
            if (ListKetQuaTimKiem.Count > 0)
            {
                dataGridViewTimKiem.Rows[0].Selected = true;
                ShowSanPham(ListKetQuaTimKiem[0]);
            }
            else
            {
                ShowSanPham(new SanPham());
            }
        }

        private void tbxTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnTimKiem_Click(sender, e);
        }

        SanPham sanpham = new SanPham();//Sản phẩm được lựa chọn trên bảng tìm kiếm

        private void dataGridViewTimKiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewTimKiem.CurrentRow.Selected = true;
                int ID = Convert.ToInt32(dataGridViewTimKiem.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                sanpham = ListKetQuaTimKiem.First(x => x.ID == ID);
                ShowSanPham(sanpham);
            }
            catch
            { }
        }

        private void ShowSanPham(SanPham _sanpham)
        {
            lbTenSanPham.Text = _sanpham.TenSanPham;
            sanpham = _sanpham;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(sanpham.ID != 0)
            {
                try
                {
                    int soluong = Convert.ToInt32(tbxSoLuong.Text);
                    if(soluong>0)
                    {
                        int stt = ListSanPhamHoaDon.FindIndex(x => x.ID == sanpham.ID);
                        if (stt == -1)
                        {
                            sanpham.SoLuong = soluong;
                            ListSanPhamHoaDon.Add(sanpham);
                        }
                        else
                        {
                            ListSanPhamHoaDon[stt].SoLuong += soluong;
                        }
                        ShowSanPhamHoaDon();
                    }    
                    else
                    {
                        MessageBox.Show("Chưa nhập số lượng hoặc số lượng không hợp lệ!!!");
                    }                    
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Chưa chọn sản phẩm!");
            }
        }

        private void ShowSanPhamHoaDon()
        {
            int TongTien = 0;
            dataGridViewHoaDon.Rows.Clear();
            foreach (SanPham sp in ListSanPhamHoaDon)
            {
                int n = dataGridViewHoaDon.Rows.Add();
                dataGridViewHoaDon.Rows[n].Cells[0].Value = sp.ID.ToString();
                dataGridViewHoaDon.Rows[n].Cells[1].Value = sp.TenSanPham.ToString();
                dataGridViewHoaDon.Rows[n].Cells[2].Value = sp.SoLuong.ToString();
                dataGridViewHoaDon.Rows[n].Cells[3].Value = sp.GiaBan.ToString();
                sp.TamTinh = sp.SoLuong * sp.GiaBan;
                TongTien += sp.TamTinh;
                dataGridViewHoaDon.Rows[n].Cells[4].Value = sp.TamTinh.ToString();                
            }
            lbTongTien.Text = TongTien.ToString("#,##0") + "đ.";
        }

        private void tbxSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnThem_Click(sender, e);
            }
        }

        private void tbxSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private int rowIndex = 0;

        private void dataGridViewHoaDon_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewHoaDon.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dataGridViewHoaDon.CurrentCell = this.dataGridViewHoaDon.Rows[e.RowIndex].Cells[1];
                contextMenuStrip1.Show(this.dataGridViewHoaDon, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewHoaDon.Rows[rowIndex].Cells["IDKetQua"].FormattedValue.ToString());
            int stt = ListSanPhamHoaDon.FindIndex(x => x.ID == id);
            using (FormSua form = new FormSua(ListSanPhamHoaDon[stt].SoLuong, ListSanPhamHoaDon[stt].GiaBan))
            {
                var result = form.ShowDialog();
                ListSanPhamHoaDon[stt].SoLuong = form.SoLuongPublic;
                ListSanPhamHoaDon[stt].GiaBan = form.GiaPublic;
            }
            ShowSanPhamHoaDon();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewHoaDon.Rows[rowIndex].Cells["IDKetQua"].FormattedValue.ToString());
            ListSanPhamHoaDon.RemoveAll(r => r.ID == id);
            ShowSanPhamHoaDon();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(ListSanPhamHoaDon);
            frm.ShowDialog();
        }
    }
}
