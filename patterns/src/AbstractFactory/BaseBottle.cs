using System;
namespace patterns.src.AbstractFactory
{
    public abstract class BaseBottle
    {
        public void Fill(BaseWater water)
        {
            Console.WriteLine(String.Format("Наливаем {0} в {1}...", water.GetType().Name, this.GetType().Name));
        }
    }
}
