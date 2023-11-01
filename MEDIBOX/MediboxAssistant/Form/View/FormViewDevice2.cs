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
    public partial class FormViewDevice2 : FormBase
    {
        private const String TAG = "FormViewDevice2";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private DateTime mLastSearch = new DateTime();

        private Device mDevice = new Device();
        private IList<Device> mListData_Flat = new List<Device>();
        private IList<Device> mListData = new List<Device>();

        private IList<ThongTinDanhSachDevice> mListThongTinDanhSachDevice = new List<ThongTinDanhSachDevice>();
        private IList<ThongTinDanhSachDevice> mListThongTinDanhSachDevice_Flat = new List<ThongTinDanhSachDevice>();
        private ThongTinDanhSachDevice mThongTinDanhSachDevice = null;

        private enum ProcessingType
        {
            LoadData,
        }

        public FormViewDevice2()
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
                Device data = (Device)x;
                if (data != null && data.DeviceID > 0)
                {
                    return Home.GetDefault(data.HomeID).HomeName;
                }
                return "";
            };
            this.olvColumnRoom.AspectGetter = delegate(object x)
            {
                Device data = (Device)x;
                if (data != null && data.DeviceID > 0)
                {
                    return Room.GetDefault(data.RoomID).RoomName;
                }
                return "";
            };
            this.olvColumnUser.AspectGetter = delegate(object x)
            {
                Device data = (Device)x;
                if (data != null && data.DeviceID > 0)
                {
                    return User.GetDefault(data.UserID).UserName;
                }
                return "";
            };

            //Init container tree list view
            this.mListViewData.CanExpandGetter = delegate(object x)
            {
                Device data = (Device)x;
                if (data.mListSubData != null && data.mListSubData.Count > 0)
                {
                    IList<Device> mListSubData = data.mListSubData;

                    if (mListSubData.Count > 0)
                    {
                        return true;
                    }
                }

                return false;
            };

            this.mListViewData.ChildrenGetter = delegate(object x)
            {
                Device data = (Device)x;
                IList<Device> mListSubData = data.mListSubData;

                return mListSubData;
            };

            mListViewData.PrimarySortOrder = SortOrder.Ascending;

            //Init container tree list view
            this.ListViewNhomDichVu.CanExpandGetter = delegate(object x)
            {
                ThongTinDanhSachDevice data = (ThongTinDanhSachDevice)x;
                if (data.mListSubData != null && data.mListSubData.Count > 0)
                {
                    IList<ThongTinDanhSachDevice> mListSubData = data.mListSubData;
                    return data.mListSubData.Count > 0;
                }

                return false;
            };
            this.ListViewNhomDichVu.ChildrenGetter = delegate(object x)
            {
                ThongTinDanhSachDevice data = (ThongTinDanhSachDevice)x;
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
                        if (mThongTinDanhSachDevice == null || mThongTinDanhSachDevice.ThongTinDanhSachDeviceID == 0)
                        {
                            UtilityListView.ListViewRefresh(ListViewNhomDichVu, mListThongTinDanhSachDevice);
                            ListViewNhomDichVu.SelectedIndex = 0;
                        }
                        else
                        {
                            UtilityListView.ListViewRefresh(ListViewNhomDichVu, mListThongTinDanhSachDevice, mThongTinDanhSachDevice.ThongTinDanhSachDeviceID.ToString(), 1);
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
                        mListData_Flat = DevicePresenter.GetDevices(null, null);
                        MyVar.mListDevice = mListData_Flat;

                        //Update dữ liệu
                        mListData = new List<Device>();
                        foreach (Home nhom in MyVar.mListHome)
                        {
                            if (mListData_Flat.Any(p => p.HomeID == nhom.HomeID))
                            {
                                Device group_Device = new Device();
                                group_Device.HomeID = nhom.HomeID;
                                group_Device.DeviceID = -1;
                                group_Device.DeviceCode = nhom.HomeName;
                                group_Device.mListSubData = new List<Device>();
                                mListData.Add(group_Device);

                                IList<Room> ListRoom = MyVar.mListRoom.Where(p => p.HomeID == nhom.HomeID).ToList();
                                if (ListRoom.Count == 0)
                                {
                                    group_Device.mListSubData = mListData_Flat.Where(p => p.HomeID == nhom.HomeID).ToList();
                                    group_Device.mListSubData = group_Device.mListSubData.Select(p => { p.mParent = group_Device; return p; }).ToList();
                                }
                                else
                                {
                                    foreach (Room mRoom in ListRoom)
                                    {
                                        if (mListData_Flat.Any(p => p.RoomID == mRoom.RoomID && p.HomeID == mRoom.HomeID))
                                        {
                                            Device type_service = new Device();
                                            type_service.HomeID = nhom.HomeID;
                                            type_service.RoomID = mRoom.RoomID;
                                            type_service.DeviceID = -2;
                                            type_service.DeviceCode = mRoom.RoomName;
                                            type_service.mListSubData = mListData_Flat.Where(p => p.RoomID == mRoom.RoomID && p.HomeID == mRoom.HomeID).ToList();
                                            type_service.mListSubData = type_service.mListSubData.Select(p => { p.mParent = type_service; return p; }).ToList();
                                            if (type_service.mListSubData.Count > 0)
                                            {
                                                group_Device.mListSubData.Add(type_service);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //Update danh sách                      
                        {
                            mListThongTinDanhSachDevice = new List<ThongTinDanhSachDevice>();
                            mListThongTinDanhSachDevice_Flat = new List<ThongTinDanhSachDevice>();
                            ThongTinDanhSachDevice.ThongTinDanhSachDeviceID_Index = 1;

                            //Add tất cả nhóm dịch vụ
                            ThongTinDanhSachDevice root = new ThongTinDanhSachDevice();
                            root.ThongTinDanhSachDeviceType = (int)ThongTinDanhSachDevice.TYPE.ROOT;
                            root.mListData = mListData;
                            root.ThongTinDanhSachDeviceName = String.Format("Tất cả Thiết Bị ({0})".Translate(), mListData_Flat.Count());
                            mListThongTinDanhSachDevice.Add(root);
                            mListThongTinDanhSachDevice_Flat.Add(root);

                            foreach (Home nhom_dich_vu in MyVar.mListHome)
                            {
                                Device group_service = mListData.FirstOrDefault(p => p.HomeID == nhom_dich_vu.HomeID && p.DeviceID == -1);
                                if (group_service != null)
                                {
                                    ThongTinDanhSachDevice mData = new ThongTinDanhSachDevice();
                                    mData.ThongTinDanhSachDeviceType = (int)ThongTinDanhSachDevice.TYPE.GROUP;
                                    mData.HomeID = nhom_dich_vu.HomeID;
                                    mData.mListSubData = new List<ThongTinDanhSachDevice>();
                                    mData.mListData = group_service.mListSubData;
                                    mData.ThongTinDanhSachDeviceName = nhom_dich_vu.HomeName + " (" + mListData_Flat.Where(p => p.HomeID == mData.HomeID).Count() + ")";
                                    mListThongTinDanhSachDevice.Add(mData);
                                    mListThongTinDanhSachDevice_Flat.Add(mData);

                                    //Add loại dịch vụ
                                    {
                                        IList<Room> list_sub = MyVar.mListRoom.Where(p => p.HomeID == nhom_dich_vu.HomeID).ToList();
                                        list_sub = list_sub.OrderBy(p => p.HomeID).ThenBy(p => p.RoomName).ToList();

                                        foreach (Room sub_data in list_sub)
                                        {
                                            Device type_service = group_service.mListSubData.FirstOrDefault(p => p.RoomID == sub_data.RoomID && p.DeviceID == -2 && p.HomeID == sub_data.HomeID);
                                            if (type_service != null)
                                            {
                                                ThongTinDanhSachDevice mSubData = new ThongTinDanhSachDevice();
                                                mSubData.ThongTinDanhSachDeviceType = (int)ThongTinDanhSachDevice.TYPE.SUB_GROUP;
                                                mSubData.HomeID = mData.HomeID;
                                                mSubData.RoomID = sub_data.RoomID;
                                                mSubData.mListData = group_service.mListSubData.Where(p => p.RoomID == sub_data.RoomID && p.HomeID == sub_data.HomeID).ToList();
                                                mSubData.ThongTinDanhSachDeviceName = sub_data.RoomName + " (" + mListData_Flat.Where(p => p.HomeID == mSubData.HomeID && p.RoomID == mSubData.RoomID).Count() + ")";
                                                if (mSubData.mListData.Count > 0)
                                                {
                                                    mData.mListSubData.Add(mSubData);
                                                    mListThongTinDanhSachDevice_Flat.Add(mSubData);
                                                }
                                            }
                                        }
                                    }
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
            Device data = mListViewData.SelectedObject as Device;
            if (data != null && data.DeviceID > 0)
            {
                using (FormEditDevice form = new FormEditDevice(data, mListData_Flat))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        mDevice = form.mDevice;
                        DoRefresh();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormEditDevice form = new FormEditDevice(null, mListData_Flat))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    mDevice = form.mDevice;
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
            Device data = mListViewData.SelectedObject as Device;
            if (data != null && data.DeviceID > 0)
            {
                if (SanitaMessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DevicePresenter.DeleteDevice(data) > 0)
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
            mThongTinDanhSachDevice = ListViewNhomDichVu.SelectedObject as ThongTinDanhSachDevice;
            if (mThongTinDanhSachDevice != null)
            {
                //Refresh dịch vụ
                if (mDevice == null)
                {
                    UtilityListView.ListViewRefresh(mListViewData, mThongTinDanhSachDevice.mListData);
                }
                else
                {
                    UtilityListView.ListViewRefresh(mListViewData, mThongTinDanhSachDevice.mListData, mDevice.DeviceID.ToString(), 0);
                }

                //Seach
                if (!String.IsNullOrEmpty(txtSearch.Text.Trim()) && mThongTinDanhSachDevice.mListData.Count > 0)
                {
                    UtilityListView.DoListViewFilter(mListViewData, txtSearch.Text);
                }
            }
        }

        private void ListViewNhomDichVu_FormatRow(object sender, FormatRowEventArgs e)
        {
            ThongTinDanhSachDevice data = e.Model as ThongTinDanhSachDevice;
            if (data != null)
            {
                if (data.ThongTinDanhSachDeviceType == (int)ThongTinDanhSachDevice.TYPE.ROOT)
                {
                    e.Item.Font = new Font(e.Item.Font, FontStyle.Bold);
                }
                if (data.ThongTinDanhSachDeviceType == (int)ThongTinDanhSachDevice.TYPE.GROUP)
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
            Device data = e.Model as Device;
            if (data != null)
            {
                if (data.DeviceID < 0)
                {
                    e.Item.Font = new System.Drawing.Font(e.Item.Font, System.Drawing.FontStyle.Bold);
                }
            }
        }


    }
}