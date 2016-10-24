using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Text.RegularExpressions;
using i_VXRFS.SystemConfiguration;
using i_VXRFS.ApplicationProcedure;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    public partial class quantitationanalysisapplication : Form
    {
        //声明两个变量，获得定量分析程序创建名和创建时间
        public string Applicationname=string.Empty;
        public string newApplicationtime=string.Empty;
        public int isApplicationnameexist=0;
        public string newApplicationTempname ="tempFile";//出放临时文件的文件夹
        public quantitationanalysisapplication()
        {
            InitializeComponent();
            this.dgv_elementchannel.Controls.Add(comboBox1);
            comboBox1.Visible = false;
            //int index = this.dgv_elementchannel.Rows.Add();
            //声明委托
            this.dgv_elementchannel.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dgv_elementchannel_CellMouseClick);
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
        }
        public DataGridView dgv1//定义属性，将dgv名称传入其它窗口中调用
        {
           get{ return dgv_additivecompound;  }
            set { dgv_additivecompound = value;}
        }
        public DataGridView dgv2//定义属性，将dgv名称传入其它窗口中调用
        {
            get { return dgv_quantitationcompound; }
            set { dgv_quantitationcompound = value; }
        }
        public DataGridView dgv3//定义属性，将dgv名称传入其它窗口中调用
        {
            get { return dgv_elementchannel; }
            set { dgv_elementchannel = value; }
        }
        public DataGridView dgv4//定义属性，将dgv名称传入其它窗口中调用
        {
            get { return dgv_deductbg_quantitation; }
            set { dgv_deductbg_quantitation = value; }
        }

        i_VXRFS_function XRF_function=new i_VXRFS_function();//实例化公共类
        private void newquantitationanalysisapplication_Load(object sender, EventArgs e)
        {
            btn_save.Enabled = false;
           // btn_checkPHD.Enabled = false;
            //读取在该定量分析程序名文件夹文件中的数据，并显示在窗口相应的位置
            string filepath = XRF_function.QuantitationApplicationPath + "\\" + Applicationname + "\\"+Applicationname+".txt";
            FileStream openfile = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite);
            StreamReader readDataSR = new StreamReader(openfile,Encoding.Default);
            readDataSR.BaseStream.Seek(0, SeekOrigin.Begin);//文件开头
            List<string> allinfo = new List<string> { };
            int i = 0;
            allinfo.Add(readDataSR.ReadLine());
            while (allinfo[i] != null)
            {
                allinfo.Add(readDataSR.ReadLine());
                i++;
            }
            //分别获取-通用参数，条件，样品描述，添加剂化合物表，待测元素化合物表，待测元素参数表，公共背景参数表1，公共背景参数表2
            //所在数组中的索引号； 
            List<int> index = new List<int> { };
            index = SplictStr.getdataindex(allinfo); //index[]记录上述各字段在allinfo数组中的索引号

            //读取“通用参数”中的数据显示在窗口中
            string[] getgeneralstr = SplictStr.splictstr(allinfo[index[0] + 1]);
            lab_applicationname.Text = this.Applicationname;
            txt_createsoftname.Text = getgeneralstr[0];
            txt_updatesoftname.Text = getgeneralstr[2];
            txt_createtime.Text = getgeneralstr[1];
            txt_updatetime.Text = getgeneralstr[3];
            txt_createsoftname.ReadOnly = true;
            txt_updatesoftname.ReadOnly = true;
            this.txt_createtime.ReadOnly = true;
            this.txt_updatetime.ReadOnly = true;
            int txtb_rownum=2;
            string txtb_str = string.Empty;
            while (txtb_rownum<index[1])
            {
                txtb_str += allinfo[txtb_rownum]+" ";
                txtb_rownum++;
            }
            txtb_samplepreparedescribe.Text = txtb_str;
            txtb_rownum = 2;
            //读取“条件”中的数据，显示出来
            string[] getconditionstr = SplictStr.splictstr(allinfo[index[1] + 1]);
            numUD_xrfvacuumlocktime.Text = getconditionstr[0];
            cbox_medium.Text = getconditionstr[1];
            numUD_delaytime.Text = getconditionstr[2];
            cbox_mask.Text = getconditionstr[3];
            cbox_priority.Text = getconditionstr[5];
            cbox_cup.Text = getconditionstr[8];
            CheckBoxState.ifOpenCheckBox(ckbox_ifqualitation, getconditionstr[6]);
            CheckBoxState.ifOpenCheckBox(ckbox_fragilesample,getconditionstr[7]);
            string[] getconditionstr2 = SplictStr.splictstr(allinfo[index[1] + 2]);
            CheckBoxState.ifOpenCheckBox(ckbox_order, getconditionstr2[0]);
            CheckBoxState.ifOpenCheckBox(ckbox_rotation, getconditionstr2[1]);
            CheckBoxState.ifOpenCheckBox(ckbox_providereport, getconditionstr2[2]);
            CheckBoxState.ifOpenCheckBox(ckbox_checkmeasurement, getconditionstr2[3]);
            //读取“样品描述”数据显示
            string[] getSPstr = SplictStr.splictstr(allinfo[index[2] + 1]);
            cbox_samplestate.Text = getSPstr[0];
            cbox_samplesize.Text = getSPstr[1];
            cbox_sampleLOI.Text = getSPstr[2];
            txt_samplethick.Text = getSPstr[3];
            txt_samplediameter.Text = getSPstr[4];
            txt_additive.Text = getSPstr[5];
            txt_totalmass.Text = getSPstr[6];
            CheckBoxState.ifOpenCheckBox(ckbox_fixratio, getSPstr[7]);
        
            cbox_saveFilepath.Text = this.Applicationname;
            cbox_revise.Text = Applicationname;
            cbox_reviseupdate.Text = Applicationname;
            cbox_getinputdata.Text = Applicationname;

            //样品描述中的添加剂表
            dgv_additivecompound.ColumnCount = 3;
            dgv_additivecompound.ColumnHeadersVisible = true;
            dgv_additivecompound.Columns[0].HeaderCell.Value = "化合物";//显示数据表抬头的别名
            dgv_additivecompound.Columns[1].HeaderCell.Value = "化学式";
            dgv_additivecompound.Columns[2].HeaderCell.Value = "重量(g)";

            dgv_quantitationcompound.ColumnCount = 8;
            dgv_quantitationcompound.ColumnHeadersVisible = true;
            dgv_quantitationcompound.Columns[0].HeaderCell.Value = "化合物名";//显示数据表抬头的别名
            dgv_quantitationcompound.Columns[1].HeaderCell.Value = "化学式";
            dgv_quantitationcompound.Columns[2].HeaderCell.Value = "元素";
            dgv_quantitationcompound.Columns[3].HeaderCell.Value = "光源";//显示数据表抬头的别名
            dgv_quantitationcompound.Columns[4].HeaderCell.Value = "单位";
            dgv_quantitationcompound.Columns[5].HeaderCell.Value = "最小值";
            dgv_quantitationcompound.Columns[6].HeaderCell.Value = "最大值";//显示数据表抬头的别名
            dgv_quantitationcompound.Columns[7].HeaderCell.Value = "报告";

            dgv_elementchannel.ColumnCount = 22;
            dgv_elementchannel.ColumnHeadersVisible = true;
            dgv_elementchannel.Columns[0].HeaderCell.Value = "元素";//显示数据表抬头的别名
            dgv_elementchannel.Columns[1].HeaderCell.Value = "谱线";
            dgv_elementchannel.Columns[2].HeaderCell.Value = "晶体";
            dgv_elementchannel.Columns[3].HeaderCell.Value = "准直器";//显示数据表抬头的别名
            dgv_elementchannel.Columns[4].HeaderCell.Value = "探测器";
            dgv_elementchannel.Columns[5].HeaderCell.Value = "滤光片";
            dgv_elementchannel.Columns[6].HeaderCell.Value = "KV";//显示数据表抬头的别名
            dgv_elementchannel.Columns[7].HeaderCell.Value = "mA";
            dgv_elementchannel.Columns[8].HeaderCell.Value = "角度";//显示数据表抬头的别名
            dgv_elementchannel.Columns[9].HeaderCell.Value = "背景点1";
            dgv_elementchannel.Columns[10].HeaderCell.Value = "背景点2";
            dgv_elementchannel.Columns[11].HeaderCell.Value = "背景点3";//显示数据表抬头的别名
            dgv_elementchannel.Columns[12].HeaderCell.Value = "背景点4";
            dgv_elementchannel.Columns[13].HeaderCell.Value = "PHD1(底线)";
            dgv_elementchannel.Columns[14].HeaderCell.Value = "PHD1(高线)";//显示数据表抬头的别名
            dgv_elementchannel.Columns[15].HeaderCell.Value = "PHD2(底线)";
            dgv_elementchannel.Columns[16].HeaderCell.Value = "PHD2(高线)";//显示数据表抬头的别名
            dgv_elementchannel.Columns[17].HeaderCell.Value = "PHD1因子";
            dgv_elementchannel.Columns[18].HeaderCell.Value = "PHD2因子";
            dgv_elementchannel.Columns[19].HeaderCell.Value = "ACT.";//显示数据表抬头的别名
            dgv_elementchannel.Columns[20].HeaderCell.Value = "PSC.";
            dgv_elementchannel.Columns[21].HeaderCell.Value = "更新时间";

            dgv_deductbg_quantitation.ColumnCount = 10;
            dgv_deductbg_quantitation.ColumnHeadersVisible = true;
            dgv_deductbg_quantitation.Columns[0].HeaderCell.Value = "元素名";//显示数据表抬头的别名
            dgv_deductbg_quantitation.Columns[1].HeaderCell.Value = "测量时间(s)";
            dgv_deductbg_quantitation.Columns[2].HeaderCell.Value = "CSE(%)";
            dgv_deductbg_quantitation.Columns[3].HeaderCell.Value = "背景点数";
            dgv_deductbg_quantitation.Columns[4].HeaderCell.Value = "漂移校正";
            dgv_deductbg_quantitation.Columns[5].HeaderCell.Value = "背景常数(kcps)";
            dgv_deductbg_quantitation.Columns[6].HeaderCell.Value = "背景元素";
            dgv_deductbg_quantitation.Columns[7].HeaderCell.Value = "背景测量时间(s)";
            dgv_deductbg_quantitation.Columns[8].HeaderCell.Value = "背景方法";
            dgv_deductbg_quantitation.Columns[9].HeaderCell.Value = "因子";

            try
            {
                //读取的数据添加到“添加剂化合物表”DGV中
                string[] getaddtivestr = { };
                int k = 0;
                List<string[]> ReadData = new List<string[]>();
                while ((index[3] + k + 1) < index[4])
                {
                    getaddtivestr = SplictStr.splictstr(allinfo[index[3] + k + 1]);
                    ReadData.Add(getaddtivestr);
                    k++;
                    getaddtivestr = null;
                }
                if (ReadData.Count > 0)
                    SysConfig_FileSave.DListAddToDgv(dgv_additivecompound, ReadData);
                ReadData.Clear();
                //读取的数据添加到“待测元素化合物表”DGV中
                string[] getelementComstr = { };
                k = 0;
                while ((index[4] + k + 2) < index[5])
                {
                    getelementComstr = SplictStr.splictstr(allinfo[index[4] + k + 2]);
                    ReadData.Add(getelementComstr);
                    k++;
                }
                if (ReadData.Count > 0)
                    SysConfig_FileSave.DListAddToDgv(dgv_quantitationcompound, ReadData);
                ReadData.Clear();
                string[] normalizestr = SplictStr.splictstr(allinfo[index[4] + 1]);
                CheckBoxState.ifOpenCheckBox(ckbox_normalize, normalizestr[0]);
                cbox_normalize.Text = normalizestr[1];
                //读取的数据添加到“待测元素参数表”DGV中
                string[] getelementParastr = { };
                k = 0;
                while ((index[5] + k + 1) < index[6])
                {
                    getelementParastr = SplictStr.splictstr(allinfo[index[5] + k + 1]);
                    ReadData.Add(getelementParastr);
                    k++;
                }
                if (ReadData.Count > 0)
                    SysConfig_FileSave.DListAddToDgv(dgv_elementchannel, ReadData);
                ReadData.Clear();
                //读取的数据添加到“公共背景参数表1”DGV中
                string[] getbgparastr1 = { };
                k = 0;
                while ((index[6] + k + 2) < (allinfo.Count - 1) && allinfo[(index[6] + k + 2)] != " ")
                {
                    getbgparastr1 = SplictStr.splictstr(allinfo[index[6] + k + 2]);
                    ReadData.Add(getbgparastr1);
                    k++;
                }
                if (ReadData.Count > 0)
                    SysConfig_FileSave.DListAddToDgv(dgv_deductbg_quantitation, ReadData);
                ReadData.Clear();
                string[] bg_TestTimestr = SplictStr.splictstr(allinfo[index[6] + 1]);
                txt_measuremintime.Text = bg_TestTimestr[0];
                txt_measuremaxtime.Text = bg_TestTimestr[1];
                
                dgv_additivecompound.AllowUserToAddRows = false;
                dgv_deductbg_quantitation.AllowUserToAddRows = false;
                dgv_elementchannel.AllowUserToAddRows = false;
                dgv_quantitationcompound.AllowUserToAddRows = false;
                dgv_additivecompound.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_deductbg_quantitation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_quantitationcompound.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                readDataSR.Close();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string temppath = XRF_function.QuantitationApplicationTempPath + "\\" + Applicationname + "tempfile.txt";
            //跳出对话框，点击“保存”时，才执行下列代码
            MessageBoxButtons messBtn = MessageBoxButtons.YesNo;
            DialogResult dr = MessageBox.Show("确定需要对所做的修改保存吗？","是否保存",messBtn);
            if (dr == DialogResult.Yes)
            {
                //其它数据保存在临时文件中*.txt
                
                UtilityClass.CreateFile(temppath, true);
                StreamWriter savedgvDataSW = new StreamWriter(temppath, false, Encoding.Default);
                
                    //开始写入各种数据到临时文件中
                    // saveSW.WriteLine(Applicationname);
                    txt_updatetime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    savedgvDataSW.WriteLine("通用参数");
                    string generalinfo = txt_createsoftname.Text + "," + txt_createtime.Text + "," + txt_updatesoftname.Text + "," + txt_updatetime.Text;
                    savedgvDataSW.WriteLine(generalinfo);
                    savedgvDataSW.WriteLine(txtb_samplepreparedescribe.Text);
                    savedgvDataSW.WriteLine("条件");
                    string ifqualitation = string.Empty;
                    if (ckbox_ifqualitation.Checked == true)
                        ifqualitation = "1";
                    else ifqualitation = "0";
                    string iffragilesample = string.Empty;
                    if (ckbox_fragilesample.Checked == true)
                        iffragilesample = "1";
                    else iffragilesample = "0";
                    string conditioninfo1 = numUD_xrfvacuumlocktime.Text + "," + cbox_medium.Text + "," + numUD_delaytime.Text
                        + "," + cbox_mask.Text + "," + cbox_saveFilepath.Text + "," + cbox_priority.Text + "," + ifqualitation + "," + iffragilesample + "," + cbox_cup.Text;
                    savedgvDataSW.WriteLine(conditioninfo1);
                    string iforder = string.Empty;
                    if (ckbox_order.Checked == true)
                        iforder = "1";
                    else iforder = "0";
                    string ifrotation = string.Empty;
                    if (ckbox_rotation.Checked == true)
                        ifrotation = "1";
                    else ifrotation = "0";
                    string ifreport = string.Empty;
                    if (ckbox_providereport.Checked == true)
                        ifreport = "1";
                    else ifreport = "0";
                    string ifrevise = string.Empty;
                    if (ckbox_checkmeasurement.Checked == true)
                        ifrevise = "1";
                    else ifrevise = "0";
                    string conditioninfo2 = iforder + "," + ifrotation + "," + ifreport + "," + ifrevise;
                    savedgvDataSW.WriteLine(conditioninfo2);
                    savedgvDataSW.WriteLine("样品描述");
                    string iffixratio = string.Empty;
                    if (ckbox_fixratio.Checked == true)
                        iffixratio = "1";
                    else iffixratio = "0";
                    string sampledescribe = cbox_samplestate.Text + "," + cbox_samplesize.Text + "," + cbox_sampleLOI.Text + "," + txt_samplethick.Text +
                                          "," + txt_samplediameter.Text + "," + txt_additive.Text + "," + txt_totalmass.Text + "," + iffixratio;
                    savedgvDataSW.WriteLine(sampledescribe);

                    //savedgvDataSW.Flush();
                   

                //string temppath = XRF_function.QuantitationApplicationTempPath + "\\" + newApplicationname + "tempfile.txt";
               // FileStream savedgvDataToTempfile = new FileStream(temppath, FileMode.Append, FileAccess.Write);
              //  StreamWriter savedgvDataSW = new StreamWriter(savedgvDataToTempfile, Encoding.Default);
                //把DGV添加添加剂化合物表中数据保存txt
                savedgvDataSW.WriteLine("添加剂化合物表");
                List<string> saveData = new List<string>();
                SysConfig_FileSave.readDgvToListMoreRow(dgv_additivecompound, ref saveData);
                for (int i = 0; i < saveData.Count; i++)
                {
                    savedgvDataSW.WriteLine(saveData[i]);
                }
                saveData.Clear();
                //把待测“化合物”列表数据添加到*.Txt中
                savedgvDataSW.WriteLine("待测元素化合物表");
                string ifquantitationnormalize = string.Empty;
                if (ckbox_normalize.Checked == true)
                    ifquantitationnormalize = "1";
                else ifquantitationnormalize = "0";
                savedgvDataSW.WriteLine(ifquantitationnormalize + "," + cbox_normalize.Text);
                SysConfig_FileSave.readDgvToListMoreRow(dgv_quantitationcompound, ref saveData);
                for (int i = 0; i < saveData.Count; i++)
                {
                    savedgvDataSW.WriteLine(saveData[i]);
                }
                saveData.Clear();
                //把待测“化合物”列表数据添加到*.Txt中
                //最后一列时间更新
                for (int i = 0; i < dgv_elementchannel.Rows.Count; i++)
                {
                     dgv_elementchannel.Rows[i].Cells[dgv_elementchannel.Columns.Count-1].Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
                savedgvDataSW.WriteLine("待测元素参数表");
                SysConfig_FileSave.readDgvToListMoreRow(dgv_elementchannel, ref saveData);
                for (int i = 0; i < saveData.Count; i++)
                {
                    savedgvDataSW.WriteLine(saveData[i]);
                }
                saveData.Clear();
                //把“公共背景”列表1数据添加到*.Txt中
                savedgvDataSW.WriteLine("公共背景参数表1");
                savedgvDataSW.WriteLine(txt_measuremintime.Text + "," + txt_measuremaxtime.Text);
                SysConfig_FileSave.readDgvToListMoreRow(dgv_deductbg_quantitation, ref saveData);
                for (int i = 0; i < saveData.Count; i++)
                {
                    savedgvDataSW.WriteLine(saveData[i]);
                }
                saveData.Clear();
                savedgvDataSW.Flush();
               // savedgvDataToTempfile.Flush();
                savedgvDataSW.Dispose();
                savedgvDataSW.Close();
               // savedgvDataToTempfile.Dispose();
               // savedgvDataToTempfile.Close();
               
                //将临时文件移动到指定的新建定量分析程序文件夹中
                string newpath = null;
             //   string oldpath = XRF_function.QuantitationApplicationTempPath + "\\" + Applicationname + "tempfile.txt";//临时文件存放地址
                newpath = XRF_function.QuantitationApplicationPath + "\\" + Applicationname + "\\" + Applicationname + ".txt";
                if (File.Exists(newpath))
                {
                    File.Delete(newpath);
                }
                FileInfo finfo = new FileInfo(temppath);
                finfo.MoveTo(newpath); //移动到的目标文件夹中，并指定新的文件名
                this.Close();
               // MessageBox.Show("保存成功");
            }
            else
            {
                //当“保存”对话框选择“否”，不保存，执行清除dgv,临时文件
                File.Delete(temppath);
            }
            
            this.Close();
        }
       
        //每点击一次tabpage,重载一次数据保存到临时文件tempfile.txt中（覆盖原有数据）,五个数据表的数据update..最后"保存"时再剪切到*.txt文件中
        private void tabCtr_quantitationanalysisapplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            //其它数据保存在临时文件中*.txt
            string temppath = XRF_function.QuantitationApplicationTempPath + "\\"+Applicationname +"tempfile.txt";
           
            UtilityClass.CreateFile(temppath,true);
            StreamWriter saveSW = new StreamWriter(temppath,false,Encoding.Default);
            try
            {
                //开始写入各种数据到临时文件中
               // saveSW.WriteLine(Applicationname);
                saveSW.WriteLine("通用参数");
                string generalinfo = txt_createsoftname.Text + "," + txt_createtime.Text + "," + txt_updatesoftname.Text + "," + txt_updatetime.Text;
                saveSW.WriteLine(generalinfo);
                saveSW.WriteLine(txtb_samplepreparedescribe.Text);
                saveSW.WriteLine("条件");
                string ifqualitation = string.Empty;
                if (ckbox_ifqualitation.Checked == true)
                    ifqualitation = "1";
                else ifqualitation = "0";
                string iffragilesample = string.Empty;
                if (ckbox_fragilesample.Checked == true)
                    iffragilesample = "1";
                else iffragilesample = "0";
                string conditioninfo1 = numUD_xrfvacuumlocktime.Text + "," + cbox_medium.Text + "," + numUD_delaytime.Text
                    + "," + cbox_mask.Text + "," + cbox_saveFilepath.Text + "," + cbox_priority.Text + "," + ifqualitation + "," + iffragilesample + "," + cbox_cup.Text;
                saveSW.WriteLine(conditioninfo1);
                string iforder = string.Empty;
                if (ckbox_order.Checked == true)
                    iforder = "1";
                else iforder = "0";
                string ifrotation = string.Empty;
                if (ckbox_rotation.Checked == true)
                    ifrotation = "1";
                else ifrotation = "0";
                string ifreport = string.Empty;
                if (ckbox_providereport.Checked == true)
                    ifreport = "1";
                else ifreport = "0";
                string ifrevise = string.Empty;
                if (ckbox_checkmeasurement.Checked == true)
                    ifrevise = "1";
                else ifrevise = "0";
                string conditioninfo2 = iforder + "," + ifrotation + "," + ifreport + "," + ifrevise;
                saveSW.WriteLine(conditioninfo2);
                saveSW.WriteLine("样品描述");
                string iffixratio = string.Empty;
                if (ckbox_fixratio.Checked == true)
                    iffixratio = "1";
                else iffixratio = "0";
                string sampledescribe = cbox_samplestate.Text + "," + cbox_samplesize.Text + "," + cbox_sampleLOI.Text + "," + txt_samplethick.Text +
                                      "," + txt_samplediameter.Text + "," + txt_additive.Text + "," + txt_totalmass.Text + "," + iffixratio;
                saveSW.WriteLine(sampledescribe);

                saveSW.Flush();
                //saveTempfile.Flush();
                //saveSW.Dispose();
                //saveSW.Close();
                //saveTempfile.Dispose();
                //saveTempfile.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                saveSW.Close();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            string temppath = XRF_function.QuantitationApplicationTempPath + "\\" + Applicationname + "tempfile.txt";
            if(File.Exists(temppath))
                File.Delete(temppath);
            this.Close();
        }

        private void quantitationanalysisapplication_FormClosed(object sender, FormClosedEventArgs e)
        {
            string temppath = XRF_function.QuantitationApplicationTempPath + "\\" + Applicationname + "tempfile.txt";
            if (File.Exists(temppath))
                File.Delete(temppath);
        }

        private void btn_addadditive_Click(object sender, EventArgs e)
        {
            AddCompound addcompoundform = new AddCompound(this);
            addcompoundform.dgv_name = dgv_additivecompound;//将dgv名传入子窗口中
            addcompoundform.OpenOrNew = "open";
            addcompoundform.Show();
        }

        private void btn_addcompound_Click(object sender, EventArgs e)
        {
            AddCompound addcompoundform = new AddCompound(this);
            addcompoundform.dgv_name = dgv_quantitationcompound;//将dgv名传入子窗口中
            addcompoundform.OpenOrNew = "open";
            addcompoundform.Show();
        }

        private void btn_addelementchannel_Click(object sender, EventArgs e)
        {
            AddCompound addcompoundform = new AddCompound(this);
            addcompoundform.dgv_name = dgv_elementchannel;//将dgv名传入子窗口中
            addcompoundform.OpenOrNew = "open";
            addcompoundform.Show();
        }
       
        private void btn_addchannel_quantitationprogram_Click(object sender, EventArgs e)
        {
            AddCompound addcompoundform = new AddCompound(this);
            addcompoundform.dgv_name = dgv_deductbg_quantitation;//将dgv名传入子窗口中
            addcompoundform.OpenOrNew = "open";
            addcompoundform.Show();
        }

        private void btn_delchannel_quantitationprogram_Click(object sender, EventArgs e)
        {
            if (dgv_deductbg_quantitation.SelectedRows.Count != 0)
            {
                dgv_deductbg_quantitation.Rows.Remove(dgv_deductbg_quantitation.CurrentRow);
            }
            else
            {
                MessageBox.Show("请选择需要删除的行！");
            }
        }

        private void btn_deladditive_Click(object sender, EventArgs e)
        {
            if (dgv_additivecompound.SelectedRows.Count != 0)
            {
                dgv_additivecompound.Rows.Remove(dgv_additivecompound.CurrentRow);
            }
            else
            {
                MessageBox.Show("请选择需要删除的行！");
            }
        }

        private void btn_delcompound_Click(object sender, EventArgs e)
        {
            if (dgv_quantitationcompound.SelectedRows.Count != 0)
            {
                int index = dgv_quantitationcompound.CurrentRow.Index;
                for (int i = 0; i < dgv_deductbg_quantitation.RowCount; i++)
                {
                    if (dgv_quantitationcompound.Rows[index].Cells[2].Value.ToString() == dgv_deductbg_quantitation.Rows[i].Cells[0].Value.ToString())
                        dgv_deductbg_quantitation.Rows.Remove(dgv_deductbg_quantitation.Rows[i]);
                }
                for (int j = 0; j < dgv_elementchannel.RowCount; j++)
                {
                    if (dgv_elementchannel.Rows[j].Cells[0].Value.ToString() == dgv_quantitationcompound.Rows[index].Cells[2].Value.ToString())
                        dgv_elementchannel.Rows.Remove(dgv_elementchannel.Rows[j]);
                }
                dgv_quantitationcompound.Rows.Remove(dgv_quantitationcompound.CurrentRow);
            }
            else
            {
                MessageBox.Show("请选择需要删除的行！");
            }
        }

        private void btn_delelementchannel_Click(object sender, EventArgs e)
        {
            if (dgv_elementchannel.SelectedRows.Count != 0)
            {
                int index = dgv_elementchannel.CurrentRow.Index;
                for (int i = 0; i < dgv_deductbg_quantitation.RowCount; i++)
                {
                    if (dgv_elementchannel.Rows[index].Cells[0].Value.ToString() == dgv_deductbg_quantitation.Rows[i].Cells[0].Value.ToString())
                        dgv_deductbg_quantitation.Rows.Remove(dgv_deductbg_quantitation.Rows[i]);
                }
                dgv_elementchannel.Rows.Remove(dgv_elementchannel.CurrentRow);
            }
            else
            {
                MessageBox.Show("请选择需要删除的行！");
            }
        }

        private void btn_checkPHD_Click(object sender, EventArgs e)
        {
            if(dgv_elementchannel.SelectedRows.Count>0){
                CheckPHD checkPHDform = new CheckPHD(this);
                //把选定的待测元素参数传值过去
                checkPHDform.getelementparameter = XRF_function.GetDgvRowData(dgv_elementchannel);
                checkPHDform.DgvIndex = dgv_elementchannel.CurrentCell.RowIndex;
                checkPHDform.identifyStr = "open";
                checkPHDform.Show();
            }else{
                MessageBox.Show("请选择元素！");
            }
        }

        private void btn_checkangle_Click(object sender, EventArgs e)
        {
            if (dgv_elementchannel.SelectedRows.Count >0)
            {
                CheckAngle checkAngleform = new CheckAngle(this);
                //把选定的待测元素参数传值过去
                checkAngleform.getelementparameter = XRF_function.GetDgvRowData(dgv_elementchannel);
                checkAngleform.DgvIndex = dgv_elementchannel.CurrentCell.RowIndex;
                checkAngleform.identifyStr = "open";
                checkAngleform.Show();
            }
            else
            {
                MessageBox.Show("请选择元素！");
            }
        }

        private void btn_addfromperiod_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ColumnIndex = dgv_elementchannel.CurrentCell.ColumnIndex;
            int RowIndex = dgv_elementchannel.CurrentCell.RowIndex;
            if (dgv_elementchannel.CurrentCell != null)
            {
                if (ColumnIndex != 6 && ColumnIndex != 7)
                    dgv_elementchannel.CurrentCell.Value = comboBox1.Items[comboBox1.SelectedIndex];
                else if (ColumnIndex == 6)
                {
                    if (Convert.ToInt16(dgv_elementchannel.Rows[RowIndex].Cells[ColumnIndex + 1].Value) * Convert.ToInt16(comboBox1.Items[comboBox1.SelectedIndex]) > 4000)
                    {
                        dgv_elementchannel.Rows[RowIndex].Cells[ColumnIndex + 1].Value = 5 * Convert.ToInt16(4000 / (5 * Convert.ToInt16(comboBox1.Items[comboBox1.SelectedIndex])));
                    }
                    dgv_elementchannel.CurrentCell.Value = comboBox1.Items[comboBox1.SelectedIndex];
                }
                else if (ColumnIndex == 7)
                {
                    if (Convert.ToInt16(dgv_elementchannel.Rows[RowIndex].Cells[ColumnIndex - 1].Value) * Convert.ToInt16(comboBox1.Items[comboBox1.SelectedIndex]) > 4000)
                    {
                        dgv_elementchannel.Rows[RowIndex].Cells[ColumnIndex - 1].Value = 5 * Convert.ToInt16(4000 / (5 * Convert.ToInt16(comboBox1.Items[comboBox1.SelectedIndex])));
                    }
                    dgv_elementchannel.CurrentCell.Value = comboBox1.Items[comboBox1.SelectedIndex];
                }
            }
        }

        private void dgv_elementchannel_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string path = null;
            List<int> tb_str = new List<int>();
            string[] line_Style = { "KA", "KB", "LA", "LB", "LC", "M" };
            if (dgv_elementchannel.CurrentCell.ColumnIndex > 0 && dgv_elementchannel.CurrentCell.ColumnIndex < 8)
            {
                if (dgv_elementchannel.CurrentCell.ColumnIndex == 2)
                {
                    path = Public_Path.SysConfigurationParameterPath + "\\crystal.txt";
                    tb_str.Add(1);
                }
                if (dgv_elementchannel.CurrentCell.ColumnIndex == 3)
                {
                    path = Public_Path.SysConfigurationParameterPath + "\\collimator.txt";
                    tb_str.Add(1);
                }
                if (dgv_elementchannel.CurrentCell.ColumnIndex == 4)
                {
                    path = Public_Path.SysConfigurationParameterPath + "\\detector.txt";
                    tb_str.Add(1);
                }
                if (dgv_elementchannel.CurrentCell.ColumnIndex == 5)
                {
                    path = Public_Path.SysConfigurationParameterPath + "\\filter.txt";
                    tb_str.Add(1); tb_str.Add(2);
                }
                this.comboBox1.Items.Clear();
                int columnIndex = dgv_elementchannel.CurrentCell.ColumnIndex;
                int rowIndex = dgv_elementchannel.CurrentCell.RowIndex;
                Rectangle rect = dgv_elementchannel.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                comboBox1.Left = rect.Left;
                comboBox1.Top = rect.Top;
                comboBox1.Width = rect.Width;
                comboBox1.Height = rect.Height;
                //添加数据到下拉框列表中
                if (columnIndex > 1 && columnIndex < 6)
                {

                    List<string[]> Sysdata = new List<string[]>();
                    SysConfig_FileSave.ReadTxtToDList(path, ref Sysdata);
                    TxtDataUploadToDgvColumnCombobox.TxtDataToDgvColumnCombobox(comboBox1, Sysdata, tb_str);
                }
                if (columnIndex == 1)
                {
                    for (int i = 0; i < line_Style.Count(); i++)
                    {
                        comboBox1.Items.Add(line_Style[i]);
                    }
                }
                if (columnIndex == 6)
                {
                    for (int i = 20; i < 61; i += 5)
                    {
                        comboBox1.Items.Add(i);
                    }
                }
                if (columnIndex == 7)
                {
                    for (int i = 5; i < 121; i += 5)
                    {
                        comboBox1.Items.Add(i);
                    }
                }
                string consultingRoom = dgv_elementchannel.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index3 = comboBox1.Items.IndexOf(consultingRoom);
                comboBox1.SelectedIndex = index3;
                comboBox1.Visible = true;
            }
            else
            {
                comboBox1.Visible = false;
            }
        }

        
    }
}
