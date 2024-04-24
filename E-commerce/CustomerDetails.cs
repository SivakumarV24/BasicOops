using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce
{
     //Class 
    /// <summary>
    /// Class CustomerDetails used to create instance for student <see cref="CustomerDetails"/>
    /// </summary>
    public class CustomerDetails
    {
        // Field
        /// <summary>
        /// Static field s_id used to AutoIncreamentation of the CustomerID.
        /// </summary>
        private static int s_id=1000;
        // Property
        /// <summary>
        /// CustomerID property used to store the customerID
        /// </summary>
        /// <value></value>
        public string CustomerID { get; } //Read Only
        /// <summary>
        /// Name property used to store the Name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// City property used to store the City
        /// </summary>
        /// <value></value>
        public string City { get; set; }
        /// <summary>
        /// MobileNumber property used to store the MobileNumber
        /// </summary>
        /// <value></value>
        public string MobileNumber { get; set; }
        /// <summary>
        /// WalletBalance property used to store the Walletbalance of the user.
        /// </summary>
        /// <value></value>
        public double WalletBalance { get; set; }
        /// <summary>
        /// EmailID property used to store the EmailID
        /// </summary>
        /// <value></value>
        public string EmailID { get; set; }

        //constructors
        public CustomerDetails(){}
        /// <summary>
        /// CustomerDetails constructor used to asssign the default value to the Proeprty
        /// </summary>
        /// <param name="name"></param>
        /// <param name="city"></param>
        /// <param name="mobilenumber"></param>
        /// <param name="walletBalance"></param>
        /// <param name="emailId"></param>
        public CustomerDetails(string name,string city,string mobilenumber,double walletBalance,string emailId)
        {
            s_id++;
            CustomerID="CID"+s_id;
            Name=name;
            City=city;
            MobileNumber=mobilenumber;
            WalletBalance=walletBalance;
            EmailID=emailId;
        }
        // Methods
        // WalletRecharge
        /// <summary>
        /// WalletRecharge method used to Recharge the Customer Wallet.
        /// </summary>
        /// <param name="rechargeAmount"></param>
        /// <returns></returns>
        public double WalletRecharge(double rechargeAmount)
        {
            WalletBalance+=rechargeAmount;
            return WalletBalance;
        }
        // DeduceBalance
        /// <summary>
        /// DeductBalance method used to reduce the CustomerWalletBalance.
        /// </summary>
        /// <param name="deductAmount"></param>
        public void DeductBalance(double deductAmount)
        {
            WalletBalance-=deductAmount;
        }
    }
}