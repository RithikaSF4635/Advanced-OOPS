using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public enum Gender {Select,Female,Male,Transgender}
    public class PersonalDetails
    {
        /*Properties: Name, FatherName, Gender- {Select, Male, Female, Transgender}, 
        Mobile, DOB, MailID, Location
        */
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public string MailID { get; set; }
        public string Location { get; set; }
        
        
        public PersonalDetails(string name,string fatherName,Gender gender,string mobile,DateTime dob,string mailID,string location)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            Mobile=mobile;
            DOB=dob;
            MailID=mailID;
            Location=location;
        }
        public PersonalDetails()
        {
            
        }
        
        
        
        
        
        
        
        
        
        
        
    }
}