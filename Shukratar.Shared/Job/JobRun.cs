using System;

namespace Shukratar.Shared.Job
{
    public class JobRun
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string OutputUrl { get; set; }
    }
}