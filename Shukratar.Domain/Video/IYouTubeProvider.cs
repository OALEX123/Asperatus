namespace Shukratar.Domain.Video
{
    public interface IYouTubeProvider
    {
        Video Get(string id);
    }
}