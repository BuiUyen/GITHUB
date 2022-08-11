using ExcelDataReader;
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
using HtmlAgilityPack;
using System.Threading;

namespace Lay_San_Pham_3M
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class SanPham
        {
            public string LinkSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string SKU { get; set; }
            public string Gia { get; set; }
            public string GiaCu { get; set; }
            public string ThongSoKiThuat { get; set; }
            public List<string> LinkAnhSP { get; set; }
            public string CanNang { get; set; }
            public List<string> ListTenPhanLoai { get; set; }
            public string PhanLoai { get; set; }
            public List<SanPham> mListSanPhamPhanLoai { get; set; }
        }

        DataTableCollection tableCollection;
        public string fileName = @"E:\code.txt";
        public List<SanPham> mListSanPham = new List<SanPham>();
        public List<SanPham> mList3M = new List<SanPham>();
        public List<SanPham> mListKetQua = new List<SanPham>();

        ChromeDriver driver;

        private void btnLaySanPham_Click(object sender, EventArgs e)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com/");
            System.Threading.Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            int sotrang = 2;
            Int32.TryParse(txbSoTrang.Text, out sotrang);

            int i = 1;
            do
            {
                string link = @"https://chotroihn.vn/collections/all?q=&page=" + i.ToString() + @"&view=grid";
                driver.Navigate().GoToUrl(link);
                System.Threading.Thread.Sleep(10000);


                mListSanPham.Clear();
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (StreamWriter fs = File.CreateText(fileName))
                {
                    fs.WriteLine(driver.PageSource);

                }
                mListSanPham = ReadSource();

                foreach (SanPham sp in mListSanPham)
                {
                    int n = dataGridViewSanPham.Rows.Add();
                    dataGridViewSanPham.Rows[n].Cells[0].Value = sp.LinkSanPham;
                    dataGridViewSanPham.Rows[n].Cells[1].Value = sp.TenSanPham;
                    dataGridViewSanPham.Rows[n].Cells[2].Value = sp.Gia;
                }
                i++;
            }
            while (i <= sotrang);
        }

        public List<SanPham> ReadSource()
        {
            List<SanPham> mlistsanpham = new List<SanPham>();
            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    SanPham mSanPham = new SanPham();
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("grid-view-item__link image-ajax"))
                        {
                            List<string> mList = s.Split('/').ToList<string>();
                            mList[1] = mList[1].Remove(mList[1].Length - 2); ;
                            mSanPham.LinkSanPham = "https://chotroihn.vn/" + mList[1];
                        }

                        if (s.Contains("first-img img-responsive center-block"))
                        {
                            List<string> mList = s.Split('"').ToList<string>();
                            mSanPham.TenSanPham = mList[mList.Count - 2];
                        }

                        if (s.Contains("class=\"money\""))
                        {
                            if (mSanPham.LinkSanPham != null)
                            {
                                List<string> mList = s.Split('>').ToList<string>();
                                string str = mList[mList.Count - 2];
                                mSanPham.Gia = str.Remove(str.Length - 6);
                                mlistsanpham.Add(mSanPham);
                            }
                            //reset san pham
                            mSanPham = new SanPham();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            return mlistsanpham;
        }

        private void txbSoTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnXuat1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Trang_tính1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Uyên";

            for (int i = 1; i < dataGridViewSanPham.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewSanPham.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewSanPham.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewSanPham.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridViewSanPham.Rows[i].Cells[j].Value.ToString();
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Link Anh Web";
            saveFileDialog.DefaultExt = ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txbFile.Text = openFileDialog.FileName;
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
                System.Data.DataTable dt = tableCollection[tableCollection[0].TableName];
                dataGridViewDaTa.DataSource = dt;
                mList3M = (from DataRow dr in dt.Rows                                    
                                    select new SanPham()
                                    {
                                        LinkSanPham = dr["Link Sản Phẩm"].ToString(),
                                        TenSanPham = dr["Tên Sản Phẩm"].ToString(),
                                        Gia = dr["Giá"].ToString()
                                    }).ToList();
            }
            catch
            {
                MessageBox.Show("Không tồn tại bảng sản phẩm cần tìm!", "Thông Báo");
            }
        }

        private void btnXuLi_Click(object sender, EventArgs e)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com/");
            System.Threading.Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            mListKetQua.Clear();
            {
                foreach (SanPham mSanPham in mList3M)
                {
                    string link = mSanPham.LinkSanPham;
                    driver.Navigate().GoToUrl(link);
                    //System.Threading.Thread.Sleep(1000);
                    
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    using (StreamWriter fs = File.CreateText(fileName))
                    {
                        fs.WriteLine(driver.PageSource);

                    }
                    SanPham sp = ReadSourceImage(mSanPham);

                    int n = dataGridViewKetQua.Rows.Add();
                    dataGridViewKetQua.Rows[n].Cells[0].Value = sp.LinkSanPham;
                    dataGridViewKetQua.Rows[n].Cells[1].Value = sp.TenSanPham;
                    dataGridViewKetQua.Rows[n].Cells[2].Value = sp.Gia;
                    dataGridViewKetQua.Rows[n].Cells[3].Value = sp.ThongSoKiThuat;
                    for (int i = 0; i < sp.LinkAnhSP.Count && i < 5; i++)
                    {
                        dataGridViewKetQua.Rows[n].Cells[i + 4].Value = sp.LinkAnhSP[i];
                    }
                    dataGridViewKetQua.Rows[n].Cells[10].Value = sp.CanNang;
                    dataGridViewKetQua.Rows[n].Cells[11].Value = sp.PhanLoai;
                }
            }            
        }

        public SanPham ReadSourceImage(SanPham mSanPham)
        {
            List<SanPham> mlistsanpham = new List<SanPham>();
            string ThongSoKiThuat = "";

            //lay thong tin san pham
            try
            {
                // LAY THONG SO KI THUAT
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    int x = 0;
                    
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("</ul>") && x == 1)
                        {
                            ThongSoKiThuat = ThongSoKiThuat + s;
                            break;
                        }

                        if (x == 1)
                        {
                            if(s.Contains("<ul>"))
                            {
                                ThongSoKiThuat = ThongSoKiThuat + s;
                            }
                            else
                            {
                                ThongSoKiThuat = ThongSoKiThuat + s + "\n\n";
                            }                            
                        }

                        if (s.ToLower().Contains(">thông số kỹ thuật") || s.ToLower().Contains(">thông số kĩ thuật"))
                        {
                            x = 1;
                        }
                    }
                }
                mSanPham.ThongSoKiThuat = ConvertHTMLToPlanText(ThongSoKiThuat).Substring(1).Replace("\r","\n\n");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            try
            {
                // LAY LINK ANH SAN PHAM
                List<string> SubString;
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    mSanPham.LinkAnhSP = new List<string>();

                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("\"option1\":\"Default Title\""))
                        {
                            mSanPham.PhanLoai = "Có phân loại";
                        }                        
                        
                        if (s.Contains("\"featured_image\":{\"src\":"))
                        {
                            SubString = s.Split(',').ToList();
                            for (int i = 0; i < SubString.Count; i++)
                            {
                                if (SubString[i].Contains("\"images\""))
                                {
                                    List<string> _sub = SubString[i].Split('"').ToList();
                                    foreach (string str in _sub)
                                    {
                                        if (str.Contains("bizweb.dktcdn.net") && !mSanPham.LinkAnhSP.Contains(str))
                                        {
                                            mSanPham.LinkAnhSP.Add(str);
                                        }
                                    }
                                }

                                if (SubString[i].Contains("\"src\"") && !SubString[i].Contains("\"images\"") && !SubString[i].Contains("\"featured_image\""))
                                {
                                    List<string> _sub = SubString[i].Split('"').ToList();
                                    foreach (string str in _sub)
                                    {
                                        if (str.Contains("bizweb.dktcdn.net") && !mSanPham.LinkAnhSP.Contains(str))
                                        {
                                            mSanPham.LinkAnhSP.Add(str);
                                        }
                                    }
                                }

                                if (SubString[i].Contains("\"weight\""))
                                {
                                    List<string> _sub = SubString[i].Split('"').ToList();
                                    mSanPham.CanNang = _sub[2].Substring(1);
                                }
                            }
                            break;
                        }                        
                    }
                }                
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            return mSanPham;
        }

        public SanPham ReadSourceImage2(SanPham mSanPham)
        {
            //mSanPham = new SanPham();
            mSanPham.LinkAnhSP = new List<string>();            
            string link = mSanPham.LinkSanPham;
            try
            {
                driver.Navigate().GoToUrl(link);
                Thread.Sleep(3000);


                //Lấy ảnh đại diện
                var mListAnhDaiDien = driver.FindElements(By.ClassName("thumb-link"));
                foreach (var Anh in mListAnhDaiDien)
                {
                    mSanPham.LinkAnhSP.Add(Anh.GetAttribute("data-zoom-image"));
                }

                //Lấy tên sản phẩm
                mSanPham.TenSanPham = driver.FindElements(By.ClassName("title-head"))[0].Text;                

                //Lấy list phân loại
                var phanloai = driver.FindElements(By.ClassName("select-swatch"));
                if (phanloai.Count != 0)
                {
                    //Lấy tên phân loại sản phẩm
                    mSanPham.PhanLoai = driver.FindElements(By.ClassName("header"))[1].Text;

                    //Danh sách giá trị phân loại
                    mSanPham.ListTenPhanLoai = new List<string>();
                    var tenphanloai = driver.FindElement(By.ClassName("select-swap")).Text;
                    string[] listphanloai = tenphanloai.Split('\r');

                    mSanPham.mListSanPhamPhanLoai = new List<SanPham>();

                    //đếm số phân loại
                    int i = 0;
                    foreach (var item in listphanloai)
                    {
                        string pl = item.Trim();
                        mSanPham.ListTenPhanLoai.Add(pl);

                        driver.FindElements(By.ClassName("swatch-element"))[i].Click();//click từng phân loại
                        Thread.Sleep(1000);
                        mSanPham.mListSanPhamPhanLoai.Add(LayThongTinSanPham(mSanPham, pl));
                        i++;
                    }
                }
                else
                {
                    mSanPham = LayThongTinSanPham(mSanPham, mSanPham.PhanLoai);
                    //mSanPham = LayThongTinSanPham(mSanPham, "Mặc định");
                }
            }
            catch (Exception ex)
            {
                mSanPham.TenSanPham = "lỗi link sản phẩm"+ ex;
            }
            
            return mSanPham;
        }

        public SanPham LayThongTinSanPham(SanPham mSanPham, string phanloai)
        {
            SanPham sanpham = new SanPham();
            sanpham.LinkSanPham = mSanPham.LinkSanPham;
            sanpham.TenSanPham = mSanPham.TenSanPham;
            sanpham.LinkAnhSP = mSanPham.LinkAnhSP;
            sanpham.Gia = driver.FindElements(By.ClassName("product-price"))[0].Text;
            sanpham.GiaCu = driver.FindElements(By.ClassName("product-price-old"))[0].Text;
            if(sanpham.GiaCu == null)
            {
                sanpham.GiaCu = "0";
            }    
            sanpham.SKU = driver.FindElements(By.ClassName("product_sku"))[0].Text;
            sanpham.SKU = sanpham.SKU.Replace("Mã sản phẩm:", "").Trim();
            sanpham.PhanLoai = phanloai;
            return sanpham;
        }

        public static string ConvertHTMLToPlanText(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         RegexOptions.IgnoreCase);
                //result = Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         RegexOptions.IgnoreCase);

                // replace special characters:
                result = Regex.Replace(result,
                         @" ", " ",
                         RegexOptions.IgnoreCase);

                result = Regex.Replace(result,
                         @"&bull;", " * ",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"&lsaquo;", "<",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"&rsaquo;", ">",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"&trade;", "(tm)",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"&frasl;", "/",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"&lt;", "<",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"&gt;", ">",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"&copy;", "(c)",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         @"&reg;", "(r)",
                         RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         RegexOptions.IgnoreCase);

                // for testing
                //Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         RegexOptions.IgnoreCase);
                result = Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {

                return "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com/");
            System.Threading.Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());            

            dataGridViewKetQua2.Rows.Clear();
            mListKetQua.Clear();
            {
                foreach (SanPham mSanPham in mList3M)
                {
                    var _sanpham = ReadSourceImage2(mSanPham);
                    mListKetQua.Add(_sanpham);
                }
            }

            foreach (SanPham mSanPham in mListKetQua)
            {
                if (!(mSanPham.mListSanPhamPhanLoai == null))
                {
                    foreach(SanPham _sanpham in mSanPham.mListSanPhamPhanLoai)
                    {
                        ShowKetQua(_sanpham);
                    }
                }
                else
                {
                    ShowKetQua(mSanPham);
                }
            }
        }

        private void ShowKetQua(SanPham mSanPham)
        {
            int n = dataGridViewKetQua2.Rows.Add();
            dataGridViewKetQua2.Rows[n].Cells[0].Value = mSanPham.LinkSanPham;
            dataGridViewKetQua2.Rows[n].Cells[1].Value = mSanPham.TenSanPham;
            dataGridViewKetQua2.Rows[n].Cells[2].Value = mSanPham.SKU;
            dataGridViewKetQua2.Rows[n].Cells[3].Value = mSanPham.PhanLoai;
            dataGridViewKetQua2.Rows[n].Cells[4].Value = mSanPham.Gia;
            dataGridViewKetQua2.Rows[n].Cells[5].Value = mSanPham.GiaCu;
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            try
            {
                for (int i = 0; i < 500; i=i+100)
                {
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        CheckSDT(i, i + 99);
                    }).Start();
                }
                MessageBox.Show("Đã xong");
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckSDT(int min, int max)
        {
            string SoDienThoai = "";
            driver = new ChromeDriver();
            try
            {
                for (int i = min; i < max; i++)
                {
                    driver.Navigate().GoToUrl(@"https://checkorder.sapoapps.vn/orders/app/widget?store=linhkien3m.mysapo.net");
                    Thread.Sleep(1000);
                    var sdt = driver.FindElement(By.ClassName("form-control"));
                    SoDienThoai = "032" + i.ToString("0000000");
                    
                    //điền số điện thoại
                    sdt.SendKeys(SoDienThoai);
                    sdt.SendKeys(OpenQA.Selenium.Keys.Return);
                    Thread.Sleep(1000);
                    var test = driver.FindElements(By.Id("empty-error"));
                    string tenfile = min.ToString() + "-" + max.ToString();
                    if (test.Count == 0)
                    {
                        LuuSDT(tenfile, SoDienThoai);
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LuuSDT(string tenfile, string SDT)
        {
            tenfile = @"D:\SoDienThoai" + tenfile + ".txt";
            if (!File.Exists(tenfile))
            {
                using (StreamWriter fs = File.CreateText(tenfile))
                {

                }
            }

            string readText = File.ReadAllText(tenfile);
            using (StreamWriter writer = new StreamWriter(tenfile))
            {
                writer.WriteLine(readText + SDT);
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Trang_tính1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            worksheet.Name = "Uyên";

            for (int i = 1; i < dataGridViewKetQua2.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewKetQua2.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewKetQua2.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewKetQua2.Columns.Count; j++)
                {
                    if (dataGridViewKetQua2.Rows[i].Cells[j].Value == null)
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                    else
                        worksheet.Cells[i + 2, j + 1] = dataGridViewKetQua2.Rows[i].Cells[j].Value.ToString();
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
    }
}

