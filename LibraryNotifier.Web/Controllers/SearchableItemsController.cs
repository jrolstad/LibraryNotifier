using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LibraryNotifier.Core.Commands;
using LibraryNotifier.Core.Commands.Requests;
using LibraryNotifier.Core.Commands.Responses;
using LibraryNotifier.Core.Factories;
using LibraryNotifier.Core.Mappers;
using LibraryNotifier.Core.Models;
using LibraryNotifier.Web.Models;
using Ninject;

namespace LibraryNotifier.Web.Controllers
{
    public class SearchableItemsController : Controller
    {
        private readonly ICommand<Request<string>, QueryResponse<SearchableItem>> _getItemsCommand;
        private readonly ICommand<Request<string>, ActionResponse<SearchableItem>> _addItemCommand;
        private readonly IMapper<SearchableItem, SearchableItemViewModel> _searchableItemMapper;
        private readonly ICommand<Request<string>, ActionResponse<SearchableItem>> _removeItemCommand;
        private readonly ICommand<Request<string>, QueryResponse<SearchResult>> _searchCommand;
        private readonly IMapper<IEnumerable<SearchResult>, IEnumerable<SearchResultViewModel>> _searchResultMapper;
        private readonly IFactory<string, ApplicationSettings> _applicationSettingFactory;

        public SearchableItemsController(
            ICommand<Request<string>,QueryResponse<SearchableItem>> getItemsCommand,
            [Named("AddSearchableItem")]
            ICommand<Request<string>,ActionResponse<SearchableItem>> addItemCommand,
            IMapper<SearchableItem,SearchableItemViewModel> searchableItemMapper,
            [Named("RemoveSearchableItem")]
            ICommand<Request<string>,ActionResponse<SearchableItem>> removeItemCommand,
            ICommand<Request<string>,QueryResponse<SearchResult>> searchCommand,
            IMapper<IEnumerable<SearchResult>,IEnumerable<SearchResultViewModel>> searchResultMapper,
            IFactory<string,ApplicationSettings> applicationSettingFactory)
        {
            _getItemsCommand = getItemsCommand;
            _addItemCommand = addItemCommand;
            _searchableItemMapper = searchableItemMapper;
            _removeItemCommand = removeItemCommand;
            _searchCommand = searchCommand;
            _searchResultMapper = searchResultMapper;
            _applicationSettingFactory = applicationSettingFactory;
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

        public JsonResult Search()
        {
            var settings = _applicationSettingFactory.Create(null);
            var result = _searchCommand.Execute(new Request<string> { Parameter = settings.NewLibraryItemUri });

            var viewModels = _searchResultMapper.Map(result.Results);

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }
        

    }
}
