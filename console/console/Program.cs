using System;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int aNumber = 103;

            // Usage of extension method called "IsEven" for int objects
            Console.WriteLine($"Number {aNumber} is {(aNumber.IsEven() ? "even" : "odd")}");
        }
    }
}