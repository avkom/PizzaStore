using System;
using System.Collections.Generic;
using System.Transactions;
using SimpleInjector;

namespace Infrastructure.DataAccess
{
    public class Uow : ReadOnlyUow, IUow
    {
        private readonly TransactionScope _transactionScope;

        public Uow(Container container, IsolationLevel isolationLevel) 
            : base(container)
        {
            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = isolationLevel
            };
            _transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
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
            _transactionScope.Complete();
        }

        public override void Dispose()
        {
            base.Dispose();
            _transactionScope.Dispose();
        }
    }
}
