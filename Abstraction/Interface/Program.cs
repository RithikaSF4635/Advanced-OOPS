using System;
namespace Interface;
public class Program
{
    public static void Main(string[] args)
    {
        Square number=new Square(); //class variable as object
        number.Number=20;
        Console.WriteLine(number.Calculate());
        Circle number1=new Circle();
        number1.Number=5;
        Console.WriteLine(number1.Calculate());
    }
}
