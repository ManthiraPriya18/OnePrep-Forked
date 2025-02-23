using ObjectOrientedProgramming._2.Encapsulation.Problem;
using ObjectOrientedProgramming._2.Encapsulation.Solution;
using ObjectOrientedProgramming.Helpers.Common;
using ObjectOrientedProgramming.Interface.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._2.Encapsulation
{
    public class ExecuteEncapsulation : IExecute
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
            Problem.GooglePay googlePay = new Problem.GooglePay();
            int userId = 1;
            int pin = 1234;
            googlePay.ConsoleBalanceByUserId(userId,pin);

            Problem.PhonePe phonePe = new Problem.PhonePe();
            phonePe.ConsoleBalanceByUserId(userId, pin);

        }

        public void RunSolution()
        {
            Solution.GooglePay googlePay = new Solution.GooglePay();
            int userId = 1;
            int pin = 1234;
            googlePay.ConsoleBalanceByUserId(userId, pin);

            Solution.PhonePe phonePe = new Solution.PhonePe();
            phonePe.ConsoleBalanceByUserId(userId, pin);
        }
    }
}
