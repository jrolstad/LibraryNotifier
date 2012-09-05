using System.Collections.Generic;
using LibraryNotifier.Core.Models;

namespace LibraryNotifier.Core.Commands.Responses
{
    public class QueryResponse<T>
    {
        public IEnumerable<T> Results { get; set; }
    }
}