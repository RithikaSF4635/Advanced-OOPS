using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiInheritance
{
    public class EmployeeDetails:StudentDetails
    {
        private static int s_employeeID=1000;
        public string EmployeeID { get; }
        public string Designation { get; set; }

        public EmployeeDetails(string studentID,string userID,string userName,string fatherName,Gender gender,int age,string phoneNumber,int standard,string yearOfJoining,string designation):base(studentID,userID,userName,fatherName, gender,age, phoneNumber,standard,yearOfJoining)
        {
            s_employeeID++;
            EmployeeID="SF"+s_employeeID;
            Designation=designation;
        }
        
        
        
        
    }
}