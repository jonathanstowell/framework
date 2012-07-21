using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Profile.Management.Data.Abstract;
using ThreeBytes.User.Profile.Management.Data.Abstract.Infrastructure;
using ThreeBytes.User.Profile.Management.Entities;

namespace ThreeBytes.User.Profile.Management.Data.Concrete
{
    public class ProfileManagementProfileRepository : KeyedGenericRepository<UserProfileManagementProfile>, IProfileManagementProfileRepository
    {
        public ProfileManagementProfileRepository(IProfileManagementDatabaseFactory databaseFactory, IProfileManagementUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Session.QueryOver<UserProfileManagementProfile>().Where(x => x.Email == email && x.ApplicationName == applicationName).RowCount() == 0;
        }
    }
}
