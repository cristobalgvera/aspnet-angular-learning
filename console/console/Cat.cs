using System;

namespace console
{
    internal class Cat : IAnimal
    {
        public void Talk() => Console.WriteLine("Miau");
    }
}