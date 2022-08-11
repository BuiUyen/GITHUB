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
using Microsoft.Reporting.WebForms;
using System.Runtime.Remoting.Messaging;

namespace Tao_Danh_Sach_San_Pham_Di_Cho
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public class SanPham
        {
            public int ID { get; set; }
            public string TenSanPham { get; set; }
            public string TenDayDu { get; set; }
            public string ThuocTinh { get; set; }
            public int Gia { get; set; }

            public List<int> ListGia = new List<int>();
            public string SanThuongMai { get; set; }

            public List<string> ListSanThuongMai = new List<string>();
            public int GiaNhap { get; set; }
            public int SoLuong { get; set; }
            public int TamTinh { get; set; }
            public string AnhDaiDien { get; set; }
        }

        DataTableCollection tableCollection;

        public List<SanPham> ListGoc = new List<SanPham>();

        public List<SanPham> ListKetQuanTimKiem = new List<SanPham>();

        public List<SanPham> ListOutput = new List<SanPham>();

        private void FormMain_Load(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now;

            using (var steam = File.Open("Data.xlsx", FileMode.Open, FileAccess.Read))
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
                    List = (from DataRow dr in dt.Rows
                            select new SanPham()
                            {
                                TenSanPham = dr["Tên sản phẩm"].ToString(),
                                ThuocTinh = dr["Giá trị thuộc tính"].ToString(),
                                Gia = Convert.ToInt32(dr["Giá"]),
                                AnhDaiDien = dr["Ảnh đại diện"].ToString()
                            }).ToList();

                    foreach (SanPham sp in List)
                    {
                        if (sp.ThuocTinh == "")
                        {
                            sp.TenDayDu = sp.TenSanPham;
                        }
                        else
                        {
                            sp.TenDayDu = sp.TenSanPham + " - " + sp.ThuocTinh;
                        }

                        sp.TenSanPham = sp.TenSanPham.ToUpper();
                        SanPham mSanPham = new SanPham();
                        int stt = ListGoc.FindIndex(x => x.TenSanPham == sp.TenSanPham);

                        if (stt >= 0 && sp.ThuocTinh == "")
                        {
                            ListGoc[stt].ListSanThuongMai.Add(table.TableName);
                            ListGoc[stt].ListGia.Add(sp.Gia);
                            ListGoc[stt].Gia = ListGoc[stt].ListGia.Min();
                        }
                        else
                        {
                            sp.ID = ListGoc.Count + 1;
                            sp.ListSanThuongMai.Add(table.TableName);
                            sp.ListGia.Add(sp.Gia);
                            ListGoc.Add(sp);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi Sheet Data", "Thông Báo");
            }
        }

        private void tbxTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTim_Click(sender, e);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tx = tbxTimkiem.Text;
            List<int> IDKetqua = new List<int>();
            dataGridViewKetQua.Rows.Clear();
            dataGridViewSanThuongMai.Rows.Clear();
            foreach (SanPham sp in ListGoc)
            {
                int vi_tri = sp.TenSanPham.IndexOf(tx.ToUpper());
                if (vi_tri >= 0)
                {
                    IDKetqua.Add(vi_tri);
                    ListKetQuanTimKiem.Add(sp);
                    int n = dataGridViewKetQua.Rows.Add();
                    dataGridViewKetQua.Rows[n].Cells[0].Value = sp.ID.ToString();
                    dataGridViewKetQua.Rows[n].Cells[1].Value = sp.TenDayDu.ToString();
                    dataGridViewKetQua.Rows[n].Cells[2].Value = sp.Gia.ToString();
                }
            }

            //Lựa chọn sản phẩm đầu tiên trong danh sách
            if (ListKetQuanTimKiem.Count > 0)
            {
                dataGridViewKetQua.Rows[0].Selected = true;
                ShowSanPham(ListKetQuanTimKiem[0]);
            }
        }

        SanPham sanpham = new SanPham();//Sản phẩm được lựa chọn trên bảng tìm kiếm

        private void dataGridViewKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewSanThuongMai.Rows.Clear();
            try
            {
                dataGridViewKetQua.CurrentRow.Selected = true;
                int ID = Convert.ToInt32(dataGridViewKetQua.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                sanpham = ListKetQuanTimKiem.First(x => x.ID == ID);
                ShowSanPham(sanpham);
            }
            catch
            { }
        }

        private void ShowSanPham(SanPham sanpham)
        {
            for (int i = 0; i < sanpham.ListGia.Count; i++)
            {
                int n = dataGridViewSanThuongMai.Rows.Add();
                dataGridViewSanThuongMai.Rows[n].Cells[0].Value = sanpham.ListSanThuongMai[i].ToString();
                dataGridViewSanThuongMai.Rows[n].Cells[1].Value = sanpham.ListGia[i].ToString();
            }

            lbTenSanPham.Text = sanpham.TenDayDu;
            lbGia.Text = sanpham.Gia.ToString("#,##0") + "đ";
            tbxGia.Text = sanpham.Gia.ToString();

            if (sanpham.AnhDaiDien != "")
            {
                var request = WebRequest.Create(sanpham.AnhDaiDien);
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
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                int SoLuong = Convert.ToInt32(txbSoLuong.Text);
                int Gia = Convert.ToInt32(tbxGia.Text);
                if (SoLuong != 0)
                {
                    int stt = ListOutput.FindIndex(x => x.ID == sanpham.ID);
                    if (stt < 0)
                    {
                        if (sanpham.ID == 0)
                        {
                            MessageBox.Show("Chưa chọn linh kiện!!!", "Thông Báo");
                        }
                        else
                        {
                            sanpham.SoLuong = SoLuong;
                            sanpham.Gia = Gia;
                            ListOutput.Add(sanpham);
                        }
                    }
                    else
                    {
                        ListOutput[stt].SoLuong += SoLuong;
                    }
                    ShowDataGirdViewOutput();
                }
                else
                {
                    MessageBox.Show("Trời ạ, số lượng 0 thì thêm làm gì?", "Thông Báo");
                }
            }
            catch
            {
                MessageBox.Show("Chưa điền số lượng hoặc giá sản phẩm!", "Thông Báo");
            }
        }

        private void txbSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnThemSanPham_Click(sender, e);
            }
        }

        private void txbSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void ShowDataGirdViewOutput()
        {
            int tongtien = 0;
            dataGridViewOutput.Rows.Clear();
            foreach (SanPham sp in ListOutput)
            {
                sp.TamTinh = sp.Gia * sp.SoLuong;
                int n = dataGridViewOutput.Rows.Add();
                dataGridViewOutput.Rows[n].Cells[0].Value = sp.ID.ToString();
                dataGridViewOutput.Rows[n].Cells[1].Value = sp.TenDayDu.ToString();
                dataGridViewOutput.Rows[n].Cells[2].Value = sp.Gia.ToString("#,##0") + "đ";
                dataGridViewOutput.Rows[n].Cells[3].Value = sp.SoLuong.ToString();
                dataGridViewOutput.Rows[n].Cells[4].Value = sp.TamTinh.ToString("#,##0") + "đ";
                tongtien += sp.TamTinh;
            }
            lbTongTien.Text = tongtien.ToString("#,##0") + "đ";
        }

        private int rowIndex = 0;

        private void dataGridViewOutput_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewOutput.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dataGridViewOutput.CurrentCell = this.dataGridViewOutput.Rows[e.RowIndex].Cells[1];
                contextMenuStrip1.Show(this.dataGridViewOutput, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewOutput.Rows[rowIndex].Cells["IDKetQua"].FormattedValue.ToString());
            int stt = ListOutput.FindIndex(x => x.ID == id);
            using (Form2 form = new Form2())
            {
                var result = form.ShowDialog();                
                ListOutput[stt].SoLuong = form.SoLuongPublic;
                ListOutput[stt].Gia = form.GiaPublic;
            }
            ShowDataGirdViewOutput();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewOutput.Rows[rowIndex].Cells["IDKetQua"].FormattedValue.ToString());
            ListOutput.RemoveAll(r => r.ID == id);
            ShowDataGirdViewOutput();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Yêu cầu mua hàng";

            for (int i = 1; i < dataGridViewOutput.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewOutput.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewOutput.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewOutput.Columns.Count; j++)
                {
                    if(dataGridViewOutput.Rows[i].Cells[j].Value == null)
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }   
                    else
                    worksheet.Cells[i + 2, j + 1] = dataGridViewOutput.Rows[i].Cells[j].Value.ToString();
                }
            }

            var saveFileDialog = new SaveFileDialog();

            //Đặt tên file lưu
            var dt = DateTime.Now;
            saveFileDialog.FileName = "Phiếu ngày " + dt.ToString("dd-MM-yyyy");
            saveFileDialog.DefaultExt = ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string code = "";
            foreach (SanPham sp in ListOutput)
            {
                code += sp.ID.ToString() + "$" + sp.TenDayDu.ToString() + "$" + sp.Gia.ToString() + "$" + sp.SoLuong.ToString() + "\n";
            }
            TaoFileCode(code);
        }

        public void TaoFileCode(string input)
        {
            var dt = DateTime.Now;
            string fileName = @"file\" + dt.ToString("dd-MM-yyyy") + ".txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (StreamWriter fs = File.CreateText(fileName))
            {
                fs.WriteLine(input);
                MessageBox.Show("Đã lưu file ngày: " + dt.ToString("dd-MM-yyyy") + ".txt");
            }
        }

        private void btnTimFileCu_Click(object sender, EventArgs e)
        {
            ListOutput.Clear();
            var dt = dateTimePicker.Value;
            string fileName = @"file\" + dt.ToString("dd-MM-yyyy") + ".txt";
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
                            SanPham sp = new SanPham();
                            sp.ID = int.Parse(mlist[0]);
                            sp.TenDayDu = mlist[1];
                            sp.Gia = int.Parse(mlist[2]);
                            sp.SoLuong = int.Parse(mlist[3]);
                            sp.TamTinh = sp.Gia * sp.SoLuong;
                            ListOutput.Add(sp);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            ShowDataGirdViewOutput();
        }

        private void btnPhieuIn_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(ListOutput);
            frm.ShowDialog();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (tbxSanPhamThem.Text != "" & tbxGiaThem.Text != "" & tbxSoLuongThem.Text != "")
            {
                if (int.Parse(tbxGiaThem.Text) == 0 || int.Parse(tbxSoLuongThem.Text) == 0)
                {
                    MessageBox.Show("Thiếu giá hoặc số lượng");
                }
                else
                {
                    SanPham sanpham = new SanPham();
                    sanpham.ID = ListGoc.Count;
                    sanpham.TenDayDu = tbxSanPhamThem.Text;
                    sanpham.Gia = int.Parse(tbxGiaThem.Text);
                    sanpham.SoLuong = int.Parse(tbxSoLuongThem.Text);
                    sanpham.TamTinh = sanpham.Gia * sanpham.SoLuong;
                    ListGoc.Add(sanpham);
                    ListOutput.Add(sanpham);
                    ShowDataGirdViewOutput();
                }
            }
            else MessageBox.Show("Chưa đủ thông tin!");            
        }

        private void tbxSoLuongThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnThemSanPham_Click(sender, e);
            }
        }

        private void tbxSoLuongThem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbxGiaThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnThemSanPham_Click(sender, e);
            }
        }

        private void tbxGiaThem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
