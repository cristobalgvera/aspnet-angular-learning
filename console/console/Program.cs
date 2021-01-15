using System;
using System.Collections.Generic;
using System.Linq;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var myList = new List<string> { "Hello" };

            myList.ForEach(Console.WriteLine);

            myList.Add("World");

            var newList = myList.Select(word => $"{word} XX").ToList();

            newList.Add("!");

            newList.ForEach(Console.WriteLine);
        }
    }
}