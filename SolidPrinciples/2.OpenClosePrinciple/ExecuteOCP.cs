using SolidPrinciples.Helpers.Common;
using SolidPrinciples.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._2.OpenClosePrinciple
{
    public class ExecuteOCP : IExecute
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
            throw new NotImplementedException();
        }

        public void RunSolution()
        {
            throw new NotImplementedException();
        }
    }
}
