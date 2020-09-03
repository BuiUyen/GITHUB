namespace Medibox
{
    partial class FormViewRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.btnXoa = new DevComponents.DotNetBar.ButtonItem();
            this.DataProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.TimerSearch = new System.Windows.Forms.Timer(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.DichVuMenuBar = new DevComponents.DotNetBar.ContextMenuBar();
            this.DichVuMenu = new DevComponents.DotNetBar.ButtonItem();
            this.mListViewData = new Sanita.Utility.UI.TreeListView();
            this.olvColumn1 = ((Sanita.Utility.UI.OLVColumn)(new Sanita.Utility.UI.OLVColumn()));
            this.olvColumnHome = ((Sanita.Utility.UI.OLVColumn)(new Sanita.Utility.UI.OLVColumn()));
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ListViewNhomDichVu = new Sanita.Utility.UI.TreeListView();
            this.olvColumnData = ((Sanita.Utility.UI.OLVColumn)(new Sanita.Utility.UI.OLVColumn()));
            this.olvColumn8 = ((Sanita.Utility.UI.OLVColumn)(new Sanita.Utility.UI.OLVColumn()));
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.btnImport = new DevComponents.DotNetBar.ButtonItem();
            this.btnExport = new DevComponents.DotNetBar.ButtonItem();
            this.btnExit = new DevComponents.DotNetBar.ButtonItem();
            this.lblBenhAn = new DevComponents.DotNetBar.LabelX();
            this.olvColumnUser = ((Sanita.Utility.UI.OLVColumn)(new Sanita.Utility.UI.OLVColumn()));
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DichVuMenuBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mListViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListViewNhomDichVu)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelItem2
            // 
            this.labelItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.labelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.labelItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.PaddingBottom = 1;
            this.labelItem2.PaddingLeft = 10;
            this.labelItem2.PaddingTop = 1;
            this.labelItem2.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.labelItem2.Text = "Phòng";
            // 
            // btnXoa
            // 
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // DataProgress
            // 
            this.DataProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            // 
            // 
            // 
            this.DataProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DataProgress.Location = new System.Drawing.Point(3, 54);
            this.DataProgress.Name = "DataProgress";
            this.DataProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.DataProgress.ProgressColor = System.Drawing.Color.Maroon;
            this.DataProgress.ProgressTextColor = System.Drawing.Color.Maroon;
            this.DataProgress.ProgressTextFormat = "";
            this.DataProgress.ProgressTextVisible = true;
            this.DataProgress.Size = new System.Drawing.Size(50, 50);
            this.DataProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.DataProgress.TabIndex = 223;
            this.DataProgress.Value = 100;
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = true;
            this.controlContainerItem1.Control = this.DataProgress;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // TimerSearch
            // 
            this.TimerSearch.Tick += new System.EventHandler(this.TimerSearch_Tick);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.DichVuMenuBar);
            this.panelEx1.Controls.Add(this.mListViewData);
            this.panelEx1.Controls.Add(this.txtSearch);
            this.panelEx1.Controls.Add(this.ListViewNhomDichVu);
            this.panelEx1.Controls.Add(this.panelEx3);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1350, 690);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 32;
            // 
            // DichVuMenuBar
            // 
            this.DichVuMenuBar.AntiAlias = true;
            this.DichVuMenuBar.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.DichVuMenuBar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DichVuMenuBar.IsMaximized = false;
            this.DichVuMenuBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.DichVuMenu});
            this.DichVuMenuBar.Location = new System.Drawing.Point(732, 285);
            this.DichVuMenuBar.Name = "DichVuMenuBar";
            this.DichVuMenuBar.Size = new System.Drawing.Size(82, 25);
            this.DichVuMenuBar.Stretch = true;
            this.DichVuMenuBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DichVuMenuBar.TabIndex = 224;
            this.DichVuMenuBar.TabStop = false;
            // 
            // DichVuMenu
            // 
            this.DichVuMenu.AutoExpandOnClick = true;
            this.DichVuMenu.Name = "DichVuMenu";
            this.DichVuMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem2,
            this.btnXoa});
            this.DichVuMenu.Text = "Menu";
            // 
            // mListViewData
            // 
            this.mListViewData.AllColumns.Add(this.olvColumn1);
            this.mListViewData.AllColumns.Add(this.olvColumnHome);
            this.mListViewData.AllColumns.Add(this.olvColumnUser);
            this.mListViewData.AlternateRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.mListViewData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mListViewData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mListViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumnHome,
            this.olvColumnUser});
            this.DichVuMenuBar.SetContextMenuEx(this.mListViewData, this.DichVuMenu);
            this.mListViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mListViewData.FullRowSelect = true;
            this.mListViewData.GridLines = true;
            this.mListViewData.HideSelection = false;
            this.mListViewData.Location = new System.Drawing.Point(265, 87);
            this.mListViewData.Name = "mListViewData";
            this.mListViewData.OwnerDraw = true;
            this.mListViewData.ShowGroups = false;
            this.mListViewData.Size = new System.Drawing.Size(1085, 603);
            this.mListViewData.TabIndex = 229;
            this.mListViewData.UseAlternatingBackColors = true;
            this.mListViewData.UseCompatibleStateImageBehavior = false;
            this.mListViewData.UseFiltering = true;
            this.mListViewData.View = System.Windows.Forms.View.Details;
            this.mListViewData.VirtualMode = true;
            this.mListViewData.FormatRow += new System.EventHandler<Sanita.Utility.UI.FormatRowEventArgs>(this.mListViewData_FormatRow);
            this.mListViewData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mListViewData_MouseDoubleClick);
            this.mListViewData.Resize += new System.EventHandler(this.mListViewData_Resize);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "RoomName";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "Phòng";
            this.olvColumn1.Width = 300;
            // 
            // olvColumnHome
            // 
            this.olvColumnHome.AspectName = "";
            this.olvColumnHome.CellPadding = null;
            this.olvColumnHome.Text = "Home";
            this.olvColumnHome.Width = 200;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.txtSearch.Border.BorderLeftWidth = -1;
            this.txtSearch.Border.BorderRightWidth = -1;
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.ButtonCustom.Visible = true;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.FocusHighlightEnabled = true;
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(265, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(1085, 27);
            this.txtSearch.TabIndex = 231;
            this.txtSearch.WatermarkColor = System.Drawing.Color.DimGray;
            this.txtSearch.WatermarkText = "Tìm kiếm (Ctrl+F)";
            this.txtSearch.ButtonCustomClick += new System.EventHandler(this.txtSearch_ButtonCustomClick);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ListViewNhomDichVu
            // 
            this.ListViewNhomDichVu.AllColumns.Add(this.olvColumnData);
            this.ListViewNhomDichVu.AllColumns.Add(this.olvColumn8);
            this.ListViewNhomDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ListViewNhomDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListViewNhomDichVu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnData,
            this.olvColumn8});
            this.ListViewNhomDichVu.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListViewNhomDichVu.FullRowSelect = true;
            this.ListViewNhomDichVu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewNhomDichVu.HideSelection = false;
            this.ListViewNhomDichVu.Location = new System.Drawing.Point(0, 60);
            this.ListViewNhomDichVu.Name = "ListViewNhomDichVu";
            this.ListViewNhomDichVu.OwnerDraw = true;
            this.ListViewNhomDichVu.ShowGroups = false;
            this.ListViewNhomDichVu.Size = new System.Drawing.Size(265, 630);
            this.ListViewNhomDichVu.TabIndex = 230;
            this.ListViewNhomDichVu.UnfocusedHighlightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ListViewNhomDichVu.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.ListViewNhomDichVu.UseCompatibleStateImageBehavior = false;
            this.ListViewNhomDichVu.UseFiltering = true;
            this.ListViewNhomDichVu.View = System.Windows.Forms.View.Details;
            this.ListViewNhomDichVu.VirtualMode = true;
            this.ListViewNhomDichVu.FormatRow += new System.EventHandler<Sanita.Utility.UI.FormatRowEventArgs>(this.ListViewNhomDichVu_FormatRow);
            this.ListViewNhomDichVu.SelectedIndexChanged += new System.EventHandler(this.ListViewNhomDichVu_SelectedIndexChanged);
            // 
            // olvColumnData
            // 
            this.olvColumnData.AspectName = "ThongTinDanhSachRoomName";
            this.olvColumnData.CellPadding = null;
            this.olvColumnData.Text = "Nội Dung";
            this.olvColumnData.Width = 265;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "ThongTinDanhSachRoomID";
            this.olvColumn8.CellPadding = null;
            this.olvColumn8.Text = "ID";
            this.olvColumn8.Width = 0;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.btnAdd);
            this.panelEx3.Controls.Add(this.btnRefresh);
            this.panelEx3.Controls.Add(this.buttonX1);
            this.panelEx3.Controls.Add(this.lblBenhAn);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx3.Size = new System.Drawing.Size(1350, 60);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor2.Color = System.Drawing.SystemColors.Control;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Top;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 220;
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.Image = global::MediboxAssistant.Properties.Resources.Add_32x32;
            this.btnAdd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAdd.Location = new System.Drawing.Point(120, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 58);
            this.btnAdd.TabIndex = 147;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Image = global::MediboxAssistant.Properties.Resources.Refresh_32__1_;
            this.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefresh.Location = new System.Drawing.Point(50, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 58);
            this.btnRefresh.TabIndex = 148;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.AutoExpandOnClick = true;
            this.buttonX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonX1.Location = new System.Drawing.Point(1, 1);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.ShowSubItems = false;
            this.buttonX1.Size = new System.Drawing.Size(49, 58);
            this.buttonX1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.btnImport,
            this.btnExport,
            this.btnExit});
            this.buttonX1.TabIndex = 146;
            this.buttonX1.Visible = false;
            // 
            // labelItem1
            // 
            this.labelItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.labelItem1.ForeColor = System.Drawing.Color.Black;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.PaddingBottom = 3;
            this.labelItem1.PaddingLeft = 10;
            this.labelItem1.PaddingTop = 3;
            this.labelItem1.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.labelItem1.Text = "File";
            // 
            // btnImport
            // 
            this.btnImport.GlobalItem = false;
            this.btnImport.Name = "btnImport";
            this.btnImport.Text = "Thêm Từ File Excel";
            // 
            // btnExport
            // 
            this.btnExport.GlobalItem = false;
            this.btnExport.Name = "btnExport";
            this.btnExport.Text = "Xuất File Excel";
            // 
            // btnExit
            // 
            this.btnExit.BeginGroup = true;
            this.btnExit.GlobalItem = false;
            this.btnExit.Name = "btnExit";
            this.btnExit.Text = "Đóng";
            // 
            // lblBenhAn
            // 
            // 
            // 
            // 
            this.lblBenhAn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBenhAn.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBenhAn.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBenhAn.ForeColor = System.Drawing.Color.Maroon;
            this.lblBenhAn.Location = new System.Drawing.Point(1020, 1);
            this.lblBenhAn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblBenhAn.Name = "lblBenhAn";
            this.lblBenhAn.Size = new System.Drawing.Size(329, 58);
            this.lblBenhAn.TabIndex = 9;
            this.lblBenhAn.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // olvColumnUser
            // 
            this.olvColumnUser.CellPadding = null;
            this.olvColumnUser.Text = "Quản Lý";
            this.olvColumnUser.Width = 200;
            // 
            // FormViewRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 690);
            this.Controls.Add(this.panelEx1);
            this.Name = "FormViewRoom";
            this.Text = "Danh Sách Phòng";
            this.Load += new System.EventHandler(this.Database_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DichVuMenuBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mListViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListViewNhomDichVu)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnRefresh;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ButtonItem btnImport;
        private DevComponents.DotNetBar.ButtonItem btnExport;
        private DevComponents.DotNetBar.ButtonItem btnExit;
        private DevComponents.DotNetBar.LabelX lblBenhAn;
        private DevComponents.DotNetBar.ContextMenuBar DichVuMenuBar;
        private DevComponents.DotNetBar.ButtonItem DichVuMenu;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.ButtonItem btnXoa;
        private DevComponents.DotNetBar.Controls.CircularProgress DataProgress;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private Sanita.Utility.UI.TreeListView mListViewData;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private Sanita.Utility.UI.TreeListView ListViewNhomDichVu;
        private Sanita.Utility.UI.OLVColumn olvColumnData;
        private Sanita.Utility.UI.OLVColumn olvColumn8;
        private Sanita.Utility.UI.OLVColumn olvColumnHome;
        private System.Windows.Forms.Timer TimerSearch;
        private Sanita.Utility.UI.OLVColumn olvColumn1;
        private Sanita.Utility.UI.OLVColumn olvColumnUser;
    }
}