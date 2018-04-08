namespace patterns.Visitor
{
    /// <inheritdoc />
    public class Monkey : Hamster
    {
        /// <summary>
        /// The write C++ code.
        /// </summary>
        public void WriteCPlusPlusCode() => System.Console.WriteLine("Brilliantly! It's a masterpiece!");

        /// <inheritdoc />
        public override void Accept(PaymentVisitor visitor) => visitor.VisitMonkey(this);
    }
}
