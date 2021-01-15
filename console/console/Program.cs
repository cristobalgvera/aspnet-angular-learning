namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var dog = new Dog();
            var cat = new Cat();

            // Interface contract method
            DoAnimalTalk(dog);
            DoAnimalTalk(cat);

            // Interface default method
            DoAnimalRun(dog);
            DoAnimalRun(cat);

            // Abstract class abstract method
            DoAnimalNoise(dog);
            DoAnimalNoise(cat);
        }

        private static void DoAnimalTalk(IAnimal animal) => animal.Talk();

        private static void DoAnimalRun(IAnimal animal) => animal.Run();

        private static void DoAnimalNoise(Animal animal) => animal.Noise();
    }
}