using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._2.OpenClosePrinciple.Solution
{
    /*
        Here we created an Interface which will have CheckIfUserValid method, and we create seperate class for User, Admin where each will contain 
        its own logic to validate, In future if we want to add one more role called SuperAdmin, we can simply inherit the interface and will have its
        own implementation.

        Hence this class is open for extension but closed for modification
     */
    public class UserService : IAccountService
    {
        public bool CheckIfUserValid(string userId)
        {
            // Assume we have Implementation to check in User Details Table
            return true;
        }
    }
    public class AdminService : IAccountService
    {
        public bool CheckIfUserValid(string userId)
        {
            // Assume we have Implementation to check in Admin Details Table
            return true;
        }
    }
    public class SuperAdminService : IAccountService
    {
        public bool CheckIfUserValid(string userId)
        {
            // Assume we have Implementation to check in Super Details Table
            return true;
        }
    }

}
