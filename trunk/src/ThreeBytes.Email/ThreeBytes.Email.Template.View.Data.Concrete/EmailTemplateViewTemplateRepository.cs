using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.View.Data.Abstract;
using ThreeBytes.Email.Template.View.Data.Abstract.Infrastructure;
using ThreeBytes.Email.Template.View.Entities;

namespace ThreeBytes.Email.Template.View.Data.Concrete
{
    public class EmailTemplateViewTemplateRepository : HistoricKeyedGenericRepository<EmailTemplateViewTemplate>, IEmailTemplateViewTemplateRepository
    {
        public EmailTemplateViewTemplateRepository(IEmailTemplateViewDatabaseFactory databaseFactory, IEmailTemplateViewUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public virtual bool UniqueTemplate(string name, string applicationName)
        {
            return Session.QueryOver<EmailTemplateViewTemplate>().Where(x => x.Name == name && x.ApplicationName == applicationName).RowCount() == 0;
        }
    }
}
