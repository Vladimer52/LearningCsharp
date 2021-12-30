using System;

namespace pattern
{

    public class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Работаю я");
        }
    }

    public class Manager : Employee
    {
        public override void Work()
        {
            Console.WriteLine("работаем!");
        }
        public bool isOnVocation { get; set; }
    }

    internal class Program
    {


        static void UseEmployee(Employee employee)
        {
            if(employee is Manager manager && manager.isOnVocation == false)
            {
                manager.Work();
            }
        }
        static void Main(string[] args)
        {
            Employee employee = new Manager();
            switch (employee)
            {
                case Manager manager when manager.isOnVocation == false: //используется WHEN для задания доп. условия
                    manager.Work();
                    break;
                case null:
                    Console.WriteLine("Объект не задан");
                    break;
                    default: Console.WriteLine("объект не менеджер");
                    break;
            }
            UseEmployee(employee); 
            Console.WriteLine("Hello World!");
        }

    }
}
