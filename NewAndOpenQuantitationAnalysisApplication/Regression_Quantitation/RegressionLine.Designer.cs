namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    partial class RegressionLine
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
            this.curveBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.isShowRMS = new System.Windows.Forms.CheckBox();
            this.isShowReg = new System.Windows.Forms.CheckBox();
            this.isShowDEF = new System.Windows.Forms.CheckBox();
            this.isShowExp = new System.Windows.Forms.CheckBox();
            this.isInterval = new System.Windows.Forms.CheckBox();
            this.intervalBox2 = new System.Windows.Forms.TextBox();
            this.intervalBox1 = new System.Windows.Forms.TextBox();
            this.intervalButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.nameLable = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.maxXLable = new System.Windows.Forms.Label();
            this.maxYLable = new System.Windows.Forms.Label();
            this.preButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.calcButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lab_equation = new System.Windows.Forms.Label();
            this.lab_equation2 = new System.Windows.Forms.Label();
            this.lab_equation3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.curveBox)).BeginInit();
            this.SuspendLayout();
            // 
            // curveBox
            // 
            this.curveBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.curveBox.Location = new System.Drawing.Point(19, 156);
            this.curveBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.curveBox.Name = "curveBox";
            this.curveBox.Size = new System.Drawing.Size(1064, 386);
            this.curveBox.TabIndex = 0;
            this.curveBox.TabStop = false;
            this.curveBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.curveBox_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "标样信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "计算结果";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "测量时间:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "浓度(回归值%):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Y/kcps";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "断点:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "标样:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 50);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "浓度(标准值%):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(379, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "计数率(kcps):";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(302, 46);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(76, 21);
            this.textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(461, 43);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(76, 21);
            this.textBox2.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(302, 23);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(76, 21);
            this.textBox3.TabIndex = 15;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(78, 23);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(76, 21);
            this.textBox4.TabIndex = 16;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(129, 46);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(76, 21);
            this.textBox5.TabIndex = 17;
            // 
            // isShowRMS
            // 
            this.isShowRMS.AutoSize = true;
            this.isShowRMS.Location = new System.Drawing.Point(32, 84);
            this.isShowRMS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.isShowRMS.Name = "isShowRMS";
            this.isShowRMS.Size = new System.Drawing.Size(96, 16);
            this.isShowRMS.TabIndex = 18;
            this.isShowRMS.Text = "显示RMS.RE.K";
            this.isShowRMS.UseVisualStyleBackColor = true;
            this.isShowRMS.CheckedChanged += new System.EventHandler(this.isShowRMS_CheckedChanged);
            // 
            // isShowReg
            // 
            this.isShowReg.AutoSize = true;
            this.isShowReg.Location = new System.Drawing.Point(148, 106);
            this.isShowReg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.isShowReg.Name = "isShowReg";
            this.isShowReg.Size = new System.Drawing.Size(84, 16);
            this.isShowReg.TabIndex = 19;
            this.isShowReg.Text = "显示回归线";
            this.isShowReg.UseVisualStyleBackColor = true;
            this.isShowReg.CheckedChanged += new System.EventHandler(this.isShow_CheckedChanged);
            // 
            // isShowDEF
            // 
            this.isShowDEF.AutoSize = true;
            this.isShowDEF.Location = new System.Drawing.Point(32, 106);
            this.isShowDEF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.isShowDEF.Name = "isShowDEF";
            this.isShowDEF.Size = new System.Drawing.Size(78, 16);
            this.isShowDEF.TabIndex = 20;
            this.isShowDEF.Text = "显示D.E.F";
            this.isShowDEF.UseVisualStyleBackColor = true;
            this.isShowDEF.CheckedChanged += new System.EventHandler(this.isShowDEF_CheckedChanged);
            // 
            // isShowExp
            // 
            this.isShowExp.AutoSize = true;
            this.isShowExp.Location = new System.Drawing.Point(148, 84);
            this.isShowExp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.isShowExp.Name = "isShowExp";
            this.isShowExp.Size = new System.Drawing.Size(96, 16);
            this.isShowExp.TabIndex = 21;
            this.isShowExp.Text = "显示指数常数";
            this.isShowExp.UseVisualStyleBackColor = true;
            this.isShowExp.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // isInterval
            // 
            this.isInterval.AutoSize = true;
            this.isInterval.Location = new System.Drawing.Point(260, 84);
            this.isInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.isInterval.Name = "isInterval";
            this.isInterval.Size = new System.Drawing.Size(72, 16);
            this.isInterval.TabIndex = 22;
            this.isInterval.Text = "是否分段";
            this.isInterval.UseVisualStyleBackColor = true;
            this.isInterval.CheckedChanged += new System.EventHandler(this.isInterval_CheckedChanged);
            // 
            // intervalBox2
            // 
            this.intervalBox2.Enabled = false;
            this.intervalBox2.Location = new System.Drawing.Point(376, 104);
            this.intervalBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.intervalBox2.Name = "intervalBox2";
            this.intervalBox2.Size = new System.Drawing.Size(76, 21);
            this.intervalBox2.TabIndex = 23;
            // 
            // intervalBox1
            // 
            this.intervalBox1.Enabled = false;
            this.intervalBox1.Location = new System.Drawing.Point(296, 104);
            this.intervalBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.intervalBox1.Name = "intervalBox1";
            this.intervalBox1.Size = new System.Drawing.Size(76, 21);
            this.intervalBox1.TabIndex = 24;
            // 
            // intervalButton
            // 
            this.intervalButton.Enabled = false;
            this.intervalButton.Location = new System.Drawing.Point(471, 104);
            this.intervalButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.intervalButton.Name = "intervalButton";
            this.intervalButton.Size = new System.Drawing.Size(44, 18);
            this.intervalButton.TabIndex = 25;
            this.intervalButton.Text = "OK";
            this.intervalButton.UseVisualStyleBackColor = true;
            this.intervalButton.Click += new System.EventHandler(this.intervalButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1036, 561);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "X/浓度%";
            // 
            // nameLable
            // 
            this.nameLable.AutoSize = true;
            this.nameLable.Location = new System.Drawing.Point(26, 163);
            this.nameLable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLable.Name = "nameLable";
            this.nameLable.Size = new System.Drawing.Size(23, 12);
            this.nameLable.TabIndex = 27;
            this.nameLable.Text = "MgO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 487);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 12);
            this.label12.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 519);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "0";
            // 
            // maxXLable
            // 
            this.maxXLable.AutoSize = true;
            this.maxXLable.Location = new System.Drawing.Point(1053, 546);
            this.maxXLable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxXLable.Name = "maxXLable";
            this.maxXLable.Size = new System.Drawing.Size(29, 12);
            this.maxXLable.TabIndex = 33;
            this.maxXLable.Text = "100%";
            // 
            // maxYLable
            // 
            this.maxYLable.AutoSize = true;
            this.maxYLable.Location = new System.Drawing.Point(16, 142);
            this.maxYLable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxYLable.Name = "maxYLable";
            this.maxYLable.Size = new System.Drawing.Size(0, 12);
            this.maxYLable.TabIndex = 34;
            // 
            // preButton
            // 
            this.preButton.Location = new System.Drawing.Point(622, 45);
            this.preButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.preButton.Name = "preButton";
            this.preButton.Size = new System.Drawing.Size(40, 18);
            this.preButton.TabIndex = 35;
            this.preButton.Text = "<<<";
            this.preButton.UseVisualStyleBackColor = true;
            this.preButton.Click += new System.EventHandler(this.preButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(667, 45);
            this.nextButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(39, 18);
            this.nextButton.TabIndex = 36;
            this.nextButton.Text = ">>>";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(622, 102);
            this.calcButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(40, 23);
            this.calcButton.TabIndex = 37;
            this.calcButton.Text = "计算";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(665, 102);
            this.showButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(40, 23);
            this.showButton.TabIndex = 38;
            this.showButton.Text = "查看";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(453, 106);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 16);
            this.label11.TabIndex = 39;
            this.label11.Text = "%";
            // 
            // lab_equation
            // 
            this.lab_equation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_equation.AutoSize = true;
            this.lab_equation.Location = new System.Drawing.Point(40, 559);
            this.lab_equation.Name = "lab_equation";
            this.lab_equation.Size = new System.Drawing.Size(47, 12);
            this.lab_equation.TabIndex = 40;
            this.lab_equation.Text = "label14";
            // 
            // lab_equation2
            // 
            this.lab_equation2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_equation2.AutoSize = true;
            this.lab_equation2.Location = new System.Drawing.Point(40, 582);
            this.lab_equation2.Name = "lab_equation2";
            this.lab_equation2.Size = new System.Drawing.Size(47, 12);
            this.lab_equation2.TabIndex = 41;
            this.lab_equation2.Text = "label14";
            // 
            // lab_equation3
            // 
            this.lab_equation3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_equation3.AutoSize = true;
            this.lab_equation3.Location = new System.Drawing.Point(40, 607);
            this.lab_equation3.Name = "lab_equation3";
            this.lab_equation3.Size = new System.Drawing.Size(47, 12);
            this.lab_equation3.TabIndex = 42;
            this.lab_equation3.Text = "label14";
            // 
            // Regression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 630);
            this.Controls.Add(this.lab_equation3);
            this.Controls.Add(this.lab_equation2);
            this.Controls.Add(this.lab_equation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.preButton);
            this.Controls.Add(this.maxYLable);
            this.Controls.Add(this.maxXLable);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nameLable);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.intervalButton);
            this.Controls.Add(this.intervalBox1);
            this.Controls.Add(this.intervalBox2);
            this.Controls.Add(this.isInterval);
            this.Controls.Add(this.isShowExp);
            this.Controls.Add(this.isShowDEF);
            this.Controls.Add(this.isShowReg);
            this.Controls.Add(this.isShowRMS);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.curveBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Regression";
            this.Text = " 回归";
            this.Load += new System.EventHandler(this.Regression_Load);
            ((System.ComponentModel.ISupportInitialize)(this.curveBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox curveBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox isShowRMS;
        private System.Windows.Forms.CheckBox isShowReg;
        private System.Windows.Forms.CheckBox isShowDEF;
        private System.Windows.Forms.CheckBox isShowExp;
        private System.Windows.Forms.CheckBox isInterval;
        private System.Windows.Forms.TextBox intervalBox2;
        private System.Windows.Forms.TextBox intervalBox1;
        private System.Windows.Forms.Button intervalButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label nameLable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label maxXLable;
        private System.Windows.Forms.Label maxYLable;
        private System.Windows.Forms.Button preButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lab_equation;
        private System.Windows.Forms.Label lab_equation2;
        private System.Windows.Forms.Label lab_equation3;
    }
}