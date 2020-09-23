namespace Phan_mem_ban_hang_linh_kien
{
    partial class FormMatKhauQuanLiTaiKhoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.btnXacNhanMatKhau = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xác nhận lại mật khẩu:";
            // 
            // tbxXacNhanMatKhau
            // 
            this.tbxXacNhanMatKhau.Location = new System.Drawing.Point(170, 24);
            this.tbxXacNhanMatKhau.Name = "tbxXacNhanMatKhau";
            this.tbxXacNhanMatKhau.PasswordChar = '*';
            this.tbxXacNhanMatKhau.Size = new System.Drawing.Size(260, 22);
            this.tbxXacNhanMatKhau.TabIndex = 0;
            this.tbxXacNhanMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxXacNhanMatKhau_KeyDown);
            // 
            // btnXacNhanMatKhau
            // 
            this.btnXacNhanMatKhau.Location = new System.Drawing.Point(456, 18);
            this.btnXacNhanMatKhau.Name = "btnXacNhanMatKhau";
            this.btnXacNhanMatKhau.Size = new System.Drawing.Size(104, 34);
            this.btnXacNhanMatKhau.TabIndex = 1;
            this.btnXacNhanMatKhau.Text = "Xác nhận";
            this.btnXacNhanMatKhau.UseVisualStyleBackColor = true;
            this.btnXacNhanMatKhau.Click += new System.EventHandler(this.btnXacNhanMatKhau_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(486, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Liên hệ: Uyên Đẹp Zai";
            // 
            // FormMatKhauQuanLiTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 92);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXacNhanMatKhau);
            this.Controls.Add(this.tbxXacNhanMatKhau);
            this.Controls.Add(this.label1);
            this.Name = "FormMatKhauQuanLiTaiKhoan";
            this.Text = "Xác nhận mật khẩu tài khoản Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxXacNhanMatKhau;
        private System.Windows.Forms.Button btnXacNhanMatKhau;
        private System.Windows.Forms.Label label2;
    }
}