using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountOpening
{
    public enum Gender{
        Select,
        Male,
        Female
    }
    public class CustomerDetails
    {
        private static  int s_id=1000;
        public CustomerDetails()
        {
            s_id++;
            CustomerId="HDFC"+s_id; 
        }
        public string CustomerId { get; }
        public string CustomerName { get; set; }
        public float Balance { get; set;}

        public Gender Gender { get; set;}
        public double PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string MailId{ get; set; }
    }
}