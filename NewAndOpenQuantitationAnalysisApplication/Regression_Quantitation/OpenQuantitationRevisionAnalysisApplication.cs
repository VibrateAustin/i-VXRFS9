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

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    public partial class OpenQuantitationRevisionAnalysisApplication : Form
    {
        public OpenQuantitationRevisionAnalysisApplication()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void OpenQuantitationAnalysisApplication_Load(object sender, EventArgs e)
        {
            //加载 已经创建的定量分析程序 放在下拉框中
            DirectoryInfo getallinfo = new DirectoryInfo(XRF_function.QuantitationApplicationPath);
            FileSystemInfo[] fsinfos = getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)//判断是否为文件夹
                {
                    DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                    cbox_openquantitationanalysisapplication.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //需要判断所选择的定量分析程序名称，在打开的窗口中显示所对应的设置参数？？？？

            //打开 定量分析程序参数设置界面  需要修改打开的窗口，使其打开时加载所选择的定量分析程序名所含有的参数！！！！
            Revision_QuantitationAnalysis quantitationanalysisapplicationform = new Revision_QuantitationAnalysis();
            //把所选的分析程序名 传值到打开分析程序窗口中
            quantitationanalysisapplicationform.ApplicationName = cbox_openquantitationanalysisapplication.Text;
            quantitationanalysisapplicationform.Show();
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
