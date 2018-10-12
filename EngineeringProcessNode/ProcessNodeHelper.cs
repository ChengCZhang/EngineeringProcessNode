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
        public static ProcessNode IncreaseDaysbyPbt(this ProcessNode node, int days)
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
        public static ProcessNode IncreaseHoursbyPbt(this ProcessNode node, int hours)
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
        /// <param name="days">要减少的天数</param>
        public static ProcessNode ReduceDaysbyPct(this ProcessNode node, int days)
        {
           // if (days>0)
           // {
           //     Math.Abs(days);
           // }
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
        /// <param name="hours">要减少的小时</param>
        public static ProcessNode ReduceHoursbyPct(this ProcessNode node, int hours)
        {
            if (node.PlannedCompletionTime.HasValue)
            {
                node.PlannedBeginTime = node.PlannedCompletionTime.Value.AddHours(hours);
            }
            return node;
        }


        #endregion

        #region 位运算相关

        /// <summary>
        /// 设置基本状态 BS
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要设置的基本状态</param>
        /// <remarks>基本状态低8位状态和高8位状态分别是唯一的</remarks>
        /// <returns>返回自身</returns>
        public static ProcessNode SetStatus(this ProcessNode node, ProcessNodeBaseStatus status)
        {
            //todo 
            //没有做bitcount：
            if (((uint)status & 0xff) != 0)
            {
                //低位
                node.BaseStatus &= (ProcessNodeBaseStatus)0xff00 & status;
            }

            if ((uint)status >> 8 != 0)
            {
                //高位
                node.BaseStatus &= (ProcessNodeBaseStatus)0x00ff & status;
            }
            return node;
        }

        #region 添加

        /// <summary>
        /// 增加特殊状态 SS
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要增加的特殊状态</param>
        /// <returns>返回自身</returns>
        public static ProcessNode AddStatus(this ProcessNode node, ProcessNodeSpecialStatus status)
        {
            node.SpecialStatus |= status;
            return node;
        }

        /// <summary>
        /// 增加约束条件 ST
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要增加的约束条件</param>
        /// <returns>返回自身</returns>
        public static ProcessNode AddStatus(this ProcessNode node, ProcessNodeRestrictions status)
        {
            node.Restrictions |= status;
            return node;
        }

        /// <summary>
        /// 增加上级分支
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要增加的上级分支</param>
        /// <returns>返回自身</returns>
        public static ProcessNode AddBranchPre(this ProcessNode node, ProcessNodeBranch status)
        {
            node.PreviousBranch |= status;
            return node;
        }

        /// <summary>
        /// 增加下级分支
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要增加的下级分支</param>
        /// <returns>返回自身</returns>
        public static ProcessNode AddBranchNex(this ProcessNode node, ProcessNodeBranch status)
        {
            node.NextBranch |= status;
            return node;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除特殊状态 SS
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要删除的特殊状态</param>
        /// <returns>返回自身</returns>
        public static ProcessNode DeleteStatus(this ProcessNode node, ProcessNodeSpecialStatus status)
        {
            node.SpecialStatus &= ~status;
            return node;
        }

        /// <summary>
        /// 删除约束条件 ST
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要删除的约束条件</param>
        /// <returns>返回自身</returns>
        public static ProcessNode DeleteStatus(this ProcessNode node, ProcessNodeRestrictions status)
        {
            node.Restrictions &= ~status;
            return node;
        }

        /// <summary>
        /// 删除上级分支
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要删除的上级分支</param>
        /// <returns>返回自身</returns>
        public static ProcessNode DeleteBranchPre(this ProcessNode node, ProcessNodeBranch status)
        {
            node.PreviousBranch &= ~status;
            return node;
        }

        /// <summary>
        /// 删除下级分支
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要删除的特殊状态</param>
        /// <returns>返回自身</returns>
        public static ProcessNode DeleteBranchNex(this ProcessNode node, ProcessNodeBranch status)
        {
            node.NextBranch &= ~status;
            return node;
        }

        #endregion


        #region 查询

        /// <summary>
        /// 是否存在特殊状态 SS
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要判断是否存在的状态</param>
        /// <returns>指示是否存在</returns>
        public static bool HasStatus(this ProcessNode node, ProcessNodeSpecialStatus status) => (node.SpecialStatus & status) == status;

        /// <summary>
        /// 是否存在约束条件 ST
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要判断是否存在的状态</param>
        /// <returns>指示是否存在</returns>
        public static bool HasStatus(this ProcessNode node, ProcessNodeRestrictions status) => (node.Restrictions & status) == status;

        /// <summary>
        /// 是否存在基本状态 BS
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要判断是否存在的基本状态</param>
        /// <returns>指示是否存在</returns>
        public static bool HasStatus(this ProcessNode node, ProcessNodeBaseStatus status) => (node.BaseStatus & status) == status;

        /// <summary>
        /// 是否存在上级分支 
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要判断是否存在的分支</param>
        /// <returns>指示是否存在</returns>
        public static bool HasBranchPre(this ProcessNode node, ProcessNodeBranch status) => (node.PreviousBranch & status) == status;

        /// <summary>
        /// 是否存在下级分支 
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="status">要判断是否存在的分支</param>
        /// <returns>指示是否存在</returns>
        public static bool HasBranchNex(this ProcessNode node, ProcessNodeBranch status) => (node.NextBranch & status) == status;

        #endregion

        #endregion


    }
}
