using System;
using System.Collections.Generic;
using System.Linq;
using LibraryNotifier.Core.Commands;
using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Commands.Responses;
using LibraryNotifier.Core.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace LibraryNotifier.Core.Test.Commands
{
    [TestFixture]
    public class SearchNewLibraryItemsCommandTests
    {

        [Test]
        public void When_searching_then_only_matching_items_are_found()
        {
            // Arrange
            var searchableItems = new[] {new SearchableItem{Title = "one"}, new SearchableItem{Title = "two"}};
            var newItems = new[]
                               {new LibraryItem {Title = "foo", Summary = "Onethree"}, new LibraryItem {Title = "five"}};
            var getNewLibraryItemsCommand = MockRepository.GenerateStub<ICommand<Request<string>,GetNewLibraryItemsResponse>>();
            getNewLibraryItemsCommand.Stub(c => c.Execute(Arg<Request<string>>.Is.Anything)).Return(new GetNewLibraryItemsResponse { Items = newItems });

            var getSearchableItemsCommand = MockRepository.GenerateStub<ICommand<Request<string>,QueryResponse<SearchableItem>>>();
            getSearchableItemsCommand.Stub(c => c.Execute(Arg<Request<string>>.Is.Anything)).Return(new QueryResponse<SearchableItem> {Results = searchableItems});
            
            var request = new Request<string>();

            var command = new SearchNewLibraryItemsCommand(getSearchableItemsCommand, getNewLibraryItemsCommand);

            // Act
            var response = command.Execute(request);

            // Assert
            Assert.That(response.Results.Count(),Is.EqualTo(1));
            Assert.That(response.Results.First().Item.Title, Is.EqualTo("one"));
            Assert.That(response.Results.First().Matches.Count(), Is.EqualTo(1));
            Assert.That(response.Results.First().Matches.First().Title, Is.EqualTo("foo"));
        }

    }
}