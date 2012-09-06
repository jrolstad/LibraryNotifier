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
        private readonly ICommand<Request<string>, ActionResponse<SearchableItem>> _removeItemCommand;

        public SearchableItemsController(
            ICommand<Request<string>,QueryResponse<SearchableItem>> getItemsCommand,
            [Named("AddSearchableItem")]
            ICommand<Request<string>,ActionResponse<SearchableItem>> addItemCommand,
            IMapper<SearchableItem,SearchableItemViewModel> searchableItemMapper,
            [Named("RemoveSearchableItem")]
            ICommand<Request<string>,ActionResponse<SearchableItem>> removeItemCommand)
        {
            _getItemsCommand = getItemsCommand;
            _addItemCommand = addItemCommand;
            _searchableItemMapper = searchableItemMapper;
            _removeItemCommand = removeItemCommand;
        }

        public ActionResult Index()
        {
            return View();
        }

       
        public JsonResult Get()
        {
            var result = _getItemsCommand.Execute(new Request<string>());

            var viewModels = result.Results.Select(_searchableItemMapper.Map);

            return Json(viewModels,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(string title)
        {
            var result =_addItemCommand.Execute(new Request<string> {Parameter = title});

            var newItem = _searchableItemMapper.Map(result.Result);

            return Json(newItem,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Remove(string id)
        {
            _removeItemCommand.Execute(new Request<string> {Parameter = id});

            return Json(id, JsonRequestBehavior.AllowGet);
        }
        

    }
}
