using System.Collections.ObjectModel;
using System.Linq;

namespace Shukratar.Domain.Html
{
    public class HtmlAttributesCollection : Collection<HtmlAttribute>
    {
        public HtmlAttribute this[string name]
        {
            get { return Items.FirstOrDefault(x => x.Name == name); }
        }
    }
}