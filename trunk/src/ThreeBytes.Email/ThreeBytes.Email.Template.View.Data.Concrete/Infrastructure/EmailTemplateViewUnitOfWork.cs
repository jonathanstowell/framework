using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Template.View.Data.Concrete.Infrastructure
{
    public class EmailTemplateViewUnitOfWork : UnitOfWork, IEmailTemplateViewUnitOfWork
    {
        public EmailTemplateViewUnitOfWork(IEmailTemplateViewDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
