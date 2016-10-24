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

namespace i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation
{
    public partial class AddCorrectionFactor : Form
    {
        public AddCorrectionFactor()
        {
            InitializeComponent();
        }
        public string path;
        public List<List<string>> LineParamData;
        i_VXRFS_function XRF_function = new i_VXRFS_function();
        private void AddCorrectionFactor_Load(object sender, EventArgs e)
        {
            rbtn_conc.Checked = true; //默认浓度校正因子被选中
            lstb_Loc.Items.Add("None");
            lstb_LoR.Items.Add("None");
            lstb_a.Items.Add("None");
            lstb_b.Items.Add("None");
            lstb_c.Items.Add("None");
            lstb_d.Items.Add("None");
            for (int i = 1; i < LineParamData.Count; i++)
            {
                lstb_Loc.Items.Add(LineParamData[i][0]);
                lstb_LoR.Items.Add(LineParamData[i][0]);
                lstb_a.Items.Add(LineParamData[i][0]);
                lstb_b.Items.Add(LineParamData[i][0]);
                lstb_c.Items.Add(LineParamData[i][0]);
                lstb_d.Items.Add(LineParamData[i][0]);
            }
            label6.Visible = false;
            lstb_LoR.Visible = false;
            //lstb_a.Items.Font= new Font("Arial", 15);
            //将系统氧化物表的化合物数据添加到listview的Item中
            //SqlConnection conn = new SqlConnection(XRF_function.LinkDataBasePath);
            //string str = "Select name from tb_sysoxide";
            //conn.Open();
            //SqlCommand cmd = new SqlCommand(str, conn);
            //SqlDataReader sdr = cmd.ExecuteReader();
            //while (sdr.Read())
            //{
            //    lstb_Loc.Items.Add(sdr[0].ToString());
            //    lstb_a.Items.Add(sdr[0].ToString());
            //    lstb_b.Items.Add(sdr[0].ToString());
            //    lstb_c.Items.Add(sdr[0].ToString());
            //    lstb_d.Items.Add(sdr[0].ToString());
            //}
            //sdr.Close();
            //conn.Close();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCorrectionFactor_FormClosed(object sender, FormClosedEventArgs e)
        {
            lstb_Loc.Items.Clear();
            lstb_a.Items.Clear();
            lstb_b.Items.Clear();
            lstb_c.Items.Clear();
            lstb_d.Items.Clear();
        }

        private void rbtn_kcps_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_kcps.Checked == true)
            {
                label6.Visible = true;
                lstb_LoR.Visible = true;
            }
            else
            {
                label6.Visible = false;
                lstb_LoR.Visible = false;
            }
        }

        
    }
}
