using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{   /// <summary>
    /// DataTyep Gender used to Slect a instance of <see cref="UserDetails"/> Gender Information
    /// </summary>
    public enum Gender{
        Male,Female,Transgender
    }
    /// <summary>
    /// DataTyep Department used to Slect a instance of <see cref="UserDetails"/> Gender Information
    /// </summary>
    public enum Department{
        ECE,EEE,CSE
    }
    //Class 
    /// <summary>
    /// Class userDetails used to create instance for user <see cref="UserDetails"/>
    /// </summary>
    public class UserDetails
    {
        // Field
        /// <summary>
        /// static Field s_userID used to autoincreament userID  of the instance  <see cref="UserID"/>
        /// </summary>
         private static int s_userID=3000;
        /*  a.	UserID (Auto Increment – SF3000)
            b.	UserName
            c.	Gender
            d.	Department – (Enum – ECE, EEE, CSE)
            e.	MobileNumber
            f.	MailID
            g.	WalletBalance
            */
        // property
        public string UserID { get;} //Read Only
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public string MobileNumber { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }
        //Constructor
        public  UserDetails(string userName,Gender gender,Department department,string mobileNumber,string mailID,double walletBalance)
        {
            //Auto increamentation
            s_userID++;
            // Assigning Value to property
            UserID="SF"+s_userID;
            UserName=userName;
            Gender=gender;
            Department=department;
            MobileNumber=mobileNumber;
            MailID=mailID;
            WalletBalance=walletBalance;
        }
        //Methods
        //WalletRecharge Method
        public double WalletRecharge(double amount)
        {
            return WalletBalance+=amount;
        }
        //DeductBalance
        public double DeductBalance(double amount)
        {
            return WalletBalance-=amount;
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}