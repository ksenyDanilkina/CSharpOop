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
            var persons = new List<Person> { new Person("Иван", 25), new Person("Ирина", 44),
                new Person("Ирина", 25),  new Person("Алексей", 44), new Person("Игнат", 15) };

            var uniqueNames = persons.Select(p => p.Name).Distinct().ToList();

            Console.WriteLine("Имена: " + string.Join(", ", uniqueNames));

            var peopleUnder18 = persons.Where(p => p.Age < 18).ToList();

            if (peopleUnder18.Count == 0)
            {
                Console.WriteLine("В списке нет людей младше 18.");
            }
            else
            {
                var averageAge = peopleUnder18.Select(p => p.Age).Average();

                Console.WriteLine("Средний возраст людей младше 18: " + averageAge);
            }

            var groupedByAverageAgePersons = persons.GroupBy(p => p.Name)
                .ToDictionary(p => p.Key, p => p.Select(x => x.Age).Average());

            var stringBuilder = new StringBuilder();

            foreach (var keyValuePair in groupedByAverageAgePersons)
            {
                stringBuilder.Append(keyValuePair.Key).Append(" - ").Append(keyValuePair.Value).AppendLine();
            }

            Console.WriteLine(stringBuilder);

            var personsFrom20To45Age = persons.Where(p => (p.Age >= 20 && p.Age <= 45))
                .OrderByDescending(p => p.Age).ThenBy(p => p.Name);

            Console.WriteLine("Имена людей в возрасте от 20 до 45 лет: " + string.Join("; ", personsFrom20To45Age));
        }
    }
}
