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
            var results = toMap
                .SelectMany(result => result.Matches)
                .Select(
                    match =>
                    new SearchResultViewModel
                        {
                            Title = match.Title,
                            Summary = match.Summary,
                            Url = match.Link.AbsoluteUri
                        });

            return results;
        }
    }
}