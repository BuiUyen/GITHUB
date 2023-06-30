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

namespace Lấy_Dữ_Liệu_KOOL
{
    public partial class FormMAIN : Form
    {
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
            public List<string> ListMaPhanLoai { get; set; }
            public List<string> ListPhanLoai { get; set; }
            public List<string> ListAnh { get; set; }

            public string MoTaSanPham { get; set; }
        }

        public List<SanPham> mListSanPham = new List<SanPham>();

        public List<SanPham> mListPhanLoai = new List<SanPham>();

        private void buttonRUN_Click(object sender, EventArgs e)
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
            for (int stt = 1; stt <= 66; stt++)
            {
                string line = stt.ToString("00");
                string link = @"https://kinhmatkool.com/--pi" + line;
                try
                {
                    driver.Navigate().GoToUrl(link);
                    System.Threading.Thread.Sleep(1000);

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

                    //Lấy tên biến thể
                    _sanpham.BienThe = driver.FindElements(By.ClassName("active"))[0].Text;

                    var listbienthe = driver.FindElements(By.ClassName("bk_product-variation--disabled"));
                    _sanpham.ListMaPhanLoai = new List<string>();
                    _sanpham.ListPhanLoai = new List<string>();
                    _sanpham.ListAnh = new List<string>();
                    //Lấy mã biến thể
                    foreach (var item in listbienthe)
                    {
                        string bienthe = item.GetAttribute("href").Split('=')[1];
                        _sanpham.ListMaPhanLoai.Add(bienthe);
                        _sanpham.ListPhanLoai.Add(item.Text);
                    }

                    _sanpham.MoTaSanPham = driver.FindElements(By.ClassName("active"))[0].Text;

                    //Lấy hình ảnh
                    var image = driver.FindElements(By.ClassName("elevatezoom-gallery"));
                    foreach (var item in image)
                    {
                        string ima = item.GetAttribute("href");
                        _sanpham.ListAnh.Add(ima);
                    }    

                    mListSanPham.Add(_sanpham);
                }
                catch (Exception ex)
                {
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
                    String anhsanpham = "";
                    for (int i = 0; i < sanpham.ListAnh.Count; i++)
                    {
                        anhsanpham = anhsanpham + @";" + sanpham.ListAnh[i];
                    }
                    dataGridViewData.Rows[n].Cells[11].Value = anhsanpham;

                    for (int i = 0; i < sanpham.ListMaPhanLoai.Count; i++)
                    {
                        dataGridViewData.Rows[n].Cells[8].Value = sanpham.ListMaPhanLoai[i];
                        dataGridViewData.Rows[n].Cells[9].Value = sanpham.ListPhanLoai[i];
                        if(!(i == sanpham.ListMaPhanLoai.Count - 1))
                        n = dataGridViewData.Rows.Add();
                    }

                    
                }

            }
        }
    }
}
