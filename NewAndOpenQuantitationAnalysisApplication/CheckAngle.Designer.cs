namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    partial class CheckAngle
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
            this.gbox_angleparameter = new System.Windows.Forms.GroupBox();
            this.tabCtr_Angle = new System.Windows.Forms.TabControl();
            this.tabP_parameter = new System.Windows.Forms.TabPage();
            this.ckbox_noloadsample = new System.Windows.Forms.CheckBox();
            this.txtb_scantime = new System.Windows.Forms.TextBox();
            this.txtb_step = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbox_mask = new System.Windows.Forms.ComboBox();
            this.txtb_endangle = new System.Windows.Forms.TextBox();
            this.txtb_startangle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabP_bg = new System.Windows.Forms.TabPage();
            this.dgv_bgConff = new System.Windows.Forms.DataGridView();
            this.dgv_bgPoint = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabP_time = new System.Windows.Forms.TabPage();
            this.dgv_time = new System.Windows.Forms.DataGridView();
            this.Abs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bg1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bg2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bg3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bg4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtb_sensilivity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtb_peakbg = new System.Windows.Forms.TextBox();
            this.txtb_conc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabP_overlap = new System.Windows.Forms.TabPage();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txtb_angle = new System.Windows.Forms.TextBox();
            this.txtb_line = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gbox_scanresult = new System.Windows.Forms.GroupBox();
            this.picb_overlap = new System.Windows.Forms.PictureBox();
            this.txtb_peakposition = new System.Windows.Forms.TextBox();
            this.cbox_Y = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_measurement = new System.Windows.Forms.Button();
            this.btn_loadsample = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.txtb_bgTime = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.gbox_angleparameter.SuspendLayout();
            this.tabCtr_Angle.SuspendLayout();
            this.tabP_parameter.SuspendLayout();
            this.tabP_bg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bgConff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bgPoint)).BeginInit();
            this.tabP_time.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_time)).BeginInit();
            this.tabP_overlap.SuspendLayout();
            this.gbox_scanresult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_overlap)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox_angleparameter
            // 
            this.gbox_angleparameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_angleparameter.Controls.Add(this.tabCtr_Angle);
            this.gbox_angleparameter.Location = new System.Drawing.Point(3, 12);
            this.gbox_angleparameter.Name = "gbox_angleparameter";
            this.gbox_angleparameter.Size = new System.Drawing.Size(1079, 152);
            this.gbox_angleparameter.TabIndex = 0;
            this.gbox_angleparameter.TabStop = false;
            // 
            // tabCtr_Angle
            // 
            this.tabCtr_Angle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtr_Angle.Controls.Add(this.tabP_parameter);
            this.tabCtr_Angle.Controls.Add(this.tabP_bg);
            this.tabCtr_Angle.Controls.Add(this.tabP_time);
            this.tabCtr_Angle.Controls.Add(this.tabP_overlap);
            this.tabCtr_Angle.Location = new System.Drawing.Point(6, 11);
            this.tabCtr_Angle.Name = "tabCtr_Angle";
            this.tabCtr_Angle.SelectedIndex = 0;
            this.tabCtr_Angle.Size = new System.Drawing.Size(1073, 135);
            this.tabCtr_Angle.TabIndex = 0;
            this.tabCtr_Angle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabCtr_Angle_MouseMove);
            // 
            // tabP_parameter
            // 
            this.tabP_parameter.BackColor = System.Drawing.Color.Transparent;
            this.tabP_parameter.Controls.Add(this.txtb_bgTime);
            this.tabP_parameter.Controls.Add(this.label16);
            this.tabP_parameter.Controls.Add(this.ckbox_noloadsample);
            this.tabP_parameter.Controls.Add(this.txtb_scantime);
            this.tabP_parameter.Controls.Add(this.txtb_step);
            this.tabP_parameter.Controls.Add(this.label4);
            this.tabP_parameter.Controls.Add(this.label5);
            this.tabP_parameter.Controls.Add(this.cbox_mask);
            this.tabP_parameter.Controls.Add(this.txtb_endangle);
            this.tabP_parameter.Controls.Add(this.txtb_startangle);
            this.tabP_parameter.Controls.Add(this.label3);
            this.tabP_parameter.Controls.Add(this.label2);
            this.tabP_parameter.Controls.Add(this.label1);
            this.tabP_parameter.Location = new System.Drawing.Point(4, 22);
            this.tabP_parameter.Name = "tabP_parameter";
            this.tabP_parameter.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_parameter.Size = new System.Drawing.Size(1065, 109);
            this.tabP_parameter.TabIndex = 0;
            this.tabP_parameter.Text = "扫描参数";
            // 
            // ckbox_noloadsample
            // 
            this.ckbox_noloadsample.AutoSize = true;
            this.ckbox_noloadsample.Location = new System.Drawing.Point(273, 77);
            this.ckbox_noloadsample.Name = "ckbox_noloadsample";
            this.ckbox_noloadsample.Size = new System.Drawing.Size(120, 16);
            this.ckbox_noloadsample.TabIndex = 10;
            this.ckbox_noloadsample.Text = "测量后不载出样品";
            this.ckbox_noloadsample.UseVisualStyleBackColor = true;
            // 
            // txtb_scantime
            // 
            this.txtb_scantime.Location = new System.Drawing.Point(360, 46);
            this.txtb_scantime.Name = "txtb_scantime";
            this.txtb_scantime.Size = new System.Drawing.Size(100, 21);
            this.txtb_scantime.TabIndex = 9;
            // 
            // txtb_step
            // 
            this.txtb_step.Location = new System.Drawing.Point(360, 15);
            this.txtb_step.Name = "txtb_step";
            this.txtb_step.Size = new System.Drawing.Size(100, 21);
            this.txtb_step.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "扫描时间(s)：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "步长：";
            // 
            // cbox_mask
            // 
            this.cbox_mask.FormattingEnabled = true;
            this.cbox_mask.Items.AddRange(new object[] {
            "5",
            "8",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35"});
            this.cbox_mask.Location = new System.Drawing.Point(117, 74);
            this.cbox_mask.Name = "cbox_mask";
            this.cbox_mask.Size = new System.Drawing.Size(100, 20);
            this.cbox_mask.TabIndex = 5;
            // 
            // txtb_endangle
            // 
            this.txtb_endangle.Location = new System.Drawing.Point(117, 46);
            this.txtb_endangle.Name = "txtb_endangle";
            this.txtb_endangle.Size = new System.Drawing.Size(100, 21);
            this.txtb_endangle.TabIndex = 4;
            // 
            // txtb_startangle
            // 
            this.txtb_startangle.Location = new System.Drawing.Point(117, 15);
            this.txtb_startangle.Name = "txtb_startangle";
            this.txtb_startangle.Size = new System.Drawing.Size(100, 21);
            this.txtb_startangle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "面罩(mm)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "终止角：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始角：";
            // 
            // tabP_bg
            // 
            this.tabP_bg.BackColor = System.Drawing.Color.Transparent;
            this.tabP_bg.Controls.Add(this.dgv_bgConff);
            this.tabP_bg.Controls.Add(this.dgv_bgPoint);
            this.tabP_bg.Controls.Add(this.label7);
            this.tabP_bg.Controls.Add(this.label6);
            this.tabP_bg.Location = new System.Drawing.Point(4, 22);
            this.tabP_bg.Name = "tabP_bg";
            this.tabP_bg.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_bg.Size = new System.Drawing.Size(1065, 109);
            this.tabP_bg.TabIndex = 1;
            this.tabP_bg.Text = "背景";
            // 
            // dgv_bgConff
            // 
            this.dgv_bgConff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bgConff.Location = new System.Drawing.Point(381, 42);
            this.dgv_bgConff.Name = "dgv_bgConff";
            this.dgv_bgConff.RowTemplate.Height = 23;
            this.dgv_bgConff.Size = new System.Drawing.Size(345, 61);
            this.dgv_bgConff.TabIndex = 6;
            // 
            // dgv_bgPoint
            // 
            this.dgv_bgPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bgPoint.Location = new System.Drawing.Point(7, 42);
            this.dgv_bgPoint.Name = "dgv_bgPoint";
            this.dgv_bgPoint.RowTemplate.Height = 23;
            this.dgv_bgPoint.Size = new System.Drawing.Size(345, 61);
            this.dgv_bgPoint.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(379, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "背景系数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "背景点：";
            // 
            // tabP_time
            // 
            this.tabP_time.BackColor = System.Drawing.Color.Transparent;
            this.tabP_time.Controls.Add(this.dgv_time);
            this.tabP_time.Controls.Add(this.txtb_sensilivity);
            this.tabP_time.Controls.Add(this.label10);
            this.tabP_time.Controls.Add(this.txtb_peakbg);
            this.tabP_time.Controls.Add(this.txtb_conc);
            this.tabP_time.Controls.Add(this.label9);
            this.tabP_time.Controls.Add(this.label8);
            this.tabP_time.Location = new System.Drawing.Point(4, 22);
            this.tabP_time.Name = "tabP_time";
            this.tabP_time.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_time.Size = new System.Drawing.Size(1065, 109);
            this.tabP_time.TabIndex = 2;
            this.tabP_time.Text = "时间";
            // 
            // dgv_time
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_time.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_time.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_time.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Abs,
            this.LLD,
            this.peak,
            this.bg1,
            this.bg2,
            this.bg3,
            this.bg4});
            this.dgv_time.Location = new System.Drawing.Point(223, 49);
            this.dgv_time.Name = "dgv_time";
            this.dgv_time.RowHeadersVisible = false;
            this.dgv_time.RowTemplate.Height = 23;
            this.dgv_time.Size = new System.Drawing.Size(463, 44);
            this.dgv_time.TabIndex = 6;
            // 
            // Abs
            // 
            this.Abs.HeaderText = "绝对误差%";
            this.Abs.Name = "Abs";
            // 
            // LLD
            // 
            this.LLD.HeaderText = "LLD(ppm)";
            this.LLD.Name = "LLD";
            this.LLD.Width = 60;
            // 
            // peak
            // 
            this.peak.HeaderText = "Peak(s)";
            this.peak.Name = "peak";
            this.peak.Width = 60;
            // 
            // bg1
            // 
            this.bg1.HeaderText = "Bg1(s)";
            this.bg1.Name = "bg1";
            this.bg1.Width = 60;
            // 
            // bg2
            // 
            this.bg2.HeaderText = "Bg2(s)";
            this.bg2.Name = "bg2";
            this.bg2.Width = 60;
            // 
            // bg3
            // 
            this.bg3.HeaderText = "Bg3(s)";
            this.bg3.Name = "bg3";
            this.bg3.Width = 60;
            // 
            // bg4
            // 
            this.bg4.HeaderText = "Bg4(s)";
            this.bg4.Name = "bg4";
            this.bg4.Width = 60;
            // 
            // txtb_sensilivity
            // 
            this.txtb_sensilivity.Location = new System.Drawing.Point(322, 22);
            this.txtb_sensilivity.Name = "txtb_sensilivity";
            this.txtb_sensilivity.Size = new System.Drawing.Size(90, 21);
            this.txtb_sensilivity.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(221, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "灵敏度(kcps,%):";
            // 
            // txtb_peakbg
            // 
            this.txtb_peakbg.Location = new System.Drawing.Point(87, 50);
            this.txtb_peakbg.Name = "txtb_peakbg";
            this.txtb_peakbg.Size = new System.Drawing.Size(90, 21);
            this.txtb_peakbg.TabIndex = 3;
            // 
            // txtb_conc
            // 
            this.txtb_conc.Location = new System.Drawing.Point(87, 22);
            this.txtb_conc.Name = "txtb_conc";
            this.txtb_conc.Size = new System.Drawing.Size(90, 21);
            this.txtb_conc.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "峰背景：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "浓度(%):";
            // 
            // tabP_overlap
            // 
            this.tabP_overlap.BackColor = System.Drawing.Color.Transparent;
            this.tabP_overlap.Controls.Add(this.btn_cancle);
            this.tabP_overlap.Controls.Add(this.btn_add);
            this.tabP_overlap.Controls.Add(this.txtb_angle);
            this.tabP_overlap.Controls.Add(this.txtb_line);
            this.tabP_overlap.Controls.Add(this.label13);
            this.tabP_overlap.Controls.Add(this.label12);
            this.tabP_overlap.Controls.Add(this.label11);
            this.tabP_overlap.Location = new System.Drawing.Point(4, 22);
            this.tabP_overlap.Name = "tabP_overlap";
            this.tabP_overlap.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_overlap.Size = new System.Drawing.Size(1065, 109);
            this.tabP_overlap.TabIndex = 3;
            this.tabP_overlap.Text = "谱峰重叠";
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(324, 76);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 6;
            this.btn_cancle.Text = "删除";
            this.btn_cancle.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(324, 42);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // txtb_angle
            // 
            this.txtb_angle.Location = new System.Drawing.Point(106, 78);
            this.txtb_angle.Name = "txtb_angle";
            this.txtb_angle.Size = new System.Drawing.Size(100, 21);
            this.txtb_angle.TabIndex = 4;
            // 
            // txtb_line
            // 
            this.txtb_line.Location = new System.Drawing.Point(106, 44);
            this.txtb_line.Name = "txtb_line";
            this.txtb_line.Size = new System.Drawing.Size(100, 21);
            this.txtb_line.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(59, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "角度：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(59, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "谱线：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "可能重叠峰：";
            // 
            // gbox_scanresult
            // 
            this.gbox_scanresult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_scanresult.Controls.Add(this.picb_overlap);
            this.gbox_scanresult.Controls.Add(this.txtb_peakposition);
            this.gbox_scanresult.Controls.Add(this.cbox_Y);
            this.gbox_scanresult.Controls.Add(this.label15);
            this.gbox_scanresult.Controls.Add(this.label14);
            this.gbox_scanresult.Location = new System.Drawing.Point(3, 170);
            this.gbox_scanresult.Name = "gbox_scanresult";
            this.gbox_scanresult.Size = new System.Drawing.Size(1079, 467);
            this.gbox_scanresult.TabIndex = 1;
            this.gbox_scanresult.TabStop = false;
            this.gbox_scanresult.Text = "扫描结果";
            // 
            // picb_overlap
            // 
            this.picb_overlap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picb_overlap.BackColor = System.Drawing.Color.White;
            this.picb_overlap.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picb_overlap.Location = new System.Drawing.Point(6, 40);
            this.picb_overlap.Name = "picb_overlap";
            this.picb_overlap.Size = new System.Drawing.Size(1067, 412);
            this.picb_overlap.TabIndex = 4;
            this.picb_overlap.TabStop = false;
            this.picb_overlap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picb_overlap_MouseClick);
            this.picb_overlap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picb_overlap_MouseMove);
            // 
            // txtb_peakposition
            // 
            this.txtb_peakposition.Location = new System.Drawing.Point(86, 13);
            this.txtb_peakposition.Name = "txtb_peakposition";
            this.txtb_peakposition.Size = new System.Drawing.Size(77, 21);
            this.txtb_peakposition.TabIndex = 3;
            // 
            // cbox_Y
            // 
            this.cbox_Y.FormattingEnabled = true;
            this.cbox_Y.Items.AddRange(new object[] {
            "平方根",
            "线性"});
            this.cbox_Y.Location = new System.Drawing.Point(210, 14);
            this.cbox_Y.Name = "cbox_Y";
            this.cbox_Y.Size = new System.Drawing.Size(121, 20);
            this.cbox_Y.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(169, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "Y-轴:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(39, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "峰位置：";
            // 
            // btn_measurement
            // 
            this.btn_measurement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_measurement.Location = new System.Drawing.Point(335, 665);
            this.btn_measurement.Name = "btn_measurement";
            this.btn_measurement.Size = new System.Drawing.Size(75, 23);
            this.btn_measurement.TabIndex = 9;
            this.btn_measurement.Text = "测量";
            this.btn_measurement.UseVisualStyleBackColor = true;
            // 
            // btn_loadsample
            // 
            this.btn_loadsample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_loadsample.Location = new System.Drawing.Point(236, 665);
            this.btn_loadsample.Name = "btn_loadsample";
            this.btn_loadsample.Size = new System.Drawing.Size(75, 23);
            this.btn_loadsample.TabIndex = 8;
            this.btn_loadsample.Text = "加载";
            this.btn_loadsample.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(133, 665);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ok.Location = new System.Drawing.Point(30, 665);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 6;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_reset.Location = new System.Drawing.Point(438, 665);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 10;
            this.btn_reset.Text = "重置";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // txtb_bgTime
            // 
            this.txtb_bgTime.Location = new System.Drawing.Point(568, 46);
            this.txtb_bgTime.Name = "txtb_bgTime";
            this.txtb_bgTime.Size = new System.Drawing.Size(100, 21);
            this.txtb_bgTime.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(479, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 12);
            this.label16.TabIndex = 11;
            this.label16.Text = "背景时间(s)：";
            // 
            // CheckAngle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 712);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_measurement);
            this.Controls.Add(this.btn_loadsample);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.gbox_scanresult);
            this.Controls.Add(this.gbox_angleparameter);
            this.Name = "CheckAngle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检查角度";
            this.Load += new System.EventHandler(this.CheckAngle_QuantitationAnalysis_Load);
            this.gbox_angleparameter.ResumeLayout(false);
            this.tabCtr_Angle.ResumeLayout(false);
            this.tabP_parameter.ResumeLayout(false);
            this.tabP_parameter.PerformLayout();
            this.tabP_bg.ResumeLayout(false);
            this.tabP_bg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bgConff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bgPoint)).EndInit();
            this.tabP_time.ResumeLayout(false);
            this.tabP_time.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_time)).EndInit();
            this.tabP_overlap.ResumeLayout(false);
            this.tabP_overlap.PerformLayout();
            this.gbox_scanresult.ResumeLayout(false);
            this.gbox_scanresult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_overlap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox_angleparameter;
        private System.Windows.Forms.TabControl tabCtr_Angle;
        private System.Windows.Forms.TabPage tabP_parameter;
        private System.Windows.Forms.TabPage tabP_bg;
        private System.Windows.Forms.TabPage tabP_time;
        private System.Windows.Forms.TabPage tabP_overlap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtb_startangle;
        private System.Windows.Forms.TextBox txtb_endangle;
        private System.Windows.Forms.TextBox txtb_scantime;
        private System.Windows.Forms.TextBox txtb_step;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbox_mask;
        private System.Windows.Forms.CheckBox ckbox_noloadsample;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtb_conc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtb_peakbg;
        private System.Windows.Forms.TextBox txtb_sensilivity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgv_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abs;
        private System.Windows.Forms.DataGridViewTextBoxColumn LLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn peak;
        private System.Windows.Forms.DataGridViewTextBoxColumn bg1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bg2;
        private System.Windows.Forms.DataGridViewTextBoxColumn bg3;
        private System.Windows.Forms.DataGridViewTextBoxColumn bg4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txtb_angle;
        private System.Windows.Forms.TextBox txtb_line;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.GroupBox gbox_scanresult;
        private System.Windows.Forms.Button btn_measurement;
        private System.Windows.Forms.Button btn_loadsample;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbox_Y;
        private System.Windows.Forms.TextBox txtb_peakposition;
        private System.Windows.Forms.PictureBox picb_overlap;
        private System.Windows.Forms.DataGridView dgv_bgPoint;
        private System.Windows.Forms.DataGridView dgv_bgConff;
        private System.Windows.Forms.TextBox txtb_bgTime;
        private System.Windows.Forms.Label label16;
    }
}