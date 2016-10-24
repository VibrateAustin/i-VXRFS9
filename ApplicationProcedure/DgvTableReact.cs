using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_VXRFS.ApplicationProcedure
{
    public class DgvTableReact
    {
        //插入数据到数据表列中，并且显示在Dgv中
        //形参：connectionstr连接数据库字符串，dgv_name1:插入的源数据dgv，tb_name1:数据表源数据;dgv_name2:被插入数据dgv)
        public static void InsertDataToTableColumns(string connectionstr, DataGridView dgv_name2, DataGridView dgv_name1, string tb_name2)
        {
            i_VXRFS_function XRF_function = new i_VXRFS_function();
            List<string> ColumnName = new List<string> { };
            List<string> ColumnType = new List<string> { };
            SqlConnection conn;
            conn = new SqlConnection(connectionstr);//实例化SQLConnection变量，并连接数据库
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //获取数据表列头名，返回字符数据  还需要获取字段类型
                string str = "Select syscolumns.name,systypes.name FROM syscolumns,systypes Where syscolumns.xusertype=systypes.xusertype And syscolumns.id=Object_Id('" + tb_name2 + "')";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader objReader = cmd.ExecuteReader();
                while (objReader.Read())
                {
                    ColumnName.Add(objReader[0].ToString());
                    ColumnType.Add(objReader[1].ToString());
                }
                objReader.Close();
                //将“化合物”列表dgv数据添加到tb_name2中
                int rownum = dgv_name1.Rows.Count;
                int index=0;
                for (int i = 0; i < rownum; i++)
                {
                    if (dgv_name1.Rows[i].Selected == true)
                    {
                        string headStr = dgv_name1.Rows[i].Cells[1].Value.ToString();
                        //判断当前是否已经存在该化合物
                        for (int m = 0; m < ColumnName.Count; m++)
                        {
                            if (headStr == ColumnName[m])
                                index++;
                        }
                        if (index == 0)
                        {
                            //把选择的化合物添加到tb_name2中，并且dgv_name2需要相应的添加一列
                            string str1 = "alter table " + tb_name2 + " add \"" + headStr + "\" float;";
                            SqlCommand cmd1 = new SqlCommand(str1, conn);
                            cmd1.ExecuteNonQuery();

                            DataTable dt = new DataTable();
                            dt.Columns.Add(new DataColumn(headStr, typeof(float)));
                        }
                        else
                        {
                            MessageBox.Show("该化合物已经存在！");
                            index = 0;
                        }
                    }
                }
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                XRF_function.showdatagridview(dgv_name2,tb_name2);
                conn.Close();
            }
        }
        //添加列头
        public static void AddDataToTableColumnsHeader(string connectionstr, string[] data, string tb_name)
        {
            i_VXRFS_function XRF_function = new i_VXRFS_function();
            List<string> ColumnName = new List<string> { };
            List<string> ColumnType = new List<string> { };
            SqlConnection conn;
            conn = new SqlConnection(connectionstr);//实例化SQLConnection变量，并连接数据库
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //获取数据表列头名，返回字符数据  还需要获取字段类型
                string str = "Select syscolumns.name,systypes.name FROM syscolumns,systypes Where syscolumns.xusertype=systypes.xusertype And syscolumns.id=Object_Id('" + tb_name + "')";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader objReader = cmd.ExecuteReader();
                while (objReader.Read())
                {
                    ColumnName.Add(objReader[0].ToString());
                    ColumnType.Add(objReader[1].ToString());
                }
                objReader.Close();
                
                int index = 0;
                //判断当前是否已经存在该列头名
                for (int n = 8; n < data.Length-1;n++ )
                {
                    for (int m = 0; m < ColumnName.Count; m++)
                    {
                        if (data[n] == ColumnName[m])
                            index++;
                    }
                    if (index == 0)
                    {
                        //把该列头名添加到tb_name2，并且dgv_name需要相应的添加一列
                        string str1 = "alter table " + tb_name + " add \"" + data[n] + "\" float;";
                        SqlCommand cmd1 = new SqlCommand(str1, conn);
                        cmd1.ExecuteNonQuery();

                        DataTable dt = new DataTable();
                        dt.Columns.Add(new DataColumn(data[n], typeof(float)));
                    }
                    else
                    {
                       // MessageBox.Show("该化合物已经存在！");
                        index = 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               // XRF_function.showdatagridview(dgv_name, tb_name);
                conn.Close();
            }
        }
        //删除Table和Dgv的列数据
        public static void DeleteTableAndDgvColumnsData(string connectionstr, DataGridView dgv_name, string tb_name)
        {
            i_VXRFS_function XRF_function = new i_VXRFS_function();
            SqlConnection conn;
            conn = new SqlConnection(connectionstr);//实例化SQLConnection变量，并连接数据库
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                //将选择的列dgv数据删除和tb_name2中删除 （只能删除列索引大于8的列）
               int index = dgv_name.CurrentCell.ColumnIndex;
               if (index > 7)
               {
                   //把选择的化合物添加到tb_name2中，并且dgv_name2需要相应的添加一列
                   string str = "alter table " + tb_name + " drop Column \"" + dgv_name.Columns[index].HeaderText.ToString() + "\";";
                   SqlCommand cmd = new SqlCommand(str, conn);
                   cmd.ExecuteNonQuery();

                   dgv_name.Columns.Remove(dgv_name.Columns[index].HeaderText.ToString());
               }
               else
               {
                   MessageBox.Show("该列不可删除！");
               }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                XRF_function.showdatagridview(dgv_name, tb_name);
                conn.Close();
            }
        }
        //删除几列列头
        public static void DeleteTableAndDgvColumnsHeader(string connectionstr, DataGridView dgv_name, string tb_name)
        {
            i_VXRFS_function XRF_function = new i_VXRFS_function();
            SqlConnection conn;
            conn = new SqlConnection(connectionstr);//实例化SQLConnection变量，并连接数据库
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                //删除列索引大于8的列
                int index = 8;
                int columnNum = dgv_name.ColumnCount;
                for (int i = 0; i < columnNum - 8;i++ )
                {
                    string str = "alter table " + tb_name + " drop Column \"" + dgv_name.Columns[index].HeaderText.ToString() + "\";";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.ExecuteNonQuery();

                    dgv_name.Columns.Remove(dgv_name.Columns[index].HeaderText.ToString());
                    //index++;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //XRF_function.showdatagridview(dgv_name, tb_name);
                conn.Close();
            }
        }
        //将str插入到数据表中一列
        public static void StrInsertTable(string connectionstr,DataGridView dgv_name,string insertstr, string tb_name)
        {
            i_VXRFS_function XRF_function = new i_VXRFS_function();
            List<string> ColumnName = new List<string> { };
            List<string> ColumnType = new List<string> { };
            SqlConnection conn;
            conn = new SqlConnection(connectionstr);//实例化SQLConnection变量，并连接数据库
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //获取数据表列头名，返回字符数据  还需要获取字段类型
                string str = "Select syscolumns.name,systypes.name FROM syscolumns,systypes Where syscolumns.xusertype=systypes.xusertype And syscolumns.id=Object_Id('" + tb_name + "')";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader objReader = cmd.ExecuteReader();
                while (objReader.Read())
                {
                    ColumnName.Add(objReader[0].ToString());
                    ColumnType.Add(objReader[1].ToString());
                }
                objReader.Close();

                    //把数据str添加到tb_name2
                    string str1 = "insert into " + tb_name + "(" + ColumnName[0]+") Values('" + insertstr + "');";
                    SqlCommand cmd1 = new SqlCommand(str1, conn);
                    cmd1.ExecuteNonQuery();

            }
            catch (SqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                XRF_function.showdatagridview(dgv_name, tb_name);
                conn.Close();
            }
        }
        //将Txt中的数据有条件的显示在Dgv 中（strCondition 为条件数组值）
        public static void TxtDataAddToDgvWhereCondition(string path,string tb_name,DataGridView dgv_name,List<string> strCondition=null)
        {
            i_VXRFS_function XRF_function = new i_VXRFS_function();
            //第一：读取在该标样名文件夹文件txt中的数据，存放在字符数组中
            FileStream openfile = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
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
            readDataSR.Close();
            //第二：把字符数组添加到数据表中
            dgv_name.Columns[0].HeaderCell.Value = "标样名";//显示数据表抬头的别名
            dgv_name.Columns[1].HeaderCell.Value = "样品量(g)";
            dgv_name.Columns[2].HeaderCell.Value = "总质量(g)";
            dgv_name.Columns[3].HeaderCell.Value = "比例/类型";//显示数据表抬头的别名
            dgv_name.Columns[4].HeaderCell.Value = "样品形态";
            dgv_name.Columns[5].HeaderCell.Value = "添加剂";
            dgv_name.Columns[6].HeaderCell.Value = "烧失量(%)";//显示数据表抬头的别名
            dgv_name.Columns[7].HeaderCell.Value = "总百分比(%)";
            //先添加列头
            string[] dataheader = SplictStr.splictstr(allinfo[0]);
            AddDataToTableColumnsHeader(XRF_function.LinkDataBasePath, dataheader, tb_name);

            int index=1;
            string[] getdata = null;
            while(index < allinfo.Count-1)
            {
                getdata = SplictStr.splictstr(allinfo[index]);
                InsertDataToDgv.TxtDataInputToDgv(XRF_function.LinkDataBasePath, tb_name, getdata);
                index++;
                getdata = null;
            }
            //第三：根据“其它三项”条件，有条件的显示数据到dgv中
            SqlConnection conn = new SqlConnection(XRF_function.LinkDataBasePath);//实例化SQLConnection变量，并连接数据库
            string str=string.Empty;
            try
            {
                if (strCondition.Count == 1)
                {
                    str = " select * from " + tb_name + " where state = '"+strCondition[0]+"';";
                }
                else if (strCondition.Count == 2)
                {
                    str = " select * from " + tb_name + " where state = '" + strCondition[0] + "' And additive = '" + strCondition[1] + "';";
                }
                else if (strCondition.Count == 3)
                {
                    str = " select * from " + tb_name + " where state = '" + strCondition[0] + "' And additive = '" + strCondition[1] + "' And ratio = " + strCondition[2] + ";";
                }
                else
                {
                    str = " select * from " + tb_name;
                }
                SqlDataAdapter sda = new SqlDataAdapter(str, conn);//实例化SqlDataAdaoter对象
                DataSet ds = new DataSet(); //实例化Dataset对象
                sda.Fill(ds); //用fill方法填充Dataset
                dgv_name.DataSource = ds.Tables[0];//设置dgv数据来源
                // dgv.RowHeadersVisible = false;//不显示行标题
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
           
        }
        
    }
}
