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

namespace Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Checker
        {
            public string ID { get; set; }
            public string Gia { get; set; }
            public string Ten { get; set; }
            public string SDT { get; set; }
            public string LinkAnh { get; set; }
            public List<string> ListAnh { get; set; }
        }

        public class Image
        {
            public string Link { get; set; }

            public string Alt { get; set; }
        }

        public class Object
        {
            public int ID { get; set; }

            public List<string> mListData = new List<string>();
        }

        public string fileName = @"D:\code.txt";

        public List<Object> mListData = new List<Object>();

        public List<Checker> mListChecker = new List<Checker>();

        public List<Image>  mListKetQua = new List<Image>();

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

            //string linktest = @"https://checkerviet.pro/threads/phuong-chi-mau-anh-ha-thanh-so-huu-khuon-mat-xinh-dang-dep-hoan-hao.58665/";
            //driver.Navigate().GoToUrl(linktest);
            //System.Threading.Thread.Sleep(100);
            //TaoFileCode(driver.PageSource);
            //Object _object = new Object();
            //_object.ID = 586654;
            //_object.mListData = ReadSource();
            //if (_object.mListData.Count > 0)
            //{
            //    mListData.Add(_object);
            //}

            
            
            string fileoutput = @"link.txt";
            List<int> List_cod = new List<int>();
            if (File.Exists(fileoutput))
            {
                File.Delete(fileoutput);
            }
            using (StreamWriter fs = File.CreateText(fileoutput))
            {
                
            }
            int.TryParse(tbxMin.Text, out int Min);
            int.TryParse(tbxMax.Text, out int Max);

            for (int test = Min; test <= Max; test++)
            {
                try
                {
                    string linkdh = @"https://checkerviet.org/threads/" + test.ToString() + "/";
                    driver.Navigate().GoToUrl(linkdh);
                    System.Threading.Thread.Sleep(5000);
                    TaoFileCode(driver.PageSource);

                    Object _object = new Object();
                    _object.ID = test;
                    _object.mListData = ReadSource();
                    if (_object.mListData.Count > 0)
                    {
                        string readText = File.ReadAllText(fileoutput);
                        using (StreamWriter writer = new StreamWriter(fileoutput))
                        {
                            writer.WriteLine(readText + test.ToString());
                        }
                    }                
                }
                catch (Exception ex)
                {

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
                        if (s.Contains("Trang bạn yêu cầu không tìm thấy"))
                        {
                            break;
                        }

                        if (s.Contains("lbContainer-zoomer"))
                        {                            
                            string[] arr = s.Split('"');                           
                            List_String.Add(arr[3]);
                        }
                        
                        if (s.Contains("js-selectToQuoteEnd"))
                        {
                            break;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();
                    txbFile.Text = filePath.ToString();
                }
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

            mListChecker = new List<Checker>();
            using (StreamReader reader = new StreamReader(filePath.ToString()))
            {
                string s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    Checker _checker = new Checker();
                    _checker.ListAnh = new List<string>(12);

                    string linkdh = @"https://checkerviet.gg/threads/" + s.ToString() + "/";
                    try
                    {
                        driver.Navigate().GoToUrl(linkdh);
                    }
                    catch (Exception ex)
                    {
                        Actions actions = new Actions(driver);
                        actions.SendKeys(OpenQA.Selenium.Keys.Escape);
                    }                    

                    _checker.ID = s;

                    //lấy tên
                    try
                    {
                        _checker.Ten = driver.Title;
                    }
                    catch
                    {
                        _checker.Ten = "lỗi tên";
                    }

                    //lấy giá
                    try
                    {
                        _checker.Gia = driver.FindElements(By.ClassName("label--orange"))[0].Text;
                    }
                    catch
                    {
                        _checker.Gia = "lỗi giá";
                    }

                    //lấy ảnh
                    try
                    {
                        var test = driver.FindElements(By.ClassName("lbContainer-zoomer"));
                        foreach (var ele in test)
                        {
                            _checker.ListAnh.Add(ele.GetAttribute("data-src"));
                        }
                    }
                    catch
                    {

                    }

                    //lấy SD
                    try
                    {
                        _checker.SDT = driver.FindElement(By.ClassName("fone")).Text;
                    }
                    catch
                    {
                        _checker.SDT = "lỗi SDT";
                    }
                    mListChecker.Add(_checker);
                }
            }
            ShowKetQua();
        }

        public void ShowKetQua()
        {
            dataGridViewKetQua.Rows.Clear();
            foreach(Checker ch in mListChecker)
            {
                int n = dataGridViewKetQua.Rows.Add();
                dataGridViewKetQua.Rows[n].Cells[0].Value = ch.ID;
                dataGridViewKetQua.Rows[n].Cells[1].Value = ch.Gia;
                dataGridViewKetQua.Rows[n].Cells[2].Value = ch.Ten;
                dataGridViewKetQua.Rows[n].Cells[3].Value = ch.SDT;

                for(int i = 0; i < ch.ListAnh.Count - 1 & i < 11 ; i++)
                {
                    dataGridViewKetQua.Rows[n].Cells[i+4].Value = ch.ListAnh[i];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileoutput = @"D:\link.txt";
            dataGridView1.Rows.Clear();

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000"); //an chorme

            var driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl("https://www.google.com/");
            System.Threading.Thread.Sleep(300);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            mListKetQua = new List<Image>();          

            //string linktest = @"https://upload69.pro/user/anhyeuem/?list=images&sort=date_desc&page=1&seek=MzEeET";

            string linktest = @"https://upload69.pro/user/hoanggia01/?page=1&peek=M6e0Ex";
            try
            {
                driver.Navigate().GoToUrl(linktest);
            }
            catch (Exception ex)
            {
                Actions actions = new Actions(driver);
                actions.SendKeys(OpenQA.Selenium.Keys.Escape);
            }

            
            for( int n = 0; n<600;n++)
            {
                var element = driver.FindElements(By.TagName("img"));

                for (int i = 1; i < 25; i++)
                {
                    Image image = new Image();
                    image.Link = element[i].GetAttribute("src");
                    image.Alt = element[i].GetAttribute("alt");
                    mListKetQua.Add(image);

                    string readText = File.ReadAllText(fileoutput);
                    using (StreamWriter writer = new StreamWriter(fileoutput))
                    {
                        writer.WriteLine(readText + image.Link.ToString());
                    }
                }
                
                driver.FindElements(By.ClassName("icon-arrow-right7"))[0].Click();
                Thread.Sleep(3000);
            }

            foreach (Image image in mListKetQua)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = n.ToString();
                dataGridView1.Rows[n].Cells[1].Value = image.Link;
                dataGridView1.Rows[n].Cells[2].Value = image.Alt;
            }

        }
    }
}
