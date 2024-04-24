using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    /// <summary>
    /// DataType VaccineName used to Slect a instance of <see cref="Vaccine"/> Gender Information
    /// </summary>
    //enum
    public enum VaccineName{
        Covishield,Covaccine
    }
     //Class 
    /// <summary>
    /// Class Vaccine used to create instance for student <see cref="Vaccine"/>
    /// </summary>
    public class Vaccine
    {
        /*  a.	VaccineID {Auto Incremented ID – CID2001}
            b.	VaccineName {Enum – Covishield, Covaccine}
            c.	NoOfDoseAvailable
        */
        // Field
        private static int s_vaccineID=2000;
        //property
        public string VaccineID { get; }
        public VaccineName VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }
        //constructor
        public Vaccine(VaccineName vaccineName,int noOfDoseAvailable)
        {
            //Auto Increamentation
            s_vaccineID++;
            // Assigning Value to Property
            VaccineID="CID"+s_vaccineID;
            NoOfDoseAvailable=noOfDoseAvailable;
        }
        
        
        
        
        
        
    }
}