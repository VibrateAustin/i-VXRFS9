namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    partial class Revision_QuantitationAnalysis
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbox_regressionresults = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgv_regressionresult = new System.Windows.Forms.DataGridView();
            this.gbox_coefficientrevision = new System.Windows.Forms.GroupBox();
            this.dgv_coefficientrevision = new System.Windows.Forms.DataGridView();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_deblock = new System.Windows.Forms.Button();
            this.btn_lock = new System.Windows.Forms.Button();
            this.btn_theoreticalcoefficient = new System.Windows.Forms.Button();
            this.btn_calculate = new System.Windows.Forms.Button();
            this.btn_limitofdetection = new System.Windows.Forms.Button();
            this.btn_checkdata = new System.Windows.Forms.Button();
            this.btn_regressionLine = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.gbox_regressionresults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_regressionresult)).BeginInit();
            this.gbox_coefficientrevision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_coefficientrevision)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox_regressionresults
            // 
            this.gbox_regressionresults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_regressionresults.Controls.Add(this.comboBox1);
            this.gbox_regressionresults.Controls.Add(this.dgv_regressionresult);
            this.gbox_regressionresults.Location = new System.Drawing.Point(4, 23);
            this.gbox_regressionresults.Name = "gbox_regressionresults";
            this.gbox_regressionresults.Size = new System.Drawing.Size(1175, 304);
            this.gbox_regressionresults.TabIndex = 0;
            this.gbox_regressionresults.TabStop = false;
            this.gbox_regressionresults.Text = "回归结果";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(572, 134);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 7;
            // 
            // dgv_regressionresult
            // 
            this.dgv_regressionresult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_regressionresult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_regressionresult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_regressionresult.Location = new System.Drawing.Point(8, 20);
            this.dgv_regressionresult.Name = "dgv_regressionresult";
            this.dgv_regressionresult.RowTemplate.Height = 23;
            this.dgv_regressionresult.Size = new System.Drawing.Size(1161, 278);
            this.dgv_regressionresult.TabIndex = 0;
            // 
            // gbox_coefficientrevision
            // 
            this.gbox_coefficientrevision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_coefficientrevision.Controls.Add(this.dgv_coefficientrevision);
            this.gbox_coefficientrevision.Location = new System.Drawing.Point(4, 333);
            this.gbox_coefficientrevision.Name = "gbox_coefficientrevision";
            this.gbox_coefficientrevision.Size = new System.Drawing.Size(1175, 293);
            this.gbox_coefficientrevision.TabIndex = 1;
            this.gbox_coefficientrevision.TabStop = false;
            this.gbox_coefficientrevision.Text = "系数校正";
            // 
            // dgv_coefficientrevision
            // 
            this.dgv_coefficientrevision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_coefficientrevision.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_coefficientrevision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_coefficientrevision.Location = new System.Drawing.Point(8, 20);
            this.dgv_coefficientrevision.Name = "dgv_coefficientrevision";
            this.dgv_coefficientrevision.RowTemplate.Height = 23;
            this.dgv_coefficientrevision.Size = new System.Drawing.Size(1161, 267);
            this.dgv_coefficientrevision.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_add.Location = new System.Drawing.Point(12, 648);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_delete.Location = new System.Drawing.Point(102, 648);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "删除";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_deblock
            // 
            this.btn_deblock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_deblock.Location = new System.Drawing.Point(192, 648);
            this.btn_deblock.Name = "btn_deblock";
            this.btn_deblock.Size = new System.Drawing.Size(75, 23);
            this.btn_deblock.TabIndex = 4;
            this.btn_deblock.Text = "解锁";
            this.btn_deblock.UseVisualStyleBackColor = true;
            // 
            // btn_lock
            // 
            this.btn_lock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_lock.Location = new System.Drawing.Point(282, 648);
            this.btn_lock.Name = "btn_lock";
            this.btn_lock.Size = new System.Drawing.Size(75, 23);
            this.btn_lock.TabIndex = 5;
            this.btn_lock.Text = "锁定";
            this.btn_lock.UseVisualStyleBackColor = true;
            // 
            // btn_theoreticalcoefficient
            // 
            this.btn_theoreticalcoefficient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_theoreticalcoefficient.Location = new System.Drawing.Point(372, 648);
            this.btn_theoreticalcoefficient.Name = "btn_theoreticalcoefficient";
            this.btn_theoreticalcoefficient.Size = new System.Drawing.Size(75, 23);
            this.btn_theoreticalcoefficient.TabIndex = 6;
            this.btn_theoreticalcoefficient.Text = "理论系数";
            this.btn_theoreticalcoefficient.UseVisualStyleBackColor = true;
            this.btn_theoreticalcoefficient.Click += new System.EventHandler(this.btn_theoreticalcoefficient_Click);
            // 
            // btn_calculate
            // 
            this.btn_calculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_calculate.Location = new System.Drawing.Point(466, 648);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.Size = new System.Drawing.Size(75, 23);
            this.btn_calculate.TabIndex = 7;
            this.btn_calculate.Text = "计算";
            this.btn_calculate.UseVisualStyleBackColor = true;
            // 
            // btn_limitofdetection
            // 
            this.btn_limitofdetection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_limitofdetection.Location = new System.Drawing.Point(559, 648);
            this.btn_limitofdetection.Name = "btn_limitofdetection";
            this.btn_limitofdetection.Size = new System.Drawing.Size(75, 23);
            this.btn_limitofdetection.TabIndex = 8;
            this.btn_limitofdetection.Text = "检出限";
            this.btn_limitofdetection.UseVisualStyleBackColor = true;
            this.btn_limitofdetection.Click += new System.EventHandler(this.btn_limitofdetection_Click);
            // 
            // btn_checkdata
            // 
            this.btn_checkdata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_checkdata.Location = new System.Drawing.Point(650, 648);
            this.btn_checkdata.Name = "btn_checkdata";
            this.btn_checkdata.Size = new System.Drawing.Size(75, 23);
            this.btn_checkdata.TabIndex = 9;
            this.btn_checkdata.Text = "查看数据";
            this.btn_checkdata.UseVisualStyleBackColor = true;
            this.btn_checkdata.Click += new System.EventHandler(this.btn_checkdata_Click);
            // 
            // btn_regressionLine
            // 
            this.btn_regressionLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_regressionLine.Location = new System.Drawing.Point(741, 648);
            this.btn_regressionLine.Name = "btn_regressionLine";
            this.btn_regressionLine.Size = new System.Drawing.Size(75, 23);
            this.btn_regressionLine.TabIndex = 10;
            this.btn_regressionLine.Text = "回归曲线";
            this.btn_regressionLine.UseVisualStyleBackColor = true;
            this.btn_regressionLine.Click += new System.EventHandler(this.btn_regressionLine_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_save.Location = new System.Drawing.Point(835, 648);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_print.Location = new System.Drawing.Point(923, 648);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 12;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // Revision_QuantitationAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 692);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_regressionLine);
            this.Controls.Add(this.btn_checkdata);
            this.Controls.Add(this.btn_limitofdetection);
            this.Controls.Add(this.btn_calculate);
            this.Controls.Add(this.btn_theoreticalcoefficient);
            this.Controls.Add(this.btn_lock);
            this.Controls.Add(this.btn_deblock);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.gbox_coefficientrevision);
            this.Controls.Add(this.gbox_regressionresults);
            this.Name = "Revision_QuantitationAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "校正";
            this.Load += new System.EventHandler(this.Revision_QuantitationAnalysis_Load);
            this.gbox_regressionresults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_regressionresult)).EndInit();
            this.gbox_coefficientrevision.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_coefficientrevision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox_regressionresults;
        private System.Windows.Forms.DataGridView dgv_regressionresult;
        private System.Windows.Forms.GroupBox gbox_coefficientrevision;
        private System.Windows.Forms.DataGridView dgv_coefficientrevision;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_deblock;
        private System.Windows.Forms.Button btn_lock;
        private System.Windows.Forms.Button btn_theoreticalcoefficient;
        private System.Windows.Forms.Button btn_calculate;
        private System.Windows.Forms.Button btn_limitofdetection;
        private System.Windows.Forms.Button btn_checkdata;
        private System.Windows.Forms.Button btn_regressionLine;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}