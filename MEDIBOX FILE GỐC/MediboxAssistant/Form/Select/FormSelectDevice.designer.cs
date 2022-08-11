namespace Medibox
{
    partial class FormSelectDevice
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.mListViewData = new Sanita.Utility.UI.ObjectListView();
            this.olvColumn3 = ((Sanita.Utility.UI.OLVColumn)(new Sanita.Utility.UI.OLVColumn()));
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.btnUnSelectAll = new DevComponents.DotNetBar.ButtonX();
            this.btnSelectAll = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.olvColumn1 = ((Sanita.Utility.UI.OLVColumn)(new Sanita.Utility.UI.OLVColumn()));
            this.olvColumn2 = ((Sanita.Utility.UI.OLVColumn)(new Sanita.Utility.UI.OLVColumn()));
            this.TimerSearch = new System.Windows.Forms.Timer(this.components);
            this.olvColumn4 = ((Sanita.Utility.UI.OLVColumn)(new Sanita.Utility.UI.OLVColumn()));
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mListViewData)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.mListViewData);
            this.panelEx1.Controls.Add(this.txtSearch);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(664, 562);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 32;
            // 
            // mListViewData
            // 
            this.mListViewData.AllColumns.Add(this.olvColumn4);
            this.mListViewData.AllColumns.Add(this.olvColumn3);
            this.mListViewData.AlternateRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.mListViewData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mListViewData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mListViewData.CheckBoxes = true;
            this.mListViewData.CheckedAspectName = "isSelected";
            this.mListViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn4,
            this.olvColumn3});
            this.mListViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mListViewData.FullRowSelect = true;
            this.mListViewData.GridLines = true;
            this.mListViewData.HideSelection = false;
            this.mListViewData.Location = new System.Drawing.Point(0, 27);
            this.mListViewData.MenuLabelSortAscending = "Sắp xếp tăng dần theo \'{0}\'";
            this.mListViewData.Name = "mListViewData";
            this.mListViewData.ShowGroups = false;
            this.mListViewData.Size = new System.Drawing.Size(664, 495);
            this.mListViewData.TabIndex = 210;
            this.mListViewData.UseAlternatingBackColors = true;
            this.mListViewData.UseCompatibleStateImageBehavior = false;
            this.mListViewData.UseFiltering = true;
            this.mListViewData.View = System.Windows.Forms.View.Details;
            this.mListViewData.FormatRow += new System.EventHandler<Sanita.Utility.UI.FormatRowEventArgs>(this.mListViewData_FormatRow);
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "DeviceName";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.FillsFreeSpace = true;
            this.olvColumn3.Text = "Tên Thiết Bị";
            this.olvColumn3.Width = 400;
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
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(664, 27);
            this.txtSearch.TabIndex = 211;
            this.txtSearch.WatermarkColor = System.Drawing.Color.DimGray;
            this.txtSearch.WatermarkText = "Tìm kiếm (Ctrl+F)";
            this.txtSearch.ButtonCustomClick += new System.EventHandler(this.txtSearch_ButtonCustomClick);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.btnUnSelectAll);
            this.panelEx2.Controls.Add(this.btnSelectAll);
            this.panelEx2.Controls.Add(this.btnSave);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 522);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx2.Size = new System.Drawing.Size(664, 40);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Top;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 52;
            // 
            // btnUnSelectAll
            // 
            this.btnUnSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnUnSelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnSelectAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUnSelectAll.Image = global::MediboxAssistant.Properties.Resources.Cancel_32x32;
            this.btnUnSelectAll.Location = new System.Drawing.Point(126, 1);
            this.btnUnSelectAll.Name = "btnUnSelectAll";
            this.btnUnSelectAll.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnUnSelectAll.Size = new System.Drawing.Size(150, 38);
            this.btnUnSelectAll.TabIndex = 102;
            this.btnUnSelectAll.Text = "Bỏ Chọn Tất Cả";
            this.btnUnSelectAll.Click += new System.EventHandler(this.btnUnSelectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnSelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSelectAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectAll.Image = global::MediboxAssistant.Properties.Resources.Apply_32x322;
            this.btnSelectAll.Location = new System.Drawing.Point(1, 1);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSelectAll.Size = new System.Drawing.Size(125, 38);
            this.btnSelectAll.TabIndex = 101;
            this.btnSelectAll.Text = "Chọn Tất Cả";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Image = global::MediboxAssistant.Properties.Resources.Save_32x32;
            this.btnSave.Location = new System.Drawing.Point(548, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSave.Size = new System.Drawing.Size(115, 38);
            this.btnSave.TabIndex = 100;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // olvColumn1
            // 
            this.olvColumn1.CellPadding = null;
            // 
            // olvColumn2
            // 
            this.olvColumn2.CellPadding = null;
            // 
            // TimerSearch
            // 
            this.TimerSearch.Tick += new System.EventHandler(this.TimerSearch_Tick);
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "DeviceCode";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.Text = "Mã Thiết Bị";
            this.olvColumn4.Width = 150;
            // 
            // FormSelectDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 562);
            this.Controls.Add(this.panelEx1);
            this.Name = "FormSelectDevice";
            this.Text = "Chọn Thiết Bị";
            this.Load += new System.EventHandler(this.FormSelecICD10_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mListViewData)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private Sanita.Utility.UI.ObjectListView mListViewData;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private Sanita.Utility.UI.OLVColumn olvColumn1;
        private Sanita.Utility.UI.OLVColumn olvColumn2;
        private DevComponents.DotNetBar.ButtonX btnUnSelectAll;
        private DevComponents.DotNetBar.ButtonX btnSelectAll;
        private System.Windows.Forms.Timer TimerSearch;
        private Sanita.Utility.UI.OLVColumn olvColumn3;
        private Sanita.Utility.UI.OLVColumn olvColumn4;
    }
}