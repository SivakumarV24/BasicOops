using System;
namespace StudentAdmission
{
    /// <summary>
    /// DataTyep Gender used to Slect a instance of <see cref="StudentDetails"/> Gender Information
    /// </summary>
    public enum Gender{
        Select,
        Male,
        Female,
        Transgender
    }
    //Class 
    /// <summary>
    /// Class SudentDetails used to create instance for student <see cref="StudentDetails"/>
    /// </summary>
    public class StudentDetails
    {
        // Field
        /// <summary>
        /// static Field s_id used to autoincreament StudentID  of the instance of <see cref="StudentDetails"/>
        /// </summary>
        private static int s_id=3000;
         /// <summary>
        /// StudentID Property used to store StudentID
        /// </summary>
        public string StudentID { get; }
        /// <summary>
        /// StudentName Property used to store StudentName.
        /// </summary>
        /// <value></value>
        public string StudentName { get; set; }
        /// <summary>
        /// FatherName Property used to Store FatherName.
        /// </summary>
        /// <value></value>
        public string FatherName { get; set; }
        /// <summary>
        /// DOB used to Store DOB
        /// </summary>
        /// <value> Format : dd/MM/yyyy  DateType : DateOnly</value>
        public DateOnly DOB { get; set; }
        /// <summary>
        /// Gender used to Store Gender
        /// </summary>
        /// </summary>
        /// <value>Value : Male, Female, Transgender</value>
        public Gender Gender { get; set; }
        /// <summary>
        ///  Physics used to store PhysicsMark
        /// </summary>
        /// <value>DateType : </value>
        public float Physics { get; set; }
        public float Chemistry { get; set; }
        public float Maths {get; set; }
        // Constructor
        /// <summary>
        /// StudentDetails Construction used to initialize default values to its Properties. <see cref="StudentDetails"/>
        /// </summary>
        public StudentDetails(){
            s_id++;
            StudentID="SF"+s_id;
        }
        /// <summary>
        /// StudentDetails Construction used to store Default value.That value are stored in Property <see cref="StudentDetails"/>
        /// </summary>
        /// <param name="studentName">studentName used to initialize parameter values to StudentName property</param>
        /// <param name="fatherName">fatherName used to initialize parameter values to FatheName property</param>
        /// <param name="dob">dob used to initialize parameter values to DOB property</param>
        /// <param name="gender">gender used to initialize parameter values to Gender property</param>
        /// <param name="physics">physics used to initialize parameter values to Physics property</param>
        /// <param name="chemistry">chemistry used to initialize parameter values to Chemistry property</param>
        /// <param name="maths">maths used to initialize parameter values to Maths property</param>
        public StudentDetails(string studentName,string fatherName,DateOnly dob,Gender gender,float physics,float chemistry,float maths)
        {
            s_id++;
            // Assigning value to property
            StudentID="SF"+s_id;
            StudentName=studentName;
            FatherName=fatherName;
            DOB=dob;
            Gender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }
       
        /// <summary>
        /// Method CheckEligibility to find average of physics,chemistry,maths mark and find eligibility <see cref="StudentDetails"/>
        /// </summary>
        /// <param name="Physics">Physics to store a physics Mark</param>
        /// <param name="Chemistry">Chemistry to store a chemistry Mark</param>
        /// <param name="Maths">Maths to store a mathsMark</param>
        /// <returns>Return true if eligible,Return false if not eligible</returns>
        public bool CheckEligibility(float Physics,float Chemistry,float Maths)
        {
            float average=(Physics+Chemistry+Maths)/3;
            if(average>=75.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Method ShowStudentDetails used to Display StudentDetails of instance of <see cref="StudentDetails"/>
        /// </summary>
        /// <param name="details">details to store a studentDetails of instance</param>
        /// Methods
        public void ShowStudentDetails(StudentDetails details)
        {
            
            Console.WriteLine($"      Student Details    ");
            Console.WriteLine();
            Console.WriteLine($"------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| StudentID | StudentName    | FatherName         | DOB           | Gender     | Physics   | Chemistry   | Maths   |");           
            Console.WriteLine($"------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| {details.StudentID}    |  {details.StudentName}   |  {details.FatherName}      |  {details.DOB}   |   {details.Gender}     |     {details.Physics}    |     {details.Chemistry}      | {details.Maths}     | ");
            Console.WriteLine();
        }
    }
}