using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class ItemDetails
    {
        /*Properties: ItemID – (ITID100), OrderID, FoodID, PurchaseCount, PriceOfOrder */

        private static int s_itemID=4000;
        public string ItemID { get; }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public int PurchaseCount { get; set; }
        public double PriceOfOrder { get; set; }
        
        public ItemDetails(string orderID,string foodID,int purchaseCount,double priceOfOrder)
        {
            s_itemID++;
            ItemID="ITID"+s_itemID;
            OrderID=orderID;
            FoodID=foodID;
            PurchaseCount=purchaseCount;
            PriceOfOrder=priceOfOrder;
        }
        
        public ItemDetails(string items)
        {
            string[] values=items.Split(",");
            s_itemID=int.Parse(values[0].Remove(0,4));
            ItemID=values[0];
            OrderID=values[1];
            FoodID=values[2];
            PurchaseCount=int.Parse(values[3]);
            PriceOfOrder=double.Parse(values[4]);
        }
        
        
        
        
        
        
    }
}