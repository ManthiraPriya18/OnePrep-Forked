using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Helpers.Common
{
    public static class Seperators
    {
        public static void PrintProblemExecStartsSeperator()
        {
            Console.WriteLine();
            Console.WriteLine("************** PROBLEM EXECUTION STARTS *****************");
            Console.WriteLine();
        }
        public static void PrintProblemExecEndsSeperator()
        {
            Console.WriteLine();
            Console.WriteLine("************** PROBLEM EXECUTION ENDS   *****************");
            Console.WriteLine();
        }
        public static void PrintSolutionExecStartsSeperator()
        {
            Console.WriteLine();
            Console.WriteLine("############## SOLUTION EXECUTION STARTS #################");
            Console.WriteLine();
        }
        public static void PrintSolutionExecEndsSeperator()
        {
            Console.WriteLine();
            Console.WriteLine("############## SOLUTION EXECUTION ENDS   #################");
            Console.WriteLine();
        }
    }
}
