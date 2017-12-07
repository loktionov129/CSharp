namespace patterns.FactoryMethod
{
    public class ConcreteCreator : Creator
    {
        public override Product CreateProduct()
        {
            return new ConcreteProduct("concrete_product");
        }
    }
}
