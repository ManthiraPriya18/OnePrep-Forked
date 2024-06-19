using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public static class ExecuteSingleton
    {
        /* 
            Singleton:
                This defines the object creates and Instantiated only once. The same object will be use elsewhere.

                Assume that we have a class, that contains the hotel server's name in a list, we need to server on a rotational basis.
                If a object created it will start from first user again (Run the problem for better understanding)
                
         */


        public static void Run()
        {
            RunProblem();
            RunSolution();
        }

        private static void RunProblem()
        {
            PrintProblemSeperator();

            // Creating 2 new Objs, will create two new instance.
            Problem Table1 = new Problem();
            Problem Table2 = new Problem();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Current server for Table 1 is " + Table1.GetCurrentServerName());
                Console.WriteLine("Current server for Table 2 is " + Table2.GetCurrentServerName());
            }

            PrintProblemSeperator();
        }

        private static void RunSolution()
        {
            PrintSolutionSeperator();

            //Getting the same instance no matter how many times we requested.
            Solution Table1 = Solution.GetInstance();
            Solution Table2 = Solution.GetInstance();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Current server for Table 1 is " + Table1.GetCurrentServerName());
                Console.WriteLine("Current server for Table 2 is " + Table2.GetCurrentServerName());
            }
            PrintSolutionSeperator();
        }

        private static void PrintProblemSeperator()
        {
            Console.WriteLine();
            Console.WriteLine("************** PROBLEM *****************");
            Console.WriteLine();
        }

        private static void PrintSolutionSeperator()
        {
            Console.WriteLine();
            Console.WriteLine("############## SOLUTION #################");
            Console.WriteLine();
        }

    }
}
