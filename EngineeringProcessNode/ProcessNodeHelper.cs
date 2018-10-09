using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProcessNode
{
    /// <summary>
    /// 进度节点拓展方法
    /// </summary>
    public static class ProcessNodeHelper
    {
        /// <summary>
        /// 固定计划开始时间，增加天数，修改计划结束时间
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="days">要增加的天数（正）</param>
        public static ProcessNode IncreaseDaysbyPBT(this ProcessNode node, uint days)
        {
            if (node.PlannedBeginTime.HasValue)
            {
                node.PlannedCompletionTime = node.PlannedBeginTime.Value.AddDays(days);
            }
            return node;
        }

        /// <summary>
        /// 固定计划开始时间，增加小时，修改计划结束时间
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="hours">要增加的小时数（正）</param>
        public static ProcessNode IncreaseHoursbyPBT(this ProcessNode node, uint hours)
        {
            if (node.PlannedBeginTime.HasValue)
            {
                node.PlannedCompletionTime = node.PlannedBeginTime.Value.AddHours(hours);
            }
            return node;
        }

        /// <summary>
        /// 固定计划结束时间，减少天数，修改计划开始时间
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="days">要减少的天数（正）</param>
        public static ProcessNode ReduceDaysbyPCT(this ProcessNode node, uint days)
        {
            if (node.PlannedCompletionTime.HasValue)
            {
                node.PlannedBeginTime = node.PlannedCompletionTime.Value.AddDays(-days);
            }
            return node;
        }

        /// <summary>
        /// 固定计划结束时间，减少小时，修改计划开始时间
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="hours">要减少的小时（正）</param>
        public static ProcessNode ReduceHoursbyPCT(this ProcessNode node, uint hours)
        {
            if (node.PlannedCompletionTime.HasValue)
            {
                node.PlannedBeginTime = node.PlannedCompletionTime.Value.AddHours(-hours);
            }
            return node;
        }
    }
}
