namespace Infrastructure.DataAccess
{
    public interface IUowFactory
    {
        IUow Start();
    }
}
