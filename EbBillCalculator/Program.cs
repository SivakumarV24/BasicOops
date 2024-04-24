using System;
using System.Collections.Generic;
namespace EbBillCalculator;
class Program{
    public static void Main(string[] args)
    {
        int count=0;
        Program program=new Program();
        UserDetails userDetails=new UserDetails();
        List<UserDetails> userList=new List<UserDetails>();
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
                    string meterId=program.Registration(userList);          
                    Console.WriteLine("------------Registration Successfull------------");
                    Console.WriteLine();
                    Console.WriteLine($"Your Customer Id : {meterId}");
                    break;
                }
                case 2:
                {
                    (bool login,UserDetails details)=program.Login(userList);
                    if(login)
                    {
                        Console.WriteLine("------------Login Successfull---------------");
                        Console.WriteLine();
                        Console.WriteLine($"Welcome {details.UserName}.");  
                        bool submenuOption=true;
                        while(submenuOption)
                        {

                            Console.WriteLine("------------Enter the Option----------");
                            Console.WriteLine("1.Calculate Amount");
                            Console.WriteLine("2.Display Details");
                            Console.WriteLine("3. Exit");
                            Console.WriteLine("---------------------------------------");
                            int menuOption=int.Parse(Console.ReadLine());
                            switch(menuOption)
                            {
                                case 1:
                                {
                                    Console.WriteLine($"Amount : {program.CalculateAmount(details)}");
                                    break;
                                }
                                case 2:
                                {
                                    Console.WriteLine($"Meter Id : {details.MeterId}");
                                    Console.WriteLine($"UserName : {details.UserName}");
                                    Console.WriteLine($"Phone Number : {details.PhoneNumber}");
                                    Console.WriteLine($"Mail Id : {details.MailId}");
                                    Console.WriteLine();
                                    break;                          
                                }
                                case 3:
                                {
                                    Console.WriteLine("-------------Exit------------");
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
    public string Registration(List<UserDetails> list)
    {
        UserDetails userDetails=new UserDetails();
        Console.Write("Enter UserName :");
        userDetails.UserName=Console.ReadLine();
        Console.Write("Enter Phone Number : ");
        userDetails.PhoneNumber=double.Parse(Console.ReadLine());
        Console.Write("Enter MailId : ");
        userDetails.MailId=Console.ReadLine();
        list.Add(userDetails);
        return userDetails.MeterId;
    }
    public (bool,UserDetails) Login(List<UserDetails> list)
    {
        bool flag=false;
        UserDetails details=null;
        Console.Write("Enter Meter Id : ");
        string id=Console.ReadLine();
        foreach(UserDetails obj in list)
        {
            if(id.Equals(obj.MeterId))
            {
                details=obj;
                flag=true;
                break;
            }
        }
        return (flag,details);
    }
    public float CalculateAmount(UserDetails details)
    {
        Console.Write("Enter Unit Details : ");
        float unit=float.Parse(Console.ReadLine());
        float amount=unit*5;
        return amount;
        
    }
}