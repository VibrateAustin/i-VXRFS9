using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace i_VXRFS
{
    //步进扫描的参数结构
    public struct ScanParameter
    {
        public double start;
        public double end;
        public double step;
        public double stoptime;
        public byte speed;
        //构造函数
        public ScanParameter(double start, double end, double step, double stoptime, byte speed)
        {
            this.start = start;
            this.end = end;
            this.step = step;
            this.stoptime = stoptime;
            this.speed = speed;
        }
    }

    //样品交换系统
    public class Exchange
    {
        public struct Operation
        {
            public byte action;
            public int position;
            public byte expectation;

            //构造函数
            public Operation(byte a, int p, byte e)
            {
                action = a;
                position = p;
                expectation = e;
            }
        }

        //包含了样品交换系统所有需要的命令
        private List<Operation> orders = new List<Operation>
        {
            new Operation(0x00, 0, 0xAB),   //无响应
            new Operation(0x01, 1, 0x01),   //外轴上升
            new Operation(0x02, 1, 0x02),   //外轴下降
            new Operation(0x03, 2, 0x03),   //内轴上升
            new Operation(0x04, 2, 0x04),   //内轴下降
            new Operation(0x05, 3, 0x05),   //内轴自旋
            new Operation(0x06, 4, 0x06),   //转到放样位
            new Operation(0x07, 4, 0x07),   //转到测样位
            new Operation(0x08, 4, 0x08),   //转到维修位
            new Operation(0x09, 5, 0x09),   //样品盖开
            new Operation(0x0A, 5, 0x0A),   //样品盖关
            new Operation(0x0B, 6, 0x00),   //抓手放
            new Operation(0x0C, 6, 0x01),   //抓手取
        };

        private byte[] query = new byte[] { 0xAC, 0xBD };
        private DataTransmitter dt = new DataTransmitter();
        private Optical optical = new Optical();
        private Atmosphere atmosphere = new Atmosphere();
        private uint sID = 0x02, rID = 0x20;


        //查询
        public byte[] Check()
        {
            byte[] back = null;
            if (!dt.Send(query, sID))
                return back;
            DateTime startT = DateTime.Now;
            do
            {
                back = dt.GetData(rID);
                if (back.Length == 23)
                    break;
            }
            while ((DateTime.Now - startT).TotalMilliseconds < 1000);//1000毫秒之后出现延时错误
            return back;
        }
        //单步操作，包括命令执行之后验证是否到位，返回bool类型表示是否操作成功
        public bool Operate(Operation operation)
        {
            byte[] order = new byte[] { 0xAA, operation.action, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0xBB };
            if (!dt.Send(order, sID))
                return false;
            byte[] back = null;
            DateTime startT = DateTime.Now;
            do
            {
                back = Check();
                if (back.Length != 23)
                    break;
                else if (!back.Take(6).ToList().Contains(0))
                    break;
            }
            while ((DateTime.Now - startT).TotalMilliseconds < 5000);//5000毫秒之后出现延时错误
            if (back != null && back.Length == 23)
            {
                if (back[operation.position] == operation.expectation)
                {
                    return true;
                }
                else
                {
                    //可以添加其他提示信息
                    return false;
                }
            }
            else
            {
                //可以添加其他提示信息
                return false;
            }
        }

        public bool Initial()
        {
            //初始化R
            byte[] initialR = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            if (!optical.Initial())
                return false;

            //外轴上升
            if (!Operate(orders[1]))
                return false;
            //内轴下降
            if (!Operate(orders[4]))
                return false;
            //关闭样品盖
            if (!Operate(orders[10]))
                return false;

            //判断压力，抽真空
            //
            //
            //抽真空结束

            //外轴下降
            if (!Operate(orders[2]))
                return false;

            //检查内、外轴是否处于低位
            byte[] back = null;
            DateTime startT = DateTime.Now;
            do
            {
                back = Check();
                if (back.Length != 23)
                    break;
                else if (!back.Take(6).ToList().Contains(0))
                    break;
            }
            while ((DateTime.Now - startT).TotalMilliseconds < 5000);
            if (back == null || back.Length != 23)
                return false;
            if (back[1] != 0x02 || back[2] != 0x04)
                return false;
            //检查完成

            //转动转轴
            if (!Operate(orders[6]))
                return false;

            //初始化R
            if (!optical.Initial())
                return false;
            //初始化R完成

            //外轴上升
            if (!Operate(orders[1]))
                return false;

            //检查压力，放气
            //
            //
            //放气完成

            //打开样品盖
            if (!Operate(orders[9]))
                return false;
            //内轴上升
            if (!Operate(orders[3]))
                return false;
            else
                return true;
        }

        public bool Input()
        {
            //初始化R
            byte[] initialR = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            if (!optical.Initial())
                return false;
            //初始化R结束

            //外轴上升
            if (!Operate(orders[1]))
                return false;

            //检查样品室是否有样品，决定是否要先用抓手取，还是直接抓手放
            //
            //
            //放样完成

            //内轴下降
            if (!Operate(orders[4]))
                return false;
            //关闭样品盖
            if (!Operate(orders[10]))
                return false;

            //判断压力，抽真空
            //
            //
            //抽真空结束

            //外轴下降
            if (!Operate(orders[2]))
                return false;

            //检查内、外轴是否处于低位，还要检查转轴处于06还是07位
            byte[] back = null;
            DateTime startT = DateTime.Now;
            do
            {
                back = Check();
                if (back.Length != 23)
                    break;
                else if (!back.Take(6).ToList().Contains(0))
                    break;
            }
            while ((DateTime.Now - startT).TotalMilliseconds < 5000);
            if (back == null || back.Length != 23)
                return false;
            if (back[1] != 0x02 || back[2] != 0x04)
                return false;
            //检查完成

            //根据上一个检查结果转动转轴
            if (back[4] == 0x06)
            {
                if (!Operate(orders[7]))
                    return false;
            }
            else if (back[4] == 0x07)
            {
                if (!Operate(orders[6]))
                    return false;
            }
            else
            {
                return false;
            }
            //转轴转动完成

            //初始化R
            if (!optical.Initial())
                return false;
            //初始化R完成

            //外轴上升
            if (!Operate(orders[1]))
                return false;
            else
                return true;

            //检查压力，放气
            //
            //
            //放气完成

            //打开样品盖
            //if (!Operate(orders[9]))
            //    return false;
            //内轴上升
            //if (!Operate(orders[3]))
            //    return false;
            //else
            //    return true;
        }

        public bool Output()
        {
            //检查压力，抽真空
            //
            //
            //抽真空完成

            //外轴下降
            if (!Operate(orders[2]))
                return false;
            //内轴下降
            if (!Operate(orders[4]))
                return false;

            //再次检查内、外轴是否处于低位，还要确定转轴是处于07位还是06位
            byte[] back = null;
            DateTime startT = DateTime.Now;
            do
            {
                back = Check();
                if (back.Length != 23)
                    break;
                else if (!back.Take(6).ToList().Contains(0))
                    break;
            }
            while ((DateTime.Now - startT).TotalMilliseconds < 5000);
            if (back == null || back.Length != 23)
                return false;
            if (back[1] != 0x02 || back[2] != 0x04)
                return false;
            //检查完成

            //根据上一步的结果转动转轴
            if (back[4] == 0x06)
            {
                if (!Operate(orders[7]))
                    return false;
            }
            else if (back[4] == 0x07)
            {
                if (!Operate(orders[6]))
                    return false;
            }
            else
            {
                return false;
            }
            //转轴转动wancheng

            //初始化R
            byte[] initialR = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            if (!optical.Initial())
                return false;
            //初始化R完成

            //外轴上升
            if (!Operate(orders[1]))
                return false;

            //检查压力，放气
            //
            //
            //放气完成

            //打开样品盖
            if (!Operate(orders[9]))
                return false;
            //内轴上升
            if (!Operate(orders[3]))
                return false;
            else
                return true;
        }
    }

    //分光系统
    public class Optical
    {
        DataTransmitter dt = new DataTransmitter();
        //public struct Sites
        //{
        //    byte frontstop;
        //    byte backstop;
        //    byte filter;
        //    byte collimator;
        //    byte microA;
        //    byte microR;
        //    byte crystal;
        //    byte detector;

        //    public Sites(byte[] sites)
        //    {
        //        frontstop = sites[0];
        //        backstop = sites[1];
        //        filter = sites[2];
        //        collimator = sites[3];
        //        microA = sites[4];
        //        microR = sites[5];
        //        crystal = sites[6];
        //        detector = sites[7];
        //    }
        //}

        private byte[] query = new byte[] { 0xAC, 0xBD };

        //查询
        public byte[] Check()
        {
            byte[] back = null;
            if (!dt.Send(query, 0x02))
                return back;
            DateTime startT = DateTime.Now;
            do
            {
                back = dt.GetData(0x20);
                if (back.Length == 23)
                    break;
            }
            while ((DateTime.Now - startT).TotalMilliseconds < 1000);//1000毫秒之后出现延时错误
            return back;
        }
        public bool Initial()
        {
            //byte[] order = new byte[] { 0xAA, 0x00, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0xFF, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0xBB };
            //if (!dt.Send(order, 0x02))
            //    return false;
            //if (!dt.Send(query, 0x02))
            //    return false;
            //Thread.Sleep(5000);
            //byte[] back = dt.Receive(0x20);
            ////可以添加对back数据格式的验证，避免出现索引溢出等错误
            //for (int i = 0; i < 8; i++)
            //{
            //    if (back[i + 7] != order[i + 2])
            //    {
            //        return false;
            //    }
            //}
            //return true;
            //初始化的另外一种实现方式是直接调用Operate函数
            byte[] initial = new byte[] { 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0xFF };
            if (!Operate(initial))
            {
                return false;
            }
            return true;
        }

        public bool Operate(byte[] site)
        {
            byte[] order = new byte[] { 0xAA, 0x00, site[0], site[1], site[2], site[3], site[4], site[5], site[6], site[7], 0x00, 0x00, 0x00, 0x00, 0x00, 0xBB };
            if (!dt.Send(order, 0x02))
                return false;
            byte[] back = null;
            DateTime startT = DateTime.Now;
            do
            {
                back = Check();
                if (back.Length != 23)
                    break;
                else if (!back.ToList().GetRange(7, 8).Contains(0))
                    break;
            }
            while ((DateTime.Now - startT).TotalMilliseconds < 5000);
            //可以添加对back数据格式的验证，避免出现索引溢出等错误
            for (int i = 0; i < 8; i++)
            {
                if (back[i + 7] != order[i + 2])
                {
                    return false;
                }
            }
            return true;
        }
    }

    //真空和温控系统
    public class Atmosphere
    {
        DataTransmitter dt = new DataTransmitter();
        DataConverter dc = new DataConverter();

        public double Pa_sample;
        public double Pa_optical;
        public double T;

        private List<byte[]> orders = new List<byte[]>
        {
            new byte[] {0x07,0x0F,0x01,0x00,0x00,0x00,0x00,0x00},
            new byte[] {0x07,0x0F,0x02,0x00,0x00,0x00,0x00,0x00},
            new byte[] {0x07,0x0F,0x03,0x00,0x00,0x00,0x00,0x00},
            new byte[] {0x07,0x0F,0x04,0x00,0x00,0x00,0x00,0x00},
            new byte[] {0x07,0x0F,0xFF,0x00,0x00,0x00,0x00,0x00},
            new byte[] {0x07,0x00,0x00,0x00,0x0F,0x01,0x00,0x00},
            new byte[] {0x07,0x00,0x00,0x00,0x0F,0x02,0x00,0x00},
            new byte[] {0x07,0x00,0x00,0x00,0x0F,0xFF,0x00,0x00},
        };

        public void GetPaAndT()
        {
            byte[] back = dt.GetData(0x70);
            double[] re = dc.ByteToTPa(back);
            this.T = re[0];
            this.Pa_sample = re[1];
            this.Pa_optical = re[2];
        }

        public bool Operate(byte[] order)
        {
            if (!dt.Send(order, 0x07))
                return false;
            return true;
        }
    }

    //X射线光管高压与管流控制系统
    public class XTube
    {
        DataTransmitter dt = new DataTransmitter();
        public int voltage = 0, current = 0;

        private List<byte[]> voltageOrders = new List<byte[]>
        {
            new byte[] { 0xA1, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA2, 0x01, 0xB8, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA2, 0x02, 0x0A, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA2, 0x02, 0x5C, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA2, 0x02, 0xAE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA2, 0x03, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA2, 0x03, 0x51, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA2, 0x03, 0x99, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA2, 0x03, 0xE6, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA1, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }
        };
        private List<byte[]> currentOrders = new List<byte[]>
        {
            new byte[] { 0xA3, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x00, 0x42, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x00, 0x56, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x00, 0x69, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x00, 0x7D, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x00, 0x92, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x00, 0xA5, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x00, 0xB8, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x00, 0xCB, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x00, 0xDF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x00, 0xF1, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x01, 0x04, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x01, 0x18, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x01, 0x2B, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x01, 0x3F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x01, 0x53, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x01, 0x66, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x01, 0x79, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x01, 0x8D, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA4, 0x01, 0x9F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
            new byte[] { 0xA3, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },
        };

        public bool Step(byte[] order)
        {
            if (!dt.Send(order, 0x40))
                return false;
            byte[] back = null;
            DateTime startT = DateTime.Now;
            do
            {
                back = dt.GetData(0x04);
                if (back.Length == 8)
                    break;
            }
            while ((DateTime.Now - startT).TotalMilliseconds < 15000);
            if (back == null)
                return false;
            if (back[0] == 0x23)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Initial()
        {
            if (!Step(currentOrders[0]))
                return false;
            if (!Step(voltageOrders[0]))
                return false;
            if (!Step(voltageOrders[1]))
                return false;
            voltage = 25;
            if (!Step(currentOrders[1]))
                return false;
            else
                current = 10;
            return true;
        }

        public bool ChangeTo(int vol, int cur)
        {
            int v = Math.Abs(vol - voltage) / 5;
            int c = Math.Abs(cur - current) / 5;
            int volStep = (vol > voltage) ? 5 : -5;
            int curStep = (cur > current) ? 5 : -5;
            //如果同时升和同时降
            if ((volStep >= 0 && curStep >= 0) || (volStep <= 0 && curStep <= 0))
            {
                int n1 = Math.Min(v, c);
                int n2 = Math.Abs(v - c);
                //第一步：交叉走
                for (int i = 0; i < n1; i++)
                {
                    int index_v = (voltage + volStep - 20) / 5;
                    if (!Step(voltageOrders[index_v]))
                        return false;
                    else
                        voltage += volStep;
                    Thread.Sleep(3000);//每次返回数据成功之后再休眠3秒钟稳定一下
                    int index_c = (current + curStep - 5) / 5;
                    if (!Step(currentOrders[index_c]))
                        return false;
                    else
                        current += curStep;
                    Thread.Sleep(3000);
                }
                //第二步：交叉走完成之后还没有到达目标数值的，再单独走
                if (v > c)
                {
                    for (int j = 0; j < n2; j++)
                    {
                        int index_v = (voltage + volStep - 20) / 5;
                        if (!Step(voltageOrders[index_v]))
                            return false;
                        else
                            voltage += volStep;
                        Thread.Sleep(3000);
                    }
                }
                else if (v < c)
                {
                    for (int j = 0; j < n2; j++)
                    {
                        int index_c = (current + curStep - 5) / 5;
                        if (!Step(currentOrders[index_c]))
                            return false;
                        else
                            current += curStep;
                        Thread.Sleep(3000);
                    }
                }
            }
            //如果一个升一个降，则先降一步，降完之后判断另一个是否可以上升（是否超出功率），如果不可以上升则继续下降
            else if ((volStep > 0 && curStep < 0) || (volStep < 0 && curStep > 0))
            {
                //如果是电压升，电流降
                if (volStep > 0 && curStep < 0)
                {
                    do
                    {
                        do
                        {
                            int index_c = (current + curStep - 5) / 5;
                            if (!Step(currentOrders[index_c]))
                                return false;
                            else
                                current += curStep;
                            Thread.Sleep(3000);
                        }
                        while ((voltage + 5) * current > 4000);
                        int index_v = (voltage + volStep - 20) / 5;
                        if (!Step(voltageOrders[index_v]))
                            return false;
                        else
                            voltage += volStep;
                        Thread.Sleep(3000);
                    }
                    while (voltage != vol && current != cur);
                }
                //如果是电流升，电压降
                else if (volStep < 0 && curStep > 0)
                {
                    do
                    {
                        do
                        {
                            int index_v = (voltage + volStep - 20) / 5;
                            if (!Step(voltageOrders[index_v]))
                                return false;
                            else
                                voltage += volStep;
                            Thread.Sleep(3000);
                        }
                        while ((current + 5) * voltage > 4000);
                        int index_c = (current + curStep - 5) / 5;
                        if (!Step(currentOrders[index_c]))
                            return false;
                        else
                            current += curStep;
                        Thread.Sleep(3000);
                    }
                    while (voltage != vol && current != cur);
                }
                //电压或者电流到达预设点之后，另一个继续升降
                if (voltage == vol)
                {
                    int n = Math.Abs((cur - current) / 5);
                    for (int j = 0; j < n; j++)
                    {
                        int index_c = (current + curStep - 5) / 5;
                        if (!Step(currentOrders[index_c]))
                            return false;
                        else
                            current += curStep;
                        Thread.Sleep(3000);
                    }
                }
                else if (current == cur)
                {
                    int n = Math.Abs((vol - voltage) / 5);
                    for (int j = 0; j < n; j++)
                    {
                        int index_v = (voltage + volStep - 20) / 5;
                        if (!Step(voltageOrders[index_v]))
                            return false;
                        else
                            voltage += volStep;
                        Thread.Sleep(3000);
                    }
                }
            }
            //for (int i = 0; i < v; i++)
            //{
            //    int index = (voltage + volStep - 20) / 5;
            //    if (!Step(voltageOrders[index]))
            //        return false;
            //    else
            //        voltage += 5;
            //    Thread.Sleep(3000);//每次返回数据成功之后再休眠3秒钟稳定一下
            //}
            //for (int i = 0; i < c; i++)
            //{
            //    int index = (current + curStep - 5) / 5;
            //    if (!Step(currentOrders[index]))
            //        return false;
            //    else
            //        current += 5;
            //    Thread.Sleep(3000);
            //}
            return true;
        }

        public bool Close()
        {
            if (!ChangeTo(25, 10))
                return false;
            if (!Step(voltageOrders[9]))
                return false;
            if (!Step(currentOrders[20]))
                return false;
            return true;
        }
    }

    //测角仪控制系统
    public class Goniometer
    {
        DataTransmitter dt = new DataTransmitter();
        DataConverter dc = new DataConverter();
        public double TwoTheta = 10;//表示2theta角度，理论计算用的角度，即使有PC附加转动这个值也不变，变的是actual
        public double Theta = 5;
        public double actual = 10;//真实的2theta角度，因为可以有附加转动
        private double additional = 30;

        public byte[] Check()
        {
            byte[] back = null;
            DateTime startT = DateTime.Now;
            do
            {
                back = dt.GetData(0x05);
                if (back.Length == 8)
                    break;
                Thread.Sleep(10);
            }
            while ((DateTime.Now - startT).TotalMilliseconds < 15000);//超时时间可用移动角度大致计算
            return back;
        }
        public bool Initial()
        {
            byte[] order = new byte[] { 0x82, 0xFF, 0xFF, 0xFF, 0xFF, 0x0A, 0xFF, 0xFF };
            if (!dt.Send(order, 0x50))
                return false;
            byte[] back = Check();
            if (back == null)
                return false;
            if (back[0] == 0x07 && back[1] == 0x0A)
            {
                TwoTheta = 10;
                Theta = 5;
                actual = TwoTheta;
                return true;
            }
            else
            {
                return false;
            }
        }

        //只是单纯的一起移动，不考虑大角度到小角度多会2°的问题
        private bool MoveTogether(double destination, byte speed)
        {
            double angle = Math.Abs(destination - TwoTheta);
            byte direction = (byte)(destination > TwoTheta ? 1 : 0);
            byte[] span = dc.AngleToByte(angle);
            byte[] order = new byte[] { 0x72, direction, span[0], span[1], span[2], speed, 0xFF, 0xFF };
            if (!dt.Send(order, 0x50))
                return false;
            byte[] back = Check();
            if (back == null)
                return false;
            if (back[0] == 0x07 && back[1] == 0x0A)
            {
                TwoTheta = destination;
                Theta = destination / 2;
                actual = TwoTheta;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool MoveTogetherPrecisely(double destination, byte speed)
        {
            //小角度到大角度直接转
            if (destination > TwoTheta)
            {
                if (!MoveTogether(destination, speed))
                    return false;
            }
            //大角度到小角度要先多回2°，再往大角度方向走2°
            else
            {
                if (!MoveTogether(destination - 2, speed))
                    return false;
                if (!MoveTogether(destination, speed))
                    return false;
            }
            return true;
        }

        //也是单纯移动2theta附加角，不考虑大角度到小角度多回2°的问题
        private bool MoveTwoTheta(double destination, byte speed)
        {
            double angle = 2 * Math.Abs(destination - actual);
            byte direction = (byte)(destination > actual ? 1 : 0);
            byte[] span = dc.AngleToByte(angle);
            byte[] order = new byte[] { 0x71, direction, span[0], span[1], span[2], speed, 0xFF, 0xFF };
            if (!dt.Send(order, 0x50))
                return false;
            byte[] back = Check();
            if (back == null)
                return false;
            if (back[0] == 0x07 && back[1] == 0x0A)
            {
                actual = destination;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool MoveTwoThetaPrecisely(double destination, byte speed)
        {
            if (destination > TwoTheta)
            {
                if (!MoveTwoTheta(destination, speed))
                    return false;
            }
            //大角度到小角度要先多回2°，再往大角度方向走2°
            else
            {
                if (!MoveTwoTheta(destination - 2, speed))
                    return false;
                if (!MoveTwoTheta(destination, speed))
                    return false;
            }
            return true;
        }

        //定点测量
        public bool FixedPoint(double destination, byte speed, string detector)
        {
            if (detector == "PC")
            {
                if (!MoveTogetherPrecisely(destination, speed))
                    return false;
                if (actual == TwoTheta)
                {
                    if (!MoveTwoThetaPrecisely(actual + additional, speed))
                        return false;
                }
            }
            else if (detector == "SC")
            {
                if (!MoveTogetherPrecisely(destination, speed))
                    return false;
                if (actual != TwoTheta)
                {
                    if (!MoveTwoThetaPrecisely(actual - additional, speed))
                        return false;
                }
            }
            //开始用8000D进行采谱
            //
            //
            //采谱完成
            return true;
        }

        //步阶扫描
        public async Task<bool> StepScan(ScanParameter paramter, int low, int high, Func<EndPoint, double, int, int, Task<double>> mca)
        {
            GlobalVariables.strength.Clear();
            double start = paramter.start;
            double end = paramter.end;
            double step = paramter.step;
            double stoptime = paramter.stoptime;
            EndPoint deviceIP = new IPEndPoint(IPAddress.Parse("192.168.0.1"), 10001);

            //if (!MoveTogetherPrecisely(start - step, 0x0A))
            //    return false;
            int n = (int)((end - start) / step);
            for (int i = 1; i <= n + 1; i++)
            {
                //if (!MoveTogetherPrecisely(start + i * step, paramter.speed))
                //    return false;
                //使用8000D进行采谱
                double strength = await mca(deviceIP, stoptime, low, high);
                GlobalVariables.strength.Add((float)strength);
                //
                //采谱完成
            }
            string path = @"C:\Users\佘晓萌\Desktop\spec.txt";
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(stream);
            for (int i = 0; i < GlobalVariables.strength.Count; i++)
            {
                writer.WriteLine(GlobalVariables.strength[i]);
            }
            writer.Close();
            stream.Close();

            //可以添加把数据保存到txt文件的操作
            return true;
        }
    }
}
