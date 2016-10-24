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

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    public partial class LimitDetection_RevisionQuantitation : Form
    {
        public LimitDetection_RevisionQuantitation()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void LimitDetection_RevisionQuantitation_Load(object sender, EventArgs e)
        {
            try
            {
               
                    dgv_limitdetection.ColumnCount = 6;
                    dgv_limitdetection.Columns[0].HeaderCell.Value = "化合物名";//显示数据表抬头的别名
                    dgv_limitdetection.Columns[1].HeaderCell.Value = "最小检出限(ppm)";
                    dgv_limitdetection.Columns[2].HeaderCell.Value = "标样名";
                    dgv_limitdetection.Columns[3].HeaderCell.Value = "最大检出限(ppm)";//显示数据表抬头的别名
                    dgv_limitdetection.Columns[4].HeaderCell.Value = "标样名";
                    dgv_limitdetection.Columns[5].HeaderCell.Value = "平均检出限(ppm)";
                    dgv_limitdetection.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                
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
    }
}
