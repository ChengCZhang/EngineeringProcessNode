using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProcessNode
{
    /// <summary>
    /// 节点基本状态
    /// </summary>
    public enum ProcessNodeBaseStatus
    {
        /// <summary>
        /// 等待开始
        /// </summary>
        [Description("等待")]
        Waiting,
        /// <summary>
        /// 正在进行
        /// </summary>
        [Description("进行")]
        Processing,
        /// <summary>
        /// 已经结束
        /// </summary>
        [Description("结束")]
        Finish
    }

    /// <summary>
    /// 节点进度状态
    /// </summary>
    public enum ProcessNodeProgressStatus
    {
        /// <summary>
        /// 早于允许时间
        /// </summary>
        [Description("提前")]
        Ahead,
        /// <summary>
        /// 在允许时间段内
        /// </summary>
        [Description("按期")]
        OnSchedule,
        /// <summary>
        /// 晚于允许时间
        /// </summary>
        [Description("延误")]
        Delayed
    }

    /// <summary>
    /// 节点特殊状态
    /// </summary>
    [Flags]
    public enum ProcessNodeSpecialStatus
    {
        /// <summary>
        /// 缺省状态
        /// </summary>
        [Description("缺省")]
        None = 0,

    }

    /// <summary>
    /// 节点约束条件
    /// </summary>
    [Flags]
    public enum ProcessNodeRestrictions
    {
        /// <summary>
        /// 缺省状态
        /// </summary>
        [Description("缺省")]
        None = 0,
    }

    /// <summary>
    /// 节点分支
    /// </summary>
    public enum ProcessNodeBranch
    {
        /// <summary>
        /// 默认分支
        /// </summary>
        Zero,
        /// <summary>
        /// 分支1
        /// </summary>
        One,
        /// <summary>
        /// 分支2
        /// </summary>
        Two,
    }
}
