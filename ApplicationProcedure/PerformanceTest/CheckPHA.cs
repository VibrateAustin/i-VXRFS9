using i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults;
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
    public partial class CheckPHA : Form
    {
        public CheckPHA()
        {
            InitializeComponent();
        }
        public List<string> getelementparameter;//存放父窗口传值过来的元素参数
        public int DgvRowIndex;
        private PerformanceTest_mainPage phdAForm;
        public CheckPHA(PerformanceTest_mainPage phdaForm):this()
        {
            this.phdAForm = phdaForm;
        }
        public List<double> RawData;
        //public int DgvIndex;//上一窗口参数的行号
        private void CheckPHD_QuantitaionAnalysis_Load(object sender, EventArgs e)
        {
            txtb_step.Text = "0.04"; txtb_step.ReadOnly = true;
            txtb_steptime.Text = "20"; txtb_steptime.ReadOnly = true;
            cbox_mask.Text = "20";
            txtb_brkV.Text = getelementparameter[6]; txtb_brkV.ReadOnly = true;
            txtb_brmA.Text = getelementparameter[7]; txtb_brmA.ReadOnly = true;
            txtb_elemK.Text = getelementparameter[1]; txtb_elemK.ReadOnly = true;
            txtb_filter.Text = getelementparameter[5]; txtb_filter.ReadOnly = true;
            txtb_detector.Text = getelementparameter[4]; txtb_detector.ReadOnly = true;
            txtb_crystal.Text = getelementparameter[2]; txtb_crystal.ReadOnly = true;
            txtb_collimator.Text = getelementparameter[3]; txtb_collimator.ReadOnly = true;
            label7.Text = getelementparameter[8];
            label8.Text = getelementparameter[13];
            label9.Text = getelementparameter[14];
            
            //窗口图像背景虚线的绘制
            Bitmap Bmap_2 = new Bitmap(picb_phdresult.Width, picb_phdresult.Height);
            Graphics g = Graphics.FromImage(Bmap_2);
            Pen pen = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(picb_phdresult.ClientRectangle.X + picb_phdresult.ClientRectangle.Width, picb_phdresult.ClientRectangle.Y + picb_phdresult.ClientRectangle.Height);
            g.DrawRectangle(pen, picb_phdresult.ClientRectangle.X, picb_phdresult.ClientRectangle.Y,
                picb_phdresult.ClientRectangle.X + picb_phdresult.ClientRectangle.Width,
                picb_phdresult.ClientRectangle.Y + picb_phdresult.ClientRectangle.Height);
            Pen myPen = new Pen(Color.Blue, 1);
            for (int i = 55; i < ClientRectangle.Width; )
            {
                for (int j = 10; j < picb_phdresult.ClientRectangle.Height - 20; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i, j + 5));
                    j += 10;
                }
                i += Convert.ToInt32(ClientRectangle.Width / 11);
            }

            for (int j = 10; j < ClientRectangle.Height; )
            {
                for (int i = 49; i < ClientRectangle.Width-51; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += ClientRectangle.Height / 10;
            }
            g.DrawRectangle(pen, 55, 10,
                picb_phdresult.ClientRectangle.Width-85,
                picb_phdresult.ClientRectangle.Height-39);
            Font font = new System.Drawing.Font("Arial", 8);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawString("0", font, sb, 40, picb_phdresult.ClientRectangle.Height - 45);
            g.DrawString("Y-轴(KeV)", font, sb, 5, 25);
            g.DrawString("PHD", font, sb, ClientRectangle.Width - 45, picb_phdresult.ClientRectangle.Height -38);

            //绘制默认的谱线
            string path = Public_Path.PHDAngelCheckPath + "\\" + getelementparameter[0] + ".txt";
            RawData = Class_QualitationSpectraLine.ReadDataFromTxt2(path);
            double datamax = RawData.Max();
            float sizeX = ((float)(picb_phdresult.Width - 85) / RawData.Count);
            //横坐标的转化
            int LL = Convert.ToInt16(getelementparameter[13])+1;
            int UL = Convert.ToInt16(getelementparameter[14])+1;
            double pointArea = (picb_phdresult.Width - 85) / 100;
            float Lx = (float)(Math.Floor(LL * pointArea *1.08) + 55); float Ux = (float)(Math.Floor(UL * pointArea *1.08) + 55);

            Pen pens = new Pen(Color.Blue, 1);
            for (int i = 0; i < RawData.Count - 1; i++)
            {
                float yH=(float)(((picb_phdresult.Height - 120) * RawData[i] / datamax));
                float xW = (float)(i + 1) * sizeX + 55;
                if (xW > Lx && xW < Ux)
                {
                    for (int j = 0; j < Math.Ceiling(yH); j++) //画实心
                    {
                        PointF pf1 = new PointF(xW - sizeX / 2, (float)(picb_phdresult.Height - 31 - j));
                        PointF pf2 = new PointF(xW + sizeX / 2, (float)(picb_phdresult.Height - 31 - j));
                        g.DrawLine(pens, pf1, pf2);
                    }
                }
                else  //画空心
                {
                    PointF pf1 = new PointF(xW - sizeX / 2, (float)(picb_phdresult.Height - 31));
                    PointF pf2 = new PointF(xW - sizeX / 2, (float)(picb_phdresult.Height - 31 - yH));
                    g.DrawLine(pens, pf1, pf2);
                    PointF pf3 = new PointF(xW + sizeX / 2, (float)(picb_phdresult.Height - 31));
                    PointF pf4 = new PointF(xW + sizeX / 2, (float)(picb_phdresult.Height - 31 - yH));
                    g.DrawLine(pens, pf3, pf4);
                    PointF pf5 = new PointF(xW - sizeX / 2, (float)(picb_phdresult.Height - 31 - yH));
                    PointF pf6 = new PointF(xW + sizeX / 2, (float)(picb_phdresult.Height - 31 - yH));
                    g.DrawLine(pens, pf5, pf6);
                }
            }
            //绘制两条竖线
            Pen penV = new Pen(Color.Black, 2);
            PointF pfL1 = new PointF(Lx, 50); PointF pfL2 = new PointF(Lx, picb_phdresult.Height - 30); g.DrawLine(penV, pfL1, pfL2);
            PointF pfU1 = new PointF(Ux, 50); PointF pfU2 = new PointF(Ux, picb_phdresult.Height - 30); g.DrawLine(penV, pfU1, pfU2);
            //横坐标值
            Font font1 = new System.Drawing.Font("Arial", 10);
            SolidBrush sb1 = new SolidBrush(Color.Black);
            float yyy = 0;
            for (int i = 0; i < 11; i++)
            {
                yyy = (float)(50 + (float)10.8 * i * pointArea);
                g.DrawString((i*10).ToString(), font1, sb1,yyy , picb_phdresult.ClientRectangle.Height - 20);
            }
            Font font2 = new System.Drawing.Font("Arial", 12);
            SolidBrush sb2 = new SolidBrush(Color.Red);
            g.DrawString(getelementparameter[0], font2, sb2, ClientRectangle.Width - 130, 40);
            picb_phdresult.Image = Bmap_2;
            g.Dispose();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picb_phdresult_MouseClick(object sender, MouseEventArgs e)
        {
            paint_PHD(e.X);
            factor++;
        }
        private int factor = 0; //标识鼠标点击的次数
        private float Lx, Ux; 
        public void paint_PHD(int X)
        {
            //窗口图像背景虚线的绘制
            Bitmap Bmap_2 = new Bitmap(picb_phdresult.Width, picb_phdresult.Height);
            Graphics g = Graphics.FromImage(Bmap_2);
            Pen pen = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(picb_phdresult.ClientRectangle.X + picb_phdresult.ClientRectangle.Width, picb_phdresult.ClientRectangle.Y + picb_phdresult.ClientRectangle.Height);
            g.DrawRectangle(pen, picb_phdresult.ClientRectangle.X, picb_phdresult.ClientRectangle.Y,
                picb_phdresult.ClientRectangle.X + picb_phdresult.ClientRectangle.Width,
                picb_phdresult.ClientRectangle.Y + picb_phdresult.ClientRectangle.Height);
            Pen myPen = new Pen(Color.Blue, 1);
            for (int i = 55; i < ClientRectangle.Width; )
            {
                for (int j = 10; j < picb_phdresult.ClientRectangle.Height - 20; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i, j + 5));
                    j += 10;
                }
                i += Convert.ToInt32(ClientRectangle.Width / 11);
            }

            for (int j = 10; j < ClientRectangle.Height; )
            {
                for (int i = 49; i < ClientRectangle.Width - 51; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += ClientRectangle.Height / 10;
            }
            g.DrawRectangle(pen, 55, 10,
                picb_phdresult.ClientRectangle.Width - 85,
                picb_phdresult.ClientRectangle.Height - 39);
            Font font = new System.Drawing.Font("Arial", 8);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawString("0", font, sb, 40, picb_phdresult.ClientRectangle.Height - 45);
            g.DrawString("Y-轴(KeV)", font, sb, 5, 25);
            g.DrawString("PHD", font, sb, ClientRectangle.Width - 45, picb_phdresult.ClientRectangle.Height - 38);

            //横坐标的转化
            int LL = Convert.ToInt16(getelementparameter[13])+1;
            int UL = Convert.ToInt16(getelementparameter[14])+1;
            double pointArea = (picb_phdresult.Width - 85) / 100;
            //绘制默认的谱线
            string path = Public_Path.PHDAngelCheckPath + "\\" + getelementparameter[0] + ".txt";
            RawData = Class_QualitationSpectraLine.ReadDataFromTxt2(path);
            double datamax = RawData.Max();
            float sizeX = ((float)(picb_phdresult.Width - 85) / RawData.Count);
            if (factor == 0) //第一次点击时，产生
            {
                Lx =(float)(LL * pointArea *1.08 + 55);
                Ux = (float)(UL * pointArea * 1.08 + 55);
            }
            if (X < (picb_phdresult.Width - 85) / 2 + 55)
            {
                Lx = X;
            }
            else Ux = X;
            label8.Text = Convert.ToInt16(getXData((int)Lx)).ToString();
            label9.Text = Convert.ToInt16(getXData((int)Ux)).ToString();
           
            Pen pens = new Pen(Color.Blue, 1);
            for (int i = 0; i < RawData.Count - 1; i++)
            {
                float yH = (float)(((picb_phdresult.Height - 120) * RawData[i] / datamax));
                float xW = (float)(i + 1) * sizeX + 55;
                if (xW > Lx && xW < Ux)
                {
                    for (int j = 0; j < Math.Ceiling(yH); j++) //画实心
                    {
                        PointF pf1 = new PointF(xW - sizeX / 2, (float)(picb_phdresult.Height - 31 - j));
                        PointF pf2 = new PointF(xW + sizeX / 2, (float)(picb_phdresult.Height - 31 - j));
                        g.DrawLine(pens, pf1, pf2);
                    }
                }
                else  //画空心
                {
                    PointF pf1 = new PointF(xW - sizeX / 2, (float)(picb_phdresult.Height - 31));
                    PointF pf2 = new PointF(xW - sizeX / 2, (float)(picb_phdresult.Height - 31 - yH));
                    g.DrawLine(pens, pf1, pf2);
                    PointF pf3 = new PointF(xW + sizeX / 2, (float)(picb_phdresult.Height - 31));
                    PointF pf4 = new PointF(xW + sizeX / 2, (float)(picb_phdresult.Height - 31 - yH));
                    g.DrawLine(pens, pf3, pf4);
                    PointF pf5 = new PointF(xW - sizeX / 2, (float)(picb_phdresult.Height - 31 - yH));
                    PointF pf6 = new PointF(xW + sizeX / 2, (float)(picb_phdresult.Height - 31 - yH));
                    g.DrawLine(pens, pf5, pf6);
                }
            }
            //绘制两条竖线
            Pen penV = new Pen(Color.Black, 2);
            PointF pfL1 = new PointF(Lx, 50); PointF pfL2 = new PointF(Lx, picb_phdresult.Height - 30); g.DrawLine(penV, pfL1, pfL2);
            PointF pfU1 = new PointF(Ux, 50); PointF pfU2 = new PointF(Ux, picb_phdresult.Height - 30); g.DrawLine(penV, pfU1, pfU2);
            //横坐标值
            Font font1 = new System.Drawing.Font("Arial", 10);
            SolidBrush sb1 = new SolidBrush(Color.Black);
            float yyy = 0;
            for (int i = 0; i < 11; i++)
            {
                yyy = (float)(50 + (float)10.8 * i * pointArea);
                g.DrawString((i * 10).ToString(), font1, sb1, yyy, picb_phdresult.ClientRectangle.Height - 20);
            }
            Font font2 = new System.Drawing.Font("Arial", 12);
            SolidBrush sb2 = new SolidBrush(Color.Red);
            g.DrawString(getelementparameter[0], font2, sb2, ClientRectangle.Width - 130, 40);
            picb_phdresult.Image = Bmap_2;
            g.Dispose();
        }
        private int getXData(int X)
        {
            int pointArea =(picb_phdresult.Width - 85 )/ 100;
            double xx = (X - 55) / pointArea /1.08;
            int XX;
            XX=Convert.ToInt16(Math.Floor(xx));
            return XX;
        }
        //更新保存数据
        //i_VXRFS_function XRF_function = new i_VXRFS_function();
        //public int sqlData(string str)
        //{
        //    SqlConnection conn = new SqlConnection(XRF_function.LinkDataBasePath);
        //    conn.Open();
        //    SqlCommand sqc = new SqlCommand(str, conn);
        //    int i = Convert.ToInt16(sqc.ExecuteNonQuery());
        //    conn.Close();
        //    return i;
        //}
        private void btn_ok_Click(object sender, EventArgs e)
        {
            //更新数据到数据库中
            //13-14
            getelementparameter[13] = label8.Text.ToString();
            getelementparameter[14] = label9.Text.ToString();
            //更新数据到数据库中
            phdAForm.dgv1.Rows[DgvRowIndex].Cells[13].Value = getelementparameter[13];
            phdAForm.dgv1.Rows[DgvRowIndex].Cells[14].Value = getelementparameter[14];
            phdAForm.dgv1.Rows[DgvRowIndex].Cells[21].Value = DateTime.Now.ToString("yyyy/MM/dd");
            this.Close();
        }
       

    }
}
