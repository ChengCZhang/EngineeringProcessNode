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
        #region 计划时间修改

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


        #endregion

        #region 状态增加、删除、判断是否存在

        /// <summary>
        /// 增加特殊状态 SS
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="state">要增加的特殊状态</param>
        /// <returns>返回自身</returns>
        public static ProcessNode AddState(this ProcessNode node, ProcessNodeSpecialState state)
        {
            node.SpecialState |= state;
            return node;
        }

        /// <summary>
        /// 增加约束条件 ST
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="state">要增加的约束条件</param>
        /// <returns>返回自身</returns>
        public static ProcessNode AddState(this ProcessNode node, ProcessNodeRestrictions state)
        {
            node.Restrictions |= state;
            return node;
        }

        /// <summary>
        /// 删除特殊状态 SS
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="state">要删除的特殊状态</param>
        /// <returns>返回自身</returns>
        public static ProcessNode DeleteState(this ProcessNode node, ProcessNodeSpecialState state)
        {
            node.SpecialState &= ~state;
            return node;
        }

        /// <summary>
        /// 删除约束条件 ST
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="state">要删除的约束条件</param>
        /// <returns>返回自身</returns>
        public static ProcessNode DeleteState(this ProcessNode node, ProcessNodeRestrictions state)
        {
            node.Restrictions &= ~state;
            return node;
        }

        /// <summary>
        /// 是否存在特殊状态 SS
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="state">要判断是否存在的状态</param>
        /// <returns>指示是否存在</returns>
        public static bool HasState(this ProcessNode node, ProcessNodeSpecialState state) => (node.SpecialState & state) == state;

        /// <summary>
        /// 是否存在约束条件 ST
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="state">要判断是否存在的状态</param>
        /// <returns>指示是否存在</returns>
        public static bool HasState(this ProcessNode node, ProcessNodeRestrictions state) => (node.Restrictions & state) == state;

        #endregion


    }
}
