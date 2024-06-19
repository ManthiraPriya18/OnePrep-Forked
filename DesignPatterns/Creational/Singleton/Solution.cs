using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public  class Solution
    {
        /*  SOLUTION:
         *  
            - The instance should not be created when requested. Hence changing the constrcutor to private.
            - Having a static class, which will supply the instance that is created. So whenever a new instance requeires,
              User can have something liek this Solution.GetInstance(), Then they can perform the operations
            
         */


        List<string> serversList = new List<string>();

        private int curServerIndex = 0;

        private static readonly Solution _instance = new Solution();
        private Solution()
        {
            serversList.Add("Thiru");
            serversList.Add("Nila");
            serversList.Add("Krishnan");
            serversList.Add("Karnan");
            Console.WriteLine("Object created in Singleton solution");
        }

        //Method to get the single instance
        public static Solution GetInstance()
        {
            return _instance;
        }
        public string GetCurrentServerName()
        {
            string name = serversList[curServerIndex];
            curServerIndex++;
            if (curServerIndex >= serversList.Count)
            {
                curServerIndex = 0;
            }
            return name;
        }
    }
}
