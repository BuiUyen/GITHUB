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
    public partial class FormViewIntentData : FormBase
    {
        private const String TAG = "FormViewIntentData";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private DateTime mLastSearch = new DateTime();

        private Intent mIntent = new Intent();
        private IList<Intent> mListData_Flat = new List<Intent>();
        private IList<Intent> mListData = new List<Intent>();

        private IList<ThongTinDanhSachIntent> mListThongTinDanhSachIntent = new List<ThongTinDanhSachIntent>();
        private IList<ThongTinDanhSachIntent> mListThongTinDanhSachIntent_Flat = new List<ThongTinDanhSachIntent>();
        private ThongTinDanhSachIntent mThongTinDanhSachIntent = null;

        private enum ProcessingType
        {
            LoadData,
        }

        public FormViewIntentData()
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

            this.olvColumnLoai.AspectGetter = delegate(object x)
            {
                Intent data = (Intent)x;
                if (data != null && data.IntentID > 0)
                {
                    return DM_Intent_Type.GetDefault(data.DM_Intent_TypeID).DM_Intent_TypeName;
                }
                return "";
            };

            //Init container tree list view
            this.mListViewData.CanExpandGetter = delegate(object x)
            {
                Intent data = (Intent)x;
                if (data.mListSubData != null && data.mListSubData.Count > 0)
                {
                    IList<Intent> mListSubData = data.mListSubData;

                    if (mListSubData.Count > 0)
                    {
                        return true;
                    }
                }

                return false;
            };

            this.mListViewData.ChildrenGetter = delegate(object x)
            {
                Intent data = (Intent)x;
                IList<Intent> mListSubData = data.mListSubData;

                return mListSubData;
            };

            //Init container tree list view
            this.ListViewNhomDichVu.CanExpandGetter = delegate(object x)
            {
                ThongTinDanhSachIntent data = (ThongTinDanhSachIntent)x;
                if (data.mListSubData != null && data.mListSubData.Count > 0)
                {
                    IList<ThongTinDanhSachIntent> mListSubData = data.mListSubData;
                    return data.mListSubData.Count > 0;
                }

                return false;
            };
            this.ListViewNhomDichVu.ChildrenGetter = delegate(object x)
            {
                ThongTinDanhSachIntent data = (ThongTinDanhSachIntent)x;
                return data.mListSubData;
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
                        //Refresh nhóm dịch vụ
                        if (mThongTinDanhSachIntent == null || mThongTinDanhSachIntent.ThongTinDanhSachIntentID == 0)
                        {
                            UtilityListView.ListViewRefresh(ListViewNhomDichVu, mListThongTinDanhSachIntent);
                            ListViewNhomDichVu.SelectedIndex = 0;
                        }
                        else
                        {
                            UtilityListView.ListViewRefresh(ListViewNhomDichVu, mListThongTinDanhSachIntent, mThongTinDanhSachIntent.ThongTinDanhSachIntentID.ToString(), 1);
                        }
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
                        mListData_Flat = IntentPresenter.GetIntents();

                        //Update dữ liệu
                        mListData = new List<Intent>();
                        foreach (DM_Intent_Type nhom in DM_Intent_Type.GetDefaultList(0))
                        {
                            if (mListData_Flat.Any(p => p.DM_Intent_TypeID == nhom.DM_Intent_TypeID))
                            {
                                Intent group_Intent = new Intent();
                                group_Intent.DM_Intent_TypeID = nhom.DM_Intent_TypeID;
                                group_Intent.IntentID = -1;
                                group_Intent.IntentName = nhom.DM_Intent_TypeName;
                                group_Intent.mListSubData = mListData_Flat.Where(p => p.DM_Intent_TypeID == nhom.DM_Intent_TypeID).ToList();
                                mListData.Add(group_Intent);
                            }
                        }

                        //Update danh sách tất cả các khoa                      
                        {
                            mListThongTinDanhSachIntent = new List<ThongTinDanhSachIntent>();
                            mListThongTinDanhSachIntent_Flat = new List<ThongTinDanhSachIntent>();
                            ThongTinDanhSachIntent.ThongTinDanhSachIntentID_Index = 1;

                            //Add tất cả khoa
                            ThongTinDanhSachIntent root = new ThongTinDanhSachIntent();
                            root.ThongTinDanhSachIntentType = (int)ThongTinDanhSachIntent.TYPE.ROOT;
                            root.mListData = mListData;
                            root.ThongTinDanhSachIntentName = "Tất Cả Ý Muốn (" + mListData_Flat.Where(p => p.IntentID > 0).Count() + ")";
                            mListThongTinDanhSachIntent.Add(root);
                            mListThongTinDanhSachIntent_Flat.Add(root);
                        }

                        foreach (DM_Intent_Group nhom_dich_vu in DM_Intent_Group.GetDefaultList(0))
                        {
                            ThongTinDanhSachIntent mData = new ThongTinDanhSachIntent();
                            mData.ThongTinDanhSachIntentType = (int)ThongTinDanhSachIntent.TYPE.GROUP;
                            mData.DM_Intent_GroupID = nhom_dich_vu.DM_Intent_GroupID;
                            mData.mListSubData = new List<ThongTinDanhSachIntent>();
                            mData.mListData = mListData;
                            mData.ThongTinDanhSachIntentName = DM_Intent_Group.GetDefault(mData.DM_Intent_GroupID).DM_Intent_GroupName;

                            //Add loại khoa
                            {
                                IList<DM_Intent_SubGroup> list_sub = DM_Intent_SubGroup.GetDefaultList_Group(0, mData.DM_Intent_GroupID);
                                foreach (DM_Intent_SubGroup sub_data in list_sub)
                                {
                                    ThongTinDanhSachIntent mSubData = new ThongTinDanhSachIntent();
                                    mSubData.ThongTinDanhSachIntentType = (int)ThongTinDanhSachIntent.TYPE.SUB_GROUP;
                                    mSubData.DM_Intent_GroupID = mData.DM_Intent_GroupID;
                                    mSubData.DM_Intent_SubGroupID = sub_data.DM_Intent_SubGroupID;
                                    mSubData.mListData = new List<Intent>();
                                    mSubData.ThongTinDanhSachIntentName = DM_Intent_SubGroup.GetDefault(mSubData.DM_Intent_SubGroupID).DM_Intent_SubGroupName;

                                    //Loai
                                    if (sub_data.DM_Intent_GroupID == DM_Intent_Group.LOAI)
                                    {
                                        int loai_khoa = sub_data.DM_Intent_SubGroupID - DM_Intent_SubGroup.LOAI_INIT;
                                        mSubData.mListData = mListData_Flat.Where(p => p.DM_Intent_TypeID == loai_khoa).ToList();
                                    }

                                    //Check
                                    if (mSubData.mListData.Count > 0)
                                    {
                                        mSubData.ThongTinDanhSachIntentName += " (" + mSubData.mListData.Count + ")";
                                        mData.mListSubData.Add(mSubData);
                                        mListThongTinDanhSachIntent_Flat.Add(mSubData);
                                    }
                                }
                            }

                            //Check
                            if (mData.mListData.Count > 0)
                            {
                                mListThongTinDanhSachIntent.Add(mData);
                                mListThongTinDanhSachIntent_Flat.Add(mData);
                            }
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
            DoRefresh();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void mListViewData_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Intent data = mListViewData.SelectedObject as Intent;
            if (data != null && data.IntentID > 0)
            {
                using (FormEditIntent form = new FormEditIntent(data, mListData_Flat))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        mIntent = form.mIntent;
                        DoRefresh();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormEditIntent form = new FormEditIntent(null, mListData_Flat))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    mIntent = form.mIntent;
                    DoRefresh();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void DoRefresh()
        {
            bwAsync_Start(ProcessingType.LoadData);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Intent data = mListViewData.SelectedObject as Intent;
            if (data != null && data.IntentID > 0)
            {
                if (SanitaMessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (IntentPresenter.DeleteIntent(data) > 0)
                    {
                        DoRefresh();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void ListViewNhomDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            mThongTinDanhSachIntent = ListViewNhomDichVu.SelectedObject as ThongTinDanhSachIntent;
            if (mThongTinDanhSachIntent != null)
            {
                //Refresh dịch vụ
                if (mIntent == null)
                {
                    UtilityListView.ListViewRefresh(mListViewData, mThongTinDanhSachIntent.mListData);
                }
                else
                {
                    UtilityListView.ListViewRefresh(mListViewData, mThongTinDanhSachIntent.mListData, mIntent.IntentName, 0);
                }

                //Seach
                if (!String.IsNullOrEmpty(txtSearch.Text.Trim()) && mThongTinDanhSachIntent.mListData.Count > 0)
                {
                    UtilityListView.DoListViewFilter(mListViewData, txtSearch.Text);
                }
            }
        }

        private void ListViewNhomDichVu_FormatRow(object sender, FormatRowEventArgs e)
        {
            ThongTinDanhSachIntent data = e.Model as ThongTinDanhSachIntent;
            if (data != null)
            {
                if (data.ThongTinDanhSachIntentType == (int)ThongTinDanhSachIntent.TYPE.ROOT)
                {
                    e.Item.Font = new Font(e.Item.Font, FontStyle.Bold);
                }
                if (data.ThongTinDanhSachIntentType == (int)ThongTinDanhSachIntent.TYPE.GROUP)
                {
                    e.Item.Font = new Font(e.Item.Font, FontStyle.Bold);
                }
            }
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

        private void TimerSearch_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - mLastSearch).TotalMilliseconds > 500)
            {
                UtilityListView.DoListViewFilter(mListViewData, txtSearch.Text);
                TimerSearch.Enabled = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            mLastSearch = DateTime.Now;
            TimerSearch.Enabled = true;
        }

        private void txtSearch_ButtonCustomClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "";
            }
            txtSearch.Focus();
        }

        private void mListViewData_FormatRow(object sender, FormatRowEventArgs e)
        {
            Intent data = e.Model as Intent;
            if (data != null)
            {
                if (data.IntentID <= 0)
                {
                    e.Item.Font = new System.Drawing.Font(e.Item.Font, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}