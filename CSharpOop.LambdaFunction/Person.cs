namespace CSharpOop.LambdaFunction
{
    class Person
    {
        private string name;
        private int age;

        public string GetName()
        {
            return name;
        }

        public int GetAge()
        {
            return age;
        }
        
        public Person(string name, int age)
        {            
            this.name = name;
            this.age = age;
        }
    }
}
