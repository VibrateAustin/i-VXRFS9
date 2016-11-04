using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    class MathHelper
    {
        /// <summary>
        /// 对一组点通过最小二乘法进行线性回归
        /// </summary>
        /// <param name="parray"></param>
        public static void LinearRegression(List<PointF> parray, ref float K, ref float B)
        {
            double RMSE;
            double R2;
            if (parray.Count == 0)
            {
                MessageBox.Show("无法进行线性回归");
                return;
            }
            if (parray.Count == 1)
            {
                parray.Add(new Point(0, 0));
            }
            double averagex = 0, averagey = 0;
            foreach (PointF p in parray)
            {
                averagex += p.X;
                averagey += p.Y;
            }
            averagex /= parray.Count;
            averagey /= parray.Count;
            double numerator = 0;
            double denominator = 0;
            foreach (PointF p in parray)
            {
                numerator += (p.X - averagex) * (p.Y - averagey);
                denominator += (p.X - averagex) * (p.X - averagex);
            }
            K = (float)(numerator / denominator);
            B = (float)(averagey - K * averagex);
            RMSE = 0;
            double regressionSS = 0;
            foreach (PointF p in parray)
            {
                RMSE += (p.Y - B - K * p.X) * (p.Y - B - K * p.X);
                regressionSS += (B + K * p.X - averagey) * (B + K * p.X - averagey);
            }
            R2 = 1 - RMSE / regressionSS;
        }

        public static PointF cross(float k1, float b1, float k2, float b2)
        {
            float x = (b2 - b1) / (k1 - k2);
            return new PointF(x, k1 * x + b1);
        }

        //求直线与矩形的交点
        public static void GetEndPoint(Rectangle rec, PointF f, ref List<PointF> crosses)
        {
            crosses.Add(new PointF(rec.X, rec.X * f.X + f.Y));
            crosses.Add(new PointF((rec.Y - f.Y) / f.X, rec.Y));
            crosses.Add(new PointF(rec.X + rec.Width, (rec.X + rec.Width) * f.X + f.Y));
            crosses.Add(new PointF((rec.Y + rec.Height - f.Y) / f.X, rec.Y + rec.Height));
            List<PointF> wrong = new List<PointF>();
            foreach (PointF p in crosses)
            {
                if (p.X < rec.X || p.Y < rec.Y || p.X > rec.X + rec.Width || p.Y > rec.Y + rec.Height)
                {
                    wrong.Add(p);
                }
            }
            foreach (PointF p in wrong)
            {
                crosses.Remove(p);
            }
            if (crosses.Count == 2)
            {
                if (crosses[0].X > crosses[1].X)
                {
                    PointF t = crosses[0];
                    crosses[0] = crosses[1];
                    crosses[1] = t;
                }
            }
            else
            {
                crosses = null;
            }
        }
    }
}
