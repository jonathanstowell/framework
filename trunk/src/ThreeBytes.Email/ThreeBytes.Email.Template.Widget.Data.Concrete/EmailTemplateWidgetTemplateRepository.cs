using System.Collections.Generic;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.Widget.Data.Abstract;
using ThreeBytes.Email.Template.Widget.Data.Abstract.Infrastructure;
using ThreeBytes.Email.Template.Widget.Entities;

namespace ThreeBytes.Email.Template.Widget.Data.Concrete
{
    public class EmailTemplateWidgetTemplateRepository : KeyedGenericRepository<EmailTemplateWidgetTemplate>, IEmailTemplateWidgetTemplateRepository
    {
        public EmailTemplateWidgetTemplateRepository(IEmailTemplateWidgetDatabaseFactory databaseFactory, IEmailTemplateWidgetUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public IList<EmailTemplateWidgetTemplate> GetMostRecent(int take, string applicationName)
        {
            IList<EmailTemplateWidgetTemplate> result = Session.QueryOver<EmailTemplateWidgetTemplate>()
                .Where(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.CreationDateTime).Desc
                .Take(take)
                .List();

            return result;
        }

        public virtual bool UniqueTemplate(string name, string applicationName)
        {
            return Session.QueryOver<EmailTemplateWidgetTemplate>().Where(x => x.Name == name && x.Subject == applicationName).RowCount() == 0;
        }
    }
}
