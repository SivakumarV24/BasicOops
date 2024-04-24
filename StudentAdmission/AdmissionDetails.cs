using System;
using System.Collections.Generic;
namespace StudentAdmission
{
    /// <summary>
    /// DateType AdmissionStatus is used to store a AdmissionStatus (Booked, Cancelled ) <see cref="AdmissionDetails"/>
    /// </summary> 
    public enum AdmissionStatus{
        Select,
        Booked,
        Cancelled
    }
    //Class 
    /// <summary>
    /// Class AdmissionDetails used to create instance for student <see cref="AdmissionDetails"/>
    /// </summary>
    public class AdmissionDetails
    {
        /// <summary>
        /// static Field s_id used to autoincreament AdmissionDetails  of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
         private static int s_id=1000;
         // Property
        public string AdmissionID { get; set; }
        public string StudentID { get; }
        public string DepartmentID { get; set; }
        public DateOnly AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }
         // constuctors
        public AdmissionDetails(){}
        public AdmissionDetails(string studentId,string departmentId,DateOnly admissionDate,AdmissionStatus admissionStatus)
        {
            // Auto increamentation
            s_id++;
            // Assigning value to property
            AdmissionID="AID"+s_id;
            StudentID=studentId;
            DepartmentID=departmentId;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }    
       
                
    }
}