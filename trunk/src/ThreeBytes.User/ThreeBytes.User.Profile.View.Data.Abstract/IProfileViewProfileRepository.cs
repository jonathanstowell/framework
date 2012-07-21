using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Profile.View.Entities;

namespace ThreeBytes.User.Profile.View.Data.Abstract
{
    public interface IProfileViewProfileRepository : IHistoricKeyedGenericRepository<UserProfileViewProfile>
    {
        bool UniqueEmail(Guid itemId, string email, string applicationName);
    }
}
