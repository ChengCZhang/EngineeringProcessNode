using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProcessNode
{
    /// <summary>
    /// 节点基本状态/节点进度状态
    /// </summary>
    [Flags]
    public enum ProcessNodeBaseStatus : uint
    {
        /// <summary>
        /// 缺省状态
        /// </summary>
        [Description("缺省")]

        None = 0x0000,
        /// <summary>
        /// 等待开始
        /// </summary>
        [Description("等待")]
        Waiting = 0x0001,
        /// <summary>
        /// 正在进行
        /// </summary>
        [Description("进行")]
        Processing = 0x0002,
        /// <summary>
        /// 已经结束
        /// </summary>
        [Description("结束")]
        Finish = 0x0004,
        /// <summary>
        /// 早于允许时间
        /// </summary>
        [Description("提前")]
        Ahead = 0x0100,
        /// <summary>
        /// 在允许时间段内
        /// </summary>
        [Description("按期")]
        OnSchedule = 0x0200,
        /// <summary>
        /// 晚于允许时间
        /// </summary>
        [Description("延误")]
        Delayed = 0x0400,

    }

    /// <summary>
    /// 节点特殊状态
    /// </summary>
    [Flags]
    public enum ProcessNodeSpecialStatus : uint
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
    public enum ProcessNodeRestrictions : uint
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
    [Flags]
    public enum ProcessNodeBranch : uint
    {
        /// <summary>
        /// 默认分支
        /// </summary>
        [Description("缺省")]
        Zero = 0,
        /// <summary>
        /// 分支1
        /// </summary>
        [Description("分支1")]
        One = 1 << 1,
        /// <summary>
        /// 分支1的别名
        /// </summary>
        [Description("是")]
        Yes = 1 << 1,
        /// <summary>
        /// 分支2
        /// </summary>
        [Description("分支2")]
        Two = 1 << 2,
        /// <summary>
        /// 分支2的别名
        /// </summary>
        [Description("否")]
        No = 1 << 2,
        /// <summary>
        /// 分支3
        /// </summary>
        [Description("分支3")]
        Three = 1 << 3,
        /// <summary>
        /// 分支4
        /// </summary>
        [Description("分支4")]
        Four = 1 << 4,
        /// <summary>
        /// 分支5
        /// </summary>
        [Description("分支5")]
        Five = 1 << 5,
        /// <summary>
        /// 分支6
        /// </summary>
        [Description("分支6")]
        Six = 1 << 6,
        /// <summary>
        /// 分支7
        /// </summary>
        [Description("分支7")]
        Seven = 1 << 7,
        /// <summary>
        /// 分支8
        /// </summary>
        [Description("分支8")]
        Eight = 1 << 8,
    }
}
