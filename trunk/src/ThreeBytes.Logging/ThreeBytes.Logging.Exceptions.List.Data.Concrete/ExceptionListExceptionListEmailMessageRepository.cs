using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Logging.Exceptions.List.Data.Abstract;
using ThreeBytes.Logging.Exceptions.List.Data.Abstract.Infrastructure;
using ThreeBytes.Logging.Exceptions.List.Entities;

namespace ThreeBytes.Logging.Exceptions.List.Data.Concrete
{
    public class ExceptionListExceptionListEmailMessageRepository : KeyedGenericRepository<ExceptionList>, IExceptionListEmailMessageRepository
    {
        public ExceptionListExceptionListEmailMessageRepository(IExceptionListDatabaseFactory databaseFactory, IExceptionListUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }
    }
}
