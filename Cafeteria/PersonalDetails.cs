using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public enum Gender{Select,Female,Male,Transgender}
    public class PersonalDetails
    {
        /*
        Properties: 
        •	Name
        •	FatherName
        •	Gender {Enum - Select, Male, Female, Transgender}
        •	Mobile
        •	MailID
        */
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public string MobileNumber { get; set; }
        public string MailID { get; set; }
        
        public PersonalDetails(string name,string fatherName,Gender gender,string mobileNumber,string mailID)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            MobileNumber=mobileNumber;
            MailID=mailID;
        }
        
        
        
        
        
        
        
        

    }
}