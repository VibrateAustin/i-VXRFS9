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

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision
{
    public partial class AddDriftSample : Form
    {
        public AddDriftSample()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void AddCompound_Load(object sender, EventArgs e)
        {
           
        }

        private DriftCorrectionApplication _f1;//调用父窗口(打开定量分析程序窗口)
        public AddDriftSample(DriftCorrectionApplication f1)
            : this()
        {
            this._f1 = f1;
        }
       
        private void btn_add_Click(object sender, EventArgs e)
        {
            int index = _f1.dgv3.Rows.Add();
            _f1.dgv3.Rows[index].Cells[0].Value = txtb_driftsample.Text;
            _f1.dgv3.Rows[index].Cells[1].Value = "真空";
            _f1.dgv3.Rows[index].Cells[2].Value = 25;
            _f1.dgv3.Rows[index].Cells[5].Value = "Yes";
            _f1.dgv3.Rows[index].Cells[6].Value = "Yes";
            BanColumsSort(_f1.dgv3);
            int ColIndex = 0;
            if (_f1.dgv3.Rows.Count >= 2)
            {
                if (_f1.dgv1.Rows[0].Cells[3].Value == null)
                    ColIndex = 3;
                else ColIndex = 4;
                _f1.btn1.Visible = false;
            }
            else if (_f1.dgv3.Rows.Count  == 1)
            {
                if (_f1.dgv1.Rows[0].Cells[3].Value == null)
                    ColIndex = 3;
                else if (_f1.dgv1.Rows[0].Cells[4].Value == null && _f1.dgv1.Rows[0].Cells[3].Value != null)
                    ColIndex = 4;
            }
            for (int i = 0; i < _f1.dgv1.Rows.Count; i++)
            {
                _f1.dgv1.Rows[i].Cells[ColIndex].Value = txtb_driftsample.Text;
            }
            this.Close();
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
            this.Close();
        }

       
    }
}
