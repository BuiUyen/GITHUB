namespace TEST_Conect_POSTGRESS_SQL
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
            this.button1 = new System.Windows.Forms.Button();
            this.tbxDiaChiMayChu = new System.Windows.Forms.TextBox();
            this.tbxTenDangNhap = new System.Windows.Forms.TextBox();
            this.tbxMatKhau = new System.Windows.Forms.TextBox();
            this.tbxTenCoSoDuLieu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(571, 168);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 86);
            this.button1.TabIndex = 0;
            this.button1.Text = "KIỂM TRA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxDiaChiMayChu
            // 
            this.tbxDiaChiMayChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDiaChiMayChu.Location = new System.Drawing.Point(25, 64);
            this.tbxDiaChiMayChu.Name = "tbxDiaChiMayChu";
            this.tbxDiaChiMayChu.Size = new System.Drawing.Size(374, 41);
            this.tbxDiaChiMayChu.TabIndex = 1;
            this.tbxDiaChiMayChu.Text = "192.168.1.7";
            // 
            // tbxTenDangNhap
            // 
            this.tbxTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTenDangNhap.Location = new System.Drawing.Point(25, 150);
            this.tbxTenDangNhap.Name = "tbxTenDangNhap";
            this.tbxTenDangNhap.Size = new System.Drawing.Size(374, 41);
            this.tbxTenDangNhap.TabIndex = 2;
            this.tbxTenDangNhap.Text = "postgres";
            // 
            // tbxMatKhau
            // 
            this.tbxMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMatKhau.Location = new System.Drawing.Point(25, 239);
            this.tbxMatKhau.Name = "tbxMatKhau";
            this.tbxMatKhau.Size = new System.Drawing.Size(374, 41);
            this.tbxMatKhau.TabIndex = 3;
            this.tbxMatKhau.Text = "230798";
            // 
            // tbxTenCoSoDuLieu
            // 
            this.tbxTenCoSoDuLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTenCoSoDuLieu.Location = new System.Drawing.Point(25, 333);
            this.tbxTenCoSoDuLieu.Name = "tbxTenCoSoDuLieu";
            this.tbxTenCoSoDuLieu.Size = new System.Drawing.Size(374, 41);
            this.tbxTenCoSoDuLieu.TabIndex = 4;
            this.tbxTenCoSoDuLieu.Text = "Checker";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Địa chỉ máy chủ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mật khẩu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tên cơ sở dữ liệu";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 430);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxTenCoSoDuLieu);
            this.Controls.Add(this.tbxMatKhau);
            this.Controls.Add(this.tbxTenDangNhap);
            this.Controls.Add(this.tbxDiaChiMayChu);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxDiaChiMayChu;
        private System.Windows.Forms.TextBox tbxTenDangNhap;
        private System.Windows.Forms.TextBox tbxMatKhau;
        private System.Windows.Forms.TextBox tbxTenCoSoDuLieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

