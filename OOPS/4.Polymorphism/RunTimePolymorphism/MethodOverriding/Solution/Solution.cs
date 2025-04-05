using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.MethodOverriding.Solution
{
    /*
     * Fix: virtual in Shape and override in Circle let the runtime call the correct Draw() based on the object’s actual type, not its reference type.
        Problem Solved: No need for type casting or extra methods—code is cleaner, and Shape references can dynamically adapt to any derived type’s behavior.
     */
    public class Shape
    {
        public virtual string Draw() // Virtual allows overriding
        {
            return "Drawing a generic shape";
        }
    }

    public class Circle : Shape
    {
        public override string Draw() // Override customizes behavior
        {
            return "Drawing a circle";
        }
    }
}
