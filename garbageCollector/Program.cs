using System;

namespace garbageCollector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test();
           // GC.Collect(); //вызывает очистку неиспользуемых ресурсов, деструкторы классов
        }
        private static void Test()
        {

            using Country country = new Country() ; //применяется только для классов, в которых реализован интерфейс IDisposable
                country.x = 10;
                country.y = 20;
            //ссылки на область в куче будут удалены, после выполнения метода Test
        }

    }

    class Country :IDisposable
    {
        public int x;
        public int y;

        public void Dispose()
        {
            Console.Beep();
            Console.WriteLine("Disposed");
        }
    }
}
