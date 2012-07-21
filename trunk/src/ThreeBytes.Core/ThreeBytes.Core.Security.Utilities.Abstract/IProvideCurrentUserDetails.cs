using System;

namespace ThreeBytes.Core.Security.Utilities.Abstract
{
    public interface IProvideCurrentUserDetails
    {
        string Username { get; }
        Guid UserId { get; }
        bool IsFromExternalProvider { get; }
        string ExternalProvider { get; }
    }
}
