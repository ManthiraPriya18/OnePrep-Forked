using SolidPrinciples._1.SingleResponsibilityPrinciple;
using SolidPrinciples._2.OpenClosePrinciple;
using SolidPrinciples._3.LiskovSubsitutionPrinciple;
using SolidPrinciples._4.InterfaceSegregationPrinciple;
using SolidPrinciples._5.DependencyInversionPrinciple;
using System.Diagnostics;

Console.WriteLine("Execution started");

try
{
    //new ExecuteSRP().Run();
    //new ExecuteOCP().Run();
    new ExecuteLSP().Run();
    //new ExecuteISP().Run();
    //new ExecuteDSP().Run();
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