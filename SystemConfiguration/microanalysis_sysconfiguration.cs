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
    public partial class microanalysis_sysconfiguration : Form
    {
        public microanalysis_sysconfiguration()
        {
            InitializeComponent();
        }
       
        private void microanalysis_sysconfiguration_Load(object sender, EventArgs e)
        {
            dgv_scanarea.AllowUserToDeleteRows = false; //禁止删除行
            try
            {
                string savePath_scanarea = Public_Path.SysConfigurationParameterPath + "\\Micro_scanarea.txt";
                if (!File.Exists(savePath_scanarea))
                {
                    dgv_scanarea.ColumnCount = 3;
                    dgv_scanarea.Columns[1].HeaderCell.Value = "X方向最大(mm)";//显示数据表抬头的别名
                    dgv_scanarea.Columns[0].HeaderCell.Value = "束斑(um)";
                    dgv_scanarea.Columns[2].HeaderCell.Value = "Y方向最大(mm)";
                }
                else
                {
                    List<string[]> data = new List<string[]>();
                    SysConfig_FileSave.ReadTxtToDList(savePath_scanarea, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_scanarea, data);
                    data.Clear();
                }

                dgv_scanarea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
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
                List<string> data = new List<string>();
                SysConfig_FileSave.readDgvToList(dgv_scanarea, ref data);
                string savePath_scanarea = Public_Path.SysConfigurationParameterPath + "\\Micro_scanarea.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_scanarea);
                data.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("update/revise data success");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
