using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ExcelDataReader;
using Medibox.Model;
using Medibox.Presenter;
using Sanita.Utility;
using Sanita.Utility.ExtendedThread;
using Sanita.Utility.UI;

namespace Medibox
{
    public partial class FormViewSanPhamWeb : FormBase
    {
        private const String TAG = "FormViewSanPhamWeb";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;

        private DateTime mLastSearch = new DateTime();

        private IList<SanPhamWeb> mListSanPhamWeb = new List<SanPhamWeb>();
        private SanPhamWeb mSanPhamWeb = new SanPhamWeb();

        private IList<SanPhamWeb> mListSanPhamDon = new List<SanPhamWeb>();
        //private IList<SanPhamWeb> mListSPAnh = new List<SanPhamWeb>();
        //private IList<SanPhamWeb> mListSP_IDSanPham = new List<SanPhamWeb>();
        private List<SanPhamWeb> mListSanPhamWebInput = new List<SanPhamWeb>();

        private enum ProcessingType
        {
            LoadData,
        }

        public FormViewSanPhamWeb()
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
                        UtilityListView.ListViewRefresh(mListViewData, mListSanPhamWeb);
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
                        mListSanPhamWeb = SanPhamWebPresenter.GetSanPhamWebs();
                        MyVar.mListSanPhamWeb = mListSanPhamWeb;

                        //tạo 2 list liên quan
                        mListSanPhamDon = XuLiSanPham(mListSanPhamWeb);
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
            SanPhamWeb data = mListViewData.SelectedObject as SanPhamWeb;
            if (data != null && data.SanPhamWebID > 0)
            {
                IList<SanPhamWeb> mlsitsanpham = mListSanPhamDon.FirstOrDefault(x => x.ID == data.ID).mListPhanLoai;
                using (FormEditSanPhamWeb form = new FormEditSanPhamWeb(data, mlsitsanpham))
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
            using (FormEditSanPhamWeb form = new FormEditSanPhamWeb(null, mListSanPhamWeb))
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
            SanPhamWeb data = mListViewData.SelectedObject as SanPhamWeb;
            if (data != null && data.SanPhamWebID > 0)
            {
                if (SanitaMessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (SanPhamWebPresenter.DeleteSanPhamWeb(data) > 0)
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
        

        private void btnImport_Click(object sender, EventArgs e)
        {
            DataTableCollection tableCollection = null;
            string nametable= "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var steam = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                            });
                            tableCollection = result.Tables;
                            nametable = tableCollection[0].TableName;
                        }
                    }
                }
            }


