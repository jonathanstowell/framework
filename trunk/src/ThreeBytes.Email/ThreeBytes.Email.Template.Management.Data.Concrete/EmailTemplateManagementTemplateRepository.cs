using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.Management.Data.Abstract;
using ThreeBytes.Email.Template.Management.Data.Abstract.Infrastructure;
using ThreeBytes.Email.Template.Management.Entities;

namespace ThreeBytes.Email.Template.Management.Data.Concrete
{
    public class EmailTemplateManagementTemplateRepository : KeyedGenericRepository<EmailTemplateManagementTemplate>, IEmailTemplateManagementTemplateRepository
    {
        public EmailTemplateManagementTemplateRepository(IEmailTemplateManagementDatabaseFactory databaseFactory, IEmailTemplateManagementUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public virtual bool UniqueTemplate(string name, string applicationName)
        {
            return Session.QueryOver<EmailTemplateManagementTemplate>().Where(x => x.Name == name && x.ApplicationName == applicationName).RowCount() == 0;
        }
    }
}
