using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults
{
    public class Class_QualitationSpectraLine
    {
       // private List<double> RawData = new List<double> ();//原始数据
        //读取在该分析程序名文件夹文件中的数据，并显示在窗口相应的位置
        public static List<double> ReadDataFromTxt(string path)
        {
           
            FileStream openfile = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            StreamReader readDataSR = new StreamReader(openfile, Encoding.Default);
            readDataSR.BaseStream.Seek(0, SeekOrigin.Begin);//文件开头
            List<string> allinfo = new List<string> { };
            //int i = 0;
            //allinfo.Add(readDataSR.ReadLine());
            //while (allinfo[i] != null)//每行读取数据
            //{
            //    allinfo.Add(readDataSR.ReadLine());
            //    i++;
            //}
            while (!readDataSR.EndOfStream)
            {
                allinfo.Add(readDataSR.ReadLine());
            }
            //将每行的数据分解，放在list列表中
            List<Double> RawData = new List<double> { };
            for (int n = 0; n < allinfo.Count;n++ )
            {
                RawData.Add(Convert.ToDouble(allinfo[n].Split('\t')));
            }
            return RawData;
        }
        public static List<double> ReadDataFromTxt2(string path)
        {
            List<double> rawdata = new List<double> { };
            rawdata.Clear();
            //打开文件，选择数据来源
            string[] strrawdata = new string[] { };
            string strmar;
            FileStream openfile = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            StreamReader readDataSR = new StreamReader(openfile, Encoding.Default);
            readDataSR.BaseStream.Seek(0, SeekOrigin.Begin);//文件开头
                while (readDataSR.ReadLine() != null)
                {
                    strmar = readDataSR.ReadToEnd();
                    strmar = Regex.Replace(strmar, @"[\n]", "");
                    strmar = Regex.Replace(strmar, @"[\r]", "\t");
                    strmar = strmar.TrimEnd((char[])"\t".ToCharArray());
                    //strrawdata = strmar.Split('\t');
                    strrawdata = strmar.Split(' ', '\t', ',');
                }
                openfile.Close();
                readDataSR.Close();
            int count = strrawdata.Length;
            for (int i = 0; i < count; i++)
            {
                rawdata.Add(Convert.ToDouble(strrawdata[i]));
            }
            return rawdata;
        }
        //平滑方法
        public static List<double> Smooth9(List<double> Data)//九点平滑
        {
            List<double> Smooth9 = new List<double>();
            for (int i = 0; i < Data.Count; i++)
                Smooth9.Add(0);
            Smooth9[0] = Data[0];
            Smooth9[1] = Data[1];
            Smooth9[2] = Data[2];
            Smooth9[3] = Data[3];
            Smooth9[Data.Count - 4] = Data[Data.Count - 4];
            Smooth9[Data.Count - 3] = Data[Data.Count - 3];
            Smooth9[Data.Count - 2] = Data[Data.Count - 2];
            Smooth9[Data.Count - 1] = Data[Data.Count - 1];
            for (int i = 4; i < Data.Count - 4; i++)
                Smooth9[i] = ((-21) * Data[i - 4] + 14 * Data[i - 3] + 39 * Data[i - 2] + 54 * Data[i - 1]
                                 + 59 * Data[i] + 54 * Data[i + 1] + 39 * Data[i + 2] + 14 * Data[i + 3]
                                 - 21 * Data[i + 4]) / 231;
            for (int i = 0; i < Smooth9.Count; i++)
                Smooth9[i] = Smooth9[i] >= 0 ? Smooth9[i] : 0;
            return Smooth9;
        }
        public  static List<double> Smooth5(List<double> Data)//五点平滑
        {
            List<double> Smooth5 = new List<double>();
            for (int i = 0; i < Data.Count; i++)
                Smooth5.Add(0);
            Smooth5[0] = Data[0];
            Smooth5[1] = Data[1];
            Smooth5[Data.Count - 2] = Data[Data.Count - 2];
            Smooth5[Data.Count - 1] = Data[Data.Count - 1];
            for (int i = 2; i < Data.Count - 2; i++)
                Smooth5[i] = (-3 * Data[i - 2] + 12 * Data[i - 1]
                                 + 17 * Data[i] + 12 * Data[i + 1] - 3 * Data[i + 2]) / 35;
            for (int i = 0; i < Smooth5.Count; i++)
                Smooth5[i] = Smooth5[i] >= 0 ? Smooth5[i] : 0;
            return Smooth5;
        }
        /// <summary>
        /// 从txt中读取数据放在二维数组中
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="data">存放在的数组变量中</param>
        public static void ReadTxtToArray(string path,ref string[,] data)
        {
            FileStream openfile = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            StreamReader readDataSR = new StreamReader(openfile, Encoding.Default);
            readDataSR.BaseStream.Seek(0, SeekOrigin.Begin);//文件开头
            List<string> allinfo = new List<string> { };
            //int i = 0;
            string[] resstr = { };
            //allinfo.Add(readDataSR.ReadLine());
            //while (allinfo[i] != null)
            //{
            //    allinfo.Add(readDataSR.ReadLine());
            //    i++;
            //}
            while (!readDataSR.EndOfStream)
            {
                allinfo.Add(readDataSR.ReadLine());
            }
            for (int j = 0; j < allinfo.Count(); j++)
            {
                resstr = allinfo[j].Split(' ', '\t', ',');
                for (int k = 0; k < resstr.Length; k++)
                {
                    data[j, k] = resstr[k];
                }
                resstr = null;
            }
            openfile.Close();
            readDataSR.Close();
        }
        public static void ReadTxtToList(string path, ref List<List<string>> data)
        {
            FileStream openfile = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            StreamReader readDataSR = new StreamReader(openfile, Encoding.Default);
            readDataSR.BaseStream.Seek(0, SeekOrigin.Begin);//文件开头
            List<string> allinfo = new List<string> { };
            //int i = 0;
            string[] resstr = { };
            List<string> tepdata;
            //while (!readDataSR.EndOfStream)
            //{
            //    allinfo=readDataSR.ReadLine();
            //    resstr = allinfo.Split(' ', '\t');
            //    for (int i = 0; i < resstr.Length; i++)
            //    {
            //        tepdata.Add(resstr[i]);
            //        resstr[i] = null;
            //    }
            //    data.Add(tepdata);
            //    tepdata = null;
            //    allinfo = null;
            //}
            while (!readDataSR.EndOfStream)
            {
                allinfo.Add(readDataSR.ReadLine());
            }
            for (int j = 0; j < allinfo.Count(); j++)
            {
                tepdata = new List<string> { };
                resstr = allinfo[j].Split(' ', '\t',',');
                for (int k = 0; k < resstr.Length; k++)
                {
                    tepdata.Add(resstr[k]);
                }
                data.Add(tepdata);
               // tepdata = null;
                resstr = null;
            }
            openfile.Close();
            readDataSR.Close();
        }


    }
}
