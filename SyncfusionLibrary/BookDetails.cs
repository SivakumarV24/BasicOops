using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
     //Class 
    /// <summary>
    /// Class BookDetails used to create instance for Book <see cref="BookDetails"/>
    /// </summary>
    public class BookDetails
    {
        // Field
        /// <summary>
        /// static Field s_bookID used to autoincreament BookID  of the instance  <see cref="BookDetails"/>
        /// </summary>
        private static int s_bookID=1000;
        /*
            1.	BookID (Auto Increment - BID1000)
            2.	BookName
            3.	AuthorName
            4.	BookCount
        */
        // property
        public string BookID { get; } // ReadOnly
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int BookCount { get; set; }
        // constructor
        public BookDetails(string bookName,string authorName,int bookCount)
        {
            // Auto  Increamentation
            s_bookID++;
            BookID="BID"+s_bookID;
            // Assigning value to property.
            BookName=bookName;
            AuthorName=authorName;
            BookCount=bookCount;
        }
        
        
        
        
        
        
        
        
    }
}