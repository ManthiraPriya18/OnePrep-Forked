// See https://aka.ms/new-console-template for more information
using DesignPatterns.Creational.Singleton;
using System.Diagnostics;

Console.WriteLine("Execution started");

try
{
    ExecuteSingleton.Run();
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
    Debugger.Break();
}
finally
{
    Console.WriteLine("Execution Ended");
    Console.ReadKey();
}