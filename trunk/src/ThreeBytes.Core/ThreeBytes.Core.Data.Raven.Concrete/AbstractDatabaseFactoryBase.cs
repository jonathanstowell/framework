using System;
using Raven.Client;
using ThreeBytes.Core.Concrete;
using ThreeBytes.Core.Data.Raven.Abstract;

namespace ThreeBytes.Core.Data.Raven.Concrete
{
    public abstract class AbstractDatabaseFactoryBase : Disposable, IRavenDatabaseFactory
    {
        private readonly IProvideDocumentStoreInitialisation provideDocumentStoreInitialisation;

        private IDocumentStore documentStore;
        private IDocumentSession session;

        protected AbstractDatabaseFactoryBase(IProvideDocumentStoreInitialisation provideDocumentStoreInitialisation)
        {
            if (provideDocumentStoreInitialisation == null)
                throw new ArgumentNullException("provideDocumentStoreInitialisation");

            this.provideDocumentStoreInitialisation = provideDocumentStoreInitialisation;
        }

        public IDocumentStore DocumentStore
        {
            get { return documentStore ?? (documentStore = provideDocumentStoreInitialisation.DocumentStore); }
        }

        public IDocumentSession Session
        {
            get { return session ?? (session = DocumentStore.OpenSession()); }
        }

        protected override void DisposeCore()
        {
            if (session != null)
            {
                session.Dispose();
                session = null;
            }

            if (documentStore != null)
            {
                documentStore.Dispose();
                documentStore = null;
            }

            base.DisposeCore();
        }
    }
}
