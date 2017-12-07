namespace patterns.FactoryMethod
{
    public abstract class Product
    {
        protected string Name { get; }

        protected Product(string name)
        {
            Name = name;
        }

        public void Show()
        {
            System.Console.WriteLine($"i am a {Name}");
        }
    }
}
