using System;
using NHibernate;
using ThreeBytes.Core.Concrete;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.nHibernate.Abstract;

namespace ThreeBytes.Core.Data.nHibernate.Concrete
{
    public class RepositoryBase : Disposable
    {
        #region Properties
        /// <summary>
        /// Database access through the data context
        /// </summary>
        private ISession session;
        private readonly IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork { get { return unitOfWork; } }

        /// <summary>
        /// Gets the database factory.
        /// </summary>
        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        protected ISession Session
        {
            get { return session ?? (session = DatabaseFactory.Session); }
        }
        #endregion

        #region Constructor
        public RepositoryBase(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
        {
            if (databaseFactory == null)
                throw new ArgumentNullException("databaseFactory");

            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            this.unitOfWork = unitOfWork;
            DatabaseFactory = databaseFactory;
        }
        #endregion

        protected void ReleaseCurrentSession()
        {
            if (session == null) return;

            if (session.IsOpen)
                session.Close();

            if (DatabaseFactory != null)
                DatabaseFactory.Dispose();

            session.Dispose();
            session = null;
        }

        protected override void DisposeCore()
        {
            if (session == null) return;

            if (session.IsOpen)
                session.Close();

            if (DatabaseFactory != null)
                DatabaseFactory.Dispose();

            session.Dispose();
            session = null;

            base.DisposeCore();
        }
    }
}
