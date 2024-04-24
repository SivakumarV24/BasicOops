using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce
{
    public static class Operations
    {
        // List created for  Customer Details,Product Details,Order Details,.
        static List<CustomerDetails> customerList = new List<CustomerDetails>();
        static List<ProductDetails> productList = new List<ProductDetails>();
        static List<OrderDetails> orderList = new List<OrderDetails>();
        // create a object for customerDetails to store currentuserDetails;
        static CustomerDetails currentUser;
        //Registration
        public static void Registration()
        {
            bool flag = true;
            // getting customer details from user.
            Console.WriteLine("       Welcome to registration      ");
            Console.WriteLine();
            // getting customer Name from user.
            Console.Write("Enter Customer Name : ");
            string name = "";
            while (flag)
            {
                name = Console.ReadLine();
                int count = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    if ((name[i] >= 'A' && name[i] <= 'Z') || (name[i] >= 'a' && name[i] <= 'z') || name[i] == ' ')
                    {
                        count++;
                    }
                }
                if (count == name.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You Entered Invaild Format !");
                    Console.Write("Name should Contain Alphabets. Enter Student Name : ");
                }
            }
            // getting Father Name from user.
            Console.Write("Enter City : ");
            flag = true;
            string city = "";
            while (flag)
            {
                city = Console.ReadLine();
                int count = 0;
                for (int i = 0; i < city.Length; i++)
                {
                    if ((city[i] >= 'A' && city[i] <= 'Z') || (city[i] >= 'a' && city[i] <= 'z') || city[i] == ' ')
                    {
                        count++;
                    }
                }
                if (count == city.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You Entered Invaild Format !");
                    Console.Write("city should Contain only Alphabets. Enter Student Name : ");
                }
            }
            // getting PhoneNumber
            Console.Write($"Enter 10 Digit Mobile Number : ");
            string phoneNumber = "";
            flag = true;
            while (flag)
            {
                phoneNumber = Console.ReadLine();
                int count = 0;
                if (phoneNumber.Length == 10)
                {
                    for (int i = 0; i < phoneNumber.Length; i++)
                    {
                        if (phoneNumber[i] >= '0' && phoneNumber[i] <= '9')
                        {
                            count++;
                        }
                    }
                }
                if (count == phoneNumber.Length)
                {
                    flag = false;
                    break;
                }
                else
                {
                    Console.WriteLine("You Entered Invaild Format !");
                    Console.Write("Number should Contain only Number with 10  digits. Enter Mobile Number : ");
                }
            }
            Console.Write($"Enter MailId (ex:name@mail.com) :");
            string mailId = "";
            flag = true;
            while (flag)
            {
                mailId = Console.ReadLine();
                if (mailId.Contains("@mail.com"))
                {
                    flag = false;
                }
                else
                {
                    Console.Write($"You Enter Invalid Format Enter Mail again (ex:name@mail.com): ");
                }
            }
            Console.Write($"Enter Wallet Balance : ");
            double walletBalance = double.Parse(Console.ReadLine());
            // Adding All details to object and store in list.
            CustomerDetails addCustomer = new CustomerDetails(name, city, phoneNumber, walletBalance, mailId);
            customerList.Add(addCustomer);
            Console.WriteLine($"Registration Successfully. Your Customer : {addCustomer.CustomerID} ");

        }
        //Login
        public static void Login()
        {
            bool flag = false;
            Console.WriteLine();
            Console.Write("Enter Your CustomerId : ");
            string customerId = Console.ReadLine();
            customerId = customerId.ToUpper();
            foreach (CustomerDetails customerDetails in customerList)
            {
                if (customerDetails.CustomerID == customerId)
                {
                    currentUser = customerDetails;
                    flag = true;
                    SubMenu();
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"invalid CustomerID");

            }
        }
        //Main Menu
        public static void MainMenu()
        {
            bool flag = true;
            bool condition = true;
            Console.WriteLine("    Welcome to SynCart");
            Console.WriteLine("    ------------------");
            Console.WriteLine();
            do
            {
                // Main Menu
                Console.WriteLine("       Main Menu     ");
                Console.WriteLine("       ---------     ");
                Console.WriteLine("1. Customer Registration");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                if (condition)
                {
                    Console.WriteLine("Enter the option Given Above : ");
                }
                else
                {
                    Console.WriteLine("You enter Wrong Option !. Enter the correct option Given Above : ");
                }
                // getting option from user.
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            // customer Registration
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            //Login
                            Login();
                            break;
                        }
                    case 3:
                        {
                            //Exit from Application
                            Console.WriteLine("------Thank You-----");
                            flag = false;
                            condition = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (flag);

        }
        //SubMenu
        public static void SubMenu()
        {
            Console.WriteLine();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine($"       Menu       ");
                Console.WriteLine();
                Console.WriteLine("a. Purchase");
                Console.WriteLine("b. Order History");
                Console.WriteLine("c. Cancel Order");
                Console.WriteLine("d. Wallet Balance");
                Console.WriteLine("e. Wallet reacharge");
                Console.WriteLine("f. Exit");
                Console.Write($"Enter the option Given Above: ");
                char character = char.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (character)
                {
                    case 'a':
                        {
                            //Purchase Product
                            Purchase();
                            break;
                        }
                    case 'b':
                        {
                            //Order History  
                            OrderHistory();
                            break;
                        }
                    case 'c':
                        {
                            // Cancel Order
                            CancelOrder();
                            break;
                        }

                    case 'd':
                        {
                            // wallet Balance
                            ShowBalance();
                            break;
                        }
                    case 'e':
                        {
                            // Recharge Wallet
                            WalletRecharge();
                            break;
                        }
                    case 'f':
                        {
                            // Exit from submenu
                            Console.WriteLine($"-----Exit From Menu-----");
                            Console.WriteLine();
                            flag = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Your enter Invalid Option !.");
                            break;
                        }
                }
            }
        }
        //Purchase
        public static void Purchase()
        {
            bool invaild = false;
            while (!invaild)
            {
                Console.WriteLine($"       Product List         ");
                Console.WriteLine();
                Console.WriteLine($"-------------------------------------------------------------------------------------------------");
                Console.WriteLine($"| ProductID |   ProductName   |Available Stock Quantity| Price Per Quantity | Shipping Duration |");
                Console.WriteLine($"-------------------------------------------------------------------------------------------------");
                foreach (ProductDetails list in productList)
                {
                    Console.WriteLine($"|{list.ProductID}    | {list.ProductName} | {list.Stock}              |  {list.Price}             |  {list.ShippingDuration}          |");
                    Console.WriteLine($"-------------------------------------------------------------------------------------------------------");
                }
                int deliveryCharge = 50;
                float totalAmount = 0;
                int valid = 0;
                Console.WriteLine();
                Console.Write($"Enter the ProductId to Purchase : ");
                string productId = Console.ReadLine();
                productId = productId.ToUpper();
                foreach (ProductDetails list in productList)
                {
                    if (productId == list.ProductID)
                    {
                        Console.Write($"Enter the Quantity to Purchase : ");
                        int quantity = int.Parse(Console.ReadLine());
                        valid = 1;
                        if (quantity <= list.Stock)
                        {
                            totalAmount = (quantity * list.Price) + deliveryCharge;

                            if (totalAmount <= currentUser.WalletBalance)
                            {
                                currentUser.DeductBalance(totalAmount);
                                list.Stock -= quantity;
                                DateTime date = DateTime.Now;
                                OrderDetails orderPlaced = new OrderDetails(currentUser.CustomerID, list.ProductID, totalAmount, date, quantity, Enum.Parse<OrderStatus>("Ordered"));
                                orderList.Add(orderPlaced);
                                Console.WriteLine();
                                Console.WriteLine($"Order Placed Successfully. Order ID: {orderPlaced.OrderID}");
                                date = date.AddDays((double)list.ShippingDuration);
                                Console.WriteLine($"Order placed successfully. Your order will be delivered on {date.ToString("dd/MM/yyyy")}");
                                Console.WriteLine();

                                invaild = true;
                            }
                            else
                            {
                                Console.WriteLine($"Insufficient Wallet Balance. Please recharge your wallet and do purchase again.");
                                invaild = true;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Required count not available. Current availability is {list.Stock} .");
                            invaild = true;
                            break;
                        }
                    }
                }
                if (valid == 0)
                {
                    Console.WriteLine($"Invalid ProductID !.");
                    Console.WriteLine();
                }
            }
        }
        //Show Order History
        public static void OrderHistory()
        {
            int valid = 0;
            Console.WriteLine();
            Console.WriteLine($"                  Order Details                      ");
            Console.WriteLine($"------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Order ID | Customer ID | Product ID | TotalPrice | Purchasedate | Quantity Purchased | Order Status|");
            Console.WriteLine($"------------------------------------------------------------------------------------------------------");
            foreach (OrderDetails list in orderList)
            {
                if (list.CustomerID == currentUser.CustomerID)
                {
                    valid = 1;
                    Console.WriteLine($"| {list.OrderID}  | {list.CustomerID}     | {list.ProductID}     | {list.TotalPrice}      | {list.PurchaseDate.ToString("dd/MM/yyyy")}   |     {list.Quantity}              | {list.OrderStatus}     |");
                    Console.WriteLine($"------------------------------------------------------------------------------------------------------");
                }
            }
            if (valid == 0)
            {
                Console.WriteLine($"No data Found");
                Console.WriteLine("");
            }
        }
        //Cancel Order
        public static void CancelOrder()
        {
            int valid = 0;
            Console.WriteLine();
            Console.WriteLine($"                  Order Details                      ");
            Console.WriteLine($"------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Order ID | Customer ID | Product ID | TotalPrice | Purchasedate | Quantity Purchased | Order Status|");
            Console.WriteLine($"------------------------------------------------------------------------------------------------------");
            foreach (OrderDetails list in orderList)
            {
                if (list.CustomerID == currentUser.CustomerID && list.OrderStatus == OrderStatus.Ordered)
                {
                    valid = 1;
                    Console.WriteLine($"| {list.OrderID}  | {list.CustomerID}     | {list.ProductID}     | {list.TotalPrice}      | {list.PurchaseDate.ToString("dd/MM/yyyy")}   |     {list.Quantity}              | {list.OrderStatus}     |");
                    Console.WriteLine($"------------------------------------------------------------------------------------------------------");
                }
            }
            if (valid == 0)
            {
                Console.WriteLine($"No data Found");
                Console.WriteLine();
            }
            else
            {
                int data = 0;
                Console.WriteLine();
                Console.WriteLine($"Enter The Product OrderID to Cancel : ");
                string orderID = Console.ReadLine();
                orderID = orderID.ToUpper();
                foreach (OrderDetails list in orderList)
                {
                    if (orderID == list.OrderID)
                    {
                        data = 1;
                        foreach (ProductDetails productDetail in productList)
                        {
                            if (productDetail.ProductID == list.ProductID)
                            {
                                productDetail.Stock += list.Quantity;
                                break;
                            }
                        }
                        currentUser.WalletBalance += list.TotalPrice;

                        list.OrderStatus = OrderStatus.Cancelled;
                        Console.WriteLine();
                        Console.WriteLine($"Order : {orderID} cancelled successfully");
                    }
                }
                if (data == 0)
                {
                    Console.WriteLine($"Invalid OrderId");
                }
            }
        }
        // Show Balance
        public static void ShowBalance()
        {
            Console.WriteLine();
            Console.WriteLine($"Wallet Balance : {currentUser.WalletBalance}");
            Console.WriteLine();
        }
        // WalletRecharge
        public static void WalletRecharge()
        {
            Console.WriteLine();
            Console.Write($"Do you Want to Recharge The Wallet.? Yes/No : ");
            bool valid = true;
            string response = "";
            while (valid)
            {
                response = Console.ReadLine();
                response = response.ToLower();
                if (response == "yes" || response == "no")
                {
                    valid = false;
                }
                else
                {
                    Console.Write($"You Entered Wrong Response.! Do you Want to Recharge The Wallet.? Yes/No ");
                }
            }
            if (response == "yes")
            {
                Console.WriteLine($"Enter The Amount to Recharge : ");
                double rechargeAmount = double.Parse(Console.ReadLine());
                double balance = currentUser.WalletRecharge(rechargeAmount);
                Console.WriteLine();
                Console.WriteLine($"Your Wallet Balance : {balance}");
            }
        }
        //AddDefaultValue()
        public static void AddDefaultValue()
        {
            //Default Customer Details Added in customerList
            customerList.Add(new CustomerDetails("Ravi", "chennai", "9885858588", 50000, "ravi@mail.com"));
            customerList.Add(new CustomerDetails("Baskaran", "chennai", "9888475757", 60000, "baskaran@mail.com"));
            // Default product details Added in productList
            productList.Add(new ProductDetails("Mobile (Samsung)", 10, 10000, 3));
            productList.Add(new ProductDetails("Tablet (Lenovo)", 5, 15000, 2));
            productList.Add(new ProductDetails("Camera (Sony)", 3, 20000, 4));
            productList.Add(new ProductDetails("iphone ", 5, 50000, 6));
            productList.Add(new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3));
            productList.Add(new ProductDetails("HeadPhone (Boat)", 5, 1000, 2));
            productList.Add(new ProductDetails("Speakers (Boat)", 4, 500, 2));
            // Default Admission Datails added in admission List
            orderList.Add(new OrderDetails("CID1001", "PID101", 20000, DateTime.Now, 2, Enum.Parse<OrderStatus>("Ordered")));
            orderList.Add(new OrderDetails("CID1002", "PID103", 40000, DateTime.Now, 2, Enum.Parse<OrderStatus>("Ordered")));
        }
    }
}