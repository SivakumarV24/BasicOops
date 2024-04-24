using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    //Class 
    /// <summary>
    /// Class Vaccination used to create instance for student <see cref="Vaccination"/>
    /// </summary>
    public class Vaccination
    {
        /*  •	VaccinationID (Auto increment – VID3001)
            •	Registration Number (Beneficiary Reg. num)
            •	VaccineID
            •	DoseNumber – (1,2,3)
            •	Vaccinated Date (DateTime.Now)
            */
        //Field
        private static int s_vaccinationID=3000;
        //property
        public string VaccinationID { get; }
        public string RegistrationNumber { get; set; }
        public string VaccineID { get; set; }
        public int DoseNumber { get; set; }
        public DateTime VaccinatedDate { get; set; }
        //constructor
        public Vaccination(string  registrationNumber,string vaccineID,int doseNumber,DateTime vaccinatedDate)
        {
            //Auto increamentation
            s_vaccinationID++;
            // Assigning Value to Property
            VaccinationID="VID"+s_vaccinationID;
            RegistrationNumber=registrationNumber;
            VaccineID=vaccineID;
            DoseNumber=doseNumber;
            VaccinatedDate=vaccinatedDate;
        }
        
        
        
        
        
        
        
        
        
    }
}