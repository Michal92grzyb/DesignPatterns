using System;

namespace Visitor
{
    // Visitor has ability to extend class, by using other class.

    // Visitee - component - class that's being visited. It needs to implement some kind of "visitee" or component interface. Accept method is crucial - it comes with
    // operation that is required to be done.
    interface IAnimal
    {
        void Accept(IAnimalOperation operation);
    }

    // Visitor - interface lists all visitor interfaces, classes deriving from this interface will work similar to commands.
    interface IAnimalOperation
    {
        void VisitMonkey(Monkey monkey);
        void VisitLion(Lion lion);
        void VisitDolphin(Dolphin dolphin);
    }

    class Monkey : IAnimal
    {
        public void Shout()
        {
            Console.WriteLine("Oooh o aa aa!");
        }

        public void Accept(IAnimalOperation operation)
        {
            operation.VisitMonkey(this);
        }
    }

    class Lion : IAnimal
    {
        public void Roar()
        {
            Console.WriteLine("Roaar!");
        }

        public void Accept(IAnimalOperation operation)
        {
            operation.VisitLion(this);
        }
    }

    class Dolphin : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Tuut tittu tuutt!");
        }

        public void Accept(IAnimalOperation operation)
        {
            operation.VisitDolphin(this);
        }
    }

    class Speak : IAnimalOperation
    {
        public void VisitDolphin(Dolphin dolphin)
        {
            dolphin.Speak();
        }

        public void VisitLion(Lion lion)
        {
            lion.Roar();
        }

        public void VisitMonkey(Monkey monkey)
        {
            monkey.Shout();
        }
    }

    class Jump : IAnimalOperation
    {
        public void VisitDolphin(Dolphin dolphin)
        {
            Console.WriteLine("Walked on water a little and disappeared!");
        }

        public void VisitLion(Lion lion)
        {
            Console.WriteLine("Jumped 7 feet! Back on the ground!");
        }

        public void VisitMonkey(Monkey monkey)
        {
            Console.WriteLine("Jumped 20 feet high! on to the tree!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var monkey = new Monkey();
            var lion = new Lion();
            var dolphin = new Dolphin();

            // when some visitor needs to do its job, we create instance of visitor class and use visitee accept method with newly visitor instance as parameter.
            var speak = new Speak();

            // it goes like this: put visitor in visitee accept method. Then visitor calls for visitee method thats inside
            monkey.Accept(speak);    // Ooh oo aa aa!    
            lion.Accept(speak);      // Roaaar!
            dolphin.Accept(speak);   // Tuut tutt tuutt!

            var jump = new Jump();

            monkey.Accept(speak);   // Ooh oo aa aa!
            monkey.Accept(jump);    // Jumped 20 feet high! on to the tree!

            lion.Accept(speak);     // Roaaar!
            lion.Accept(jump);      // Jumped 7 feet! Back on the ground!

            dolphin.Accept(speak);  // Tuut tutt tuutt!
            dolphin.Accept(jump);   // Walked on water a little and disappeared

            Console.ReadLine();
        }
    }
}
