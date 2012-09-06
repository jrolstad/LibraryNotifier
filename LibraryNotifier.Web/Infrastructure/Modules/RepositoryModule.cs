using System.Configuration;
using LibraryNotifier.Core.Data;
using MongoDB.Driver;
using Ninject.Modules;

namespace LibraryNotifier.Web.Infrastructure.Modules
{
    public class RepositoryModule:NinjectModule
    {
        public override void Load()
        {
           

            Bind<IRepository>().To<MongoDbRepository>().InSingletonScope();
            Bind<MongoDatabase>().ToMethod(context =>
            {
                var connectionString = ConfigurationManager.AppSettings["MONGOHQ_URL"];
                var server = MongoServer.Create(connectionString);

                var dbNameStartPosition = connectionString.LastIndexOf(@"/", System.StringComparison.Ordinal);
                var databaseName = connectionString.Substring(dbNameStartPosition+1);

                var db = server.GetDatabase(databaseName);

                return db;
            });
        }
    }
}