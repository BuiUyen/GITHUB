using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using ExcelDataReader;
using static Lấy_Dữ_Liệu_KOOL.FormMAIN;

namespace Lấy_Dữ_Liệu_KOOL
{    
    public partial class FormMAIN : Form
    {
        DataTableCollection tableCollection;
        public FormMAIN()
        {
            InitializeComponent();
        }

        public class SanPham
        {
            public string ID { get; set; }
            public string TenSanPham { get; set; }
            public string MaSanPham { get; set; }
            public string DanhMuc { get; set; }
            public string ThuongHieu { get; set; }
            public string TinhTrang { get; set; }
            public string GiaBan { get; set; }
            public string GiaCu { get; set; }
            public string BienThe { get; set; }
            public string MaBienThe { get; set; }
            public List<string> ListMaPhanLoai { get; set; }
            public List<string> ListPhanLoai { get; set; }
            public List<string> ListAnh { get; set; }
            public string MoTaSanPham { get; set; }
        }

        public class LinkSP
        {
            public string ID { get; set; }
            public string BienThe { get; set; }
            public string MaBienThe { get; set; }
        }
        
        public List<SanPham> mListSanPham = new List<SanPham>();

        public List<SanPham> mListPhanLoai = new List<SanPham>();

        public List<LinkSP> mListGoc = new List<LinkSP>();

        string filename = @"code.txt";

        private void buttonRUN_Click(object sender, EventArgs e)
        {
                        
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000"); //an chorme
            var driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl("https://www.google.com/");
            System.Threading.Thread.Sleep(300);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            //foreach (string line in txtCheckerCode.Lines)
            for (int stt = 1; stt <= 300; stt++)
            {
                string line;
                if (stt<100)
                {
                    line = stt.ToString("00");
                }
                else
                {
                    line = stt.ToString("000");
                }
                
                string link = @"https://kinhmatkool.com/--pi" + line;
                try
                {
                    driver.Navigate().GoToUrl(link);
                    System.Threading.Thread.Sleep(1000);

                    //tao file code txt
                    using (StreamWriter fs = File.CreateText(filename))
                    {
                        fs.WriteLine(driver.PageSource);
                    }

                    SanPham _sanpham = new SanPham();
                    _sanpham.ID = line;

                    //Lấy tên sản phẩm
                    _sanpham.TenSanPham = driver.FindElements(By.ClassName("product-title"))[0].Text;

                    //Lấy cụm dữ liệu
                    var list = driver.FindElements(By.ClassName("list-unstyled"))[0].Text.Split('\r');
                    _sanpham.MaSanPham = list[1].Replace("\n", "");
                    _sanpham.DanhMuc = list[3].Replace("\n", "");
                    _sanpham.ThuongHieu = list[5].Replace("\n", "");
                    _sanpham.TinhTrang = list[7].Replace("\n", "");

                    //Lấy giá sản phẩm
                    _sanpham.GiaBan = driver.FindElements(By.ClassName("special-price"))[0].Text;
                    _sanpham.GiaCu = driver.FindElements(By.ClassName("old-price"))[0].Text;

                    ////Lấy tên biến thể
                    //_sanpham.BienThe = driver.FindElements(By.ClassName("active"))[0].Text;

                    //var listbienthe = driver.FindElements(By.ClassName("bk_product-variation--disabled"));
                    //_sanpham.ListMaPhanLoai = new List<string>();
                    //_sanpham.ListPhanLoai = new List<string>();
                    //_sanpham.ListAnh = new List<string>();

                    ////Lấy mã biến thể
                    //foreach (var item in listbienthe)
                    //{
                    //    string bienthe = item.GetAttribute("href").Split('=')[1];
                    //    _sanpham.ListMaPhanLoai.Add(bienthe);
                    //    _sanpham.ListPhanLoai.Add(item.Text);
                    //}

                    _sanpham.MoTaSanPham = driver.FindElements(By.ClassName("active"))[0].Text;




                    _sanpham = MaPhanLoaiSanPham(_sanpham);
                    
                    

                    ////Lấy hình ảnh
                    //var image = driver.FindElements(By.ClassName("elevatezoom-gallery"));
                    //foreach (var item in image)
                    //{
                    //    string ima = item.GetAttribute("href");
                    //    _sanpham.ListAnh.Add(ima);
                    //}    

                    mListSanPham.Add(_sanpham);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    Actions actions = new Actions(driver);
                    actions.SendKeys(OpenQA.Selenium.Keys.Escape);
                }

                dataGridViewData.Rows.Clear();
                foreach (SanPham sanpham in mListSanPham)
                {
                    int n = dataGridViewData.Rows.Add();
                    dataGridViewData.Rows[n].Cells[0].Value = sanpham.ID;
                    dataGridViewData.Rows[n].Cells[1].Value = sanpham.TenSanPham;
                    dataGridViewData.Rows[n].Cells[2].Value = sanpham.MaSanPham;
                    dataGridViewData.Rows[n].Cells[3].Value = sanpham.DanhMuc;
                    dataGridViewData.Rows[n].Cells[4].Value = sanpham.ThuongHieu;
                    dataGridViewData.Rows[n].Cells[5].Value = sanpham.TinhTrang;
                    dataGridViewData.Rows[n].Cells[6].Value = sanpham.GiaBan;
                    dataGridViewData.Rows[n].Cells[7].Value = sanpham.GiaCu;

                    dataGridViewData.Rows[n].Cells[10].Value = sanpham.MoTaSanPham;
                    //String anhsanpham = "";
                    //for (int i = 0; i < sanpham.ListAnh.Count; i++)
                    //{
                    //    anhsanpham = anhsanpham + @";" + sanpham.ListAnh[i];
                    //}
                    //dataGridViewData.Rows[n].Cells[11].Value = anhsanpham;

                    for (int i = 0; i < sanpham.ListMaPhanLoai.Count; i++)
                    {
                        dataGridViewData.Rows[n].Cells[0].Value = sanpham.ID;
                        dataGridViewData.Rows[n].Cells[8].Value = sanpham.ListMaPhanLoai[i];
                        //dataGridViewData.Rows[n].Cells[9].Value = sanpham.ListPhanLoai[i];
                        if(!(i == sanpham.ListMaPhanLoai.Count - 1))
                        n = dataGridViewData.Rows.Add();
                    }

                    
                }

            }
        }

