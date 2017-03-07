using System.Text.RegularExpressions;
using Shukratar.Domain.Syndication;

namespace Shukratar.Domain.Category
{
    public abstract class Category
    {
        public static readonly Regex NamePattern = new Regex(@"\w.*");

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual FeedItem FeedItem { get; set; }

        public int FeedItemId { get; set; }
    }
}