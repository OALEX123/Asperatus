using System.Linq;
using Shukratar.Domain.Web;
using Shukratar.Domain.Website;

namespace Shukratar.Domain.Parser
{
    public class WebPageParser : IWebPageParser
    {
        private readonly IHtmlSelector _htmlSelector;

        public WebPageParser(IHtmlSelector htmlSelector)
        {
            _htmlSelector = htmlSelector;
        }

        public void Parse(NewsPage page)
        {
            var videoElements = _htmlSelector.Select(page.Content, Video.Video.Selector);

            if (videoElements.Any())
            {
                page.VideoLink = videoElements.First().Attributes["src"].Value;
            }
        }
    }
}
