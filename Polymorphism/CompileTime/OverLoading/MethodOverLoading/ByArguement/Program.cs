using System;
namespace ByArguement;
public class Program
{
    public static void Main(string[] args)
    {
        Add(1,2,3);
        Add(1,2);
    }
    public static void Add(int A,int B,int C)
    {
        Console.WriteLine(A+B+C);
    }
    public static void Add(int A,int B)
    {
        Console.WriteLine(A+B);
    }
}