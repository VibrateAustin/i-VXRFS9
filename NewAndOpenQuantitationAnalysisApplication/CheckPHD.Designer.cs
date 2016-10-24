namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    partial class CheckPHD
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbox_noloadsample = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtb_steptime = new System.Windows.Forms.TextBox();
            this.txtb_step = new System.Windows.Forms.TextBox();
            this.cbox_mask = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PHD_ul = new System.Windows.Forms.Label();
            this.PHD_ll = new System.Windows.Forms.Label();
            this.peak_position = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picb_phdresult = new System.Windows.Forms.PictureBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_loadsample = new System.Windows.Forms.Button();
            this.btn_measurement = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_phdresult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ckbox_noloadsample);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtb_steptime);
            this.groupBox1.Controls.Add(this.txtb_step);
            this.groupBox1.Controls.Add(this.cbox_mask);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1077, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PHD参数";
            // 
            // ckbox_noloadsample
            // 
            this.ckbox_noloadsample.AutoSize = true;
            this.ckbox_noloadsample.Location = new System.Drawing.Point(285, 54);
            this.ckbox_noloadsample.Name = "ckbox_noloadsample";
            this.ckbox_noloadsample.Size = new System.Drawing.Size(120, 16);
            this.ckbox_noloadsample.TabIndex = 6;
            this.ckbox_noloadsample.Text = "测量后不载出样品";
            this.ckbox_noloadsample.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "步长时间(s)：";
            // 
            // txtb_steptime
            // 
            this.txtb_steptime.Location = new System.Drawing.Point(368, 23);
            this.txtb_steptime.Name = "txtb_steptime";
            this.txtb_steptime.Size = new System.Drawing.Size(100, 21);
            this.txtb_steptime.TabIndex = 4;
            // 
            // txtb_step
            // 
            this.txtb_step.Location = new System.Drawing.Point(128, 23);
            this.txtb_step.Name = "txtb_step";
            this.txtb_step.Size = new System.Drawing.Size(121, 21);
            this.txtb_step.TabIndex = 3;
            // 
            // cbox_mask
            // 
            this.cbox_mask.FormattingEnabled = true;
            this.cbox_mask.Items.AddRange(new object[] {
            "5",
            "8",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35"});
            this.cbox_mask.Location = new System.Drawing.Point(128, 52);
            this.cbox_mask.Name = "cbox_mask";
            this.cbox_mask.Size = new System.Drawing.Size(121, 20);
            this.cbox_mask.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "面罩：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "步长：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.PHD_ul);
            this.groupBox2.Controls.Add(this.PHD_ll);
            this.groupBox2.Controls.Add(this.peak_position);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.picb_phdresult);
            this.groupBox2.Location = new System.Drawing.Point(3, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1077, 538);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PHD结果";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 504);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 504);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(96, 504);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "label7";
            // 
            // PHD_ul
            // 
            this.PHD_ul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PHD_ul.AutoSize = true;
            this.PHD_ul.Location = new System.Drawing.Point(274, 504);
            this.PHD_ul.Name = "PHD_ul";
            this.PHD_ul.Size = new System.Drawing.Size(0, 12);
            this.PHD_ul.TabIndex = 6;
            // 
            // PHD_ll
            // 
            this.PHD_ll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PHD_ll.AutoSize = true;
            this.PHD_ll.Location = new System.Drawing.Point(208, 504);
            this.PHD_ll.Name = "PHD_ll";
            this.PHD_ll.Size = new System.Drawing.Size(0, 12);
            this.PHD_ll.TabIndex = 5;
            // 
            // peak_position
            // 
            this.peak_position.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.peak_position.AutoSize = true;
            this.peak_position.Location = new System.Drawing.Point(96, 504);
            this.peak_position.Name = "peak_position";
            this.peak_position.Size = new System.Drawing.Size(0, 12);
            this.peak_position.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 504);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "UL:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 504);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "PHD LL:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 504);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "峰值位置：";
            // 
            // picb_phdresult
            // 
            this.picb_phdresult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picb_phdresult.BackColor = System.Drawing.Color.White;
            this.picb_phdresult.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picb_phdresult.Location = new System.Drawing.Point(6, 20);
            this.picb_phdresult.Name = "picb_phdresult";
            this.picb_phdresult.Size = new System.Drawing.Size(1065, 466);
            this.picb_phdresult.TabIndex = 0;
            this.picb_phdresult.TabStop = false;
            this.picb_phdresult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picb_phdresult_MouseClick);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ok.Location = new System.Drawing.Point(28, 665);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancle.Location = new System.Drawing.Point(131, 665);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 3;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_loadsample
            // 
            this.btn_loadsample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_loadsample.Location = new System.Drawing.Point(234, 665);
            this.btn_loadsample.Name = "btn_loadsample";
            this.btn_loadsample.Size = new System.Drawing.Size(75, 23);
            this.btn_loadsample.TabIndex = 4;
            this.btn_loadsample.Text = "加载";
            this.btn_loadsample.UseVisualStyleBackColor = true;
            // 
            // btn_measurement
            // 
            this.btn_measurement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_measurement.Location = new System.Drawing.Point(333, 665);
            this.btn_measurement.Name = "btn_measurement";
            this.btn_measurement.Size = new System.Drawing.Size(75, 23);
            this.btn_measurement.TabIndex = 5;
            this.btn_measurement.Text = "测量";
            this.btn_measurement.UseVisualStyleBackColor = true;
            // 
            // CheckPHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 712);
            this.Controls.Add(this.btn_measurement);
            this.Controls.Add(this.btn_loadsample);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1100, 750);
            this.MinimumSize = new System.Drawing.Size(1100, 726);
            this.Name = "CheckPHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检查PHD值";
            this.Load += new System.EventHandler(this.CheckPHD_QuantitaionAnalysis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_phdresult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckbox_noloadsample;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtb_steptime;
        private System.Windows.Forms.TextBox txtb_step;
        private System.Windows.Forms.ComboBox cbox_mask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_loadsample;
        private System.Windows.Forms.Button btn_measurement;
        private System.Windows.Forms.PictureBox picb_phdresult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label peak_position;
        private System.Windows.Forms.Label PHD_ll;
        private System.Windows.Forms.Label PHD_ul;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}