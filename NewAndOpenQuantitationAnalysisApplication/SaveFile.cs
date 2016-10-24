using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    public partial class SaveFile : Form
    {
        //文件保存路径全局变量，路径最后不要带 "\"

        public string SAVEFILE_PATH = Public_Path.QuantitationApplicationPath;

        public saveFile inv;

        public SaveFile(saveFile inv)
        {
            this.inv = inv;
            InitializeComponent();
        }
        
        //取消
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //确认，将选中的文件返回
        private void confirm_Click(object sender, EventArgs e)
        {
            if (nameBox.Text.Length > 0)
            {
                inv(SAVEFILE_PATH + "\\" + nameBox.Text + "\\S_" + nameBox.Text + ".db");
            }
            this.Close();
        }

    }
}
