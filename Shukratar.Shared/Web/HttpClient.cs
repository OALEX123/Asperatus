using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Shukratar.Domain.Web;

namespace Shukratar.Shared.Web
{
    public class HttpClient : IHttpClient
    {
        private const string UserAgent = "Asperatusbot";
        private const int Timeout = 10000;

        public WebPage Get(Uri uri)
        {
            Trace.TraceInformation($"Request {uri.OriginalString}");

            var request = (HttpWebRequest) WebRequest.Create(uri);
            request.Accept = WebPage.AllowedContentType;
            request.Timeout = Timeout;
            request.UserAgent = UserAgent;

            var webPage = new WebPage {Uri = uri.OriginalString};

            try
            {
                var response = request.GetResponse();

                webPage.ContentLength = response.ContentLength;
                webPage.ContentType = response.ContentType;

                var stream = response.GetResponseStream();

                if (!response.ContentType.Contains(WebPage.AllowedContentType) ||
                    response.ContentLength > WebPage.MaxContentLength || stream == null)
                    return webPage;

                using (var reader = new StreamReader(stream))
                {
                    webPage.Content = reader.ReadToEnd();

                    return webPage;
                }
            }
            catch (WebException e)
            {
                Trace.TraceWarning("Unable to load '{0}' page: {1}", uri.OriginalString, e.Message);

                webPage.Status = (WebPageStatus) e.Status;

                webPage.ContentLength = e.Response?.ContentLength;
                webPage.ContentType = e.Response?.ContentType;

                return webPage;
            }
        }
    }
}