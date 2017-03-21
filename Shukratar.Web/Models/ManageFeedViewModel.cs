using System.Collections.Generic;

namespace Shukratar.Web.Models
{
    public class ManageFeedViewModel
    {
        public FeedViewModel Feed { get; set; }

        public IEnumerable<FeedCountryViewModel> Countries { get; set; }

        public IEnumerable<FeedCategoryViewModel> Categories { get; set; }
    }

    public class FeedCountryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FeedCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}