using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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

namespace Lay_Khach_Hang_3M
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string fileName = @"D:\code.txt";

        public List<string> listDauSDT = new List<string> { "088","091","094","083","084","085","081","082","086","096","097","098","032","033","034","035","036","037","038","039","089","090","093","070","079","077","076","078","092","056","058","099","059" };

        private void btnXuLi_Click(object sender, EventArgs e)
        {
            //var driver = new ChromeDriver();
            var driver2 = new FirefoxDriver();
            driver2.Navigate().GoToUrl("https://chotroihn.vn/apps/kiem-tra-don-hang");
            //driver2.FindElementById("PhoneNumber").SendKeys("0327006111");
            //driver.FindElementById("Password").SendKeys("Mualinhkien.1108");

            //WebDriverWait wait = new WebDriverWait(driver2, TimeSpan.FromSeconds(1));
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Name("PhoneNumber")));

            string input = driver2.PageSource;
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (StreamWriter fs = File.CreateText(fileName))
            {
                fs.WriteLine(input);
            }
            Thread.Sleep(5000);
            Actions action = new Actions(driver2);
            action.MoveByOffset(423, 34).Perform();
            Thread.Sleep(5000);
            action.Click();

            //if(title_field != null)
            //{
            //    Actions actions = new Actions(driver);
            //    actions.MoveToElement(title_field);
            //    actions.Click();
            //    actions.SendKeys("123");
            //    actions.Build().Perform();
            //}



            //IWebElement element = driver.FindElementByClassName("container-fluid");
            //title_field.SendKeys(OpenQA.Selenium.Keys.Return);//Đăng nhập tài khoản
            //System.Threading.Thread.Sleep(2000);

            //((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            //driver.SwitchTo().Window(driver.WindowHandles.Last());

            //int i = 1;

            //do
            //{
            //    string link = @"https://linh-kien-tu-hu.mysapo.net/admin/settings/files?Page=" + i.ToString();
            //    driver.Navigate().GoToUrl(link);
            //    System.Threading.Thread.Sleep(2000);
            //}
            //while (mListAnhSP.Count > 0);
        }
    }
}
