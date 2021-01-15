using System;
using System.Threading;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(CalculateExecutionTime(SendMessage));
            Console.WriteLine(CalculateExecutionTime(() => Thread.Sleep(500))); // Delegate can be an anonymous function

            Func<int, int, bool> func = Equals; // To use a function that return a value as a variable
            // var func = new Func<int, int, int>(Equals); -> A fancy way of doing above stuff

            var result = func(5, 6);
            Console.WriteLine(result);

            Action<string> action = Greet; // To use a function that return VOID as a variable
            // var action = new Action<string>(Greet); -> A fancy way of doing above stuff

            action("Hello");

            // An ugly way to make inline functions and store it in variables, but works well
            var inLineAction = new Action<string>((string word) => Console.WriteLine($"Hello World! - {word}"));
            var inLineFunc = new Func<int, int>((int number) => 4 + number);

            inLineAction("YOUUU!");
            Console.WriteLine(inLineFunc(5));
        }

        private delegate void DelegateExample(); // Used to provide a method (delegate) to a function as parameter

        private static void SendMessage() => Thread.Sleep(1000);

        private static double CalculateExecutionTime(DelegateExample delegateExample)
        {
            var startingTime = DateTime.Now;
            delegateExample();
            var endingTime = DateTime.Now;
            return (endingTime - startingTime).TotalMilliseconds;
        }

        private static bool Equals(int a, int b) => a == b;

        private static void Greet(string message) => Console.WriteLine(message);
    }
}