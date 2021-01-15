using System;

namespace console
{
    internal class Dog : IAnimal
    {
        public void Talk() => Console.WriteLine("Guau");
    }
}