            try
            {
                System.Data.DataTable dt = tableCollection[nametable];
                mListSanPhamWebInput = (from DataRow dr in dt.Rows
                                        select new SanPhamWeb()
                                        {
                                            Alias = dr["Đường dẫn / Alias"].ToString(),
                                            TenSanPham = dr["Tên sản phẩm"].ToString(),
                                            NoiDung = dr["Nội dung"].ToString(),
                                            NhaCungCap = dr["Nhà cung cấp"].ToString(),
                                            Loai = dr["Loại"].ToString(),
                                            Tag = dr["Tags"].ToString(),
                                            HienThi = dr["Hiển thị"].ToString(),
                                            ThuocTinh = dr["Thuộc tính 1(Option1 Name)"].ToString(),
                                            GiaTriThuocTinh = dr["Giá trị thuộc tính 1(Option1 Value)"].ToString(),
                                            ThuocTinh2 = dr["Thuộc tính 2(Option2 Name)"].ToString(),
                                            GiaTriThuocTinh2 = dr["Giá trị thuộc tính 2(Option2 Value)"].ToString(),
                                            ThuocTinh3 = dr["Thuộc tính 3(Option3 Name)"].ToString(),
                                            GiaTriThuocTinh3 = dr["Giá trị thuộc tính 1(Option3 Value)"].ToString(),
                                            SKU = dr["Mã (SKU)"].ToString(),
                                            QuanLyKho = dr["Quản lý kho"].ToString(),
                                            SoLuong = dr["Số lượng"].ToString(),
                                            ChoPhepBan = dr["Cho phép tiếp tục mua khi hết hàng(continue/deny)"].ToString(),
                                            Variant = dr["Variant Fulfillment Service"].ToString(),
                                            Gia = dr["Giá"].ToString(),
                                            GiaSoSanh = dr["Giá so sánh"].ToString(),
                                            YeuCauVanChuyen = dr["Yêu cầu vận chuyển"].ToString(),
                                            VAT = dr["VAT"].ToString(),
                                            MaVach = dr["Mã vạch(Barcode)"].ToString(),
                                            AnhDaiDien = dr["Ảnh đại diện"].ToString(),
                                            ChuThich = dr["Chú thích ảnh"].ToString(),
                                            TheTieuDe = dr["Thẻ tiêu đề(SEO Title)"].ToString(),
                                            TheMoTa = dr["Thẻ mô tả(SEO Description)"].ToString(),
                                            CanNang = dr["Cân nặng"].ToString(),
                                            DonViCan = dr["Đơn vị cân nặng"].ToString(),
                                            AnhPhienBan = dr["Ảnh phiên bản"].ToString(),
                                            MoTaNgan = dr["Mô tả ngắn"].ToString(),
                                            ID = dr["Id sản phẩm"].ToString(),
                                            IDTuyChon = dr["Id tùy chọn"].ToString()
                                        }).ToList();

                //tạo tên phiên bản
                for (int x = 0; x < mListSanPhamWebInput.Count; x++)
                {
                    if (mListSanPhamWebInput[x].TenSanPham == "")
                    {
                        SanPhamWeb lk = mListSanPhamWebInput.FirstOrDefault(v => v.ID == mListSanPhamWebInput[x].ID);
                        mListSanPhamWebInput[x].TenPhienBan = lk.TenSanPham + " - " + mListSanPhamWebInput[x].GiaTriThuocTinh;
                    }
                    else
                    {
                        mListSanPhamWebInput[x].TenPhienBan = mListSanPhamWebInput[x].TenSanPham;
                    }
                }

                SanPhamWebPresenter.DeleteAllSanPhamWeb();
                if (SanitaMessageBox.Show("Bạn có muốn cập nhật sản phẩm web?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (SanPhamWeb _sanpham in mListSanPhamWebInput)
                    {
                        SanPhamWebPresenter.InsertSanPhamWeb(_sanpham);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
                MessageBox.Show(Ex.ToString());
            }
            
            DoRefresh();
        }

        private List<SanPhamWeb> XuLiSanPham (IList<SanPhamWeb> mListInput) //tạo list sản phẩm theo ảnh sản phẩm
        {
            List<SanPhamWeb> mListOutput = new List<SanPhamWeb>();
            for (int x = 0; x < mListInput.Count; x++)
            {
                if (mListOutput.FirstOrDefault(v => v.ID == mListInput[x].ID) == null)
                {
                    SanPhamWeb _linhkien = new SanPhamWeb();
                    _linhkien = mListInput[x];
                    _linhkien.mListLinhKien.Add(_linhkien);

                    if (!(mListInput[x].AnhDaiDien == ""))
                    {

                        _linhkien.mListAnh.Add(mListInput[x].AnhDaiDien);
                    }

                    if (!(mListInput[x].IDTuyChon == ""))
                    {

                        _linhkien.mListPhanLoai.Add(_linhkien);
                    }

                    mListOutput.Add(_linhkien);
                }
                else
                {
                    int stt = mListOutput.FindIndex(v => v.ID == mListInput[x].ID);                    
                    mListOutput[stt].mListLinhKien.Add(mListInput[x]);

                    if (!(mListInput[x].AnhDaiDien == ""))
                    {

                        mListOutput[stt].mListAnh.Add(mListInput[x].AnhDaiDien);
                    }

                    if (!(mListInput[x].IDTuyChon == ""))
                    {

                        mListOutput[stt].mListPhanLoai.Add(mListInput[x]);
                    }
                }
            }
            return mListOutput;
        }

        private void txtSearch_ButtonCustomClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "";
            }
            txtSearch.Focus();
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

        #endregion
    }
}