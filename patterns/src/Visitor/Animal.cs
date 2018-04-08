namespace patterns.Visitor
{
    /// <summary>
    /// The animal.
    /// </summary>
    public abstract class Animal
    {
        /// <summary>
        /// The accept.
        /// </summary>
        /// <param name="visitor">
        /// The visitor.
        /// </param>
        public abstract void Accept(PaymentVisitor visitor);
    }
}
