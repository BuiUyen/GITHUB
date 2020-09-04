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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataInput)).BeginInit();
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
            this.dataGridViewDataInput.Size = new System.Drawing.Size(1424, 529);
            this.dataGridViewDataInput.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 915);
            this.Controls.Add(this.dataGridViewDataInput);
            this.Controls.Add(this.cbxSheet);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbxLinkFile);
            this.Name = "Form1";
            this.Text = "Xử Lí Chi Phí Lazada - Bùi Hữu Uyên";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxLinkFile;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cbxSheet;
        private System.Windows.Forms.DataGridView dataGridViewDataInput;
    }
}

