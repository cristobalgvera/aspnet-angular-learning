using System;
using System.Collections.Generic;

namespace console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var myCollection = new Collection<Person>();

            myCollection.Add(new Person("John"));

            myCollection.List.ForEach(person => Console.WriteLine(person.Name));

            Console.WriteLine(myCollection.GetAtPosition(0).Name);
        }

        private class Person
        {
            public Person(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
        }

        private class Collection<T>
        {
            public List<T> List { get; set; }

            public Collection()
            {
                List = new List<T>();
            }

            public void Add(T element) => List.Add(element);

            public T GetAtPosition(int position)
            {
                try
                {
                    return List[position];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            public T Remove(int position)
            {
                try
                {
                    var element = List[position];
                    List.RemoveAt(position);
                    return element;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}