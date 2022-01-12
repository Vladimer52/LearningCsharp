using System;

namespace DateTime1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime(2015, 7, 21, 18, 30, 0); // год, месяц, день, час, минута, секунда
            Console.WriteLine(dateTime);
            Console.WriteLine(DateTime.Now); // текущее время
            Console.WriteLine(DateTime.UtcNow); // текущее время по UTC
            Console.WriteLine(DateTime.Today);
        }
    }
}
