using SolidPrinciples._1.SingleResponsibilityPrinciple;
using System.Diagnostics;

Console.WriteLine("Execution started");

try
{
    new ExecuteSRP().Run();
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