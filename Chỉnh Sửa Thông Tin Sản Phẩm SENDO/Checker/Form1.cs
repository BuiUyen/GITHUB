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
using System.ComponentModel;
using OpenDialogWindowHandler;
using OpenQA.Selenium.Interactions;

namespace Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true; // ho tro bao cao tien do
            bw.WorkerSupportsCancellation = true; // cho phep dung tien trinh
            // su kien
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            InitializeComponent();
        }

        public class SanPham
        {
            public string ID { get; set; }
            public string TenSanPham { get; set; }
            public string SKU { get; set; }
            public string TinhTrang { get; set; }
        }

        private BackgroundWorker bw;
        public List<SanPham> mListInput = new List<SanPham>();
        ChromeDriver driver;
        SanPham sanphamDangChay = new SanPham();
        int stt = 0;

        private void btnRun_Click(object sender, EventArgs e)
        {
            dataGridViewKetQua.Rows.Clear();
            Khoi_Tao_Chrome();

            //test mới
            foreach (SanPham sp in mListInput)
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
            bw.RunWorkerAsync();
        }

        private void Khoi_Tao_Chrome()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000"); //an chorme

            driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl("https://ban.sendo.vn/");
            driver.FindElementById("field-username").SendKeys("0889424462");
            driver.FindElementById("field-password").SendKeys("Buihuuuyen.1508");
            driver.FindElement(By.Name("password")).SendKeys(OpenQA.Selenium.Keys.Return);//Đăng nhập tài khoản
            System.Threading.Thread.Sleep(10000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        private void Chay_Chuong_Trinh(SanPham _sanpham)
        {
            if(checkBoxBaiViet.Checked == true)
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
                driver.FindElementById("field-name").Clear();
                driver.FindElementById("field-name").SendKeys(_sanpham.TenSanPham);
                Thread.Sleep(3000);
            }
            //Chỉnh sửa SKU sản phẩm
            if (checkBoxSKU.Checked == true)
            {
                driver.FindElementById("field-store_sku").Clear();
                driver.FindElementById("field-store_sku").SendKeys(_sanpham.SKU);
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
                if (undefined == null)
                {

                }
                else
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
            foreach(SanPham sp in mListInput)
            {
                int n = dataGridViewKetQua.Rows.Add();
                dataGridViewKetQua.Rows[n].Cells[0].Value = sp.ID;
                dataGridViewKetQua.Rows[n].Cells[1].Value = sp.TenSanPham;
                dataGridViewKetQua.Rows[n].Cells[2].Value = sp.SKU;
                dataGridViewKetQua.Rows[n].Cells[3].Value = sp.TinhTrang;
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
                            SanPham sp = new SanPham();
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

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Đã hoàn thành công việc!");
            Show_Ket_Qua();
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {            
            progressBar1.Value = e.ProgressPercentage;            
            Application.DoEvents();            
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (SanPham sp in mListInput)
            {
                sanphamDangChay = sp;
                stt = mListInput.FindIndex(n => n.ID == sp.ID);
                try
                {
                    Chay_Chuong_Trinh(sp);
                    mListInput[stt].TinhTrang = "đã xong";
                }
                catch
                {
                    mListInput[stt].TinhTrang = "lỗi";
                }
                Thread.Sleep(13000);
                var i = (int)Math.Round(((double)(stt + 1)/(double)(mListInput.Count))*100,0);
                // neu chon nut ket thuc thi ngung
                if (bw.CancellationPending) break;
                // bao cao tien do
                bw.ReportProgress(i, i);                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (File.Exists("file code.txt"))
            //{
            //    File.Delete("file code.txt");
            //}

            //using (StreamWriter fs = File.CreateText("file code.txt"))
            //{
            using (StreamReader sr = File.OpenText("file code.txt"))
                {
                    File.WriteAllText(@"D:\FileNoiDung.html", sr.ReadToEnd());
                }
            //}

            
        }
    }
}