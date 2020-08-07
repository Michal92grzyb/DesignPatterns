using System;

namespace Singleton
{
    public class President
    {
        static President instance;
        // Private constructor
        private President()
        {
            //Hiding the Constructor
        }

        // Public constructor
        public static President GetInstance()
        {
            if (instance == null)
            {
                instance = new President();
            }
            return instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            President a = President.GetInstance();
            President b = President.GetInstance();

            Console.WriteLine((a == b).ToString());
        }
    }
}
