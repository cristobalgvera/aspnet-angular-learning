using System;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your age");
            var age = int.Parse(Console.ReadLine()); // Will fail if no input

            if (age >= 18)
                Console.WriteLine("Your are older");
            else if (age == 13)
                Console.WriteLine("You have 13!!");
            else
                Console.WriteLine("You're too young");

            // Ternary operator way

            Console.WriteLine(age >= 18 ? "Your are older" : "You're too young");
        }
    }
}