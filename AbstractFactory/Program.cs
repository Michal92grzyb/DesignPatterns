using System;

namespace AbstractFactory
{
    // Extended factory pattern. Now the type of factory created is determined at runtime by user. A Factory is created, but without specyfying it class.

    interface IDoor
    {
        void GetDescription();
    }

    class WoodenDoor : IDoor
    {
        public void GetDescription()
        {
            Console.WriteLine("I am a wooden door");
        }
    }

    class IronDoor : IDoor
    {
        public void GetDescription()
        {
            Console.WriteLine("I am a iron door");
        }
    }

    interface IDoorFittingExpert
    {
        void GetDescription();
    }

    class Welder : IDoorFittingExpert
    {
        public void GetDescription()
        {
            Console.WriteLine("I can only fit iron doors");
        }
    }

    class Carpenter : IDoorFittingExpert
    {
        public void GetDescription()
        {
            Console.WriteLine("I can only fit wooden doors");
        }
    }

    interface IDoorFactory
    {
        IDoor MakeDoor();
        IDoorFittingExpert MakeFittingExpert();
    }

    class WoodenDoorFactory : IDoorFactory
    {
        public IDoor MakeDoor()
        {
            return new WoodenDoor();
        }
        // Iron door factory to get iron door and the relevant fitting expert
        public IDoorFittingExpert MakeFittingExpert()
        {
            return new Carpenter();
        }
    }

    class IronDoorFactory : IDoorFactory
    {
        public IDoor MakeDoor()
        {
            return new IronDoor();
        }

        public IDoorFittingExpert MakeFittingExpert()
        {
            return new Welder();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // used when there are hidden dependencies and different creation logic with seemingly similar objects.
            IDoorFactory woodenDoorFactory = new WoodenDoorFactory();
            IDoor woodenDoor = woodenDoorFactory.MakeDoor();
            IDoorFittingExpert woodenDoorFittingExpert = woodenDoorFactory.MakeFittingExpert();

            woodenDoor.GetDescription(); //Output : I am a wooden door
            woodenDoorFittingExpert.GetDescription();//Output : I can only fit woooden doors

            IDoorFactory ironDoorFactory = new IronDoorFactory();
            IDoor ironDoor = ironDoorFactory.MakeDoor();
            IDoorFittingExpert ironDoorFittingExpert = ironDoorFactory.MakeFittingExpert();

            ironDoor.GetDescription();//Output : I am an iron door
            ironDoorFittingExpert.GetDescription();//Output : I can only fit iron doors

            Console.ReadLine();
        }
    }
}
