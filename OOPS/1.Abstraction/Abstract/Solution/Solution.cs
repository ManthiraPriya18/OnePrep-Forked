using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._1.Abstraction.Abstract.Solution
{
    /*
     * Here we created an Abstrct class & declared an abstract method and Car & Bike will be extend this abstarct class and forced to implement the abstarct method
     * 'StartEngine'. Hence in mechanic class, we just need to pass the Vehicle class, since car & bike having its own implementation, at runtime it will be called.
     * 
     */
    abstract class Vehicle
    {
        public abstract void StartEngine();
    }

    class Car : Vehicle
    {
        public override void StartEngine() => Console.WriteLine("Car engine started");
    }

    class Bike : Vehicle
    {
        public override void StartEngine() => Console.WriteLine("Bike engine started");
    }

    class Mechanic
    {
        public void StartVehicle(Vehicle vehicle)
        {
            vehicle.StartEngine(); // Abstracted call
        }
    }

}
