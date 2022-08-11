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
    public partial class FormEditUser : FormBase
    {
        private const String TAG = "FormEditUser";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private User mUser = new User();
        private IList<User> mListUser = new List<User>();

        private enum ProcessingType
        {
            SaveData,
        }

        public FormEditUser(User _mUser, IList<User> _mListUser)
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

            mUser = _mUser ?? new User();
            mListUser = _mListUser;

            txtUserCode.Text = mUser.UserCode;
            txtUserName.Text = mUser.UserName;
            txtPass.Text = mUser.UserPassword;
            txtAPIKey.Text = mUser.APIKey;
            txtLocaltionName.Text = mUser.LocaltionName;
            txtLatitude.Text = mUser.Latitude;
            txtLongitude.Text = mUser.Longitude;
            txtHassIO_URL.Text = mUser.HassIO_URL;
            txtHassIO_KEY.Text = mUser.HassIO_KEY;

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
                        if (mUser.UserID > 0)
                        {
                            UserPresenter.UpdateUser(mUser);
                        }
                        else
                        {
                            UserPresenter.InsertUser(mUser);
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

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validate
            if (String.IsNullOrEmpty(txtUserCode.Text.Trim()))
            {
                SanitaMessageBox.Show("Chưa nhập mã người dùng !", "Thông Báo".Translate());
                txtUserCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                SanitaMessageBox.Show("Chưa nhập tên người dùng !", "Thông Báo".Translate());
                txtUserName.Focus();
                return;
            }

            if (mListUser.Any(p => p.UserID != mUser.UserID && txtUserCode.Text.Trim() == p.UserCode))
            {
                SanitaMessageBox.Show("Mã người dùng đã được sử dụng !", "Thông Báo".Translate());
                txtUserCode.Focus();
                return;
            }

            if (mListUser.Any(p => p.UserID != mUser.UserID && txtUserName.Text.Trim() == p.UserName))
            {
                SanitaMessageBox.Show("Tên người dùng đã được sử dụng !", "Thông Báo".Translate());
                txtUserName.Focus();
                return;
            }

            mUser.UserCode = txtUserCode.Text;
            mUser.UserName = txtUserName.Text;
            mUser.UserPassword = txtPass.Text;
            mUser.APIKey = txtAPIKey.Text;
            mUser.LocaltionName = txtLocaltionName.Text;
            mUser.Latitude = txtLatitude.Text;
            mUser.Longitude = txtLongitude.Text;
            mUser.HassIO_URL = txtHassIO_URL.Text;
            mUser.HassIO_KEY = txtHassIO_KEY.Text;

            bwAsync_Start(ProcessingType.SaveData);
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 0x0D)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

    }
}