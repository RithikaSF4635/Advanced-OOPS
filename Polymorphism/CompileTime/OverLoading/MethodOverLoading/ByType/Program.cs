using System;
namespace ByType;
public class Program
{
    public static void Main(string[] args)
    {
        //Add method to add integer
        int result=Add(3,4);
        double result2=Add(3,4);
        string result1=Add("3","4");
    }
    public static int Add(int a,int b)
    {
        return a+b;
    }
    public static double Add(double a,double b)
    {
        return a+b;
    }
    public static string Add(string a,string b)
    {
        return a+b;
    }
}