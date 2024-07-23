
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class Problem
    {
        /*
         * Simple Factory pattern solve the problem of creational of an Object, The code is tightly coupled with the creational of the object type.
         * Which to high maintainable code and it violated Open/Closed principle
         * 
         */

        public void AddEmployeeBonusAndSalary(Employee emp)
        {
            EmployeeDbModel empDbModel = new EmployeeDbModel
            {
                EmployeeId = emp.EmployeeId,
                EmployeeName = emp.EmployeeName,
                EmployeeType = emp.EmployeeType,
                LastOnline = DateTime.Now,
            };

            // Bonus and salary differ from Permanent employess and Contractor employees. Hence based on Emp Type we can define that

            /* Here the Salary/Bonus logic is tightly coupled here, and In future if we introduce a new employee called 'Temp Employee'
             * Then we need to modify here, Which leads to high maintainable code and it violated Open/Closed principle
             * 
             */
            if (empDbModel.EmployeeId == 1)
            {
                //Permanent Employee
                empDbModel.Salary = 10000;
                empDbModel.BonusInPercentage = 10;
            }
            else if (empDbModel.EmployeeType == 2)
            {
                // Contractor employee
                empDbModel.Salary = 8000;
                empDbModel.BonusInPercentage = 8;
            }

            InsertEmployeeInDB(empDbModel);
        }

        private void InsertEmployeeInDB(EmployeeDbModel emp)
        {
            Console.WriteLine("Inserting Employee in DB started....");
            Console.WriteLine($"Inserted for  {emp.EmployeeName}");
            Console.WriteLine("Inserting Employee in DB Completed....");
        }
    }

    public class EmployeeDbModel : Employee
    {
        public DateTime LastOnline { get; set; }
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int EmployeeType { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public int Salary { get; set; }
        public int BonusInPercentage { get; set; }

        public int MedicalAllowance { get; set; }
        public int HomeAllowance { get; set; }
    }


}
