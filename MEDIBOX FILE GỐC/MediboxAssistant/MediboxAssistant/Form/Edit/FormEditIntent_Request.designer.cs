namespace Medibox
{
    partial class FormEditIntent_Request
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
            this.txtEntity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtEntity_Current = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtType_Current = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.txtEntity_Current);
            this.panelEx1.Controls.Add(this.txtType_Current);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.txtEntity);
            this.panelEx1.Controls.Add(this.txtType);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.txtName);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.panelEx2);
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
            // txtEntity
            // 
            // 
            // 
            // 
            this.txtEntity.Border.Class = "TextBoxBorder";
            this.txtEntity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEntity.ButtonCustom.Visible = true;
            this.txtEntity.FocusHighlightEnabled = true;
            this.txtEntity.Location = new System.Drawing.Point(379, 34);
            this.txtEntity.Name = "txtEntity";
            this.txtEntity.PreventEnterBeep = true;
            this.txtEntity.Size = new System.Drawing.Size(959, 23);
            this.txtEntity.TabIndex = 1;
            this.txtEntity.ButtonCustomClick += new System.EventHandler(this.txtEntity_ButtonCustomClick);
            // 
            // txtType
            // 
            // 
            // 
            // 
            this.txtType.Border.Class = "TextBoxBorder";
            this.txtType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtType.ButtonCustom.Visible = true;
            this.txtType.FocusHighlightEnabled = true;
            this.txtType.Location = new System.Drawing.Point(8, 34);
            this.txtType.Name = "txtType";
            this.txtType.PreventEnterBeep = true;
            this.txtType.Size = new System.Drawing.Size(365, 23);
            this.txtType.TabIndex = 0;
            this.txtType.ButtonCustomClick += new System.EventHandler(this.txtType_ButtonCustomClick);
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(379, 8);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(250, 23);
            this.labelX1.TabIndex = 82;
            this.labelX1.Text = "Đối tượng";
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.Location = new System.Drawing.Point(8, 147);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.PreventEnterBeep = true;
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtName.Size = new System.Drawing.Size(1330, 493);
            this.txtName.TabIndex = 4;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(8, 119);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(250, 23);
            this.labelX6.TabIndex = 77;
            this.labelX6.Text = "Nội dung";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(8, 8);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(250, 23);
            this.labelX7.TabIndex = 76;
            this.labelX7.Text = "Chủ đề";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.btnSave);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 650);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx2.Size = new System.Drawing.Size(1350, 40);
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
            this.btnSave.Location = new System.Drawing.Point(1234, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSave.Size = new System.Drawing.Size(115, 38);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtEntity_Current
            // 
            // 
            // 
            // 
            this.txtEntity_Current.Border.Class = "TextBoxBorder";
            this.txtEntity_Current.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEntity_Current.ButtonCustom.Visible = true;
            this.txtEntity_Current.FocusHighlightEnabled = true;
            this.txtEntity_Current.Location = new System.Drawing.Point(379, 88);
            this.txtEntity_Current.Name = "txtEntity_Current";
            this.txtEntity_Current.PreventEnterBeep = true;
            this.txtEntity_Current.Size = new System.Drawing.Size(959, 23);
            this.txtEntity_Current.TabIndex = 3;
            this.txtEntity_Current.ButtonCustomClick += new System.EventHandler(this.txtEntity_Current_ButtonCustomClick);
            // 
            // txtType_Current
            // 
            // 
            // 
            // 
            this.txtType_Current.Border.Class = "TextBoxBorder";
            this.txtType_Current.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtType_Current.ButtonCustom.Visible = true;
            this.txtType_Current.FocusHighlightEnabled = true;
            this.txtType_Current.Location = new System.Drawing.Point(8, 88);
            this.txtType_Current.Name = "txtType_Current";
            this.txtType_Current.PreventEnterBeep = true;
            this.txtType_Current.Size = new System.Drawing.Size(365, 23);
            this.txtType_Current.TabIndex = 2;
            this.txtType_Current.ButtonCustomClick += new System.EventHandler(this.txtType_Current_ButtonCustomClick);
            this.txtType_Current.TextChanged += new System.EventHandler(this.txtType_Current_TextChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(379, 62);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(250, 23);
            this.labelX2.TabIndex = 89;
            this.labelX2.Text = "Đối tượng hiện taị";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(8, 62);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(250, 23);
            this.labelX3.TabIndex = 88;
            this.labelX3.Text = "Chủ đề hiện tại";
            // 
            // FormEditIntent_Request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 690);
            this.Controls.Add(this.panelEx1);
            this.Name = "FormEditIntent_Request";
            this.Text = "Intent Request";
            this.Load += new System.EventHandler(this.Database_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtType;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEntity;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEntity_Current;
        private DevComponents.DotNetBar.Controls.TextBoxX txtType_Current;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}