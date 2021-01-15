using System;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a number lower than 100");
            var number = int.Parse(Console.ReadLine()); // Will fail if no input

            Console.WriteLine("While loop");

            while (number <= 100)
            {
                Console.WriteLine(number);
                number++;
            }

            Console.WriteLine("Do... While loop");

            do
            {
                Console.WriteLine(number);
                number++;
            } while (number <= 130);
        }
    }
}