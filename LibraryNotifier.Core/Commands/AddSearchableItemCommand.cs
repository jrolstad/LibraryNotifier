using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Commands.Responses;
using LibraryNotifier.Core.Data;
using LibraryNotifier.Core.Models;

namespace LibraryNotifier.Core.Commands
{
    public class AddSearchableItemCommand:ICommand<Request<string>,ActionResponse<SearchableItem>>
    {
        private readonly IRepository _repository;

        public AddSearchableItemCommand(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResponse<SearchableItem> Execute(Request<string> request)
        {
            if (string.IsNullOrWhiteSpace(request.Parameter))
                return new ActionResponse<SearchableItem> {Result = null};

            var searchableItem = new SearchableItem
                                     {
                                         Title = request.Parameter,
                                         Id = System.Guid.NewGuid().ToString()
                                     };

            _repository.Save(searchableItem);

            var response = new ActionResponse<SearchableItem> {Result = searchableItem};

            return response;

        }
    }
}