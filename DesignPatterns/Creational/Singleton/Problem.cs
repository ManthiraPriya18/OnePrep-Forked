using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public class Problem
    {

        /*
             Whenever a new instanceis created a copy of this will be generated, So that we wont get the consistency accessing lsit element,
            ie) In GetCurrentServerName() if we request, we will get the next server, But if the obj is different, Then we will get different server than the next one.
            Beacuse each obj will have its own copy

         */
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
