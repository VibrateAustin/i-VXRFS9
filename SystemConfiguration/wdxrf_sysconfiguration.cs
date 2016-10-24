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
    public partial class wdxrf_sysconfiguration : Form 
    {
        public wdxrf_sysconfiguration()
        {
            InitializeComponent();
        }
        
        i_VXRFS_function XRF_function=new i_VXRFS_function();//实例化公共类
        private void wdxrf_sysconfiguration_Load(object sender, EventArgs e)
        {
            dgv_bar.AllowUserToDeleteRows = false; //禁止删除行
            dgv_vacuum.AllowUserToDeleteRows = false;
            dgv_goniometer.AllowUserToDeleteRows = false;
            try
            {
                string path_crystal=Public_Path.SysConfigurationParameterPath +"\\crystal.txt";
                if (!File.Exists(path_crystal))
                {
                    dgv_crystal.ColumnCount = 4;
                    dgv_crystal.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                    dgv_crystal.Columns[1].HeaderCell.Value = "名称";
                    dgv_crystal.Columns[2].HeaderCell.Value = "2d(mm)";
                    dgv_crystal.Columns[3].HeaderCell.Value = "K";
                    
                    dgv_mask.ColumnCount = 2;
                    dgv_mask.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                    dgv_mask.Columns[1].HeaderCell.Value = "直径(mm)";
                   
                    dgv_filter.ColumnCount = 3;
                    dgv_filter.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                    dgv_filter.Columns[1].HeaderCell.Value = "材料";
                    dgv_filter.Columns[2].HeaderCell.Value = "厚度(um)";
                    
                    dgv_grating.ColumnCount = 2;
                    dgv_grating.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                    dgv_grating.Columns[1].HeaderCell.Value = "大小";
                    
                    dgv_detector.ColumnCount = 9;
                    dgv_detector.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                    dgv_detector.Columns[1].HeaderCell.Value = "名称";
                    dgv_detector.Columns[2].HeaderCell.Value = "最大计数率(kcps)";
                    dgv_detector.Columns[3].HeaderCell.Value = "r0";
                    dgv_detector.Columns[4].HeaderCell.Value = "v0";
                    dgv_detector.Columns[5].HeaderCell.Value = "p0";
                    dgv_detector.Columns[6].HeaderCell.Value = "k0";
                    dgv_detector.Columns[7].HeaderCell.Value = "γ";
                    dgv_detector.Columns[8].HeaderCell.Value = "η";
                    
                    dgv_collimator.ColumnCount = 2;
                    dgv_collimator.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                    dgv_collimator.Columns[1].HeaderCell.Value = "宽度(um)";
                   
                    dgv_vacuum.ColumnCount = 3;
                    dgv_vacuum.Columns[0].HeaderCell.Value = "工作压力(pa)";//显示数据表抬头的别名
                    dgv_vacuum.Columns[1].HeaderCell.Value = "报警压力(pa)";
                    dgv_vacuum.Columns[2].HeaderCell.Value = "关高压";
                   
                    dgv_goniometer.ColumnCount = 3;
                    dgv_goniometer.Columns[0].HeaderCell.Value = "名称";
                    dgv_goniometer.Columns[1].HeaderCell.Value = "起始角";//显示数据表抬头的别名
                    dgv_goniometer.Columns[2].HeaderCell.Value = "终止角";
                    
                    dgv_bar.ColumnCount = 8;
                    dgv_bar.Columns[0].HeaderCell.Value = "靶材";//显示数据表抬头的别名
                    dgv_bar.Columns[1].HeaderCell.Value = "Be窗厚度(um)";
                    dgv_bar.Columns[2].HeaderCell.Value = "最大电压(kv)";
                    dgv_bar.Columns[3].HeaderCell.Value = "最大电流(mA)";
                    dgv_bar.Columns[4].HeaderCell.Value = "最大功率(w)";
                    dgv_bar.Columns[5].HeaderCell.Value = "入射角";
                    dgv_bar.Columns[6].HeaderCell.Value = "出射角";
                    dgv_bar.Columns[7].HeaderCell.Value = "取出角";
                }
                else
                {
                    List<string[]> data = new List<string[]>();
                    string savePath_mask = Public_Path.SysConfigurationParameterPath + "\\mask.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_mask, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_mask, data);
                    data.Clear();
                    
                    string savePath_filter = Public_Path.SysConfigurationParameterPath + "\\filter.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_filter, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_filter, data);
                    data.Clear();
                    
                    string savePath_detector = Public_Path.SysConfigurationParameterPath + "\\detector.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_detector, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_detector, data);
                    data.Clear();
                    
                    string savePath_collimator = Public_Path.SysConfigurationParameterPath + "\\collimator.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_collimator, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_collimator, data);
                    data.Clear();
                   
                    string savePath_vacuum = Public_Path.SysConfigurationParameterPath + "\\vacuum.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_vacuum, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_vacuum, data);
                    data.Clear();
                    
                    string savePath_goniometer = Public_Path.SysConfigurationParameterPath + "\\goniometer.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_goniometer, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_goniometer, data);
                    data.Clear();
                    
                    string savePath_bar = Public_Path.SysConfigurationParameterPath + "\\bar.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_bar, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_bar, data);
                    data.Clear();
                   
                    string savePath_grating = Public_Path.SysConfigurationParameterPath + "\\grating.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_grating, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_grating, data);
                    data.Clear();
                    
                    string savePath_crystal = Public_Path.SysConfigurationParameterPath + "\\crystal.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_crystal, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_crystal, data);
                    data.Clear();
                }
                dgv_crystal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_mask.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_filter.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_grating.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_detector.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_collimator.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_vacuum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_goniometer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_bar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
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
                SysConfig_FileSave.readDgvToList(dgv_mask, ref data);
                string savePath_mask = Public_Path.SysConfigurationParameterPath + "\\mask.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_mask);
                data.Clear();
                SysConfig_FileSave.readDgvToList(dgv_filter, ref data);
                string savePath_filter = Public_Path.SysConfigurationParameterPath + "\\filter.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_filter);
                data.Clear();
                SysConfig_FileSave.readDgvToList(dgv_detector, ref data);
                string savePath_detector = Public_Path.SysConfigurationParameterPath + "\\detector.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_detector);
                data.Clear();
                SysConfig_FileSave.readDgvToList(dgv_collimator, ref data);
                string savePath_collimator = Public_Path.SysConfigurationParameterPath + "\\collimator.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_collimator);
                data.Clear();
                SysConfig_FileSave.readDgvToList(dgv_vacuum, ref data);
                string savePath_vacuum = Public_Path.SysConfigurationParameterPath + "\\vacuum.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_vacuum);
                data.Clear();
                SysConfig_FileSave.readDgvToList(dgv_goniometer, ref data);
                string savePath_goniometer = Public_Path.SysConfigurationParameterPath + "\\goniometer.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_goniometer);
                data.Clear();
                SysConfig_FileSave.readDgvToList(dgv_bar, ref data);
                string savePath_bar = Public_Path.SysConfigurationParameterPath + "\\bar.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_bar);
                data.Clear();
                SysConfig_FileSave.readDgvToList(dgv_grating, ref data);
                string savePath_grating = Public_Path.SysConfigurationParameterPath + "\\grating.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_grating);
                data.Clear();
                SysConfig_FileSave.readDgvToList(dgv_crystal, ref data);
                string savePath_crystal = Public_Path.SysConfigurationParameterPath + "\\crystal.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_crystal);
                data.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("update data success");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
      
    }
}
