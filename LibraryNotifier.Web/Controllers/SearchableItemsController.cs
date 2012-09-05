using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryNotifier.Core.Commands;
using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Commands.Responses;
using LibraryNotifier.Core.Mappers;
using LibraryNotifier.Core.Models;
using LibraryNotifier.Web.Models;
using LibraryNotifier.Web.Models.Requests;
using Ninject;

namespace LibraryNotifier.Web.Controllers
{
    public class SearchableItemsController : Controller
    {
        private readonly ICommand<Request<string>, QueryResponse<SearchableItem>> _getItemsCommand;
        private readonly ICommand<Request<string>, ActionResponse<SearchableItem>> _addItemCommand;
        private readonly IMapper<SearchableItem, SearchableItemViewModel> _searchableItemMapper;

        public SearchableItemsController(
            ICommand<Request<string>,QueryResponse<SearchableItem>> getItemsCommand,
            [Named("AddSearchableItem")]
            ICommand<Request<string>,ActionResponse<SearchableItem>> addItemCommand,
            IMapper<SearchableItem,SearchableItemViewModel> searchableItemMapper)
        {
            _getItemsCommand = getItemsCommand;
            _addItemCommand = addItemCommand;
            _searchableItemMapper = searchableItemMapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {
            var result = _getItemsCommand.Execute(new Request<string>());

            var viewModels = result.Results.Select(_searchableItemMapper.Map);

            return Json(viewModels);
        }

        public void Add(AddSearchableItemRequest request)
        {
            _addItemCommand.Execute(new Request<string> {Parameter = request.Title});
        }


        

    }
}