        public SanPham MaPhanLoaiSanPham(SanPham mSanPham)
        {
            //lay thong tin ma phan loai san pham
            mSanPham.ListMaPhanLoai = new List<string>();
            try
            {
                // LAY THONG SO KI THUAT
                using (StreamReader sr = File.OpenText(filename))
                {
                    string s = "";
                    int x = 0;

                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("<a href=\"?variant_id="))
                        {
                            string text = s.Split('"')[1];
                            text = text.Split('=')[1];
                            mSanPham.ListMaPhanLoai.Add(text);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return mSanPham;
         }
    private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Trang_tính1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            worksheet.Name = "Uyên";

            for (int i = 1; i < dataGridViewData.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewData.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewData.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewData.Columns.Count; j++)
                {
                    try
                    {
                        if(dataGridViewData.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridViewData.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                    
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Danh sach san pham Kool";
            saveFileDialog.DefaultExt = ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
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
                //dataGridViewData.DataSource = dt;
                mListGoc = (from DataRow dr in dt.Rows
                             select new LinkSP()
                             {
                                 ID = dr["ID"].ToString(),
                                 BienThe = dr["Biến Thể"].ToString(),
                                 MaBienThe = dr["Mã Biến Thể"].ToString()
                             }).ToList();

                ChayChuongTrinhLayDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
                MessageBox.Show(ex.ToString());
            }
        }

        private void ChayChuongTrinhLayDuLieu()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000"); //an chorme
            var driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl("https://www.google.com/");
            System.Threading.Thread.Sleep(300);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            //foreach (string line in txtCheckerCode.Lines)
            for (int stt = 0; stt < mListGoc.Count; stt++)
            {
                string link = @"https://kinhmatkool.com/--pi" + mListGoc[stt].ID + "?variant_id=" + mListGoc[stt].MaBienThe;

                //try
                {
                    driver.Navigate().GoToUrl(link);
                    System.Threading.Thread.Sleep(1000);

                    SanPham _sanpham = new SanPham();
                    _sanpham.ID = mListGoc[stt].ID;

                    //Lấy tên sản phẩm
                    _sanpham.TenSanPham = driver.FindElements(By.ClassName("product-title"))[0].Text;

                    //Lấy cụm dữ liệu
                    var list = driver.FindElements(By.ClassName("list-unstyled"))[0].Text.Split('\r');
                    _sanpham.MaSanPham = list[1].Replace("\n", "");
                    _sanpham.DanhMuc = list[3].Replace("\n", "");
                    _sanpham.ThuongHieu = list[5].Replace("\n", "");
                    _sanpham.TinhTrang = list[7].Replace("\n", "");

                    //Lấy giá sản phẩm
                    _sanpham.GiaBan = driver.FindElements(By.ClassName("special-price"))[0].Text;
                    _sanpham.GiaCu = driver.FindElements(By.ClassName("old-price"))[0].Text;

                    //Lấy tên biến thể
                    _sanpham.BienThe = mListGoc[stt].BienThe;
                    _sanpham.MaBienThe = mListGoc[stt].MaBienThe;

                    //var listbienthe = driver.FindElements(By.ClassName("bk_product-variation--disabled"));
                    //_sanpham.ListMaPhanLoai = new List<string>();
                    //_sanpham.ListPhanLoai = new List<string>();
                    //_sanpham.ListAnh = new List<string>();
                    //Lấy mã biến thể
                    //foreach (var item in listbienthe)
                    //{
                    //    string bienthe = item.GetAttribute("href").Split('=')[1];
                    //    _sanpham.ListMaPhanLoai.Add(bienthe);
                    //    _sanpham.ListPhanLoai.Add(item.Text);
                    //}

                    _sanpham.BienThe = driver.FindElements(By.ClassName("active"))[0].Text;
                    _sanpham.MoTaSanPham = driver.FindElements(By.ClassName("active"))[1].Text;

                    //Lấy hình ảnh
                    _sanpham.ListAnh = new List<string>();
                    var image = driver.FindElements(By.ClassName("elevatezoom-gallery"));
                    foreach (var item in image)
                    {
                        string ima = item.GetAttribute("href");
                        _sanpham.ListAnh.Add(ima);
                    }

                    mListSanPham.Add(_sanpham);
                }
                //catch (Exception ex)
                //{
                //    Actions actions = new Actions(driver);
                //    actions.SendKeys(OpenQA.Selenium.Keys.Escape);
                //}

                dataGridViewData.Rows.Clear();
                foreach (SanPham sanpham in mListSanPham)
                {
                    int n = dataGridViewData.Rows.Add();
                    dataGridViewData.Rows[n].Cells[0].Value = sanpham.ID;
                    dataGridViewData.Rows[n].Cells[1].Value = sanpham.TenSanPham;
                    dataGridViewData.Rows[n].Cells[2].Value = sanpham.MaSanPham;
                    dataGridViewData.Rows[n].Cells[3].Value = sanpham.DanhMuc;
                    dataGridViewData.Rows[n].Cells[4].Value = sanpham.ThuongHieu;
                    dataGridViewData.Rows[n].Cells[5].Value = sanpham.TinhTrang;
                    dataGridViewData.Rows[n].Cells[6].Value = sanpham.GiaBan;
                    dataGridViewData.Rows[n].Cells[7].Value = sanpham.GiaCu;

                    dataGridViewData.Rows[n].Cells[10].Value = sanpham.MoTaSanPham;
                    String anhsanpham = "";
                    for (int i = 0; i < sanpham.ListAnh.Count; i++)
                    {
                        anhsanpham = anhsanpham + @";" + sanpham.ListAnh[i];
                    }
                    dataGridViewData.Rows[n].Cells[11].Value = anhsanpham;

                    //for (int i = 0; i < sanpham.ListMaPhanLoai.Count; i++)
                    //{
                    //    dataGridViewData.Rows[n].Cells[8].Value = sanpham.ListMaPhanLoai[i];
                    //    dataGridViewData.Rows[n].Cells[9].Value = sanpham.ListPhanLoai[i];
                    //    if (!(i == sanpham.ListMaPhanLoai.Count - 1))
                    //        n = dataGridViewData.Rows.Add();
                    //}

                    dataGridViewData.Rows[n].Cells[8].Value = sanpham.MaBienThe;
                    dataGridViewData.Rows[n].Cells[9].Value = sanpham.BienThe;

                }

            }
        }

    }
}
