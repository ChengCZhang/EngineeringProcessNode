using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineeringProcessNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProcessNode.Tests
{
    [TestClass()]
    public class ProcessNodeHelperTests
    {
        /// <summary>
        /// 固定计划开始时间，增加天数
        /// </summary>
        [TestMethod()]
        public void IncreaseDaysbyPbtTest()
        {
            var node = new ProcessNode();

            Assert.IsTrue(node.IncreaseDaysbyPbt(0).PlannedCompletionTime == node.PlannedBeginTime);
            node.PlannedBeginTime = DateTime.Now;

            Assert.IsTrue(node.IncreaseDaysbyPbt(0).PlannedCompletionTime == node.PlannedBeginTime);

            Assert.IsTrue(node.IncreaseDaysbyPbt(1).PlannedCompletionTime == node.PlannedBeginTime.Value.AddDays(1));
            node.PlannedBeginTime = null;

            Assert.IsTrue(node.IncreaseDaysbyPbt(1).PlannedCompletionTime == node.PlannedCompletionTime);
        }
        
        /// <summary>
        /// 固定计划开始时间，增加小时
        /// </summary>
        [TestMethod()]
        public void IncreaseHoursbyPbtTest()
        {
            var node = new ProcessNode();
            Assert.IsTrue(node.IncreaseHoursbyPbt(0).PlannedCompletionTime == node.PlannedBeginTime);
            node.PlannedBeginTime = DateTime.Now;

            Assert.IsTrue(node.IncreaseHoursbyPbt(0).PlannedCompletionTime == node.PlannedBeginTime);

            Assert.IsTrue(node.IncreaseHoursbyPbt(1).PlannedCompletionTime == node.PlannedBeginTime.Value.AddHours(1));
            node.PlannedBeginTime = null;

            Assert.IsTrue(node.IncreaseHoursbyPbt(1).PlannedCompletionTime == node.PlannedCompletionTime);
        }
        /// <summary>
        /// 固定计划结束时间，减少时间
        /// </summary>
        [TestMethod()]
        public void ReduceDaysbyPctTest()
        {
            var node = new ProcessNode();
            Assert.IsTrue(node.ReduceDaysbyPct(0).PlannedBeginTime == node.PlannedCompletionTime);
            //node.PlannedCompletionTime = DateTime.Now;
            //
            //Assert.IsTrue(node.ReduceDaysbyPct(0).PlannedBeginTime == node.PlannedCompletionTime);

            Assert.IsTrue(node.ReduceDaysbyPct(1).PlannedBeginTime == node.PlannedCompletionTime.Value.AddDays(1));
            node.PlannedBeginTime = null;

            Assert.IsTrue(node.ReduceDaysbyPct(1).PlannedBeginTime == node.PlannedCompletionTime);
        }
        /// <summary>
        /// 固定计划结束时间，减少小时,修改计划开始时间
        /// </summary>
        [TestMethod()]
        public void ReduceHoursbyPctTest()
        {
            var node = new ProcessNode();
            Assert.IsTrue(node.ReduceHoursbyPct(-2).PlannedBeginTime == node.PlannedCompletionTime);
            node.PlannedBeginTime = DateTime.Now;
            
            Assert.IsTrue(node.ReduceHoursbyPct(0).PlannedCompletionTime == node.PlannedCompletionTime);
            
            Assert.IsTrue(node.ReduceHoursbyPct(1).PlannedCompletionTime == node.PlannedCompletionTime.Value.AddHours(1));
            node.PlannedBeginTime = null;
            
            Assert.IsTrue(node.ReduceHoursbyPct(1).PlannedBeginTime == node.PlannedBeginTime);
            Assert.Fail();
        }

        [TestMethod()]
        public void SetStatusTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void AddStatusTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
            
        }

        [TestMethod()]
        public void AddStatusTest1()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void AddBranchPreTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void AddBranchNexTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteStatusTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteStatusTest1()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteBranchPreTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteBranchNexTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void HasStatusTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void HasStatusTest1()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void HasStatusTest2()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void HasBranchPreTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void HasBranchNexTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }
    }
}