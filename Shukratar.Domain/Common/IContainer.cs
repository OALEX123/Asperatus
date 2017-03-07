namespace Shukratar.Domain.Common
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}