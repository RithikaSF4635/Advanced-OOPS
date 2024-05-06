using System;
using AbstractClassesAndMethods;
namespace AbstractionClassesAndMethods;
public class Program
{
    public static void Main(string[] args)
    {
        Employee job1=new Syncfusion();
        job1.Name="Naruto";
        Console.WriteLine(job1.Display());
        Console.WriteLine(job1.Salary(30));

        Employee job2=new Syncfusion();
        job2.Name="susuko";
        Console.WriteLine(job1.Display());
        Console.WriteLine(job1.Salary(30));

    }
}
