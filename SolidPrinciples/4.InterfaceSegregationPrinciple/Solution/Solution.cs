using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._4.InterfaceSegregationPrinciple.Solution
{

    /*
        Here we just segregated the interface, Thus the required class can extends to th interface only that is required.
        The Bird class can extends IBird (which extends IWalkingOrganism & IFlyingOrganism), 
        and the Fish class can extends IFish(which extends ISwimmingOrganism),
        Thus we are not forcing the class to implement all the methods that is not nesscary
     */
    public class Bird : IBird
    {
        public void Fly()
        {
            Console.WriteLine("The Bird is Flying");
        }

        public void Walk()
        {
            Console.WriteLine("The Bird is Walking");
        }
    }

    public class Fish : IFish
    {
        public void Swim()
        {
            Console.WriteLine("The Fish is Swimming");
        }
    }
}
