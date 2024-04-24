using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VaccinationDrive
{
    public static class Operations
    {
        // Create a static list 
        static List<Beneficiary> beneficiaryList=new List<Beneficiary>();
        static List<Vaccination> vaccinationList=new List<Vaccination>();
        static List<Vaccine> vaccineList=new List<Vaccine>();
        //object
        static Beneficiary currentBeneficiary;
        // Methods
        // Main Menu Method
        public static void MainMenu()
        {
            /*
            1.	Beneficiary Registration
            2.	Login 
            3.	Get Vaccine Info
            4.	Exit

            */
            // show application name
            Console.WriteLine($"*************Vaccination Drive**********");
            //iterate until Exit
            bool flag=true;
            do
            {
                Console.WriteLine($"Main Menu\n1. Beneficiary Registration\n2. Login\n3. Get Vaccine Info\n 4. EXit");
                Console.WriteLine($"Enter the option given Above : ");
                int mainOption=int.Parse(Console.ReadLine());
                //Main Menu structure
                switch(mainOption)
                {
                    case 1:
                    {
                        //Beneficiary Registration
                        Console.WriteLine($"***********Welcome To Beneficiary Registration************");
                        BeneficiaryRegistration();                        
                        break;
                    }
                    case 2:
                    {
                        // Beneficiary Login
                        Console.WriteLine($"******************Welcom to Login*********************");
                        BeneficiaryLogin();
                        break;
                    }
                    case 3:
                    {
                        // Get Vaccine Info
                        Console.WriteLine($"****************Vaccine Info*****************");
                        GetVaccineInfo();                        
                        break;
                    }
                    case 4:
                    {
                        // Exit from Application.
                        flag=false;
                        Console.WriteLine($"Exit From Application");
                        break;                        
                    }
                    default:
                    {
                        Console.WriteLine($"Invalid Option !.");
                        break;
                    }
                }                 
            } while (flag);
            // Show Main Menu

        }//main Menu End
        //BeneficiaryRegistration method
        public static void BeneficiaryRegistration()
        {
            /*
            a.	Name
            b.	Age
            c.	Gender
            d.	Mobile Number
            e.	City
*/
            //Need to get Details from user
            Console.Write($"Enter Your Name : ");
            string name=Console.ReadLine();
            Console.Write($"Enter Your age : ");
            int age=int.Parse(Console.ReadLine());
            Console.Write($"Enter Your gender (Male, Female, Transgender)");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write($"Enter Your Mobile Number : ");
            string mobileNumber=Console.ReadLine();
            Console.Write($"Enter Your City : ");
            string city=Console.ReadLine();
            // Details are stored in BeneficiaryObject
            Beneficiary beneficiaryDetails=new Beneficiary(name,age,gender,mobileNumber,city);
            //BeneficiaryObject add in list
            beneficiaryList.Add(beneficiaryDetails);
            // Show BeneficiaryObject
            Console.WriteLine($"Registration successfully. Your Registration Number : {beneficiaryDetails.RegistrationNumber} . ");               
        }//BeneficiaryRegistration method end
        //BeneficiaryLogin Method end
        //Sub Menu
        public static void SubMenu()
        {
                 /*
                1.	Show My Details
                2.	Take Vaccination
                3.	My Vaccination History
                4.	Next Due Date
                5.	Exit
                */
            bool flag=true;
            do
            {
                //Show Submenu
                Console.WriteLine($"Sub Menu\n1. Show My Details\n2. Take vaccination\n3. My Vaccination History\n4. Next Due Date\n5. Exit");
                Console.WriteLine($"Enter the Option Given Above : ");                
                int subOption=int.Parse(Console.ReadLine());
                switch(subOption)
                {
                    case 1:
                    {
                        // Display My Details
                        ShowMyDetails();
                        break;
                    }
                    case 2:
                    {
                        // Take Vaccination
                        VaccinationTaken();
                        break;
                    }
                    case 3:
                    {
                        // My Vaccination History
                        VaccinationHistory();
                        break;
                    }
                    case 4:
                    {
                        //Next Due
                        NextDUe();
                        break;
                    }
                    case 5:
                    {
                        // Exit From SubMenu
                        flag=false;
                        Console.WriteLine($"*****Exit From Submenu*****");
                        break;                        
                    }
                    default:
                    {
                        // Invalid Option !.
                        Console.WriteLine($"Invalid Option!");
                        break;
                    }
                }
                
            } while (flag);            
        }//Submenun method end
        // ShowMyDetails method
        public static void ShowMyDetails()
        {
            Console.WriteLine($"Rgistration Number : {currentBeneficiary.RegistrationNumber} ");
            Console.WriteLine($"Name : {currentBeneficiary.Name} ");
            Console.WriteLine($"Age :  {currentBeneficiary.Age}");
            Console.WriteLine($"Gender :  {currentBeneficiary.Gender}");
            Console.WriteLine($"Mobile :  {currentBeneficiary.MobileNumber}");
            Console.WriteLine($"City : {currentBeneficiary.City}");    
        }
        // Take Vaccination method
        public static void VaccinationTaken()
        {
            // Show Vaccine Details
            Console.WriteLine($"-----------------------------------------------------------------");
            Console.WriteLine($"|{"VaccineID",-10}|{"VaccineName",-10}|{"NoOfDoseAvailable",-10}|");
            Console.WriteLine($"-----------------------------------------------------------------");
            foreach (Vaccine list in vaccineList)
            {
                Console.WriteLine($"|{list.VaccineID,-10}|{list.VaccineName,-10}|{list.NoOfDoseAvailable,-10}|");                
            }
            // Get Vaccine Id from user
            Console.WriteLine($"Enter VaccineID : ");
            string vaccineID=Console.ReadLine();
            int flag=0;
            // Check validId or not
            foreach (Vaccine list in vaccineList)
            {
                if(list.VaccineID.Equals(vaccineID))
                {
                    flag=1;
                    // Check if beneficiary take any vaccine
                    int valid=0;
                    foreach(Vaccination vaccinationhistory in vaccinationList)
                    {
                        if(vaccinationhistory.RegistrationNumber==currentBeneficiary.RegistrationNumber && vaccinationhistory.VaccineID==vaccineID)
                        {
                            valid++;
                        }
                    }
                    if(valid==0)
                    {
                        if(currentBeneficiary.Age>14)
                        {
                            Vaccination addVaccinationDetails=new Vaccination(currentBeneficiary.RegistrationNumber,vaccineID,1,DateTime.Now);
                            vaccinationList.Add(addVaccinationDetails);
                            list.NoOfDoseAvailable-=1;
                            Console.WriteLine($"VaccinationSuccessful");
                            
                        }
                    }
                    else if(valid==1 || valid==2)
                    {
                        DateTime lastvaccinationDate=new DateTime();
                        foreach(Vaccination vaccinationhistory in vaccinationList)
                        {
                            if(vaccinationhistory.RegistrationNumber==currentBeneficiary.RegistrationNumber && vaccinationhistory.VaccineID ==vaccineID)
                            {
                                lastvaccinationDate=vaccinationhistory.VaccinatedDate;
                            }
                        }
                        DateTime today=DateTime.Now;
                        TimeSpan span=today-lastvaccinationDate;
                        int days=span.Days;
                        if(days>=30)
                        {
                            Vaccination addVaccinationDetails=new Vaccination(currentBeneficiary.RegistrationNumber,vaccineID,valid+1,DateTime.Now);
                            vaccinationList.Add(addVaccinationDetails);
                            list.NoOfDoseAvailable-=1;
                            Console.WriteLine($"VaccinationSuccessful");
                        }
                        else
                        {
                            Console.WriteLine($"You Vaccinated On {lastvaccinationDate}.After 30 Days.You have procced to take next vaccine");
                            
                        }
                    }
                    else if(valid==3)
                    {
                        Console.WriteLine($"All the three Vaccination are completed, you cannot be vaccinated now");
                        
                    }
                }               
            }
            if(flag==0)
            {
                Console.WriteLine($"Invalid Vaccine ID");
                
            }              
        }
        //My vaccination History method
        public static void VaccinationHistory()
        {
            Console.WriteLine($"VaccinationID|RegisterNumber|VaccineID|DoseNumber|VaccinatedDate");
            
            foreach (Vaccination list in vaccinationList)
            {
                if(currentBeneficiary.RegistrationNumber==list.RegistrationNumber)
                {
                    Console.WriteLine($"|{list.VaccinationID}|{list.RegistrationNumber}|{list.VaccineID}|{list.DoseNumber}|{list.VaccinatedDate}|");
                }                
            }
        }
        // Next Due Method
        public static void NextDUe()
        {
            DateTime lastVaccinationDate=new DateTime();
            int dose=0;
            foreach (Vaccination list in vaccinationList)
            {
                if(currentBeneficiary.RegistrationNumber==list.RegistrationNumber)
                {
                    lastVaccinationDate=list.VaccinatedDate;
                    dose=list.DoseNumber;
                }                
            }
            if(dose==0)
            {
                Console.WriteLine($"you can take vaccine now");
                
            }
            else if(dose==1 || dose==2)
            {
                DateTime nextDue=lastVaccinationDate.AddDays(30);
                Console.WriteLine($"Next Due Date : {nextDue.ToString("dd/MM/yyyy")}");                
            }
            else if(dose==3)
            {
                Console.WriteLine($"You have completed all vaccination. Thanks for your participation in the vaccination drive.");                
            }
        }
        public static void BeneficiaryLogin()
        {
            //get input from user.
            int flag=0;
            Console.Write($"Enter Your Registration Number : ");
            string registrationNumber=Console.ReadLine().ToUpper();
            // check the Registration number is present or not.
            foreach (Beneficiary detail in beneficiaryList)
            {
                if(registrationNumber.Equals(detail.RegistrationNumber))
                {
                    flag=1;
                    // detail are stored in beneficiary.
                    currentBeneficiary=detail;
                    SubMenu();
                    break;
                }
            }
            if(flag==0)
            {
                Console.WriteLine($"Invalid Registration NUmber.");                
            }
            

        }//BeneficiaryLogin Method end
        //GetVaccineInfo Method
        public static void GetVaccineInfo()
        {
            Console.WriteLine($"-------------------------------------");
            Console.WriteLine($"|Vaccine Name   | NoOfDoseAvailable |");
            Console.WriteLine($"-------------------------------------");           
            foreach (Vaccine list in vaccineList)
            {
                Console.WriteLine($"|{list.VaccineName}     |        {list.NoOfDoseAvailable}         |");
            }
        }//GetVaccineInfo end
        // Add DefaultDetails Method
        public static void AddDefaultDetails()
        {
            Beneficiary beneficiary=new Beneficiary("Ravichandran",	21,Gender.Male,	"8484484","Chennai");
            Beneficiary beneficiaryone=new Beneficiary("Baskaran",22,Gender.Male,	"8484747","Chennai");
            beneficiaryList.AddRange(new List<Beneficiary>(){beneficiary,beneficiaryone});
            vaccineList.Add(new Vaccine(VaccineName.Covishield,50));
            vaccineList.Add(new Vaccine(VaccineName.Covaccine,50));
            Vaccination vaccination=new Vaccination(beneficiary.RegistrationNumber,"CID2001",1, new DateTime(2021,11,11));
            Vaccination vaccinationOne=new Vaccination(beneficiary.RegistrationNumber,"CID2001",2,new DateTime(2022,3,11));
            Vaccination vaccinationTwo=new Vaccination(beneficiaryone.RegistrationNumber,"CID2002",1,new DateTime(2022,4,4));
            vaccinationList.AddRange(new List<Vaccination>(){vaccination,vaccinationOne,vaccinationTwo});

        }// AddDefaultDetails end

    }
}