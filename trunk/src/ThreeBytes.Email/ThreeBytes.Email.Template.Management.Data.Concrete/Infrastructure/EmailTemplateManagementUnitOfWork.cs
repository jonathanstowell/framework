using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Template.Management.Data.Concrete.Infrastructure
{
    public class EmailTemplateManagementUnitOfWork : UnitOfWork, IEmailTemplateManagementUnitOfWork
    {
        public EmailTemplateManagementUnitOfWork(IEmailTemplateManagementDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
