namespace Danh_Sách_Sản_Phẩm_Up_Shopee
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
            this.cbxSheet = new System.Windows.Forms.ComboBox();
            this.btnOpenFileExcel = new System.Windows.Forms.Button();
            this.tbxFile = new System.Windows.Forms.TextBox();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.tbxListMaSanPham = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.dataGridViewKetQua = new System.Windows.Forms.DataGridView();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhanLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhanLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKUSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxSheet
            // 
            this.cbxSheet.FormattingEnabled = true;
            this.cbxSheet.Location = new System.Drawing.Point(752, 12);
            this.cbxSheet.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSheet.Name = "cbxSheet";
            this.cbxSheet.Size = new System.Drawing.Size(160, 24);
            this.cbxSheet.TabIndex = 5;
            this.cbxSheet.SelectedIndexChanged += new System.EventHandler(this.cbxSheet_SelectedIndexChanged);
            // 
            // btnOpenFileExcel
            // 
            this.btnOpenFileExcel.Location = new System.Drawing.Point(621, 12);
            this.btnOpenFileExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFileExcel.Name = "btnOpenFileExcel";
            this.btnOpenFileExcel.Size = new System.Drawing.Size(100, 25);
            this.btnOpenFileExcel.TabIndex = 4;
            this.btnOpenFileExcel.Text = "Open";
            this.btnOpenFileExcel.UseVisualStyleBackColor = true;
            this.btnOpenFileExcel.Click += new System.EventHandler(this.btnOpenFileExcel_Click);
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(13, 13);
            this.tbxFile.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.Size = new System.Drawing.Size(585, 22);
            this.tbxFile.TabIndex = 3;
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(13, 63);
            this.dataGridViewData.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowHeadersWidth = 51;
            this.dataGridViewData.Size = new System.Drawing.Size(1915, 119);
            this.dataGridViewData.TabIndex = 6;
            // 
            // tbxListMaSanPham
            // 
            this.tbxListMaSanPham.Location = new System.Drawing.Point(1492, 208);
            this.tbxListMaSanPham.Multiline = true;
            this.tbxListMaSanPham.Name = "tbxListMaSanPham";
            this.tbxListMaSanPham.Size = new System.Drawing.Size(436, 471);
            this.tbxListMaSanPham.TabIndex = 7;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(1672, 685);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(96, 32);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "Chạy";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dataGridViewKetQua
            // 
            this.dataGridViewKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSanPham,
            this.TenSanPham,
            this.MaPhanLoai,
            this.TenPhanLoai,
            this.SKUSanPham,
            this.SKU,
            this.Gia,
            this.SoLuong});
            this.dataGridViewKetQua.Location = new System.Drawing.Point(13, 208);
            this.dataGridViewKetQua.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewKetQua.Name = "dataGridViewKetQua";
            this.dataGridViewKetQua.RowHeadersWidth = 51;
            this.dataGridViewKetQua.Size = new System.Drawing.Size(1472, 597);
            this.dataGridViewKetQua.TabIndex = 9;
            // 
            // MaSanPham
            // 
            this.MaSanPham.HeaderText = "Mã Sản phẩm";
            this.MaSanPham.MinimumWidth = 6;
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.Width = 125;
            // 
            // TenSanPham
            // 
            this.TenSanPham.HeaderText = "Tên Sản phẩm";
            this.TenSanPham.MinimumWidth = 6;
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.Width = 125;
            // 
            // MaPhanLoai
            // 
            this.MaPhanLoai.HeaderText = "Mã Phân loại";
            this.MaPhanLoai.MinimumWidth = 6;
            this.MaPhanLoai.Name = "MaPhanLoai";
            this.MaPhanLoai.Width = 125;
            // 
            // TenPhanLoai
            // 
            this.TenPhanLoai.HeaderText = "Tên phân loại";
            this.TenPhanLoai.MinimumWidth = 6;
            this.TenPhanLoai.Name = "TenPhanLoai";
            this.TenPhanLoai.Width = 125;
            // 
            // SKUSanPham
            // 
            this.SKUSanPham.HeaderText = "SKU Sản phẩm";
            this.SKUSanPham.MinimumWidth = 6;
            this.SKUSanPham.Name = "SKUSanPham";
            this.SKUSanPham.Width = 125;
            // 
            // SKU
            // 
            this.SKU.HeaderText = "SKU";
            this.SKU.MinimumWidth = 6;
            this.SKU.Name = "SKU";
            this.SKU.Width = 125;
            // 
            // Gia
            // 
            this.Gia.HeaderText = "Giá";
            this.Gia.MinimumWidth = 6;
            this.Gia.Name = "Gia";
            this.Gia.Width = 125;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1943, 818);
            this.Controls.Add(this.dataGridViewKetQua);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbxListMaSanPham);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.cbxSheet);
            this.Controls.Add(this.btnOpenFileExcel);
            this.Controls.Add(this.tbxFile);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxSheet;
        private System.Windows.Forms.Button btnOpenFileExcel;
        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.TextBox tbxListMaSanPham;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataGridView dataGridViewKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhanLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhanLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKUSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
    }
}

