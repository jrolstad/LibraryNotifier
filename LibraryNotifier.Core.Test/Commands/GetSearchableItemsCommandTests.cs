using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using LibraryNotifier.Core.Commands;
using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Data;
using LibraryNotifier.Core.Models;
using NUnit.Framework;

namespace LibraryNotifier.Core.Test.Commands
{
    [TestFixture]
    public class GetSearchableItemsCommandTests
    {

        [Test]
        public void When_getting_the_searchable_items_then_all_are_obtained()
        {
            // Arrange
            var repository = new InMemoryRepository();
            repository.Save(Builder<SearchableItem>.CreateNew().Build());
            repository.Save(Builder<SearchableItem>.CreateNew().Build());
            repository.Save(Builder<SearchableItem>.CreateNew().Build());

            var command = new GetSearchableItemsCommand(repository);

            var request = new Request<string>();

            // Act
            var response = command.Execute(request);

            // Assert
            Assert.That(response.Results.Count(),Is.EqualTo(3));
        }

    }
}