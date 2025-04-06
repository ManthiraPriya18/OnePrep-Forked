using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.Abstract.Solution
{
    public abstract class Animal
    {
        public abstract void Speak(); // No body
    }

    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Bark!");
        }
    }

}
