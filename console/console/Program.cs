using System;
using System.Collections.Generic;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            var number = int.Parse(Console.ReadLine()); // Will fail if no input

            for (var i = 0; i < number; i++)
            {
                var result = i * number;
                Console.WriteLine($"{i} * {number} = {result}");
            }

            var namesList = new List<string> { "Jhon", "Peter", "Douglas" };

            foreach (var name in namesList)
            {
                Console.WriteLine($"I'm {name}");
            }

            // LINQ way
            namesList.ForEach(Console.WriteLine); // Just names
            namesList.ForEach(name => Console.WriteLine($"I'm {name}")); // Same output as line 21
        }
    }
}