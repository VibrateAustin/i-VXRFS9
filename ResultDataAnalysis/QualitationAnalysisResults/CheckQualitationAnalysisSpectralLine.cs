using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults
{
    public partial class CheckQualitationAnalysisSpectralLine : Form
    {
        public CheckQualitationAnalysisSpectralLine()
        {
            InitializeComponent();
        }
        public List<double> smoothdata = new List<double>();
        public List<List<double>> AllData = new List<List<double>>(); //存放每个区段的原始数据
        public List<List<List<string>>> AllPeakData = new List<List<List<string>>>();//存放所有的谱峰数据
        //鼠标双击，把移除的点的索引放在这个列表中（每个文件中该谱线所在的行号）
        List<int> RemoveP_1 = new List<int>(); List<int> RemoveP_2 = new List<int>(); List<int> RemoveP_3 = new List<int>();
        List<int> RemoveP_4 = new List<int>(); List<int> RemoveP_5 = new List<int>(); List<int> RemoveP_6 = new List<int>();
        List<int> RemoveP_7 = new List<int>(); List<int> RemoveP_8 = new List<int>(); List<int> RemoveP_9 = new List<int>();
        List<int> RemoveP_10 = new List<int>(); List<int> RemoveP_11 = new List<int>();
        private double[] step = { 0.04, 0.052, 0.031, 0.052, 0.05, 0.05, 0.08, 0.1, 0.06, 0.06, 0.1 }; //每个区段的步长
        private double[] startAng = { 14.02, 17.026, 12.016, 26.626, 37.025, 61.025, 76.04, 91.05, 104.03, 133.53, 20.55 };//起始角度
        //窗口图像背景虚线的绘制
        private void paint(PictureBox picb_name)
        {
            
            Bitmap Bmap_2 = new Bitmap(picb_name.Width, picb_name.Height);
            Graphics g = Graphics.FromImage(Bmap_2);
            Pen pen = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(picb_name.ClientRectangle.X + picb_name.ClientRectangle.Width, picb_name.ClientRectangle.Y + picb_name.ClientRectangle.Height);
            g.DrawRectangle(pen, picb_name.ClientRectangle.X, picb_name.ClientRectangle.Y,
                picb_name.ClientRectangle.X + picb_name.ClientRectangle.Width,
                picb_name.ClientRectangle.Y + picb_name.ClientRectangle.Height);
            Pen myPen = new Pen(Color.Gray, 1);
            for (int i = 0; i < ClientRectangle.Width; )
            {
                for (int j = 0; j < picb_name.ClientRectangle.Height; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i, j + 5));
                    j += 10;
                }
                i += Convert.ToInt32(ClientRectangle.Width / 7.3);
            }

            for (int j = 0; j < ClientRectangle.Height; )
            {
                for (int i = 0; i < ClientRectangle.Width ; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += Convert.ToInt32(ClientRectangle.Height / 6.7);
            }
            picb_name.Image = Bmap_2;
            g.Dispose();
        }
        
        /// <summary>
        /// 绘制的曲线
        /// </summary>
        /// <param name="picb_name"></param>
        /// <param name="RawData"></param>
        /// <param name="peakdata">读取的谱峰信息，含标题行</param>
        /// <param name="zoneNum"></param>
        public void DrawSmoothLine(PictureBox picb_name,List<double> RawData,List<List<string>> peakdata,int zoneNum)
        {
            //窗口图像背景虚线的绘制
            Bitmap Bmap_2 = new Bitmap(picb_name.Width, picb_name.Height);
            Graphics g = Graphics.FromImage(Bmap_2);
            Pen pen = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(picb_name.ClientRectangle.X + picb_name.ClientRectangle.Width, picb_name.ClientRectangle.Y + picb_name.ClientRectangle.Height);
            g.DrawRectangle(pen, picb_name.ClientRectangle.X, picb_name.ClientRectangle.Y,
                picb_name.ClientRectangle.X + picb_name.ClientRectangle.Width,
                picb_name.ClientRectangle.Y + picb_name.ClientRectangle.Height);
            Pen myPen = new Pen(Color.Gray, 1);
            for (int i = 0; i < ClientRectangle.Width; )
            {
                for (int j = 0; j < picb_name.ClientRectangle.Height; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i, j + 5));
                    j += 10;
                }
                i += Convert.ToInt32(ClientRectangle.Width / 7.3);
            }

            for (int j = 0; j < ClientRectangle.Height; )
            {
                for (int i = 0; i < ClientRectangle.Width; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += Convert.ToInt32(ClientRectangle.Height / 6.7);
            }

            //smoothdata = Class_QualitationSpectraLine.Smooth9(RawData);//返回九点平滑后的数据
            List<double> orgdata = new List<double>();//需要实例化
            for (int i = 0; i < RawData.Count; i++)
            {
                orgdata.Add(Convert.ToDouble(RawData[i]));
            }
            //smoothdata = Smooth5(rawdata);//返回五点平滑后的数据
            //根据平滑后的数据绘平滑后谱线图
            double smoothdatamax = orgdata.Max();
            float sizeX = ((float)picb_name.Width / orgdata.Count);
            if (picb_name == picb_4 || picb_name == picb_3)//该几个窗口图线显示过小
                sizeX = (float)(sizeX * 1);
            else if (picb_name == picb_5 || picb_name == picb_8)
                sizeX = (float)(sizeX * 1);
            else if (picb_name == picb_2)
                sizeX = (float)(sizeX * 1);
            Pen pens = new Pen(Color.Blue, 1);
            for (int i = 0; i < orgdata.Count - 1; i++)
            {
                PointF pf1 = new PointF((float)i * sizeX,
                    (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i] / smoothdatamax)));
                PointF pf2 = new PointF((float)(i + 1) * sizeX,
                    (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i + 1] / smoothdatamax)));
                g.DrawLine(pens, pf1, pf2);
            }
            //double[] step = { 0.04, 0.052, 0.031, 0.052, 0.05, 0.05, 0.08, 0.1, 0.06, 0.06, 0.1 }; //每个区段的步长
            //double[] startAng = { 14.02, 17.026, 12.016, 26.626, 37.025, 61.025, 76.04, 91.05, 104.03, 133.53, 20.55 };//起始角度
            float x, y;
                for (int q = 1; q < peakdata.Count; q++)
                {
                    double theta = Convert.ToDouble(peakdata[q][2]);
                    int position = (int)Math.Ceiling(((double)(theta - startAng[zoneNum - 1]) / step[zoneNum - 1]));
                    Font font = new Font("宋体", 10);
                    SolidBrush brush = new SolidBrush(Color.Blue);
                    x = ((float)(position * sizeX - 20));
                    y = (float)(picb_name.Height - 50 - (picb_name.Height - 50) * orgdata[position] / smoothdatamax);
                    string peak = null;
                    if (peakdata[q].Count > 8)
                        peak = peakdata[q][7] + peakdata[q][8];
                    else peak = peakdata[q][7];
                    g.DrawString(peak, font, brush, x, y);
                }
            picb_name.Image = Bmap_2;
            g.Dispose();
        }

        public List<string> SampleInfo;//存放上一窗口传值过来的样品数据
        i_VXRFS_function XRF_function =new i_VXRFS_function();
        private void CheckQualitationAnalysisSpectralLine_Load(object sender, EventArgs e)
        {
            //自动把选择的样品数据加载到picb图中
            DirectoryInfo getallinfo = new DirectoryInfo(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2]);//定性分析程序下的定性分析样品名结果文件夹列表
            FileSystemInfo[] fsinfos = getallinfo.GetFileSystemInfos();//获得指定目录下的所有文件和文件夹
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)//判断是否为文件夹
                {
                    DirectoryInfo getdinfo = new DirectoryInfo(fsinfo.FullName);
                    if (getdinfo.Name == SampleInfo[1])
                    {  //按照样品名寻找对应的存放数据的文件夹
                        //打开文件夹，依次读取*.txt文件
                        List<double> rawdata1;
                        List<List<string>> peakdata1;
                        PictureBox picb_name = picb_1;
                        for (int i = 1; i < 12; i++)
                        {
                            rawdata1 = new List<double>();
                            peakdata1 = new List<List<string>>();
                            switch (i)
                            {
                                case 1:
                                    picb_name = picb_1;
                                    break;
                                case 2:
                                    picb_name = picb_2;
                                    break;
                                case 3:
                                    picb_name = picb_3;
                                    break;
                                case 4:
                                    picb_name = picb_4;
                                    break;
                                case 5:
                                    picb_name = picb_5;
                                    break;
                                case 6:
                                    picb_name = picb_6;
                                    break;
                                case 7:
                                    picb_name = picb_7;
                                    break;
                                case 8:
                                    picb_name = picb_8;
                                    break;
                                case 9:
                                    picb_name = picb_9;
                                    break;
                                case 10:
                                    picb_name = picb_10;
                                    break;
                                case 11:
                                    picb_name = picb_11;
                                    break;
                            }
                            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\"+i+".txt";
                            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
                            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\"+i+".txt");
                            DrawSmoothLine(picb_name, rawdata1, peakdata1,i);
                            //List<List<string>> peakTepData = new List<List<string>>();
                            //for (int k = 0; k < peakdata1.Count;k++ )
                            //{
                            //    List<string> data = new List<string>();
                            //    data.Add(peakdata1[k][2]);
                            //    data.Add(peakdata1[k][7]);
                            //    if (peakdata1[k].Count > 8) data.Add(peakdata1[k][8]);
                            //    peakTepData.Add(data);
                            //}
                            AllPeakData.Add(peakdata1);
                            AllData.Add(rawdata1);
                            path = null;
                        }
                    }
                }
            }
        }
        
        private void picb_1_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy=getXY(e.X, 1);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
            //Graphics g = this.CreateGraphics();
           // picb_1.Cursor.DrawStretched(g, new Rectangle(new PointF(x,y),10));
        }
        private void picb_2_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy = getXY(e.X, 2);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
        }
        private void picb_3_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy = getXY(e.X, 3);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
        }
        private void picb_4_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy = getXY(e.X, 4);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
        }
        private void picb_5_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy = getXY(e.X, 5);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
        }
        private void picb_6_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy = getXY(e.X, 6);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
        }
        private void picb_7_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy = getXY(e.X, 7);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
        }
        private void picb_8_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy = getXY(e.X, 8);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
        }
        private void picb_9_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy = getXY(e.X, 9);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
        }
        private void picb_10_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy = getXY(e.X, 10);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
        }
        private void picb_11_MouseMove(object sender, MouseEventArgs e)
        {
            PointF xy = getXY(e.X, 11);
            lb_x.Text = Convert.ToString(xy.X);
            lb_y.Text = Convert.ToString(xy.Y);
        }
        private void btn_compareLine_Click(object sender, EventArgs e)
        {
            ContrastSpectraLine_QualitationResults contrastspectralineform = new ContrastSpectraLine_QualitationResults();
            contrastspectralineform.sampleinfo=SampleInfo;
            contrastspectralineform.Show();
        }

        private void btn_checkallline_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 有剔除点的时候，使用这个方法绘制谱图
        /// </summary>
        /// <param name="picb_name"></param>
        /// <param name="RawData"></param>
        /// <param name="peakdata"></param>
        /// <param name="zoneNum"></param>
        /// <param name="removeP">剔除点的索引列表</param>
        public void DrawSmoothLine(PictureBox picb_name, List<double> RawData, List<List<string>> peakdata, int zoneNum, List<int> removeP)
        {
            //窗口图像背景虚线的绘制
            Bitmap Bmap_2 = new Bitmap(picb_name.Width, picb_name.Height);
            Graphics g = Graphics.FromImage(Bmap_2);
            Pen pen = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(picb_name.ClientRectangle.X + picb_name.ClientRectangle.Width, picb_name.ClientRectangle.Y + picb_name.ClientRectangle.Height);
            g.DrawRectangle(pen, picb_name.ClientRectangle.X, picb_name.ClientRectangle.Y,
                picb_name.ClientRectangle.X + picb_name.ClientRectangle.Width,
                picb_name.ClientRectangle.Y + picb_name.ClientRectangle.Height);
            Pen myPen = new Pen(Color.Gray, 1);
            for (int i = 0; i < ClientRectangle.Width; )
            {
                for (int j = 0; j < picb_name.ClientRectangle.Height; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i, j + 5));
                    j += 10;
                }
                i += Convert.ToInt32(ClientRectangle.Width / 7.3);
            }

            for (int j = 0; j < ClientRectangle.Height; )
            {
                for (int i = 0; i < ClientRectangle.Width; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += Convert.ToInt32(ClientRectangle.Height / 6.7);
            }

            //smoothdata = Class_QualitationSpectraLine.Smooth9(RawData);//返回九点平滑后的数据
            List<double> orgdata = new List<double>();//需要实例化
            for (int i = 0; i < RawData.Count; i++)
            {
                orgdata.Add(Convert.ToDouble(RawData[i]));
            }
            //smoothdata = Smooth5(rawdata);//返回五点平滑后的数据
            //根据平滑后的数据绘平滑后谱线图
            double smoothdatamax = orgdata.Max();
            float sizeX = ((float)picb_name.Width / orgdata.Count);
            if (picb_name == picb_4 || picb_name == picb_3)//该几个窗口图线显示过小
                sizeX = (float)(sizeX * 1);
            else if (picb_name == picb_5 || picb_name == picb_8)
                sizeX = (float)(sizeX * 1);
            else if (picb_name == picb_2)
                sizeX = (float)(sizeX * 1);
            Pen pens = new Pen(Color.Blue, 1);
            for (int i = 0; i < orgdata.Count - 1; i++)
            {
                PointF pf1 = new PointF((float)i * sizeX,
                    (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i] / smoothdatamax)));
                PointF pf2 = new PointF((float)(i + 1) * sizeX,
                    (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i + 1] / smoothdatamax)));
                g.DrawLine(pens, pf1, pf2);
            }
            //double[] step = { 0.04, 0.052, 0.031, 0.052, 0.05, 0.05, 0.08, 0.1, 0.06, 0.06, 0.1 }; //每个区段的步长
            //double[] startAng = { 14.02, 17.026, 12.016, 26.626, 37.025, 61.025, 76.04, 91.05, 104.03, 133.53, 20.55 };//起始角度
            float x, y;
            if (removeP.Count != 0)
            {
                for (int q = 1; q < peakdata.Count; q++)
                {
                    int a = 0;
                    for (int m = 0; m < removeP.Count; m++)
                    {
                        if (removeP[m] == q) a++;
                    }
                    if (a == 0)
                    {
                        double theta = Convert.ToDouble(peakdata[q][2]);
                        int position = (int)Math.Ceiling(((double)(theta - startAng[zoneNum - 1]) / step[zoneNum - 1]));
                        Font font = new Font("宋体", 10);
                        SolidBrush brush = new SolidBrush(Color.Blue);
                        x = ((float)(position * sizeX - 20));
                        y = (float)(picb_name.Height - 50 - (picb_name.Height - 50) * orgdata[position] / smoothdatamax);
                        string peak = null;
                        if (peakdata[q].Count > 8)
                            peak = peakdata[q][7] + peakdata[q][8];
                        else peak = peakdata[q][7];
                        g.DrawString(peak, font, brush, x, y);
                    }
                }
            }
            else
            {
                for (int q = 1; q < peakdata.Count; q++)
                {
                    double theta = Convert.ToDouble(peakdata[q][2]);
                    int position = (int)Math.Ceiling(((double)(theta - startAng[zoneNum - 1]) / step[zoneNum - 1]));
                    Font font = new Font("宋体", 10);
                    SolidBrush brush = new SolidBrush(Color.Blue);
                    x = ((float)(position * sizeX - 20));
                    y = (float)(picb_name.Height - 50 - (picb_name.Height - 50) * orgdata[position] / smoothdatamax);
                    string peak = null;
                    if (peakdata[q].Count > 8)
                        peak = peakdata[q][7] + peakdata[q][8];
                    else peak = peakdata[q][7];
                    g.DrawString(peak, font, brush, x, y);

                }
            }
            picb_name.Image = Bmap_2;
            g.Dispose();
        }
        /// <summary>
        /// 获得鼠标点处的坐标值，需要转换成实际数据对应的值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="zoneNum">区段值</param>
        /// <returns></returns>
        private PointF getXY(int X, int zoneNum)
        {
            PointF point = new PointF();
            float sizeX = ((float)picb_1.Width / AllData[zoneNum - 1].Count);
            float x = (float)(((X / sizeX) * step[zoneNum - 1] + startAng[zoneNum - 1]));
            int index = (int)Math.Ceiling((double)((X / sizeX)));
            float y = 0;
            if (index < AllData[zoneNum - 1].Count && index > -1)
                y = (float)(AllData[zoneNum - 1][index]);
            else if (index < 0) y = (float)(AllData[zoneNum - 1][0]);
            else y = (float)(AllData[zoneNum - 1][AllData[zoneNum - 1].Count - 1]);
            point.X = x; point.Y = y;
            return point;
        }
        /// <summary>
        /// 把鼠标捕获的坐标转换为可以识别对比的值
        /// </summary>
        /// <param name="point">鼠标坐标值</param>
        /// <param name="zoneNum">区段值</param>
        /// <returns>需要剔除的点的行号（在AllPeakDAta第二维数中）</returns>
        private void JudgeIfClickPeak(PointF point, int zoneNum,ref List<int> RemoveP_N)
        {
            //List<List<int>> removeP = new List<List<int>>();
            PointF XY = new PointF();
            XY = getXY((int)point.X, zoneNum);
            
            float sizeX = ((float)picb_1.Width / AllData[zoneNum - 1].Count);
            float max = (float)AllData[zoneNum - 1].Max();
            //float x = (float)(((point.X / sizeX) * step[zoneNum - 1] + startAng[zoneNum - 1]));
            float y = (picb_1.Height - point.Y - 20) * max / (picb_1.Height - 50); //与绘图的Y轴转换对应
            //判断点击点附近是否存在谱峰
            int index = (int)Math.Ceiling((double)((point.X / sizeX)));
            float yL, yM, yR = 0;
            int factor = 1;
            if (XY.Y / 1000 > 1) factor = 1; else if (XY.Y / 100 > 1) factor = 1; else if (XY.Y / 10 > 1) factor = 3; else if (XY.Y > 1) factor = 4; else factor = 6;
            yL=(float)(AllData[zoneNum - 1][index-factor]);
            yM = (float)(AllData[zoneNum - 1][index]);
            yR = (float)(AllData[zoneNum - 1][index + factor]);
            List<float> PeakRangeData = new List<float>();
            PeakRangeData.Add(yL); PeakRangeData.Add(yM); PeakRangeData.Add(yR);

            for (int i = 1; i < AllPeakData[zoneNum-1].Count;i++ )
            {   
                //点击点在谱峰点周围
                if ((double)XY.X +0.2 > Convert.ToDouble(AllPeakData[zoneNum-1][i][2]) && (double)XY.X - 0.2 < Convert.ToDouble(AllPeakData[zoneNum-1][i][2]))
                {    
                    //并且点击点的Y值在谱峰值附近
                    if( y > PeakRangeData.Min() && y < PeakRangeData.Max()){
                        if (RemoveP_N.Contains(i))
                        {
                            //如果存在，则把该点从列表中移除
                            int indexO = RemoveP_N.IndexOf(i);
                            RemoveP_N.RemoveAt(indexO);
                        }
                        else
                        {
                            RemoveP_N.Add(i);
                        }
                    }
                }
            }
        }
        private void picb_1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 1,ref RemoveP_1);
            List<double> rawdata1 =new List<double> ();
            List<List<string>> peakdata1=new List<List<string>> ();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\1.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\1.txt");
            DrawSmoothLine(picb_1, rawdata1, peakdata1, 1,RemoveP_1);
        }
        private void picb_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 2, ref RemoveP_2);
            List<double> rawdata1 = new List<double>();
            List<List<string>> peakdata1 = new List<List<string>>();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\2.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\2.txt");
            DrawSmoothLine(picb_2, rawdata1, peakdata1, 2, RemoveP_2);
        }
        private void picb_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 3, ref RemoveP_3);
            List<double> rawdata1 = new List<double>();
            List<List<string>> peakdata1 = new List<List<string>>();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\3.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\3.txt");
            DrawSmoothLine(picb_3, rawdata1, peakdata1, 3, RemoveP_3);
        }
        private void picb_4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 4, ref RemoveP_4);
            List<double> rawdata1 = new List<double>();
            List<List<string>> peakdata1 = new List<List<string>>();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\4.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\4.txt");
            DrawSmoothLine(picb_4, rawdata1, peakdata1, 4, RemoveP_4);
        }
        private void picb_5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 5, ref RemoveP_5);
            List<double> rawdata1 = new List<double>();
            List<List<string>> peakdata1 = new List<List<string>>();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\5.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\5.txt");
            DrawSmoothLine(picb_5, rawdata1, peakdata1, 5, RemoveP_5);
        }
        private void picb_6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 6, ref RemoveP_6);
            List<double> rawdata1 = new List<double>();
            List<List<string>> peakdata1 = new List<List<string>>();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\6.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\6.txt");
            DrawSmoothLine(picb_6, rawdata1, peakdata1,6, RemoveP_6);
        }
        private void picb_7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 7, ref RemoveP_7);
            List<double> rawdata1 = new List<double>();
            List<List<string>> peakdata1 = new List<List<string>>();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\7.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\7.txt");
            DrawSmoothLine(picb_7, rawdata1, peakdata1, 7, RemoveP_7);
        }
        private void picb_8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 8, ref RemoveP_8);
            List<double> rawdata1 = new List<double>();
            List<List<string>> peakdata1 = new List<List<string>>();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\8.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\8.txt");
            DrawSmoothLine(picb_8, rawdata1, peakdata1, 8, RemoveP_8);
        }
        private void picb_9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 9, ref RemoveP_9);
            List<double> rawdata1 = new List<double>();
            List<List<string>> peakdata1 = new List<List<string>>();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\9.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\9.txt");
            DrawSmoothLine(picb_9, rawdata1, peakdata1, 9, RemoveP_9);
        }
        private void picb_10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 10, ref RemoveP_10);
            List<double> rawdata1 = new List<double>();
            List<List<string>> peakdata1 = new List<List<string>>();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\10.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\10.txt");
            DrawSmoothLine(picb_10, rawdata1, peakdata1, 10, RemoveP_10);
        }
        private void picb_11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JudgeIfClickPeak(new PointF(e.X, e.Y), 11, ref RemoveP_11);
            List<double> rawdata1 = new List<double>();
            List<List<string>> peakdata1 = new List<List<string>>();
            string path = XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\peak\\11.txt";
            Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata1);
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + SampleInfo[2] + "\\" + SampleInfo[1] + "\\11.txt");
            DrawSmoothLine(picb_11, rawdata1, peakdata1, 11, RemoveP_11);
        }
    


    }
}
