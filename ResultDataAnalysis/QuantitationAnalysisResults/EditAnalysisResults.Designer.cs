namespace i_VXRFS.ResultDataAnalysis.QuantitationAnalysisResults
{
    partial class EditAnalysisResults
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbox_baseinfo = new System.Windows.Forms.GroupBox();
            this.txtb_samplename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtb_analysisapplicationname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtb_samplemodel = new System.Windows.Forms.TextBox();
            this.lb_model = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_compoundperc = new System.Windows.Forms.DataGridView();
            this.txtb_factor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtb_totalp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_compoundkcps = new System.Windows.Forms.DataGridView();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_input = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_calconc = new System.Windows.Forms.Button();
            this.btn_calkcpsconc = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv_input = new System.Windows.Forms.DataGridView();
            this.gbox_baseinfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_compoundperc)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_compoundkcps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_input)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox_baseinfo
            // 
            this.gbox_baseinfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_baseinfo.Controls.Add(this.txtb_samplename);
            this.gbox_baseinfo.Controls.Add(this.label2);
            this.gbox_baseinfo.Controls.Add(this.txtb_analysisapplicationname);
            this.gbox_baseinfo.Controls.Add(this.label1);
            this.gbox_baseinfo.Controls.Add(this.txtb_samplemodel);
            this.gbox_baseinfo.Controls.Add(this.lb_model);
            this.gbox_baseinfo.Location = new System.Drawing.Point(3, 12);
            this.gbox_baseinfo.Name = "gbox_baseinfo";
            this.gbox_baseinfo.Size = new System.Drawing.Size(979, 91);
            this.gbox_baseinfo.TabIndex = 0;
            this.gbox_baseinfo.TabStop = false;
            this.gbox_baseinfo.Text = "样品基本信息";
            // 
            // txtb_samplename
            // 
            this.txtb_samplename.Location = new System.Drawing.Point(131, 56);
            this.txtb_samplename.Name = "txtb_samplename";
            this.txtb_samplename.Size = new System.Drawing.Size(100, 21);
            this.txtb_samplename.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "样品名：";
            // 
            // txtb_analysisapplicationname
            // 
            this.txtb_analysisapplicationname.Location = new System.Drawing.Point(403, 23);
            this.txtb_analysisapplicationname.Name = "txtb_analysisapplicationname";
            this.txtb_analysisapplicationname.Size = new System.Drawing.Size(100, 21);
            this.txtb_analysisapplicationname.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "分析程序名：";
            // 
            // txtb_samplemodel
            // 
            this.txtb_samplemodel.Location = new System.Drawing.Point(131, 23);
            this.txtb_samplemodel.Name = "txtb_samplemodel";
            this.txtb_samplemodel.Size = new System.Drawing.Size(100, 21);
            this.txtb_samplemodel.TabIndex = 1;
            // 
            // lb_model
            // 
            this.lb_model.AutoSize = true;
            this.lb_model.Location = new System.Drawing.Point(68, 26);
            this.lb_model.Name = "lb_model";
            this.lb_model.Size = new System.Drawing.Size(41, 12);
            this.lb_model.TabIndex = 0;
            this.lb_model.Text = "模式：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dgv_input);
            this.groupBox1.Controls.Add(this.dgv_compoundperc);
            this.groupBox1.Controls.Add(this.txtb_factor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtb_totalp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 412);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dgv_compoundperc
            // 
            this.dgv_compoundperc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_compoundperc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_compoundperc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_compoundperc.Location = new System.Drawing.Point(7, 45);
            this.dgv_compoundperc.Name = "dgv_compoundperc";
            this.dgv_compoundperc.RowTemplate.Height = 23;
            this.dgv_compoundperc.Size = new System.Drawing.Size(490, 361);
            this.dgv_compoundperc.TabIndex = 10;
            // 
            // txtb_factor
            // 
            this.txtb_factor.Location = new System.Drawing.Point(328, 14);
            this.txtb_factor.Name = "txtb_factor";
            this.txtb_factor.Size = new System.Drawing.Size(100, 21);
            this.txtb_factor.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "归一化因子：";
            // 
            // txtb_totalp
            // 
            this.txtb_totalp.Location = new System.Drawing.Point(119, 14);
            this.txtb_totalp.Name = "txtb_totalp";
            this.txtb_totalp.Size = new System.Drawing.Size(100, 21);
            this.txtb_totalp.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "总百分含量(%)：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgv_compoundkcps);
            this.groupBox2.Location = new System.Drawing.Point(512, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 412);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dgv_compoundkcps
            // 
            this.dgv_compoundkcps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_compoundkcps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_compoundkcps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_compoundkcps.Location = new System.Drawing.Point(6, 45);
            this.dgv_compoundkcps.Name = "dgv_compoundkcps";
            this.dgv_compoundkcps.RowTemplate.Height = 23;
            this.dgv_compoundkcps.Size = new System.Drawing.Size(458, 361);
            this.dgv_compoundkcps.TabIndex = 11;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ok.Location = new System.Drawing.Point(26, 547);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_input
            // 
            this.btn_input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_input.Location = new System.Drawing.Point(431, 547);
            this.btn_input.Name = "btn_input";
            this.btn_input.Size = new System.Drawing.Size(75, 23);
            this.btn_input.TabIndex = 4;
            this.btn_input.Text = "手动输入";
            this.btn_input.UseVisualStyleBackColor = true;
            this.btn_input.Click += new System.EventHandler(this.btn_input_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancle.Location = new System.Drawing.Point(123, 547);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 5;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_calconc
            // 
            this.btn_calconc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_calconc.Location = new System.Drawing.Point(213, 547);
            this.btn_calconc.Name = "btn_calconc";
            this.btn_calconc.Size = new System.Drawing.Size(75, 23);
            this.btn_calconc.TabIndex = 6;
            this.btn_calconc.Text = "计算浓度";
            this.btn_calconc.UseVisualStyleBackColor = true;
            // 
            // btn_calkcpsconc
            // 
            this.btn_calkcpsconc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_calkcpsconc.Location = new System.Drawing.Point(299, 547);
            this.btn_calkcpsconc.Name = "btn_calkcpsconc";
            this.btn_calkcpsconc.Size = new System.Drawing.Size(118, 23);
            this.btn_calkcpsconc.TabIndex = 7;
            this.btn_calkcpsconc.Text = "计算计数率和浓度";
            this.btn_calkcpsconc.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_add.Location = new System.Drawing.Point(518, 547);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 8;
            this.btn_add.Text = "化合物";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgv_input
            // 
            this.dgv_input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_input.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_input.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_input.Location = new System.Drawing.Point(7, 45);
            this.dgv_input.Name = "dgv_input";
            this.dgv_input.RowTemplate.Height = 23;
            this.dgv_input.Size = new System.Drawing.Size(490, 361);
            this.dgv_input.TabIndex = 11;
            // 
            // EditAnalysisResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 602);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_calkcpsconc);
            this.Controls.Add(this.btn_calconc);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_input);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbox_baseinfo);
            this.Name = "EditAnalysisResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定量分析结果";
            this.Load += new System.EventHandler(this.EditAnalysisResults_Load);
            this.gbox_baseinfo.ResumeLayout(false);
            this.gbox_baseinfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_compoundperc)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_compoundkcps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_input)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox_baseinfo;
        private System.Windows.Forms.TextBox txtb_samplename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtb_analysisapplicationname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtb_samplemodel;
        private System.Windows.Forms.Label lb_model;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtb_totalp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtb_factor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_compoundperc;
        private System.Windows.Forms.DataGridView dgv_compoundkcps;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_input;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_calconc;
        private System.Windows.Forms.Button btn_calkcpsconc;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_input;
    }
}