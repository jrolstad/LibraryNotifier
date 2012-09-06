using System;

namespace LibraryNotifier.Web.Models
{
    public class SearchResultViewModel
    {
        public string Title { get; set; }

        public string Summary { get; set; }

        public string Url { get; set; }

        public string SearchTerms { get; set; }

        public string LastUpdatedAt { get; set; }
    }
}