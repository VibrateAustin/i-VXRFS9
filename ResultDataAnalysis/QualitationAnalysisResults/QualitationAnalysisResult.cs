using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults
{
    public partial class QualitationAnalysisResult : Form
    {
        public QualitationAnalysisResult()
        {
            InitializeComponent();
        }
        public List<String> AppInfo;
        public int checkIfFormFromAddContrastSample = 0;//判断是否从”添加对比样品“而来的
        i_VXRFS_function XRF_function = new i_VXRFS_function();//实例化公共类
        private void QualitationAnalysisResults_Load(object sender, EventArgs e)
        {
            lab_testsampletime.Text = DateTime.Today.ToShortDateString();//显示当前测试时间
            radiobtn_all.Checked = true;
              try
            {
                //加载 已经创建的分析程序 放在下拉框中
                DirectoryInfo getallinfo = new DirectoryInfo(XRF_function.QualitationApplicationPath);//定性分析结果
                FileSystemInfo[] fsinfos = getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
                foreach (FileSystemInfo fsinfo in fsinfos)
                {
                    if (fsinfo is DirectoryInfo)//判断是否为文件夹
                    {
                        DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                        cbox_qualitationanalysisname.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中(定性分析程序名)
                    }
                }
                if (checkIfFormFromAddContrastSample == 0)
                {
                    btn_ok.Visible = false;
                    btn_checkspectralLine.Visible = true;
                    btn_checkpeak.Visible = true;
                    btn_analysis.Visible = true;
                    btn_cancle.Visible = true;
                    btn_rank.Visible = true;
                }
                else
                {
                    btn_ok.Visible = true;
                    btn_checkspectralLine.Visible = false;
                    btn_checkpeak.Visible = false;
                    btn_analysis.Visible = false;
                    btn_cancle.Visible = false;
                    btn_rank.Visible = false;
                    cbox_qualitationanalysisname.Text = AppInfo[2];

                    dgv_qualitationanalysisresults.ColumnCount = 5;
                    dgv_qualitationanalysisresults.ColumnHeadersVisible = true;
                    dgv_qualitationanalysisresults.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                    dgv_qualitationanalysisresults.Columns[1].HeaderCell.Value = "样品名";
                    dgv_qualitationanalysisresults.Columns[2].HeaderCell.Value = "分析程序名";
                    dgv_qualitationanalysisresults.Columns[3].HeaderCell.Value = "测试时间";//显示数据表抬头的别名
                    dgv_qualitationanalysisresults.Columns[4].HeaderCell.Value = "数据处理时间";
                    dgv_qualitationanalysisresults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    DirectoryInfo getallinfo1 = new DirectoryInfo(XRF_function.QualitationApplicationPath + "\\" + cbox_qualitationanalysisname.Text);//定性分析程序下的定性分析样品名结果文件夹列表
                    FileSystemInfo[] fsinfos1 = getallinfo1.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
                    foreach (FileSystemInfo fsinfo in fsinfos1)
                    {
                        if (fsinfo is DirectoryInfo)//判断是否为文件夹
                        {
                            DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                            //cbox_qualitationanalysisname.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中(定性分析程序名)
                            int index = this.dgv_qualitationanalysisresults.Rows.Add();

                            dgv_qualitationanalysisresults.Rows[index].Cells[0].Value = 1;
                            dgv_qualitationanalysisresults.Rows[index].Cells[1].Value = getdinfo.Name;
                            dgv_qualitationanalysisresults.Rows[index].Cells[2].Value = cbox_qualitationanalysisname.Text;
                            dgv_qualitationanalysisresults.Rows[index].Cells[3].Value = getdinfo.CreationTime;
                            dgv_qualitationanalysisresults.Rows[index].Cells[4].Value = getdinfo.LastWriteTime;
                        }
                    }
                    //按时间排序
                    dgv_qualitationanalysisresults.Sort(dgv_qualitationanalysisresults.Columns[3], ListSortDirection.Descending);
                    checkIfFormFromAddContrastSample = 0;
                    dgv_qualitationanalysisresults.AllowUserToAddRows = false;
                }
             }
             catch (SqlException ex)
             {
                 MessageBox.Show(ex.Message);
             }
               
        }

        private void btn_checkspectralLine_Click(object sender, EventArgs e)
        {
            if (dgv_qualitationanalysisresults.SelectedRows.Count == 1)
            {
                //获得所选样品的信息
                List<string> sampleinfoQ = new List<string> { };
                sampleinfoQ = XRF_function.GetDgvRowData(dgv_qualitationanalysisresults);//获取选中行的数据信息，并传送到下一窗口

                CheckQualitationAnalysisSpectralLine checkaualitationpectralline = new CheckQualitationAnalysisSpectralLine();
                checkaualitationpectralline.SampleInfo = sampleinfoQ;
                checkaualitationpectralline.Show();
            }
            else
            {
                MessageBox.Show("请选择需要查看的样品！");
            }
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            //dgv添加列
            dgv_qualitationanalysisresults.ColumnCount = 5;
            dgv_qualitationanalysisresults.ColumnHeadersVisible = true;
            dgv_qualitationanalysisresults.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
            dgv_qualitationanalysisresults.Columns[1].HeaderCell.Value = "样品名";
            dgv_qualitationanalysisresults.Columns[2].HeaderCell.Value = "分析程序名";
            dgv_qualitationanalysisresults.Columns[3].HeaderCell.Value = "测试时间";//显示数据表抬头的别名
            dgv_qualitationanalysisresults.Columns[4].HeaderCell.Value = "数据处理时间";
            dgv_qualitationanalysisresults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_qualitationanalysisresults.Rows.Clear();
            DirectoryInfo getallinfo = new DirectoryInfo(XRF_function.QualitationApplicationPath + "\\" + cbox_qualitationanalysisname.Text);//定性分析程序下的定性分析样品名结果文件夹列表
            FileSystemInfo[] fsinfos = getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)//判断是否为文件夹
                {
                    DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                    //cbox_qualitationanalysisname.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中(定性分析程序名)

                    if (radiobtn_testday.Checked == true
                        && Convert.ToDateTime(getdinfo.CreationTime.ToString("yyyy-MM-dd")) == Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")))
                    {
                        int index = this.dgv_qualitationanalysisresults.Rows.Add();
                        dgv_qualitationanalysisresults.Rows[index].Cells[0].Value = 1;
                        dgv_qualitationanalysisresults.Rows[index].Cells[1].Value = getdinfo.Name;
                        dgv_qualitationanalysisresults.Rows[index].Cells[2].Value = cbox_qualitationanalysisname.Text;
                        dgv_qualitationanalysisresults.Rows[index].Cells[3].Value = getdinfo.CreationTime;
                        dgv_qualitationanalysisresults.Rows[index].Cells[4].Value = getdinfo.LastWriteTime;
                    }
                    else if (radiobtn_starttime.Checked == true 
                        && DateTime.Compare(Convert.ToDateTime(dtp_testtime1_qualitationresults.Value.ToString("yyyy-MM-dd")), Convert.ToDateTime(getdinfo.CreationTime.ToString("yyyy-MM-dd"))) < 0
                        && DateTime.Compare(Convert.ToDateTime(dtp_testtime2_qualitationresults.Value.ToString("yyyy-MM-dd")), Convert.ToDateTime(getdinfo.CreationTime.ToString("yyyy-MM-dd"))) > 0)
                    {
                        int index = this.dgv_qualitationanalysisresults.Rows.Add();
                        dgv_qualitationanalysisresults.Rows[index].Cells[0].Value = 1;
                        dgv_qualitationanalysisresults.Rows[index].Cells[1].Value = getdinfo.Name;
                        dgv_qualitationanalysisresults.Rows[index].Cells[2].Value = cbox_qualitationanalysisname.Text;
                        dgv_qualitationanalysisresults.Rows[index].Cells[3].Value = getdinfo.CreationTime;
                        dgv_qualitationanalysisresults.Rows[index].Cells[4].Value = getdinfo.LastWriteTime;
                    }
                    else if(radiobtn_all.Checked==true)
                    {
                        int index = this.dgv_qualitationanalysisresults.Rows.Add();
                        dgv_qualitationanalysisresults.Rows[index].Cells[0].Value = 1;
                        dgv_qualitationanalysisresults.Rows[index].Cells[1].Value = getdinfo.Name;
                        dgv_qualitationanalysisresults.Rows[index].Cells[2].Value = cbox_qualitationanalysisname.Text;
                        dgv_qualitationanalysisresults.Rows[index].Cells[3].Value = getdinfo.CreationTime;
                        dgv_qualitationanalysisresults.Rows[index].Cells[4].Value = getdinfo.LastWriteTime;
                    }
                }
            }
            //按时间排序
            dgv_qualitationanalysisresults.Sort(dgv_qualitationanalysisresults.Columns[3], ListSortDirection.Descending);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            List<string> Sinfo = new List<string> { };
            if (dgv_qualitationanalysisresults.SelectedRows.Count == 1)
            {
                //获得所选样品的信息
                Sinfo = XRF_function.GetDgvRowData(dgv_qualitationanalysisresults);
                if (Sinfo[2] == AppInfo[2] && Sinfo[1] == AppInfo[1])
                {
                    MessageBox.Show("该样品已选，请选择其它对比样品！");
                }
                else
                {
                    ContrastSpectraLine_QualitationResults.pCurrentWin.AddSampleRefreshForm(Sinfo);
                    //ContrastSpectraLine_QualitationResults constraform = new ContrastSpectraLine_QualitationResults();
                    //constraform.sampleinfo2 = Sinfo;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("请选择需要查看的样品！");
            }
        }

        
    }
}
