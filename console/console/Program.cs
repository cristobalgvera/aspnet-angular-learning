using System;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var myTuple = ("First", 10); 

            Console.WriteLine(myTuple.Item1);

            var (name, age) = ("Eduardo", 29);

            Console.WriteLine($"I'm {name} and I have {age} years old");
        }
    }
}