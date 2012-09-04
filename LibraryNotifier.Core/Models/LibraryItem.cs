using System;

namespace LibraryNotifier.Core.Models
{
    public class LibraryItem
    {
        public string Title { get; set; }

        public Uri Link { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        public string Summary { get; set; }
    }
}