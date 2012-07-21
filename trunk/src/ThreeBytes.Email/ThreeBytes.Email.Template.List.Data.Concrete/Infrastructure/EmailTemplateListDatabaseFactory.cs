using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Template.List.Data.Concrete.Infrastructure
{
    public class EmailTemplateListDatabaseFactory : AbstractDatabaseFactoryBase, IEmailTemplateListDatabaseFactory
    {
        public EmailTemplateListDatabaseFactory(IProvideEmailTemplateListSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
