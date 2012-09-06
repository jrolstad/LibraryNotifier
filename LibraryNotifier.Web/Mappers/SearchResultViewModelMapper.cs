using System.Collections.Generic;
using System.Linq;
using LibraryNotifier.Core.Mappers;
using LibraryNotifier.Core.Models;
using LibraryNotifier.Web.Models;

namespace LibraryNotifier.Web.Mappers
{
    public class SearchResultViewModelMapper : IMapper<IEnumerable<SearchResult>, IEnumerable<SearchResultViewModel>>
    {
        public IEnumerable<SearchResultViewModel> Map(IEnumerable<SearchResult> toMap)
        {
            foreach (var searchResult in toMap)
            {
                foreach (var match in searchResult.Matches)
                {
                    yield return new SearchResultViewModel
                        {
                            SearchTerms = searchResult.Item.Title,
                            Summary = match.Summary,
                            Title = match.Title,
                            Url = match.Link.AbsoluteUri,
                            LastUpdatedAt = match.LastUpdatedAt.ToString()
                        };
                }
            }
        }
    }
}