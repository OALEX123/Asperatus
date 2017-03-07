using System;

namespace Shukratar.Domain.Web
{
    public interface IHttpClient
    {
        WebPage Get(Uri uri);
    }
}