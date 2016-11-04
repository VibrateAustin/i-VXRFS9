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

        private void btn_checkpeak_Click(object sender, EventArgs e)
        {
            if (dgv_qualitationanalysisresults.SelectedRows.Count == 1)
            {
                //获得所选样品的信息
                List<string> sampleinfoQ = new List<string> { };
                sampleinfoQ = XRF_function.GetDgvRowData(dgv_qualitationanalysisresults);//获取选中行的数据信息，并传送到下一窗口

                CheckQualitationAnalysisPeak checkPeak = new CheckQualitationAnalysisPeak();
                checkPeak.SampleInfo = sampleinfoQ;
                checkPeak.Show();
            }
            else
            {
                MessageBox.Show("请选择需要查看的样品！");
            }

        }

        public class Sample
        {
            private string test_program;
            private string sample_name;
            private DirectoryInfo sample_directory;
            //构造函数
            public Sample(string name, string program)
            {
                sample_name = name;
                test_program = program;
                sample_directory = new DirectoryInfo(Public_Path.QualitationApplicationPath + "\\" + program + "\\" + name);
            }
            //属性1：样品名称
            public string SampleName
            {
                get { return sample_name; }
            }
            //属性2：用来测试样品的程序
            public string TestProgram
            {
                get { return test_program; }
            }
            //属性3：测试结果所存放的文件夹
            public DirectoryInfo SampleDirectory
            {
                get { return sample_directory; }
            }

            //方法1：获取峰强数据
            //private Dictionary<int, List<List<string>>> GetIntensityData()
            //{
            //    Dictionary<int, List<List<string>>> IntensityData = null;
            //    for (int i = 0; i < 11; i++)
            //    {
            //        List<List<string>> intensity_list = null;
            //        string[] intensity_str = File.ReadAllLines(sample_directory.FullName + "\\" + i);
            //        for (int j = 0; j < intensity_str.Length - 1; j++)
            //        {
            //            string[] intensity_row = intensity_str[j + 1].Split('\t');
            //            for (int k = 0; k < 10; k++)
            //            {
            //                intensity_list[j][k] = intensity_row[k];
            //            }
            //        }
            //        IntensityData.Add(i, intensity_list);
            //    }
            //    return IntensityData;
            //}
            //方法1：获取峰强数据
            public Dictionary<int,List<string>> GetIntensity()
            {
                Dictionary<int, List<string>> intensity = new Dictionary<int, List<string>>();
                char[] charSeparators = new char[] { ',', '\t', '\n', '\r' };
                for (int i=0;i<11;i++)
                {
                    List<string> points = new List<string>();
                    string[] points_str = File.ReadAllLines(sample_directory.FullName + "\\" + i);
                    for (int j=1;j<points_str.Length;j++)
                    {
                        string[] rowdata = points_str[j].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                        points.AddRange(rowdata);
                    }
                    intensity.Add(i + 1, points);
                }
                return intensity;
            }
            //方法2：获取峰位数据
            //private Dictionary<int, Dictionary<int, List<string>>> GetSiteData()
            //{
            //    Dictionary<int, Dictionary<int, List<string>>> SiteData = null;
            //    for (int i = 0; i < 11; i++)
            //    {
            //        Dictionary<int, List<string>> site_data = null;
            //        string[] site_str = File.ReadAllLines(sample_directory.FullName + "\\peak\\" + i);
            //        for (int j = 0; j < site_str.Length; j++)
            //        {
            //            string[] site = site_str[j + 1].Split('\t');
            //            List<string> site_ = null;
            //            for (int k = 0; k < site.Length; k++)
            //            {
            //                site_[k] = site[k];
            //            }
            //            site_data.Add(j + 1, site_);
            //        }
            //        SiteData.Add(i + 1, site_data);
            //    }
            //    return SiteData;
            //}
            //方法2：获取峰位数据
            public Dictionary<int, List<PeakSite>> GetSite()
            {
                Dictionary<int, List<PeakSite>> site = new Dictionary<int, List<PeakSite>>();
                char[] charSeparators = new char[] { ',', '\t', '\n', '\r' };
                for (int i=0;i<11;i++)
                {
                    List<PeakSite> peaks = new List<PeakSite>();  //每一个区段的峰位数据
                    string[] peaks_str = File.ReadAllLines(sample_directory.FullName + "\\peak\\" + i);
                    for (int j=0;j<peaks_str.Length;j++)
                    {
                        string[] peak = peaks_str[j + 1].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                        peaks.Add(new PeakSite(peak));
                    }
                    site.Add(i + 1, peaks);
                }
                return site;
            }
            //方法3：获取参数数据
            private Dictionary<int, List<string>> GetParameterData()
            {
                Dictionary<int, List<string>> ParameterData = null;
                string[] parameters = File.ReadAllLines(sample_directory.FullName + "\\" + sample_name);
                for (int i = 0; i < parameters.Length - 1; i++)
                {
                    List<string> parameters_list = null;
                    string[] parameters_str = null;
                    for (int j = 0; j < 10; j++)
                    {
                        parameters_list[j] = parameters_str[j];
                    }
                    ParameterData.Add(i + 1, parameters_list);
                }
                return ParameterData;
            }
            //方法4：获取所有数据点
            private List<List<string>> GetAllPoint()
            {
                List<List<string>> AllPoint = null;
                return AllPoint;
            }
        }
    }

    public struct PeakSite
    {
        //构造函数1:使用从txt文件中读取的字符串初始化
        public PeakSite(string[] peak)
        {
            if (peak.Length<7)
            {
                this.Energy = 0;
                this.TwoTheta = 0;
                this.Width = 0;
                this.Intensity = 0;
                this.Background = 0;
                this.SNR = 0;
                this.Match = null;
                return;
            }
            this.Energy = Convert.ToDouble(peak[0]);
            this.TwoTheta = Convert.ToDouble(peak[1]);
            this.Width = Convert.ToDouble(peak[2]);
            this.Intensity = Convert.ToDouble(peak[3]);
            this.Background = Convert.ToDouble(peak[4]);
            this.SNR = Convert.ToDouble(peak[5]);
            this.Match = null;
            Array.Copy(peak, 6, Match, 0, 0);
        }
        //属性1：峰所在位置的能量
        public double Energy
        {
            get;
            set;
        }
        //属性2：峰所在位置的2theta角
        public double TwoTheta
        {
            get;
            set;
        }
        //属性3：峰宽
        public double Width
        {
            get;
            set;
        }
        //属性4：峰强
        public double Intensity
        {
            get;
            set;
        }
        //属性5：背景峰强
        public double Background
        {
            get;
            set;
        }
        //属性6：信噪比
        public double SNR
        {
            get;
            set;
        }
        //属性7：匹配出的峰名称
        public string[] Match
        {
            get;
            set;
        }
    }
}
