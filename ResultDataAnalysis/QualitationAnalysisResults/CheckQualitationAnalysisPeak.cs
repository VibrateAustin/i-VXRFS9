using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults
{
    public partial class CheckQualitationAnalysisPeak : Form
    {
        public CheckQualitationAnalysisPeak()
        {
            InitializeComponent();
        }

        string path_sample = null;
        public List<string> SampleInfo = new List<string> { };
        public List<List<string>> testParameter = new List<List<string>> { };

        /*
        public void ReadParameters(string path ,ref List<List<string>> testParameter)
        {
            FileStream openfile = new FileStream(path,FileMode.Open,FileAccess.Read);
            StreamReader read = new StreamReader(openfile);
            while (!read.EndOfStream)
            {
                List<string> Parameters_piecewise = new List<string> { };
                Parameters_piecewise.AddRange(read.ReadLine().Split(' ','\t',','));
                testParameter.Add(Parameters_piecewise);
            }
            openfile.Close();
            read.Close();
        }
        */

        public void ShowParameters()        //参数不全，待补充
        {
            string path_parameters = path_sample + "\\" + SampleInfo[1] + ".txt";
            Class_QualitationSpectraLine.ReadTxtToList(path_parameters, ref testParameter);
            int index = tabControl1.SelectedIndex + 1;

            textBox1.Text = testParameter[index][13];
            textBox2.Text = testParameter[index][14];
            textBox3.Text = testParameter[index][11];
            textBox4.Text = testParameter[index][10];
            textBox5.Text = testParameter[index][12];
            textBox11.Text = testParameter[index][7];
            textBox12.Text = testParameter[index][8];
            textBox13.Text = testParameter[index][9];

        }

        public void ShowPeakSite()
        {
            dataGridView1.Rows.Clear();             //此方法没有清除列标题行，本应该清除所有数据，待改进
            string path_sites = path_sample + "\\peak\\" + (tabControl1.SelectedIndex + 1) + ".txt";
            string[] _peaks = File.ReadAllLines(path_sites);

            dataGridView1.ColumnCount = _peaks[0].Split(' ', '\t', ',').Length;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderCell.Value = "峰序号";
            dataGridView1.Columns[1].HeaderCell.Value = "能量强度 keV";
            dataGridView1.Columns[2].HeaderCell.Value = "2theta";
            dataGridView1.Columns[3].HeaderCell.Value = "峰宽";
            dataGridView1.Columns[4].HeaderCell.Value = "峰强 kcps";
            dataGridView1.Columns[5].HeaderCell.Value = "背景峰强 kcps";
            dataGridView1.Columns[6].HeaderCell.Value = "signal-";
            for (int i = 7; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Value = "匹配谱线" + (i - 6);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 1; i < _peaks.Length; i++)
            {
                string[] row = _peaks[i].Split('\t');
                dataGridView1.Rows.Add(row);
            }
        }

        public void ShowPeakIntensity()
        {
            dataGridView1.Rows.Clear();                  //此方法没有清除列标题行，本应该清除所有数据，待改进
            double step = 0.050;                         //步长和起始角数据需要进一步修改
            double startAngle = 14;
            List<List<string>> data_intensity = new List<List<string>> { };

            string path_intensity = path_sample + "\\" + (tabControl1.SelectedIndex + 1) + ".txt";
            Class_QualitationSpectraLine.ReadTxtToList(path_intensity, ref data_intensity);

            dataGridView1.ColumnCount = 11;
            dataGridView1.Columns[0].HeaderText = "2theta";
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 1; i < 11; i++)
            {
                dataGridView1.Columns[i].HeaderText = "+ " + (i * step).ToString();
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < data_intensity.Count - 1; i++)//区段1和2的txt文件比其他区段多出一个空行，导致数据表里也多出一个空行
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = (startAngle + i * 10 * step).ToString("0.00");
                for (int j = 0; j < data_intensity[i + 1].Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j + 1].Value = data_intensity[i + 1][j];
                }
            }
        }

        //加载“查看峰”窗口，默认显示峰位数据
        private void CheckQualitationAnalysisPeak_Load(object sender, EventArgs e)
        {
            QualitationAnalysisResult.Sample sample = new QualitationAnalysisResult.Sample(SampleInfo[2], SampleInfo[1]);
            path_sample = Public_Path.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1];
            this.ShowParameters();
            this.ShowPeakSite();
        }

        //事件——区段标签的切换
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowParameters();
            this.ShowPeakSite();
        }

        //事件——查看峰位
        private void button2_Click(object sender, EventArgs e)
        {
            this.ShowPeakSite();
        }

        //事件——查看峰强
        private void button1_Click(object sender, EventArgs e)
        {
            this.ShowPeakIntensity();
        }
    }
}
