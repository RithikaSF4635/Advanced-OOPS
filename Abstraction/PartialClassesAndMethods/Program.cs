using System;
namespace PartialClassesAndMethods;
public class Program
{
    public static void Main(string[] args)
    {
        PersonalDetails personal=new PersonalDetails();
        personal.DOB=new DateTime(2000,06,12);
    }
}