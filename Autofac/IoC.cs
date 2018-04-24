using Autofac;

namespace NetRore.Csharp.Cmd
{
    public static class IoC
    {
        public static IContainer Container { get; private set; }

        static IoC()
        {
            Container = CreateBuilder().Build();
        }

        private static ContainerBuilder CreateBuilder()
        {
            return new ContainerBuilder()
                .BuildInfrastructure()
                .BuildSomething();
        }
    }
}