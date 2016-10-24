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
    public partial class TheoreticalCoefficient_RevisionQuantitation : Form
    {
        public TheoreticalCoefficient_RevisionQuantitation()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void TheoreticalCoefficient_RevisionQuantitation_Load(object sender, EventArgs e)
        {
            try
            {
               
                    dgv_theoreticalcoefficient.ColumnCount = 3;
                    dgv_theoreticalcoefficient.Columns[0].HeaderCell.Value = "化合物名";//显示数据表抬头的别名
                    dgv_theoreticalcoefficient.Columns[1].HeaderCell.Value = "单位";
                    dgv_theoreticalcoefficient.Columns[2].HeaderCell.Value = "含量";
                    dgv_theoreticalcoefficient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
