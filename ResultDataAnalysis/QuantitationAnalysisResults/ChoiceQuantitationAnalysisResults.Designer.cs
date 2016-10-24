namespace i_VXRFS.ResultDataAnalysis.QuantitationAnalysisResults
{
    partial class ChoiceQuantitationAnalysisResults
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_choiceQAName = new System.Windows.Forms.ComboBox();
            this.cbox_testmodel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_samplename = new System.Windows.Forms.TextBox();
            this.gbox_time = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radiobtn_timearrange = new System.Windows.Forms.RadioButton();
            this.radiobtn_all = new System.Windows.Forms.RadioButton();
            this.gbox_order = new System.Windows.Forms.GroupBox();
            this.radiobtn_samplename = new System.Windows.Forms.RadioButton();
            this.radiobtn_time = new System.Windows.Forms.RadioButton();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_default = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.gbox_time.SuspendLayout();
            this.gbox_order.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分析程序名称：";
            // 
            // cbox_choiceQAName
            // 
            this.cbox_choiceQAName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbox_choiceQAName.FormattingEnabled = true;
            this.cbox_choiceQAName.Location = new System.Drawing.Point(153, 48);
            this.cbox_choiceQAName.Name = "cbox_choiceQAName";
            this.cbox_choiceQAName.Size = new System.Drawing.Size(226, 20);
            this.cbox_choiceQAName.TabIndex = 1;
            // 
            // cbox_testmodel
            // 
            this.cbox_testmodel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbox_testmodel.FormattingEnabled = true;
            this.cbox_testmodel.Items.AddRange(new object[] {
            "一般",
            "标准",
            "校正",
            "升级"});
            this.cbox_testmodel.Location = new System.Drawing.Point(153, 85);
            this.cbox_testmodel.Name = "cbox_testmodel";
            this.cbox_testmodel.Size = new System.Drawing.Size(226, 20);
            this.cbox_testmodel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "检查模式：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "样品名称：";
            // 
            // txt_samplename
            // 
            this.txt_samplename.Location = new System.Drawing.Point(153, 121);
            this.txt_samplename.Name = "txt_samplename";
            this.txt_samplename.Size = new System.Drawing.Size(226, 21);
            this.txt_samplename.TabIndex = 5;
            // 
            // gbox_time
            // 
            this.gbox_time.Controls.Add(this.dateTimePicker2);
            this.gbox_time.Controls.Add(this.dateTimePicker1);
            this.gbox_time.Controls.Add(this.label5);
            this.gbox_time.Controls.Add(this.label4);
            this.gbox_time.Controls.Add(this.radiobtn_timearrange);
            this.gbox_time.Controls.Add(this.radiobtn_all);
            this.gbox_time.Location = new System.Drawing.Point(12, 166);
            this.gbox_time.Name = "gbox_time";
            this.gbox_time.Size = new System.Drawing.Size(221, 133);
            this.gbox_time.TabIndex = 6;
            this.gbox_time.TabStop = false;
            this.gbox_time.Text = "时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "截止时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "开始时间：";
            // 
            // radiobtn_timearrange
            // 
            this.radiobtn_timearrange.AutoSize = true;
            this.radiobtn_timearrange.Location = new System.Drawing.Point(106, 24);
            this.radiobtn_timearrange.Name = "radiobtn_timearrange";
            this.radiobtn_timearrange.Size = new System.Drawing.Size(71, 16);
            this.radiobtn_timearrange.TabIndex = 1;
            this.radiobtn_timearrange.TabStop = true;
            this.radiobtn_timearrange.Text = "时间区间";
            this.radiobtn_timearrange.UseVisualStyleBackColor = true;
            // 
            // radiobtn_all
            // 
            this.radiobtn_all.AutoSize = true;
            this.radiobtn_all.Location = new System.Drawing.Point(22, 24);
            this.radiobtn_all.Name = "radiobtn_all";
            this.radiobtn_all.Size = new System.Drawing.Size(47, 16);
            this.radiobtn_all.TabIndex = 0;
            this.radiobtn_all.TabStop = true;
            this.radiobtn_all.Text = "所有";
            this.radiobtn_all.UseVisualStyleBackColor = true;
            // 
            // gbox_order
            // 
            this.gbox_order.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_order.Controls.Add(this.radiobtn_samplename);
            this.gbox_order.Controls.Add(this.radiobtn_time);
            this.gbox_order.Location = new System.Drawing.Point(239, 166);
            this.gbox_order.Name = "gbox_order";
            this.gbox_order.Size = new System.Drawing.Size(199, 133);
            this.gbox_order.TabIndex = 9;
            this.gbox_order.TabStop = false;
            this.gbox_order.Text = "分类排序";
            // 
            // radiobtn_samplename
            // 
            this.radiobtn_samplename.AutoSize = true;
            this.radiobtn_samplename.Location = new System.Drawing.Point(64, 90);
            this.radiobtn_samplename.Name = "radiobtn_samplename";
            this.radiobtn_samplename.Size = new System.Drawing.Size(71, 16);
            this.radiobtn_samplename.TabIndex = 1;
            this.radiobtn_samplename.TabStop = true;
            this.radiobtn_samplename.Text = "样品名称";
            this.radiobtn_samplename.UseVisualStyleBackColor = true;
            // 
            // radiobtn_time
            // 
            this.radiobtn_time.AutoSize = true;
            this.radiobtn_time.Location = new System.Drawing.Point(64, 43);
            this.radiobtn_time.Name = "radiobtn_time";
            this.radiobtn_time.Size = new System.Drawing.Size(71, 16);
            this.radiobtn_time.TabIndex = 0;
            this.radiobtn_time.TabStop = true;
            this.radiobtn_time.Text = "检测时间";
            this.radiobtn_time.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ok.Location = new System.Drawing.Point(72, 337);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 10;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancle.Location = new System.Drawing.Point(174, 337);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 11;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_default
            // 
            this.btn_default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_default.Location = new System.Drawing.Point(278, 337);
            this.btn_default.Name = "btn_default";
            this.btn_default.Size = new System.Drawing.Size(75, 23);
            this.btn_default.TabIndex = 12;
            this.btn_default.Text = "默认";
            this.btn_default.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(80, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 21);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(80, 98);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(130, 21);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // ChoiceQuantitationAnalysisResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 397);
            this.Controls.Add(this.btn_default);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.gbox_order);
            this.Controls.Add(this.gbox_time);
            this.Controls.Add(this.txt_samplename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbox_testmodel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbox_choiceQAName);
            this.Controls.Add(this.label1);
            this.Name = "ChoiceQuantitationAnalysisResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定量分析结果";
            this.Load += new System.EventHandler(this.ChoiceQuantitationAnalysisResults_Load);
            this.gbox_time.ResumeLayout(false);
            this.gbox_time.PerformLayout();
            this.gbox_order.ResumeLayout(false);
            this.gbox_order.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_choiceQAName;
        private System.Windows.Forms.ComboBox cbox_testmodel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_samplename;
        private System.Windows.Forms.GroupBox gbox_time;
        private System.Windows.Forms.RadioButton radiobtn_timearrange;
        private System.Windows.Forms.RadioButton radiobtn_all;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbox_order;
        private System.Windows.Forms.RadioButton radiobtn_samplename;
        private System.Windows.Forms.RadioButton radiobtn_time;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_default;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}