namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    partial class Standardsample
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataView = new System.Windows.Forms.DataGridView();
            this.addStandard = new System.Windows.Forms.Button();
            this.deleteStandard = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.importStandards = new System.Windows.Forms.Button();
            this.exportStandards = new System.Windows.Forms.Button();
            this.addCompound = new System.Windows.Forms.Button();
            this.deleteCompound = new System.Windows.Forms.Button();
            this.morphologyBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.additiveBox = new System.Windows.Forms.ComboBox();
            this.ratioBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelFilter = new System.Windows.Forms.Button();
            this.filter = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.datePicker1 = new System.Windows.Forms.DateTimePicker();
            this.datePicker2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AllowUserToResizeColumns = false;
            this.dataView.AllowUserToResizeRows = false;
            this.dataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(11, 71);
            this.dataView.Margin = new System.Windows.Forms.Padding(2);
            this.dataView.MultiSelect = false;
            this.dataView.Name = "dataView";
            this.dataView.RowTemplate.Height = 27;
            this.dataView.Size = new System.Drawing.Size(1055, 508);
            this.dataView.TabIndex = 0;
            this.dataView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataView_CellBeginEdit);
            this.dataView.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataView_CellParsing);
            this.dataView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellValueChanged);
            // 
            // addStandard
            // 
            this.addStandard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addStandard.Enabled = false;
            this.addStandard.Location = new System.Drawing.Point(9, 592);
            this.addStandard.Margin = new System.Windows.Forms.Padding(2);
            this.addStandard.Name = "addStandard";
            this.addStandard.Size = new System.Drawing.Size(70, 27);
            this.addStandard.TabIndex = 1;
            this.addStandard.Text = "添加标样";
            this.addStandard.UseVisualStyleBackColor = true;
            this.addStandard.Click += new System.EventHandler(this.addStandard_Click);
            // 
            // deleteStandard
            // 
            this.deleteStandard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteStandard.Enabled = false;
            this.deleteStandard.Location = new System.Drawing.Point(84, 592);
            this.deleteStandard.Margin = new System.Windows.Forms.Padding(2);
            this.deleteStandard.Name = "deleteStandard";
            this.deleteStandard.Size = new System.Drawing.Size(70, 27);
            this.deleteStandard.TabIndex = 2;
            this.deleteStandard.Text = "删除标样";
            this.deleteStandard.UseVisualStyleBackColor = true;
            this.deleteStandard.Click += new System.EventHandler(this.deleteStandard_Click);
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.save.Enabled = false;
            this.save.Location = new System.Drawing.Point(384, 592);
            this.save.Margin = new System.Windows.Forms.Padding(2);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(70, 27);
            this.save.TabIndex = 4;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // importStandards
            // 
            this.importStandards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importStandards.Location = new System.Drawing.Point(309, 592);
            this.importStandards.Margin = new System.Windows.Forms.Padding(2);
            this.importStandards.Name = "importStandards";
            this.importStandards.Size = new System.Drawing.Size(70, 27);
            this.importStandards.TabIndex = 5;
            this.importStandards.Text = "导入标样";
            this.importStandards.UseVisualStyleBackColor = true;
            this.importStandards.Click += new System.EventHandler(this.importStandards_Click);
            // 
            // exportStandards
            // 
            this.exportStandards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportStandards.Enabled = false;
            this.exportStandards.Location = new System.Drawing.Point(459, 592);
            this.exportStandards.Margin = new System.Windows.Forms.Padding(2);
            this.exportStandards.Name = "exportStandards";
            this.exportStandards.Size = new System.Drawing.Size(70, 27);
            this.exportStandards.TabIndex = 6;
            this.exportStandards.Text = "导出Excel";
            this.exportStandards.UseVisualStyleBackColor = true;
            this.exportStandards.Click += new System.EventHandler(this.exportStandards_Click);
            // 
            // addCompound
            // 
            this.addCompound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addCompound.Enabled = false;
            this.addCompound.Location = new System.Drawing.Point(159, 592);
            this.addCompound.Margin = new System.Windows.Forms.Padding(2);
            this.addCompound.Name = "addCompound";
            this.addCompound.Size = new System.Drawing.Size(70, 27);
            this.addCompound.TabIndex = 7;
            this.addCompound.Text = "添加化合物";
            this.addCompound.UseVisualStyleBackColor = true;
            this.addCompound.Click += new System.EventHandler(this.addCompound_Click);
            // 
            // deleteCompound
            // 
            this.deleteCompound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteCompound.Enabled = false;
            this.deleteCompound.Location = new System.Drawing.Point(234, 592);
            this.deleteCompound.Margin = new System.Windows.Forms.Padding(2);
            this.deleteCompound.Name = "deleteCompound";
            this.deleteCompound.Size = new System.Drawing.Size(70, 27);
            this.deleteCompound.TabIndex = 8;
            this.deleteCompound.Text = "删除化合物";
            this.deleteCompound.UseVisualStyleBackColor = true;
            this.deleteCompound.Click += new System.EventHandler(this.deleteCompound_Click);
            // 
            // morphologyBox
            // 
            this.morphologyBox.FormattingEnabled = true;
            this.morphologyBox.Location = new System.Drawing.Point(9, 30);
            this.morphologyBox.Margin = new System.Windows.Forms.Padding(2);
            this.morphologyBox.Name = "morphologyBox";
            this.morphologyBox.Size = new System.Drawing.Size(89, 20);
            this.morphologyBox.TabIndex = 10;
            this.morphologyBox.SelectedIndexChanged += new System.EventHandler(this.morphologyBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "标样形态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "添加剂";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "比例/类型";
            // 
            // additiveBox
            // 
            this.additiveBox.FormattingEnabled = true;
            this.additiveBox.Location = new System.Drawing.Point(101, 30);
            this.additiveBox.Margin = new System.Windows.Forms.Padding(2);
            this.additiveBox.Name = "additiveBox";
            this.additiveBox.Size = new System.Drawing.Size(89, 20);
            this.additiveBox.TabIndex = 17;
            // 
            // ratioBox
            // 
            this.ratioBox.FormattingEnabled = true;
            this.ratioBox.Location = new System.Drawing.Point(194, 30);
            this.ratioBox.Margin = new System.Windows.Forms.Padding(2);
            this.ratioBox.Name = "ratioBox";
            this.ratioBox.Size = new System.Drawing.Size(89, 20);
            this.ratioBox.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "标样建立时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "to";
            // 
            // cancelFilter
            // 
            this.cancelFilter.Location = new System.Drawing.Point(600, 30);
            this.cancelFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cancelFilter.Name = "cancelFilter";
            this.cancelFilter.Size = new System.Drawing.Size(70, 21);
            this.cancelFilter.TabIndex = 14;
            this.cancelFilter.Text = "取消过滤";
            this.cancelFilter.UseVisualStyleBackColor = true;
            this.cancelFilter.Click += new System.EventHandler(this.cancelFilter_Click);
            // 
            // filter
            // 
            this.filter.Location = new System.Drawing.Point(505, 30);
            this.filter.Margin = new System.Windows.Forms.Padding(2);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(71, 21);
            this.filter.TabIndex = 12;
            this.filter.Text = "过滤";
            this.filter.UseVisualStyleBackColor = true;
            this.filter.Click += new System.EventHandler(this.filter_Click);
            // 
            // print
            // 
            this.print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.print.Enabled = false;
            this.print.Location = new System.Drawing.Point(534, 592);
            this.print.Margin = new System.Windows.Forms.Padding(2);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(70, 27);
            this.print.TabIndex = 24;
            this.print.Text = "打印";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(505, 101);
            this.calendar.Margin = new System.Windows.Forms.Padding(7);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.ShowTodayCircle = false;
            this.calendar.TabIndex = 25;
            this.calendar.Visible = false;
            this.calendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateSelected);
            // 
            // datePicker1
            // 
            this.datePicker1.CustomFormat = "yyyyMMdd";
            this.datePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker1.Location = new System.Drawing.Point(292, 30);
            this.datePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.datePicker1.Name = "datePicker1";
            this.datePicker1.Size = new System.Drawing.Size(75, 21);
            this.datePicker1.TabIndex = 28;
            // 
            // datePicker2
            // 
            this.datePicker2.CustomFormat = "yyyyMMdd";
            this.datePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker2.Location = new System.Drawing.Point(405, 30);
            this.datePicker2.Margin = new System.Windows.Forms.Padding(2);
            this.datePicker2.Name = "datePicker2";
            this.datePicker2.Size = new System.Drawing.Size(72, 21);
            this.datePicker2.TabIndex = 29;
            // 
            // Standardsample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 628);
            this.Controls.Add(this.datePicker2);
            this.Controls.Add(this.datePicker1);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.print);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ratioBox);
            this.Controls.Add(this.additiveBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelFilter);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.morphologyBox);
            this.Controls.Add(this.deleteCompound);
            this.Controls.Add(this.addCompound);
            this.Controls.Add(this.exportStandards);
            this.Controls.Add(this.importStandards);
            this.Controls.Add(this.save);
            this.Controls.Add(this.deleteStandard);
            this.Controls.Add(this.addStandard);
            this.Controls.Add(this.dataView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Standardsample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标样";
            this.Load += new System.EventHandler(this.Standards_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button addStandard;
        private System.Windows.Forms.Button deleteStandard;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button importStandards;
        private System.Windows.Forms.Button exportStandards;
        private System.Windows.Forms.Button addCompound;
        private System.Windows.Forms.Button deleteCompound;
        private System.Windows.Forms.ComboBox morphologyBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox additiveBox;
        private System.Windows.Forms.ComboBox ratioBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelFilter;
        private System.Windows.Forms.Button filter;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.DateTimePicker datePicker1;
        private System.Windows.Forms.DateTimePicker datePicker2;
    }
}

