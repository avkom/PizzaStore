using System;
using System.Collections.Generic;
using SimpleInjector;

namespace Infrastructure.DataAccess
{
    public class Uow : ReadOnlyUow, IUow
    {
        public Uow(Container container) : base(container)
        {
        }

        public void Commit()
        {
            foreach (KeyValuePair<Type, IDisposable> uow in Uows)
            {
                ITransactional transactional = uow.Value as ITransactional;
                if (transactional != null)
                {
                    transactional.Commit();
                }
            }
        }
    }
}
