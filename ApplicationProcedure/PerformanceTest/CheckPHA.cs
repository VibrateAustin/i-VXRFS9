using i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_VXRFS.ApplicationProcedure.PerformanceTest
{
    public partial class CheckPHA : Form
    { 
        public List<string> getelementparameter;  //存放父窗口传值过来的元素参数
        public int DgvRowIndex;  //上一窗口参数的行号
        private PerformanceTest_mainPage phdAForm;
        //构造函数
        public CheckPHA()
        {
            InitializeComponent();
        }
        public CheckPHA(PerformanceTest_mainPage phdaForm):this()
        {
            this.phdAForm = phdaForm;
        }
        private int lL;    //低限
        private int uL;    //高限
        public List<double> RawData;    //计数率

        //从文件中读取数据并加载
        private void CheckPHD_QuantitaionAnalysis_Load(object sender, EventArgs e)
        {
            //显示父窗口传递过来的数据
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

            //从文件中读取已经存在的PHD信息
            string path = Public_Path.PHDAngelCheckPath + "\\" + getelementparameter[0] + ".txt";
            RawData = Class_QualitationSpectraLine.ReadDataFromTxt2(path);
            lL = Convert.ToInt16(getelementparameter[13]);
            uL = Convert.ToInt16(getelementparameter[14]);
            PaintPHD();
        }

        //绘制PHD：利用计数率（RawData）、低限（lL）和高限（uL）
        private void PaintPHD()
        {
            Bitmap bmp = new Bitmap(picb_phdresult.Width, picb_phdresult.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black, 1);
            //绘制边框
            g.DrawRectangle(new Pen(Color.Black, 2), picb_phdresult.ClientRectangle);
            Rectangle drawingArea = new Rectangle(55, 10, picb_phdresult.Width - 85, picb_phdresult.Height - 39);
            g.DrawRectangle(new Pen(Color.Black, 2), drawingArea);
            float pointWidth = drawingArea.Width / (float)100;
            //绘制网格线
            Pen gridline = new Pen(Color.Blue, 1);
            for (int i = 1; i < 10; i++)
            {
                float x = 55 + i * drawingArea.Width / (float)10;
                for (int y = 10; y < 10 + drawingArea.Height; y += 10)
                {
                    g.DrawLine(gridline, new PointF(x, y), new PointF(x, y + 5));
                }
            }
            for (int j = 1; j < 6; j++)
            {
                float y = 10 + j * drawingArea.Height / (float)6;
                for (int x = 55; x < 55 + drawingArea.Width; x += 10)
                {
                    g.DrawLine(gridline, new PointF(x, y), new PointF(x + 5, y));
                }
            }
            //绘制坐标轴和标签
            Font font = new Font("Arial", 10);
            SolidBrush brush = new SolidBrush(Color.Black);
            for (int i = 0; i <= 10; i++)
            {
                g.DrawString((i * 10).ToString(), font, brush, new PointF(45 + i * 10 * pointWidth, 15 + drawingArea.Height));
            }
            for (int i = 2; i < 100; i += 2)
            {
                float x = 55 + i * pointWidth;
                int y = 10 + drawingArea.Height;
                g.DrawLine(pen, new PointF(x, y), new PointF(x, y + 5));
                if (i % 10 == 0)
                {
                    g.DrawLine(pen, new PointF(x, y + 5), new PointF(x, y + 10));
                }
            }
            Font font2 = new System.Drawing.Font("Arial", 12);
            SolidBrush sb2 = new SolidBrush(Color.Red);
            g.DrawString(getelementparameter[0], font2, sb2, ClientRectangle.Width - 130, 40);
            //绘制PHD
            double max = RawData.Max();
            for (int i = 0; i < 40; i++)         //传入真实的数据之后再进行更改
            {
                float h = (float)((5 / (float)6) * drawingArea.Height * RawData[i] / max);
                g.DrawRectangle(pen, 55 + (float)(i + 0.5) * pointWidth, 10 + drawingArea.Height - h, pointWidth, h);
            }
            //绘制上下限
            g.DrawLine(pen, new PointF(55 + lL * pointWidth, 30), new PointF(55 + lL * pointWidth, 10 + drawingArea.Height));
            g.DrawLine(pen, new PointF(55 + uL * pointWidth, 30), new PointF(55 + uL * pointWidth, 10 + drawingArea.Height));
            picb_phdresult.BackgroundImage = bmp;
            g.Dispose();
        }

        //改变PHD的低限（lL）和高限（uL）
        private void picb_phdresult_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 55 && e.X < picb_phdresult.Width - 30)
            {
                if (e.X < 55 + (picb_phdresult.Width - 85) / 2)
                {
                    lL = (int)Math.Round((e.X - 55) / ((picb_phdresult.Width - 85) / (float)100));
                }
                else
                {
                    uL = (int)Math.Round((e.X - 55) / ((picb_phdresult.Width - 85) / (float)100));
                }
                PaintPHD();
            }
            label8.Text = lL.ToString();
            label9.Text = uL.ToString();

            //paint_PHD(e.X);
            //factor++;
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btn_measurement_Click(object sender, EventArgs e)
        {
            //deviceIP和livetime后期要进行更改，因为它们的值会从其他地方传递过来
            IPEndPoint deviceIP = new IPEndPoint(IPAddress.Parse("192.168.0.1"), 10001);
            float livetime = 10;
            await Task.Factory.StartNew(() => GetCountRate(deviceIP, livetime));
            PaintPHD();
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

        //启动MCA，接收返回的数据，计算计数率
        public void GetCountRate(IPEndPoint deviceIP, float livetime)
        {
            //IPEndPoint deviceIP = new IPEndPoint(IPAddress.Parse("192.168.0.1"), 10001);
            UdpClient client = new UdpClient(10001);
            Packet clearPkt = new Packet(0xF0, 1);
            client.Send(clearPkt.ToBinary(), clearPkt.ToBinary().Length, deviceIP);     //第一步：清空数据
            byte[] ack1 = client.Receive(ref deviceIP);
            List<string> command = new List<string>
            {
                "MCAE=ON;",
                //string.Format("PREL={0}S",livetime),
            };
            CommandPacket com = new CommandPacket(command, "set");
            client.Send(com.ToBinary(), com.ToBinary().Length, deviceIP);       //第二步：开启MCA
            byte[] ack2 = client.Receive(ref deviceIP);
            if (ack2.Length == 8)
            {
                Packet ackPkt = new Packet(ack2);
                if (ackPkt.PID1 == 0xFF && ackPkt.PID2 == 0)
                {
                    Task.Run(() =>
                    {
                        Packet reqSpec = new Packet(2, 3);
                        Thread.Sleep((int)(livetime * 1000));
                        client.Send(reqSpec.ToBinary(), reqSpec.ToBinary().Length, deviceIP);
                        Thread.Sleep(1000);
                        byte[] response = new byte[6216];
                        //第三步：接收光谱数据，因为每次只能接收520个字节，要循环接收12次
                        for (int i = 0; i < 12; i++)
                        {
                            byte[] sec = new byte[i == 11 ? 496 : 520];
                            sec = client.Receive(ref deviceIP);
                            sec.CopyTo(response, i * 520);
                        }
                        SpecPacket spec = new SpecPacket(response);
                        RawData = spec.GetCountRate();       //第四步：将接收到的光谱数据转换为计数率
                    }
                    );
                }
                else
                {
                    MessageBox.Show("多道分析器启动失败，请重新开始测试", "错误", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("多道分析器启动失败，请重新开始测试", "错误", MessageBoxButtons.OK);
            }
        }

    }
}
