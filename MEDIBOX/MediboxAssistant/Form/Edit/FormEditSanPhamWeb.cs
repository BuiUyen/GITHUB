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
    public partial class FormEditSanPhamWeb : FormBase
    {
        private const String TAG = "FormEditSanPhamWeb";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private SanPhamWeb mSanPhamWeb = new SanPhamWeb();
        private IList<SanPhamWeb> mListSanPhamWeb = new List<SanPhamWeb>();

        private SanPhamWeb data;

        private enum ProcessingType
        {
            SaveData,
        }

        public FormEditSanPhamWeb(SanPhamWeb _mSanPhamWeb, IList<SanPhamWeb> _mListSanPhamWeb)
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

            mSanPhamWeb = _mSanPhamWeb ?? new SanPhamWeb();
            mListSanPhamWeb = _mListSanPhamWeb;

            txtAlias.Text = mSanPhamWeb.Alias;            
            txtTenSanPham.Text = mSanPhamWeb.TenSanPham;
            txtNhaCungCap.Text = mSanPhamWeb.NhaCungCap;
            txtLoai.Text = mSanPhamWeb.Loai;
            txtTag.Text = mSanPhamWeb.Tag;
            if(mSanPhamWeb.HienThi == "TRUE")
            {
                checkBoxHienThi.Checked = true;
                checkBoxHienThi.Checked = false;
            }
            else
            {
                checkBoxHienThi.Checked = false;
                checkBoxHienThi.Checked = true;
            }
            txtThongSo.Text = mSanPhamWeb.ThongSo;
            txtCongDung.Text = mSanPhamWeb.CongDung;
            UtilityListView.ListViewRefresh(mListViewData, mListSanPhamWeb);
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
                        if (mSanPhamWeb.SanPhamWebID > 0)
                        {
                            SanPhamWebPresenter.UpdateSanPhamWeb(mSanPhamWeb);
                        }
                        else
                        {
                            SanPhamWebPresenter.InsertSanPhamWeb(mSanPhamWeb);
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
            //if (String.IsNullOrEmpty(txtAlias.Text.Trim()))
            //{
            //    SanitaMessageBox.Show("Chưa nhập mã người dùng !", "Thông Báo".Translate());
            //    txtAlias.Focus();
            //    return;
            //}

            //if (String.IsNullOrEmpty(txtUserName.Text.Trim()))
            //{
            //    SanitaMessageBox.Show("Chưa nhập tên người dùng !", "Thông Báo".Translate());
            //    txtAlias.Focus();
            //    return;
            //}

            //if (mListUser.Any(p => p.UserID != mUser.UserID && txtAlias.Text.Trim() == p.UserCode))
            //{
            //    SanitaMessageBox.Show("Mã người dùng đã được sử dụng !", "Thông Báo".Translate());
            //    txtAlias.Focus();
            //    return;
            //}

            //if (mListUser.Any(p => p.UserID != mUser.UserID && txtUserName.Text.Trim() == p.UserName))
            //{
            //    SanitaMessageBox.Show("Tên người dùng đã được sử dụng !", "Thông Báo".Translate());
            //    txtUserName.Focus();
            //    return;
            //}

            //mSanPhamWeb.UserCode = txtAlias.Text;
            //mSanPhamWeb.UserName = txtUserName.Text;
            //mSanPhamWeb.UserPassword = txtTenSanPham.Text;
            //mSanPhamWeb.APIKey = txtAPIKey.Text;
            //mSanPhamWeb.LocaltionName = txtNhaCungCap.Text;
            //mSanPhamWeb.Latitude = txtLoai.Text;
            //mSanPhamWeb.Longitude = txtLongitude.Text;
            //mSanPhamWeb.HassIO_URL = txtTag.Text;
            //mSanPhamWeb.HassIO_KEY = txtHassIO_KEY.Text;

            //bwAsync_Start(ProcessingType.SaveData);
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