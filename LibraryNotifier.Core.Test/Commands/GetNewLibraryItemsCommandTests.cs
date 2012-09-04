using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using LibraryNotifier.Core.Commands;
using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Commands.Responses;
using LibraryNotifier.Core.Factories;
using LibraryNotifier.Core.Mappers;
using LibraryNotifier.Core.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace LibraryNotifier.Core.Test.Commands
{
    [TestFixture]
    public class GetNewLibraryItemsCommandTests
    {
        private string _feedUrl;
        private GetNewLibraryItemsResponse _response;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            var items = new[] {new SyndicationItem(),new SyndicationItem()};
            var feed = new SyndicationFeed(items);

            var mapper = MockRepository.GenerateStub<IMapper<SyndicationItem,LibraryItem>>();
            var xmlReaderFactory = MockRepository.GenerateStub<IFactory<string,XmlReader>>();
            var syndicationFeedFactory = MockRepository.GenerateStub<IFactory<XmlReader,SyndicationFeed>>();
            
            var command = new GetNewLibraryItemsCommand(mapper, xmlReaderFactory, syndicationFeedFactory);

            var request = new GetNewLibraryItemsRequest {Url = _feedUrl};

            _response = command.Execute(request);
        }
        

    }
}