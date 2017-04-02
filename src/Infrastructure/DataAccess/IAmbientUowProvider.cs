namespace Infrastructure.DataAccess
{
    public interface IAmbientUowProvider
    {
        T GetUow<T>() where T : class, IUow;
    }
}
