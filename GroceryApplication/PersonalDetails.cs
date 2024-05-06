using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApplication
{
    public enum Gender {Select,Female,Male,Transgender}
    public class PersonalDetails
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string MailID { get; set; }
        
        
        public PersonalDetails(string name,string fatherName,Gender gender,string phoneNumber,DateTime dob,string mailID)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            PhoneNumber=phoneNumber;
            DOB=dob;
            MailID=mailID;
        }
        
        
        
        
        
        
        
        
        
    }
}