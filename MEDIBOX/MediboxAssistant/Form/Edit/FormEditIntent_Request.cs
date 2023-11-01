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
    public partial class FormEditIntent_Request : FormBase
    {
        private const String TAG = "FormEditIntent_Request";
        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        public Intent_Request mIntent_Request = new Intent_Request();
        private IList<Intent_Request> mListIntent_Request = new List<Intent_Request>();

        private AutocompleteMenu mAutoMennu_DM_Intent_Type = new AutocompleteMenu();
        private AutocompleteMenu mAutoMennu_DM_Entity_Type = new AutocompleteMenu();
        private AutocompleteMenu mAutoMennu_DM_Intent_Type_Current = new AutocompleteMenu();
        private AutocompleteMenu mAutoMennu_DM_Entity_Type_Current = new AutocompleteMenu();

        private enum ProcessingType
        {
            SaveData,
        }

        public FormEditIntent_Request(Intent_Request _mIntent_Request, IList<Intent_Request> _mListIntent_Request)
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

            mIntent_Request = _mIntent_Request ?? new Intent_Request();
            mListIntent_Request = _mListIntent_Request;
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
                        if (mIntent_Request.Intent_RequestID > 0)
                        {
                            Intent_RequestPresenter.UpdateIntent_Request(mIntent_Request);
                        }
                        else
                        {
                            Intent_RequestPresenter.InsertIntent_Request(mIntent_Request);
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
            mAutoMennu_DM_Intent_Type.SetAutocompleteItems(DM_Intent_Type.GetDefaultList(0).Select(p => new AutoData(p.DM_Intent_TypeName, p.DM_Intent_TypeID.ToString())).ToList());
            mAutoMennu_DM_Intent_Type.ComboboxMode = true;
            mAutoMennu_DM_Intent_Type.MaximumSize = new System.Drawing.Size(txtType.Width - 4, 300);
            mAutoMennu_DM_Intent_Type.SetAutocompleteMenu(txtType);
            txtType.KeyDown += Control_KeyDown;

            mAutoMennu_DM_Entity_Type.SetAutocompleteItems(DM_Entity_Type.GetDefaultList(0).Select(p => new AutoData(p.DM_Entity_TypeName, p.DM_Entity_TypeID.ToString())).ToList());
            mAutoMennu_DM_Entity_Type.ComboboxMode = true;
            mAutoMennu_DM_Entity_Type.MaximumSize = new System.Drawing.Size(txtEntity.Width - 4, 300);
            mAutoMennu_DM_Entity_Type.SetAutocompleteMenu(txtEntity);
            txtEntity.KeyDown += Control_KeyDown;

            mAutoMennu_DM_Intent_Type_Current.SetAutocompleteItems(DM_Intent_Type.GetDefaultList(0).Select(p => new AutoData(p.DM_Intent_TypeName, p.DM_Intent_TypeID.ToString())).ToList());
            mAutoMennu_DM_Intent_Type_Current.ComboboxMode = true;
            mAutoMennu_DM_Intent_Type_Current.MaximumSize = new System.Drawing.Size(txtType_Current.Width - 4, 300);
            mAutoMennu_DM_Intent_Type_Current.SetAutocompleteMenu(txtType_Current);
            txtType_Current.KeyDown += Control_KeyDown;

            mAutoMennu_DM_Entity_Type_Current.SetAutocompleteItems(DM_Entity_Type.GetDefaultList(0).Select(p => new AutoData(p.DM_Entity_TypeName, p.DM_Entity_TypeID.ToString())).ToList());
            mAutoMennu_DM_Entity_Type_Current.ComboboxMode = true;
            mAutoMennu_DM_Entity_Type_Current.MaximumSize = new System.Drawing.Size(txtEntity_Current.Width - 4, 300);
            mAutoMennu_DM_Entity_Type_Current.SetAutocompleteMenu(txtEntity_Current);
            txtEntity_Current.KeyDown += Control_KeyDown;

            txtName.Text = mIntent_Request.Data;
            txtType.Text = DM_Intent_Type.GetDefault(mIntent_Request.DM_Intent_TypeID).DM_Intent_TypeName;
            txtEntity.Text = DM_Entity_Type.GetDefault(mIntent_Request.DM_Entity_TypeID).DM_Entity_TypeName;
            txtType_Current.Text = DM_Intent_Type.GetDefault(mIntent_Request.Current_DM_Intent_TypeID).DM_Intent_TypeName;
            txtEntity_Current.Text = DM_Entity_Type.GetDefault(mIntent_Request.Current_DM_Entity_TypeID).DM_Entity_TypeName;
        }

        void Control_KeyDown(object sender, KeyEventArgs e)
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
            mIntent_Request.Data = txtName.Text;
            mIntent_Request.DM_Intent_TypeID = DM_Intent_Type.GetID(txtType.Text.Trim());
            mIntent_Request.DM_Entity_TypeID = DM_Entity_Type.GetID(txtEntity.Text.Trim(), mIntent_Request.DM_Intent_TypeID);
            mIntent_Request.Current_DM_Intent_TypeID = DM_Intent_Type.GetID(txtType_Current.Text.Trim());
            mIntent_Request.Current_DM_Entity_TypeID = DM_Entity_Type.GetID(txtEntity_Current.Text.Trim(), mIntent_Request.Current_DM_Intent_TypeID);

            bwAsync_Start(ProcessingType.SaveData);
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
            int DM_Intent_TypeID = DM_Intent_Type.GetID(txtType.Text.Trim());
            if (DM_Intent_TypeID > 0)
            {
                mAutoMennu_DM_Entity_Type.SetAutocompleteItems(DM_Entity_Type.GetDefaultList(0).Where(p => p.DM_Intent_TypeID == DM_Intent_TypeID).Select(p => new AutoData(p.DM_Entity_TypeName, p.DM_Entity_TypeID.ToString())).ToList());
                mAutoMennu_DM_Entity_Type.SetAutocompleteMenu(txtEntity);
            }
        }

        private void txtType_Current_TextChanged(object sender, EventArgs e)
        {
            int DM_Intent_TypeID_Current = DM_Intent_Type.GetID(txtType_Current.Text.Trim());
            if (DM_Intent_TypeID_Current > 0)
            {
                mAutoMennu_DM_Entity_Type_Current.SetAutocompleteItems(DM_Entity_Type.GetDefaultList(0).Where(p => p.DM_Intent_TypeID == DM_Intent_TypeID_Current).Select(p => new AutoData(p.DM_Entity_TypeName, p.DM_Entity_TypeID.ToString())).ToList());
                mAutoMennu_DM_Entity_Type_Current.SetAutocompleteMenu(txtEntity_Current);
            }
        }

        private void txtType_ButtonCustomClick(object sender, EventArgs e)
        {
            mAutoMennu_DM_Intent_Type.Show(txtType, true, true);
        }

        private void txtEntity_ButtonCustomClick(object sender, EventArgs e)
        {
            mAutoMennu_DM_Entity_Type.Show(txtEntity, true, true);
        }

        private void txtType_Current_ButtonCustomClick(object sender, EventArgs e)
        {
            mAutoMennu_DM_Intent_Type_Current.Show(txtType_Current, true, true);
        }

        private void txtEntity_Current_ButtonCustomClick(object sender, EventArgs e)
        {
            mAutoMennu_DM_Entity_Type_Current.Show(txtEntity_Current, true, true);
        }

    }
}