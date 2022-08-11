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

namespace Lay_Thong_Tin_San_Pham_Sendo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        public string codeshop;
        int sotrang;
        public string fileName = @"D:\code.txt";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            codeshop = tbxCodeShop.Text;
            sotrang = Int32.Parse(tbxSoTrang.Text);
            if(sotrang == 0)
            {
                MessageBox.Show("Chưa nhập số trang sản phẩm!!!");
            }   
            else
            {
                string link = @"https://www.sendo.vn/tim-kiem?p=1&platform=2&seller_admin_id=" + codeshop + @"&sortType=rank";
                var driver = new ChromeDriver(driverService, new ChromeOptions());
                driver.Navigate().GoToUrl(link);
                System.Threading.Thread.Sleep(1000);
                
                TaoFileCode(driver.PageSource);

                ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                for (int i=2; i < sotrang + 1;i++)
                {
                    link = @"https://www.sendo.vn/tim-kiem?p=" + i.ToString() +"&platform=2&seller_admin_id=" + codeshop + @"&sortType=rank";
                    driver.Navigate().GoToUrl(link);
                    System.Threading.Thread.Sleep(1000);
                    TaoFileCode(driver.PageSource);

                }                
            }
            
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

        private void tbxSoTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
