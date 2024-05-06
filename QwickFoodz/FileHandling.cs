using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("QwickFoodz"))
            {
                Console.WriteLine("Creating Directory...........");
                Directory.CreateDirectory("QwickFoodz");
            }

            if (!File.Exists("QwickFoodz/CustomerDetails.csv"))
            {
                Console.WriteLine("Creating File.......");
                File.Create("QwickFoodz/CustomerDetails.csv");
            }

            if (!File.Exists("QwickFoodz/FoodDetails.csv"))
            {
                Console.WriteLine("Creating File.......");
                File.Create("QwickFoodz/FoodDetails.csv");
            }

            if (!File.Exists("QwickFoodz/OrderDetails.csv"))
            {
                Console.WriteLine("Creating File.......");
                File.Create("QwickFoodz/OrderDetails.csv");
            }

            if (!File.Exists("QwickFoodz/ItemDetails.csv"))
            {
                Console.WriteLine("Creating File.......");
                File.Create("QwickFoodz/ItemDetails.csv");
            }
        }


        public static void WriteToCsv()
        {
            //Customer Details
            string[] customers=new string[Operations.customerDetailsList.Count];
            for (int i=0;i<Operations.customerDetailsList.Count;i++)
            {
                customers[i]=Operations.customerDetailsList[i].CustomerID+","+Operations.customerDetailsList[i].Name+","+Operations.customerDetailsList[i].FatherName+","+Operations.customerDetailsList[i].Gender+","+Operations.customerDetailsList[i].Mobile+","+Operations.customerDetailsList[i].DOB+","+Operations.customerDetailsList[i].MailID+","+Operations.customerDetailsList[i].Location+","+Operations.customerDetailsList[i].WalletBalance;
            }
            File.WriteAllLines("QwickFoodz/CustomerDetails.csv",customers);

            //Food Details
            string[] foods=new string[Operations.foodDetailsList.Count];
            for (int i=0;i<Operations.foodDetailsList.Count;i++)
            {
                foods[i]=Operations.foodDetailsList[i].FoodID+","+Operations.foodDetailsList[i].FoodName+","+Operations.foodDetailsList[i].PricePerQuantity+","+Operations.foodDetailsList[i].QuantityAvailable;
            }
            File.WriteAllLines("QwickFoodz/FoodDetails.csv",foods);

            //Order Details
            string[] orders=new string[Operations.orderDetailsList.Count];
            for (int i=0;i<Operations.orderDetailsList.Count;i++)
            {
                orders[i]=Operations.orderDetailsList[i].OrderID+","+Operations.orderDetailsList[i].CustomerID+","+Operations.orderDetailsList[i].TotalPrice+","+Operations.orderDetailsList[i].DateOfOrder+","+Operations.orderDetailsList[i].OrderStatus;
            }
            File.WriteAllLines("QwickFoodz/OrderDetails.csv",orders);

            //Item Details
            string[] items=new string[Operations.itemDetailsList.Count];
            for (int i=0;i<Operations.itemDetailsList.Count;i++)
            {
                items[i]=Operations.itemDetailsList[i].ItemID+","+Operations.itemDetailsList[i].OrderID+","+Operations.itemDetailsList[i].FoodID+","+Operations.itemDetailsList[i].PurchaseCount+","+Operations.itemDetailsList[i].PriceOfOrder;
            }
            File.WriteAllLines("QwickFoodz/ItemDetails.csv",items);
        }

        public static void ReadFromCsv()
        {
            //customer
            string[] customers=File.ReadAllLines("QwickFoodz/CustomerDetails.csv");
            foreach (string customer in customers)
            {
                   
                CustomerDetails customer1=new CustomerDetails(customer);
                Operations.customerDetailsList.Add(customer1);
            }

            string[] foods=File.ReadAllLines("QwickFoodz/FoodDetails.csv");
            foreach(string food in foods)
            {
                FoodDetails food1=new FoodDetails(food);
                Operations.foodDetailsList.Add(food1);
            }

            string[] orders=File.ReadAllLines("QwickFoodz/OrderDetails.csv");
            foreach(string order in orders)
            {
                OrderDetails order1=new OrderDetails(order);
                Operations.orderDetailsList.Add(order1);
            }

            string[] items=File.ReadAllLines("QwickFoodz/ItemDetails.csv");
            foreach(string item in items)
            {
                ItemDetails item1=new ItemDetails(item);
                Operations.itemDetailsList.Add(item1);
            }
        }
    }
}