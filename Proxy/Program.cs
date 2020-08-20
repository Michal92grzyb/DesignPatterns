using System;

namespace Proxy
{
    // Create 2 classes. They share same interface. First class (proxy) has interface implementation as field, and is necessary for contructor to create object.
    // Second class is the main object. Point is to use first class as access check for second one method body. Proxy class interface implementation is calling for the same methods
    // as in second class, but there are checks if code should be executed before proceeding. Not so frequent, used mostly for libraries.
    interface IDoor
    {
        void Open();
        void Close();
    }

    class LabDoor : IDoor
    {
        public void Close()
        {
            Console.WriteLine("Closing lab door");
        }

        public void Open()
        {
            Console.WriteLine("Opening lab door");
        }
    }

    class SecuredDoor
    {
        private IDoor mDoor;

        public SecuredDoor(IDoor door)
        {
            mDoor = door ?? throw new ArgumentNullException("door", "door can not be null");
        }

        public void Open(string password)
        {
            if (Authenticate(password))
            {
                mDoor.Open();
            }
            else
            {
                Console.WriteLine("Big no! It ain't possible.");
            }
        }

        private bool Authenticate(string password)
        {
            return password == "$ecr@t" ? true : false;
        }

        public void Close()
        {
            mDoor.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var door = new SecuredDoor(new LabDoor());
            door.Open("invalid"); // Big no! It ain't possible.

            door.Open("$ecr@t"); // Opening lab door
            door.Close(); // Closing lab door

            Console.ReadLine();
        }
    }
}
