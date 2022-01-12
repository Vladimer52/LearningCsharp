using System;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Tom", 15);
            Type type = user.GetType();

            Console.WriteLine(type.ToString());
        }
    }
    [AgeValidation(18)] //аттрибут, который присваевает значение поля Age = 18
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
        public void Display() => Console.WriteLine($"Имя: {Name}, Возраст:{Age}");

        public int Payment(int hours, int perhour) => hours* perhour;
    }

    public class AgeValidationAttribute : System.Attribute
    {
        public int Age { get; set; }
        public AgeValidationAttribute()
        {

        }
        public AgeValidationAttribute(int age)
        {
            Age = age;
        }
    }
}
