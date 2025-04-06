using ObjectOrientedProgramming._1.Abstraction.Abstract.Problem;
using ObjectOrientedProgramming._1.Abstraction.Abstract.Solution;
using ObjectOrientedProgramming.Helpers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemAbstract = ObjectOrientedProgramming._1.Abstraction.Abstract.Problem;
using SolutionAbstract = ObjectOrientedProgramming._1.Abstraction.Abstract.Solution;
using ProblemInterface = ObjectOrientedProgramming._1.Abstraction.Interface.Problem;
using SolutionInterface = ObjectOrientedProgramming._1.Abstraction.Interface.Solution;
namespace ObjectOrientedProgramming._1.Abstraction
{
    public class ExecuteAbstraction
    {
        public void Run()
        {
            ExecuteAbstract();
            ExecuteInterface();
        }

        #region Abstract Class & Method
        public void ExecuteAbstract()
        {
            Seperators.PrintProblemExecStartsSeperator();
            ExecuteAbstractProbelm();
            Seperators.PrintProblemExecEndsSeperator();

            Seperators.PrintSolutionExecStartsSeperator();
            ExecuteAbstractSolution();
            Seperators.PrintSolutionExecEndsSeperator();
        }

        public void ExecuteAbstractProbelm()
        {
            ProblemAbstract.Car car = new ProblemAbstract.Car();
            ProblemAbstract.Bike bike = new ProblemAbstract.Bike();
            ProblemAbstract.Mechanic mechanic = new ProblemAbstract.Mechanic();
            mechanic.StartCar(car);
            mechanic.StartBike(bike);
        }
        public void ExecuteAbstractSolution()
        {
            SolutionAbstract.Vehicle car = new SolutionAbstract.Car();
            SolutionAbstract.Vehicle bike = new SolutionAbstract.Bike();

            SolutionAbstract.Mechanic mechanic = new SolutionAbstract.Mechanic();

            mechanic.StartVehicle(car);
            mechanic.StartVehicle(bike);
        }

        #endregion

        #region Interface

        public void ExecuteInterface()
        {
            Seperators.PrintProblemExecStartsSeperator();
            ExecuteInterfaceProbelm();
            Seperators.PrintProblemExecEndsSeperator();

            Seperators.PrintSolutionExecStartsSeperator();
            ExecuteInterfaceSolution();
            Seperators.PrintSolutionExecEndsSeperator();
        }

        public void ExecuteInterfaceProbelm()
        {
            ProblemInterface.Car car = new ProblemInterface.Car();
            ProblemInterface.Bike bike = new ProblemInterface.Bike();
            ProblemInterface.Mechanic mechanic = new ProblemInterface.Mechanic();
            mechanic.StartCar(car);
            mechanic.StartBike(bike);
        }
        public void ExecuteInterfaceSolution()
        {
            SolutionInterface.IVehicle car = new SolutionInterface.Car();
            SolutionInterface.IVehicle bike = new SolutionInterface.Bike();

            SolutionInterface.Mechanic mechanic = new SolutionInterface.Mechanic();

            mechanic.StartVehicle(car);
            mechanic.StartVehicle(bike);
        }

        #endregion
    }
}
