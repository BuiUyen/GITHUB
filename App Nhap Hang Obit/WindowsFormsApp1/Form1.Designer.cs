namespace WindowsFormsApp1
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
            this.tbxLinkExcel = new System.Windows.Forms.TextBox();
            this.btnOpenLink = new System.Windows.Forms.Button();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewKetQua = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTimkiem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewEnd = new System.Windows.Forms.DataGridView();
            this.ID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.điềuChỉnhSốLượngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSanPham = new System.Windows.Forms.Label();
            this.tbxSoLuong = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbGia = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEnd)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxLinkExcel
            // 
            this.tbxLinkExcel.Location = new System.Drawing.Point(108, 15);
            this.tbxLinkExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLinkExcel.Name = "tbxLinkExcel";
            this.tbxLinkExcel.ReadOnly = true;
            this.tbxLinkExcel.Size = new System.Drawing.Size(485, 22);
            this.tbxLinkExcel.TabIndex = 2;
            // 
            // btnOpenLink
            // 
            this.btnOpenLink.Location = new System.Drawing.Point(603, 15);
            this.btnOpenLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenLink.Name = "btnOpenLink";
            this.btnOpenLink.Size = new System.Drawing.Size(100, 25);
            this.btnOpenLink.TabIndex = 3;
            this.btnOpenLink.Text = "...";
            this.btnOpenLink.UseVisualStyleBackColor = true;
            this.btnOpenLink.Click += new System.EventHandler(this.btnOpenLink_Click);
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(548, 142);
            this.dataGridViewData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowHeadersWidth = 51;
            this.dataGridViewData.Size = new System.Drawing.Size(519, 273);
            this.dataGridViewData.TabIndex = 4;
            // 
            // cboSheet
            // 
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(844, 16);
            this.cboSheet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(165, 24);
            this.cboSheet.TabIndex = 5;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(789, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sheet";
            // 
            // dataGridViewKetQua
            // 
            this.dataGridViewKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Ten,
            this.Gia});
            this.dataGridViewKetQua.Location = new System.Drawing.Point(16, 142);
            this.dataGridViewKetQua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewKetQua.MultiSelect = false;
            this.dataGridViewKetQua.Name = "dataGridViewKetQua";
            this.dataGridViewKetQua.ReadOnly = true;
            this.dataGridViewKetQua.RowHeadersWidth = 51;
            this.dataGridViewKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKetQua.Size = new System.Drawing.Size(508, 196);
            this.dataGridViewKetQua.TabIndex = 8;
            this.dataGridViewKetQua.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKetQua_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 30;
            // 
            // Ten
            // 
            this.Ten.HeaderText = "Tên Linh Kiện";
            this.Ten.MinimumWidth = 6;
            this.Ten.Name = "Ten";
            this.Ten.ReadOnly = true;
            this.Ten.Width = 200;
            // 
            // Gia
            // 
            this.Gia.HeaderText = "Giá";
            this.Gia.MinimumWidth = 6;
            this.Gia.Name = "Gia";
            this.Gia.ReadOnly = true;
            this.Gia.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(789, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Data";
            // 
            // tbxTimkiem
            // 
            this.tbxTimkiem.Location = new System.Drawing.Point(108, 73);
            this.tbxTimkiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxTimkiem.Name = "tbxTimkiem";
            this.tbxTimkiem.Size = new System.Drawing.Size(256, 22);
            this.tbxTimkiem.TabIndex = 10;
            this.tbxTimkiem.TextChanged += new System.EventHandler(this.tbxTimkiem_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Đường dẫn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tìm Kiếm:";
            // 
            // dataGridViewEnd
            // 
            this.dataGridViewEnd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEnd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID2,
            this.Ten2,
            this.Gia2,
            this.SoLuong,
            this.ThanhTien});
            this.dataGridViewEnd.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewEnd.Location = new System.Drawing.Point(16, 454);
            this.dataGridViewEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewEnd.Name = "dataGridViewEnd";
            this.dataGridViewEnd.RowHeadersWidth = 51;
            this.dataGridViewEnd.Size = new System.Drawing.Size(1051, 313);
            this.dataGridViewEnd.TabIndex = 13;
            this.dataGridViewEnd.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewEnd_CellMouseUp);
            // 
            // ID2
            // 
            this.ID2.HeaderText = "ID";
            this.ID2.MinimumWidth = 6;
            this.ID2.Name = "ID2";
            this.ID2.Width = 50;
            // 
            // Ten2
            // 
            this.Ten2.HeaderText = "Tên Linh Kiện";
            this.Ten2.MinimumWidth = 6;
            this.Ten2.Name = "Ten2";
            this.Ten2.Width = 400;
            // 
            // Gia2
            // 
            this.Gia2.HeaderText = "Giá";
            this.Gia2.MinimumWidth = 6;
            this.Gia2.Name = "Gia2";
            this.Gia2.Width = 125;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 125;
            // 
            // ThanhTien
            // 
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.MinimumWidth = 6;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.Width = 125;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.điềuChỉnhSốLượngToolStripMenuItem,
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 52);
            // 
            // điềuChỉnhSốLượngToolStripMenuItem
            // 
            this.điềuChỉnhSốLượngToolStripMenuItem.Name = "điềuChỉnhSốLượngToolStripMenuItem";
            this.điềuChỉnhSốLượngToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.điềuChỉnhSốLượngToolStripMenuItem.Text = "Điều chỉnh số lượng";
            this.điềuChỉnhSốLượngToolStripMenuItem.Click += new System.EventHandler(this.điềuChỉnhSốLượngToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 357);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Sản phẩm:";
            // 
            // lbSanPham
            // 
            this.lbSanPham.AutoSize = true;
            this.lbSanPham.Location = new System.Drawing.Point(104, 357);
            this.lbSanPham.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSanPham.Name = "lbSanPham";
            this.lbSanPham.Size = new System.Drawing.Size(20, 17);
            this.lbSanPham.TabIndex = 15;
            this.lbSanPham.Text = "...";
            // 
            // tbxSoLuong
            // 
            this.tbxSoLuong.Location = new System.Drawing.Point(340, 390);
            this.tbxSoLuong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSoLuong.Name = "tbxSoLuong";
            this.tbxSoLuong.Size = new System.Drawing.Size(75, 22);
            this.tbxSoLuong.TabIndex = 16;
            this.tbxSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSoLuong_KeyDown);
            this.tbxSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSoLuong_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(424, 390);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 25);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbGia
            // 
            this.lbGia.AutoSize = true;
            this.lbGia.Location = new System.Drawing.Point(104, 394);
            this.lbGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(24, 17);
            this.lbGia.TabIndex = 18;
            this.lbGia.Text = "0đ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 394);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Giá:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 394);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Số lượng:";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(967, 774);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 28);
            this.btnXuatExcel.TabIndex = 22;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(16, 786);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "UyenDepZai cái nhẹ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 817);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxSoLuong);
            this.Controls.Add(this.lbSanPham);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTimkiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewKetQua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSheet);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.btnOpenLink);
            this.Controls.Add(this.tbxLinkExcel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Tính Giá Linh Kiện";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEnd)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbxLinkExcel;
        private System.Windows.Forms.Button btnOpenLink;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.ComboBox cboSheet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewKetQua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxTimkiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridView dataGridViewEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSanPham;
        private System.Windows.Forms.TextBox tbxSoLuong;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem điềuChỉnhSốLượngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.Label label8;
    }
}

