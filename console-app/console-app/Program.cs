using System;
using System.Linq;

namespace console_app
{
    class Program
    {
        public static void Main(string[] args)
        {
            var cat = new Cat
            {
                Name = "Paco",
                Age = 3
            };

            Console.WriteLine($"Cat angry: {cat.IsAngry}");
            
            cat.CheckAngry();
            Console.WriteLine($"Cat angry: {cat.IsAngry}");

        }
    }
}