using System;

namespace Additional_classes_and_structures_C_Sharp
{
    internal class Program
    {
        #region Lazy
        class Library
        {
            private string[] _books = new string[99];

            public void GetBook()
            {
                Console.WriteLine("Выдаем книгу читателю");
            }
        }

        class Reader
        {
            public void ReadBook()
            {
                Lazy<Library> library = new Lazy<Library>(); // не инициализируется, если не используется
                library.Value.GetBook();
                Console.WriteLine("Читаем книгу");
            }

            public void ReadEBook() => Console.WriteLine("Читаем электронную книгу");
        }
        #endregion


        static void Main(string[] args)
        {
            #region Lazy
            Reader reader = new Reader();
            reader.ReadEBook();
            #endregion

            var people = new string[] { "Tom", "Bob", "Alice", "Kate", "Sam" };

            string? first = Array.Find(people, person => person.Length > 3); //ищем номер элемента, в котором длина больше 3
            Console.WriteLine(first);
            string? last = Array.Find(people, person => person.Length > 3); //то же самое, с конца
            Console.WriteLine(last);

            Array.Reverse(people, 1, 3); // изменяем порядок 3 элементов, начиная с индекса 1

            foreach (string p in people)
            {
                Console.Write($"{p}, ");
            }

            Array.Sort(people, 1 , 3);// сортируем 3 элемента с индекса 1
            foreach (string p in people)
            {
                Console.Write($"{p}, ");
            }

        }
    }
}
