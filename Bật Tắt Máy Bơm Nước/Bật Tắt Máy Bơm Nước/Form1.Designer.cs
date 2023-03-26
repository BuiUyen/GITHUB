namespace Bật_Tắt_Máy_Bơm_Nước
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnBatMayBom = new System.Windows.Forms.Button();
            this.btnTatMayBom = new System.Windows.Forms.Button();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBatMayBom
            // 
            this.btnBatMayBom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatMayBom.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatMayBom.Image = ((System.Drawing.Image)(resources.GetObject("btnBatMayBom.Image")));
            this.btnBatMayBom.Location = new System.Drawing.Point(80, 72);
            this.btnBatMayBom.Name = "btnBatMayBom";
            this.btnBatMayBom.Size = new System.Drawing.Size(200, 200);
            this.btnBatMayBom.TabIndex = 0;
            this.btnBatMayBom.UseVisualStyleBackColor = true;
            this.btnBatMayBom.Click += new System.EventHandler(this.btnBatMayBom_Click);
            // 
            // btnTatMayBom
            // 
            this.btnTatMayBom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTatMayBom.Image = ((System.Drawing.Image)(resources.GetObject("btnTatMayBom.Image")));
            this.btnTatMayBom.Location = new System.Drawing.Point(78, 72);
            this.btnTatMayBom.Name = "btnTatMayBom";
            this.btnTatMayBom.Size = new System.Drawing.Size(200, 200);
            this.btnTatMayBom.TabIndex = 1;
            this.btnTatMayBom.UseVisualStyleBackColor = true;
            this.btnTatMayBom.Click += new System.EventHandler(this.btnTatMayBom_Click);
            // 
            // lbThongBao
            // 
            this.lbThongBao.AutoSize = true;
            this.lbThongBao.Font = new System.Drawing.Font("SVN-Circular", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongBao.Location = new System.Drawing.Point(88, 293);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(190, 24);
            this.lbThongBao.TabIndex = 2;
            this.lbThongBao.Text = "Đã bật máy bơm!!!";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Image = global::Bật_Tắt_Máy_Bơm_Nước.Properties.Resources._1212e212;
            this.btnRefresh.Location = new System.Drawing.Point(324, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 60);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.btnTatMayBom);
            this.Controls.Add(this.btnBatMayBom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Bật Tắt Máy Bơm - Uyên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBatMayBom;
        private System.Windows.Forms.Button btnTatMayBom;
        private System.Windows.Forms.Label lbThongBao;
        private System.Windows.Forms.Button btnRefresh;
    }
}

