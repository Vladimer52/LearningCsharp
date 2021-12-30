using System;

namespace events
{

    public class Account
    {
        public int Sum { get; private set; }

        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;
        public Account(int sum)
        {
            Sum = sum;
        }

        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счет поступило {sum}");
        }
        public void Take(int sum)
        {
            if(sum <= Sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета снято {sum}");
            } else
            {
                Notify?.Invoke($"Недостаточно средств, текущий баланс {Sum}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(1000);
            account.Notify += mes => Console.WriteLine(mes); // установка лямбда-выражения в качестве обработчика событий
            account.Put(1000);
            account.Take(1500);
            Console.WriteLine($"Sum = {account.Sum}");
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
