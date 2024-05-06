using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance
{
    public enum Gender{Select,Female,Male,Transgender}
    public class PersonalDetails
    {
        private static int s_userID=1000;
        public string UserID { get;  }
        
        
        public string UserName { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        
        
        
        public PersonalDetails(string userName,string fatherName,Gender gender,int age,string phoneNumber)
        {
            s_userID++;
            UserID="SF"+s_userID;
            UserName=userName;
            FatherName=fatherName;
            Gender=gender;
            Age=age;
            PhoneNumber=phoneNumber;
        }
         public PersonalDetails(string userID,string userName,string fatherName,Gender gender,int age,string phoneNumber)
        {
            
            UserID=userID;
            UserName=userName;
            FatherName=fatherName;
            Gender=gender;
            Age=age;
            PhoneNumber=phoneNumber;
        }
        
        
        
        
        
    }
}