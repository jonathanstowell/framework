using System;
using NHibernate;
using ThreeBytes.Core.Concrete;
using ThreeBytes.Core.Data.nHibernate.Abstract;

namespace ThreeBytes.Core.Data.nHibernate.Concrete
{
    public abstract class AbstractDatabaseFactoryBase : Disposable, IDatabaseFactory
    {
        private readonly IProvideSessionFactoryInitialisation provideSessionFactoryInitialisation;

        private ISessionFactory sessionFactory;
        private ISession session;

        protected AbstractDatabaseFactoryBase(IProvideSessionFactoryInitialisation provideSessionFactoryInitialisation)
        {
            if (provideSessionFactoryInitialisation == null)
                throw new ArgumentNullException("provideSessionFactoryInitialisation");

            this.provideSessionFactoryInitialisation = provideSessionFactoryInitialisation;
        }

        public ISessionFactory SessionFactory
        {
            get { return sessionFactory ?? (sessionFactory = provideSessionFactoryInitialisation.InitialiseSessionFactory()); }
        }

        public ISession Session
        {
            get { return session ?? (session = SessionFactory.OpenSession()); }
        }

        protected override void DisposeCore()
        {
            if (session != null)
            {
                if (session.IsOpen)
                    session.Close();

                session.Dispose();
            }

            if (sessionFactory != null)
            {
                sessionFactory.Close();
                sessionFactory.Dispose();
            }

            base.DisposeCore();
        }
    }
}
