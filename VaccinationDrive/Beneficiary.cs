using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    //Enum
    /// <summary>
    /// DataType Gender used to Slect a instance of <see cref="Beneficiary"/> Gender Information
    /// </summary>
    public enum Gender{
        Male,Female,Others
    }
    //Class 
    /// <summary>
    /// Class Beneficiary used to create instance for student <see cref="Beneficiary"/>
    /// Refer Doucumentation on <see href="www.syncfusion.com"/>
    /// </summary>
    public class Beneficiary
    {
        /*  a.	Registration Number (Auto Incremented BID1001)
            b.	Name
            c.	Age
            d.	Gender (Enum [Male, Female, Others])
            e.	Mobile Number
            f.	City
        */
        //Field
        private static int s_registrationNumber=1000;
        // Property
        public string RegistrationNumber { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
        //Constructor
        public Beneficiary(string name,int age,Gender gender,string mobileNumber,string city)
        {
            //Auto Increamentation
            s_registrationNumber++;
             // Assigning Value to Property
            RegistrationNumber="BID"+s_registrationNumber;
            Name=name;
            Age=age;
            Gender=gender;
            MobileNumber=mobileNumber;
            City=city;
        }
        
        
        
        
        
        
        
        
        
        
        
        
    }
}