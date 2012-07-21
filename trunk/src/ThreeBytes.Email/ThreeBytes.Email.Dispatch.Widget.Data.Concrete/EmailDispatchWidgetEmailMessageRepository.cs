using System.Collections.Generic;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dispatch.Widget.Data.Abstract;
using ThreeBytes.Email.Dispatch.Widget.Data.Abstract.Infrastructure;
using ThreeBytes.Email.Dispatch.Widget.Entities;

namespace ThreeBytes.Email.Dispatch.Widget.Data.Concrete
{
    public class EmailDispatchWidgetEmailMessageRepository : KeyedGenericRepository<EmailDispatchWidgetEmailMessage>, IEmailDispatchWidgetEmailMessageRepository
    {
        public EmailDispatchWidgetEmailMessageRepository(IEmailDispatchWidgetDatabaseFactory databaseFactory, IEmailDispatchWidgetUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public IList<EmailDispatchWidgetEmailMessage> GetMostRecent(int take)
        {
            IList<EmailDispatchWidgetEmailMessage> result = Session.QueryOver<EmailDispatchWidgetEmailMessage>()
                .OrderBy(x => x.CreationDateTime).Desc
                .Take(take)
                .List();

            return result;
        }

        public IList<EmailDispatchWidgetEmailMessage> GetMostRecent(int take, string applicationName)
        {
            IList<EmailDispatchWidgetEmailMessage> result = Session.QueryOver<EmailDispatchWidgetEmailMessage>()
                .Where(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.CreationDateTime).Desc
                .Take(take)
                .List();

            return result;
        }
    }
}
