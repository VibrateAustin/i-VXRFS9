using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision
{
    public class driftSave
    {
        /// <summary>
        /// 把dgv数据读取到list列表中
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="data"></param>
        public static void readDgvToList(DataGridView dgv,ref List<string> data){
            string rowStr = null;
            for (int i = 0; i < dgv.ColumnCount; i++) //添加列头到数组第一行中
            {
                rowStr += dgv.Columns[i].HeaderText + ",";
            }
            rowStr=rowStr.Substring(0, rowStr.Length - 1);
            data.Add(rowStr);
            rowStr = null;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value == null) dgv.Rows[i].Cells[j].Value = " ";
                    rowStr += dgv.Rows[i].Cells[j].Value.ToString() + ",";
                }
                rowStr= rowStr.Substring(0,rowStr.Length-1);
                data.Add(rowStr);
                rowStr = null;
            }
        }
        //将txt文件获取字符串，并按行拆分成字符数组
            //分别获取-基本参数描述，漂移校正，校正样品，检测
            //所在数组中的索引号的方法；
        public static List<int> getdataindex(List<string> allinfo)
            {
                List<int> index = new List<int> { };
                // int k = 0;
                for (int j = 0; j < allinfo.Count(); j++)
                {
                    if (allinfo[j] == "基本参数描述")
                    {
                        index.Add(j);
                        continue;
                    }
                    if (allinfo[j] == "漂移校正参数")
                    {
                        index.Add(j);
                        continue;
                    }
                    if (allinfo[j] == "校正样品")
                    {
                        index.Add(j);
                        continue;
                    }
                    if (allinfo[j] == "检测")
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
                resstr = str.Split(',');
                return resstr;
            }
        //添加列头
        public static void insertTextToDgvColumn(DataGridView dgv, string[] str)
        {
            dgv.ColumnCount = str.Length;
            dgv.ColumnHeadersVisible = true;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Name = str[i];
            }
        } 
        public static void insertTextToDgvRow(DataGridView dgv,string[] str)
        {
            int index = dgv.Rows.Add();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Rows[index].Cells[i].Value = str[i];
            }
        }

    }
}
