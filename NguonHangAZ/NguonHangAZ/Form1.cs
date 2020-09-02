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

namespace NguonHangAZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class SanPham
        {
            public string ID { get; set; }

            public string link { get; set; }
        }

        public class DonHang
        {
            public string ID { get; set; }
            public string ID_AZ { get; set; }
            
            public List<SanPham> SanPham = new List<SanPham>();

        }
        
        
        public string fileName = @"D:\code.txt";        

        private void btnRun_Click(object sender, EventArgs e)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;


            //ChromeOptions option = new ChromeOptions();
            //option.AddArgument("--headless");
            //var driver = new ChromeDriver(option);

            var driver = new ChromeDriver(driverService, new ChromeOptions());
            driver.Navigate().GoToUrl("https://nguonhangaz.com/user/login");
            driver.FindElementById("exampleInputEmail_2").SendKeys("Linhkiendientutuhu@gmail.com");
            driver.FindElementById("exampleInputpwd_2").SendKeys("Buihuuuyen.1508");

            //Đăng nhập tài khoản
            IWebElement element = driver.FindElement(By.Id("exampleInputpwd_2"));
            element.SendKeys(OpenQA.Selenium.Keys.Return);            
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            List<string> ListString_IDAZ = new List<string>();
            int i = 1;
            do
            {
                string link = @"https://nguonhangaz.com/order/all?status=-99&page=" + i.ToString();
                i++;
                driver.Navigate().GoToUrl(link);
                System.Threading.Thread.Sleep(1000);
                TaoFileCode(driver.PageSource);
                ListString_IDAZ = ReadSource();
            }
            while (ListString_IDAZ.Count > 0);
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

                        if (s.Contains("Không có bản ghi nào"))
                        {
                            break;
                        }

                        if (s.Contains("text-primary"))
                        {
                            string[] list = s.Split('>');
                            foreach (string i in list)
                            {
                                if (i.Contains("MA130"))
                                {
                                    i.Trim();
                                    List_String.Add(i.Substring(1, 12));
                                }
                            }
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






    }
}
