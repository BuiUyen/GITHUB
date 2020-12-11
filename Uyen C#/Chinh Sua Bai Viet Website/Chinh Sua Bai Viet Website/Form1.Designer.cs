namespace Chinh_Sua_Bai_Viet_Website
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
            this.tbxFile = new System.Windows.Forms.TextBox();
            this.btnOpenFileExcel = new System.Windows.Forms.Button();
            this.cbxSheet = new System.Windows.Forms.ComboBox();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbSoLuongAnh = new System.Windows.Forms.Label();
            this.lbIDSanPham = new System.Windows.Forms.Label();
            this.lbIDTuyChon = new System.Windows.Forms.Label();
            this.lbSKU = new System.Windows.Forms.Label();
            this.tbxTenSanPham = new System.Windows.Forms.TextBox();
            this.tbxGiaBan = new System.Windows.Forms.TextBox();
            this.tbxGiaSoSanh = new System.Windows.Forms.TextBox();
            this.tbxCanNang = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridViewKetQua = new System.Windows.Forms.DataGridView();
            this.tbxTimTags = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewTagsGoiY = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.lbTags = new System.Windows.Forms.Label();
            this.btnTiep = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbSTTAnhDaiDien = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDTuyChon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaSoSanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanNang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDTags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagsGoiY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXuat = new System.Windows.Forms.Button();
            this.dataGridViewXuat = new System.Windows.Forms.DataGridView();
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
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTagsGoiY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(16, 15);
            this.tbxFile.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.Size = new System.Drawing.Size(585, 22);
            this.tbxFile.TabIndex = 0;
            // 
            // btnOpenFileExcel
            // 
            this.btnOpenFileExcel.Location = new System.Drawing.Point(624, 14);
            this.btnOpenFileExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFileExcel.Name = "btnOpenFileExcel";
            this.btnOpenFileExcel.Size = new System.Drawing.Size(100, 25);
            this.btnOpenFileExcel.TabIndex = 1;
            this.btnOpenFileExcel.Text = "Open";
            this.btnOpenFileExcel.UseVisualStyleBackColor = true;
            this.btnOpenFileExcel.Click += new System.EventHandler(this.btnOpenFileExcel_Click);
            // 
            // cbxSheet
            // 
            this.cbxSheet.FormattingEnabled = true;
            this.cbxSheet.Location = new System.Drawing.Point(755, 14);
            this.cbxSheet.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSheet.Name = "cbxSheet";
            this.cbxSheet.Size = new System.Drawing.Size(160, 24);
            this.cbxSheet.TabIndex = 2;
            this.cbxSheet.SelectedIndexChanged += new System.EventHandler(this.cbxSheet_SelectedIndexChanged);
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(16, 47);
            this.dataGridViewData.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowHeadersWidth = 51;
            this.dataGridViewData.Size = new System.Drawing.Size(1914, 119);
            this.dataGridViewData.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên sản phẩm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Id sản phẩm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Id tùy chọn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mã (SKU):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 469);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cân nặng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Giá bán:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Giá so sánh:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1205, 173);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1352, 679);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1478, 679);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 31);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbSoLuongAnh
            // 
            this.lbSoLuongAnh.AutoSize = true;
            this.lbSoLuongAnh.Location = new System.Drawing.Point(1571, 686);
            this.lbSoLuongAnh.Name = "lbSoLuongAnh";
            this.lbSoLuongAnh.Size = new System.Drawing.Size(16, 17);
            this.lbSoLuongAnh.TabIndex = 14;
            this.lbSoLuongAnh.Text = "1";
            // 
            // lbIDSanPham
            // 
            this.lbIDSanPham.AutoSize = true;
            this.lbIDSanPham.Location = new System.Drawing.Point(160, 210);
            this.lbIDSanPham.Name = "lbIDSanPham";
            this.lbIDSanPham.Size = new System.Drawing.Size(20, 17);
            this.lbIDSanPham.TabIndex = 15;
            this.lbIDSanPham.Text = "...";
            // 
            // lbIDTuyChon
            // 
            this.lbIDTuyChon.AutoSize = true;
            this.lbIDTuyChon.Location = new System.Drawing.Point(160, 252);
            this.lbIDTuyChon.Name = "lbIDTuyChon";
            this.lbIDTuyChon.Size = new System.Drawing.Size(20, 17);
            this.lbIDTuyChon.TabIndex = 16;
            this.lbIDTuyChon.Text = "...";
            // 
            // lbSKU
            // 
            this.lbSKU.AutoSize = true;
            this.lbSKU.Location = new System.Drawing.Point(160, 341);
            this.lbSKU.Name = "lbSKU";
            this.lbSKU.Size = new System.Drawing.Size(20, 17);
            this.lbSKU.TabIndex = 17;
            this.lbSKU.Text = "...";
            // 
            // tbxTenSanPham
            // 
            this.tbxTenSanPham.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTenSanPham.Location = new System.Drawing.Point(163, 289);
            this.tbxTenSanPham.Name = "tbxTenSanPham";
            this.tbxTenSanPham.Size = new System.Drawing.Size(855, 34);
            this.tbxTenSanPham.TabIndex = 18;
            // 
            // tbxGiaBan
            // 
            this.tbxGiaBan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGiaBan.Location = new System.Drawing.Point(163, 370);
            this.tbxGiaBan.Name = "tbxGiaBan";
            this.tbxGiaBan.Size = new System.Drawing.Size(424, 34);
            this.tbxGiaBan.TabIndex = 19;
            this.tbxGiaBan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxGiaBan_KeyDown);
            this.tbxGiaBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxGiaBan_KeyPress);
            // 
            // tbxGiaSoSanh
            // 
            this.tbxGiaSoSanh.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGiaSoSanh.Location = new System.Drawing.Point(163, 415);
            this.tbxGiaSoSanh.Name = "tbxGiaSoSanh";
            this.tbxGiaSoSanh.Size = new System.Drawing.Size(424, 34);
            this.tbxGiaSoSanh.TabIndex = 20;
            this.tbxGiaSoSanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxGiaSoSanh_KeyDown);
            this.tbxGiaSoSanh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxGiaSoSanh_KeyPress);
            // 
            // tbxCanNang
            // 
            this.tbxCanNang.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCanNang.Location = new System.Drawing.Point(163, 459);
            this.tbxCanNang.Name = "tbxCanNang";
            this.tbxCanNang.Size = new System.Drawing.Size(153, 34);
            this.tbxCanNang.TabIndex = 21;
            this.tbxCanNang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCanNang_KeyDown);
            this.tbxCanNang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCanNang_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "gram.";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1466, 730);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(239, 67);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "Thêm";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dataGridViewKetQua
            // 
            this.dataGridViewKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IDTuyChon,
            this.TenSanPham,
            this.SKU,
            this.GiaBan,
            this.GiaSoSanh,
            this.CanNang,
            this.TagSP});
            this.dataGridViewKetQua.Location = new System.Drawing.Point(16, 804);
            this.dataGridViewKetQua.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewKetQua.Name = "dataGridViewKetQua";
            this.dataGridViewKetQua.RowHeadersWidth = 51;
            this.dataGridViewKetQua.Size = new System.Drawing.Size(1689, 570);
            this.dataGridViewKetQua.TabIndex = 24;
            // 
            // tbxTimTags
            // 
            this.tbxTimTags.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTimTags.Location = new System.Drawing.Point(69, 530);
            this.tbxTimTags.Name = "tbxTimTags";
            this.tbxTimTags.Size = new System.Drawing.Size(266, 34);
            this.tbxTimTags.TabIndex = 25;
            this.tbxTimTags.TextChanged += new System.EventHandler(this.tbxTimTags_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 540);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Tags:";
            // 
            // dataGridViewTagsGoiY
            // 
            this.dataGridViewTagsGoiY.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTagsGoiY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTagsGoiY.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDTags,
            this.TagsGoiY});
            this.dataGridViewTagsGoiY.Location = new System.Drawing.Point(355, 530);
            this.dataGridViewTagsGoiY.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewTagsGoiY.Name = "dataGridViewTagsGoiY";
            this.dataGridViewTagsGoiY.RowHeadersWidth = 51;
            this.dataGridViewTagsGoiY.Size = new System.Drawing.Size(843, 216);
            this.dataGridViewTagsGoiY.TabIndex = 27;
            this.dataGridViewTagsGoiY.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTagsGoiY_CellClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 764);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "Tags:";
            // 
            // lbTags
            // 
            this.lbTags.AutoSize = true;
            this.lbTags.Location = new System.Drawing.Point(124, 764);
            this.lbTags.Name = "lbTags";
            this.lbTags.Size = new System.Drawing.Size(20, 17);
            this.lbTags.TabIndex = 30;
            this.lbTags.Text = "...";
            // 
            // btnTiep
            // 
            this.btnTiep.Location = new System.Drawing.Point(69, 640);
            this.btnTiep.Name = "btnTiep";
            this.btnTiep.Size = new System.Drawing.Size(175, 62);
            this.btnTiep.TabIndex = 31;
            this.btnTiep.Text = "Sản Phẩm Tiếp Theo";
            this.btnTiep.UseVisualStyleBackColor = true;
            this.btnTiep.Click += new System.EventHandler(this.btnTiep_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(593, 380);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 17);
            this.label11.TabIndex = 32;
            this.label11.Text = "đồng.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(593, 425);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 17);
            this.label12.TabIndex = 33;
            this.label12.Text = "đồng.";
            // 
            // lbSTTAnhDaiDien
            // 
            this.lbSTTAnhDaiDien.AutoSize = true;
            this.lbSTTAnhDaiDien.Location = new System.Drawing.Point(1447, 686);
            this.lbSTTAnhDaiDien.Name = "lbSTTAnhDaiDien";
            this.lbSTTAnhDaiDien.Size = new System.Drawing.Size(16, 17);
            this.lbSTTAnhDaiDien.TabIndex = 34;
            this.lbSTTAnhDaiDien.Text = "1";
            // 
            // ID
            // 
            this.ID.FillWeight = 43.50782F;
            this.ID.HeaderText = "ID Sản phẩm";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            // 
            // IDTuyChon
            // 
            this.IDTuyChon.FillWeight = 46.21473F;
            this.IDTuyChon.HeaderText = "ID Tùy Chọn";
            this.IDTuyChon.MinimumWidth = 6;
            this.IDTuyChon.Name = "IDTuyChon";
            // 
            // TenSanPham
            // 
            this.TenSanPham.FillWeight = 182.9041F;
            this.TenSanPham.HeaderText = "Tên Sản Phẩm";
            this.TenSanPham.MinimumWidth = 6;
            this.TenSanPham.Name = "TenSanPham";
            // 
            // SKU
            // 
            this.SKU.FillWeight = 43.9003F;
            this.SKU.HeaderText = "SKU";
            this.SKU.MinimumWidth = 6;
            this.SKU.Name = "SKU";
            // 
            // GiaBan
            // 
            this.GiaBan.FillWeight = 46.58588F;
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.MinimumWidth = 6;
            this.GiaBan.Name = "GiaBan";
            // 
            // GiaSoSanh
            // 
            this.GiaSoSanh.FillWeight = 49.12538F;
            this.GiaSoSanh.HeaderText = "Giá So Sánh";
            this.GiaSoSanh.MinimumWidth = 6;
            this.GiaSoSanh.Name = "GiaSoSanh";
            // 
            // CanNang
            // 
            this.CanNang.FillWeight = 51.52679F;
            this.CanNang.HeaderText = "Cân Nặng";
            this.CanNang.MinimumWidth = 6;
            this.CanNang.Name = "CanNang";
            // 
            // TagSP
            // 
            this.TagSP.FillWeight = 336.235F;
            this.TagSP.HeaderText = "Tags";
            this.TagSP.MinimumWidth = 6;
            this.TagSP.Name = "TagSP";
            // 
            // IDTags
            // 
            this.IDTags.FillWeight = 32.08556F;
            this.IDTags.HeaderText = "ID";
            this.IDTags.MinimumWidth = 6;
            this.IDTags.Name = "IDTags";
            // 
            // TagsGoiY
            // 
            this.TagsGoiY.FillWeight = 167.9144F;
            this.TagsGoiY.HeaderText = "Tags";
            this.TagsGoiY.MinimumWidth = 6;
            this.TagsGoiY.Name = "TagsGoiY";
            // 
            // btnXuat
            // 
            this.btnXuat.Location = new System.Drawing.Point(1303, 1381);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(239, 31);
            this.btnXuat.TabIndex = 35;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // dataGridViewXuat
            // 
            this.dataGridViewXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewXuat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dataGridViewXuat.Location = new System.Drawing.Point(16, 803);
            this.dataGridViewXuat.Name = "dataGridViewXuat";
            this.dataGridViewXuat.RowHeadersWidth = 51;
            this.dataGridViewXuat.RowTemplate.Height = 24;
            this.dataGridViewXuat.Size = new System.Drawing.Size(1689, 571);
            this.dataGridViewXuat.TabIndex = 36;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 48.89976F;
            this.Column1.HeaderText = "Đường dẫn / Alias";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 192.4983F;
            this.Column2.HeaderText = "Tên sản phẩm";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 315;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 47.79522F;
            this.Column3.HeaderText = "Mã (SKU)";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 78;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 41.05677F;
            this.Column4.HeaderText = "Giá";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 67;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 52.27544F;
            this.Column5.HeaderText = "Giá so sánh";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 86;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 245.5917F;
            this.Column6.HeaderText = "Ảnh đại diện";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 402;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 86.7261F;
            this.Column7.HeaderText = "Cân nặng";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 141;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 101.6314F;
            this.Column8.HeaderText = "Id sản phẩm";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 167;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 117.1464F;
            this.Column9.HeaderText = "Id tùy chọn";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 191;
            // 
            // Column10
            // 
            this.Column10.FillWeight = 66.37909F;
            this.Column10.HeaderText = "Tags";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 109;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(1651, 1381);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(54, 31);
            this.btnExcel.TabIndex = 37;
            this.btnExcel.Text = "=>";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1723, 1424);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dataGridViewXuat);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.lbSTTAnhDaiDien);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnTiep);
            this.Controls.Add(this.lbTags);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridViewTagsGoiY);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbxTimTags);
            this.Controls.Add(this.dataGridViewKetQua);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxCanNang);
            this.Controls.Add(this.tbxGiaSoSanh);
            this.Controls.Add(this.tbxGiaBan);
            this.Controls.Add(this.tbxTenSanPham);
            this.Controls.Add(this.lbSKU);
            this.Controls.Add(this.lbIDTuyChon);
            this.Controls.Add(this.lbIDSanPham);
            this.Controls.Add(this.lbSoLuongAnh);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.cbxSheet);
            this.Controls.Add(this.btnOpenFileExcel);
            this.Controls.Add(this.tbxFile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Phân mềm phân loại sản phẩm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTagsGoiY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.Button btnOpenFileExcel;
        private System.Windows.Forms.ComboBox cbxSheet;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbSoLuongAnh;
        private System.Windows.Forms.Label lbIDSanPham;
        private System.Windows.Forms.Label lbIDTuyChon;
        private System.Windows.Forms.Label lbSKU;
        private System.Windows.Forms.TextBox tbxTenSanPham;
        private System.Windows.Forms.TextBox tbxGiaBan;
        private System.Windows.Forms.TextBox tbxGiaSoSanh;
        private System.Windows.Forms.TextBox tbxCanNang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dataGridViewKetQua;
        private System.Windows.Forms.TextBox tbxTimTags;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridViewTagsGoiY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbTags;
        private System.Windows.Forms.Button btnTiep;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbSTTAnhDaiDien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTuyChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaSoSanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanNang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagsGoiY;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.DataGridView dataGridViewXuat;
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
        private System.Windows.Forms.Button btnExcel;
    }
}

