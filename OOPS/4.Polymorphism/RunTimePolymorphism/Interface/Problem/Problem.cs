using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.Interface.Problem
{
    /*
     * Since there is different way for payment, when we proccess the payments - class ProccessPayments, we will ended up writing lot of conditions based
     * on different type of payments.
     * 
     */
    public class UpiPayment
    {
        public void Pay() => Console.WriteLine("Paid via UPI");
    }

    public class CardPayment
    {
        public void Pay() => Console.WriteLine("Paid via Card");
    }

    public class ProccessPayments
    {
        public void ProcessUpiPayment(UpiPayment paymentMethod)
        {
            paymentMethod.Pay(); 
        }
        public void ProcessCardPayment(CardPayment paymentMethod)
        {
            paymentMethod.Pay();
        }
    }
}
