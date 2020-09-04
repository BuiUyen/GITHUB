using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dang_Don_Len_GHTK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //XuLiDonHang("1412");
            btnSuaSanPham.Hide();
        }

        public class DonHang
        {
            public string SanPham = "Linh Kiện Điện Tử";
            public string IDSapo { get; set; }
            public string MaDonHang { get; set; }
            public string NgayThang { get; set; }
            public string TrangThaiDonHang { get; set; }
            public string GiaTien { get; set; }
            public string PhiVanChuyen { get; set; }
            public string TongTien { get; set; }
            public int SoTien { get; set; }

            public string DonViVanChuyen { get; set; }
            public string KhoiLuong { get; set; }

            public string CanNangThucTe { get; set; }

            public string TenKhachHang { get; set; }
            public string SDT { get; set; }
            public string DiaChi { get; set; }
            public string Gmail { get; set; }


        }

        public List<DonHang> mListDonHang = new List<DonHang>();
        public List<DonHang> mListKetQua = new List<DonHang>();

        public string fileName = @"D:\code.txt";
        public string MaDonChon;
        public int sttSuaSanPham;

        private void btnRun_Click(object sender, EventArgs e)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var driver = new ChromeDriver(driverService, new ChromeOptions());
            driver.Navigate().GoToUrl("https://linh-kien-tu-hu.mysapo.net/admin");
            driver.FindElementById("Email").SendKeys("quangsshn.vne@gmail.com");
            driver.FindElementById("Password").SendKeys("Mualinhkien.1108");
            System.Threading.Thread.Sleep(1000);
            IWebElement element = driver.FindElement(By.Name("Password"));
            element.SendKeys(OpenQA.Selenium.Keys.Return);//Đăng nhập tài khoản
            System.Threading.Thread.Sleep(2000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());            

            string link = @"https://linh-kien-tu-hu.mysapo.net/admin/orders";
            driver.Navigate().GoToUrl(link);
            System.Threading.Thread.Sleep(1000);
            TaoFileCode(driver.PageSource);
            List<string> ListIDSapo = ReadSource();

            link = @"https://linh-kien-tu-hu.mysapo.net/admin/orders?Page=2";
            driver.Navigate().GoToUrl(link);
            System.Threading.Thread.Sleep(1000);
            TaoFileCode(driver.PageSource);
            foreach(string str in ReadSource())
            {
                ListIDSapo.Add(str);
            }

            link = @"https://linh-kien-tu-hu.mysapo.net/admin/orders?Page=3";
            driver.Navigate().GoToUrl(link);
            System.Threading.Thread.Sleep(1000);
            TaoFileCode(driver.PageSource);
            foreach (string str in ReadSource())
            {
                ListIDSapo.Add(str);
            }

            mListDonHang.Clear();
            int test = 0;
            foreach(string id in ListIDSapo)
            {
                test++;
                string linkdh = @"https://linh-kien-tu-hu.mysapo.net/admin/orders/" + id;
                driver.Navigate().GoToUrl(linkdh);
                System.Threading.Thread.Sleep(500);
                TaoFileCode(driver.PageSource);
                mListDonHang.Add(XuLiDonHang(id));               
            }
            ShowDonHang();
            btnRun.Hide();
        }

        public List<string> ReadSource()
        {
            List<string> List_String = new List<string>();
            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("parent-quick-view-"))
                        {
                            string code = s.Trim().Substring(26,7);
                            List_String.Add(code);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            return List_String;
        }

        //Xử lí trang đơn hàng
        public DonHang XuLiDonHang(string IDSapo)
        {
            DonHang mDonHang = new DonHang();
            mDonHang.IDSapo = IDSapo;
            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    int dvvc = 0;
                    int pvc = 0;
                    int thongtinkhachhang = 0;
                    List<string> ttkh = new List<string>();

                    while ((s = sr.ReadLine()) != null)
                    {
                        s = s.Trim();                        
                        if (s.Contains("ui-title-bar__title"))
                        {
                            string code = s.Substring(33, 4);
                            mDonHang.MaDonHang = code;
                        }

                        if (s.Contains("ui-title-bar__metadata"))
                        {
                            string code = s.Substring(37, 16);
                            mDonHang.NgayThang = code;
                        }

                        //trạng thái đơn hàng
                        if (s.Contains("badge__pip"))
                        {
                            string[] list = s.Split('<');
                            string code = list[3].Substring(6,list[3].Length-6);
                            mDonHang.TrangThaiDonHang = code;
                        }

                        //tiền đơn hàng
                        if (s.Contains("₫</td>"))
                        {
                            string code = s.Substring(4, s.Length - 4);
                            code = code.Substring(0, code.Length - 5);
                            mDonHang.GiaTien = code;
                        }

                        //đơn vị vận chuyển
                        if (dvvc == 1)
                        {
                            string code = s.Substring(5, s.Length - 5);
                            code = code.Substring(0, code.Length - 6);
                            mDonHang.DonViVanChuyen = code;
                            dvvc = 0;
                        }

                        if (s.Contains("<div>Vận chuyển</div>"))
                        {
                            dvvc = 1;
                        }

                        //cân nặng
                        if (s.Contains("kg</div>"))
                        {
                            string code = s.Substring(5, s.Length - 5);
                            code = code.Substring(0, code.Length - 6);
                            mDonHang.KhoiLuong = code;
                            pvc = 1;
                        }

                        //phí vận chuyển
                        if(pvc == 1 && s.Contains("₫"))
                        {
                            mDonHang.PhiVanChuyen = s;
                            pvc = 0;
                        }

                        //tổng tiền thanh toán
                        if (s.Contains("₫</strong></td>"))
                        {
                            string code = s.Substring(12, s.Length - 12);
                            code = code.Substring(0, code.Length - 14);
                            mDonHang.TongTien = code;

                            mDonHang.SoTien = Int32.Parse(Regex.Replace(code, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled));
                        }
                        //Thông tin người nhận
                        if (thongtinkhachhang == 1)
                        {
                            ttkh.Add(s.Substring(0, s.Length - 4).Trim());
                            if(ttkh.Count == 6)
                            {
                                mDonHang.TenKhachHang = ttkh[0];
                                mDonHang.SDT = ttkh[1];
                                mDonHang.DiaChi = ttkh[2] + ", " + ttkh[3] + ", " + ttkh[4] + ", " + ttkh[5];
                                thongtinkhachhang = 0;
                            }
                        }
                        if (s.Contains("type--subdued word_break__content"))
                        {
                            thongtinkhachhang = 1;
                        }

                        mDonHang.CanNangThucTe = "0.2";
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            return mDonHang;
        }

        public void TaoFileCode(string input)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (StreamWriter fs = File.CreateText(fileName))
            {
                fs.WriteLine(input);                
            }
        }

        private void txbMaDonInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbMaDonInput_TextChanged(object sender, EventArgs e)
        {
            if(mListDonHang.FirstOrDefault(x => x.MaDonHang == txbMaDonInput.Text) == null)
            {
                ClearThongTinDonHang();
            }
            else
            {
                DonHang _donhang = mListDonHang.FirstOrDefault(x => x.MaDonHang == txbMaDonInput.Text);
                MaDonChon = _donhang.MaDonHang;

                DienThongTinDonHang(_donhang);
            }
        }

        private void ClearThongTinDonHang()
        {
            tbxTenKhachHang.Clear();
            tbxSDT.Clear();
            tbxDiaChi.Clear();
            tbxKhoiLuong.Clear();
            tbxGiaTien.Clear();
            tbxPhiVanChuyen.Clear();
            tbxTongTien.Clear();
            lbDonViVanChuyen.Text = "";
            tbxSoTien.Clear();
            tbxKhoiLuongThucTe.Clear();
        }

        private void DienThongTinDonHang(DonHang _donhang)
        {
            tbxTenKhachHang.Text = _donhang.TenKhachHang;
            tbxSDT.Text = _donhang.SDT;
            tbxDiaChi.Text = _donhang.DiaChi;
            tbxKhoiLuong.Text = _donhang.KhoiLuong;
            tbxGiaTien.Text = _donhang.GiaTien;
            tbxPhiVanChuyen.Text = _donhang.PhiVanChuyen;
            tbxTongTien.Text = _donhang.TongTien;
            lbDonViVanChuyen.Text = _donhang.DonViVanChuyen;
            tbxSoTien.Text = _donhang.SoTien.ToString();
            tbxKhoiLuongThucTe.Text = _donhang.CanNangThucTe;
        }

        public void ShowDonHang()
        {
            dataGridViewTatCa.Rows.Clear();
            foreach (DonHang dh in mListDonHang)
            {
                int n = dataGridViewTatCa.Rows.Add();
                dataGridViewTatCa.Rows[n].Cells[0].Value = dh.MaDonHang.ToString();
                dataGridViewTatCa.Rows[n].Cells[1].Value = dh.SDT.ToString();
                dataGridViewTatCa.Rows[n].Cells[2].Value = dh.TenKhachHang.ToString();
                dataGridViewTatCa.Rows[n].Cells[3].Value = dh.DiaChi.ToString();
                dataGridViewTatCa.Rows[n].Cells[4].Value = dh.SanPham.ToString();
                dataGridViewTatCa.Rows[n].Cells[5].Value = dh.TongTien.ToString();
            }
        }

        private void tbxSDTInput_TextChanged(object sender, EventArgs e)
        {
            if (mListDonHang.FirstOrDefault(x => x.SDT.Contains(tbxSDTInput.Text)) == null)
            {
                ClearThongTinDonHang();
            }
            else
            {
                DonHang _donhang = mListDonHang.FirstOrDefault(x => x.SDT.Contains(tbxSDTInput.Text));
                MaDonChon = _donhang.MaDonHang;
                DienThongTinDonHang(_donhang);
            }
        }

        private void tbxSDTInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbxSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (tbxTenKhachHang.Text == "")
            {

            }
            else
            {

                DonHang _donhang = mListDonHang.FirstOrDefault(x => x.MaDonHang == MaDonChon);
                if (mListKetQua.FirstOrDefault(x => x.MaDonHang == MaDonChon) == null)
                {
                    _donhang.SoTien = Int32.Parse(tbxSoTien.Text);
                    _donhang.CanNangThucTe = tbxKhoiLuongThucTe.Text;
                    mListKetQua.Add(_donhang);
                    ClearThongTinDonHang();
                }
                else
                {
                    MessageBox.Show("Đã tồn tại đơn này!");
                }
                ShowDataGirdViewKetQua();
            }
        }

        private void ShowDataGirdViewKetQua()
        {
            dataGridViewKetQua.Rows.Clear();
            foreach (DonHang dh in mListKetQua)
            {
                int n = dataGridViewKetQua.Rows.Add();
                dataGridViewKetQua.Rows[n].Cells[0].Value = dh.MaDonHang.ToString();
                dataGridViewKetQua.Rows[n].Cells[1].Value = dh.SDT.ToString();
                dataGridViewKetQua.Rows[n].Cells[2].Value = dh.TenKhachHang.ToString();
                dataGridViewKetQua.Rows[n].Cells[3].Value = dh.DiaChi.ToString();
                dataGridViewKetQua.Rows[n].Cells[4].Value = dh.SanPham.ToString();
                dataGridViewKetQua.Rows[n].Cells[5].Value = "1";
                dataGridViewKetQua.Rows[n].Cells[6].Value = dh.CanNangThucTe.ToString();
                dataGridViewKetQua.Rows[n].Cells[7].Value = dh.SoTien.ToString();
            }
        }

        private int rowIndex = 0;

        //chỉnh sửa bảng kết quả sản phẩm
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = (dataGridViewKetQua.Rows[rowIndex].Cells["MaDonHangKQ"].FormattedValue.ToString());
            mListKetQua.RemoveAll(r => r.MaDonHang == id);
            ShowDataGirdViewKetQua();
        }
        
        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = (dataGridViewKetQua.Rows[rowIndex].Cells["MaDonHangKQ"].FormattedValue.ToString());
            sttSuaSanPham = mListKetQua.FindIndex(r => r.MaDonHang == id);
            DienThongTinDonHang(mListKetQua[sttSuaSanPham]);
            btnSuaSanPham.Show();            
        }
        private void dataGridViewKetQua_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewKetQua.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dataGridViewKetQua.CurrentCell = this.dataGridViewKetQua.Rows[e.RowIndex].Cells[1];
                contextMenuStrip1.Show(this.dataGridViewKetQua, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }        
        
        //điều chỉnh bảng ban đầu
        private void dataGridViewTatCa_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    dataGridViewTatCa.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                    dataGridViewTatCa.CurrentCell = this.dataGridViewTatCa.Rows[e.RowIndex].Cells[1];
                    contextMenuStrip2.Show(this.dataGridViewTatCa, e.Location);
                    contextMenuStrip2.Show(Cursor.Position);
                }
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        private void thêmĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = (dataGridViewTatCa.Rows[rowIndex].Cells["MaDonHang"].FormattedValue.ToString());
            if (mListKetQua.FirstOrDefault(x => x.MaDonHang == id) == null)
            {
                DonHang _donhang = mListDonHang.FirstOrDefault(r => r.MaDonHang == id);
                _donhang.CanNangThucTe = "0.2";
                mListKetQua.Add(_donhang);
            }
            else
            {
                MessageBox.Show("Đã tồn tại đơn này!");
            }
            
            ShowDataGirdViewKetQua();
        }

        private void btnSuaSanPham_Click(object sender, EventArgs e)
        {
            mListKetQua[sttSuaSanPham].SoTien = Int32.Parse(tbxSoTien.Text);
            mListKetQua[sttSuaSanPham].CanNangThucTe = tbxKhoiLuongThucTe.Text;
            ShowDataGirdViewKetQua();
            ClearThongTinDonHang();
            btnSuaSanPham.Hide();
        }
    }
}
