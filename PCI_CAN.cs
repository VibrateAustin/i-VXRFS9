using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i_VXRFS
{
    public class PCI_CAN
    {
        
        


    }
    //读取*.txt数据，放到相应的数组或列表中
    public class ReadText
    {
        //分别获取-通用参数，条件，样品描述，添加剂化合物表，待测元素化合物表，待测元素参数表，公共背景参数表1，公共背景参数表2
        //所在数组中的索引号的方法；
        public static List<int> getdataindex(List<string> allinfo)
        {
            List<int> index = new List<int> { };
            // int k = 0;
            for (int j = 0; j < allinfo.Count(); j++)
            {
                if (allinfo[j] == "通用参数")
                {
                    index.Add(j);
                    continue;
                }
                if (allinfo[j] == "条件")
                {
                    index.Add(j);
                    continue;
                }
                if (allinfo[j] == "样品描述")
                {
                    index.Add(j);
                    continue;
                }
                if (allinfo[j] == "添加剂化合物表")
                {
                    index.Add(j);
                    continue;
                }
                if (allinfo[j] == "待测元素化合物表")
                {
                    index.Add(j);
                    continue;
                }
                if (allinfo[j] == "待测元素参数表")
                {
                    index.Add(j);
                    continue;
                }
                if (allinfo[j] == "公共背景参数表1")
                {
                    index.Add(j);
                    continue;
                }
                if (allinfo[j] == "公共背景参数表2")
                {
                    index.Add(j);
                    continue;
                }
            }
            return index;
        }
        //建立将字符串拆分的方法
        public static string[] splictstr(string str)
        {
            string[] resstr = { };
            resstr = str.Split(' ', '\t', ',');
            return resstr;
        } 
        //读取txt中的数据
        public static List<string> ReadFileData(string filepath){
            FileStream openfile = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite);
            StreamReader readDataSR = new StreamReader(openfile, Encoding.Default);
            readDataSR.BaseStream.Seek(0, SeekOrigin.Begin);//文件开头
            List<string> allinfo = new List<string> { };
            int i = 0;
            allinfo.Add(readDataSR.ReadLine());
            while (allinfo[i] != null)
            {
                allinfo.Add(readDataSR.ReadLine());
                i++;
            }
            return allinfo;
        }
        /// <summary>
        /// 分别获取-条件，样品描述，添加剂化合物表，待测元素化合物表，待测元素参数表，公共背景时间参数表1中的数据
        /// </summary>
        /// <param name="AllInfo">从txt文件中读取到的数据一维字符串数组</param>
        /// <param name="condition">条件数据,涉及到测量时参数的传递</param>
        /// <param name="sampDescibe">样品描述数据</param>
        /// <param name="addtiveTb">添加剂化合物表数据</param>
        /// <param name="compoundTb">待测化合物表数据</param>
        /// <param name="normalize">结果数据是否归一化</param>
        /// <param name="elementTb">待测元素参数表数据，涉及到测量时参数的传递</param>
        /// <param name="bgTimeTb">公共背景时间表数据</param>
        public static void getDetailData(List<string> AllInfo,ref List<string> condition,ref List<string> sampDescibe,
                                                        ref string[,] addtiveTb,ref string[,] compoundTb,ref List<string> normalize,ref string[,] elementTb,ref string[,] bgTimeTb )
        {
            //分别获取-通用参数，条件，样品描述，添加剂化合物表，待测元素化合物表，待测元素参数表，公共背景参数表1，公共背景参数表2
            //所在数组中的索引号； 
            List<int> index = new List<int> { };
            index = ReadText.getdataindex(AllInfo); //index[]记录上述各字段在allinfo数组中的索引号
            //获得条件数据
            string[] mediumStr = null;
            mediumStr = ReadText.splictstr(AllInfo[index[1] + 1]);
            ReadText.stringTransformToList(mediumStr, ref condition);
            mediumStr = null;
            mediumStr = ReadText.splictstr(AllInfo[index[1] + 2]);
            ReadText.stringTransformToList(mediumStr, ref condition);
            mediumStr = null;
            //获取样品描述数据
            mediumStr = ReadText.splictstr(AllInfo[index[2] + 1]);
            ReadText.stringTransformToList(mediumStr, ref sampDescibe);
            mediumStr = null;
            //添加剂表数据
            int k = 0;
            while ((index[3] + k + 2) < index[4])
            {
                mediumStr = ReadText.splictstr(AllInfo[index[3] + k + 2]);
                for (int i = 0; i < mediumStr.Length; i++)
                {
                    addtiveTb[k, i] = mediumStr[i];
                }
                k++;
                mediumStr = null;
            }
            //读取待测化合物表数据
            k = 0;
            while ((index[4] + k + 3) < index[5])
            {
                mediumStr = ReadText.splictstr(AllInfo[index[4] + k + 3]);
                for (int i = 0; i < mediumStr.Length; i++)
                {
                    compoundTb[k, i] = mediumStr[i];
                }
                k++;
                mediumStr = null;
            }
            mediumStr = ReadText.splictstr(AllInfo[index[4] + 1]);
            ReadText.stringTransformToList(mediumStr, ref normalize);//是否归一化变量
            mediumStr = null;
            //读取待测元素参数表数据
            k = 0;
            while ((index[5] + k + 2) < index[6])
            {
                mediumStr = ReadText.splictstr(AllInfo[index[5] + k + 2]);
                for (int i = 0; i < mediumStr.Length; i++)
                {
                    elementTb[k, i] = mediumStr[i];
                }
                k++;
                mediumStr = null;
            }
            //读取背景时间参数表
            k = 0;
            while ((index[6] + k + 3) < (AllInfo.Count - 1) && AllInfo[(index[6] + k + 3)] != " ")
            {
                mediumStr = ReadText.splictstr(AllInfo[index[6] + k + 3]);
                for (int i = 0; i < mediumStr.Length; i++)
                {
                    bgTimeTb[k, i] = mediumStr[i];
                }
                k++;
                mediumStr = null;
            }

        }
        /// <summary>
        /// 将字符串数据并接为List
        /// </summary>
        /// <param name="str"></param>
        /// <param name="listStr"></param>
        public static void stringTransformToList(string[] str,ref List<string> listStr)
        {
            for (int i = 0; i < str.Length;i++ )
            {
                listStr.Add(str[i]);
            }
        }
       
    }


}
