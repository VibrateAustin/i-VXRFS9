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
using System.Threading;
using System.Text.RegularExpressions;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision
{
    public partial class OpenCreatedQuantitationAnalysisApplication : Form
    {
        public OpenCreatedQuantitationAnalysisApplication()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void OpenQuantitationAnalysisApplication_Load(object sender, EventArgs e)
        {
            //加载 已经创建的定量分析程序 放在下拉框中
            DirectoryInfo getallinfo = new DirectoryInfo(XRF_function.QuantitationApplicationPath);
            FileSystemInfo[] fsinfos = getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)//判断是否为文件夹
                {
                    DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                    cbox_openquantitationanalysisapplication.Items.Add(getdinfo.Name);//添加文件夹名到下拉框中
                }
            }
        }
        private DriftCorrectionApplication dca;
        public OpenCreatedQuantitationAnalysisApplication(DriftCorrectionApplication DCA):this(){
            this.dca = DCA;
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string Elementpath = XRF_function.QuantitationApplicationPath + "\\" + cbox_openquantitationanalysisapplication.Text + "\\S_" + cbox_openquantitationanalysisapplication.Text+".txt";
            List<string> elementData = new List<string>();
            ReadTxtToList(Elementpath,ref elementData);//从读取数据的第8索引数据开始
            for(int i=8;i<elementData.Count;i++){
                int index=dca.dgv1.Rows.Add();
                dca.dgv1.Rows[index].Cells[0].Value = elementData[i];
                dca.dgv1.Rows[index].Cells[1].Value = 0.00;
                dca.dgv1.Rows[index].Cells[2].Value = 0.00;
                dca.dgv1.Rows[index].Cells[3].Value = null;
                dca.dgv1.Rows[index].Cells[4].Value = null;
                BanColumsSort(dca.dgv1);
                int index1 = dca.dgv2.Rows.Add();
                dca.dgv2.Rows[index1].Cells[0].Value = elementData[i];
                dca.dgv2.Rows[index1].Cells[5].Value = "升级";
                dca.dgv2.Rows[index1].Cells[6].Value = 0.8;
                dca.dgv2.Rows[index1].Cells[7].Value = 1.2;
                BanColumsSort(dca.dgv2);
            }
            
            this.Close();
        }
        //只读取文件的第一行数据
        public static void ReadTxtToList(string path, ref List<string> data)
        {
            FileStream openfile = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            StreamReader readDataSR = new StreamReader(openfile, Encoding.Default);
            readDataSR.BaseStream.Seek(0, SeekOrigin.Begin);//文件开头
            List<string> allinfo = new List<string> { };
            //int i = 0;
            string[] resstr = { };
                allinfo.Add(readDataSR.ReadLine());
                resstr = allinfo[0].Split(' ', '\t', ',');
                for (int k = 0; k < resstr.Length; k++)
                {
                    data.Add(resstr[k]);
                }
                resstr = null;
            openfile.Close();
            readDataSR.Close();
        }
        //禁止点击列头排序
        public void BanColumsSort(DataGridView dgv){
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
