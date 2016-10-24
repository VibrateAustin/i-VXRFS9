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
using i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    public partial class Revision_QuantitationAnalysis : Form
    {
        public Revision_QuantitationAnalysis()
        {
            InitializeComponent();
            this.dgv_regressionresult.Controls.Add(comboBox1);
            comboBox1.Visible = false;
            //int index = this.dgv_elementchannel.Rows.Add();
            //声明委托
            this.dgv_regressionresult.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dgv_regressionresult_CellMouseClick);
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
        }

        private void dgv_regressionresult_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            string[] method = {"Classic","FP"};
            string[] method_func = { "C=D+E.R.M", "C=(D+E.R).M", "C=D+E.R+F.R.R" };
            if (dgv_regressionresult.CurrentCell.ColumnIndex > 25 && dgv_regressionresult.CurrentCell.ColumnIndex < 28)
            {
                
                this.comboBox1.Items.Clear();
                int columnIndex = dgv_regressionresult.CurrentCell.ColumnIndex;
                int rowIndex = dgv_regressionresult.CurrentCell.RowIndex;
                Rectangle rect = dgv_regressionresult.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                comboBox1.Left = rect.Left;
                comboBox1.Top = rect.Top;
                comboBox1.Width = rect.Width;
                comboBox1.Height = rect.Height;
                //添加数据到下拉框列表中
                if (columnIndex == 26)
                {
                    for (int i = 0; i < method.Count(); i++)
                    {
                        comboBox1.Items.Add(method[i]);
                    }
                }
                if (columnIndex == 27)
                {
                    for (int i = 0; i < method_func.Count(); i++)
                    {
                        comboBox1.Items.Add(method_func[i]);
                    }
                }
                string consultingRoom = dgv_regressionresult.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                //comboBox1.Items.Add(consultingRoom);
                int index3 = comboBox1.Items.IndexOf(consultingRoom);
                comboBox1.SelectedIndex = index3;
                comboBox1.Visible = true;
            }
            else
            {
                comboBox1.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgv_regressionresult.CurrentCell != null)
            {
                dgv_regressionresult.CurrentCell.Value = comboBox1.Items[comboBox1.SelectedIndex];
            }
        }
        public string ApplicationName;
        public List<List<string>> LineParamData = new List<List<string>>();
        i_VXRFS_function XRF_function = new i_VXRFS_function();//实例化公共类
        /// <summary>
        /// 将列表中数据插入到dgv中
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="data"></param>
        public void ListDataInsertToDgv(DataGridView dgv, List<List<string>> data)
        {
            int index;
            for (int i = 1; i < data.Count; i++)
            {
                index = dgv.Rows.Add();
                for (int j = 0; j < data[i].Count; j++)
                {
                    dgv.Rows[index].Cells[j].Value = data[i][j];
                }
            }
        }
        public string LineParam_path = null;
        private void Revision_QuantitationAnalysis_Load(object sender, EventArgs e)
        {
            try
            {
                LineParam_path = XRF_function.QuantitationApplicationPath + "\\" + ApplicationName + "\\ReLineParam_" + ApplicationName + ".txt";
                Class_QualitationSpectraLine.ReadTxtToList(LineParam_path, ref LineParamData);
                
                    dgv_regressionresult.ColumnCount = 29;
                    dgv_regressionresult.ColumnHeadersVisible = true;
                    dgv_regressionresult.Columns[0].HeaderCell.Value = "化合物名";
                    dgv_regressionresult.Columns[1].HeaderCell.Value = "单位";
                    dgv_regressionresult.Columns[2].HeaderCell.Value = "元素";
                    dgv_regressionresult.Columns[3].HeaderCell.Value = "D1";
                    dgv_regressionresult.Columns[4].HeaderCell.Value = "E1";
                    dgv_regressionresult.Columns[5].HeaderCell.Value = "F1";
                    dgv_regressionresult.Columns[6].HeaderCell.Value = "RMS1";
                    dgv_regressionresult.Columns[7].HeaderCell.Value = "RE1";
                    dgv_regressionresult.Columns[8].HeaderCell.Value = "K1";

                    dgv_regressionresult.Columns[9].HeaderCell.Value = "D2";
                    dgv_regressionresult.Columns[10].HeaderCell.Value = "E2";
                    dgv_regressionresult.Columns[11].HeaderCell.Value = "F2";
                    dgv_regressionresult.Columns[12].HeaderCell.Value = "RMS2";
                    dgv_regressionresult.Columns[13].HeaderCell.Value = "RE2";
                    dgv_regressionresult.Columns[14].HeaderCell.Value = "K2";

                    dgv_regressionresult.Columns[15].HeaderCell.Value = "D3";
                    dgv_regressionresult.Columns[16].HeaderCell.Value = "E3";
                    dgv_regressionresult.Columns[17].HeaderCell.Value = "F3";
                    dgv_regressionresult.Columns[18].HeaderCell.Value = "RMS3";
                    dgv_regressionresult.Columns[19].HeaderCell.Value = "RE3";
                    dgv_regressionresult.Columns[20].HeaderCell.Value = "K3";

                    dgv_regressionresult.Columns[21].HeaderCell.Value = "Bg";
                    dgv_regressionresult.Columns[22].HeaderCell.Value = "Bg1";
                    dgv_regressionresult.Columns[23].HeaderCell.Value = "Bg2";
                    dgv_regressionresult.Columns[24].HeaderCell.Value = "断点1";
                    dgv_regressionresult.Columns[25].HeaderCell.Value = "断点2";
                    dgv_regressionresult.Columns[26].HeaderCell.Value = "方法模型";
                    dgv_regressionresult.Columns[27].HeaderCell.Value = "回归曲线类型";
                    dgv_regressionresult.Columns[28].HeaderCell.Value = "误差";
                    ListDataInsertToDgv(dgv_regressionresult, LineParamData);
               
                    dgv_coefficientrevision.ColumnCount = 6;
                    dgv_coefficientrevision.Columns[0].HeaderCell.Value = "化合物名";//显示数据表抬头的别名
                    dgv_coefficientrevision.Columns[1].HeaderCell.Value = "校正系数（化合物1）";
                    dgv_coefficientrevision.Columns[2].HeaderCell.Value = "校正系数（化合物2）";
                    dgv_coefficientrevision.Columns[3].HeaderCell.Value = "校正系数（化合物3）";//显示数据表抬头的别名
                    dgv_coefficientrevision.Columns[4].HeaderCell.Value = "校正系数（化合物4）";
                    dgv_coefficientrevision.Columns[5].HeaderCell.Value = "校正系数（化合物5）";
                    dgv_coefficientrevision.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                    dgv_coefficientrevision.AllowUserToAddRows = false;
                    dgv_regressionresult.AllowUserToAddRows = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btn_add_Click(object sender, EventArgs e)
        {
            AddCorrectionFactor addcorrectionfactor = new AddCorrectionFactor();
           // addcorrectionfactor.path = LineParam_path; //路径参数传递
            addcorrectionfactor.LineParamData = LineParamData;
            addcorrectionfactor.Show();
        }

        private void btn_limitofdetection_Click(object sender, EventArgs e)
        {
            LimitDetection_RevisionQuantitation limitdetection = new LimitDetection_RevisionQuantitation();
            limitdetection.Show();
        }

        private void btn_theoreticalcoefficient_Click(object sender, EventArgs e)
        {
            TheoreticalCoefficient_RevisionQuantitation theoreticalcoefficientform = new TheoreticalCoefficient_RevisionQuantitation();
            theoreticalcoefficientform.Show();
        }

        private void btn_regressionLine_Click(object sender, EventArgs e)
        {
            RegressionLine regressionforma = new RegressionLine();
            regressionforma.ApplicationNames = ApplicationName;
            regressionforma.Show();
        }

        private void btn_checkdata_Click(object sender, EventArgs e)
        {
            ShowAllData checkdataRQFormc = new ShowAllData();
            checkdataRQFormc.ApplicationNames = ApplicationName;
            checkdataRQFormc.Show();
        }
       
    }
}
