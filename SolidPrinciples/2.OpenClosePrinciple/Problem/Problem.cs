using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._2.OpenClosePrinciple.Problem
{
    /*
        In AppUsersService, we have a method called CheckIfUserValid, This method is responsible to validate user across different role.
        Assume that we done with our Implementation with two roles (Admin & User). Now in future we need to introdcue one more role.
        Now we have to modify the existing function, which violates the rule - Open Close Principle
        This class is Open for modification (Like fixing bugs), and its Open for modification (It should close for modification)
        Modification here means additional logic in the existing function
     */
    public class AppUsersService
    {
        public bool CheckIfUserValid(string userId)
        {
            if (userId.StartsWith("Adm-"))
            {
                // Assume we have Implementation to check in Admin Details Table
                return true;
            }
            else if (userId.StartsWith("User-"))
            {
                // Assume we have Implementation to check in User Details Table
                return true;
            }

            return false;
        }
    }
}
