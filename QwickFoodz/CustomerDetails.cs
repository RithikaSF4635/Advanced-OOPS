using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class CustomerDetails : PersonalDetails,IBalance
    {
        //Field
        private double _balance;
        private static int s_customerID=1000;

        //Properties
        public string CustomerID { get; }
        public double WalletBalance { get{return _balance;}  }
        
        //Constructor
        public CustomerDetails(string name,string fatherName,Gender gender,string mobile,DateTime dob,string mailID,string location,double walletBalance) : base (name,fatherName,gender,mobile,dob,mailID,location)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
        }

        public CustomerDetails(string customers)
        {
            string[] values=customers.Split(",");
            CustomerID=values[0];
            s_customerID=int.Parse(values[0].Remove(0,3));
            Name=values[1];
            FatherName=values[2];
            Gender=Enum.Parse<Gender>(values[3]);
            Mobile=values[4];
            DOB=DateTime.Parse(values[5]);
            MailID=values[6];
            Location=values[7];
            
            
        }

        //Methods
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