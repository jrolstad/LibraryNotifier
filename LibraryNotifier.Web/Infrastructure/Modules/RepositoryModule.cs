using LibraryNotifier.Core.Data;
using Ninject.Modules;

namespace LibraryNotifier.Web.Infrastructure.Modules
{
    public class RepositoryModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<InMemoryRepository>();
        }
    }
}