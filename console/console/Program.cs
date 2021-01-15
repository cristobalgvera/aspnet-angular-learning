using System;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var person = new Person();

            var fullName = person.Concatenate("John", "Cage");

            Console.WriteLine(fullName);

            Console.WriteLine(person.Sum(4, 6));
        }

        private class Person
        {
            public string Concatenate(string name, string lastName) => $"{name} {lastName}";

            public int Sum(int a, int b) => a + b;
        }
    }
}