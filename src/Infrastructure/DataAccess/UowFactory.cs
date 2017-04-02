using System;
using System.Transactions;
using SimpleInjector;

namespace Infrastructure.DataAccess
{
    public class UowFactory : IUowFactory
    {
        private readonly Container _container;

        public UowFactory(Container container)
        {
            _container = container;
        }

        public IUow BeginUow()
        {
            return new Uow(_container, IsolationLevel.ReadCommitted);
        }

        public IUow BeginUow(IsolationLevel isolationLevel)
        {
            return new Uow(_container, isolationLevel);
        }

        public IDisposable BeginReadOnlyUow()
        {
            return new ReadOnlyUow(_container);
        }
    }
}
