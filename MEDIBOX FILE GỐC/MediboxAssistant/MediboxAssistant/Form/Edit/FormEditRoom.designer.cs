namespace Medibox
{
    partial class FormEditRoom
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.txtUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtRoomName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtHome = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.txtHome);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.txtUser);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.txtRoomName);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(345, 216);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 32;
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.ButtonCustom.Visible = true;
            this.txtUser.FocusHighlightEnabled = true;
            this.txtUser.Location = new System.Drawing.Point(9, 35);
            this.txtUser.Name = "txtUser";
            this.txtUser.PreventEnterBeep = true;
            this.txtUser.Size = new System.Drawing.Size(327, 23);
            this.txtUser.TabIndex = 0;
            this.txtUser.ButtonCustomClick += new System.EventHandler(this.txtUser_ButtonCustomClick);
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(9, 9);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(250, 23);
            this.labelX7.TabIndex = 78;
            this.labelX7.Text = "Người dùng";
            // 
            // txtRoomName
            // 
            // 
            // 
            // 
            this.txtRoomName.Border.Class = "TextBoxBorder";
            this.txtRoomName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoomName.FocusHighlightColor = System.Drawing.Color.LightYellow;
            this.txtRoomName.FocusHighlightEnabled = true;
            this.txtRoomName.Location = new System.Drawing.Point(9, 146);
            this.txtRoomName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(327, 23);
            this.txtRoomName.TabIndex = 2;
            this.txtRoomName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(9, 119);
            this.labelX5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(253, 23);
            this.labelX5.TabIndex = 63;
            this.labelX5.Text = "Phòng";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.btnSave);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 176);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx2.Size = new System.Drawing.Size(345, 40);
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
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Image = global::MediboxAssistant.Properties.Resources.Save_32x32;
            this.btnSave.Location = new System.Drawing.Point(229, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSave.Size = new System.Drawing.Size(115, 38);
            this.btnSave.TabIndex = 100;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHome
            // 
            // 
            // 
            // 
            this.txtHome.Border.Class = "TextBoxBorder";
            this.txtHome.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHome.ButtonCustom.Visible = true;
            this.txtHome.FocusHighlightEnabled = true;
            this.txtHome.Location = new System.Drawing.Point(9, 90);
            this.txtHome.Name = "txtHome";
            this.txtHome.PreventEnterBeep = true;
            this.txtHome.Size = new System.Drawing.Size(327, 23);
            this.txtHome.TabIndex = 1;
            this.txtHome.ButtonCustomClick += new System.EventHandler(this.txtHome_ButtonCustomClick);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(9, 64);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(250, 23);
            this.labelX1.TabIndex = 83;
            this.labelX1.Text = "Home";
            // 
            // FormEditRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 216);
            this.Controls.Add(this.panelEx1);
            this.Name = "FormEditRoom";
            this.Text = "Phòng";
            this.Load += new System.EventHandler(this.Database_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRoomName;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUser;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHome;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}