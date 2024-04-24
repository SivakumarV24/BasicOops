using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
    public enum Gender
    {
        Male,
        Female
    }
    
    public enum WorkLocation
    {
        Chennai,
        Coimbatore,
        Madurai
    }
    public class EmployeeDetails
    {
        private static int s_Id=1000;
        public EmployeeDetails()
        {
            s_Id++;
            EmployeeId="SF"+s_Id;
        }
        public string EmployeeId { get; set; }
        public String EmployeeName { get; set; }
        public string Role { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public int NumberOfWorkingDayInMonth {get; set;}
        public int NumberofLeave { get; set; }
        public Gender Gender {get; set;}
    }
}