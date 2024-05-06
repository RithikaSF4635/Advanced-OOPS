using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class FoodDetails
    {
        /*Properties: FoodID, FoodName, PricePerQuantity, QuantityAvailable*/

        private static int s_foodID=2000;
        public string FoodID{ get; }
        public string FoodName { get; set; }
        public double PricePerQuantity { get; set; }
        public int QuantityAvailable { get; set; }
        
        
        public FoodDetails(string foodName,double pricePerQuantity,int quantityAvailable)
        {
            s_foodID++;
            FoodID="FID"+s_foodID;
            FoodName=foodName;
            PricePerQuantity=pricePerQuantity;
            QuantityAvailable=quantityAvailable;
        }
        
        public FoodDetails(string foods)
        {
            string[] values=foods.Split(",");
            s_foodID=int.Parse(values[0].Remove(0,3));
            FoodID=values[0];
            FoodName=values[1];
            PricePerQuantity=double.Parse(values[2]);
            QuantityAvailable=int.Parse(values[3]);
        }
        
        
        
    }
}