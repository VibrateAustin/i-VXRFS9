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
using i_VXRFS.NewAndOpenQuantitationAnalysisApplication;
using i_VXRFS.SystemConfiguration;
using i_VXRFS.ApplicationProcedure;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision
{
    public partial class AddDriftCompound : Form
    {
        public AddDriftCompound()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void AddCompound_Load(object sender, EventArgs e)
        {
            //加载“系统化合物”列表中的数据到dgv中
            try
            {
               
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

        private DriftCorrectionApplication _f1;//调用父窗口(打开定量分析程序窗口)
        public AddDriftCompound(DriftCorrectionApplication f1)
            : this()
        {
            this._f1 = f1;
        }

        public DataGridView dgv_name;
        public string OpenOrNew = string.Empty;
       // private NewAndOpenQuantitationAnalysisApplication.newquantitationanalysisapplication newquantitationanalysisapplication;
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (dgv_addcompound.SelectedRows != null)
            {
                int index = _f1.dgv1.Rows.Add();
                _f1.dgv1.Rows[index].Cells[0].Value = dgv_addcompound.CurrentRow.Cells[1].Value;
                _f1.dgv1.Rows[index].Cells[1].Value = 0.00;
                _f1.dgv1.Rows[index].Cells[2].Value = 0.00;
                _f1.dgv1.Rows[index].Cells[3].Value = null;
                _f1.dgv1.Rows[index].Cells[4].Value = null;
                BanColumsSort(_f1.dgv1);
                int index1 = _f1.dgv2.Rows.Add();
                _f1.dgv2.Rows[index1].Cells[0].Value =dgv_addcompound.CurrentRow.Cells[1].Value;
                _f1.dgv2.Rows[index1].Cells[5].Value = "升级";
                _f1.dgv2.Rows[index1].Cells[6].Value = 0.8;
                _f1.dgv2.Rows[index1].Cells[7].Value = 1.2;
                BanColumsSort(_f1.dgv2);
            }
            else
            {
                MessageBox.Show("请选择要添加的元素！");
            }
        }
        //禁止点击列头排序
        public void BanColumsSort(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            //XRF_function.TruncateTableData("tb_addcompound");
            this.Close();
        }

        private void AddCompound_FormClosed(object sender, FormClosedEventArgs e)
        {
            //XRF_function.TruncateTableData("tb_addcompound");
        }
    }
}
