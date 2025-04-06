using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ObjectOrientedProgramming._3.Inheritance.SingleInheritance.Solution
{
    /*
     * If we just simply inherits the Animal class in Dog class, then we can access StartWalk & TotalAnimalPopulation without creating a object of Animal class
     */
    class Animal
    {
        public readonly int AnimalIntelligence;
        public readonly int AnimalCuteness;
        public int TotalAnimalPopulation = 10000;
        public Animal(int animalIntelligence, int animalCuteness)
        {
            AnimalIntelligence = animalIntelligence;
            AnimalCuteness = animalCuteness;
        }
        public void Eat() => Console.WriteLine("Eating...");
        public void StartWalk() => Console.WriteLine("Start Walking...");

        public virtual string FavFood()
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

    class Dog : Animal
    {
        public static new int AnimalCuteness = 8;
        public int animalIntelligence;


        public Dog(int animalIntelligence) : base(animalIntelligence, AnimalCuteness)
        {
            this.animalIntelligence = animalIntelligence;
        }

        public void Bark() => Console.WriteLine("Barking...");

        public override string FavFood()
        {
            return "Dog FavFood is Biscuits";
        }
        //If a Child overrdide a parent method, then from child we cant call the parent method even after casting
        //Hence we have to expose one more method in child, which will call the base method.
        public string BaseFavFood()
        {
            return base.FavFood();
        }
        public string AverageLifeSpan()
        {
            return "Avergae Life Span of Dog is 12 years";
        }

        // New keyword will hide the parent implementation but it wont override, hence by casting we can access parent method
        public new string AverageWeight()
        {
            return "Average Weight of Dog is 12Kg";
        }

        public string SpecificMethodInDog()
        {
            return "This Method only available in Dog";
        }
    }

}
