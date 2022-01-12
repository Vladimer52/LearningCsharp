using System;
using System.Threading;

namespace multiThreading
{
    class Counter
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    internal class Program
    {
        static int x = 0;
        static object locker = new object();
        static void Main(string[] args)
        {
            Thread t = Thread.CurrentThread; // получаем текущий поток
            Console.WriteLine($"Имя потока {t.Name}");
            Console.WriteLine($"Запущен ли поток {t.IsAlive}");
            Console.WriteLine($"Приоритет потока {t.Priority}");
            Console.WriteLine($"Статус потока {t.ThreadState}");

            Counter counter = new Counter();
            counter.x = 1;
            counter.y = 2;

            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = "поток " + i.ToString();
                myThread.Start();
            }
           /* Thread secondThread = new Thread(new ParameterizedThreadStart(DoubleCount));
            secondThread.Start(counter);*/

            for (int i = 9; i > 0; i--)
            {
                Console.WriteLine("Главный поток");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }


        }

        public static void Count()
        {
            lock (locker)
            {
                x = 1;
                for (int i = 9; i > 0; i--)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Console.WriteLine(i * i);
                    Thread.Sleep(100);
                }
            }
        }

        public static void DoubleCount(object n)
        {
            Counter counter = (Counter)n;

            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Второй поток");
                Console.WriteLine(i*counter.x*counter.y); //для случая, когда нужно в поток передать  несколько параметров, используем классовый подход
                                                            // но подход, когда в Thread.Start передается параметр не является потокобезопасным
                                                            //поэтому лучше операции выполнять в отдельном классе и запускать делегат без параметров
                Thread.Sleep(400);
            }
        }


    }
}
