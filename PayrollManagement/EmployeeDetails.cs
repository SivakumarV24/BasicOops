using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PayrollManagement
{
    /// <summary>
    /// DataType Gender used to Slect a instance of <see cref="EmployeeDetails"/> Gender Information
    /// </summary>
    public enum Gender{
        Default,
        Male,
        Female,
        Transgender
    }
    /// <summary>
    /// DataType Branch used to Slect a instance of <see cref="EmployeeDetails"/> Gender Information
    /// </summary>
    public enum Branch{
        Default,
        Eymard,
        Karuna,
        Madhura
    }
    /// <summary>
    /// DataType Branch used to Slect a instance of <see cref="EmployeeDetails"/> Gender Information
    /// </summary>
    public enum Team{
        Default,
        Network,
        Hardware,
        Developer,
        Facility
    }
     //Class 
    /// <summary>
    /// Class EmployeeDetails used to create instance for Employee <see cref="EmployeeDetails"/>
    /// </summary>
    public class EmployeeDetails
    {
        //Field
        public static int s_id=3000;
        
        public string EmployeeID { get; }
        public string FullName { get; set; }
        public DateOnly DOB { get; set; }
        public string MobileNumber { get; set; }
        public Gender Gender { get; set; }
        public Branch Branch { get; set; }
        public Team Team { get; set; }
        public EmployeeDetails(string fullName,DateOnly dob,string mobileNumber,Gender gender,Branch branch,Team team)
        {
            s_id++;
            EmployeeID="SF"+s_id;
            FullName=fullName;
            DOB=dob;
            MobileNumber=mobileNumber;
            Gender=gender;
            Branch=branch;
            Team=team;
        }
        
    }
    
}