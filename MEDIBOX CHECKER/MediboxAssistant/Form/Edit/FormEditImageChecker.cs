using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Medibox.Model;
using Medibox.Presenter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Sanita.Utility;
using Sanita.Utility.ExtendedThread;
using Sanita.Utility.UI;

namespace Medibox
{
    public partial class FormEditImageChecker : FormBase
    {
        private const String TAG = "FormEditImage";

        public ImageChecker mImageChecker = new ImageChecker();

        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private IList<ImageChecker> mListImageChecker = new List<ImageChecker>();
        

        private enum ProcessingType
        {
            SaveData,
        }

        public FormEditImageChecker(ImageChecker _mChecker, IList<ImageChecker> _mListImageChecker)
        {
            InitializeComponent();
            this.Translate();
            this.UpdateUI();
            base.DoInit();

            //Create worker
            mThread = new ExBackgroundWorker();
            mThread.WorkerReportsProgress = true;
            mThread.WorkerSupportsCancellation = true;
            mThread.ProgressChanged += new ProgressChangedEventHandler(bwAsync_WorkerChanged);
            mThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwAsync_WorkerCompleted);
            mThread.DoWork += new DoWorkEventHandler(bwAsync_Worker);
            
        }

        #region Worker thread

        private void bwAsync_Start(ProcessingType type)
        {
            if (!mThread.IsBusy)
            {
                mThread.RunWorkerAsync(type);
            }
        }

        private void bwAsync_WorkerChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (e.ProgressPercentage == -123456)
                {
                    mProgress = new FormProgress();
                    mProgress.Progress.TextVisible = false;
                    mProgress.ShowDialog();
                }
                else if (e.ProgressPercentage == 0)
                {
                    mProgress.Progress.Value = 0;
                    mProgress.Progress.Maximum = (int)e.UserState;
                }
                else if (e.ProgressPercentage > 0)
                {
                    mProgress.Progress.Value = e.ProgressPercentage;
                    mProgress.Progress.Text = string.Format("{0}%", (mProgress.Progress.Value * 100) / mProgress.Progress.Maximum);
                }
                else if (e.ProgressPercentage < 0)
                {
                    SanitaMessageBox.Show("Có lỗi xảy ra !", "Thông Báo".Translate());
                }
            }
            catch
            {
            }
        }

        private void bwAsync_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mProgress.DoClose();
            ProcessingType type = (ProcessingType)e.Result;

            switch (type)
            {
                case ProcessingType.SaveData:
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    break;
                default:
                    break;
            }
        }

        private void bwAsync_Worker(object sender, DoWorkEventArgs e)
        {
            ProcessingType type = (ProcessingType)e.Argument;
            e.Result = type;

            switch (type)
            {
                case ProcessingType.SaveData:
                    {
                        //if (mChecker.CheckerID > 0)
                        //{
                        //    CheckerPresenter.UpdateChecker(mChecker);
                        //}
                        //else
                        //{
                        //    CheckerPresenter.InsertChecker(mChecker);
                        //}
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, System.Windows.Forms.Keys keyData)
        {
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S:
                    btnOK_Click(this, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Database_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
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
            for(int stt = 70000; stt <=80000; stt++)
            {
                string line = stt.ToString();
                string link = @"https://checkerviet.bid/threads/" + line + @"/";
                try
                {
                    driver.Navigate().GoToUrl(link);
                    System.Threading.Thread.Sleep(3000);

                    Checker _checker = new Checker(); 

                    var title = driver.FindElements(By.ClassName("p-title-value"))[0];
                    
                    if(title.Text != "Oops! Từ từ đã checker!")
                    {
                        _checker.Name = title.Text;
                        // giá cả
                        var price = title.FindElements(By.ClassName("label--orange"));
                        if (price.Count != 0)
                        {
                            _checker.Price = price[0].Text;
                            // địa chỉ
                            var Address = title.FindElements(By.ClassName("label--skyBlue"));
                            if (Address.Count != 0)
                            {
                                _checker.Address = Address[0].Text;

                            }
                            // số điện thoại
                            var Phone = driver.FindElements(By.ClassName("tel"));
                            if (Phone.Count != 0)
                            {
                                _checker.Phone = Phone[0].Text;
                            }

                            _checker.CheckerCode = line;
                            CheckerPresenter.InsertChecker(_checker);
                            var elements = driver.FindElements(By.ClassName("bbWrapper"))[0].FindElements(By.TagName("img"));

                            foreach (var ele in elements)
                            {
                                ImageChecker _image = new ImageChecker();
                                _image.CheckerCode = line;
                                _image.Link = ele.GetAttribute("src");
                                _image.Alt = ele.GetAttribute("alt");
                                ImageCheckerPresenter.InsertImageChecker(_image);
                            }
                        }
                        
                    }                    
                }
                catch (Exception ex)
                {
                    Actions actions = new Actions(driver);
                    actions.SendKeys(OpenQA.Selenium.Keys.Escape);
                }

            }
            
            bwAsync_Start(ProcessingType.SaveData);
        }
    }
}