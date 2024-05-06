using System;
namespace OverRidding;
public class Animal
{
    public virtual void Eat()
    {
        Console.WriteLine("Animal eats food");
    }
}
public class Dog:Animal
{
    public override void Eat()
    {
        Console.WriteLine("Dog eats food");
    }
}
public class Pomerian:Dog
{
    public override void Eat()
    {
        Console.WriteLine("Pomerian eats food");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Animal animal=new Animal();
        Dog dog=new Dog();
        Pomerian pomerian=new Pomerian();

        animal.Eat();
        dog.Eat();
        pomerian.Eat();
    }
}