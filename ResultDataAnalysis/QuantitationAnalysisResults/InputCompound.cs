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
using i_VXRFS.SystemConfiguration;
using i_VXRFS.ApplicationProcedure;


namespace i_VXRFS.ResultDataAnalysis.QuantitationAnalysisResults
{
    public partial class InputCompound : Form
    {
        public InputCompound()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void AddCompound_Load(object sender, EventArgs e)
        {
            //加载“系统化合物”列表中的数据到dgv中
            try
            {
                //"添加化合物列表"
                dgv_addcompound.ColumnCount = 2;
                dgv_addcompound.Columns[0].HeaderCell.Value = "化合物";//显示数据表抬头的别名
                dgv_addcompound.Columns[1].HeaderCell.Value = "化学式";
                dgv_addcompound.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域

                List<string[]> OxideData = new List<string[]>();
                List<string[]> NonoxideData = new List<string[]>();
                string Opath = Public_Path.SysConfigurationParameterPath + "\\oxide.txt";
                string NonOpath = Public_Path.SysConfigurationParameterPath + "\\nonoxide.txt";
                SysConfig_FileSave.ReadTxtToDList(Opath, ref OxideData);
                SysConfig_FileSave.ReadTxtToDList(NonOpath, ref NonoxideData);
                DlistDataAddToDgv(dgv_addcompound, OxideData);
                DlistDataAddToDgv(dgv_addcompound, NonoxideData);
                dgv_addcompound.AllowUserToAddRows = false;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //将从txt中读取的数据添加到dgv中
        private void DlistDataAddToDgv(DataGridView dgv, List<string[]> data)
        {
            int index = 0;
            for (int i = 1; i < data.Count; i++)
            {
                index = dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = data[i][1];
                dgv.Rows[index].Cells[1].Value = data[i][0];
            }
        }

        private EditAnalysisResults _f1;//调用父窗口(打开定量分析程序窗口)
        public InputCompound(EditAnalysisResults f1)
            : this()
        {
            this._f1 = f1;
        }
        
       // public DataGridView dgv_name;
        //public string OpenOrNew = string.Empty;
       
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (dgv_addcompound.SelectedRows.Count > 0 && dgv_addcompound.CurrentRow.Cells[0].Value.ToString()!="")
            {
                string str = dgv_addcompound.CurrentRow.Cells[1].Value.ToString();
                InsertDataToDgv(_f1.dgvP, str);
                    
            }
            else
            {
                MessageBox.Show("请选择要添加的元素！");
            }
        }
        private void InsertDataToDgv(DataGridView dgv,string str)
        {
            int index = dgv.Rows.Add();
            dgv.Rows[index].Cells[0].Value = str;
            dgv.Rows[index].Cells[2].Value = "%";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            //XRF_function.TruncateTableData("tb_addcompound");
            this.Close();
        }

        private void AddCompound_FormClosed(object sender, FormClosedEventArgs e)
        {
           // XRF_function.TruncateTableData("tb_addcompound");
        }
    }
}
