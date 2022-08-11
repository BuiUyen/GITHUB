using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Medibox.Model;
using Medibox.Presenter;
using Sanita.Utility;
using Sanita.Utility.ExtendedThread;
using Sanita.Utility.UI;

namespace Medibox
{
    public partial class FormEditHome : FormBase
    {
        private const String TAG = "FormEditHome";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private Home mHome = new Home();
        private IList<Home> mListHome = new List<Home>();

        private AutocompleteMenu mAutoMennu_User = new AutocompleteMenu();

        private enum ProcessingType
        {
            SaveData,
        }

        public FormEditHome(Home _mHome, IList<Home> _mListHome)
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

            mHome = _mHome ?? new Home();
            mListHome = _mListHome;

            txtHomeName.Text = mHome.HomeName;
            txtUser.Text = User.GetDefault(mHome.UserID).UserName;
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
                        if (mHome.HomeID > 0)
                        {
                            HomePresenter.UpdateHome(mHome);
                        }
                        else
                        {
                            HomePresenter.InsertHome(mHome);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    btnOK_Click(this, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Database_Load(object sender, EventArgs e)
        {
            mAutoMennu_User.SetAutocompleteItems(MyVar.mListUser.Select(p => new AutoData(p.UserName, p.UserID.ToString())).ToList());
            mAutoMennu_User.ComboboxMode = true;
            mAutoMennu_User.MaximumSize = new System.Drawing.Size(txtUser.Width - 4, 300);
            mAutoMennu_User.SetAutocompleteMenu(txtUser);
            txtUser.KeyDown += Control_KeyDown;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validate
            if (String.IsNullOrEmpty(txtHomeName.Text.Trim()))
            {
                SanitaMessageBox.Show("Chưa nhập home !", "Thông Báo".Translate());
                txtHomeName.Focus();
                return;
            }

            if (mListHome.Any(p => p.HomeID != mHome.HomeID && txtHomeName.Text.Trim() == p.HomeName))
            {
                SanitaMessageBox.Show("Tên đã được sử dụng !", "Thông Báo".Translate());
                txtHomeName.Focus();
                return;
            }

            mHome.HomeName = txtHomeName.Text;
            mHome.UserID = User.GetID(txtUser.Text.Trim());

            bwAsync_Start(ProcessingType.SaveData);
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 0x0D)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void txtUser_ButtonCustomClick(object sender, EventArgs e)
        {
            mAutoMennu_User.Show(txtUser, true, true);
        }

    }
}