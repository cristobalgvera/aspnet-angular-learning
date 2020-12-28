using System;

namespace console_app
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("How many outputs do you want?");

            var outputsAmount = Convert.ToInt16(Console.ReadLine());

            for (var exponent = 1; exponent <= outputsAmount; exponent++)
            {
                var result = Math.Pow(2, exponent);
                Console.WriteLine($"2^{exponent} = {result}");
            }

            var diceSum = 0;
            int diceValue;
            var random = new Random();

            // while (diceValue > 1)
            // {
            //     diceValue = random.Next(1, 7);
            //     Console.WriteLine($"Dice: {diceValue}");
            //     diceSum += diceValue;
            // }

            Console.WriteLine("Press enter to roll the dice until dice been 1");

            do
            {
                Console.ReadKey();
                diceValue = random.Next(1, 7);
                Console.WriteLine($"Dice: {diceValue}");
                diceSum += diceValue;
            } while (diceValue > 1);

            Console.WriteLine($"Dice values sum: {diceSum}");
        }
    }
}