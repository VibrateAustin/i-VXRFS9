using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision
{
    public partial class DriftCorrectionApplication : Form
    {
        public DriftCorrectionApplication()
        {
            InitializeComponent();
        }
        public string newDriftApplicationtime = string.Empty;//需“新建漂移校正”窗口传入的值
        public string newDriftApplicationname = string.Empty;
        public int isDriftApplicationnameexist = 0;
        public bool isOpen = false;
        public DataGridView dgv1
        {
            get { return dgv_driftcorrectionparameter; }
            set { dgv_driftcorrectionparameter = value; }
        }
        public DataGridView dgv2
        {
            get { return dgv_test; }
            set { dgv_test = value; }
        }
        public DataGridView dgv3
        {
            get { return dgv_correctionsample; }
            set { dgv_correctionsample = value; }
        }
        public Button btn1
        {
            get { return btn_addsample; }
            set { btn_addsample = value; }
        }
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void DriftCorrectionApplication_Load(object sender, EventArgs e)
        {
            if (isDriftApplicationnameexist == 0 && isOpen==false)  //新建的漂移校正程序
            {
                txt_createsoft.Text = "i-VXRFS";
                txt_updatesoft.Text = "i-VXRFS";
                txt_createtime.Text = newDriftApplicationtime;
                txt_updatetesttime.Text = newDriftApplicationtime;
                txt_firsttesttime.Text = newDriftApplicationtime;
                txt_updatetime.Text = newDriftApplicationtime;
                cbox_filesavepath.Text = newDriftApplicationname;
                btn_addsample.Visible = true;
                try
                {
                    //“漂移校正参数”数据表信息
                    dgv_driftcorrectionparameter.ColumnCount = 5;
                    dgv_driftcorrectionparameter.ColumnHeadersVisible = true;
                    dgv_driftcorrectionparameter.Columns[0].HeaderCell.Value = "化合物";//显示数据表抬头的别名
                    dgv_driftcorrectionparameter.Columns[1].HeaderCell.Value = "斜率(α)";
                    dgv_driftcorrectionparameter.Columns[2].HeaderCell.Value = "截距(β)";
                    dgv_driftcorrectionparameter.Columns[3].HeaderCell.Value = "高点样品名";
                    dgv_driftcorrectionparameter.Columns[4].HeaderCell.Value = "低点样品名";
                    dgv_driftcorrectionparameter.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    //if (XRF_function.showdatagridview(dgv_driftcorrectionparameter, "tb_driftcorrectionparameter") == true)
                    //{

                    //}
                    //“校正样品”信息表
                    dgv_correctionsample.ColumnCount = 7;
                    dgv_correctionsample.ColumnHeadersVisible = true;
                    dgv_correctionsample.Columns[0].HeaderCell.Value = "校正样品名";
                    dgv_correctionsample.Columns[1].HeaderCell.Value = "介质";
                    dgv_correctionsample.Columns[2].HeaderCell.Value = "杯尺寸";
                    dgv_correctionsample.Columns[3].HeaderCell.Value = "真空锁定时间(s)";
                    dgv_correctionsample.Columns[4].HeaderCell.Value = "延迟时间(s)";
                    dgv_correctionsample.Columns[5].HeaderCell.Value = "旋转";//显示数据表抬头的别名
                    dgv_correctionsample.Columns[6].HeaderCell.Value = "易碎样品";
                    dgv_correctionsample.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    //if (XRF_function.showdatagridview(dgv_correctionsample, "tb_correctionsample") == true)
                    //{
                    //    // MessageBox.Show("show tb_wdxrfbar success");
                    //    //调整列宽，以填充满控件的显示区域
                    //}
                    //“检测”信息表
                    dgv_test.ColumnCount = 8;
                    dgv_test.ColumnHeadersVisible = true;
                    dgv_test.Columns[0].HeaderCell.Value = "化合物";//显示数据表抬头的别名
                    dgv_test.Columns[1].HeaderCell.Value = "测试时间(s)";
                    dgv_test.Columns[2].HeaderCell.Value = "应用强度(kcps)";//最近一次测量结果
                    dgv_test.Columns[3].HeaderCell.Value = "推荐强度(kcps)";//第一次测量的结果
                    dgv_test.Columns[4].HeaderCell.Value = "误差";
                    dgv_test.Columns[5].HeaderCell.Value = "校对模式";//显示数据表抬头的别名
                    dgv_test.Columns[6].HeaderCell.Value = "低限度";//0.7
                    dgv_test.Columns[7].HeaderCell.Value = "高限度";//1.3
                    dgv_test.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域

                  
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else  if(isDriftApplicationnameexist==1|| isOpen==true)             //通过复制过来的漂移校正程序，读取文件中的数据。或者是打开漂移校正程序
            {
                string filepath = XRF_function.DriftCorrectionApplicationPath + "\\" + newDriftApplicationname + "\\" + newDriftApplicationname+".txt";
                FileStream openfile = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite);
                StreamReader readDataSR = new StreamReader(openfile, Encoding.Default);
                readDataSR.BaseStream.Seek(0, SeekOrigin.Begin);//文件开头c

                List<string> allinfo = new List<string> { };
                int i = 0;
                allinfo.Add(readDataSR.ReadLine());
                while (allinfo[i] != null)
                {
                    allinfo.Add(readDataSR.ReadLine());
                    i++;
                }
                openfile.Close();
                readDataSR.Close();
                //分别获取-基本参数描述，漂移校正，校正样品，检测
                //所在数组中的索引号； 
                List<int> index = new List<int> { };
                index = driftSave.getdataindex(allinfo); //index[]记录上述各字段在allinfo数组中的索引号

                //基本参数描述
                string[] getgeneralstr = driftSave.splictstr(allinfo[index[0] + 1]);
                txt_createsoft.Text = getgeneralstr[0];
                txt_createtime.Text = getgeneralstr[1];
                txt_updatesoft.Text = getgeneralstr[2];
                txt_updatetime.Text = getgeneralstr[3];
                txt_firsttesttime.Text = getgeneralstr[4];
                txt_updatetesttime.Text = getgeneralstr[5];
                cbox_cupsize.Text = getgeneralstr[6];
                cbox_filesavepath.Text =getgeneralstr[7];
                cbox_correctionmodel.Text = getgeneralstr[8];
                txtb_describe.Text = getgeneralstr[9];

                string[] getaddtivestr = driftSave.splictstr(allinfo[index[1] +1]);
                driftSave.insertTextToDgvColumn(dgv_driftcorrectionparameter, getaddtivestr); //添加列头
                getaddtivestr = null;
                int k = 0;
                while ((index[1] + k + 2) < index[2])
                {
                    getaddtivestr = driftSave.splictstr(allinfo[index[1] + k + 2]);
                    driftSave.insertTextToDgvRow(dgv_driftcorrectionparameter, getaddtivestr);
                    k++;
                    getaddtivestr = null;
                }
                string[] getaddtivestr1 = driftSave.splictstr(allinfo[index[2] + 1]);
                driftSave.insertTextToDgvColumn(dgv_correctionsample, getaddtivestr1); //添加列头
                getaddtivestr1 = null;
                int k1 = 0;
                while ((index[2] + k1 + 2) < index[3])
                {
                    getaddtivestr1 = driftSave.splictstr(allinfo[index[2] + k1 + 2]);
                    driftSave.insertTextToDgvRow(dgv_correctionsample, getaddtivestr1);
                    k1++;
                    getaddtivestr1 = null;
                }
                string[] getaddtivestr2 = driftSave.splictstr(allinfo[index[3] + 1]);
                driftSave.insertTextToDgvColumn(dgv_test, getaddtivestr2); //添加列头
                getaddtivestr2 = null;
                int k2 = 0;
                while ((index[3] + k2 + 2) < allinfo.Count-1 && allinfo[index[3]+k2+2]!=" ")
                {
                    getaddtivestr2 = driftSave.splictstr(allinfo[index[3] + k2 + 2]);
                    driftSave.insertTextToDgvRow(dgv_test, getaddtivestr2);
                    k2++;
                    getaddtivestr2 = null;
                }

            }
            txt_createsoft.ReadOnly = true;
            txt_updatesoft.ReadOnly = true;
            txt_createtime.ReadOnly = true;
            txt_updatetime.ReadOnly = true;
            txt_updatetesttime.ReadOnly = true;
            txt_firsttesttime.ReadOnly = true;
            dgv_correctionsample.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
            dgv_driftcorrectionparameter.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
            dgv_test.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列宽，以填充满控件的显示区域
            dgv_correctionsample.AllowUserToAddRows = false;
            dgv_driftcorrectionparameter.AllowUserToAddRows = false;
            dgv_test.AllowUserToAddRows = false;
        }

        private void btn_addelementfromold_Click(object sender, EventArgs e)
        {
            OpenCreatedQuantitationAnalysisApplication openCreatedQAAForm = new OpenCreatedQuantitationAnalysisApplication(this);
            openCreatedQAAForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDriftCompound adddriftForm = new AddDriftCompound(this);
            adddriftForm.Show();
        }
        //禁止点击列头排序
        public void BanColumsSort(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)  //delete
        {
            if(dgv_driftcorrectionparameter.SelectedRows !=null){
                int index = dgv_driftcorrectionparameter.CurrentCell.RowIndex;
                dgv_driftcorrectionparameter.Rows.Remove(dgv_driftcorrectionparameter.CurrentRow);
                dgv_test.Rows.Remove(dgv_test.Rows[index]);
            }else{
                MessageBox.Show("请选择要删除的元素化合物！");
            }
        }
        //添加漂移校正样品
        private void btn_addsample_Click(object sender, EventArgs e)
        {
            AddDriftSample adddriftSqmple = new AddDriftSample(this);
            adddriftSqmple.Show();
        }
        private int of = 0;
        private void btn_cancle_correctionsample_Click(object sender, EventArgs e)
        {
            if (dgv_correctionsample.SelectedRows != null)
            {
                int index = dgv_correctionsample.CurrentCell.RowIndex;
                dgv_correctionsample.Rows.Remove(dgv_correctionsample.CurrentRow);
                int ColIndex = 0;
                if (index == 0)
                {
                    if (of == 0)
                    {
                        ColIndex = 3;
                        of = 1;
                    }
                    else
                    {
                        ColIndex = 4; of = 0;
                    }
                }
                else
                {
                    ColIndex = 4;
                }
                for (int i = 0; i < dgv_driftcorrectionparameter.Rows.Count; i++)
                {
                    dgv_driftcorrectionparameter.Rows[i].Cells[ColIndex].Value = null;
                }
                btn_addsample.Visible = true;
            }
            else
            {
                MessageBox.Show("请选择要删除的元素化合物！");
            }
        }
        //保存数据
        private void btn_save_Click(object sender, EventArgs e)
        {
            string savePath = null;
            if (isDriftApplicationnameexist == 1) //复制过来的程序，保存在临时文件中
            {
                savePath = XRF_function.QuantitationApplicationTempPath + "\\"+newDriftApplicationname+"_temp.txt";
            }
            else
            {
                savePath = XRF_function.DriftCorrectionApplicationPath + "\\" + newDriftApplicationname + "\\" + newDriftApplicationname + ".txt";
            }
            UtilityClass.CreateFile(savePath, true);
            StreamWriter saveSW = new StreamWriter(savePath, false, Encoding.Default);
            saveSW.WriteLine("基本参数描述");
            setEmpty(txt_createsoft); setEmpty(txt_createtime); setEmpty(txt_updatesoft); setEmpty(txt_updatetime); setEmpty(txt_firsttesttime); setEmpty(txt_updatetesttime);
            setEmpty(cbox_cupsize); setEmpty(cbox_filesavepath); setEmpty(cbox_correctionmodel); setEmpty(txtb_describe);
            string info=txt_createsoft.Text  +"," + txt_createtime.Text+","+txt_updatesoft.Text+"," + txt_updatetime.Text+","+txt_firsttesttime.Text+","+txt_updatetesttime.Text+","+ cbox_cupsize.Text+
                ","+ cbox_filesavepath.Text+","+cbox_correctionmodel.Text +"," +txtb_describe.Text;
            saveSW.WriteLine(info);
            List<string> data = new List<string>();
            driftSave.readDgvToList(dgv_driftcorrectionparameter, ref data);
            saveSW.WriteLine("漂移校正参数");
            for (int i = 0; i < data.Count; i++)
                saveSW.WriteLine(data[i]);
            data.Clear();
            driftSave.readDgvToList(dgv_correctionsample, ref data);
            saveSW.WriteLine("校正样品");
            for (int i = 0; i < data.Count; i++)
                saveSW.WriteLine(data[i]);
            data.Clear();
            driftSave.readDgvToList(dgv_test, ref data);
            saveSW.WriteLine("检测");
            for (int i = 0; i < data.Count; i++)
                saveSW.WriteLine(data[i]);
            data.Clear();

            saveSW.Flush();
            saveSW.Close();
            if (isDriftApplicationnameexist == 1)
            {
                //弹出窗口提示修改程序名
                changeDriftApplicationName changeapplicationname = new changeDriftApplicationName();
                changeapplicationname.changename = this.newDriftApplicationname;//把定量分析程序名传递给子窗口变量
                changeapplicationname.Show();
                isDriftApplicationnameexist = 0;
               // this.Close();
            }
            this.Close();
        }
        private void setEmpty(TextBox txtb)
        {
            if (txtb.Text == null)
                txtb.Text =" ";
        }
        private void setEmpty(ComboBox cbox)
        {
            if (cbox.Text == null)
                cbox.Text = " ";
        }


    }
}
