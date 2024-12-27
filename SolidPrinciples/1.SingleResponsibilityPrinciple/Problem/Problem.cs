using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._1.SingleResponsibilityPrinciple.Problem
{
    /*
        This UserLoginService class is responsible for login functionality, However this class is responsible for more than one functionality, Which is 
        Checking if user exists & sending the otp - which is a problem.
     */
    public class UserLoginService
    {
        /// <summary>
        /// This method will take userMailId, and check If exists in DB then will send OTP.
        /// </summary>
        /// <param name="userMailId"></param>
        public void LoginUser(string userMailId)
        {
            bool isUserExists = IsUserExists(userMailId);
            if(!isUserExists)
            {
                Console.WriteLine("User with this MailId Doest exists");
                return;
            }
            bool isOtpSent= SendOTPToUser(userMailId);
            if(!isOtpSent)
            {
                Console.WriteLine("OTP not sent");
                return;
            }
            Console.WriteLine("OTP sent to user");
        }

        private bool IsUserExists(string mailId)
        {

            bool isValid = true;
            // Assume tht we are making a DB call
            return isValid;
        }

        private bool SendOTPToUser(string mailId)
        {
            bool send = true;
            // Assme that we are using SMPT to send OTP to user
            return send;
        }
    }
}
