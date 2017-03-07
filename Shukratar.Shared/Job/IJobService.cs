namespace Shukratar.Shared.Job
{
    public interface IJobService
    {
        Job GetState();

        void Run();
    }
}