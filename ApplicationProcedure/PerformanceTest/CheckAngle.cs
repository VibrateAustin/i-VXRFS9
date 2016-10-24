using i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults;
using i_VXRFS.SystemConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_VXRFS.ApplicationProcedure.PerformanceTest
{
    public partial class CheckAngle : Form
    {
        public CheckAngle()
        {
            InitializeComponent();
        }
        public List<string> getelementparameter;//上一窗口传递的元素参数
        public int DgvIndex;
        public List<double> RawData = new List<double>();
        private PerformanceTest_mainPage phdAForm;
        public CheckAngle(PerformanceTest_mainPage f1)
            :this()
        {
            this.phdAForm = f1;
        }
        private int SysDataIndex = 0; //记录从文件中查到到的数据行的索引，便于保存是进行数据更新
        private List<string[]> SysData;
        private void SearchDataFromTxt(string SysPath, ref List<string> dataA)
        {
            SysData = new List<string[]>();
            SysConfig_FileSave.ReadTxtToDList(SysPath, ref SysData);
            if (SysData.Count > 0)
            {
                int count = 0;
                foreach (string str in SysData[0])
                    count++;
                for (int i = 1; i < SysData.Count; i++)
                {
                    if (SysData[i][0] == getelementparameter[0])
                    {
                        SysDataIndex = i;
                        for (int j = 0; j < count; j++)
                            dataA.Add(SysData[i][j]);
                    }
                }
            }
        }
       
        public int index = 1;//区别：绘制竖线还是插值曲线
        private void CheckAngle_QuantitationAnalysis_Load(object sender, EventArgs e)
        {
            List<string> dataA = new List<string>();
            string SysPath = Public_Path.SysConfigurationParameterPath + "\\ElementAngel_Data.txt";
            SearchDataFromTxt(SysPath, ref dataA);
            if (dataA.Count > 0)
            {
                txtb_peakposition.Text = getelementparameter[8];
                txtb_startangle.Text = dataA[2].ToString();
                txtb_endangle.Text = dataA[3].ToString();
                txtb_scantime.Text = dataA[4].ToString();
                txtb_step.Text = dataA[6].ToString();//step的值估计需要变动
                //txtb_bgTime.Text = dataA[5].ToString();
            }
            else
            {
                txtb_peakposition.Text = getelementparameter[8];
                txtb_startangle.Text =(Convert.ToDouble(getelementparameter[8])-1).ToString();
                txtb_endangle.Text = (Convert.ToDouble(getelementparameter[8]) + 1).ToString();
                txtb_scantime.Text = "1";
                txtb_step.Text = "01";//step的值估计需要变动
                //txtb_bgTime.Text = "10";
            }
            cbox_mask.Text = "20";
            txtb_brkV.Text = getelementparameter[6]; txtb_brkV.ReadOnly = true;
            txtb_brmA.Text = getelementparameter[7]; txtb_brmA.ReadOnly = true;
            txtb_elemK.Text = getelementparameter[1]; txtb_elemK.ReadOnly = true;
            txtb_filter.Text = getelementparameter[5]; txtb_filter.ReadOnly = true;
            txtb_detector.Text = getelementparameter[4]; txtb_detector.ReadOnly = true;
            txtb_crystal.Text = getelementparameter[2]; txtb_crystal.ReadOnly = true;
            txtb_collimator.Text = getelementparameter[3]; txtb_collimator.ReadOnly = true;

            dgv_bgPoint.ColumnCount = 4; dgv_bgPoint.ColumnHeadersVisible = true;
            dgv_bgPoint.Columns[0].Name = "Bg1"; dgv_bgPoint.Columns[1].Name = "Bg2"; dgv_bgPoint.Columns[2].Name = "Bg3"; dgv_bgPoint.Columns[3].Name = "Bg4";
            dgv_bgPoint.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int index=dgv_bgPoint.Rows.Add();
            dgv_bgPoint.Rows[index].Cells[0].Value = getelementparameter[9];
            dgv_bgPoint.Rows[index].Cells[1].Value = getelementparameter[10];
            dgv_bgPoint.Rows[index].Cells[2].Value = getelementparameter[11];
            dgv_bgPoint.Rows[index].Cells[3].Value = getelementparameter[12];

            dgv_bgConff.ColumnCount = 4; dgv_bgConff.ColumnHeadersVisible = true;
            dgv_bgConff.Columns[0].Name = "BgC"; dgv_bgConff.Columns[1].Name = "BgL"; dgv_bgConff.Columns[2].Name = "BgQ"; dgv_bgConff.Columns[3].Name = "BgT";
            dgv_bgConff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int index1 = dgv_bgConff.Rows.Add();
            dgv_bgConff.Rows[index1].Cells[0].Value = 0.000;
            dgv_bgConff.Rows[index1].Cells[1].Value = 0.000;
            dgv_bgConff.Rows[index1].Cells[2].Value = 0.000;
            dgv_bgConff.Rows[index1].Cells[3].Value = 0.000;
           
            //窗口图像背景虚线的绘制
            Bitmap Bmap_2 = new Bitmap(picb_overlap.Width, picb_overlap.Height);
            Graphics g = Graphics.FromImage(Bmap_2);
            Pen pen = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(picb_overlap.ClientRectangle.X + picb_overlap.ClientRectangle.Width, picb_overlap.ClientRectangle.Y + picb_overlap.ClientRectangle.Height);
            g.DrawRectangle(pen, picb_overlap.ClientRectangle.X, picb_overlap.ClientRectangle.Y,
                picb_overlap.ClientRectangle.X + picb_overlap.ClientRectangle.Width,
                picb_overlap.ClientRectangle.Y + picb_overlap.ClientRectangle.Height);
            Pen myPen = new Pen(Color.Gray, 1);
            for (int i = 65; i < ClientRectangle.Width; )
            {
                for (int j = 25; j < picb_overlap.ClientRectangle.Height - 20; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i, j + 5));
                    j += 10;
                }
                i += Convert.ToInt32(ClientRectangle.Width / 10);
            }

            for (int j = 25; j < ClientRectangle.Height; )
            {
                for (int i = 59; i < ClientRectangle.Width - 51; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += ClientRectangle.Height / 10;
            }
            g.DrawRectangle(pen, 65, 25,
                picb_overlap.ClientRectangle.Width - 94,
                picb_overlap.ClientRectangle.Height - 56);
            Font font = new System.Drawing.Font("Arial", 8);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawString("0", font, sb, 40, picb_overlap.ClientRectangle.Height - 45);
            g.DrawString("Y-轴(kcps)", font, sb, 5, 25);
            //g.DrawString("2Theata", font, sb, ClientRectangle.Width/2 - 65, picb_overlap.ClientRectangle.Height - 15);

            //绘制默认的谱线
            string path = Public_Path.PHDAngelCheckPath + "\\" + getelementparameter[0]+".txt";
            RawData=Class_QualitationSpectraLine.ReadDataFromTxt2(path);
            double datamax = RawData.Max();
            float sizeX = ((float)(picb_overlap.Width-94) / RawData.Count);
            Pen pens = new Pen(Color.Blue, 1);
            for (int i = 0; i < RawData.Count - 1; i++)
            {
                PointF pf1 = new PointF((float)i * sizeX + 65,
                    (float)((picb_overlap.Height - 60 - (picb_overlap.Height - 120) * RawData[i] / datamax)));
                PointF pf2 = new PointF((float)(i + 1) * sizeX + 65,
                    (float)((picb_overlap.Height - 60 - (picb_overlap.Height - 120) * RawData[i + 1] / datamax)));
                g.DrawLine(pens, pf1, pf2);
            }
            Font font1 = new System.Drawing.Font("Arial", 10);
            SolidBrush sb1 = new SolidBrush(Color.Black);
            g.DrawString(datamax.ToString(), font1, sb1, 70, 40);
            Font font2= new System.Drawing.Font("Arial", 12);
            SolidBrush sb2 = new SolidBrush(Color.Red);
            g.DrawString(getelementparameter[0] +" "+ getelementparameter[1], font2, sb2, ClientRectangle.Width - 150,40);
            string txt=null;//横坐标值
            float factor = (float)(Convert.ToDouble(txtb_endangle.Text) - Convert.ToDouble(txtb_startangle.Text)) / 9;
            for (int i = 0; i < 10;i++ )
            {
                txt=(Math.Round(Convert.ToDouble(txtb_startangle.Text)+i*factor,4)).ToString();
                g.DrawString(txt, font1, sb1, 45+106*i, picb_overlap.ClientRectangle.Height - 25);
            }
            picb_overlap.Image = Bmap_2;
            g.Dispose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picb_overlap_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void picb_overlap_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 1) //峰位值
            {
                XData = e.X;
                paint_line();
                double sizeX = ((double)(picb_overlap.Width - 94) / RawData.Count);
                double angel = (e.X - 65) / sizeX * Convert.ToDouble(txtb_step.Text) + Convert.ToDouble(txtb_startangle.Text);
                txtb_peakposition.Text = Math.Round(angel,4).ToString();
            }
            else //背景点
            {
                if (axisData.Count < 4)
                {
                    axisData.Add(e.X);
                    ayisData.Add(e.Y);
                    List<double> bgData = new List<double>(); double sizeX = 0; double angel = 0;
                    for (int i = 0; i < axisData.Count; i++)
                    {
                        sizeX = ((double)(picb_overlap.Width - 94) / RawData.Count);
                        angel = (axisData[i] - 65) / sizeX * Convert.ToDouble(txtb_step.Text) + Convert.ToDouble(txtb_startangle.Text);
                        bgData.Add(angel - Convert.ToDouble(txtb_peakposition.Text));
                        dgv_bgPoint.Rows[0].Cells[i].Value = Math.Round(bgData[i], 4);
                    }
                    paint_line();
                }
            }
        }

        public void paint_line()
        {
            //txtb_peakposition.Text = getelementparameter[8];
            //txtb_startangle.Text = (Convert.ToDouble(getelementparameter[8]) - 1.0).ToString();
            //txtb_endangle.Text = (Convert.ToDouble(getelementparameter[8]) + 1.0).ToString();
            //txtb_scantime.Text = getelementparameter[22];
            //txtb_step.Text = "0.04";
            //cbox_mask.Text = "20";
            
            //窗口图像背景虚线的绘制
            Bitmap Bmap_2 = new Bitmap(picb_overlap.Width, picb_overlap.Height);
            Graphics g = Graphics.FromImage(Bmap_2);
            Pen pen = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(picb_overlap.ClientRectangle.X + picb_overlap.ClientRectangle.Width, picb_overlap.ClientRectangle.Y + picb_overlap.ClientRectangle.Height);
            g.DrawRectangle(pen, picb_overlap.ClientRectangle.X, picb_overlap.ClientRectangle.Y,
                picb_overlap.ClientRectangle.X + picb_overlap.ClientRectangle.Width,
                picb_overlap.ClientRectangle.Y + picb_overlap.ClientRectangle.Height);
            Pen myPen = new Pen(Color.Gray, 1);
            for (int i = 65; i < ClientRectangle.Width; )
            {
                for (int j = 25; j < picb_overlap.ClientRectangle.Height - 20; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i, j + 5));
                    j += 10;
                }
                i += Convert.ToInt32(ClientRectangle.Width / 10);
            }

            for (int j = 25; j < ClientRectangle.Height; )
            {
                for (int i = 59; i < ClientRectangle.Width - 51; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += ClientRectangle.Height / 10;
            }
            g.DrawRectangle(pen, 65, 25,
                picb_overlap.ClientRectangle.Width - 94,
                picb_overlap.ClientRectangle.Height - 56);
            Font font = new System.Drawing.Font("Arial", 8);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawString("0", font, sb, 40, picb_overlap.ClientRectangle.Height - 45);
            g.DrawString("Y-轴(kcps)", font, sb, 5, 25);
            //g.DrawString("2Theata", font, sb, ClientRectangle.Width/2 - 65, picb_overlap.ClientRectangle.Height - 15);

            //绘制默认的谱线
            string path = Public_Path.PHDAngelCheckPath + "\\" + getelementparameter[0] + ".txt";
            RawData = Class_QualitationSpectraLine.ReadDataFromTxt2(path);
            double datamax = RawData.Max();
            float sizeX = ((float)(picb_overlap.Width - 94) / RawData.Count);
            Pen pens = new Pen(Color.Blue, 1);
            for (int i = 0; i < RawData.Count - 1; i++)
            {
                PointF pf1 = new PointF((float)i * sizeX + 65,
                    (float)((picb_overlap.Height - 60 - (picb_overlap.Height - 120) * RawData[i] / datamax)));
                PointF pf2 = new PointF((float)(i + 1) * sizeX + 65,
                    (float)((picb_overlap.Height - 60 - (picb_overlap.Height - 120) * RawData[i + 1] / datamax)));
                g.DrawLine(pens, pf1, pf2);
            }
            Font font1 = new System.Drawing.Font("Arial", 10);
            SolidBrush sb1 = new SolidBrush(Color.Black);
            g.DrawString(datamax.ToString(), font1, sb1, 70, 40);
            Font font2 = new System.Drawing.Font("Arial", 12);
            SolidBrush sb2 = new SolidBrush(Color.Red);
            g.DrawString(getelementparameter[0] + " " + getelementparameter[1], font2, sb2, ClientRectangle.Width - 150, 40);
            string txt = null;//横坐标值
            float factor = (float)(Convert.ToDouble(txtb_endangle.Text) - Convert.ToDouble(txtb_startangle.Text)) / 9;
            for (int i = 0; i < 10; i++)
            {
                txt = (Math.Round(Convert.ToDouble(txtb_startangle.Text) + i * factor, 4)).ToString();
                g.DrawString(txt, font1, sb1, 45 + 106 * i, picb_overlap.ClientRectangle.Height - 25);
            }
            if ( XData!=0 )
            {
                //绘制竖线
                Pen penX = new Pen(Color.Orange, 1);
                g.DrawLine(penX, new Point(XData, 50), new Point(XData, picb_overlap.ClientRectangle.Height - 55));
                g.DrawLine(penX, new Point(XData - 30, picb_overlap.ClientRectangle.Height - 55), new Point(XData + 30, picb_overlap.ClientRectangle.Height - 55));
            }
            if(axisData.Count!=0)
            {
                //绘制插值曲线
                foreach (double axisdata in axisData)
                {
                    Xdata.Add(axisdata-65);
                    Ydata.Add(RawData[Convert.ToInt32((axisdata-65)/ sizeX)]);
                }
                Pen pens2 = new Pen(Color.Red, 1);
                //获得插值后的Y值
                double XdataMax = Xdata.Max();
                //smoothdatamax = smoothdata.Max();
                double XdataMin = Xdata.Min();
                int n = (int)(XdataMax - XdataMin) + 20;
                List<double> XInterpolationData = new List<double>();
                for (int i = (int)(XdataMin - 10); i < (int)(XdataMax + 10); i++)
                {
                    XInterpolationData.Add(i);
                }
                //如果只有一个插值点
                if (Xdata.Count == 1)
                {
                    PointF pf1 = new PointF((float)(Xdata[0] - 30)+65,
                        (float)((picb_overlap.Height - 60 - (picb_overlap.Height - 120) * Ydata[0] / datamax)));
                    PointF pf2 = new PointF((float)(RawData.Count - 10) * sizeX+65,
                        (float)((picb_overlap.Height - 60 - (picb_overlap.Height - 120) * Ydata[0] / datamax)));
                    g.DrawLine(pens2, pf1, pf2);
                }
                else
                {     //牛顿插值算法得出插值后的Y值
                    YInterpolationRebackData = Newton_method(Xdata, Ydata, XInterpolationData);
                    for (int i = 0; i < XInterpolationData.Count - 1; i++)
                    {
                        PointF pf1 = new PointF((float)XInterpolationData[i]+65,
                            (float)((picb_overlap.Height - 60 - (picb_overlap.Height - 120) * YInterpolationRebackData[i] / datamax)));
                        PointF pf2 = new PointF((float)XInterpolationData[i + 1]+65,
                            (float)((picb_overlap.Height - 60 - (picb_overlap.Height - 120) * YInterpolationRebackData[i + 1] / datamax)));
                        g.DrawLine(pens2, pf1, pf2);
                        
                    }
                }
                for (int k = 0; k < Xdata.Count; k++)
                {
                    Font font3 = new System.Drawing.Font("Arial", 12);
                    SolidBrush sb3 = new SolidBrush(Color.Red);
                    g.DrawString("X", font3, sb3, (int)axisData[k]-10, (int)ayisData[k]-10);
                }
                Xdata.Clear();
                Ydata.Clear();
            }
            picb_overlap.Image = Bmap_2;
            g.Dispose();
        }
        public int XData=0;//记录“扫描参数”的点击点
        public List<double> ayisData = new List<double>();//获得鼠标点击点的窗口纵坐标值
        public List<double> axisData = new List<double>();//获得鼠标点击点的窗口横坐标值
        public List<double> Xdata=new List<double>();//获得鼠标点击点的横坐标值
        public List<double> Ydata = new List<double>();//获得鼠标点击点的纵坐标值
        public List<double> YInterpolationRebackData = new List<double>();//获得插值法返回的插值曲线的纵坐标值
        
        //牛顿插值算法,形参为插值点的横纵坐标;X 为需要被插值的横坐标
        public List<double> Newton_method(List<double> x, List<double> y, List<double> X)
        {
            int n = x.Count;
            //得到差商表中对角线的值f[x0,..xk]
            double[] g = new double[n];
            double[] temp = new double[n];
            for (int i = 0; i < n; i++)
            {
                g[i] = y[i];
            }
            for (int j = 1; j < n; j++)
            {
                for (int i = j; i < n; i++)
                {
                    temp[i] = (g[i] - g[i - 1]) / (x[i] - x[i - j]);
                }
                for (int i = j; i < n; i++)
                {
                    g[i] = temp[i];
                    temp[i] = 0;
                }
            }
            //计算插值多项式
            List<double> Y = new List<double>();
            double tk = 1;
            double t = g[0];
            for (int i = 0; i < X.Count; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    tk *= (X[i] - x[j]);
                    t += tk * g[j + 1];
                }
                Y.Add(t);
                t = g[0];
                tk = 1;
            }
            return Y;
        }

        /// <summary>
        /// 获取当前鼠标所在的tabpage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabCtr_Angle_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabCtr_Angle.TabPages.Count; i++)
            {
                if (tabCtr_Angle.GetTabRect(i).Contains(e.Location))
                {
                    if (i != 1) index = 1; else index = 2;
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //更新数据到数据库中
            //8-12.21
                phdAForm.dgv1.Rows[DgvIndex].Cells[8].Value = getelementparameter[8];
                for (int i = 0; i < 4; i++)
                {
                    if (Convert.ToDouble(dgv_bgPoint.Rows[0].Cells[i].Value) != 0)
                        phdAForm.dgv1.Rows[DgvIndex].Cells[9 + i].Value = dgv_bgPoint.Rows[0].Cells[i].Value;
                }
                phdAForm.dgv1.Rows[DgvIndex].Cells[21].Value = DateTime.Now.ToString("yyyy/MM/dd");
            
            SysData[SysDataIndex][1] = txtb_peakposition.Text;
            SysData[SysDataIndex][2] = txtb_startangle.Text;
            SysData[SysDataIndex][3] = txtb_endangle.Text;
            SysData[SysDataIndex][4] = txtb_scantime.Text;
            //SysData[SysDataIndex][5] = txtb_bgTime.Text;
            SysData[SysDataIndex][6] = txtb_step.Text;
            string path = Public_Path.SysConfigurationParameterPath + "\\ElementAngel_Data.txt";
            SysConfig_FileSave.ListToSaveTxt(SysData, path);
            this.Close();
        }
        
        //建立更新数据表一行的方法
        //i_VXRFS_function XRF_function=new i_VXRFS_function();
        //public int sqlData(string str){
        //    SqlConnection conn = new SqlConnection(XRF_function.LinkDataBasePath);
        //    conn.Open();
        //    SqlCommand sqc = new SqlCommand(str, conn);
        //    int i=Convert.ToInt16(sqc.ExecuteNonQuery());
        //    conn.Close();
        //    return i;
        //}
        //public Boolean sqlSelect(string str)
        //{
        //    SqlConnection conn = new SqlConnection(XRF_function.LinkDataBasePath);
        //    conn.Open();
        //    SqlCommand sqc = new SqlCommand(str, conn);
        //    SqlDataReader sdr = sqc.ExecuteReader();
        //    sdr.Read();
        //    bool i = false;
        //    if (sdr.HasRows) i = true; else i = false;
        //    conn.Close();
        //    return i;
        //}
    }
}
