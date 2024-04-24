using System;
namespace CollegeDetails
{
    public enum AdmissionStatus{
        Select,Admitted,Cancelled
    }
    public class AdmissionDetails
    {
        /*  a.	AdmissionID – (Auto Increment ID - AID1001)
            b.	StudentID
            c.	DepartmentID
            d.	AdmissionDate
            e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
        */
        //Field
        private static int s_admissionID=100;
        //property
        public string AdmissionID { get; } // Read Only
        public string StudentID { get; set; } 
        public string DepartmentID { get;set; } 
        public DateTime AdmissionDate { get;set;} 
        public AdmissionStatus AdmissionStatus { get; set; }
        //Constructor 
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,AdmissionStatus admissionStatus)
        {
            // Auto increamentation
            s_admissionID++;
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }      
    }
}