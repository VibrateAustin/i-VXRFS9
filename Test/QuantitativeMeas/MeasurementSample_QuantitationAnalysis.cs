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

namespace i_VXRFS.Test.QuantitativeMeas
{
    public partial class MeasurementSample_QuantitationAnalysis : Form
    {
        public MeasurementSample_QuantitationAnalysis()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();//实例化公共类
        private void MeasurementSample_QuantitationAnalysis_Load(object sender, EventArgs e)
        {
            try
            {
                //定量分析中测量样品列表信息表
                
                    dgv_measurementsamplelist.ColumnCount = 9;
                    dgv_measurementsamplelist.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                    dgv_measurementsamplelist.Columns[1].HeaderCell.Value = "测量状态";
                    dgv_measurementsamplelist.Columns[2].HeaderCell.Value = "样品位置区";
                    dgv_measurementsamplelist.Columns[3].HeaderCell.Value = "位置所在号";//显示数据表抬头的别名
                    dgv_measurementsamplelist.Columns[4].HeaderCell.Value = "模式";
                    dgv_measurementsamplelist.Columns[5].HeaderCell.Value = "优先级";
                    dgv_measurementsamplelist.Columns[6].HeaderCell.Value = "测量次数";//显示数据表抬头的别名
                    dgv_measurementsamplelist.Columns[7].HeaderCell.Value = "分析程序名";
                    dgv_measurementsamplelist.Columns[8].HeaderCell.Value = "样品名称";
                    dgv_measurementsamplelist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_starttest_Click(object sender, EventArgs e)
        {
            //需要进行判断 是标准还是半定量分析 再显示不同的窗口
            //i_VXRFS.MeasurementForm.MeasurementForm_Std meas = new i_VXRFS.MeasurementForm.MeasurementForm_Std();
            //meas.Show();
            i_VXRFS.Test.QuantitativeMeas.MeasurementForm_NonStd meas = new i_VXRFS.Test.QuantitativeMeas.MeasurementForm_NonStd();
            meas.Show();
        }

        private void btn_starttest_list_Click(object sender, EventArgs e)
        {
            //需要进行判断 是标准还是半定量分析 再显示不同的窗口
            i_VXRFS.Test.QuantitativeMeas.MeasurementForm_Std meas = new i_VXRFS.Test.QuantitativeMeas.MeasurementForm_Std();
            meas.Show();
        }
    }
}
