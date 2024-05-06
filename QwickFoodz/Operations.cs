using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class Operations
    {
        public static CustomList<CustomerDetails> customerDetailsList=new CustomList<CustomerDetails>();
        public static CustomList<FoodDetails> foodDetailsList=new CustomList<FoodDetails>();
        public static CustomList<OrderDetails> orderDetailsList=new CustomList<OrderDetails>();
        public static CustomList<ItemDetails> itemDetailsList=new CustomList<ItemDetails>();
        public static CustomerDetails currentLoggedInCustomer;


        //Main Menu method
        public static void MainMenu()
        {
            Console.WriteLine("****************Qwick Foodz*************");
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
            Console.Write("Enter your location : ");
            string location=Console.ReadLine();
            
            double walletBalance=0.0;

            CustomerDetails customer=new CustomerDetails(name,fatherName,gender,mobile,dob,mailID,location,walletBalance);
            customerDetailsList.Add(customer);
            Console.WriteLine($"Customer registration successful. Your Customer ID: {customer.CustomerID}");


        }


        //Login method
        public static void Login()
        {
            Console.WriteLine("Enter the CustomerID : ");
            string loginID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach (CustomerDetails customer in customerDetailsList)
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


        //SubMenu method
        public static void SubMenu()
        {
            string subChoice="yes";
            do
            {
                Console.WriteLine("SubMenu\n1. Show Profile\n2. Order Food\n3. Cancel Order\n4. Modify Order\n5. Order History\n6. Recharge wallet\n7. Show Wallet Balance\n8. Exit");
                Console.WriteLine("Enter Option : ");
                int subOption = int.Parse(Console.ReadLine());
                switch(subOption)
                {
                    case 1:
                    {
                        //Show Profile
                        ShowProfile();
                        break;
                    }
                    case 2:
                    {
                        //Order Food method
                        OrderFood();
                        break;
                    }
                    case 3:
                    {
                        //Cancel Order
                        CancelOrder();
                        break;
                    }
                    case 4:
                    {
                        //Modify Order method
                        ModifyOrder();
                        break;

                    }
                    case 5:
                    {
                        //Order History method
                        OrderHistory();
                        break;
                    }
                    case 6:
                    {
                        //Recharge method
                        Recharge();
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


        //Show Profile method
        public static void ShowProfile()
        {
            foreach (CustomerDetails customer in customerDetailsList)
            {
                if (currentLoggedInCustomer.CustomerID.Equals(customer.CustomerID))
                {
                    Console.WriteLine($"|{customer.CustomerID}|{customer.Name}|{customer.FatherName}|{customer.Gender}|{customer.Mobile}|{customer.DOB}|{customer.MailID}|{customer.Location}|{customer.WalletBalance}");
                }
                
            }
        }


        //Order History method
        public static void OrderHistory()
        {
            bool flag=true;
            foreach (OrderDetails order in orderDetailsList)
            {
                if (currentLoggedInCustomer.CustomerID.Equals(order.CustomerID))
                {
                    flag=false;
                    Console.WriteLine($"|{order.OrderID}|{order.CustomerID}|{order.TotalPrice}|{order.DateOfOrder}|{order.OrderStatus}|");
                }
                
            }
            if (flag)
            {
                Console.WriteLine("No Orders found");
            }
        }


        //Recharge Wallet method 
        public static void Recharge()
        {
            Console.Write("Enter amount : ");
            double amount=double.Parse(Console.ReadLine());
            currentLoggedInCustomer.WalletRecharge(amount);
            Console.WriteLine($"Current Wallet Balance : {currentLoggedInCustomer.WalletBalance}");
        }


        //Show Wallet Balance method
        public static void WalletBalance()
        {
            Console.WriteLine($"Wallet Balance of customer : {currentLoggedInCustomer.WalletBalance}");
        }


        //Order Food method
        public static void OrderFood()
        {
            double amount=0.0;
            double totalAmount=0.0;
            Console.Write("Do you want order food from Qwick Foodz ,say yes or no : ");
            string wish=Console.ReadLine().ToLower();
            if (wish == "yes")
            {
                OrderDetails order = new OrderDetails(currentLoggedInCustomer.CustomerID, 0, DateTime.Now, OrderStatus.Initiated);
                orderDetailsList.Add(order);
                CustomList<ItemDetails> localItemList = new CustomList<ItemDetails>();
                string toOrderMore="yes";
                do
                {
                    //display the food items
                    foreach (FoodDetails food in foodDetailsList)
                    {
                        Console.WriteLine($"|{food.FoodID}|{food.FoodName}|{food.PricePerQuantity}|{food.QuantityAvailable}");
                    }

                    Console.Write("Enter the foodID : ");
                    string customerFoodID=Console.ReadLine().ToUpper();
                    bool flag=true;
                    //To validate foodId
                    foreach (FoodDetails food in foodDetailsList)
                    {
                        if (customerFoodID.Equals(food.FoodID))
                        {
                            Console.Write("Enter food Quantity you needed : ");
                            int quantity=int.Parse(Console.ReadLine());
                            if (quantity<=food.QuantityAvailable)
                            {
                                amount=food.PricePerQuantity*quantity;
                                totalAmount+=amount;
                                food.QuantityAvailable-=quantity;
                                ItemDetails food1=new ItemDetails(order.OrderID,food.FoodID,quantity,amount);
                                localItemList.Add(food1);
                            }
                            else
                            {
                                Console.WriteLine($"Quantity you asked is unavailable.Available quantity : {food.QuantityAvailable}");
                            }

                            flag=false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("Invalid FoodID");
                    }
                    Console.Write("Do you want to order more food, say yes or no : ");
                    toOrderMore=Console.ReadLine().ToLower();

                } while (toOrderMore == "yes");


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
                            order.TotalPrice=totalAmount;
                            order.OrderStatus=OrderStatus.Ordered;
                            itemDetailsList.AddRange(localItemList);
                            Console.WriteLine($"Your Total Bill amount is {order.TotalPrice}");
                            Console.WriteLine($"Successfully your Order has been Placed. Your Order ID : {order.OrderID}");
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
                                foreach (ItemDetails item in localItemList)
                                {
                                    foreach (FoodDetails food in foodDetailsList)
                                    {
                                        food.QuantityAvailable += item.PurchaseCount;
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
                    foreach (ItemDetails item in localItemList)
                    {
                        foreach (FoodDetails food in foodDetailsList)
                        {
                            food.QuantityAvailable+=item.PurchaseCount;
                        }
                    }
                }


            }
        }


        //CancelOrder method
        public static void CancelOrder()
        {
            bool flag=true;
            foreach (OrderDetails order in orderDetailsList)
            {
                if (currentLoggedInCustomer.CustomerID.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                {
                    flag=false;
                    Console.WriteLine($"|{order.OrderID}|{order.CustomerID}|{order.TotalPrice}|{order.DateOfOrder}|{order.OrderStatus}|");
                }
                
            }
            if (flag)
            {
                Console.WriteLine("No orders found to cancel ");
            }

            if (!flag)
            {
                Console.Write("Enter order ID to cancel : ");
                string cancelOrderID=Console.ReadLine().ToUpper();
                //validate order ID
                bool temp=true;
                foreach (OrderDetails order in orderDetailsList)
                {
                    if (cancelOrderID.Equals(order.OrderID) && currentLoggedInCustomer.CustomerID.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                    {
                        temp=false;
                        order.OrderStatus=OrderStatus.Cancelled;
                        currentLoggedInCustomer.WalletRecharge(order.TotalPrice);
                        Console.WriteLine("Enter your Order has been Cancelled successfully");
                        foreach (ItemDetails item in itemDetailsList)
                        {
                            if (order.OrderID.Equals(item.OrderID))
                            {
                                foreach (FoodDetails food in foodDetailsList)
                                {
                                    if (item.FoodID.Equals(food.FoodID))
                                    {
                                        food.QuantityAvailable+=item.PurchaseCount;
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


        //Modify Order method
        public static void ModifyOrder()
        {
            //Displaying the orders placed by current logged in customer
            foreach (OrderDetails order in orderDetailsList)
            {
                if (currentLoggedInCustomer.CustomerID.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                {
                    Console.WriteLine($"|{order.OrderID}|{order.CustomerID}|{order.TotalPrice}|{order.DateOfOrder}|{order.OrderStatus}|");
                }
                
            }

            //Asking orderID to modify order
            Console.Write("Enter the OrderID to be modified : ");
            string modifyOrderID=Console.ReadLine().ToUpper();
            //To validate it
            bool flag=true;
            foreach (OrderDetails order in orderDetailsList)
            {
                if (modifyOrderID.Equals(order.OrderID) && currentLoggedInCustomer.CustomerID.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                {
                    flag=false;
                    foreach (ItemDetails item in itemDetailsList)
                    {
                        if (modifyOrderID.Equals(item.OrderID))
                        {
                            Console.WriteLine($"|{item.ItemID}|{item.OrderID}|{item.FoodID}|{item.PurchaseCount}|{item.PriceOfOrder}|");
                        }
                        
                    }

                    //Asking itemID to modify
                    Console.Write("Enter Item ID to modify : ");
                    string modifyItemID=Console.ReadLine().ToUpper();
                    //to validate it
                    bool temp=true;
                    foreach (ItemDetails item in itemDetailsList)
                    {
                        if (modifyItemID.Equals(item.ItemID) && modifyOrderID.Equals(item.OrderID))
                        {
                            temp =false;
                            foreach (FoodDetails food in foodDetailsList)
                            {
                                if (item.FoodID.Equals(food.FoodID))
                                {
                                    Console.Write("Do you need to increase the quantity ,say yes or no : ");
                                    string toIncreaseQuantity=Console.ReadLine().ToLower();
                                    if (toIncreaseQuantity=="yes")
                                    {
                                        Console.Write("Enter the new quantity : ");
                                        int newQuantity=int.Parse(Console.ReadLine());

                                        if (newQuantity<=food.QuantityAvailable)
                                        {
                                            double newPriceAmount=food.PricePerQuantity*newQuantity;
                                            item.PriceOfOrder+=newPriceAmount;
                                            item.PurchaseCount+=newQuantity;
                                            order.TotalPrice+=newPriceAmount;
                                            food.QuantityAvailable-=newQuantity;
                                            string option1="yes";
                                            do
                                            {
                                                if (currentLoggedInCustomer.WalletBalance >= newPriceAmount)
                                                {
                                                    currentLoggedInCustomer.DeductBalance(newPriceAmount);
                                                    Console.WriteLine("Your Order has been Modified successfully");
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

                                        double newPriceAmount=food.PricePerQuantity*newQuantity;
                                        item.PriceOfOrder-=newPriceAmount;
                                        item.PurchaseCount-=newQuantity;
                                        order.TotalPrice-=newPriceAmount;
                                        food.QuantityAvailable+=newQuantity;
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
                        Console.WriteLine("Invalid Item ID");
                    }
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid OrderID");
            }
        }



        //Adding Default values
        public static void AddDefault()
        {
            //CustomerList
            CustomerDetails customer1=new CustomerDetails("Ravi","Ettapparajan",Gender.Male,"974774646",new DateTime(1999,11,11),"ravi@gmail.com","Chennai",10000);
            CustomerDetails customer2=new CustomerDetails("Baskaran","Sethurajan",Gender.Male,"847575775",new DateTime(1999,11,11),"baskaran@gmail.com","Chennai",15000);
            customerDetailsList.Add(customer1);
            customerDetailsList.Add(customer2);

            //Display customer list
            foreach (CustomerDetails customer in customerDetailsList)
            {
                Console.WriteLine($"|{customer.CustomerID}|{customer.Name}|{customer.FatherName}|{customer.Gender}|{customer.Mobile}|{customer.DOB}|{customer.MailID}|{customer.Location}|{customer.WalletBalance}");
            }


            //FoodDetailsList
            FoodDetails food1=new FoodDetails("Chicken Briyani 1Kg",100,12);
            FoodDetails food2=new FoodDetails("Mutton Briyani 1Kg",150,10);
            FoodDetails food3=new FoodDetails("Veg Full Meals",80,30);
            FoodDetails food4=new FoodDetails("Noodles",100,40);
            FoodDetails food5=new FoodDetails("Dosa",40,40);
            FoodDetails food6=new FoodDetails("Idly (2 pieces)",20,50);
            FoodDetails food7=new FoodDetails("Pongal",40,20);
            FoodDetails food8=new FoodDetails("Vegetable Briyani",80,15);
            FoodDetails food9=new FoodDetails("Lemon Rice",50,30);
            FoodDetails food10=new FoodDetails("Veg Pulav",120,30);
            FoodDetails food11=new FoodDetails("Chicken 65 (200 Grams)",75,30);
            foodDetailsList.Add(food1);
            foodDetailsList.Add(food2);
            foodDetailsList.Add(food3);
            foodDetailsList.Add(food4);
            foodDetailsList.Add(food5);
            foodDetailsList.Add(food6);
            foodDetailsList.Add(food7);
            foodDetailsList.Add(food8);
            foodDetailsList.Add(food9);
            foodDetailsList.Add(food10);
            foodDetailsList.Add(food11);

            //display foodList
            foreach (FoodDetails food in foodDetailsList)
            {
                Console.WriteLine($"|{food.FoodID}|{food.FoodName}|{food.PricePerQuantity}|{food.QuantityAvailable}");
            }

            //OrderDetails list
            OrderDetails order1=new OrderDetails("CID1001",580,new DateTime(2022,11,26),OrderStatus.Ordered);
            OrderDetails order2=new OrderDetails("CID1002",870,new DateTime(2022,11,26),OrderStatus.Ordered);
            OrderDetails order3=new OrderDetails("CID1001",820,new DateTime(2022,11,26),OrderStatus.Cancelled);
            orderDetailsList.Add(order1);
            orderDetailsList.Add(order2);
            orderDetailsList.Add(order3);

            //display order List
            foreach (OrderDetails order in orderDetailsList)
            {
                Console.WriteLine($"|{order.OrderID}|{order.CustomerID}|{order.TotalPrice}|{order.DateOfOrder}|{order.OrderStatus}|");
            }


            //ItemDetails List
            ItemDetails item1=new ItemDetails("OID3001","FID2001",2,200);
            ItemDetails item2=new ItemDetails("OID3001","FID2002",2,300);
            ItemDetails item3=new ItemDetails("OID3001","FID2003",1,80);
            ItemDetails item4=new ItemDetails("OID3002","FID2001",1,100);
            ItemDetails item5=new ItemDetails("OID3002","FID2002",4,600);
            ItemDetails item6=new ItemDetails("OID3002","FID2010",1,120);
            ItemDetails item7=new ItemDetails("OID3002","FID2009",1,50);
            ItemDetails item8=new ItemDetails("OID3003","FID2002",2,300);
            ItemDetails item9=new ItemDetails("OID3003","FID2008",4,320);
            ItemDetails item10=new ItemDetails("OID3003","FID2001",2,200);
            itemDetailsList.Add(item1);
            itemDetailsList.Add(item2);
            itemDetailsList.Add(item3);
            itemDetailsList.Add(item4);
            itemDetailsList.Add(item5);
            itemDetailsList.Add(item6);
            itemDetailsList.Add(item7);
            itemDetailsList.Add(item8);
            itemDetailsList.Add(item9);
            itemDetailsList.Add(item10);

            //display item List

            foreach (ItemDetails item in itemDetailsList)
            {
                Console.WriteLine($"|{item.ItemID}|{item.OrderID}|{item.FoodID}|{item.PurchaseCount}|{item.PriceOfOrder}|");
            }

        }
    }
}