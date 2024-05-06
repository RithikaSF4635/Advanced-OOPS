using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class PersonalDetails
    {
        //Properties
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public PersonalDetails(string userName,string phoneNumber)
        {
            UserName=userName;
            PhoneNumber=phoneNumber;
        }
        
        public PersonalDetails()
        {
            
        }
        
        
    }
}