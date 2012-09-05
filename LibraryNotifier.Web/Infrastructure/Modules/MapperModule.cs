using System.ServiceModel.Syndication;
using LibraryNotifier.Core.Mappers;
using LibraryNotifier.Core.Models;
using LibraryNotifier.Web.Mappers;
using LibraryNotifier.Web.Models;
using Ninject.Modules;

namespace LibraryNotifier.Web.Infrastructure.Modules
{
    public class MapperModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper<SyndicationItem, LibraryItem>>().To<SyndicatedLibraryItemMapper>();
            Bind<IMapper<SearchableItem, SearchableItemViewModel>>().To<SearchableItemViewModelMapper>();
        }
    }
}