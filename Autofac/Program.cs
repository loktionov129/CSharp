using Autofac;
using NetRore.Csharp.Cmd.Interfaces;

namespace NetRore.Csharp.Cmd
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using (var requestScope = IoC.Container.BeginLifetimeScope())
            {
                var car = requestScope.Resolve<ICar>();
                car.Move();
            }
        }
    }
}