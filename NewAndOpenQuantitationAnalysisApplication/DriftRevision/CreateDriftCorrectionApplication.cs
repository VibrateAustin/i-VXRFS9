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
    public partial class CreateDriftCorrectionApplication : Form
    {
        public CreateDriftCorrectionApplication()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void btn_copy_Click(object sender, EventArgs e)
        {
            copyDriftcorrectionapplication copyDriftcorrectionapplicationform = new copyDriftcorrectionapplication();
            copyDriftcorrectionapplicationform.Show();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //在指定的路径创建该漂移校正名称的文件夹，之后所设置的参数都保存在该文件夹中
            //（如果有重名的话，需要怎么处理？如果是copy过来的，那么在最后设定完参数保存时，需要修改程序名）

            string path =XRF_function.DriftCorrectionApplicationPath + "\\" + txt_newdriftcorrectionapplication.Text;
            if (txt_newdriftcorrectionapplication == null)
                MessageBox.Show("漂移校正程序名不能为空");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //打开新建的漂移校正程序参数设置 新界面
            DriftCorrectionApplication driftcorrectionapplicationform = new DriftCorrectionApplication();
            this.Hide();
            driftcorrectionapplicationform.newDriftApplicationtime = DateTime.Now.ToString("yyyy-MM-dd");//把数据传值给要显示的窗体参数中
            driftcorrectionapplicationform.newDriftApplicationname = txt_newdriftcorrectionapplication.Text;//把数据传值给要显示的窗体参数中
            driftcorrectionapplicationform.isDriftApplicationnameexist = Convert.ToInt32(lab_num.Text);//标记该分析程序是复制过去的
            driftcorrectionapplicationform.Show();
            this.Close();
        }

        private void ChoiceDriftCorrectionApplication_Load(object sender, EventArgs e)
        {
            lab_num.Text = "0";
        }
    }
}
