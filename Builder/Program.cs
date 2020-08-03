using System;

namespace Builder
{
    class Burger
    {
        // IMPORTANT: This is Fluent Builder pattern variation with no Director class. Another Builder implementation, closer to mainstream theory will be provided.
        // The problem: You want to create an instance of object, but it comes with many customizable options. Constructor can be very long and misleading "telescopic".
        // Also when extending said class in future there is chance of creating unnecessary errors. 
        // Similar to Factory, but factory creates objects in one step, and builder in many.

        private int mSize;
        private bool mCheese;
        private bool mPepperoni;
        private bool mLettuce;
        private bool mTomato;

        public Burger(BurgerBuilder builder)
        {
            this.mSize = builder.Size;
            this.mCheese = builder.Cheese;
            this.mPepperoni = builder.Pepperoni;
            this.mLettuce = builder.Lettuce;
            this.mTomato = builder.Tomato;
        }

        public string GetDescription()
        {
            var sb = new StringBuilder();
            sb.Append(String.Format("This is {0} inch Burger. ", this.mSize));
            return sb.ToString();
        }
    }

    class BurgerBuilder 
    {
        public int Size;
        public bool Cheese;
        public bool Pepperoni;
        public bool Lettuce;
        public bool Tomato;

        public BurgerBuilder(int size)
        {
            this.Size = size;
        }

        public BurgerBuilder AddCheese()
        {
            this.Cheese = true;
            return this;
        }

        public BurgerBuilder AddPepperoni()
        {
            this.Pepperoni = true;
            return this;
        }

        public BurgerBuilder AddLettuce()
        {
            this.Lettuce = true;
            return this;
        }

        public BurgerBuilder AddTomato()
        {
            this.Tomato = true;
            return this;
        }

        public Burger Build()
        {
            return new Burger(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Build method at the end of chain fulfills the role of Director class.
            var burger = new BurgerBuilder(4).AddCheese()
                                                .AddPepperoni()
                                                .AddLettuce()
                                                .AddTomato()
                                                .Build();
            Console.WriteLine(burger.GetDescription());
            Console.ReadLine();
        }

    }
}
