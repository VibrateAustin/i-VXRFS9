using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace i_VXRFS
{
    class GlobalVariables
    {
        //样品测量列表
        public static DataTable measure_list = new DataTable();

        //步进扫描中的强度数据，在测试过程中实时更新
        public static List<double> strength = new List<double>();

        //用来存储从CAN收到的所有数据
        public static List<DataFromID> data_can = new List<DataFromID>
            {
                new DataFromID(0x70, 8),
                new DataFromID(0x20, 23),
                new DataFromID(0x04, 8),
                new DataFromID(0x05, 8),
                new DataFromID(0x0A, 8),//具体多少字节是一个完整的数据包，待定
                new DataFromID(0x0B, 8),//同上
            };

    }
}
