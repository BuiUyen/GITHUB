
namespace Chỉnh_sửa_đồng_bộ_giá
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewData_Goc = new System.Windows.Forms.DataGridView();
            this.cbxSheet = new System.Windows.Forms.ComboBox();
            this.btnOpenFileExcel = new System.Windows.Forms.Button();
            this.tbxFile = new System.Windows.Forms.TextBox();
            this.dataGridViewInput = new System.Windows.Forms.DataGridView();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSapo = new System.Windows.Forms.TabPage();
            this.tabShopee = new System.Windows.Forms.TabPage();
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
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXuLy = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData_Goc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSapo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewData_Goc
            // 
            this.dataGridViewData_Goc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData_Goc.Location = new System.Drawing.Point(6, 72);
            this.dataGridViewData_Goc.Name = "dataGridViewData_Goc";
            this.dataGridViewData_Goc.RowHeadersWidth = 51;
            this.dataGridViewData_Goc.Size = new System.Drawing.Size(1592, 311);
            this.dataGridViewData_Goc.TabIndex = 7;
            // 
            // cbxSheet
            // 
            this.cbxSheet.FormattingEnabled = true;
            this.cbxSheet.Location = new System.Drawing.Point(559, 22);
            this.cbxSheet.Name = "cbxSheet";
            this.cbxSheet.Size = new System.Drawing.Size(121, 28);
            this.cbxSheet.TabIndex = 6;
            this.cbxSheet.SelectedIndexChanged += new System.EventHandler(this.cbxSheet_SelectedIndexChanged);
            // 
            // btnOpenFileExcel
            // 
            this.btnOpenFileExcel.Location = new System.Drawing.Point(467, 14);
            this.btnOpenFileExcel.Name = "btnOpenFileExcel";
            this.btnOpenFileExcel.Size = new System.Drawing.Size(75, 43);
            this.btnOpenFileExcel.TabIndex = 5;
            this.btnOpenFileExcel.Text = "Open";
            this.btnOpenFileExcel.UseVisualStyleBackColor = true;
            this.btnOpenFileExcel.Click += new System.EventHandler(this.btnOpenFileExcel_Click);
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(6, 22);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.Size = new System.Drawing.Size(440, 26);
            this.tbxFile.TabIndex = 4;
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SKU,
            this.GiaBan});
            this.dataGridViewInput.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewInput.Location = new System.Drawing.Point(1744, 45);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.RowHeadersWidth = 51;
            this.dataGridViewInput.Size = new System.Drawing.Size(616, 1157);
            this.dataGridViewInput.TabIndex = 8;
            this.dataGridViewInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewInput_KeyDown);
            // 
            // SKU
            // 
            this.SKU.HeaderText = "Mã SKU*";
            this.SKU.MinimumWidth = 8;
            this.SKU.Name = "SKU";
            this.SKU.Width = 150;
            // 
            // GiaBan
            // 
            this.GiaBan.HeaderText = "Giá bán lẻ*";
            this.GiaBan.MinimumWidth = 8;
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dánToolStripMenuItem,
            this.xóaTấtCảToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 68);
            // 
            // dánToolStripMenuItem
            // 
            this.dánToolStripMenuItem.Name = "dánToolStripMenuItem";
            this.dánToolStripMenuItem.Size = new System.Drawing.Size(169, 32);
            this.dánToolStripMenuItem.Text = "Dán";
            this.dánToolStripMenuItem.Click += new System.EventHandler(this.dánToolStripMenuItem_Click);
            // 
            // xóaTấtCảToolStripMenuItem
            // 
            this.xóaTấtCảToolStripMenuItem.Name = "xóaTấtCảToolStripMenuItem";
            this.xóaTấtCảToolStripMenuItem.Size = new System.Drawing.Size(169, 32);
            this.xóaTấtCảToolStripMenuItem.Text = "Xóa Tất Cả";
            this.xóaTấtCảToolStripMenuItem.Click += new System.EventHandler(this.xóaTấtCảToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSapo);
            this.tabControl1.Controls.Add(this.tabShopee);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1614, 1190);
            this.tabControl1.TabIndex = 10;
            // 
            // tabSapo
            // 
            this.tabSapo.Controls.Add(this.label1);
            this.tabSapo.Controls.Add(this.dataGridViewKetQua);
            this.tabSapo.Controls.Add(this.dataGridViewData_Goc);
            this.tabSapo.Controls.Add(this.tbxFile);
            this.tabSapo.Controls.Add(this.btnOpenFileExcel);
            this.tabSapo.Controls.Add(this.cbxSheet);
            this.tabSapo.Location = new System.Drawing.Point(4, 29);
            this.tabSapo.Name = "tabSapo";
            this.tabSapo.Padding = new System.Windows.Forms.Padding(3);
            this.tabSapo.Size = new System.Drawing.Size(1606, 1157);
            this.tabSapo.TabIndex = 0;
            this.tabSapo.Text = "Sapo";
            this.tabSapo.UseVisualStyleBackColor = true;
            // 
            // tabShopee
            // 
            this.tabShopee.Location = new System.Drawing.Point(4, 29);
            this.tabShopee.Name = "tabShopee";
            this.tabShopee.Padding = new System.Windows.Forms.Padding(3);
            this.tabShopee.Size = new System.Drawing.Size(1616, 954);
            this.tabShopee.TabIndex = 1;
            this.tabShopee.Text = "Shopee";
            this.tabShopee.UseVisualStyleBackColor = true;
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
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column27,
            this.Column28});
            this.dataGridViewKetQua.Location = new System.Drawing.Point(6, 479);
            this.dataGridViewKetQua.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewKetQua.Name = "dataGridViewKetQua";
            this.dataGridViewKetQua.RowHeadersWidth = 51;
            this.dataGridViewKetQua.RowTemplate.Height = 24;
            this.dataGridViewKetQua.Size = new System.Drawing.Size(1592, 673);
            this.dataGridViewKetQua.TabIndex = 41;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tên sản phẩm*";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Hình thức quản lý sản phẩm";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Loại sản phẩm";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Mô tả sản phẩm";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Nhãn hiệu";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Tags";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Thuộc tính 1";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Giá trị thuộc tính 1";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Thuộc tính 2";
            this.Column9.MinimumWidth = 8;
            this.Column9.Name = "Column9";
            this.Column9.Width = 150;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Giá trị thuộc tính 2";
            this.Column10.MinimumWidth = 8;
            this.Column10.Name = "Column10";
            this.Column10.Width = 150;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Thuộc tính 3";
            this.Column11.MinimumWidth = 8;
            this.Column11.Name = "Column11";
            this.Column11.Width = 150;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Giá trị thuộc tính 3";
            this.Column12.MinimumWidth = 8;
            this.Column12.Name = "Column12";
            this.Column12.Width = 150;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Tên phiên bản sản phẩm";
            this.Column13.MinimumWidth = 8;
            this.Column13.Name = "Column13";
            this.Column13.Width = 150;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Mã SKU*";
            this.Column14.MinimumWidth = 8;
            this.Column14.Name = "Column14";
            this.Column14.Width = 150;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Barcode";
            this.Column15.MinimumWidth = 8;
            this.Column15.Name = "Column15";
            this.Column15.Width = 150;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Khối lượng";
            this.Column16.MinimumWidth = 8;
            this.Column16.Name = "Column16";
            this.Column16.Width = 150;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "Đơn vị khối lượng";
            this.Column17.MinimumWidth = 8;
            this.Column17.Name = "Column17";
            this.Column17.Width = 150;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "Ảnh đại diện";
            this.Column18.MinimumWidth = 8;
            this.Column18.Name = "Column18";
            this.Column18.Width = 150;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "Đơn vị";
            this.Column19.MinimumWidth = 8;
            this.Column19.Name = "Column19";
            this.Column19.Width = 150;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "Áp dụng thuế";
            this.Column20.MinimumWidth = 8;
            this.Column20.Name = "Column20";
            this.Column20.Width = 150;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "LC_CN1_Giá vốn khởi tạo*";
            this.Column21.MinimumWidth = 8;
            this.Column21.Name = "Column21";
            this.Column21.Width = 150;
            // 
            // Column22
            // 
            this.Column22.HeaderText = "LC_CN1_Tồn kho ban đầu*";
            this.Column22.MinimumWidth = 8;
            this.Column22.Name = "Column22";
            this.Column22.Width = 150;
            // 
            // Column23
            // 
            this.Column23.HeaderText = "LC_CN1_Tồn tối thiểu";
            this.Column23.MinimumWidth = 8;
            this.Column23.Name = "Column23";
            this.Column23.Width = 150;
            // 
            // Column24
            // 
            this.Column24.HeaderText = "LC_CN1_Tồn tối đa";
            this.Column24.MinimumWidth = 8;
            this.Column24.Name = "Column24";
            this.Column24.Width = 150;
            // 
            // Column25
            // 
            this.Column25.HeaderText = "LC_CN1_Điểm lưu kho";
            this.Column25.MinimumWidth = 8;
            this.Column25.Name = "Column25";
            this.Column25.Width = 150;
            // 
            // Column26
            // 
            this.Column26.HeaderText = "PL_Giá bán buôn";
            this.Column26.MinimumWidth = 8;
            this.Column26.Name = "Column26";
            this.Column26.Width = 150;
            // 
            // Column27
            // 
            this.Column27.HeaderText = "PL_Giá nhập";
            this.Column27.MinimumWidth = 8;
            this.Column27.Name = "Column27";
            this.Column27.Width = 150;
            // 
            // Column28
            // 
            this.Column28.HeaderText = "PL_Giá bán lẻ";
            this.Column28.MinimumWidth = 8;
            this.Column28.Name = "Column28";
            this.Column28.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Bảng Kết Quả Cập Nhật";
            // 
            // btnXuLy
            // 
            this.btnXuLy.Location = new System.Drawing.Point(1628, 248);
            this.btnXuLy.Name = "btnXuLy";
            this.btnXuLy.Size = new System.Drawing.Size(110, 110);
            this.btnXuLy.TabIndex = 11;
            this.btnXuLy.Text = "Xử Lý";
            this.btnXuLy.UseVisualStyleBackColor = true;
            this.btnXuLy.Click += new System.EventHandler(this.btnXuLy_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.Location = new System.Drawing.Point(1628, 1158);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(110, 35);
            this.btnXuat.TabIndex = 12;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2371, 1214);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.btnXuLy);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridViewInput);
            this.Name = "Form1";
            this.Text = "Điều chỉnh hàng loạt giá Sapo và Shopee";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData_Goc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabSapo.ResumeLayout(false);
            this.tabSapo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewData_Goc;
        private System.Windows.Forms.ComboBox cbxSheet;
        private System.Windows.Forms.Button btnOpenFileExcel;
        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.DataGridView dataGridViewInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSapo;
        private System.Windows.Forms.TabPage tabShopee;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaTấtCảToolStripMenuItem;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXuLy;
        private System.Windows.Forms.Button btnXuat;
    }
}

