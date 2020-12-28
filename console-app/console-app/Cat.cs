namespace console_app
{
    public class Cat
    {
        public string? Name { get; set; }
        public int Age { get; set; }

        public bool IsAngry { get; private set; } = false;

        public void CheckAngry() => IsAngry = Name == null || Name.Contains("a");
    }
}