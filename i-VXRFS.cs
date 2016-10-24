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
using i_VXRFS.NewAndOpenQuantitationAnalysisApplication.Regression_Quantitation;
using i_VXRFS.SystemConfiguration;
using i_VXRFS.Test.QuantitativeMeas;
using i_VXRFS.NewAndOpenQuantitationAnalysisApplication.DriftRevision;
//using i_VXRFS.PerformanceTest;
using i_VXRFS.ApplicationProcedure.PerformanceTest;
using i_VXRFS.ApplicationProcedure;
using i_VXRFS.ResultDataAnalysis.QualitationAnalysisResults;
using i_VXRFS.ResultDataAnalysis.QuantitationAnalysisResults;
using i_VXRFS.Test;

namespace i_VXRFS
{
    
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void 波长色散系统设置ToolStripMenuItem_Click(object sender, EventArgs e)//打开波长色散系统设置窗口
        {
            wdxrf_sysconfiguration wdxrfform = new wdxrf_sysconfiguration();
            wdxrfform.MdiParent=this;
            wdxrfform.Show();
        }

        private void 能量色散系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edxrf_sysconfiguration edxrfform = new edxrf_sysconfiguration();
            edxrfform.MdiParent = this;
            edxrfform.Show();
        }

        private void 微区分析系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            microanalysis_sysconfiguration microform = new microanalysis_sysconfiguration();
            microform.MdiParent = this;
            microform.Show();
        }

        private void 新建程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createnewquantitativeanalysis_application createnewquantitationanalysisapplicationform = new createnewquantitativeanalysis_application();
            createnewquantitationanalysisapplicationform.MdiParent = this;
            createnewquantitationanalysisapplicationform.Show();
        }

        private void 打开程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //选择需要打开的定量分析程序名

            //打开新建的定量分析程序参数设置界面
            OpenQuantitationAnalysisApplication openquantitationanalysisapplicationform = new OpenQuantitationAnalysisApplication();
            openquantitationanalysisapplicationform.Show();
        }

        private void 删除程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteQuantitationAnalysisApplication deletequantitationanalysisapplicationform = new DeleteQuantitationAnalysisApplication();
            deletequantitationanalysisapplicationform.Show();
        }

        private void 标样ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Standardsample standardsampleLibrary_quantitationanalysisapplicationform = new Standardsample();
            standardsampleLibrary_quantitationanalysisapplicationform.Show();
        }


        private void 校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenQuantitationRevisionAnalysisApplication revisionform = new OpenQuantitationRevisionAnalysisApplication();
            revisionform.Show();
        }

        private void pHD角度校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformanceTest_mainPage phdangelForm = new PerformanceTest_mainPage();
            phdangelForm.Show();
        }


        private void 新建漂移校正程序ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateDriftCorrectionApplication createdriftcorrectionform = new CreateDriftCorrectionApplication();
            createdriftcorrectionform.Show();
        }

        private void 打开漂移校正程序ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenDriftCorrectionApplication opendriftcorrectionform = new OpenDriftCorrectionApplication();
            opendriftcorrectionform.Show();
        }

        private void 删除漂移校正程序ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteDriftCorrectionApplication deletedriftcorrectionapplicationform = new DeleteDriftCorrectionApplication();
            deletedriftcorrectionapplicationform.Show();
        }

        private void 性能测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformanceTest_mainPage performanceForm = new PerformanceTest_mainPage();
            performanceForm.Show();
        }


        private void 系统化合物ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SystemCompound syscompoundform = new SystemCompound();
            syscompoundform.Show();
        }

        private void 标准样品库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StandardSampleLibrary standardsamplelibraryform = new StandardSampleLibrary();
            standardsamplelibraryform.Show();
        }

        private void 定量分析ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChoiceQuantitationAnalysisResults choicequantitationanalysisresultsform = new ChoiceQuantitationAnalysisResults();
            choicequantitationanalysisresultsform.Show();
        }

        private void 定性结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QualitationAnalysisResult qualitationanalysisresultsform = new QualitationAnalysisResult();
            qualitationanalysisresultsform.Show();
        }
        //定量分析 测量
        private void 定量分析ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MeasurementSample_QuantitationAnalysis measurementsample_quantitationform = new MeasurementSample_QuantitationAnalysis();
            measurementsample_quantitationform.Show();
        }
        //定性分析 测量   与定量测量不同  ——需要做修改
        private void 定性分析ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MeasurementSample_QuantitationAnalysis measurementsampleform = new MeasurementSample_QuantitationAnalysis();
            measurementsampleform.Show();
        }

        private void 谱仪状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSpectroState spectroform = new ShowSpectroState();
            spectroform.Show();
        }

      

   
       
    }
}
