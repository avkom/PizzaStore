using System;

namespace Infrastructure.DataAccess
{
    public interface IUow : IDisposable
    {
        void Commit();
    }
}
