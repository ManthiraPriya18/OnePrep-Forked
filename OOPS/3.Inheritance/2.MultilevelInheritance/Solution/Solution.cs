using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._3.Inheritance.MultilevelInheritance.Solution
{
    /*
     * Here the Multilevel inheritance Employee -> Engineer -> BackendEngineer
     */
    class Employee
    {
        public void AttendMeeting() => Console.WriteLine("Employee: Attend general meetings");

        public virtual void DailyStandup() => Console.WriteLine("Employee: Attend daily standup");

        public virtual string Role() => "Employee";
    }

    class Engineer : Employee
    {
        public new void AttendMeeting() => Console.WriteLine("Engineer: Attend sprint meetings");

        public sealed override void DailyStandup() => Console.WriteLine("Engineer: Attends with scrum team");

        public override string Role() => "Engineer";
    }

    class BackendEngineer : Engineer
    {
        public new void AttendMeeting() => Console.WriteLine("BackendEngineer: Backend architecture sync");

        // ❌ Can't override sealed method:
        // public override void DailyStandup() { ... }

        public new string Role() => "Backend Engineer";
    }

}
