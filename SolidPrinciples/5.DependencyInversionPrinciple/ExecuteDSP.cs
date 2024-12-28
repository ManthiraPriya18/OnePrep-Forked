using Microsoft.Extensions.DependencyInjection;
using SolidPrinciples._5.DependencyInversionPrinciple.Problem;
using SolidPrinciples._5.DependencyInversionPrinciple.Solution;
using SolidPrinciples.Helpers.Common;
using SolidPrinciples.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._5.DependencyInversionPrinciple
{
    public class ExecuteDSP : IExecute
    {
        public void Run()
        {
            Seperators.PrintProblemExecStartsSeperator();
            RunProblem();
            Seperators.PrintProblemExecEndsSeperator();
            Seperators.PrintSolutionExecStartsSeperator();
            RunSolution();
            Seperators.PrintSolutionExecEndsSeperator();
        }

        public void RunProblem()
        {
            Problem.Switch switchObj = new Problem.Switch();
            switchObj.TurnOnAndOffBulb();
            switchObj.TurnOnAndOffFan();
        }

        public void RunSolution()
        {
            // Here high level class - Switch doesnt depend on the lower level module - meaning we are not doing any operation with the
            // lower level module bulb or fan in Switch, But we are using the interface to do the nessary things
            // Thus both Switch and (Bulb,Fan) depends on IDevice
            IDevice bulb = new Solution.LightBulb();
            Solution.Switch switchForBulb = new Solution.Switch(bulb);
            switchForBulb.TurnOn();
            switchForBulb.TurnOff();

            IDevice fan = new Solution.Fan();
            Solution.Switch switchForFan = new Solution.Switch(fan);
            switchForFan.TurnOn();
            switchForFan.TurnOff();

        }
    }
}
