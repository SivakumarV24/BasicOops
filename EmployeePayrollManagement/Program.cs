using System;
using System.Collections.Generic;
namespace EmployeePayrollManagement;
class Program{
    public static void Main(string[] args)
    {
        int count=0;
        Program program=new Program();
        List<EmployeeDetails> employeeList=new List<EmployeeDetails>();
        bool flag=true;
        do{
            if(count==0)
            {
                Console.WriteLine("------------Main Menu------------");
                Console.WriteLine("1.Registration");
                Console.WriteLine("2.Login");
                Console.WriteLine("3.Exit");
                Console.WriteLine("---------------------------------");
            }
            int option=int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {          
                    string employeeId=program.Registration(employeeList);          
                    Console.WriteLine("------------Registration Successfull------------");
                    Console.WriteLine();
                    Console.WriteLine($"Your Customer Id : {employeeId}");
                    break;
                }
                case 2:
                {
                    (bool login,EmployeeDetails details)=program.Login(employeeList);
                    if(login)
                    {
                        Console.WriteLine("------------Login Successfull---------------");
                        Console.WriteLine();
                        Console.WriteLine($"Welcome {details.EmployeeName}.");  
                        bool submenuOption=true;
                        while(submenuOption)
                        {

                            Console.WriteLine("------------Enter the Option----------");
                            Console.WriteLine("1.Calculate Salary");
                            Console.WriteLine("2.Display Details");
                            Console.WriteLine("3. Exit");
                            Console.WriteLine("---------------------------------------");
                            int menuOption=int.Parse(Console.ReadLine());
                            switch(menuOption)
                            {
                                case 1:
                                {
                                    Console.WriteLine($"Salary : {program.CalculateSalary(details)}");
                                    break;
                                }
                                case 2:
                                {
                                    Console.WriteLine($"Employee Id : {details.EmployeeId}");
                                    Console.WriteLine($"Employee Name : {details.EmployeeName}");
                                    Console.WriteLine($"Role : {details.Role}");
                                    Console.WriteLine($"Work Location : {details.WorkLocation}");
                                    Console.WriteLine($"Team Name : {details.TeamName}");
                                    Console.WriteLine($"Date of Joining : {details.DateOfJoining}");
                                    Console.WriteLine($"Number of Working Days in Month : {details.NumberOfWorkingDayInMonth}");
                                    Console.WriteLine($"Number of leave Taken : {details.NumberofLeave}");
                                    Console.WriteLine($"Gender : {details.Gender}");
                                    Console.WriteLine();
                                    break;                          
                                }
                                case 3:
                                {
                                    Console.WriteLine("-----------------------------");
                                    submenuOption=false;
                                    break;
                                }
                                default :
                                {
                                    Console.WriteLine("--------------------------------------");
                                    Console.WriteLine("Your Enter Wrong Option! Enter Again");
                                    break;
                                }
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invaild EmployeeId");
                    }
                    break;
                }
                case 3:
                {
                    Console.WriteLine("------------Exit------------");
                    flag=false;
                    break;
                }
                default :
                {
                    Console.WriteLine("--------------------------------------");
                    Console.Write ("Your Enter Wrong Option! Enter  Again: ");
                    count=1;
                    break;
                }
            }

        }while(flag);
    }
    public string Registration(List<EmployeeDetails> list)
    {
        EmployeeDetails employeeDetail=new EmployeeDetails();
        System.Console.Write("Enter Your Employee Name : ");
        employeeDetail.EmployeeName=Console.ReadLine();
        Console.Write("Enter Your Role : ");
        employeeDetail.Role=Console.ReadLine();
        Console.Write("Enter Your Location Chennai Madurai Coimbatore : ");
        employeeDetail.WorkLocation=Enum.Parse<WorkLocation>(Console.ReadLine(),true);
        Console.Write("Enter Your Team name : ");
        employeeDetail.TeamName=Console.ReadLine();
        Console.Write("Enter yout Date of Joing (dd/MM/yyy): ");
        employeeDetail.DateOfJoining=DateOnly.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
        Console.Write("Enter Number of Working Days in Month : ");
        employeeDetail.NumberOfWorkingDayInMonth=int.Parse(Console.ReadLine());
        Console.Write("Enter Number of Leave Taken : ");
        employeeDetail.NumberofLeave=int.Parse(Console.ReadLine());
        Console.Write("Enter Gender Male Female : ");
        employeeDetail.Gender=Enum.Parse<Gender>(Console.ReadLine(),true);
        list.Add(employeeDetail);
        
        return employeeDetail.EmployeeId;
    }
    public (bool,EmployeeDetails) Login(List<EmployeeDetails> list)
    {
        EmployeeDetails data=null;
        bool flag=false;
        Console.Write("Enter Your EmployeeId : ");
        string empId=Console.ReadLine();
        empId=empId.ToUpper();
        foreach(EmployeeDetails details in list)
        {
            if(empId==details.EmployeeId)
            {
                data=details;
                flag=true;
                break;
            }
        }
        return (flag,data);
    }
    public int CalculateSalary(EmployeeDetails details)
    {
        int salaryPerDay=500;
        int totalSalary=0;
        totalSalary=(details.NumberOfWorkingDayInMonth-details.NumberofLeave)*salaryPerDay;
        return totalSalary;
    }
}