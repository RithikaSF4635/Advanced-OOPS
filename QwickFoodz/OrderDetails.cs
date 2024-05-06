using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public enum OrderStatus {Default,Initiated,Ordered,Cancelled}
    public class OrderDetails
    {
        /*Properties: OrderID, CustomerID, TotalPrice, DateOfOrder,
         OrderStatus – {Default, Initiated, Ordered, Cancelled}
         */

         private static int s_orderID=3000;
         public string OrderID { get;}
         public string CustomerID { get; set; }
         public double TotalPrice { get; set; }
         public DateTime DateOfOrder { get; set; }
         public OrderStatus OrderStatus { get; set; }
         
         
         public OrderDetails(string customerID,double totalPrice,DateTime dateOfOrder,OrderStatus orderStatus)
         {
            s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateOfOrder=dateOfOrder;
            OrderStatus=orderStatus;
         }
         
         public OrderDetails(string orders)
         {
            string[] values=orders.Split(",");
            
            OrderID=values[0];
            s_orderID=int.Parse(values[0].Remove(0,3));
            CustomerID=values[1];
            TotalPrice=double.Parse(values[2]);
            DateOfOrder=DateTime.Parse(values[3]);
            OrderStatus=Enum.Parse<OrderStatus>(values[4]);
         }
         
         
         
         
         
    }
}