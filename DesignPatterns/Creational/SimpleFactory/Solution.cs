using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.SimpleFactory
{
    public class Solution
    {
        /*
            In Factory patterns we create the object of the Class without Exposing the Creation/Instantiation Logic to the User 
            who wants to create the Object and then return the newly Created object using the Common Interface which is inherited  by the Class”. 
            
            Thus the creation of the object will be taken care by the factory, Hence the conditional code is not tightly coupled in the Business logic layer.
            And there will be no change in the future in Business layer, when we introduce a new type of employee, A similar obj for TempEmployee will be created 
            in the factory.
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

            IEmployee empObj = new EmployeeFactory().GetEmployee(emp.EmployeeType);
            empDbModel.Salary = empObj.GetSalary();
            empDbModel.BonusInPercentage = empObj.GetBonus();

            InsertEmployeeInDB(empDbModel);
        }

        private void InsertEmployeeInDB(EmployeeDbModel emp)
        {
            Console.WriteLine("Inserting Employee in DB started....");
            Console.WriteLine($"Inserted for  {emp.EmployeeName}");
            Console.WriteLine("Inserting Employee in DB Completed....");
        }
    }

    public class EmployeeFactory
    {
        public IEmployee GetEmployee(int EmpType)
        {
            if (EmpType == 1)
            {
                return new PermanentEmployee();
            }
            if(EmpType == 2)
            {
                return new ContractorEmployee();
            }

            throw new InvalidOperationException();
        }
    }

    public interface IEmployee 
    {
        int GetSalary();
        int GetBonus();
    }

    public class PermanentEmployee : IEmployee
    {
        public int GetBonus()
        {
            return 10;
        }

        public int GetSalary()
        {
            return 10000;
        }
    }
    public class ContractorEmployee : IEmployee
    {
        public int GetBonus()
        {
            return 8;
        }

        public int GetSalary()
        {
            return 8000;
        }
    }
}
