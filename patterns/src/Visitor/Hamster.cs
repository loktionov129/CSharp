namespace patterns.Visitor
{
    /// <inheritdoc />
    public class Hamster : Animal
    {
        /// <summary>
        /// The omnomnom.
        /// </summary>
        public void Omnomnom() => System.Console.WriteLine("Om-nom-nom");

        /// <inheritdoc />
        public override void Accept(PaymentVisitor visitor) => visitor.VisitHamster(this);
    }
}
