namespace patterns.AbstractFactory
{
    public class CocaColaFactory : BaseFactory
    {
        public override BaseBottle CreateBottle()
        {
            return new CocaColaBottle();
        }

        public override BaseWater CreateWater()
        {
            return new CocaColaWater();
        }
    }
}
