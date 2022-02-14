namespace TOOL_MEDIBOX
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
            this.tbxModel = new System.Windows.Forms.TextBox();
            this.tbxDB = new System.Windows.Forms.TextBox();
            this.tbxPresenter = new System.Windows.Forms.TextBox();
            this.tbxUtility = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxModel
            // 
            this.tbxModel.Location = new System.Drawing.Point(15, 29);
            this.tbxModel.Multiline = true;
            this.tbxModel.Name = "tbxModel";
            this.tbxModel.Size = new System.Drawing.Size(1061, 495);
            this.tbxModel.TabIndex = 1;
            this.tbxModel.TextChanged += new System.EventHandler(this.tbxModel_TextChanged);
            // 
            // tbxDB
            // 
            this.tbxDB.Location = new System.Drawing.Point(1115, 29);
            this.tbxDB.Multiline = true;
            this.tbxDB.Name = "tbxDB";
            this.tbxDB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDB.Size = new System.Drawing.Size(1061, 495);
            this.tbxDB.TabIndex = 2;
            // 
            // tbxPresenter
            // 
            this.tbxPresenter.Location = new System.Drawing.Point(12, 572);
            this.tbxPresenter.Multiline = true;
            this.tbxPresenter.Name = "tbxPresenter";
            this.tbxPresenter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxPresenter.Size = new System.Drawing.Size(1061, 495);
            this.tbxPresenter.TabIndex = 3;
            // 
            // tbxUtility
            // 
            this.tbxUtility.Location = new System.Drawing.Point(1115, 572);
            this.tbxUtility.Multiline = true;
            this.tbxUtility.Name = "tbxUtility";
            this.tbxUtility.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxUtility.Size = new System.Drawing.Size(1061, 495);
            this.tbxUtility.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1112, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Danh mục DB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 539);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Presenter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1112, 539);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "MediboxDatabaseUtility";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2212, 1096);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxUtility);
            this.Controls.Add(this.tbxPresenter);
            this.Controls.Add(this.tbxDB);
            this.Controls.Add(this.tbxModel);
            this.Name = "Form1";
            this.Text = "Bùi Hữu Uyên TOOL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxModel;
        private System.Windows.Forms.TextBox tbxDB;
        private System.Windows.Forms.TextBox tbxPresenter;
        private System.Windows.Forms.TextBox tbxUtility;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

