using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpOop.LambdaFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Иван", 25);
            Person person2 = new Person("Ирина", 44);
            Person person3 = new Person("Ирина", 66);
            Person person4 = new Person("Алексей", 44);
            Person person5 = new Person("Игнат", 15);

            List<Person> persons = new List<Person> { person1, person2, person3, person4, person5 };

            string uniqueNames = string.Join(", ", persons.Select(person => person.GetName()).Distinct().ToList());

            Console.WriteLine("Имена: " + uniqueNames);

            List<Person> peopleUnder18 = persons.Where(person => person.GetAge() < 18).ToList();           

            if (peopleUnder18.Count == 0)
            {
                Console.WriteLine("В списке нет людей младше 18.");
            }
            else
            {
                double averageAge = peopleUnder18.Select(person => person.GetAge()).Average();

                Console.WriteLine("Средний возраст людей младше 18: " + averageAge);
            }                  

            Dictionary<string, double> groupedPersons = persons.GroupBy(person => person.GetName()).
                ToDictionary(name => name.Key, age => age.Select(person => person.GetAge()).ToList().Average());

            StringBuilder stringBuilder = new StringBuilder();

            foreach (KeyValuePair<string, double> keyValue in groupedPersons)
            {               
                stringBuilder.Append(keyValue.Key).Append(" - ").Append(keyValue.Value).AppendLine();
            }

            Console.WriteLine(stringBuilder);

            List<string> personsNamesFrom20To45Age = persons.Where(person => (person.GetAge() >= 20 && person.GetAge() <= 45)).
                OrderByDescending(person => person.GetAge()).ThenBy(person => person, new PersonAgeComparer()).
                Select(person => person.GetName()).ToList();

            Console.WriteLine("Имена людей в возрасте от 20 до 45 лет: " + string.Join(", ", personsNamesFrom20To45Age));
        }
    }
}
