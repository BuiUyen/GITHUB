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
    public partial class FormQuanLiTaiKhoan : Form
    {
        public class TaiKhoan
        {
            public int ID { get; set; }            
            public string TenNguoiDung{ get; set; }
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
            public string MaQuyen { get; set; }
            public string CapQuyen { get; set; }
        }

        public List<TaiKhoan> mListTaiKhoan = new List<TaiKhoan>();

        public FormQuanLiTaiKhoan()
        {
            InitializeComponent();
        }

        public string fileName = @"file\DanhSachTaiKhoan.txt";

        private void FormQuanLiTaiKhoan_Load(object sender, EventArgs e)
        {
            btnSua.Hide();

            CbxCapQuyen.Items.Add("Admin");
            CbxCapQuyen.Items.Add("Bán hàng");

            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        List<string> mlist = s.Split('$').ToList();
                        if (mlist.Count > 1)
                        {
                            TaiKhoan taikhoan = new TaiKhoan();
                            taikhoan.TenDangNhap = mlist[0];
                            taikhoan.TenDangNhap = mlist[1];
                            taikhoan.MatKhau = mlist[2];
                            taikhoan.MaQuyen = mlist[3];
                            taikhoan.CapQuyen = mlist[4];
                            mListTaiKhoan.Add(taikhoan);
                        }
                    }
                }
                ShowTaiKhoan();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public void ShowTaiKhoan()
        {
            dataGridViewTaiKhoan.Rows.Clear();
            foreach (TaiKhoan taikhoan in mListTaiKhoan)
            {
                int n = dataGridViewTaiKhoan.Rows.Add();
                dataGridViewTaiKhoan.Rows[n].Cells[0].Value = (n+1).ToString();
                dataGridViewTaiKhoan.Rows[n].Cells[1].Value = taikhoan.TenNguoiDung.ToString();
                dataGridViewTaiKhoan.Rows[n].Cells[2].Value = taikhoan.TenDangNhap.ToString();
                dataGridViewTaiKhoan.Rows[n].Cells[3].Value = taikhoan.MatKhau.ToString();
                dataGridViewTaiKhoan.Rows[n].Cells[4].Value = taikhoan.MaQuyen.ToString();
                dataGridViewTaiKhoan.Rows[n].Cells[5].Value = taikhoan.CapQuyen.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string code = "";
            foreach (TaiKhoan taikhoan in mListTaiKhoan)
            {
                code += taikhoan.TenNguoiDung.ToString() + "$" + taikhoan.TenDangNhap.ToString() + "$" + taikhoan.MatKhau.ToString() + "$" + taikhoan.MaQuyen.ToString() + "$" + taikhoan.CapQuyen.ToString() + "\n" ;
            }            
            
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (StreamWriter fs = File.CreateText(fileName))
            {
                fs.WriteLine(code);
                MessageBox.Show("Đã lưu danh sách tài khoản!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            if (tbxTenNguoiDung.Text == "" || tbxTenDangNhap.Text == "" || tbxMatKhau.Text == "" || CbxCapQuyen.Text == "")
            {
                MessageBox.Show("Chưa đủ thông tin tài khoản!!!");
            }
            else
            {                
                if(mListTaiKhoan.FirstOrDefault(x=>x.TenDangNhap == tbxTenDangNhap.Text) == null)
                {
                    taikhoan.TenNguoiDung = tbxTenNguoiDung.Text;
                    taikhoan.TenDangNhap = tbxTenDangNhap.Text;
                    taikhoan.MatKhau = tbxMatKhau.Text;
                    taikhoan.CapQuyen = CbxCapQuyen.Text;
                    switch (taikhoan.CapQuyen)
                    {
                        case "Admin":
                            taikhoan.MaQuyen = "admin";
                            break;
                        case "Bán hàng":
                            taikhoan.MaQuyen = "banhang";
                            break;
                        default:
                            break;
                    }
                    mListTaiKhoan.Add(taikhoan);
                    ShowTaiKhoan();
                    ClearThongTin();
                    MessageBox.Show("Đã thêm tài khoản cho: " + taikhoan.TenNguoiDung);
                }
                else
                {
                    MessageBox.Show("Đã tồn tại tên đăng nhập: " + tbxTenDangNhap.Text);
                }                
            }
        }

        public void ClearThongTin()
        {
            tbxTenNguoiDung.Clear();
            tbxTenDangNhap.Clear();
            tbxMatKhau.Clear();
            CbxCapQuyen.Text = "";
        }

        public int stt;

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSua.Show();
            stt = Convert.ToInt32(dataGridViewTaiKhoan.Rows[rowIndex].Cells["STT"].FormattedValue.ToString());
            //stt = mListTaiKhoan.FindIndex(x => x.ID == id);
            tbxTenNguoiDung.Text = mListTaiKhoan[stt].TenNguoiDung;
            tbxTenDangNhap.Text = mListTaiKhoan[stt].TenDangNhap;
            tbxMatKhau.Text = mListTaiKhoan[stt].MatKhau;
            CbxCapQuyen.Text = mListTaiKhoan[stt].CapQuyen;            
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stt = Convert.ToInt32(dataGridViewTaiKhoan.Rows[rowIndex].Cells["STT"].FormattedValue.ToString());
            mListTaiKhoan.Remove(mListTaiKhoan[stt]);
            ShowTaiKhoan();
        }

        private int rowIndex = 0;

        private void dataGridViewTaiKhoan_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewTaiKhoan.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dataGridViewTaiKhoan.CurrentCell = this.dataGridViewTaiKhoan.Rows[e.RowIndex].Cells[1];
                contextMenuStrip1.Show(this.dataGridViewTaiKhoan, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            mListTaiKhoan[stt].TenNguoiDung = tbxTenNguoiDung.Text;
            mListTaiKhoan[stt].TenDangNhap = tbxTenDangNhap.Text;
            mListTaiKhoan[stt].MatKhau = tbxMatKhau.Text;
            mListTaiKhoan[stt].CapQuyen = CbxCapQuyen.Text;
            switch (mListTaiKhoan[stt].CapQuyen)
            {
                case "Admin":
                    mListTaiKhoan[stt].MaQuyen = "admin";
                    break;
                case "Bán hàng":
                    mListTaiKhoan[stt].MaQuyen = "banhang";
                    break;
                default:
                    break;
            }
            ClearThongTin();
            ShowTaiKhoan();
            btnSua.Hide();
        }
    }
}
