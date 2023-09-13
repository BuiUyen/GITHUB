namespace Checker
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
            this.btnRun = new System.Windows.Forms.Button();
            this.dataGridViewInput = new System.Windows.Forms.DataGridView();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewKetQua = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBoxSKU = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxTenSanPham = new System.Windows.Forms.CheckBox();
            this.checkBoxAnh = new System.Windows.Forms.CheckBox();
            this.checkBoxBaiViet = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(1067, 377);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(173, 97);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Chạy tool";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Link,
            this.TenSanPham,
            this.MaSanPham});
            this.dataGridViewInput.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewInput.Location = new System.Drawing.Point(1343, 14);
            this.dataGridViewInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.RowHeadersWidth = 51;
            this.dataGridViewInput.Size = new System.Drawing.Size(471, 729);
            this.dataGridViewInput.TabIndex = 9;
            // 
            // Link
            // 
            this.Link.HeaderText = "Link*";
            this.Link.MinimumWidth = 8;
            this.Link.Name = "Link";
            this.Link.Width = 150;
            // 
            // TenSanPham
            // 
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.MinimumWidth = 8;
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.Width = 150;
            // 
            // MaSanPham
            // 
            this.MaSanPham.HeaderText = "Mã SKU";
            this.MaSanPham.MinimumWidth = 8;
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.Width = 150;
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
            // dataGridViewKetQua
            // 
            this.dataGridViewKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewKetQua.Location = new System.Drawing.Point(11, 9);
            this.dataGridViewKetQua.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridViewKetQua.Name = "dataGridViewKetQua";
            this.dataGridViewKetQua.RowHeadersWidth = 51;
            this.dataGridViewKetQua.RowTemplate.Height = 24;
            this.dataGridViewKetQua.Size = new System.Drawing.Size(963, 633);
            this.dataGridViewKetQua.TabIndex = 42;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID sản phẩm";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên sản phẩm";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "SKU";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Đã đăng";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(88, 676);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(753, 36);
            this.progressBar1.TabIndex = 43;
            // 
            // checkBoxSKU
            // 
            this.checkBoxSKU.AutoSize = true;
            this.checkBoxSKU.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSKU.Location = new System.Drawing.Point(996, 53);
            this.checkBoxSKU.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSKU.Name = "checkBoxSKU";
            this.checkBoxSKU.Size = new System.Drawing.Size(179, 40);
            this.checkBoxSKU.TabIndex = 44;
            this.checkBoxSKU.Text = "Sửa SKU";
            this.checkBoxSKU.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1027, 652);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 97);
            this.button1.TabIndex = 48;
            this.button1.Text = "Chạy tool";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxTenSanPham
            // 
            this.checkBoxTenSanPham.AutoSize = true;
            this.checkBoxTenSanPham.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTenSanPham.Location = new System.Drawing.Point(996, 119);
            this.checkBoxTenSanPham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxTenSanPham.Name = "checkBoxTenSanPham";
            this.checkBoxTenSanPham.Size = new System.Drawing.Size(333, 40);
            this.checkBoxTenSanPham.TabIndex = 49;
            this.checkBoxTenSanPham.Text = "Sửa Tên Sản Phẩm";
            this.checkBoxTenSanPham.UseVisualStyleBackColor = true;
            // 
            // checkBoxAnh
            // 
            this.checkBoxAnh.AutoSize = true;
            this.checkBoxAnh.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAnh.Location = new System.Drawing.Point(996, 191);
            this.checkBoxAnh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAnh.Name = "checkBoxAnh";
            this.checkBoxAnh.Size = new System.Drawing.Size(174, 40);
            this.checkBoxAnh.TabIndex = 50;
            this.checkBoxAnh.Text = "Sửa Ảnh";
            this.checkBoxAnh.UseVisualStyleBackColor = true;
            // 
            // checkBoxBaiViet
            // 
            this.checkBoxBaiViet.AutoSize = true;
            this.checkBoxBaiViet.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxBaiViet.Location = new System.Drawing.Point(996, 267);
            this.checkBoxBaiViet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxBaiViet.Name = "checkBoxBaiViet";
            this.checkBoxBaiViet.Size = new System.Drawing.Size(229, 40);
            this.checkBoxBaiViet.TabIndex = 51;
            this.checkBoxBaiViet.Text = "Sửa Bài Viết";
            this.checkBoxBaiViet.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1828, 770);
            this.Controls.Add(this.checkBoxBaiViet);
            this.Controls.Add(this.checkBoxAnh);
            this.Controls.Add(this.checkBoxTenSanPham);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxSKU);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridViewKetQua);
            this.Controls.Add(this.dataGridViewInput);
            this.Controls.Add(this.btnRun);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Chỉnh Sửa Sàn Sendo - Uyên";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataGridView dataGridViewInput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaTấtCảToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBoxSKU;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxTenSanPham;
        private System.Windows.Forms.CheckBox checkBoxAnh;
        private System.Windows.Forms.CheckBox checkBoxBaiViet;
    }
}

