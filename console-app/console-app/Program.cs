using System;

namespace console_app
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Skynet!";
            Console.ForegroundColor = ConsoleColor.Red;

            const int someNumber = 3;

            Console.WriteLine($"Hello World! Number: {someNumber}");
            Console.WriteLine("What's your name?");

            var name = Console.ReadLine();
            
            Console.WriteLine($"Hello {(name != "" ? name : "user")}");

            Console.ReadKey();
        }
    }
}