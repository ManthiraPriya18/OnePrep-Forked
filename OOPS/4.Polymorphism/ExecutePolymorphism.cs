using ObjectOrientedProgramming._4.Polymorphism.CompileTimePolymorphism;
using ObjectOrientedProgramming.Helpers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemVector = ObjectOrientedProgramming._4.Polymorphism.CompileTimePolymorphism.OperatorOverloading.Problem;
using SolutionVector = ObjectOrientedProgramming._4.Polymorphism.CompileTimePolymorphism.OperatorOverloading.Solution;
using ProblemCalculator = ObjectOrientedProgramming._4.Polymorphism.CompileTimePolymorphism.MethodOverloading.Problem;
using SolutionCalculator = ObjectOrientedProgramming._4.Polymorphism.CompileTimePolymorphism.MethodOverloading.Solution;
using ProblemShape = ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.MethodOverriding.Problem;
using SolutionShape = ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.MethodOverriding.Solution;
using ProblemAnimal = ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.Abstract.Problem;
using SolutionAnimal = ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.Abstract.Solution;
using ProblemPayment = ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.Interface.Problem;
using SolutionPayment = ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.Interface.Solution;
using ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.Interface.Solution;
namespace ObjectOrientedProgramming._4.Polymorphism
{
    public class ExecutePolymorphism
    {
        public void Run()
        {
            RunCompileTimePolymorphism();
            RunRunTimePolymorphism();
        }
   
        #region CompileTimePolymorphism
        public void RunCompileTimePolymorphism()
        {
            RunMethodOverloading_CTP();
            RunOperatorOverloading_CTP();
        }
        #region Method Overloading - CompileTimePolymorphism
        public void RunMethodOverloading_CTP()
        {
            Seperators.PrintProblemExecStartsSeperator();
            RunMethodOverloadingProblem();
            Seperators.PrintProblemExecEndsSeperator();

            Seperators.PrintSolutionExecStartsSeperator();
            RunMethodOverloadingSolution();
            Seperators.PrintSolutionExecEndsSeperator();
        }

        public void RunMethodOverloadingProblem()
        {
            ProblemCalculator.Calculator problemCalculator = new ProblemCalculator.Calculator();
            Console.WriteLine(problemCalculator.AddTwoIntegers(1, 2));
            Console.WriteLine(problemCalculator.AddTwoDoubles(1.1, 2.2));
            Console.WriteLine(problemCalculator.AddThreeIntegers(1, 2, 3));
        }
        public void RunMethodOverloadingSolution()
        {
            SolutionCalculator.Calculator solutionCalculator = new SolutionCalculator.Calculator();
            Console.WriteLine(solutionCalculator.Add(1, 2));
            Console.WriteLine(solutionCalculator.Add(1.1, 2.2));
            Console.WriteLine(solutionCalculator.Add(1, 2, 3));
        }
        #endregion

        #region Operator Overloading - CompileTimePolymorphism

        public void RunOperatorOverloading_CTP()
        {
            Seperators.PrintProblemExecStartsSeperator();
            RunOperatorOverloadingProblem();
            Seperators.PrintProblemExecEndsSeperator();
            Seperators.PrintSolutionExecStartsSeperator();
            RunOperatorOverloadingSolution();
            Seperators.PrintSolutionExecEndsSeperator();
        }

        public void RunOperatorOverloadingProblem() 
        {
            ProblemVector.Vector2D first = new ProblemVector.Vector2D(1, 2);
            ProblemVector.Vector2D second = new ProblemVector.Vector2D(2, 4);
            ProblemVector.Vector2D third = new ProblemVector.Vector2D(3, 8);

            ProblemVector.Vector2D vectorSum = first.AddVectors(second);
            vectorSum = vectorSum.AddVectors(third);
            Console.WriteLine($"Vector sum Coordinates : {vectorSum.X},{vectorSum.Y}");
        }
        public void RunOperatorOverloadingSolution()
        {
            SolutionVector.Vector2D first = new SolutionVector.Vector2D(1, 2);
            SolutionVector.Vector2D second = new SolutionVector.Vector2D(2, 4);
            SolutionVector.Vector2D third = new SolutionVector.Vector2D(3, 8);

            SolutionVector.Vector2D vectorSum = (first + second) + third;
            Console.WriteLine($"Vector sum Coordinates : {vectorSum.X},{vectorSum.Y}");
        }

