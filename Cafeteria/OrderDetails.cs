using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public enum OrderStatus{Default, Initiated,Ordered,Cancelled}
    public class OrderDetails
    {
        /*
        Properties:
        •	OrderID (Auto – OID1001)
        •	UserID
        •	OrderDate
        •	TotalPrice
        •	OrderStatus – (Default, Initiated, Ordered, Cancelled)
        */
        //Field
        private static int s_orderID=1000;
        //Properies
        public string OrderID { get; }
        public string USerID { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        
        
        public OrderDetails(string userID,DateTime orderDate,double totalPrice,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            USerID=userID;
            OrderDate=orderDate;
            TotalPrice=totalPrice;
            OrderStatus=orderStatus;
        }
        
        
        
        
        
        
        
    }
}