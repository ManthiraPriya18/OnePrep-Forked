using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._1.Abstraction.Interface.Solution
{
    /*
     * Here since we have a common interface vehicle, which will be extends by both Car & Bike, And in Mechanic we can simply pass the IVehicle as params.
     * Thus we are hiding the implementation details of Car & Bike, but expose those object details via an interface thus acheived abstarction here
     */
    public interface IVehicle
    {
        void StartEngine();
    }

    class Car : IVehicle
    {
        public void StartEngine() => Console.WriteLine("Car engine started");
    }

    class Bike : IVehicle
    {
        public void StartEngine() => Console.WriteLine("Bike engine started");
    }

    class Mechanic
    {
        public void StartVehicle(IVehicle vehicle)
        {
            vehicle.StartEngine(); // Works for any IVehicle
        }
    }

}
