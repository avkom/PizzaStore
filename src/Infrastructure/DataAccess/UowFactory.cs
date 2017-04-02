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

        public IUow Start()
        {
            return _container.GetInstance<IUow>();
        }
    }
}
