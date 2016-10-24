using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_VXRFS.Test.QuantitativeMeas
{
    public partial class MeasurementForm_NonStd : Form
    {
        public MeasurementForm_NonStd()
        {
            InitializeComponent();
        }

        private void MeasurementForm_NonStd_Load(object sender, EventArgs e)
        {
            //窗口图像背景虚线的绘制 实时测量时半定量分析实况图
            Bitmap Bmap_2 = new Bitmap(picb_testresultsMap.Width, picb_testresultsMap.Height);
            Graphics g = Graphics.FromImage(Bmap_2);
            Pen pen = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(picb_testresultsMap.ClientRectangle.X + picb_testresultsMap.ClientRectangle.Width, picb_testresultsMap.ClientRectangle.Y + picb_testresultsMap.ClientRectangle.Height);
            g.DrawRectangle(pen, picb_testresultsMap.ClientRectangle.X, picb_testresultsMap.ClientRectangle.Y,
                picb_testresultsMap.ClientRectangle.X + picb_testresultsMap.ClientRectangle.Width,
                picb_testresultsMap.ClientRectangle.Y + picb_testresultsMap.ClientRectangle.Height);
            Pen myPen = new Pen(Color.Blue, 1);
            for (int i = 65; i < ClientRectangle.Width; )
            {
                for (int j = 10; j < picb_testresultsMap.ClientRectangle.Height - 20; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i, j + 5));
                    j += 10;
                }
                i += Convert.ToInt32(ClientRectangle.Width / 10);
            }

            for (int j = 10; j < ClientRectangle.Height; )
            {
                for (int i = 59; i < ClientRectangle.Width - 31; )
                {
                    g.DrawLine(myPen, new Point(i, j), new Point(i + 5, j));
                    i += 10;
                }
                j += ClientRectangle.Height / 10;
            }
            g.DrawRectangle(pen, 65, 10,
                picb_testresultsMap.ClientRectangle.Width - 78,
                picb_testresultsMap.ClientRectangle.Height - 39);
            Font font = new System.Drawing.Font("Arial", 8);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawString("0", font, sb, 40, picb_testresultsMap.ClientRectangle.Height - 45);
            g.DrawString("Y-轴(kcps)", font, sb, 5, 25);
            g.DrawString("X-轴", font, sb, ClientRectangle.Width - 85, picb_testresultsMap.ClientRectangle.Height - 25);
            picb_testresultsMap.Image = Bmap_2;
            g.Dispose();
        }
    }
}
