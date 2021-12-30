using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Collections
{
    internal class Program
    {
        #region Observable
        static void observableFunc()
        {
            System.Collections.ObjectModel.ObservableCollection<User> users = new System.Collections.ObjectModel.ObservableCollection<User>
            {
                new User() { Name = "Bill"},
                new User() { Name = "Tom"},
                new User() { Name = "alice"}
            };

            users.CollectionChanged += Users_CollectionChanged;

            users.Add(new User() { Name = "Bob" });
            users.RemoveAt(1);
            users[0] = new User() { Name = "Adrew" };

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }

        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    User newUser = e.NewItems[0] as User;
                    Console.WriteLine($"Добавлен новый пользователь {newUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    User oldUser = e.OldItems[0] as User;
                    Console.WriteLine($"Удален пользователь {oldUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    User replacedUser = e.OldItems[0] as User;
                    User replacingUser = e.NewItems[0] as User;
                    Console.WriteLine($"пользователь {replacedUser.Name} заменен на {replacingUser.Name}");
                    break;
            }
        }

        class User
        {
            public string Name { get; set; }
        }
        #endregion

        static void arrayList()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(2.3);
            arrayList.Add( "Hello" );

            foreach (object item in arrayList)
            {
                Console.WriteLine(item);
            }
            arrayList.RemoveAt(0); //удаляем первый элемент
            arrayList.Reverse(); //переворачиваем  список

           // Console.WriteLine(arrayList[0]); //получаем элемент по индексу
        }

        static void listFunc()
        {
            List<int> list = new List<int>() { 1, 2, 4, 45 };

            list.Add(1);
            list.AddRange(new int[] { 6,4,7});

            list.Insert(2, 666);//вставляем на место 3 число 666

            list.RemoveAt(1); // удаляем второй элемент

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


        }

        #region IEnumerable
        class Week : IEnumerable
        {
            string [] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                         "Friday", "Saturday", "Sunday" };

            public IEnumerator GetEnumerator()
            {
                return days.GetEnumerator();
            }
        }

        static void enumerableFunc()
        {
            Week week = new Week();
            foreach(var item in week)
            {
                Console.WriteLine(item);
            }
        }
        #endregion
        static void Main(string[] args)
        {
            arrayList();
            Console.WriteLine("========================");
            listFunc();
            Console.WriteLine("========================");
            observableFunc();
            Console.WriteLine("========================");
            enumerableFunc();
            Console.WriteLine("========================");
            Console.WriteLine("Hello World!");
        }
    }
}
