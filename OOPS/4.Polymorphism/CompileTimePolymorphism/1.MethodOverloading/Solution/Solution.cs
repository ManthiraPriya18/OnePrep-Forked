using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._4.Polymorphism.CompileTimePolymorphism.MethodOverloading.Solution
{
    /* SOLUTION
     * We can use method overloading here, let the caller can decide which method to b call by the parameter.
     * Method overloading : The method name is same, But Parameters are different type or no of parameter can be different
     */
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
