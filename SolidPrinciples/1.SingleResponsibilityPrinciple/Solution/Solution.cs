using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._1.SingleResponsibilityPrinciple.Problem
{
    /*
        Here we extract the Implementation of each of the functionality such as checking if user exists, sending Mail into a seperate class.
        This acheiving single functionality for each class
     */

    public class LoginService
    {
         public void LoginUser(string userMailId)
         {
            bool isUserExists = new UserService().IsUserExists(userMailId);
            if (!isUserExists)
            {
                Console.WriteLine("User with this MailId Doest exists");
                return;
            }
            MailMessage mailMessage = new MailMessage 
                {
                    Subject ="Your OTP for login"
                };
            bool isOtpSent = new MailService().SendMail(mailMessage);
            if (!isOtpSent)
            {
                Console.WriteLine("OTP not sent");
                return;
            }
            Console.WriteLine("OTP sent to user");
         }
    }

    /// <summary>
    /// This class is responsible for activities related to user, Such as check if user exists, Deactivate account etc
    /// </summary>
    public class UserService
    {
        public bool IsUserExists(string mailId)
        {
            // Assume that we are making a DB call to check user exists
            return true;
        }
    }

    /// <summary>
    /// This class is responsible to send mail, such as sending OTP, or sending promotional mail
    /// </summary>
    public class MailService
    {
        public bool SendMail(MailMessage mailMessage)
        {
            // Assume that we are sending the mail using SMPT
            bool sent = true;
            
            return sent;
        }
    }
}
