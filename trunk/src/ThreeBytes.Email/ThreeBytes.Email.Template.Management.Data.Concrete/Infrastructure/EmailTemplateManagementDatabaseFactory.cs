using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Template.Management.Data.Concrete.Infrastructure
{
    public class EmailTemplateManagementDatabaseFactory : AbstractDatabaseFactoryBase, IEmailTemplateManagementDatabaseFactory
    {
        public EmailTemplateManagementDatabaseFactory(IProvideEmailTemplateManagementSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
