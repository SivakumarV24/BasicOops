using System;
using System.Collections.Generic;
namespace StudentAdmission
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool flag=true;
            bool condition=true;
            // List created for  studentList,DepartmentList,AdmissionList.
            List<StudentDetails> studentList=new List<StudentDetails>();
            List<DepartmentDetails> departmentList=new List<DepartmentDetails>();
            List<AdmissionDetails> admissionList=new List<AdmissionDetails>();
            // Create a object for classes.
            Program program=new Program();
            DepartmentDetails departmentDetails=new DepartmentDetails();
            //Default Student Details Added in studentList
            studentList.Add(new StudentDetails("Ravichandran E","Ettapparajan",DateOnly.Parse("11/11/1999"),Enum.Parse<Gender>("Male"),95,95,95));
            studentList.Add(new StudentDetails("Baskaran S","Sethurajan",DateOnly.Parse("11/11/1999"),Enum.Parse<Gender>("Male"),95,95,95));
            // Default department and seat added in departmentList
            departmentList.Add(new DepartmentDetails("EEE",29));
            departmentList.Add(new DepartmentDetails("CSE",29));
            departmentList.Add(new DepartmentDetails("MECH",30));
            departmentList.Add(new DepartmentDetails("ECE",30));
            // Default Admission Datails added in admission List
            admissionList.Add(new AdmissionDetails("SF3001","DID101",DateOnly.Parse("11/05/2022"),Enum.Parse<AdmissionStatus>("Booked")));
            admissionList.Add(new AdmissionDetails("SF3002","DID102",DateOnly.Parse("12/05/2022"),Enum.Parse<AdmissionStatus>("Booked")));
            //Welcom to Syncfusion Colleger Of Engineering and Technology.
            Console.WriteLine("        Welcome to SCET");
            Console.WriteLine("       ----------------");
            Console.WriteLine();
            do{
                // Main Menu
                Console.WriteLine("       Main Menu     ");
                Console.WriteLine("       ---------     ");
                Console.WriteLine("1. Student Registration");
                Console.WriteLine("2. Student Login");
                Console.WriteLine("3. Department wise seat availability");
                Console.WriteLine("4. Exit");
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
                        // student Registration
                        string studentId=program.StudentRegistration(studentList);
                        Console.WriteLine($"Student Registered Successfully and StudentID is {studentId}. ");
                        break;
                    }
                    case 2:
                    {
                        StudentDetails details=new StudentDetails();
                        // Student Login
                        (bool login,StudentDetails studentDetails)=program.Login(studentList);
                        if(login)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Welcome {studentDetails.StudentName}.");
                            Console.WriteLine();
                            bool toPerfromOperation=true;
                            while(toPerfromOperation)
                            {
                                Console.WriteLine($"       Menu       ");
                                Console.WriteLine();
                                Console.WriteLine("a. Check Eligibility");
                                Console.WriteLine("b. Show Datails");
                                Console.WriteLine("c. Take Admission");
                                Console.WriteLine("d. Cancel Admission");
                                Console.WriteLine("e. Show Admission Details");
                                Console.WriteLine("f. Exit");
                                Console.Write($"Enter the option Given Above: ");
                                char character=char.Parse(Console.ReadLine());
                                Console.WriteLine();                                
                                switch(character)
                                {
                                    case 'a':
                                    {
                                        // Checck Eligibility
                                        Console.WriteLine($"      Check Eligibility     ");
                                        Console.WriteLine();                      
                                        if(details.CheckEligibility(studentDetails.Physics,studentDetails.Chemistry,studentDetails.Maths))
                                        {
                                            Console.WriteLine($"You are Eligible :-)");                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine($"You are Not Eligibale :-(");                                            
                                        }
                                        break;
                                    }
                                    case 'b':
                                    {
                                        // Show StudentDetails
                                        program.ShowStudentDetails(studentDetails);
                                        break;                 
                                    }
                                    case 'c':
                                    {
                                        // Take Admission
                                        bool process=true;
                                        while(process)
                                        {
                                            // Get Department Id from user
                                            program.ShowDepartmentDetails(departmentList);
                                            Console.WriteLine();
                                            Console.WriteLine($"Enter DepartmentId :  ");        
                                            string departmentId=Console.ReadLine().ToUpper();
                                            int availableSeat=0;
                                            string department="";
                                            int valid=0;
                                            // validate the Department Id;
                                            foreach(DepartmentDetails list in departmentList)
                                            {
                                                if(list.DepartmentID==departmentId)
                                                {
                                                    availableSeat=list.NumberOfSeats;
                                                    department=list.DepartmentName;
                                                    valid=1;
                                                    break;
                                                }
                                            }
                                            if(valid==0)
                                            {
                                                Console.WriteLine($"Invalid DepartmentID !.");   
                                            }
                                            else
                                            {
                                                // if valid check eligiblity And Check seats are available
                                                bool alreadyTaken=false;
                                                if(studentDetails.CheckEligibility(studentDetails.Physics,studentDetails.Chemistry,studentDetails.Maths))
                                                {
                                                    if(availableSeat>0)
                                                    {
                                                        // Check Student already taken or not
                                                        foreach(AdmissionDetails list in admissionList)
                                                        {
                                                            if(list.StudentID==studentDetails.StudentID)
                                                            {
                                                                alreadyTaken=true;
                                                            }
                                                        }
                                                        if(!alreadyTaken)
                                                        {
                                                            // if not taken create a object for AdmissionDetils and add Student Details
                                                            Console.WriteLine($"Your are Eligible For this Department.");
                                                            Console.WriteLine();            
                                                            AdmissionStatus  admissionStatus=AdmissionStatus.Select;
                                                            bool status=false;
                                                            while(!status)
                                                            {
                                                                Console.WriteLine($"Please Enter either 'Booked' to Confirm your Booking or  'Cancelled' to cancel it ");
                                                                status=Enum.TryParse<AdmissionStatus>(Console.ReadLine(),true,out admissionStatus);
                                                                if(!status)
                                                                {
                                                                    Console.WriteLine($"Your Enter invalid Response !.");
                                                                }
                                                            }
                                                            if(admissionStatus==AdmissionStatus.Booked)
                                                            {
                                                               
                                                                foreach(DepartmentDetails list in departmentList)
                                                                {
                                                                    if(list.DepartmentID==departmentId)
                                                                    {
                                                                        list.NumberOfSeats=list.NumberOfSeats-1;
                                                                        break;
                                                                    }
                                                                }
                                                                DateOnly todayDate=DateOnly.FromDateTime(DateTime.Now);
                                                                AdmissionDetails newAdmission=new AdmissionDetails(studentDetails.StudentID,department,todayDate,admissionStatus);
                                                                Console.WriteLine();
                                                                admissionList.Add(newAdmission);
                                                                Console.WriteLine($"Admission took successfully. Your admission ID - {newAdmission.AdmissionID}.");                                                                
                                                                process=false;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine($"You Cancelled Your Admission :-(");
                                                                Console.WriteLine();
                                                                Console.WriteLine($"Thank You :-)");
                                                                process=false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // If already Taken 
                                                            Console.WriteLine($"You Already took Admission !");
                                                            process=false;
                                                            
                                                        }
                                                    }
                                                    else
                                                    {
                                                        // No seats are avilable
                                                        Console.WriteLine($"Seat Not Available For  this Department");
                                                        Console.WriteLine();                                                        
                                                        Console.WriteLine($"Try to Choose Other DepartmentID");
                                                        
                                                    }
                                                }
                                                else
                                                {
                                                    // Not Eligible
                                                    Console.WriteLine($"You Are Not eligible For This Department");
                                                    process=false;
                                                    
                                                }
                                            }
                                        }
                                        break;
                                    }
                                    case 'd':
                                    {
                                        // Cancel Admission
                                        Console.WriteLine($"      Admission Ddetails       ");
                                        Console.WriteLine();
                                        Console.WriteLine($"----------------------------------------------------------------------------");
                                        Console.WriteLine($"| AdmissionId | StudentID | DepartmentId | AdmissionDate | AdmissionStatus |");                                    
                                        Console.WriteLine($"----------------------------------------------------------------------------");
                                        int data=0;
                                        string departmentId="";
                                        foreach(AdmissionDetails list in admissionList)
                                        {
                                            if(studentDetails.StudentID==list.StudentID && list.AdmissionStatus==AdmissionStatus.Booked)
                                            {
                                                departmentId=list.DepartmentID;
                                                Console.WriteLine($"| {list.AdmissionID,-10}     | {list.StudentID}    | {list.DepartmentID}       | {list.AdmissionDate.ToString("dd/MM/yyyy")}    | {list.AdmissionStatus}          | ");
                                                Console.WriteLine($"-------------------------------------------------------------------------");
                                                Console.WriteLine();
                                                AdmissionStatus admissionStatus=AdmissionStatus.Select;
                                                bool status=false;
                                                while(!status)
                                                {
                                                    Console.WriteLine($"Please Enter 'Cancelled' to cancel it ");
                                                    status=Enum.TryParse<AdmissionStatus>(Console.ReadLine(),true,out admissionStatus);
                                                    if(!status)
                                                    {
                                                        Console.WriteLine($"Your Enter invalid Response !.");
                                                    }
                                                }
                                                list.AdmissionStatus=AdmissionStatus.Cancelled;
                                                data=1;
                                            }
                                        }
                                        if(data==0)
                                        {
                                            Console.WriteLine($"No Data Found");
                                            Console.WriteLine();                                                                                       
                                        }
                                        else
                                        {
                                            foreach(DepartmentDetails list in departmentList)
                                            {
                                                if(list.DepartmentID==departmentId)
                                                {
                                                    list.NumberOfSeats=list.NumberOfSeats+1;
                                                }
                                            }
                                            Console.WriteLine($"Admission Cancelled Successfully");
                                        }                                    
                                        break;
                                    }
                                    case 'e':
                                    {
                                        // Admission Details
                                        Console.WriteLine($"----------------------------------------------------------------------------");
                                        Console.WriteLine($"| AdmissionId | StudentID | DepartmentId | AdmissionDate | AdmissionStatus |");
                                    
                                        Console.WriteLine($"----------------------------------------------------------------------------");
                                        foreach(AdmissionDetails list in admissionList)
                                        {
                                            if(studentDetails.StudentID==list.StudentID)
                                            {
                                                Console.WriteLine($"| {list.AdmissionID}     | {list.StudentID}    | {list.DepartmentID}       | {list.AdmissionDate.ToString("dd/MM/yyyy")}    | {list.AdmissionStatus}          | ");
                                                Console.WriteLine($"---------------------------------------------------------------------------");
                                            }
                                        }
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
                        else
                        {
                            Console.WriteLine("Invalid StudentID");
                        }
                        break;
                    }
                    case 3:
                    {
                        //Department wise seat availability
                        program.ShowDepartmentDetails(departmentList);
                        break;
                    }
                    case 4:
                    {
                        //Exit from Application
                        Console.WriteLine("------Thank You-----");
                        flag=false;
                        condition=false;
                        break;
                    }
                    default :
                    {
                        break;
                    }
                }
            }while(flag);
        }
        // Student Registration Method
        public string StudentRegistration(List<StudentDetails> studentList)
        {
            bool flag=true;
            StudentDetails studentDetails=new StudentDetails();
            // getting student details from user.
            Console.WriteLine("       Welcome to registration      ");
            Console.WriteLine();
            // getting Student Name from user.
            Console.Write("Enter Student Name : ");
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
            // getting Father Name from user.
            Console.Write("Enter Father Name : ");
            flag=true;
            string fatherName="";
            while(flag)
            {
                fatherName=Console.ReadLine();
                int count=0;
                for(int i=0;i<fatherName.Length;i++)
                {
                    if((fatherName[i]>='A' && fatherName[i]<='Z')||(fatherName[i]>='a'&& fatherName[i]<='z')||fatherName[i]==' ')
                    {
                        count++;
                    }
                }
                if(count==fatherName.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You Entered Invaild Format !");
                    Console.Write("Name should Contain only Alphabets. Enter Student Name : ");
                }
            }
            // getting DOB from user.
            Console.Write("Enter Date of Birth (dd/MM/yyyy) : ");
            DateOnly date=new DateOnly();
            bool valid=false;
            while(!valid)
            {
                valid=DateOnly.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",out date);
                if(!valid)
                {
                    Console.Write("Invalid Format!.Enter Correct Date Format (dd/MM/yyyy) : ");
                }
            }
            // getting Gender from user.
            Console.Write("Enter Gender - Male, Female, Transgender : ");
            valid=false;
            Gender gender=Gender.Select;
            while(!valid)
            {
               valid=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
               if(!valid)
               {
                Console.Write("You Entered Invalid Gender!.Enter Gender Agin (Male,Female,Transgender) : ");
               }
            }
            // getting Physics Mark from user.
            Console.Write("Enter Physics Mark : ");
            valid=false;
            float physicsMark=0;
            while(!valid)
            {
                valid=float.TryParse(Console.ReadLine(),null,out physicsMark);
                if(physicsMark>=0 && physicsMark<=100)
                {
                    valid=true;
                }
                else
                {
                    Console.Write("Mark should be Number 1 to 100.Enter Physics Mark Again : ");
                    valid=false;
                }

            }
            // getting Chemistry Mark from user.
            Console.Write("Enter Chemistry Mark : ");
             valid=false;
            float chemistryMark=0;
            while(!valid)
            {
                valid=float.TryParse(Console.ReadLine(),null,out chemistryMark);
                if(chemistryMark>=0 && chemistryMark<=100)
                {
                    valid=true;
                }
                else
                {
                    Console.Write("Mark should be Number 1 to 100.Enter Chemistry Mark Again : ");
                    valid=false;
                }

            }
            // getting Maths Mark from user.
            Console.Write("Enter Maths Mark : ");
             valid=false;
            float mathsMark=0;
            while(!valid)
            {
                valid=float.TryParse(Console.ReadLine(),null,out mathsMark);
                if(mathsMark>=0 && mathsMark<=100)
                {
                    valid=true;
                }
                else
                {
                    Console.Write("Mark should be Number 1 to 100.Enter Maths Mark Again : ");
                    valid=false;
                }
            }
            // set value to the studentDetails property
            studentDetails.StudentName=name;
            studentDetails.FatherName=fatherName;
            studentDetails.DOB=date;
            studentDetails.Gender=gender;
            studentDetails.Physics=physicsMark;
            studentDetails.Chemistry=chemistryMark;
            studentDetails.Maths=mathsMark;
            // Add studentDetails object to studentList
            studentList.Add(studentDetails);
            // return StudentId;
            return studentDetails.StudentID;        
        }
        // Student Login Method
        public (bool,StudentDetails) Login(List<StudentDetails> studentList)
        {
            StudentDetails details=null;
            bool flag=false;
            Console.WriteLine("Welcome to Login");
            Console.WriteLine();
            Console.Write("Enter Your StudentID : ");
            string studentId=Console.ReadLine();
            studentId=studentId.ToUpper();
            foreach (StudentDetails studentDetails in studentList)
            {
                if(studentDetails.StudentID==studentId)
                {
                    details=studentDetails;
                    flag=true;
                }
            }
            return (flag,details);
        }
        public void ShowStudentDetails(StudentDetails details)
        {
            Console.WriteLine($"      Student Details    ");
            Console.WriteLine();
            Console.WriteLine($"------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| StudentID | StudentName    | FatherName         | DOB           | Gender     | Physics   | Chemistry   | Maths   |");           
            Console.WriteLine($"------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| {details.StudentID}    |  {details.StudentName}   |  {details.FatherName}      |  {details.DOB}   |   {details.Gender}     |     {details.Physics}    |     {details.Chemistry}      | {details.Maths}     | ");
            Console.WriteLine();
        }
        public void ShowAdmissionDetails(List<AdmissionDetails> admissionDetailsList)
        {
            bool flag=true;
            Console.WriteLine($"----------------------------------------------------------------------------");
            Console.WriteLine($"| AdmissionId | StudentID | DepartmentId | AdmissionDate | AdmissionStatus |");           
            Console.WriteLine($"----------------------------------------------------------------------------");
            foreach(AdmissionDetails list in admissionDetailsList)
            {
                Console.WriteLine($"| {list.AdmissionID}     | {list.StudentID}    | {list.DepartmentID}       | {list.AdmissionDate}    | {list.AdmissionStatus}          | ");
                Console.WriteLine($"------------------------------------------------------------------------------------");
                flag=false;
            }
            if(flag)
            {
                Console.WriteLine($"No Data Found");                
            }
        }
        public void ShowDepartmentDetails(List<DepartmentDetails> details)
        {
            Console.WriteLine($"--------------------------------------------------------------");
            Console.WriteLine($"| Departmet Id | Department Name | Numner of Seats Available |");            
            Console.WriteLine($"--------------------------------------------------------------");            
            foreach(DepartmentDetails list in details)
            {
                Console.WriteLine($"|    {list.DepartmentID}    |      {list.DepartmentName}        |           {list.NumberOfSeats}              |");
                Console.WriteLine($"-------------------------------------------------------------- ");                
            }      
        }
    }
}