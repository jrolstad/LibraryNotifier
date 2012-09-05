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
    public class RemoveSearchableItemCommandTests
    {

        [Test]
        public void When_executing_then_the_item_is_removed()
        {
            // Arrange
            var repository = new InMemoryRepository();

            var itemToDelete = Builder<SearchableItem>.CreateNew().Build();
            repository.Save(itemToDelete);

            var command = new RemoveSearchableItemCommand(repository);

            var request = new Request<string> {Parameter = itemToDelete.Id};

            // Act
            var response = command.Execute(request);

            // Assert
            Assert.That(response.Result.Id,Is.EqualTo(request.Parameter));
            Assert.That(response.Result.Title,Is.EqualTo(itemToDelete.Title));
            Assert.That(repository.Find<SearchableItem>().Count(), Is.EqualTo(0));
        }

    }
}