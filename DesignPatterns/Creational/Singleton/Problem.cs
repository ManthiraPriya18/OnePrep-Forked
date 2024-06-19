using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public class Problem
    {
        List<string> serversList = new List<string>();

        private int curServerIndex = 0;
        public Problem()
        {
            serversList.Add("Thiru");
            serversList.Add("Nila");
            serversList.Add("Krishnan");
            serversList.Add("Karnan");
            Console.WriteLine("Object created in Singleton Problem");
        }

        public string GetCurrentServerName()
        {
            string name = serversList[curServerIndex];
            curServerIndex++;
            if(curServerIndex >= serversList.Count)
            {
                curServerIndex = 0;
            }
            return name;
        }
    }
}
