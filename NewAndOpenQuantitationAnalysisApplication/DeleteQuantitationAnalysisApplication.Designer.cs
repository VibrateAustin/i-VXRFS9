namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    partial class DeleteQuantitationAnalysisApplication
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
            this.cbox_deletequantitationanalysisapplication = new System.Windows.Forms.ComboBox();
            this.lab_oldquantitationapplication = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbox_deletequantitationanalysisapplication
            // 
            this.cbox_deletequantitationanalysisapplication.FormattingEnabled = true;
            this.cbox_deletequantitationanalysisapplication.Location = new System.Drawing.Point(100, 90);
            this.cbox_deletequantitationanalysisapplication.Name = "cbox_deletequantitationanalysisapplication";
            this.cbox_deletequantitationanalysisapplication.Size = new System.Drawing.Size(213, 20);
            this.cbox_deletequantitationanalysisapplication.TabIndex = 11;
            // 
            // lab_oldquantitationapplication
            // 
            this.lab_oldquantitationapplication.AutoSize = true;
            this.lab_oldquantitationapplication.Location = new System.Drawing.Point(65, 49);
            this.lab_oldquantitationapplication.Name = "lab_oldquantitationapplication";
            this.lab_oldquantitationapplication.Size = new System.Drawing.Size(113, 12);
            this.lab_oldquantitationapplication.TabIndex = 10;
            this.lab_oldquantitationapplication.Text = "定量分析程序名称：";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(211, 182);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 9;
            this.btn_close.Text = "取消";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(67, 182);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // DeleteQuantitationAnalysisApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 255);
            this.Controls.Add(this.cbox_deletequantitationanalysisapplication);
            this.Controls.Add(this.lab_oldquantitationapplication);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_ok);
            this.Name = "DeleteQuantitationAnalysisApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "删除定量分析程序";
            this.Load += new System.EventHandler(this.DeleteQuantitationAnalysisApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_deletequantitationanalysisapplication;
        private System.Windows.Forms.Label lab_oldquantitationapplication;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_ok;
    }
}