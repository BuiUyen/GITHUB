
namespace Chỉnh_sửa_đồng_bộ_giá
{
    partial class Form2
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
            this.web_sapo = new System.Windows.Forms.WebBrowser();
            this.tbxSKU = new System.Windows.Forms.TextBox();
            this.btnChaySKU = new System.Windows.Forms.Button();
            this.tbxHTML = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxHTML2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(12, 25);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.Size = new System.Drawing.Size(700, 26);
            this.tbxFile.TabIndex = 7;
            // 
            // btnOpenFileExcel
            // 
            this.btnOpenFileExcel.Location = new System.Drawing.Point(730, 14);
            this.btnOpenFileExcel.Name = "btnOpenFileExcel";
            this.btnOpenFileExcel.Size = new System.Drawing.Size(112, 52);
            this.btnOpenFileExcel.TabIndex = 8;
            this.btnOpenFileExcel.Text = "Open";
            this.btnOpenFileExcel.UseVisualStyleBackColor = true;
            this.btnOpenFileExcel.Click += new System.EventHandler(this.btnOpenFileExcel_Click);
            // 
            // cbxSheet
            // 
            this.cbxSheet.FormattingEnabled = true;
            this.cbxSheet.Location = new System.Drawing.Point(880, 25);
            this.cbxSheet.Name = "cbxSheet";
            this.cbxSheet.Size = new System.Drawing.Size(121, 28);
            this.cbxSheet.TabIndex = 9;
            this.cbxSheet.SelectedIndexChanged += new System.EventHandler(this.cbxSheet_SelectedIndexChanged);
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(12, 74);
            this.dataGridViewData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowHeadersWidth = 51;
            this.dataGridViewData.Size = new System.Drawing.Size(1955, 149);
            this.dataGridViewData.TabIndex = 10;
            // 
            // web_sapo
            // 
            this.web_sapo.Location = new System.Drawing.Point(946, 276);
            this.web_sapo.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_sapo.Name = "web_sapo";
            this.web_sapo.Size = new System.Drawing.Size(1021, 1034);
            this.web_sapo.TabIndex = 11;
            // 
            // tbxSKU
            // 
            this.tbxSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSKU.Location = new System.Drawing.Point(12, 248);
            this.tbxSKU.Name = "tbxSKU";
            this.tbxSKU.Size = new System.Drawing.Size(225, 57);
            this.tbxSKU.TabIndex = 12;
            // 
            // btnChaySKU
            // 
            this.btnChaySKU.Location = new System.Drawing.Point(276, 248);
            this.btnChaySKU.Name = "btnChaySKU";
            this.btnChaySKU.Size = new System.Drawing.Size(110, 57);
            this.btnChaySKU.TabIndex = 13;
            this.btnChaySKU.Text = "Xử lý";
            this.btnChaySKU.UseVisualStyleBackColor = true;
            this.btnChaySKU.Click += new System.EventHandler(this.btnChaySKU_Click);
            // 
            // tbxHTML
            // 
            this.tbxHTML.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHTML.Location = new System.Drawing.Point(24, 455);
            this.tbxHTML.Multiline = true;
            this.tbxHTML.Name = "tbxHTML";
            this.tbxHTML.Size = new System.Drawing.Size(324, 585);
            this.tbxHTML.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 681);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 57);
            this.button1.TabIndex = 15;
            this.button1.Text = "Xử lý";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxHTML2
            // 
            this.tbxHTML2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHTML2.Location = new System.Drawing.Point(518, 455);
            this.tbxHTML2.Multiline = true;
            this.tbxHTML2.Name = "tbxHTML2";
            this.tbxHTML2.Size = new System.Drawing.Size(324, 585);
            this.tbxHTML2.TabIndex = 16;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1980, 1332);
            this.Controls.Add(this.tbxHTML2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxHTML);
            this.Controls.Add(this.btnChaySKU);
            this.Controls.Add(this.tbxSKU);
            this.Controls.Add(this.web_sapo);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.tbxFile);
            this.Controls.Add(this.btnOpenFileExcel);
            this.Controls.Add(this.cbxSheet);
            this.Name = "Form2";
            this.Text = "Tạo file text bài viết sản phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.Button btnOpenFileExcel;
        private System.Windows.Forms.ComboBox cbxSheet;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.WebBrowser web_sapo;
        private System.Windows.Forms.TextBox tbxSKU;
        private System.Windows.Forms.Button btnChaySKU;
        private System.Windows.Forms.TextBox tbxHTML;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxHTML2;
    }
}