namespace i_VXRFS.ResultDataAnalysis.QuantitationAnalysisResults
{
    partial class QuantitationAnalysisResults
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lab_quantitationanalysisapplicationname = new System.Windows.Forms.Label();
            this.gbox_QAreaultsConditions = new System.Windows.Forms.GroupBox();
            this.ckb_bg = new System.Windows.Forms.CheckBox();
            this.ckbox_totalpercentage = new System.Windows.Forms.CheckBox();
            this.ckbox_drift_bg_LoR_kcps = new System.Windows.Forms.CheckBox();
            this.ckbox_driftAndBgintensity = new System.Windows.Forms.CheckBox();
            this.ckbox_driftintensity = new System.Windows.Forms.CheckBox();
            this.ckbox_LOI = new System.Windows.Forms.CheckBox();
            this.ckbox_resulttype_concen = new System.Windows.Forms.CheckBox();
            this.ckbox_concentration = new System.Windows.Forms.CheckBox();
            this.ckbox_Sweight = new System.Windows.Forms.CheckBox();
            this.ckbox_normalizefactor = new System.Windows.Forms.CheckBox();
            this.ckbox_Rweight = new System.Windows.Forms.CheckBox();
            this.ckbox_meartime = new System.Windows.Forms.CheckBox();
            this.ckbox_testdate = new System.Windows.Forms.CheckBox();
            this.ckbox_analysisapplicationname = new System.Windows.Forms.CheckBox();
            this.dgv_quantitationanalysisresults = new System.Windows.Forms.DataGridView();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_moveout = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_calculateconcentration = new System.Windows.Forms.Button();
            this.btn_calculateconcentrationAndintensity = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_totalsearchnum = new System.Windows.Forms.Label();
            this.gbox_QAreaultsConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_quantitationanalysisresults)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_quantitationanalysisapplicationname
            // 
            this.lab_quantitationanalysisapplicationname.AutoSize = true;
            this.lab_quantitationanalysisapplicationname.Location = new System.Drawing.Point(461, 25);
            this.lab_quantitationanalysisapplicationname.Name = "lab_quantitationanalysisapplicationname";
            this.lab_quantitationanalysisapplicationname.Size = new System.Drawing.Size(0, 12);
            this.lab_quantitationanalysisapplicationname.TabIndex = 0;
            // 
            // gbox_QAreaultsConditions
            // 
            this.gbox_QAreaultsConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_QAreaultsConditions.Controls.Add(this.ckb_bg);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_totalpercentage);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_drift_bg_LoR_kcps);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_driftAndBgintensity);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_driftintensity);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_LOI);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_resulttype_concen);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_concentration);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_Sweight);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_normalizefactor);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_Rweight);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_meartime);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_testdate);
            this.gbox_QAreaultsConditions.Controls.Add(this.ckbox_analysisapplicationname);
            this.gbox_QAreaultsConditions.Location = new System.Drawing.Point(7, 12);
            this.gbox_QAreaultsConditions.Name = "gbox_QAreaultsConditions";
            this.gbox_QAreaultsConditions.Size = new System.Drawing.Size(1172, 147);
            this.gbox_QAreaultsConditions.TabIndex = 1;
            this.gbox_QAreaultsConditions.TabStop = false;
            // 
            // ckb_bg
            // 
            this.ckb_bg.AutoSize = true;
            this.ckb_bg.Location = new System.Drawing.Point(299, 78);
            this.ckb_bg.Name = "ckb_bg";
            this.ckb_bg.Size = new System.Drawing.Size(108, 16);
            this.ckb_bg.TabIndex = 17;
            this.ckb_bg.Text = "背景强度(浓度)";
            this.ckb_bg.UseVisualStyleBackColor = true;
            this.ckb_bg.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_totalpercentage
            // 
            this.ckbox_totalpercentage.AutoSize = true;
            this.ckbox_totalpercentage.Location = new System.Drawing.Point(299, 103);
            this.ckbox_totalpercentage.Name = "ckbox_totalpercentage";
            this.ckbox_totalpercentage.Size = new System.Drawing.Size(102, 16);
            this.ckbox_totalpercentage.TabIndex = 16;
            this.ckbox_totalpercentage.Text = "总百分含量(%)";
            this.ckbox_totalpercentage.UseVisualStyleBackColor = true;
            this.ckbox_totalpercentage.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_drift_bg_LoR_kcps
            // 
            this.ckbox_drift_bg_LoR_kcps.AutoSize = true;
            this.ckbox_drift_bg_LoR_kcps.Location = new System.Drawing.Point(700, 27);
            this.ckbox_drift_bg_LoR_kcps.Name = "ckbox_drift_bg_LoR_kcps";
            this.ckbox_drift_bg_LoR_kcps.Size = new System.Drawing.Size(216, 16);
            this.ckbox_drift_bg_LoR_kcps.TabIndex = 15;
            this.ckbox_drift_bg_LoR_kcps.Text = "漂移强度+背景强度+强度校正(kcps)";
            this.ckbox_drift_bg_LoR_kcps.UseVisualStyleBackColor = true;
            this.ckbox_drift_bg_LoR_kcps.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_driftAndBgintensity
            // 
            this.ckbox_driftAndBgintensity.AutoSize = true;
            this.ckbox_driftAndBgintensity.Location = new System.Drawing.Point(490, 102);
            this.ckbox_driftAndBgintensity.Name = "ckbox_driftAndBgintensity";
            this.ckbox_driftAndBgintensity.Size = new System.Drawing.Size(162, 16);
            this.ckbox_driftAndBgintensity.TabIndex = 13;
            this.ckbox_driftAndBgintensity.Text = "漂移强度+背景强度(kcps)";
            this.ckbox_driftAndBgintensity.UseVisualStyleBackColor = true;
            this.ckbox_driftAndBgintensity.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_driftintensity
            // 
            this.ckbox_driftintensity.AutoSize = true;
            this.ckbox_driftintensity.Location = new System.Drawing.Point(490, 78);
            this.ckbox_driftintensity.Name = "ckbox_driftintensity";
            this.ckbox_driftintensity.Size = new System.Drawing.Size(108, 16);
            this.ckbox_driftintensity.TabIndex = 12;
            this.ckbox_driftintensity.Text = "漂移强度(kcps)";
            this.ckbox_driftintensity.UseVisualStyleBackColor = true;
            this.ckbox_driftintensity.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_LOI
            // 
            this.ckbox_LOI.AutoSize = true;
            this.ckbox_LOI.Location = new System.Drawing.Point(490, 27);
            this.ckbox_LOI.Name = "ckbox_LOI";
            this.ckbox_LOI.Size = new System.Drawing.Size(66, 16);
            this.ckbox_LOI.TabIndex = 11;
            this.ckbox_LOI.Text = "烧失(%)";
            this.ckbox_LOI.UseVisualStyleBackColor = true;
            this.ckbox_LOI.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_resulttype_concen
            // 
            this.ckbox_resulttype_concen.AutoSize = true;
            this.ckbox_resulttype_concen.Location = new System.Drawing.Point(36, 78);
            this.ckbox_resulttype_concen.Name = "ckbox_resulttype_concen";
            this.ckbox_resulttype_concen.Size = new System.Drawing.Size(72, 16);
            this.ckbox_resulttype_concen.TabIndex = 10;
            this.ckbox_resulttype_concen.Text = "结果形式";
            this.ckbox_resulttype_concen.UseVisualStyleBackColor = true;
            this.ckbox_resulttype_concen.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_concentration
            // 
            this.ckbox_concentration.AutoSize = true;
            this.ckbox_concentration.Location = new System.Drawing.Point(700, 52);
            this.ckbox_concentration.Name = "ckbox_concentration";
            this.ckbox_concentration.Size = new System.Drawing.Size(48, 16);
            this.ckbox_concentration.TabIndex = 8;
            this.ckbox_concentration.Text = "浓度";
            this.ckbox_concentration.UseVisualStyleBackColor = true;
            this.ckbox_concentration.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_Sweight
            // 
            this.ckbox_Sweight.AutoSize = true;
            this.ckbox_Sweight.Location = new System.Drawing.Point(299, 52);
            this.ckbox_Sweight.Name = "ckbox_Sweight";
            this.ckbox_Sweight.Size = new System.Drawing.Size(72, 16);
            this.ckbox_Sweight.TabIndex = 7;
            this.ckbox_Sweight.Text = "样品质量";
            this.ckbox_Sweight.UseVisualStyleBackColor = true;
            this.ckbox_Sweight.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_normalizefactor
            // 
            this.ckbox_normalizefactor.AutoSize = true;
            this.ckbox_normalizefactor.Location = new System.Drawing.Point(36, 52);
            this.ckbox_normalizefactor.Name = "ckbox_normalizefactor";
            this.ckbox_normalizefactor.Size = new System.Drawing.Size(84, 16);
            this.ckbox_normalizefactor.TabIndex = 6;
            this.ckbox_normalizefactor.Text = "归一化因子";
            this.ckbox_normalizefactor.UseVisualStyleBackColor = true;
            this.ckbox_normalizefactor.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_Rweight
            // 
            this.ckbox_Rweight.AutoSize = true;
            this.ckbox_Rweight.Location = new System.Drawing.Point(299, 27);
            this.ckbox_Rweight.Name = "ckbox_Rweight";
            this.ckbox_Rweight.Size = new System.Drawing.Size(72, 16);
            this.ckbox_Rweight.TabIndex = 5;
            this.ckbox_Rweight.Text = "熔剂质量";
            this.ckbox_Rweight.UseVisualStyleBackColor = true;
            this.ckbox_Rweight.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_meartime
            // 
            this.ckbox_meartime.AutoSize = true;
            this.ckbox_meartime.Location = new System.Drawing.Point(490, 52);
            this.ckbox_meartime.Name = "ckbox_meartime";
            this.ckbox_meartime.Size = new System.Drawing.Size(90, 16);
            this.ckbox_meartime.TabIndex = 4;
            this.ckbox_meartime.Text = "测量时长(s)";
            this.ckbox_meartime.UseVisualStyleBackColor = true;
            this.ckbox_meartime.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_testdate
            // 
            this.ckbox_testdate.AutoSize = true;
            this.ckbox_testdate.Location = new System.Drawing.Point(36, 103);
            this.ckbox_testdate.Name = "ckbox_testdate";
            this.ckbox_testdate.Size = new System.Drawing.Size(72, 16);
            this.ckbox_testdate.TabIndex = 3;
            this.ckbox_testdate.Text = "测试日期";
            this.ckbox_testdate.UseVisualStyleBackColor = true;
            this.ckbox_testdate.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // ckbox_analysisapplicationname
            // 
            this.ckbox_analysisapplicationname.AutoSize = true;
            this.ckbox_analysisapplicationname.Location = new System.Drawing.Point(36, 27);
            this.ckbox_analysisapplicationname.Name = "ckbox_analysisapplicationname";
            this.ckbox_analysisapplicationname.Size = new System.Drawing.Size(192, 16);
            this.ckbox_analysisapplicationname.TabIndex = 0;
            this.ckbox_analysisapplicationname.Text = "分析程序名称/漂移校正名/升级";
            this.ckbox_analysisapplicationname.UseVisualStyleBackColor = true;
            this.ckbox_analysisapplicationname.CheckedChanged += new System.EventHandler(this.ckb_bg_CheckedChanged);
            // 
            // dgv_quantitationanalysisresults
            // 
            this.dgv_quantitationanalysisresults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_quantitationanalysisresults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_quantitationanalysisresults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_quantitationanalysisresults.Location = new System.Drawing.Point(7, 182);
            this.dgv_quantitationanalysisresults.Name = "dgv_quantitationanalysisresults";
            this.dgv_quantitationanalysisresults.RowTemplate.Height = 23;
            this.dgv_quantitationanalysisresults.Size = new System.Drawing.Size(1172, 430);
            this.dgv_quantitationanalysisresults.TabIndex = 2;
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_exit.Location = new System.Drawing.Point(12, 640);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_moveout
            // 
            this.btn_moveout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_moveout.Location = new System.Drawing.Point(110, 640);
            this.btn_moveout.Name = "btn_moveout";
            this.btn_moveout.Size = new System.Drawing.Size(75, 23);
            this.btn_moveout.TabIndex = 4;
            this.btn_moveout.Text = "移除";
            this.btn_moveout.UseVisualStyleBackColor = true;
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_edit.Location = new System.Drawing.Point(211, 640);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 5;
            this.btn_edit.Text = "编辑";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_calculateconcentration
            // 
            this.btn_calculateconcentration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_calculateconcentration.Location = new System.Drawing.Point(312, 640);
            this.btn_calculateconcentration.Name = "btn_calculateconcentration";
            this.btn_calculateconcentration.Size = new System.Drawing.Size(75, 23);
            this.btn_calculateconcentration.TabIndex = 6;
            this.btn_calculateconcentration.Text = "计算浓度";
            this.btn_calculateconcentration.UseVisualStyleBackColor = true;
            // 
            // btn_calculateconcentrationAndintensity
            // 
            this.btn_calculateconcentrationAndintensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_calculateconcentrationAndintensity.Location = new System.Drawing.Point(411, 640);
            this.btn_calculateconcentrationAndintensity.Name = "btn_calculateconcentrationAndintensity";
            this.btn_calculateconcentrationAndintensity.Size = new System.Drawing.Size(102, 23);
            this.btn_calculateconcentrationAndintensity.TabIndex = 7;
            this.btn_calculateconcentrationAndintensity.Text = "计算强度和浓度";
            this.btn_calculateconcentrationAndintensity.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "总搜索到的结果条数：";
            // 
            // lab_totalsearchnum
            // 
            this.lab_totalsearchnum.AutoSize = true;
            this.lab_totalsearchnum.Location = new System.Drawing.Point(135, 167);
            this.lab_totalsearchnum.Name = "lab_totalsearchnum";
            this.lab_totalsearchnum.Size = new System.Drawing.Size(41, 12);
            this.lab_totalsearchnum.TabIndex = 10;
            this.lab_totalsearchnum.Text = "label2";
            // 
            // QuantitationAnalysisResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 692);
            this.Controls.Add(this.lab_totalsearchnum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_calculateconcentrationAndintensity);
            this.Controls.Add(this.btn_calculateconcentration);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_moveout);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.dgv_quantitationanalysisresults);
            this.Controls.Add(this.gbox_QAreaultsConditions);
            this.Controls.Add(this.lab_quantitationanalysisapplicationname);
            this.Name = "QuantitationAnalysisResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定量分析结果";
            this.Load += new System.EventHandler(this.QuantitationAnalysisResults_Load);
            this.gbox_QAreaultsConditions.ResumeLayout(false);
            this.gbox_QAreaultsConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_quantitationanalysisresults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_quantitationanalysisapplicationname;
        private System.Windows.Forms.GroupBox gbox_QAreaultsConditions;
        private System.Windows.Forms.DataGridView dgv_quantitationanalysisresults;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_moveout;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_calculateconcentration;
        private System.Windows.Forms.Button btn_calculateconcentrationAndintensity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_totalsearchnum;
        private System.Windows.Forms.CheckBox ckbox_analysisapplicationname;
        private System.Windows.Forms.CheckBox ckbox_meartime;
        private System.Windows.Forms.CheckBox ckbox_testdate;
        private System.Windows.Forms.CheckBox ckbox_driftAndBgintensity;
        private System.Windows.Forms.CheckBox ckbox_driftintensity;
        private System.Windows.Forms.CheckBox ckbox_LOI;
        private System.Windows.Forms.CheckBox ckbox_resulttype_concen;
        private System.Windows.Forms.CheckBox ckbox_concentration;
        private System.Windows.Forms.CheckBox ckbox_Sweight;
        private System.Windows.Forms.CheckBox ckbox_normalizefactor;
        private System.Windows.Forms.CheckBox ckbox_Rweight;
        private System.Windows.Forms.CheckBox ckbox_totalpercentage;
        private System.Windows.Forms.CheckBox ckbox_drift_bg_LoR_kcps;
        private System.Windows.Forms.CheckBox ckb_bg;
    }
}