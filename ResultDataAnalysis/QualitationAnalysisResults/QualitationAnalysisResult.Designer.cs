namespace i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults
{
    partial class QualitationAnalysisResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_qualitationanalysisname = new System.Windows.Forms.ComboBox();
            this.gbox_conditionparameter = new System.Windows.Forms.GroupBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.txt_totalresultsnum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbox_testmodel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radiobtn_all = new System.Windows.Forms.RadioButton();
            this.lab_testsampletime = new System.Windows.Forms.Label();
            this.radiobtn_testday = new System.Windows.Forms.RadioButton();
            this.dtp_testtime2_qualitationresults = new System.Windows.Forms.DateTimePicker();
            this.dtp_testtime1_qualitationresults = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.radiobtn_starttime = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_qualitationanalysisresults = new System.Windows.Forms.DataGridView();
            this.btn_checkspectralLine = new System.Windows.Forms.Button();
            this.btn_checkpeak = new System.Windows.Forms.Button();
            this.btn_rank = new System.Windows.Forms.Button();
            this.btn_analysis = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.gbox_conditionparameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_qualitationanalysisresults)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择分析程序：";
            // 
            // cbox_qualitationanalysisname
            // 
            this.cbox_qualitationanalysisname.FormattingEnabled = true;
            this.cbox_qualitationanalysisname.Location = new System.Drawing.Point(147, 17);
            this.cbox_qualitationanalysisname.Name = "cbox_qualitationanalysisname";
            this.cbox_qualitationanalysisname.Size = new System.Drawing.Size(196, 20);
            this.cbox_qualitationanalysisname.TabIndex = 1;
            // 
            // gbox_conditionparameter
            // 
            this.gbox_conditionparameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_conditionparameter.Controls.Add(this.btn_check);
            this.gbox_conditionparameter.Controls.Add(this.txt_totalresultsnum);
            this.gbox_conditionparameter.Controls.Add(this.label5);
            this.gbox_conditionparameter.Controls.Add(this.cbox_testmodel);
            this.gbox_conditionparameter.Controls.Add(this.label4);
            this.gbox_conditionparameter.Controls.Add(this.radiobtn_all);
            this.gbox_conditionparameter.Controls.Add(this.lab_testsampletime);
            this.gbox_conditionparameter.Controls.Add(this.radiobtn_testday);
            this.gbox_conditionparameter.Controls.Add(this.dtp_testtime2_qualitationresults);
            this.gbox_conditionparameter.Controls.Add(this.dtp_testtime1_qualitationresults);
            this.gbox_conditionparameter.Controls.Add(this.label3);
            this.gbox_conditionparameter.Controls.Add(this.radiobtn_starttime);
            this.gbox_conditionparameter.Controls.Add(this.label2);
            this.gbox_conditionparameter.Location = new System.Drawing.Point(4, 52);
            this.gbox_conditionparameter.Name = "gbox_conditionparameter";
            this.gbox_conditionparameter.Size = new System.Drawing.Size(1177, 131);
            this.gbox_conditionparameter.TabIndex = 2;
            this.gbox_conditionparameter.TabStop = false;
            this.gbox_conditionparameter.Text = "条件参数";
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(729, 88);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(75, 23);
            this.btn_check.TabIndex = 12;
            this.btn_check.Text = "查看";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // txt_totalresultsnum
            // 
            this.txt_totalresultsnum.Location = new System.Drawing.Point(558, 87);
            this.txt_totalresultsnum.Name = "txt_totalresultsnum";
            this.txt_totalresultsnum.Size = new System.Drawing.Size(100, 21);
            this.txt_totalresultsnum.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(475, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "搜索的结果数：";
            // 
            // cbox_testmodel
            // 
            this.cbox_testmodel.FormattingEnabled = true;
            this.cbox_testmodel.Items.AddRange(new object[] {
            "一般",
            "标准",
            "校正",
            "升级"});
            this.cbox_testmodel.Location = new System.Drawing.Point(546, 58);
            this.cbox_testmodel.Name = "cbox_testmodel";
            this.cbox_testmodel.Size = new System.Drawing.Size(112, 20);
            this.cbox_testmodel.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(475, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "测量模式：";
            // 
            // radiobtn_all
            // 
            this.radiobtn_all.AutoSize = true;
            this.radiobtn_all.Location = new System.Drawing.Point(259, 89);
            this.radiobtn_all.Name = "radiobtn_all";
            this.radiobtn_all.Size = new System.Drawing.Size(47, 16);
            this.radiobtn_all.TabIndex = 9;
            this.radiobtn_all.TabStop = true;
            this.radiobtn_all.Text = "所有";
            this.radiobtn_all.UseVisualStyleBackColor = true;
            // 
            // lab_testsampletime
            // 
            this.lab_testsampletime.AutoSize = true;
            this.lab_testsampletime.Location = new System.Drawing.Point(324, 60);
            this.lab_testsampletime.Name = "lab_testsampletime";
            this.lab_testsampletime.Size = new System.Drawing.Size(41, 12);
            this.lab_testsampletime.TabIndex = 8;
            this.lab_testsampletime.Text = "label4";
            // 
            // radiobtn_testday
            // 
            this.radiobtn_testday.AutoSize = true;
            this.radiobtn_testday.Location = new System.Drawing.Point(259, 58);
            this.radiobtn_testday.Name = "radiobtn_testday";
            this.radiobtn_testday.Size = new System.Drawing.Size(59, 16);
            this.radiobtn_testday.TabIndex = 7;
            this.radiobtn_testday.TabStop = true;
            this.radiobtn_testday.Text = "今天：";
            this.radiobtn_testday.UseVisualStyleBackColor = true;
            // 
            // dtp_testtime2_qualitationresults
            // 
            this.dtp_testtime2_qualitationresults.Location = new System.Drawing.Point(104, 87);
            this.dtp_testtime2_qualitationresults.Name = "dtp_testtime2_qualitationresults";
            this.dtp_testtime2_qualitationresults.Size = new System.Drawing.Size(128, 21);
            this.dtp_testtime2_qualitationresults.TabIndex = 6;
            // 
            // dtp_testtime1_qualitationresults
            // 
            this.dtp_testtime1_qualitationresults.Location = new System.Drawing.Point(104, 58);
            this.dtp_testtime1_qualitationresults.Name = "dtp_testtime1_qualitationresults";
            this.dtp_testtime1_qualitationresults.Size = new System.Drawing.Size(128, 21);
            this.dtp_testtime1_qualitationresults.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "到:";
            // 
            // radiobtn_starttime
            // 
            this.radiobtn_starttime.AutoSize = true;
            this.radiobtn_starttime.Location = new System.Drawing.Point(54, 58);
            this.radiobtn_starttime.Name = "radiobtn_starttime";
            this.radiobtn_starttime.Size = new System.Drawing.Size(41, 16);
            this.radiobtn_starttime.TabIndex = 4;
            this.radiobtn_starttime.TabStop = true;
            this.radiobtn_starttime.Text = "从:";
            this.radiobtn_starttime.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "测试时间：";
            // 
            // dgv_qualitationanalysisresults
            // 
            this.dgv_qualitationanalysisresults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_qualitationanalysisresults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_qualitationanalysisresults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_qualitationanalysisresults.Location = new System.Drawing.Point(4, 189);
            this.dgv_qualitationanalysisresults.Name = "dgv_qualitationanalysisresults";
            this.dgv_qualitationanalysisresults.RowTemplate.Height = 23;
            this.dgv_qualitationanalysisresults.Size = new System.Drawing.Size(1177, 414);
            this.dgv_qualitationanalysisresults.TabIndex = 3;
            // 
            // btn_checkspectralLine
            // 
            this.btn_checkspectralLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_checkspectralLine.Location = new System.Drawing.Point(24, 635);
            this.btn_checkspectralLine.Name = "btn_checkspectralLine";
            this.btn_checkspectralLine.Size = new System.Drawing.Size(75, 23);
            this.btn_checkspectralLine.TabIndex = 4;
            this.btn_checkspectralLine.Text = "查看谱线";
            this.btn_checkspectralLine.UseVisualStyleBackColor = true;
            this.btn_checkspectralLine.Click += new System.EventHandler(this.btn_checkspectralLine_Click);
            // 
            // btn_checkpeak
            // 
            this.btn_checkpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_checkpeak.Location = new System.Drawing.Point(124, 635);
            this.btn_checkpeak.Name = "btn_checkpeak";
            this.btn_checkpeak.Size = new System.Drawing.Size(75, 23);
            this.btn_checkpeak.TabIndex = 5;
            this.btn_checkpeak.Text = "查看峰";
            this.btn_checkpeak.UseVisualStyleBackColor = true;
            this.btn_checkpeak.Click += new System.EventHandler(this.btn_checkpeak_Click);
            // 
            // btn_rank
            // 
            this.btn_rank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_rank.Location = new System.Drawing.Point(223, 635);
            this.btn_rank.Name = "btn_rank";
            this.btn_rank.Size = new System.Drawing.Size(75, 23);
            this.btn_rank.TabIndex = 6;
            this.btn_rank.Text = "排序";
            this.btn_rank.UseVisualStyleBackColor = true;
            // 
            // btn_analysis
            // 
            this.btn_analysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_analysis.Location = new System.Drawing.Point(321, 635);
            this.btn_analysis.Name = "btn_analysis";
            this.btn_analysis.Size = new System.Drawing.Size(75, 23);
            this.btn_analysis.TabIndex = 7;
            this.btn_analysis.Text = "分析";
            this.btn_analysis.UseVisualStyleBackColor = true;
            // 
            // btn_cancle
            // 
            this.btn_cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancle.Location = new System.Drawing.Point(420, 635);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 8;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_print.Location = new System.Drawing.Point(519, 635);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 9;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ok.Location = new System.Drawing.Point(621, 635);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 10;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // QualitationAnalysisResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 692);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_analysis);
            this.Controls.Add(this.btn_rank);
            this.Controls.Add(this.btn_checkpeak);
            this.Controls.Add(this.btn_checkspectralLine);
            this.Controls.Add(this.dgv_qualitationanalysisresults);
            this.Controls.Add(this.gbox_conditionparameter);
            this.Controls.Add(this.cbox_qualitationanalysisname);
            this.Controls.Add(this.label1);
            this.Name = "QualitationAnalysisResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定性分析结果";
            this.Load += new System.EventHandler(this.QualitationAnalysisResults_Load);
            this.gbox_conditionparameter.ResumeLayout(false);
            this.gbox_conditionparameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_qualitationanalysisresults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_qualitationanalysisname;
        private System.Windows.Forms.GroupBox gbox_conditionparameter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radiobtn_starttime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_testtime1_qualitationresults;
        private System.Windows.Forms.RadioButton radiobtn_testday;
        private System.Windows.Forms.DateTimePicker dtp_testtime2_qualitationresults;
        private System.Windows.Forms.Label lab_testsampletime;
        private System.Windows.Forms.RadioButton radiobtn_all;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbox_testmodel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_totalresultsnum;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.DataGridView dgv_qualitationanalysisresults;
        private System.Windows.Forms.Button btn_checkspectralLine;
        private System.Windows.Forms.Button btn_checkpeak;
        private System.Windows.Forms.Button btn_rank;
        private System.Windows.Forms.Button btn_analysis;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_ok;
    }
}