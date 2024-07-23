using DesignPatterns.Creational.SimpleFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class Solution
    {
        public void AddEmployeeBonusAndSalary(Employee emp)
        {
            EmployeeDbModel empDbModel = new EmployeeDbModel
            {
                EmployeeId = emp.EmployeeId,
                EmployeeName = emp.EmployeeName,
                EmployeeType = emp.EmployeeType,
                LastOnline = DateTime.Now,
            };
            EmployeeManagerfactory empFactory = new EmployeeManagerfactory();
            BaseEmployeeFactory baseEmpFactory= empFactory.CreateFactory(empDbModel);
            baseEmpFactory.ApplySalary();
            InsertEmployeeInDB(empDbModel);
        }

        private void InsertEmployeeInDB(EmployeeDbModel emp)
        {
            Console.WriteLine("Inserting Employee in DB started....");
            Console.WriteLine($"Inserted for  {emp.EmployeeName}");
            Console.WriteLine("Inserting Employee in DB Completed....");
        }
    }

    public class EmployeeManagerfactory
    {
        public BaseEmployeeFactory CreateFactory(EmployeeDbModel emp)
        {
            if (emp.EmployeeType == 1)
            {
                return new PermanentEmployeeFactory(emp);
            }
            if (emp.EmployeeType == 1)
            {
                return new ContractEmployeeFactory(emp);
            }
            throw new InvalidOperationException();
        }
    }

    public abstract class BaseEmployeeFactory
    {
        protected EmployeeDbModel _emp;
        public BaseEmployeeFactory(EmployeeDbModel employeeDbModel)
        {
            _emp = employeeDbModel;
        }
        public abstract IEmployee Create();

        public Employee ApplySalary()
        {
            IEmployee employee = this.Create();
            _emp.Salary = employee.GetSalary() ;
            _emp.BonusInPercentage = employee.GetBonus();
            return _emp;
        }
    }


    public class PermanentEmployeeFactory : BaseEmployeeFactory
    {
        public PermanentEmployeeFactory(EmployeeDbModel employeeDbModel) : base(employeeDbModel)
        {
        }

        public override IEmployee Create()
        {
            PermanentEmployee permanentEmployee = new PermanentEmployee();
            _emp.HomeAllowance = permanentEmployee.GetHomeAllowance();
            return permanentEmployee;
        }
    }

    public class ContractEmployeeFactory : BaseEmployeeFactory
    {
        public ContractEmployeeFactory(EmployeeDbModel employeeDbModel) : base(employeeDbModel)
        {
        }

        public override IEmployee Create()
        {
            ContractorEmployee contractorEmployee = new ContractorEmployee();
            _emp.MedicalAllowance = contractorEmployee.GetMedicalAllowance();
            return contractorEmployee;
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

        public int GetHomeAllowance()
        {
            return 250;
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

        public int GetMedicalAllowance()
        {
            return 100;
        }
    }
}
