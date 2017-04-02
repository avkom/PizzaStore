using System;
using System.Collections.Generic;
using SimpleInjector;

namespace Infrastructure.DataAccess
{
    public class Uow: IUow, IAmbientUowProvider
    {
        private readonly Container _container;

        [ThreadStatic]
        private static IDictionary<Type, IUow> _uows;

        public Uow(Container container)
        {
            _container = container;
            _uows = new Dictionary<Type, IUow>();
        }

        public void Dispose()
        {
            foreach (KeyValuePair<Type, IUow> uow in _uows)
            {
                uow.Value.Dispose();
            }
        }

        public void Commit()
        {
            foreach (KeyValuePair<Type, IUow> uow in _uows)
            {
                uow.Value.Commit();
            }
        }

        public T GetUow<T>() where T : class, IUow
        {
            IUow uow;
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
