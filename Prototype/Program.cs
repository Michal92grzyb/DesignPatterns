using System;

namespace Prototype
{
    // Create object based on objest of same class.
    class Sheep
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public Sheep(string name, string category)
        {
            Name = name;
            Category = category;
        }

        public Sheep Clone()
        {
            // worth mentioning that MemberWiseClone() will only create a shallow copy of object. It will not create new objects that are part of main objects, but use
            // references to currently existing and used by primary object
            return MemberwiseClone() as Sheep;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var original = new Sheep("Jolly", "Mountain Sheep");
            Console.WriteLine(original.Name); // Jolly
            Console.WriteLine(original.Category); // Mountain Sheep

            var cloned = original.Clone();
            cloned.Name = "Dolly";
            Console.WriteLine(cloned.Name); // Dolly
            Console.WriteLine(cloned.Category); // Mountain Sheep
            Console.WriteLine(original.Name); // Dolly

            Console.ReadLine();
        }
    }
}
