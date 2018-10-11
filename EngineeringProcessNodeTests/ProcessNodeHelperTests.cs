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

        [TestMethod()]
        public void IncreaseHoursbyPbtTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void ReduceDaysbyPctTest()
        {
            var node = new ProcessNode();
            Assert.Fail();
        }

        [TestMethod()]
        public void ReduceHoursbyPctTest()
        {
            var node = new ProcessNode();
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