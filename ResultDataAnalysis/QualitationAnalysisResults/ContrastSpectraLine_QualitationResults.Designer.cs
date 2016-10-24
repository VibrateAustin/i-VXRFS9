namespace i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults
{
    partial class ContrastSpectraLine_QualitationResults
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_scanarea = new System.Windows.Forms.ComboBox();
            this.btn_showAllSpectraLine = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_deductBg = new System.Windows.Forms.Button();
            this.btn_merge = new System.Windows.Forms.Button();
            this.btn_deduct = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_addcontrastsample = new System.Windows.Forms.Button();
            this.dgv_contrastspectraline = new System.Windows.Forms.DataGridView();
            this.lb_y = new System.Windows.Forms.Label();
            this.lb_x = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picb_contrast = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_contrastspectraline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb_contrast)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbox_scanarea);
            this.groupBox1.Controls.Add(this.btn_showAllSpectraLine);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.btn_deductBg);
            this.groupBox1.Controls.Add(this.btn_merge);
            this.groupBox1.Controls.Add(this.btn_deduct);
            this.groupBox1.Controls.Add(this.btn_cancle);
            this.groupBox1.Controls.Add(this.btn_addcontrastsample);
            this.groupBox1.Controls.Add(this.dgv_contrastspectraline);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(978, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(826, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "扫描区段:";
            // 
            // cbox_scanarea
            // 
            this.cbox_scanarea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbox_scanarea.FormattingEnabled = true;
            this.cbox_scanarea.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.cbox_scanarea.Location = new System.Drawing.Point(891, 242);
            this.cbox_scanarea.Name = "cbox_scanarea";
            this.cbox_scanarea.Size = new System.Drawing.Size(67, 20);
            this.cbox_scanarea.TabIndex = 16;
            this.cbox_scanarea.SelectedIndexChanged += new System.EventHandler(this.cbox_scanarea_SelectedIndexChanged);
            // 
            // btn_showAllSpectraLine
            // 
            this.btn_showAllSpectraLine.Location = new System.Drawing.Point(515, 242);
            this.btn_showAllSpectraLine.Name = "btn_showAllSpectraLine";
            this.btn_showAllSpectraLine.Size = new System.Drawing.Size(111, 23);
            this.btn_showAllSpectraLine.TabIndex = 7;
            this.btn_showAllSpectraLine.Text = "显示所有区段谱线";
            this.btn_showAllSpectraLine.UseVisualStyleBackColor = true;
            this.btn_showAllSpectraLine.Click += new System.EventHandler(this.btn_showAllSpectraLine_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(435, 242);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(74, 23);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "保存结果";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_deductBg
            // 
            this.btn_deductBg.Location = new System.Drawing.Point(355, 242);
            this.btn_deductBg.Name = "btn_deductBg";
            this.btn_deductBg.Size = new System.Drawing.Size(74, 23);
            this.btn_deductBg.TabIndex = 5;
            this.btn_deductBg.Text = "扣除背景";
            this.btn_deductBg.UseVisualStyleBackColor = true;
            this.btn_deductBg.Click += new System.EventHandler(this.btn_deductBg_Click);
            // 
            // btn_merge
            // 
            this.btn_merge.Location = new System.Drawing.Point(275, 242);
            this.btn_merge.Name = "btn_merge";
            this.btn_merge.Size = new System.Drawing.Size(74, 23);
            this.btn_merge.TabIndex = 4;
            this.btn_merge.Text = "合并";
            this.btn_merge.UseVisualStyleBackColor = true;
            this.btn_merge.Click += new System.EventHandler(this.btn_merge_Click);
            // 
            // btn_deduct
            // 
            this.btn_deduct.Location = new System.Drawing.Point(195, 242);
            this.btn_deduct.Name = "btn_deduct";
            this.btn_deduct.Size = new System.Drawing.Size(74, 23);
            this.btn_deduct.TabIndex = 3;
            this.btn_deduct.Text = "相减";
            this.btn_deduct.UseVisualStyleBackColor = true;
            this.btn_deduct.Click += new System.EventHandler(this.btn_deduct_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(115, 242);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(74, 23);
            this.btn_cancle.TabIndex = 2;
            this.btn_cancle.Text = "删除";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_addcontrastsample
            // 
            this.btn_addcontrastsample.Location = new System.Drawing.Point(20, 242);
            this.btn_addcontrastsample.Name = "btn_addcontrastsample";
            this.btn_addcontrastsample.Size = new System.Drawing.Size(89, 23);
            this.btn_addcontrastsample.TabIndex = 1;
            this.btn_addcontrastsample.Text = "选择对比样品";
            this.btn_addcontrastsample.UseVisualStyleBackColor = true;
            this.btn_addcontrastsample.Click += new System.EventHandler(this.btn_addcontrastsample_Click);
            // 
            // dgv_contrastspectraline
            // 
            this.dgv_contrastspectraline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_contrastspectraline.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_contrastspectraline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_contrastspectraline.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_contrastspectraline.Location = new System.Drawing.Point(6, 11);
            this.dgv_contrastspectraline.Name = "dgv_contrastspectraline";
            this.dgv_contrastspectraline.RowTemplate.Height = 23;
            this.dgv_contrastspectraline.Size = new System.Drawing.Size(966, 213);
            this.dgv_contrastspectraline.TabIndex = 0;
            // 
            // lb_y
            // 
            this.lb_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_y.AutoSize = true;
            this.lb_y.Location = new System.Drawing.Point(269, 581);
            this.lb_y.Name = "lb_y";
            this.lb_y.Size = new System.Drawing.Size(0, 12);
            this.lb_y.TabIndex = 13;
            // 
            // lb_x
            // 
            this.lb_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_x.AutoSize = true;
            this.lb_x.Location = new System.Drawing.Point(184, 581);
            this.lb_x.Name = "lb_x";
            this.lb_x.Size = new System.Drawing.Size(0, 12);
            this.lb_x.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 581);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Y:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 581);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "X:";
            // 
            // picb_contrast
            // 
            this.picb_contrast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picb_contrast.BackColor = System.Drawing.Color.White;
            this.picb_contrast.Location = new System.Drawing.Point(9, 291);
            this.picb_contrast.Name = "picb_contrast";
            this.picb_contrast.Size = new System.Drawing.Size(966, 280);
            this.picb_contrast.TabIndex = 14;
            this.picb_contrast.TabStop = false;
            this.picb_contrast.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picb_contrast_MouseMove);
            // 
            // ContrastSpectraLine_QualitationResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 602);
            this.Controls.Add(this.picb_contrast);
            this.Controls.Add(this.lb_y);
            this.Controls.Add(this.lb_x);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1000, 640);
            this.Name = "ContrastSpectraLine_QualitationResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "谱图对比";
            this.Load += new System.EventHandler(this.ContrastSpectraLine_QualitationResults_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_contrastspectraline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb_contrast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_contrastspectraline;
        private System.Windows.Forms.Button btn_addcontrastsample;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_merge;
        private System.Windows.Forms.Button btn_deduct;
        private System.Windows.Forms.Button btn_showAllSpectraLine;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_deductBg;
        private System.Windows.Forms.Label lb_y;
        private System.Windows.Forms.Label lb_x;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picb_contrast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_scanarea;
    }
}