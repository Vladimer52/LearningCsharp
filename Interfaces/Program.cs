using System;

namespace Interfaces
{
    class Person : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Человек идет");
        }
    }

    class Car : IMovable
    {
        public void Move()
        {
            Console.WriteLine("машина едет");
        }
    }
    class Program
    {
        static void Action(IMovable movable)
        {
            movable.Move();
        }
        static void Main(string[] args)
        {
            Person person = new Person();
            Car car = new Car();

            Action(person);
            Action(car);
            Console.WriteLine("Hello World!");
        }
    }
}
