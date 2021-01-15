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

            // Usage of static methods
            Console.WriteLine($"Sum of three numbers: {Math.Sum(4, 6, 7)}");
            Console.WriteLine($"Subtraction of two numbers: {Math.Subtraction(4, 6)}");
        }

        private class Person
        {
            public string Concatenate(string name, string lastName) => $"{name} {lastName}";

            public int Sum(int a, int b) => a + b;
        }

        private class Math
        {
            // Overload example
            public static int Sum(int a, int b) => a + b;

            public static int Sum(int a, int b, int c) => a + b + c;

            // Default parameters values example
            public static int Subtraction(int a, int b, int c = 0) => a - b - c;
        }
    }
}