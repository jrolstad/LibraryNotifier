using LibraryNotifier.Core.Models;

namespace LibraryNotifier.Core.Factories
{
    public class ApplicationSettingsFactory:IFactory<string,ApplicationSettings>
    {
        public ApplicationSettings Create(string request)
        {
            return new ApplicationSettings {NewLibraryItemUri = "http://www.sno-isle.org/rss/itemlist.cfm?lid=1"};
        }
    }
}