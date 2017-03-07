namespace Shukratar.Domain.Html
{
    public class HtmlElement
    {
        public HtmlElement()
        {
            Attributes = new HtmlAttributesCollection();
        }

        public string Type { get; set; }

        public string Name { get; set; }

        public HtmlAttributesCollection Attributes { get; set; }
    }
}