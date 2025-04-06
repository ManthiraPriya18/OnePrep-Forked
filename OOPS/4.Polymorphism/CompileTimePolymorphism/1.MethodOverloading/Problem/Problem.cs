using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._4.Polymorphism.CompileTimePolymorphism.MethodOverloading.Problem
{
    /* 
     * The class ProblemCalculator will have different methods to perform different operations, However it will work, but our primary functionality
     * is addition,
     */
    public class Calculator
    {
        public int AddTwoIntegers(int a, int b)
        {
            return a + b;
        }

        public double AddTwoDoubles(double a, double b)
        {
            return a + b;
        }

        public int AddThreeIntegers(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
