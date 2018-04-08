namespace patterns.Visitor
{
    /// <inheritdoc />
    public class Dog : Animal
    {
        /// <summary>
        /// The woof.
        /// </summary>
        public void Woof() => System.Console.WriteLine("woof-woof");

        /// <inheritdoc />
        public override void Accept(PaymentVisitor visitor) => visitor.VisitDog(this);
    }
}
