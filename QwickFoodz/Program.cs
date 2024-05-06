using System;
namespace QwickFoodz;
public class Program
{
    public static void Main(string[] args)
    {
        //FileHandling.Create();
        Operations.AddDefault();
        FileHandling.ReadFromCsv();
        Operations.MainMenu();
        FileHandling.WriteToCsv();
    }
}