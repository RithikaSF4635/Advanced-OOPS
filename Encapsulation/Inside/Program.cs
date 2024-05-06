using System;
namespace Inside;
public class Program
{
    public static void Main(string[] args)
    {
        First sample=new First();
        Console.WriteLine(sample.PrivateOut);
        Console.WriteLine(sample.PublicNumber);

        Second sample1=new Second();
        Console.WriteLine(sample1.ProtectedNumberOut);
        Console.WriteLine(sample1.InternalProtectedOut);
    }
}