using System.Linq;
using System.Reflection;

using Autofac;

using JackSazerak.Library.PlatformInterfaces;

namespace JackSazerak.Library.Helpers
{
    public static class AutofacConfiguration
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .Where(t => t.IsAssignableTo<IDI>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}