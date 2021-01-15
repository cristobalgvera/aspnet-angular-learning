using System;
using System.Collections.Generic;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var names = new List<string> { "Peter", "John", "Douglas" };

                Console.WriteLine(names[3]); // Index out of bounds
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}