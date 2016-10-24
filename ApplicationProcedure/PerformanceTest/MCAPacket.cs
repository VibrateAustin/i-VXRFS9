using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace i_VXRFS.ApplicationProcedure.PerformanceTest
{
    //所有数据包类型的基类，包含所有数据包类型共有的成员和操作
    public class Packet
    {
        protected byte[] packet;
        protected int pid1;
        protected int pid2;
        protected int dataLen;
        protected byte[] data;
        public byte[] checksum = new byte[2];

        //属性：PID
        public int PID1
        {
            get { return pid1; }
            set { pid1 = value; }
        }
        public int PID2
        {
            get { return pid2; }
            set { pid2 = value; }
        }

        //构造函数
        //构造函数1：无参构造函数
        public Packet() { }
        //构造函数2：不包含具体数据的数据包
        public Packet(int a, int b)
        {
            pid1 = a;
            pid2 = b;
            dataLen = 0;
            data = null;
        }
        //构造函数3：包含具体数据的数据包
        public Packet(int a, int b, byte[] d)
        {
            pid1 = a;
            pid2 = b;
            dataLen = d.Length;
            data = d;
        }
        //构造函数4：用全部字节数组实例化，主要用于接收从MCA传回来的数据
        public Packet(byte[] packet)
        {
            this.packet = packet;
            pid1 = packet[2];
            pid2 = packet[3];
            dataLen = 256 * packet[4] + packet[5];
            checksum[0] = packet[packet.Length - 2];
            checksum[1] = packet[packet.Length - 1];
            if (packet.Length == 8)
            {
                data = null;
            }
            else
            {
                data = new byte[packet.Length - 8];
                Array.Copy(packet, 6, data, 0, packet.Length - 8);
            }
        }

        //方法1：根据前面的字节计算CheckSum，要求PID或data必须有值
        //使用情形：1/计算传回的数据包的checksum以进行验证  2/在发送数据之前计算checksum进行赋值
        public byte[] CalCheckSum()
        {
            int sum = 0;
            if (data != null)
            {
                sum += data.Sum(b => Convert.ToInt32(b));
            }
            sum += (0xF5 + 0xFA + pid1 + pid2);
            sum += (dataLen % 256 + dataLen / 256);
            sum = 65536 - sum % 65536;
            byte[] check = new byte[2];
            check[0] = Convert.ToByte(sum / 256);
            check[1] = Convert.ToByte(sum % 256);
            if (checksum == null)
            {
                checksum = check;
            }
            return check;
        }
        //方法2：将此类转化为Byte[]数组形式，以便于传输
        public byte[] ToBinary()
        {
            int data_length = (data == null) ? 0 : data.Length;
            byte[] packetBinary = new byte[data_length + 8];
            packetBinary[0] = Convert.ToByte(0xF5);
            packetBinary[1] = Convert.ToByte(0xFA);
            packetBinary[2] = Convert.ToByte(pid1);
            packetBinary[3] = Convert.ToByte(pid2);
            packetBinary[4] = Convert.ToByte(data_length / 256);
            packetBinary[5] = Convert.ToByte(data_length % 256);
            if (data != null)
            {
                data.CopyTo(packetBinary, 6);

            }
            CalCheckSum().CopyTo(packetBinary, data_length + 6);
            packet = packetBinary;
            return packetBinary;
        }
    }

    //接收到的光谱数据包的类型，此类型派生于Packet，包含spec和status数据，而且只能表示多道数为2048的数据
    //主要属性：FastCount、SlowCount、AccTime、LiveTime、RealTime
    public class SpecPacket : Packet
    {
        private byte[] status = new byte[64];
        private byte[] spec;
        public List<double> countRate = new List<double>();

        //属性1：FastCount
        public ulong FastCount
        {
            get
            {
                ulong FastCount = status[0] + 256 * (status[1] + 256 * (status[2] + 256 * (uint)status[3]));
                return FastCount;
            }
        }
        //属性2：SlowCount
        public ulong SlowCount
        {
            get
            {
                ulong slowCount = status[4] + 256 * (status[5] + 256 * (status[6] + 256 * (uint)status[7]));
                return slowCount;
            }
        }
        //属性3：AccTime
        public ulong AccTime
        {
            get
            {
                ulong accTime = status[12] + 100 * (status[13] + 256 * (status[14] + 256 * (uint)status[15]));
                return accTime;
            }
        }
        //属性4：LiveTime
        public ulong LiveTime
        {
            get
            {
                ulong liveTime = status[16] + 256 * (status[17] + 256 * (status[18] + 256 * (uint)status[19]));
                return liveTime;
            }
        }
        //属性5：RealTime
        public ulong RealTime
        {
            get
            {
                ulong realTime = status[20] + 256 * (status[21] + 256 * (status[22] + 256 * (uint)status[23]));
                return realTime;
            }
        }

        //构造函数
        public SpecPacket(byte[] packet) : base(packet)
        {
            status = GetStatus();
        }

        //获取status
        private byte[] GetStatus()
        {
            status = new byte[64];
            Array.Copy(data, data.Length - 64, status, 0, 64);
            return status;
        }
        //获取spec
        private byte[] GetSpec()
        {
            spec = new byte[packet[4] * 256 + packet[5] - 64];
            Array.Copy(data, spec, spec.Length);
            return spec;
        }

        //方法1：计算每个channel的计数（count）
        public List<int> GetCount()
        {
            List<int> counts = new List<int>();
            spec = GetSpec();
            for (int i = 0; i < spec.Length; i += 3)
            {
                int count = 0;
                count += Convert.ToInt32(spec[i]);
                count += 256 * Convert.ToInt32(spec[i + 1]);
                count += 256 * 256 * Convert.ToInt32(spec[i + 2]);
                counts.Add(count);
            }
            return counts;
        }
        //方法2：计算每个channel的计数率（CountRate）
        public List<double> GetCountRate()
        {
            countRate.Clear();
            if (LiveTime != 0)
            {
                countRate = GetCount().ConvertAll(c => c / (double)LiveTime);
            }
            return countRate;
        }
        //方法3：计算总的计数率（TotalCountRate）：参数为设置的高低限
        public double GetTotalCountRate(int lowL,int upL)
        {
            double totalCR=0;
            List<double> cr= GetCountRate();
            for (int i=lowL;i<=upL;i++)
            {
                totalCR += cr[i];
            }
            return totalCR;
        }
    }

    //发送ASCII命令或者接收ReadBack的数据包，同样派生于Packet（涉及readback的可能还需要添加一些函数）
    public class CommandPacket : Packet
    {
        private List<string> command = new List<string>();

        //构造函数1：用于发送
        public CommandPacket(List<string> cm, string set_read)
        {
            pid1 = 0x20;
            if (set_read == "set")
            {
                pid2 = 2;
            }
            else if (set_read == "read")
            {
                pid2 = 3;
            }
            command = cm;
            data = CommandToBinary();
            dataLen = data.Length;
        }
        //构造函数2：用于接收
        public CommandPacket(byte[] packet) : base(packet) { }

        //方法1：把字符串命令转化为二进制数据
        private byte[] CommandToBinary()
        {
            string commandStr = "";
            for (int i = 0; i < command.Count; i++)
            {
                commandStr += command[i];
            }
            byte[] commandBinary = Encoding.UTF8.GetBytes(commandStr);
            return commandBinary;
        }
    }

    //用于广播寻找设备的ip地址
    public class BroadcastPacket
    {
        private byte[] packet = new byte[6];

        //构造函数
        public BroadcastPacket()
        {
            packet[0] = 0;
            packet[1] = 0;
            packet[4] = 0xF4;
            packet[5] = 0xFA;
            Random r = new Random();
            packet[2] = Convert.ToByte(r.Next(256));
            packet[3] = Convert.ToByte(r.Next(256));
        }
    }
}
