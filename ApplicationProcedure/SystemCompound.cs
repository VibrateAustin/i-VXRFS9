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

namespace i_VXRFS.ApplicationProcedure
{
    public partial class SystemCompound : Form
    {
        public SystemCompound()
        {
            InitializeComponent();
        }
       
        private void SystemCompound_Load(object sender, EventArgs e)
        {
            try
            {
                //"系统化合物"中添加化合物信息表
                string savePath_oxide = Public_Path.SysConfigurationParameterPath + "\\oxide.txt";
                if (!File.Exists(savePath_oxide))
                {
                    dgv_oxide.ColumnCount = 12;
                    dgv_oxide.Columns[0].HeaderCell.Value = "化合物名";//显示数据表抬头的别名
                    dgv_oxide.Columns[1].HeaderCell.Value = "分析元素";
                    dgv_oxide.Columns[2].HeaderCell.Value = "密度";
                    dgv_oxide.Columns[3].HeaderCell.Value = "类型";//显示数据表抬头的别名
                    dgv_oxide.Columns[4].HeaderCell.Value = "元素1";
                    dgv_oxide.Columns[5].HeaderCell.Value = "数量";
                    dgv_oxide.Columns[6].HeaderCell.Value = "元素2";//显示数据表抬头的别名
                    dgv_oxide.Columns[7].HeaderCell.Value = "数量";
                    dgv_oxide.Columns[8].HeaderCell.Value = "元素3";//显示数据表抬头的别名
                    dgv_oxide.Columns[9].HeaderCell.Value = "数量";
                    dgv_oxide.Columns[10].HeaderCell.Value = "元素4";
                    dgv_oxide.Columns[11].HeaderCell.Value = "数量";//显示数据表抬头的别名

                    dgv_nonoxide.ColumnCount = 14;
                    dgv_nonoxide.Columns[0].HeaderCell.Value = "化合物名";//显示数据表抬头的别名
                    dgv_nonoxide.Columns[1].HeaderCell.Value = "分析元素";
                    dgv_nonoxide.Columns[2].HeaderCell.Value = "密度";
                    dgv_nonoxide.Columns[3].HeaderCell.Value = "类型";//显示数据表抬头的别名
                    dgv_nonoxide.Columns[4].HeaderCell.Value = "元素1";
                    dgv_nonoxide.Columns[5].HeaderCell.Value = "数量";
                    dgv_nonoxide.Columns[6].HeaderCell.Value = "元素2";//显示数据表抬头的别名
                    dgv_nonoxide.Columns[7].HeaderCell.Value = "数量";
                    dgv_nonoxide.Columns[8].HeaderCell.Value = "元素3";//显示数据表抬头的别名
                    dgv_nonoxide.Columns[9].HeaderCell.Value = "数量";
                    dgv_nonoxide.Columns[10].HeaderCell.Value = "元素4";
                    dgv_nonoxide.Columns[11].HeaderCell.Value = "数量";//显示数据表抬头的别名
                    dgv_nonoxide.Columns[12].HeaderCell.Value = "元素5";
                    dgv_nonoxide.Columns[13].HeaderCell.Value = "数量";
                }
                else
                {
                    List<string[]> data = new List<string[]>();
                    SysConfig_FileSave.ReadTxtToDList(savePath_oxide, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_oxide, data);
                    data.Clear();

                    string savePath_nonoxide = Public_Path.SysConfigurationParameterPath + "\\nonoxide.txt";
                    SysConfig_FileSave.ReadTxtToDList(savePath_nonoxide, ref data);
                    SysConfig_FileSave.DListAddToDgv(dgv_nonoxide, data);
                    data.Clear();

                }
                //取消，刚打开DGV时默认选中首行首列的单元格
                dgv_oxide.Rows[0].Selected = false;
                dgv_oxide.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                dgv_nonoxide.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> data = new List<string>();
                SysConfig_FileSave.readDgvToList(dgv_oxide, ref data);
                string savePath_oxide = Public_Path.SysConfigurationParameterPath + "\\oxide.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_oxide);
                data.Clear();
                SysConfig_FileSave.readDgvToList(dgv_nonoxide, ref data);
                string savePath_nonoxide = Public_Path.SysConfigurationParameterPath + "\\nonoxide.txt";
                SysConfig_FileSave.ListToSaveTxt(data, savePath_nonoxide);
                data.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("保存系统化合物表成功！");
                this.Close();
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            if (PageIndex == 0)
            {
                if (dgv_oxide.SelectedRows.Count > 0)
                {
                    int index = dgv_oxide.CurrentCell.RowIndex;
                    dgv_oxide.Rows.Remove(dgv_oxide.CurrentRow);
                }
            }
            else
            {
                if (dgv_nonoxide.SelectedRows.Count > 0)
                {
                    int index = dgv_nonoxide.CurrentCell.RowIndex;
                    dgv_nonoxide.Rows.Remove(dgv_nonoxide.CurrentRow);
                }
            }
            
        }

        private void tctr_systemcompound_SelectedIndexChanged(object sender, EventArgs e)
        {
            //取消，刚打开DGV时默认选中首行首列的单元格
            dgv_oxide.Rows[0].Selected = false;
            dgv_nonoxide.Rows[0].Selected = false;
        }
        public int PageIndex = 0; //识别是哪个page
        private void tctr_systemcompound_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tctr_systemcompound.TabPages.Count; i++)
            {
                if (tctr_systemcompound.GetTabRect(i).Contains(e.Location))
                {
                    if (i != 1) PageIndex = 0; else PageIndex = 1;
                }
            }
        }

        
    }
}
