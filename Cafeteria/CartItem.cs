using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public class CartItem
    {
        /*
        Properties:
        •	ItemID (Auto - ITID101) 
        •	OrderID
        •	FoodID
        •	OrderPrice
        •	OrderQuantity
        */
        private static int s_itemID=100;
        public string ItemID { get; }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public double OrderPrice { get; set; }
        public int OrderQuantity { get; set; }
        
        public CartItem(string orderID,string foodID,double orderPrice,int orderQuantity)
        {
            s_itemID++;
            ItemID="ITID"+s_itemID;
            OrderID=orderID;
            FoodID=foodID;
            OrderPrice=orderPrice;
            OrderQuantity=orderQuantity;
        }
        
        
        
        
        
        
        
        

    }
}