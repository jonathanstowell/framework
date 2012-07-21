using System.Data;
using Raven.Client;
using ThreeBytes.Core.Concrete;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.Raven.Abstract;

namespace ThreeBytes.Core.Data.Raven.Concrete
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private IDocumentSession session;

        protected IRavenDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected IDocumentSession Session
        {
            get { return session ?? (session = DatabaseFactory.Session); }
        }

        public UnitOfWork(IRavenDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        public bool IsInTransaction
        {
            get { return Session.Advanced.HasChanges; }
        }

        public void BeginTransaction()
        {
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
        }

        public void RollBackTransaction()
        {

        }

        public bool CommitTransaction()
        {
            try
            {
                Session.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                ReleaseCurrentTransaction();
            }
        }

        private void ReleaseCurrentTransaction()
        {
            if (session == null) return;
            session.Dispose();
            session = null;
        }

        protected override void DisposeCore()
        {
            ReleaseCurrentTransaction();
            base.DisposeCore();
        }
    }
}
