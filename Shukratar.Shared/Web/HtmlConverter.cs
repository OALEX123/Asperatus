using CsQuery;
using Shukratar.Domain.Html;

namespace Shukratar.Shared.Web
{
    public class HtmlConverter : IHtmlConverter
    {
        public string ToPlainText(string html)
        {
            return CQ.Create(html).Text().Trim();
        }
    }
}