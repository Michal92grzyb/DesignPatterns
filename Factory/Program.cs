using System;

namespace Factory
{
    class Program
    {
        //Factory creates object instance without exposing instantiation logic

        public interface IDoor
        {
            int GetHeight();
            int GetWidth();
        }

        public class WoodenDoor : IDoor
        {
            private int Height { get; set; }
            private int Width { get; set; }

            public WoodenDoor(int height, int width)
            {
                this.Height = height;
                this.Width = width;
            }

            public int GetHeight()
            {
                return this.Height;
            }
            public int GetWidth()
            {
                return this.Width;
            }
        }

        public static class DoorFactory
        {
            public static IDoor MakeDoor(int height, int width)
            {
                return new WoodenDoor(height, width);
            }
        }

        static void Main(string[] args)
        {
            // When creating an object is not just a few assignments and involves some logic, 
            // it makes sense to put it in a dedicated factory instead of repeating the same code everywhere.
            var door = DoorFactory.MakeDoor(80, 30);
            Console.WriteLine($"Height of Door : {door.GetHeight()}");
            Console.WriteLine($"Width of Door : {door.GetWidth()}");
        }
    }
}
