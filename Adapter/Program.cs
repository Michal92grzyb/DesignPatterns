using System;

namespace Adapter
{
    // when you want to wrap object that is otherwise incompatible with some interface or abstract class, you can use Adapter pattern to do it
    // instead of changing the code.
    interface ILion
    {
        void Roar();
    }

    class AfricanLion : ILion
    {
        public void Roar()
        {

        }
    }

    class AsiaLion : ILion
    {
        public void Roar()
        {

        }
    }

    // This needs to be added to the game
    class WildDog
    {
        public void Bark()
        {
        }
    }

    // Adapter around wild dog to make it compatible with our game
    class WildDogAdapter : ILion
    {
        private WildDog mDog;
        public WildDogAdapter(WildDog dog)
        {
            this.mDog = dog;
        }

        // the place where WildDog is being adapted to match ILion interface
        public void Roar()
        {
            mDog.Bark();
        }
    }

    class Hunter
    {
        public void Hunt(ILion lion)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var wildDog = new WildDog();
            var wildDogAdapter = new WildDogAdapter(wildDog);

            var hunter = new Hunter();
            hunter.Hunt(wildDogAdapter);

            Console.ReadLine();
        }

        // used when you want to use existing class or library but it's interface is incompatible with rest of the code (ex. you want to use json, but class uses xml)
    }
}
