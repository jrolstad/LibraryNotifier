using System;
using System.Collections.Generic;
using System.Linq;
using LibraryNotifier.Core.Commands;
using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Data;
using LibraryNotifier.Core.Models;
using NUnit.Framework;

namespace LibraryNotifier.Core.Test.Commands
{
    [TestFixture]
    public class AddSearchableItemCommandTests
    {

        [Test]
        public void When_executing_then_an_item_is_added()
        {
            // Arrange
            var repository = new InMemoryRepository();

            var command = new AddSearchableItemCommand(repository);

            var request = new Request<string> {Parameter = "My new item name"};

            // Act
            var response = command.Execute(request);

            // Assert
            Assert.That(response.Result.Title,Is.EqualTo(request.Parameter));
            Assert.That(response.Result.Id,Is.Not.EqualTo(""));

            var savedItem = repository.Get<SearchableItem>(response.Result.Id);
            Assert.That(savedItem,Is.Not.Null);
            Assert.That(savedItem.Title,Is.EqualTo(request.Parameter));
        }

    }
}