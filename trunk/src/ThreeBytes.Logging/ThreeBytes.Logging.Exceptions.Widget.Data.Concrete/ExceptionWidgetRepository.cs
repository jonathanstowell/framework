using System.Collections.Generic;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Logging.Exceptions.Widget.Data.Abstract;
using ThreeBytes.Logging.Exceptions.Widget.Data.Abstract.Infrastructure;
using ThreeBytes.Logging.Exceptions.Widget.Entities;

namespace ThreeBytes.Logging.Exceptions.Widget.Data.Concrete
{
    public class ExceptionWidgetRepository : KeyedGenericRepository<ExceptionWidget>, IExceptionWidgetRepository
    {
        public ExceptionWidgetRepository(IExceptionWidgetDatabaseFactory databaseFactory, IExceptionWidgetUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public IList<ExceptionWidget> GetMostRecent(int take)
        {
            IList<ExceptionWidget> result = Session.QueryOver<ExceptionWidget>()
                .OrderBy(x => x.CreationDateTime).Desc
                .Take(take)
                .List();

            return result;
        }
    }
}
