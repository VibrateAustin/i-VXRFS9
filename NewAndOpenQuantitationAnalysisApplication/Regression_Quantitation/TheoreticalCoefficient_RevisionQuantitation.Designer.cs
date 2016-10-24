namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    partial class TheoreticalCoefficient_RevisionQuantitation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_theoreticalcoefficient = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtb_sum = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_default = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_LOI = new System.Windows.Forms.RadioButton();
            this.rbtn_balance = new System.Windows.Forms.RadioButton();
            this.rbtn_compound = new System.Windows.Forms.RadioButton();
            this.rbtn_flux = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbox_cal_A = new System.Windows.Forms.CheckBox();
            this.ckbox_caloverlap = new System.Windows.Forms.CheckBox();
            this.rbtn_line_overlap = new System.Windows.Forms.RadioButton();
            this.rbtn_alloverlap = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_theoreticalcoefficient)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_theoreticalcoefficient
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_theoreticalcoefficient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_theoreticalcoefficient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_theoreticalcoefficient.Location = new System.Drawing.Point(3, 38);
            this.dgv_theoreticalcoefficient.Name = "dgv_theoreticalcoefficient";
            this.dgv_theoreticalcoefficient.RowTemplate.Height = 23;
            this.dgv_theoreticalcoefficient.Size = new System.Drawing.Size(342, 321);
            this.dgv_theoreticalcoefficient.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "总和：";
            // 
            // txtb_sum
            // 
            this.txtb_sum.Location = new System.Drawing.Point(259, 13);
            this.txtb_sum.Name = "txtb_sum";
            this.txtb_sum.Size = new System.Drawing.Size(85, 21);
            this.txtb_sum.TabIndex = 2;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ok.Location = new System.Drawing.Point(33, 391);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // btn_cancle
            // 
            this.btn_cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancle.Location = new System.Drawing.Point(137, 391);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 4;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_default
            // 
            this.btn_default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_default.Location = new System.Drawing.Point(242, 391);
            this.btn_default.Name = "btn_default";
            this.btn_default.Size = new System.Drawing.Size(75, 23);
            this.btn_default.TabIndex = 5;
            this.btn_default.Text = "默认";
            this.btn_default.UseVisualStyleBackColor = true;
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_print.Location = new System.Drawing.Point(344, 391);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 6;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtn_flux);
            this.groupBox1.Controls.Add(this.rbtn_compound);
            this.groupBox1.Controls.Add(this.rbtn_balance);
            this.groupBox1.Controls.Add(this.rbtn_LOI);
            this.groupBox1.Location = new System.Drawing.Point(367, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "扣除方法";
            // 
            // rbtn_LOI
            // 
            this.rbtn_LOI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtn_LOI.AutoSize = true;
            this.rbtn_LOI.Location = new System.Drawing.Point(57, 28);
            this.rbtn_LOI.Name = "rbtn_LOI";
            this.rbtn_LOI.Size = new System.Drawing.Size(47, 16);
            this.rbtn_LOI.TabIndex = 0;
            this.rbtn_LOI.TabStop = true;
            this.rbtn_LOI.Text = "烧失";
            this.rbtn_LOI.UseVisualStyleBackColor = true;
            // 
            // rbtn_balance
            // 
            this.rbtn_balance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtn_balance.AutoSize = true;
            this.rbtn_balance.Location = new System.Drawing.Point(194, 28);
            this.rbtn_balance.Name = "rbtn_balance";
            this.rbtn_balance.Size = new System.Drawing.Size(47, 16);
            this.rbtn_balance.TabIndex = 1;
            this.rbtn_balance.TabStop = true;
            this.rbtn_balance.Text = "平衡";
            this.rbtn_balance.UseVisualStyleBackColor = true;
            // 
            // rbtn_compound
            // 
            this.rbtn_compound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtn_compound.AutoSize = true;
            this.rbtn_compound.Location = new System.Drawing.Point(194, 63);
            this.rbtn_compound.Name = "rbtn_compound";
            this.rbtn_compound.Size = new System.Drawing.Size(59, 16);
            this.rbtn_compound.TabIndex = 2;
            this.rbtn_compound.TabStop = true;
            this.rbtn_compound.Text = "化合物";
            this.rbtn_compound.UseVisualStyleBackColor = true;
            // 
            // rbtn_flux
            // 
            this.rbtn_flux.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtn_flux.AutoSize = true;
            this.rbtn_flux.Location = new System.Drawing.Point(57, 63);
            this.rbtn_flux.Name = "rbtn_flux";
            this.rbtn_flux.Size = new System.Drawing.Size(47, 16);
            this.rbtn_flux.TabIndex = 3;
            this.rbtn_flux.TabStop = true;
            this.rbtn_flux.Text = "Flux";
            this.rbtn_flux.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbtn_line_overlap);
            this.groupBox2.Controls.Add(this.rbtn_alloverlap);
            this.groupBox2.Controls.Add(this.ckbox_caloverlap);
            this.groupBox2.Controls.Add(this.ckbox_cal_A);
            this.groupBox2.Location = new System.Drawing.Point(367, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 205);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // ckbox_cal_A
            // 
            this.ckbox_cal_A.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbox_cal_A.AutoSize = true;
            this.ckbox_cal_A.Location = new System.Drawing.Point(57, 36);
            this.ckbox_cal_A.Name = "ckbox_cal_A";
            this.ckbox_cal_A.Size = new System.Drawing.Size(72, 16);
            this.ckbox_cal_A.TabIndex = 0;
            this.ckbox_cal_A.Text = "计算α值";
            this.ckbox_cal_A.UseVisualStyleBackColor = true;
            // 
            // ckbox_caloverlap
            // 
            this.ckbox_caloverlap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbox_caloverlap.AutoSize = true;
            this.ckbox_caloverlap.Location = new System.Drawing.Point(57, 82);
            this.ckbox_caloverlap.Name = "ckbox_caloverlap";
            this.ckbox_caloverlap.Size = new System.Drawing.Size(84, 16);
            this.ckbox_caloverlap.TabIndex = 1;
            this.ckbox_caloverlap.Text = "计算重叠峰";
            this.ckbox_caloverlap.UseVisualStyleBackColor = true;
            // 
            // rbtn_line_overlap
            // 
            this.rbtn_line_overlap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtn_line_overlap.AutoSize = true;
            this.rbtn_line_overlap.Location = new System.Drawing.Point(100, 155);
            this.rbtn_line_overlap.Name = "rbtn_line_overlap";
            this.rbtn_line_overlap.Size = new System.Drawing.Size(155, 16);
            this.rbtn_line_overlap.TabIndex = 5;
            this.rbtn_line_overlap.TabStop = true;
            this.rbtn_line_overlap.Text = "只计算选中的谱线重叠峰";
            this.rbtn_line_overlap.UseVisualStyleBackColor = true;
            // 
            // rbtn_alloverlap
            // 
            this.rbtn_alloverlap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtn_alloverlap.AutoSize = true;
            this.rbtn_alloverlap.Location = new System.Drawing.Point(100, 120);
            this.rbtn_alloverlap.Name = "rbtn_alloverlap";
            this.rbtn_alloverlap.Size = new System.Drawing.Size(107, 16);
            this.rbtn_alloverlap.TabIndex = 4;
            this.rbtn_alloverlap.TabStop = true;
            this.rbtn_alloverlap.Text = "计算所有重叠峰";
            this.rbtn_alloverlap.UseVisualStyleBackColor = true;
            // 
            // TheoreticalCoefficient_RevisionQuantitation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 436);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_default);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txtb_sum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_theoreticalcoefficient);
            this.Name = "TheoreticalCoefficient_RevisionQuantitation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "理论系数";
            this.Load += new System.EventHandler(this.TheoreticalCoefficient_RevisionQuantitation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_theoreticalcoefficient)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_theoreticalcoefficient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtb_sum;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_default;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn_LOI;
        private System.Windows.Forms.RadioButton rbtn_flux;
        private System.Windows.Forms.RadioButton rbtn_compound;
        private System.Windows.Forms.RadioButton rbtn_balance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtn_line_overlap;
        private System.Windows.Forms.RadioButton rbtn_alloverlap;
        private System.Windows.Forms.CheckBox ckbox_caloverlap;
        private System.Windows.Forms.CheckBox ckbox_cal_A;
    }
}