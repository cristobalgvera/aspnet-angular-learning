using System;
using System.Linq;

namespace console_app
{
    class Program
    {
        public static void Main(string[] args)
        {
            MeetAlien();
            Console.WriteLine("----------------");
            MeetAlien();
            Console.WriteLine("----------------");

            Console.WriteLine("Insert a number to square it");
            var squaredNumber = Square(Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine($"Result is: {squaredNumber}");
            Console.WriteLine("----------------");

            Console.WriteLine("Insert a number");
            var userNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(IsEven(userNumber) ? $"{userNumber} is even" : $"{userNumber} is not even");
            Console.WriteLine("----------------");

            const string someString = "This is a string word";
            var splattedString = someString.Split(" ").ToList();

            Console.WriteLine(someString);
            Console.WriteLine("-------- Splitted word --------");
            splattedString.ForEach(Console.WriteLine);
        }

        private static void MeetAlien()
        {
            var random = new Random();
            var name = $"X-{random.Next(1000, 5001)}";
            var age = random.Next(70, 501);
            Console.WriteLine($"Hi, I'm {name},");
            Console.WriteLine($"I'm {age} years old.");
            Console.WriteLine($"I'm an alien...");
        }

        private static double Square(double number) => Math.Pow(number, 2);

        private static bool IsEven(double number) => number % 2 == 0;
    }
}