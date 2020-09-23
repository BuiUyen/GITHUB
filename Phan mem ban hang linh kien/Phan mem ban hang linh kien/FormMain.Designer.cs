namespace Phan_mem_ban_hang_linh_kien
{
    partial class FormMain
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
            this.btnQuanLiTaiKhoan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuanLiTaiKhoan
            // 
            this.btnQuanLiTaiKhoan.Location = new System.Drawing.Point(1125, 12);
            this.btnQuanLiTaiKhoan.Name = "btnQuanLiTaiKhoan";
            this.btnQuanLiTaiKhoan.Size = new System.Drawing.Size(125, 28);
            this.btnQuanLiTaiKhoan.TabIndex = 0;
            this.btnQuanLiTaiKhoan.Text = "Quản lí tài khoản";
            this.btnQuanLiTaiKhoan.UseVisualStyleBackColor = true;
            this.btnQuanLiTaiKhoan.Click += new System.EventHandler(this.btnQuanLiTaiKhoan_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 858);
            this.Controls.Add(this.btnQuanLiTaiKhoan);
            this.Name = "FormMain";
            this.Text = "Phần Mềm Bán Hàng";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuanLiTaiKhoan;
    }
}

