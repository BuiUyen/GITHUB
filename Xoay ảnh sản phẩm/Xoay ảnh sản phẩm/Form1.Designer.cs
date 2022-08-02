namespace Xoay_ảnh_sản_phẩm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txbFile = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbxLinkExcel = new System.Windows.Forms.TextBox();
            this.bnOpenFile = new System.Windows.Forms.Button();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.tbxSKU = new System.Windows.Forms.TextBox();
            this.tbxFoder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(489, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mở ảnh:";
            // 
            // txbFile
            // 
            this.txbFile.Location = new System.Drawing.Point(557, 26);
            this.txbFile.Name = "txbFile";
            this.txbFile.Size = new System.Drawing.Size(812, 27);
            this.txbFile.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(1387, 2);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(126, 74);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(720, 720);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(965, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(720, 720);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(1691, 88);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(720, 720);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // tbxLinkExcel
            // 
            this.tbxLinkExcel.Location = new System.Drawing.Point(700, 853);
            this.tbxLinkExcel.Name = "tbxLinkExcel";
            this.tbxLinkExcel.Size = new System.Drawing.Size(563, 27);
            this.tbxLinkExcel.TabIndex = 6;
            // 
            // bnOpenFile
            // 
            this.bnOpenFile.Location = new System.Drawing.Point(1292, 852);
            this.bnOpenFile.Name = "bnOpenFile";
            this.bnOpenFile.Size = new System.Drawing.Size(94, 29);
            this.bnOpenFile.TabIndex = 7;
            this.bnOpenFile.Text = "Open";
            this.bnOpenFile.UseVisualStyleBackColor = true;
            this.bnOpenFile.Click += new System.EventHandler(this.bnOpenFile_Click);
            // 
            // cboSheet
            // 
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(1431, 853);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(151, 28);
            this.cboSheet.TabIndex = 8;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(1853, 2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(94, 74);
            this.btnRun.TabIndex = 10;
            this.btnRun.Text = "Lấy ảnh";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tbxSKU
            // 
            this.tbxSKU.Location = new System.Drawing.Point(1659, 26);
            this.tbxSKU.Name = "tbxSKU";
            this.tbxSKU.Size = new System.Drawing.Size(172, 27);
            this.tbxSKU.TabIndex = 9;
            this.tbxSKU.TextChanged += new System.EventHandler(this.tbxSKU_TextChanged);
            // 
            // tbxFoder
            // 
            this.tbxFoder.Location = new System.Drawing.Point(1953, 852);
            this.tbxFoder.Name = "tbxFoder";
            this.tbxFoder.Size = new System.Drawing.Size(458, 27);
            this.tbxFoder.TabIndex = 11;
            this.tbxFoder.DoubleClick += new System.EventHandler(this.tbxFoder_DoubleClick_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1885, 855);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Folder";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2450, 911);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxFoder);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbxSKU);
            this.Controls.Add(this.cboSheet);
            this.Controls.Add(this.bnOpenFile);
            this.Controls.Add(this.tbxLinkExcel);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txbFile);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Xoay ảnh sản phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txbFile;
        private Button btnOpenFile;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TextBox tbxLinkExcel;
        private Button bnOpenFile;
        private ComboBox cboSheet;
        private Button btnRun;
        private TextBox tbxSKU;
        private TextBox tbxFoder;
        private Label label2;
    }
}