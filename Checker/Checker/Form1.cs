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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Object
        {
            public int ID { get; set; }

            public List<string> mListData = new List<string>();
        }

        public string fileName = @"D:\code.txt";

        public List<Object> mListData = new List<Object>();

        private void btnRun_Click(object sender, EventArgs e)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument("--window-position=-32000,-32000");

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

            int test = 10000;
            for (test = 10000; test <= 99999; test++)
            {
                string linkdh = @"https://checkerviet.pro/threads/" + test.ToString() + "/";
                driver.Navigate().GoToUrl(linkdh);
                System.Threading.Thread.Sleep(100);
                TaoFileCode(driver.PageSource);

                Object _object = new Object();
                _object.ID = test;
                _object.mListData = ReadSource();
                if (_object.mListData.Count > 0)
                {
                    mListData.Add(_object);
                }
            }

            string link = "";
            string fileoutput = @"D:\link.txt";
            foreach (Object ob in mListData)
            {
                link = link + "\n" + ob.ID.ToString();

                foreach(string str in ob.mListData)
                {
                    link = link + "\n" + str;
                } 
            }

            if (File.Exists(fileoutput))
            {
                File.Delete(fileoutput);
            }
            using (StreamWriter fs = File.CreateText(fileoutput))
            {
                fs.WriteLine(link);
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
    }
}
