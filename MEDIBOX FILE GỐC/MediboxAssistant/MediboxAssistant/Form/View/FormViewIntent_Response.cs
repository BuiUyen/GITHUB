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
    public partial class FormViewIntent_Response : FormBase
    {
        private const String TAG = "FormViewIntent_Response";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private DateTime mLastSearch = new DateTime();

        private Intent_Response mIntent_Response = new Intent_Response();
        private IList<Intent_Response> mListData_Flat = new List<Intent_Response>();
        private IList<Intent_Response> mListData = new List<Intent_Response>();

        private IList<ThongTinDanhSachIntent_Response> mListThongTinDanhSachIntent_Response = new List<ThongTinDanhSachIntent_Response>();
        private IList<ThongTinDanhSachIntent_Response> mListThongTinDanhSachIntent_Response_Flat = new List<ThongTinDanhSachIntent_Response>();
        private ThongTinDanhSachIntent_Response mThongTinDanhSachIntent_Response = null;

        private enum ProcessingType
        {
            LoadData,
        }

        public FormViewIntent_Response()
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
                Intent_Response data = (Intent_Response)x;
                if (data != null && data.Intent_ResponseID > 0)
                {
                    return DM_Intent_Type.GetDefault(data.DM_Intent_TypeID).DM_Intent_TypeName;
                }
                return "";
            };

            this.olvColumnDoiTuong.AspectGetter = delegate(object x)
            {
                Intent_Response data = (Intent_Response)x;
                if (data != null && data.Intent_ResponseID > 0)
                {
                    DM_Entity_Type checkdata = DM_Entity_Type.GetDefaultList(0).FirstOrDefault(p => p.DM_Intent_TypeID == data.DM_Intent_TypeID && p.DM_Entity_TypeID == data.DM_Entity_TypeID);
                    if (checkdata != null)
                    {
                        return checkdata.DM_Entity_TypeName;
                    }
                    else
                    {
                        return "";
                    }
                }
                return "";
            };

            //Init container tree list view
            this.mListViewData.CanExpandGetter = delegate(object x)
            {
                Intent_Response data = (Intent_Response)x;
                if (data.mListSubData != null && data.mListSubData.Count > 0)
                {
                    IList<Intent_Response> mListSubData = data.mListSubData;

                    if (mListSubData.Count > 0)
                    {
                        return true;
                    }
                }

                return false;
            };

            this.mListViewData.ChildrenGetter = delegate(object x)
            {
                Intent_Response data = (Intent_Response)x;
                IList<Intent_Response> mListSubData = data.mListSubData;

                return mListSubData;
            };

            //Init container tree list view
            this.ListViewNhomDichVu.CanExpandGetter = delegate(object x)
            {
                ThongTinDanhSachIntent_Response data = (ThongTinDanhSachIntent_Response)x;
                if (data.mListSubData != null && data.mListSubData.Count > 0)
                {
                    IList<ThongTinDanhSachIntent_Response> mListSubData = data.mListSubData;
                    return data.mListSubData.Count > 0;
                }

                return false;
            };
            this.ListViewNhomDichVu.ChildrenGetter = delegate(object x)
            {
                ThongTinDanhSachIntent_Response data = (ThongTinDanhSachIntent_Response)x;
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
                        if (mThongTinDanhSachIntent_Response == null || mThongTinDanhSachIntent_Response.ThongTinDanhSachIntent_ResponseID == 0)
                        {
                            UtilityListView.ListViewRefresh(ListViewNhomDichVu, mListThongTinDanhSachIntent_Response);
                            ListViewNhomDichVu.SelectedIndex = 0;
                        }
                        else
                        {
                            UtilityListView.ListViewRefresh(ListViewNhomDichVu, mListThongTinDanhSachIntent_Response, mThongTinDanhSachIntent_Response.ThongTinDanhSachIntent_ResponseID.ToString(), 1);
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
                        mListData_Flat = Intent_ResponsePresenter.GetIntent_Responses();

                        //Update dữ liệu
                        mListData = new List<Intent_Response>();
                        foreach (DM_Intent_Type nhom in DM_Intent_Type.GetDefaultList(0))
                        {
                            if (mListData_Flat.Any(p => p.DM_Intent_TypeID == nhom.DM_Intent_TypeID))
                            {
                                Intent_Response group_Intent_Response = new Intent_Response();
                                group_Intent_Response.DM_Intent_TypeID = nhom.DM_Intent_TypeID;
                                group_Intent_Response.Intent_ResponseID = -1;
                                group_Intent_Response.Data = nhom.DM_Intent_TypeName;
                                group_Intent_Response.mListSubData = new List<Intent_Response>();
                                mListData.Add(group_Intent_Response);

                                IList<DM_Entity_Type> ListDM_Entity_Type = DM_Entity_Type.GetDefaultList(0).Where(p => p.DM_Intent_TypeID == nhom.DM_Intent_TypeID).ToList();
                                if (ListDM_Entity_Type.Count == 0)
                                {
                                    group_Intent_Response.mListSubData = mListData_Flat.Where(p => p.DM_Intent_TypeID == nhom.DM_Intent_TypeID).ToList();
                                    group_Intent_Response.mListSubData = group_Intent_Response.mListSubData.Select(p => { p.mParent = group_Intent_Response; return p; }).ToList();
                                }
                                else
                                {
                                    foreach (DM_Entity_Type loai_dichvu in ListDM_Entity_Type)
                                    {
                                        if (mListData_Flat.Any(p => p.DM_Entity_TypeID == loai_dichvu.DM_Entity_TypeID && p.DM_Intent_TypeID == loai_dichvu.DM_Intent_TypeID))
                                        {
                                            Intent_Response type_service = new Intent_Response();
                                            type_service.DM_Intent_TypeID = nhom.DM_Intent_TypeID;
                                            type_service.DM_Entity_TypeID = loai_dichvu.DM_Entity_TypeID;
                                            type_service.Intent_ResponseID = -2;
                                            type_service.Data = loai_dichvu.DM_Entity_TypeName;
                                            type_service.mListSubData = mListData_Flat.Where(p => p.DM_Entity_TypeID == loai_dichvu.DM_Entity_TypeID && p.DM_Intent_TypeID == loai_dichvu.DM_Intent_TypeID).ToList();
                                            type_service.mListSubData = type_service.mListSubData.Select(p => { p.mParent = type_service; return p; }).ToList();
                                            if (type_service.mListSubData.Count > 0)
                                            {
                                                group_Intent_Response.mListSubData.Add(type_service);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //Update danh sách                      
                        {
                            mListThongTinDanhSachIntent_Response = new List<ThongTinDanhSachIntent_Response>();
                            mListThongTinDanhSachIntent_Response_Flat = new List<ThongTinDanhSachIntent_Response>();
                            ThongTinDanhSachIntent_Response.ThongTinDanhSachIntent_ResponseID_Index = 1;

                            //Add tất cả nhóm dịch vụ
                            ThongTinDanhSachIntent_Response root = new ThongTinDanhSachIntent_Response();
                            root.ThongTinDanhSachIntent_ResponseType = (int)ThongTinDanhSachIntent_Response.TYPE.ROOT;
                            root.mListData = mListData;
                            root.ThongTinDanhSachIntent_ResponseName = String.Format("Tất cả ({0})".Translate(), mListData_Flat.Count());
                            mListThongTinDanhSachIntent_Response.Add(root);
                            mListThongTinDanhSachIntent_Response_Flat.Add(root);

                            foreach (DM_Intent_Type nhom_dich_vu in DM_Intent_Type.GetDefaultList(1))
                            {
                                Intent_Response group_service = mListData.FirstOrDefault(p => p.DM_Intent_TypeID == nhom_dich_vu.DM_Intent_TypeID && p.Intent_ResponseID == -1);
                                if (group_service != null)
                                {
                                    ThongTinDanhSachIntent_Response mData = new ThongTinDanhSachIntent_Response();
                                    mData.ThongTinDanhSachIntent_ResponseType = (int)ThongTinDanhSachIntent_Response.TYPE.GROUP;
                                    mData.DM_Intent_TypeID = nhom_dich_vu.DM_Intent_TypeID;
                                    mData.mListSubData = new List<ThongTinDanhSachIntent_Response>();
                                    mData.mListData = group_service.mListSubData;
                                    mData.ThongTinDanhSachIntent_ResponseName = DM_Intent_Type.GetDefault(mData.DM_Intent_TypeID).DM_Intent_TypeName + " (" + mListData_Flat.Where(p => p.DM_Intent_TypeID == mData.DM_Intent_TypeID).Count() + ")";
                                    mListThongTinDanhSachIntent_Response.Add(mData);
                                    mListThongTinDanhSachIntent_Response_Flat.Add(mData);

                                    //Add loại dịch vụ
                                    {
                                        IList<DM_Entity_Type> list_sub = DM_Entity_Type.GetDefaultList(0).Where(p => p.DM_Intent_TypeID == nhom_dich_vu.DM_Intent_TypeID).ToList();
                                        list_sub = list_sub.OrderBy(p => p.DM_Intent_TypeID).ThenBy(p => p.DM_Entity_TypeID).ToList();

                                        foreach (DM_Entity_Type sub_data in list_sub)
                                        {
                                            Intent_Response type_service = group_service.mListSubData.FirstOrDefault(p => p.DM_Entity_TypeID == sub_data.DM_Entity_TypeID && p.Intent_ResponseID == -2 && p.DM_Intent_TypeID == sub_data.DM_Intent_TypeID);
                                            if (type_service != null)
                                            {
                                                ThongTinDanhSachIntent_Response mSubData = new ThongTinDanhSachIntent_Response();
                                                mSubData.ThongTinDanhSachIntent_ResponseType = (int)ThongTinDanhSachIntent_Response.TYPE.SUB_GROUP;
                                                mSubData.DM_Intent_TypeID = mData.DM_Intent_TypeID;
                                                mSubData.DM_Entity_TypeID = sub_data.DM_Entity_TypeID;
                                                mSubData.mListData = group_service.mListSubData.Where(p => p.DM_Entity_TypeID == sub_data.DM_Entity_TypeID && p.DM_Intent_TypeID == sub_data.DM_Intent_TypeID).ToList();
                                                mSubData.ThongTinDanhSachIntent_ResponseName = DM_Entity_Type.GetDefault(mSubData.DM_Entity_TypeID).DM_Entity_TypeName + " (" + mListData_Flat.Where(p => p.DM_Entity_TypeID == mSubData.DM_Entity_TypeID && p.DM_Intent_TypeID == mSubData.DM_Intent_TypeID).Count() + ")";
                                                if (mSubData.mListData.Count > 0)
                                                {
                                                    mData.mListSubData.Add(mSubData);
                                                    mListThongTinDanhSachIntent_Response_Flat.Add(mSubData);
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
            Intent_Response data = mListViewData.SelectedObject as Intent_Response;
            if (data != null && data.Intent_ResponseID > 0)
            {
                using (FormEditIntent_Response form = new FormEditIntent_Response(data, mListData_Flat))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        mIntent_Response = form.mIntent_Response;
                        DoRefresh();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormEditIntent_Response form = new FormEditIntent_Response(null, mListData_Flat))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    mIntent_Response = form.mIntent_Response;
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
            Intent_Response data = mListViewData.SelectedObject as Intent_Response;
            if (data != null && data.Intent_ResponseID > 0)
            {
                if (SanitaMessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (Intent_ResponsePresenter.DeleteIntent_Response(data) > 0)
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
            mThongTinDanhSachIntent_Response = ListViewNhomDichVu.SelectedObject as ThongTinDanhSachIntent_Response;
            if (mThongTinDanhSachIntent_Response != null)
            {
                //Refresh dịch vụ
                if (mIntent_Response == null)
                {
                    UtilityListView.ListViewRefresh(mListViewData, mThongTinDanhSachIntent_Response.mListData);
                }
                else
                {
                    UtilityListView.ListViewRefresh(mListViewData, mThongTinDanhSachIntent_Response.mListData, mIntent_Response.Intent_ResponseID.ToString(), 0);
                }

                //Seach
                if (!String.IsNullOrEmpty(txtSearch.Text.Trim()) && mThongTinDanhSachIntent_Response.mListData.Count > 0)
                {
                    UtilityListView.DoListViewFilter(mListViewData, txtSearch.Text);
                }
            }
        }

        private void ListViewNhomDichVu_FormatRow(object sender, FormatRowEventArgs e)
        {
            ThongTinDanhSachIntent_Response data = e.Model as ThongTinDanhSachIntent_Response;
            if (data != null)
            {
                if (data.ThongTinDanhSachIntent_ResponseType == (int)ThongTinDanhSachIntent_Response.TYPE.ROOT)
                {
                    e.Item.Font = new Font(e.Item.Font, FontStyle.Bold);
                }
                if (data.ThongTinDanhSachIntent_ResponseType == (int)ThongTinDanhSachIntent_Response.TYPE.GROUP)
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
            Intent_Response data = e.Model as Intent_Response;
            if (data != null)
            {
                if (data.Intent_ResponseID <= 0)
                {
                    e.Item.Font = new System.Drawing.Font(e.Item.Font, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Intent_Response data = mListViewData.SelectedObject as Intent_Response;
            if (data != null && data.Intent_ResponseID > 0)
            {
                Intent_Response mDataNew = ObjectCopier.Clone(data);
                mDataNew.Intent_ResponseID = 0;
                using (FormEditIntent_Response form = new FormEditIntent_Response(mDataNew, mListData_Flat))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        mIntent_Response = form.mIntent_Response;
                        DoRefresh();
                    }
                }
            }
        }


    }
}