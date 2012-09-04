using System;
using System.Collections.Generic;
using LibraryNotifier.Core.Models;

namespace LibraryNotifier.Core.Commands.Responses
{
    public class GetNewLibraryItemsResponse
    {
        public DateTime LastUpdatedAt { get; set; }

        public IEnumerable<LibraryItem> NewItems { get; set; }
    }
}