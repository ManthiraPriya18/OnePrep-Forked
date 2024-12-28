using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._4.InterfaceSegregationPrinciple.Problem
{

    /*
        Here the class Bird extends the interface ILivingOrganism, Where we are forced to implement all the methods that defined in interface.
        And we are having all the methods in a single interface.
        Bird actually cannot swim, This functionality is not require in Bird class, yet we forced Bird class to implement this by interface ILivingOrganism.
        Thus forcing the class to implement the methods that it doesnt require violates Interface Segregation principle.
     */
    public class Bird : ILivingOrganism
    {
        public void Fly()
        {
            Console.WriteLine("The Bird is Flying");
        }

        public void Swim()
        {
            // Bird class no need to implement this
            throw new NotImplementedException("Birds cannot swim");
        }

        public void Walk()
        {
            Console.WriteLine("The Bird is Walking");
        }
    }
    public class Fish : ILivingOrganism
    {
        public void Fly()
        {
            throw new NotImplementedException("Fish cannot fly");
        }

        public void Swim()
        {
            Console.WriteLine("The Fish is Swimming");
        }

        public void Walk()
        {
            throw new NotImplementedException("Fish cannot Walk");

        }
    }
}
