namespace Shukratar.Domain.Web
{
    public class WebPage
    {
        public const string AllowedContentType = "text/html";

        public const int MaxContentLength = 2000000;

        public string Uri { get; set; }

        public string Content { get; set; }

        public string ContentType { get; set; }

        public long? ContentLength { get; set; }

        public WebPageStatus? Status { get; set; }
    }
}
