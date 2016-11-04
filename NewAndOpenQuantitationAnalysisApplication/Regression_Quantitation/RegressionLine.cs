using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    public partial class RegressionLine : Form
    {
        #region  声明变量

        //当前界面显示的点集
        public List<PointF> list = new List<PointF>();

        //是否为剔除点，key为化合物的名字
        public Dictionary<String, List<bool>> states = new Dictionary<string, List<bool>>();

        //每个化合物的样本名，key为化合物的名字
        public Dictionary<String, List<String>> names = new Dictionary<String, List<String>>();

        //每个数据点是否被剔除，key为化合物的名字
        public Dictionary<String, bool> isIn = new Dictionary<string, bool>();

        //每个化合物的拟合直线是否被修改过
        public Dictionary<string, bool> isModify = new Dictionary<string, bool>();

        //list中x,y的最大值
        public float maxX, maxY;

        //分段拟合的分段点
        public List<float> iv1 = new List<float>();
        public List<float> iv2 = new List<float>();

        //化合物列表
        public List<string> compound = new List<string>();

        //化合物所对应的数据点，key为化合物的名字
        public Dictionary<string, List<PointF>> map = new Dictionary<string, List<PointF>>();

        //化合物所对应的拟合直线，key为化合物的名字
        public Dictionary<string, List<PointF>> lines = new Dictionary<string, List<PointF>>();

        //是否分段
        public List<bool> isIntervalList = new List<bool>();

        public int idxCom = 0;

        //背景图像
        private Bitmap backGround;

        //放大倍数
        private PointF magnification = new PointF(1f, 1f);

        //截图的Rectangle，表示截图在全图中的位置
        private Rectangle PartRec;

        //需要显示的点的索引
        private List<int> selectedPoint = new List<int>();

        //所有数据点的绘图坐标
        private List<PointF> pointOnImage = new List<PointF>();

        //图中要显示的所有直线
        private List<Line> lineOnImage = new List<Line>();

        #endregion

        #region  自定义结构

        //自定义由两个点组成的结构
        private struct TwoPoints
        {
            public PointF A { get; set; }
            public PointF B { get; set; }
            public TwoPoints(PointF a, PointF b)
            {
                this.A = a;
                this.B = b;
            }
        }

        //自定义一个直线的结构，包括直线的断点，直线的斜率和截距
        private struct Line
        {
            public PointF EndPointA { get; set; }
            public PointF EndPointB { get; set; }
            public PointF BreakPointA { get; set; }
            public PointF BreakPointB { get; set; }
            public Line(PointF ea, PointF eb, PointF ba, PointF bb)
            {
                this.EndPointA = ea;
                this.EndPointB = eb;
                this.BreakPointA = ba;
                this.BreakPointB = bb;
            }
            public void DrawLine(Graphics g)
            {
                //定义两种pen
                Pen solid = new Pen(Color.Blue, 1);
                Pen dash = new Pen(Color.Blue, 1);
                dash.DashStyle = DashStyle.Custom;
                dash.DashPattern = new float[] { 3f, 3f };
                //根据端点与交点的位置关系分类讨论画图
                if (EndPointA.X <= BreakPointA.X && EndPointB.X >= BreakPointB.X)
                {
                    g.DrawLine(dash, EndPointA.X, EndPointA.Y, BreakPointA.X, BreakPointA.Y);
                    g.DrawLine(solid, BreakPointA.X, BreakPointA.Y, BreakPointB.X, BreakPointB.Y);
                    g.DrawLine(dash, BreakPointB.X, BreakPointB.Y, EndPointB.X, EndPointB.Y);
                    g.FillEllipse(new SolidBrush(Color.Green), BreakPointA.X - 2.5f, BreakPointA.Y - 2.5f, 5, 5);
                    g.FillEllipse(new SolidBrush(Color.Green), BreakPointB.X - 2.5f, BreakPointB.Y - 2.5f, 5, 5);
                }
                else if (EndPointA.X >= BreakPointA.X && EndPointB.X <= BreakPointB.X)
                {
                    g.DrawLine(solid, EndPointA.X, EndPointA.Y, EndPointB.X, EndPointB.Y);
                }
                else if (EndPointA.X >= BreakPointA.X && EndPointA.X <= BreakPointB.X && EndPointB.X >= BreakPointB.X)
                {
                    g.DrawLine(solid, EndPointA.X, EndPointA.Y, BreakPointB.X, BreakPointB.Y);
                    g.DrawLine(dash, BreakPointB.X, BreakPointB.Y, EndPointB.X, EndPointB.Y);
                    g.FillEllipse(new SolidBrush(Color.Green), BreakPointB.X - 2.5f, BreakPointB.Y - 2.5f, 5, 5);
                }
                else if (EndPointA.X <= BreakPointA.X && EndPointB.X >= BreakPointA.X && EndPointB.X <= BreakPointB.X)
                {
                    g.DrawLine(dash, EndPointA.X, EndPointA.Y, BreakPointA.X, BreakPointA.Y);
                    g.DrawLine(solid, BreakPointA.X, BreakPointA.Y, EndPointB.X, EndPointB.Y);
                    g.FillEllipse(new SolidBrush(Color.Green), BreakPointA.X - 2.5f, BreakPointA.Y - 2.5f, 5, 5);
                }
                else if (EndPointA.X > BreakPointB.X || EndPointB.X < BreakPointA.X)
                {
                    g.DrawLine(dash, EndPointA.X, EndPointA.Y, EndPointB.X, EndPointB.Y);
                }
            }
        }

        #endregion

        #region  初始化窗口

        public RegressionLine()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            // Show();
            // readData();
            // nameLable.Text = compound[0];
            // paintData(map[compound[0]]);
        }
        public string ApplicationNames;
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void Regression_Load(object sender, EventArgs e)
        {
            //窗口图像背景虚线的绘制
            Bitmap Bmap_2 = new Bitmap(curveBox.Width, curveBox.Height);
            Graphics g = Graphics.FromImage(Bmap_2);
            Pen pen = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(curveBox.ClientRectangle.X + curveBox.ClientRectangle.Width, curveBox.ClientRectangle.Y + curveBox.ClientRectangle.Height);
            g.DrawRectangle(pen, curveBox.ClientRectangle.X, curveBox.ClientRectangle.Y,
                curveBox.ClientRectangle.X + curveBox.ClientRectangle.Width,
                curveBox.ClientRectangle.Y + curveBox.ClientRectangle.Height);
            curveBox.Image = Bmap_2;
            g.Dispose();
            readData();
            nameLable.Text = compound[0];
            backGround = new Bitmap(curveBox.Width, curveBox.Height);
            PartRec = new Rectangle(0, 0, curveBox.Width, curveBox.Height);
            paintData(map[compound[0]]);
        }

        #endregion

        #region  数据处理工具

        //读入并初始化数据结构
        private void readData()
        {
            //获得每个标样点
            string regData = XRF_function.QuantitationApplicationPath + "\\" + ApplicationNames + "\\RevisionData_" + ApplicationNames + ".txt";
            string[] data = File.ReadAllLines(regData, Encoding.UTF8);
            string[] title = data[0].Split('\t');
            for (int i = 1; i < data.Length; ++i)
            {
                string[] item = data[i].Split('\t');
                for (int j = 3; j < item.Length; ++j)
                    if (item[0].Length > 0 && !isIn.ContainsKey(title[j] + "," + item[0]))
                    {
                        isIn.Add(title[j] + "," + item[0], item[j].Equals("X") ? false : true);
                    }
            }
            //将标样点转成(x,y)
            string xPath = XRF_function.QuantitationApplicationPath + "\\" + ApplicationNames + "\\S_" + ApplicationNames + ".txt";
            string yPath = XRF_function.QuantitationApplicationPath + "\\" + ApplicationNames + "\\R_" + ApplicationNames + ".txt";
            string[] xStrs = File.ReadAllLines(xPath);
            string[] yStrs = File.ReadAllLines(yPath);
            Dictionary<string, Dictionary<string, float>> xMap = new Dictionary<string, Dictionary<string, float>>();
            title = xStrs[0].Split(' ', '\t', ',');
            for (int i = 1; i < xStrs.Length; ++i)
            {
                string[] item = xStrs[i].Split(' ', '\t', ',');
                for (int j = 8; j < item.Length; ++j)
                {
                    if (!xMap.ContainsKey(title[j]))
                    {
                        xMap.Add(title[j], new Dictionary<string, float>());
                    }
                    if (float.Parse(item[j]) > 0)
                    {
                        xMap[title[j]].Add(item[0], float.Parse(item[j]));
                    }
                }
            }
            title = yStrs[0].Split(' ', '\t', ',');
            for (int i = 1; i < yStrs.Length; ++i)
            {
                string[] item = yStrs[i].Split(' ', '\t', ',');
                for (int j = 1; j < item.Length; ++j)
                {
                    if (xMap.ContainsKey(title[j]) && xMap[title[j]].ContainsKey(item[0]))
                    {
                        if (!map.ContainsKey(title[j]))
                        {
                            compound.Add(title[j]);
                            isIntervalList.Add(false);
                            iv1.Add(0);
                            iv2.Add(0);
                            map.Add(title[j], new List<PointF>());
                            states.Add(title[j], new List<bool>());
                            names.Add(title[j], new List<String>());
                            lines.Add(title[j], new List<PointF>());
                        }
                        map[title[j]].Add(new PointF(xMap[title[j]][item[0]], float.Parse(item[j])));
                        states[title[j]].Add(isIn.ContainsKey(title[j] + "," + item[0]) ? isIn[title[j] + "," + item[0]] : true);
                        names[title[j]].Add(item[0]);
                    }
                }
            }
            //读入数据回归信息
            string regParam = XRF_function.QuantitationApplicationPath + "\\" + ApplicationNames + "\\ReLineParam_" + ApplicationNames + ".txt";
            data = File.ReadAllLines(regParam, Encoding.UTF8);
            for (int i = 1; i < data.Length; ++i)
            {
                string[] item = data[i].Split('\t');
                if (lines.ContainsKey(item[0]))
                {
                    List<PointF> list = lines[item[0]];
                    for (int j = 0; j < 3; ++j)
                        if (item[3 + j * 6].Length > 0)
                        {
                            lines[item[0]].Add(new PointF(float.Parse(item[3 + j * 6]), float.Parse(item[3 + j * 6 + 1])));
                            if (!isModify.ContainsKey(item[0]))
                                isModify.Add(item[0], false);
                        }
                    //判断数据里哪些是分段的
                    for (int k = 0; k < compound.Count; ++k)
                        if (compound[k].Equals(item[0]))
                        {

                            if (item[24].Length > 0)
                            {
                                iv1[k] = float.Parse(item[24]);
                            }
                            if (item[25].Length > 0)
                            {
                                iv2[k] = float.Parse(item[25]);
                            }
                            isIntervalList[k] = iv1[k] != 0 || iv2[k] != 0;
                            break;
                        }
                }
            }
            isInterval.Checked = isIntervalList[idxCom];
        }

        //坐标转换，数据坐标->绘图坐标
        /*
        private PointF transform(PointF p)
        {
            return transform(p.X, p.Y);
        }

        //坐标转换，数据坐标->绘图坐标
        private PointF transform(float x, float y)
        {
            PointF r = new PointF();
            r.X = x / maxX * curveBox.Width;
            int h = curveBox.Height * 20 / 21;
            r.Y = h - y / maxY * h;
            return r;
        }
        */
        //修改transform函数，可以根据图像尺寸的不同来转换坐标
        private PointF transform(float x, float y, Size s)
        {
            PointF r = new PointF();
            r.X = x / maxX * s.Width;
            int h = s.Height * 20 / 21;
            r.Y = h - y / maxY * h;
            return r;
        }
        private PointF transform(PointF p, Size s)
        {
            return transform(p.X, p.Y, s);
        }

        //用区间范围st，ed间的点，拟合一条直线
        private bool getLine(float st, float ed, ref PointF res)
        {
            float k = 0, b = 0;
            List<PointF> tmp = new List<PointF>();
            for (int i = 0; i < list.Count; ++i)
            {
                if (states[compound[idxCom]][i] && st <= list[i].X && list[i].X < ed)
                {
                    tmp.Add(list[i]);
                }
            }
            if (tmp.Count == 0)
            {
                return false;
            }
            MathHelper.LinearRegression(tmp, ref k, ref b);
            res.X = k;
            res.Y = b;
            return true;           //总是会返回true
        }
        //获得拟合直线
        private List<PointF> getLine()
        {
            if (isModify.ContainsKey(compound[idxCom]))
            {
                if (!isModify[compound[idxCom]])
                {
                    return lines[compound[idxCom]];
                }
            }
            List<PointF> line = new List<PointF>();
            PointF line1 = new PointF();
            if (getLine(0, iv1[idxCom], ref line1))    //带参数的getline总是会返回true，为什么还需要判定。
            {
                line.Add(line1);
            }
            PointF line2 = new PointF();
            if (getLine(iv1[idxCom], iv2[idxCom], ref line2))
            {
                line.Add(line2);
            }
            PointF line3 = new PointF();
            if (getLine(iv2[idxCom], float.MaxValue, ref line3))
            {
                line.Add(line3);
            }
            return line;
        }

        //将方程，RMS等数据转化为字符串显示出来
        private string toString(PointF p)
        {
            return (isShowDEF.Checked ? string.Format("D: {0}, E: {1}, F: 0  ", p.X.ToString("0.0000"), p.Y.ToString("0.0000")) : "") +
                (isShowRMS.Checked ? string.Format("RMS: {0}  ", p.X.ToString("0.0000")) : "");
            //TODO 单个直线的各种参数计算
        }

        #endregion

        #region  图像的绘制

        //双缓冲绘图，根据各种复选框选择情况，绘制直线，点，坐标系，文本框等等
        /*
        private void paint()
        {
            Bitmap bm = new Bitmap(curveBox.Width, curveBox.Height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            //Graphics g = Graphics.FromImage(Bmap_2);  绘制边框
            Pen pen1 = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(curveBox.ClientRectangle.X + curveBox.ClientRectangle.Width - 2, curveBox.ClientRectangle.Y + curveBox.ClientRectangle.Height - 2);
            g.DrawRectangle(pen1, curveBox.ClientRectangle.X, curveBox.ClientRectangle.Y,
                curveBox.ClientRectangle.X + curveBox.ClientRectangle.Width,
                curveBox.ClientRectangle.Y + curveBox.ClientRectangle.Height);

            //绘制坐标轴
            Pen pen = new Pen(Color.Gray, 1);
            pen.DashStyle = DashStyle.Custom;
            pen.DashPattern = new float[] { 5f, 5f };
            int n = 5;
            for (int i = 1; i < n; ++i)
            {
                g.DrawLine(pen, curveBox.Width / n * i, 0, curveBox.Width / n * i, curveBox.Height);
                int h = curveBox.Height / n * i * 20 / 21;
                g.DrawLine(pen, 0, h, curveBox.Width, h);
            }
            pen = new Pen(Color.Gray);
            g.DrawLine(pen, 0, curveBox.Height * 20 / 21, curveBox.Width, curveBox.Height * 20 / 21);
            //绘制点
            Size s = bm.Size;
            for (int i = 0; i < list.Count; ++i)
            {
                PointF t = transform(list[i], s);
                g.FillEllipse(new SolidBrush(states[compound[idxCom]][i] ? Color.Blue : Color.Red), t.X, t.Y, 5, 5);
            }
            //绘制回归线
            if (isShowReg.Checked)
            {
                List<PointF> line = getLine();
                if (line.Count > 0)
                {
                    if (line.Count == 3)
                    {
                        PointF p1 = MathHelper.cross(line[0].X, line[0].Y, line[1].X, line[1].Y);
                        PointF p2 = MathHelper.cross(line[1].X, line[1].Y, line[2].X, line[2].Y);
                        if (p1.X >= p2.X)
                        {
                            line.RemoveAt(1);
                        }
                    }
                    float last = 0;
                    PointF lastline = line[0];
                    Pen dash = new Pen(Color.Blue, 1);//
                    dash.DashStyle = DashStyle.Dash;//
                    for (int i = 1; i < line.Count; ++i)
                    {
                        PointF p = MathHelper.cross(lastline.X, lastline.Y, line[i].X, line[i].Y);
                        g.DrawLine(new Pen(Color.Blue, 1), transform(last, last * lastline.X + lastline.Y, s), transform(p.X, p.X * lastline.X + lastline.Y, s));
                        g.DrawLine(dash, transform(0,lastline.Y, s), transform(last, last * lastline.X + lastline.Y, s));//
                        g.DrawLine(dash, transform(p.X, p.X * lastline.X + lastline.Y, s), transform(maxX, maxX * lastline.X + lastline.Y, s));//
                        last = p.X;
                        lastline = line[i];
                    }
                    g.DrawLine(new Pen(Color.Blue, 1), transform(last, last * lastline.X + lastline.Y, s), transform(maxX, maxX * lastline.X + lastline.Y, s));
                    g.DrawLine(dash, transform(0, lastline.Y, s), transform(last, last * lastline.X + lastline.Y, s));//
                }
                lines[compound[idxCom]] = line;
                //显示方程
                lab_equation.Text = line.Count >= 1 ? toString(line[0]) : "";
                lab_equation2.Text = line.Count >= 2 ? toString(line[1]) : "";
                lab_equation3.Text = line.Count >= 3 ? toString(line[2]) : "";
            }
            //画在背景上
            curveBox.BackgroundImage = bm;
        }
        */

        //以下三个函数是把原Paint函数分解的结果，便于使用
        private void paint_frame(Bitmap bm)
        {
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            //Graphics g = Graphics.FromImage(Bmap_2);  绘制边框
            Pen pen1 = new Pen(Color.Black, 2);
            PointF start = new PointF(0, 0);
            PointF end = new PointF(curveBox.ClientRectangle.X + curveBox.ClientRectangle.Width - 2, curveBox.ClientRectangle.Y + curveBox.ClientRectangle.Height - 2);
            g.DrawRectangle(pen1, curveBox.ClientRectangle.X, curveBox.ClientRectangle.Y,
                curveBox.ClientRectangle.X + curveBox.ClientRectangle.Width,
                curveBox.ClientRectangle.Y + curveBox.ClientRectangle.Height);

            //绘制坐标轴
            Pen pen = new Pen(Color.Gray, 1);
            pen.DashStyle = DashStyle.Custom;
            pen.DashPattern = new float[] { 5f, 5f };
            int n = 5;
            for (int i = 1; i < n; ++i)
            {
                g.DrawLine(pen, curveBox.Width / n * i, 0, curveBox.Width / n * i, curveBox.Height);
                int h = curveBox.Height / n * i * 20 / 21;
                g.DrawLine(pen, 0, h, curveBox.Width, h);
            }
            pen = new Pen(Color.Gray);
            g.DrawLine(pen, 0, curveBox.Height * 20 / 21, curveBox.Width, curveBox.Height * 20 / 21);
            g.Dispose();
        }

        private void paint_point(Bitmap bm)
        {
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            pointOnImage = new List<PointF>();
            lineOnImage = new List<Line>();
            Size s = new Size((int)(curveBox.Width * magnification.X), (int)(curveBox.Height * magnification.Y));
            //绘制数据点
            //第一步，把所有的点在后台全图的坐标下表示
            for (int i = 0; i < list.Count; i++)
            {
                pointOnImage.Add(new PointF(transform(list[i], s).X - PartRec.X, transform(list[i], s).Y - PartRec.Y));
            }
            //第二步，根据绘图坐标（pointOnImage）把框选的数据点（selectedPoint表示索引）绘制出来
            foreach (int i in selectedPoint)
            {
                g.FillEllipse(new SolidBrush(states[compound[idxCom]][i] ? Color.Blue : Color.Red), pointOnImage[i].X, pointOnImage[i].Y, 5, 5);
            }

            //绘制回归线
            if (isShowReg.Checked)
            {
                List<PointF> line = getLine();
                if (line.Count > 0)
                {
                    List<TwoPoints> breakpoint = new List<TwoPoints>();
                    if (line.Count == 3)
                    {
                        PointF p1 = MathHelper.cross(line[0].X, line[0].Y, line[1].X, line[1].Y);
                        PointF p2 = MathHelper.cross(line[1].X, line[1].Y, line[2].X, line[2].Y);
                        if (p1.X >= p2.X)
                        {
                            line.RemoveAt(1);
                            PointF p = MathHelper.cross(line[0].X, line[0].Y, line[1].X, line[1].Y);
                            breakpoint.Add(new TwoPoints(transform(0, line[0].Y, s), transform(p, s)));
                            breakpoint.Add(new TwoPoints(transform(p, s), transform(maxX, maxX * line[1].X + line[1].Y, s)));
                        }
                        else
                        {
                            breakpoint.Add(new TwoPoints(transform(0, line[0].Y, s), transform(p1, s)));
                            breakpoint.Add(new TwoPoints(transform(p1, s), transform(p2, s)));
                            breakpoint.Add(new TwoPoints(transform(p2, s), transform(maxX, maxX * line[2].X + line[2].Y, s)));
                        }
                    }
                    else if (line.Count == 2)
                    {
                        PointF p = MathHelper.cross(line[0].X, line[0].Y, line[1].X, line[1].Y);
                        breakpoint.Add(new TwoPoints(transform(0, line[0].Y, s), transform(p, s)));
                        breakpoint.Add(new TwoPoints(transform(p, s), transform(maxX, maxX * line[1].X + line[1].Y, s)));
                    }
                    else
                    {
                        breakpoint.Add(new TwoPoints(transform(0, line[0].Y, s), transform(maxX, maxX * line[0].X + line[0].Y, s)));
                    }

                    float factor = (-1) * s.Height * maxX * 20 / (s.Width * maxY * 21);
                    for (int i = 0; i < line.Count; i++)
                    {
                        List<PointF> crosses = new List<PointF>();
                        MathHelper.GetEndPoint(PartRec, new PointF(line[i].X * factor, transform(0, line[i].Y, s).Y), ref crosses);
                        if (crosses != null)
                        {
                            crosses[0] = new PointF(crosses[0].X - PartRec.X, crosses[0].Y - PartRec.Y);
                            crosses[1] = new PointF(crosses[1].X - PartRec.X, crosses[1].Y - PartRec.Y);
                            PointF bpA = new PointF(breakpoint[i].A.X - PartRec.X, breakpoint[i].A.Y - PartRec.Y);
                            PointF bpB = new PointF(breakpoint[i].B.X - PartRec.X, breakpoint[i].B.Y - PartRec.Y);
                            lineOnImage.Add(new Line(crosses[0], crosses[1], bpA, bpB));
                        }
                    }
                    foreach (Line l in lineOnImage)
                    {
                        l.DrawLine(g);
                    }
                    lines[compound[idxCom]] = line;
                    //显示方程
                    lab_equation.Text = line.Count >= 1 ? toString(line[0]) : "";
                    lab_equation2.Text = line.Count >= 2 ? toString(line[1]) : "";
                    lab_equation3.Text = line.Count >= 3 ? toString(line[2]) : "";
                }
            }
        }

        private void paint()
        {
            Bitmap bm = new Bitmap(curveBox.Width, curveBox.Height);
            paint_point(bm);
            paint_frame(bm);
            curveBox.BackgroundImage = bm;
            backGround = bm;
        }

        //将数据点传入，并自适应坐标轴的大小
        private void paintData(List<PointF> data)
        {
            list.Clear();
            maxX = 0.0f;
            maxY = 0.0f;
            float minY = 0;
            foreach (PointF t in data)
            {
                list.Add(t);
                maxX = Math.Max(maxX, t.X);
                maxY = Math.Max(maxY, t.Y);
                minY = Math.Min(minY, t.Y);
            }
            maxX = (float)Math.Ceiling(maxX + 0.5);
            maxY = maxY * 1.1f;
            if (minY < 0 && -minY * 30 > maxY)
            {
                maxY = -minY * 30;
            }
            maxXLable.Text = string.Format("{0:0}%", maxX);
            maxYLable.Text = string.Format("{0:f}", maxY);
            selectedPoint = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                selectedPoint.Add(i);
            }
            paint();
        }

        #endregion

        #region   图像的放大

        //寻找选中的点，修改选中状态     //右击时，返回最初的图像
        private void curveBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int selectIdx = 0;
                float max = float.MaxValue;
                Size s = new Size((int)(curveBox.Width * magnification.X), (int)(curveBox.Height * magnification.Y));
                foreach (int i in selectedPoint)
                //for (int i = 0; i < list.Count; ++i)
                {
                    //PointF t = transform(list[i], curveBox.Size);
                    PointF t = transform(list[i], s);
                    //float d = (t.X - e.X) * (t.X - e.X) + (t.Y - e.Y) * (t.Y - e.Y);
                    float d = (e.X + PartRec.X - t.X) * (e.X + PartRec.X - t.X) + (e.Y + PartRec.Y - t.Y) * (e.Y + PartRec.Y - t.Y);
                    if (d < max)
                    {
                        max = d;
                        selectIdx = i;
                    }
                }
                if (max < 60) //响应距离，可修改
                {
                    states[compound[idxCom]][selectIdx] = !states[compound[idxCom]][selectIdx];
                    if (isModify.ContainsKey(compound[idxCom]))
                    {
                        isModify[compound[idxCom]] = true;
                    }
                    paint();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                initial();
            }
        }

        //以下四个变量和三个事件处理函数都用于图像的放大
        private Rectangle selector;   //记录框选时的矩形
        private Point startPoint;     //记录按下鼠标的位置
        private bool ismove;          //是否用鼠标进行了框选
        private bool isLargest;       //是否已经放大到最大
        private void curveBox_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }

        private void curveBox_MouseMove(object sender, MouseEventArgs e)
        {
            PointF current = new PointF();
            current.X = maxX * (PartRec.X + e.X) / (curveBox.Width * magnification.X);
            current.Y = maxY - maxY * (PartRec.Y + e.Y) / (curveBox.Height * magnification.Y) * 20 / 21;
            label14.Text = string.Format("X:{0:0.0} Y:{1:f}", current.X, current.Y);
            if (e.Button == MouseButtons.Left)
            {
                Bitmap copypic = new Bitmap(curveBox.Width, curveBox.Height);
                Graphics g = Graphics.FromImage(copypic);
                Pen pen = new Pen(Color.Black, 1);
                Point start = new Point(Math.Min(startPoint.X, e.X), Math.Min(startPoint.Y, e.Y));
                Point end = new Point(Math.Max(startPoint.X, e.X), Math.Max(startPoint.Y, e.Y));
                selector.Location = start;
                selector.Size = new Size((end.X - start.X), (end.Y - start.Y));
                selector.Intersect(curveBox.ClientRectangle);
                g.DrawImage(backGround, new Point(0, 0));
                g.DrawRectangle(pen, selector);
                curveBox.BackgroundImage = copypic;
                g.Dispose();
                ismove = true;
            }
        }

        private void curveBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (ismove)
            {
                if (isLargest)
                {
                    curveBox.BackgroundImage = backGround;
                }
                else
                {
                    for (int i = 0; i < pointOnImage.Count; i++)
                    {
                        PointF p = pointOnImage[i];
                        if (selector.Contains(new Point((int)p.X, (int)p.Y)))
                        {
                            selectedPoint.Add(i);
                        }
                    }
                    float pp_f_x = curveBox.Width / (float)selector.Width;
                    float pp_f_y = curveBox.Height / (float)selector.Height;
                    if (magnification.X * pp_f_x >= 20)
                    {
                        pp_f_x = 20 / magnification.X;
                        pp_f_y = pp_f_x;
                        selector.X += (int)(0.5f * (selector.Width - curveBox.Width / pp_f_x));
                        selector.Y += (int)(0.5f * (selector.Height - curveBox.Height / pp_f_y));
                        isLargest = true;
                    }
                    else if (magnification.Y * pp_f_y >= 20)
                    {
                        pp_f_y = 20 / magnification.Y;
                        pp_f_x = pp_f_y;
                        selector.X += (int)(0.5f * (selector.Width - curveBox.Width / pp_f_x));
                        selector.Y += (int)(0.5f * (selector.Height - curveBox.Height / pp_f_y));
                        isLargest = true;
                    }
                    magnification.X *= pp_f_x;
                    magnification.Y *= pp_f_y;
                    PartRec = new Rectangle((int)((selector.X + PartRec.X) * pp_f_x), (int)((selector.Y + PartRec.Y) * pp_f_y), curveBox.Width, curveBox.Height);
                    paint();
                    maxXLable.Text = string.Format("{0:0.0}%", maxX * (PartRec.X + curveBox.Width) / (curveBox.Width * magnification.X));
                    label15.Text = string.Format("{0:0.0}%", maxX * PartRec.X / (curveBox.Width * magnification.X));
                    maxYLable.Text = string.Format("{0:f}", maxY - maxY * PartRec.Y / (curveBox.Height * magnification.Y) * 20 / 21);
                    label13.Text = string.Format("{0:f}", maxY - maxY * (PartRec.Y + curveBox.Height * 20 / 21) / (curveBox.Height * magnification.Y) * 20 / 21);
                }
            }
            ismove = false;
        }

        private void curveBox_MouseLeave(object sender, EventArgs e)
        {
            label14.Text = "X:0 Y:0";
        }

        #endregion

        #region  处理一系列button和checkbox的事件

        //直线拟合（支持分段）
        private void isInterval_CheckedChanged(object sender, EventArgs e)
        {
            intervalBox1.Enabled = isInterval.Checked;
            intervalBox2.Enabled = isInterval.Checked;
            intervalButton.Enabled = isInterval.Checked;
            isIntervalList[idxCom] = isInterval.Checked;
            if (isInterval.Checked)
            {
                intervalBox1.Text = iv1[idxCom] + "";
                intervalBox2.Text = iv2[idxCom] + "";
            }
            else
            {
                iv1[idxCom] = 0;
                iv2[idxCom] = 0;
                isModify[compound[idxCom]] = true;
            }
            paint();
        }

        //是否显示拟合直线
        private void isShow_CheckedChanged(object sender, EventArgs e)
        {
            paint();
        }

        //分段按钮
        private void intervalButton_Click(object sender, EventArgs e)
        {
            if (isModify.ContainsKey(compound[idxCom]))
            {
                isModify[compound[idxCom]] = true;
            }
            float a = 0, b = 0;
            float.TryParse(intervalBox1.Text, out a);
            float.TryParse(intervalBox2.Text, out b);
            if (a < b)
            {
                iv1[idxCom] = a;
                iv2[idxCom] = b;
                paint();
            }
        }

        //是否显示RMS等
        private void isShowRMS_CheckedChanged(object sender, EventArgs e)
        {
            paint();
        }

        //是否显示DEF等
        private void isShowDEF_CheckedChanged(object sender, EventArgs e)
        {
            paint();
        }

        //是否显示指数常数
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            paint();
        }

        //上一个化合物
        private void preButton_Click(object sender, EventArgs e)
        {
            if (idxCom > 0)
            {
                --idxCom;
                nameLable.Text = compound[idxCom];
                initial();
            }
            isInterval.Checked = isIntervalList[idxCom];
            intervalBox1.Text = iv1[idxCom] + "";
            intervalBox2.Text = iv2[idxCom] + "";
        }

        //下一个化合物
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (idxCom < compound.Count - 1)
            {
                ++idxCom;
                nameLable.Text = compound[idxCom];
                initial();
            }
            isInterval.Checked = isIntervalList[idxCom];
            intervalBox1.Text = iv1[idxCom] + "";
            intervalBox2.Text = iv2[idxCom] + "";
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            //求出每个点是否被剔除
            foreach (string key in names.Keys)
            {
                List<bool> state = states[key];
                List<string> name = names[key];
                for (int i = 0; i < state.Count; ++i)
                    if (isIn.ContainsKey(key + "," + name[i]))
                    {
                        isIn[key + "," + name[i]] = state[i];
                    }
            }
            //读入regdata，并用当前点是否被剔除替换掉原来的数据
            string regData = XRF_function.QuantitationApplicationPath + "\\" + ApplicationNames + "\\RevisionData_" + ApplicationNames + ".txt";
            string regParam = XRF_function.QuantitationApplicationPath + "\\" + ApplicationNames + "\\ReLineParam_" + ApplicationNames + ".txt";
            string[] data = File.ReadAllLines(regData, Encoding.UTF8);
            string[] title = data[0].Split('\t');
            for (int i = 1; i < data.Length; ++i)
            {
                string[] item = data[i].Split('\t');
                for (int j = 0; j < item.Length; ++j)
                    if (isIn.ContainsKey(title[j] + "," + item[0]))
                    {
                        if (isIn[title[j] + "," + item[0]])
                        {
                            item[j] = "";
                        }
                        else
                        {
                            item[j] = "X";
                        }
                    }
                data[i] = string.Join("\t", item);
            }
            File.WriteAllLines(regData, data, Encoding.UTF8);
            //读入regparam,并将当前的拟合直线写入，同时计算RMS等参数一起写入
            data = File.ReadAllLines(regParam, Encoding.UTF8);
            for (int i = 1; i < data.Length; ++i)
            {
                string[] item = data[i].Split('\t');
                if (lines.ContainsKey(item[0]))
                {
                    List<PointF> list = lines[item[0]];
                    for (int j = 0; j < 3; ++j)
                    {
                        item[3 + j * 6] = "";
                        item[3 + j * 6 + 1] = "";
                    }
                    for (int j = 0; j < list.Count; ++j)
                    {
                        item[3 + j * 6] = list[j].X + "";
                        item[3 + j * 6 + 1] = list[j].Y + "";
                        //TODO 在这里加入各种参数的计算
                    }
                    for (int k = 0; k < compound.Count; ++k)
                        if (compound[k].Equals(item[0]))
                        {
                            if (isIntervalList[k])
                            {
                                item[24] = iv1[k] + "";
                                item[25] = iv2[k] + "";
                            }
                            else
                            {
                                item[24] = "0";
                                item[25] = "0";
                            }
                            break;
                        }

                }
                data[i] = string.Join("\t", item);
            }
            File.WriteAllLines(regParam, data, Encoding.UTF8);
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            //new ShowAllData().Show();
            ShowAllData checkdataRQForm = new ShowAllData();
            checkdataRQForm.ApplicationNames = ApplicationNames;
            checkdataRQForm.Show();
        }

        #endregion

        //放大或者切换页面后回到最开始的图像
        private void initial()
        {
            magnification = new PointF(1f, 1f);
            backGround = new Bitmap(curveBox.Width, curveBox.Height);
            PartRec = new Rectangle(0, 0, curveBox.Width, curveBox.Height);
            isLargest = false;
            paintData(map[compound[idxCom]]);
        }
    }
}
