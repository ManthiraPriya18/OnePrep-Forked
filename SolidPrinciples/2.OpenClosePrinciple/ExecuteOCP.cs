using SolidPrinciples._2.OpenClosePrinciple.Problem;
using SolidPrinciples._2.OpenClosePrinciple.Solution;
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
            bool isValid = new AppUsersService().CheckIfUserValid("Adm-12TY");
            Console.WriteLine($"This userId is {(isValid? "" : "not" )} a valid one!");
        }

        public void RunSolution()
        {
            string userId = "Adm-12YT";
            IAccountService accountService = GetAccountService(userId);
            bool isValid = accountService.CheckIfUserValid(userId);
            Console.WriteLine($"This userId is {(isValid ? "" : "not")} a valid one!");

        }

        //Incase of new role like superAdmin, we will add the new entry here
        // And we are extending behavior through data, not code. hence its not violating the Open close principle
        private static readonly Dictionary<string, Func<IAccountService>> ServiceMap = new()
        {
            { "Adm-", () => new AdminService() },
            { "User-", () => new UserService() }
        };
        public static IAccountService GetAccountService(string userId)
        {
            
            var prefix = ServiceMap.Keys.FirstOrDefault(key => userId.StartsWith(key));
            if (prefix != null)
            {
                return ServiceMap[prefix]();
            }

            throw new ArgumentException("Invalid user ID format");
        }
    }
}
