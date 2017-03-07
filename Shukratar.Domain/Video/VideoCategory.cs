using System.Collections.Generic;

namespace Shukratar.Domain.Video
{
    public class VideoCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Video> Videos { get; set; }
    }
}
