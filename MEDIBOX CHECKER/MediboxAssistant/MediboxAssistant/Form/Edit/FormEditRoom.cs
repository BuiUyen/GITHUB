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
    public partial class FormEditRoom : FormBase
    {
        private const String TAG = "FormEditRoom";

        public Room mRoom = new Room();

        //Private
        private FormProgress mProgress = new FormProgress();
        private ExBackgroundWorker mThread;
        private IList<Room> mListRoom = new List<Room>();
        private AutocompleteMenu mAutoMennu_User = new AutocompleteMenu();
        private AutocompleteMenu mAutoMennu_Home = new AutocompleteMenu();

        private enum ProcessingType
        {
            SaveData,
        }

        public FormEditRoom(Room _mRoom, IList<Room> _mListRoom)
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

            mRoom = _mRoom ?? new Room();
            mListRoom = _mListRoom;

            txtRoomName.Text = mRoom.RoomName;
            txtUser.Text = User.GetDefault(mRoom.UserID).UserName;
            txtHome.Text = Home.GetDefault(mRoom.HomeID).HomeName;
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
                        if (mRoom.RoomID > 0)
                        {
                            RoomPresenter.UpdateRoom(mRoom);
                        }
                        else
                        {
                            RoomPresenter.InsertRoom(mRoom);
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
            mAutoMennu_User.SetAutocompleteItems(MyVar.mListUser.Select(p => new AutoData(p.UserName, p.UserID.ToString())).ToList());
            mAutoMennu_User.ComboboxMode = true;
            mAutoMennu_User.MaximumSize = new System.Drawing.Size(txtUser.Width - 4, 300);
            mAutoMennu_User.SetAutocompleteMenu(txtUser);
            txtUser.KeyDown += Control_KeyDown;

            mAutoMennu_Home.SetAutocompleteItems(MyVar.mListHome.Select(p => new AutoData(p.HomeName, p.HomeID.ToString())).ToList());
            mAutoMennu_Home.ComboboxMode = true;
            mAutoMennu_Home.MaximumSize = new System.Drawing.Size(txtHome.Width - 4, 300);
            mAutoMennu_Home.SetAutocompleteMenu(txtHome);
            txtHome.KeyDown += Control_KeyDown;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validate
            if (String.IsNullOrEmpty(txtRoomName.Text.Trim()))
            {
                SanitaMessageBox.Show("Chưa nhập Room !", "Thông Báo".Translate());
                txtRoomName.Focus();
                return;
            }

            if (mListRoom.Any(p => p.RoomID != mRoom.RoomID && txtRoomName.Text.Trim() == p.RoomName))
            {
                SanitaMessageBox.Show("Tên đã được sử dụng !", "Thông Báo".Translate());
                txtRoomName.Focus();
                return;
            }

            mRoom.RoomName = txtRoomName.Text;
            mRoom.UserID = User.GetID(txtUser.Text.Trim());
            mRoom.HomeID = Home.GetID(txtHome.Text.Trim());

            bwAsync_Start(ProcessingType.SaveData);
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 0x0D)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void txtUser_ButtonCustomClick(object sender, EventArgs e)
        {
            mAutoMennu_User.Show(txtUser, true, true);
        }

        private void txtHome_ButtonCustomClick(object sender, EventArgs e)
        {
            mAutoMennu_Home.Show(txtHome, true, true);
        }

    }
}