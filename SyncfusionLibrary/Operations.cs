using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    // static class
    /// <summary>
    /// Class Operation used to Call the functionality <see cref="Operations"/>
    /// </summary>
    public static class Operations
    {
        //Create a list for store Object
        static List<UserDetails> userList=new List<UserDetails>();
        static List<BookDetails> bookList=new List<BookDetails>();
        static List<BorrowDetails> borrowBookList=new List<BorrowDetails>();

        // Create a object for to store current userDetails
        static UserDetails currentLoggedInUserDetails;
        // Add Default Value Method
        // Main Menu Mehtod
        public static void MainMenu()
        {
            bool flag=true;
            // Need to Show Title
            Console.WriteLine($"**************SYNCFUSION LIBRARY***************");
            Console.WriteLine();           
            
            // run until exit
            do
            {
                /*
                    1.	UserRegistration
                    2.	UserLogin
                    3.	Exit
                    */
                // Need to Show main Menu
                Console.WriteLine($"********Main Menu********");
                Console.WriteLine($"1. UserRegistration\n2. UserLogin\n3.Exit");
                Console.Write($"Enter the option given above : ");
                int mainOption=int.Parse(Console.ReadLine());
                switch(mainOption)
                {
                    case 1:
                    {
                        // UserRegistration
                        Console.WriteLine($"********Welcom to Registration********");
                        UserRegistration();
                        break;
                        
                    }
                    case 2:
                    {   // user Login
                        Console.WriteLine($"************Login***********");
                        UserLogin();
                        break;                        
                    }
                    case 3:
                    {
                        // Exit from Application
                        Console.WriteLine($"Exit From Application");
                        flag=false;
                        break;
                    }
                    default:
                    {
                        // Invalid Option
                        Console.WriteLine($"Your Entered Invalid Option !.");
                        break;                       
                    }
                }               
            } while (flag);
            
        }// Main Menu Method end
        public static void UserRegistration()
        {
            /*  a.	Username
                b.	Gender (Enum – Select, Male, Female, Transgender)
                c.	Department  
                d.	MobileNumber
                e.	MailID
                f.	WalletBalance
            */
            // get details From users
            Console.Write($"Enter Your Name : ");
            string userName="";
            bool valid=true;
            while(valid)
            {
                userName=Console.ReadLine();
                int count=0;
                for(int i=0;i<userName.Length;i++)
                {
                    if((userName[i]>='A' && userName[i]<='Z')||(userName[i]>='a'&&userName[i]<='z')|| userName[i]==' ')
                    {
                        count++;
                    }
                }
                if(count==userName.Length)
                {
                    valid=false;
                }
                else
                {
                    Console.Write($"Name Should be Alphabets. Enter Your Name : ");                    
                }
            }
            Console.Write($"Enter Your Gender (male,Female,Transgender) : ");
            valid=false;
            Gender gender=Gender.Male;
            while(!valid)
            {
                valid=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
                if(!valid)
                {
                    Console.Write($"Gender Invalid. Enter Your Gender (male,Female,Transgender) :");                    
                }
            }
            Console.Write($"Enter Your Department (EEE,CSE,ECE) : ");
             valid=false;
            Department department=Department.ECE;
            while(!valid)
            {
                valid=Enum.TryParse<Department>(Console.ReadLine(),true,out department);;
                if(!valid)
                {
                    Console.Write($"Department Invalid. Enter Your Department (EEE,CSE,ECE) : ");                    
                }
            }
            Console.Write($"Enter Your MobileNumber : ");
            valid=false;
            string mobileNumber="";
            while(!valid)
            {
                mobileNumber=Console.ReadLine();
                int count=0;
                for(int i=0;i<mobileNumber.Length;i++)
                {
                    if(mobileNumber[i]>='0' && mobileNumber[i]<='9')
                    {
                        count++;
                    }
                }
                if(count==mobileNumber.Length)
                {
                    valid=true;
                }
                else
                {
                    Console.Write($"Number Should be 10 Digits and Contains Only Number. Enter Your MobileNumber : ");                    
                }
            } 
            Console.Write($"Enter Your MailID (ex:name@gmailcom): ");
            valid=true;
            string mailID="";
            while(valid)
            {
                mailID=Console.ReadLine();
                if(mailID.Contains("gmail.com"))
                {
                    valid=false;
                }
                else
                {
                    Console.Write($"MailId Contains @gmail.com. Enter Your MailID (ex:name@gmailcom): ");
                    
                }
            }  
            Console.Write($"Enter WalletBalance (Minimum 100) :");
            double walletBalance=0;
            valid=true;
            while(valid)
            {
                walletBalance=double.Parse(Console.ReadLine());
                if(walletBalance>=100)
                {
                    valid=false;
                }
                else
                {
                    Console.Write($"Minimum WalletBalance =100.Enter WalletBalance Equal or More Than 100 : ");                    
                }
            }
                     
            // Store the userDetails in list
            UserDetails addUser=new UserDetails(userName,gender,department,mobileNumber,mailID,walletBalance);
            userList.Add(addUser);
            // display userId
            Console.WriteLine($"Registration Successfully. Your UserID : {addUser.UserID}.");            
        }
        public static void UserLogin()
        {
            // get UserID from user
            int flag=0;
            Console.Write($"Enter You UserID : ");
            string userID=Console.ReadLine().ToUpper();
            // check userId is present or not
            foreach(UserDetails user in userList)
            {
                if(userID.Equals(user.UserID))
                {
                    // Store the userDetails in currentLoggedInuserDetails;
                    flag=1;
                    currentLoggedInUserDetails=user;
                    // show Sub menu
                    SubMenu();
                    break;
                }
            }
            if(flag==0)
            {
                Console.WriteLine($"Invalid User ID. Please enter a valid one");                
            }  
        }// Login End
        // SubMenu Method
        public static void SubMenu()
        {
            /*
            1.	Borrowbook.
            2.	ShowBorrowedhistory.
            3.	ReturnBooks
            4.	WalletRecharge 
            5.	Exit
            */
            // Need to show sub Menu
            Console.WriteLine($"*********Sub Menu*********");
            bool flag=true;
            //runs until exit
            do
            {
                 Console.WriteLine($"1. Borrow Book\n2. Show Borrowed history\n3. ReturunBooks\n4. Wallet Recharge\n5. Exit");
                // Need to get input form user 
                Console.WriteLine($"Enter the option given above : ");
                int subOption=int.Parse(Console.ReadLine());
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine($"*********Borrow Book**********");
                        BorrowBook();
                        break;                        
                    }
                    case 2:
                    {
                        Console.WriteLine($"*********Borrowed History**********");
                        ShowBorrowedhistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine($"***********Return Books************");
                        ReturnBooks();
                        break;                        
                    }
                    case 4:
                    {
                        Console.WriteLine($"***********Wallet Recharge************");
                        WalletRecharge();
                        break;                        
                    }
                    case 5:
                    {
                        flag=false;
                        Console.WriteLine($"***********Exit from SubMenu**********");
                        break;                        
                    }
                    default :
                    {
                        Console.WriteLine($"Invalid Option!.");                        
                        break;
                    }
                }
            } while (flag);
        }//Submenu Ends
        // Borrow Book Method
        public static void BorrowBook()
        {
            //Need to show book list
            int flag=0;
            int count=0;
            Console.WriteLine($"--------------------------------------------");
            Console.WriteLine($"|{"BookID",-10}|{"BookName",-10}|{"AuthorName",-10}|{"BookCount",10}|");
            Console.WriteLine($"---------------------------------------------");         
            foreach(BookDetails book in bookList)
            {
                if(book.BookCount>0)
                {
                    Console.WriteLine($"|{book.BookID,-10}|{book.BookName,-10}|{book.AuthorName,-10}|{book.BookCount,-10}|");
                    Console.WriteLine($"---------------------------------------------"); 
                    flag=1;
                }
            }
            if(flag==0)
            {
                Console.WriteLine($"Book Are not Available");               
            }
            else
            {
                // Need to ask user to pick one book
                Console.Write($"Enter the BookID : ");
                string bookID=Console.ReadLine().ToUpper();
                //check bookId is present or not
                foreach (BookDetails book in bookList)
                {
                    if(bookID.Equals(book.BookID))
                    {
                        count=1;
                        // ask user to book count
                        Console.Write($"Enter the Book Count : ");
                        int bookCount=int.Parse(Console.ReadLine());
                        if(bookCount<=book.BookCount)
                        {
                            //if available check user borrowedbook is less than or equal to 3.
                            int borrowBookCount=0;
                            foreach(BorrowDetails borrow in borrowBookList)
                            {
                                if(currentLoggedInUserDetails.UserID==borrow.UserID && borrow.Status==Status.Borrowed)
                                {
                                    borrowBookCount+=borrow.BorrowBookCount;
                                }
                            }
                            if((borrowBookCount+bookCount)<=3)
                            {
                                
                                 //if less than 3  create a object to store details
                                BorrowDetails addBorrowDetails=new BorrowDetails(book.BookID,currentLoggedInUserDetails.UserID,DateTime.Now,bookCount,Status.Borrowed,0);
                                book.BookCount-=bookCount;
                                // added into list.
                                borrowBookList.Add(addBorrowDetails);
                                Console.WriteLine($"Book Borrowed successfully.Your BorrowID : {addBorrowDetails.BorrowID}");                                
                            }
                            else
                            {
                                if(borrowBookCount==3)
                                {
                                    Console.WriteLine($"You have borrowed 3 books already");  
                                }
                                else
                                {
                                    Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {borrowBookCount} and requested count is {bookCount}, which exceeds 3 ");                                    
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Books are not available for the selected count");
                            foreach(BorrowDetails borrow in borrowBookList)
                            {
                                if(borrow.BookID==book.BookID && borrow.Status==Status.Borrowed)
                                {
                                    DateTime nextDate=borrow.BorrowedDate.AddDays(15);
                                    Console.WriteLine($"The book will be available on  : {nextDate.ToString("dd/MM/yyyy")}");
                                    break;                                    
                                }
                            }
                            
                        }                     
                    }
                }
                if(count==0)
                {
                    Console.WriteLine($"Invalid Book ID, Please enter valid ID");
                    
                }
            }   
        }
        // Show Borrowed History Method
        public static void ShowBorrowedhistory()
        {
            int flag=0;
            Console.WriteLine($"------------------------------------------------------------------------");
            Console.WriteLine($"|{"BorrowID",-8}|{"BookID",-8}|{"UserID",-8}|{"BorrowedDate",-8}|{"BorrowBookCount",-8}|{"PaidFineAmount",-8}|");
            Console.WriteLine($"------------------------------------------------------------------------");
            // Show borrowed history where Status =Borrowed 
            foreach(BorrowDetails borrowbook in borrowBookList)
            {
                if(borrowbook.Status==Status.Borrowed && currentLoggedInUserDetails.UserID==borrowbook.UserID)
                {
                    Console.WriteLine($"|{borrowbook.BorrowID,-8}|{borrowbook.BookID,-8}|{borrowbook.UserID,-8}|{borrowbook.BorrowedDate.ToString("dd/MM/yyyy"),-13}|{borrowbook.BorrowBookCount,-14}|{borrowbook.PaidFineAmount,-14}|");
                    Console.WriteLine($"------------------------------------------------------------------------");
                    flag=1;
                }
            }
            if(flag==0)
            {
                Console.WriteLine($"No Borrowed Books History Found.");                
            }
        }
        //Return Books Mehtod
        public static  void ReturnBooks()
        {
            int flag=0;
            Console.WriteLine($"------------------------------------------------------------------------------------");
            Console.WriteLine($"|{"BorrowID",-10}|{"BookID",-10}|{"BorrowedDate",-12} |{"BorrowBookCount",-16}|{"PaidFineAmount",-15}| {"ReturnDated",-12}|");
            Console.WriteLine($"------------------------------------------------------------------------------------");
            DateTime todayDate=DateTime.Today;           
            foreach (BorrowDetails borrow in borrowBookList)
            {
                if(borrow.Status==Status.Borrowed && borrow.UserID==currentLoggedInUserDetails.UserID)
                {
                    flag=1;
                    if(borrow.BorrowedDate.AddDays(15)<todayDate)
                    {
                        TimeSpan span=todayDate-borrow.BorrowedDate.AddDays(15);
                        int fine=(int)span.Days;
                        fine*=borrow.BorrowBookCount;
                        borrow.PaidFineAmount=fine;
                        Console.WriteLine($"|{borrow.BorrowID,-10}|{borrow.BookID,-10}|{borrow.BorrowedDate.ToString("dd/MM/yyyy"),-13}|{borrow.BorrowBookCount,-16}|{fine,-15}| {borrow.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy"),-12}|");
                        Console.WriteLine($"-------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine($"|{borrow.BorrowID,-10}|{borrow.BookID,-10}|{borrow.BorrowedDate.ToString("dd/MM/yyyy"),-13}|{borrow.BorrowBookCount,-16}|{borrow.PaidFineAmount,-15}| {borrow.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy"),-12}|");
                        Console.WriteLine($"-------------------------------------------------------------------------------------");
                    } 
                }    
            }
            if(flag==0)
            {
                Console.WriteLine($"No Data Found.");
            }
            else
            {
                //Ask user to Enter BorrowedID 
                int count=0;
                Console.Write($"Enter Your BorrowedID : ");
                string borrowID=Console.ReadLine().ToUpper();
                foreach (BorrowDetails borrow in borrowBookList)
                {
                    if(borrow.Status==Status.Borrowed && borrow.UserID==currentLoggedInUserDetails.UserID && borrow.BorrowID==borrowID)
                    {
                        count=1;
                        if(borrow.PaidFineAmount>0)
                        {
                            if(currentLoggedInUserDetails.WalletBalance>=borrow.PaidFineAmount)
                            {
                                currentLoggedInUserDetails.DeductBalance(borrow.PaidFineAmount);
                                borrow.Status=Status.Returned;
                                foreach (BookDetails book in bookList)
                                {
                                    if(book.BookID==borrow.BookID)
                                    {
                                        book.BookCount+=borrow.BorrowBookCount;
                                        break;
                                    }
                                }
                                Console.WriteLine($"Book returned successfully");
                            }
                            else
                            {
                                Console.WriteLine($"Insufficient balance. Please rechange and proceed");                                
                            }
                        }
                        else
                        {
                            borrow.Status=Status.Returned;
                            foreach (BookDetails book in bookList)
                            {
                                if(book.BookID==borrow.BookID)
                                {
                                    book.BookCount+=borrow.BorrowBookCount;
                                    break;
                                }
                            }
                            Console.WriteLine($"Book returned successfully");
                            
                        }
                        
                    }             
                    
                }
                if(count==0)
                {
                    Console.WriteLine($"Invalid Borrowed ID.");                    
                }

            }
        }
        //Wallent Recharge method
        public static void  WalletRecharge()
        {
            // Ask user Want to recharge the wallet ? Yes/No
            Console.Write($"Do You Want to recharge the wallet ? Yes/No");
            bool valid=true;
            while(valid)
            {
                // geeting input from user.
                string response=Console.ReadLine().ToUpper();
                if(response.Equals("YES"))
                {
                    Console.WriteLine($"Enter the Amount to Recharge : ");
                    double amount=double.Parse(Console.ReadLine());                
                    double walletBalance=currentLoggedInUserDetails.WalletRecharge(amount);
                    Console.WriteLine($"Recharge Successfully. Your Wallet Balance : {walletBalance}");
                    valid=false;
                    break;
                                
                }
                else if(response.Equals("NO"))
                {
                    valid=false;
                    break;
                }
            }           
        }
        // Add Default value Method
        public static void AddDefaultValue()
        {
            // Adding Default value to list.
            userList.Add(new UserDetails("Ravichandran",Gender.Male,Department.EEE,	"9938388333","ravi@gmail.com",100));
            userList.Add(new UserDetails("Priyadharshini",Gender.Female,Department.CSE,	"9944444455","priya@gmail.com",100));
            bookList.Add(new BookDetails("C#","Author1",3));
            bookList.Add(new BookDetails("HTML","Author2",5));
            bookList.Add(new BookDetails("CSS","Author1",3));
            bookList.Add(new BookDetails("JS","Author1",3));
            bookList.Add(new BookDetails("TS","Author2",2));
            borrowBookList.Add(new BorrowDetails("BID1001","SF3001",new DateTime(2023,09,10),2,	Status.Borrowed,0));
            borrowBookList.Add(new BorrowDetails("BID1003","SF3001",new DateTime(2023,09,12),1,	Status.Borrowed,0));
            borrowBookList.Add(new BorrowDetails("BID1004","SF3001",new DateTime(2023,09,14),1,	Status.Returned,16));
            borrowBookList.Add(new BorrowDetails("BID1003","SF3002",new DateTime(2023,09,11),2,	Status.Borrowed,0));
            borrowBookList.Add(new BorrowDetails("BID1005","SF3002",new DateTime(2023,09,9),1,	Status.Returned,20));
        }// AddDefaultValue end
    }
}