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
    public partial class FormEditDM_Intent_Type : FormBase
    {
        private const String TAG = "FormEditDM_Intent_Type";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private DM_Intent_Type mDM_Intent_Type = new DM_Intent_Type();
        private IList<DM_Intent_Type> mListDM_Intent_Type = new List<DM_Intent_Type>();

        private enum ProcessingType
        {
            SaveData,
        }

        public FormEditDM_Intent_Type(DM_Intent_Type _mDM_Intent_Type, IList<DM_Intent_Type> _mListDM_Intent_Type)
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

            mDM_Intent_Type = _mDM_Intent_Type ?? new DM_Intent_Type();
            mListDM_Intent_Type = _mListDM_Intent_Type;

            txtLoaiChuDe.Text = mDM_Intent_Type.DM_Intent_TypeName;
            txtDisable.Checked = mDM_Intent_Type.DM_Intent_TypeDisable == 1;
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
                        if (mDM_Intent_Type.DM_Intent_TypeID > 0)
                        {
                            DM_Intent_TypePresenter.UpdateDM_Intent_Type(mDM_Intent_Type);
                        }
                        else
                        {
                            if (DM_Intent_TypePresenter.InsertDM_Intent_Type(mDM_Intent_Type) > 0)
                            {
                                //Tăng số ID lên
                                mDM_Intent_Type.DM_Intent_TypeID = mDM_Intent_Type.DM_Intent_TypeDBID + 10000;
                                DM_Intent_TypePresenter.UpdateDM_Intent_Type(mDM_Intent_Type);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region  Control Event
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
            if (String.IsNullOrEmpty(txtLoaiChuDe.Text.Trim()))
            {
                SanitaMessageBox.Show("Chưa nhập loại chủ đề !", "Thông Báo".Translate());
                txtLoaiChuDe.Focus();
                return;
            }

            mDM_Intent_Type.DM_Intent_TypeName = txtLoaiChuDe.Text;
            mDM_Intent_Type.DM_Intent_TypeDisable = txtDisable.Checked ? 1 : 0;

            bwAsync_Start(ProcessingType.SaveData);
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 0x0D)
            {
                SendKeys.SendWait("{TAB}");
            }
        }


        #endregion
    }
}