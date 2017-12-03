namespace patterns.AbstractFactory
{
    public class Client
    {
        public BaseBottle Bottle { get; }
        public BaseWater Water { get; }

        public Client(BaseFactory factory)
        {
            Bottle = factory.CreateBottle();
            Water = factory.CreateWater();
        }

        public void Run()
        {
            Bottle.Fill(Water);
        }
    }
}
