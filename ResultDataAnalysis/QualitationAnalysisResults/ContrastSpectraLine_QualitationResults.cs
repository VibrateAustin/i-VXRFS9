using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults
{
    public partial class ContrastSpectraLine_QualitationResults : Form
    {
        public static ContrastSpectraLine_QualitationResults pCurrentWin = null;
        public ContrastSpectraLine_QualitationResults()
        {
            InitializeComponent();
            pCurrentWin = this;
        }
        //窗口图像背景虚线的绘制
        public List<double> orgdata;//原始数据
        public int zoneNum = 1;//区段值
        public string[,] Data = new string[20, 15];//存放该化合物对应的各区段参数列表值
        public string[,] Data2 = new string[20, 15];
        public string verify = "default";
        public int ifAddSampleComtrast = 1;
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
                i += Convert.ToInt32(ClientRectangle.Width / 8.15);
            }

            for (int j = 0; j < ClientRectangle.Height; )
            {
                for (int i = 0; i < ClientRectangle.Width; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += Convert.ToInt32(ClientRectangle.Height / 8.6);
            }
            picb_name.Image = Bmap_2;
            g.Dispose();
        }
        //private void paint_line(PictureBox picb_name,List<double> RawData,int zoneNum,Color color)
        //{
        //    Bitmap Bmap_2 = new Bitmap(picb_name.Width, picb_name.Height);
        //    Graphics g = Graphics.FromImage(Bmap_2);
        //    Pen pen = new Pen(Color.Black, 2);
        //    PointF start = new PointF(0, 0);
        //    PointF end = new PointF(picb_name.ClientRectangle.X + picb_name.ClientRectangle.Width, picb_name.ClientRectangle.Y + picb_name.ClientRectangle.Height);
        //    g.DrawRectangle(pen, picb_name.ClientRectangle.X, picb_name.ClientRectangle.Y,
        //        picb_name.ClientRectangle.X + picb_name.ClientRectangle.Width,
        //        picb_name.ClientRectangle.Y + picb_name.ClientRectangle.Height);
        //    Pen myPen = new Pen(Color.Gray, 1);
        //    for (int i = 0; i < ClientRectangle.Width; )
        //    {
        //        for (int j = 0; j < picb_name.ClientRectangle.Height; )
        //        {
        //            g.DrawLine(myPen, new Point(i, j), new Point(i, j + 5));
        //            j += 10;
        //        }
        //        i += Convert.ToInt32(ClientRectangle.Width / 8.15);
        //    }

        //    for (int j = 0; j < ClientRectangle.Height; )
        //    {
        //        for (int i = 0; i < ClientRectangle.Width; )
        //        {
        //            g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
        //            i += 10;
        //        }
        //        j += Convert.ToInt32(ClientRectangle.Height / 8.6);
        //    }
        //    //orgdata = Class_QualitationSpectraLine.Smooth9(RawData);//返回九点平滑后的数据
        //    orgdata = new List<double>();//需要实例化
        //    for (int i = 0; i < RawData.Count; i++)
        //    {
        //        orgdata.Add(Convert.ToDouble(RawData[i]));
        //    }
        //    //orgdata = Smooth5(rawdata);//返回五点平滑后的数据
        //    //根据平滑后的数据绘平滑后谱线图
        //    double orgdatamax = orgdata.Max();
        //    float sizeX = ((float)picb_name.Width / orgdata.Count);
        //    if (zoneNum == 2 || zoneNum == 8)//该几个窗口图线显示过小
        //        sizeX = (float)(sizeX * 1);
        //    else 
        //        sizeX = (float)(sizeX * 1);
        //    Pen pens = new Pen(color, 1);
        //    for (int i = 0; i < orgdata.Count - 1; i++)
        //    {
        //        PointF pf1 = new PointF((float)i * sizeX,
        //            (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i] / orgdatamax)));
        //        PointF pf2 = new PointF((float)(i + 1) * sizeX,
        //            (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i + 1] / orgdatamax)));
        //        g.DrawLine(pens, pf1, pf2);
        //    }
        //    picb_name.Image = Bmap_2;
        //    g.Dispose();
        //}
        //窗口中同时显示多条谱线
        //private void paint_multiLine(PictureBox picb_name, List<List<double>> RawData, int zoneNum)
        //{
        //    Bitmap Bmap_2 = new Bitmap(picb_name.Width, picb_name.Height);
        //    Graphics g = Graphics.FromImage(Bmap_2);
        //    Pen pen = new Pen(Color.Black, 2);
        //    PointF start = new PointF(0, 0);
        //    PointF end = new PointF(picb_name.ClientRectangle.X + picb_name.ClientRectangle.Width, picb_name.ClientRectangle.Y + picb_name.ClientRectangle.Height);
        //    g.DrawRectangle(pen, picb_name.ClientRectangle.X, picb_name.ClientRectangle.Y,
        //        picb_name.ClientRectangle.X + picb_name.ClientRectangle.Width,
        //        picb_name.ClientRectangle.Y + picb_name.ClientRectangle.Height);
        //    Pen myPen = new Pen(Color.Gray, 1);
        //    for (int i = 0; i < ClientRectangle.Width; )
        //    {
        //        for (int j = 0; j < picb_name.ClientRectangle.Height; )
        //        {
        //            g.DrawLine(myPen, new Point(i, j), new Point(i, j + 5));
        //            j += 10;
        //        }
        //        i += Convert.ToInt32(ClientRectangle.Width / 8.15);
        //    }

        //    for (int j = 0; j < ClientRectangle.Height; )
        //    {
        //        for (int i = 0; i < ClientRectangle.Width; )
        //        {
        //            g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
        //            i += 10;
        //        }
        //        j += Convert.ToInt32(ClientRectangle.Height / 8.6);
        //    }
        //    //orgdata = Class_QualitationSpectraLine.Smooth9(RawData);//返回九点平滑后的数据
        //    orgdata = new List<double>();//需要实例化
        //    int colorN = 0;
        //    Color[] color = { Color.Blue, Color.Red, Color.Orange, Color.Purple,Color.Green, Color.Yellow, Color.Black, Color.Beige, Color.Pink, Color.PowderBlue, Color.PaleGreen };
        //    for (int n = 0; n < RawData.Count; n++)
        //    {
        //        orgdata.Clear();
        //        for(int i=0;i<RawData[n].Count;i++)
        //        {
        //            orgdata.Add(Convert.ToDouble(RawData[n][i]));
        //        }
        //        //orgdata = Smooth5(rawdata);//返回五点平滑后的数据
        //        //根据平滑后的数据绘平滑后谱线图
        //        double orgdatamax = orgdata.Max();
        //        float sizeX = ((float)picb_name.Width / orgdata.Count);
        //        if (zoneNum == 2 || zoneNum == 8)//该几个窗口图线显示过小
        //            sizeX = (float)(sizeX * 1);
        //        else
        //            sizeX = (float)(sizeX * 1);
        //        if (colorN > 10) colorN = 0;
        //        Pen pens = new Pen(color[colorN], 1);
        //        for (int i = 0; i < orgdata.Count - 1; i++)
        //        {
        //            PointF pf1 = new PointF((float)i * sizeX,
        //                (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i] / orgdatamax)));
        //            PointF pf2 = new PointF((float)(i + 1) * sizeX,
        //                (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i + 1] / orgdatamax)));
        //            g.DrawLine(pens, pf1, pf2);
        //        }
        //        colorN++;
        //    }
        //    picb_name.Image = Bmap_2;
        //    g.Dispose();
        //}
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        public List<String> sampleinfo;
        //public List<String> sampleinfo2;
        public List<List<String>> sampleinfoList=new List<List<String>>();
        //public string[,] SampleInfo = new string[20, 2];//把父窗口加载的数据放在数组中
        private void ContrastSpectraLine_QualitationResults_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgv_contrastspectraline.ColumnCount = 15;
                dgv_contrastspectraline.ColumnHeadersVisible = true;
               
                    // MessageBox.Show("show tb_wdxrfbar success");
                    dgv_contrastspectraline.Columns[0].HeaderCell.Value = "序号";//显示数据表抬头的别名
                    dgv_contrastspectraline.Columns[1].HeaderCell.Value = "样品名";
                    dgv_contrastspectraline.Columns[2].HeaderCell.Value = "谱线区段";
                    dgv_contrastspectraline.Columns[3].HeaderCell.Value = "显示谱线";//显示数据表抬头的别名
                    dgv_contrastspectraline.Columns[4].HeaderCell.Value = "显示峰位";
                    dgv_contrastspectraline.Columns[5].HeaderCell.Value = "添加kcps";//显示数据表抬头的别名
                    dgv_contrastspectraline.Columns[6].HeaderCell.Value = "乘积";
                    dgv_contrastspectraline.Columns[7].HeaderCell.Value = "KV";
                    dgv_contrastspectraline.Columns[8].HeaderCell.Value = "mA";//显示数据表抬头的别名
                    dgv_contrastspectraline.Columns[9].HeaderCell.Value = "X-靶";
                    dgv_contrastspectraline.Columns[10].HeaderCell.Value = "准直器";//显示数据表抬头的别名
                    dgv_contrastspectraline.Columns[11].HeaderCell.Value = "过滤器";
                    dgv_contrastspectraline.Columns[12].HeaderCell.Value = "探测器";
                    dgv_contrastspectraline.Columns[13].HeaderCell.Value = "开始角";//显示数据表抬头的别名
                    dgv_contrastspectraline.Columns[14].HeaderCell.Value = "终止角";
                    dgv_contrastspectraline.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
                    btn_merge.Enabled = false;
                    btn_deduct.Enabled = false;
                    btn_cancle.Enabled = false;
                    //把数据放在列表中
                    string path = XRF_function.QualitationApplicationPath + "\\" + sampleinfo[2] + "\\" + sampleinfo[1] + "\\" + sampleinfo[1] + ".txt";
                    Class_QualitationSpectraLine.ReadTxtToArray(path, ref Data);
                    int index = this.dgv_contrastspectraline.Rows.Add();
                    for(int i=0;i<Data.GetLength(1);i++){
                        dgv_contrastspectraline.Rows[index].Cells[i].Value = Data[1,i];
                    }
                    sampleinfoList.Add(sampleinfo);
                    cbox_scanarea.Text = zoneNum.ToString();
                paint(picb_contrast);
                //打开窗口默认显示第一区段谱图
                List<double> rawdata1 = new List<double>();
                rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfo[2] + "\\" + sampleinfo[1] + "\\"+zoneNum+".txt");
                List<List<double>> iData=new List<List<double>> ();
                ListTransfromArray(rawdata1, ref iData);
                D_paint_multiLine(picb_contrast, iData,zoneNum);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picb_contrast_MouseMove(object sender, MouseEventArgs e)
        {
            lb_x.Text = Convert.ToString(e.X);
            lb_y.Text = Convert.ToString(280 - e.Y);
        }
        /// <summary>
        /// 区段值改变，列表中的值和谱图框中显示的图对应改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbox_scanarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ScanArea=Convert.ToInt16(cbox_scanarea.Text);
            zoneNum = ScanArea;
            if (verify == "扣背景")
            {
                List<double> rawdata = new List<double>();
                List<double> bgData = new List<double>();
                rawdata = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\" + zoneNum + ".txt");
                for (int j = 0; j < rawdata.Count; j++)
                {
                    bgData.Add(rawdata[j] - 5);//假设背景点都为5kcps
                }
                this.DADFreshForm(bgData);
            }
            else if (verify == "default")
            {
                List<double> rawdata = new List<double>();
                List<double> bgData = new List<double>();
                rawdata = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\" + zoneNum + ".txt");
                for (int j = 0; j < rawdata.Count; j++)
                {
                    bgData.Add(rawdata[j]);
                }
                this.DADFreshForm(bgData);
            }
            else if (verify == "相减")
            {
                List<double> rawdata1 = new List<double>();
                List<double> rawdata2 = new List<double>();
                List<double> minusData = new List<double>();
                rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\" + zoneNum + ".txt");
                if(sampleinfoList.Count>1)
                    rawdata2 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[1][2] + "\\" + sampleinfoList[1][1] + "\\" + zoneNum + ".txt");
                int Mincount = 0;int Maxcount=0;
                if (rawdata1.Count > rawdata2.Count) {
                    Mincount = rawdata2.Count;
                    Maxcount=rawdata1.Count;
                    for (int j = 0; j < Mincount; j++)
                    {
                        minusData.Add(rawdata1[j] - rawdata2[j]);
                    }
                    for (int j = Mincount; j < Maxcount; j++)
                    {
                        minusData.Add(rawdata1[j]);
                    }
                }
                else {
                    Mincount = rawdata1.Count;
                    Maxcount=rawdata2.Count;
                    for (int j = 0; j < Mincount; j++)
                    {
                        minusData.Add(rawdata1[j] - rawdata2[j]);
                    }
                    for (int j = Mincount; j < Maxcount; j++)
                    {
                        minusData.Add(0-rawdata2[j]);
                    }
                }
                
                this.MinusFreshForm(minusData);
            }
            else if (verify == "合并")
            {
                List<double> rawdata1 = new List<double>();
                List<double> rawdata2 = new List<double>();
                List<double> minusData = new List<double>();
                rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\" + zoneNum + ".txt");
                if(sampleinfoList.Count>1)
                    rawdata2 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[1][2] + "\\" + sampleinfoList[1][1] + "\\" + zoneNum + ".txt");
                int Mincount = 0; int Maxcount = 0;
                if (rawdata1.Count > rawdata2.Count)
                {
                    Mincount = rawdata2.Count;
                    Maxcount = rawdata1.Count;
                    for (int j = 0; j < Mincount; j++)
                    {
                        minusData.Add(rawdata1[j] + rawdata2[j]);
                    }
                    for (int j = Mincount; j < Maxcount; j++)
                    {
                        minusData.Add(rawdata1[j]);
                    }
                }
                else
                {
                    Mincount = rawdata1.Count;
                    Maxcount = rawdata2.Count;
                    for (int j = 0; j < Mincount; j++)
                    {
                        minusData.Add(rawdata1[j] + rawdata2[j]);
                    }
                    for (int j = Mincount; j < Maxcount; j++)
                    {
                        minusData.Add(rawdata2[j]);
                    }
                }
                this.DADFreshForm(minusData);
            }
        }

        private void btn_addcontrastsample_Click(object sender, EventArgs e)
        {
            ifAddSampleComtrast = 0;
            QualitationAnalysisResult qualiAnaResForm = new QualitationAnalysisResult();
            qualiAnaResForm.checkIfFormFromAddContrastSample=1;
            qualiAnaResForm.AppInfo = sampleinfo;
            qualiAnaResForm.Show();
        }
        public void AddSampleRefreshForm(List<String> sampinfo)
        {
            try
            {
                dgv_contrastspectraline.Rows.Clear();
                if (ifAddSampleComtrast == 0) btn_addcontrastsample.Enabled = false;//只能添加一个样品进行比较
                else btn_addcontrastsample.Enabled = true;
                btn_merge.Enabled = true;
                btn_deduct.Enabled = true;
                btn_cancle.Enabled = true;
                cbox_scanarea.Text = zoneNum.ToString();
                //把数据放在列表中
                
                sampleinfoList.Add(sampinfo);
                string path = XRF_function.QualitationApplicationPath + "\\" + sampinfo[2] + "\\" + sampinfo[1] + "\\" + sampinfo[1] + ".txt";
                Class_QualitationSpectraLine.ReadTxtToArray(path, ref Data2);
                int index = this.dgv_contrastspectraline.Rows.Add();
                for (int i = 0; i < Data.GetLength(1); i++)
                {
                    dgv_contrastspectraline.Rows[index].Cells[i].Value = Data[zoneNum, i];
                }
                int index1 = this.dgv_contrastspectraline.Rows.Add();
                for (int i = 0; i < Data2.GetLength(1); i++)
                {
                    dgv_contrastspectraline.Rows[index1].Cells[i].Value = Data2[zoneNum, i];
                }
               
                paint(picb_contrast);
                //打开窗口默认显示第一区段谱图
                List<double> rawdata = new List<double>();
                rawdata = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\" + zoneNum + ".txt");
                List<double> rawdata2 = new List<double>();
                rawdata2 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampinfo[2] + "\\" + sampinfo[1] + "\\" + zoneNum + ".txt");
                List<List<double>> data = new List<List<double>>();
                this.ListTransfromArray(rawdata,ref data);
                this.ListTransfromArray(rawdata2,ref data);
                D_paint_multiLine(picb_contrast, data, zoneNum);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 一维列表添加到二维列表中
        /// </summary>
        /// <param name="listdata"></param>
        /// <param name="data"></param>
        private void ListTransfromArray(List<double> listdata,ref List<List<double>> data)
        {
            List<double> midData = new List<double>();
            for (int k = 0; k < listdata.Count;k++ )
            {
                midData.Add(listdata[k]);
            }
            data.Add(midData);
        }
        
        private void btn_deductBg_Click(object sender, EventArgs e)
        {
            verify = "扣背景";
            //背景点数据的获得  ？？ 需要修改
            List<double> rawdata = new List<double>();
            List<double> bgData = new List<double>();
            rawdata = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\" + zoneNum + ".txt");
            for (int j = 0; j < rawdata.Count; j++)
            {
                bgData.Add(rawdata[j] - 20);//假设背景点都为20cps
            }

           // string temppath = XRF_function.QuantitationApplicationTempPath + "\\deductBg_" + sampleinfoList[0][1] + "\\" + zoneNum + ".txt";
           // //FileStream savedgvDataToTempfile = new FileStream(temppath, FileMode.Append, FileAccess.Write);
           // //StreamWriter savedgvDataSW = new StreamWriter(savedgvDataToTempfile, Encoding.Default);
           // //把DGV添加添加剂化合物表中数据保存txt
           //UtilityClass.CreateFile(temppath, true);
           // StreamWriter saveSW = new StreamWriter(temppath, false, Encoding.Default);
           // saveSW.WriteLine("添加剂化合物表");

            this.DADFreshForm(bgData);
        }
        /// <summary>
        /// 
        /// 清空二维数组
        /// </summary>
        /// <param name="str"></param>
        public void emptyArray(ref string[,] str)
        {
            for (int i = 0; i < str.GetLength(0); i++)
            {
                for (int j = 0; j < str.GetLength(1); j++)
                {
                    str[i, j] = null;
                }
            }

        }
        /// <summary>
        /// 扣除背景，相减，合并  三者更新窗口
        /// </summary>
        /// <param name="mid_Data">传入扣除背景，相减，合并第三者的数据</param>
        public void DADFreshForm(List<double> mid_Data=null)
        {
            try
            {
                dgv_contrastspectraline.Rows.Clear();
                string path = null;
                string[,] tempData = new string[20, 15];
                for (int m = 0; m < sampleinfoList.Count; m++)
                {
                    path = XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[m][2] + "\\" + sampleinfoList[m][1] + "\\" + sampleinfoList[m][1] + ".txt";
                    Class_QualitationSpectraLine.ReadTxtToArray(path, ref tempData);
                    int index1 = this.dgv_contrastspectraline.Rows.Add();
                    for (int i = 0; i < tempData.GetLength(1); i++)
                    {
                        dgv_contrastspectraline.Rows[index1].Cells[i].Value = tempData[zoneNum, i];
                    }
                    this.emptyArray(ref tempData);
                    path = null;
                }
                paint(picb_contrast);
                //打开窗口默认显示第一区段谱图
                List<double> rawdata = new List<double>();
                List<List<double>> data = new List<List<double>>();
                for (int i = 0; i < sampleinfoList.Count; i++)
                {
                    rawdata = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[i][2] + "\\" + sampleinfoList[i][1] + "\\" + zoneNum + ".txt");
                    this.ListTransfromArray(rawdata, ref data);
                    rawdata.Clear();
                }
                if(mid_Data!=null)
                    this.ListTransfromArray(mid_Data, ref data);
                rawdata.Clear();

                D_paint_multiLine(picb_contrast, data, zoneNum);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_deduct_Click(object sender, EventArgs e)
        {
            verify = "相减";
            List<double> rawdata1 = new List<double>();
            List<double> rawdata2 = new List<double>();
            List<double> minusData = new List<double>();
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\" + zoneNum + ".txt");
            if(sampleinfoList.Count>1)
                rawdata2 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[1][2] + "\\" + sampleinfoList[1][1] + "\\" + zoneNum + ".txt");
            int Mincount = 0; int Maxcount = 0;
            if (rawdata1.Count > rawdata2.Count)
            {
                Mincount = rawdata2.Count;
                Maxcount = rawdata1.Count;
                for (int j = 0; j < Mincount; j++)
                {
                    minusData.Add(rawdata1[j] - rawdata2[j]);
                }
                for (int j = Mincount; j < Maxcount; j++)
                {
                    minusData.Add(rawdata1[j]);
                }
            }
            else
            {
                Mincount = rawdata1.Count;
                Maxcount = rawdata2.Count;
                for (int j = 0; j < Mincount; j++)
                {
                    minusData.Add(rawdata1[j] - rawdata2[j]);
                }
                for (int j = Mincount; j < Maxcount; j++)
                {
                    minusData.Add(0 - rawdata2[j]);
                }
            }
            this.MinusFreshForm(minusData);
        }
        public void MinusFreshForm(List<double> mid_Data)
        {
            try
            {
                dgv_contrastspectraline.Rows.Clear();
                string path = null;
                string[,] tempData = new string[20, 15];
                for (int m = 0; m < sampleinfoList.Count; m++)
                {
                    path = XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[m][2] + "\\" + sampleinfoList[m][1] + "\\" + sampleinfoList[m][1] + ".txt";
                    Class_QualitationSpectraLine.ReadTxtToArray(path, ref tempData);
                    int index1 = this.dgv_contrastspectraline.Rows.Add();
                    for (int i = 0; i < tempData.GetLength(1); i++)
                    {
                        dgv_contrastspectraline.Rows[index1].Cells[i].Value = tempData[zoneNum, i];
                    }
                    this.emptyArray(ref tempData);
                    path = null;
                }
                paint(picb_contrast);
                //打开窗口默认显示第一区段谱图
                List<double> rawdata = new List<double>();
                List<List<double>> data = new List<List<double>>();
                for (int i = 0; i < sampleinfoList.Count; i++)
                {
                    rawdata = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[i][2] + "\\" + sampleinfoList[i][1] + "\\" + zoneNum + ".txt");
                    this.ListTransfromArray(rawdata, ref data);
                    rawdata.Clear();
                }
               // List<List<double>> data1 = new List<List<double>>();
                this.ListTransfromArray(mid_Data, ref data);
                rawdata.Clear();

               // paint_multiLine(picb_contrast, data, zoneNum);
                D_paint_multiLine(picb_contrast, data, zoneNum);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 绘制谱线图 主程序
        /// </summary>
        /// <param name="picb_name"></param>
        /// <param name="RawData"></param>
        /// <param name="zoneNum"></param>
        private void D_paint_multiLine(PictureBox picb_name, List<List<double>> RawData, int zoneNum)
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
                i += Convert.ToInt32(ClientRectangle.Width / 8.15);
            }

            for (int j = 0; j < ClientRectangle.Height; )
            {
                for (int i = 0; i < ClientRectangle.Width; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += Convert.ToInt32(ClientRectangle.Height / 8.6);
            }
            //orgdata = Class_QualitationSpectraLine.Smooth9(RawData);//返回九点平滑后的数据
            orgdata = new List<double>();//需要实例化
            int colorN = 0;
            Color[] color = { Color.Blue, Color.Red, Color.Orange, Color.Purple, Color.Green, Color.Yellow, Color.Black, Color.Beige, Color.Pink, Color.PowderBlue, Color.PaleGreen };
            double[] step = { 0.04,0.052,0.031,0.052,0.05,0.05,0.08,0.1,0.06,0.06,0.1}; //每个区段的步长
            double[] startAng = {14.02,17.026,12.016,26.626,37.025,61.025,76.04,91.05,104.03,133.53,20.55};//起始角度
            for (int n = 0; n < RawData.Count; n++)
            {
                orgdata.Clear();
                for (int i = 0; i < RawData[n].Count; i++)
                {
                    orgdata.Add(Convert.ToDouble(RawData[n][i]));
                }
                //orgdata = Smooth5(rawdata);//返回五点平滑后的数据
                //根据平滑后的数据绘平滑后谱线图
                double orgdatamax = orgdata.Max();
                double orgdatamin = orgdata.Min();
                double rate = (Math.Abs(orgdatamin)+orgdatamax);
                float sizeX = ((float)picb_name.Width / orgdata.Count);
                if (zoneNum == 2 || zoneNum == 3)//该几个窗口图线显示过小
                    sizeX = (float)(sizeX * 1);
                else if (zoneNum == 5 || zoneNum == 8)
                    sizeX = (float)(sizeX * 1);
                if (colorN >10) colorN = 0;
                Pen pens = new Pen(color[colorN], 1);
                for (int i = 0; i < orgdata.Count - 1; i++)
                {
                    PointF pf1,pf2;
                    if (verify == "相减")
                    {
                        pf1 = new PointF((float)i * sizeX, (float)((picb_name.Height  +20 - (picb_name.Height - 50) * orgdata[i] / orgdatamax))/2);
                        pf2 = new PointF((float)(i + 1) * sizeX,
                               (float)((picb_name.Height +20 - (picb_name.Height - 50) * orgdata[i + 1] / orgdatamax))/2);
                    }
                    else
                    {
                        pf1 = new PointF((float)i * sizeX, (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i] / orgdatamax)));
                        pf2 = new PointF((float)(i + 1) * sizeX,
                               (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i + 1] / orgdatamax)));
                    }
                    g.DrawLine(pens, pf1, pf2);
                }
                //在谱图框中写入元素符号
                if(n<sampleinfoList.Count){
                    List<List<string>> peakdata = new List<List<string>>();
                    string path= XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[n][2] + "\\" + sampleinfoList[n][1] + "\\peak\\" + zoneNum + ".txt";
                    Class_QualitationSpectraLine.ReadTxtToList(path,ref peakdata);
                    float x,y;
                    for (int q = 1; q < peakdata.Count; q++)
                    {
                        double theta = Convert.ToDouble(peakdata[q][2]);
                        int position = (int)Math.Ceiling(((double)(theta - startAng[zoneNum-1]) / step[zoneNum-1]));
                        Font font = new Font("宋体", 10);
                        SolidBrush brush = new SolidBrush(color[colorN]);
                        x = ((float)(position*sizeX-20));
                        if (verify == "相减") y = (float)(picb_name.Height - 45 - (picb_name.Height - 50) * orgdata[position] / orgdatamax)/2;
                        else  y = (float)(picb_name.Height - 45 - (picb_name.Height - 50) * orgdata[position] / orgdatamax);
                        string peak = null;
                        if (peakdata[q].Count>8)
                            peak = peakdata[q][7] + peakdata[q][8];
                        else peak = peakdata[q][7];
                        g.DrawString(peak, font, brush, x, y);
                    }
                    PointF pointSamp = new PointF((float)(n+1)*150,2);
                    g.DrawString(sampleinfoList[n][1], new Font("宋体",15),new SolidBrush(color[colorN]), pointSamp);
                }
                colorN++;
            }
            picb_name.Image = Bmap_2;
            g.Dispose();
        }
        private void btn_merge_Click(object sender, EventArgs e)
        {
            verify = "合并";
            List<double> rawdata1 = new List<double>();
            List<double> rawdata2 = new List<double>();
            List<double> minusData = new List<double>();
            rawdata1 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\" + zoneNum + ".txt");
            if(sampleinfoList.Count>1)
                rawdata2 = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[1][2] + "\\" + sampleinfoList[1][1] + "\\" + zoneNum + ".txt");
            int Mincount = 0; int Maxcount = 0;
            if (rawdata1.Count > rawdata2.Count)
            {
                Mincount = rawdata2.Count;
                Maxcount = rawdata1.Count;
                for (int j = 0; j < Mincount; j++)
                {
                    minusData.Add(rawdata1[j] + rawdata2[j]);
                }
                for (int j = Mincount; j < Maxcount; j++)
                {
                    minusData.Add(rawdata1[j]);
                }
            }
            else
            {
                Mincount = rawdata1.Count;
                Maxcount = rawdata2.Count;
                for (int j = 0; j < Mincount; j++)
                {
                    minusData.Add(rawdata1[j] + rawdata2[j]);
                }
                for (int j = Mincount; j < Maxcount; j++)
                {
                    minusData.Add(rawdata2[j]);
                }
            }
            this.DADFreshForm(minusData);
        }

        private void btn_cancle_Click(object sender, EventArgs e) //删除按钮
        {
            if (dgv_contrastspectraline.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dgvR in dgv_contrastspectraline.SelectedRows)
                {
                    if (dgvR.IsNewRow == false && dgv_contrastspectraline.CurrentRow.Index > 0)
                    {
                        dgv_contrastspectraline.Rows.Remove(dgvR);
                    }
                }
                //谱图框需要实时删除对应的谱图
                int index = 0;
               /*   List<List<string>> SampleData = new List<List<string>>();
                 List<string> temdata;
                 for (int i = 0; i < dgv_contrastspectraline.Rows.Count; i++)
                 {
                     temdata = new List<string>();
                     temdata.Add(dgv_contrastspectraline.Rows[i].Cells[1].Value.ToString());
                     temdata.Add(dgv_contrastspectraline.Rows[i].Cells[2].Value.ToString());
                     SampleData.Add(temdata);
                     temdata.Clear();
                 }
                 for (int i = 0; i < SampleData.Count; i++)
                 {
                     if (SampleData[0][0] != SampleData[i][0])
                         index = 1;
                 }*/
                    string samplename = dgv_contrastspectraline.Rows[0].Cells[1].Value.ToString();
                    List<string> temdata = new List<string>();
                    List<string> temName = new List<string>();
                    int rowsNum = dgv_contrastspectraline.Rows.Count - 1;
                    if(sampleinfoList.Count>1) 
                        rowsNum=dgv_contrastspectraline.Rows.Count - 2;
                    for (int i = 0; i <rowsNum ; i++)
                    {
                        temdata.Add(dgv_contrastspectraline.Rows[i].Cells[2].Value.ToString());
                    }
                    for (int i = 0; i < dgv_contrastspectraline.Rows.Count - 1; i++)
                    {
                        temName.Add(dgv_contrastspectraline.Rows[i].Cells[1].Value.ToString());
                    }
                    for (int i = 0; i < temName.Count;i++ )
                        if (temName[i]!=samplename) index = 1;
                    if (index == 0)
                    {
                        for (int j = sampleinfoList.Count; j > 1; j--)
                            sampleinfoList.RemoveAt(j - 1);
                    }
                    if (dgv_contrastspectraline.Rows.Count == 2)
                    {
                        ifAddSampleComtrast = 1;
                        verify = "default";
                        btn_addcontrastsample.Enabled = true;
                        btn_deduct.Enabled = false;
                        btn_merge.Enabled = false;
                        
                    }
                    if (dgv_contrastspectraline.Rows.Count == 2)
                    {
                        DADFreshForm();
                    }
                    else
                    {
                        //绘制剩余区段谱图
                        List<double> rawdata = new List<double>();
                        List<List<double>> data = new List<List<double>>();
                        List<int> zone = new List<int>();
                        for (int i = 0; i < temdata.Count; i++)
                        {
                            rawdata = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\" + temdata[i] + ".txt");
                            this.ListTransfromArray(rawdata, ref data);
                            zone.Add(Convert.ToInt16(temdata[i]));
                            rawdata.Clear();
                        }
                        if (dgv_contrastspectraline.Rows.Count == 3 && sampleinfoList.Count > 1)//当删除到第二条谱线时，需判断列表是否存在第二个样品，有就显示谱线
                        {
                            rawdata = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[1][2] + "\\" + sampleinfoList[1][1] + "\\" + zoneNum + ".txt");
                            this.ListTransfromArray(rawdata, ref data);
                            zone.Add(zoneNum);
                            rawdata.Clear();
                        }
                        paint_AllLine(picb_contrast, data, zone);
                    }
            }
            else
            {
                MessageBox.Show("请选择要删除的行！");
            }
        }

        private void btn_showAllSpectraLine_Click(object sender, EventArgs e)  //显示所有区段谱图按钮
        {
            verify = "default";
            btn_cancle.Enabled = true;
            dgv_contrastspectraline.Rows.Clear();
            string path = null;
            string[,] tempData = new string[20, 15];
            for (int m = 0; m < sampleinfoList.Count; m++)
            {
                path = XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[m][2] + "\\" + sampleinfoList[m][1] + "\\" + sampleinfoList[m][1] + ".txt";
                Class_QualitationSpectraLine.ReadTxtToArray(path, ref tempData);
                if (m == 0)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        int jx = this.dgv_contrastspectraline.Rows.Add();
                        for (int i = 0; i < tempData.GetLength(1); i++)
                        {
                            dgv_contrastspectraline.Rows[jx].Cells[i].Value = tempData[j+1, i];
                        }
                    }
                }
                else
                {
                    int index1 = this.dgv_contrastspectraline.Rows.Add();
                    for (int i = 0; i < tempData.GetLength(1); i++)
                    {
                        dgv_contrastspectraline.Rows[index1].Cells[i].Value = tempData[zoneNum, i];
                    }
                }
                this.emptyArray(ref tempData);
                path = null;
            }
            //绘制11区段谱图
            List<double> rawdata = new List<double>();
            List<List<double>> data = new List<List<double>>();
            List<int> zone =new List<int> ();
            for (int i = 1; i < 12; i++)
            {
                rawdata = Class_QualitationSpectraLine.ReadDataFromTxt2(XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\" + i + ".txt");
                this.ListTransfromArray(rawdata, ref data);
                zone.Add(i);
                rawdata.Clear();
            }
            
            paint_AllLine(picb_contrast, data, zone);

        }
        private void paint_AllLine(PictureBox picb_name, List<List<double>> RawData, List<int> zone)
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
                i += Convert.ToInt32(ClientRectangle.Width / 8.15);
            }

            for (int j = 0; j < ClientRectangle.Height; )
            {
                for (int i = 0; i < ClientRectangle.Width; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += Convert.ToInt32(ClientRectangle.Height / 8.6);
            }
            //orgdata = Class_QualitationSpectraLine.Smooth9(RawData);//返回九点平滑后的数据
            orgdata = new List<double>();//需要实例化
            int colorN = 0;
            Color[] color = { Color.Blue, Color.Red, Color.Orange, Color.Purple, Color.Green, Color.Yellow, Color.Black, Color.Beige, Color.Pink, Color.PowderBlue, Color.PaleGreen };
            double[] step = { 0.04, 0.052, 0.031, 0.052, 0.05, 0.05, 0.08, 0.1, 0.06, 0.06, 0.1 }; //每个区段的步长
            double[] startAng = { 14.02, 17.026, 12.016, 26.626, 37.025, 61.025, 76.04, 91.05, 104.03, 133.53, 20.55 };//起始角度
            for (int n = 0; n < RawData.Count; n++)
            {
                orgdata.Clear();
                for (int i = 0; i < RawData[n].Count; i++)
                {
                    orgdata.Add(Convert.ToDouble(RawData[n][i]));
                }
                //orgdata = Smooth5(rawdata);//返回五点平滑后的数据
                //根据平滑后的数据绘平滑后谱线图
                double orgdatamax = orgdata.Max();
                double orgdatamin = orgdata.Min();
                double rate = (Math.Abs(orgdatamin) + orgdatamax);
                float sizeX = ((float)picb_name.Width / orgdata.Count);
               /* if (zoneNum == 2 || zoneNum == 3)//该几个窗口图线显示过小
                    sizeX = (float)(sizeX * 1);
                else if (zoneNum == 5 || zoneNum == 8)
                    sizeX = (float)(sizeX * 1);*/
                if (colorN > 10) colorN = 0;
                Pen pens = new Pen(color[colorN], 1);
                for (int i = 0; i < orgdata.Count - 1; i++)
                {
                    PointF pf1, pf2;
                    
                        pf1 = new PointF((float)i * sizeX, (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i] / orgdatamax)));
                        pf2 = new PointF((float)(i + 1) * sizeX,
                               (float)((picb_name.Height - 20 - (picb_name.Height - 50) * orgdata[i + 1] / orgdatamax)));
                    
                    g.DrawLine(pens, pf1, pf2);
                }
                //在谱图框中写入元素符号
                
                    List<List<string>> peakdata = new List<List<string>>();
                    string path = path = XRF_function.QualitationApplicationPath + "\\" + sampleinfoList[0][2] + "\\" + sampleinfoList[0][1] + "\\peak\\" + zone[n] + ".txt";
                    Class_QualitationSpectraLine.ReadTxtToList(path, ref peakdata);
                    float x, y;
                    for (int q = 1; q < peakdata.Count; q++)
                    {
                        double theta = Convert.ToDouble(peakdata[q][2]);
                        int position = (int)Math.Ceiling(((double)(theta - startAng[zone[n] - 1]) / step[zone[n] - 1]));
                        Font font = new Font("宋体", 10);
                        SolidBrush brush = new SolidBrush(color[colorN]);
                        x = ((float)(position * sizeX - 20));
                        y = (float)(picb_name.Height - 45 - (picb_name.Height - 40) * orgdata[position] / orgdatamax);
                        string peak = null;
                        if (peakdata[q].Count > 8)
                            peak = peakdata[q][7] + peakdata[q][8];
                        else peak = peakdata[q][7];
                        g.DrawString(peak, font, brush, x, y);
                    }
                colorN++;
            }
            PointF pointSamp = new PointF((float)120, 2);
            g.DrawString(sampleinfoList[0][1], new Font("宋体", 15), new SolidBrush(color[0]), pointSamp);

            picb_name.Image = Bmap_2;
            g.Dispose();
        }
    }
}
