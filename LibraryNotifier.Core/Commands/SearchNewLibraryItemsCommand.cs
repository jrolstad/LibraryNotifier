using System;
using System.Collections.Generic;
using System.Linq;
using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Commands.Responses;
using LibraryNotifier.Core.Models;

namespace LibraryNotifier.Core.Commands
{
    public class SearchNewLibraryItemsCommand:ICommand<Request<string>,QueryResponse<SearchResult>>
    {
        private readonly ICommand<Request<string>, QueryResponse<SearchableItem>> _getSearchableItemsCommand;
        private readonly ICommand<Request<string>, GetNewLibraryItemsResponse> _getNewLibraryItemsCommand;

        public SearchNewLibraryItemsCommand(ICommand<Request<string>,QueryResponse<SearchableItem>> getSearchableItemsCommand,ICommand<Request<string>,GetNewLibraryItemsResponse> getNewLibraryItemsCommand)
        {
            _getSearchableItemsCommand = getSearchableItemsCommand;
            _getNewLibraryItemsCommand = getNewLibraryItemsCommand;
        }

        public QueryResponse<SearchResult> Execute(Request<string> request)
        {
            var searchableItems = _getSearchableItemsCommand.Execute(new Request<string>());
            var newItems = _getNewLibraryItemsCommand.Execute(new Request<string>());

            var results =  GetMatchingNewItems(newItems, searchableItems)
                .ToList();

            var response = new QueryResponse<SearchResult> {Results = results};

            return response;
        }

        private IEnumerable<SearchResult> GetMatchingNewItems(GetNewLibraryItemsResponse newItems, QueryResponse<SearchableItem> searchableItems)
        {
            foreach (var searchableItem in searchableItems.Results)
            {
                var searchTerms = searchableItem.Title;
                var newItemMatches = newItems
                    .Items
                    .Where(item => ItemsMatch(searchTerms, item))
                    .ToList()
                    ;

                if(newItemMatches.Any())
                    yield return new SearchResult {Item = searchableItem, Matches = newItemMatches};
            }
        }

        private bool ItemsMatch(string searchTerms, LibraryItem item)
        {
            return item.Title.SafeContains(searchTerms) || item.Summary.SafeContains(searchTerms);
        }
    }

    public static class StringExtensions
    {
        public static bool SafeContains(this string value, string searchString)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return value.ToLower().Contains(searchString.ToLower().Trim());
        }
    }
}