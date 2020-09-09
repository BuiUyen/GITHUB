namespace Doi_Soat_Doanh_Thu_Lazada
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
            this.tbxLinkFile = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cbxSheet = new System.Windows.Forms.ComboBox();
            this.dataGridViewDataInput = new System.Windows.Forms.DataGridView();
            this.dataGridViewDataOutput = new System.Windows.Forms.DataGridView();
            this.btnXuLi = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxLinkFile
            // 
            this.tbxLinkFile.Location = new System.Drawing.Point(12, 12);
            this.tbxLinkFile.Name = "tbxLinkFile";
            this.tbxLinkFile.Size = new System.Drawing.Size(1066, 22);
            this.tbxLinkFile.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(1094, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(127, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cbxSheet
            // 
            this.cbxSheet.FormattingEnabled = true;
            this.cbxSheet.Location = new System.Drawing.Point(1239, 12);
            this.cbxSheet.Name = "cbxSheet";
            this.cbxSheet.Size = new System.Drawing.Size(197, 24);
            this.cbxSheet.TabIndex = 2;
            this.cbxSheet.SelectedIndexChanged += new System.EventHandler(this.cbxSheet_SelectedIndexChanged);
            // 
            // dataGridViewDataInput
            // 
            this.dataGridViewDataInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataInput.Location = new System.Drawing.Point(12, 62);
            this.dataGridViewDataInput.Name = "dataGridViewDataInput";
            this.dataGridViewDataInput.RowHeadersWidth = 51;
            this.dataGridViewDataInput.RowTemplate.Height = 24;
            this.dataGridViewDataInput.Size = new System.Drawing.Size(1424, 508);
            this.dataGridViewDataInput.TabIndex = 3;
            // 
            // dataGridViewDataOutput
            // 
            this.dataGridViewDataOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridViewDataOutput.Location = new System.Drawing.Point(12, 900);
            this.dataGridViewDataOutput.Name = "dataGridViewDataOutput";
            this.dataGridViewDataOutput.RowHeadersWidth = 51;
            this.dataGridViewDataOutput.RowTemplate.Height = 24;
            this.dataGridViewDataOutput.Size = new System.Drawing.Size(1424, 643);
            this.dataGridViewDataOutput.TabIndex = 4;
            // 
            // btnXuLi
            // 
            this.btnXuLi.Location = new System.Drawing.Point(409, 712);
            this.btnXuLi.Name = "btnXuLi";
            this.btnXuLi.Size = new System.Drawing.Size(75, 23);
            this.btnXuLi.TabIndex = 5;
            this.btnXuLi.Text = "button1";
            this.btnXuLi.UseVisualStyleBackColor = true;
            this.btnXuLi.Click += new System.EventHandler(this.btnXuLi_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã Đơn Hàng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Giá Trị Đơn Hàng Ban Đầu";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Giá Trị Đơn Hàng";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tiền Nhận Thực Tế";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tổng Phí";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 1555);
            this.Controls.Add(this.btnXuLi);
            this.Controls.Add(this.dataGridViewDataOutput);
            this.Controls.Add(this.dataGridViewDataInput);
            this.Controls.Add(this.cbxSheet);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbxLinkFile);
            this.Name = "Form1";
            this.Text = "Xử Lí Chi Phí Lazada - Bùi Hữu Uyên";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxLinkFile;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cbxSheet;
        private System.Windows.Forms.DataGridView dataGridViewDataInput;
        private System.Windows.Forms.DataGridView dataGridViewDataOutput;
        private System.Windows.Forms.Button btnXuLi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}

