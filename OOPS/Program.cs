using ObjectOrientedProgramming._2.Encapsulation;
using System.Diagnostics;

Console.WriteLine("Execution started");

try
{
    new ExecuteEncapsulation().Run();
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