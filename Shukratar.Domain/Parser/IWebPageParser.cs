using Shukratar.Domain.Website;

namespace Shukratar.Domain.Parser
{
    public interface IWebPageParser
    {
        void Parse(NewsPage page);
    }
}