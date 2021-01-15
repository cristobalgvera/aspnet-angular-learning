using System;
using System.Threading.Tasks;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Before async method");
            MethodAsync();
            Console.WriteLine("After async method");
            Console.ReadLine(); // If you wait 2,5 seconds, async task will be done
        }

        private static async void MethodAsync()
        {
            Console.WriteLine("Inside async method");
            await AwaitTask();
            Console.WriteLine("Async task done");
        }

        private static Task AwaitTask() => Task.Delay(2500);
    }
}