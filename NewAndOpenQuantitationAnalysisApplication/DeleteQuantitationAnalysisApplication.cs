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

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    public partial class DeleteQuantitationAnalysisApplication : Form
    {
        public DeleteQuantitationAnalysisApplication()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void DeleteQuantitationAnalysisApplication_Load(object sender, EventArgs e)
        {
            //加载 已经创建的定量分析程序 放在下拉框中
            DirectoryInfo dinfo = new DirectoryInfo(XRF_function.QuantitationApplicationPath);
            FileSystemInfo[] fsinfos = dinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)//判断是否为文件夹
                {
                    DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                    cbox_deletequantitationanalysisapplication.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo deleteinfo = new DirectoryInfo(XRF_function.QuantitationApplicationPath + "\\" + cbox_deletequantitationanalysisapplication.Text);
                deleteinfo.Delete(true);
                this.Close();
            }
            catch(SqlException ex)
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
