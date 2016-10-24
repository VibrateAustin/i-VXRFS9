using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_VXRFS.ApplicationProcedure
{
    public class SysConfig_FileSave
    {
        /// <summary>
        /// 把dgv数据读取到list列表中
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="data"></param>
        public static void readDgvToList(DataGridView dgv, ref List<string> data)
        {
            string rowStr = null;
            for (int i = 0; i < dgv.ColumnCount; i++) //添加列头到数组第一行中
            {
                rowStr += dgv.Columns[i].HeaderText + ",";
            }
            rowStr = rowStr.Substring(0, rowStr.Length - 1);
            data.Add(rowStr);
            rowStr = null;
            for (int i = 0; i < dgv.Rows.Count-1; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value == null) dgv.Rows[i].Cells[j].Value = "";
                    rowStr += dgv.Rows[i].Cells[j].Value.ToString() + ",";
                }
                rowStr = rowStr.Substring(0, rowStr.Length - 1);
                data.Add(rowStr);
                rowStr = null;
            }
        }
        public static void readDgvToListMoreRow(DataGridView dgv, ref List<string> data)
        {
            string rowStr = null;
            for (int i = 0; i < dgv.ColumnCount; i++) //添加列头到数组第一行中
            {
                rowStr += dgv.Columns[i].HeaderText + ",";
            }
            rowStr = rowStr.Substring(0, rowStr.Length - 1);
            data.Add(rowStr);
            rowStr = null;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value == null) dgv.Rows[i].Cells[j].Value ="";
                    rowStr += dgv.Rows[i].Cells[j].Value.ToString() + ",";
                }
                rowStr = rowStr.Substring(0, rowStr.Length - 1);
                data.Add(rowStr);
                rowStr = null;
            }
        }
        //将列表中数据保存到txt文件中
        public static void ListToSaveTxt(List<string> data,string path)
        {
            UtilityClass.CreateFile(path, true);
            StreamWriter saveSW = new StreamWriter(path, false, Encoding.Default);
            for (int i = 0; i < data.Count;i++ )
                saveSW.WriteLine(data[i]);
            saveSW.Flush();
            saveSW.Close();
        }
        public static void ListToSaveTxt(List<string[]> data, string path)
        {
            UtilityClass.CreateFile(path, true);
            StreamWriter saveSW = new StreamWriter(path, false, Encoding.Default);
            int ColsD = 0;
            foreach (string colsD in data[0])
                ColsD++;
            string str = null;
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < ColsD; j++)
                    str += data[i][j]+",";
                str = str.Substring(0, str.Length - 1);
                saveSW.WriteLine(str);
                str = null;
            }
            saveSW.Flush();
            saveSW.Close();
        }
        //打开txt文件读取数据到list
        public static void ReadTxtToDList(string path,ref List<string[]> data)
        {
            FileStream openfile = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader readDataSR = new StreamReader(openfile, Encoding.Default);
            readDataSR.BaseStream.Seek(0, SeekOrigin.Begin);//文件开头c

            List<string> allinfo = new List<string> { };
            int j = 0;
            allinfo.Add(readDataSR.ReadLine());
            while (allinfo[j] != null)
            {
                allinfo.Add(readDataSR.ReadLine());
                j++;
            }
            openfile.Close();
            readDataSR.Close();

            List<string> tempData = new List<string>();
            string[] tempD = {  };
            for (int i = 0; i < allinfo.Count()-1; i++)
            {
                tempD = allinfo[i].Split(',');
               // for (int k = 0; k < tempD.Length; k++)
               //     tempData.Add(tempD[k]);
                data.Add(tempD);
                tempData.Clear();
                tempD = null;
            }
        }
        //把list数据 添加到dgv
        public static void DListAddToDgv(DataGridView dgv, List<string[]> Tdata)
        {
            //添加dgv列头
            int ColsD = 0;
            foreach (string colsD in Tdata[0])
                ColsD++;
            dgv.ColumnCount = ColsD;
            dgv.ColumnHeadersVisible = true;
            for (int clos = 0; clos < ColsD; clos++)
            {
                dgv.Columns[clos].Name = Tdata[0][clos];
            }
            //添加行数据
            for (int rows = 1; rows < Tdata.Count(); rows++)
            {
                int index = dgv.Rows.Add();
                for (int clos = 0; clos < ColsD; clos++)
                {
                    dgv.Rows[index].Cells[clos].Value = Tdata[rows][clos];
                }
            }
        }


    }
}
