using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._4.Polymorphism.CompileTimePolymorphism.OperatorOverloading.Problem
{
    /*
     * We are having a class called vector2d, which will basically work with the coordinates, lets say if we want to 
     * add/multiply/subtract etc 2 coordinates, We have to create seperate functions, which will take the params and perform the operation.
     * Techically there is no problem here, However this will be simplified if we give a custom method for 'add'
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

        public Vector2D AddVectors(Vector2D v1)
        {
            return new Vector2D(v1.X + X, v1.Y + Y);
        }

    }
}
