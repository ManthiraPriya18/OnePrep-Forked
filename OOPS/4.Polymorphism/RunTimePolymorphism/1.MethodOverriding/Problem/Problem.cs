using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.MethodOverriding.Problem
{
    /*
     * Issue: circle.Draw() uses the base Shape version because there’s no overriding. 
     * You need type casting and a separate method (DrawCircle), which is clunky and breaks uniform treatment.
     */
    public class Shape
    {
        public string Draw() // No virtual keyword, no overriding possible
        {
            return "Drawing a generic shape";
        }
    }

    public class Circle : Shape
    {
        public int radius = 12;
        // Can't override Draw(), so we make a new method with same name
        public  string Draw()
        {
            return "Drawing a circle";
        }
    }
}
