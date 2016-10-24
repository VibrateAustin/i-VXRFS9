namespace i_VXRFS.SystemConfiguration
{
    partial class edxrf_sysconfiguration
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
            this.gbox_detector = new System.Windows.Forms.GroupBox();
            this.dgv_detector = new System.Windows.Forms.DataGridView();
            this.gbox_monochromator = new System.Windows.Forms.GroupBox();
            this.dgv_monochromator = new System.Windows.Forms.DataGridView();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.gbox_multiprogramnumber = new System.Windows.Forms.GroupBox();
            this.cbox_multiprogramnumber = new System.Windows.Forms.ComboBox();
            this.gbox_detector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detector)).BeginInit();
            this.gbox_monochromator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_monochromator)).BeginInit();
            this.gbox_multiprogramnumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbox_detector
            // 
            this.gbox_detector.Controls.Add(this.dgv_detector);
            this.gbox_detector.Location = new System.Drawing.Point(12, 12);
            this.gbox_detector.Name = "gbox_detector";
            this.gbox_detector.Size = new System.Drawing.Size(421, 132);
            this.gbox_detector.TabIndex = 3;
            this.gbox_detector.TabStop = false;
            this.gbox_detector.Text = "探测器";
            // 
            // dgv_detector
            // 
            this.dgv_detector.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_detector.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_detector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_detector.Location = new System.Drawing.Point(14, 32);
            this.dgv_detector.Name = "dgv_detector";
            this.dgv_detector.RowTemplate.Height = 23;
            this.dgv_detector.Size = new System.Drawing.Size(396, 90);
            this.dgv_detector.TabIndex = 1;
            // 
            // gbox_monochromator
            // 
            this.gbox_monochromator.Controls.Add(this.dgv_monochromator);
            this.gbox_monochromator.Location = new System.Drawing.Point(12, 150);
            this.gbox_monochromator.Name = "gbox_monochromator";
            this.gbox_monochromator.Size = new System.Drawing.Size(421, 291);
            this.gbox_monochromator.TabIndex = 4;
            this.gbox_monochromator.TabStop = false;
            this.gbox_monochromator.Text = "单色器";
            // 
            // dgv_monochromator
            // 
            this.dgv_monochromator.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_monochromator.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_monochromator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_monochromator.Location = new System.Drawing.Point(14, 32);
            this.dgv_monochromator.Name = "dgv_monochromator";
            this.dgv_monochromator.RowTemplate.Height = 23;
            this.dgv_monochromator.Size = new System.Drawing.Size(396, 253);
            this.dgv_monochromator.TabIndex = 1;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_close.Location = new System.Drawing.Point(242, 484);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 10;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_print.Location = new System.Drawing.Point(132, 484);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 9;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_save.Location = new System.Drawing.Point(28, 484);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // gbox_multiprogramnumber
            // 
            this.gbox_multiprogramnumber.Controls.Add(this.cbox_multiprogramnumber);
            this.gbox_multiprogramnumber.Location = new System.Drawing.Point(454, 150);
            this.gbox_multiprogramnumber.MaximumSize = new System.Drawing.Size(180, 80);
            this.gbox_multiprogramnumber.MinimumSize = new System.Drawing.Size(180, 80);
            this.gbox_multiprogramnumber.Name = "gbox_multiprogramnumber";
            this.gbox_multiprogramnumber.Size = new System.Drawing.Size(180, 80);
            this.gbox_multiprogramnumber.TabIndex = 4;
            this.gbox_multiprogramnumber.TabStop = false;
            this.gbox_multiprogramnumber.Text = "多道数";
            // 
            // cbox_multiprogramnumber
            // 
            this.cbox_multiprogramnumber.FormattingEnabled = true;
            this.cbox_multiprogramnumber.Items.AddRange(new object[] {
            "8192",
            "4096",
            "2048",
            "1024",
            "512"});
            this.cbox_multiprogramnumber.Location = new System.Drawing.Point(12, 36);
            this.cbox_multiprogramnumber.Name = "cbox_multiprogramnumber";
            this.cbox_multiprogramnumber.Size = new System.Drawing.Size(157, 20);
            this.cbox_multiprogramnumber.TabIndex = 0;
            // 
            // edxrf_sysconfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 532);
            this.Controls.Add(this.gbox_multiprogramnumber);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.gbox_monochromator);
            this.Controls.Add(this.gbox_detector);
            this.MaximumSize = new System.Drawing.Size(660, 570);
            this.MinimumSize = new System.Drawing.Size(660, 570);
            this.Name = "edxrf_sysconfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "能量色散系统配置";
            this.Load += new System.EventHandler(this.edxrf_sysconfiguration_Load);
            this.gbox_detector.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detector)).EndInit();
            this.gbox_monochromator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_monochromator)).EndInit();
            this.gbox_multiprogramnumber.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox_detector;
        private System.Windows.Forms.DataGridView dgv_detector;
        private System.Windows.Forms.GroupBox gbox_monochromator;
        private System.Windows.Forms.DataGridView dgv_monochromator;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.GroupBox gbox_multiprogramnumber;
        private System.Windows.Forms.ComboBox cbox_multiprogramnumber;
    }
}