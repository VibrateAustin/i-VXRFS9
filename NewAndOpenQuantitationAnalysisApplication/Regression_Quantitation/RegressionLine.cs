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
        //当前界面显示的点集
        public List<PointF> list = new List<PointF>();

        //是否为剔除点，key为化合物的名字
        public Dictionary<String, List<bool>> states = new Dictionary<string, List<bool>>();

        //每个化合物的样本名，key为化合物的名字
        public Dictionary<String, List<String>> names = new Dictionary<String, List<String>>();

        //每个数据点是否被剔除，key为化合物的名字
        public Dictionary<String, bool> isIn = new Dictionary<string, bool>();

        //每个化合物的拟合直线是否被修改过
        public Dictionary<String, bool> isModify = new Dictionary<string, bool>();

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
        //寻找选中的点，并变成红色
        private void curveBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int selectIdx = 0;
                float max = float.MaxValue;
                for (int i = 0; i < list.Count; ++i)
                {
                    PointF t = transform(list[i]);
                    float d = (t.X - e.X) * (t.X - e.X) + (t.Y - e.Y) * (t.Y - e.Y);
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
        }

        //坐标转换，数据坐标->绘图坐标
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

        //直线信息使用PointF这个类保存，参数p为一条直线，p.x为斜率，p.y为截距
        //根据复选框选择情况，生成显示信息
        //RMS，DEF等信息，可以在这个方法里计算，以及展示在界面最下方的文本框里
        private string toString(PointF p)
        {
            return (isShowDEF.Checked ? string.Format("D: {0}, E: {1}, F: 0  ", p.X.ToString("0.0000"), p.Y.ToString("0.0000")) : "") +
                (isShowRMS.Checked ? string.Format("RMS: {0}  ", p.X.ToString("0.0000")) : "");
            //TODO 单个直线的各种参数计算
        }

        //双缓冲绘图，根据各种复选框选择情况，绘制直线，点，坐标系，文本框等等
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
            for (int i = 0; i < list.Count; ++i)
            {
                PointF t = transform(list[i]);
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
                    for (int i = 1; i < line.Count; ++i)
                    {
                        PointF p = MathHelper.cross(lastline.X, lastline.Y, line[i].X, line[i].Y);
                        g.DrawLine(new Pen(Color.Blue, 1), transform(last, last * lastline.X + lastline.Y), transform(p.X, p.X * lastline.X + lastline.Y));
                        last = p.X;
                        lastline = line[i];
                    }
                    g.DrawLine(new Pen(Color.Blue, 1), transform(last, last * lastline.X + lastline.Y), transform(maxX, maxX * lastline.X + lastline.Y));
                }
                lines[compound[idxCom]] = line;
                //显示方程
                lab_equation.Text = line.Count >= 1 ? toString(line[0]) : "";
                lab_equation2.Text = line.Count >= 2 ? toString(line[1]) : "";
                lab_equation3.Text = line.Count >= 3 ? toString(line[2]) : "";
            }
            //画在背景上
            curveBox.BackgroundImage = bm;
            g.Dispose();
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
            paint();
        }

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
            paintData(map[compound[0]]);
        }

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
            return true;
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
            if (getLine(0, iv1[idxCom], ref line1))
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

        //上一个化合物
        private void preButton_Click(object sender, EventArgs e)
        {
            if (idxCom > 0)
            {
                --idxCom;
                nameLable.Text = compound[idxCom];
                paintData(map[compound[idxCom]]);
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
                paintData(map[compound[idxCom]]);
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
    }
}
