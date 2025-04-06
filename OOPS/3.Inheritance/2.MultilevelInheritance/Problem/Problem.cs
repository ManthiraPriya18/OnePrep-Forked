using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._3.Inheritance.MultilevelInheritance.Problem
{
    /*
     * Duplicate code for standup logic,No hierarchy for future changes, No code reuse
     * Every class re-implements common behavior — duplication grows, maintainability dies, and consistency is lost.
     * What of we have some more class called FrontEndEngineer
     */
    class Employee
    {
        public void AttendMeeting() => Console.WriteLine("General meeting...");
        public void DailyStandup() => Console.WriteLine("Employee standup...");
        public string Role() => "Employee";
    }

    class BackendEngineer
    {
        public void AttendMeeting() => Console.WriteLine("Backend sync...");
        public void DailyStandup() => Console.WriteLine("Engineer standup...");
        public string Role() => "Backend Engineer";
    }

}
