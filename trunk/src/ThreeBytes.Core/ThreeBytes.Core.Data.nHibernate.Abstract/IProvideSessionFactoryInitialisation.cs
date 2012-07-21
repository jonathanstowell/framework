using NHibernate;

namespace ThreeBytes.Core.Data.nHibernate.Abstract
{
    public interface IProvideSessionFactoryInitialisation
    {
        ISessionFactory InitialiseSessionFactory();
    }
}
