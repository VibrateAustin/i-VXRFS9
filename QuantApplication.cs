using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace i_VXRFS
{
    //公共参数
    public struct CommanParameter
    {
        string create_at;
        DateTime create_time;
        string update_at;
        DateTime update_time;
        string sample_preparation;
    }

    //条件
    public struct Condition
    {
        //常用条件
        int lock_time;
        int delay_time;
        int mask;
        int cup;
        string medium;
        string priority;
        string save_path;
        bool is_quanlitation;
        bool is_fragile;

        //定量条件
        bool is_rotation;
        bool is_start_high;
        bool is_check;
        bool is_report;
        string input;
        string calibration;
        string calibration_update;
    }

    //样品描述
    public struct SampleDescription
    {
        string sample_state;
        string sample_size;
        double lost;
        double thickness;
        double diameter;
        string additive;
        double total_mass;
        bool is_fixed_ratio;
        //还需要一个对添加剂具体描述的字段，但是暂时未定怎么描述
    }

    //化合物
    public struct Compound
    {
        bool is_normalized;
        double normalized_num;
        DataTable compound;
    }

    //公共背景
    public struct Background
    {
        double min_time;
        double max_time;
        DataTable background;
    }

    //定量分析程序
    public struct QuantApplication
    {
        CommanParameter common_papameter;
        Condition condition;
        SampleDescription sample_descrition;
        Compound compound;
        DataTable element;
        Background background;
    }
}
