using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagement
{
     //Class 
    /// <summary>
    /// Class AttendanceDEtails used to create instance for Employee <see cref="AttendanceDetails"/>
    /// </summary>
    public class AttendanceDetails
    {
        //Field
        /// <summary>
        /// static field s_id used to autoIncreamentation of the AttendanceID
        /// </summary>
        private static int s_id=1000;
        //Property
        /// <summary>
        /// AttendanceID used to store the AttendanceID
        /// </summary>
        public string AttendanceID { get;} // read Only
        /// <summary>
        /// EmployeeID used to store the EmployeeID
        /// </summary>
        /// <value></value>
        public string EmployeeID { get; set; }
        /// <summary>
        /// Date used to store the Date
        /// </summary>
        /// <value></value>
        public DateOnly Date { get; set; }
        /// <summary>
        /// CheckInTime used to store the CheckInTime
        /// </summary>
        /// <value></value>
        public DateTime CheckInTime { get; set; }
        /// <summary>
        /// CheckOutTime used to store the CheckoUTTime
        /// </summary>
        /// <value></value>
        public DateTime CheckOutTime { get; set; }
        /// <summary>
        /// HoursWorked used to store the HoursWorked
        /// </summary>
        /// <value></value>
        public int HoursWorked { get; set; }
        /// <summary>
        /// AttendanceDetaiils constructor used to assign the Default value to the proeperty
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <param name="checkInTime"></param>
        /// <param name="checkOutTime"></param>
        /// <param name="hoursWorked"></param>
        public AttendanceDetails(string employeeID,DateOnly date,DateTime checkInTime,DateTime checkOutTime,int hoursWorked)
        {
            s_id++;
            AttendanceID="AID"+s_id;
            EmployeeID=employeeID;
            Date=date;
            CheckInTime=checkInTime;
            CheckOutTime=checkOutTime;
            HoursWorked=hoursWorked;
        }
        /// <summary>
        /// AttendanceDetaiils constructor used to assign the Default value to the proeperty
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <param name="checkInTime"></param>
        public AttendanceDetails(string employeeID,DateOnly date,DateTime checkInTime)
        {
            s_id++;
            AttendanceID="AID"+s_id;
            EmployeeID=employeeID;
            Date=date;
            CheckInTime=checkInTime;   
        }
        
    }
}