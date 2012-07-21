using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Template.List.Data.Concrete.Infrastructure
{
    public class EmailTemplateListUnitOfWork : UnitOfWork, IEmailTemplateListUnitOfWork
    {
        public EmailTemplateListUnitOfWork(IEmailTemplateListDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
