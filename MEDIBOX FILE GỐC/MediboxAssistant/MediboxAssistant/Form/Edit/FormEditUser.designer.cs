namespace Medibox
{
    partial class FormEditUser
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
            this.txtUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtAPIKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPassword = new DevComponents.DotNetBar.LabelX();
            this.txtLatitude = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.txtHassIO_KEY = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txtHassIO_URL = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLongitude = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUserCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtLocaltionName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.FocusHighlightColor = System.Drawing.Color.LightYellow;
            this.txtUserName.FocusHighlightEnabled = true;
            this.txtUserName.Location = new System.Drawing.Point(350, 34);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(327, 23);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(350, 7);
            this.labelX3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(101, 23);
            this.labelX3.TabIndex = 20;
            this.labelX3.Text = "Tên người dùng";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(350, 61);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(101, 23);
            this.labelX2.TabIndex = 19;
            this.labelX2.Text = "APIKey";
            // 
            // txtAPIKey
            // 
            // 
            // 
            // 
            this.txtAPIKey.Border.Class = "TextBoxBorder";
            this.txtAPIKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAPIKey.FocusHighlightColor = System.Drawing.Color.LightYellow;
            this.txtAPIKey.FocusHighlightEnabled = true;
            this.txtAPIKey.Location = new System.Drawing.Point(350, 88);
            this.txtAPIKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(327, 23);
            this.txtAPIKey.TabIndex = 3;
            this.txtAPIKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.txtPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.Location = new System.Drawing.Point(8, 169);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(101, 23);
            this.txtPassword.TabIndex = 19;
            this.txtPassword.Text = "Kinh độ";
            // 
            // txtLatitude
            // 
            // 
            // 
            // 
            this.txtLatitude.Border.Class = "TextBoxBorder";
            this.txtLatitude.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLatitude.FocusHighlightColor = System.Drawing.Color.LightYellow;
            this.txtLatitude.FocusHighlightEnabled = true;
            this.txtLatitude.Location = new System.Drawing.Point(8, 196);
            this.txtLatitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(327, 23);
            this.txtLatitude.TabIndex = 5;
            this.txtLatitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.txtHassIO_KEY);
            this.panelEx1.Controls.Add(this.labelX8);
            this.panelEx1.Controls.Add(this.txtHassIO_URL);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.txtPass);
            this.panelEx1.Controls.Add(this.txtLongitude);
            this.panelEx1.Controls.Add(this.txtUserCode);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.txtLocaltionName);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Controls.Add(this.txtUserName);
            this.panelEx1.Controls.Add(this.txtLatitude);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.txtPassword);
            this.panelEx1.Controls.Add(this.txtAPIKey);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(686, 324);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 32;
            // 
            // txtHassIO_KEY
            // 
            // 
            // 
            // 
            this.txtHassIO_KEY.Border.Class = "TextBoxBorder";
            this.txtHassIO_KEY.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHassIO_KEY.FocusHighlightColor = System.Drawing.Color.LightYellow;
            this.txtHassIO_KEY.FocusHighlightEnabled = true;
            this.txtHassIO_KEY.Location = new System.Drawing.Point(350, 252);
            this.txtHassIO_KEY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHassIO_KEY.Name = "txtHassIO_KEY";
            this.txtHassIO_KEY.Size = new System.Drawing.Size(327, 23);
            this.txtHassIO_KEY.TabIndex = 9;
            this.txtHassIO_KEY.UseSystemPasswordChar = true;
            this.txtHassIO_KEY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(350, 225);
            this.labelX8.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(101, 23);
            this.labelX8.TabIndex = 70;
            this.labelX8.Text = "HassIO_KEY";
            // 
            // txtHassIO_URL
            // 
            // 
            // 
            // 
            this.txtHassIO_URL.Border.Class = "TextBoxBorder";
            this.txtHassIO_URL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHassIO_URL.FocusHighlightColor = System.Drawing.Color.LightYellow;
            this.txtHassIO_URL.FocusHighlightEnabled = true;
            this.txtHassIO_URL.Location = new System.Drawing.Point(8, 252);
            this.txtHassIO_URL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHassIO_URL.Name = "txtHassIO_URL";
            this.txtHassIO_URL.Size = new System.Drawing.Size(327, 23);
            this.txtHassIO_URL.TabIndex = 7;
            this.txtHassIO_URL.UseSystemPasswordChar = true;
            this.txtHassIO_URL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(8, 225);
            this.labelX7.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(101, 23);
            this.labelX7.TabIndex = 65;
            this.labelX7.Text = "HassIO_URL";
            // 
            // txtPass
            // 
            // 
            // 
            // 
            this.txtPass.Border.Class = "TextBoxBorder";
            this.txtPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass.FocusHighlightColor = System.Drawing.Color.LightYellow;
            this.txtPass.FocusHighlightEnabled = true;
            this.txtPass.Location = new System.Drawing.Point(8, 88);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(327, 23);
            this.txtPass.TabIndex = 2;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // txtLongitude
            // 
            // 
            // 
            // 
            this.txtLongitude.Border.Class = "TextBoxBorder";
            this.txtLongitude.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLongitude.FocusHighlightColor = System.Drawing.Color.LightYellow;
            this.txtLongitude.FocusHighlightEnabled = true;
            this.txtLongitude.Location = new System.Drawing.Point(350, 196);
            this.txtLongitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(327, 23);
            this.txtLongitude.TabIndex = 6;
            this.txtLongitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // txtUserCode
            // 
            // 
            // 
            // 
            this.txtUserCode.Border.Class = "TextBoxBorder";
            this.txtUserCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserCode.FocusHighlightColor = System.Drawing.Color.LightYellow;
            this.txtUserCode.FocusHighlightEnabled = true;
            this.txtUserCode.Location = new System.Drawing.Point(8, 34);
            this.txtUserCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(327, 23);
            this.txtUserCode.TabIndex = 0;
            this.txtUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(8, 61);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(101, 23);
            this.labelX1.TabIndex = 62;
            this.labelX1.Text = "Mật khẩu";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(350, 169);
            this.labelX4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(101, 23);
            this.labelX4.TabIndex = 60;
            this.labelX4.Text = "Vĩ độ";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(8, 7);
            this.labelX5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(253, 23);
            this.labelX5.TabIndex = 63;
            this.labelX5.Text = "Mã người dùng";
            // 
            // txtLocaltionName
            // 
            // 
            // 
            // 
            this.txtLocaltionName.Border.Class = "TextBoxBorder";
            this.txtLocaltionName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLocaltionName.FocusHighlightColor = System.Drawing.Color.LightYellow;
            this.txtLocaltionName.FocusHighlightEnabled = true;
            this.txtLocaltionName.Location = new System.Drawing.Point(8, 142);
            this.txtLocaltionName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLocaltionName.Name = "txtLocaltionName";
            this.txtLocaltionName.Size = new System.Drawing.Size(669, 23);
            this.txtLocaltionName.TabIndex = 4;
            this.txtLocaltionName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(8, 115);
            this.labelX6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(101, 23);
            this.labelX6.TabIndex = 61;
            this.labelX6.Text = "Địa chỉ";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.btnSave);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 284);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx2.Size = new System.Drawing.Size(686, 40);
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
            this.btnSave.Location = new System.Drawing.Point(570, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSave.Size = new System.Drawing.Size(115, 38);
            this.btnSave.TabIndex = 100;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 324);
            this.Controls.Add(this.panelEx1);
            this.Name = "FormEditUser";
            this.Text = "Cập Nhật Người Dùng";
            this.Load += new System.EventHandler(this.Database_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtUserName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAPIKey;
        private DevComponents.DotNetBar.LabelX txtPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLatitude;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHassIO_URL;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLongitude;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserCode;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLocaltionName;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHassIO_KEY;
        private DevComponents.DotNetBar.LabelX labelX8;
    }
}