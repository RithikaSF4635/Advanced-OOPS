using System;
using OperatorOverLoading;
namespace OperationOverLoading;
public class Program
{
    public static void Main(string[] args)
    {
        Box box1=new Box(1.2,3.2,4.2);
        Box box2=new Box(5.5,6.5,7.5);

        Console.WriteLine(box1.CalculateVolume());
        Console.WriteLine(box2.CalculateVolume());

        Box box3=Box.Add(box1,box2);
        Box box4=box1+box2;

    }
}