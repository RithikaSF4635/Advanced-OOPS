using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public static  class FileHandling
    {
        public static void Create()
        {
            //Creating Directory
            if (!Directory.Exists("MetroCardManagement"))
            {
                Console.WriteLine("Creating Directory....");
                Directory.CreateDirectory("MetroCardManagement");
            }

            //Creating File
            //UserDetails file
            if (!File.Exists("MetroCardManagement/UserDetails.csv"))
            {
                Console.WriteLine("Creating file.....");
                File.Create("MetroCardManagement/UserDetails.csv").Close();
            }

            //Travel History Details
            if (!File.Exists("MetroCardManagement/TravelHistory.csv"))
            {
                Console.WriteLine("Creating File....");
                File.Create("MetroCardManagement/TravelHistory.csv").Close();
            }

            //Ticket Fair Details
            if (!File.Exists("MetroCardManagement/TicketFair.csv"))
            {
                Console.WriteLine("Creating File.....");
                File.Create("MetroCardManagement/TicketFair.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            //UserDetails
            string[] users=new string[Operations.userDetailsList.Count];
            for (int i=0;i<Operations.userDetailsList.Count;i++)
            {
                users[i]=Operations.userDetailsList[i].CardNumber+","+Operations.userDetailsList[i].UserName+","+Operations.userDetailsList[i].PhoneNumber+","+Operations.userDetailsList[i].WalletBalance;
            }
            File.WriteAllLines("MetroCardManagement/UserDetails.csv",users);

            //TravelHistoryDetails
            string[] travels=new string[Operations.travelDetailsList.Count];
            for(int i=0;i<Operations.travelDetailsList.Count;i++)
            {
                travels[i]=Operations.travelDetailsList[i].TravelID+","+Operations.travelDetailsList[i].CardNumber+","+Operations.travelDetailsList[i].FromLocation+","+Operations.travelDetailsList[i].ToLocation+","+Operations.travelDetailsList[i].Date+","+Operations.travelDetailsList[i].TravelCost;

            }
            File.WriteAllLines("MetroCardManagement/TravelHistory.csv",travels);

            //Ticket Fair Details
            string[] tickets=new string[Operations.ticketFairDetailsList.Count];
            for (int i=0;i<Operations.ticketFairDetailsList.Count;i++)
            {
                tickets[i]=Operations.ticketFairDetailsList[i].TicketID+","+Operations.ticketFairDetailsList[i].FromLocation+","+Operations.ticketFairDetailsList[i].ToLocation+","+Operations.ticketFairDetailsList[i].TicketPrice;
            }
            File.WriteAllLines("MetroCardManagement/TicketFair.csv",tickets);
        }

        public static void ReadFromCSV()
        {
            //UserDetails
            string[] users=File.ReadAllLines("MetroCardManagement/UserDetails.csv");
            foreach (string user in users)
            {
                
                UserDetails user1=new UserDetails(user);
                Operations.userDetailsList.Add(user1);
            }

            //TravelHistory
            string[] travels=File.ReadAllLines("MetroCardManagement/TravelHistory.csv");
            foreach (string travel in travels)
            {
                TravelDetails travel1=new TravelDetails(travel);
                Operations.travelDetailsList.Add(travel1);
            }

            //TicketFair
            string[] tickets=File.ReadAllLines("MetroCardManagement/TicketFair.csv");
            foreach (string ticket in tickets)
            {
                TicketFairDetails ticket1=new TicketFairDetails(ticket);
                Operations.ticketFairDetailsList.Add(ticket1);
            }
        }
       
        
    }
}