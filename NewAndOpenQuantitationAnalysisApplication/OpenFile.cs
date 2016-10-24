using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    public partial class OpenFile : Form
    {
        
        //文件保存路径全局变量，路径最后不要带 "\"
        public string OPENFILE_PATH = Public_Path.SysStandardSampleLibraryPath;
        
        public openFile inv;

        public OpenFile(openFile inv)
        {
            this.inv = inv;
            InitializeComponent();
        }

        //载入路径下所有需要的文件
        private void OpenFile_Load(object sender, EventArgs e)
        {
            foreach (string name in Directory.GetFiles(OPENFILE_PATH, "*.db"))
            {
                string[] str = name.Split('\\');
                fileBox.Items.Add(str[str.Length - 1].Replace(".db", ""));
            }
        }

        //取消
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //确认，将选中的文件返回
        private void confirm_Click(object sender, EventArgs e)
        {
            if (fileBox.Text.Length > 0)
            {
                inv(OPENFILE_PATH + "\\" + fileBox.Text + ".db");
            }
            else
            {
                inv(OPENFILE_PATH + "\\tmp.db");
                
            }
            this.Close();
        }
    }
}
