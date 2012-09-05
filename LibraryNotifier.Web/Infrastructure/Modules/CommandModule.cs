using LibraryNotifier.Core.Commands;
using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Commands.Responses;
using LibraryNotifier.Core.Models;
using Ninject.Modules;

namespace LibraryNotifier.Web.Infrastructure.Modules
{
    public class CommandModule:NinjectModule
    {
        public override void Load()
        {
            
            
            Bind<ICommand<Request<string>, ActionResponse<SearchableItem>>>()
                .To<AddSearchableItemCommand>()
                .Named("AddSearchableItem")
                ;
             
            Bind<ICommand<Request<string>, ActionResponse<SearchableItem>>>()
                .To<RemoveSearchableItemCommand>()
                .Named("RemoveSearchableItem")
                ;

            Bind<ICommand<Request<string>, QueryResponse<SearchResult>>>()
                .To<SearchNewLibraryItemsCommand>()
                ;
            Bind<ICommand<Request<string>, QueryResponse<SearchableItem>>>()
                .To<GetSearchableItemsCommand>()
                ;

            Bind<ICommand<Request<string>, GetNewLibraryItemsResponse>>()
                .To<GetNewLibraryItemsCommand>()
                ;

        }
    }
}