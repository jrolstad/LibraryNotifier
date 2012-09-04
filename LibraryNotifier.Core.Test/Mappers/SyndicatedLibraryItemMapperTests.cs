using System;
using System.ServiceModel.Syndication;
using LibraryNotifier.Core.Mappers;
using LibraryNotifier.Core.Models;
using NUnit.Framework;

namespace LibraryNotifier.Core.Test.Mappers
{
    [TestFixture]
    public class SyndicatedLibraryItemMapperTests
    {
        private SyndicationItem _item;
        private LibraryItem _result;
        private Uri _itemAlternateLink;
        private DateTime _lastUpdatedAt;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            _itemAlternateLink = new Uri("http://google.com");
            _lastUpdatedAt = DateTime.Now.AddDays(-4);

            _item = new SyndicationItem(Guid.NewGuid().ToString(),
                                        Guid.NewGuid().ToString(),
                                        _itemAlternateLink,
                                        Guid.NewGuid().ToString(),
                                        new DateTimeOffset(_lastUpdatedAt));
            

            var mapper = new SyndicatedLibraryItemMapper();

            _result = mapper.Map(_item);

        }

        [Test]
        public void Then_the_title_is_mapped()
        {
            Assert.That(_result.Title,Is.EqualTo(_item.Title.Text));

        }

        [Test]
        public void Then_the_link_is_mapped()
        {
            Assert.That(_result.Link, Is.EqualTo(_itemAlternateLink));

        }

        [Test]
        public void Then_the_last_update_time_is_mapped()
        {
            Assert.That(_result.LastUpdatedAt, Is.EqualTo(_lastUpdatedAt));

        } 

    }
}