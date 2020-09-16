namespace Tao_Danh_Sach_San_Pham_Di_Cho
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTimkiem = new System.Windows.Forms.TextBox();
            this.dataGridViewKetQua = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewSanThuongMai = new System.Windows.Forms.DataGridView();
            this.SanThuongMai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaSanThuongMai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTim = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTenSanPham = new System.Windows.Forms.Label();
            this.txbSoLuong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbGia = new System.Windows.Forms.Label();
            this.btnThemSanPham = new System.Windows.Forms.Button();
            this.dataGridViewOutput = new System.Windows.Forms.DataGridView();
            this.IDKetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TamTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnTimFileCu = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.btnPhieuIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbxSanPhamThem = new System.Windows.Forms.TextBox();
            this.tbxGiaThem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxSoLuongThem = new System.Windows.Forms.TextBox();
            this.btnThemMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSanThuongMai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1469, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Made in Bui Huu Uyen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tìm Kiếm:";
            // 
            // tbxTimkiem
            // 
            this.tbxTimkiem.Location = new System.Drawing.Point(109, 28);
            this.tbxTimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTimkiem.Name = "tbxTimkiem";
            this.tbxTimkiem.Size = new System.Drawing.Size(946, 22);
            this.tbxTimkiem.TabIndex = 13;
            this.tbxTimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxTimkiem_KeyDown);
            // 
            // dataGridViewKetQua
            // 
            this.dataGridViewKetQua.ColumnHeadersHeight = 29;
            this.dataGridViewKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Ten,
            this.Gia});
            this.dataGridViewKetQua.Location = new System.Drawing.Point(20, 77);
            this.dataGridViewKetQua.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewKetQua.MultiSelect = false;
            this.dataGridViewKetQua.Name = "dataGridViewKetQua";
            this.dataGridViewKetQua.ReadOnly = true;
            this.dataGridViewKetQua.RowHeadersWidth = 51;
            this.dataGridViewKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKetQua.Size = new System.Drawing.Size(785, 375);
            this.dataGridViewKetQua.TabIndex = 15;
            this.dataGridViewKetQua.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKetQua_CellClick);
            // 
            // ID
            // 
            this.ID.FillWeight = 80.21391F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // Ten
            // 
            this.Ten.FillWeight = 109.8931F;
            this.Ten.HeaderText = "Tên Sản Phẩm";
            this.Ten.MinimumWidth = 6;
            this.Ten.Name = "Ten";
            this.Ten.ReadOnly = true;
            this.Ten.Width = 400;
            // 
            // Gia
            // 
            this.Gia.FillWeight = 109.8931F;
            this.Gia.HeaderText = "Giá";
            this.Gia.MinimumWidth = 6;
            this.Gia.Name = "Gia";
            this.Gia.ReadOnly = true;
            this.Gia.Width = 200;
            // 
            // dataGridViewSanThuongMai
            // 
            this.dataGridViewSanThuongMai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSanThuongMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSanThuongMai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SanThuongMai,
            this.GiaSanThuongMai});
            this.dataGridViewSanThuongMai.Location = new System.Drawing.Point(813, 77);
            this.dataGridViewSanThuongMai.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewSanThuongMai.MultiSelect = false;
            this.dataGridViewSanThuongMai.Name = "dataGridViewSanThuongMai";
            this.dataGridViewSanThuongMai.ReadOnly = true;
            this.dataGridViewSanThuongMai.RowHeadersWidth = 51;
            this.dataGridViewSanThuongMai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSanThuongMai.Size = new System.Drawing.Size(387, 375);
            this.dataGridViewSanThuongMai.TabIndex = 16;
            // 
            // SanThuongMai
            // 
            this.SanThuongMai.HeaderText = "Sàn Thương Mại";
            this.SanThuongMai.MinimumWidth = 6;
            this.SanThuongMai.Name = "SanThuongMai";
            this.SanThuongMai.ReadOnly = true;
            // 
            // GiaSanThuongMai
            // 
            this.GiaSanThuongMai.HeaderText = "Giá";
            this.GiaSanThuongMai.MinimumWidth = 6;
            this.GiaSanThuongMai.Name = "GiaSanThuongMai";
            this.GiaSanThuongMai.ReadOnly = true;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(1081, 10);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 58);
            this.btnTim.TabIndex = 17;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 486);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tên sản phẩm:";
            // 
            // lbTenSanPham
            // 
            this.lbTenSanPham.AutoSize = true;
            this.lbTenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSanPham.ForeColor = System.Drawing.Color.Red;
            this.lbTenSanPham.Location = new System.Drawing.Point(128, 479);
            this.lbTenSanPham.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTenSanPham.Name = "lbTenSanPham";
            this.lbTenSanPham.Size = new System.Drawing.Size(25, 24);
            this.lbTenSanPham.TabIndex = 19;
            this.lbTenSanPham.Text = "...";
            // 
            // txbSoLuong
            // 
            this.txbSoLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txbSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSoLuong.Location = new System.Drawing.Point(465, 513);
            this.txbSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txbSoLuong.Name = "txbSoLuong";
            this.txbSoLuong.Size = new System.Drawing.Size(203, 45);
            this.txbSoLuong.TabIndex = 20;
            this.txbSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSoLuong_KeyDown);
            this.txbSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSoLuong_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 527);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 527);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Giá:";
            // 
            // lbGia
            // 
            this.lbGia.AutoSize = true;
            this.lbGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGia.ForeColor = System.Drawing.Color.Red;
            this.lbGia.Location = new System.Drawing.Point(128, 522);
            this.lbGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(25, 24);
            this.lbGia.TabIndex = 23;
            this.lbGia.Text = "...";
            // 
            // btnThemSanPham
            // 
            this.btnThemSanPham.Location = new System.Drawing.Point(689, 513);
            this.btnThemSanPham.Name = "btnThemSanPham";
            this.btnThemSanPham.Size = new System.Drawing.Size(173, 45);
            this.btnThemSanPham.TabIndex = 24;
            this.btnThemSanPham.Text = "Thêm";
            this.btnThemSanPham.UseVisualStyleBackColor = true;
            this.btnThemSanPham.Click += new System.EventHandler(this.btnThemSanPham_Click);
            // 
            // dataGridViewOutput
            // 
            this.dataGridViewOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDKetQua,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.SoLuong,
            this.TamTinh});
            this.dataGridViewOutput.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewOutput.Location = new System.Drawing.Point(20, 568);
            this.dataGridViewOutput.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewOutput.MultiSelect = false;
            this.dataGridViewOutput.Name = "dataGridViewOutput";
            this.dataGridViewOutput.ReadOnly = true;
            this.dataGridViewOutput.RowHeadersWidth = 51;
            this.dataGridViewOutput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOutput.Size = new System.Drawing.Size(1581, 460);
            this.dataGridViewOutput.TabIndex = 25;
            this.dataGridViewOutput.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewOutput_CellMouseUp);
            // 
            // IDKetQua
            // 
            this.IDKetQua.HeaderText = "ID";
            this.IDKetQua.MinimumWidth = 6;
            this.IDKetQua.Name = "IDKetQua";
            this.IDKetQua.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên Sản Phẩm";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Giá";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // TamTinh
            // 
            this.TamTinh.HeaderText = "Tạm Tính";
            this.TamTinh.MinimumWidth = 6;
            this.TamTinh.Name = "TamTinh";
            this.TamTinh.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sửaToolStripMenuItem,
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 64);
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(113, 30);
            this.sửaToolStripMenuItem.Text = "Sửa";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(113, 30);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.Location = new System.Drawing.Point(1285, 1041);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(173, 81);
            this.btnXuat.TabIndex = 28;
            this.btnXuat.Text = "Xuất File";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(20, 1041);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(173, 81);
            this.btnLuu.TabIndex = 29;
            this.btnLuu.Text = "Lưu File";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnTimFileCu
            // 
            this.btnTimFileCu.Location = new System.Drawing.Point(1492, 516);
            this.btnTimFileCu.Name = "btnTimFileCu";
            this.btnTimFileCu.Size = new System.Drawing.Size(109, 45);
            this.btnTimFileCu.TabIndex = 30;
            this.btnTimFileCu.Text = "Tìm";
            this.btnTimFileCu.UseVisualStyleBackColor = true;
            this.btnTimFileCu.Click += new System.EventHandler(this.btnTimFileCu_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(1220, 529);
            this.dateTimePicker.MaxDate = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(264, 22);
            this.dateTimePicker.TabIndex = 31;
            this.dateTimePicker.Value = new System.DateTime(2020, 9, 11, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(988, 1073);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 32;
            this.label6.Text = "Tổng:";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.ForeColor = System.Drawing.Color.Red;
            this.lbTongTien.Location = new System.Drawing.Point(1053, 1063);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(31, 29);
            this.lbTongTien.TabIndex = 33;
            this.lbTongTien.Text = "...";
            // 
            // btnPhieuIn
            // 
            this.btnPhieuIn.Image = global::Tao_Danh_Sach_San_Pham_Di_Cho.Properties.Resources.Printer_5121;
            this.btnPhieuIn.Location = new System.Drawing.Point(1517, 1052);
            this.btnPhieuIn.Name = "btnPhieuIn";
            this.btnPhieuIn.Size = new System.Drawing.Size(84, 58);
            this.btnPhieuIn.TabIndex = 34;
            this.btnPhieuIn.UseVisualStyleBackColor = true;
            this.btnPhieuIn.Click += new System.EventHandler(this.btnPhieuIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1220, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 375);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // tbxSanPhamThem
            // 
            this.tbxSanPhamThem.Location = new System.Drawing.Point(309, 1054);
            this.tbxSanPhamThem.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSanPhamThem.Name = "tbxSanPhamThem";
            this.tbxSanPhamThem.Size = new System.Drawing.Size(642, 22);
            this.tbxSanPhamThem.TabIndex = 35;
            // 
            // tbxGiaThem
            // 
            this.tbxGiaThem.Location = new System.Drawing.Point(309, 1093);
            this.tbxGiaThem.Margin = new System.Windows.Forms.Padding(4);
            this.tbxGiaThem.Name = "tbxGiaThem";
            this.tbxGiaThem.Size = new System.Drawing.Size(169, 22);
            this.tbxGiaThem.TabIndex = 36;
            this.tbxGiaThem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxGiaThem_KeyDown);
            this.tbxGiaThem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxGiaThem_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 1057);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "Sản phẩm:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 1096);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "Giá:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(543, 1096);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 41;
            this.label10.Text = "Số lượng:";
            // 
            // tbxSoLuongThem
            // 
            this.tbxSoLuongThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tbxSoLuongThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSoLuongThem.Location = new System.Drawing.Point(617, 1092);
            this.tbxSoLuongThem.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSoLuongThem.Name = "tbxSoLuongThem";
            this.tbxSoLuongThem.Size = new System.Drawing.Size(203, 30);
            this.tbxSoLuongThem.TabIndex = 40;
            this.tbxSoLuongThem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSoLuongThem_KeyDown);
            this.tbxSoLuongThem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSoLuongThem_KeyPress);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(866, 1083);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(85, 45);
            this.btnThemMoi.TabIndex = 42;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1630, 1140);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbxSoLuongThem);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxGiaThem);
            this.Controls.Add(this.tbxSanPhamThem);
            this.Controls.Add(this.btnPhieuIn);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.btnTimFileCu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewOutput);
            this.Controls.Add(this.btnThemSanPham);
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbSoLuong);
            this.Controls.Add(this.lbTenSanPham);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dataGridViewSanThuongMai);
            this.Controls.Add(this.dataGridViewKetQua);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxTimkiem);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Phiếu Mua Hàng";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSanThuongMai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxTimkiem;
        private System.Windows.Forms.DataGridView dataGridViewKetQua;
        private System.Windows.Forms.DataGridView dataGridViewSanThuongMai;
        private System.Windows.Forms.DataGridViewTextBoxColumn SanThuongMai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaSanThuongMai;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTenSanPham;
        private System.Windows.Forms.TextBox txbSoLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbGia;
        private System.Windows.Forms.Button btnThemSanPham;
        private System.Windows.Forms.DataGridView dataGridViewOutput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TamTinh;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnTimFileCu;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Button btnPhieuIn;
        private System.Windows.Forms.TextBox tbxSanPhamThem;
        private System.Windows.Forms.TextBox tbxGiaThem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxSoLuongThem;
        private System.Windows.Forms.Button btnThemMoi;
    }
}

