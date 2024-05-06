using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Cafeteria
{
    public static class Operations
    {
        static CustomList<UserDetails> userList=new CustomList<UserDetails>();
        static CustomList<FoodDetails> foodList=new CustomList<FoodDetails>();
        static CustomList<OrderDetails> orderList=new CustomList<OrderDetails>();
        static CustomList<CartItem> cartItemsList=new CustomList<CartItem>();
        static UserDetails currentLoggedInUser;

        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("**********************Cafeteria Application*********************");
            


            string mainChoice = "yes";
            do
            {
                Console.WriteLine("MainMenu\n1. Registration\n2. User Login\n3. Exit");
                
                Console.Write("Select a option: ");
                int mainOption = int.Parse(Console.ReadLine());
                 
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("***************User Registration*******************");
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("***************User Login**********************");
                            UserLogin();
                            break;
                        }
                    
                    case 3:
                        {

                            Console.WriteLine("Application Exited Successfully");
                            mainChoice = "no";
                            break;
                        }

                }
                
            } while (mainChoice == "yes");

        }//Main menu ends

        //User Registration
        public static void UserRegistration()
        {
            
            Console.Write("Enter your name : ");
            string name=Console.ReadLine();
            Console.Write("Enter your father's name : ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your Mobile Number : ");
            string mobileNumber=Console.ReadLine();
            Console.Write("Enter your MailID : ");
            string mailID=Console.ReadLine();
            Console.Write("Enter your Gender : ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your Work Station Number : ");
            string workStationNumber=Console.ReadLine();
            
            
            UserDetails user1=new UserDetails(name,fatherName,gender,mobileNumber,mailID,workStationNumber);
            userList.Add(user1);
            
            Console.WriteLine($"Registration Successfull and User ID is {user1.UserID}");

        }//User Registration Ends

        //User Login
        public static void UserLogin()
        {
            Console.Write("Enter your user ID to login : ");
            string loginID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(UserDetails user in userList)
            {
                flag=false;
                Console.WriteLine("Login Successfully........");
                currentLoggedInUser=user;
                SubMenu();
                break;
            }
            if (flag)
            {
                Console.WriteLine("Invalid UserID");
            }
        }//User Login ends

        //Sub Menu Method

        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                Console.WriteLine("Sub Menu\n1. Show My Profile\n2. Food Order\n3. Modify Order\n4. Cancel Order\n5. Order History\n6. Wallet Recharge\n7. Show Wallet Balance\n8. Exit");

                Console.Write("Select a option: ");
                int subOption = int.Parse(Console.ReadLine());

                switch (subOption)
                {
                    case 1:
                    {
                        ShowMyProfile();
                        break;
                    }
                    case 2:
                    {
                        FoodOrder();
                        break;
                    }

                    case 3:
                    {

                        ModifyOrder();
                        break;
                    }
                    case 4:
                    {
                        CancelOrder();
                        break;
                    }
                    case 5:
                    {
                        OrderHistory();
                        break;
                    }
                    case 6:
                    {
                        Recharge();
                        break;
                    }
                    case 7:
                    {
                        Console.WriteLine("Your wallet Balance : "+currentLoggedInUser.WalletBalance);
                        break;
                    }
                    case 8:
                    {
                        subChoice="no";
                        break;
                    }

                }

            } while (subChoice == "yes");
        }

        //Show My Profile method
        public static void ShowMyProfile()
        {
            foreach(UserDetails user in userList)
            {
                if (user.UserID==currentLoggedInUser.UserID)
                {
                    Console.WriteLine($"|{user.Name}|{user.FatherName}|{user.Gender}|{user.MobileNumber}|{user.MailID}|{user.WorkStationNumber}|{user.WalletBalance}|");

                }
            }
        }        

        //FoodOrder method
        public static void FoodOrder()
        {
            double amount=0.0;
            double totalAmount=0.0;
            Console.Write("Do you want to purchase the food ,say 'yes' or 'no' : ");
            string choice=Console.ReadLine().ToLower();
            if(choice=="yes")
            {
                CustomList<CartItem> tempCartItemList=new CustomList<CartItem>();
                OrderDetails order=new OrderDetails(currentLoggedInUser.UserID,DateTime.Now,0,OrderStatus.Initiated);
                orderList.Add(order);
                string subChoice="yes";
                do
                {
                    foreach (FoodDetails food in foodList)
                    {
                        Console.WriteLine($"|{food.FoodID}|{food.FoodName}|{food.FoodPrice}|{food.AvailableQuantity}|");
                    }
                    Console.Write("Enter the Food ID : ");
                    string FoodID=Console.ReadLine();
                    foreach (FoodDetails food in foodList)
                    {
                        if (food.FoodID.Equals(FoodID))
                        {
                            Console.Write("Enter the count of quantity to purchase : ");
                            int count=int.Parse(Console.ReadLine());
                            if (count<=food.AvailableQuantity)
                            {
                                amount=food.FoodPrice*count;
                                totalAmount+=amount;
                                food.AvailableQuantity-=count;
                                CartItem food1=new CartItem(order.OrderID,food.FoodID,amount,count);
                                tempCartItemList.Add(food1);
                                Console.WriteLine("Your food successfully added to cart.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Asked count is not available.Available count: {food.AvailableQuantity}");
                            }
                        }
                    }
                    Console.Write("Do you want to pick another food,Yes or No :");
                    subChoice=Console.ReadLine().ToLower();
                }while(subChoice=="yes");

                Console.Write("Do you want to confirm the order,Yes or No : ");
                string option2="yes";
                string option1=Console.ReadLine().ToLower();
                if (option1=="yes")
                {
                    do
                    {
                        if (currentLoggedInUser.WalletBalance>=totalAmount)
                        {
                            currentLoggedInUser.DeductAmount(totalAmount);
                            Console.WriteLine($"Balance Deducted,Your Available Balance is {currentLoggedInUser.WalletBalance}");
                            order.OrderStatus=OrderStatus.Ordered;
                            order.TotalPrice=totalAmount;
                            cartItemsList.AddRange(tempCartItemList);
                            Console.WriteLine($"Order was Successful.Your Order ID is {order.OrderID}");
                            option2="no";

                        }
                        else
                        {
                            Console.WriteLine("Insufficient Balance");
                            Console.WriteLine("Are you willing to recharge.yes or no :");
                            string option=Console.ReadLine().ToLower();
                            if (option =="yes")
                            {
                                Console.Write("Enter the amount : ");
                                double amount1 = double.Parse(Console.ReadLine());
                                currentLoggedInUser.WalletRecharge(amount1);
                                Console.WriteLine($"Recharge was successful.Current balance is {currentLoggedInUser.WalletBalance}");

                            }
                            else
                            {
                                foreach(CartItem cart in tempCartItemList)
                                {
                                    foreach(FoodDetails food in foodList)
                                    {
                                        if (food.FoodID==cart.FoodID)
                                        {
                                            food.AvailableQuantity+=cart.OrderQuantity;
                                        }
                                    }
                                }
                                Console.WriteLine("Cart Removed Successfully");
                                option2="no";
                            }
                        }
                    }while(option2=="yes");
                }
                else
                {
                    foreach(CartItem cart in tempCartItemList)
                    {
                        foreach (FoodDetails food in foodList)
                        {
                            if (food.FoodID == cart.FoodID)
                            {
                                food.AvailableQuantity += cart.OrderQuantity;
                            }
                        }



                    }
                     Console.WriteLine("Cart Removed Successfully");
                }
            }
            else
            {
                Console.WriteLine();
                choice="no";
            }
        }//FoodOrder Ends

        //Modify Order Method

        public static void ModifyOrder()
        {
            bool flag=true;
            foreach(OrderDetails order in orderList)
            {
                if(currentLoggedInUser.UserID==order.USerID && order.OrderStatus==OrderStatus.Ordered)
                {
                    flag=false;
                    Console.WriteLine($"|{order.OrderID}|{order.USerID}|{order.OrderDate}|{order.TotalPrice}|{order.OrderStatus}|");

                }
            }
            if(flag)
            {
                Console.WriteLine("No history found");
            }

            Console.Write("Choose the Order ID : ");
            string userOrderID=Console.ReadLine().ToUpper();
            foreach(OrderDetails order in orderList)
            {
                if (userOrderID==order.OrderID && currentLoggedInUser.UserID==order.USerID&& order.OrderStatus==OrderStatus.Ordered)
                {
                    foreach (CartItem cart in cartItemsList)
                    {
                        if (cart.OrderID==userOrderID)
                        {
                            Console.WriteLine($"| {cart.ItemID} | {cart.OrderID} | {cart.FoodID} | {cart.OrderPrice} | {cart.OrderQuantity} |");
                        }
                    }
                    Console.Write("Enter the ItemID: ");
                    string userItemID = Console.ReadLine().ToUpper();
                    foreach(CartItem cart in cartItemsList)
                    {
                        if (userItemID == cart.ItemID && currentLoggedInUser.UserID == order.USerID)
                        {
                            Console.Write("Enter the new quantity of the food: ");
                            int newQuantity = int.Parse(Console.ReadLine());
                            foreach(FoodDetails food in foodList)
                            {
                                if (food.FoodID == cart.FoodID)
                                {
                                    Console.Write("Which one you choose, Add or Sub: ");
                                    string option = Console.ReadLine().ToLower();

                                    if (option == "add")
                                    {
                                        if (food.AvailableQuantity > newQuantity)
                                        {
                                            double newPrice = food.FoodPrice * newQuantity;
                                            cart.OrderPrice += newPrice;
                                            cart.OrderQuantity += newQuantity;
                                            order.TotalPrice += cart.OrderPrice;
                                            food.AvailableQuantity -= newQuantity;
                                            currentLoggedInUser.DeductAmount(newPrice);
                                            Console.WriteLine("Modified Successfully");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        double newPrice = food.FoodPrice * newQuantity;
                                        cart.OrderPrice -= newPrice;
                                        cart.OrderQuantity -= newQuantity;
                                        order.TotalPrice -= cart.OrderPrice;
                                        food.AvailableQuantity += newQuantity;
                                        Console.WriteLine("Modified Successfully");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //Cancel Order Method
        public static void CancelOrder()
        {
            Console.WriteLine($"| {"Order ID"} | {"User ID"} | {"Order Date"} | {"Total Price"} | {"Order Status"} |");
            bool flag = true;
            foreach(OrderDetails order in orderList)
            {
                if(currentLoggedInUser.UserID.Equals(order.USerID))
                {
                    flag = false;
                    Console.WriteLine($"| {order.OrderID} | {order.USerID} | {order.OrderDate} | {order.TotalPrice} | {order.OrderStatus} |");
                }
            }
            if(flag)
            {
                Console.WriteLine("No Purchased Found. You have not made any purchase yet.");
            }

            if(!flag)
            {
                Console.Write("Enter the Order ID to Cancel the Order: ");
                string orderID = Console.ReadLine().ToUpper();
                bool flag1 = true;

                foreach(OrderDetails order in orderList)
                {
                    flag1 = false;
                    if (currentLoggedInUser.UserID.Equals(order.USerID) && order.OrderStatus == OrderStatus.Ordered && orderID.Equals(order.OrderID))
                    {
                        currentLoggedInUser.WalletRecharge(order.TotalPrice);
                        order.OrderStatus = OrderStatus.Cancelled;
                        Console.WriteLine($"Your Order {order.OrderID} is cancelled successfully");
                    }
                }
                if(flag1)
                {
                    Console.WriteLine("Invalid OrderID");
                }
            }
        }//Cancel Order Method Ends

        public static void Recharge()
        {
            double amount1 = double.Parse(Console.ReadLine());
            currentLoggedInUser.WalletRecharge(amount1);
            Console.WriteLine($"Recharge was successful.Current balance is {currentLoggedInUser.WalletBalance}");
        }

        public static void OrderHistory()
        {
            Console.WriteLine($"| {"Order ID"} | {"User ID"} | {"Order Date"} | {"Total Price"} | {"Order Status"} |");
            bool flag = true;
             foreach(OrderDetails order in orderList)
            {
                if(currentLoggedInUser.UserID.Equals(order.USerID))
                {
                    flag = false;
                    Console.WriteLine($"| {order.OrderID} | {order.USerID} | {order.OrderDate} | {order.TotalPrice} | {order.OrderStatus} |");
                }
            }
            if(flag)
            {
                Console.WriteLine("No Purchased Found. You have not made any purchase yet.");
            }
        }

        //Add Default Data
        public static void AddDefaultData()
        {
            //Adding User Details
            UserDetails user1 = new UserDetails("Ravichandran", "Ettaparajan", Gender.Male,"8857777575","ravi@gmail.com","WS101");
            userList.Add(user1);
            UserDetails user2 = new UserDetails("Baskaran","Sethurajan",Gender.Male,"9577747744","baskaran@gmail.com","WS105");
            userList.Add(user2);
            
            //Adding Food Details
            FoodDetails food1=new FoodDetails("Coffee",20,100);
            FoodDetails food2=new FoodDetails("Tea",15,100);
            FoodDetails food3=new FoodDetails("Biscuit",10,100);
            FoodDetails food4=new FoodDetails("Juice",50,100);
            FoodDetails food5=new FoodDetails("Puff",40,100);
            FoodDetails food6=new FoodDetails("Milk",10,100);
            FoodDetails food7=new FoodDetails("Popcorn",20,20);
            foodList.Add(food1);
            foodList.Add(food2);
            foodList.Add(food3);
            foodList.Add(food4);
            foodList.Add(food5);
            foodList.Add(food6);
            foodList.Add(food7);

            //Adding Order Details
            OrderDetails order1=new OrderDetails("SF1001",new DateTime(2022,06,15),70,OrderStatus.Ordered);
            OrderDetails order2=new OrderDetails("SF1002",new DateTime(2022,06,15),100,OrderStatus.Ordered);
            orderList.Add(order1);
            orderList.Add(order2);

            //Adding CartItems
            CartItem item1= new CartItem("OID1001","FID101",20,1);
            CartItem item2= new CartItem("OID1001","FID103",10,1);
            CartItem item3= new CartItem("OID1001","FID105",40,1);
            CartItem item4= new CartItem("OID1002","FID103",10,1);
            CartItem item5= new CartItem("OID1002","FID104",50,1);
            CartItem item6= new CartItem("OID1002","FID105",40,1);
            cartItemsList.Add(item1);
            cartItemsList.Add(item2);
            cartItemsList.Add(item3);
            cartItemsList.Add(item4);
            cartItemsList.Add(item5);
            cartItemsList.Add(item6);
        }

    }
}