        #endregion

        #endregion

        #region RunTimePolymorphism
        public void RunRunTimePolymorphism()
        {
            RunMethodOverriding_RTP();
            RunAbstractClassAndMethods_RTP();
            RunInterface_RTP();
        }

        #region Method Overriding - RunTimePolymorphism
        public void RunMethodOverriding_RTP()
        {
            Seperators.PrintProblemExecStartsSeperator();
            RunMethodOverridingProblem();
            Seperators.PrintProblemExecEndsSeperator();

            Seperators.PrintSolutionExecStartsSeperator();
            RunMethodOverridingSolution();
            Seperators.PrintSolutionExecEndsSeperator();
        }

        public void RunMethodOverridingProblem()
        {
            ProblemShape.Shape shape = new ProblemShape.Shape();
            ProblemShape.Shape circle = new ProblemShape.Circle(); // Treated as Shape
            
            Console.WriteLine(shape.Draw());  // Output: "Drawing a generic shape"
            Console.WriteLine(circle.Draw()); // Output: "Drawing a generic shape" (not a circle!)

            // Must explicitly call Draw, losing polymorphism
            Console.WriteLine(((ProblemShape.Circle)circle).Draw()); // Output: "Drawing a circle"
            Console.WriteLine(((ProblemShape.Circle)circle).radius); // Output: "12: Radius"
        }
        public void RunMethodOverridingSolution()
        {
            SolutionShape.Shape shape = new SolutionShape.Shape();
            SolutionShape.Shape circle = new SolutionShape.Circle(); // Still treated as Shape

            Console.WriteLine(shape.Draw());  // Output: "Drawing a generic shape"
            Console.WriteLine(circle.Draw()); // Output: "Drawing a circle" (polymorphism works!)
            
        }
        #endregion

        #region Abstract class/methods - RunTimePolymorphism
        public void RunAbstractClassAndMethods_RTP()
        {
            Seperators.PrintProblemExecStartsSeperator();
            RunAbstractClassAndMethodsProblem();
            Seperators.PrintProblemExecEndsSeperator();

            Seperators.PrintSolutionExecStartsSeperator();
            RunAbstractClassAndMethodsSolution();
            Seperators.PrintSolutionExecEndsSeperator();
        }

        public void RunAbstractClassAndMethodsProblem()
        {
            ProblemAnimal.Animal pet = new ProblemAnimal.Dog();
            pet.Speak(); // ⚠️ Output: "Some generic sound"

        }
        public void RunAbstractClassAndMethodsSolution()
        {
            SolutionAnimal.Animal pet = new SolutionAnimal.Dog();
            pet.Speak(); // ✅ Output: "Bark!"

        }
        #endregion

        #region Interface - RunTimePolymorphism
        public void RunInterface_RTP()
        {
            Seperators.PrintProblemExecStartsSeperator();
            RunInterfaceProblem();
            Seperators.PrintProblemExecEndsSeperator();

            Seperators.PrintSolutionExecStartsSeperator();
            RunInterfaceSolution();
            Seperators.PrintSolutionExecEndsSeperator();
        }

        public void RunInterfaceProblem()
        {
            ProblemPayment.CardPayment cardPayment = new ProblemPayment.CardPayment();

            ProblemPayment.UpiPayment upiPayment = new ProblemPayment.UpiPayment();

            ProblemPayment.ProccessPayments proccessPayments = new ProblemPayment.ProccessPayments();
            proccessPayments.ProcessCardPayment(cardPayment);
            proccessPayments.ProcessUpiPayment(upiPayment);
        }
        public void RunInterfaceSolution()
        {
            SolutionPayment.IPayment cardPayment = new SolutionPayment.CardPayment();
            SolutionPayment.IPayment upiPayment = new SolutionPayment.UpiPayment();

            SolutionPayment.ProccessPayments proccessPayments = new SolutionPayment.ProccessPayments();
            proccessPayments.ProcessPayment(cardPayment); // ✅ Decided at runtime: calls CardPayment's Pay()
            proccessPayments.ProcessPayment(upiPayment); // ✅ Decided at runtime: calls CardPayment's Pay()
        }
        #endregion
        #endregion
    }
}
