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
    public partial class FormViewRoom : FormBase
    {
        private const String TAG = "FormViewRoom";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private DateTime mLastSearch = new DateTime();

        private Room mRoom = new Room();
        private IList<Room> mListData_Flat = new List<Room>();
        private IList<Room> mListData = new List<Room>();

        private IList<ThongTinDanhSachRoom> mListThongTinDanhSachRoom = new List<ThongTinDanhSachRoom>();
        private IList<ThongTinDanhSachRoom> mListThongTinDanhSachRoom_Flat = new List<ThongTinDanhSachRoom>();
        private ThongTinDanhSachRoom mThongTinDanhSachRoom = null;

        private enum ProcessingType
        {
            LoadData,
        }

        public FormViewRoom()
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

            this.olvColumnHome.AspectGetter = delegate(object x)
            {
                Room data = (Room)x;
                if (data != null && data.RoomID > 0)
                {
                    return Home.GetDefault(data.HomeID).HomeName;
                }
                return "";
            };

            this.olvColumnUser.AspectGetter = delegate(object x)
            {
                Room data = (Room)x;
                if (data != null && data.RoomID > 0)
                {
                    return User.GetDefault(data.UserID).UserName;
                }
                return "";
            };

            //Init container tree list view
            this.mListViewData.CanExpandGetter = delegate(object x)
            {
                Room data = (Room)x;
                if (data.mListSubData != null && data.mListSubData.Count > 0)
                {
                    IList<Room> mListSubData = data.mListSubData;

                    if (mListSubData.Count > 0)
                    {
                        return true;
                    }
                }

                return false;
            };

            this.mListViewData.ChildrenGetter = delegate(object x)
            {
                Room data = (Room)x;
                IList<Room> mListSubData = data.mListSubData;

                return mListSubData;
            };

            mListViewData.PrimarySortOrder = SortOrder.Ascending;

            //Init container tree list view
            this.ListViewNhomDichVu.CanExpandGetter = delegate(object x)
            {
                ThongTinDanhSachRoom data = (ThongTinDanhSachRoom)x;
                if (data.mListSubData != null && data.mListSubData.Count > 0)
                {
                    IList<ThongTinDanhSachRoom> mListSubData = data.mListSubData;
                    return data.mListSubData.Count > 0;
                }

                return false;
            };
            this.ListViewNhomDichVu.ChildrenGetter = delegate(object x)
            {
                ThongTinDanhSachRoom data = (ThongTinDanhSachRoom)x;
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
                        if (mThongTinDanhSachRoom == null || mThongTinDanhSachRoom.ThongTinDanhSachRoomID == 0)
                        {
                            UtilityListView.ListViewRefresh(ListViewNhomDichVu, mListThongTinDanhSachRoom);
                            ListViewNhomDichVu.SelectedIndex = 0;
                        }
                        else
                        {
                            UtilityListView.ListViewRefresh(ListViewNhomDichVu, mListThongTinDanhSachRoom, mThongTinDanhSachRoom.ThongTinDanhSachRoomID.ToString(), 1);
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
                        mListData_Flat = RoomPresenter.GetRooms(null, null);
                        MyVar.mListRoom = mListData_Flat;

                        //Update dữ liệu
                        mListData = new List<Room>();
                        foreach (Home nhom_khoa in MyVar.mListHome)
                        {
                            if (mListData_Flat.Any(p => p.HomeID == nhom_khoa.HomeID))
                            {
                                Room group_Room = new Room();
                                group_Room.HomeID = nhom_khoa.HomeID;
                                group_Room.RoomID = -1;
                                group_Room.RoomName = nhom_khoa.HomeName;
                                group_Room.mListSubData = mListData_Flat.Where(p => p.HomeID == nhom_khoa.HomeID).ToList();
                                mListData.Add(group_Room);
                            }
                        }

                        //Update danh sách                 
                        {
                            mListThongTinDanhSachRoom = new List<ThongTinDanhSachRoom>();
                            mListThongTinDanhSachRoom_Flat = new List<ThongTinDanhSachRoom>();
                            ThongTinDanhSachRoom.ThongTinDanhSachRoomID_Index = 1;

                            //Add tất cả khoa
                            ThongTinDanhSachRoom root = new ThongTinDanhSachRoom();
                            root.ThongTinDanhSachRoomType = (int)ThongTinDanhSachRoom.TYPE.ROOT;
                            root.mListData = mListData;
                            root.ThongTinDanhSachRoomName = "Tất Cả Phòng (" + mListData_Flat.Where(p => p.RoomID > 0).Count() + ")";
                            mListThongTinDanhSachRoom.Add(root);
                            mListThongTinDanhSachRoom_Flat.Add(root);
                        }

                        foreach (DM_Room_Group nhom_dich_vu in DM_Room_Group.GetDefaultList(0))
                        {
                            ThongTinDanhSachRoom mData = new ThongTinDanhSachRoom();
                            mData.ThongTinDanhSachRoomType = (int)ThongTinDanhSachRoom.TYPE.GROUP;
                            mData.DM_Room_GroupID = nhom_dich_vu.DM_Room_GroupID;
                            mData.mListSubData = new List<ThongTinDanhSachRoom>();
                            mData.mListData = mListData;
                            mData.ThongTinDanhSachRoomName = DM_Room_Group.GetDefault(mData.DM_Room_GroupID).DM_Room_GroupName;

                            //Add loại khoa
                            {
                                IList<DM_Room_SubGroup> list_sub = DM_Room_SubGroup.GetDefaultList_Group(0, mData.DM_Room_GroupID);
                                foreach (DM_Room_SubGroup sub_data in list_sub)
                                {
                                    ThongTinDanhSachRoom mSubData = new ThongTinDanhSachRoom();
                                    mSubData.ThongTinDanhSachRoomType = (int)ThongTinDanhSachRoom.TYPE.SUB_GROUP;
                                    mSubData.DM_Room_GroupID = mData.DM_Room_GroupID;
                                    mSubData.DM_Room_SubGroupID = sub_data.DM_Room_SubGroupID;
                                    mSubData.mListData = new List<Room>();
                                    mSubData.ThongTinDanhSachRoomName = DM_Room_SubGroup.GetDefault(mSubData.DM_Room_SubGroupID).DM_Room_SubGroupName;

                                    //Loai 
                                    if (sub_data.DM_Room_GroupID == DM_Room_Group.HOME)
                                    {
                                        int loai_khoa = sub_data.DM_Room_SubGroupID - DM_Room_SubGroup.HOME_INIT;
                                        mSubData.mListData = mListData_Flat.Where(p => p.HomeID == loai_khoa).ToList();
                                    }

                                    if (sub_data.DM_Room_GroupID == DM_Room_Group.USER)
                                    {
                                        int loai_khoa = sub_data.DM_Room_SubGroupID - DM_Room_SubGroup.USER_INIT;
                                        mSubData.mListData = mListData_Flat.Where(p => p.UserID == loai_khoa).ToList();
                                    }

                                    //Check
                                    if (mSubData.mListData.Count > 0)
                                    {
                                        mSubData.ThongTinDanhSachRoomName += " (" + mSubData.mListData.Count + ")";
                                        mData.mListSubData.Add(mSubData);
                                        mListThongTinDanhSachRoom_Flat.Add(mSubData);
                                    }
                                }
                            }

                            //Check
                            if (mData.mListData.Count > 0)
                            {
                                mListThongTinDanhSachRoom.Add(mData);
                                mListThongTinDanhSachRoom_Flat.Add(mData);
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
            Room data = mListViewData.SelectedObject as Room;
            if (data != null && data.RoomID > 0)
            {
                using (FormEditRoom form = new FormEditRoom(data, mListData_Flat))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        mRoom = form.mRoom;
                        DoRefresh();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormEditRoom form = new FormEditRoom(null, mListData_Flat))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    mRoom = form.mRoom;
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
            Room data = mListViewData.SelectedObject as Room;
            if (data != null && data.RoomID > 0)
            {
                if (SanitaMessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (RoomPresenter.DeleteRoom(data) > 0)
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
            mThongTinDanhSachRoom = ListViewNhomDichVu.SelectedObject as ThongTinDanhSachRoom;
            if (mThongTinDanhSachRoom != null)
            {
                //Refresh dịch vụ
                if (mRoom == null)
                {
                    UtilityListView.ListViewRefresh(mListViewData, mThongTinDanhSachRoom.mListData);
                }
                else
                {
                    UtilityListView.ListViewRefresh(mListViewData, mThongTinDanhSachRoom.mListData, mRoom.RoomID.ToString(), 0);
                }

                //Seach
                if (!String.IsNullOrEmpty(txtSearch.Text.Trim()) && mThongTinDanhSachRoom.mListData.Count > 0)
                {
                    UtilityListView.DoListViewFilter(mListViewData, txtSearch.Text);
                }
            }
        }

        private void ListViewNhomDichVu_FormatRow(object sender, FormatRowEventArgs e)
        {
            ThongTinDanhSachRoom data = e.Model as ThongTinDanhSachRoom;
            if (data != null)
            {
                if (data.ThongTinDanhSachRoomType == (int)ThongTinDanhSachRoom.TYPE.ROOT)
                {
                    e.Item.Font = new Font(e.Item.Font, FontStyle.Bold);
                }
                if (data.ThongTinDanhSachRoomType == (int)ThongTinDanhSachRoom.TYPE.GROUP)
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
            Room data = e.Model as Room;
            if (data != null)
            {
                if (data.RoomID < 0)
                {
                    e.Item.Font = new System.Drawing.Font(e.Item.Font, System.Drawing.FontStyle.Bold);
                }
            }
        }


    }
}