using SolidPrinciples._1.SingleResponsibilityPrinciple.Problem;
using SolidPrinciples.Helpers.Common;
using SolidPrinciples.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._1.SingleResponsibilityPrinciple
{
    /*
        Single Responsibility Principle:
            - A Class can contain many methods/functions as long as they are serving for a single functionality.
     */
    public class ExecuteSRP : IExecute
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
            new UserLoginService().LoginUser("test@gmail.com");
        }

        public void RunSolution()
        {
            new LoginService().LoginUser("test@gmail.com");
        }
    }
}
