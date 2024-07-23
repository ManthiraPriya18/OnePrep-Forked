using DesignPatterns.Helpers.Common;
using DesignPatterns.Helpers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class ExecuteFactoryMethod : IExecute
    {
        public void Run()
        {
            Common.PrintProblemSeperator();
            RunProblem();
            Common.PrintProblemSeperator();
            Common.PrintSolutionSeperator();
            RunSolution();
            Common.PrintSolutionSeperator();
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public void RunSolution()
        {
            throw new NotImplementedException();
        }
    }
}
