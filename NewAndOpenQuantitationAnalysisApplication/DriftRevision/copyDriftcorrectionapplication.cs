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
using i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision
{
    public partial class copyDriftcorrectionapplication : Form
    {
        public copyDriftcorrectionapplication()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void btn_ok_Click(object sender, EventArgs e)
        {
            //复制所选的漂移校正分析程序 到 上一级的需要新建的漂移校正程序名称中
            Form form = Application.OpenForms["CreateDriftCorrectionApplication"];
            if (form == null)
                form = new CreateDriftCorrectionApplication();
            form.Controls["txt_newdriftcorrectionapplication"].Text = this.cbox_driftcorrectionapplicationname.Text;
            form.Controls["lab_num"].Text = "1"; //传递一个值，标记该漂移校正分析程序是复制过去的 （该标签不可见）
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copyDriftcorrectionapplication_Load(object sender, EventArgs e)
        {
            //加载 已经创建的漂移校正程序 放在下拉框中
            DirectoryInfo getallinfo = new DirectoryInfo(XRF_function.DriftCorrectionApplicationPath);
            FileSystemInfo[] fsinfos = getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)//判断是否为文件夹
                {
                    DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                    cbox_driftcorrectionapplicationname.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中
                }
            }
        }
    }
}
