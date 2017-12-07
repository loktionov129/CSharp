using System;
namespace patterns.AbstractFactory
{
    public abstract class BaseBottle
    {
        public void Fill(BaseWater water)
        {
            Console.WriteLine($"Наливаем {water.GetType().Name} в {this.GetType().Name}...");
        }
    }
}
