using System;

namespace Infrastructure.DataAccess
{
    public interface IAmbientUowProvider
    {
        T Get<T>() where T : class, IDisposable;
    }
}
