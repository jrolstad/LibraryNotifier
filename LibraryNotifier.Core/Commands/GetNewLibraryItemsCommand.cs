using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Commands.Responses;
using LibraryNotifier.Core.Factories;
using LibraryNotifier.Core.Mappers;
using LibraryNotifier.Core.Models;

namespace LibraryNotifier.Core.Commands
{
    public class GetNewLibraryItemsCommand: ICommand<Request<string>,GetNewLibraryItemsResponse>
    {
        private readonly IMapper<SyndicationItem, LibraryItem> _itemMapper;
        private readonly IFactory<string, XmlReader> _xmlReaderFactory;
        private readonly IFactory<XmlReader, SyndicationFeed> _syndicationFeedFactory;

        public GetNewLibraryItemsCommand(IMapper<SyndicationItem,LibraryItem> itemMapper, IFactory<string,XmlReader> xmlReaderFactory, IFactory<XmlReader,SyndicationFeed> syndicationFeedFactory )
        {
            _itemMapper = itemMapper;
            _xmlReaderFactory = xmlReaderFactory;
            _syndicationFeedFactory = syndicationFeedFactory;
        }

        public GetNewLibraryItemsResponse Execute(Request<string> request)
        {
            var reader = _xmlReaderFactory.Create(request.Parameter);
            var feed = _syndicationFeedFactory.Create(reader);

            if (feed == null)
                throw new ApplicationException(string.Format("Unable to connect to feed at {0}",request.Parameter));

            var newItems = feed.Items
                .Select(_itemMapper.Map)
                .ToList()
                ;

            var response = new GetNewLibraryItemsResponse
                {
                    LastUpdatedAt = feed.LastUpdatedTime.DateTime,
                    Items = newItems
                };

            reader.Close();

            return response;
        }
    }
}