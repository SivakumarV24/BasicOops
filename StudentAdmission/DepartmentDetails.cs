using System;
using System.Collections.Generic;
namespace StudentAdmission
{
    //Class 
    /// <summary>
    /// Class DepartmentDEtails used to create instance for student <see cref="DepartmentDetails"/>
    /// </summary>
    public class DepartmentDetails
    {
        // field
        /// <summary>
        /// static Field s_id used to autoincreament DepartmentID  of the instance of <see cref="DepartmentDetails"/>
        /// </summary>
        private static int s_id=100;
        // property
        public string DepartmentID { get; }
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }
        // Constructor
        public DepartmentDetails(){}
        public DepartmentDetails(string departmentName,int Totalseat)
        {
            // Auto increamentation
            s_id++;
            // Assigning value to property
            DepartmentID="DID"+s_id;
            DepartmentName=departmentName;
            NumberOfSeats=Totalseat;
        }
       
        
    }
}