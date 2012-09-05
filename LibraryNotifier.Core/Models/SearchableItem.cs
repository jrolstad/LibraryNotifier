using LibraryNotifier.Core.Data;

namespace LibraryNotifier.Core.Models
{
    public class SearchableItem : IEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}