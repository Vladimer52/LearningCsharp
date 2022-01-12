using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }
    }

    public class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            List<User> users = new List<User>()
            {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var selectedUsers = from u in users
                                from lang in u.Languages
                                where u.Age > 23
                                where lang == "Английский"
                                select u;
            foreach (var user in selectedUsers)
                Console.WriteLine($"{user.Name} - {user.Age}");


            var selectedTeams = from t in teams
                                where t.ToUpper().StartsWith("Б")
                                orderby t//упорядычиваем по возрастанию
                                select t; //выбираем нужные команды
            
            foreach (var team in selectedTeams)
                Console.WriteLine(team);

            List<int> num = new List<int> { 1, 2, 3, 5, 7, 5, 4, 44 };
            IEnumerable<int> evens = from i in num
                                     where i%2 == 0
                                     select i;
            IEnumerable<int> odd = num.Where(i => i%2 != 0 && i > 4);
            foreach(int i in odd)
                Console.WriteLine(i);
            Console.WriteLine();
            foreach (var n in evens)
                Console.WriteLine(n);

            //====================================//

            List<Phone> phones = new List<Phone>
{
    new Phone {Name="Lumia 430", Company="Microsoft" },
    new Phone {Name="Mi 5", Company="Xiaomi" },
    new Phone {Name="LG G 3", Company="LG" },
    new Phone {Name="iPhone 5", Company="Apple" },
    new Phone {Name="Lumia 930", Company="Microsoft" },
    new Phone {Name="iPhone 6", Company="Apple" },
    new Phone {Name="Lumia 630", Company="Microsoft" },
    new Phone {Name="LG G 4", Company="LG" }
};
            var phoneGroup = from phone in phones
                             group phone by phone.Company;
            foreach (IGrouping<string, Phone> phone in phoneGroup)
            {
                Console.WriteLine(phone.Key);
                foreach(var t in phone)
                    Console.WriteLine(t.Name);
                Console.WriteLine();
            }
        }
    }
}
