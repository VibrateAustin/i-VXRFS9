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

namespace i_VXRFS.ResultDataAnalysis.QuantitationAnalysisResults
{
    public partial class ChoiceQuantitationAnalysisResults : Form
    {
        public ChoiceQuantitationAnalysisResults()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void ChoiceQuantitationAnalysisResults_Load(object sender, EventArgs e)
        {
            //加载 已经创建的定量分析程序 放在下拉框中
            DirectoryInfo getallinfo = new DirectoryInfo(XRF_function.QuantitationAnalysisResultsPath);
            FileSystemInfo[] fsinfos = getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)//判断是否为文件夹
                {
                    DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                    cbox_choiceQAName.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中
                }
            }
            radiobtn_all.Checked = true;
            radiobtn_time.Checked = true;
            cbox_testmodel.Text = "一般";
           
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if ((cbox_choiceQAName.Text)!=null && cbox_choiceQAName.Text!="")
            {
                QuantitationAnalysisResults quantitationanalysisreaultsform = new QuantitationAnalysisResults();
                quantitationanalysisreaultsform.quantitationanlysisapplicationname = cbox_choiceQAName.Text;
                quantitationanalysisreaultsform.QAR_testmodel = cbox_testmodel.Text;
                if (radiobtn_time.Checked == true)  //判断结果列表按照什么排序
                    quantitationanalysisreaultsform.orderSequence = 0;  //按时间排序
                else quantitationanalysisreaultsform.orderSequence = 1;  //按样品名称排序
                if (radiobtn_timearrange.Checked == true)
                {
                    quantitationanalysisreaultsform.ShowTimeSamp = new List<string>();
                    quantitationanalysisreaultsform.ShowTimeSamp.Add(dateTimePicker1.Text.ToString());  //判断是否显示所有数据
                    quantitationanalysisreaultsform.ShowTimeSamp.Add(dateTimePicker2.Text.ToString());
                }
                quantitationanalysisreaultsform.Show();
                this.Close();
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
