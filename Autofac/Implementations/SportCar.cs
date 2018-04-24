using System;
using NetRore.Csharp.Cmd.Interfaces;

namespace NetRore.Csharp.Cmd.Implementations
{
    public class SportCar : ICar, IDisposable
    {
        public void Move()
        {
            Console.WriteLine("Wroom-wroom!");
        }

        public void Dispose()
        {
            Console.WriteLine("Good bye!");
        }
    }
}