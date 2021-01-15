using System;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var person = new Person("Allan");

            Console.WriteLine($"Name: {person.Name} - Age: {person.Age}");
        }
    }

    internal class Person
    {
        public Person()
        {
        }

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, string lastName, int age, DateTime birthday)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
    }
}