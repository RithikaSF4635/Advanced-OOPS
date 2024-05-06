using System;
namespace SingleInheritance;
class Program
{
    public static void Main(string[] args)
    {
        
        PersonalDetails user=new PersonalDetails("Rithika","Rajendran",Gender.Female,23,"7477383");
        Console.WriteLine($"Person ID : {user.UserId}, Person Name : {user.UserName}, Father's Name : {user.FatherName}, Gender : {user.Gender}, Phone Number : {user.PhoneNumber}");

        StudentDetails Student=new StudentDetails(user.UserId,user.UserName,user.FatherName,user.Gender,user.Age,user.PhoneNumber,1,"year");
    }
}
