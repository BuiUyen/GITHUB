namespace Tao_Danh_Sach_San_Pham_Di_Cho
{
    partial class Form2
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
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxSoLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxGia = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Số lượng:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(272, 35);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 59);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxSoLuong
            // 
            this.tbxSoLuong.Location = new System.Drawing.Point(113, 85);
            this.tbxSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSoLuong.Name = "tbxSoLuong";
            this.tbxSoLuong.Size = new System.Drawing.Size(132, 22);
            this.tbxSoLuong.TabIndex = 3;
            this.tbxSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSoLuong_KeyDown);
            this.tbxSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSoLuong_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Giá:";
            // 
            // tbxGia
            // 
            this.tbxGia.Location = new System.Drawing.Point(113, 35);
            this.tbxGia.Margin = new System.Windows.Forms.Padding(4);
            this.tbxGia.Name = "tbxGia";
            this.tbxGia.Size = new System.Drawing.Size(132, 22);
            this.tbxGia.TabIndex = 6;
            this.tbxGia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxGia_KeyDown);
            this.tbxGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxGia_KeyPress);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(402, 137);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxGia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxSoLuong);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Sửa Số Lượng";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxGia;
    }
}