using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace console_app
{
    class Program
    {
        public static void Main(string[] args)
        {
            var friends = new List<string>
            {
                "Daniela",
                "Rene"
            };

            string[] languages =
            {
                "C#",
                "Java",
                "JavaScript",
                "TypeScript",
                "Python"
            };


            friends.ForEach(WriteLine);
            
            friends.Add("Cristóbal");
            friends.ForEach(WriteLine);

            friends.Remove("Rene");
            friends.ForEach(WriteLine);

            for (var index = 0; index < languages.Length; index++)
            {
                var language = languages[index];
                WriteLine($"{index + 1}. {language}");
            }

            languages
                .Where(language => language.Contains("Java"))
                .ToList()
                .ForEach(WriteLine);
        }
    }
}