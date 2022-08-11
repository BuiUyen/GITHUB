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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(782, 338);
            this.btnRun.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(130, 79);
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
            this.dataGridViewInput.Location = new System.Drawing.Point(962, 11);
            this.dataGridViewInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.RowHeadersWidth = 51;
            this.dataGridViewInput.Size = new System.Drawing.Size(353, 592);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 48);
            // 
            // dánToolStripMenuItem
            // 
            this.dánToolStripMenuItem.Name = "dánToolStripMenuItem";
            this.dánToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.dánToolStripMenuItem.Text = "Dán";
            this.dánToolStripMenuItem.Click += new System.EventHandler(this.dánToolStripMenuItem_Click);
            // 
            // xóaTấtCảToolStripMenuItem
            // 
            this.xóaTấtCảToolStripMenuItem.Name = "xóaTấtCảToolStripMenuItem";
            this.xóaTấtCảToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
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
            this.dataGridViewKetQua.Location = new System.Drawing.Point(8, 7);
            this.dataGridViewKetQua.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.dataGridViewKetQua.Name = "dataGridViewKetQua";
            this.dataGridViewKetQua.RowHeadersWidth = 51;
            this.dataGridViewKetQua.RowTemplate.Height = 24;
            this.dataGridViewKetQua.Size = new System.Drawing.Size(722, 514);
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
            this.progressBar1.Location = new System.Drawing.Point(66, 549);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(565, 29);
            this.progressBar1.TabIndex = 43;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(756, 74);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 44;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(756, 122);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 45;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(756, 166);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 17);
            this.checkBox3.TabIndex = 46;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(756, 224);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(80, 17);
            this.checkBox4.TabIndex = 47;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 621);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridViewKetQua);
            this.Controls.Add(this.dataGridViewInput);
            this.Controls.Add(this.btnRun);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Lọc Sản Phẩm Shopee";
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
    }
}

