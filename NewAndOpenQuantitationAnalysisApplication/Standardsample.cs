using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using Microsoft.VisualBasic;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication
{
    public delegate void addCoumpound(List<string> name);

    public delegate void openFile(string name);

    public delegate void saveFile(string name);

    public partial class Standardsample : Form
    {
        //临时表名
        public string tmpTableName = "tmp";

        //数据表名
        public string tableName = "standards";

        //数据库地址
        public string path = "";

        public Standardsample()
        {
            InitializeComponent();
        }

        //添加标样
        private void addStandard_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("标样名称：", "添加标样", "", 500, 500);
            if (name.Length > 0)
            {
                SQLiteHelper.ExecuteNonQuery("insert into " + tmpTableName + " (name,addtime) values('" + name + "','" + DateTime.Now.ToString("yyyyMMdd") + "')", path);
                refresh("");
            }
        }

        //删除标样
        private void deleteStandard_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否确定删除" + dataView.CurrentRow.Cells[0].Value + "[" + dataView.CurrentRow.Cells[2].Value + "]标样", "删除标样", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                SQLiteHelper.ExecuteNonQuery("delete from " + tmpTableName + " where name = '" + dataView.CurrentRow.Cells[0].Value + "' and (morphology = '" + dataView.CurrentRow.Cells[2].Value + "' or morphology = '' or morphology is null)", path);
            }
            refresh("");
        }

        //根据条件刷新表中数据
        private void refresh(string where)
        {
            dataView.DataSource = SQLiteHelper.ExecuteDataset("select * from " + tmpTableName + (where.Length > 0 ? " where " + where : ""), path).Tables[0];
            morphologyBox.Items.Clear();
            additiveBox.Items.Clear();
            ratioBox.Items.Clear();
            HashSet<string> set = new HashSet<string>();
            HashSet<string> set1 = new HashSet<string>();
            HashSet<string> set2 = new HashSet<string>();
            for (int i = 0; i < dataView.Rows.Count; ++i)
            {
                if (set.Add(dataView.Rows[i].Cells[2].Value + ""))
                {
                    morphologyBox.Items.Add(dataView.Rows[i].Cells[2].Value + "");
                }
                if (set1.Add(dataView.Rows[i].Cells[3].Value + ""))
                {
                    additiveBox.Items.Add(dataView.Rows[i].Cells[3].Value + "");
                }
                if (set2.Add(dataView.Rows[i].Cells[4].Value + ""))
                {
                    ratioBox.Items.Add(dataView.Rows[i].Cells[4].Value + "");
                }
            }
            for (int i = 0; i < dataView.Columns.Count; ++i)
            {
                switch (dataView.Columns[i].Name)
                {
                    case "Name":
                        dataView.Columns[i].HeaderText = "名称";
                        break;
                    case "SampleMass":
                        dataView.Columns[i].HeaderText = "样品量(g)";
                        break;
                    case "Morphology":
                        dataView.Columns[i].HeaderText = "样品形态";
                        break;
                    case "Additive":
                        dataView.Columns[i].HeaderText = "添加剂";
                        break;
                    case "Ratio":
                        dataView.Columns[i].HeaderText = "比例/类型";
                        break;
                    case "Addtime":
                        dataView.Columns[i].HeaderText = "建立时间";
                        break;
                    case "LossMass":
                        dataView.Columns[i].HeaderText = "烧失量(%)";
                        break;
                    case "TotPercent":
                        dataView.Columns[i].HeaderText = "总百分含量(%)";
                        break;
                }
            }
        }

        //当表中数据被编辑，写入数据库临时表
        private void dataView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SQLiteHelper.ExecuteNonQuery("update " + tmpTableName + " set " + dataView.Columns[e.ColumnIndex].Name + " = '" + dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "' where name = '" + dataView.Rows[e.RowIndex].Cells[0].Value + "'", path);
                refresh("");
            }
        }

        //导入标样
        private void importStandards_Click(object sender, EventArgs e)
        {
            (new OpenFile(openfile)).Show();
        }

        //打开文件
        public void openfile(string name)
        {
            path = name;
            SQLiteHelper.ExecuteNonQuery("create table if not exists " + tableName + " (Name text, SampleMass double, Morphology text, Additive text, Ratio text, Addtime text, LossMass double, TotPercent)", path);
            SQLiteHelper.ExecuteNonQuery("drop table if exists " + tmpTableName, path);
            SQLiteHelper.ExecuteNonQuery("create table " + tmpTableName + " as select * from " + tableName, path);
            refresh("");
            addStandard.Enabled = true;
            addCompound.Enabled = true;
            deleteStandard.Enabled = true;
            deleteCompound.Enabled = true;
            exportStandards.Enabled = true;
            save.Enabled = true;
            print.Enabled = true;
        }

        //删除化合物
        private void deleteCompound_Click(object sender, EventArgs e)
        {
            int delIdx = dataView.CurrentCell.ColumnIndex;
            if (delIdx < 8)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("是否确定删除" + dataView.Columns[delIdx].Name + "化合物", "删除化合物", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                string tmpName = tmpTableName + "_tmp";
                string columns = "";
                for (int i = 0; i < dataView.ColumnCount; ++i)
                    if (i != delIdx)
                    {
                        columns += (columns.Length > 0 ? "," : "") + dataView.Columns[i].Name;
                    }
                SQLiteHelper.ExecuteNonQuery("create table " + tmpName + " as select " + columns + " from " + tmpTableName, path);
                SQLiteHelper.ExecuteNonQuery("drop table " + tmpTableName, path);
                SQLiteHelper.ExecuteNonQuery("alter table " + tmpName + " rename to " + tmpTableName, path);
            }
            refresh("");
        }

        //添加化合物界面的响应逻辑
        public void compound(List<string> name)
        {
            if (name.Count > 0)
            {
                foreach (string s in name)
                {
                    bool isAdd = true;
                    for (int j = 0; j < dataView.ColumnCount; ++j)
                        if (dataView.Columns[j].Name.Equals(s))
                        {
                            isAdd = false;
                        }
                    if (isAdd)
                    {
                        SQLiteHelper.ExecuteNonQuery("alter table " + tmpTableName + " add column " + s + " double", path);
                    }
                }
            }
            refresh("");
        }

        //打开添加化合物界面
        private void addCompound_Click(object sender, EventArgs e)
        {
            (new AddCompound_qualitation(compound)).Show();
        }

        private void Standards_Load(object sender, EventArgs e)
        {
        }

        //条件过滤
        private void filter_Click(object sender, EventArgs e)
        {
            string where = (datePicker1.Text.Length > 0 ? "addtime >= " + datePicker1.Text + " and " : "")
                + (datePicker2.Text.Length > 0 ? "addtime <= " + datePicker2.Text + " and " : "")
                + (morphologyBox.Text.Length > 0 ? "morphology = \"" + morphologyBox.Text + "\" and " : "")
                + (additiveBox.Text.Length > 0 ? "additive = \"" + additiveBox.Text + "\" and " : "")
                + (ratioBox.Text.Length > 0 ? "ratio = \"" + ratioBox.Text + "\" and " : "");
            if (where.Length > 0)
            {
                refresh(where.Substring(0, where.Length - 4));
            }
        }

        //取消过滤
        private void cancelFilter_Click(object sender, EventArgs e)
        {
            refresh("");
        }

        //标样形态下拉框变动逻辑
        private void morphologyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ratioBox.Items.Clear();
            additiveBox.Items.Clear();
            if (morphologyBox.SelectedIndex > -1)
            {
                HashSet<string> set1 = new HashSet<string>();
                HashSet<string> set2 = new HashSet<string>();
                for (int i = 0; i < dataView.Rows.Count; ++i)
                    if (dataView.Rows[i].Cells[2].Value.Equals(morphologyBox.Text))
                    {
                        if (set1.Add(dataView.Rows[i].Cells[3].Value + ""))
                        {
                            additiveBox.Items.Add(dataView.Rows[i].Cells[3].Value + "");
                        }
                        if (set2.Add(dataView.Rows[i].Cells[4].Value + ""))
                        {
                            ratioBox.Items.Add(dataView.Rows[i].Cells[4].Value + "");
                        }
                    }
            }
        }
        /*
        //显示回归界面，可删除
        private void button1_Click(object sender, EventArgs e)
        {
            new i_VXRFS.Regression_Quantitation.Regression().Show();
        }
        */
        //保存
        private void save_Click(object sender, EventArgs e)
        {
            (new SaveFile(savefile)).Show();
        }

        private void saveNow()
        {
            SQLiteHelper.ExecuteNonQuery("drop table if exists " + tableName, path);
            SQLiteHelper.ExecuteNonQuery("create table " + tableName + " as select * from " + tmpTableName, path);
            StreamWriter sw = new StreamWriter(new FileStream(path.Replace(".db", ".txt"), FileMode.Create));
            for (int j = 0; j < dataView.Columns.Count; ++j)
            {
                if (j > 0)
                {
                    sw.Write(",");
                }
                sw.Write(dataView.Columns[j].HeaderText);
            }
            sw.WriteLine("");
            for (int i = 0; i < dataView.RowCount; ++i)
            {
                for (int j = 0; j < dataView.ColumnCount; ++j)
                {
                    if (j > 0)
                    {
                        sw.Write(",");
                    }
                    sw.Write(dataView.Rows[i].Cells[j].Value);
                }
                sw.WriteLine("");
                sw.Flush();
            }
            sw.Close();
        }

        //保存文件
        private void savefile(string name)
        {
                System.IO.File.Copy(path, name, true);
                path = name;
                saveNow();
                refresh("");
        }
        /*
        //另存为
        private void saveas(object sender, EventArgs e)
        {
            OpenFileDialog fileD = new OpenFileDialog();
            fileD.CheckFileExists = false;
            if (fileD.ShowDialog() == DialogResult.OK)
            {
                String sourcePath = "";
                String targetPath = fileD.FileName;
                System.IO.File.Copy(sourcePath, targetPath, false);
                SQLiteHelper.ExecuteNonQuery("drop table if exists " + tableName, path);
                SQLiteHelper.ExecuteNonQuery("alter table " + tmpTableName + " rename to " + tableName, path);
                SQLiteHelper.ExecuteNonQuery("create table " + tmpTableName + " as select * from " + tableName, path);
                refresh("");
            }
        }*/

        //导出成Excel
        private void exportStandards_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileD = new OpenFileDialog();
            fileD.CheckFileExists = false;
            if (fileD.ShowDialog() == DialogResult.OK)
            {
                Excel.Application excel = null;
                Excel.Workbook workbook = null;
                Excel.Worksheet sheet = null;
                try
                {
                    excel = new Excel.ApplicationClass();
                    workbook = excel.Workbooks.Add(true);
                    sheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                    for (int i = 0; i < dataView.Columns.Count; ++i)
                    {
                        sheet.Cells[1, i + 1] = dataView.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dataView.Rows.Count; ++i)
                    {
                        for (int j = 0; j < dataView.Columns.Count; ++j)
                        {
                            sheet.Cells[2 + i, 1 + j] = dataView.Rows[i].Cells[j].Value;
                        }
                    }
                    workbook.SaveAs(fileD.FileName, Excel.XlFileFormat.xlWorkbookDefault);
                    workbook.Close(true, null, null);
                    excel.Workbooks.Close();
                    excel.Quit();
                }
                finally
                {
                    if (sheet != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                        sheet = null;
                    }
                    if (workbook != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                        workbook = null;
                    }
                    if (excel != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                        excel = null;
                    }
                    GC.Collect();
                }
            }
        }

        //弹出打印窗口
        private void print_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = path.Split('\\').Last().Replace(".db", "");
            printer.PageNumbers = true;
            printer.ShowTotalPageNumber = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "页 脚";
            printer.FooterSpacing = 15;
            printer.PageSeparator = " / ";
            printer.PageText = "页";
            printer.PrintPreviewDataGridView(dataView);
        }

        //选中日期，修改对应格数据
        private void calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            dataView.CurrentCell.Value = e.Start.Date.ToString("yyyyMMdd");
            SQLiteHelper.ExecuteNonQuery("update " + tmpTableName + " set " + dataView.Columns[5].Name + " = '" + dataView.Rows[dataView.CurrentRow.Index].Cells[5].Value + "' where name = '" + dataView.Rows[dataView.CurrentRow.Index].Cells[0].Value + "'", path);
            refresh("");
            calendar.Visible = false;
        }

        //判断是否是日期列
        private void dataView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                calendar.Visible = true;
            }
        }

        //结束编辑状态关闭日历
        private void dataView_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            calendar.Visible = false;
        }
    }
}
