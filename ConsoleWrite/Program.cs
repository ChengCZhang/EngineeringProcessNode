using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TimeTest timeTest = new TimeTest();
            if (timeTest.EndTime.HasValue)
            {
                timeTest.StarTime = timeTest.EndTime.Value.AddDays(-5);
            }

        }
    }
    public class TimeTest
    {
        public DateTime? StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        //public static ProcessNode ReduceDaysbyPct(this ProcessNode node, uint days)
        //{
        //    if (node.PlannedCompletionTime.HasValue)
        //    {
        //        node.PlannedBeginTime = node.PlannedCompletionTime.Value.AddDays(-days);
        //    }
        //    return node;
        //}
        
    }
}
