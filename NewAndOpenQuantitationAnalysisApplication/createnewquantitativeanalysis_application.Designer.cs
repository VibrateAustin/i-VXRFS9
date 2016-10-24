namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    partial class createnewquantitativeanalysis_application
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
            this.lab_newquantitationapplication = new System.Windows.Forms.Label();
            this.txt_newquantitationapplication = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_copy = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.lab_num = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_newquantitationapplication
            // 
            this.lab_newquantitationapplication.AutoSize = true;
            this.lab_newquantitationapplication.Location = new System.Drawing.Point(28, 67);
            this.lab_newquantitationapplication.Name = "lab_newquantitationapplication";
            this.lab_newquantitationapplication.Size = new System.Drawing.Size(113, 12);
            this.lab_newquantitationapplication.TabIndex = 0;
            this.lab_newquantitationapplication.Text = "定量分析程序名称：";
            // 
            // txt_newquantitationapplication
            // 
            this.txt_newquantitationapplication.Location = new System.Drawing.Point(148, 64);
            this.txt_newquantitationapplication.Name = "txt_newquantitationapplication";
            this.txt_newquantitationapplication.Size = new System.Drawing.Size(221, 21);
            this.txt_newquantitationapplication.TabIndex = 1;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(45, 151);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(279, 151);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(75, 23);
            this.btn_copy.TabIndex = 3;
            this.btn_copy.Text = "复制";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(158, 151);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 4;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // lab_num
            // 
            this.lab_num.AutoSize = true;
            this.lab_num.Location = new System.Drawing.Point(302, 207);
            this.lab_num.Name = "lab_num";
            this.lab_num.Size = new System.Drawing.Size(0, 12);
            this.lab_num.TabIndex = 5;
            this.lab_num.Visible = false;
            // 
            // createnewquantitativeanalysis_application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(414, 231);
            this.Controls.Add(this.lab_num);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_copy);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_newquantitationapplication);
            this.Controls.Add(this.lab_newquantitationapplication);
            this.Name = "createnewquantitativeanalysis_application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建定量分析程序";
            this.Load += new System.EventHandler(this.createnewquantitativeanalysis_application_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_newquantitationapplication;
        private System.Windows.Forms.TextBox txt_newquantitationapplication;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Label lab_num;
    }
}