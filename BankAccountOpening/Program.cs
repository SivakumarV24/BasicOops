using System;
using System.Collections.Generic;

namespace BankAccountOpening;
class Program{
    public static void Main(string[] args)
    {
        int response=1;
        int count=0;
        List<Object> list=new List<Object>();
        Program program=new Program();
        while(response>0)
        {
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
                    string custId=program.Registration(list);
                    
                    Console.WriteLine("------------Registration Successfull------------");
                    Console.WriteLine();
                    Console.WriteLine($"Your Customer Id : {custId}");
                    response=1;
                    break;
                }
                case 2:
                {
                    
                    (bool login,CustomerDetails details)=program.Login(list);
                    if(login)
                    {
                        Console.WriteLine("------------Login Successfull---------------");
                        Console.WriteLine();
                        Console.WriteLine($"Welcome {details.CustomerName}.");  
                        bool submenuOption=true;
                        while(submenuOption)
                        {

                            Console.WriteLine("------------Enter the Option----------");
                            Console.WriteLine("1.Deposit");
                            Console.WriteLine("2.Withdraw");
                            Console.WriteLine("3.Check balance");
                            Console.WriteLine("4.exit");
                            Console.WriteLine("---------------------------------------");
                            int menuOption=int.Parse(Console.ReadLine());
                            switch(menuOption)
                            {
                                case 1:
                                {
                                    program.Deposit(details);
                                    break;
                                }
                                case 2:
                                {
                                    program.Withdraw(details);
                                    break;
                                }
                                case 3:
                                {
                                    program.BalanceCheck(details);
                                    break;
                                }
                                case 4:
                                {
                                    Console.WriteLine("------------------------------------");
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
                        Console.WriteLine("Invaild CustomerId");
                    }
                    response=1;
                    break;
                }
                case 3:
                {
                    Console.WriteLine("------------Exit------------");
                    response=0;
                    break;
                }
                default :
                {
                    Console.WriteLine("--------------------------------------");
                    Console.Write ("Your Enter Wrong Option! Enter  Again: ");
                    count=1;
                    response=1;
                    break;
                }
            }
        }
    }
    public string Registration(List<object> list)
    {
        CustomerDetails customerList=new CustomerDetails();
        Console.WriteLine("------------Welcome to Registration------------");
        Console.WriteLine();
        Console.Write("Enter Customer name: ");
        int count=0;
        string customerName="";
        customerName=Console.ReadLine();
        customerList.CustomerName=customerName;
        Console.WriteLine("Select Gender Male Female Transgender : ");
        Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
        customerList.Gender=gender;
        Console.Write("Enter Phone Number: ");
        double phoneNumber=0;
        bool  number=false;
        while(!number)
        {
            phoneNumber=double.Parse(Console.ReadLine());
            string num=phoneNumber.ToString();
            if(num.Length==10)
            {
                number=true;
            }
            else
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("You Enter invalid format Enter again: ");
            }
        }
        customerList.PhoneNumber=phoneNumber;
        Console.Write("Enter Mail Id: ");
        bool mail=false;
        string mailId="";
        while(!mail)
        {
             mailId=Console.ReadLine();
            if(mailId.Contains("@gmail.com"))
            {
                mail=true;
            }
            else
            {
                Console.WriteLine("--------------------------------------");
                Console.Write("You Enter invalid format Enter again: ");
            }
        }
        DateOnly date=new DateOnly();
        bool temp=false;
        count=0;
        while(!temp)
        {
            if(count==0)
            {
                Console.Write("Enter Date of Birth (dd/MM/yyyy): ");
                count++;
            }
            else
            {
                Console.WriteLine("----------------------------------------------------");
                Console.Write("Your Enter invalid format! Enter Again (dd/MM/yyyy): ");

            }
            temp=DateOnly.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out date);
        }
        customerList.DateOfBirth=date;
        list.Add(customerList);
        return customerList.CustomerId;
    }
    public (bool,CustomerDetails) Login(List<object> list)
    {
        bool login=false;
        CustomerDetails detail=null;
        Console.WriteLine("------------Login------------");
        Console.Write("Enter Customer Id: ");
        string Id=Console.ReadLine();
        Id=Id.ToUpper();
        foreach(CustomerDetails details in list)
        {
            if(details.CustomerId==Id)
            {
                detail=details;
                login =true;
            }
        }
        return (login,detail);
        

    }
    public void Deposit(CustomerDetails customer)
    {
        Console.WriteLine("Enter the Amount to Deposit: ");
        float Deposit=float.Parse(Console.ReadLine());
        customer.Balance=customer.Balance+Deposit;
        Console.WriteLine(" ----------------------------------------");
        Console.WriteLine($"|       Total Balance :    {customer.Balance} | ");
        Console.WriteLine(" ----------------------------------------");
    }
    public void Withdraw(CustomerDetails customer)
    {
        Console.WriteLine("Enter the Amount to Withdraw: ");
        float withdraw=float.Parse(Console.ReadLine());
        customer.Balance=customer.Balance-withdraw;        
        Console.WriteLine(" ----------------------------------------");
        Console.WriteLine($"|       Total Balance :     {customer.Balance}  | ");
        Console.WriteLine(" ----------------------------------------");
    }
    public void BalanceCheck(CustomerDetails customer)
    {
        Console.WriteLine(" ----------------------------------------");
        Console.WriteLine($"|        Total Balance :   {customer.Balance} |");   
        Console.WriteLine(" ----------------------------------------");

    }
}