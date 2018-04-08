namespace patterns.Visitor
{
    /// <inheritdoc />
    public class Cat : Animal
    {
        /// <summary>
        /// The meow.
        /// </summary>
        public void Meow() => System.Console.WriteLine("meow-meow");

        /// <inheritdoc />
        public override void Accept(PaymentVisitor visitor) => visitor.VisitCat(this);
    }
}
