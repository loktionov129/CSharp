namespace patterns.AbstractFactory
{
    public class PepsiFactory : BaseFactory
    {
        public override BaseBottle CreateBottle()
        {
            return new PepsiBottle();
        }

        public override BaseWater CreateWater()
        {
            return new PepsiWater();
        }
    }
}
