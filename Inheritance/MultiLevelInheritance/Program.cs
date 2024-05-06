using System;
namespace MultiInheritance;
class Program
{
    public static void Main(string[] args)
    {
        
        PersonalDetails user=new PersonalDetails("Rithika","Rajendran",Gender.Female,23,"7477383");
        Console.WriteLine($"Person ID : {user.UserID}, Person Name : {user.UserName}, Father's Name : {user.FatherName}, Gender : {user.Gender}, Phone Number : {user.PhoneNumber}");

        StudentDetails student=new StudentDetails(user.UserID,user.UserName,user.FatherName,user.Gender,user.Age,user.PhoneNumber,1,"year");
        EmployeeDetails employee=new EmployeeDetails(student.StudentID,student.UserID,student.UserName,student.FatherName,student.Gender,student.Age,student.PhoneNumber,student.Standard,student.YearOfJoining,"Software Engineer");
    }
}
