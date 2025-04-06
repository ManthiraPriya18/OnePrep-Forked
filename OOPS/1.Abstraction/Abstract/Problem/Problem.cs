using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._1.Abstraction.Abstract.Problem
{
    /*
    * Here we are having two classes - Car & Bike, The functionality is basically same which is starting the Engine, But in the Mechanic class
    * we ended up with multiple method which will actually for the different classes, There is two ways to solve
    * One is using Interface & another one is Abstraction - Same problem is used in AnstarctProblem & InterfaceProblem
    */
    class Car
    {
        public void StartEngine() => Console.WriteLine("Car engine started");
    }

    class Bike
    {
        public void StartEngine() => Console.WriteLine("Bike engine started");
    }

    class Mechanic
    {
        public void StartCar(Car car)
        {
            car.StartEngine(); // Car engine started
        }
        public void StartBike(Bike bike)
        {
            bike.StartEngine(); // Bike engine started
        }
    }

}
