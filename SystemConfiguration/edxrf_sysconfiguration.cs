using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using i_VXRFS.ApplicationProcedure;

namespace i_VXRFS.SystemConfiguration
{
    public partial class edxrf_sysconfiguration : Form
    {
        public edxrf_sysconfiguration()
        {
            InitializeComponent();
        }
        
        i_VXRFS_function XRF_function = new i_VXRFS_function();//实例化公共类
        private void edxrf_sysconfiguration_Load(object sender, EventArgs e)
        {
            dgv_detector.AllowUserToDeleteRows = false; //禁止删除行
            dgv_monochromator.AllowUserToDeleteRows = false;
            try
            {
                string Ed_detectorPath = Public_Path.SysConfigurationParameterPath + "\\Ed_detector.txt";
                if (!File.Exists(Ed_detectorPath))
                {
                    dgv_detector.ColumnCount = 3;
                    dgv_detector.Columns[1].HeaderCell.Value = "有效面积(mm2)";//显示数据表抬头的别名
                    dgv_detector.Columns[0].HeaderCell.Value = "名称";
                    dgv_detector.Columns[2].HeaderCell.Value = "最大计数率(kcps)";

                    dgv_monochromator.ColumnCount = 3;
                    dgv_monochromator.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                    dgv_monochromator.Columns[1].HeaderCell.Value = "名称";
                    dgv_monochromator.Columns[2].HeaderCell.Value = "波长(mm)";

                    cbox_multiprogramnumber.SelectedIndex = 0;
                }
                else
                {
                    List<string[]> data = new List<string[]>();
                    string savePath_multiprogramnumber = Public_Path.SysConfigurationParameterPath + "\\Ed_multiprogramnumber.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_multiprogramnumber, ref data);
                    cbox_multiprogramnumber.Text = data[0][0];
                    data.Clear();

                    string savePath_monochromator = Public_Path.SysConfigurationParameterPath + "\\Ed_monochromator.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_monochromator, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_monochromator, data);
                    data.Clear();

                    string savePath_detector = Public_Path.SysConfigurationParameterPath + "\\Ed_detector.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_detector, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_detector, data);
                    data.Clear();
                }
                dgv_detector.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_monochromator.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //把数据保存到系统配置文件

                List<string> data = new List<string>();
                SysConfig_FileSave.readDgvToList(dgv_detector, ref data);
                string savePath_detector = Public_Path.SysConfigurationParameterPath + "\\Ed_detector.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_detector);
                data.Clear();
                SysConfig_FileSave.readDgvToList(dgv_monochromator, ref data);
                string savePath_monochromator = Public_Path.SysConfigurationParameterPath + "\\Ed_monochromator.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_monochromator);
                data.Clear();
                string strData = cbox_multiprogramnumber.Text.ToString();
                data.Add(strData);
                string savePath_multiprogramnumber = Public_Path.SysConfigurationParameterPath + "\\Ed_multiprogramnumber.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_multiprogramnumber);
                data.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("update data success");
                this.Close();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
