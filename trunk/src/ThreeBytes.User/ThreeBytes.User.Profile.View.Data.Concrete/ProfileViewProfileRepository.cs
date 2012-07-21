using System;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Profile.View.Data.Abstract;
using ThreeBytes.User.Profile.View.Data.Abstract.Infrastructure;
using ThreeBytes.User.Profile.View.Entities;

namespace ThreeBytes.User.Profile.View.Data.Concrete
{
    public class ProfileViewProfileRepository : HistoricKeyedGenericRepository<UserProfileViewProfile>, IProfileViewProfileRepository
    {
        public ProfileViewProfileRepository(IProfileViewDatabaseFactory databaseFactory, IProfileViewUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public bool UniqueEmail(Guid itemId, string email, string applicationName)
        {
            return Session.QueryOver<UserProfileViewProfile>().Where(x => x.Email == email && x.ApplicationName == applicationName && x.ItemId != itemId).RowCount() == 0;
        }
    }
}
