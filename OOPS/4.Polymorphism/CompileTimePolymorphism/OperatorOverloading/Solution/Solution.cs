using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._4.Polymorphism.CompileTimePolymorphism.OperatorOverloading.Solution
{
    /*
     * Here we overload the + operator with our custom implementation, hence whenever if we call + with this class objects, This custom logic will be Executed
     */
    public class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Overloading the + operator
        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
