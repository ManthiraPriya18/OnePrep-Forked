using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.Abstract.Problem
{
    public class Animal
    {
        public void Speak()
        {
            Console.WriteLine("Some generic sound");
        }
    }

    public class Dog : Animal
    {
        public void Speak()
        {
            Console.WriteLine("Bark!");
        }
    }

}
