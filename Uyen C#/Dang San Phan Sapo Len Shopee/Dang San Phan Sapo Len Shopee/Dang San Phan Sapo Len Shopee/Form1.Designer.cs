namespace Dang_San_Phan_Sapo_Len_Shopee
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
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxLinkExcel = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.btnXuLi = new System.Windows.Forms.Button();
            this.dataGridViewKetQua = new System.Windows.Forms.DataGridView();
            this.DuongDan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HienThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaVach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkAnhSapo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanNang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(12, 32);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.Size = new System.Drawing.Size(657, 489);
            this.dataGridViewData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Link File Gốc:";
            // 
            // tbxLinkExcel
            // 
            this.tbxLinkExcel.Location = new System.Drawing.Point(90, 6);
            this.tbxLinkExcel.Name = "tbxLinkExcel";
            this.tbxLinkExcel.Size = new System.Drawing.Size(335, 20);
            this.tbxLinkExcel.TabIndex = 2;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(449, 6);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 20);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // cboSheet
            // 
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(548, 6);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(121, 21);
            this.cboSheet.TabIndex = 4;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // btnXuLi
            // 
            this.btnXuLi.Location = new System.Drawing.Point(675, 236);
            this.btnXuLi.Name = "btnXuLi";
            this.btnXuLi.Size = new System.Drawing.Size(65, 53);
            this.btnXuLi.TabIndex = 5;
            this.btnXuLi.Text = ">>>";
            this.btnXuLi.UseVisualStyleBackColor = true;
            this.btnXuLi.Click += new System.EventHandler(this.btnXuLi_Click);
            // 
            // dataGridViewKetQua
            // 
            this.dataGridViewKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DuongDan,
            this.TenSanPham,
            this.NoiDung,
            this.HienThi,
            this.SKU,
            this.Gia,
            this.MaVach,
            this.LinkAnhSapo,
            this.CanNang});
            this.dataGridViewKetQua.Location = new System.Drawing.Point(746, 32);
            this.dataGridViewKetQua.Name = "dataGridViewKetQua";
            this.dataGridViewKetQua.Size = new System.Drawing.Size(657, 489);
            this.dataGridViewKetQua.TabIndex = 6;
            // 
            // DuongDan
            // 
            this.DuongDan.HeaderText = "Đường dẫn / Alias";
            this.DuongDan.Name = "DuongDan";
            // 
            // TenSanPham
            // 
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.Name = "TenSanPham";
            // 
            // NoiDung
            // 
            this.NoiDung.HeaderText = "Nội dung";
            this.NoiDung.Name = "NoiDung";
            // 
            // HienThi
            // 
            this.HienThi.HeaderText = "Hiển thị";
            this.HienThi.Name = "HienThi";
            // 
            // SKU
            // 
            this.SKU.HeaderText = "Mã (SKU)";
            this.SKU.Name = "SKU";
            // 
            // Gia
            // 
            this.Gia.HeaderText = "Giá";
            this.Gia.Name = "Gia";
            // 
            // MaVach
            // 
            this.MaVach.HeaderText = "Mã vạch(Barcode)";
            this.MaVach.Name = "MaVach";
            // 
            // LinkAnhSapo
            // 
            this.LinkAnhSapo.HeaderText = "Ảnh đại diện";
            this.LinkAnhSapo.Name = "LinkAnhSapo";
            // 
            // CanNang
            // 
            this.CanNang.HeaderText = "Cân nặng";
            this.CanNang.Name = "CanNang";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(675, 467);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(65, 54);
            this.btnXuatExcel.TabIndex = 7;
            this.btnXuatExcel.Text = "Xuất";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 534);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.dataGridViewKetQua);
            this.Controls.Add(this.btnXuLi);
            this.Controls.Add(this.cboSheet);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.tbxLinkExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewData);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxLinkExcel;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ComboBox cboSheet;
        private System.Windows.Forms.Button btnXuLi;
        private System.Windows.Forms.DataGridView dataGridViewKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuongDan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn HienThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVach;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkAnhSapo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanNang;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}

