using System;

namespace console
{
    internal class Cat : Animal, IAnimal
    {
        public void Talk() => Console.WriteLine("Miau");

        public override void Noise() => Console.WriteLine("Cat noise");
    }
}