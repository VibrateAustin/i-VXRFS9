﻿namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision
{
    partial class DeleteDriftCorrectionApplication
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
            this.cbox_deletedriftcorrectionapplication = new System.Windows.Forms.ComboBox();
            this.lab_oldquantitationapplication = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbox_deletedriftcorrectionapplication
            // 
            this.cbox_deletedriftcorrectionapplication.FormattingEnabled = true;
            this.cbox_deletedriftcorrectionapplication.Location = new System.Drawing.Point(110, 97);
            this.cbox_deletedriftcorrectionapplication.Name = "cbox_deletedriftcorrectionapplication";
            this.cbox_deletedriftcorrectionapplication.Size = new System.Drawing.Size(213, 20);
            this.cbox_deletedriftcorrectionapplication.TabIndex = 15;
            // 
            // lab_oldquantitationapplication
            // 
            this.lab_oldquantitationapplication.AutoSize = true;
            this.lab_oldquantitationapplication.Location = new System.Drawing.Point(75, 56);
            this.lab_oldquantitationapplication.Name = "lab_oldquantitationapplication";
            this.lab_oldquantitationapplication.Size = new System.Drawing.Size(113, 12);
            this.lab_oldquantitationapplication.TabIndex = 14;
            this.lab_oldquantitationapplication.Text = "漂移校正程序名称：";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(221, 189);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 13;
            this.btn_close.Text = "取消";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(77, 189);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // DeleteDriftCorrectionApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 268);
            this.Controls.Add(this.cbox_deletedriftcorrectionapplication);
            this.Controls.Add(this.lab_oldquantitationapplication);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_ok);
            this.Name = "DeleteDriftCorrectionApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "删除漂移校正程序";
            this.Load += new System.EventHandler(this.DeleteDriftCorrectionApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_deletedriftcorrectionapplication;
        private System.Windows.Forms.Label lab_oldquantitationapplication;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_ok;
    }
}