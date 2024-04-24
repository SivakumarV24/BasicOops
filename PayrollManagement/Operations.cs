using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagement
{
    public static class Operations
    {
        // List created for  EmployeeList,AttendanceList.
        static List<EmployeeDetails> employeeList=new List<EmployeeDetails>();
        static List<AttendanceDetails> attendanceList=new List<AttendanceDetails>();
        //create a object for current user;
        static EmployeeDetails currentUser;
        // Main Menu
        public static void MainMenu()
        {
            bool flag=true;
            bool condition=true;
            Console.WriteLine("       Welcome to Payroll Management System");
            Console.WriteLine("       ------------------------------------");
            Console.WriteLine();
            do{
                // Main Menu
                Console.WriteLine("       Main Menu     ");
                Console.WriteLine("       ---------     ");
                Console.WriteLine("1. Employee Registration");
                Console.WriteLine("2. Employee Login");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                if(condition)
                {
                    Console.WriteLine("Enter the option Given Above : ");
                }
                else
                {
                    Console.WriteLine("You enter Wrong Option !. Enter the correct option Given Above : ");
                }
                // getting option from user.
                int option=int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        // Employee Registration
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        // Employee Login
                        Login();
                        break;
                    }
                    case 3:
                    {
                        //Exit from Application
                        Console.WriteLine("------Thank You------");
                        flag=false;
                        condition=false;
                        break;
                    }
                    default :
                    {
                        Console.WriteLine($"Invalid Option");
                        break;
                    }
                }
            }while(flag);
        }
        //Registration
        public static void Registration()
        {
            bool flag=true;
            // getting Employee details from user.
            Console.WriteLine("       Welcome to registration      ");
            Console.WriteLine();
            // getting Student Name from user.
            Console.Write("Enter Full Name : ");
            string name="";
            while(flag)
            {
                name=Console.ReadLine();
                int count=0;
                for(int i=0;i<name.Length;i++)
                {
                    if((name[i]>='A' && name[i]<='Z')||(name[i]>='a'&& name[i]<='z')||name[i]==' ')
                    {
                        count++;
                    }
                }
                if(count==name.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You Entered Invaild Format !");
                    Console.Write("Name should Contain Alphabets. Enter Student Name : ");                   
                }
            }
            // getting DOB from user.
            Console.Write("Enter Date of Birth (dd/MM/yyyy) : ");
            DateOnly dob=new DateOnly();
            bool valid=false;
            while(!valid)
            {
                valid=DateOnly.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",out dob);
                if(!valid)
                {
                    Console.Write("Invalid Format!.Enter Correct Date Format (dd/MM/yyyy) : ");
                }
            }
            // getting MobileNumber
            Console.Write($"Enter 10 Digit Mobile Number : ");            
            string mobileNumber="";
            flag=true;
            while(flag)
            {
                mobileNumber=Console.ReadLine();
                int count=0;
                if(mobileNumber.Length==10)
                {
                     for(int i=0;i<mobileNumber.Length;i++)
                    {
                        if(mobileNumber[i]>='0' && mobileNumber[i]<='9')
                        {
                            count++;
                        }
                    }
                }
                if(count==mobileNumber.Length)
                {
                    flag=false;
                    break;
                }
                else
                {
                    Console.WriteLine("You Entered Invaild Format !");
                    Console.Write("Number should Contain only Number with 10  digits. Enter Mobile Number : ");
                }
            }
            // getting Gender from user.
            Console.Write("Enter Gender - Male, Female, Transgender : ");
            valid=false;
            Gender gender=Gender.Default;
            while(!valid)
            {
               valid=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
               if(!valid)
               {
                Console.Write("You Entered Invalid Gender!.Enter Gender Again (Male,Female,Transgender) : ");
               }
            }
            // getting Branch from user.
            Console.Write("Enter Branch - Eymard, Karuna, Madhura : ");
            valid=false;
            Branch branch=Branch.Default;
            while(!valid)
            {
               valid=Enum.TryParse<Branch>(Console.ReadLine(),true,out branch);
               if(!valid)
               {
                Console.Write("You Entered Invalid Branch!.Enter Branch Again (Eymard, Karuna, Madhura) : ");
               }
            }
            // getting Team from user.
            Console.Write("Enter Team - Network, Hardware, Developer, Facility : ");
            valid=false;
            Team team=Team.Default;
            while(!valid)
            {
               valid=Enum.TryParse<Team>(Console.ReadLine(),true,out team);
               if(!valid)
               {
                Console.Write("You Entered Invalid Team!.Enter Team Again (Network, Hardware, Developer, Facility) : ");
               }
            }
            // Details added in employeeDetails object.
            EmployeeDetails employeeDetails=new EmployeeDetails(name,dob,mobileNumber,gender,branch,team);
            // Store EmployeeDetails Object in list.
            employeeList.Add(employeeDetails);
            //Display EmployeeID
            Console.WriteLine($"Registration Successfully.Your EmployeeID : {employeeDetails.EmployeeID}");    
        }
        // Login
        public static void Login()
        {
            bool flag=false;
            Console.WriteLine("Welcome to Login");
            Console.WriteLine();
            Console.Write("Enter Your EmployeeID : ");
            string employeeId=Console.ReadLine();
            employeeId=employeeId.ToUpper();
            foreach (EmployeeDetails employeeDetails in employeeList )
            {
                if(employeeDetails.EmployeeID==employeeId)
                {
                    currentUser=employeeDetails;
                    SubMenu();
                    flag=true;
                    break;
                }
            }
            if(!flag)
            {
                Console.WriteLine($"invalid EmployeeID");
                
            }
        }
        //Submenu
        public static void SubMenu()
        {
            Console.WriteLine($"Welcome {currentUser.FullName}.");
                            Console.WriteLine();
                            bool toPerfromOperation=true;
                            while(toPerfromOperation)
                            {
                                Console.WriteLine($"       Menu       ");
                                Console.WriteLine();
                                Console.WriteLine("a. Add Attendance");
                                Console.WriteLine("b. Display Datails");
                                Console.WriteLine("c. Calculate Salary");
                                Console.WriteLine("f. Exit");
                                Console.Write($"Enter the option Given Above: ");
                                char character=char.Parse(Console.ReadLine());
                                Console.WriteLine();                                
                                switch(character)
                                {
                                    case 'a':
                                    {
                                        
                                        // Add Attendance
                                        AddAttendance();                                                       
                                        break;
                                    }
                                    case 'b':
                                    {
                                        // Show Details
                                        ShowDetails();                                
                                        break;                 
                                    }
                                    case 'c':
                                    {
                                        //calculate Salary
                                        CalculateSalary();
                                        break;
                                    }
                                    case 'f':
                                    {
                                        // Exit from Submenu
                                        Console.WriteLine($"-----Exit From Menu-----");
                                        Console.WriteLine();
                                        toPerfromOperation=false;                                  
                                        break;
                                    }
                                    default :
                                    {
                                        Console.WriteLine("Your enter Invalid Option !.");
                                        break;
                                    }
                                }
                            } 
        }
        // Add Attendance
        public static void AddAttendance()
        {
            bool valid = true;
            // Add Attendance
            while (valid)
            {
                Console.WriteLine($"     Attendance     ");
                Console.WriteLine();
                Console.WriteLine($"1. Check In");
                Console.WriteLine($"2. Check Out");
                Console.WriteLine($"Enter The Option to Perform : ");
                int response = int.Parse(Console.ReadLine());
                AttendanceDetails addAttendance = null;
                switch (response)
                {
                    case 1:
                        {
                            Console.Write($"Enter Date and Time (dd/MM/yyyy HH:mm tt): ");
                            DateTime checkIn = new DateTime();
                            bool invalid = false;
                            while (!invalid)
                            {
                                bool date = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm tt", null, System.Globalization.DateTimeStyles.None, out checkIn);
                                if (!date)
                                {
                                    Console.WriteLine($"Invalid format !. Enter Again (dd/MM/yyyy HH:mm tt) :");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            DateOnly dateOnly = DateOnly.FromDateTime(checkIn);
                            addAttendance = new AttendanceDetails(currentUser.EmployeeID, dateOnly, checkIn);
                            attendanceList.Add(addAttendance);
                            Console.WriteLine($"Check In Successfully");
                            valid = false;
                            break;

                        }
                    case 2:
                        {
                            Console.Write($"Enter Date and Time (dd/MM/yyyy HH:mm tt): ");
                            DateTime checkOut = new DateTime();
                            bool invalid = false;
                            while (!invalid)
                            {
                                bool date = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm tt", null, System.Globalization.DateTimeStyles.None, out checkOut);
                                if (!date)
                                {
                                    Console.WriteLine($"Invalid format !. Enter Again (dd/MM/yyyy HH:mm tt) :");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            DateOnly dateonly = DateOnly.FromDateTime(checkOut);
                            int hours = 0;
                            int workingHours = 9;
                            foreach (AttendanceDetails list in attendanceList)
                            {
                                if (currentUser.EmployeeID == list.EmployeeID && list.Date == dateonly)
                                {
                                    TimeSpan span = list.CheckOutTime - checkOut;
                                    hours = span.Hours;
                                    if (hours >= workingHours)
                                    {
                                        list.HoursWorked = 8;
                                        list.CheckOutTime = checkOut;
                                    }
                                }
                            }
                            valid = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Your Enter Invalid Option !. ");
                            break;
                        }
                }
            }
        }
        //Show Details
        public static void ShowDetails()
        {
            Console.WriteLine($"     Employee Details");
            Console.WriteLine();
            Console.WriteLine($"EmployeeID : {currentUser.EmployeeID}");
            Console.WriteLine($"Name : {currentUser.FullName}");
            Console.WriteLine($"DOB : {currentUser.DOB}");
            Console.WriteLine($"MobileNumber : {currentUser.MobileNumber}");
            Console.WriteLine($"Gender : {currentUser.Gender}");
            Console.WriteLine($"Branch : {currentUser.Branch}");
            Console.WriteLine($"Team :  {currentUser.Team}"); 
        }
        public static void CalculateSalary()
        {
            int numberOfWorkingDay=0;
            foreach(AttendanceDetails list in attendanceList)
            {
                if(list.EmployeeID==currentUser.EmployeeID && list.HoursWorked==8)
                {
                    numberOfWorkingDay++;
                }
            }
            Console.WriteLine($"Total Salary = {numberOfWorkingDay*500}");
        }
        // Add Default value
        public static void AddDefaultValue()
        {
            //Default Employee Details Added in studentList
            employeeList.Add(new EmployeeDetails("Ravi",DateOnly.Parse("11/11/1999"),"9958858888",Enum.Parse<Gender>("Male"),Enum.Parse<Branch>("Eymard"),Enum.Parse<Team>("Developer")));
            // Default Attendance Datails added in admission List
            attendanceList.Add(new AttendanceDetails("SF3001",new DateOnly(2022,05,15),	DateTime.Parse("09:00 AM"),	DateTime.Parse("06:10 PM"),	8));
            attendanceList.Add(new AttendanceDetails("SF3002",new DateOnly(2022,05,16),	DateTime.Parse("09:10 AM"),	DateTime.Parse("06:50 PM"),	8));
        }
    }
}