using System;

namespace strings
{
    internal class Program
    {
        static void metodsStrings()
        {
            string s1 = "Hello";
            string s2 = null;
            string s3 = new string('a', 6); // будет выведено aaaaaa
            string s4 = new string(new char[] { 'a', 'b', 'c' });

            string s5 = String.Concat(s1, s3);
            Console.WriteLine($" Concat s1 + s3 = {s5}");

            string[] values = { s1, s4, s3 };
            String s6 = String.Join(" ", values);
            Console.WriteLine($"String Join - {s6}");

            //сравеннеи строк
            int result = String.Compare(s1, s3);
            if(result > 0)
            {
                Console.WriteLine("строка s1 по алфавиту раньше s3");
            }
            else if (result < 0)
            {
                Console.WriteLine("строка s1 по алфавиту позже s3");
            } else
            {
                Console.WriteLine("строки идентичны");
            }

            //поиск в строке
            char ch = 'o';
            int indexOfChar = s1.IndexOf(ch);
            Console.WriteLine(indexOfChar);

            if (s5.EndsWith(ch))
            {
                Console.WriteLine($"строка '{s5}' заканчивается символом {ch}");
            } else
            {
                Console.WriteLine($"строка '{s5}' не заканчивается символом {ch}");
            }

        }

        static void formatingString()
        {
            double number = 23.7;
            string s1 = String.Format("{0:C}", number); //форматирование для валюты
            //string s2 = String.Format("{0:d}", number); //форматирование целых значений

            string s3 = String.Format("{0:f4}", number); //форматирование дробного числа с точностю 4 знака

            string s4 = String.Format("{0:P1}", number); //вывод процентов

            long num = 19876543210;
            string s5 = String.Format("{0:+# (###) ###-##-##}", num);
            string s6 = num.ToString("{+# ### ### ## ##}");
            string[] values = new string[] { s1, s3, s4, s5, s6 };
            foreach(string value in values)
            {
                Console.WriteLine(value);
            }
            
        }

        static void Main(string[] args)
        {
            metodsStrings();

            formatingString();
        }
    }
}
