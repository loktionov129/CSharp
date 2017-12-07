using System;

namespace patterns.FactoryMethod
{
    public class Program : BaseProgram
    {
        protected override void Run()
        {
            Creator creator = new ConcreteCreator();
            Product prouct = creator.CreateProduct();

            prouct.Show();
        }
    }
}
