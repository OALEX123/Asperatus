using System.Text.RegularExpressions;

namespace Shukratar.Domain.Video
{
    public class YouTubeVideo : Video
    {
        private static readonly Regex UrlRegex = new Regex(".*youtube.com/embed/(?<Id>[A-z0-9-]*)");


        public static string ParseId(string url)
        {
            return UrlRegex.Match(url).Groups["Id"].Value;
        }

        public override string GetLink()
        {
            return $"https://www.youtube.com/watch?v={ExternalId}";
        }

        public override string GetEmbedLink()
        {
            return $"https://www.youtube.com/embed/{ExternalId}";
        }
    }
}