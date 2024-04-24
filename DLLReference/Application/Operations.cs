using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CollegeDetails;

namespace Application
{
    // Static Class
    public static class Operations
    {
        //Local object Created
        static StudentDetails currentLoggedInStudent;
        //Static List
        static List<StudentDetails> studentList = new List<StudentDetails>();
        static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        // Main Menu
        public static void MainMenu()
        {
            Console.WriteLine($"*********************Welcom to Syncfusion College********************");
            string mainChoice = "yes";
            do
            {
                // Need to show the main menu option
                Console.WriteLine($"MainMenu\n1. Registration\n2. Login\n3. Departmentwise Seat Availability\n4. Exit ");
                // Need to get an input from user and validate.
                int mainOption = int.Parse(Console.ReadLine());
                //Need tocreate mainmenu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine($"**********Student Registration***********");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"****************Login****************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"*******Departmentwise Seat Availability********");
                            DepartmentwiseSeatsAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine($"Application Exited Successfully");
                            mainChoice = "no";
                            break;
                        }
                }
                //Need to iterate until the option is exit.
            } while (mainChoice == "yes");
        }// Main menu ends
        //Student Registration
        public static void StudentRegistration()
        {
            // Need to get required Details
            Console.Write($"Enter Your Name : ");
            string studentName = Console.ReadLine();
            Console.Write($"Enter Your Father Name : ");
            string fatherName = Console.ReadLine();
            Console.Write($"Enter Your Date of Birth (dd/MM/yyyy) : ");
            DateTime dob = new DateTime();
            bool valid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            Console.Write($"Enter Your Gender (Male, Female, Transgender ) : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine($"Enter Your Physics Mark : ");
            int physicsMark = int.Parse(Console.ReadLine());
            Console.Write($"Enter Your Chemistry Mark : ");
            int chemistryMark = int.Parse(Console.ReadLine());
            Console.Write($"Enter Your Maths Mark : ");
            int mathsMark = int.Parse(Console.ReadLine());
            // Need to create an object
            StudentDetails studentDetails = new StudentDetails(studentName, fatherName, dob, gender, physicsMark, chemistryMark, mathsMark);
            // Need to store object in list
            studentList.Add(studentDetails);
            // Need to show StudentID
            Console.WriteLine($"Student Registered Successfully and StudentID is {studentDetails.StudentID}");
            Console.WriteLine();
        }// Student Registration ends.
        // Student Login
        public static void StudentLogin()
        {
            //Need to get Id input
            Console.WriteLine($"Enter Your StudentID : ");
            string loginID = Console.ReadLine().ToUpper();
            // Validate by its presence in the list.
            int flag = 0;
            foreach (StudentDetails student in studentList)
            {
                if (loginID.Equals(student.StudentID))
                {
                    flag = 1;
                    // Assigning current user to global Object
                    currentLoggedInStudent = student;
                    Console.WriteLine($"Logged In Successfully");
                    SubMenu();
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine($"Invalid StudentID or ID is not present");
            }

        }// Login Mehtod ends
        // Sub menu
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                // Need to show sub menu
                Console.WriteLine($"**********Sub Menu**********");
                Console.WriteLine($"1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. Show Admission Details\n 6. Exit");
                // Need to get input from user
                Console.WriteLine($"Enter Your option : ");
                int subOption = int.Parse(Console.ReadLine());
                //Need to create a structure
                switch (subOption)
                {
                    case 1:
                        {
                            Console.WriteLine($"************Check Elgibillity************");
                            CheckEligibility();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"*************Show Details****************");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"***************Take Admission***************");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine($"***************Cancel Admission***************");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine($"**************Admission Details***************");
                            ShowAdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine($"Taking back to MainMenu");
                            flag = false;
                            break;
                        }
                }
                // iterate until flag=false.                
            } while (flag);
        }//Submenu Ends
        // Check Eligibility
        public static void CheckEligibility()
        {
            // Need to get cutoff value as input
            Console.WriteLine($"Enter the CutOff Value : ");
            double cutOff = int.Parse(Console.ReadLine());
            // Need to check Eligible or not.
            if (currentLoggedInStudent.CheckEligibility(cutOff))
            {
                Console.WriteLine($"Student Are Eligible");
            }
            else
            {
                Console.WriteLine($"Student are Not Eligible");
            }

        }// Check Eligibility Check
        //Show Details
        public static void ShowDetails()
        {
            // Need to show current Student.
            Console.WriteLine($"|Student ID|Student Name | DOB   | Gender | Physics | Chemistry | Maths |");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}| ");
        }// Show Details end
        // Take Admission
        public static void TakeAdmission()
        {
            // Need to show available Department Details
            DepartmentwiseSeatsAvailability();
            // Need to ask Department Id from user.
            Console.WriteLine($"Enter DepartmentID : ");
            string departmentID=Console.ReadLine().ToUpper();            
            // Check the Id present or not
            int flag=0;
            foreach(DepartmentDetails department in departmentList)
            {
                if(departmentID.Equals(department.DepartmentID))
                {
                    flag=1;
                    // Check Student Eligibility
                    if(currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        // Check Seat Availability
                        if(department.NumberOfSeats>0)
                        {
                            // Check student already taken Admission
                            bool alreadyTaken=false;
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedInStudent.StudentID.Equals(admission.AdmissionID) && admission.AdmissionStatus==AdmissionStatus.Admitted)
                                {
                                    alreadyTaken=true;
                                }
                            }
                            if(!alreadyTaken)
                            {
                                // Reduce Seat Count.
                                department.NumberOfSeats-=1;
                                // if not taken create a Admission object
                               
                                AdmissionDetails takeAdmission=new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted); 
                                // Add to the AdmissionList
                                admissionList.Add(takeAdmission);
                                // Display the AdmissionId
                                Console.WriteLine($"Admission took successfully. Your admission ID – {takeAdmission.AdmissionID}");
                            }
                            else
                            {
                                Console.WriteLine($"You are already Taken Admission");                              
                            }
             
                        }
                        else
                        {
                            Console.WriteLine($"Seats Not Available");
                            break;                           
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine($"You are Not Eligible due to low cutOff");
                        break;                      
                    }                  
                }
                break;
            }
            if(flag==0)
            {
                Console.WriteLine($"Invalid DepartmentID");                
            }
           
        }// Take Admission ends
        // Cancel Admission
        public static void CancelAdmission()
        {
            int count=0;
            // Need to check Admission Detailsm is Admitted
            foreach (AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus==AdmissionStatus.Admitted)
                {                    
                    // Need to change Admission Status from Admitted to Cancelled.
                    count++;
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    foreach (DepartmentDetails department in departmentList)
                    {
                        if(department.DepartmentID.Equals(admission.DepartmentID))
                        {
                            //return the seat to department.
                            department.NumberOfSeats+=1;
                            break;
                        }                       
                    }
                    break;
                }
            }
            if(count==0)
            {
                Console.WriteLine($"We have No Admission to cancel");                
            }
            else
            {
                Console.WriteLine($"Admission cancelled successfully");                
            }
        }//Cancel Admission end
        // Show Admission Details
        public static void ShowAdmissionDetails()
        {
            // Need to show current Logged In Student's Admission Details.
            int flag = 0;
            Console.WriteLine($"|Admission ID | Student ID | Department ID | Admission Date | Admission Status |");
            foreach (AdmissionDetails admission in admissionList)
            {
                if (admission.StudentID.Equals(currentLoggedInStudent.StudentID))
                {
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}|");
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine($"No Data Found");
            }
        }// ShowAdmissionDetails end
        // Departmentwise Seats Availability
        public static void DepartmentwiseSeatsAvailability()
        {
            //Need to show all Department Details
            Console.WriteLine($"| DepartmentID | DepartmentName | NumberOfSeats");
            int flag = 0;
            foreach (DepartmentDetails department in departmentList)
            {
                if (department.NumberOfSeats > 0)
                {
                    Console.WriteLine($"|{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}|");
                    flag = 1;

                }
            }
            if (flag == 0)
            {
                Console.WriteLine($"No Data Found");
            }
        }
        // Adding Default Data
        public static void AddDefaultData()
        {
            StudentDetails studentDetails1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails studentDetails2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            studentList.Add(studentDetails1);
            studentList.Add(studentDetails2);
            /*  studentList.Add(new StudentDetails("Ravichandran E","Ettapparajan", new DateTime(1999,11,11),Gender.Male,95,95,95));
                studentList.Add(new StudentDetails("Baskaran S","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95));*/
            DepartmentDetails departmentDetails1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails departmentDetails2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails departmentDetails3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails departmentDetails4 = new DepartmentDetails("ECE", 30);
            departmentList.AddRange(new List<DepartmentDetails> { departmentDetails1, departmentDetails2, departmentDetails3, departmentDetails4 });
            AdmissionDetails admissionDetails1 = new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 5, 11), AdmissionStatus.Admitted);
            AdmissionDetails admissionDetails2 = new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 5, 11), AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissionDetails> { admissionDetails1, admissionDetails2 });

            Console.WriteLine();

            Console.WriteLine();
           
            Console.WriteLine();
        }
    }
}