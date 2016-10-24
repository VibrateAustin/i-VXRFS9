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
using System.Data.SqlClient;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision
{
    public partial class DeleteDriftCorrectionApplication : Form
    {
        public DeleteDriftCorrectionApplication()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void DeleteDriftCorrectionApplication_Load(object sender, EventArgs e)
        {
            //加载 已经创建的漂移校正程序 放在下拉框中
            DirectoryInfo getallinfo = new DirectoryInfo(XRF_function.DriftCorrectionApplicationPath);
            FileSystemInfo[] fsinfos = getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)//判断是否为文件夹
                {
                    DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                    cbox_deletedriftcorrectionapplication.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo deleteinfo = new DirectoryInfo(XRF_function.DriftCorrectionApplicationPath + "\\" + cbox_deletedriftcorrectionapplication.Text);
                deleteinfo.Delete(true);
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
