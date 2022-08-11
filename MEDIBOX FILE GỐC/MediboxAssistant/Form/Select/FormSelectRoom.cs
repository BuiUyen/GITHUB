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
    public partial class FormSelectRoom : FormBase
    {
        //Public
        public String ListRoomID = "";

        private IList<Room> mListRoom = new List<Room>();
        private DateTime mLastSearch = new DateTime();

        public FormSelectRoom(IList<int> list_id_selected, IList<Room> list_Room)
        {
            InitializeComponent(); this.Translate(); this.UpdateUI();
            base.DoInit();
            mListViewData.MaxDisplayNumber = -1;

            mListRoom = list_Room;
            if (list_id_selected != null)
            {
                mListRoom = mListRoom.Select(p => { p.isSelected = list_id_selected.Contains(p.RoomID); return p; }).ToList();
            }
            else
            {
                mListRoom = mListRoom.Select(p => { p.isSelected = false; return p; }).ToList();
            }

            UtilityListView.ListViewRefresh(mListViewData, mListRoom);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.F:
                    txtSearch.Focus();
                    return true;
                case Keys.Control | Keys.S:
                    btnSave_Click(this, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Control Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            IList<int> list_id = mListRoom.Where(p => p.isSelected).Select(p => p.RoomID).ToList();
            ListRoomID = String.Join(";", list_id);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FormSelecICD10_Load(object sender, EventArgs e)
        {

        }

        private void mListViewData_FormatRow(object sender, FormatRowEventArgs e)
        {
            Room data = e.Model as Room;
            if (data != null)
            {
                if (data.isSelected)
                {
                    e.Item.ForeColor = Color.Red;
                }
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
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


        private void TimerSearch_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - mLastSearch).TotalMilliseconds > 500)
            {
                UtilityListView.DoListViewFilter(mListViewData, txtSearch.Text);
                if (String.IsNullOrEmpty(txtSearch.Text))
                {
                    //txtSearch.ButtonCustom.Image = global::Medibox.Properties.Resources.Find_16;
                }
                else
                {
                    //txtSearch.ButtonCustom.Image = global::Medibox.Properties.Resources.delete_16;
                }

                TimerSearch.Enabled = false;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Room data in mListRoom)
            {
                data.isSelected = true;
            }
            UtilityListView.ListViewRefresh(mListViewData, mListRoom);
        }

        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Room data in mListRoom)
            {
                data.isSelected = false;
            }
            UtilityListView.ListViewRefresh(mListViewData, mListRoom);
        }

        #endregion
    }
}