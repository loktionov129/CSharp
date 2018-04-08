namespace patterns.Visitor
{
    using System;

    /// <summary>
    /// The payment visitor.
    /// </summary>
    public class PaymentVisitor
    {
        /// <summary>
        /// The visit cat.
        /// </summary>
        /// <param name="cat">
        /// The cat.
        /// </param>
        public void VisitCat(Cat cat)
        {
            Console.WriteLine("Some logic with cat...");
            cat.Meow();
        }

        /// <summary>
        /// The visit dog.
        /// </summary>
        /// <param name="dog">
        /// The dog.
        /// </param>
        public void VisitDog(Dog dog)
        {
            Console.WriteLine("Another logic with dog...");
            dog.Woof();
        }

        /// <summary>
        /// The visit monkey.
        /// </summary>
        /// <param name="monkey">
        /// The monkey.
        /// </param>
        public void VisitMonkey(Monkey monkey)
        {
            Console.WriteLine("Respected Monkey! Stop do your shit, please.");
            monkey.WriteCPlusPlusCode();
        }

        /// <summary>
        /// The visit hamster.
        /// </summary>
        /// <param name="hamster">
        /// The hamster.
        /// </param>
        public void VisitHamster(Hamster hamster)
        {
            Console.WriteLine("Dear Hamster! Go away, please, we are don't like a you.");
            hamster.Omnomnom();
        }
    }
}
