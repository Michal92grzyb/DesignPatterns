using System;

namespace FactoryMethod
{
    /* To implement this you need 2 abstract classes / 1 abstract class and 1 interface. One of it represents product, which can come in many forms (in this case Interviewer),
        other one represents its factory (HiringManager). HiringManager got factory method to make interviewer without knowing what type of interviewer it's going to be.
        Created objects will have the ame interfaces implemented but will do their job in different way.
    */


    interface IInterviewer
    {
        void AskQuestions();
    }

    class DeveloperInterviewer : IInterviewer
    {
        public void AskQuestions()
        {
            Console.WriteLine("Asking about design patterns!");
        }
    }

    class CommunityExecutiveInterviewer : IInterviewer
    {
        public void AskQuestions()
        {
            Console.WriteLine("Asking about community building!");
        }
    }

    abstract class HiringManager
    {
        // Factory method
        abstract protected IInterviewer MakeInterviewer();
        public void TakeInterview()
        {
            var interviewer = this.MakeInterviewer();
            interviewer.AskQuestions();
        }
    }

    class DevelopmentManager : HiringManager
    {
        protected override IInterviewer MakeInterviewer()
        {
            return new DeveloperInterviewer();
        }
    }

    class MarketingManager : HiringManager
    {
        protected override IInterviewer MakeInterviewer()
        {
            return new CommunityExecutiveInterviewer();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            HiringManager devManager = new DevelopmentManager();
            devManager.TakeInterview(); //Output : Asking about design patterns!

            HiringManager marketingManager = new MarketingManager();
            marketingManager.TakeInterview(); //Output : Asking about community building!

            // Useful when there is some generic processing in a class but the required sub-class is dynamically decided at runtime.
            // Or putting it in other words, when the client doesn't know what exact sub-class it might need.
        }
    }
}
