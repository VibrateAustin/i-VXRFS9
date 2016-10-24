using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using i_VXRFS.NewAndOpenQuantitationAnalysisApplication;
using i_VXRFS.SystemConfiguration;
using i_VXRFS.ApplicationProcedure;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    public partial class AddCompound : Form
    {
        public AddCompound()
        {
            InitializeComponent();
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void AddCompound_Load(object sender, EventArgs e)
        {
            //加载“系统化合物”列表中的数据到dgv中
            try
            {
                //"添加化合物列表"
                
                dgv_addcompound.ColumnCount = 2;
                dgv_addcompound.Columns[0].HeaderCell.Value = "化合物";//显示数据表抬头的别名
                dgv_addcompound.Columns[1].HeaderCell.Value = "化学式";
                dgv_addcompound.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域

                List<string[]> OxideData = new List<string[]>();
                List<string[]> NonoxideData = new List<string[]>();
                string Opath = Public_Path.SysConfigurationParameterPath + "\\oxide.txt";
                string NonOpath = Public_Path.SysConfigurationParameterPath + "\\nonoxide.txt";
                SysConfig_FileSave.ReadTxtToDList(Opath, ref OxideData);
                SysConfig_FileSave.ReadTxtToDList(NonOpath, ref NonoxideData);
                DlistDataAddToDgv(dgv_addcompound, OxideData);
                DlistDataAddToDgv(dgv_addcompound, NonoxideData);
                dgv_addcompound.AllowUserToAddRows = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
        //将从txt中读取的数据添加到dgv中
        private void DlistDataAddToDgv(DataGridView dgv, List<string[]> data)
        {
            int index = 0;
            for (int i = 1; i < data.Count; i++)
            {
                index = dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = data[i][1];
                dgv.Rows[index].Cells[1].Value = data[i][0];
            }
        }

        private quantitationanalysisapplication _f1;//调用父窗口(打开定量分析程序窗口)
        public AddCompound(quantitationanalysisapplication f1)
            : this()
        {
            this._f1 = f1;
        }
        private newquantitationanalysisapplication _f2;//新建定量分析程序窗口
        public AddCompound(newquantitationanalysisapplication f2)
            : this()
        {
            this._f2 = f2;
        }

        public DataGridView dgv_name;
        public string OpenOrNew = string.Empty;
       
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (dgv_addcompound.SelectedRows.Count > 0)
            {
                if (OpenOrNew == "open")
                {
                    //将某个dgv数据添加到另一个dgv中
                    if (dgv_name == _f1.dgv1)
                    {
                        int index = dgv_addcompound.CurrentRow.Index;
                        int addIndex = 0;
                        addIndex = dgv_name.Rows.Add();
                        dgv_name.Rows[addIndex].Cells[0].Value = dgv_addcompound.Rows[index].Cells[1].Value;
                        dgv_name.Rows[addIndex].Cells[1].Value = dgv_addcompound.Rows[index].Cells[1].Value;
                        dgv_name.Rows[addIndex].Cells[2].Value = 0;
                    }
                    else if (dgv_name == _f1.dgv2)
                    {
                        //把“添加化合物”中添加的化合物填入“化合物”数据表中，并在dgv中显示
                        int index = dgv_addcompound.CurrentRow.Index;
                        int addIndex = 0;
                        addIndex = dgv_name.Rows.Add();
                        dgv_name.Rows[addIndex].Cells[0].Value = dgv_addcompound.Rows[index].Cells[1].Value;
                        dgv_name.Rows[addIndex].Cells[1].Value = dgv_addcompound.Rows[index].Cells[1].Value;
                        dgv_name.Rows[addIndex].Cells[2].Value = dgv_addcompound.Rows[index].Cells[0].Value;
                        dgv_name.Rows[addIndex].Cells[3].Value = "Rh";
                        dgv_name.Rows[addIndex].Cells[4].Value = "%";
                        dgv_name.Rows[addIndex].Cells[7].Value = "Yes";

                        string TxtPath = Public_Path.SysConfigurationParameterPath + "\\Element_Data.txt";
                        SearchDgvToList(_f1.dgv3, TxtPath, dgv_name.Rows[addIndex].Cells[2].Value.ToString());

                        int bgIndex = 0;
                        bgIndex = _f1.dgv4.Rows.Add();
                        _f1.dgv4.Rows[bgIndex].Cells[0].Value = dgv_addcompound.Rows[index].Cells[0].Value;
                        _f1.dgv4.Rows[bgIndex].Cells[1].Value = "20";
                        _f1.dgv4.Rows[bgIndex].Cells[4].Value = "Yes";
                        _f1.dgv4.Rows[bgIndex].Cells[9].Value = "1.00";
                        _f1.dgv4.Rows[bgIndex].Cells[7].Value = "10";
                    }
                    else if (dgv_name == _f1.dgv3)
                    {
                        //“添加元素”中把添加的元素显示在dgv中（只添加了一元素列）
                        int index = dgv_addcompound.CurrentRow.Index;
                        string TxtPath = Public_Path.SysConfigurationParameterPath + "\\Element_Data.txt";
                        SearchDgvToList(_f1.dgv3, TxtPath, dgv_addcompound.Rows[index].Cells[0].Value.ToString());

                        int bgIndex = 0;
                        bgIndex = _f1.dgv4.Rows.Add();
                        _f1.dgv4.Rows[bgIndex].Cells[0].Value = dgv_addcompound.Rows[index].Cells[0].Value;
                        _f1.dgv4.Rows[bgIndex].Cells[1].Value = "20";
                        _f1.dgv4.Rows[bgIndex].Cells[4].Value = "Yes";
                        _f1.dgv4.Rows[bgIndex].Cells[9].Value = "1.00";
                        _f1.dgv4.Rows[bgIndex].Cells[7].Value = "10";
                    }
                    else if (dgv_name==_f1.dgv4)
                    {
                        int index = dgv_addcompound.CurrentRow.Index;
                        int bgIndex = 0;
                        bgIndex = _f1.dgv4.Rows.Add();
                        _f1.dgv4.Rows[bgIndex].Cells[0].Value = dgv_addcompound.Rows[index].Cells[0].Value;
                        _f1.dgv4.Rows[bgIndex].Cells[1].Value = "20";
                        _f1.dgv4.Rows[bgIndex].Cells[4].Value = "Yes";
                        _f1.dgv4.Rows[bgIndex].Cells[9].Value = "1.00";
                        _f1.dgv4.Rows[bgIndex].Cells[7].Value = "10";
                    }
                   // OpenOrNew = null;
                }
                else if(OpenOrNew=="new")
                {
                    //将某个dgv数据添加到另一个dgv中
                    if (dgv_name == _f2.dgv1)
                    {
                        int index = dgv_addcompound.CurrentRow.Index;
                        int addIndex = 0;
                            addIndex = dgv_name.Rows.Add();
                            dgv_name.Rows[addIndex].Cells[0].Value = dgv_addcompound.Rows[index].Cells[1].Value;
                            dgv_name.Rows[addIndex].Cells[1].Value = dgv_addcompound.Rows[index].Cells[1].Value;
                            dgv_name.Rows[addIndex].Cells[2].Value = 0;
                       
                    }
                    else if (dgv_name == _f2.dgv2)
                    {
                        //把“添加化合物”中添加的化合物填入“化合物”数据表中，并在dgv中显示
                        int index = dgv_addcompound.CurrentRow.Index;
                        int addIndex = 0;
                            addIndex = dgv_name.Rows.Add();
                            dgv_name.Rows[addIndex].Cells[0].Value = dgv_addcompound.Rows[index].Cells[1].Value;
                            dgv_name.Rows[addIndex].Cells[1].Value = dgv_addcompound.Rows[index].Cells[1].Value;
                            dgv_name.Rows[addIndex].Cells[2].Value = dgv_addcompound.Rows[index].Cells[0].Value;
                            dgv_name.Rows[addIndex].Cells[3].Value = "Rh";
                            dgv_name.Rows[addIndex].Cells[4].Value ="%";
                            dgv_name.Rows[addIndex].Cells[7].Value = "Yes";
                        
                        string TxtPath=Public_Path.SysConfigurationParameterPath+"\\Element_Data.txt";
                        SearchDgvToList(_f2.dgv3, TxtPath, dgv_name.Rows[addIndex].Cells[2].Value.ToString());

                        int bgIndex = 0;
                            bgIndex = _f2.dgv4.Rows.Add();
                            _f2.dgv4.Rows[bgIndex].Cells[0].Value = dgv_addcompound.Rows[index].Cells[0].Value;
                            _f2.dgv4.Rows[bgIndex].Cells[1].Value = "20";
                            _f2.dgv4.Rows[bgIndex].Cells[4].Value = "Yes";
                            _f2.dgv4.Rows[bgIndex].Cells[9].Value = "1.00";
                            _f2.dgv4.Rows[bgIndex].Cells[7].Value = "10";
                       
                    }
                    else if (dgv_name == _f2.dgv3)
                    {
                        //“添加元素”中把添加的元素显示在dgv中（只添加了一元素列）
                        int index = dgv_addcompound.CurrentRow.Index;
                        string TxtPath = Public_Path.SysConfigurationParameterPath + "\\Element_Data.txt";
                        SearchDgvToList(_f2.dgv3, TxtPath, dgv_addcompound.Rows[index].Cells[0].Value.ToString());

                        int bgIndex = 0;
                        bgIndex = _f2.dgv4.Rows.Add();
                        _f2.dgv4.Rows[bgIndex].Cells[0].Value = dgv_addcompound.Rows[index].Cells[0].Value;
                        _f2.dgv4.Rows[bgIndex].Cells[1].Value = "20";
                        _f2.dgv4.Rows[bgIndex].Cells[4].Value = "Yes";
                        _f2.dgv4.Rows[bgIndex].Cells[9].Value = "1.00";
                        _f2.dgv4.Rows[bgIndex].Cells[7].Value = "10";
                    }
                    else if (dgv_name == _f2.dgv4)
                    {
                        //“添加元素”中把添加的元素显示在dgv中（只添加了一元素列）
                        int index = dgv_addcompound.CurrentRow.Index;
                        int bgIndex = 0;
                        bgIndex = _f2.dgv4.Rows.Add();
                        _f2.dgv4.Rows[bgIndex].Cells[0].Value = dgv_addcompound.Rows[index].Cells[0].Value;
                        _f2.dgv4.Rows[bgIndex].Cells[1].Value = "20";
                        _f2.dgv4.Rows[bgIndex].Cells[4].Value = "Yes";
                        _f2.dgv4.Rows[bgIndex].Cells[9].Value = "1.00";
                        _f2.dgv4.Rows[bgIndex].Cells[7].Value = "10";
                    }
                   // OpenOrNew = null;
                }
            }
            else
            {
                MessageBox.Show("请选择要添加的元素！");
            }
        }
        //通过dgv中数据OrgData查找txt中对应的数据并添加在dgv中
        private void SearchDgvToList(DataGridView dgv,string TxtDataPath,DataGridView OrgData,int ColsIndex)
        {
            List<string[]> SearchedData=new List<string[]> ();
            List<string[]> TxtData = new List<string[]>();
            SysConfig_FileSave.ReadTxtToDList(TxtDataPath, ref TxtData); //从txt中读取数据到list中
            SearchedData.Add(TxtData[0]);
            for (int i = 0; i < OrgData.Rows.Count - 1; i++)
            {
                for(int j=1;j<TxtData.Count;j++){
                    if (TxtData[j][0] == OrgData.Rows[i].Cells[ColsIndex].Value.ToString())
                    {
                        SearchedData.Add(TxtData[j]);
                        continue;
                    }
                }
            }
            SysConfig_FileSave.DListAddToDgv(dgv,SearchedData);
        }
        private void SearchDgvToList(DataGridView dgv, string TxtDataPath, string OrgData)
        {
            List<string[]> SearchedData = new List<string[]>();
            List<string[]> TxtData = new List<string[]>();
            SysConfig_FileSave.ReadTxtToDList(TxtDataPath, ref TxtData); //从txt中读取数据到list中
            
                for (int j = 1; j < TxtData.Count; j++)
                {
                    if (TxtData[j][0] == OrgData)
                    {
                        SearchedData.Add(TxtData[j]);
                        continue;
                    }
                }
            DListAddToDgv(dgv, SearchedData);
        }
        //把list数据 添加到dgv
        private static void DListAddToDgv(DataGridView dgv, List<string[]> Tdata)
        {
            //添加dgv列头
            int ColsD = 0;
            foreach (string colsD in Tdata[0])
                ColsD++;
           
            //添加行数据
            for (int rows = 0; rows < Tdata.Count(); rows++)
            {
                int index = dgv.Rows.Add();
                for (int clos = 0; clos < ColsD; clos++)
                {
                    dgv.Rows[index].Cells[clos].Value = Tdata[rows][clos];
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
           // XRF_function.TruncateTableData("tb_addcompound");
            this.Close();
        }

        private void AddCompound_FormClosed(object sender, FormClosedEventArgs e)
        {
           // XRF_function.TruncateTableData("tb_addcompound");
        }
    }
}
