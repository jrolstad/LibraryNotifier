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

                var databaseName = ConfigurationManager.AppSettings["MONGOHQ_DATABASE"];
                var db = server.GetDatabase(databaseName);

                return db;
            });
        }
    }
}