using SolidPrinciples._4.InterfaceSegregationPrinciple.Problem;
using SolidPrinciples._4.InterfaceSegregationPrinciple.Solution;
using SolidPrinciples.Helpers.Common;
using SolidPrinciples.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._4.InterfaceSegregationPrinciple
{
    public class ExecuteISP : IExecute
    {
        public void Run()
        {
            Seperators.PrintProblemExecStartsSeperator();
            RunProblem();
            Seperators.PrintProblemExecEndsSeperator();
            Seperators.PrintSolutionExecStartsSeperator();
            RunSolution();
            Seperators.PrintSolutionExecEndsSeperator();
        }

        public void RunProblem()
        {
            try
            {
                ILivingOrganism bird = new Problem.Bird();
                bird.Fly(); // This will work
                bird.Swim(); // This will throw error

               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
            try
            {
                ILivingOrganism fish = new Problem.Fish();
                fish.Swim(); // This will work
                fish.Walk(); // This will throw error
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void RunSolution()
        {
            IBird bird = new Solution.Bird();
            bird.Walk();
            bird.Fly();

            IFish fish = new Solution.Fish();
            fish.Swim();
        }
    }
}
