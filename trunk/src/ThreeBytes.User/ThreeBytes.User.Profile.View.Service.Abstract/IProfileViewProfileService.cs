using System;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Profile.View.Entities;

namespace ThreeBytes.User.Profile.View.Service.Abstract
{
    public interface IProfileViewProfileService : IHistoricKeyedGenericService<UserProfileViewProfile>
    {
        bool UniqueEmail(Guid itemId, string email, string applicationName);
    }
}
