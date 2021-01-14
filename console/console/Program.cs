using System;
using System.Diagnostics;

namespace console
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string name = "I'm Cris";
            var number = 3;

            Console.WriteLine(name + number);

            number = 5;

            Console.WriteLine(name + number);

            var date = DateTime.Now;
            const bool civilState = true;

            Console.WriteLine(!civilState);
            Console.WriteLine(date);

            const State state = State.Active;

            Console.WriteLine(state);

            var isMeantToBeNull = CanBeNull();

            Debug.Assert(isMeantToBeNull != null, nameof(isMeantToBeNull) + " != null");
            Console.WriteLine(isMeantToBeNull);
        }

        private static bool? CanBeNull() => new Random().Next(100) > 50 ? (bool?) null : true;
    }

    internal enum State
    {
        Active,
        Inactive
    }
}
