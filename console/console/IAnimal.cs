using System;

namespace console
{
    internal interface IAnimal
    {
        public void Run() => Console.WriteLine("I'm running!");

        public void Talk();
    }
}