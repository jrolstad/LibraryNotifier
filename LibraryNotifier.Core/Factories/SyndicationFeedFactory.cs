using System.ServiceModel.Syndication;
using System.Xml;

namespace LibraryNotifier.Core.Factories
{
    public class SyndicationFeedFactory:IFactory<XmlReader,SyndicationFeed>
    {
        public SyndicationFeed Create(XmlReader request)
        {
            return SyndicationFeed.Load(request);
        }
    }
}