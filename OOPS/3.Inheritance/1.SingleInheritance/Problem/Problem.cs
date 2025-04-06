using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._3.Inheritance.SingleInheritance.Problem
{
    /*
     * If we want to access TotalAnimalPopulation or StartWalk function in Dog class, we need to create an Animal object inside it to perform that
     * which is coupling the code too tightly. 
     */
    class Animal
    {
        public int TotalAnimalPopulation = 10000;
        public void Eat() => Console.WriteLine("Eating...");
        public void StartWalk() => Console.WriteLine("Start Walking...");
        public string FavFood()
        {
            return "Animal FavFood is Meat";
        }

        public string AverageLifeSpan()
        {
            return "Avergae Life Span of Animal is 30 years";
        }

        public string AverageWeight()
        {
            return "Average Weight of Animal is 40kg";
        }
    }

    class Dog
    {
        public void Bark() => Console.WriteLine("Barking...");

        public int GetTotalPopulation()
        {
            Animal animal = new Animal();
            return animal.TotalAnimalPopulation;
        }
        public string FavFood()
        {
            return "Dog FavFood is Biscuits";
        }
        public string AverageLifeSpan()
        {
            return "Avergae Life Span of Dog is 12 years";
        }
        public string AverageWeight()
        {
            return "Average Weight of Dog is 12Kg";
        }
    }

}