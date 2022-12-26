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
using System.Drawing;

namespace Medibox
{
    public partial class FormViewDM_Intent_Type : FormBase
    {
        private const String TAG = "FormViewDM_Intent_Type";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;

        private IList<DM_Intent_Type> mListDM_Intent_Type = new List<DM_Intent_Type>();


        private enum ProcessingType
        {
            LoadData,
        }

        public FormViewDM_Intent_Type()
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
                        UtilityListView.ListViewRefresh(mListViewData, mListDM_Intent_Type);
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
                        DM_Intent_Type.InitDefaultList(DM_Intent_TypePresenter.GetDM_Intent_Types(null, null));
                        mListDM_Intent_Type = DM_Intent_Type.GetDefaultList(1).OrderBy(p => p.DM_Intent_TypeID).ToList();
                        MyVar.mListDM_Intent_Type = DM_Intent_Type.GetDefaultList(0).OrderBy(p => p.DM_Intent_TypeID).ToList();
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
            DM_Intent_Type data = mListViewData.SelectedObject as DM_Intent_Type;
            if (data != null && data.DM_Intent_TypeDBID > 0)
            {
                using (FormEditDM_Intent_Type form = new FormEditDM_Intent_Type(data, mListDM_Intent_Type))
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
            using (FormEditDM_Intent_Type form = new FormEditDM_Intent_Type(null, mListDM_Intent_Type))
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
            DM_Intent_Type data = mListViewData.SelectedObject as DM_Intent_Type;
            if (data != null && data.DM_Intent_TypeID > 0)
            {
                if (SanitaMessageBox.Show("Bạn có chắc chắn muốn xóa loại chủ đề này không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Check xem có Entity nào ko
                    IList<DM_Entity_Type> listcheck = DM_Entity_Type.GetDefaultList(0).Where(p => p.DM_Entity_TypeID == data.DM_Intent_TypeID).ToList();
                    if (listcheck.Count == 0)
                    {
                        if (DM_Intent_TypePresenter.DeleteDM_Intent_Type(data) > 0)
                        {
                            DoRefresh();
                        }
                    }
                    else
                    {
                        SanitaMessageBox.Show("Loại chủ đề đã tồn tại đối tượng !", "Thông Báo".Translate());
                        return;
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

        private void mListViewData_FormatRow(object sender, FormatRowEventArgs e)
        {
            DM_Intent_Type data = e.Model as DM_Intent_Type;
            if (data != null)
            {
                if (data.DM_Intent_TypeDisable == 1)
                {
                    e.Item.Font = new System.Drawing.Font(e.Item.Font, System.Drawing.FontStyle.Strikeout);
                    e.Item.ForeColor = Color.Red;
                }
            }
        }
    }
}