using System;
namespace MetroCardManagement;
public class Program
{
    public static void Main(string[] args)
    {
        
        FileHandling.Create();
        //Operations.AddDefaultValues();
        FileHandling.ReadFromCSV();
        Operations.MainMenu();
        FileHandling.WriteToCSV();

    }
}