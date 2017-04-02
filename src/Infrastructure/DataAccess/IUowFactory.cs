using System;
using System.Transactions;

namespace Infrastructure.DataAccess
{
    public interface IUowFactory
    {
        IUow BeginUow();

        IUow BeginUow(IsolationLevel isolationLevel);

        IDisposable BeginReadOnlyUow();
    }
}
