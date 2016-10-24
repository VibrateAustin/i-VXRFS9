namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    partial class AddCorrectionFactor
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
            this.rbtn_func = new System.Windows.Forms.RadioButton();
            this.rbtn_conc = new System.Windows.Forms.RadioButton();
            this.rbtn_kcps = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstb_LoR = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstb_d = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstb_c = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstb_b = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstb_a = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstb_Loc = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtn_func);
            this.groupBox1.Controls.Add(this.rbtn_conc);
            this.groupBox1.Controls.Add(this.rbtn_kcps);
            this.groupBox1.Location = new System.Drawing.Point(1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "校正类型";
            // 
            // rbtn_func
            // 
            this.rbtn_func.AutoSize = true;
            this.rbtn_func.Location = new System.Drawing.Point(458, 25);
            this.rbtn_func.Name = "rbtn_func";
            this.rbtn_func.Size = new System.Drawing.Size(71, 16);
            this.rbtn_func.TabIndex = 2;
            this.rbtn_func.TabStop = true;
            this.rbtn_func.Text = "计算函数";
            this.rbtn_func.UseVisualStyleBackColor = true;
            // 
            // rbtn_conc
            // 
            this.rbtn_conc.AutoSize = true;
            this.rbtn_conc.Location = new System.Drawing.Point(260, 25);
            this.rbtn_conc.Name = "rbtn_conc";
            this.rbtn_conc.Size = new System.Drawing.Size(47, 16);
            this.rbtn_conc.TabIndex = 1;
            this.rbtn_conc.TabStop = true;
            this.rbtn_conc.Text = "浓度";
            this.rbtn_conc.UseVisualStyleBackColor = true;
            // 
            // rbtn_kcps
            // 
            this.rbtn_kcps.AutoSize = true;
            this.rbtn_kcps.Location = new System.Drawing.Point(66, 25);
            this.rbtn_kcps.Name = "rbtn_kcps";
            this.rbtn_kcps.Size = new System.Drawing.Size(59, 16);
            this.rbtn_kcps.TabIndex = 0;
            this.rbtn_kcps.TabStop = true;
            this.rbtn_kcps.Text = "计数率";
            this.rbtn_kcps.UseVisualStyleBackColor = true;
            this.rbtn_kcps.CheckedChanged += new System.EventHandler(this.rbtn_kcps_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lstb_LoR);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lstb_d);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lstb_c);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lstb_b);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lstb_a);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lstb_Loc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(1, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(682, 274);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "校正";
            // 
            // lstb_LoR
            // 
            this.lstb_LoR.FormattingEnabled = true;
            this.lstb_LoR.ItemHeight = 12;
            this.lstb_LoR.Location = new System.Drawing.Point(130, 63);
            this.lstb_LoR.Name = "lstb_LoR";
            this.lstb_LoR.ScrollAlwaysVisible = true;
            this.lstb_LoR.Size = new System.Drawing.Size(85, 184);
            this.lstb_LoR.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(154, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Lo(R)";
            // 
            // lstb_d
            // 
            this.lstb_d.FormattingEnabled = true;
            this.lstb_d.ItemHeight = 12;
            this.lstb_d.Location = new System.Drawing.Point(573, 63);
            this.lstb_d.Name = "lstb_d";
            this.lstb_d.ScrollAlwaysVisible = true;
            this.lstb_d.Size = new System.Drawing.Size(85, 184);
            this.lstb_d.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(602, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "+γ";
            // 
            // lstb_c
            // 
            this.lstb_c.FormattingEnabled = true;
            this.lstb_c.ItemHeight = 12;
            this.lstb_c.Location = new System.Drawing.Point(462, 63);
            this.lstb_c.Name = "lstb_c";
            this.lstb_c.ScrollAlwaysVisible = true;
            this.lstb_c.Size = new System.Drawing.Size(85, 184);
            this.lstb_c.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "+δ";
            // 
            // lstb_b
            // 
            this.lstb_b.FormattingEnabled = true;
            this.lstb_b.ItemHeight = 12;
            this.lstb_b.Location = new System.Drawing.Point(351, 63);
            this.lstb_b.Name = "lstb_b";
            this.lstb_b.ScrollAlwaysVisible = true;
            this.lstb_b.Size = new System.Drawing.Size(85, 184);
            this.lstb_b.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "+β";
            // 
            // lstb_a
            // 
            this.lstb_a.FormattingEnabled = true;
            this.lstb_a.ItemHeight = 12;
            this.lstb_a.Location = new System.Drawing.Point(238, 63);
            this.lstb_a.Name = "lstb_a";
            this.lstb_a.ScrollAlwaysVisible = true;
            this.lstb_a.Size = new System.Drawing.Size(85, 184);
            this.lstb_a.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "+α";
            // 
            // lstb_Loc
            // 
            this.lstb_Loc.FormattingEnabled = true;
            this.lstb_Loc.ItemHeight = 12;
            this.lstb_Loc.Location = new System.Drawing.Point(17, 63);
            this.lstb_Loc.Name = "lstb_Loc";
            this.lstb_Loc.ScrollAlwaysVisible = true;
            this.lstb_Loc.Size = new System.Drawing.Size(85, 184);
            this.lstb_Loc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lo(C)";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(40, 377);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(168, 377);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 3;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // AddCorrectionFactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 432);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(700, 470);
            this.MinimumSize = new System.Drawing.Size(700, 470);
            this.Name = "AddCorrectionFactor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加系数校正因子";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddCorrectionFactor_FormClosed);
            this.Load += new System.EventHandler(this.AddCorrectionFactor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn_kcps;
        private System.Windows.Forms.RadioButton rbtn_func;
        private System.Windows.Forms.RadioButton rbtn_conc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstb_c;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstb_b;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstb_a;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstb_Loc;
        private System.Windows.Forms.ListBox lstb_d;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.ListBox lstb_LoR;
        private System.Windows.Forms.Label label6;
    }
}