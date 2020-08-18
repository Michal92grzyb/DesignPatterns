using System;
using System.Collections.Generic;

namespace Composite
{
    interface IComponent
    {
        string GetElementContent(int depth);
    }

    class Package : IComponent
    {
        List<IComponent> _components;

        public Package()
        {
            _components = new List<IComponent>();
        }

        public void Add(IComponent component)
        {
            _components.Add(component);
        }

        public string GetElementContent(int depth = 0)
        {
            string retVal = "Box:\n";
            foreach (var component in _components)
            {
                for(int x = 0; x <= depth; x++)
                {
                    retVal += "\t";
                }
                retVal += component.GetElementContent(depth + 1) + Environment.NewLine;
            }

            return retVal;
        }
    }

    class Element : IComponent
    {
        string _name {get;}

        public Element(string name)
        {
            _name = name;
        }

        public string GetElementContent(int depth = 0)
        {
            return _name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var box = new Package();
            
            var toolBox = new Package();
            var hammer = new Element("hammer");

            var phoneBox = new Package();
            var phone = new Element("phone");
            var charger = new Element("charger");

            var receipt = new Element("receipt");

            box.Add(receipt);

            phoneBox.Add(phone);
            phoneBox.Add(charger);
            toolBox.Add(hammer);

            box.Add(phoneBox);
            box.Add(toolBox);

            System.Console.WriteLine(box.GetElementContent());
        }
    }
}
