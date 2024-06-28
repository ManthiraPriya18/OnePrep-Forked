// See https://aka.ms/new-console-template for more information
using DesignPatterns.Creational.SimpleFactory;
using DesignPatterns.Creational.Singleton;
using System.Diagnostics;

Console.WriteLine("Execution started");

try
{
   new ExecuteSimpleFactory().Run();
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