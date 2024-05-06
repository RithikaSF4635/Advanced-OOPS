using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance
{
    public class StudentDetails:PersonalDetails
    {
        private static int s_studentID=2000;
        public string StudentID { get;  }
        public int Standard { get; set; }
        public string YearOfJoining { get; set; }
        
        
        public StudentDetails(string userID,string userName,string fatherName,Gender gender,int age,string phoneNumber,int standard,string yearOfJoining):base(userID,userName,fatherName, gender,age, phoneNumber)
        {
            s_studentID++;
            StudentID="SID"+s_studentID;
            Standard=standard;
            YearOfJoining=yearOfJoining;
            
        }
        
        
        
    }
}