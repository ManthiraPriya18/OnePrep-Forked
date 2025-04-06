using ObjectOrientedProgramming._1.Abstraction;
using ObjectOrientedProgramming._2.Encapsulation;
using ObjectOrientedProgramming._4.Polymorphism;
using System.Diagnostics;

Console.WriteLine("Execution started");

try
{
    //new ExecuteEncapsulation().Run();
    //new ExecutePolymorphism().Run();
    new ExecuteAbstraction().Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    Debugger.Break();
}
finally
{
    Console.WriteLine("Execution Ended");
    Console.ReadKey();
}