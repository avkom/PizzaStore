using System;
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
            return _container.GetInstance<IUow>();
        }

        public IDisposable BeginReadOnlyUow()
        {
            return _container.GetInstance<ReadOnlyUow>();
        }
    }
}
