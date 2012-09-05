using LibraryNotifier.Web.Infrastructure.Modules;
using Ninject;
using Ninject.Modules;

namespace LibraryNotifier.Web.Infrastructure
{
    public class Bootstrapper
    {
         public static void Configure(IKernel kernel)
         {
             var modules = new NinjectModule[]
                               {
                                 new FactoryModule(), 
                                 new CommandModule(), 
                                 new MapperModule(), 
                                 new RepositoryModule()
                               };

             kernel.Load(modules);
         }
    }
}