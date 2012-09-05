using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Commands.Responses;
using LibraryNotifier.Core.Data;
using LibraryNotifier.Core.Models;

namespace LibraryNotifier.Core.Commands
{
    public class RemoveSearchableItemCommand:ICommand<Request<string>,ActionResponse<SearchableItem>>
    {
        private readonly IRepository _repository;

        public RemoveSearchableItemCommand(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResponse<SearchableItem> Execute(Request<string> request)
        {
            var itemToDelete = _repository.Get<SearchableItem>(request.Parameter);
            _repository.Delete(itemToDelete);

            var response = new ActionResponse<SearchableItem> {Result = itemToDelete};
            return response;
        }
    }
}