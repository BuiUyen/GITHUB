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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            List<int> List_cod = new List<int>();
            if (File.Exists(@"link.txt"))
            {
                File.Delete(@"link.txt");
            }
            using (StreamWriter fs = File.CreateText(@"link.txt"))
            {
                fs.WriteLine("");
            }
            InitializeComponent();
        }

        public class SanPham
        {
            public string LinkSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string DanhGia { get; set; }
            public string SoDanhGia { get; set; }
            public string LuotBan { get; set; }
            public string GiaVon { get; set; }
            public string GiaBanGoc { get; set; }
            public string GiaBanHienTai { get; set; }
        }

        public string fileName = @"D:\code.txt";
        
        public List<SanPham> mListInput = new List<SanPham>();
        //public List<SanPham> mListOutput = new List<SanPham>();

        private void btnRun_Click(object sender, EventArgs e)
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

            foreach (SanPham sp in mListInput)
            {
                try
                {
                    driver.Navigate().GoToUrl(sp.LinkSanPham);
                    System.Threading.Thread.Sleep(1000);

                    //Tên sản phẩm
                    sp.TenSanPham = driver.FindElement(By.ClassName("attM6y")).Text;

                    //Sao và lượt đánh giá
                    var danhgia = driver.FindElements(By.ClassName("OitLRu"));
                    if (danhgia.Count == 0)
                    {
                        sp.DanhGia = "0";
                        sp.SoDanhGia = "0";
                    }
                    else
                    {
                        sp.DanhGia = danhgia[0].Text;
                        sp.SoDanhGia = danhgia[1].Text;
                    }

                    //Lượt bán
                    sp.LuotBan = driver.FindElement(By.ClassName("aca9MM")).Text;

                    //Giá bán gốc
                    try
                    {
                        var giabangoc = driver.FindElement(By.ClassName("_2MaBXe"));
                        sp.GiaBanGoc = giabangoc.Text;
                    }
                    catch
                    {
                        sp.GiaBanGoc = "0";
                    }

                    //Giá bán hiện tại
                    sp.GiaBanHienTai = driver.FindElement(By.ClassName("Ybrg9j")).Text;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            dataGridViewKetQua.Rows.Clear();
            foreach (SanPham sp in mListInput)
            {
                int n = dataGridViewKetQua.Rows.Add();
                dataGridViewKetQua.Rows[n].Cells[0].Value = sp.TenSanPham;
                dataGridViewKetQua.Rows[n].Cells[1].Value = sp.LinkSanPham;
                dataGridViewKetQua.Rows[n].Cells[2].Value = sp.GiaBanGoc;
                dataGridViewKetQua.Rows[n].Cells[3].Value = sp.GiaBanHienTai;
                dataGridViewKetQua.Rows[n].Cells[4].Value = sp.DanhGia;
                dataGridViewKetQua.Rows[n].Cells[5].Value = sp.SoDanhGia;
                dataGridViewKetQua.Rows[n].Cells[6].Value = sp.LuotBan;
            }
        }


        private void xóaTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewInput.Rows.Clear();
            mListInput = new List<SanPham>();
        }

        private void dánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteToExcel(true);
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
                            SanPham sp = new SanPham();
                            sp.LinkSanPham = fields[0];
                            sp.TenSanPham = fields[1];
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
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendo_Click(object sender, EventArgs e)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000"); //an chorme
            
            //var driver = new ChromeDriver(driverService, options);
            //driver.Navigate().GoToUrl("https://www.google.com/");
            //System.Threading.Thread.Sleep(300);
            //((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            //driver.SwitchTo().Window(driver.WindowHandles.Last());            

            foreach (SanPham sp in mListInput)
            {
                try
                {
                    var driver = new ChromeDriver(driverService, options);
                    driver.Navigate().GoToUrl(sp.LinkSanPham);
                    System.Threading.Thread.Sleep(5000);

                    //Sao và lượt đánh giá
                    var sodanhgia = driver.FindElements(By.ClassName("_314-995483"));
                    if (sodanhgia.Count == 0)
                    {
                        sp.DanhGia = "0";
                        sp.SoDanhGia = "0";
                    }
                    else
                    {
                        try
                        {
                            var danhgia = driver.FindElement(By.ClassName("d7e-922765"));                            
                            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", danhgia); // cuộn chuột đến bao giờ xuất hiện element
                            Thread.Sleep(500);
                            if (danhgia == null)
                            {
                                sp.DanhGia = "0";
                            }
                            else
                            {
                                sp.DanhGia = danhgia.Text;
                            }
                        }
                        catch
                        {
                            sp.DanhGia = "0";
                        }
                        
                        sp.SoDanhGia = sodanhgia[0].Text;
                    }

                    //Lượt bán
                    var luotban = driver.FindElements(By.ClassName("_314-13ea6b"));
                    if (luotban.Count == 0)
                    {
                        sp.LuotBan = "0";
                    }
                    else
                    {
                        sp.LuotBan = luotban[0].Text;
                    }

                    //Giá bán gốc
                    try
                    {
                        sp.GiaBanGoc = driver.FindElements(By.ClassName("d7e-87b451"))[0].Text;
                    }
                    catch
                    {
                        sp.GiaBanGoc = "0";
                    }

                    //Giá bán hiện tại
                    //sp.GiaBanHienTai = driver.FindElement(By.ClassName("Ybrg9j")).Text;
                    string _text = sp.LinkSanPham + "/" + sp.GiaBanGoc + "/" + sp.DanhGia + "/" + sp.SoDanhGia + "/" + sp.LuotBan;                    

                    string readText = File.ReadAllText(@"link.txt");
                    using (StreamWriter writer = new StreamWriter(@"link.txt"))
                    {
                        writer.WriteLine(readText + _text);
                    }
                    driver.Close();
                    driver.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            dataGridViewKetQua.Rows.Clear();
            foreach (SanPham sp in mListInput)
            {
                int n = dataGridViewKetQua.Rows.Add();
                dataGridViewKetQua.Rows[n].Cells[0].Value = sp.TenSanPham;
                dataGridViewKetQua.Rows[n].Cells[1].Value = sp.LinkSanPham;
                dataGridViewKetQua.Rows[n].Cells[2].Value = sp.GiaBanGoc;
                dataGridViewKetQua.Rows[n].Cells[3].Value = sp.GiaBanHienTai;
                dataGridViewKetQua.Rows[n].Cells[4].Value = sp.DanhGia;
                dataGridViewKetQua.Rows[n].Cells[5].Value = sp.SoDanhGia;
                dataGridViewKetQua.Rows[n].Cells[6].Value = sp.LuotBan;
            }
        }
    }
}