using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_VXRFS.Test.QuantitativeMeas
{
    public partial class MeasurementForm_Std : Form
    {
        public MeasurementForm_Std()
        {
            InitializeComponent();
        }

        private void MeasurementForm_Std_Load(object sender, EventArgs e)
        {
            dgv_results.ColumnCount = 5;
            dgv_results.ColumnHeadersVisible = true;
            dgv_results.Columns[0].HeaderCell.Value = "元素";
            dgv_results.Columns[1].HeaderCell.Value = "总强度(kcps)";
            dgv_results.Columns[2].HeaderCell.Value = "净强度(kcps)";
            dgv_results.Columns[3].HeaderCell.Value = "漂移强度(kcps)";
            dgv_results.Columns[4].HeaderCell.Value = "浓度(%)";
            dgv_results.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
