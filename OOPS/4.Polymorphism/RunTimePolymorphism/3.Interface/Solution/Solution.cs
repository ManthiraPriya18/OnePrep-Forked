using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._4.Polymorphism.RunTimePolymorphism.Interface.Solution
{
    /*
     * Here since we are having a common interface, the classes will be extend this interface will be resolved in runtime, thus acheived polymorphism
     */
    public interface IPayment
    {
        void Pay();
    }
    public class UpiPayment : IPayment
    {
        public void Pay() => Console.WriteLine("Paid via UPI");
    }

    public class CardPayment : IPayment
    {
        public void Pay() => Console.WriteLine("Paid via Card");
    }
    
    public class ProccessPayments
    {
        public void ProcessPayment(IPayment paymentMethod)
        {
            paymentMethod.Pay(); // ✅ Clean and flexible
        }

    }
}
