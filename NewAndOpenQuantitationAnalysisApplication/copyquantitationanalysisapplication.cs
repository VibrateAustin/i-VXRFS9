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

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    public partial class copyquantitationanalysisapplication : Form
    {
        public copyquantitationanalysisapplication()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
       // getApplicationname GetQuantitationApplication_DirectoryName = new getApplicationname();//声明获得定量分析程序名的公共类
        private void btn_ok_Click(object sender, EventArgs e)
        {
            //复制所选的定量分析程序 到 上一级的需要新建的定量分析程序名称中
            Form form = Application.OpenForms["createnewquantitativeanalysis_application"];
            if (form == null)
                form = new createnewquantitativeanalysis_application();
            form.Controls["txt_newquantitationapplication"].Text = this.cbox_quantitationanalysisapplication.Text;
            form.Controls["lab_num"].Text = "1"; //传递一个值，标记该定量分析程序是复制过去的 （该标签不可见）
            this.Close();
        }
       
        private void copyquantitationanalysisapplication_Load(object sender, EventArgs e)
        {
            //加载 已经创建的定量分析程序 放在下拉框中
            DirectoryInfo getallinfo = new DirectoryInfo(XRF_function.QuantitationApplicationPath);
            FileSystemInfo[] fsinfos=getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)//判断是否为文件夹
                {
                    DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                    cbox_quantitationanalysisapplication.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中
                }
            }
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
