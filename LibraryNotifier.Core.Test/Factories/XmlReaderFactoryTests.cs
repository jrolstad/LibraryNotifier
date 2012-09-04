using System;
using System.Collections.Generic;
using System.Linq;
using LibraryNotifier.Core.Factories;
using NUnit.Framework;

namespace LibraryNotifier.Core.Test.Factories
{
    [TestFixture]
    public class XmlReaderFactoryTests
    {

        [Test]
        public void When_creating_a_new_reader()
        {
            // Arrange
            var factory = new XmlReaderFactory();

            var request = "http://www.google.com";
            
            // Act
            var result = factory.Create(request);

            // Assert
            Assert.That(result,Is.Not.Null);
            Assert.That(result.BaseURI,Is.StringContaining(request));
        } 

    }
}