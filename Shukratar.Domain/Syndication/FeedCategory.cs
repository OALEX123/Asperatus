﻿using System.Collections.Generic;

namespace Shukratar.Domain.Syndication
{
    public class FeedCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Feed> Feeds { get; set; }
    }
}