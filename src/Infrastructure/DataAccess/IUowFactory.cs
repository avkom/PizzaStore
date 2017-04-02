using System;

namespace Infrastructure.DataAccess
{
    public interface IUowFactory
    {
        IUow BeginUow();

        IDisposable BeginReadOnlyUow();
    }
}
