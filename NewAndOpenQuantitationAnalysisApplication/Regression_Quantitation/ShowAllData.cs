using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    public partial class ShowAllData : Form
    {
        public ShowAllData()
        {
            InitializeComponent();
        }

        public void addCell(DataGridViewRow row, string str){
            DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
            textboxcell.Value = str;
            row.Cells.Add(textboxcell);
        }
        public string ApplicationNames;
        i_VXRFS_function XRF_function = new i_VXRFS_function();
       // public string regData = Public_Path.QuantitationApplicationPath + "\\test\\RevisionData_test.txt";
        public void loadData()
        {
            string regData = XRF_function.QuantitationApplicationPath + "\\" + ApplicationNames + "\\RevisionData_" + ApplicationNames + ".txt";
            dataGridView.Columns.Clear();
            string[] data = File.ReadAllLines(regData, Encoding.UTF8);
            string[] strs = data[0].Split('\t');
            for (int i = 0; i < strs.Length; ++i)
                if (time_check.Checked || i != 1)
                {
                    DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
                    c.HeaderText = strs[i];
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView.Columns.Add(c);
                }
            List<CheckBox> checks = new List<CheckBox>();
            checks.Add(check0);
            checks.Add(check1);
            checks.Add(check2);
            checks.Add(check3);
            checks.Add(check4);
            checks.Add(check5);
            checks.Add(check6);
            checks.Add(check7);
            checks.Add(check8);
            checks.Add(check9);
            checks.Add(check10);
            for (int i = 1; i < data.Length; i += 11)
            {
                DataGridViewRow row = new DataGridViewRow();
                strs = data[i].Split('\t');
                addCell(row, strs[0]);

                if (time_check.Checked)
                {
                    addCell(row, strs[1]);
                }

                bool isFill = false;
                for (int idx = 0; idx < 11; ++idx)
                    if (checks[idx].Checked)
                    {   
                        strs = data[i + idx].Split('\t');
                        if (isFill)
                        {
                            row = new DataGridViewRow();
                            addCell(row, "");
                            if (time_check.Checked)
                            {
                                addCell(row, "");
                            }
                        }
                        for (int j = 2; j < strs.Length; ++j)
                        {
                            addCell(row, strs[j]);
                        }
                        dataGridView.Rows.Add(row);
                        isFill = true;
                    }
            }
        }

        private void ShowData_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void check4_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void check7_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void time_check_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void check5_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void check8_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void check0_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void check3_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void check6_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void check9_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void check10_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
