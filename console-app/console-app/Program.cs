using System;

namespace console_app
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Skynet!";
            Console.ForegroundColor = ConsoleColor.Red;

            const int someNumber = 3;

            Console.WriteLine($"Hello World! Number: {someNumber}");
            Console.WriteLine("What's your name?");

            var name = Console.ReadLine();

            Console.WriteLine($"Hello {(name != "" ? name : "user")}");

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
            
            Console.WriteLine($"{consoleNumber} / 3 = {consoleNumber / 3}");

            Console.ReadKey();
        }
    }
}