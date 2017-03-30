namespace Shukratar.Shared.Job
{
    public enum JobRunState
    {
        Stopped,
        Running
    }

    public class Job
    {
        public string Name { get; set; }

        public string RunCommand { get; set; }

        public JobRun LatestRun { get; set; }

        public JobRunState RunState { get; set; }
    }
}