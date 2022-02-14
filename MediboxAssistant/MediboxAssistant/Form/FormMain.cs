using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Medibox.Model;
using Medibox.Presenter;
using Sanita.Utility;
using Sanita.Utility.Logger;
using Sanita.Utility.SplashScreen;
using System.IO;
using System.Linq;
using Medibox.Utility;

namespace Medibox
{
    public partial class FormMain : FormBase
    {
        //Constant
        private const String TAG = "FormMain";

        //Private
        private static readonly Object lockAlert = new Object();

        #region Init

        public FormMain()
        {
            //Init control
            InitializeComponent();
            base.DoInit();
            this.Translate();
            this.UpdateUI();

            UtilityCache.mInstance.Start();
            while (!UtilityCache.mInstance.IsCacheCompleted)
            {
                System.Threading.Thread.Sleep(100);
            }

            //Init
            this.Text = "Phần mềm trợ lý ảo Medibox - " + MyVar.mAppVersion + " - " + MyVar.mAppDescription;
            CurrentTimer.Enabled = true;

            //Init form            
            txtStatusWeb_LinkClicked(null, null);

            //Load time
            CurrentTimer_Tick(null, null);

            txtLinkWeb.Text = "http://" + SystemInfo.IPAddress1 + ":" + UtilityWebServer.mInstance.WebServerPort;

            //Start timer
            UtilityUpdateTime.mInstance.Start();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
        }

        private void FormMedibox_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region MENU

        private void btnNhapDuLieuThoCa_Click(object sender, EventArgs e)
        {
            //Medibox.Tool.UtilityThoCa.mInstance.UpdateData();
            using (Medibox.Tool.Form_ThoCa_BaiThoChiTiet form = new Tool.Form_ThoCa_BaiThoChiTiet())
            {
                form.ShowDialog();
            }
        }

        private void CurrentTimer_Tick(object sender, EventArgs e)
        {

        }

        private void NOW_Timer_Tick(object sender, EventArgs e)
        {
            SystemInfo.NOW = SystemInfo.NOW.AddMilliseconds(10);
        }

        private async void txtStatusWeb_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            if (UtilityWebServer.mInstance.WebServerRunnning)
            {
                try
                {
                    await UtilityWebServer.mInstance.StopWebServer();
                }
                catch (Exception ex)
                {
                    SanitaLog.e(TAG, ex);
                }
            }
            else
            {
                try
                {
                    int num = await UtilityWebServer.mInstance.StartWebServer();
                }
                catch (Exception ex)
                {
                    SanitaLog.e(TAG, ex);
                }
            }
        }


        private void btnDanhSachThietBi_Click(object sender, EventArgs e)
        {
            using (FormViewDevice2 form = new FormViewDevice2())
            {
                form.ShowDialog();
            }
        }

        private void btnDanhSachIntent_Click(object sender, EventArgs e)
        {
            using (FormViewIntent form = new FormViewIntent())
            {
                form.ShowDialog();
            }
        }

        private void btnIntentRequest_Click(object sender, EventArgs e)
        {
            using (FormViewIntent_Request form = new FormViewIntent_Request())
            {
                form.ShowDialog();
            }
        }

        private void btnIntentResponse_Click(object sender, EventArgs e)
        {
            using (FormViewIntent_Response form = new FormViewIntent_Response())
            {
                form.ShowDialog();
            }
        }

        private void btnDSLoaiChuDe_Click(object sender, EventArgs e)
        {
            using (FormViewDM_Intent_Type form = new FormViewDM_Intent_Type())
            {
                form.ShowDialog();
            }
        }

        private void btnDSDoiTuong_Click(object sender, EventArgs e)
        {
            using (FormViewDM_Entity_Type form = new FormViewDM_Entity_Type())
            {
                form.ShowDialog();
            }
        }

        private void btnDSUser_Click(object sender, EventArgs e)
        {
            using (FormViewUser form = new FormViewUser())
            {
                form.ShowDialog();
            }
        }

        private void btnDSHome_Click(object sender, EventArgs e)
        {
            using (FormViewHome form = new FormViewHome())
            {
                form.ShowDialog();
            }
        }

        private void btnDSRoom_Click(object sender, EventArgs e)
        {
            using (FormViewRoom form = new FormViewRoom())
            {
                form.ShowDialog();
            }
        }

        private void btnSanPhamWEB_Click(object sender, EventArgs e)
        {
            using (FormViewSanPhamWeb form = new FormViewSanPhamWeb())
            {
                form.ShowDialog();
            }
        }

        #endregion
    }
}