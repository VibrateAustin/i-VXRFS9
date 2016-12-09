using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using System.Data;

namespace i_VXRFS
{
    public class Public_Path
    {   //D:\\XRF\\XRF\\i-VXRFS LastOne\\
        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey) return ConfigurationManager.AppSettings[strKey];
            }
            return null;
        }
        public static string QuantitationApplicationPath = GetAppConfig("QuantitationApplicationPath"); //定量分析程序方法保存数据路径
        public static string QuantitationAnalysisResultsPath = GetAppConfig("QuantitationAnalysisResultsPath"); //定量分析结果保存数据路径
        public static string QualitationApplicationPath = GetAppConfig("QualitationApplicationPath");  //定性分析结果数据保存路径
        public static string QuantitationApplicationTempPath = GetAppConfig("QuantitationApplicationTempPath");  //临时文件保存路径
        public static string PHDAngelCheckPath = GetAppConfig("PHDAngelCheckPath");
        public static string DriftCorrectionApplicationPath = GetAppConfig("DriftCorrectionApplicationPath");  //漂移校正数据保存路径
        public static string SysStandardSampleLibraryPath = GetAppConfig("SysStandardSampleLibraryPath");  //标样库数据保存路径
        public static string SysConfigurationParameterPath = GetAppConfig("SysConfigurationParameterPath"); 


        //定义全局变量（文件存放路径）  注：在项目外包中，许多用静态方法定义的类，需要调用以下静态路径
        //public static string QuantitationApplicationPath = "XRF_Files\\QuantitationAnalysis_Directories"; //定量分析程序方法保存数据路径
        //public static string QuantitationAnalysisResultsPath = "XRF_Files\\QuantitationAnalysisResults"; //定量分析结果保存数据路径
        //public static string QualitationApplicationPath = "XRF_Files\\QualitationAnalysisResults";  //定性分析结果数据保存路径
        //public static string QuantitationApplicationTempPath = "XRF_Files\\TempFile";  //临时文件保存路径
        //public static string PHDAngelCheckPath = "XRF_Files\\PHDAngelCheck";
        //public static string DriftCorrectionApplicationPath = "XRF_Files\\driftcorrectionapplication_Directories";  //漂移校正数据保存路径
        //public static string SysStandardSampleLibraryPath = "XRF_Files\\SysStandardSampleLibrary";  //标样库数据保存路径
        //public static string SysConfigurationParameterPath = "XRF_Files\\i-VXRFS_SysConfigurationParameter"; //存放仪器系统配置参数文件夹
    }
    class i_VXRFS_function
    {
        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey) return ConfigurationManager.AppSettings[strKey];
            }
            return null;
        }
        public  string QuantitationApplicationPath = GetAppConfig("QuantitationApplicationPath"); //定量分析程序方法保存数据路径
        public  string QuantitationAnalysisResultsPath = GetAppConfig("QuantitationAnalysisResultsPath"); //定量分析结果保存数据路径
        public  string QualitationApplicationPath = GetAppConfig("QualitationApplicationPath");  //定性分析结果数据保存路径
        public  string QuantitationApplicationTempPath = GetAppConfig("QuantitationApplicationTempPath");  //临时文件保存路径
        public  string PHDAngelCheckPath = GetAppConfig("PHDAngelCheckPath");
        public  string DriftCorrectionApplicationPath = GetAppConfig("DriftCorrectionApplicationPath");  //漂移校正数据保存路径
        public  string SysStandardSampleLibraryPath = GetAppConfig("SysStandardSampleLibraryPath");  //标样库数据保存路径
        public  string SysConfigurationParameterPath = GetAppConfig("SysConfigurationParameterPath"); 


        //定义全局变量（文件存放路径）
        //public string QuantitationApplicationPath = "XRF_Files\\QuantitationAnalysis_Directories";
        //public string QuantitationAnalysisResultsPath = "XRF_Files\\QuantitationAnalysisResults"; //定量分析结果保存数据路径
        //public string QualitationApplicationPath = "XRF_Files\\QualitationAnalysisResults";
        //public string PHDAngelCheckPath = "XRF_Files\\PHDAngelCheck";
        //public string QuantitationApplicationTempPath = "XRF_Files\\TempFile";
        //public string DriftCorrectionApplicationPath = "XRF_Files\\driftcorrectionapplication_Directories";
        public string LinkDataBasePath = "Data Source=yingguang-pc\\yingguang;Initial Catalog=MySqlDb;Integrated Security=True";  //数据库连接字符串
        //public string SysStandardSampleLibraryPath = "XRF_Files\\SysStandardSampleLibrary";
        //public string SysConfigurationParameterPath = "XRF_Files\\i-VXRFS_SysConfigurationParameter"; //存放仪器系统配置参数文件夹

        public SqlConnection conn;
        public SqlDataAdapter adapter;
        //建立打开数据表并显示在相应位置的方法,形参tb_name为数据表名
        public bool showdatagridview(DataGridView dgv, string tb_name)
        {
            try
            {
                conn = new SqlConnection(LinkDataBasePath);//实例化SQLConnection变量，并连接数据库
                string str = " select * from " + tb_name;
                SqlDataAdapter sda = new SqlDataAdapter(str, conn);//实例化SqlDataAdaoter对象
                DataSet ds = new DataSet(); //实例化Dataset对象
                sda.Fill(ds); //用fill方法填充Dataset
                dgv.DataSource = ds.Tables[0];//设置dgv数据来源
                // dgv.RowHeadersVisible = false;//不显示行标题
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        //建立更新数据表的方法1
        public DataTable dbconn(string strsql)// 建立datatable的方法
        {
            this.adapter = new SqlDataAdapter(strsql, conn);//实例化sqldataadapter对象
            DataTable dtselect = new DataTable();//实例化datatable对象
            int rnt = this.adapter.Fill(dtselect);
            return dtselect;
        }
        public Boolean dbupdate(DataGridView dgv, string tb_name)//建立一个dbupdate的更新数据表的方法
        {
            string strsql = "select * from " + tb_name;
            DataTable dtupdate = new DataTable();
            dtupdate = this.dbconn(strsql);
            dtupdate.Rows.Clear();
            DataTable dtshow = new DataTable();
            dtshow = (DataTable)dgv.DataSource;
            for (int i = 0; i < dgv.RowCount - 1; i++)//使用importrow方法复制dtshow中的值到dtupdate中
                dtupdate.ImportRow(dtshow.Rows[i]);
            try
            {
                SqlCommandBuilder commandbuilder;
                commandbuilder = new SqlCommandBuilder(this.adapter);//声明sqlcommandbuilder的变量
                this.adapter.Update(dtupdate); //update方法更新数据表
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            dtupdate.AcceptChanges();//提交更改
            return true;
        }
        //建立删除DGV表中某一行方法 
        public bool DeleteDGVRow(DataGridView dgv)
        {
            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    DataRowView drv = dgv.SelectedRows[0].DataBoundItem as DataRowView;
                    drv.Row.Delete();
                    return true;
                }
                else
                {
                    MessageBox.Show("请选择需要删除的化合物！");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        //清空数据表中的数据
        public bool TruncateTableData(string tb_name)
        {
            try
            {
                conn = new SqlConnection(LinkDataBasePath);//实例化SQLConnection变量，并连接数据库
                conn.Open();
                string str = " truncate table " + tb_name;
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        //建立删除数据库中某一行方法 (形参：dgv名，数据表名，主键名)  
        public bool DeleteDataBaseRow(DataGridView dgvname, string tb_name, string keyname)
        {
            try
            {
                string currentname = dgvname.CurrentRow.Cells[keyname].Value.ToString();
                SqlConnection conn = new SqlConnection(LinkDataBasePath);
                conn.Open();
                string str = "delete from " + tb_name + " where " + keyname + "='" + currentname + "';";
                SqlCommand sqc = new SqlCommand(str, conn);
                sqc.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        //数据删除联动（删除一数据表中的某行，另一个数据表的某行同步删除）
        public bool DeleteDataBaseRow(DataGridView dgvname, string tb_name, string keyname, string tb_nameFollow, string followname)
        {
            try
            {
                string currentname = dgvname.CurrentRow.Cells[0].Value.ToString();
                SqlConnection conn = new SqlConnection(LinkDataBasePath);
                conn.Open();
                string str = "delete from " + tb_name + " where " + keyname + "='" + currentname + "';";
                SqlCommand sqc = new SqlCommand(str, conn);
                sqc.ExecuteNonQuery();
                string str1 = "delete from " + tb_nameFollow + " where " + followname + "='" + currentname + "';";
                SqlCommand sqc1 = new SqlCommand(str1, conn);
                sqc1.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool DeleteDataBaseRow(DataGridView dgvname, string tb_name, string keyname, string tb_nameFollow, string followname, string tb_nameFollow2, string followname2)
        {
            try
            {
                string currentname = dgvname.CurrentRow.Cells[keyname].Value.ToString();
                SqlConnection conn = new SqlConnection(LinkDataBasePath);
                conn.Open();
                string str = "delete from " + tb_name + " where " + keyname + "='" + currentname + "';";
                SqlCommand sqc = new SqlCommand(str, conn);
                sqc.ExecuteNonQuery();
                string str1 = "delete from " + tb_nameFollow + " where " + followname + "='" + currentname + "';";
                SqlCommand sqc1 = new SqlCommand(str1, conn);
                sqc1.ExecuteNonQuery();
                string str2 = "delete from " + tb_nameFollow2 + " where " + followname2 + "='" + currentname + "';";
                SqlCommand sqc2 = new SqlCommand(str2, conn);
                sqc2.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        //定义定量分析程序名字符串的全局变量
        private string quantitationanalysisapplication = "";
        public string QuantitationAnalysisApplication_DirectoryName
        {
            get
            {
                return quantitationanalysisapplication;
            }
            set
            {
                quantitationanalysisapplication = value;
            }
        }

        //声明一种方法，读取DGV表中的数据，并保存在字符串数据列表中
        public string[,] GetDGVData(DataGridView dgv)
        {
            string[,] str = new string[dgv.RowCount, dgv.ColumnCount];
            if (dgv.Rows.Count == 0)
                return null;
            else
            {
                for (int i = 0; i < dgv.ColumnCount; i++) //添加列头到数组第一行中
                {
                    str[0, i] = dgv.Columns[i].HeaderText;
                }
                int j = 0;
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    for (j = 0; j < dgv.ColumnCount; j++)
                    {
                        str[i + 1, j] = dgv.Rows[i].Cells[j].Value.ToString();//关键步骤
                    }
                    //  str[i + 1,j+1] += "\n";
                    j = 0;
                }
                return str;
            }
        }
        public string[] GetDGVData2(DataGridView dgv)
        {
            string[] str = new string[dgv.RowCount];
            if (dgv.Rows.Count == 0)
                return null;
            else
            {
                for (int i = 0; i < dgv.ColumnCount; i++) //添加列头到数组第一行中
                {
                    str[0] += dgv.Columns[i].HeaderText + " ";
                }
                int j = 0;
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    for (j = 0; j < dgv.ColumnCount; j++)
                    {
                        str[i + 1] += dgv.Rows[i].Cells[j].Value.ToString() + " ";//关键步骤
                    }
                    //  str[i + 1,j+1] += "\n";
                    j = 0;
                }
                return str;
            }
        }
        public string[] transformToOneD(string[,] str)
        {

            int n = str.GetLength(0);//二维数组行数
            int m = str.GetLength(1);//二维数组列数
            string[] OneDstr = new string[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    OneDstr[i] += str[i, j] + " ";
                }
            }
            return OneDstr;
        }

        //获得DGV中所选的行号,并把该行的值放在一个数值中  ******
        public List<string> GetDgvRowData(DataGridView dgv)
        {
            List<string> elementparameter = new List<string> { };
            int index = -1;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Selected == true)
                    index = i;
            }
            if (index >= 0)
            {
                for (int k = 0; k < dgv.ColumnCount; k++)
                    elementparameter.Add(dgv.Rows[index].Cells[k].Value.ToString());
                index = -1;
                return elementparameter;
            }
            else
            {
                return null;
            }
        }
        
    }

    //将tb_name中某列值加载到dgv某列的下拉框Item中(tb_str 为需要从table中查找的列字段名)???
    public class TableColumnDataUploadToDgvColumnComboBox
    {
        /// <summary>
        /// 绑定一下拉列表框
        /// </summary>
        public static ComboBox cmb_Temp = new ComboBox();//定义下拉框
        public static void BindColumn(string connectionstr,ComboBox com,string tb_name, string tb_str)
        {
            SqlConnection conn = new SqlConnection(connectionstr);
            conn.Open();
            string sql = "select " + tb_str + " from " + tb_name;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//实例化SqlDataAdaoter对象
            DataSet ds = new DataSet(); //实例化Dataset对象
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sda.Fill(ds); //用fill方法填充Dataset
            SqlDataReader objReader = cmd.ExecuteReader();
            while (objReader.Read())
            {
                com.Items.Add(objReader[0].ToString());
            }
            objReader.Close();
            conn.Close();
        }
        //加载数据
        public static void BindData(string connectionstr,DataGridView dgv_name)
        {
            //添加化合物后，在元素通道表中自动添加相对应的元素参数默认值到dgv列表中(tb_quantitationcompound(QC)与tb_syselementparameter(SEP)内连接)，仅仅只是显示在dgv表中，并没有添加到数据表中
            SqlConnection conn = new SqlConnection(connectionstr);
            conn.Open();
            string innerstr = "select SEP.element,SEP.Line,SEP.br,SEP.Collimator,SEP.Detector,SEP.filter,SEP.KV,SEP.mA," +
                      "SEP.Angle,SEP.Bg1,SEP.Bg2,SEP.Bg3,SEP.Bg4,SEP.PHD1,SEP.PHD11,SEP.PHD2,SEP.PHD21," +
                      "SEP.Fact1,SEP.Fact2,SEP.Att#,SEP.PSC,SEP.updatetime " +
                      "from tb_quantitationcompound QC inner join tb_syselementparameter SEP on QC.element=SEP.element";
            SqlCommand cmd = new SqlCommand(innerstr, conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds, "tb_quantitationelementchannel");
            dgv_name.DataSource = ds.Tables[0];//在dgv_elementchannel中添加内连接后的数据
            conn.Close();
            dgv_name.Columns[0].HeaderCell.Value = "元素通道名";//显示数据表抬头的别名
            dgv_name.Columns[1].HeaderCell.Value = "谱线";
            dgv_name.Columns[2].HeaderCell.Value = "X-靶";
        }
        //添加下拉列表框事件
        public static void dgv_CurrentCellChanged(DataGridView dgv_name,int index)
        {
            cmb_Temp.Visible = false;
            try
            {
                if (dgv_name.CurrentCell.ColumnIndex == index)
                {
                    Rectangle rect = dgv_name.GetCellDisplayRectangle(dgv_name.CurrentCell.ColumnIndex, dgv_name.CurrentCell.RowIndex, false);
                    string sexValue = dgv_name.CurrentCell.Value.ToString();
                    for (int i = 0; i < cmb_Temp.Items.Count; i++)
                    {
                        if (sexValue == cmb_Temp.DisplayMember[i].ToString())
                        {
                            cmb_Temp.Text = cmb_Temp.DisplayMember[i].ToString();
                        }
                    }
                    cmb_Temp.Left = rect.Left;
                    cmb_Temp.Top = rect.Top;
                    cmb_Temp.Width = rect.Width;
                    cmb_Temp.Height = rect.Height;
                    cmb_Temp.Visible = true;
                }
                else
                {
                    cmb_Temp.Visible = false;
                }
            }
            catch
            {
            }
        }

        public static void GetDgvComboBoxColumn(string connectionstr,DataGridView dgv_name,string tb_name,string tb_str,int index)
        {
           // BindData(connectionstr,dgv_name);//数据加载
            //
            string sql = "select id," + tb_str + " from " + tb_name;
            DataGridViewComboBoxColumn dgvComboBoxColumn = (dgv_name.Columns[index] as DataGridViewComboBoxColumn);
            //DataGridViewComboBoxColumn dgvComboBoxColumn = new DataGridViewComboBoxColumn();//dataGridView1.Columns[0] as DataGridViewComboBoxColumn;
            dgvComboBoxColumn.DataPropertyName = "id";
            //dgvComboBoxColumn.DataSource = GetTable(connectionstr,sql).DefaultView;//必须在设置dataGridView1的DataSource的属性前设置
            dgvComboBoxColumn.DisplayMember = tb_str;
            dgvComboBoxColumn.ValueMember = "id";

           // dgv_name.Columns.Add(dgvComboBoxColumn);
        }
        public static DataSet GetTable(string connectionstr, string sql,string tb_name)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionstr))
            {
                sqlconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlconn);
                sqlda.Fill(ds,tb_name);
                sqlconn.Close();
                return ds;
            }
        }
    }
    public class TxtDataUploadToDgvColumnCombobox
    {
        public static void TxtDataToDgvColumnCombobox(ComboBox cbox_name,List<string[]> data,List<int> index)
        {
            for (int i = 1; i < data.Count; i++)
            {
                if(index.Count==1)
                    cbox_name.Items.Add(data[i][index[0]]);
                else if(index.Count==2)
                    cbox_name.Items.Add(data[i][index[0]]+data[i][index[1]]);
            }
        }
    }

    public class InsertDataToDgv
    {
        //*.Txt数据读取并添加到数据表中(形参：dgv名，connectionstr连接数据库字符串，tb_name 数据表名，insertdatastr 需要插入的数据)
        public static void TxtDataInputToDgv(string connectionstr, string tb_name, string[] insertdatastr)
        {
            //获取数据表列头名，返回字符数据  还需要获取字段类型
            List<string> ColumnName=new List<string> {};
            List<string> ColumnType = new List<string> { };
            SqlConnection conn;
            conn = new SqlConnection(connectionstr);//实例化SQLConnection变量，并连接数据库
            try{
                if(conn.State==ConnectionState.Closed)
                {
                    conn.Open();
                }
                string str="Select syscolumns.name,systypes.name FROM syscolumns,systypes Where syscolumns.xusertype=systypes.xusertype And syscolumns.id=Object_Id('" + tb_name + "')";
                SqlCommand cmd=new SqlCommand(str,conn);
                SqlDataReader objReader=cmd.ExecuteReader();
                while(objReader.Read())
                {
                    ColumnName.Add(objReader[0].ToString());
                    ColumnType.Add(objReader[1].ToString());
                }
                objReader.Close();
                //将Txt数据插入到数据表中
                int ColumnLen=ColumnName.Count;
                string ColumnStr = string.Empty;
                string ColumnValues =string.Empty;
                //for (int i = 0; i < ColumnLen; i++)
                //{
                //    ColumnStr +=","+ ColumnName[i] ;
                //}
                for (int i = 0; i < ColumnLen; i++)
                {
                    if (insertdatastr[i] == null || insertdatastr[i].ToString() == "")
                    {
                        continue;
                    }
                    else
                    {
                        ColumnStr += "," + ColumnName[i];
                        //添加一个判断，如果为int 或者 float 时, 强制转换类型 
                        if (ColumnType[i] == "tinyint" || ColumnType[i] == "int" || ColumnType[i] == "float")
                        {
                            ColumnValues += "," + (insertdatastr[i]);
                        }
                        else
                        {
                            ColumnValues += ",'" + insertdatastr[i] + "'";
                        }
                    }
                }
                ColumnStr = ColumnStr.Substring(1);
                ColumnValues = ColumnValues.Substring(1);
                string insertstr = "insert into " + tb_name + " (" + ColumnStr + ") Values(" + ColumnValues + ");";
                SqlCommand cmd2 = new SqlCommand(insertstr, conn);
                cmd2.ExecuteNonQuery();
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
        //dgv数据添加到数据表中，update后显示在dgv表中(形参：connectionstr连接数据库字符串，dgv_name1:插入的源数据dgv，tb_name1:数据表源数据;dgv_name2:被插入数据dgv,index:标识值（0 表示添加元素，1表示添加化合物，2表示都添加）)
        public static void DgvDataInputToDgv(string connectionstr,DataGridView dgv_name2,DataGridView dgv_name1,string tb_name2,int index,string tb_name1="tb_addcompound")
        {
            i_VXRFS_function XRF_function = new i_VXRFS_function();
            //获取数据表列头名，返回字符数据  还需要获取字段类型
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
                string str = "Select syscolumns.name,systypes.name FROM syscolumns,systypes Where syscolumns.xusertype=systypes.xusertype And syscolumns.id=Object_Id('" + tb_name2 + "')";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader objReader = cmd.ExecuteReader();
                while (objReader.Read())
                {
                    ColumnName.Add(objReader[0].ToString());
                    ColumnType.Add(objReader[1].ToString());
                }
                objReader.Close();
                int Columnindex = 0;
                int numk = 0;
                while(ColumnType[numk]!="datetime")
                {
                    numk++;
                    if (numk >= ColumnType.Count)
                    {
                        numk = 0;
                        break;
                    }
                }
                Columnindex = numk;
                string insertstr = string.Empty;
                string ColumnValues = string.Empty;
                //将“化合物”列表dgv数据添加到tb_name2中
                int rownum = dgv_name1.Rows.Count;
                for (int i = 0; i < rownum; i++)
                {
                    if (dgv_name1.Rows[i].Selected == true)
                    {
                        if (index == 0)
                        {
                            //在table最后datetime列插入当前时间
                            if (Columnindex != 0)
                            {
                                string gettime = DateTime.Now.ToString("yyyy-MM-dd");
                                ColumnValues = "'" + dgv_name1.Rows[i].Cells[0].Value.ToString() + "','"+gettime+"'";//将元素添加到字符串中
                                insertstr = "insert into " + tb_name2 + " (" + ColumnName[0] +","+ColumnName[Columnindex]+ ") Values(" + ColumnValues + ");";
                                Columnindex = 0;
                            }
                            else
                            {
                                ColumnValues = "'" + dgv_name1.Rows[i].Cells[0].Value.ToString() + "'";//将元素添加到字符串中
                                insertstr = "insert into " + tb_name2 + " (" + ColumnName[0] + ") Values(" + ColumnValues + ");";
                            }
                        }
                        if (index == 1)
                        {
                            ColumnValues = "'" + dgv_name1.Rows[i].Cells[1].Value.ToString() + "'";//将化合物添加到字符串中（一列）
                            insertstr = "insert into " + tb_name2 + " (" + ColumnName[0] + ") Values(" + ColumnValues + ");";
                        }
                        if (index == 2)
                        {
                            ColumnValues = "'" + dgv_name1.Rows[i].Cells[0].Value.ToString() + "','" + dgv_name1.Rows[i].Cells[1].Value.ToString() + "'";//将元素，化合物添加到字符串中
                            insertstr = "insert into " + tb_name2 + " (" + ColumnName[0] + "," + ColumnName[1] + ") Values(" + ColumnValues + ");";
                        }
                        if (index == 3)
                        {
                            ColumnValues = "'" + dgv_name1.Rows[i].Cells[1].Value.ToString() + "','" + dgv_name1.Rows[i].Cells[1].Value.ToString() + "'";//将化合物添加到字符串中（两列）
                            insertstr = "insert into " + tb_name2 + " (" + ColumnName[0] + "," + ColumnName[1] + ") Values(" + ColumnValues + ");";
                        }
                        if (index == 4)//特定的应用 tb_quantitationcompound
                        {
                            ColumnValues = "'" + dgv_name1.Rows[i].Cells[1].Value.ToString() + "','" + dgv_name1.Rows[i].Cells[1].Value.ToString()
                                + "','" + dgv_name1.Rows[i].Cells[0].Value.ToString() + "'";//将化合物添加到字符串中（三列）
                            insertstr = "insert into " + tb_name2 + " (" + ColumnName[0] + "," + ColumnName[1] + "," + ColumnName[2] + ") Values(" + ColumnValues + ");";
                        }
                    }
                }
                if (insertstr != string.Empty)
                {
                    SqlCommand cmd2 = new SqlCommand(insertstr, conn);
                    cmd2.ExecuteNonQuery();
                    XRF_function.showdatagridview(dgv_name2, tb_name2);
                   // XRF_function.dbupdate(dgv_name2, tb_name2);
                } 
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
        //将dgv数据插入到数据表中  仅限于定量分析方法程序中使用
        public static void DgvDataInputToTable(string connectionstr, DataGridView dgv_name,string tb_name)
        {
            //获取数据表列头名，返回字符数据  还需要获取字段类型
            List<string> ColumnName = new List<string> { };
            List<string> ColumnType = new List<string> { };
            List<string> Columnelement = new List<string> { };
            SqlConnection conn;
            conn = new SqlConnection(connectionstr);//实例化SQLConnection变量，并连接数据库
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string str = "Select syscolumns.name,systypes.name FROM syscolumns,systypes Where syscolumns.xusertype=systypes.xusertype And syscolumns.id=Object_Id('" + tb_name + "')";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader objReader = cmd.ExecuteReader();
                while (objReader.Read())
                {
                    ColumnName.Add(objReader[0].ToString());
                    ColumnType.Add(objReader[1].ToString());
                }
                objReader.Close();
                //int Columnindex = 0;
                //int numk = 0;
                //while (ColumnType[numk] != "datetime")
                //{
                //    numk++;
                //    if (numk >= ColumnType.Count)
                //    {
                //        numk = 0;
                //        break;
                //    }
                //}
                //Columnindex = numk;
                string gettime = DateTime.Now.ToString("yyyy-MM-dd");
                //将Txt数据插入到数据表中
                int ColumnLen = ColumnName.Count;
                string ColumnStr = string.Empty;
                string ColumnValues = string.Empty;
                string str3 = "Select " + ColumnName[0] + " FROM " + tb_name + ";";
                SqlCommand cmd3 = new SqlCommand(str3, conn);
                SqlDataReader objReader3 = cmd3.ExecuteReader();
                while (objReader3.Read())
                {
                    Columnelement.Add(objReader3[0].ToString());
                }
                objReader3.Close();
                //for (int i = 0; i < ColumnLen; i++)
                //{
                //    ColumnStr += "," + ColumnName[i];
                //}
                for (int k = 0; k < dgv_name.Rows.Count - 1; k++)//只把刚刚添加进去的数据即最后一行的数据添加进去
                {
                    int ifelementexist = 0;
                    for (int m=0;m<Columnelement.Count;m++)
                    {
                        if(dgv_name.Rows[k].Cells[0].Value.ToString()==Columnelement[m])
                            ifelementexist++;
                    }
                    if (ifelementexist == 0)
                    {
                        for (int i = 0; i < ColumnLen; i++)
                        {
                            if (i == 22)
                            {
                                ColumnStr += "," + ColumnName[i];
                                ColumnValues += ",'" + gettime + "'";
                            }
                            if (dgv_name.Rows[k].Cells[i].Value == null || dgv_name.Rows[k].Cells[i].Value.ToString() == "")
                            {
                                continue;
                            }
                            else
                            {
                                ColumnStr += "," + ColumnName[i];
                                //添加一个判断，如果为int 或者 float 时, 强制转换类型 
                                if (ColumnType[i] == "tinyint" || ColumnType[i] == "int" || ColumnType[i] == "float")
                                {
                                    ColumnValues += "," + dgv_name.Rows[k].Cells[i].Value;
                                }
                                else
                                {
                                    ColumnValues += ",'" + dgv_name.Rows[k].Cells[i].Value + "'";
                                }
                            }
                        }
                        ColumnStr = ColumnStr.Substring(1);
                        ColumnValues = ColumnValues.Substring(1);
                        string insertstr = "insert into " + tb_name + " (" + ColumnStr + ") Values(" + ColumnValues + ");";
                        SqlCommand cmd2 = new SqlCommand(insertstr, conn);
                        cmd2.ExecuteNonQuery();
                        ColumnValues = null;
                        ColumnStr = null;
                    }
                    else
                    {
                       // MessageBox.Show("元素已经存在列表中，请不要重复添加相同的元素！");
                        continue;
                    }
                }
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
    
    //创建新的文件夹
    public class UtilityClass
    {
        public static void CreateFile(string argFileName, bool argReplace)
        {
            if (File.Exists(argFileName))
            {
                if (argReplace)
                {
                    File.Delete(argFileName);
                }
                else
                {
                    throw new Exception("文件名存在");
                }
            }
            FileInfo objFile = new FileInfo(argFileName);
            FileStream objStream = objFile.Create();
            objStream.Close();
        }
    }
    //将txt文件获取字符串，并按行拆分成字符数组
    public class SplictStr
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
    }
    //建立直接根据“0”，“1” 自动打开或者关闭CheckBox状态的方法类
    public class CheckBoxState
    {
        public static void ifOpenCheckBox(CheckBox ctrl_name,string str)
        {
            if (str=="1")
            {
                ctrl_name.Checked = true;
                
            }
            else if (str == "0")
            {
                ctrl_name.Checked = false;
            }
        }
        //ckbox的状态无法传进来 ？？？
        //public static void GetCheckBoxState(CheckBox ctrl_name, string str)
        //{
        //    if (ctrl_name.Checked == true)
        //    {
        //        str = "1";
        //    }
        //    else if (ctrl_name.Checked == false)
        //    {
        //        str = "0";
        //    }
        //}
    }

    public class TableJoin//存在一些问题？？
    {
        public static void TableInnerJoin(string connectionstr, DataGridView dgv_name, string tb_nameL, string tb_nameR, string tb_name = "tb_quantitationelementchannel")
        {
            SqlConnection conn = new SqlConnection(connectionstr);
            conn.Open();
            try
            {
                //获取数据表列头名，返回字符数据  还需要获取字段类型
                List<string> ColumnName = new List<string> { };
                List<string> ColumnType = new List<string> { };
                string str = "Select syscolumns.name,systypes.name FROM syscolumns,systypes Where syscolumns.xusertype=systypes.xusertype And syscolumns.id=Object_Id('" + tb_nameR + "')";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader objReader = cmd.ExecuteReader();
                while (objReader.Read())
                {
                    ColumnName.Add(objReader[0].ToString());
                    ColumnType.Add(objReader[1].ToString());
                }
                objReader.Close();
                int ColumnLen = ColumnName.Count;
                string ColumnStr = string.Empty;
                string ColumnValues = string.Empty;
                for (int i = 0; i < ColumnLen; i++)
                {
                    ColumnStr += "," +tb_nameR+"."+ ColumnName[i];
                }
                ColumnStr = ColumnStr.Substring(1);
                string innerstr = "select "+ColumnStr+
                          "from "+tb_nameL +" inner join "+tb_nameR +" on "+tb_nameL+".element="+tb_nameR+".element";
                SqlCommand cmd2 = new SqlCommand(innerstr, conn);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd2;
                DataSet ds = new DataSet();
                sda.Fill(ds, tb_name);
                dgv_name.DataSource = ds.Tables[0];//在dgv_elementchannel中添加内连接后的数据
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

    //将一个数据表的某几列数据插入到另一个数据表中的某几列(tb_name1 为数据源) 
    //public class InsertDataFromTbToTb
    //{
    //    public static void InsertDataFromTb(string connectionstr,string tb_name1,string tb_name2)
    //    {
    //        SqlConnection conn = new SqlConnection(connectionstr);
    //        //获取数据表列头名，返回字符数据  还需要获取字段类型
    //        List<string> ColumnName1=new List<string> {};
    //        List<string> ColumnType1 = new List<string> { };
    //        List<string> ColumnName2=new List<string> {};
    //        List<string> ColumnType2 = new List<string> { };
    //         try{
    //            if(conn.State==ConnectionState.Closed)
    //            {
    //                conn.Open();
    //            }
    //            string str1="Select syscolumns.name,systypes.name FROM syscolumns,systypes Where syscolumns.xusertype=systypes.xusertype And syscolumns.id=Object_Id('" + tb_name1 + "')";
    //            SqlCommand cmd1=new SqlCommand(str1,conn);
    //            SqlDataReader objReader=cmd1.ExecuteReader();
    //            while(objReader.Read())
    //            {
    //                ColumnName1.Add(objReader[0].ToString());
    //                ColumnType1.Add(objReader[1].ToString());
    //            }
    //            objReader.Close();
    //             string str2="Select syscolumns.name,systypes.name FROM syscolumns,systypes Where syscolumns.xusertype=systypes.xusertype And syscolumns.id=Object_Id('" + tb_name2 + "')";
    //            SqlCommand cmd2=new SqlCommand(str2,conn);
    //            SqlDataReader objReader2=cmd2.ExecuteReader();
    //            while(objReader.Read())
    //            {
    //                ColumnName2.Add(objReader[0].ToString());
    //                ColumnType2.Add(objReader[1].ToString());
    //            }
    //            objReader2.Close();
    //            string insertstr="insert into '" +tb_name2 +"'('"+ColumnName2[0]+"','"+ColumnName2[1]+"') Select '" +ColumnName1[1]+"','"+ColumnName1[0]+"'from '"+tb_name1+"';";
    //            SqlCommand cmd=new SqlCommand(insertstr,conn);
    //            cmd.ExecuteNonQuery();
    //         }
    //         catch (SqlException ex)
    //         {
    //             MessageBox.Show(ex.Message);
    //         }
    //         finally
    //         {
    //             conn.Close();
    //         }
    //     }
    //}


    //以下内容均是Austin完成
    //读取数据的类
    public class ReadData
    {
        //从txt文件中读取数据到DataTable中
        public DataTable TxtToTable(string path)
        {
            DataTable table = new DataTable();
            string[] strs = File.ReadAllLines(path);
            string[] header = strs[0].Split('\t', ' ', '，');
            for (int i = 0; i < header.Length; i++)
            {
                table.Columns.Add(header[i]);
            }
            for (int i = 0; i < strs.Length; i++)
            {
                string[] strs_line = strs[i].Split('\t', ' ', '，');
                DataRow row = table.NewRow();
                row.ItemArray = strs_line;
                table.Rows.Add(row);
            }
            return table;
        }
        //把DataTable写入txt文件中
        public void TableToTxt(string path, DataTable table)
        {
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            List<string> headers = new List<string>();
            for (int i=0;i<table.Columns.Count;i++)
            {
                headers.Add(table.Columns[i].ColumnName);
            }
            writer.WriteLine(string.Join("\t", headers));
            for (int i=0;i<table.Rows.Count;i++)
            {
                string str = string.Join("\t", table.Rows[i].ItemArray);
                writer.WriteLine(str);
            }
        }
        //一旦绑定之后，DataGridView和DataTable中的数据是联动的，不需要相互转化
        

        //从txt文件中读取数据到List<String>中
        public List<string> TxtToList(string path)
        {
            List<string> data = new List<string>();
            string[] strs = File.ReadAllLines(path);
            for (int i=0;i<strs.Length;i++)//数据必须要从第一行开始
            {
                string[] strs_line = strs[i].Split('\t', ' ', '，');
                data.AddRange(strs_line);
            }
            return data;
        }
        //把List<T>数据写入txt文件,写入的存数据，没有标题
        public void ListToTxt<T>(string path, List<T> list)
        {
            int rowcount = list.Count / 10;
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int i=0;i<rowcount;i++)
            {
                string line = string.Join("\t", list.GetRange(i * 10, 10));
                writer.WriteLine(line);
            }
            if (list.Count % 10 != 0)
            {
                string last_line = string.Join("\t", list.GetRange(rowcount * 10, list.Count - rowcount * 10));
                writer.WriteLine(last_line);
            }
            
        }
        //把List<string>写入DataTable中
        public void ListToTable<T>(ref DataTable table, List<T> list)
        {
            int columncount = table.Columns.Count;
            int rowcount = list.Count / columncount;
            for (int i=0;i<rowcount;i++)
            {
                table.Rows.Add(list.GetRange(i * columncount, columncount));
            }
            if (list.Count%columncount!=0)
            {
                table.Rows.Add(list.GetRange(rowcount * columncount, list.Count - rowcount * columncount));
            }
        }
    }
}
