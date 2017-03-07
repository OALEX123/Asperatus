using System.Linq;

namespace Shukratar.Domain.News
{
    public interface IVideoNewsProvider
    {
        IQueryable<VideoNews> Get();
    }
}
