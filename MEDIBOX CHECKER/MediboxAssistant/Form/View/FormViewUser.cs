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
    public partial class FormViewUser : FormBase
    {
        private const String TAG = "FormViewUser";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;

        private IList<User> mListUser = new List<User>();
        private User mUser = new User();

        private String ListHomeID = "";
        private String ListRoomID = "";
        private String ListDeviceID = "";
        private enum ProcessingType
        {
            LoadData,
            PhanQuyenHome,
            PhanQuyenPhong,
            PhanQuyenThietBi,
        }

        public FormViewUser()
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
                        UtilityListView.ListViewRefresh(mListViewData, mListUser);
                    }
                    break;
                case ProcessingType.PhanQuyenHome:
                case ProcessingType.PhanQuyenPhong:
                case ProcessingType.PhanQuyenThietBi:
                    {
                        bwAsync_Start(ProcessingType.LoadData);
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
                        mListUser = UserPresenter.GetUsers(null, null);
                        MyVar.mListUser = mListUser;
                    }
                    break;
                case ProcessingType.PhanQuyenHome:
                    {
                        IList<int> _list_id = new List<int>();
                        if (!String.IsNullOrEmpty(ListHomeID))
                        {
                            foreach (String strID in ListHomeID.Split(';'))
                            {
                                int id = 0;
                                int.TryParse(strID, out id);
                                if (id > 0)
                                {
                                    _list_id.Add(id);
                                }
                            }
                        }

                        //foreach (Home home in MyVar.mListHome)
                        //{
                        //    if (_list_id.Contains(home.HomeID))
                        //    {
                        //        if (home.UserID != mUser.UserID)
                        //        {
                        //            home.UserID = mUser.UserID;
                        //            HomePresenter.UpdateHome(home);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (home.UserID == mUser.UserID)
                        //        {
                        //            home.UserID = 0;
                        //            HomePresenter.UpdateHome(home);
                        //        }
                        //    }
                        //}
                    }
                    break;
                case ProcessingType.PhanQuyenPhong:
                    {
                        IList<int> _list_id = new List<int>();
                        if (!String.IsNullOrEmpty(ListRoomID))
                        {
                            foreach (String strID in ListRoomID.Split(';'))
                            {
                                int id = 0;
                                int.TryParse(strID, out id);
                                if (id > 0)
                                {
                                    _list_id.Add(id);
                                }
                            }
                        }

                        //foreach (Room mRoom in MyVar.mListRoom)
                        //{
                        //    if (_list_id.Contains(mRoom.HomeID))
                        //    {
                        //        if (mRoom.UserID != mUser.UserID)
                        //        {
                        //            mRoom.UserID = mUser.UserID;
                        //            RoomPresenter.UpdateRoom(mRoom);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (mRoom.UserID == mUser.UserID)
                        //        {
                        //            mRoom.UserID = 0;
                        //            RoomPresenter.UpdateRoom(mRoom);
                        //        }
                        //    }
                        //}
                    }
                    break;
                case ProcessingType.PhanQuyenThietBi:
                    {
                        IList<int> _list_id = new List<int>();
                        if (!String.IsNullOrEmpty(ListDeviceID))
                        {
                            foreach (String strID in ListDeviceID.Split(';'))
                            {
                                int id = 0;
                                int.TryParse(strID, out id);
                                if (id > 0)
                                {
                                    _list_id.Add(id);
                                }
                            }
                        }

                        foreach (Device mDevice in MyVar.mListDevice)
                        {
                            if (_list_id.Contains(mDevice.HomeID))
                            {
                                if (mDevice.UserID != mUser.UserID)
                                {
                                    mDevice.UserID = mUser.UserID;
                                    DevicePresenter.UpdateDevice(mDevice);
                                }
                            }
                            else
                            {
                                if (mDevice.UserID == mUser.UserID)
                                {
                                    mDevice.UserID = 0;
                                    DevicePresenter.UpdateDevice(mDevice);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Event
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
            User data = mListViewData.SelectedObject as User;
            if (data != null && data.UserID > 0)
            {
                using (FormEditUser form = new FormEditUser(data, mListUser))
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
            using (FormEditUser form = new FormEditUser(null, mListUser))
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
            User data = mListViewData.SelectedObject as User;
            if (data != null && data.UserID > 0)
            {
                if (SanitaMessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (UserPresenter.DeleteUser(data) > 0)
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

        private void btnCauHinhHome_Click(object sender, EventArgs e)
        {
            User data = mListViewData.SelectedObject as User;
            if (data != null && data.UserID > 0)
            {
                mUser = data;
                //IList<Home> mListHome_Select = MyVar.mListHome.Where(p => p.UserID == data.UserID).ToList();
                //using (FormSelectHome form = new FormSelectHome(mListHome_Select.Select(p => p.HomeID).ToList(), MyVar.mListHome))
                //{
                //    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //    {
                //        ListHomeID = form.ListHomeID;
                //        bwAsync_Start(ProcessingType.PhanQuyenHome);
                //    }
                //}
            }
        }

        private void btnCauHinhPhong_Click(object sender, EventArgs e)
        {
            User data = mListViewData.SelectedObject as User;
            if (data != null && data.UserID > 0)
            {
                mUser = data;
                //IList<Room> mListRoom_Select = MyVar.mListRoom.Where(p => p.UserID == data.UserID).ToList();
                //using (FormSelectRoom form = new FormSelectRoom(mListRoom_Select.Select(p => p.RoomID).ToList(), MyVar.mListRoom))
                //{
                //    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //    {
                //        ListRoomID = form.ListRoomID;
                //        bwAsync_Start(ProcessingType.PhanQuyenPhong);
                //    }
                //}
            }
        }

        private void btnCauHinhThietBi_Click(object sender, EventArgs e)
        {
            User data = mListViewData.SelectedObject as User;
            if (data != null && data.UserID > 0)
            {
                mUser = data;
                IList<Device> mListDevice_Select = MyVar.mListDevice.Where(p => p.UserID == data.UserID).ToList();
                using (FormSelectDevice form = new FormSelectDevice(mListDevice_Select.Select(p => p.DeviceID).ToList(), MyVar.mListDevice))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ListDeviceID = form.ListDeviceID;
                        bwAsync_Start(ProcessingType.PhanQuyenThietBi);
                    }
                }
            }
        }

        #endregion
    }
}