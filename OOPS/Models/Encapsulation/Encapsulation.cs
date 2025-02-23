using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming.Models.Encapsulation
{
    public class BankCustomer
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Pin { get; set; }
        public double Balance { get; set; }

        /*
            We can use this also, If we dont want the value to be updated after Object creation
             public double Balance { get; init; }
         */
    }

    /*
     * 
    Though this is a record, the feild can be updated since 
    we are using getter & setter
    public record BankCustomerRecord
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Pin { get; set; }
        public double Balance { get; set; }

        public BankCustomerRecord(int userId, int pin, double balance,string name)
        {
            UserId = userId;
            Pin = pin;
            Balance = balance;
            Name = name;
        }
    }


    */

    /*
     This is a record, But we are using init, hence only at the initial time the setting of the feild is alloweds
     public record BankCustomerRecord
    {
        public int UserId { get; init; }
        public string Name { get; init; } = string.Empty;
        public int Pin { get; init; }
        public double Balance { get; init; }

        public BankCustomerRecord(int userId, int pin, double balance,string name)
        {
            UserId = userId;
            Pin = pin;
            Balance = balance;
            Name = name;
        }
    }
     */
    public record BankCustomerRecord2(
        int UserId,
        int Pin,
        double Balance,
        string Name
    );
}
