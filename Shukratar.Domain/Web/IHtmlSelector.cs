using System.Collections.Generic;
using Shukratar.Domain.Html;

namespace Shukratar.Domain.Web
{
    public interface IHtmlSelector
    {
        List<HtmlElement> Select(string html, string selector);
    }
}