using System.Linq;
using System.ServiceModel.Syndication;
using LibraryNotifier.Core.Models;

namespace LibraryNotifier.Core.Mappers
{
    public class SyndicatedLibraryItemMapper : IMapper<SyndicationItem, LibraryItem>
    {
        public LibraryItem Map(SyndicationItem toMap)
        {
            return new LibraryItem
                {
                    Title = toMap.Title.Text,
                    Link = toMap.Links.Select(link=>link.Uri).FirstOrDefault(),
                    LastUpdatedAt = toMap.LastUpdatedTime.DateTime,
                    Summary = (toMap.Summary == null ? null : toMap.Summary.Text)
                };
        }
    }
}