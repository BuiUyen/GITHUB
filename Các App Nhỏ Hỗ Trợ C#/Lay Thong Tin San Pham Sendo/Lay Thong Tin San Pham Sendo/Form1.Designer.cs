namespace Lay_Thong_Tin_San_Pham_Sendo
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCodeShop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSoTrang = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Shop:";
            // 
            // tbxCodeShop
            // 
            this.tbxCodeShop.Location = new System.Drawing.Point(95, 6);
            this.tbxCodeShop.Name = "tbxCodeShop";
            this.tbxCodeShop.Size = new System.Drawing.Size(251, 22);
            this.tbxCodeShop.TabIndex = 2;
            this.tbxCodeShop.Text = "108209";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số trang:";
            // 
            // tbxSoTrang
            // 
            this.tbxSoTrang.Location = new System.Drawing.Point(469, 6);
            this.tbxSoTrang.Name = "tbxSoTrang";
            this.tbxSoTrang.Size = new System.Drawing.Size(93, 22);
            this.tbxSoTrang.TabIndex = 4;
            this.tbxSoTrang.Text = "1";
            this.tbxSoTrang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSoTrang_KeyPress);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbxSoTrang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCodeShop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "FormMain";
            this.Text = "Bùi Hữu Uyên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCodeShop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSoTrang;
    }
}

