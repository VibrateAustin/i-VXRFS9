using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision
{
    public partial class OpenDriftCorrectionApplication : Form
    {
        public OpenDriftCorrectionApplication()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //打开 漂移校正程序参数设置界面  需要修改打开的窗口，使其打开时加载所选择的漂移校正程序名所含有的参数！！！！
            DriftCorrectionApplication driftcorrectionpplicationform = new DriftCorrectionApplication();
            //把所选的分析程序名 传值到打开分析程序窗口中
            driftcorrectionpplicationform.newDriftApplicationname = cbox_opendriftcorrectionapplication.Text;
            driftcorrectionpplicationform.isOpen = true;//传递参数说明是打开漂移校正程序
            driftcorrectionpplicationform.Show();
            this.Close();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void OpenDriftCorrectionApplication_Load(object sender, EventArgs e)
        {
            //加载 已经创建的漂移校正程序 放在下拉框中
            DirectoryInfo getallinfo = new DirectoryInfo(XRF_function.DriftCorrectionApplicationPath);
            FileSystemInfo[] fsinfos = getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)//判断是否为文件夹
                {
                    DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                    cbox_opendriftcorrectionapplication.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
