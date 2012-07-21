using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.Widget.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Template.Widget.Data.Concrete.Infrastructure
{
    public class EmailTemplateWidgetDatabaseFactory : AbstractDatabaseFactoryBase, IEmailTemplateWidgetDatabaseFactory
    {
        public EmailTemplateWidgetDatabaseFactory(IProvideEmailTemplateWidgetSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
