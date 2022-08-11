namespace Lay_San_Pham_3M
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
            this.btnLaySanPham = new System.Windows.Forms.Button();
            this.dataGridViewSanPham = new System.Windows.Forms.DataGridView();
            this.LinkSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSoTrang = new System.Windows.Forms.TextBox();
            this.btnXuat1 = new System.Windows.Forms.Button();
            this.dataGridViewDaTa = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txbFile = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.cbxSheet = new System.Windows.Forms.ComboBox();
            this.btnXuLi = new System.Windows.Forms.Button();
            this.dataGridViewKetQua = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDaTa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaySanPham
            // 
            this.btnLaySanPham.Location = new System.Drawing.Point(12, 12);
            this.btnLaySanPham.Name = "btnLaySanPham";
            this.btnLaySanPham.Size = new System.Drawing.Size(94, 23);
            this.btnLaySanPham.TabIndex = 0;
            this.btnLaySanPham.Text = "Truy Cập 3M";
            this.btnLaySanPham.UseVisualStyleBackColor = true;
            this.btnLaySanPham.Click += new System.EventHandler(this.btnLaySanPham_Click);
            // 
            // dataGridViewSanPham
            // 
            this.dataGridViewSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LinkSanPham,
            this.TenSanPham,
            this.Gia});
            this.dataGridViewSanPham.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewSanPham.Name = "dataGridViewSanPham";
            this.dataGridViewSanPham.Size = new System.Drawing.Size(434, 397);
            this.dataGridViewSanPham.TabIndex = 1;
            // 
            // LinkSanPham
            // 
            this.LinkSanPham.HeaderText = "Link Sản Phẩm";
            this.LinkSanPham.Name = "LinkSanPham";
            // 
            // TenSanPham
            // 
            this.TenSanPham.HeaderText = "Tên Sản Phẩm";
            this.TenSanPham.Name = "TenSanPham";
            // 
            // Gia
            // 
            this.Gia.HeaderText = "Giá";
            this.Gia.Name = "Gia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số Trang Sản Phẩm:";
            // 
            // txbSoTrang
            // 
            this.txbSoTrang.Location = new System.Drawing.Point(241, 14);
            this.txbSoTrang.Name = "txbSoTrang";
            this.txbSoTrang.Size = new System.Drawing.Size(45, 20);
            this.txbSoTrang.TabIndex = 3;
            this.txbSoTrang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSoTrang_KeyPress);
            // 
            // btnXuat1
            // 
            this.btnXuat1.Location = new System.Drawing.Point(12, 448);
            this.btnXuat1.Name = "btnXuat1";
            this.btnXuat1.Size = new System.Drawing.Size(75, 23);
            this.btnXuat1.TabIndex = 4;
            this.btnXuat1.Text = "Xuất Excel";
            this.btnXuat1.UseVisualStyleBackColor = true;
            this.btnXuat1.Click += new System.EventHandler(this.btnXuat1_Click);
            // 
            // dataGridViewDaTa
            // 
            this.dataGridViewDaTa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDaTa.Location = new System.Drawing.Point(452, 41);
            this.dataGridViewDaTa.Name = "dataGridViewDaTa";
            this.dataGridViewDaTa.Size = new System.Drawing.Size(434, 150);
            this.dataGridViewDaTa.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "File:";
            // 
            // txbFile
            // 
            this.txbFile.Location = new System.Drawing.Point(481, 14);
            this.txbFile.Name = "txbFile";
            this.txbFile.Size = new System.Drawing.Size(270, 20);
            this.txbFile.TabIndex = 7;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(757, 14);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(26, 20);
            this.btnOpenFile.TabIndex = 8;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // cbxSheet
            // 
            this.cbxSheet.FormattingEnabled = true;
            this.cbxSheet.Location = new System.Drawing.Point(789, 13);
            this.cbxSheet.Name = "cbxSheet";
            this.cbxSheet.Size = new System.Drawing.Size(97, 21);
            this.cbxSheet.TabIndex = 9;
            this.cbxSheet.SelectedIndexChanged += new System.EventHandler(this.cbxSheet_SelectedIndexChanged);
            // 
            // btnXuLi
            // 
            this.btnXuLi.Location = new System.Drawing.Point(604, 197);
            this.btnXuLi.Name = "btnXuLi";
            this.btnXuLi.Size = new System.Drawing.Size(135, 27);
            this.btnXuLi.TabIndex = 10;
            this.btnXuLi.Text = "Lấy Ảnh Và Thông Số";
            this.btnXuLi.UseVisualStyleBackColor = true;
            this.btnXuLi.Click += new System.EventHandler(this.btnXuLi_Click);
            // 
            // dataGridViewKetQua
            // 
            this.dataGridViewKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dataGridViewKetQua.Location = new System.Drawing.Point(452, 230);
            this.dataGridViewKetQua.Name = "dataGridViewKetQua";
            this.dataGridViewKetQua.Size = new System.Drawing.Size(434, 208);
            this.dataGridViewKetQua.TabIndex = 11;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Link Sản Phẩm";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên Sản Phẩm";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Giá";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Thông Số Kĩ Thuật";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Link Ảnh 1";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Link Ảnh 2";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Link Ảnh 3";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Link Ảnh 4";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Link Ảnh 5";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Link Ảnh 6";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Cân Nặng";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Phân Loại";
            this.Column12.Name = "Column12";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 480);
            this.Controls.Add(this.dataGridViewKetQua);
            this.Controls.Add(this.btnXuLi);
            this.Controls.Add(this.cbxSheet);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txbFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewDaTa);
            this.Controls.Add(this.btnXuat1);
            this.Controls.Add(this.txbSoTrang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewSanPham);
            this.Controls.Add(this.btnLaySanPham);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Uyên Đẹp Zai";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDaTa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLaySanPham;
        private System.Windows.Forms.DataGridView dataGridViewSanPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSoTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.Button btnXuat1;
        private System.Windows.Forms.DataGridView dataGridViewDaTa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ComboBox cbxSheet;
        private System.Windows.Forms.Button btnXuLi;
        private System.Windows.Forms.DataGridView dataGridViewKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}

