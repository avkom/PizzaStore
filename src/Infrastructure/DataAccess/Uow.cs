using System;
using System.Collections.Generic;
using SimpleInjector;

namespace Infrastructure.DataAccess
{
    public class Uow: IUow, IAmbientUowProvider
    {
        private readonly Container _container;

        [ThreadStatic]
        private static IDictionary<Type, IDisposable> _uows;

        public Uow(Container container)
        {
            _container = container;
            _uows = new Dictionary<Type, IDisposable>();
        }

        public void Dispose()
        {
            foreach (KeyValuePair<Type, IDisposable> uow in _uows)
            {
                uow.Value.Dispose();
            }
        }

        public void Commit()
        {
            foreach (KeyValuePair<Type, IDisposable> uow in _uows)
            {
                ITransactional transactional = uow.Value as ITransactional;
                if (transactional != null)
                {
                    transactional.Commit();
                }
            }
        }

        public T Get<T>() where T : class, IDisposable
        {
            IDisposable uow;
            bool uowExists = _uows.TryGetValue(typeof(T), out uow);
            if (!uowExists)
            {
                uow = _container.GetInstance<T>();
                _uows[typeof(T)] = uow;
            }

            return (T)uow;
        }
    }
}
