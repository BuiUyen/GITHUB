using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using ExcelDataReader.Exceptions;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using _Excel = Microsoft.Office.Interop.Excel;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public class LinhKien
        {
            public int ID { get; set; }
            public string TenLinhKien { get; set; }
            public int GiaTien { get; set; }
            public int SoLuong { get; set; }
            public int ThanhTien { get; set; }

        }

        DataTableCollection tableCollection;
        public List<LinhKien> List = new List<LinhKien>();
        LinhKien _linhkien = new LinhKien();
        public List<LinhKien> ListKetQua = new List<LinhKien>();
        public List<LinhKien> ListEnd = new List<LinhKien>();        


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _linhkien.ID = 0;
        }

        private void LoadData()
        {
            try
            {
                System.Data.DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
                dataGridViewData.DataSource = dt;
                List = (from DataRow dr in dt.Rows
                        select new LinhKien()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            TenLinhKien = dr["Ten Linh Kien"].ToString(),
                            GiaTien = Convert.ToInt32(dr["Gia Tien"])
                        }).ToList();
            }
            catch
            {
                MessageBox.Show("Lỗi Sheet Data", "Thông Báo");
            }
        }

        private void btnOpenLink_Click(object sender, EventArgs e)
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

        private void tbxTimkiem_TextChanged(object sender, EventArgs e)
        {
            string tx = tbxTimkiem.Text;
            List<LinhKien> ketqua = new List<LinhKien>();
            List<int> IDKetqua = new List<int>();

            dataGridViewKetQua.Rows.Clear();
            foreach (LinhKien lk in List)
            {
                int vi_tri = Chuyenchuhoa(lk.TenLinhKien).IndexOf(Chuyenchuhoa(tx));
                if (vi_tri >= 0)
                {
                    IDKetqua.Add(vi_tri);
                    ketqua.Add(lk);
                    int n = dataGridViewKetQua.Rows.Add();
                    dataGridViewKetQua.Rows[n].Cells[0].Value = lk.ID.ToString();
                    dataGridViewKetQua.Rows[n].Cells[1].Value = lk.TenLinhKien.ToString();
                    dataGridViewKetQua.Rows[n].Cells[2].Value = lk.GiaTien.ToString();
                }
            }
        }

        private string Chuyenchuhoa(string input)
        {
            int l = input.Length;
            char[] arr = input.ToCharArray(0, l);
            char[] arrout = input.ToCharArray(0, l);
            for (int i = 0; i < l; i++)
            {
                arrout[i] = Char.ToUpper(arr[i]);
            }
            string output = new string(arrout);
            return output;
        }

        private void dataGridViewKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewKetQua.CurrentRow.Selected = true;
                _linhkien = new LinhKien();
                _linhkien.ID = Convert.ToInt32(dataGridViewKetQua.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                _linhkien.TenLinhKien = dataGridViewKetQua.Rows[e.RowIndex].Cells["Ten"].FormattedValue.ToString();
                _linhkien.GiaTien = Convert.ToInt32(dataGridViewKetQua.Rows[e.RowIndex].Cells["Gia"].FormattedValue.ToString());
            }
            catch
            { }
            lbSanPham.Text = _linhkien.TenLinhKien;
            lbGia.Text = _linhkien.GiaTien.ToString() + "đ";
        }

        private void tbxSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int SoLuong = Convert.ToInt32(tbxSoLuong.Text);
                if (SoLuong != 0)
                {
                    if (ListEnd.FirstOrDefault(x => x.ID == _linhkien.ID) == null)
                    {
                        if(_linhkien.ID==0)
                        {
                            MessageBox.Show("Chưa chọn linh kiện!!!", "Thông Báo");
                        }
                        else
                        {
                            _linhkien.SoLuong = SoLuong;
                            ListEnd.Add(_linhkien);
                        }
                    }
                    else
                    {
                        foreach (LinhKien x in ListEnd)
                            if (x.ID == _linhkien.ID)
                            {
                                x.SoLuong = x.SoLuong + SoLuong;
                            }
                    }
                    ShowDataGirdViewEnd();
                }
                else
                {
                    MessageBox.Show("Trời ạ, số lượng 0 thì thêm làm gì?", "Thông Báo");
                }
            }
            catch
            {
                MessageBox.Show("Chưa điền số lượng!", "Thông Báo");
            }
        }

        private void tbxSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void ShowDataGirdViewEnd()
        {
            dataGridViewEnd.Rows.Clear();
            foreach (LinhKien lk in ListEnd)
            {
                lk.ThanhTien = lk.SoLuong * lk.GiaTien;
                int n = dataGridViewEnd.Rows.Add();
                dataGridViewEnd.Rows[n].Cells[0].Value = lk.ID.ToString();
                dataGridViewEnd.Rows[n].Cells[1].Value = lk.TenLinhKien.ToString();
                dataGridViewEnd.Rows[n].Cells[2].Value = lk.GiaTien.ToString();
                dataGridViewEnd.Rows[n].Cells[3].Value = lk.SoLuong.ToString();
                dataGridViewEnd.Rows[n].Cells[4].Value = lk.ThanhTien.ToString();
            }
        }


        private int rowIndex = 0;

        private void điềuChỉnhSốLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewEnd.Rows[rowIndex].Cells["ID2"].FormattedValue.ToString());
            foreach (LinhKien x in ListEnd)
                if (x.ID == id)
                {
                    using (Form2 form = new Form2(x.SoLuong))
                    {
                        var result = form.ShowDialog();
                        int val = form.SoLuongPublic;
                        x.SoLuong = val;

                    }
                }
            ShowDataGirdViewEnd();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewEnd.Rows[rowIndex].Cells["ID2"].FormattedValue.ToString());

            ListEnd.RemoveAll(r => r.ID == id);

            ShowDataGirdViewEnd();
        }


        private void dataGridViewEnd_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewEnd.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dataGridViewEnd.CurrentCell = this.dataGridViewEnd.Rows[e.RowIndex].Cells[1];
                contextMenuStrip1.Show(this.dataGridViewEnd, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
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
            
            for( int i = 1; i< dataGridViewEnd.Columns.Count +1; i++)
            {
                worksheet.Cells[1,i] = dataGridViewEnd.Columns[i - 1].HeaderText;
            }

            for( int i=0; i< dataGridViewEnd.Rows.Count-1; i++)
            {
                for(int j=0; j< dataGridViewEnd.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridViewEnd.Rows[i].Cells[j].Value.ToString();
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Bảng giá linh kiện";
            saveFileDialog.DefaultExt = ".xlsx";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }
    }    
}
