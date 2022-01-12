using System;
using System.Threading.Tasks;

namespace TPL_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task tast = new Task(() => Console.WriteLine("Hello Task"));
            //tast.Start();
            //OR
            Task task = Task.Run(() => Console.WriteLine("Hello Task"));
            task.Wait();

            Console.WriteLine("Завершение метода Main");

        }
    }
}
