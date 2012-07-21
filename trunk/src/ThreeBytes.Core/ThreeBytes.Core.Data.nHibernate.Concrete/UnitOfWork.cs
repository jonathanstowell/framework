using System;
using System.Data;
using NHibernate;
using ThreeBytes.Core.Concrete;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.nHibernate.Abstract;

namespace ThreeBytes.Core.Data.nHibernate.Concrete
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private ISession _session;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected ISession Session
        {
            get { return _session ?? (_session = DatabaseFactory.Session); }
        }

        private ITransaction _transaction;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        public bool IsInTransaction
        {
            get { return _transaction != null; }
        }

        public void BeginTransaction()
        {
            if (!IsInTransaction)
                _transaction = Session.BeginTransaction();
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (!IsInTransaction)
                _transaction = Session.BeginTransaction();
        }

        /// <summary>
        /// Rolls the back transaction.
        /// </summary>
        public void RollBackTransaction()
        {
            _transaction.Rollback();
            Session.Clear();
        }

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        /// <exception cref="ApplicationException">Cannot roll back a transaction while there is no transaction running.</exception>
        public bool CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new ApplicationException("Cannot roll back a transaction while there is no transaction running.");
            }

            try
            {
                _transaction.Commit();
                return true;
            }
            catch
            {
                _transaction.Rollback();
                Session.Clear();
                return false;
            }
            finally
            {
                ReleaseCurrentTransaction();
            }
        }

        /// <summary>
        /// Releases the current transaction
        /// </summary>
        private void ReleaseCurrentTransaction()
        {
            if (_transaction == null) return;
            _transaction.Dispose();
            _transaction = null;
        }

        protected override void DisposeCore()
        {
            ReleaseCurrentTransaction();
            base.DisposeCore();
        }
    }
}
