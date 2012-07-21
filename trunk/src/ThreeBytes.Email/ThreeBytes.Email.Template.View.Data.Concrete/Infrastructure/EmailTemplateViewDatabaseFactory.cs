using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Template.View.Data.Concrete.Infrastructure
{
    public class EmailTemplateViewDatabaseFactory : AbstractDatabaseFactoryBase, IEmailTemplateViewDatabaseFactory
    {
        public EmailTemplateViewDatabaseFactory(IProvideEmailTemplateViewSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
