using System;
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
        private const string _feedUrl = "http://rolstad.co/rss";
        private GetNewLibraryItemsResponse _response;
        private readonly DateTime _lastUpdateTime = DateTime.Now.AddDays(-5.54);

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            var items = new[] {new SyndicationItem(),new SyndicationItem()};
            var feed = new SyndicationFeed(items){LastUpdatedTime = _lastUpdateTime};

            var mapper = MockRepository.GenerateStub<IMapper<SyndicationItem,LibraryItem>>();
            mapper.Stub(m => m.Map(Arg<SyndicationItem>.Is.Anything)).Return(new LibraryItem());

            var reader = MockRepository.GenerateStub<XmlReader>();
            
            var xmlReaderFactory = MockRepository.GenerateStub<IFactory<string,XmlReader>>();
            xmlReaderFactory.Stub(factory => factory.Create(_feedUrl)).Return(reader);

             var syndicationFeedFactory = MockRepository.GenerateStub<IFactory<XmlReader,SyndicationFeed>>();
            syndicationFeedFactory.Stub(factory => factory.Create(reader)).Return(feed);
            
            var command = new GetNewLibraryItemsCommand(mapper, xmlReaderFactory, syndicationFeedFactory);

            var request = new GetNewLibraryItemsRequest {Url = _feedUrl};

            _response = command.Execute(request);
        }


        [Test]
        public void When_executing_then_the_new_items_are_returned()
        {
            // Assert
            Assert.That(_response.NewItems.Count(),Is.EqualTo(2));
        }

        [Test]
        public void When_executing_then_the_last_updated_time_is_returned()
        {
            // Assert
            Assert.That(_response.LastUpdatedAt,Is.EqualTo(_lastUpdateTime));
        }
        

    }
}