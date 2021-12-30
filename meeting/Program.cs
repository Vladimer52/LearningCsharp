using System;
using System.Collections.Generic;

namespace meeting
{
    public struct S : IDisposable
    {
        private bool dispose;
        public void Dispose()
        {
            dispose = true;
        }
        public bool GetDispose()
        {
            return dispose;
        }
    }

    public class A
    {
        public virtual void Print1()
        {
            Console.Write("A");
        }
        public void Print2()
        {
            Console.Write("A");
        }
    }
    public class B : A
    {
        public override void Print1()
        {
            Console.Write("B");
        }
    }
    public class C : B
    {
        new public void Print2()
        {
            Console.Write("C");
        }
    }

    class Account<T>
    {
        public T Id { get; set; }
        public int Sum { get; set; }
    }

    delegate int Square(int x);
    class Program
    {
        delegate bool IsEqual(int x);
        public static int[] nums = { 3, 5, 7, 4, 2, 4, 1 };

        public static int[] sortFunc(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if(numbers[i]> numbers[j])
                    {
                        (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                    }
                }
            }
            return numbers;
        }

        private static int Sum(int[]numbers, IsEqual func)
        {
            int summ = 0;
            foreach(var n in numbers)
            {
                if(func(n)) //если соответствует делегату, то прибавляем
                summ += n;
            }

            return summ;
        }

        static void Main(string[] args)
        {
            int[] integers = { 54, 7, -41, 2, 4, 2, 89, 33, -5, 12 };
            bool isMatch = true;
            Square square = i => i * i;
            Account<int> account = new Account<int>();
            account.Id = 1;
            Account<string> account1 = new Account<string>();
            account1.Id = "aaa";

            var c = new C();
            A a = c;

            int z = square(6);
            Console.WriteLine(z);

            int result = Sum(integers, x => x % 2 == 0); //сложить четные числа из массива
            Console.WriteLine(result);

            int[] num = sortFunc(nums);
            if (isMatch is true)
            {
                foreach (var n in num)
                {
                    Console.WriteLine(n);
                }
            }



            a.Print2();
            a.Print1();
            c.Print2();
        }
    }
}
