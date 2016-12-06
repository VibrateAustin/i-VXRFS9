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

                //dgv_measurementsamplelist.ColumnCount = 9;
                //dgv_measurementsamplelist.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                //dgv_measurementsamplelist.Columns[1].HeaderCell.Value = "测量状态";
                //dgv_measurementsamplelist.Columns[2].HeaderCell.Value = "样品位置区";
                //dgv_measurementsamplelist.Columns[3].HeaderCell.Value = "位置所在号";//显示数据表抬头的别名
                //dgv_measurementsamplelist.Columns[4].HeaderCell.Value = "模式";
                //dgv_measurementsamplelist.Columns[5].HeaderCell.Value = "优先级";
                //dgv_measurementsamplelist.Columns[6].HeaderCell.Value = "测量次数";//显示数据表抬头的别名
                //dgv_measurementsamplelist.Columns[7].HeaderCell.Value = "分析程序名";
                //dgv_measurementsamplelist.Columns[8].HeaderCell.Value = "样品名称";
                //dgv_measurementsamplelist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域

                //显示已经存在的测量列表，数据来源于GlobalVariables静态类
                if (GlobalVariables.measure_list.Columns.Count == 0)
                {
                    GlobalVariables.measure_list.Columns.Add("序号");
                    GlobalVariables.measure_list.Columns.Add("测量状态");
                    GlobalVariables.measure_list.Columns.Add("样品位置区");
                    GlobalVariables.measure_list.Columns.Add("样品所在号");
                    GlobalVariables.measure_list.Columns.Add("模式");
                    GlobalVariables.measure_list.Columns.Add("优先级");
                    GlobalVariables.measure_list.Columns.Add("测量次数");
                    GlobalVariables.measure_list.Columns.Add("分析程序名");
                    GlobalVariables.measure_list.Columns.Add("样品名称");
                }
                dgv_measurementsamplelist.DataSource = GlobalVariables.measure_list;
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

        private void btn_add_addsample_Click(object sender, EventArgs e)
        {
            //验证需要输入的值是否为空
            if (string.IsNullOrWhiteSpace(cbox_samplepositionarea.Text)||string.IsNullOrWhiteSpace(cbox_samplepositionnum.Text))
            {
                MessageBox.Show("请选择样品位置", "错误", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrWhiteSpace(cbox_analysisapplicationname.Text))
            {
                MessageBox.Show("请选择分析程序", "错误", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_samplename_addsample.Text))
            {
                MessageBox.Show("请输入样品名称", "错误", MessageBoxButtons.OK);
                return;
            }
            if (numUD_repeattime.Value<1)
            {
                MessageBox.Show("重复次数必须大于1", "错误", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrWhiteSpace(cbox_filesaveposition.Text))
            {
                MessageBox.Show("请选择文件存储路径", "错误", MessageBoxButtons.OK);
                return;
            }
            
            DataRow r = GlobalVariables.measure_list.NewRow();
            r["序号"] = GlobalVariables.measure_list.Rows.Count + 1;
            r["测量状态"] = "未测量";
            r["样品位置区"] = cbox_samplepositionarea.Text;
            r["样品所在号"] = cbox_samplepositionnum.Text;
            r["模式"] = cbox_addsample_model.Text;
            r["优先级"] = cbox_priority.Text;
            r["测量次数"] = numUD_repeattime.Value;
            r["分析程序名"] = cbox_analysisapplicationname.Text;
            r["样品名称"] = txt_samplename_addsample.Text;
            GlobalVariables.measure_list.Rows.Add(r);
        }

        private void btn_clearlist_Click(object sender, EventArgs e)
        {
            GlobalVariables.measure_list.Rows.Clear();
        }

        private void btn_deleteonelist_Click(object sender, EventArgs e)
        {
            //暂时不支持删除多行
            if (dgv_measurementsamplelist.SelectedRows.Count==1)
            {
                int index = dgv_measurementsamplelist.Rows.IndexOf(dgv_measurementsamplelist.CurrentRow);
                GlobalVariables.measure_list.Rows.RemoveAt(index);
                for (int i = index; i < GlobalVariables.measure_list.Rows.Count; i++)
                {
                    GlobalVariables.measure_list.Rows[i]["序号"] = i + 1;
                }
            }
            else
            {
                MessageBox.Show("未选中行", "错误", MessageBoxButtons.OK);
            }
        }

        private void btn_moveup_Click(object sender, EventArgs e)
        {
            //暂时不支持移动多行
            if (dgv_measurementsamplelist.SelectedRows.Count == 1)
            {
                int index = dgv_measurementsamplelist.Rows.IndexOf(dgv_measurementsamplelist.CurrentRow);
                if (index == 0)
                    return;
                DataRow t = GlobalVariables.measure_list.NewRow();
                t.ItemArray = GlobalVariables.measure_list.Rows[index].ItemArray;
                GlobalVariables.measure_list.Rows[index].ItemArray = GlobalVariables.measure_list.Rows[index - 1].ItemArray;
                GlobalVariables.measure_list.Rows[index - 1].ItemArray = t.ItemArray;
                GlobalVariables.measure_list.Rows[index]["序号"] = index + 1;
                GlobalVariables.measure_list.Rows[index - 1]["序号"] = index;
            }
            else
            {
                MessageBox.Show("未选中行", "错误", MessageBoxButtons.OK);
            }
        }

        private void btn_movedown_Click(object sender, EventArgs e)
        {
            //暂时不支持移动多行
            if (dgv_measurementsamplelist.SelectedRows.Count==1)
            {
                int index = dgv_measurementsamplelist.Rows.IndexOf(dgv_measurementsamplelist.CurrentRow);
                if (index == GlobalVariables.measure_list.Rows.Count)
                    return;
                DataRow t = GlobalVariables.measure_list.NewRow();
                t.ItemArray = GlobalVariables.measure_list.Rows[index].ItemArray;
                GlobalVariables.measure_list.Rows[index].ItemArray = GlobalVariables.measure_list.Rows[index + 1].ItemArray;
                GlobalVariables.measure_list.Rows[index + 1].ItemArray = t.ItemArray;
                GlobalVariables.measure_list.Rows[index]["序号"] = index + 1;
                GlobalVariables.measure_list.Rows[index + 1]["序号"] = index + 2;
            }
            else
            {
                MessageBox.Show("未选中行", "错误", MessageBoxButtons.OK);
            }
        }
    }
}
