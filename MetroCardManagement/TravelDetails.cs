using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TravelDetails
    {
        /*
        Properties:
        a.	TravelId (Auto Generated -TID2001)
        b.	Card Number
        c.	FromLocation
        d.	ToLocation
        e.	Date
        f.	Travel Cost
        */

        private static int s_travelID=2000;
        public string TravelID { get; }
        public string CardNumber { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime Date { get; set; }
        public double TravelCost { get; set; }
        
        
        public TravelDetails(string cardNumber,string fromLocation,string toLocation,DateTime date,double travelCost)
        {
            s_travelID++;
            TravelID="TID"+s_travelID;
            CardNumber=cardNumber;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            Date=date;
            TravelCost=travelCost;
        }

        public TravelDetails(string travel)
        {
            string[] values=travel.Split(",");
            TravelID=values[0];
            s_travelID=int.Parse(values[0].Remove(0,3));
            CardNumber=values[1];
            FromLocation=values[2];
            ToLocation=values[3];
            Date=DateTime.Parse(values[4]);
            TravelCost=double.Parse(values[5]);
        }
        
        
        
        
        
        
        
        
        
    }
}