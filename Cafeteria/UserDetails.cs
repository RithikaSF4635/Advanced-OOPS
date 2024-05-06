using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public class UserDetails : PersonalDetails,IBalance
    {
        //Field
        private static int s_userID=1000;
        //non static field
        private double _balance;
        //Properties
        public string UserID { get; }
        public string WorkStationNumber { get; set; }
        public double WalletBalance { get{return _balance;} }

        public UserDetails(string name,string fatherName,Gender gender,string mobileNumber,string mailID,string workStationNumber) : base (name,fatherName,gender,mobileNumber,mailID)
        {
            s_userID++;
            UserID="SF"+s_userID;
            WorkStationNumber=workStationNumber;
        }

        //Method
        public void WalletRecharge(double amount)
        {
            _balance+=amount;
        }

        public void DeductAmount(double amount)
        {
            _balance-=amount;
        }
        
        
        
        
        
        
    }
}