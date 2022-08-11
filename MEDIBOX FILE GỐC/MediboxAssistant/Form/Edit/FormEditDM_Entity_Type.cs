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
    public partial class FormEditDM_Entity_Type : FormBase
    {
        private const String TAG = "FormEditDM_Entity_Type";

        public DM_Entity_Type mDM_Entity_Type = new DM_Entity_Type();

        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private IList<DM_Entity_Type> mListDM_Entity_Type = new List<DM_Entity_Type>();
        private AutocompleteMenu mAutoMennu_DM_Intent_Type = new AutocompleteMenu();

        private enum ProcessingType
        {
            SaveData,
        }

        public FormEditDM_Entity_Type(DM_Entity_Type _mDM_Entity_Type, IList<DM_Entity_Type> _mListDM_Entity_Type)
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

            mDM_Entity_Type = _mDM_Entity_Type ?? new DM_Entity_Type();
            mListDM_Entity_Type = _mListDM_Entity_Type;

            txtChuDe.Text = DM_Intent_Type.GetDefault(mDM_Entity_Type.DM_Intent_TypeID).DM_Intent_TypeName;
            txtDoiTuong.Text = mDM_Entity_Type.DM_Entity_TypeName;
            txtDisable.Checked = mDM_Entity_Type.DM_Entity_TypeDisable == 1;
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
                        if (mDM_Entity_Type.DM_Entity_TypeID > 0)
                        {
                            DM_Entity_TypePresenter.UpdateDM_Entity_Type(mDM_Entity_Type);
                        }
                        else
                        {
                            if (DM_Entity_TypePresenter.InsertDM_Entity_Type(mDM_Entity_Type) > 0)
                            {
                                //Tăng số ID lên
                                mDM_Entity_Type.DM_Entity_TypeID = mDM_Entity_Type.DM_Entity_TypeDBID + 500 + mDM_Entity_Type.DM_Intent_TypeID * 1000;
                                DM_Entity_TypePresenter.UpdateDM_Entity_Type(mDM_Entity_Type);
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
            mAutoMennu_DM_Intent_Type.SetAutocompleteItems(DM_Intent_Type.GetDefaultList(0).Select(p => new AutoData(p.DM_Intent_TypeName, p.DM_Intent_TypeID.ToString())).ToList());
            mAutoMennu_DM_Intent_Type.ComboboxMode = true;
            mAutoMennu_DM_Intent_Type.MaximumSize = new System.Drawing.Size(txtChuDe.Width - 4, 300);
            mAutoMennu_DM_Intent_Type.SetAutocompleteMenu(txtChuDe);
            txtChuDe.KeyDown += txtChuDe_KeyDown;
        }

        void txtChuDe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 0x0D)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validate
            if (String.IsNullOrEmpty(txtDoiTuong.Text.Trim()))
            {
                SanitaMessageBox.Show("Chưa nhập đối tượng !", "Thông Báo".Translate());
                txtDoiTuong.Focus();
                return;
            }

            mDM_Entity_Type.DM_Intent_TypeID = DM_Intent_Type.GetID(txtChuDe.Text.Trim());
            mDM_Entity_Type.DM_Entity_TypeName = txtDoiTuong.Text;
            mDM_Entity_Type.DM_Entity_TypeDisable = txtDisable.Checked ? 1 : 0;

            bwAsync_Start(ProcessingType.SaveData);
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 0x0D)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void txtChuDe_ButtonCustomClick(object sender, EventArgs e)
        {
            mAutoMennu_DM_Intent_Type.Show(txtChuDe, true, true);
        }



        #endregion

    }
}