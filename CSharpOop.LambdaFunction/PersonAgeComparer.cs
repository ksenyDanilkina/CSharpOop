using System.Collections.Generic;

namespace CSharpOop.LambdaFunction
{
    class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person person1, Person person2)
        {
            return person1.GetAge().CompareTo(person2.GetAge());
        }
    }
}
