using System;
using NHibernate;

namespace ThreeBytes.Core.Data.nHibernate.Abstract
{
    public interface IDatabaseFactory : IDisposable
    {
        ISessionFactory SessionFactory { get; }
        ISession Session { get; }
    }
}
