using Autofac;

using NetRore.Csharp.Cmd.Implementations;
using NetRore.Csharp.Cmd.Interfaces;

namespace NetRore.Csharp.Cmd
{
    internal static class ContainerBuilderExtensions
    {
        internal static ContainerBuilder BuildInfrastructure(this ContainerBuilder builder)
        {
            builder.RegisterType<SportCar>()
                .As<ICar>()
                .InstancePerDependency();

            return builder;
        }

        internal static ContainerBuilder BuildSomething(this ContainerBuilder builder)
        {
            // somethings ...
            return builder;
        }
    }
}