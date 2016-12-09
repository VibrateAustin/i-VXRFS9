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
    #region CAN卡内置的数据结构

    //CAN设备的硬件相关信息
    public struct VCI_BOARD_INFO
    {
        public UInt16 hw_Version;
        public UInt16 fw_Version;
        public UInt16 dr_Version;
        public UInt16 in_Version;
        public UInt16 irq_Num;
        public byte can_Num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] str_Serial_Num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] str_hw_Type;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Reserved;
    }

    //CAN设备传输的数据格式
    unsafe public struct VCI_CAN_OBJ
    {
        public uint ID;
        public uint TimeStamp;
        public byte TimeFlag;
        public byte SendType;
        public byte RemoteFlag;//是否是远程帧
        public byte ExternFlag;//是否是扩展帧
        public byte DataLen;
        public fixed byte Data[8];
        public fixed byte Reserved[3];
    }

    //CAN设备的状态
    public struct VCI_CAN_STATUS
    {
        public byte ErrInterrupt;
        public byte regMode;
        public byte regStatus;
        public byte regALCapture;
        public byte regECCapture;
        public byte regEWLimit;
        public byte regRECounter;
        public byte regTECounter;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Reserved;
    }

    //初始化CAN设备的数据类型
    public struct VCI_INIT_CONFIG
    {
        public UInt32 AccCode;
        public UInt32 AccMask;
        public UInt32 Reserved;
        public byte Filter;
        public byte Timing0;
        public byte Timing1;
        public byte Mode;
    }

    //CAN设备返回的错误信息
    public struct VCI_ERR_INFO
    {
        public UInt32 ErrCode;
        public byte Passive_ErrData1;
        public byte Passive_ErrData2;
        public byte Passive_ErrData3;
        public byte ArLost_ErrData;
    }

    //设置CAN设备的IP和端口信息
    public struct CHGDESIPANDPORT
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] szpwd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] szdesip;
        public Int32 desport;

        public void Init()
        {
            szpwd = new byte[10];
            szdesip = new byte[20];
        }
    }

    #endregion

    //存储从某个ID收到的数据
    public struct DataFromID
    {
        public byte ID;
        public List<byte> data;
        public int len;
        public DataFromID(byte ID, int length)
        {
            this.ID = ID;
            this.len = length;
            this.data = new List<byte>();
        }

        public byte[] GetOneData()
        {
            byte[] unit = new byte[len];
            for (int i = 0; i < len; i++)
            {
                unit[i] = data[i];
            }
            return unit;
        }

    }

    //引入CAN设备动态链接库中的函数
    public class Head_Class
    {
        public const int VCI_PCIE9120I = 27;
        public const int VCI_PCIE9110I = 28;
        public const int VCI_PCIE9140I = 29;

        public static UInt32 m_devtype = 28;//VCI_PCIE9110I
        public static UInt32 m_bOpen = 0;
        public static UInt32 m_devind = 0;
        public static UInt32 m_canind = 0;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <param name="DeviceInd"></param>
        /// <param name="Reserved"></param>
        /// <returns></returns>
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_OpenDevice(UInt32 DeviceType, UInt32 DeviceInd, UInt32 Reserved);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_CloseDevice(UInt32 DeviceType, UInt32 DeviceInd);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_InitCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_INIT_CONFIG pInitConfig);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_ReadBoardInfo(UInt32 DeviceType, UInt32 DeviceInd, ref VCI_BOARD_INFO pInfo);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_ReadErrInfo(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_ERR_INFO pErrInfo);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_ReadCANStatus(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_STATUS pCANStatus);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_GetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_SetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_GetReceiveNum(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, IntPtr pReceive, UInt32 Len, Int32 WaitTime);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_Transmit(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pSend, UInt32 Len);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_ClearBuffer(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_StartCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_ResetCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd); 
    }

    //数据传输类
    public class DataTransmitter
    {
        private DataConverter dc = new DataConverter();

        //发送数据
        unsafe public bool Send(byte[] data, uint ID)
        {
            List<byte[]> dataSection = dc.Section(data);
            int n = dataSection.Count;//需要发送的帧数
            VCI_CAN_OBJ[] frames = new VCI_CAN_OBJ[50];
            for (int i = 0; i < n; i++)
            {
                frames[i].ID = ID;
                frames[i].SendType = 0;//表示发送的帧类型，比如正常发送、自发自收等，以后需要修改
                frames[i].RemoteFlag = 0;
                frames[i].ExternFlag = 0;
                frames[i].DataLen = (byte)dataSection[i].Length;
                fixed (VCI_CAN_OBJ* p = frames)
                {
                    for (int j = 0; j < dataSection[i].Length; j++)
                    {
                        p[i].Data[j] = dataSection[i][j];
                    }
                }
            }
            uint m = Head_Class.VCI_Transmit(Head_Class.m_devtype, Head_Class.m_devind, Head_Class.m_canind, ref frames[0], (uint)n);//m表示实际发送成功的帧数
            if (m == n)
            {
                //可以添加其他的提示信息
                return true;
            }
            else
            {
                //可以添加其他的提示信息
                return false;
            }
        }

        //接收数据并存储在List<ReceivedData>中
        unsafe public void Receive()
        {
            uint res = Head_Class.VCI_GetReceiveNum(Head_Class.m_devtype, Head_Class.m_devind, Head_Class.m_canind);
            if (res == 0)
                return;
            //开辟内存并接收数据
            uint con_maxlen = 50;
            IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * (Int32)con_maxlen);
            res = Head_Class.VCI_Receive(Head_Class.m_devtype, Head_Class.m_devind, Head_Class.m_canind, pt, con_maxlen, 100);
            //存储数据
            for (uint i = 0; i < res; i++)
            {
                VCI_CAN_OBJ obj = (VCI_CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));
                int index = 0;
                foreach (DataFromID rd in GlobalVariables.data_can)
                {
                    if (rd.ID == obj.ID)
                    {
                        index = GlobalVariables.data_can.IndexOf(rd);
                        break;
                    }
                }
                if (obj.RemoteFlag == 0)
                {
                    for (int j = 0; j < obj.DataLen; j++)
                    {
                        GlobalVariables.data_can[index].data.Add(obj.Data[j]);
                    }
                }
            }
            //释放内存
            Marshal.FreeHGlobal(pt);
            Head_Class.VCI_ClearBuffer(Head_Class.m_devtype, Head_Class.m_devind, Head_Class.m_canind);
        }

        //从List<ReceivedData>中取出数据
        public byte[] GetData(uint ID)
        {
            int index = -1;
            foreach (DataFromID rd in GlobalVariables.data_can)
            {
                if (rd.ID == ID)
                {
                    index = GlobalVariables.data_can.IndexOf(rd);
                    break;
                }
            }
            DataFromID r = GlobalVariables.data_can[index];
            if (r.data.Count < r.len)
            {
                return r.data.ToArray();
            }
            else
            {
                byte[] result = r.data.GetRange(0, r.len).ToArray();
                r.data.RemoveRange(0, r.len);
                return result;
            }
        }
    }

    //不同类型的数据的转换类
    public class DataConverter
    {
        //将要传输的长数据分段，以便于分帧发送
        public List<byte[]> Section(byte[] data)
        {
            List<byte[]> section = new List<byte[]>();
            if (data.Length % 8 != 0)
            {
                int n = data.Length / 8 + 1;
                for (int i = 0; i < n - 1; i++)
                {
                    byte[] sec = new byte[8];
                    Array.Copy(data, i * 8, sec, 0, 8);
                    section.Add(sec);
                }
                byte[] lastSection = new byte[data.Length % 8];
                Array.Copy(data, (n - 1) * 8, lastSection, 0, data.Length % 8);
                section.Add(lastSection);
                return section;
            }
            else
            {
                int n = data.Length / 8;
                for (int i = 0; i < n; i++)
                {
                    byte[] sec = new byte[8];
                    Array.Copy(data, i * 8, sec, 0, 8);
                    section.Add(sec);
                }
                return section;
            }
        }

        //把字符串转换为byte[]，供调试时手动输入命令，例如把“00 00 00 00”形式的字符串转化为byte[]
        public byte[] StrToByte(string str)
        {
            int n = (str.Length + 1) / 3;
            byte[] data = new byte[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = System.Convert.ToByte("0x" + str.Substring(3 * i, 2), 16);
            }
            return data;
        }

        //把byte[]转换为字符串显示，把收到的数据转化为“00 00 00 00”形式显示
        public string ByteToStr(byte[] data)
        {
            int n = data.Length;
            string str = null;
            for (int i = 0; i < n; i++)
            {
                str += data[i].ToString("X2") + " ";
            }
            return str;
        }

        //把2theta角度转化为相应的theta,并且用byte[]来表示，因为theta是联动中输入的参数，而不是2theta
        public byte[] AngleToByte(double angle)
        {
            byte[] theta = new byte[3];
            theta[2] = (byte)((uint)(angle * 1000) % 256);
            theta[1] = (byte)((uint)((angle * 1000 - theta[2]) / 256) % (256 * 256));
            theta[0] = (byte)((uint)(angle * 1000 - theta[2]) / (256 * 256));
            return theta;
        }

        //把收到的byte[]数据解析转化为温度和压力
        public double[] ByteToTPa(byte[] data)
        {
            double[] TPa = new double[3];
            TPa[0] = (256 * data[1] + data[2]) / (double)10;
            TPa[1] = (16 * (256 * data[3] + data[4]) + data[5] / 16) / (double)10;
            TPa[2] = ((data[5] % 16) * 256 * 256 + data[6] * 256 + data[7]) / (double)10;
            return TPa;
        }
    }

    //CAN错误信息获取
    public class Error_type
    {
        private static void getError_info(UInt32 errorCode, VCI_ERR_INFO pErrInfo, ref string errorStr)
        {
            //if (errorCode == 0)
            //{
            if ((pErrInfo.ErrCode & 0x0100) == 0x0100)
                errorStr = "device already opened";
            else if ((pErrInfo.ErrCode & 0x0200) == 0x0200)
                errorStr = "opening device has error!";
            else if ((pErrInfo.ErrCode & 0x0400) == 0x0400)
                errorStr = "device has not opened";
            else if ((pErrInfo.ErrCode & 0x0800) == 0x0800)
                errorStr = "buffer overflow";
            else if ((pErrInfo.ErrCode & 0x1000) == 0x1000)
                errorStr = "device has not existed";
            else if ((pErrInfo.ErrCode & 0x2000) == 0x2000)
                errorStr = "loading dynamic library failed";
            else if ((pErrInfo.ErrCode & 0x4000) == 0x4000)
                errorStr = "execute order failed";
            else if ((pErrInfo.ErrCode & 0x8000) == 0x8000)
                errorStr = "memory not enough";
            else if ((pErrInfo.ErrCode & 0x0001) == 0x0001)
                errorStr = "CAN controller FIFO overflow";
            else if ((pErrInfo.ErrCode & 0x0002) == 0x0002)
                errorStr = "CAN controller error warning";
            else if ((pErrInfo.ErrCode & 0x0010) == 0x0010)
                errorStr = "CAN controller bus error";
            else if ((pErrInfo.ErrCode & 0x0004) == 0x0004)
            {
                errorStr = "CAN controller negative error" + pErrInfo.Passive_ErrData1.ToString();
            }
            else if ((pErrInfo.ErrCode & 0x0008) == 0x0008)
            {
                errorStr = "CAN controller arbitrate error" + pErrInfo.ArLost_ErrData.ToString();
            }
            //selse errorStr = "do not know error in details";
            // }
        }

        //接收错误信息数据结构
        private static VCI_ERR_INFO pErrInfo = new VCI_ERR_INFO();
        //获取错误信息
        public static string getError()
        {
            UInt32 error_Data = Head_Class.VCI_ReadErrInfo(Head_Class.m_devtype, Head_Class.m_devind, Head_Class.m_canind, ref pErrInfo);
            string errInfo = null;
            Error_type.getError_info(error_Data, pErrInfo, ref errInfo); //获取错误信息
            return errInfo;
        }
    }
}
