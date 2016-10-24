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
using i_VXRFS.ResultDataAnalysis.QuantitationAnalysisResults;

namespace i_VXRFS.ResultDataAnalysis.QuantitationAnalysisResults
{
    public partial class QuantitationAnalysisResults : Form
    {
        public QuantitationAnalysisResults()
        {
            InitializeComponent();
        }
        public int orderSequence = 0;
        public List<string> ShowTimeSamp;
        i_VXRFS_function XRF_function = new i_VXRFS_function();//实例化公共类
        public string quantitationanlysisapplicationname = string.Empty;
        public string QAR_testmodel = string.Empty;//把“检测模式”所选值传入。因为dgv中显示的数据，根据其选项，调用的数据不同
        public List<List<string>> Data = new List<List<string>>(); //读取的文件里的数据列表
        private List<string> FileName = new List<string>(); //查询到的文件名
        public string path;
        private void QuantitationAnalysisResults_Load(object sender, EventArgs e)
        {
            lab_quantitationanalysisapplicationname.Text = quantitationanlysisapplicationname;
            //lab_totalsearchnum.Text = ShowTimeSamp[0].ToString() + ShowTimeSamp[1].ToString();
            string time1 = null; string time2 = null;
             try
            {
                //定量分析结果列表
                if (QAR_testmodel == "标准")//如果“检测模式”是标准，调用“标准”数据表
                {
                    path = XRF_function.QuantitationAnalysisResultsPath + "\\" + quantitationanlysisapplicationname + "\\Standard";
                }
                else
                {
                    path = XRF_function.QuantitationAnalysisResultsPath + "\\" + quantitationanlysisapplicationname + "\\Routine";
                }
                
                //Dictionary<string, string> FileInfo = new Dictionary<string, string>();
                DirectoryInfo getallinfo = new DirectoryInfo(path);
                FileSystemInfo[] fsinfos = getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
                if (ShowTimeSamp != null)
                {
                     time1 = ShowTimeSamp[0].ToString(); time2=ShowTimeSamp[1].ToString();
                }
                //int fcount = 0;
                foreach (FileSystemInfo fsinfo in fsinfos)
                {
                    if (fsinfo is FileInfo)//判断是否为文件
                    {
                        if (time1 != null && time2 != null)
                        {
                            if (DateTime.Parse(fsinfo.CreationTime.ToShortDateString()) >= DateTime.Parse(time1) &&
                                DateTime.Parse(fsinfo.CreationTime.ToShortDateString()) <= DateTime.Parse(time2))
                            {
                                FileInfo getdinfo = new FileInfo(fsinfo.FullName);
                                FileName.Add(getdinfo.Name);//添加文件夹名到下拉框中
                               // FileName[fcount].Add(getdinfo.CreationTime.ToShortDateString());
                                //fcount++;
                                //FileInfo.Add("Name",getdinfo.Name);
                            }
                        }
                        else
                        {
                            FileInfo getdinfo = new FileInfo(fsinfo.FullName);
                            FileName.Add(getdinfo.Name);//添加文件夹名到下拉框中
                            //FileName[fcount].Add(getdinfo.CreationTime.ToShortDateString());
                            //fcount++;
                        }
                    }
                }
                //读取文件中的数据
                lab_totalsearchnum.Text = FileName.Count.ToString();
                if (FileName.Count > 0)
                {
                    //FileName中数据排序  ?
                    //FileName.Sort();
                    string FilePath = null;
                    for (int j = 0; j < FileName.Count; j++)
                    {
                        FilePath = path + "\\" + FileName[j];
                        ReadTxtToList(FilePath, ref Data);
                    }
                    ckbox_resulttype_concen.Checked = true;
                    ckbox_concentration.Checked = true;
                    ckbox_totalpercentage.Checked = true;
                    UpdateDgv();
                }
             }
             catch (SqlException ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }
        /// <summary>
        /// 读取txt文件里的数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public static void ReadTxtToList(string path, ref List<List<string>> data)
        {
            FileStream openfile = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            StreamReader readDataSR = new StreamReader(openfile, Encoding.Default);
            readDataSR.BaseStream.Seek(0, SeekOrigin.Begin);//文件开头
            List<string> allinfo = new List<string> { };
            //int i = 0;
            string[] resstr = { };
            List<string> tepdata;
            while (!readDataSR.EndOfStream)
            {
                allinfo.Add(readDataSR.ReadLine());
            }
            for (int j = 0; j < allinfo.Count(); j++)
            {
                tepdata = new List<string> { };
                resstr = allinfo[j].Split(' ', '\t', ',');
                for (int k = 0; k < resstr.Length; k++)
                {
                    tepdata.Add(resstr[k]);
                }
                data.Add(tepdata);
                // tepdata = null;
                resstr = null;
            }
            openfile.Close();
            readDataSR.Close();
        }
        /// <summary>
        /// checkBox改变时，更新数据显示
        /// </summary>
        public void UpdateDgv()
        {
            dgv_quantitationanalysisresults.Columns.Clear();
            List<CheckBox> checkCols = new List<CheckBox>();
            List<CheckBox> checkRows = new List<CheckBox>();
            checkCols.Add(ckbox_Sweight);
            checkCols.Add(ckbox_Rweight);
            checkCols.Add(ckbox_LOI);
            checkCols.Add(ckbox_normalizefactor);
            checkCols.Add(ckbox_analysisapplicationname);
            checkCols.Add(ckbox_testdate);
            checkCols.Add(ckbox_totalpercentage);
            checkCols.Add(ckbox_resulttype_concen);
            checkCols.Add(ckb_bg);
            checkRows.Add(ckbox_driftintensity);
            checkRows.Add(ckbox_driftAndBgintensity);
            checkRows.Add(ckbox_drift_bg_LoR_kcps);
            checkRows.Add(ckbox_meartime);
            checkRows.Add(ckbox_concentration);
            //添加列头
            DataGridViewTextBoxColumn ColHead = new DataGridViewTextBoxColumn();
            ColHead.HeaderText = Data[0][0];
            ColHead.SortMode = DataGridViewColumnSortMode.NotSortable; //禁止点击列头排序
            dgv_quantitationanalysisresults.Columns.Add(ColHead);
            List<int> colsIndex = new List<int>(); //需要显示哪些列数据的索引
            int ForeColsN = 1;
            colsIndex.Add(0);
            for (int cols = 0; cols < checkCols.Count-1; cols++) //最后的背景列显示比较特殊，需要分开考虑
            {
                if (checkCols[cols].Checked)
                {
                    ColHead = new DataGridViewTextBoxColumn();
                    ColHead.HeaderText = Data[0][cols+1];
                    ColHead.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgv_quantitationanalysisresults.Columns.Add(ColHead);
                    colsIndex.Add(cols+1);
                    ForeColsN++;//元素列前有多少列
                }
            }
            List<int> bgIndex =BgIndex();
            if (checkCols[8].Checked)  //显示背景数据
            {
                for (int colsN = 9; colsN < Data[0].Count; colsN++)
                {
                    ColHead = new DataGridViewTextBoxColumn();
                    ColHead.HeaderText = Data[0][colsN];
                    ColHead.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgv_quantitationanalysisresults.Columns.Add(ColHead);
                    colsIndex.Add(colsN);
                }
            }
            else
            {
                for (int colsN = 9; colsN < Data[0].Count; colsN++)
                {
                    if (!bgIndex.Contains(colsN))
                    {
                        ColHead = new DataGridViewTextBoxColumn();
                        ColHead.HeaderText = Data[0][colsN];
                        ColHead.SortMode = DataGridViewColumnSortMode.NotSortable;
                        dgv_quantitationanalysisresults.Columns.Add(ColHead);
                        colsIndex.Add(colsN);
                    }
                }
            }

            //显示行数据
            lab_totalsearchnum.Text = FileName.Count.ToString();
            List<int> rowIndex=new List<int>();  //需要显示哪些行数据的索引
            rowIndex.Add(1);
            for (int rows = 0; rows < checkRows.Count; rows++)
            {
                if (checkRows[rows].Checked)
                    rowIndex.Add(rows+2);
            }

            //显示所有数据
            for (int row = 0; row < Data.Count; row++)
            {
                if (row % 7 == 0)
                    continue;
                else if(rowIndex.Contains(row%7))
                {
                        int index = dgv_quantitationanalysisresults.Rows.Add();
                        int rowAddCell = 0;
                        for (int cols = 0; cols < Data[row].Count; cols++)
                        {
                            if (colsIndex.Contains(cols))
                            {
                                dgv_quantitationanalysisresults.Rows[index].Cells[rowAddCell].Value = Data[row][cols];
                                rowAddCell++;
                            }
                        }
                }
            }

        }
        /// <summary>
        /// 找出Data中哪些列是背景数值列
        /// </summary>
        /// <returns>返回背景列的索引值</returns>
        public List<int> BgIndex()
        {
            List<int> BgIndex = new List<int>();
            for (int i = 0; i < Data[0].Count; i++)
            {
                string HeadStr = null;
                if (Data[0][i].Length < 3)
                    continue;
                else
                {
                    HeadStr = Data[0][i].Substring(Data[0][i].Length - 3, 2);
                    if (HeadStr == "Bg")
                    {
                        BgIndex.Add(i);
                    }
                }
            }
            return BgIndex;
        }
        public void RefreshABC(List<string> filename){
            //读取文件中的数据
            lab_totalsearchnum.Text = filename.Count.ToString();
            if (filename.Count > 0)
            {
                //FileName中数据排序  ?
                //FileName.Sort();
                string FilePath = null;
                for (int j = 0; j < filename.Count; j++)
                {
                    FilePath = path + "\\" + filename[j];
                    ReadTxtToList(FilePath, ref Data);
                }
                ckbox_resulttype_concen.Checked = true;
                ckbox_concentration.Checked = true;
                ckbox_totalpercentage.Checked = true;
                UpdateDgv();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            ChoiceQuantitationAnalysisResults choicequantitationanalysisform = new ChoiceQuantitationAnalysisResults();
            choicequantitationanalysisform.Show();
        }
        public Form Odata
        {
            //set { Form = this; }
            get { return this; }
        }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_quantitationanalysisresults.SelectedRows.Count > 0 && dgv_quantitationanalysisresults.CurrentRow.Cells[0].Value.ToString()!="")
            {
                //将所选的dgv样品数据放在List表中，传给下一窗口
                List<string> sampledata = new List<string> { };
                int indexSelectedRow=0;
                //sampledata=XRF_function.GetDgvRowData(dgv_quantitationanalysisresults);
                sampledata.Add(dgv_quantitationanalysisresults.CurrentRow.Cells[0].Value.ToString());
                for (int i = 0; i < Data.Count; i++)
                {
                    if (Data[i][0] == sampledata[0])
                        indexSelectedRow = i;
                }
                List<int> bgIndex = BgIndex();
                EditAnalysisResults editanalysisresults = new EditAnalysisResults();
                editanalysisresults.Owner = this;
                editanalysisresults.samplemodel = QAR_testmodel; //模式
                editanalysisresults.analysisapplicationname = quantitationanlysisapplicationname; //定量分析程序名称
                editanalysisresults.Data = Data; //dgv中所有数据
                editanalysisresults.indexSelectedRow = indexSelectedRow; //选定行数据在Data中的行号
                editanalysisresults.bgIndex = bgIndex;  //背景数据所在列号
                editanalysisresults.FileName = FileName; //把文件名列表传递过去
                editanalysisresults.path = path; //把文件所在路径传递过去
                editanalysisresults.Show();
            }
            else
            {
                MessageBox.Show("请选择需要查看的样品！");
            }
        }

        private void ckb_bg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_Sweight_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_Rweight_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_LOI_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_normalizefactor_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_analysisapplicationname_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_testdate_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_totalpercentage_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_resulttype_concen_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_driftintensity_concen_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_driftAndBgintensity_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_drift_bg_LoR_kcps_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_meartime_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
        private void ckbox_concentration_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
    }
}
