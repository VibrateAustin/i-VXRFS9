namespace i_VXRFS.ApplicationProcedure
{
    partial class SystemCompound
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tctr_systemcompound = new System.Windows.Forms.TabControl();
            this.tabPage_oxide = new System.Windows.Forms.TabPage();
            this.dgv_oxide = new System.Windows.Forms.DataGridView();
            this.tabPage_nonoxide = new System.Windows.Forms.TabPage();
            this.dgv_nonoxide = new System.Windows.Forms.DataGridView();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.tctr_systemcompound.SuspendLayout();
            this.tabPage_oxide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_oxide)).BeginInit();
            this.tabPage_nonoxide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nonoxide)).BeginInit();
            this.SuspendLayout();
            // 
            // tctr_systemcompound
            // 
            this.tctr_systemcompound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tctr_systemcompound.Controls.Add(this.tabPage_oxide);
            this.tctr_systemcompound.Controls.Add(this.tabPage_nonoxide);
            this.tctr_systemcompound.Location = new System.Drawing.Point(0, 29);
            this.tctr_systemcompound.Name = "tctr_systemcompound";
            this.tctr_systemcompound.SelectedIndex = 0;
            this.tctr_systemcompound.Size = new System.Drawing.Size(985, 500);
            this.tctr_systemcompound.TabIndex = 0;
            this.tctr_systemcompound.SelectedIndexChanged += new System.EventHandler(this.tctr_systemcompound_SelectedIndexChanged);
            this.tctr_systemcompound.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tctr_systemcompound_MouseMove);
            // 
            // tabPage_oxide
            // 
            this.tabPage_oxide.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_oxide.Controls.Add(this.dgv_oxide);
            this.tabPage_oxide.Location = new System.Drawing.Point(4, 22);
            this.tabPage_oxide.Name = "tabPage_oxide";
            this.tabPage_oxide.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_oxide.Size = new System.Drawing.Size(977, 474);
            this.tabPage_oxide.TabIndex = 0;
            this.tabPage_oxide.Text = "氧化物";
            // 
            // dgv_oxide
            // 
            this.dgv_oxide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_oxide.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_oxide.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_oxide.Location = new System.Drawing.Point(0, 22);
            this.dgv_oxide.Name = "dgv_oxide";
            this.dgv_oxide.RowTemplate.Height = 23;
            this.dgv_oxide.Size = new System.Drawing.Size(977, 452);
            this.dgv_oxide.TabIndex = 0;
            // 
            // tabPage_nonoxide
            // 
            this.tabPage_nonoxide.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_nonoxide.Controls.Add(this.dgv_nonoxide);
            this.tabPage_nonoxide.Location = new System.Drawing.Point(4, 22);
            this.tabPage_nonoxide.Name = "tabPage_nonoxide";
            this.tabPage_nonoxide.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_nonoxide.Size = new System.Drawing.Size(977, 474);
            this.tabPage_nonoxide.TabIndex = 1;
            this.tabPage_nonoxide.Text = "非氧化物";
            // 
            // dgv_nonoxide
            // 
            this.dgv_nonoxide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_nonoxide.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_nonoxide.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nonoxide.Location = new System.Drawing.Point(0, 21);
            this.dgv_nonoxide.Name = "dgv_nonoxide";
            this.dgv_nonoxide.RowTemplate.Height = 23;
            this.dgv_nonoxide.Size = new System.Drawing.Size(1177, 622);
            this.dgv_nonoxide.TabIndex = 1;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_save.Location = new System.Drawing.Point(12, 557);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancle.Location = new System.Drawing.Point(119, 557);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 2;
            this.btn_cancle.Text = "删除";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_close.Location = new System.Drawing.Point(231, 557);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_print.Location = new System.Drawing.Point(344, 557);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 4;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // SystemCompound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 602);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tctr_systemcompound);
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "SystemCompound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统化合物";
            this.Load += new System.EventHandler(this.SystemCompound_Load);
            this.tctr_systemcompound.ResumeLayout(false);
            this.tabPage_oxide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_oxide)).EndInit();
            this.tabPage_nonoxide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nonoxide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tctr_systemcompound;
        private System.Windows.Forms.TabPage tabPage_oxide;
        private System.Windows.Forms.TabPage tabPage_nonoxide;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.DataGridView dgv_oxide;
        private System.Windows.Forms.DataGridView dgv_nonoxide;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_print;
    }
}