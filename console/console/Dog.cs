using System;

namespace console
{
    internal class Dog : Animal, IAnimal
    {
        public void Talk() => Console.WriteLine("Guau");

        public override void Noise() => Console.WriteLine("Dog noise");
    }
}