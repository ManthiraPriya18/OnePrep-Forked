using DesignPatterns.Helpers.Common;
using DesignPatterns.Helpers.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.SimpleFactory
{
    public class ExecuteSimpleFactory : IExecute
    {
        public void Run()
        {
            Common.PrintProblemSeperator();
            RunProblem();
            Common.PrintProblemSeperator();
            Common.PrintSolutionSeperator();
            RunSolution();
            Common.PrintSolutionSeperator();
        }

        public void RunProblem()
        {
            var problem = new Problem();
            Employee employee = GetEmployee();
            problem.AddEmployeeBonusAndSalary(employee);
        }

        public void RunSolution()
        {
            var solution = new Solution();
            Employee employee = GetEmployee();
            solution.AddEmployeeBonusAndSalary(employee);
        }

        private Employee GetEmployee()
        {
            List<int> availableEmpType = new List<int> { 1, 2};
            Random random = new Random();

            int randomIndex = random.Next(availableEmpType.Count);

            int randomNumber = availableEmpType[randomIndex];
          
            return new Employee
            {
                EmployeeName = "Thiru",
                EmployeeId = 42069,
                EmployeeType = randomNumber
            };
        }
    }
}
