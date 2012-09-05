using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Commands.Responses;
using LibraryNotifier.Core.Data;
using LibraryNotifier.Core.Models;

namespace LibraryNotifier.Core.Commands
{
    public class GetSearchableItemsCommand:ICommand<Request<string>,QueryResponse<SearchableItem>>
    {
        private readonly IRepository _repository;

        public GetSearchableItemsCommand(IRepository repository)
        {
            _repository = repository;
        }

        public QueryResponse<SearchableItem> Execute(Request<string> request)
        {
            var items = _repository
                .Find<SearchableItem>()
                ;

            var response = new QueryResponse<SearchableItem> {Results = items};

            return response;
        }
    }
}