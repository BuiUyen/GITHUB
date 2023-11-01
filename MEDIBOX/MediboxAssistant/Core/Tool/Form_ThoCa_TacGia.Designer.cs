namespace Medibox.Tool
{
    partial class Form_ThoCa_TacGia
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
            this.mWeb = new System.Windows.Forms.WebBrowser();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.lblBenhAn = new DevComponents.DotNetBar.LabelX();
            this.btnNext = new DevComponents.DotNetBar.ButtonX();
            this.CurrentTimer = new System.Windows.Forms.Timer(this.components);
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mWeb
            // 
            this.mWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mWeb.Location = new System.Drawing.Point(0, 60);
            this.mWeb.MinimumSize = new System.Drawing.Size(20, 20);
            this.mWeb.Name = "mWeb";
            this.mWeb.ScriptErrorsSuppressed = true;
            this.mWeb.Size = new System.Drawing.Size(1205, 647);
            this.mWeb.TabIndex = 2;
            this.mWeb.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.btnNext);
            this.panelEx3.Controls.Add(this.btnAdd);
            this.panelEx3.Controls.Add(this.lblBenhAn);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx3.Size = new System.Drawing.Size(1205, 60);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor2.Color = System.Drawing.SystemColors.Control;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Top;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 224;
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.Image = global::MediboxAssistant.Properties.Resources.Add_32x32;
            this.btnAdd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAdd.Location = new System.Drawing.Point(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 58);
            this.btnAdd.TabIndex = 147;
            this.btnAdd.Text = "Refresh";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.lblBenhAn.Location = new System.Drawing.Point(875, 1);
            this.lblBenhAn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblBenhAn.Name = "lblBenhAn";
            this.lblBenhAn.Size = new System.Drawing.Size(329, 58);
            this.lblBenhAn.TabIndex = 9;
            this.lblBenhAn.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnNext
            // 
            this.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNext.Image = global::MediboxAssistant.Properties.Resources.Add_32x32;
            this.btnNext.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNext.Location = new System.Drawing.Point(71, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(70, 58);
            this.btnNext.TabIndex = 148;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // CurrentTimer
            // 
            this.CurrentTimer.Enabled = true;
            this.CurrentTimer.Interval = 3000;
            this.CurrentTimer.Tick += new System.EventHandler(this.CurrentTimer_Tick);
            // 
            // Form_ThoCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 707);
            this.Controls.Add(this.mWeb);
            this.Controls.Add(this.panelEx3);
            this.Name = "Form_ThoCa";
            this.Text = "Form_ThoCa";
            this.panelEx3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser mWeb;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.LabelX lblBenhAn;
        private DevComponents.DotNetBar.ButtonX btnNext;
        private System.Windows.Forms.Timer CurrentTimer;
    }
}