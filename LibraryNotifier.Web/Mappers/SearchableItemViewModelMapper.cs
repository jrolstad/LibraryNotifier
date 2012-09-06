using LibraryNotifier.Core.Mappers;
using LibraryNotifier.Core.Models;
using LibraryNotifier.Web.Models;

namespace LibraryNotifier.Web.Mappers
{
    public class SearchableItemViewModelMapper:IMapper<SearchableItem,SearchableItemViewModel>
    {
        public SearchableItemViewModel Map(SearchableItem toMap)
        {
            if (toMap == null)
                return null;

            return new SearchableItemViewModel
                       {
                           Id = toMap.Id,
                           Title = toMap.Title
                       };
        }
    }
}