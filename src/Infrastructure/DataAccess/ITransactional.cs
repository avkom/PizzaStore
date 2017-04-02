namespace Infrastructure.DataAccess
{
    public interface ITransactional
    {
        void Commit();
    }
}
