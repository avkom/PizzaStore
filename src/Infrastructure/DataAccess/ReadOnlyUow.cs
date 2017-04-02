using System;
using System.Collections.Generic;
using SimpleInjector;

namespace Infrastructure.DataAccess
{
    public class ReadOnlyUow: IDisposable, IAmbientUowProvider
    {
        private readonly Container _container;

        [ThreadStatic]
        protected static IDictionary<Type, IDisposable> Uows;

        public ReadOnlyUow(Container container)
        {
            _container = container;
            Uows = new Dictionary<Type, IDisposable>();
        }

        public void Dispose()
        {
            foreach (KeyValuePair<Type, IDisposable> uow in Uows)
            {
                uow.Value.Dispose();
            }
            Uows.Clear();
        }

        public T Get<T>() where T : class, IDisposable
        {
            IDisposable uow;
            bool uowExists = Uows.TryGetValue(typeof(T), out uow);
            if (!uowExists)
            {
                uow = _container.GetInstance<T>();
                Uows[typeof(T)] = uow;
            }

            return (T)uow;
        }
    }
}
