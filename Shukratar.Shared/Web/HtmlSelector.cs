using System.Collections.Generic;
using CsQuery;
using Shukratar.Domain.Html;
using Shukratar.Domain.Web;

namespace Shukratar.Shared.Web
{
    public class HtmlSelector : IHtmlSelector
    {
        public List<HtmlElement> Select(string html, string selector)
        {
            var cq = CQ.Create(html).Select(selector);

            var htmlTags = new List<HtmlElement>();

            foreach (var element in cq.Elements)
            {
                var htmlTag = new HtmlElement
                {
                    Type = element.Type,
                    Name = element.Name,
                };

                foreach (var pair in element.Attributes)
                {
                    htmlTag.Attributes.Add(new HtmlAttribute
                    {
                        Name = pair.Key,
                        Value = pair.Value
                    });
                }

                htmlTags.Add(htmlTag);
            }

            return htmlTags;
        }
    }
}