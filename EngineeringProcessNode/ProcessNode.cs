using System;
using System.Collections.Generic;

namespace EngineeringProcessNode
{
    /// <summary>
    /// 工程进度节点
    /// </summary>
    public class ProcessNode
    {
        #region 构造函数

        /// <summary>
        /// 默认初始化
        /// </summary>
        public ProcessNode()
        {

        }


        #endregion

        #region 属性

        /// <summary>
        /// 内部名称，节点的唯一标识
        /// </summary>
        /// <remarks>内部名称确认后不要随意修改</remarks>
        public Guid InternalName { get; set; }

        /// <summary>
        /// 是否启用节点
        /// </summary>
        public bool Enable { get; set; } = true;

        /// <summary>
        /// 节点基本状态 BS
        /// </summary>
        public ProcessNodeBaseState BaseState { get; set; } = ProcessNodeBaseState.Waiting;

        /// <summary>
        /// 节点进度状态 PS
        /// </summary>
        public ProcessNodeProgressState ProgressState { get; set; } = ProcessNodeProgressState.OnSchedule;

        /// <summary>
        /// 节点特殊状态码，非唯一 SS
        /// </summary>
        public ProcessNodeSpecialState SpecialState { get; set; } = ProcessNodeSpecialState.None;

        /// <summary>
        /// 节点约束条件码，非唯一 RT
        /// </summary>
        public ProcessNodeRestrictions Restrictions { get; set; } = ProcessNodeRestrictions.None;

        private DateTime? plannedBeginTime;
        /// <summary>
        /// 计划开始时间 PBT
        /// </summary>
        public DateTime? PlannedBeginTime
        {
            get => plannedBeginTime;
            set => plannedBeginTime = PlannedCompletionTime.HasValue && value.HasValue && (PlannedCompletionTime.Value - value.Value).TotalMilliseconds < 0
                    ? PlannedCompletionTime
                    : value;
        }

        private DateTime? actualBeginTime;
        /// <summary>
        /// 实际开始时间 ABT
        /// </summary>
        public DateTime? ActualBeginTime
        {
            get => actualBeginTime;
            set => actualBeginTime = ActualCompletionTime.HasValue && value.HasValue && (ActualCompletionTime.Value - value.Value).TotalMilliseconds < 0
                ? ActualCompletionTime
                : value;
        }

        private DateTime? plannedCompletionTime;
        /// <summary>
        /// 计划完成时间 PCT
        /// </summary>
        public DateTime? PlannedCompletionTime
        {
            get => plannedCompletionTime;
            set => plannedCompletionTime = PlannedBeginTime.HasValue && value.HasValue && (PlannedBeginTime.Value - value.Value).TotalMilliseconds > 0
            ? PlannedBeginTime
            : value;
        }

        private DateTime? actualCompletionTime;
        /// <summary>
        /// 实际完成时间 ACT
        /// </summary>
        public DateTime? ActualCompletionTime
        {
            get => actualCompletionTime;
            set => actualCompletionTime = ActualBeginTime.HasValue && value.HasValue && (ActualBeginTime.Value - value.Value).TotalMilliseconds > 0
                ? ActualBeginTime
                : value;
        }

        /// <summary>
        /// 计划时间间隔
        /// </summary>
        public TimeSpan? PlannedTimeInterval => PlannedBeginTime.HasValue && PlannedCompletionTime.HasValue ? (TimeSpan?)(PlannedCompletionTime.Value - PlannedBeginTime.Value) : null;

        /// <summary>
        /// 实际时间间隔
        /// </summary>
        public TimeSpan? ActualTimeInterval => ActualBeginTime.HasValue && ActualCompletionTime.HasValue ? (TimeSpan?)(ActualCompletionTime.Value - ActualBeginTime.Value) : null;

        /// <summary>
        /// 上级节点
        /// </summary>
        public Dictionary<ProcessNodeBranch, List<Guid>> PreviousNode { get; set; }

        /// <summary>
        /// 下级节点
        /// </summary>
        public Dictionary<ProcessNodeBranch, List<Guid>> NextNode { get; set; }

        #endregion
    }
}
