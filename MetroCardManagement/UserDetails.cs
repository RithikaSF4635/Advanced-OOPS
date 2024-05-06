using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails : PersonalDetails,IBalance
    {
        private double _balance;
        private static int s_cardNumber=1000;
        public string CardNumber { get; }

        public double WalletBalance { get{return _balance;}  }




        //Contructor

        public UserDetails(string userName,string phoneNumber,double walletBalance) : base(userName,phoneNumber)
        {
            s_cardNumber++;
            CardNumber="CMRL"+s_cardNumber;
            
        }

       
        

        
        public UserDetails(string user)
        {
            string[] values=user.Split(",");
            CardNumber=values[0];
            s_cardNumber=int.Parse(values[0].Remove(0,4));
            UserName=values[1];
            PhoneNumber=values[2];
            //_balance=double.Parse(values[3]);
            
        }
        

        //methods
        public void WalletRecharge(double amount)
        {
            _balance+=amount;
        }

        public void DeductBalance(double amount)
        {
            _balance-=amount;
        }
        
        
        
    }
}