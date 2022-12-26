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
    public partial class FormViewDM_Entity_Type : FormBase
    {
        private const String TAG = "FormViewDM_Entity_Type";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private DateTime mLastSearch = new DateTime();

        private DM_Entity_Type mDM_Entity_Type = new DM_Entity_Type();
        private IList<DM_Entity_Type> mListData_Flat = new List<DM_Entity_Type>();
        private IList<DM_Entity_Type> mListData = new List<DM_Entity_Type>();

        private IList<ThongTinDanhSachDM_Entity_Type> mListThongTinDanhSachDM_Entity_Type = new List<ThongTinDanhSachDM_Entity_Type>();
        private IList<ThongTinDanhSachDM_Entity_Type> mListThongTinDanhSachDM_Entity_Type_Flat = new List<ThongTinDanhSachDM_Entity_Type>();
        private ThongTinDanhSachDM_Entity_Type mThongTinDanhSachDM_Entity_Type = null;

        private enum ProcessingType
        {
            LoadData,
        }

        public FormViewDM_Entity_Type()
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

            this.olvColumnID.AspectGetter = delegate(object x)
            {
                DM_Entity_Type data = (DM_Entity_Type)x;
                if (data != null && data.DM_Entity_TypeID > 0)
                {
                    return data.DM_Entity_TypeID;
                }
                return "";
            };

            //Init container tree list view
            this.mListViewData.CanExpandGetter = delegate(object x)
            {
                DM_Entity_Type data = (DM_Entity_Type)x;
                if (data.mListSubData != null && data.mListSubData.Count > 0)
                {
                    IList<DM_Entity_Type> mListSubData = data.mListSubData;

                    if (mListSubData.Count > 0)
                    {
                        return true;
                    }
                }

                return false;
            };

            this.mListViewData.ChildrenGetter = delegate(object x)
            {
                DM_Entity_Type data = (DM_Entity_Type)x;
                IList<DM_Entity_Type> mListSubData = data.mListSubData;

                return mListSubData;
            };

            mListViewData.PrimarySortOrder = SortOrder.Ascending;

            //Init container tree list view
            this.ListViewNhomDichVu.CanExpandGetter = delegate(object x)
            {
                ThongTinDanhSachDM_Entity_Type data = (ThongTinDanhSachDM_Entity_Type)x;
                if (data.mListSubData != null && data.mListSubData.Count > 0)
                {
                    IList<ThongTinDanhSachDM_Entity_Type> mListSubData = data.mListSubData;
                    return data.mListSubData.Count > 0;
                }

                return false;
            };
            this.ListViewNhomDichVu.ChildrenGetter = delegate(object x)
            {
                ThongTinDanhSachDM_Entity_Type data = (ThongTinDanhSachDM_Entity_Type)x;
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
                        if (mThongTinDanhSachDM_Entity_Type == null || mThongTinDanhSachDM_Entity_Type.ThongTinDanhSachDM_Entity_TypeID == 0)
                        {
                            UtilityListView.ListViewRefresh(ListViewNhomDichVu, mListThongTinDanhSachDM_Entity_Type);
                            ListViewNhomDichVu.SelectedIndex = 0;
                        }
                        else
                        {
                            UtilityListView.ListViewRefresh(ListViewNhomDichVu, mListThongTinDanhSachDM_Entity_Type, mThongTinDanhSachDM_Entity_Type.ThongTinDanhSachDM_Entity_TypeID.ToString(), 1);
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
                        DM_Entity_Type.InitDefaultList(DM_Entity_TypePresenter.GetDM_Entity_Types(null, null));
                        mListData_Flat = DM_Entity_Type.GetDefaultList(1).OrderBy(p => p.DM_Entity_TypeID).ToList();
                        MyVar.mListDM_Entity_Type = DM_Entity_Type.GetDefaultList(0).OrderBy(p => p.DM_Entity_TypeID).ToList();

                        //Update dữ liệu
                        mListData = new List<DM_Entity_Type>();
                        foreach (DM_Intent_Type nhom_khoa in DM_Intent_Type.GetDefaultList(0))
                        {
                            if (mListData_Flat.Any(p => p.DM_Intent_TypeID == nhom_khoa.DM_Intent_TypeID))
                            {
                                DM_Entity_Type group_DM_Entity_Type = new DM_Entity_Type();
                                group_DM_Entity_Type.DM_Intent_TypeID = nhom_khoa.DM_Intent_TypeID;
                                group_DM_Entity_Type.DM_Entity_TypeDBID = -1;
                                group_DM_Entity_Type.DM_Entity_TypeName = nhom_khoa.DM_Intent_TypeName;
                                group_DM_Entity_Type.mListSubData = mListData_Flat.Where(p => p.DM_Intent_TypeID == nhom_khoa.DM_Intent_TypeID).ToList();
                                mListData.Add(group_DM_Entity_Type);
                            }
                        }

                        //Update danh sách                 
                        {
                            mListThongTinDanhSachDM_Entity_Type = new List<ThongTinDanhSachDM_Entity_Type>();
                            mListThongTinDanhSachDM_Entity_Type_Flat = new List<ThongTinDanhSachDM_Entity_Type>();
                            ThongTinDanhSachDM_Entity_Type.ThongTinDanhSachDM_Entity_TypeID_Index = 1;

                            //Add tất cả khoa
                            ThongTinDanhSachDM_Entity_Type root = new ThongTinDanhSachDM_Entity_Type();
                            root.ThongTinDanhSachDM_Entity_TypeType = (int)ThongTinDanhSachDM_Entity_Type.TYPE.ROOT;
                            root.mListData = mListData;
                            root.ThongTinDanhSachDM_Entity_TypeName = "Tất Cả Đối Tượng (" + mListData_Flat.Where(p => p.DM_Entity_TypeID > 0).Count() + ")";
                            mListThongTinDanhSachDM_Entity_Type.Add(root);
                            mListThongTinDanhSachDM_Entity_Type_Flat.Add(root);
                        }

                        foreach (DM_DM_Entity_Type_Group nhom_dich_vu in DM_DM_Entity_Type_Group.GetDefaultList(0))
                        {
                            ThongTinDanhSachDM_Entity_Type mData = new ThongTinDanhSachDM_Entity_Type();
                            mData.ThongTinDanhSachDM_Entity_TypeType = (int)ThongTinDanhSachDM_Entity_Type.TYPE.GROUP;
                            mData.DM_DM_Entity_Type_GroupID = nhom_dich_vu.DM_DM_Entity_Type_GroupID;
                            mData.mListSubData = new List<ThongTinDanhSachDM_Entity_Type>();
                            mData.mListData = mListData;
                            mData.ThongTinDanhSachDM_Entity_TypeName = DM_DM_Entity_Type_Group.GetDefault(mData.DM_DM_Entity_Type_GroupID).DM_DM_Entity_Type_GroupName;

                            //Add loại khoa
                            {
                                IList<DM_DM_Entity_Type_SubGroup> list_sub = DM_DM_Entity_Type_SubGroup.GetDefaultList_Group(0, mData.DM_DM_Entity_Type_GroupID);
                                foreach (DM_DM_Entity_Type_SubGroup sub_data in list_sub)
                                {
                                    ThongTinDanhSachDM_Entity_Type mSubData = new ThongTinDanhSachDM_Entity_Type();
                                    mSubData.ThongTinDanhSachDM_Entity_TypeType = (int)ThongTinDanhSachDM_Entity_Type.TYPE.SUB_GROUP;
                                    mSubData.DM_DM_Entity_Type_GroupID = mData.DM_DM_Entity_Type_GroupID;
                                    mSubData.DM_DM_Entity_Type_SubGroupID = sub_data.DM_DM_Entity_Type_SubGroupID;
                                    mSubData.mListData = new List<DM_Entity_Type>();
                                    mSubData.ThongTinDanhSachDM_Entity_TypeName = DM_DM_Entity_Type_SubGroup.GetDefault(mSubData.DM_DM_Entity_Type_SubGroupID).DM_DM_Entity_Type_SubGroupName;

                                    //Loai 
                                    if (sub_data.DM_DM_Entity_Type_GroupID == DM_DM_Entity_Type_Group.INTENT)
                                    {
                                        int loai_khoa = sub_data.DM_DM_Entity_Type_SubGroupID - DM_DM_Entity_Type_SubGroup.INTENT_INIT;
                                        mSubData.mListData = mListData_Flat.Where(p => p.DM_Intent_TypeID == loai_khoa).ToList();
                                    }

                                    //Check
                                    if (mSubData.mListData.Count > 0)
                                    {
                                        mSubData.ThongTinDanhSachDM_Entity_TypeName += " (" + mSubData.mListData.Count + ")";
                                        mData.mListSubData.Add(mSubData);
                                        mListThongTinDanhSachDM_Entity_Type_Flat.Add(mSubData);
                                    }
                                }
                            }

                            //Check
                            if (mData.mListData.Count > 0)
                            {
                                mListThongTinDanhSachDM_Entity_Type.Add(mData);
                                mListThongTinDanhSachDM_Entity_Type_Flat.Add(mData);
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
            DM_Entity_Type data = mListViewData.SelectedObject as DM_Entity_Type;
            if (data != null && data.DM_Entity_TypeDBID > 0)
            {
                using (FormEditDM_Entity_Type form = new FormEditDM_Entity_Type(data, mListData_Flat))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        mDM_Entity_Type = form.mDM_Entity_Type;
                        DoRefresh();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormEditDM_Entity_Type form = new FormEditDM_Entity_Type(null, mListData_Flat))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    mDM_Entity_Type = form.mDM_Entity_Type;
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
            DM_Entity_Type data = mListViewData.SelectedObject as DM_Entity_Type;
            if (data != null && data.DM_Entity_TypeDBID > 0)
            {
                if (SanitaMessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DM_Entity_TypePresenter.DeleteDM_Entity_Type(data) > 0)
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
            mThongTinDanhSachDM_Entity_Type = ListViewNhomDichVu.SelectedObject as ThongTinDanhSachDM_Entity_Type;
            if (mThongTinDanhSachDM_Entity_Type != null)
            {
                //Refresh dịch vụ
                if (mDM_Entity_Type == null)
                {
                    UtilityListView.ListViewRefresh(mListViewData, mThongTinDanhSachDM_Entity_Type.mListData);
                }
                else
                {
                    UtilityListView.ListViewRefresh(mListViewData, mThongTinDanhSachDM_Entity_Type.mListData, mDM_Entity_Type.DM_Entity_TypeDBID.ToString(), 0);
                }

                //Seach
                if (!String.IsNullOrEmpty(txtSearch.Text.Trim()) && mThongTinDanhSachDM_Entity_Type.mListData.Count > 0)
                {
                    UtilityListView.DoListViewFilter(mListViewData, txtSearch.Text);
                }
            }
        }

        private void ListViewNhomDichVu_FormatRow(object sender, FormatRowEventArgs e)
        {
            ThongTinDanhSachDM_Entity_Type data = e.Model as ThongTinDanhSachDM_Entity_Type;
            if (data != null)
            {
                if (data.ThongTinDanhSachDM_Entity_TypeType == (int)ThongTinDanhSachDM_Entity_Type.TYPE.ROOT)
                {
                    e.Item.Font = new Font(e.Item.Font, FontStyle.Bold);
                }
                if (data.ThongTinDanhSachDM_Entity_TypeType == (int)ThongTinDanhSachDM_Entity_Type.TYPE.GROUP)
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
            DM_Entity_Type data = e.Model as DM_Entity_Type;
            if (data != null)
            {
                if (data.DM_Entity_TypeDBID < 0)
                {
                    e.Item.Font = new System.Drawing.Font(e.Item.Font, System.Drawing.FontStyle.Bold);
                }
                if (data.DM_Entity_TypeDisable == 1)
                {
                    e.Item.Font = new System.Drawing.Font(e.Item.Font, System.Drawing.FontStyle.Strikeout);
                    e.Item.ForeColor = Color.Red;
                }
            }
        }


    }
}