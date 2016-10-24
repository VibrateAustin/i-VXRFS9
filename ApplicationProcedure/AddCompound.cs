using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace i_VXRFS.ApplicationProcedure
{
    public partial class AddCompound : Form
    {
        public addCoumpound inv;

        //字典，保存元素->化合物的映射
        public Dictionary<string, HashSet<string>> eleDict = new Dictionary<string, HashSet<string>>();

        //字典，保存元素->谱线的映射
        public Dictionary<string, HashSet<string>> comDict = new Dictionary<string, HashSet<string>>();

        public AddCompound(addCoumpound inv)
        {
            this.inv = inv;
            InitializeComponent();
        }

        //通过button的名字判断添加了哪个元素，并加入备选表中
        private void itemClick(String item)
        {
            if (eleDict.ContainsKey(item))
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                textboxcell.Value = item;
                row.Cells.Add(textboxcell);

                DataGridViewComboBoxCell compondCombobox = new DataGridViewComboBoxCell();
                row.Cells.Add(compondCombobox);
                foreach (string s in eleDict[item])
                {
                    compondCombobox.Items.Add(s);
                }

                DataGridViewComboBoxCell cb = new DataGridViewComboBoxCell();
                row.Cells.Add(cb);
                foreach (string s in comDict[item])
                {
                    cb.Items.Add(s);
                }

                compoundView.Rows.Add(row);
            }
        }

        //元素周期表中一个元素为一个按钮
        private void H_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void He_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Li_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Be_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void B_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void C_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void N_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void O_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void F_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ne_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Na_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Mg_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Al_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Si_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void P_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void S_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Cl_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ar_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void K_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ca_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Sc_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ti_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void V_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Cr_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Mn_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Fe_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Co_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ni_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Cu_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Zn_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ga_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ge_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void As_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Se_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Br_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Kr_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Rb_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Sr_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Y_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Zr_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Nb_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Mo_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Tc_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ru_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Rh_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Pd_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ag_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Cd_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void In_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Sn_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Sb_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Te_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void I_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Xe_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Cs_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ba_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ce_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Pr_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Nd_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Pm_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Sm_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Eu_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Gd_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Tb_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Dy_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ho_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Er_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Tm_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Yb_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Lu_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Hf_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ta_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void W_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void La_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Re_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Os_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ir_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Pt_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Au_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Hg_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Tl_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Pb_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Bi_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Po_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void At_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Rn_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Fr_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ra_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ac_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Th_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Pa_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void U_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Np_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Pu_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Am_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Cm_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Bk_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Cf_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Es_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Fm_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Md_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void No_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Lr_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Rf_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Db_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Sg_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Bh_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Hs_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Mt_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Ds_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }
        private void Rg_Click(object sender, EventArgs e) { itemClick(((Button)sender).Text); }

        //载入AddCompoundConfig.txt这个配置文件，并形成字典
        private void AddCompound_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(Public_Path.SysConfigurationParameterPath + "\\AddCompoundConfig.txt");
            while (!reader.EndOfStream)
            {
                string[] strs = reader.ReadLine().Split(',');
                if (strs.Length >= 3)
                {
                    if (eleDict.ContainsKey(strs[0]))
                    {
                        eleDict[strs[0]].Add(strs[1]);
                    }
                    else
                    {
                        HashSet<string> tmp = new HashSet<string>();
                        tmp.Add(strs[1]);
                        eleDict[strs[0]] = tmp;
                    }
                    if (comDict.ContainsKey(strs[0]))
                    {
                        comDict[strs[0]].Add(strs[2]);
                    }
                    else
                    {
                        HashSet<string> tmp = new HashSet<string>();
                        tmp.Add(strs[2]);
                        comDict[strs[0]] = tmp;
                    }
                }
            }
            reader.Close();
        }

        //删除选中的化合物
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (compoundView.Rows.Count > 0)
                compoundView.Rows.RemoveAt(compoundView.CurrentCell.RowIndex);
        }

        //确认，并将化合物添加到表中
        private void confirmButton_Click(object sender, EventArgs e)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < compoundView.Rows.Count; ++i)
                if ((compoundView.Rows[i].Cells[1].Value + "").Length > 0)
                {
                    result.Add(compoundView.Rows[i].Cells[1].Value + "");
                }
            inv.Invoke(result);
            this.Close();
        }
    }
}
