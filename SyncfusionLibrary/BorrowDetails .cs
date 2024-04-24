using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    // enum
    /// <summary>
    /// Date Type Status Store a status of Admission <see cref="BorrowDetails"/>
    /// </summary
    public enum Status{
        Default,Borrowed,Returned
    }
     //Class 
    /// <summary>
    /// Class BorrowDetails used to create instance for BorrowBook <see cref="BorrowDetails"/>
    /// </summary>
    public class BorrowDetails 
    {
        // Field
        /// <summary>
        /// static Field s_borrowID used to autoincreament BookID  of the instance  <see cref="BorrowDetails"/>
        /// </summary>
        private static  int s_borrowID=2000;
        /*
        •	BorrowID (Auto Increment – LB2000)
        •	BookID 
        •	UserID
        •	BorrowedDate – ( Current Date and Time )
        •	BorrowBookCount 
        •	Status –  ( Enum - Default, Borrowed, Returned )
        •	PaidFineAmount
        */
        // Property
        /// <summary>
        /// Property BorrowId used to store borrowId.
        /// </summary>
        /// <value></value>
        public string BorrowID { get; } // ReadOnly
        public string BookID { get; set; }
        public string UserID{ get; set; }
        public DateTime BorrowedDate { get; set; }
        public int BorrowBookCount { get; set; }
        public Status Status { get; set; }
        public double PaidFineAmount { get; set; }
        // constructor
        public BorrowDetails(string bookID,string userID,DateTime borrowedDate,int borrowBookCount,Status status,double paidFineAmount)
        {
            // Auto increamentation
            s_borrowID++;
            // Assigning value to property
            BorrowID="LB"+s_borrowID;
            UserID=userID;
            BookID=bookID;
            BorrowedDate=borrowedDate;
            BorrowBookCount=borrowBookCount;
            Status=status;
            PaidFineAmount=paidFineAmount;
        }
        
        
        
        
        
        
        
        
        
        
        
        
    }
}