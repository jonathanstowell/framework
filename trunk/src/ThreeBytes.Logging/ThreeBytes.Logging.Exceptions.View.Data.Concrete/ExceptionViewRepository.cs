using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Logging.Exceptions.View.Data.Abstract;
using ThreeBytes.Logging.Exceptions.View.Data.Abstract.Infrastructure;
using ThreeBytes.Logging.Exceptions.View.Entities;

namespace ThreeBytes.Logging.Exceptions.View.Data.Concrete
{
    public class ExceptionViewRepository : KeyedGenericRepository<ExceptionView>, IExceptionViewRepository
    {
        public ExceptionViewRepository(IExceptionViewDatabaseFactory databaseFactory, IExceptionViewUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }
    }
}
