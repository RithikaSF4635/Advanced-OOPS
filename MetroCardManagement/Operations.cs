using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public static class Operations
    {
        public static CustomList<UserDetails> userDetailsList=new CustomList<UserDetails>();
        public static CustomList<TravelDetails> travelDetailsList=new CustomList<TravelDetails>();
        public static CustomList<TicketFairDetails> ticketFairDetailsList=new CustomList<TicketFairDetails>();
        public static UserDetails currentLoggedInUser;


        //MainMenu Method
        public static void MainMenu()
        {
            string mainChoice="yes";
            do
            {
                Console.WriteLine("*************Welcome to Metro Card Management Application**************");
                Console.WriteLine("Main Menu\n1. New User Registration\n2. Login User\n3. Exit");
                Console.WriteLine("Enter Option : ");
                int Option = int.Parse(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        {
                            Console.WriteLine("********Registration Page************");
                            //Registration method
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("************Login Page************");
                            //Login method
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("***********Exiting Application***********");
                            mainChoice="no";
                            break;
                        }
                }
            } while (mainChoice == "yes");

        }


        //Registration method
        public static void Registration()
        {
            Console.Write("Enter your name : ");
            string name=Console.ReadLine();
            Console.Write("Enter your phone number : ");
            string phoneNumber=Console.ReadLine();
            Console.Write("Enter your Wallet Balance : ");
            double walletBalance=double.Parse(Console.ReadLine());

            UserDetails user=new UserDetails(name,phoneNumber,walletBalance);
            userDetailsList.Add(user);

            Console.WriteLine($"Registration successfully completed. Your Card Number is {user.CardNumber}");

        }


        //Login method
        public static void Login()
        {
            Console.WriteLine("Enter the card Number : ");
            string loginID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach (UserDetails user in userDetailsList)
            {
                if (loginID.Equals(user.CardNumber))
                {
                    flag=false;
                    Console.WriteLine("LoggedIn Successfully");
                    currentLoggedInUser=user;
                    //Submenu method
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Card Number");
            }

        }

        //Sub Menu method
        public static void SubMenu()
        {
            string subChoice="yes";
            do
            {
                Console.WriteLine("SubMenu\n1. Balance Check\n2. Recharge\n3. View Travel History\n4. Travel\n5. Exit");
                Console.WriteLine("Enter Option : ");
                int subOption=int.Parse(Console.ReadLine());
                switch(subOption)
                {
                    case 1:
                    {
                        //Balance Check
                        BalanceCheck();
                        break;
                    }
                    case 2:
                    {
                        //Recharge
                        Recharge();
                        break;
                    }
                    case 3:
                    {
                        //View Travel History
                        ViewTravelHistory();
                        break;
                    }
                    case 4:
                    {
                        //Travel
                        Travel();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Exiting Sub Menu");
                        subChoice="no";
                        break;
                    }
                }
            }while (subChoice=="yes");

            
        }


        //Balance Check method
        public static void BalanceCheck()
        {

            Console.WriteLine($"Current Balance : {currentLoggedInUser.WalletBalance}");
           
        }


        //Recharge method
        public static void Recharge()
        {
            Console.Write("Enter the amount : ");
            double amount=double.Parse(Console.ReadLine());
            currentLoggedInUser.WalletRecharge(amount);
            Console.WriteLine($"Current Balance is {currentLoggedInUser.WalletBalance} ");
        }


        //View Travel History
        public static void ViewTravelHistory()
        {
            bool flag=true;
            foreach (TravelDetails travel in travelDetailsList)
            {
                if (currentLoggedInUser.CardNumber.Equals(travel.CardNumber))
                {
                    flag=false;
                    Console.WriteLine($"|{travel.TravelID}|{travel.CardNumber}|{travel.FromLocation}|{travel.ToLocation}|{travel.Date}|{travel.TravelCost}|");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Travel History found");
            }
        }


        //Travel method
        public static void Travel()
        {

            string Option1="yes";

            do
            {
                //display the ticket fair details
                foreach (TicketFairDetails ticket in ticketFairDetailsList)
                {
                    Console.WriteLine($"|{ticket.TicketID}|{ticket.FromLocation}|{ticket.ToLocation}|{ticket.TicketPrice}|");
                }

                //get ticket ID as input
                Console.Write("Enter the Ticket ID : ");
                string userTicketID = Console.ReadLine().ToUpper();
                bool flag = true;
                //Validate the ticket ID 
                foreach (TicketFairDetails ticket in ticketFairDetailsList)
                {
                    if (userTicketID.Equals(ticket.TicketID))
                    {
                        //if ticket ID is valid 
                        flag = false;
                        //Check Balance of the currentuser
                        if (currentLoggedInUser.WalletBalance >= ticket.TicketPrice)
                        {
                            //if sufficient deduct the amount from balance and the add the travel details 
                            currentLoggedInUser.DeductBalance(ticket.TicketPrice);
                            //like Card number, From and ToLocation, Travel Date, Travel cost, Travel ID  in his travel history.
                            TravelDetails travel=new TravelDetails(currentLoggedInUser.CardNumber,ticket.FromLocation,ticket.ToLocation,DateTime.Now,ticket.TicketPrice);
                            travelDetailsList.Add(travel);
                            Console.WriteLine($"Ticket has been created successfully.");
                            Option1="no";
                        }
                        else
                        {
                            //if it is insufficient ask him to recharge or exit the user service
                            Console.WriteLine("Insufficient Balance");
                            Console.Write("Do you want to recharge, yes or no : ");
                            string ToRecharge = Console.ReadLine().ToLower();
                            if (ToRecharge == "yes")
                            {
                                Console.WriteLine("Enter the amount : ");
                                double amount1 = double.Parse(Console.ReadLine());
                                currentLoggedInUser.WalletRecharge(amount1);
                                Console.WriteLine($"Your current Balance is {currentLoggedInUser.WalletBalance}");
                                break;
                            }
                            else
                            {
                                Option1="no";
                                break;
                            }
                        }



                    }
                }
                //if ticket ID is invalid show invalid ticket ID
                if (flag)
                {
                    Console.WriteLine("Invalid Ticket ID");
                }
            } while (Option1 == "yes");


        }


        //Adding Default Values

        public static void AddDefaultValues()
        {
            UserDetails user1=new UserDetails("Ravi","9848812345",1000);
            UserDetails user2=new UserDetails("Baskaran","9948854321",1000);
            userDetailsList.Add(user1);
            userDetailsList.Add(user2);

            foreach (UserDetails user in userDetailsList)
            {
                Console.WriteLine($"|{user.CardNumber}|{user.UserName}|{user.PhoneNumber}|{user.WalletBalance}");

            }

            //Travel History Details
            TravelDetails travel1=new TravelDetails("CMRL1001","Airport","Egmore",new DateTime(2023,10,10),55);
            TravelDetails travel2=new TravelDetails("CMRL1001","Egmore","Koyambedu",new DateTime(2023,10,10),32);
            TravelDetails travel3=new TravelDetails("CMRL1002","Alandur","Koyambedu",new DateTime(2023,11,10),25);
            TravelDetails travel4=new TravelDetails("CMRL1002","Egmore","Thirumangalam",new DateTime(2023,11,10),25);
            travelDetailsList.Add(travel1);
            travelDetailsList.Add(travel2);
            travelDetailsList.Add(travel3);
            travelDetailsList.Add(travel4);

            foreach (TravelDetails travel in travelDetailsList)
            {
                Console.WriteLine($"|{travel.TravelID}|{travel.CardNumber}|{travel.FromLocation}|{travel.ToLocation}|{travel.Date}|{travel.TravelCost}|");
            }

            //Adding Ticket Fair Details
            TicketFairDetails ticket1=new TicketFairDetails("Airport","Egmore",55);
            TicketFairDetails ticket2=new TicketFairDetails("Airport","Koyambedu",25);
            TicketFairDetails ticket3=new TicketFairDetails("Alandur","Koyambedu",25);
            TicketFairDetails ticket4=new TicketFairDetails("Koyambedu","Egmore",32);
            TicketFairDetails ticket5=new TicketFairDetails("Vadapalani","Egmore",45);
            TicketFairDetails ticket6=new TicketFairDetails("Arumbakkam","Egmore",25);
            TicketFairDetails ticket7=new TicketFairDetails("Vadapalani","Koyambedu",25);
            TicketFairDetails ticket8=new TicketFairDetails("Arumbakkam","Koyambedu",16);

            ticketFairDetailsList.Add(ticket1);
            ticketFairDetailsList.Add(ticket2);
            ticketFairDetailsList.Add(ticket3);
            ticketFairDetailsList.Add(ticket4);
            ticketFairDetailsList.Add(ticket5);
            ticketFairDetailsList.Add(ticket6);
            ticketFairDetailsList.Add(ticket7);
            ticketFairDetailsList.Add(ticket8);

            foreach (TicketFairDetails ticket in ticketFairDetailsList)
            {
                Console.WriteLine($"|{ticket.TicketID}|{ticket.FromLocation}|{ticket.ToLocation}|{ticket.TicketPrice}|");
            }

        }
    }
}