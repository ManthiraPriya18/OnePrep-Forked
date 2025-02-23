using ObjectOrientedProgramming.Models.Encapsulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._2.Encapsulation.Solution
{
    /*
     * Here the HDFCBank class is defined as a singleton. Here we are having a private feild _bankCustomerList where we will have the data, 
     * and a public feild bankCustomerList, which can be used by other class - See below. Since we encapsulate data by setting the getter & private setter
     * The data cannot be modified in other class. Note -> If we expose the private feild directly by returning in a method, It is possible to modify.
     * And we are using record instead of class - Record is immutable (If we have getter & setter in record then it is possible to modify)
     * Check  namespace ObjectOrientedProgramming.Models.Encapsulation
     * We can even have something like public double Balance {get; init;} -> so the value will be set when creation thats it.

     */
    public class HDFCBank
    {
        //A private field which holds the bank customer data
        private List<BankCustomerRecord> _bankCustomerList ;

        //A public feild which can be used to encapsulate the data, by getting the  _bankCustomerList, and set is set to private
        //Hence from outer class the feild cannot be modified
        public List<BankCustomerRecord> bankCustomerList { get { return _bankCustomerList; } private set { } }
        private string _bankName;
        public string BankName { get { return _bankName; } private set { } }
        private static HDFCBank? _instance;
        private HDFCBank()
        {
            _bankName = "HDFC";
            _bankCustomerList = GetBankCustomers();
            bankCustomerList = _bankCustomerList;
        }
        public static HDFCBank GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new HDFCBank();
                }
            }
            return _instance;
        }

        //This will simply return all the customer data.
        //Note the fact, That we are directly exposing the feild (Though it is private)
        //Hence the other class can able to modify feilds.
        //One option is creating a clone of the object and send that clone, Hence modifying the clone wont affect original.
        //But the good solution is exposing the feilds, by setting the setter private
        public List<BankCustomerRecord> GetAllBankCustomers()
        {
            return _bankCustomerList;
        }



        /// <summary>
        /// An helper method to create some bank details
        /// </summary>
        /// <returns></returns>
        private List<BankCustomerRecord> GetBankCustomers()
        {
            return [
                    new BankCustomerRecord(1,1234,102,"Thiru"),
                    new BankCustomerRecord(2,2345,108,"Krishna"),
                    new BankCustomerRecord(3,5678,103,"Nila")
                ];
        }
    }
    public class GooglePay
    {
        private readonly HDFCBank hDFCBank;
        public GooglePay()
        {
            hDFCBank = HDFCBank.GetInstance();
        }

        public void ConsoleBalanceByUserId(int userId, int pin)
        {

            // Getting the customer data from hdfcbank class is same in both case,
            // In one it will return us all the data that is in the public feild
            // Second is directly accessing the public feild
            List<BankCustomerRecord> bankCustomers = hDFCBank.bankCustomerList;
            /// List<BankCustomer> bankCustomers = hDFCBank.bankCustomerList;


            BankCustomerRecord? customer = bankCustomers.FirstOrDefault(c => c.UserId == userId);
            if (customer == null)
            {
                Console.WriteLine($"From {nameof(GooglePay)} - No customer found");
                return;
            }
            if (customer.Pin != pin)
            {
                Console.WriteLine($"From {nameof(GooglePay)} - Invalid Pin");
                return;
            }
            Console.WriteLine($"From {nameof(GooglePay)} - After changing the balance illegally - {customer.Balance}");

            // Since the Googlepay class have the data about the customers, It can able to modify the values.
            // The below commented code will throw error - The setter accesser is in accessible
            //hDFCBank.BankName = "SBI";
           
            // The below commeneted code will throw error - Init only property
            //customer.Balance = 999999999;

            Console.WriteLine($"From {nameof(GooglePay)} - The new balance of the customer is {customer.Balance}");
        }
    }

    public class PhonePe
    {
        private readonly HDFCBank hDFCBank;
        public PhonePe()
        {
            hDFCBank = HDFCBank.GetInstance();
        }
        public void ConsoleBalanceByUserId(int userId, int pin)
        {

            // Getting the customer data from hdfcbank class is same in both case,
            // In one it will return us all the data that is in the public feild
            // Second is directly accessing the public feild
            List<BankCustomerRecord> bankCustomers = hDFCBank.GetAllBankCustomers();
            /// List<BankCustomer> bankCustomers = hDFCBank.bankCustomerList;


            BankCustomerRecord? customer = bankCustomers.FirstOrDefault(c => c.UserId == userId);
            if (customer == null)
            {
                Console.WriteLine($"From {nameof(PhonePe)} - No customer found");
                return;
            }
            if (customer.Pin != pin)
            {
                Console.WriteLine($"From {nameof(PhonePe)} - Invalid Pin");
                return;
            }
            Console.WriteLine($"From {nameof(PhonePe)}The balance of the customer is {customer.Balance}");
        }
    }

}
