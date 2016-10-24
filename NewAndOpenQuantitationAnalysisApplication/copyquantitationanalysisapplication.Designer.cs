namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    partial class copyquantitationanalysisapplication
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lab_oldquantitationapplication = new System.Windows.Forms.Label();
            this.cbox_quantitationanalysisapplication = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(40, 173);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(184, 173);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "取消";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lab_oldquantitationapplication
            // 
            this.lab_oldquantitationapplication.AutoSize = true;
            this.lab_oldquantitationapplication.Location = new System.Drawing.Point(38, 40);
            this.lab_oldquantitationapplication.Name = "lab_oldquantitationapplication";
            this.lab_oldquantitationapplication.Size = new System.Drawing.Size(113, 12);
            this.lab_oldquantitationapplication.TabIndex = 2;
            this.lab_oldquantitationapplication.Text = "定量分析程序名称：";
            // 
            // cbox_quantitationanalysisapplication
            // 
            this.cbox_quantitationanalysisapplication.FormattingEnabled = true;
            this.cbox_quantitationanalysisapplication.Location = new System.Drawing.Point(73, 81);
            this.cbox_quantitationanalysisapplication.Name = "cbox_quantitationanalysisapplication";
            this.cbox_quantitationanalysisapplication.Size = new System.Drawing.Size(213, 20);
            this.cbox_quantitationanalysisapplication.TabIndex = 3;
            // 
            // copyquantitationanalysisapplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 252);
            this.Controls.Add(this.cbox_quantitationanalysisapplication);
            this.Controls.Add(this.lab_oldquantitationapplication);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_ok);
            this.Name = "copyquantitationanalysisapplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定量分析程序";
            this.Load += new System.EventHandler(this.copyquantitationanalysisapplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lab_oldquantitationapplication;
        private System.Windows.Forms.ComboBox cbox_quantitationanalysisapplication;
    }
}