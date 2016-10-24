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
using System.Threading;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
   
    public partial class createnewquantitativeanalysis_application : Form
    {

        public createnewquantitativeanalysis_application()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void btn_copy_Click(object sender, EventArgs e)
        {
            copyquantitationanalysisapplication copyquantitationanalysisapplicationform = new copyquantitationanalysisapplication();
            copyquantitationanalysisapplicationform.Show();
        }

        // public newquantitationanalysisapplication newapplicationform = new newquantitationanalysisapplication();
        private void btn_ok_Click(object sender, EventArgs e)
        {
            //在指定的路径创建该定量分析名称的文件夹，之后所设置的参数都保存在该文件夹中
            //（如果有重名的话，需要怎么处理？如果是copy过来的，那么在最后设定完参数保存时，需要修改程序名）
            string path = XRF_function.QuantitationApplicationPath + "\\" + txt_newquantitationapplication.Text;
            if (txt_newquantitationapplication.Text == null)
                MessageBox.Show("定量分析程序名不能为空");
            else
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                //方法2：自动创建同名数据库，拷贝需要保存数据的同名数据表
                //if (txt_newquantitationapplication == null)
                //    MessageBox.Show("定量分析程序名不能为空");

                //打开新建的定量分析程序参数设置 新界面
                newquantitationanalysisapplication newquantitationanalysisapplicationform = new newquantitationanalysisapplication();
                this.Hide();
                newquantitationanalysisapplicationform.newApplicationtime = DateTime.Now.ToString("yyyy-MM-dd");//把数据传值给要显示的窗体参数中
                newquantitationanalysisapplicationform.newApplicationname = txt_newquantitationapplication.Text;//把数据传值给要显示的窗体参数中
                newquantitationanalysisapplicationform.isApplicationnameexist = Convert.ToInt32(lab_num.Text);
                newquantitationanalysisapplicationform.Show();
                //newapplicationform.newApplicationtime = DateTime.Now.ToString("yyyy-mm-dd");
                //newapplicationform.newApplicationname = txt_newquantitationapplication.Text;
                this.txt_newquantitationapplication.Text = null;
                this.Close();
            }
        }
        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createnewquantitativeanalysis_application_Load(object sender, EventArgs e)
        {
            lab_num.Text = "0";
        }
    }
}
