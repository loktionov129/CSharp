using System;
namespace patterns.src.AbstractFactory
{
    public class Client
    {
        public BaseBottle bottle;
        public BaseWater water;

        public Client(BaseFactory factory)
        {
            bottle = factory.CreateBottle();
            water = factory.CreateWater();
        }

        public void Run()
        {
            bottle.Fill(water);
        }
    }
}