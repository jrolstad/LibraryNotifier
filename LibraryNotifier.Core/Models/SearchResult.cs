using System.Collections.Generic;

namespace LibraryNotifier.Core.Models
{
    public class SearchResult
    {
        public SearchableItem Item { get; set; }

        public IEnumerable<LibraryItem> Matches { get; set; }
    }
}