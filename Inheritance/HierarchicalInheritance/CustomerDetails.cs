using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance
{
    public class CustomerDetails:PersonalDetails
    {
        private static int s_customerID=2000;
        public string CustomerID { get; }
        public double Balance { get; set; }

        public CustomerDetails(string userID,string userName,string fatherName,Gender gender,int age,string phoneNumber,double balance):base(userID,userName,fatherName,gender,age,phoneNumber)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            Balance=balance;
        }
        
        
        
        
    }
}