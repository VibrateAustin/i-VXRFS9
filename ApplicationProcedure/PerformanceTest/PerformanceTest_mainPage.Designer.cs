namespace i_VXRFS.ApplicationProcedure.PerformanceTest
{
    partial class PerformanceTest_mainPage
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
            this.dgv_element = new System.Windows.Forms.DataGridView();
            this.bt_phd = new System.Windows.Forms.Button();
            this.bt_angel = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_print = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_wdxrf = new System.Windows.Forms.Button();
            this.btn_edxrf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_element)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_element
            // 
            this.dgv_element.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_element.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_element.Location = new System.Drawing.Point(3, 25);
            this.dgv_element.Name = "dgv_element";
            this.dgv_element.RowTemplate.Height = 23;
            this.dgv_element.Size = new System.Drawing.Size(1078, 596);
            this.dgv_element.TabIndex = 0;
            this.dgv_element.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_element_CellMouseClick);
            // 
            // bt_phd
            // 
            this.bt_phd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_phd.Location = new System.Drawing.Point(264, 654);
            this.bt_phd.Name = "bt_phd";
            this.bt_phd.Size = new System.Drawing.Size(75, 23);
            this.bt_phd.TabIndex = 1;
            this.bt_phd.Text = "PHA";
            this.bt_phd.UseVisualStyleBackColor = true;
            this.bt_phd.Click += new System.EventHandler(this.bt_phd_Click);
            // 
            // bt_angel
            // 
            this.bt_angel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_angel.Location = new System.Drawing.Point(380, 654);
            this.bt_angel.Name = "bt_angel";
            this.bt_angel.Size = new System.Drawing.Size(75, 23);
            this.bt_angel.TabIndex = 2;
            this.bt_angel.Text = "角度";
            this.bt_angel.UseVisualStyleBackColor = true;
            this.bt_angel.Click += new System.EventHandler(this.bt_angel_Click);
            // 
            // bt_save
            // 
            this.bt_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_save.Location = new System.Drawing.Point(35, 654);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 3;
            this.bt_save.Text = "保存";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_print
            // 
            this.bt_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_print.Location = new System.Drawing.Point(147, 654);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(75, 23);
            this.bt_print.TabIndex = 4;
            this.bt_print.Text = "打印";
            this.bt_print.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(524, 209);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_wdxrf
            // 
            this.btn_wdxrf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_wdxrf.Location = new System.Drawing.Point(495, 654);
            this.btn_wdxrf.Name = "btn_wdxrf";
            this.btn_wdxrf.Size = new System.Drawing.Size(75, 23);
            this.btn_wdxrf.TabIndex = 8;
            this.btn_wdxrf.Text = "波谱性能";
            this.btn_wdxrf.UseVisualStyleBackColor = true;
            this.btn_wdxrf.Click += new System.EventHandler(this.btn_wdxrf_Click);
            // 
            // btn_edxrf
            // 
            this.btn_edxrf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_edxrf.Location = new System.Drawing.Point(613, 654);
            this.btn_edxrf.Name = "btn_edxrf";
            this.btn_edxrf.Size = new System.Drawing.Size(75, 23);
            this.btn_edxrf.TabIndex = 9;
            this.btn_edxrf.Text = "能谱性能";
            this.btn_edxrf.UseVisualStyleBackColor = true;
            this.btn_edxrf.Click += new System.EventHandler(this.btn_edxrf_Click);
            // 
            // PerformanceTest_mainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 712);
            this.Controls.Add(this.btn_edxrf);
            this.Controls.Add(this.btn_wdxrf);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bt_print);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_angel);
            this.Controls.Add(this.bt_phd);
            this.Controls.Add(this.dgv_element);
            this.Name = "PerformanceTest_mainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "性能测试";
            this.Load += new System.EventHandler(this.PHDAngelRevision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_element)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_element;
        private System.Windows.Forms.Button bt_phd;
        private System.Windows.Forms.Button bt_angel;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_print;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_wdxrf;
        private System.Windows.Forms.Button btn_edxrf;
    }
}