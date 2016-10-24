using i_VXRFS.SystemConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_VXRFS.ApplicationProcedure.PerformanceTest
{
    public partial class PerformanceTest_mainPage : Form
    {
        public PerformanceTest_mainPage()
        {
            InitializeComponent();
            this.dgv_element.Controls.Add(comboBox1);
            comboBox1.Visible = false;
            //int index = this.dgv_element.Rows.Add();
            //声明委托
            this.dgv_element.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dgv_element_CellMouseClick);
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
        }
        public DataGridView dgv1
        {
            set { dgv_element = value; }
            get { return dgv_element; }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ColumnIndex = dgv_element.CurrentCell.ColumnIndex;
            int RowIndex = dgv_element.CurrentCell.RowIndex;
            if (dgv_element.CurrentCell != null)
            {
                if (ColumnIndex != 6 && ColumnIndex != 7)
                    dgv_element.CurrentCell.Value = comboBox1.Items[comboBox1.SelectedIndex];
                else if (ColumnIndex == 6)
                {
                    if (Convert.ToInt16(dgv_element.Rows[RowIndex].Cells[ColumnIndex + 1].Value) * Convert.ToInt16(comboBox1.Items[comboBox1.SelectedIndex]) > 4000)
                    {
                        dgv_element.Rows[RowIndex].Cells[ColumnIndex + 1].Value = 5 * Convert.ToInt16(4000 / (5 * Convert.ToInt16(comboBox1.Items[comboBox1.SelectedIndex])));
                    }
                    dgv_element.CurrentCell.Value = comboBox1.Items[comboBox1.SelectedIndex];
                }
                else if (ColumnIndex == 7)
                {
                    if (Convert.ToInt16(dgv_element.Rows[RowIndex].Cells[ColumnIndex - 1].Value) * Convert.ToInt16(comboBox1.Items[comboBox1.SelectedIndex]) > 4000)
                    {
                        dgv_element.Rows[RowIndex].Cells[ColumnIndex - 1].Value = 5 * Convert.ToInt16(4000 / (5 * Convert.ToInt16(comboBox1.Items[comboBox1.SelectedIndex])));
                    }
                    dgv_element.CurrentCell.Value = comboBox1.Items[comboBox1.SelectedIndex];
                }
            }
        }

        private void dgv_element_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string path = null;
            List<int> tb_str = new List<int>();
            string[] line_Style = { "KA", "KB", "LA", "LB", "LC", "M" };
            if (dgv_element.CurrentCell.ColumnIndex > 0 && dgv_element.CurrentCell.ColumnIndex < 8)
            {
                if (dgv_element.CurrentCell.ColumnIndex == 2)
                {
                    path = Public_Path.SysConfigurationParameterPath + "\\crystal.txt";
                    tb_str.Add(1);
                }
                if (dgv_element.CurrentCell.ColumnIndex == 3)
                {
                    path = Public_Path.SysConfigurationParameterPath + "\\collimator.txt";
                    tb_str.Add(1);
                }
                if (dgv_element.CurrentCell.ColumnIndex == 4)
                {
                    path = Public_Path.SysConfigurationParameterPath + "\\detector.txt";
                    tb_str.Add(1);
                }
                if (dgv_element.CurrentCell.ColumnIndex == 5)
                {
                    path = Public_Path.SysConfigurationParameterPath + "\\filter.txt";
                    tb_str.Add(1); tb_str.Add(2);
                }
                this.comboBox1.Items.Clear();
                int columnIndex = dgv_element.CurrentCell.ColumnIndex;
                int rowIndex = dgv_element.CurrentCell.RowIndex;
                Rectangle rect = dgv_element.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                comboBox1.Left = rect.Left;
                comboBox1.Top = rect.Top;
                comboBox1.Width = rect.Width;
                comboBox1.Height = rect.Height;
                //添加数据到下拉框列表中
                if (columnIndex > 1 && columnIndex < 6)
                {

                    List<string[]> Sysdata = new List<string[]>();
                    SysConfig_FileSave.ReadTxtToDList(path, ref Sysdata);
                    TxtDataUploadToDgvColumnCombobox.TxtDataToDgvColumnCombobox(comboBox1, Sysdata, tb_str);
                }
                if (columnIndex == 1)
                {
                    for (int i = 0; i < line_Style.Count(); i++)
                    {
                        comboBox1.Items.Add(line_Style[i]);
                    }
                }
                if (columnIndex == 6)
                {
                    for (int i = 20; i < 61; i += 5)
                    {
                        comboBox1.Items.Add(i);
                    }
                }
                if (columnIndex == 7)
                {
                    for (int i = 5; i < 121; i += 5)
                    {
                        comboBox1.Items.Add(i);
                    }
                }
                string consultingRoom = dgv_element.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index3 = comboBox1.Items.IndexOf(consultingRoom);
                comboBox1.SelectedIndex = index3;
                comboBox1.Visible = true;
            }
            else
            {
                comboBox1.Visible = false;
            }
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void PHDAngelRevision_Load(object sender, EventArgs e)
        {
            string ElementPath = Public_Path.SysConfigurationParameterPath + "\\Element_Data.txt";
            List<string[]> ElementData = new List<string[]>();
            SysConfig_FileSave.ReadTxtToDList(ElementPath, ref ElementData);
            SysConfig_FileSave.DListAddToDgv(dgv_element, ElementData);
            dgv_element.AllowUserToAddRows = false;
        }

        private void bt_phd_Click(object sender, EventArgs e)
        {
            if (dgv_element.SelectedRows.Count > 0)
            {
                CheckPHA checkPHDform = new CheckPHA(this);
                //把选定的待测元素参数传值过去
                checkPHDform.getelementparameter = XRF_function.GetDgvRowData(dgv_element);
                checkPHDform.DgvRowIndex = dgv_element.CurrentRow.Index;
                checkPHDform.Show();
            }
            else
            {
                MessageBox.Show("请选择元素！");
            }
        }

        private void bt_angel_Click(object sender, EventArgs e)
        {
            if (dgv_element.SelectedRows.Count > 0)
            {
                CheckAngle checkAngleform = new CheckAngle(this);
                //把选定的待测元素参数传值过去
                checkAngleform.getelementparameter = XRF_function.GetDgvRowData(dgv_element);
                checkAngleform.DgvIndex = dgv_element.CurrentRow.Index;
                checkAngleform.Show();
            }
            else
            {
                MessageBox.Show("请选择元素！");
            }
        }
        //将数据全部更新到数据库中
        private void bt_save_Click(object sender, EventArgs e)
        {
            List<string> data = new List<string>();
            string SavePath = Public_Path.SysConfigurationParameterPath + "\\Element_Data.txt";
            SysConfig_FileSave.readDgvToList(dgv_element, ref data);
            SysConfig_FileSave.ListToSaveTxt(data, SavePath);

            //InsertDataToDgv.DgvDataInputToTable(XRF_function.LinkDataBasePath, dgv_element, "tb_syselementparameter");
            //List<List<string>> RowData = new List<List<string>>();
            //List<string> ColumnName = new List<string>();
            //string str = null;
            //ReadDgvRows(dgv_element,ref RowData);
            //ColumnName = ReadTableTitleName("tb_syselementparameter");
            //for (int j = 0; j < RowData.Count; j++)
            //{
            //    for (int i = 0; i < ColumnName.Count; i++)
            //    {
            //        if (i == 6 || i == 7 || i == 8 || i == 13 || i == 14 | i == 18 || i == 22)
            //        {
            //            if (RowData[j][i] == null)
            //                str += "," + ColumnName[i] + "=0";
            //            else
            //                str += "," + ColumnName[i] + "=" + RowData[j][i];
            //        }
            //        else
            //        {
            //            if (RowData[j][i] == null)
            //                str += "," + ColumnName[i] + "="+null;
            //            else
            //                str += "," + ColumnName[i] + "='" + RowData[j][i] + "'";
            //        }
            //    }
            //    str = str.Substring(1, str.Length-1);
            //    str = "update tb_syselementparameter set " + str + " where element='" + RowData[j][0] + "';";
            //    sqlData(str);
            //    str = null;
            //}
            this.Close();
        }
        //public int sqlData(string str)
        //{
        //    SqlConnection conn = new SqlConnection(XRF_function.LinkDataBasePath);
        //    conn.Open();
        //    SqlCommand sqc = new SqlCommand(str, conn);
        //    int i = Convert.ToInt16(sqc.ExecuteNonQuery());
        //    conn.Close();
        //    return i;
        //}
        /// <summary>
        /// 读取dgv中的数据到二维列表中
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="RowData"></param>
        private void ReadDgvRows(DataGridView dgv,ref List<List<string>> RowData)
        {
            for (int i = 0; i < dgv.Rows.Count-1; i++)
            {
                List<string> tepData = new List<string>();
                if (dgv.Rows[i].Cells[0].Value != null || dgv.Rows[i].Cells[0].Value.ToString() != "")
                {
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        tepData.Add(dgv.Rows[i].Cells[j].Value.ToString());
                    }
                }
                RowData.Add(tepData);
            }
        }
        /// <summary>
        /// 查询得到数据表的抬头名
        /// </summary>
        /// <param name="tb_name"></param>
        /// <returns></returns>
        private List<string> ReadTableTitleName(string tb_name)
        {
            //获取数据表列头名，返回字符数据  还需要获取字段类型
            List<string> ColumnName = new List<string> { };
            List<string> ColumnType = new List<string> { };
           // List<string> Columnelement = new List<string> { };
            SqlConnection conn;
            conn = new SqlConnection(XRF_function.LinkDataBasePath);//实例化SQLConnection变量，并连接数据库
           
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
                return ColumnName;
        }

        private void btn_wdxrf_Click(object sender, EventArgs e)
        {
            if (dgv_element.SelectedRows.Count > 0)
            {
                CheckWDXRF checkwdxrfform = new CheckWDXRF(this);
                //把选定的待测元素参数传值过去
                checkwdxrfform.getelementparameter = XRF_function.GetDgvRowData(dgv_element);
                checkwdxrfform.DgvIndex = dgv_element.CurrentCell.RowIndex;
                checkwdxrfform.Show();
            }
            else
            {
                MessageBox.Show("请选择元素！");
            }
        }

        private void btn_edxrf_Click(object sender, EventArgs e)
        {
            if (dgv_element.SelectedRows.Count > 0)
            {
                CheckEDXRF checkedxrfform = new CheckEDXRF(this);
                //把选定的待测元素参数传值过去
                checkedxrfform.getelementparameter = XRF_function.GetDgvRowData(dgv_element);
                checkedxrfform.DgvIndex = dgv_element.CurrentCell.RowIndex;
                checkedxrfform.Show();
            }
            else
            {
                MessageBox.Show("请选择元素！");
            }
        }

    }
}
