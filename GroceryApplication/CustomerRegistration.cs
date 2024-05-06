using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApplication
{
    public class CustomerRegistration : PersonalDetails,IBalance
    {
        private double _balance;
        private static int s_customerID=1000;
        public string CustomerID { get; }
        
        
        public double WalletBalance { get{return _balance;}}


        public CustomerRegistration(string name,string fatherName,Gender gender,string phoneNumber,DateTime dob,string mailID,double walletBalance) : base (name,fatherName,gender,phoneNumber,dob,mailID)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            
        }

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