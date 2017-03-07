namespace Shukratar.Shared.Job
{
    public class Job
    {
        public string Name { get; set; }

        public string RunCommand { get; set; }

        public JobRun LatestRun { get; set; }
    }
}