using System;

namespace Memento
{
    // gives ability to restore an object to previous state.
    // there is also a version with caretaker class that holds all mementos of Originator instance
    class EditorMemento
    {
        private string mContent;

        public EditorMemento(string content)
        {
            mContent = content;
        }

        public string Content
        {
            get
            {
                return mContent;
            }
        }
    }

    // originator
    class Editor
    {
        private string mContent = string.Empty;
        private EditorMemento _memento;

        public Editor()
        {
            _memento = new EditorMemento(string.Empty);
        }

        public void Type(string words)
        {
            mContent = String.Concat(mContent, " ", words);
        }

        public string Content
        {
            get
            {
                return mContent;
            }
        }

        public void Save()
        {
            _memento = new EditorMemento(mContent);
        }

        public void Restore()
        {
            mContent = _memento.Content;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var editor = new Editor();

            //Type some stuff
            editor.Type("This is the first sentence.");
            editor.Type("This is second.");

            // Save the state to restore to : This is the first sentence. This is second.
            editor.Save();

            //Type some more
            editor.Type("This is third.");

            //Output the content
            Console.WriteLine(editor.Content); // This is the first sentence. This is second. This is third.

            //Restoring to last saved state
            editor.Restore();

            Console.Write(editor.Content); // This is the first sentence. This is second

            Console.ReadLine();
        }
    }
}
