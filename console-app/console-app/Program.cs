using System;

namespace console_app
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Skynet!";
            Console.ForegroundColor = ConsoleColor.Green;

            const int someNumber = 3;

            Console.WriteLine($"Hello World! Number: {someNumber}");
            Console.WriteLine("What's your name?");

            var name = Console.ReadLine();

            Console.WriteLine($"Hello {(!string.IsNullOrEmpty(name) ? name : "user")}");

            Console.WriteLine("Write a number below :)");
            var consoleNumber = 0.0;

            try
            {
                consoleNumber = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;

            // Inline conditional
            Console.WriteLine(consoleNumber >= 13
                ? $"{consoleNumber} / 3 = {consoleNumber / 3}"
                : $"{consoleNumber} * 3 = {consoleNumber * 3}");

            // Multiline conditional
            if (!string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name isn't empty, nice!");
            }
            else
            {
                Console.WriteLine("Name is empty, what a pity");
            }

            if (!string.IsNullOrEmpty(name) && consoleNumber > 20)
            {
                Console.WriteLine("Requirements passed");
            }
            else
            {
                Console.WriteLine("Requirements aren't passed");
            }

            Console.WriteLine("Write a number between 1 and 5: ");
            consoleNumber = Convert.ToDouble(Console.ReadLine());

            switch (consoleNumber)
            {
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                case 3:
                    Console.WriteLine("Three");
                    break;
                case 4:
                    Console.WriteLine("Four");
                    break;
                case 5:
                    Console.WriteLine("Five");
                    break;
                default:
                    Console.WriteLine("Ups, wrong number");
                    break;
            }
        }
    }
}