using ObjectOrientedProgramming.Models.Encapsulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._2.Encapsulation.Problem
{
    /*
     We are having a class called HDFCBank, which will give the user bank details, The problem is we are exposing the bankCustomerList in both
     public feild and directly through a method, Hence the consumer class (Google Pay class), can be able to modify the customer bank data from
     google pay class, Thus the data is at risk - what if Google pay class modifies the balance for a user that HDFCBank refers, and a new class
     called Phone Pe class use that modified data from HDFCBank.

     Making this class as singleton, Hence same object and feild will be shared whenever an obj for HDFCbank class creates.
     */
    public  class HDFCBank
    {
        //A public field which holds the bank customer data
        public List<BankCustomer> bankCustomerList;
        public string BankName= "HDFC";
        private static HDFCBank? _instance;
        private HDFCBank()
        {
            bankCustomerList = GetBankCustomers();
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

        /// <summary>
        /// This will simply return all the customer data
        /// </summary>
        /// <returns></returns>
        public List<BankCustomer> GetAllBankCustomers()
        {
            return bankCustomerList;
        }


        /// <summary>
        /// An helper method to create some bank details
        /// </summary>
        /// <returns></returns>
        private List<BankCustomer> GetBankCustomers()
        {
            return [
                    new BankCustomer{
                        UserId=1,
                        Name="Thiru",
                        Pin=1234,
                        Balance=102
                    },
                    new BankCustomer{
                        UserId=2,
                        Name="Krishna",
                        Pin=2345,
                        Balance=108
                    },
                    new BankCustomer{
                        UserId=3,
                        Name="Nila",
                        Pin=8901,
                        Balance=106
                    }
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
            List<BankCustomer> bankCustomers = hDFCBank.GetAllBankCustomers();
           /// List<BankCustomer> bankCustomers = hDFCBank.bankCustomerList;
          

            BankCustomer? customer = bankCustomers.FirstOrDefault(c => c.UserId == userId);
            if(customer == null)
            {
                Console.WriteLine($"From {nameof(GooglePay)} - No customer found");
                return;
            }
            if(customer.Pin!=pin)
            {
                Console.WriteLine($"From {nameof(GooglePay)} - Invalid Pin");
                return;
            }
            Console.WriteLine($"From {nameof(GooglePay)} - The balance is - {customer.Balance}");
            Console.WriteLine($"From {nameof(GooglePay)} - The name of the bank is {hDFCBank.BankName}");

            // Since the Googlepay class have the data about the customers, It can able to modify the values.
            // Here we change the balance - which is a feild in an obj in a list
            customer.Balance = 1234567890;

            // Here we change the Bank name, which is a feild
            hDFCBank.BankName = "SBI";
            Console.WriteLine($"From {nameof(GooglePay)} - After changing the balance illegally is {customer.Balance}");
            Console.WriteLine($"From {nameof(GooglePay)} - The name of the bank after changing illegally is {hDFCBank.BankName}");

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
            List<BankCustomer> bankCustomers = hDFCBank.GetAllBankCustomers();
            /// List<BankCustomer> bankCustomers = hDFCBank.bankCustomerList;


            BankCustomer? customer = bankCustomers.FirstOrDefault(c => c.UserId == userId);
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
            Console.WriteLine($"From {nameof(PhonePe)} - The balance of the customer is {customer.Balance}");
            Console.WriteLine($"From {nameof(PhonePe)} - The name of the bank is {hDFCBank.BankName}");
        }
    }
}
