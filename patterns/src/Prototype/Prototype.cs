namespace patterns.Prototype
{
    public abstract class Prototype
    {
        public string Data { get; }

        protected Prototype(string data)
        {
            Data = data;
        }

        public abstract Prototype Clone();
    }
}
