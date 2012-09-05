using System.ServiceModel.Syndication;
using System.Xml;
using LibraryNotifier.Core.Factories;
using Ninject.Modules;

namespace LibraryNotifier.Web.Infrastructure.Modules
{
    public class FactoryModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IFactory<XmlReader, SyndicationFeed>>().To<SyndicationFeedFactory>();
            Bind<IFactory<string, XmlReader>>().To<XmlReaderFactory>();
        }
    }
}