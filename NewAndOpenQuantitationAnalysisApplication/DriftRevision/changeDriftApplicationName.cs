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
    public partial class changeDriftApplicationName : Form
    {
        public string changename;
        public changeDriftApplicationName()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void changeApplicationName_Load(object sender, EventArgs e)
        {
            lab_changename.Text = ("'"+changename +"'"+ "漂移校正程序名已存在，请修改!");
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string oldpath = XRF_function.QuantitationApplicationTempPath + "\\" + changename + "_temp.txt";//临时文件存放地址
            string newdpath = XRF_function.DriftCorrectionApplicationPath + "\\" + txt_changename.Text;
            DirectoryInfo dinfo = new DirectoryInfo(newdpath);
            if (dinfo.Exists)
                MessageBox.Show("该漂移校正程序名已存在，请重新命名！");
            else
            {
                dinfo.Create();
                string newfpath = newdpath + "\\" + txt_changename.Text + ".txt";
                File.Move(oldpath, newfpath);
                this.Close();
            }
        }
    }
}
