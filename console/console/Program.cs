namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var dog = new Dog();
            var cat = new Cat();

            DoAnimalTalk(dog);
            DoAnimalTalk(cat);

            DoAnimalRun(dog);
            DoAnimalRun(cat);
        }

        private static void DoAnimalTalk(IAnimal animal) => animal.Talk();
        private static void DoAnimalRun(IAnimal animal) => animal.Run();
    }
}