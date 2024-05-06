using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApplication
{
    public static class Operations
    {
        public static CustomList<CustomerRegistration> customersList=new CustomList<CustomerRegistration>();
        public static CustomList<ProductDetails> productsList=new CustomList<ProductDetails>();
        public static CustomList<BookingDetails> bookingsList=new CustomList<BookingDetails>();
        public static CustomList<OrderDetails> ordersList=new CustomList<OrderDetails>();
        public static CustomerRegistration currentLoggedInCustomer;


        //Main Menu
        public static void MainMenu()
        {
             Console.WriteLine("****************Online Grocery Store*************");
            string mainChoice="yes";
            do
            {
                Console.WriteLine("Main Menu \n1. Customer Registration\n2. Customer Login\n3. Exit");
                Console.WriteLine("Enter Option : ");
                int mainOption=int.Parse(Console.ReadLine());
                switch(mainOption)
                {
                    case 1:
                    {
                        Console.WriteLine("************Registration Page************");
                        //Registration method
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("**************Login Page************");
                        //Login method
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Exiting Application");
                        mainChoice="no";
                        break;
                    }
                }
            }while (mainChoice=="yes");
        }

        //Registration method
        public static void Registration()
        {
            Console.Write("Enter your Name : ");
            string name=Console.ReadLine();
            Console.Write("Enter your father's name : ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your gender : ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your mobile number : ");
            string mobile=Console.ReadLine();
            Console.Write("Enter your Date of birth : ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter MailID :");
            string mailID=Console.ReadLine();
            
            
            double walletBalance=0.0;

            CustomerRegistration customer=new CustomerRegistration(name,fatherName,gender,mobile,dob,mailID,walletBalance);
            customersList.Add(customer);
            Console.WriteLine($"Customer registration successful. Your Customer ID: {customer.CustomerID}");
        }


        //Login method
        public static void Login()
        {
            Console.WriteLine("Enter the CustomerID : ");
            string loginID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach (CustomerRegistration customer in customersList)
            {
                if (loginID.Equals(customer.CustomerID))
                {
                    Console.WriteLine("You are logged in successfully");
                    flag=false;
                    currentLoggedInCustomer=customer;
                    //SubMenu method
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid CustomerID");
            }
        }


        //Sub Menu method
        public static void SubMenu()
        {
            string subChoice="yes";
            do
            {
                Console.WriteLine("SubMenu\n1. Show Customer Details\n2. Show Product Details\n3. Wallet Recharge\n4. Take Order\n5. Modify Order\n6. Cancel Order\n7. Show Wallet Balance\n8. Exit");
                Console.WriteLine("Enter Option : ");
                int subOption = int.Parse(Console.ReadLine());
                switch(subOption)
                {
                    case 1:
                    {
                        
                        ShowCustomerDetails();
                        break;
                    }
                    case 2:
                    {
                        
                        ShowProductDetails();
                        break;
                    }
                    case 3:
                    {
                        //Recharge method
                        Recharge();
                        
                        break;
                    }
                    case 4:
                    {
                        //Take Order
                        TakeOrder();
                        break;

                    }
                    case 5:
                    {
                        //Modify Order method
                        ModifyOrder();
                        break;
                    }
                    case 6:
                    {
                        //Cancel Order
                        CancelOrder();
                        break;
                    }
                    case 7:
                    {
                        //Show Wallet Balance method
                        WalletBalance();
                        break;
                    }
                    case 8:
                    {
                        Console.WriteLine("Exiting Sub Menu");
                        subChoice="no";
                        break;
                    }
                }
            } while (subChoice == "yes");

        }

        //Show Customer Details
        public static void ShowCustomerDetails()
        {
            foreach (CustomerRegistration customer in customersList)
            {
                if (currentLoggedInCustomer.CustomerID.Equals(customer.CustomerID))
                {
                    Console.WriteLine($"|{customer.CustomerID}|{customer.Name}|{customer.FatherName}|{customer.Gender}|{customer.PhoneNumber}|{customer.DOB}|{customer.MailID}|{customer.WalletBalance}");
                }
                
            }
        }

        //Show Product Details
        public static void ShowProductDetails()
        {
            foreach (ProductDetails product in productsList)
            {
                Console.WriteLine($"|{product.ProductID}|{product.ProductName}|{product.QuantityAvailable}|{product.PricePerQuantity}|");
            }
        }

       //Recharge method
       public static void Recharge()
       {
        Console.Write("Enter amount : ");
        double amount =double.Parse(Console.ReadLine());
        currentLoggedInCustomer.WalletRecharge(amount);
        Console.WriteLine($"Current Balance : {currentLoggedInCustomer.WalletBalance}");
       } 


        //Show Balance
        public static void WalletBalance()
        {
            Console.WriteLine($"Current Balance : {currentLoggedInCustomer.WalletBalance}");
        }


        //Take Order method
        public static void TakeOrder()
        {
            double amount=0.0;
            double totalAmount=0.0;
            Console.Write("Do you want to purchase  ,say yes or no : ");
            string wish=Console.ReadLine().ToLower();
            if (wish == "yes")
            {
                BookingDetails book = new BookingDetails(currentLoggedInCustomer.CustomerID, 0, DateTime.Now, BookingStatus.Initiated);
                bookingsList.Add(book);
                CustomList<OrderDetails> tempOrderList = new CustomList<OrderDetails>();
                string toBookMore="yes";
                do
                {

                    foreach (ProductDetails product in productsList)
                    {
                        Console.WriteLine($"|{product.ProductID}|{product.ProductName}|{product.QuantityAvailable}|{product.PricePerQuantity}|");
                    }

                    Console.Write("Enter the ProductID : ");
                    string customerProductID=Console.ReadLine().ToUpper();
                    bool flag=true;
                    
                    foreach (ProductDetails product in productsList)
                    {
                        if (customerProductID.Equals(product.ProductID))
                        {
                            Console.Write("Enter food Quantity you needed : ");
                            int quantity=int.Parse(Console.ReadLine());
                            if (quantity<=product.QuantityAvailable)
                            {
                                amount=product.PricePerQuantity*quantity;
                                totalAmount+=amount;
                                product.QuantityAvailable-=quantity;
                                OrderDetails product1=new OrderDetails(book.BookingID,product.ProductID,quantity,amount);
                                tempOrderList.Add(product1);
                            }
                            else
                            {
                                Console.WriteLine($"Quantity you asked is unavailable.Available quantity : {product.QuantityAvailable}");
                            }

                            flag=false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("Invalid ProductID");
                    }
                    Console.Write("Do you want to order more product, say yes or no : ");
                    toBookMore=Console.ReadLine().ToLower();

                } while (toBookMore == "yes");


                Console.Write("Do you want to confirm purchase, say yes or no : ");
                string option2="yes";
                string option1=Console.ReadLine().ToLower();
                if (option1=="yes")
                {
                    do
                    {
                        if (currentLoggedInCustomer.WalletBalance>=totalAmount)
                        {
                            currentLoggedInCustomer.DeductBalance(totalAmount);
                            book.TotalPrice=totalAmount;
                            book.BookingStatus=BookingStatus.Booked;
                            ordersList.AddRange(tempOrderList);
                            Console.WriteLine($"Your Total Bill amount is {book.TotalPrice}");
                            Console.WriteLine($"Successfully your booking has been Placed. Your booking ID : {book.BookingID}");
                            option2="no";
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Balance");
                            Console.Write("Are you willing to recharge your wallet : ");
                            string wishToRecharge=Console.ReadLine().ToLower();
                            if (wishToRecharge=="yes")
                            {
                                Console.Write("Enter amount : ");
                                double rechargeAmount=double.Parse(Console.ReadLine());
                                currentLoggedInCustomer.WalletRecharge(rechargeAmount);
                                Console.WriteLine($"Current Wallet Balance : {currentLoggedInCustomer.WalletBalance}");

                            }
                            else
                            {
                                //If customer say no to Recharge wallet
                                foreach (OrderDetails order in tempOrderList)
                                {
                                    foreach (ProductDetails product in productsList)
                                    {
                                        product.QuantityAvailable += order.PurchaseCount;
                                    }
                                }
                                option2="no";
                            }
                        }
                    }while (option2=="yes");



                }
                else
                {
                    //If customer say no to purchase order
                    foreach (OrderDetails order in tempOrderList)
                    {
                        foreach (ProductDetails product in productsList)
                        {
                            product.QuantityAvailable += order.PurchaseCount;
                        }
                    }
                }


            }
        }


        //Modify Order method
        public static void ModifyOrder()
        {
            foreach (BookingDetails book in bookingsList)
            {
                if (currentLoggedInCustomer.CustomerID.Equals(book.CustomerID) && book.BookingStatus==BookingStatus.Booked)
                {
                    Console.WriteLine($"|{book.BookingID}|{book.CustomerID}|{book.TotalPrice}|{book.DateOfBooking}|{book.BookingStatus}|");
                }
                
            }
            

            //Asking BookingID to modify 
            Console.Write("Enter the BookingID to be modified : ");
            string modifyBookingID=Console.ReadLine().ToUpper();
            //To validate it
            bool flag=true;
            foreach (BookingDetails book in bookingsList)
            {
                if (modifyBookingID.Equals(book.BookingID) && currentLoggedInCustomer.CustomerID.Equals(book.CustomerID) && book.BookingStatus==BookingStatus.Booked)
                {
                    flag=false;
                    foreach (OrderDetails order in ordersList)
                    {
                        if (modifyBookingID.Equals(order.BookingID))
                        {
                            Console.WriteLine($"|{order.OrderID}|{order.BookingID}|{order.ProductID}|{order.PurchaseCount}|{order.PriceOfOrder}|");
                        }
                        
                    }

                    //Asking orderID to modify
                    Console.Write("Enter order ID to modify : ");
                    string modifyOrderID=Console.ReadLine().ToUpper();
                    //to validate it
                    bool temp=true;
                    foreach (OrderDetails order in ordersList)
                    {
                        if (modifyOrderID.Equals(order.OrderID) && modifyBookingID.Equals(order.BookingID))
                        {
                            temp =false;
                            foreach (ProductDetails product in productsList)
                            {
                                if (order.ProductID.Equals(product.ProductID))
                                {
                                    Console.Write("Do you need to increase the quantity ,say yes or no : ");
                                    string toIncreaseQuantity=Console.ReadLine().ToLower();
                                    if (toIncreaseQuantity=="yes")
                                    {
                                        Console.Write("Enter the new quantity : ");
                                        int newQuantity=int.Parse(Console.ReadLine());

                                        if (newQuantity<=product.QuantityAvailable)
                                        {
                                            double newPriceAmount=product.PricePerQuantity*newQuantity;
                                            order.PriceOfOrder+=newPriceAmount;
                                            order.PurchaseCount+=newQuantity;
                                            book.TotalPrice+=newPriceAmount;
                                            product.QuantityAvailable-=newQuantity;
                                            string option1="yes";
                                            do
                                            {
                                                if (currentLoggedInCustomer.WalletBalance >= newPriceAmount)
                                                {
                                                    currentLoggedInCustomer.DeductBalance(newPriceAmount);
                                                    Console.WriteLine("Your booking has been Modified successfully");
                                                    Console.WriteLine($"Current Wallet Balance : {currentLoggedInCustomer.WalletBalance}");
                                                    option1="no";
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.Write("Are you willing to recharge your wallet : ");
                                                    string wishToRecharge = Console.ReadLine().ToLower();
                                                    if (wishToRecharge == "yes")
                                                    {
                                                        Console.Write("Enter amount : ");
                                                        double rechargeAmount = double.Parse(Console.ReadLine());
                                                        currentLoggedInCustomer.WalletRecharge(rechargeAmount);
                                                        Console.WriteLine($"Current Wallet Balance : {currentLoggedInCustomer.WalletBalance}");

                                                    }
                                                    else
                                                    {
                                                        option1="no";
                                                        break;
                                                    }
                                                }
                                            } while (option1 == "yes");

                                        }

                                    }
                                    else
                                    {
                                        Console.Write("Enter the new quantity : ");
                                        int newQuantity=int.Parse(Console.ReadLine());

                                        double newPriceAmount=product.PricePerQuantity*newQuantity;
                                        order.PriceOfOrder-=newPriceAmount;
                                        order.PurchaseCount-=newQuantity;
                                        book.TotalPrice-=newPriceAmount;
                                        product.QuantityAvailable+=newQuantity;
                                        currentLoggedInCustomer.WalletRecharge(newPriceAmount);
                                        Console.WriteLine("Your Order has been Modified successfully");
                                        Console.WriteLine($"Current Wallet Balance : {currentLoggedInCustomer.WalletBalance}");
                                    }
                                }
                            }
                        }
                    }
                    if (temp)
                    {
                        Console.WriteLine("Invalid order ID");
                    }
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid BookingID");
            }
        
        }


        //Cancel Order method
        public static void CancelOrder()
        {
            bool flag=true;
            foreach (BookingDetails book in bookingsList)
            {
                if (currentLoggedInCustomer.CustomerID.Equals(book.CustomerID) && book.BookingStatus.Equals(BookingStatus.Booked))
                {
                    flag=false;
                    Console.WriteLine($"|{book.BookingID}|{book.CustomerID}|{book.TotalPrice}|{book.DateOfBooking}|{book.BookingStatus}|");
                }
                
            }

            
            if (flag)
            {
                Console.WriteLine("No bookings found to cancel ");
            }

            if (!flag)
            {
                Console.Write("Enter booking ID to cancel : ");
                string cancelBookingID=Console.ReadLine().ToUpper();
                //validate booking ID
                bool temp=true;
                foreach (BookingDetails book in bookingsList)
                {
                    if (cancelBookingID.Equals(book.BookingID) && currentLoggedInCustomer.CustomerID.Equals(book.CustomerID) && book.BookingStatus.Equals(BookingStatus.Booked))
                    {
                        temp=false;
                        book.BookingStatus=BookingStatus.Cancelled;
                        currentLoggedInCustomer.WalletRecharge(book.TotalPrice);
                        Console.WriteLine("Your booking has been Cancelled successfully");
                        foreach (OrderDetails order in ordersList)
                        {
                            if (book.BookingID.Equals(order.BookingID))
                            {
                                foreach (ProductDetails product in productsList)
                                {
                                    if (order.ProductID.Equals(product.ProductID))
                                    {
                                        product.QuantityAvailable+=order.PurchaseCount;
                                    }

                                }
                            }

                        }


                    }
                }
                if (temp)
                {
                    Console.WriteLine("Invalid Order ID");
                }
            }
        }



        //Adding Default Values
        public static void AddingDefaultValues()
        {
            CustomerRegistration customer1=new CustomerRegistration("Ravi","Ettapparajan",Gender.Male,"974774646",new DateTime(1999,11,11),"ravi@gmail.com",10000);
            CustomerRegistration customer2=new CustomerRegistration("Baskaran","Sethurajan",Gender.Male,"847575775",new DateTime(1999,11,11),"baskaran@gmail.com",15000);
            customersList.Add(customer1);
            customersList.Add(customer2);

            //Displaying customer List
            foreach (CustomerRegistration customer in customersList)
            {
                Console.WriteLine($"|{customer.CustomerID}|{customer.Name}|{customer.FatherName}|{customer.Gender}|{customer.PhoneNumber}|{customer.DOB}|{customer.MailID}|{customer.WalletBalance}");
            }
            

            //Product Details
            ProductDetails product1=new ProductDetails("Sugar",20,40);
            ProductDetails product2=new ProductDetails("Rice",100,50);
            ProductDetails product3=new ProductDetails("Milk",10,40);
            ProductDetails product4=new ProductDetails("Coffee",10,10);
            ProductDetails product5=new ProductDetails("Tea",10,10);
            ProductDetails product6=new ProductDetails("Masala Powder",10,20);
            ProductDetails product7=new ProductDetails("Salt",10,10);
            ProductDetails product8=new ProductDetails("Turmeric Powder",10,25);
            ProductDetails product9=new ProductDetails("Chilli Powder",10,20);
            ProductDetails product10=new ProductDetails("Groundnut Oil",10,140);
            productsList.Add(product1);
            productsList.Add(product2);
            productsList.Add(product3);
            productsList.Add(product4);
            productsList.Add(product5);
            productsList.Add(product6);
            productsList.Add(product7);
            productsList.Add(product8);
            productsList.Add(product9);
            productsList.Add(product10);

            //Displaying products list
            foreach (ProductDetails product in productsList)
            {
                Console.WriteLine($"|{product.ProductID}|{product.ProductName}|{product.QuantityAvailable}|{product.PricePerQuantity}|");
            }

            BookingDetails book1=new BookingDetails("CID1001",220,new DateTime(2022,07,26),BookingStatus.Booked);
            BookingDetails book2=new BookingDetails("CID1002",400,new DateTime(2022,07,26),BookingStatus.Booked);
            BookingDetails book3=new BookingDetails("CID1001",280,new DateTime(2022,07,26),BookingStatus.Cancelled);
            BookingDetails book4=new BookingDetails("CID1002",0,new DateTime(2022,07,26),BookingStatus.Initiated);
            bookingsList.Add(book1);
            bookingsList.Add(book2);
            bookingsList.Add(book3);
            bookingsList.Add(book4);
            
            //displaying booking details
            foreach (BookingDetails book in bookingsList)
            {
                Console.WriteLine($"|{book.BookingID}|{book.CustomerID}|{book.TotalPrice}|{book.DateOfBooking}|{book.BookingStatus}|");
            }

            OrderDetails order1=new OrderDetails("BID3001","PID2001",2,80);
            OrderDetails order2=new OrderDetails("BID3001","PID2002",2,100);
            OrderDetails order3=new OrderDetails("BID3001","PID2003",1,40);
            OrderDetails order4=new OrderDetails("BID3002","PID2001",1,40);
            OrderDetails order5=new OrderDetails("BID3002","PID2002",4,200);
            OrderDetails order6=new OrderDetails("BID3002","PID2010",1,140);
            OrderDetails order7=new OrderDetails("BID3002","PID2009",1,20);
            OrderDetails order8=new OrderDetails("BID3003","PID2002",2,100);
            OrderDetails order9=new OrderDetails("BID3003","PID2008",4,100);
            OrderDetails order10=new OrderDetails("BID3003","PID2001",2,80);
            ordersList.Add(order1);
            ordersList.Add(order2);
            ordersList.Add(order3);
            ordersList.Add(order4);
            ordersList.Add(order5);
            ordersList.Add(order6);
            ordersList.Add(order7);
            ordersList.Add(order8);
            ordersList.Add(order9);
            ordersList.Add(order10);

            //displayinf order list
            foreach (OrderDetails order in ordersList)
            {
                Console.WriteLine($"|{order.OrderID}|{order.BookingID}|{order.ProductID}|{order.PurchaseCount}|{order.PriceOfOrder}|");
            }
            

        }
    }
}