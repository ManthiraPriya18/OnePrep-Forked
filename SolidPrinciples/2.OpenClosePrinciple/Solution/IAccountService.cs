using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._2.OpenClosePrinciple.Solution
{
    public interface IAccountService
    {
        bool CheckIfUserValid(string userId);
    }
}
