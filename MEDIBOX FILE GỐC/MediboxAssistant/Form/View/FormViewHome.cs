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
    public partial class FormViewHome : FormBase
    {
        private const String TAG = "FormViewHome";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;

        private IList<Home> mListHome = new List<Home>();


        private enum ProcessingType
        {
            LoadData,
        }

        public FormViewHome()
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

            this.olvColumnUser.AspectGetter = delegate(object x)
            {
                Home data = (Home)x;
                if (data != null && data.HomeID > 0)
                {
                    return User.GetDefault(data.UserID).UserName;
                }
                return "";
            };
        }

        #region Worker thread

        private void bwAsync_Start(ProcessingType type)
        {
            if (!mThread.IsBusy)
            {
                if (type == ProcessingType.LoadData)
                {
                    DataProgress.Visible = DataProgress.IsRunning = true;
                }
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
            DataProgress.Visible = DataProgress.IsRunning = false;
            mProgress.DoClose();
            ProcessingType type = (ProcessingType)e.Result;

            switch (type)
            {
                case ProcessingType.LoadData:
                    {
                        UtilityListView.ListViewRefresh(mListViewData, mListHome);
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
                case ProcessingType.LoadData:
                    {
                        mListHome = HomePresenter.GetHomes(null, null);
                        MyVar.mListHome = mListHome;
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
            DoRefresh();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void mListViewData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Home data = mListViewData.SelectedObject as Home;
            if (data != null && data.HomeID > 0)
            {
                using (FormEditHome form = new FormEditHome(data, mListHome))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        DoRefresh();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormEditHome form = new FormEditHome(null, mListHome))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DoRefresh();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Home data = mListViewData.SelectedObject as Home;
            if (data != null && data.HomeID > 0)
            {
                if (SanitaMessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (HomePresenter.DeleteHome(data) > 0)
                    {
                        DoRefresh();
                    }
                }
            }
        }

        private void DoRefresh()
        {
            bwAsync_Start(ProcessingType.LoadData);
        }

        private void mListViewData_Resize(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                DataProgress.Location = new System.Drawing.Point(
                    ((sender as Control).Location.X + (sender as Control).Width / 2 - DataProgress.Width / 2),
                    ((sender as Control).Location.Y + (sender as Control).Height / 2 - DataProgress.Height / 2)
                    );
            }
        }
    }
}