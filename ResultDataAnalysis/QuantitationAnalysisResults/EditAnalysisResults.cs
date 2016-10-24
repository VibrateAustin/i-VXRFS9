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
using System.IO;

namespace i_VXRFS.ResultDataAnalysis.QuantitationAnalysisResults
{
    public partial class EditAnalysisResults : Form
    {
        public EditAnalysisResults()
        {
            InitializeComponent();
        }
        public DataGridView dgvP
        {
            set { dgv_input=value; }
            get { return dgv_input; }
        }
        private QuantitationAnalysisResults editForm;
        private EditAnalysisResults(QuantitationAnalysisResults Odata) :this(){
            this.editForm = Odata;
        }
        public List<string> FileName;
        public string path;
        public string samplemodel = string.Empty;
        public string analysisapplicationname = string.Empty;
        public List<List<string>> Data; //上级窗口dgv中所有数据
        public List<int> bgIndex;//背景数据所在列号
        public int indexSelectedRow;
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void EditAnalysisResults_Load(object sender, EventArgs e)
        {
            txtb_samplemodel.Text = samplemodel;
            txtb_samplemodel.ReadOnly = true;
            txtb_analysisapplicationname.Text = analysisapplicationname;
            txtb_analysisapplicationname.ReadOnly = true;
            txtb_samplename.Text = Data[indexSelectedRow][0];
            txtb_samplename.ReadOnly = true;
            btn_add.Visible = false;
            txtb_factor.Text = Data[indexSelectedRow][4];
            txtb_totalp.Text = Data[indexSelectedRow][7];
            dgv_input.Visible = false;
            try
            {
                if (samplemodel == "标准")
                {
                    btn_calconc.Visible = false;
                    btn_calkcpsconc.Visible = false;
                    btn_cancle.Visible = true;
                    updateDgvK(dgv_compoundperc);
                    dgv_compoundkcps.Visible = false;
                    groupBox2.Visible = false;
                    btn_input.Visible = false;
                    btn_ok.Visible = false;
                    txtb_factor.Visible = false;
                    txtb_totalp.Visible = false;
                }
                else
                {
                    btn_calconc.Visible = true;
                    btn_calkcpsconc.Visible = true;
                    btn_cancle.Visible = true;
                    updateDgvP(dgv_compoundperc);
                    updateDgvK(dgv_compoundkcps);
                }
                dgv_compoundperc.AllowUserToAddRows = false;
                dgv_compoundkcps.AllowUserToAddRows = false;
                dgv_input.AllowUserToAddRows = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void updateDgvP(DataGridView dgv)
        {
            dgv.ColumnCount = 3;
            dgv.Visible = true;
            dgv.Columns[0].HeaderCell.Value = "化合物";
            dgv.Columns[1].HeaderCell.Value = "值";
            dgv.Columns[2].HeaderCell.Value = "单位";
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int index = 0;
            for (int cols = 9; cols < Data[0].Count; cols++)
            {
                if (!bgIndex.Contains(cols))
                {
                    index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = Data[indexSelectedRow - 1][cols];
                    dgv.Rows[index].Cells[1].Value = Data[indexSelectedRow + 5][cols];
                    dgv.Rows[index].Cells[2].Value = "%";
                }
            }
            dgv.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;  
        }
        private void updateDgvK(DataGridView dgv)
        {
            dgv.ColumnCount = 4;
            dgv.Visible = true;
            dgv.Columns[0].HeaderCell.Value = "元素化合物";
            dgv.Columns[3].HeaderCell.Value = "背景强度2(kcps)";
            dgv.Columns[1].HeaderCell.Value = "总强度(kcps)";
            dgv.Columns[2].HeaderCell.Value = "背景强度1(kcps)";
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
            int index2 = 0; int of = 0; int count = 0;
            for (int cols = 9; cols < Data[0].Count; cols++)
            {
                if (!bgIndex.Contains(cols))
                {
                    index2 = dgv.Rows.Add();
                    dgv.Rows[index2].Cells[0].Value = Data[indexSelectedRow - 1][cols];
                    dgv.Rows[index2].Cells[1].Value = Data[indexSelectedRow][cols];
                    if (Data[indexSelectedRow - 1][cols] == "Li2O" || Data[indexSelectedRow - 1][cols] == "F" || Data[indexSelectedRow - 1][cols] == "N2O5" || Data[indexSelectedRow - 1][cols] == "B2O3")
                        continue;
                    else
                    {
                        if (of<bgIndex.Count)
                        {
                            dgv.Rows[index2].Cells[2].Value = Data[indexSelectedRow][bgIndex[of]]; count++;
                            if (bgIndex[of] + 1 == bgIndex[of + 1])  //有第二个背景点
                            {
                                dgv.Rows[index2].Cells[3].Value = Data[indexSelectedRow][bgIndex[of+1]]; count++;
                                of += 2;
                            }
                            else of++;
                        }
                    }
                }
            }
            dgv.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void updateDgvP2(DataGridView dgv)
        {
            dgv.ColumnCount = 3;
            dgv.Visible = true;
            dgv.Columns[0].HeaderCell.Value = "输入";
            dgv.Columns[1].HeaderCell.Value = "值";
            dgv.Columns[2].HeaderCell.Value = "单位";
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int index = dgv.Rows.Add();
            dgv.Rows[index].Cells[0].Value = "总烧失量";
            dgv.Rows[index].Cells[2].Value = "%";

        }
        private int option = 0;
        private void btn_input_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                btn_add.Visible = true;
                dgv_compoundperc.Visible = false;
                dgv_input.Visible = true;
                updateDgvP2(dgv_input);
                option = 1;
            }
            else if (option == 1)
            {
                dgv_compoundperc.Visible = true;
                dgv_input.Visible = false;
                //updateDgvP(dgv_compoundperc);
                option = 2;
            }
            else
            {
                //btn_add.Visible = true;
                dgv_compoundperc.Visible = false;
                dgv_input.Visible = true;
                option = 1;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            InputCompound addcompoundform = new InputCompound(this);
            addcompoundform.Show();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            UpdateData(); //更新Data数据
            //把Data数据保存到各txt中
            string fileName = null; int indexRow = 0;
            string ColHead = null;
            for (int m = 0; m < Data[0].Count; m++)
            {
                ColHead+=Data[0][m]+'\t';
            }
            //添加输入的化合物名到Data第一行列标题中
            int q = 1;
            while (dgv_input.RowCount > q)
            {
                ColHead += dgv_input.Rows[q].Cells[0].Value.ToString() + '\t';
                q++;
                //Data[indexSelectedRow + 5].Add(dgv_input.Rows[q].Cells[1].Value.ToString()); //把浓度值添加到Data中
            }
            for (int i = 0; i < FileName.Count; i++)
            {
                //打开文件，清除数据，重新写入数据
                fileName = FileName[i].Substring(0, FileName[i].Length - 7);
                for (int j = 0; j < Data.Count; j++)
                {
                    if (Data[j][0] == fileName)
                        indexRow = j;
                }
                UtilityClass.CreateFile(path + "\\" + FileName[i], true);
                StreamWriter saveSW = new StreamWriter(path + "\\" + FileName[i], false, Encoding.Default);
                string colhead = ColHead.Substring(0, ColHead.Length - 1);
                saveSW.WriteLine(colhead);
                for (int k = 0; k < 6;k++ )
                {
                    string RowStr = null;
                    for (int m = 0; m < Data[0].Count; m++)
                    {
                        RowStr += Data[indexRow+k][m] + '\t';
                    }
                    if (indexSelectedRow == indexRow && k == 5)
                    {
                        int p = 1;
                        while (dgv_input.RowCount > p)
                        {
                            RowStr += dgv_input.Rows[p].Cells[1].Value.ToString() + '\t';
                            p++;
                        }
                    }
                    else
                    {
                        int p = 1;
                        while (dgv_input.RowCount > p)
                        {
                            RowStr += "0" + '\t';
                            p++;
                        }
                    }
                    string rowStr = RowStr.Substring(0, RowStr.Length - 1);
                    saveSW.WriteLine(rowStr);
                }
                saveSW.Close();
            }
            //在reflesh上一窗口
            this.Owner.Invalidate();
            this.Close();
        }
        //获得总百分含量
        private double getTotalP()
        {
            double TotalP = 0;
            int i = 0; int j = 1;
            do
            {
                TotalP += Convert.ToDouble(dgv_compoundperc.Rows[i].Cells[1].Value.ToString());
                i++;
            } while (dgv_compoundperc.RowCount > i);
            while (dgv_input.RowCount > j)
            {
                TotalP += Convert.ToDouble(dgv_input.Rows[j].Cells[1].Value);
                j++;
            }
            return TotalP;
        }
        //把dgv数据组装到Data
        private void UpdateData()
        {
            //获得总百分含量
            double TotalP = getTotalP();
            //获得当前日期和归一化因子
            string NowTime = DateTime.Now.ToShortDateString();
            string factors = txtb_factor.Text;
            Data[indexSelectedRow][7] = TotalP.ToString();
            Data[indexSelectedRow][6] = NowTime;
            Data[indexSelectedRow][4] = factors;
            //int q = 1;
            //while (dgv_input.RowCount > q)
            //{
            //    Data[0].Add(dgv_input.Rows[q].Cells[0].Value.ToString() );
            //    Data[indexSelectedRow + 5].Add(dgv_input.Rows[q].Cells[1].Value.ToString()); //把浓度值添加到Data中
            //}
            //更新浓度和强度数据
            int rowPoint = 0; int pointTwo = 0; int of = 0;
            for (int k = 9; k < Data[0].Count; k++)
            {
                if (bgIndex.Contains(k)) //背景列
                {
                    if (pointTwo == 0)
                    {
                        Data[indexSelectedRow][k] = dgv_compoundkcps.Rows[rowPoint].Cells[2].Value.ToString();
                    }
                    else
                    {
                        Data[indexSelectedRow][k] = dgv_compoundkcps.Rows[rowPoint].Cells[3].Value.ToString(); pointTwo = 0;
                    }
                    if (of < bgIndex.Count-1)
                    {
                        if (bgIndex[of] + 1 == bgIndex[of + 1])  //有第二个背景点
                        {
                            pointTwo = 1;
                           // of += 2;
                        }
                        of++;
                    }
                }
                else  //非背景列
                {
                    int indexRow = 0; int j = 0;
                    while (dgv_compoundperc.RowCount > j)
                    {
                        if (Data[0][k] == dgv_compoundperc.Rows[j].Cells[0].Value.ToString())
                        {
                            indexRow = j;
                            break;
                        }
                        j++;
                    }
                    if(Data[0][k]!="Li2O"&&Data[0][k]!="F"&&Data[0][k]!="B2O3"&&Data[0][k]!="N2O5")
                        rowPoint = indexRow;
                    Data[indexSelectedRow + 5][k] = dgv_compoundperc.Rows[indexRow].Cells[1].Value.ToString();
                    Data[indexSelectedRow][k]=dgv_compoundkcps.Rows[indexRow].Cells[1].Value.ToString();
                }
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
