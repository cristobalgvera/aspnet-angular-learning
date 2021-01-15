using System;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 or 2");
            var number = int.Parse(Console.ReadLine()); // Will fail if no input

            switch (number)
            {
                case 1:
                    Console.WriteLine(number + 60);
                    break;
                case 2:
                    Console.WriteLine(number);
                    break;
                default:
                    Console.WriteLine("No valid input");
                    break;
            }
        }
    }
}